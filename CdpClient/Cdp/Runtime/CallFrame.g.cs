using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
/// <summary>
/// Stack entry for runtime errors and assertions.
/// </summary>
public sealed partial class CallFrame {
/// <summary>
/// JavaScript function name.
/// </summary>
[JsonPropertyName("functionName")]public string FunctionName{get;set;}
/// <summary>
/// JavaScript script id.
/// </summary>
[JsonPropertyName("scriptId")]public ScriptId ScriptId{get;set;}
/// <summary>
/// JavaScript script name or url.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// JavaScript script line number (0-based).
/// </summary>
[JsonPropertyName("lineNumber")]public long LineNumber{get;set;}
/// <summary>
/// JavaScript script column number (0-based).
/// </summary>
[JsonPropertyName("columnNumber")]public long ColumnNumber{get;set;}
}
