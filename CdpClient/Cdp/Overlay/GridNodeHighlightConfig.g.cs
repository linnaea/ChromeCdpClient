using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Overlay;
/// <summary>
/// Configurations for Persistent Grid Highlight
/// </summary>
public sealed partial class GridNodeHighlightConfig {
/// <summary>
/// A descriptor for the highlight appearance.
/// </summary>
[JsonPropertyName("gridHighlightConfig")]public GridHighlightConfig GridHighlightConfig{get;set;}
/// <summary>
/// Identifier of the node to highlight.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
