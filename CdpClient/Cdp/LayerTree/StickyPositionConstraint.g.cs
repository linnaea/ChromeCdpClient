using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.LayerTree;
/// <summary>
/// Sticky position constraints.
/// </summary>
public sealed partial class StickyPositionConstraint {
/// <summary>
/// Layout rectangle of the sticky element before being shifted
/// </summary>
[JsonPropertyName("stickyBoxRect")]public DOM.Rect StickyBoxRect{get;set;}
/// <summary>
/// Layout rectangle of the containing block of the sticky element
/// </summary>
[JsonPropertyName("containingBlockRect")]public DOM.Rect ContainingBlockRect{get;set;}
/// <summary>
/// The nearest sticky layer that shifts the sticky box
/// </summary>
[JsonPropertyName("nearestLayerShiftingStickyBox")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public LayerId? NearestLayerShiftingStickyBox{get;set;}
/// <summary>
/// The nearest sticky layer that shifts the containing block
/// </summary>
[JsonPropertyName("nearestLayerShiftingContainingBlock")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public LayerId? NearestLayerShiftingContainingBlock{get;set;}
}
