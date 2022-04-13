using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
[Experimental]public sealed partial class PropertyPreview {
/// <summary>
/// Property name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Object type. Accessor means that the property itself is an accessor property.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum TypeEnum {
[EnumMember(Value = "object")] Object,
[EnumMember(Value = "function")] Function,
[EnumMember(Value = "undefined")] Undefined,
[EnumMember(Value = "string")] String,
[EnumMember(Value = "number")] Number,
[EnumMember(Value = "boolean")] Boolean,
[EnumMember(Value = "symbol")] Symbol,
[EnumMember(Value = "accessor")] Accessor,
[EnumMember(Value = "bigint")] Bigint,
}
[JsonPropertyName("type")]public TypeEnum Type{get;set;}
/// <summary>
/// User-friendly property value string.
/// </summary>
[JsonPropertyName("value")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Value{get;set;}
/// <summary>
/// Nested value preview.
/// </summary>
[JsonPropertyName("valuePreview")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public ObjectPreview? ValuePreview{get;set;}
/// <summary>
/// Object subtype hint. Specified for `object` type values only.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum SubtypeEnum {
[EnumMember(Value = "array")] Array,
[EnumMember(Value = "null")] Null,
[EnumMember(Value = "node")] Node,
[EnumMember(Value = "regexp")] Regexp,
[EnumMember(Value = "date")] Date,
[EnumMember(Value = "map")] Map,
[EnumMember(Value = "set")] Set,
[EnumMember(Value = "weakmap")] Weakmap,
[EnumMember(Value = "weakset")] Weakset,
[EnumMember(Value = "iterator")] Iterator,
[EnumMember(Value = "generator")] Generator,
[EnumMember(Value = "error")] Error,
[EnumMember(Value = "proxy")] Proxy,
[EnumMember(Value = "promise")] Promise,
[EnumMember(Value = "typedarray")] Typedarray,
[EnumMember(Value = "arraybuffer")] Arraybuffer,
[EnumMember(Value = "dataview")] Dataview,
[EnumMember(Value = "webassemblymemory")] Webassemblymemory,
[EnumMember(Value = "wasmvalue")] Wasmvalue,
}
[JsonPropertyName("subtype")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public SubtypeEnum? Subtype{get;set;}
}
