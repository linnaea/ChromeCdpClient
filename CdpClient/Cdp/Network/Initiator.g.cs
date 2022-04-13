using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Information about the request initiator.
/// </summary>
public sealed partial class Initiator {
/// <summary>
/// Type of this initiator.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum TypeEnum {
[EnumMember(Value = "parser")] Parser,
[EnumMember(Value = "script")] Script,
[EnumMember(Value = "preload")] Preload,
[EnumMember(Value = "SignedExchange")] SignedExchange,
[EnumMember(Value = "preflight")] Preflight,
[EnumMember(Value = "other")] Other,
}
[JsonPropertyName("type")]public TypeEnum Type{get;set;}
/// <summary>
/// Initiator JavaScript stack trace, set for Script only.
/// </summary>
[JsonPropertyName("stack")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.StackTrace? Stack{get;set;}
/// <summary>
/// Initiator URL, set for Parser type or for Script type (when script is importing module) or for SignedExchange type.
/// </summary>
[JsonPropertyName("url")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Url{get;set;}
/// <summary>
/// Initiator line number, set for Parser type or for Script type (when script is importing
/// module) (0-based).
/// </summary>
[JsonPropertyName("lineNumber")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? LineNumber{get;set;}
/// <summary>
/// Initiator column number, set for Parser type or for Script type (when script is importing
/// module) (0-based).
/// </summary>
[JsonPropertyName("columnNumber")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? ColumnNumber{get;set;}
/// <summary>
/// Set if another request triggered this request (e.g. preflight).
/// </summary>
[JsonPropertyName("requestId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public RequestId? RequestId{get;set;}
}
