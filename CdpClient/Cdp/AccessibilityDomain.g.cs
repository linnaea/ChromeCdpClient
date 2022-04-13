using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
[Experimental]public sealed partial class AccessibilityDomain {
private readonly ConnectedTarget _target;
public AccessibilityDomain(ConnectedTarget target) => _target = target;
/// <summary>
/// Disables the accessibility domain.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("Accessibility.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Enables the accessibility domain which causes `AXNodeId`s to remain consistent between method calls.
/// This turns on accessibility for the page, which can impact performance until accessibility is disabled.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("Accessibility.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetPartialAXTreeParams {
/// <summary>
/// Identifier of the node to get the partial accessibility tree for.
/// </summary>
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? NodeId{get;set;}
/// <summary>
/// Identifier of the backend node to get the partial accessibility tree for.
/// </summary>
[JsonPropertyName("backendNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? BackendNodeId{get;set;}
/// <summary>
/// JavaScript object id of the node wrapper to get the partial accessibility tree for.
/// </summary>
[JsonPropertyName("objectId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.RemoteObjectId? ObjectId{get;set;}
/// <summary>
/// Whether to fetch this nodes ancestors, siblings and children. Defaults to true.
/// </summary>
[JsonPropertyName("fetchRelatives")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? FetchRelatives{get;set;}
}
public sealed partial class GetPartialAXTreeReturn {
/// <summary>
/// The `Accessibility.AXNode` for this DOM node, if it exists, plus its ancestors, siblings and
/// children, if requested.
/// </summary>
[JsonPropertyName("nodes")]public Accessibility.AXNode[] Nodes{get;set;}
}
/// <summary>
/// Fetches the accessibility node and partial accessibility tree for this DOM node, if it exists.
/// </summary>
/// <param name="nodeId">Identifier of the node to get the partial accessibility tree for.</param>
/// <param name="backendNodeId">Identifier of the backend node to get the partial accessibility tree for.</param>
/// <param name="objectId">JavaScript object id of the node wrapper to get the partial accessibility tree for.</param>
/// <param name="fetchRelatives">Whether to fetch this nodes ancestors, siblings and children. Defaults to true.</param>
[Experimental]public async Task<GetPartialAXTreeReturn> GetPartialAXTree(
 DOM.NodeId? @nodeId=default,DOM.BackendNodeId? @backendNodeId=default,Runtime.RemoteObjectId? @objectId=default,bool? @fetchRelatives=default) {
var resp = await _target.SendRequest("Accessibility.getPartialAXTree",
new GetPartialAXTreeParams {
NodeId=@nodeId,BackendNodeId=@backendNodeId,ObjectId=@objectId,FetchRelatives=@fetchRelatives,});
return _target.DeserializeResponse<GetPartialAXTreeReturn>(resp);
}
public sealed partial class GetFullAXTreeParams {
/// <summary>
/// The maximum depth at which descendants of the root node should be retrieved.
/// If omitted, the full tree is returned.
/// </summary>
[JsonPropertyName("depth")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Depth{get;set;}
/// <summary>
/// The frame for whose document the AX tree should be retrieved.
/// If omited, the root frame is used.
/// </summary>
[JsonPropertyName("frameId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.FrameId? FrameId{get;set;}
}
public sealed partial class GetFullAXTreeReturn {
[JsonPropertyName("nodes")]public Accessibility.AXNode[] Nodes{get;set;}
}
/// <summary>
/// Fetches the entire accessibility tree for the root Document
/// </summary>
/// <param name="depth">The maximum depth at which descendants of the root node should be retrieved.
/// If omitted, the full tree is returned.</param>
/// <param name="frameId">The frame for whose document the AX tree should be retrieved.
/// If omited, the root frame is used.</param>
[Experimental]public async Task<GetFullAXTreeReturn> GetFullAXTree(
 long? @depth=default,Page.FrameId? @frameId=default) {
var resp = await _target.SendRequest("Accessibility.getFullAXTree",
new GetFullAXTreeParams {
Depth=@depth,FrameId=@frameId,});
return _target.DeserializeResponse<GetFullAXTreeReturn>(resp);
}
public sealed partial class GetRootAXNodeParams {
/// <summary>
/// The frame in whose document the node resides.
/// If omitted, the root frame is used.
/// </summary>
[JsonPropertyName("frameId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.FrameId? FrameId{get;set;}
}
public sealed partial class GetRootAXNodeReturn {
[JsonPropertyName("node")]public Accessibility.AXNode Node{get;set;}
}
/// <summary>
/// Fetches the root node.
/// Requires `enable()` to have been called previously.
/// </summary>
/// <param name="frameId">The frame in whose document the node resides.
/// If omitted, the root frame is used.</param>
[Experimental]public async Task<GetRootAXNodeReturn> GetRootAXNode(
 Page.FrameId? @frameId=default) {
var resp = await _target.SendRequest("Accessibility.getRootAXNode",
new GetRootAXNodeParams {
FrameId=@frameId,});
return _target.DeserializeResponse<GetRootAXNodeReturn>(resp);
}
public sealed partial class GetAXNodeAndAncestorsParams {
/// <summary>
/// Identifier of the node to get.
/// </summary>
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? NodeId{get;set;}
/// <summary>
/// Identifier of the backend node to get.
/// </summary>
[JsonPropertyName("backendNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? BackendNodeId{get;set;}
/// <summary>
/// JavaScript object id of the node wrapper to get.
/// </summary>
[JsonPropertyName("objectId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.RemoteObjectId? ObjectId{get;set;}
}
public sealed partial class GetAXNodeAndAncestorsReturn {
[JsonPropertyName("nodes")]public Accessibility.AXNode[] Nodes{get;set;}
}
/// <summary>
/// Fetches a node and all ancestors up to and including the root.
/// Requires `enable()` to have been called previously.
/// </summary>
/// <param name="nodeId">Identifier of the node to get.</param>
/// <param name="backendNodeId">Identifier of the backend node to get.</param>
/// <param name="objectId">JavaScript object id of the node wrapper to get.</param>
[Experimental]public async Task<GetAXNodeAndAncestorsReturn> GetAXNodeAndAncestors(
 DOM.NodeId? @nodeId=default,DOM.BackendNodeId? @backendNodeId=default,Runtime.RemoteObjectId? @objectId=default) {
var resp = await _target.SendRequest("Accessibility.getAXNodeAndAncestors",
new GetAXNodeAndAncestorsParams {
NodeId=@nodeId,BackendNodeId=@backendNodeId,ObjectId=@objectId,});
return _target.DeserializeResponse<GetAXNodeAndAncestorsReturn>(resp);
}
public sealed partial class GetChildAXNodesParams {
[JsonPropertyName("id")]public Accessibility.AXNodeId Id{get;set;}
/// <summary>
/// The frame in whose document the node resides.
/// If omitted, the root frame is used.
/// </summary>
[JsonPropertyName("frameId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.FrameId? FrameId{get;set;}
}
public sealed partial class GetChildAXNodesReturn {
[JsonPropertyName("nodes")]public Accessibility.AXNode[] Nodes{get;set;}
}
/// <summary>
/// Fetches a particular accessibility node by AXNodeId.
/// Requires `enable()` to have been called previously.
/// </summary>
/// <param name="id"></param>
/// <param name="frameId">The frame in whose document the node resides.
/// If omitted, the root frame is used.</param>
[Experimental]public async Task<GetChildAXNodesReturn> GetChildAXNodes(
 Accessibility.AXNodeId @id,Page.FrameId? @frameId=default) {
var resp = await _target.SendRequest("Accessibility.getChildAXNodes",
new GetChildAXNodesParams {
Id=@id,FrameId=@frameId,});
return _target.DeserializeResponse<GetChildAXNodesReturn>(resp);
}
public sealed partial class QueryAXTreeParams {
/// <summary>
/// Identifier of the node for the root to query.
/// </summary>
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? NodeId{get;set;}
/// <summary>
/// Identifier of the backend node for the root to query.
/// </summary>
[JsonPropertyName("backendNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? BackendNodeId{get;set;}
/// <summary>
/// JavaScript object id of the node wrapper for the root to query.
/// </summary>
[JsonPropertyName("objectId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.RemoteObjectId? ObjectId{get;set;}
/// <summary>
/// Find nodes with this computed name.
/// </summary>
[JsonPropertyName("accessibleName")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? AccessibleName{get;set;}
/// <summary>
/// Find nodes with this computed role.
/// </summary>
[JsonPropertyName("role")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Role{get;set;}
}
public sealed partial class QueryAXTreeReturn {
/// <summary>
/// A list of `Accessibility.AXNode` matching the specified attributes,
/// including nodes that are ignored for accessibility.
/// </summary>
[JsonPropertyName("nodes")]public Accessibility.AXNode[] Nodes{get;set;}
}
/// <summary>
/// Query a DOM node's accessibility subtree for accessible name and role.
/// This command computes the name and role for all nodes in the subtree, including those that are
/// ignored for accessibility, and returns those that mactch the specified name and role. If no DOM
/// node is specified, or the DOM node does not exist, the command returns an error. If neither
/// `accessibleName` or `role` is specified, it returns all the accessibility nodes in the subtree.
/// </summary>
/// <param name="nodeId">Identifier of the node for the root to query.</param>
/// <param name="backendNodeId">Identifier of the backend node for the root to query.</param>
/// <param name="objectId">JavaScript object id of the node wrapper for the root to query.</param>
/// <param name="accessibleName">Find nodes with this computed name.</param>
/// <param name="role">Find nodes with this computed role.</param>
[Experimental]public async Task<QueryAXTreeReturn> QueryAXTree(
 DOM.NodeId? @nodeId=default,DOM.BackendNodeId? @backendNodeId=default,Runtime.RemoteObjectId? @objectId=default,string? @accessibleName=default,string? @role=default) {
var resp = await _target.SendRequest("Accessibility.queryAXTree",
new QueryAXTreeParams {
NodeId=@nodeId,BackendNodeId=@backendNodeId,ObjectId=@objectId,AccessibleName=@accessibleName,Role=@role,});
return _target.DeserializeResponse<QueryAXTreeReturn>(resp);
}
public sealed partial class LoadCompleteParams {
/// <summary>
/// New document root node.
/// </summary>
[JsonPropertyName("root")]public Accessibility.AXNode Root{get;set;}
}
private Action<LoadCompleteParams>? _onLoadComplete;
/// <summary>
/// The loadComplete event mirrors the load complete event sent by the browser to assistive
/// technology when the web page has finished loading.
/// </summary>
[Experimental]public event Action<LoadCompleteParams> OnLoadComplete {
add => _onLoadComplete += value; remove => _onLoadComplete -= value;}
public sealed partial class NodesUpdatedParams {
/// <summary>
/// Updated node data.
/// </summary>
[JsonPropertyName("nodes")]public Accessibility.AXNode[] Nodes{get;set;}
}
private Action<NodesUpdatedParams>? _onNodesUpdated;
/// <summary>
/// The nodesUpdated event is sent every time a previously requested node has changed the in tree.
/// </summary>
[Experimental]public event Action<NodesUpdatedParams> OnNodesUpdated {
add => _onNodesUpdated += value; remove => _onNodesUpdated -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Accessibility.loadComplete":
_onLoadComplete?.Invoke(_target.DeserializeEvent<LoadCompleteParams>(data));
break;
case "Accessibility.nodesUpdated":
_onNodesUpdated?.Invoke(_target.DeserializeEvent<NodesUpdatedParams>(data));
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
_onLoadComplete = null;
_onNodesUpdated = null;
}
}
