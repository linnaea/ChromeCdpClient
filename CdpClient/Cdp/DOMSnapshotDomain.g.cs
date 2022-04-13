using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// This domain facilitates obtaining document snapshots with DOM, layout, and style information.
/// </summary>
[Experimental]public sealed partial class DOMSnapshotDomain {
private readonly ConnectedTarget _target;
public DOMSnapshotDomain(ConnectedTarget target) => _target = target;
/// <summary>
/// Disables DOM snapshot agent for the given page.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("DOMSnapshot.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Enables DOM snapshot agent for the given page.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("DOMSnapshot.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetSnapshotParams {
/// <summary>
/// Whitelist of computed styles to return.
/// </summary>
[JsonPropertyName("computedStyleWhitelist")]public string[] ComputedStyleWhitelist{get;set;}
/// <summary>
/// Whether or not to retrieve details of DOM listeners (default false).
/// </summary>
[JsonPropertyName("includeEventListeners")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IncludeEventListeners{get;set;}
/// <summary>
/// Whether to determine and include the paint order index of LayoutTreeNodes (default false).
/// </summary>
[JsonPropertyName("includePaintOrder")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IncludePaintOrder{get;set;}
/// <summary>
/// Whether to include UA shadow tree in the snapshot (default false).
/// </summary>
[JsonPropertyName("includeUserAgentShadowTree")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IncludeUserAgentShadowTree{get;set;}
}
public sealed partial class GetSnapshotReturn {
/// <summary>
/// The nodes in the DOM tree. The DOMNode at index 0 corresponds to the root document.
/// </summary>
[JsonPropertyName("domNodes")]public DOMSnapshot.DOMNode[] DomNodes{get;set;}
/// <summary>
/// The nodes in the layout tree.
/// </summary>
[JsonPropertyName("layoutTreeNodes")]public DOMSnapshot.LayoutTreeNode[] LayoutTreeNodes{get;set;}
/// <summary>
/// Whitelisted ComputedStyle properties for each node in the layout tree.
/// </summary>
[JsonPropertyName("computedStyles")]public DOMSnapshot.ComputedStyle[] ComputedStyles{get;set;}
}
/// <summary>
/// Returns a document snapshot, including the full DOM tree of the root node (including iframes,
/// template contents, and imported documents) in a flattened array, as well as layout and
/// white-listed computed style information for the nodes. Shadow DOM in the returned DOM tree is
/// flattened.
/// </summary>
/// <param name="computedStyleWhitelist">Whitelist of computed styles to return.</param>
/// <param name="includeEventListeners">Whether or not to retrieve details of DOM listeners (default false).</param>
/// <param name="includePaintOrder">Whether to determine and include the paint order index of LayoutTreeNodes (default false).</param>
/// <param name="includeUserAgentShadowTree">Whether to include UA shadow tree in the snapshot (default false).</param>
[Obsolete]public async Task<GetSnapshotReturn> GetSnapshot(
 string[] @computedStyleWhitelist,bool? @includeEventListeners=default,bool? @includePaintOrder=default,bool? @includeUserAgentShadowTree=default) {
var resp = await _target.SendRequest("DOMSnapshot.getSnapshot",
new GetSnapshotParams {
ComputedStyleWhitelist=@computedStyleWhitelist,IncludeEventListeners=@includeEventListeners,IncludePaintOrder=@includePaintOrder,IncludeUserAgentShadowTree=@includeUserAgentShadowTree,});
return _target.DeserializeResponse<GetSnapshotReturn>(resp);
}
public sealed partial class CaptureSnapshotParams {
/// <summary>
/// Whitelist of computed styles to return.
/// </summary>
[JsonPropertyName("computedStyles")]public string[] ComputedStyles{get;set;}
/// <summary>
/// Whether to include layout object paint orders into the snapshot.
/// </summary>
[JsonPropertyName("includePaintOrder")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IncludePaintOrder{get;set;}
/// <summary>
/// Whether to include DOM rectangles (offsetRects, clientRects, scrollRects) into the snapshot
/// </summary>
[JsonPropertyName("includeDOMRects")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IncludeDOMRects{get;set;}
/// <summary>
/// Whether to include blended background colors in the snapshot (default: false).
/// Blended background color is achieved by blending background colors of all elements
/// that overlap with the current element.
/// </summary>
[Experimental][JsonPropertyName("includeBlendedBackgroundColors")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IncludeBlendedBackgroundColors{get;set;}
/// <summary>
/// Whether to include text color opacity in the snapshot (default: false).
/// An element might have the opacity property set that affects the text color of the element.
/// The final text color opacity is computed based on the opacity of all overlapping elements.
/// </summary>
[Experimental][JsonPropertyName("includeTextColorOpacities")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IncludeTextColorOpacities{get;set;}
}
public sealed partial class CaptureSnapshotReturn {
/// <summary>
/// The nodes in the DOM tree. The DOMNode at index 0 corresponds to the root document.
/// </summary>
[JsonPropertyName("documents")]public DOMSnapshot.DocumentSnapshot[] Documents{get;set;}
/// <summary>
/// Shared string table that all string properties refer to with indexes.
/// </summary>
[JsonPropertyName("strings")]public string[] Strings{get;set;}
}
/// <summary>
/// Returns a document snapshot, including the full DOM tree of the root node (including iframes,
/// template contents, and imported documents) in a flattened array, as well as layout and
/// white-listed computed style information for the nodes. Shadow DOM in the returned DOM tree is
/// flattened.
/// </summary>
/// <param name="computedStyles">Whitelist of computed styles to return.</param>
/// <param name="includePaintOrder">Whether to include layout object paint orders into the snapshot.</param>
/// <param name="includeDOMRects">Whether to include DOM rectangles (offsetRects, clientRects, scrollRects) into the snapshot</param>
/// <param name="includeBlendedBackgroundColors">EXPERIMENTAL Whether to include blended background colors in the snapshot (default: false).
/// Blended background color is achieved by blending background colors of all elements
/// that overlap with the current element.</param>
/// <param name="includeTextColorOpacities">EXPERIMENTAL Whether to include text color opacity in the snapshot (default: false).
/// An element might have the opacity property set that affects the text color of the element.
/// The final text color opacity is computed based on the opacity of all overlapping elements.</param>
public async Task<CaptureSnapshotReturn> CaptureSnapshot(
 string[] @computedStyles,bool? @includePaintOrder=default,bool? @includeDOMRects=default,bool? @includeBlendedBackgroundColors=default,bool? @includeTextColorOpacities=default) {
var resp = await _target.SendRequest("DOMSnapshot.captureSnapshot",
new CaptureSnapshotParams {
ComputedStyles=@computedStyles,IncludePaintOrder=@includePaintOrder,IncludeDOMRects=@includeDOMRects,IncludeBlendedBackgroundColors=@includeBlendedBackgroundColors,IncludeTextColorOpacities=@includeTextColorOpacities,});
return _target.DeserializeResponse<CaptureSnapshotReturn>(resp);
}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
default:
_onUnknownEvent?.Invoke(method, data);
break;
}}
private Action<string, ArraySegment<byte>>? _onUnknownEvent;
public event Action<string, ArraySegment<byte>> OnUnknownEvent {
add => _onUnknownEvent += value; remove => _onUnknownEvent -= value;}
public void DisconnectEvents() {
_onUnknownEvent = null;
}
}
