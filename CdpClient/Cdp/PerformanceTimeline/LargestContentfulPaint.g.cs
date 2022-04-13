using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.PerformanceTimeline;
/// <summary>
/// See https://github.com/WICG/LargestContentfulPaint and largest_contentful_paint.idl
/// </summary>
public sealed partial class LargestContentfulPaint {
[JsonPropertyName("renderTime")]public Network.TimeSinceEpoch RenderTime{get;set;}
[JsonPropertyName("loadTime")]public Network.TimeSinceEpoch LoadTime{get;set;}
/// <summary>
/// The number of pixels being painted.
/// </summary>
[JsonPropertyName("size")]public double Size{get;set;}
/// <summary>
/// The id attribute of the element, if available.
/// </summary>
[JsonPropertyName("elementId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ElementId{get;set;}
/// <summary>
/// The URL of the image (may be trimmed).
/// </summary>
[JsonPropertyName("url")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Url{get;set;}
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? NodeId{get;set;}
}
