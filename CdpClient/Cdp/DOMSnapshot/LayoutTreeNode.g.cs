using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOMSnapshot;
/// <summary>
/// Details of an element in the DOM tree with a LayoutObject.
/// </summary>
public sealed partial class LayoutTreeNode {
/// <summary>
/// The index of the related DOM node in the `domNodes` array returned by `getSnapshot`.
/// </summary>
[JsonPropertyName("domNodeIndex")]public long DomNodeIndex{get;set;}
/// <summary>
/// The bounding box in document coordinates. Note that scroll offset of the document is ignored.
/// </summary>
[JsonPropertyName("boundingBox")]public DOM.Rect BoundingBox{get;set;}
/// <summary>
/// Contents of the LayoutText, if any.
/// </summary>
[JsonPropertyName("layoutText")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? LayoutText{get;set;}
/// <summary>
/// The post-layout inline text nodes, if any.
/// </summary>
[JsonPropertyName("inlineTextNodes")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public InlineTextBox[]? InlineTextNodes{get;set;}
/// <summary>
/// Index into the `computedStyles` array returned by `getSnapshot`.
/// </summary>
[JsonPropertyName("styleIndex")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? StyleIndex{get;set;}
/// <summary>
/// Global paint order index, which is determined by the stacking order of the nodes. Nodes
/// that are painted together will have the same index. Only provided if includePaintOrder in
/// getSnapshot was true.
/// </summary>
[JsonPropertyName("paintOrder")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? PaintOrder{get;set;}
/// <summary>
/// Set to true to indicate the element begins a new stacking context.
/// </summary>
[JsonPropertyName("isStackingContext")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IsStackingContext{get;set;}
}
