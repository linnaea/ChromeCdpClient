using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Overlay;
public sealed partial class IsolatedElementHighlightConfig {
/// <summary>
/// A descriptor for the highlight appearance of an element in isolation mode.
/// </summary>
[JsonPropertyName("isolationModeHighlightConfig")]public IsolationModeHighlightConfig IsolationModeHighlightConfig{get;set;}
/// <summary>
/// Identifier of the isolated element to highlight.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
