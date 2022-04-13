using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.PerformanceTimeline;
public sealed partial class LayoutShiftAttribution {
[JsonPropertyName("previousRect")]public DOM.Rect PreviousRect{get;set;}
[JsonPropertyName("currentRect")]public DOM.Rect CurrentRect{get;set;}
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? NodeId{get;set;}
}
