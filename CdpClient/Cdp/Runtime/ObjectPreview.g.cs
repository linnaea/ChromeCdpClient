using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
/// <summary>
/// Object containing abbreviated remote object value.
/// </summary>
[Experimental]public sealed partial class ObjectPreview {
/// <summary>
/// Object type.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum TypeEnum {
[EnumMember(Value = "object")] Object,
[EnumMember(Value = "function")] Function,
[EnumMember(Value = "undefined")] Undefined,
[EnumMember(Value = "string")] String,
[EnumMember(Value = "number")] Number,
[EnumMember(Value = "boolean")] Boolean,
[EnumMember(Value = "symbol")] Symbol,
[EnumMember(Value = "bigint")] Bigint,
}
[JsonPropertyName("type")]public TypeEnum Type{get;set;}
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
/// <summary>
/// String representation of the object.
/// </summary>
[JsonPropertyName("description")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Description{get;set;}
/// <summary>
/// True iff some of the properties or entries of the original object did not fit.
/// </summary>
[JsonPropertyName("overflow")]public bool Overflow{get;set;}
/// <summary>
/// List of the properties.
/// </summary>
[JsonPropertyName("properties")]public PropertyPreview[] Properties{get;set;}
/// <summary>
/// List of the entries. Specified for `map` and `set` subtype values only.
/// </summary>
[JsonPropertyName("entries")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public EntryPreview[]? Entries{get;set;}
}
