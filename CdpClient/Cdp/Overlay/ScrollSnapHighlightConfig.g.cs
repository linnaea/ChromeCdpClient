using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Overlay;
public sealed partial class ScrollSnapHighlightConfig {
/// <summary>
/// A descriptor for the highlight appearance of scroll snap containers.
/// </summary>
[JsonPropertyName("scrollSnapContainerHighlightConfig")]public ScrollSnapContainerHighlightConfig ScrollSnapContainerHighlightConfig{get;set;}
/// <summary>
/// Identifier of the node to highlight.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
