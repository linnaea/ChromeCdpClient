using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// This domain provides various functionality related to drawing atop the inspected page.
/// </summary>
[Experimental]public sealed partial class OverlayDomain {
private readonly ConnectedTarget _target;
public OverlayDomain(ConnectedTarget target) => _target = target;
/// <summary>
/// Disables domain notifications.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("Overlay.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Enables domain notifications.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("Overlay.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetHighlightObjectForTestParams {
/// <summary>
/// Id of the node to get highlight object for.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// Whether to include distance info.
/// </summary>
[JsonPropertyName("includeDistance")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IncludeDistance{get;set;}
/// <summary>
/// Whether to include style info.
/// </summary>
[JsonPropertyName("includeStyle")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IncludeStyle{get;set;}
/// <summary>
/// The color format to get config with (default: hex).
/// </summary>
[JsonPropertyName("colorFormat")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Overlay.ColorFormat? ColorFormat{get;set;}
/// <summary>
/// Whether to show accessibility info (default: true).
/// </summary>
[JsonPropertyName("showAccessibilityInfo")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ShowAccessibilityInfo{get;set;}
}
public sealed partial class GetHighlightObjectForTestReturn {
/// <summary>
/// Highlight data for the node.
/// </summary>
[JsonPropertyName("highlight")]public object Highlight{get;set;}
}
/// <summary>
/// For testing.
/// </summary>
/// <param name="nodeId">Id of the node to get highlight object for.</param>
/// <param name="includeDistance">Whether to include distance info.</param>
/// <param name="includeStyle">Whether to include style info.</param>
/// <param name="colorFormat">The color format to get config with (default: hex).</param>
/// <param name="showAccessibilityInfo">Whether to show accessibility info (default: true).</param>
public async Task<GetHighlightObjectForTestReturn> GetHighlightObjectForTest(
 DOM.NodeId @nodeId,bool? @includeDistance=default,bool? @includeStyle=default,Overlay.ColorFormat? @colorFormat=default,bool? @showAccessibilityInfo=default) {
var resp = await _target.SendRequest("Overlay.getHighlightObjectForTest",
new GetHighlightObjectForTestParams {
NodeId=@nodeId,IncludeDistance=@includeDistance,IncludeStyle=@includeStyle,ColorFormat=@colorFormat,ShowAccessibilityInfo=@showAccessibilityInfo,});
return _target.DeserializeResponse<GetHighlightObjectForTestReturn>(resp);
}
public sealed partial class GetGridHighlightObjectsForTestParams {
/// <summary>
/// Ids of the node to get highlight object for.
/// </summary>
[JsonPropertyName("nodeIds")]public DOM.NodeId[] NodeIds{get;set;}
}
public sealed partial class GetGridHighlightObjectsForTestReturn {
/// <summary>
/// Grid Highlight data for the node ids provided.
/// </summary>
[JsonPropertyName("highlights")]public object Highlights{get;set;}
}
/// <summary>
/// For Persistent Grid testing.
/// </summary>
/// <param name="nodeIds">Ids of the node to get highlight object for.</param>
public async Task<GetGridHighlightObjectsForTestReturn> GetGridHighlightObjectsForTest(
 DOM.NodeId[] @nodeIds) {
var resp = await _target.SendRequest("Overlay.getGridHighlightObjectsForTest",
new GetGridHighlightObjectsForTestParams {
NodeIds=@nodeIds,});
return _target.DeserializeResponse<GetGridHighlightObjectsForTestReturn>(resp);
}
public sealed partial class GetSourceOrderHighlightObjectForTestParams {
/// <summary>
/// Id of the node to highlight.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
public sealed partial class GetSourceOrderHighlightObjectForTestReturn {
/// <summary>
/// Source order highlight data for the node id provided.
/// </summary>
[JsonPropertyName("highlight")]public object Highlight{get;set;}
}
/// <summary>
/// For Source Order Viewer testing.
/// </summary>
/// <param name="nodeId">Id of the node to highlight.</param>
public async Task<GetSourceOrderHighlightObjectForTestReturn> GetSourceOrderHighlightObjectForTest(
 DOM.NodeId @nodeId) {
var resp = await _target.SendRequest("Overlay.getSourceOrderHighlightObjectForTest",
new GetSourceOrderHighlightObjectForTestParams {
NodeId=@nodeId,});
return _target.DeserializeResponse<GetSourceOrderHighlightObjectForTestReturn>(resp);
}
/// <summary>
/// Hides any highlight.
/// </summary>
public async Task HideHighlight(
) {
var resp = await _target.SendRequest("Overlay.hideHighlight",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class HighlightFrameParams {
/// <summary>
/// Identifier of the frame to highlight.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// The content box highlight fill color (default: transparent).
/// </summary>
[JsonPropertyName("contentColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? ContentColor{get;set;}
/// <summary>
/// The content box highlight outline color (default: transparent).
/// </summary>
[JsonPropertyName("contentOutlineColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? ContentOutlineColor{get;set;}
}
/// <summary>
/// Highlights owner element of the frame with given id.
/// Deprecated: Doesn't work reliablity and cannot be fixed due to process
/// separatation (the owner node might be in a different process). Determine
/// the owner node in the client and use highlightNode.
/// </summary>
/// <param name="frameId">Identifier of the frame to highlight.</param>
/// <param name="contentColor">The content box highlight fill color (default: transparent).</param>
/// <param name="contentOutlineColor">The content box highlight outline color (default: transparent).</param>
[Obsolete]public async Task HighlightFrame(
 Page.FrameId @frameId,DOM.RGBA? @contentColor=default,DOM.RGBA? @contentOutlineColor=default) {
var resp = await _target.SendRequest("Overlay.highlightFrame",
new HighlightFrameParams {
FrameId=@frameId,ContentColor=@contentColor,ContentOutlineColor=@contentOutlineColor,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class HighlightNodeParams {
/// <summary>
/// A descriptor for the highlight appearance.
/// </summary>
[JsonPropertyName("highlightConfig")]public Overlay.HighlightConfig HighlightConfig{get;set;}
/// <summary>
/// Identifier of the node to highlight.
/// </summary>
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? NodeId{get;set;}
/// <summary>
/// Identifier of the backend node to highlight.
/// </summary>
[JsonPropertyName("backendNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? BackendNodeId{get;set;}
/// <summary>
/// JavaScript object id of the node to be highlighted.
/// </summary>
[JsonPropertyName("objectId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.RemoteObjectId? ObjectId{get;set;}
/// <summary>
/// Selectors to highlight relevant nodes.
/// </summary>
[JsonPropertyName("selector")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Selector{get;set;}
}
/// <summary>
/// Highlights DOM node with given id or with the given JavaScript object wrapper. Either nodeId or
/// objectId must be specified.
/// </summary>
/// <param name="highlightConfig">A descriptor for the highlight appearance.</param>
/// <param name="nodeId">Identifier of the node to highlight.</param>
/// <param name="backendNodeId">Identifier of the backend node to highlight.</param>
/// <param name="objectId">JavaScript object id of the node to be highlighted.</param>
/// <param name="selector">Selectors to highlight relevant nodes.</param>
public async Task HighlightNode(
 Overlay.HighlightConfig @highlightConfig,DOM.NodeId? @nodeId=default,DOM.BackendNodeId? @backendNodeId=default,Runtime.RemoteObjectId? @objectId=default,string? @selector=default) {
var resp = await _target.SendRequest("Overlay.highlightNode",
new HighlightNodeParams {
HighlightConfig=@highlightConfig,NodeId=@nodeId,BackendNodeId=@backendNodeId,ObjectId=@objectId,Selector=@selector,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class HighlightQuadParams {
/// <summary>
/// Quad to highlight
/// </summary>
[JsonPropertyName("quad")]public DOM.Quad Quad{get;set;}
/// <summary>
/// The highlight fill color (default: transparent).
/// </summary>
[JsonPropertyName("color")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? Color{get;set;}
/// <summary>
/// The highlight outline color (default: transparent).
/// </summary>
[JsonPropertyName("outlineColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? OutlineColor{get;set;}
}
/// <summary>
/// Highlights given quad. Coordinates are absolute with respect to the main frame viewport.
/// </summary>
/// <param name="quad">Quad to highlight</param>
/// <param name="color">The highlight fill color (default: transparent).</param>
/// <param name="outlineColor">The highlight outline color (default: transparent).</param>
public async Task HighlightQuad(
 DOM.Quad @quad,DOM.RGBA? @color=default,DOM.RGBA? @outlineColor=default) {
var resp = await _target.SendRequest("Overlay.highlightQuad",
new HighlightQuadParams {
Quad=@quad,Color=@color,OutlineColor=@outlineColor,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class HighlightRectParams {
/// <summary>
/// X coordinate
/// </summary>
[JsonPropertyName("x")]public long X{get;set;}
/// <summary>
/// Y coordinate
/// </summary>
[JsonPropertyName("y")]public long Y{get;set;}
/// <summary>
/// Rectangle width
/// </summary>
[JsonPropertyName("width")]public long Width{get;set;}
/// <summary>
/// Rectangle height
/// </summary>
[JsonPropertyName("height")]public long Height{get;set;}
/// <summary>
/// The highlight fill color (default: transparent).
/// </summary>
[JsonPropertyName("color")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? Color{get;set;}
/// <summary>
/// The highlight outline color (default: transparent).
/// </summary>
[JsonPropertyName("outlineColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? OutlineColor{get;set;}
}
/// <summary>
/// Highlights given rectangle. Coordinates are absolute with respect to the main frame viewport.
/// </summary>
/// <param name="x">X coordinate</param>
/// <param name="y">Y coordinate</param>
/// <param name="width">Rectangle width</param>
/// <param name="height">Rectangle height</param>
/// <param name="color">The highlight fill color (default: transparent).</param>
/// <param name="outlineColor">The highlight outline color (default: transparent).</param>
public async Task HighlightRect(
 long @x,long @y,long @width,long @height,DOM.RGBA? @color=default,DOM.RGBA? @outlineColor=default) {
var resp = await _target.SendRequest("Overlay.highlightRect",
new HighlightRectParams {
X=@x,Y=@y,Width=@width,Height=@height,Color=@color,OutlineColor=@outlineColor,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class HighlightSourceOrderParams {
/// <summary>
/// A descriptor for the appearance of the overlay drawing.
/// </summary>
[JsonPropertyName("sourceOrderConfig")]public Overlay.SourceOrderConfig SourceOrderConfig{get;set;}
/// <summary>
/// Identifier of the node to highlight.
/// </summary>
[JsonPropertyName("nodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.NodeId? NodeId{get;set;}
/// <summary>
/// Identifier of the backend node to highlight.
/// </summary>
[JsonPropertyName("backendNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? BackendNodeId{get;set;}
/// <summary>
/// JavaScript object id of the node to be highlighted.
/// </summary>
[JsonPropertyName("objectId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.RemoteObjectId? ObjectId{get;set;}
}
/// <summary>
/// Highlights the source order of the children of the DOM node with given id or with the given
/// JavaScript object wrapper. Either nodeId or objectId must be specified.
/// </summary>
/// <param name="sourceOrderConfig">A descriptor for the appearance of the overlay drawing.</param>
/// <param name="nodeId">Identifier of the node to highlight.</param>
/// <param name="backendNodeId">Identifier of the backend node to highlight.</param>
/// <param name="objectId">JavaScript object id of the node to be highlighted.</param>
public async Task HighlightSourceOrder(
 Overlay.SourceOrderConfig @sourceOrderConfig,DOM.NodeId? @nodeId=default,DOM.BackendNodeId? @backendNodeId=default,Runtime.RemoteObjectId? @objectId=default) {
var resp = await _target.SendRequest("Overlay.highlightSourceOrder",
new HighlightSourceOrderParams {
SourceOrderConfig=@sourceOrderConfig,NodeId=@nodeId,BackendNodeId=@backendNodeId,ObjectId=@objectId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetInspectModeParams {
/// <summary>
/// Set an inspection mode.
/// </summary>
[JsonPropertyName("mode")]public Overlay.InspectMode Mode{get;set;}
/// <summary>
/// A descriptor for the highlight appearance of hovered-over nodes. May be omitted if `enabled
/// == false`.
/// </summary>
[JsonPropertyName("highlightConfig")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Overlay.HighlightConfig? HighlightConfig{get;set;}
}
/// <summary>
/// Enters the 'inspect' mode. In this mode, elements that user is hovering over are highlighted.
/// Backend then generates 'inspectNodeRequested' event upon element selection.
/// </summary>
/// <param name="mode">Set an inspection mode.</param>
/// <param name="highlightConfig">A descriptor for the highlight appearance of hovered-over nodes. May be omitted if `enabled
/// == false`.</param>
public async Task SetInspectMode(
 Overlay.InspectMode @mode,Overlay.HighlightConfig? @highlightConfig=default) {
var resp = await _target.SendRequest("Overlay.setInspectMode",
new SetInspectModeParams {
Mode=@mode,HighlightConfig=@highlightConfig,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetShowAdHighlightsParams {
/// <summary>
/// True for showing ad highlights
/// </summary>
[JsonPropertyName("show")]public bool Show{get;set;}
}
/// <summary>
/// Highlights owner element of all frames detected to be ads.
/// </summary>
/// <param name="show">True for showing ad highlights</param>
public async Task SetShowAdHighlights(
 bool @show) {
var resp = await _target.SendRequest("Overlay.setShowAdHighlights",
new SetShowAdHighlightsParams {
Show=@show,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetPausedInDebuggerMessageParams {
/// <summary>
/// The message to display, also triggers resume and step over controls.
/// </summary>
[JsonPropertyName("message")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Message{get;set;}
}
/// <param name="message">The message to display, also triggers resume and step over controls.</param>
public async Task SetPausedInDebuggerMessage(
 string? @message=default) {
var resp = await _target.SendRequest("Overlay.setPausedInDebuggerMessage",
new SetPausedInDebuggerMessageParams {
Message=@message,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetShowDebugBordersParams {
/// <summary>
/// True for showing debug borders
/// </summary>
[JsonPropertyName("show")]public bool Show{get;set;}
}
/// <summary>
/// Requests that backend shows debug borders on layers
/// </summary>
/// <param name="show">True for showing debug borders</param>
public async Task SetShowDebugBorders(
 bool @show) {
var resp = await _target.SendRequest("Overlay.setShowDebugBorders",
new SetShowDebugBordersParams {
Show=@show,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetShowFPSCounterParams {
/// <summary>
/// True for showing the FPS counter
/// </summary>
[JsonPropertyName("show")]public bool Show{get;set;}
}
/// <summary>
/// Requests that backend shows the FPS counter
/// </summary>
/// <param name="show">True for showing the FPS counter</param>
public async Task SetShowFPSCounter(
 bool @show) {
var resp = await _target.SendRequest("Overlay.setShowFPSCounter",
new SetShowFPSCounterParams {
Show=@show,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetShowGridOverlaysParams {
/// <summary>
/// An array of node identifiers and descriptors for the highlight appearance.
/// </summary>
[JsonPropertyName("gridNodeHighlightConfigs")]public Overlay.GridNodeHighlightConfig[] GridNodeHighlightConfigs{get;set;}
}
/// <summary>
/// Highlight multiple elements with the CSS Grid overlay.
/// </summary>
/// <param name="gridNodeHighlightConfigs">An array of node identifiers and descriptors for the highlight appearance.</param>
public async Task SetShowGridOverlays(
 Overlay.GridNodeHighlightConfig[] @gridNodeHighlightConfigs) {
var resp = await _target.SendRequest("Overlay.setShowGridOverlays",
new SetShowGridOverlaysParams {
GridNodeHighlightConfigs=@gridNodeHighlightConfigs,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetShowFlexOverlaysParams {
/// <summary>
/// An array of node identifiers and descriptors for the highlight appearance.
/// </summary>
[JsonPropertyName("flexNodeHighlightConfigs")]public Overlay.FlexNodeHighlightConfig[] FlexNodeHighlightConfigs{get;set;}
}
/// <param name="flexNodeHighlightConfigs">An array of node identifiers and descriptors for the highlight appearance.</param>
public async Task SetShowFlexOverlays(
 Overlay.FlexNodeHighlightConfig[] @flexNodeHighlightConfigs) {
var resp = await _target.SendRequest("Overlay.setShowFlexOverlays",
new SetShowFlexOverlaysParams {
FlexNodeHighlightConfigs=@flexNodeHighlightConfigs,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetShowScrollSnapOverlaysParams {
/// <summary>
/// An array of node identifiers and descriptors for the highlight appearance.
/// </summary>
[JsonPropertyName("scrollSnapHighlightConfigs")]public Overlay.ScrollSnapHighlightConfig[] ScrollSnapHighlightConfigs{get;set;}
}
/// <param name="scrollSnapHighlightConfigs">An array of node identifiers and descriptors for the highlight appearance.</param>
public async Task SetShowScrollSnapOverlays(
 Overlay.ScrollSnapHighlightConfig[] @scrollSnapHighlightConfigs) {
var resp = await _target.SendRequest("Overlay.setShowScrollSnapOverlays",
new SetShowScrollSnapOverlaysParams {
ScrollSnapHighlightConfigs=@scrollSnapHighlightConfigs,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetShowContainerQueryOverlaysParams {
/// <summary>
/// An array of node identifiers and descriptors for the highlight appearance.
/// </summary>
[JsonPropertyName("containerQueryHighlightConfigs")]public Overlay.ContainerQueryHighlightConfig[] ContainerQueryHighlightConfigs{get;set;}
}
/// <param name="containerQueryHighlightConfigs">An array of node identifiers and descriptors for the highlight appearance.</param>
public async Task SetShowContainerQueryOverlays(
 Overlay.ContainerQueryHighlightConfig[] @containerQueryHighlightConfigs) {
var resp = await _target.SendRequest("Overlay.setShowContainerQueryOverlays",
new SetShowContainerQueryOverlaysParams {
ContainerQueryHighlightConfigs=@containerQueryHighlightConfigs,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetShowPaintRectsParams {
/// <summary>
/// True for showing paint rectangles
/// </summary>
[JsonPropertyName("result")]public bool Result{get;set;}
}
/// <summary>
/// Requests that backend shows paint rectangles
/// </summary>
/// <param name="result">True for showing paint rectangles</param>
public async Task SetShowPaintRects(
 bool @result) {
var resp = await _target.SendRequest("Overlay.setShowPaintRects",
new SetShowPaintRectsParams {
Result=@result,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetShowLayoutShiftRegionsParams {
/// <summary>
/// True for showing layout shift regions
/// </summary>
[JsonPropertyName("result")]public bool Result{get;set;}
}
/// <summary>
/// Requests that backend shows layout shift regions
/// </summary>
/// <param name="result">True for showing layout shift regions</param>
public async Task SetShowLayoutShiftRegions(
 bool @result) {
var resp = await _target.SendRequest("Overlay.setShowLayoutShiftRegions",
new SetShowLayoutShiftRegionsParams {
Result=@result,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetShowScrollBottleneckRectsParams {
/// <summary>
/// True for showing scroll bottleneck rects
/// </summary>
[JsonPropertyName("show")]public bool Show{get;set;}
}
/// <summary>
/// Requests that backend shows scroll bottleneck rects
/// </summary>
/// <param name="show">True for showing scroll bottleneck rects</param>
public async Task SetShowScrollBottleneckRects(
 bool @show) {
var resp = await _target.SendRequest("Overlay.setShowScrollBottleneckRects",
new SetShowScrollBottleneckRectsParams {
Show=@show,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetShowHitTestBordersParams {
/// <summary>
/// True for showing hit-test borders
/// </summary>
[JsonPropertyName("show")]public bool Show{get;set;}
}
/// <summary>
/// Deprecated, no longer has any effect.
/// </summary>
/// <param name="show">True for showing hit-test borders</param>
[Obsolete]public async Task SetShowHitTestBorders(
 bool @show) {
var resp = await _target.SendRequest("Overlay.setShowHitTestBorders",
new SetShowHitTestBordersParams {
Show=@show,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetShowWebVitalsParams {
[JsonPropertyName("show")]public bool Show{get;set;}
}
/// <summary>
/// Request that backend shows an overlay with web vital metrics.
/// </summary>
/// <param name="show"></param>
public async Task SetShowWebVitals(
 bool @show) {
var resp = await _target.SendRequest("Overlay.setShowWebVitals",
new SetShowWebVitalsParams {
Show=@show,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetShowViewportSizeOnResizeParams {
/// <summary>
/// Whether to paint size or not.
/// </summary>
[JsonPropertyName("show")]public bool Show{get;set;}
}
/// <summary>
/// Paints viewport size upon main frame resize.
/// </summary>
/// <param name="show">Whether to paint size or not.</param>
public async Task SetShowViewportSizeOnResize(
 bool @show) {
var resp = await _target.SendRequest("Overlay.setShowViewportSizeOnResize",
new SetShowViewportSizeOnResizeParams {
Show=@show,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetShowHingeParams {
/// <summary>
/// hinge data, null means hideHinge
/// </summary>
[JsonPropertyName("hingeConfig")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Overlay.HingeConfig? HingeConfig{get;set;}
}
/// <summary>
/// Add a dual screen device hinge
/// </summary>
/// <param name="hingeConfig">hinge data, null means hideHinge</param>
public async Task SetShowHinge(
 Overlay.HingeConfig? @hingeConfig=default) {
var resp = await _target.SendRequest("Overlay.setShowHinge",
new SetShowHingeParams {
HingeConfig=@hingeConfig,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetShowIsolatedElementsParams {
/// <summary>
/// An array of node identifiers and descriptors for the highlight appearance.
/// </summary>
[JsonPropertyName("isolatedElementHighlightConfigs")]public Overlay.IsolatedElementHighlightConfig[] IsolatedElementHighlightConfigs{get;set;}
}
/// <summary>
/// Show elements in isolation mode with overlays.
/// </summary>
/// <param name="isolatedElementHighlightConfigs">An array of node identifiers and descriptors for the highlight appearance.</param>
public async Task SetShowIsolatedElements(
 Overlay.IsolatedElementHighlightConfig[] @isolatedElementHighlightConfigs) {
var resp = await _target.SendRequest("Overlay.setShowIsolatedElements",
new SetShowIsolatedElementsParams {
IsolatedElementHighlightConfigs=@isolatedElementHighlightConfigs,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class InspectNodeRequestedParams {
/// <summary>
/// Id of the node to inspect.
/// </summary>
[JsonPropertyName("backendNodeId")]public DOM.BackendNodeId BackendNodeId{get;set;}
}
private Action<InspectNodeRequestedParams>? _onInspectNodeRequested;
/// <summary>
/// Fired when the node should be inspected. This happens after call to `setInspectMode` or when
/// user manually inspects an element.
/// </summary>
public event Action<InspectNodeRequestedParams> OnInspectNodeRequested {
add => _onInspectNodeRequested += value; remove => _onInspectNodeRequested -= value;}
public sealed partial class NodeHighlightRequestedParams {
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
private Action<NodeHighlightRequestedParams>? _onNodeHighlightRequested;
/// <summary>
/// Fired when the node should be highlighted. This happens after call to `setInspectMode`.
/// </summary>
public event Action<NodeHighlightRequestedParams> OnNodeHighlightRequested {
add => _onNodeHighlightRequested += value; remove => _onNodeHighlightRequested -= value;}
public sealed partial class ScreenshotRequestedParams {
/// <summary>
/// Viewport to capture, in device independent pixels (dip).
/// </summary>
[JsonPropertyName("viewport")]public Page.Viewport Viewport{get;set;}
}
private Action<ScreenshotRequestedParams>? _onScreenshotRequested;
/// <summary>
/// Fired when user asks to capture screenshot of some area on the page.
/// </summary>
public event Action<ScreenshotRequestedParams> OnScreenshotRequested {
add => _onScreenshotRequested += value; remove => _onScreenshotRequested -= value;}
private Action? _onInspectModeCanceled;
/// <summary>
/// Fired when user cancels the inspect mode.
/// </summary>
public event Action OnInspectModeCanceled {
add => _onInspectModeCanceled += value; remove => _onInspectModeCanceled -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Overlay.inspectNodeRequested":
_onInspectNodeRequested?.Invoke(_target.DeserializeEvent<InspectNodeRequestedParams>(data));
break;
case "Overlay.nodeHighlightRequested":
_onNodeHighlightRequested?.Invoke(_target.DeserializeEvent<NodeHighlightRequestedParams>(data));
break;
case "Overlay.screenshotRequested":
_onScreenshotRequested?.Invoke(_target.DeserializeEvent<ScreenshotRequestedParams>(data));
break;
case "Overlay.inspectModeCanceled":
_onInspectModeCanceled?.Invoke();
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
_onInspectNodeRequested = null;
_onNodeHighlightRequested = null;
_onScreenshotRequested = null;
_onInspectModeCanceled = null;
}
}
