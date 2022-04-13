using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.PerformanceTimeline;
public sealed partial class TimelineEvent {
/// <summary>
/// Identifies the frame that this event is related to. Empty for non-frame targets.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// The event type, as specified in https://w3c.github.io/performance-timeline/#dom-performanceentry-entrytype
/// This determines which of the optional "details" fiedls is present.
/// </summary>
[JsonPropertyName("type")]public string Type{get;set;}
/// <summary>
/// Name may be empty depending on the type.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Time in seconds since Epoch, monotonically increasing within document lifetime.
/// </summary>
[JsonPropertyName("time")]public Network.TimeSinceEpoch Time{get;set;}
/// <summary>
/// Event duration, if applicable.
/// </summary>
[JsonPropertyName("duration")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Duration{get;set;}
[JsonPropertyName("lcpDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public LargestContentfulPaint? LcpDetails{get;set;}
[JsonPropertyName("layoutShiftDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public LayoutShift? LayoutShiftDetails{get;set;}
}
