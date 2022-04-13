using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Debugger;
/// <summary>
/// Debug symbols available for a wasm script.
/// </summary>
public sealed partial class DebugSymbols {
/// <summary>
/// Type of the debug symbols.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum TypeEnum {
[EnumMember(Value = "None")] None,
[EnumMember(Value = "SourceMap")] SourceMap,
[EnumMember(Value = "EmbeddedDWARF")] EmbeddedDWARF,
[EnumMember(Value = "ExternalDWARF")] ExternalDWARF,
}
[JsonPropertyName("type")]public TypeEnum Type{get;set;}
/// <summary>
/// URL of the external symbol source.
/// </summary>
[JsonPropertyName("externalURL")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ExternalURL{get;set;}
}
