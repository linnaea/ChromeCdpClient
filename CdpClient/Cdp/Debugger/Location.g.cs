using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Debugger;
/// <summary>
/// Location in the source code.
/// </summary>
public sealed partial class Location {
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
}
