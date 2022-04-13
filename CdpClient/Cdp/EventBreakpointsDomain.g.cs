using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// EventBreakpoints permits setting breakpoints on particular operations and
/// events in targets that run JavaScript but do not have a DOM.
/// JavaScript execution will stop on these operations as if there was a regular
/// breakpoint set.
/// </summary>
[Experimental]public sealed partial class EventBreakpointsDomain {
private readonly ConnectedTarget _target;
public EventBreakpointsDomain(ConnectedTarget target) => _target = target;
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
public async Task SetInstrumentationBreakpoint(
 string @eventName) {
var resp = await _target.SendRequest("EventBreakpoints.setInstrumentationBreakpoint",
new SetInstrumentationBreakpointParams {
EventName=@eventName,});
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
public async Task RemoveInstrumentationBreakpoint(
 string @eventName) {
var resp = await _target.SendRequest("EventBreakpoints.removeInstrumentationBreakpoint",
new RemoveInstrumentationBreakpointParams {
EventName=@eventName,});
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
