using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOMDebugger;
/// <summary>
/// Object event listener.
/// </summary>
public sealed partial class EventListener {
/// <summary>
/// `EventListener`'s type.
/// </summary>
[JsonPropertyName("type")]public string Type{get;set;}
/// <summary>
/// `EventListener`'s useCapture.
/// </summary>
[JsonPropertyName("useCapture")]public bool UseCapture{get;set;}
/// <summary>
/// `EventListener`'s passive flag.
/// </summary>
[JsonPropertyName("passive")]public bool Passive{get;set;}
/// <summary>
/// `EventListener`'s once flag.
/// </summary>
[JsonPropertyName("once")]public bool Once{get;set;}
/// <summary>
/// Script id of the handler code.
/// </summary>
[JsonPropertyName("scriptId")]public Runtime.ScriptId ScriptId{get;set;}
/// <summary>
/// Line number in the script (0-based).
/// </summary>
[JsonPropertyName("lineNumber")]public long LineNumber{get;set;}
/// <summary>
/// Column number in the script (0-based).
/// </summary>
[JsonPropertyName("columnNumber")]public long ColumnNumber{get;set;}
/// <summary>
/// Event handler function value.
/// </summary>
[JsonPropertyName("handler")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.RemoteObject? Handler{get;set;}
/// <summary>
/// Event original handler function value.
/// </summary>
[JsonPropertyName("originalHandler")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.RemoteObject? OriginalHandler{get;set;}
/// <summary>
/// Node the listener is added to (if any).
/// </summary>
[JsonPropertyName("backendNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? BackendNodeId{get;set;}
}
