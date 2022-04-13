using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// This domain exposes DOM read/write operations. Each DOM Node is represented with its mirror object
/// that has an `id`. This `id` can be used to get additional information on the Node, resolve it into
/// the JavaScript object wrapper, etc. It is important that client receives DOM events only for the
/// nodes that are known to the client. Backend keeps track of the nodes that were sent to the client
/// and never sends the same node twice. It is client's responsibility to collect information about
/// the nodes that were sent to the client.<p>Note that `iframe` owner elements will return
/// corresponding document elements as their child nodes.</p>
/// </summary>
public sealed partial class DOMDomain {
private readonly ConnectedTarget _target;
public DOMDomain(ConnectedTarget target) => _target = target;
public sealed partial class CollectClassNamesFromSubtreeParams {
/// <summary>
/// Id of the node to collect class names.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
public sealed partial class CollectClassNamesFromSubtreeReturn {
/// <summary>
/// Class name list.
/// </summary>
[JsonPropertyName("classNames")]public string[] ClassNames{get;set;}
}
/// <summary>
/// Collects class names for the node with given id and all of it's child nodes.
/// </summary>
/// <param name="nodeId">Id of the node to collect class names.</param>
[Experimental]public async Task<CollectClassNamesFromSubtreeReturn> CollectClassNamesFromSubtree(
 DOM.NodeId @nodeId) {
var resp = await _target.SendRequest("DOM.collectClassNamesFromSubtree",
new CollectClassNamesFromSubtreeParams {
NodeId=@nodeId,});
return _target.DeserializeResponse<CollectClassNamesFromSubtreeReturn>(resp);
}
public sealed partial class CopyToParams {
/// <summary>
/// Id of the node to copy.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// Id of the element to drop the copy into.
/// </summary>
[JsonPropertyName("targetNodeId")]public DOM.NodeId TargetNodeId{get;set;}
/// <summary>
/// Drop the copy before this node (if absent, the copy becomes the last child of
/// `targetNodeId`).
/// </summary>
[JsonPropertyName("insertBeforeNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? InsertBeforeNodeId{get;set;}
}
public sealed partial class CopyToReturn {
/// <summary>
/// Id of the node clone.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
/// <summary>
/// Creates a deep copy of the specified node and places it into the target container before the
/// given anchor.
/// </summary>
/// <param name="nodeId">Id of the node to copy.</param>
/// <param name="targetNodeId">Id of the element to drop the copy into.</param>
/// <param name="insertBeforeNodeId">Drop the copy before this node (if absent, the copy becomes the last child of
/// `targetNodeId`).</param>
[Experimental]public async Task<CopyToReturn> CopyTo(
 DOM.NodeId @nodeId,DOM.NodeId @targetNodeId,DOM.NodeId? @insertBeforeNodeId=default) {
var resp = await _target.SendRequest("DOM.copyTo",
new CopyToParams {
NodeId=@nodeId,TargetNodeId=@targetNodeId,InsertBeforeNodeId=@insertBeforeNodeId,});
return _target.DeserializeResponse<CopyToReturn>(resp);
}
public sealed partial class DescribeNodeParams {
/// <summary>
/// Identifier of the node.
/// </summary>
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? NodeId{get;set;}
/// <summary>
/// Identifier of the backend node.
/// </summary>
[JsonPropertyName("backendNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? BackendNodeId{get;set;}
/// <summary>
/// JavaScript object id of the node wrapper.
/// </summary>
[JsonPropertyName("objectId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.RemoteObjectId? ObjectId{get;set;}
/// <summary>
/// The maximum depth at which children should be retrieved, defaults to 1. Use -1 for the
/// entire subtree or provide an integer larger than 0.
/// </summary>
[JsonPropertyName("depth")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Depth{get;set;}
/// <summary>
/// Whether or not iframes and shadow roots should be traversed when returning the subtree
/// (default is false).
/// </summary>
[JsonPropertyName("pierce")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Pierce{get;set;}
}
public sealed partial class DescribeNodeReturn {
/// <summary>
/// Node description.
/// </summary>
[JsonPropertyName("node")]public DOM.Node Node{get;set;}
}
/// <summary>
/// Describes node given its id, does not require domain to be enabled. Does not start tracking any
/// objects, can be used for automation.
/// </summary>
/// <param name="nodeId">Identifier of the node.</param>
/// <param name="backendNodeId">Identifier of the backend node.</param>
/// <param name="objectId">JavaScript object id of the node wrapper.</param>
/// <param name="depth">The maximum depth at which children should be retrieved, defaults to 1. Use -1 for the
/// entire subtree or provide an integer larger than 0.</param>
/// <param name="pierce">Whether or not iframes and shadow roots should be traversed when returning the subtree
/// (default is false).</param>
public async Task<DescribeNodeReturn> DescribeNode(
 DOM.NodeId? @nodeId=default,DOM.BackendNodeId? @backendNodeId=default,Runtime.RemoteObjectId? @objectId=default,long? @depth=default,bool? @pierce=default) {
var resp = await _target.SendRequest("DOM.describeNode",
new DescribeNodeParams {
NodeId=@nodeId,BackendNodeId=@backendNodeId,ObjectId=@objectId,Depth=@depth,Pierce=@pierce,});
return _target.DeserializeResponse<DescribeNodeReturn>(resp);
}
public sealed partial class ScrollIntoViewIfNeededParams {
/// <summary>
/// Identifier of the node.
/// </summary>
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? NodeId{get;set;}
/// <summary>
/// Identifier of the backend node.
/// </summary>
[JsonPropertyName("backendNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? BackendNodeId{get;set;}
/// <summary>
/// JavaScript object id of the node wrapper.
/// </summary>
[JsonPropertyName("objectId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.RemoteObjectId? ObjectId{get;set;}
/// <summary>
/// The rect to be scrolled into view, relative to the node's border box, in CSS pixels.
/// When omitted, center of the node will be used, similar to Element.scrollIntoView.
/// </summary>
[JsonPropertyName("rect")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.Rect? Rect{get;set;}
}
/// <summary>
/// Scrolls the specified rect of the given node into view if not already visible.
/// Note: exactly one between nodeId, backendNodeId and objectId should be passed
/// to identify the node.
/// </summary>
/// <param name="nodeId">Identifier of the node.</param>
/// <param name="backendNodeId">Identifier of the backend node.</param>
/// <param name="objectId">JavaScript object id of the node wrapper.</param>
/// <param name="rect">The rect to be scrolled into view, relative to the node's border box, in CSS pixels.
/// When omitted, center of the node will be used, similar to Element.scrollIntoView.</param>
[Experimental]public async Task ScrollIntoViewIfNeeded(
 DOM.NodeId? @nodeId=default,DOM.BackendNodeId? @backendNodeId=default,Runtime.RemoteObjectId? @objectId=default,DOM.Rect? @rect=default) {
var resp = await _target.SendRequest("DOM.scrollIntoViewIfNeeded",
new ScrollIntoViewIfNeededParams {
NodeId=@nodeId,BackendNodeId=@backendNodeId,ObjectId=@objectId,Rect=@rect,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Disables DOM agent for the given page.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("DOM.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class DiscardSearchResultsParams {
/// <summary>
/// Unique search session identifier.
/// </summary>
[JsonPropertyName("searchId")]public string SearchId{get;set;}
}
/// <summary>
/// Discards search results from the session with the given id. `getSearchResults` should no longer
/// be called for that search.
/// </summary>
/// <param name="searchId">Unique search session identifier.</param>
[Experimental]public async Task DiscardSearchResults(
 string @searchId) {
var resp = await _target.SendRequest("DOM.discardSearchResults",
new DiscardSearchResultsParams {
SearchId=@searchId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class EnableParams {
/// <summary>
/// Whether to include whitespaces in the children array of returned Nodes.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum IncludeWhitespaceEnum {
[EnumMember(Value = "none")] None,
[EnumMember(Value = "all")] All,
}
[JsonPropertyName("includeWhitespace")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public IncludeWhitespaceEnum? IncludeWhitespace{get;set;}
}
/// <summary>
/// Enables DOM agent for the given page.
/// </summary>
/// <param name="includeWhitespace">EXPERIMENTAL Whether to include whitespaces in the children array of returned Nodes.</param>
public async Task Enable(
 EnableParams.IncludeWhitespaceEnum? @includeWhitespace=default) {
var resp = await _target.SendRequest("DOM.enable",
new EnableParams {
IncludeWhitespace=@includeWhitespace,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class FocusParams {
/// <summary>
/// Identifier of the node.
/// </summary>
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? NodeId{get;set;}
/// <summary>
/// Identifier of the backend node.
/// </summary>
[JsonPropertyName("backendNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? BackendNodeId{get;set;}
/// <summary>
/// JavaScript object id of the node wrapper.
/// </summary>
[JsonPropertyName("objectId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.RemoteObjectId? ObjectId{get;set;}
}
/// <summary>
/// Focuses the given element.
/// </summary>
/// <param name="nodeId">Identifier of the node.</param>
/// <param name="backendNodeId">Identifier of the backend node.</param>
/// <param name="objectId">JavaScript object id of the node wrapper.</param>
public async Task Focus(
 DOM.NodeId? @nodeId=default,DOM.BackendNodeId? @backendNodeId=default,Runtime.RemoteObjectId? @objectId=default) {
var resp = await _target.SendRequest("DOM.focus",
new FocusParams {
NodeId=@nodeId,BackendNodeId=@backendNodeId,ObjectId=@objectId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetAttributesParams {
/// <summary>
/// Id of the node to retrieve attibutes for.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
public sealed partial class GetAttributesReturn {
/// <summary>
/// An interleaved array of node attribute names and values.
/// </summary>
[JsonPropertyName("attributes")]public string[] Attributes{get;set;}
}
/// <summary>
/// Returns attributes for the specified node.
/// </summary>
/// <param name="nodeId">Id of the node to retrieve attibutes for.</param>
public async Task<GetAttributesReturn> GetAttributes(
 DOM.NodeId @nodeId) {
var resp = await _target.SendRequest("DOM.getAttributes",
new GetAttributesParams {
NodeId=@nodeId,});
return _target.DeserializeResponse<GetAttributesReturn>(resp);
}
public sealed partial class GetBoxModelParams {
/// <summary>
/// Identifier of the node.
/// </summary>
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? NodeId{get;set;}
/// <summary>
/// Identifier of the backend node.
/// </summary>
[JsonPropertyName("backendNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? BackendNodeId{get;set;}
/// <summary>
/// JavaScript object id of the node wrapper.
/// </summary>
[JsonPropertyName("objectId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.RemoteObjectId? ObjectId{get;set;}
}
public sealed partial class GetBoxModelReturn {
/// <summary>
/// Box model for the node.
/// </summary>
[JsonPropertyName("model")]public DOM.BoxModel Model{get;set;}
}
/// <summary>
/// Returns boxes for the given node.
/// </summary>
/// <param name="nodeId">Identifier of the node.</param>
/// <param name="backendNodeId">Identifier of the backend node.</param>
/// <param name="objectId">JavaScript object id of the node wrapper.</param>
public async Task<GetBoxModelReturn> GetBoxModel(
 DOM.NodeId? @nodeId=default,DOM.BackendNodeId? @backendNodeId=default,Runtime.RemoteObjectId? @objectId=default) {
var resp = await _target.SendRequest("DOM.getBoxModel",
new GetBoxModelParams {
NodeId=@nodeId,BackendNodeId=@backendNodeId,ObjectId=@objectId,});
return _target.DeserializeResponse<GetBoxModelReturn>(resp);
}
public sealed partial class GetContentQuadsParams {
/// <summary>
/// Identifier of the node.
/// </summary>
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? NodeId{get;set;}
/// <summary>
/// Identifier of the backend node.
/// </summary>
[JsonPropertyName("backendNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? BackendNodeId{get;set;}
/// <summary>
/// JavaScript object id of the node wrapper.
/// </summary>
[JsonPropertyName("objectId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.RemoteObjectId? ObjectId{get;set;}
}
public sealed partial class GetContentQuadsReturn {
/// <summary>
/// Quads that describe node layout relative to viewport.
/// </summary>
[JsonPropertyName("quads")]public DOM.Quad[] Quads{get;set;}
}
/// <summary>
/// Returns quads that describe node position on the page. This method
/// might return multiple quads for inline nodes.
/// </summary>
/// <param name="nodeId">Identifier of the node.</param>
/// <param name="backendNodeId">Identifier of the backend node.</param>
/// <param name="objectId">JavaScript object id of the node wrapper.</param>
[Experimental]public async Task<GetContentQuadsReturn> GetContentQuads(
 DOM.NodeId? @nodeId=default,DOM.BackendNodeId? @backendNodeId=default,Runtime.RemoteObjectId? @objectId=default) {
var resp = await _target.SendRequest("DOM.getContentQuads",
new GetContentQuadsParams {
NodeId=@nodeId,BackendNodeId=@backendNodeId,ObjectId=@objectId,});
return _target.DeserializeResponse<GetContentQuadsReturn>(resp);
}
public sealed partial class GetDocumentParams {
/// <summary>
/// The maximum depth at which children should be retrieved, defaults to 1. Use -1 for the
/// entire subtree or provide an integer larger than 0.
/// </summary>
[JsonPropertyName("depth")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Depth{get;set;}
/// <summary>
/// Whether or not iframes and shadow roots should be traversed when returning the subtree
/// (default is false).
/// </summary>
[JsonPropertyName("pierce")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Pierce{get;set;}
}
public sealed partial class GetDocumentReturn {
/// <summary>
/// Resulting node.
/// </summary>
[JsonPropertyName("root")]public DOM.Node Root{get;set;}
}
/// <summary>
/// Returns the root DOM node (and optionally the subtree) to the caller.
/// </summary>
/// <param name="depth">The maximum depth at which children should be retrieved, defaults to 1. Use -1 for the
/// entire subtree or provide an integer larger than 0.</param>
/// <param name="pierce">Whether or not iframes and shadow roots should be traversed when returning the subtree
/// (default is false).</param>
public async Task<GetDocumentReturn> GetDocument(
 long? @depth=default,bool? @pierce=default) {
var resp = await _target.SendRequest("DOM.getDocument",
new GetDocumentParams {
Depth=@depth,Pierce=@pierce,});
return _target.DeserializeResponse<GetDocumentReturn>(resp);
}
public sealed partial class GetFlattenedDocumentParams {
/// <summary>
/// The maximum depth at which children should be retrieved, defaults to 1. Use -1 for the
/// entire subtree or provide an integer larger than 0.
/// </summary>
[JsonPropertyName("depth")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Depth{get;set;}
/// <summary>
/// Whether or not iframes and shadow roots should be traversed when returning the subtree
/// (default is false).
/// </summary>
[JsonPropertyName("pierce")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Pierce{get;set;}
}
public sealed partial class GetFlattenedDocumentReturn {
/// <summary>
/// Resulting node.
/// </summary>
[JsonPropertyName("nodes")]public DOM.Node[] Nodes{get;set;}
}
/// <summary>
/// Returns the root DOM node (and optionally the subtree) to the caller.
/// Deprecated, as it is not designed to work well with the rest of the DOM agent.
/// Use DOMSnapshot.captureSnapshot instead.
/// </summary>
/// <param name="depth">The maximum depth at which children should be retrieved, defaults to 1. Use -1 for the
/// entire subtree or provide an integer larger than 0.</param>
/// <param name="pierce">Whether or not iframes and shadow roots should be traversed when returning the subtree
/// (default is false).</param>
[Obsolete]public async Task<GetFlattenedDocumentReturn> GetFlattenedDocument(
 long? @depth=default,bool? @pierce=default) {
var resp = await _target.SendRequest("DOM.getFlattenedDocument",
new GetFlattenedDocumentParams {
Depth=@depth,Pierce=@pierce,});
return _target.DeserializeResponse<GetFlattenedDocumentReturn>(resp);
}
public sealed partial class GetNodesForSubtreeByStyleParams {
/// <summary>
/// Node ID pointing to the root of a subtree.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// The style to filter nodes by (includes nodes if any of properties matches).
/// </summary>
[JsonPropertyName("computedStyles")]public DOM.CSSComputedStyleProperty[] ComputedStyles{get;set;}
/// <summary>
/// Whether or not iframes and shadow roots in the same target should be traversed when returning the
/// results (default is false).
/// </summary>
[JsonPropertyName("pierce")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Pierce{get;set;}
}
public sealed partial class GetNodesForSubtreeByStyleReturn {
/// <summary>
/// Resulting nodes.
/// </summary>
[JsonPropertyName("nodeIds")]public DOM.NodeId[] NodeIds{get;set;}
}
/// <summary>
/// Finds nodes with a given computed style in a subtree.
/// </summary>
/// <param name="nodeId">Node ID pointing to the root of a subtree.</param>
/// <param name="computedStyles">The style to filter nodes by (includes nodes if any of properties matches).</param>
/// <param name="pierce">Whether or not iframes and shadow roots in the same target should be traversed when returning the
/// results (default is false).</param>
[Experimental]public async Task<GetNodesForSubtreeByStyleReturn> GetNodesForSubtreeByStyle(
 DOM.NodeId @nodeId,DOM.CSSComputedStyleProperty[] @computedStyles,bool? @pierce=default) {
var resp = await _target.SendRequest("DOM.getNodesForSubtreeByStyle",
new GetNodesForSubtreeByStyleParams {
NodeId=@nodeId,ComputedStyles=@computedStyles,Pierce=@pierce,});
return _target.DeserializeResponse<GetNodesForSubtreeByStyleReturn>(resp);
}
public sealed partial class GetNodeForLocationParams {
/// <summary>
/// X coordinate.
/// </summary>
[JsonPropertyName("x")]public long X{get;set;}
/// <summary>
/// Y coordinate.
/// </summary>
[JsonPropertyName("y")]public long Y{get;set;}
/// <summary>
/// False to skip to the nearest non-UA shadow root ancestor (default: false).
/// </summary>
[JsonPropertyName("includeUserAgentShadowDOM")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IncludeUserAgentShadowDOM{get;set;}
/// <summary>
/// Whether to ignore pointer-events: none on elements and hit test them.
/// </summary>
[JsonPropertyName("ignorePointerEventsNone")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IgnorePointerEventsNone{get;set;}
}
public sealed partial class GetNodeForLocationReturn {
/// <summary>
/// Resulting node.
/// </summary>
[JsonPropertyName("backendNodeId")]public DOM.BackendNodeId BackendNodeId{get;set;}
/// <summary>
/// Frame this node belongs to.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// Id of the node at given coordinates, only when enabled and requested document.
/// </summary>
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? NodeId{get;set;}
}
/// <summary>
/// Returns node id at given location. Depending on whether DOM domain is enabled, nodeId is
/// either returned or not.
/// </summary>
/// <param name="x">X coordinate.</param>
/// <param name="y">Y coordinate.</param>
/// <param name="includeUserAgentShadowDOM">False to skip to the nearest non-UA shadow root ancestor (default: false).</param>
/// <param name="ignorePointerEventsNone">Whether to ignore pointer-events: none on elements and hit test them.</param>
public async Task<GetNodeForLocationReturn> GetNodeForLocation(
 long @x,long @y,bool? @includeUserAgentShadowDOM=default,bool? @ignorePointerEventsNone=default) {
var resp = await _target.SendRequest("DOM.getNodeForLocation",
new GetNodeForLocationParams {
X=@x,Y=@y,IncludeUserAgentShadowDOM=@includeUserAgentShadowDOM,IgnorePointerEventsNone=@ignorePointerEventsNone,});
return _target.DeserializeResponse<GetNodeForLocationReturn>(resp);
}
public sealed partial class GetOuterHTMLParams {
/// <summary>
/// Identifier of the node.
/// </summary>
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? NodeId{get;set;}
/// <summary>
/// Identifier of the backend node.
/// </summary>
[JsonPropertyName("backendNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? BackendNodeId{get;set;}
/// <summary>
/// JavaScript object id of the node wrapper.
/// </summary>
[JsonPropertyName("objectId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.RemoteObjectId? ObjectId{get;set;}
}
public sealed partial class GetOuterHTMLReturn {
/// <summary>
/// Outer HTML markup.
/// </summary>
[JsonPropertyName("outerHTML")]public string OuterHTML{get;set;}
}
/// <summary>
/// Returns node's HTML markup.
/// </summary>
/// <param name="nodeId">Identifier of the node.</param>
/// <param name="backendNodeId">Identifier of the backend node.</param>
/// <param name="objectId">JavaScript object id of the node wrapper.</param>
public async Task<GetOuterHTMLReturn> GetOuterHTML(
 DOM.NodeId? @nodeId=default,DOM.BackendNodeId? @backendNodeId=default,Runtime.RemoteObjectId? @objectId=default) {
var resp = await _target.SendRequest("DOM.getOuterHTML",
new GetOuterHTMLParams {
NodeId=@nodeId,BackendNodeId=@backendNodeId,ObjectId=@objectId,});
return _target.DeserializeResponse<GetOuterHTMLReturn>(resp);
}
public sealed partial class GetRelayoutBoundaryParams {
/// <summary>
/// Id of the node.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
public sealed partial class GetRelayoutBoundaryReturn {
/// <summary>
/// Relayout boundary node id for the given node.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
/// <summary>
/// Returns the id of the nearest ancestor that is a relayout boundary.
/// </summary>
/// <param name="nodeId">Id of the node.</param>
[Experimental]public async Task<GetRelayoutBoundaryReturn> GetRelayoutBoundary(
 DOM.NodeId @nodeId) {
var resp = await _target.SendRequest("DOM.getRelayoutBoundary",
new GetRelayoutBoundaryParams {
NodeId=@nodeId,});
return _target.DeserializeResponse<GetRelayoutBoundaryReturn>(resp);
}
public sealed partial class GetSearchResultsParams {
/// <summary>
/// Unique search session identifier.
/// </summary>
[JsonPropertyName("searchId")]public string SearchId{get;set;}
/// <summary>
/// Start index of the search result to be returned.
/// </summary>
[JsonPropertyName("fromIndex")]public long FromIndex{get;set;}
/// <summary>
/// End index of the search result to be returned.
/// </summary>
[JsonPropertyName("toIndex")]public long ToIndex{get;set;}
}
public sealed partial class GetSearchResultsReturn {
/// <summary>
/// Ids of the search result nodes.
/// </summary>
[JsonPropertyName("nodeIds")]public DOM.NodeId[] NodeIds{get;set;}
}
/// <summary>
/// Returns search results from given `fromIndex` to given `toIndex` from the search with the given
/// identifier.
/// </summary>
/// <param name="searchId">Unique search session identifier.</param>
/// <param name="fromIndex">Start index of the search result to be returned.</param>
/// <param name="toIndex">End index of the search result to be returned.</param>
[Experimental]public async Task<GetSearchResultsReturn> GetSearchResults(
 string @searchId,long @fromIndex,long @toIndex) {
var resp = await _target.SendRequest("DOM.getSearchResults",
new GetSearchResultsParams {
SearchId=@searchId,FromIndex=@fromIndex,ToIndex=@toIndex,});
return _target.DeserializeResponse<GetSearchResultsReturn>(resp);
}
/// <summary>
/// Hides any highlight.
/// </summary>
public async Task HideHighlight(
) {
var resp = await _target.SendRequest("DOM.hideHighlight",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Highlights DOM node.
/// </summary>
public async Task HighlightNode(
) {
var resp = await _target.SendRequest("DOM.highlightNode",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Highlights given rectangle.
/// </summary>
public async Task HighlightRect(
) {
var resp = await _target.SendRequest("DOM.highlightRect",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Marks last undoable state.
/// </summary>
[Experimental]public async Task MarkUndoableState(
) {
var resp = await _target.SendRequest("DOM.markUndoableState",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class MoveToParams {
/// <summary>
/// Id of the node to move.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// Id of the element to drop the moved node into.
/// </summary>
[JsonPropertyName("targetNodeId")]public DOM.NodeId TargetNodeId{get;set;}
/// <summary>
/// Drop node before this one (if absent, the moved node becomes the last child of
/// `targetNodeId`).
/// </summary>
[JsonPropertyName("insertBeforeNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? InsertBeforeNodeId{get;set;}
}
public sealed partial class MoveToReturn {
/// <summary>
/// New id of the moved node.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
/// <summary>
/// Moves node into the new container, places it before the given anchor.
/// </summary>
/// <param name="nodeId">Id of the node to move.</param>
/// <param name="targetNodeId">Id of the element to drop the moved node into.</param>
/// <param name="insertBeforeNodeId">Drop node before this one (if absent, the moved node becomes the last child of
/// `targetNodeId`).</param>
public async Task<MoveToReturn> MoveTo(
 DOM.NodeId @nodeId,DOM.NodeId @targetNodeId,DOM.NodeId? @insertBeforeNodeId=default) {
var resp = await _target.SendRequest("DOM.moveTo",
new MoveToParams {
NodeId=@nodeId,TargetNodeId=@targetNodeId,InsertBeforeNodeId=@insertBeforeNodeId,});
return _target.DeserializeResponse<MoveToReturn>(resp);
}
public sealed partial class PerformSearchParams {
/// <summary>
/// Plain text or query selector or XPath search query.
/// </summary>
[JsonPropertyName("query")]public string Query{get;set;}
/// <summary>
/// True to search in user agent shadow DOM.
/// </summary>
[JsonPropertyName("includeUserAgentShadowDOM")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IncludeUserAgentShadowDOM{get;set;}
}
public sealed partial class PerformSearchReturn {
/// <summary>
/// Unique search session identifier.
/// </summary>
[JsonPropertyName("searchId")]public string SearchId{get;set;}
/// <summary>
/// Number of search results.
/// </summary>
[JsonPropertyName("resultCount")]public long ResultCount{get;set;}
}
/// <summary>
/// Searches for a given string in the DOM tree. Use `getSearchResults` to access search results or
/// `cancelSearch` to end this search session.
/// </summary>
/// <param name="query">Plain text or query selector or XPath search query.</param>
/// <param name="includeUserAgentShadowDOM">True to search in user agent shadow DOM.</param>
[Experimental]public async Task<PerformSearchReturn> PerformSearch(
 string @query,bool? @includeUserAgentShadowDOM=default) {
var resp = await _target.SendRequest("DOM.performSearch",
new PerformSearchParams {
Query=@query,IncludeUserAgentShadowDOM=@includeUserAgentShadowDOM,});
return _target.DeserializeResponse<PerformSearchReturn>(resp);
}
public sealed partial class PushNodeByPathToFrontendParams {
/// <summary>
/// Path to node in the proprietary format.
/// </summary>
[JsonPropertyName("path")]public string Path{get;set;}
}
public sealed partial class PushNodeByPathToFrontendReturn {
/// <summary>
/// Id of the node for given path.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
/// <summary>
/// Requests that the node is sent to the caller given its path. // FIXME, use XPath
/// </summary>
/// <param name="path">Path to node in the proprietary format.</param>
[Experimental]public async Task<PushNodeByPathToFrontendReturn> PushNodeByPathToFrontend(
 string @path) {
var resp = await _target.SendRequest("DOM.pushNodeByPathToFrontend",
new PushNodeByPathToFrontendParams {
Path=@path,});
return _target.DeserializeResponse<PushNodeByPathToFrontendReturn>(resp);
}
public sealed partial class PushNodesByBackendIdsToFrontendParams {
/// <summary>
/// The array of backend node ids.
/// </summary>
[JsonPropertyName("backendNodeIds")]public DOM.BackendNodeId[] BackendNodeIds{get;set;}
}
public sealed partial class PushNodesByBackendIdsToFrontendReturn {
/// <summary>
/// The array of ids of pushed nodes that correspond to the backend ids specified in
/// backendNodeIds.
/// </summary>
[JsonPropertyName("nodeIds")]public DOM.NodeId[] NodeIds{get;set;}
}
/// <summary>
/// Requests that a batch of nodes is sent to the caller given their backend node ids.
/// </summary>
/// <param name="backendNodeIds">The array of backend node ids.</param>
[Experimental]public async Task<PushNodesByBackendIdsToFrontendReturn> PushNodesByBackendIdsToFrontend(
 DOM.BackendNodeId[] @backendNodeIds) {
var resp = await _target.SendRequest("DOM.pushNodesByBackendIdsToFrontend",
new PushNodesByBackendIdsToFrontendParams {
BackendNodeIds=@backendNodeIds,});
return _target.DeserializeResponse<PushNodesByBackendIdsToFrontendReturn>(resp);
}
public sealed partial class QuerySelectorParams {
/// <summary>
/// Id of the node to query upon.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// Selector string.
/// </summary>
[JsonPropertyName("selector")]public string Selector{get;set;}
}
public sealed partial class QuerySelectorReturn {
/// <summary>
/// Query selector result.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
/// <summary>
/// Executes `querySelector` on a given node.
/// </summary>
/// <param name="nodeId">Id of the node to query upon.</param>
/// <param name="selector">Selector string.</param>
public async Task<QuerySelectorReturn> QuerySelector(
 DOM.NodeId @nodeId,string @selector) {
var resp = await _target.SendRequest("DOM.querySelector",
new QuerySelectorParams {
NodeId=@nodeId,Selector=@selector,});
return _target.DeserializeResponse<QuerySelectorReturn>(resp);
}
public sealed partial class QuerySelectorAllParams {
/// <summary>
/// Id of the node to query upon.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// Selector string.
/// </summary>
[JsonPropertyName("selector")]public string Selector{get;set;}
}
public sealed partial class QuerySelectorAllReturn {
/// <summary>
/// Query selector result.
/// </summary>
[JsonPropertyName("nodeIds")]public DOM.NodeId[] NodeIds{get;set;}
}
/// <summary>
/// Executes `querySelectorAll` on a given node.
/// </summary>
/// <param name="nodeId">Id of the node to query upon.</param>
/// <param name="selector">Selector string.</param>
public async Task<QuerySelectorAllReturn> QuerySelectorAll(
 DOM.NodeId @nodeId,string @selector) {
var resp = await _target.SendRequest("DOM.querySelectorAll",
new QuerySelectorAllParams {
NodeId=@nodeId,Selector=@selector,});
return _target.DeserializeResponse<QuerySelectorAllReturn>(resp);
}
/// <summary>
/// Re-does the last undone action.
/// </summary>
[Experimental]public async Task Redo(
) {
var resp = await _target.SendRequest("DOM.redo",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class RemoveAttributeParams {
/// <summary>
/// Id of the element to remove attribute from.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// Name of the attribute to remove.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
}
/// <summary>
/// Removes attribute with given name from an element with given id.
/// </summary>
/// <param name="nodeId">Id of the element to remove attribute from.</param>
/// <param name="name">Name of the attribute to remove.</param>
public async Task RemoveAttribute(
 DOM.NodeId @nodeId,string @name) {
var resp = await _target.SendRequest("DOM.removeAttribute",
new RemoveAttributeParams {
NodeId=@nodeId,Name=@name,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class RemoveNodeParams {
/// <summary>
/// Id of the node to remove.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
/// <summary>
/// Removes node with given id.
/// </summary>
/// <param name="nodeId">Id of the node to remove.</param>
public async Task RemoveNode(
 DOM.NodeId @nodeId) {
var resp = await _target.SendRequest("DOM.removeNode",
new RemoveNodeParams {
NodeId=@nodeId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class RequestChildNodesParams {
/// <summary>
/// Id of the node to get children for.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// The maximum depth at which children should be retrieved, defaults to 1. Use -1 for the
/// entire subtree or provide an integer larger than 0.
/// </summary>
[JsonPropertyName("depth")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Depth{get;set;}
/// <summary>
/// Whether or not iframes and shadow roots should be traversed when returning the sub-tree
/// (default is false).
/// </summary>
[JsonPropertyName("pierce")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Pierce{get;set;}
}
/// <summary>
/// Requests that children of the node with given id are returned to the caller in form of
/// `setChildNodes` events where not only immediate children are retrieved, but all children down to
/// the specified depth.
/// </summary>
/// <param name="nodeId">Id of the node to get children for.</param>
/// <param name="depth">The maximum depth at which children should be retrieved, defaults to 1. Use -1 for the
/// entire subtree or provide an integer larger than 0.</param>
/// <param name="pierce">Whether or not iframes and shadow roots should be traversed when returning the sub-tree
/// (default is false).</param>
public async Task RequestChildNodes(
 DOM.NodeId @nodeId,long? @depth=default,bool? @pierce=default) {
var resp = await _target.SendRequest("DOM.requestChildNodes",
new RequestChildNodesParams {
NodeId=@nodeId,Depth=@depth,Pierce=@pierce,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class RequestNodeParams {
/// <summary>
/// JavaScript object id to convert into node.
/// </summary>
[JsonPropertyName("objectId")]public Runtime.RemoteObjectId ObjectId{get;set;}
}
public sealed partial class RequestNodeReturn {
/// <summary>
/// Node id for given object.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
/// <summary>
/// Requests that the node is sent to the caller given the JavaScript node object reference. All
/// nodes that form the path from the node to the root are also sent to the client as a series of
/// `setChildNodes` notifications.
/// </summary>
/// <param name="objectId">JavaScript object id to convert into node.</param>
public async Task<RequestNodeReturn> RequestNode(
 Runtime.RemoteObjectId @objectId) {
var resp = await _target.SendRequest("DOM.requestNode",
new RequestNodeParams {
ObjectId=@objectId,});
return _target.DeserializeResponse<RequestNodeReturn>(resp);
}
public sealed partial class ResolveNodeParams {
/// <summary>
/// Id of the node to resolve.
/// </summary>
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? NodeId{get;set;}
/// <summary>
/// Backend identifier of the node to resolve.
/// </summary>
[JsonPropertyName("backendNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? BackendNodeId{get;set;}
/// <summary>
/// Symbolic group name that can be used to release multiple objects.
/// </summary>
[JsonPropertyName("objectGroup")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ObjectGroup{get;set;}
/// <summary>
/// Execution context in which to resolve the node.
/// </summary>
[JsonPropertyName("executionContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ExecutionContextId? ExecutionContextId{get;set;}
}
public sealed partial class ResolveNodeReturn {
/// <summary>
/// JavaScript object wrapper for given node.
/// </summary>
[JsonPropertyName("object")]public Runtime.RemoteObject Object{get;set;}
}
/// <summary>
/// Resolves the JavaScript node object for a given NodeId or BackendNodeId.
/// </summary>
/// <param name="nodeId">Id of the node to resolve.</param>
/// <param name="backendNodeId">Backend identifier of the node to resolve.</param>
/// <param name="objectGroup">Symbolic group name that can be used to release multiple objects.</param>
/// <param name="executionContextId">Execution context in which to resolve the node.</param>
public async Task<ResolveNodeReturn> ResolveNode(
 DOM.NodeId? @nodeId=default,DOM.BackendNodeId? @backendNodeId=default,string? @objectGroup=default,Runtime.ExecutionContextId? @executionContextId=default) {
var resp = await _target.SendRequest("DOM.resolveNode",
new ResolveNodeParams {
NodeId=@nodeId,BackendNodeId=@backendNodeId,ObjectGroup=@objectGroup,ExecutionContextId=@executionContextId,});
return _target.DeserializeResponse<ResolveNodeReturn>(resp);
}
public sealed partial class SetAttributeValueParams {
/// <summary>
/// Id of the element to set attribute for.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// Attribute name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Attribute value.
/// </summary>
[JsonPropertyName("value")]public string Value{get;set;}
}
/// <summary>
/// Sets attribute for an element with given id.
/// </summary>
/// <param name="nodeId">Id of the element to set attribute for.</param>
/// <param name="name">Attribute name.</param>
/// <param name="value">Attribute value.</param>
public async Task SetAttributeValue(
 DOM.NodeId @nodeId,string @name,string @value) {
var resp = await _target.SendRequest("DOM.setAttributeValue",
new SetAttributeValueParams {
NodeId=@nodeId,Name=@name,Value=@value,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetAttributesAsTextParams {
/// <summary>
/// Id of the element to set attributes for.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// Text with a number of attributes. Will parse this text using HTML parser.
/// </summary>
[JsonPropertyName("text")]public string Text{get;set;}
/// <summary>
/// Attribute name to replace with new attributes derived from text in case text parsed
/// successfully.
/// </summary>
[JsonPropertyName("name")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Name{get;set;}
}
/// <summary>
/// Sets attributes on element with given id. This method is useful when user edits some existing
/// attribute value and types in several attribute name/value pairs.
/// </summary>
/// <param name="nodeId">Id of the element to set attributes for.</param>
/// <param name="text">Text with a number of attributes. Will parse this text using HTML parser.</param>
/// <param name="name">Attribute name to replace with new attributes derived from text in case text parsed
/// successfully.</param>
public async Task SetAttributesAsText(
 DOM.NodeId @nodeId,string @text,string? @name=default) {
var resp = await _target.SendRequest("DOM.setAttributesAsText",
new SetAttributesAsTextParams {
NodeId=@nodeId,Text=@text,Name=@name,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetFileInputFilesParams {
/// <summary>
/// Array of file paths to set.
/// </summary>
[JsonPropertyName("files")]public string[] Files{get;set;}
/// <summary>
/// Identifier of the node.
/// </summary>
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? NodeId{get;set;}
/// <summary>
/// Identifier of the backend node.
/// </summary>
[JsonPropertyName("backendNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? BackendNodeId{get;set;}
/// <summary>
/// JavaScript object id of the node wrapper.
/// </summary>
[JsonPropertyName("objectId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.RemoteObjectId? ObjectId{get;set;}
}
/// <summary>
/// Sets files for the given file input element.
/// </summary>
/// <param name="files">Array of file paths to set.</param>
/// <param name="nodeId">Identifier of the node.</param>
/// <param name="backendNodeId">Identifier of the backend node.</param>
/// <param name="objectId">JavaScript object id of the node wrapper.</param>
public async Task SetFileInputFiles(
 string[] @files,DOM.NodeId? @nodeId=default,DOM.BackendNodeId? @backendNodeId=default,Runtime.RemoteObjectId? @objectId=default) {
var resp = await _target.SendRequest("DOM.setFileInputFiles",
new SetFileInputFilesParams {
Files=@files,NodeId=@nodeId,BackendNodeId=@backendNodeId,ObjectId=@objectId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetNodeStackTracesEnabledParams {
/// <summary>
/// Enable or disable.
/// </summary>
[JsonPropertyName("enable")]public bool Enable{get;set;}
}
/// <summary>
/// Sets if stack traces should be captured for Nodes. See `Node.getNodeStackTraces`. Default is disabled.
/// </summary>
/// <param name="enable">Enable or disable.</param>
[Experimental]public async Task SetNodeStackTracesEnabled(
 bool @enable) {
var resp = await _target.SendRequest("DOM.setNodeStackTracesEnabled",
new SetNodeStackTracesEnabledParams {
Enable=@enable,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetNodeStackTracesParams {
/// <summary>
/// Id of the node to get stack traces for.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
public sealed partial class GetNodeStackTracesReturn {
/// <summary>
/// Creation stack trace, if available.
/// </summary>
[JsonPropertyName("creation")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.StackTrace? Creation{get;set;}
}
/// <summary>
/// Gets stack traces associated with a Node. As of now, only provides stack trace for Node creation.
/// </summary>
/// <param name="nodeId">Id of the node to get stack traces for.</param>
[Experimental]public async Task<GetNodeStackTracesReturn> GetNodeStackTraces(
 DOM.NodeId @nodeId) {
var resp = await _target.SendRequest("DOM.getNodeStackTraces",
new GetNodeStackTracesParams {
NodeId=@nodeId,});
return _target.DeserializeResponse<GetNodeStackTracesReturn>(resp);
}
public sealed partial class GetFileInfoParams {
/// <summary>
/// JavaScript object id of the node wrapper.
/// </summary>
[JsonPropertyName("objectId")]public Runtime.RemoteObjectId ObjectId{get;set;}
}
public sealed partial class GetFileInfoReturn {
[JsonPropertyName("path")]public string Path{get;set;}
}
/// <summary>
/// Returns file information for the given
/// File wrapper.
/// </summary>
/// <param name="objectId">JavaScript object id of the node wrapper.</param>
[Experimental]public async Task<GetFileInfoReturn> GetFileInfo(
 Runtime.RemoteObjectId @objectId) {
var resp = await _target.SendRequest("DOM.getFileInfo",
new GetFileInfoParams {
ObjectId=@objectId,});
return _target.DeserializeResponse<GetFileInfoReturn>(resp);
}
public sealed partial class SetInspectedNodeParams {
/// <summary>
/// DOM node id to be accessible by means of $x command line API.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
/// <summary>
/// Enables console to refer to the node with given id via $x (see Command Line API for more details
/// $x functions).
/// </summary>
/// <param name="nodeId">DOM node id to be accessible by means of $x command line API.</param>
[Experimental]public async Task SetInspectedNode(
 DOM.NodeId @nodeId) {
var resp = await _target.SendRequest("DOM.setInspectedNode",
new SetInspectedNodeParams {
NodeId=@nodeId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetNodeNameParams {
/// <summary>
/// Id of the node to set name for.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// New node's name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
}
public sealed partial class SetNodeNameReturn {
/// <summary>
/// New node's id.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
/// <summary>
/// Sets node name for a node with given id.
/// </summary>
/// <param name="nodeId">Id of the node to set name for.</param>
/// <param name="name">New node's name.</param>
public async Task<SetNodeNameReturn> SetNodeName(
 DOM.NodeId @nodeId,string @name) {
var resp = await _target.SendRequest("DOM.setNodeName",
new SetNodeNameParams {
NodeId=@nodeId,Name=@name,});
return _target.DeserializeResponse<SetNodeNameReturn>(resp);
}
public sealed partial class SetNodeValueParams {
/// <summary>
/// Id of the node to set value for.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// New node's value.
/// </summary>
[JsonPropertyName("value")]public string Value{get;set;}
}
/// <summary>
/// Sets node value for a node with given id.
/// </summary>
/// <param name="nodeId">Id of the node to set value for.</param>
/// <param name="value">New node's value.</param>
public async Task SetNodeValue(
 DOM.NodeId @nodeId,string @value) {
var resp = await _target.SendRequest("DOM.setNodeValue",
new SetNodeValueParams {
NodeId=@nodeId,Value=@value,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetOuterHTMLParams {
/// <summary>
/// Id of the node to set markup for.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// Outer HTML markup to set.
/// </summary>
[JsonPropertyName("outerHTML")]public string OuterHTML{get;set;}
}
/// <summary>
/// Sets node HTML markup, returns new node id.
/// </summary>
/// <param name="nodeId">Id of the node to set markup for.</param>
/// <param name="outerHTML">Outer HTML markup to set.</param>
public async Task SetOuterHTML(
 DOM.NodeId @nodeId,string @outerHTML) {
var resp = await _target.SendRequest("DOM.setOuterHTML",
new SetOuterHTMLParams {
NodeId=@nodeId,OuterHTML=@outerHTML,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Undoes the last performed action.
/// </summary>
[Experimental]public async Task Undo(
) {
var resp = await _target.SendRequest("DOM.undo",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetFrameOwnerParams {
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
}
public sealed partial class GetFrameOwnerReturn {
/// <summary>
/// Resulting node.
/// </summary>
[JsonPropertyName("backendNodeId")]public DOM.BackendNodeId BackendNodeId{get;set;}
/// <summary>
/// Id of the node at given coordinates, only when enabled and requested document.
/// </summary>
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? NodeId{get;set;}
}
/// <summary>
/// Returns iframe node that owns iframe with the given domain.
/// </summary>
/// <param name="frameId"></param>
[Experimental]public async Task<GetFrameOwnerReturn> GetFrameOwner(
 Page.FrameId @frameId) {
var resp = await _target.SendRequest("DOM.getFrameOwner",
new GetFrameOwnerParams {
FrameId=@frameId,});
return _target.DeserializeResponse<GetFrameOwnerReturn>(resp);
}
public sealed partial class GetContainerForNodeParams {
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
[JsonPropertyName("containerName")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ContainerName{get;set;}
}
public sealed partial class GetContainerForNodeReturn {
/// <summary>
/// The container node for the given node, or null if not found.
/// </summary>
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? NodeId{get;set;}
}
/// <summary>
/// Returns the container of the given node based on container query conditions.
/// If containerName is given, it will find the nearest container with a matching name;
/// otherwise it will find the nearest container regardless of its container name.
/// </summary>
/// <param name="nodeId"></param>
/// <param name="containerName"></param>
[Experimental]public async Task<GetContainerForNodeReturn> GetContainerForNode(
 DOM.NodeId @nodeId,string? @containerName=default) {
var resp = await _target.SendRequest("DOM.getContainerForNode",
new GetContainerForNodeParams {
NodeId=@nodeId,ContainerName=@containerName,});
return _target.DeserializeResponse<GetContainerForNodeReturn>(resp);
}
public sealed partial class GetQueryingDescendantsForContainerParams {
/// <summary>
/// Id of the container node to find querying descendants from.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
public sealed partial class GetQueryingDescendantsForContainerReturn {
/// <summary>
/// Descendant nodes with container queries against the given container.
/// </summary>
[JsonPropertyName("nodeIds")]public DOM.NodeId[] NodeIds{get;set;}
}
/// <summary>
/// Returns the descendants of a container query container that have
/// container queries against this container.
/// </summary>
/// <param name="nodeId">Id of the container node to find querying descendants from.</param>
[Experimental]public async Task<GetQueryingDescendantsForContainerReturn> GetQueryingDescendantsForContainer(
 DOM.NodeId @nodeId) {
var resp = await _target.SendRequest("DOM.getQueryingDescendantsForContainer",
new GetQueryingDescendantsForContainerParams {
NodeId=@nodeId,});
return _target.DeserializeResponse<GetQueryingDescendantsForContainerReturn>(resp);
}
public sealed partial class AttributeModifiedParams {
/// <summary>
/// Id of the node that has changed.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// Attribute name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Attribute value.
/// </summary>
[JsonPropertyName("value")]public string Value{get;set;}
}
private Action<AttributeModifiedParams>? _onAttributeModified;
/// <summary>
/// Fired when `Element`'s attribute is modified.
/// </summary>
public event Action<AttributeModifiedParams> OnAttributeModified {
add => _onAttributeModified += value; remove => _onAttributeModified -= value;}
public sealed partial class AttributeRemovedParams {
/// <summary>
/// Id of the node that has changed.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// A ttribute name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
}
private Action<AttributeRemovedParams>? _onAttributeRemoved;
/// <summary>
/// Fired when `Element`'s attribute is removed.
/// </summary>
public event Action<AttributeRemovedParams> OnAttributeRemoved {
add => _onAttributeRemoved += value; remove => _onAttributeRemoved -= value;}
public sealed partial class CharacterDataModifiedParams {
/// <summary>
/// Id of the node that has changed.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// New text value.
/// </summary>
[JsonPropertyName("characterData")]public string CharacterData{get;set;}
}
private Action<CharacterDataModifiedParams>? _onCharacterDataModified;
/// <summary>
/// Mirrors `DOMCharacterDataModified` event.
/// </summary>
public event Action<CharacterDataModifiedParams> OnCharacterDataModified {
add => _onCharacterDataModified += value; remove => _onCharacterDataModified -= value;}
public sealed partial class ChildNodeCountUpdatedParams {
/// <summary>
/// Id of the node that has changed.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// New node count.
/// </summary>
[JsonPropertyName("childNodeCount")]public long ChildNodeCount{get;set;}
}
private Action<ChildNodeCountUpdatedParams>? _onChildNodeCountUpdated;
/// <summary>
/// Fired when `Container`'s child node count has changed.
/// </summary>
public event Action<ChildNodeCountUpdatedParams> OnChildNodeCountUpdated {
add => _onChildNodeCountUpdated += value; remove => _onChildNodeCountUpdated -= value;}
public sealed partial class ChildNodeInsertedParams {
/// <summary>
/// Id of the node that has changed.
/// </summary>
[JsonPropertyName("parentNodeId")]public DOM.NodeId ParentNodeId{get;set;}
/// <summary>
/// If of the previous siblint.
/// </summary>
[JsonPropertyName("previousNodeId")]public DOM.NodeId PreviousNodeId{get;set;}
/// <summary>
/// Inserted node data.
/// </summary>
[JsonPropertyName("node")]public DOM.Node Node{get;set;}
}
private Action<ChildNodeInsertedParams>? _onChildNodeInserted;
/// <summary>
/// Mirrors `DOMNodeInserted` event.
/// </summary>
public event Action<ChildNodeInsertedParams> OnChildNodeInserted {
add => _onChildNodeInserted += value; remove => _onChildNodeInserted -= value;}
public sealed partial class ChildNodeRemovedParams {
/// <summary>
/// Parent id.
/// </summary>
[JsonPropertyName("parentNodeId")]public DOM.NodeId ParentNodeId{get;set;}
/// <summary>
/// Id of the node that has been removed.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
private Action<ChildNodeRemovedParams>? _onChildNodeRemoved;
/// <summary>
/// Mirrors `DOMNodeRemoved` event.
/// </summary>
public event Action<ChildNodeRemovedParams> OnChildNodeRemoved {
add => _onChildNodeRemoved += value; remove => _onChildNodeRemoved -= value;}
public sealed partial class DistributedNodesUpdatedParams {
/// <summary>
/// Insertion point where distributed nodes were updated.
/// </summary>
[JsonPropertyName("insertionPointId")]public DOM.NodeId InsertionPointId{get;set;}
/// <summary>
/// Distributed nodes for given insertion point.
/// </summary>
[JsonPropertyName("distributedNodes")]public DOM.BackendNode[] DistributedNodes{get;set;}
}
private Action<DistributedNodesUpdatedParams>? _onDistributedNodesUpdated;
/// <summary>
/// Called when distribution is changed.
/// </summary>
[Experimental]public event Action<DistributedNodesUpdatedParams> OnDistributedNodesUpdated {
add => _onDistributedNodesUpdated += value; remove => _onDistributedNodesUpdated -= value;}
private Action? _onDocumentUpdated;
/// <summary>
/// Fired when `Document` has been totally updated. Node ids are no longer valid.
/// </summary>
public event Action OnDocumentUpdated {
add => _onDocumentUpdated += value; remove => _onDocumentUpdated -= value;}
public sealed partial class InlineStyleInvalidatedParams {
/// <summary>
/// Ids of the nodes for which the inline styles have been invalidated.
/// </summary>
[JsonPropertyName("nodeIds")]public DOM.NodeId[] NodeIds{get;set;}
}
private Action<InlineStyleInvalidatedParams>? _onInlineStyleInvalidated;
/// <summary>
/// Fired when `Element`'s inline style is modified via a CSS property modification.
/// </summary>
[Experimental]public event Action<InlineStyleInvalidatedParams> OnInlineStyleInvalidated {
add => _onInlineStyleInvalidated += value; remove => _onInlineStyleInvalidated -= value;}
public sealed partial class PseudoElementAddedParams {
/// <summary>
/// Pseudo element's parent element id.
/// </summary>
[JsonPropertyName("parentId")]public DOM.NodeId ParentId{get;set;}
/// <summary>
/// The added pseudo element.
/// </summary>
[JsonPropertyName("pseudoElement")]public DOM.Node PseudoElement{get;set;}
}
private Action<PseudoElementAddedParams>? _onPseudoElementAdded;
/// <summary>
/// Called when a pseudo element is added to an element.
/// </summary>
[Experimental]public event Action<PseudoElementAddedParams> OnPseudoElementAdded {
add => _onPseudoElementAdded += value; remove => _onPseudoElementAdded -= value;}
public sealed partial class PseudoElementRemovedParams {
/// <summary>
/// Pseudo element's parent element id.
/// </summary>
[JsonPropertyName("parentId")]public DOM.NodeId ParentId{get;set;}
/// <summary>
/// The removed pseudo element id.
/// </summary>
[JsonPropertyName("pseudoElementId")]public DOM.NodeId PseudoElementId{get;set;}
}
private Action<PseudoElementRemovedParams>? _onPseudoElementRemoved;
/// <summary>
/// Called when a pseudo element is removed from an element.
/// </summary>
[Experimental]public event Action<PseudoElementRemovedParams> OnPseudoElementRemoved {
add => _onPseudoElementRemoved += value; remove => _onPseudoElementRemoved -= value;}
public sealed partial class SetChildNodesParams {
/// <summary>
/// Parent node id to populate with children.
/// </summary>
[JsonPropertyName("parentId")]public DOM.NodeId ParentId{get;set;}
/// <summary>
/// Child nodes array.
/// </summary>
[JsonPropertyName("nodes")]public DOM.Node[] Nodes{get;set;}
}
private Action<SetChildNodesParams>? _onSetChildNodes;
/// <summary>
/// Fired when backend wants to provide client with the missing DOM structure. This happens upon
/// most of the calls requesting node ids.
/// </summary>
public event Action<SetChildNodesParams> OnSetChildNodes {
add => _onSetChildNodes += value; remove => _onSetChildNodes -= value;}
public sealed partial class ShadowRootPoppedParams {
/// <summary>
/// Host element id.
/// </summary>
[JsonPropertyName("hostId")]public DOM.NodeId HostId{get;set;}
/// <summary>
/// Shadow root id.
/// </summary>
[JsonPropertyName("rootId")]public DOM.NodeId RootId{get;set;}
}
private Action<ShadowRootPoppedParams>? _onShadowRootPopped;
/// <summary>
/// Called when shadow root is popped from the element.
/// </summary>
[Experimental]public event Action<ShadowRootPoppedParams> OnShadowRootPopped {
add => _onShadowRootPopped += value; remove => _onShadowRootPopped -= value;}
public sealed partial class ShadowRootPushedParams {
/// <summary>
/// Host element id.
/// </summary>
[JsonPropertyName("hostId")]public DOM.NodeId HostId{get;set;}
/// <summary>
/// Shadow root.
/// </summary>
[JsonPropertyName("root")]public DOM.Node Root{get;set;}
}
private Action<ShadowRootPushedParams>? _onShadowRootPushed;
/// <summary>
/// Called when shadow root is pushed into the element.
/// </summary>
[Experimental]public event Action<ShadowRootPushedParams> OnShadowRootPushed {
add => _onShadowRootPushed += value; remove => _onShadowRootPushed -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "DOM.attributeModified":
_onAttributeModified?.Invoke(_target.DeserializeEvent<AttributeModifiedParams>(data));
break;
case "DOM.attributeRemoved":
_onAttributeRemoved?.Invoke(_target.DeserializeEvent<AttributeRemovedParams>(data));
break;
case "DOM.characterDataModified":
_onCharacterDataModified?.Invoke(_target.DeserializeEvent<CharacterDataModifiedParams>(data));
break;
case "DOM.childNodeCountUpdated":
_onChildNodeCountUpdated?.Invoke(_target.DeserializeEvent<ChildNodeCountUpdatedParams>(data));
break;
case "DOM.childNodeInserted":
_onChildNodeInserted?.Invoke(_target.DeserializeEvent<ChildNodeInsertedParams>(data));
break;
case "DOM.childNodeRemoved":
_onChildNodeRemoved?.Invoke(_target.DeserializeEvent<ChildNodeRemovedParams>(data));
break;
case "DOM.distributedNodesUpdated":
_onDistributedNodesUpdated?.Invoke(_target.DeserializeEvent<DistributedNodesUpdatedParams>(data));
break;
case "DOM.documentUpdated":
_onDocumentUpdated?.Invoke();
break;
case "DOM.inlineStyleInvalidated":
_onInlineStyleInvalidated?.Invoke(_target.DeserializeEvent<InlineStyleInvalidatedParams>(data));
break;
case "DOM.pseudoElementAdded":
_onPseudoElementAdded?.Invoke(_target.DeserializeEvent<PseudoElementAddedParams>(data));
break;
case "DOM.pseudoElementRemoved":
_onPseudoElementRemoved?.Invoke(_target.DeserializeEvent<PseudoElementRemovedParams>(data));
break;
case "DOM.setChildNodes":
_onSetChildNodes?.Invoke(_target.DeserializeEvent<SetChildNodesParams>(data));
break;
case "DOM.shadowRootPopped":
_onShadowRootPopped?.Invoke(_target.DeserializeEvent<ShadowRootPoppedParams>(data));
break;
case "DOM.shadowRootPushed":
_onShadowRootPushed?.Invoke(_target.DeserializeEvent<ShadowRootPushedParams>(data));
break;
default:
_onUnknownEvent?.Invoke(method, data);
break;
}}
private Action<string, ArraySegment<byte>>? _onUnknownEvent;
public event Action<string, ArraySegment<byte>> OnUnknownEvent {
add => _onUnknownEvent += value; remove => _onUnknownEvent -= value;}
public void DisconnectEvents() {
_onUnknownEvent = null;
_onAttributeModified = null;
_onAttributeRemoved = null;
_onCharacterDataModified = null;
_onChildNodeCountUpdated = null;
_onChildNodeInserted = null;
_onChildNodeRemoved = null;
_onDistributedNodesUpdated = null;
_onDocumentUpdated = null;
_onInlineStyleInvalidated = null;
_onPseudoElementAdded = null;
_onPseudoElementRemoved = null;
_onSetChildNodes = null;
_onShadowRootPopped = null;
_onShadowRootPushed = null;
}
}
