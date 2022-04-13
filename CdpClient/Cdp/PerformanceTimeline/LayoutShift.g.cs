using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.PerformanceTimeline;
/// <summary>
/// See https://wicg.github.io/layout-instability/#sec-layout-shift and layout_shift.idl
/// </summary>
public sealed partial class LayoutShift {
/// <summary>
/// Score increment produced by this event.
/// </summary>
[JsonPropertyName("value")]public double Value{get;set;}
[JsonPropertyName("hadRecentInput")]public bool HadRecentInput{get;set;}
[JsonPropertyName("lastInputTime")]public Network.TimeSinceEpoch LastInputTime{get;set;}
[JsonPropertyName("sources")]public LayoutShiftAttribution[] Sources{get;set;}
}
