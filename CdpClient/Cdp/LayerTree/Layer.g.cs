using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.LayerTree;
/// <summary>
/// Information about a compositing layer.
/// </summary>
public sealed partial class Layer {
/// <summary>
/// The unique id for this layer.
/// </summary>
[JsonPropertyName("layerId")]public LayerId LayerId{get;set;}
/// <summary>
/// The id of parent (not present for root).
/// </summary>
[JsonPropertyName("parentLayerId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public LayerId? ParentLayerId{get;set;}
/// <summary>
/// The backend id for the node associated with this layer.
/// </summary>
[JsonPropertyName("backendNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? BackendNodeId{get;set;}
/// <summary>
/// Offset from parent layer, X coordinate.
/// </summary>
[JsonPropertyName("offsetX")]public double OffsetX{get;set;}
/// <summary>
/// Offset from parent layer, Y coordinate.
/// </summary>
[JsonPropertyName("offsetY")]public double OffsetY{get;set;}
/// <summary>
/// Layer width.
/// </summary>
[JsonPropertyName("width")]public double Width{get;set;}
/// <summary>
/// Layer height.
/// </summary>
[JsonPropertyName("height")]public double Height{get;set;}
/// <summary>
/// Transformation matrix for layer, default is identity matrix
/// </summary>
[JsonPropertyName("transform")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double[]? Transform{get;set;}
/// <summary>
/// Transform anchor point X, absent if no transform specified
/// </summary>
[JsonPropertyName("anchorX")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? AnchorX{get;set;}
/// <summary>
/// Transform anchor point Y, absent if no transform specified
/// </summary>
[JsonPropertyName("anchorY")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? AnchorY{get;set;}
/// <summary>
/// Transform anchor point Z, absent if no transform specified
/// </summary>
[JsonPropertyName("anchorZ")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? AnchorZ{get;set;}
/// <summary>
/// Indicates how many time this layer has painted.
/// </summary>
[JsonPropertyName("paintCount")]public long PaintCount{get;set;}
/// <summary>
/// Indicates whether this layer hosts any content, rather than being used for
/// transform/scrolling purposes only.
/// </summary>
[JsonPropertyName("drawsContent")]public bool DrawsContent{get;set;}
/// <summary>
/// Set if layer is not visible.
/// </summary>
[JsonPropertyName("invisible")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Invisible{get;set;}
/// <summary>
/// Rectangles scrolling on main thread only.
/// </summary>
[JsonPropertyName("scrollRects")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public ScrollRect[]? ScrollRects{get;set;}
/// <summary>
/// Sticky position constraint information
/// </summary>
[JsonPropertyName("stickyPositionConstraint")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public StickyPositionConstraint? StickyPositionConstraint{get;set;}
}
