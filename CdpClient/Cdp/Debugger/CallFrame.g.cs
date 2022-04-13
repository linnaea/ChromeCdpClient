using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Debugger;
/// <summary>
/// JavaScript call frame. Array of call frames form the call stack.
/// </summary>
public sealed partial class CallFrame {
/// <summary>
/// Call frame identifier. This identifier is only valid while the virtual machine is paused.
/// </summary>
[JsonPropertyName("callFrameId")]public CallFrameId CallFrameId{get;set;}
/// <summary>
/// Name of the JavaScript function called on this call frame.
/// </summary>
[JsonPropertyName("functionName")]public string FunctionName{get;set;}
/// <summary>
/// Location in the source code.
/// </summary>
[JsonPropertyName("functionLocation")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Location? FunctionLocation{get;set;}
/// <summary>
/// Location in the source code.
/// </summary>
[JsonPropertyName("location")]public Location Location{get;set;}
/// <summary>
/// JavaScript script name or url.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Scope chain for this call frame.
/// </summary>
[JsonPropertyName("scopeChain")]public Scope[] ScopeChain{get;set;}
/// <summary>
/// `this` object for this call frame.
/// </summary>
[JsonPropertyName("this")]public Runtime.RemoteObject This{get;set;}
/// <summary>
/// The value being returned, if the function is at return point.
/// </summary>
[JsonPropertyName("returnValue")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.RemoteObject? ReturnValue{get;set;}
}
