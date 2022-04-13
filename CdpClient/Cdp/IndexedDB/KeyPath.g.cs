using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.IndexedDB;
/// <summary>
/// Key path.
/// </summary>
public sealed partial class KeyPath {
/// <summary>
/// Key path type.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum TypeEnum {
[EnumMember(Value = "null")] Null,
[EnumMember(Value = "string")] String,
[EnumMember(Value = "array")] Array,
}
[JsonPropertyName("type")]public TypeEnum Type{get;set;}
/// <summary>
/// String value.
/// </summary>
[JsonPropertyName("string")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? String{get;set;}
/// <summary>
/// Array value.
/// </summary>
[JsonPropertyName("array")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string[]? Array{get;set;}
}
