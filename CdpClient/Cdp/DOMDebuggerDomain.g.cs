using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// DOM debugging allows setting breakpoints on particular DOM operations and events. JavaScript
/// execution will stop on these operations as if there was a regular breakpoint set.
/// </summary>
public sealed partial class DOMDebuggerDomain {
private readonly ConnectedTarget _target;
public DOMDebuggerDomain(ConnectedTarget target) => _target = target;
public sealed partial class GetEventListenersParams {
/// <summary>
/// Identifier of the object to return listeners for.
/// </summary>
[JsonPropertyName("objectId")]public Runtime.RemoteObjectId ObjectId{get;set;}
/// <summary>
/// The maximum depth at which Node children should be retrieved, defaults to 1. Use -1 for the
/// entire subtree or provide an integer larger than 0.
/// </summary>
[JsonPropertyName("depth")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Depth{get;set;}
/// <summary>
/// Whether or not iframes and shadow roots should be traversed when returning the subtree
/// (default is false). Reports listeners for all contexts if pierce is enabled.
/// </summary>
[JsonPropertyName("pierce")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Pierce{get;set;}
}
public sealed partial class GetEventListenersReturn {
/// <summary>
/// Array of relevant listeners.
/// </summary>
[JsonPropertyName("listeners")]public DOMDebugger.EventListener[] Listeners{get;set;}
}
/// <summary>
/// Returns event listeners of the given object.
/// </summary>
/// <param name="objectId">Identifier of the object to return listeners for.</param>
/// <param name="depth">The maximum depth at which Node children should be retrieved, defaults to 1. Use -1 for the
/// entire subtree or provide an integer larger than 0.</param>
/// <param name="pierce">Whether or not iframes and shadow roots should be traversed when returning the subtree
/// (default is false). Reports listeners for all contexts if pierce is enabled.</param>
public async Task<GetEventListenersReturn> GetEventListeners(
 Runtime.RemoteObjectId @objectId,long? @depth=default,bool? @pierce=default) {
var resp = await _target.SendRequest("DOMDebugger.getEventListeners",
new GetEventListenersParams {
ObjectId=@objectId,Depth=@depth,Pierce=@pierce,});
return _target.DeserializeResponse<GetEventListenersReturn>(resp);
}
public sealed partial class RemoveDOMBreakpointParams {
/// <summary>
/// Identifier of the node to remove breakpoint from.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// Type of the breakpoint to remove.
/// </summary>
[JsonPropertyName("type")]public DOMDebugger.DOMBreakpointType Type{get;set;}
}
/// <summary>
/// Removes DOM breakpoint that was set using `setDOMBreakpoint`.
/// </summary>
/// <param name="nodeId">Identifier of the node to remove breakpoint from.</param>
/// <param name="type">Type of the breakpoint to remove.</param>
public async Task RemoveDOMBreakpoint(
 DOM.NodeId @nodeId,DOMDebugger.DOMBreakpointType @type) {
var resp = await _target.SendRequest("DOMDebugger.removeDOMBreakpoint",
new RemoveDOMBreakpointParams {
NodeId=@nodeId,Type=@type,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class RemoveEventListenerBreakpointParams {
/// <summary>
/// Event name.
/// </summary>
[JsonPropertyName("eventName")]public string EventName{get;set;}
/// <summary>
/// EventTarget interface name.
/// </summary>
[Experimental][JsonPropertyName("targetName")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? TargetName{get;set;}
}
/// <summary>
/// Removes breakpoint on particular DOM event.
/// </summary>
/// <param name="eventName">Event name.</param>
/// <param name="targetName">EXPERIMENTAL EventTarget interface name.</param>
public async Task RemoveEventListenerBreakpoint(
 string @eventName,string? @targetName=default) {
var resp = await _target.SendRequest("DOMDebugger.removeEventListenerBreakpoint",
new RemoveEventListenerBreakpointParams {
EventName=@eventName,TargetName=@targetName,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class RemoveInstrumentationBreakpointParams {
/// <summary>
/// Instrumentation name to stop on.
/// </summary>
[JsonPropertyName("eventName")]public string EventName{get;set;}
}
/// <summary>
/// Removes breakpoint on particular native event.
/// </summary>
/// <param name="eventName">Instrumentation name to stop on.</param>
[Experimental]public async Task RemoveInstrumentationBreakpoint(
 string @eventName) {
var resp = await _target.SendRequest("DOMDebugger.removeInstrumentationBreakpoint",
new RemoveInstrumentationBreakpointParams {
EventName=@eventName,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class RemoveXHRBreakpointParams {
/// <summary>
/// Resource URL substring.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
}
/// <summary>
/// Removes breakpoint from XMLHttpRequest.
/// </summary>
/// <param name="url">Resource URL substring.</param>
public async Task RemoveXHRBreakpoint(
 string @url) {
var resp = await _target.SendRequest("DOMDebugger.removeXHRBreakpoint",
new RemoveXHRBreakpointParams {
Url=@url,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetBreakOnCSPViolationParams {
/// <summary>
/// CSP Violations to stop upon.
/// </summary>
[JsonPropertyName("violationTypes")]public DOMDebugger.CSPViolationType[] ViolationTypes{get;set;}
}
/// <summary>
/// Sets breakpoint on particular CSP violations.
/// </summary>
/// <param name="violationTypes">CSP Violations to stop upon.</param>
[Experimental]public async Task SetBreakOnCSPViolation(
 DOMDebugger.CSPViolationType[] @violationTypes) {
var resp = await _target.SendRequest("DOMDebugger.setBreakOnCSPViolation",
new SetBreakOnCSPViolationParams {
ViolationTypes=@violationTypes,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetDOMBreakpointParams {
/// <summary>
/// Identifier of the node to set breakpoint on.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// Type of the operation to stop upon.
/// </summary>
[JsonPropertyName("type")]public DOMDebugger.DOMBreakpointType Type{get;set;}
}
/// <summary>
/// Sets breakpoint on particular operation with DOM.
/// </summary>
/// <param name="nodeId">Identifier of the node to set breakpoint on.</param>
/// <param name="type">Type of the operation to stop upon.</param>
public async Task SetDOMBreakpoint(
 DOM.NodeId @nodeId,DOMDebugger.DOMBreakpointType @type) {
var resp = await _target.SendRequest("DOMDebugger.setDOMBreakpoint",
new SetDOMBreakpointParams {
NodeId=@nodeId,Type=@type,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetEventListenerBreakpointParams {
/// <summary>
/// DOM Event name to stop on (any DOM event will do).
/// </summary>
[JsonPropertyName("eventName")]public string EventName{get;set;}
/// <summary>
/// EventTarget interface name to stop on. If equal to `"*"` or not provided, will stop on any
/// EventTarget.
/// </summary>
[Experimental][JsonPropertyName("targetName")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? TargetName{get;set;}
}
/// <summary>
/// Sets breakpoint on particular DOM event.
/// </summary>
/// <param name="eventName">DOM Event name to stop on (any DOM event will do).</param>
/// <param name="targetName">EXPERIMENTAL EventTarget interface name to stop on. If equal to `"*"` or not provided, will stop on any
/// EventTarget.</param>
public async Task SetEventListenerBreakpoint(
 string @eventName,string? @targetName=default) {
var resp = await _target.SendRequest("DOMDebugger.setEventListenerBreakpoint",
new SetEventListenerBreakpointParams {
EventName=@eventName,TargetName=@targetName,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetInstrumentationBreakpointParams {
/// <summary>
/// Instrumentation name to stop on.
/// </summary>
[JsonPropertyName("eventName")]public string EventName{get;set;}
}
/// <summary>
/// Sets breakpoint on particular native event.
/// </summary>
/// <param name="eventName">Instrumentation name to stop on.</param>
[Experimental]public async Task SetInstrumentationBreakpoint(
 string @eventName) {
var resp = await _target.SendRequest("DOMDebugger.setInstrumentationBreakpoint",
new SetInstrumentationBreakpointParams {
EventName=@eventName,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetXHRBreakpointParams {
/// <summary>
/// Resource URL substring. All XHRs having this substring in the URL will get stopped upon.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
}
/// <summary>
/// Sets breakpoint on XMLHttpRequest.
/// </summary>
/// <param name="url">Resource URL substring. All XHRs having this substring in the URL will get stopped upon.</param>
public async Task SetXHRBreakpoint(
 string @url) {
var resp = await _target.SendRequest("DOMDebugger.setXHRBreakpoint",
new SetXHRBreakpointParams {
Url=@url,});
_target.DeserializeResponse<VoidData>(resp);
}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
default:
_onUnknownEvent?.Invoke(method, data);
break;
}}
private Action<string, ArraySegment<byte>>? _onUnknownEvent;
public event Action<string, ArraySegment<byte>> OnUnknownEvent {
add => _onUnknownEvent += value; remove => _onUnknownEvent -= value;}
public void DisconnectEvents() {
_onUnknownEvent = null;
}
}
