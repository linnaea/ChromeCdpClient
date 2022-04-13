using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// Reporting of performance timeline events, as specified in
/// https://w3c.github.io/performance-timeline/#dom-performanceobserver.
/// </summary>
[Experimental]public sealed partial class PerformanceTimelineDomain {
private readonly ConnectedTarget _target;
public PerformanceTimelineDomain(ConnectedTarget target) => _target = target;
public sealed partial class EnableParams {
/// <summary>
/// The types of event to report, as specified in
/// https://w3c.github.io/performance-timeline/#dom-performanceentry-entrytype
/// The specified filter overrides any previous filters, passing empty
/// filter disables recording.
/// Note that not all types exposed to the web platform are currently supported.
/// </summary>
[JsonPropertyName("eventTypes")]public string[] EventTypes{get;set;}
}
/// <summary>
/// Previously buffered events would be reported before method returns.
/// See also: timelineEventAdded
/// </summary>
/// <param name="eventTypes">The types of event to report, as specified in
/// https://w3c.github.io/performance-timeline/#dom-performanceentry-entrytype
/// The specified filter overrides any previous filters, passing empty
/// filter disables recording.
/// Note that not all types exposed to the web platform are currently supported.</param>
public async Task Enable(
 string[] @eventTypes) {
var resp = await _target.SendRequest("PerformanceTimeline.enable",
new EnableParams {
EventTypes=@eventTypes,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class TimelineEventAddedParams {
[JsonPropertyName("event")]public PerformanceTimeline.TimelineEvent Event{get;set;}
}
private Action<TimelineEventAddedParams>? _onTimelineEventAdded;
/// <summary>
/// Sent when a performance timeline event is added. See reportPerformanceTimeline method.
/// </summary>
public event Action<TimelineEventAddedParams> OnTimelineEventAdded {
add => _onTimelineEventAdded += value; remove => _onTimelineEventAdded -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "PerformanceTimeline.timelineEventAdded":
_onTimelineEventAdded?.Invoke(_target.DeserializeEvent<TimelineEventAddedParams>(data));
break;
default:
_onUnknownEvent?.Invoke(method, data);
break;
}}
private Action<string, ArraySegment<byte>>? _onUnknownEvent;
public event Action<string, ArraySegment<byte>> OnUnknownEvent {
add => _onUnknownEvent += value; remove => _onUnknownEvent -= value;}
public void DisconnectEvents() {
_onUnknownEvent = null;
_onTimelineEventAdded = null;
}
}
