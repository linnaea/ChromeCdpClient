using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using CdpCodeGen;

const string rootNameSpace = "CdpClient";
Directory.CreateDirectory(rootNameSpace);
var domains = new List<CdpDomainDef>();
foreach (var protoFile in new[] {"js_protocol.json", "browser_protocol.json"}) {
    using var protoStream = File.OpenRead(Path.Combine("devtools-protocol", "json", protoFile));
    domains.AddRange(EmitProtocol(await JsonSerializer.DeserializeAsync<CdpProtocolDef>(
                                      protoStream, new JsonSerializerOptions())));
}

using var client = File.CreateText(Path.Combine(rootNameSpace, "ConnectedTarget.g.cs"));
WriteFileHeader(client);
client.WriteLine($"namespace {rootNameSpace};");
client.WriteLine("partial class ConnectedTarget {");
foreach (var domain in domains) {
    client.WriteLine($"private Cdp.{domain.Domain}Domain? _dom{domain.Domain};");
    client.WriteLine($"public Cdp.{domain.Domain}Domain {domain.Domain} {{get{{");
    client.WriteLine($"if(_dom{domain.Domain} != null) return _dom{domain.Domain};");
    client.WriteLine($"var a = new Cdp.{domain.Domain}Domain(this);");
    client.WriteLine($"var b = Interlocked.CompareExchange(ref _dom{domain.Domain}, a, null);");
    client.WriteLine("return b ?? a;}}");
}

client.WriteLine("");
client.WriteLine("partial void DispatchEvent(string method, ArraySegment<byte> data) {");
client.WriteLine("switch(method.Split('.')[0]) {");
foreach (var domain in domains) {
    client.WriteLine($"case \"{domain.Domain}\":");
    client.WriteLine($"_dom{domain.Domain}?.DispatchEvent(method, data);");
    client.WriteLine("break;");
}
client.WriteLine("default:");
client.WriteLine("_onUnknownEvent?.Invoke(method, data);");
client.WriteLine("break;");
client.WriteLine("}}");

client.WriteLine("private Action<string, ArraySegment<byte>>? _onUnknownEvent;");
client.WriteLine("public event Action<string, ArraySegment<byte>> OnUnknownEvent {");
client.WriteLine("add => _onUnknownEvent += value; remove => _onUnknownEvent -= value;}");

client.WriteLine("partial void DisconnectEvents() {");
client.WriteLine("_onUnknownEvent = null;");
foreach (var domain in domains) {
    client.WriteLine($"_dom{domain.Domain}?.DisconnectEvents();");
    client.WriteLine($"_dom{domain.Domain} = null;");
}
client.WriteLine("}");

client.WriteLine("}");

IEnumerable<CdpDomainDef> EmitProtocol(CdpProtocolDef protocol)
{
    foreach (var domain in protocol.Domains) {
        WriteDomain(domain);
    }

    return protocol.Domains;
}

void WriteDomain(CdpDomainDef domain)
{
    Directory.CreateDirectory(Path.Combine(rootNameSpace, "Cdp", domain.Domain));
    foreach (var type in domain.Types) {
        WriteType(domain.Domain, type);
    }

    using var os = File.CreateText(Path.Combine(rootNameSpace, "Cdp", $"{domain.Domain}Domain.g.cs"));
    WriteFileHeader(os);
    os.WriteLine($"namespace {rootNameSpace}.Cdp;");
    WriteMetadata(domain.Deprecated, domain.Experimental, null, domain.Description, os);
    os.WriteLine($"public sealed partial class {domain.Domain}Domain {{");
    os.WriteLine("private readonly ConnectedTarget _target;");
    os.WriteLine($"public {domain.Domain}Domain(ConnectedTarget target) => _target = target;");
    foreach (var cmd in domain.Commands) {
        WriteCommand(domain.Domain, cmd, os);
    }

    foreach (var ev in domain.Events) {
        WriteEvent(domain.Domain, ev, os);
    }

    os.WriteLine("public void DispatchEvent(string method, ArraySegment<byte> data) {");
    os.WriteLine("switch (method) {");
    foreach (var ev in domain.Events) {
        var eventName = UpperCamelCase(ev.Name);
        os.WriteLine($"case \"{domain.Domain}.{ev.Name}\":");
        os.Write($"_on{eventName}?.Invoke(");
        if (ev.Parameters.Length > 0) {
            os.Write($"_target.DeserializeEvent<{eventName}Params>(data)");
        }

        os.WriteLine(");");
        os.WriteLine("break;");
    }

    os.WriteLine("default:");
    os.WriteLine("_onUnknownEvent?.Invoke(method, data);");
    os.WriteLine("break;");
    os.WriteLine("}}");

    os.WriteLine("private Action<string, ArraySegment<byte>>? _onUnknownEvent;");
    os.WriteLine("public event Action<string, ArraySegment<byte>> OnUnknownEvent {");
    os.WriteLine("add => _onUnknownEvent += value; remove => _onUnknownEvent -= value;}");

    os.WriteLine("public void DisconnectEvents() {");
    os.WriteLine("_onUnknownEvent = null;");
    foreach (var ev in domain.Events) {
        os.WriteLine($"_on{UpperCamelCase(ev.Name)} = null;");
    }

    os.WriteLine("}");

    os.WriteLine("}");
}

void WriteCommand(string domain, CdpCommandDef command, TextWriter os)
{
    var commandName = UpperCamelCase(command.Name);
    var returnType = "";
    if (command.Parameters.Length > 0) {
        os.WriteLine($"public sealed partial class {commandName}Params {{");
        foreach (var prop in command.Parameters) {
            WriteProperty(domain, prop, os);
        }
        os.WriteLine("}");
    }
    if (command.Returns.Length > 0) {
        os.WriteLine($"public sealed partial class {commandName}Return {{");
        foreach (var prop in command.Returns) {
            WriteProperty(domain, prop, os);
        }
        os.WriteLine("}");
        returnType = $"<{commandName}Return>";
    }

    WriteMetadata(false, false, null, command.Description, os);
    foreach (var param in command.Parameters) {
        os.Write($"/// <param name=\"{param.Name}\">");
        if(param.Deprecated) os.Write("OBSOLETE ");
        if(param.Experimental) os.Write("EXPERIMENTAL ");

        var lines = param.Description.Split('\n');
        os.Write(lines[0]);
        if (lines.Length > 1) {
            os.WriteLine();
            for (var i = 1; i < lines.Length - 1; i++) {
                os.WriteLine($"/// {lines[i]}");
            }
            os.Write($"/// {lines[lines.Length - 1]}");
        }
        os.WriteLine("</param>");
    }
    WriteMetadata(command.Deprecated, command.Experimental, command.Redirect, null, os);
    os.WriteLine($"public async Task{returnType} {commandName}(");
    var sep = ' ';
    foreach (var param in command.Parameters.OrderBy(v => v.Optional)) {
        os.Write(sep);
        var backingType = TranslateType(domain, param.TypeRef, param.Type, param.Items);
        if (backingType == "string" && param.Enum != null) {
            backingType = $"{commandName}Params.{UpperCamelCase(param.Name)}Enum";
        }
        os.Write(backingType);
        if(param.Optional) os.Write('?');
        os.Write(" @");
        os.Write(param.Name);
        if(param.Optional) os.Write("=default");
        sep = ',';
    }
    os.WriteLine(") {");
    os.WriteLine($"var resp = await _target.SendRequest(\"{domain}.{command.Name}\",");
    if (command.Parameters.Length > 0) {
        os.WriteLine($"new {commandName}Params {{");
        foreach (var param in command.Parameters) {
            os.Write($"{UpperCamelCase(param.Name)}=@{param.Name},");
        }
        os.Write("}");
    } else {
        os.Write("VoidData.Instance");
    }
    os.WriteLine(");");

    if (returnType != "") {
        os.WriteLine($"return _target.DeserializeResponse{returnType}(resp);");
    } else {
        os.WriteLine("_target.DeserializeResponse<VoidData>(resp);");
    }
    os.WriteLine("}");
}

void WriteEvent(string domain, CdpCommandDef ev, TextWriter os)
{
    var eventName = UpperCamelCase(ev.Name);
    var typeParam = "";
    if (ev.Parameters.Length > 0) {
        os.WriteLine($"public sealed partial class {eventName}Params {{");
        foreach (var prop in ev.Parameters) {
            WriteProperty(domain, prop, os);
        }
        os.WriteLine("}");
        typeParam = $"<{eventName}Params>";
    }

    os.WriteLine($"private Action{typeParam}? _on{eventName};");
    WriteMetadata(ev.Deprecated, ev.Experimental, ev.Redirect, ev.Description, os);
    os.WriteLine($"public event Action{typeParam} On{eventName} {{");
    os.WriteLine($"add => _on{eventName} += value; remove => _on{eventName} -= value;}}");
}

void WriteType(string domain, CdpTypeDef type)
{
    using var os = File.CreateText(Path.Combine(rootNameSpace, "Cdp", domain, $"{type.Id}.g.cs"));
    WriteFileHeader(os);
    os.WriteLine($"namespace {rootNameSpace}.Cdp.{domain};");
    WriteMetadata(type.Deprecated, type.Experimental, null, type.Description, os);

    switch (type.Type) {
    case "string":
        if (type.Enum == null) {
            goto default;
        }

        WriteEnumType(type.Id, type.Enum, os);
        break;
    case "object":
        os.WriteLine($"public sealed partial class {type.Id} {{");
        foreach (var prop in type.Properties) {
            WriteProperty(null, prop, os);
        }

        os.WriteLine("}");
        break;
    default:
        var backingType = TranslateType(null, null, type.Type, type.Items);
        os.WriteLine("[JsonConverter(typeof(AliasedTypeValueConverter))]");
        os.WriteLine($"public partial struct {type.Id} {{");
        os.WriteLine($"public {backingType} Value {{get;set;}}");
        os.WriteLine($"public static implicit operator {backingType}({type.Id} v) => v.Value;");
        os.WriteLine($"public static implicit operator {type.Id}({backingType} v) => new() {{Value=v}};");
        os.WriteLine("}");
        break;
    }
}

void WriteProperty(string domain, CdpPropertyDef prop, TextWriter os)
{
    WriteMetadata(prop.Deprecated, prop.Experimental, null, prop.Description, os);
    var backingType = TranslateType(domain, prop.TypeRef, prop.Type, prop.Items);
    if (prop.Enum != null && backingType == "string") {
        backingType = $"{UpperCamelCase(prop.Name)}Enum";
        WriteEnumType(backingType, prop.Enum, os);
    }

    os.Write($"[JsonPropertyName(\"{prop.Name}\")]");
    if (prop.Optional)
        os.WriteLine("[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]");
    os.Write("public ");
    os.Write(backingType);
    if (prop.Optional) os.Write('?');
    os.Write(' ');
    os.Write(UpperCamelCase(prop.Name));
    os.WriteLine("{get;set;}");
}

void WriteEnumType(string typeName, string[] enums, TextWriter os)
{
    os.WriteLine($"[JsonConverter(typeof(StringEnumConverter))] public enum {typeName} {{");
    foreach (var enumValue in enums) {
        os.WriteLine($"[EnumMember(Value = \"{enumValue}\")] {UpperCamelCase(enumValue)},");
    }

    os.WriteLine("}");
}

void WriteMetadata(bool deprecated, bool experimental, string redirect, string desc, TextWriter os)
{
    if (!string.IsNullOrWhiteSpace(desc)) {
        os.WriteLine("/// <summary>");
        foreach (var line in desc.Split('\n'))
            os.WriteLine("/// " + line.Trim('\r'));

        os.WriteLine("/// </summary>");
    }
    
    if (experimental)
        os.Write("[Experimental]");
    
    if (deprecated) {
        os.Write("[Obsolete");
        if (redirect != null) {
            os.Write($"(\"{redirect}\")");
        }

        os.Write(']');
    }
}

string TranslateType(string domain, string typeRef, string type, CdpArrayItemDef array)
{
    if (type == "array" && array != null) {
        return TranslateType(domain, array.TypeRef, array.Type, null) + "[]";
    }

    if (typeRef != null) {
        return typeRef.Contains('.') || domain == null ? typeRef : $"{domain}.{typeRef}";
    }

    return type switch {
        "string" => "string",
        "boolean" => "bool",
        "integer" => "long",
        "number" => "double",
        "object" => "object",
        "any" => "object",
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };
}

string UpperCamelCase(string v)
{
    if (v.Length < 2) return v.ToUpperInvariant();
    if (v.Contains('-')) {
        var parts = v.Split('-');
        for (var i = 0; i < parts.Length; i++) {
            parts[i] = UpperCamelCase(parts[i]);
        }

        return string.Join("", parts);
    }
    return $"{char.ToUpperInvariant(v[0])}{v.Substring(1)}";
}

void WriteFileHeader(TextWriter os)
{
    os.WriteLine("using System;");
    os.WriteLine("using System.Threading;");
    os.WriteLine("using System.Threading.Tasks;");
    os.WriteLine("using System.Runtime.Serialization;");
    os.WriteLine("using System.Text.Json.Serialization;");
    os.WriteLine("#pragma warning disable 8618,0612");
    os.WriteLine("#nullable enable");
}
