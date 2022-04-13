using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
/// <summary>
/// Mirror object referencing original JavaScript object.
/// </summary>
public sealed partial class RemoteObject {
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
/// NOTE: If you change anything here, make sure to also update
/// `subtype` in `ObjectPreview` and `PropertyPreview` below.
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
/// Object class (constructor) name. Specified for `object` type values only.
/// </summary>
[JsonPropertyName("className")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ClassName{get;set;}
/// <summary>
/// Remote object value in case of primitive values or JSON values (if it was requested).
/// </summary>
[JsonPropertyName("value")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public object? Value{get;set;}
/// <summary>
/// Primitive value which can not be JSON-stringified does not have `value`, but gets this
/// property.
/// </summary>
[JsonPropertyName("unserializableValue")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public UnserializableValue? UnserializableValue{get;set;}
/// <summary>
/// String representation of the object.
/// </summary>
[JsonPropertyName("description")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Description{get;set;}
/// <summary>
/// Unique object identifier (for non-primitive values).
/// </summary>
[JsonPropertyName("objectId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public RemoteObjectId? ObjectId{get;set;}
/// <summary>
/// Preview containing abbreviated property values. Specified for `object` type values only.
/// </summary>
[Experimental][JsonPropertyName("preview")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public ObjectPreview? Preview{get;set;}
[Experimental][JsonPropertyName("customPreview")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CustomPreview? CustomPreview{get;set;}
}
