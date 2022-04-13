using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Debugger;
public sealed partial class BreakLocation {
/// <summary>
/// Script identifier as reported in the `Debugger.scriptParsed`.
/// </summary>
[JsonPropertyName("scriptId")]public Runtime.ScriptId ScriptId{get;set;}
/// <summary>
/// Line number in the script (0-based).
/// </summary>
[JsonPropertyName("lineNumber")]public long LineNumber{get;set;}
/// <summary>
/// Column number in the script (0-based).
/// </summary>
[JsonPropertyName("columnNumber")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? ColumnNumber{get;set;}
[JsonConverter(typeof(StringEnumConverter))] public enum TypeEnum {
[EnumMember(Value = "debuggerStatement")] DebuggerStatement,
[EnumMember(Value = "call")] Call,
[EnumMember(Value = "return")] Return,
}
[JsonPropertyName("type")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public TypeEnum? Type{get;set;}
}
