using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.IndexedDB;
/// <summary>
/// Key.
/// </summary>
public sealed partial class Key {
/// <summary>
/// Key type.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum TypeEnum {
[EnumMember(Value = "number")] Number,
[EnumMember(Value = "string")] String,
[EnumMember(Value = "date")] Date,
[EnumMember(Value = "array")] Array,
}
[JsonPropertyName("type")]public TypeEnum Type{get;set;}
/// <summary>
/// Number value.
/// </summary>
[JsonPropertyName("number")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Number{get;set;}
/// <summary>
/// String value.
/// </summary>
[JsonPropertyName("string")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? String{get;set;}
/// <summary>
/// Date value.
/// </summary>
[JsonPropertyName("date")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Date{get;set;}
/// <summary>
/// Array value.
/// </summary>
[JsonPropertyName("array")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Key[]? Array{get;set;}
}
