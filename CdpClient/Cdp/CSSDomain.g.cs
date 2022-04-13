using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// This domain exposes CSS read/write operations. All CSS objects (stylesheets, rules, and styles)
/// have an associated `id` used in subsequent operations on the related object. Each object type has
/// a specific `id` structure, and those are not interchangeable between objects of different kinds.
/// CSS objects can be loaded using the `get*ForNode()` calls (which accept a DOM node id). A client
/// can also keep track of stylesheets via the `styleSheetAdded`/`styleSheetRemoved` events and
/// subsequently load the required stylesheet contents using the `getStyleSheet[Text]()` methods.
/// </summary>
[Experimental]public sealed partial class CSSDomain {
private readonly ConnectedTarget _target;
public CSSDomain(ConnectedTarget target) => _target = target;
public sealed partial class AddRuleParams {
/// <summary>
/// The css style sheet identifier where a new rule should be inserted.
/// </summary>
[JsonPropertyName("styleSheetId")]public CSS.StyleSheetId StyleSheetId{get;set;}
/// <summary>
/// The text of a new rule.
/// </summary>
[JsonPropertyName("ruleText")]public string RuleText{get;set;}
/// <summary>
/// Text position of a new rule in the target style sheet.
/// </summary>
[JsonPropertyName("location")]public CSS.SourceRange Location{get;set;}
}
public sealed partial class AddRuleReturn {
/// <summary>
/// The newly created rule.
/// </summary>
[JsonPropertyName("rule")]public CSS.CSSRule Rule{get;set;}
}
/// <summary>
/// Inserts a new rule with the given `ruleText` in a stylesheet with given `styleSheetId`, at the
/// position specified by `location`.
/// </summary>
/// <param name="styleSheetId">The css style sheet identifier where a new rule should be inserted.</param>
/// <param name="ruleText">The text of a new rule.</param>
/// <param name="location">Text position of a new rule in the target style sheet.</param>
public async Task<AddRuleReturn> AddRule(
 CSS.StyleSheetId @styleSheetId,string @ruleText,CSS.SourceRange @location) {
var resp = await _target.SendRequest("CSS.addRule",
new AddRuleParams {
StyleSheetId=@styleSheetId,RuleText=@ruleText,Location=@location,});
return _target.DeserializeResponse<AddRuleReturn>(resp);
}
public sealed partial class CollectClassNamesParams {
[JsonPropertyName("styleSheetId")]public CSS.StyleSheetId StyleSheetId{get;set;}
}
public sealed partial class CollectClassNamesReturn {
/// <summary>
/// Class name list.
/// </summary>
[JsonPropertyName("classNames")]public string[] ClassNames{get;set;}
}
/// <summary>
/// Returns all class names from specified stylesheet.
/// </summary>
/// <param name="styleSheetId"></param>
public async Task<CollectClassNamesReturn> CollectClassNames(
 CSS.StyleSheetId @styleSheetId) {
var resp = await _target.SendRequest("CSS.collectClassNames",
new CollectClassNamesParams {
StyleSheetId=@styleSheetId,});
return _target.DeserializeResponse<CollectClassNamesReturn>(resp);
}
public sealed partial class CreateStyleSheetParams {
/// <summary>
/// Identifier of the frame where "via-inspector" stylesheet should be created.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
}
public sealed partial class CreateStyleSheetReturn {
/// <summary>
/// Identifier of the created "via-inspector" stylesheet.
/// </summary>
[JsonPropertyName("styleSheetId")]public CSS.StyleSheetId StyleSheetId{get;set;}
}
/// <summary>
/// Creates a new special "via-inspector" stylesheet in the frame with given `frameId`.
/// </summary>
/// <param name="frameId">Identifier of the frame where "via-inspector" stylesheet should be created.</param>
public async Task<CreateStyleSheetReturn> CreateStyleSheet(
 Page.FrameId @frameId) {
var resp = await _target.SendRequest("CSS.createStyleSheet",
new CreateStyleSheetParams {
FrameId=@frameId,});
return _target.DeserializeResponse<CreateStyleSheetReturn>(resp);
}
/// <summary>
/// Disables the CSS agent for the given page.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("CSS.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Enables the CSS agent for the given page. Clients should not assume that the CSS agent has been
/// enabled until the result of this command is received.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("CSS.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class ForcePseudoStateParams {
/// <summary>
/// The element id for which to force the pseudo state.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
/// <summary>
/// Element pseudo classes to force when computing the element's style.
/// </summary>
[JsonPropertyName("forcedPseudoClasses")]public string[] ForcedPseudoClasses{get;set;}
}
/// <summary>
/// Ensures that the given node will have specified pseudo-classes whenever its style is computed by
/// the browser.
/// </summary>
/// <param name="nodeId">The element id for which to force the pseudo state.</param>
/// <param name="forcedPseudoClasses">Element pseudo classes to force when computing the element's style.</param>
public async Task ForcePseudoState(
 DOM.NodeId @nodeId,string[] @forcedPseudoClasses) {
var resp = await _target.SendRequest("CSS.forcePseudoState",
new ForcePseudoStateParams {
NodeId=@nodeId,ForcedPseudoClasses=@forcedPseudoClasses,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetBackgroundColorsParams {
/// <summary>
/// Id of the node to get background colors for.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
public sealed partial class GetBackgroundColorsReturn {
/// <summary>
/// The range of background colors behind this element, if it contains any visible text. If no
/// visible text is present, this will be undefined. In the case of a flat background color,
/// this will consist of simply that color. In the case of a gradient, this will consist of each
/// of the color stops. For anything more complicated, this will be an empty array. Images will
/// be ignored (as if the image had failed to load).
/// </summary>
[JsonPropertyName("backgroundColors")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string[]? BackgroundColors{get;set;}
/// <summary>
/// The computed font size for this node, as a CSS computed value string (e.g. '12px').
/// </summary>
[JsonPropertyName("computedFontSize")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ComputedFontSize{get;set;}
/// <summary>
/// The computed font weight for this node, as a CSS computed value string (e.g. 'normal' or
/// '100').
/// </summary>
[JsonPropertyName("computedFontWeight")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ComputedFontWeight{get;set;}
}
/// <param name="nodeId">Id of the node to get background colors for.</param>
public async Task<GetBackgroundColorsReturn> GetBackgroundColors(
 DOM.NodeId @nodeId) {
var resp = await _target.SendRequest("CSS.getBackgroundColors",
new GetBackgroundColorsParams {
NodeId=@nodeId,});
return _target.DeserializeResponse<GetBackgroundColorsReturn>(resp);
}
public sealed partial class GetComputedStyleForNodeParams {
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
public sealed partial class GetComputedStyleForNodeReturn {
/// <summary>
/// Computed style for the specified DOM node.
/// </summary>
[JsonPropertyName("computedStyle")]public CSS.CSSComputedStyleProperty[] ComputedStyle{get;set;}
}
/// <summary>
/// Returns the computed style for a DOM node identified by `nodeId`.
/// </summary>
/// <param name="nodeId"></param>
public async Task<GetComputedStyleForNodeReturn> GetComputedStyleForNode(
 DOM.NodeId @nodeId) {
var resp = await _target.SendRequest("CSS.getComputedStyleForNode",
new GetComputedStyleForNodeParams {
NodeId=@nodeId,});
return _target.DeserializeResponse<GetComputedStyleForNodeReturn>(resp);
}
public sealed partial class GetInlineStylesForNodeParams {
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
public sealed partial class GetInlineStylesForNodeReturn {
/// <summary>
/// Inline style for the specified DOM node.
/// </summary>
[JsonPropertyName("inlineStyle")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CSS.CSSStyle? InlineStyle{get;set;}
/// <summary>
/// Attribute-defined element style (e.g. resulting from "width=20 height=100%").
/// </summary>
[JsonPropertyName("attributesStyle")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CSS.CSSStyle? AttributesStyle{get;set;}
}
/// <summary>
/// Returns the styles defined inline (explicitly in the "style" attribute and implicitly, using DOM
/// attributes) for a DOM node identified by `nodeId`.
/// </summary>
/// <param name="nodeId"></param>
public async Task<GetInlineStylesForNodeReturn> GetInlineStylesForNode(
 DOM.NodeId @nodeId) {
var resp = await _target.SendRequest("CSS.getInlineStylesForNode",
new GetInlineStylesForNodeParams {
NodeId=@nodeId,});
return _target.DeserializeResponse<GetInlineStylesForNodeReturn>(resp);
}
public sealed partial class GetMatchedStylesForNodeParams {
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
public sealed partial class GetMatchedStylesForNodeReturn {
/// <summary>
/// Inline style for the specified DOM node.
/// </summary>
[JsonPropertyName("inlineStyle")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CSS.CSSStyle? InlineStyle{get;set;}
/// <summary>
/// Attribute-defined element style (e.g. resulting from "width=20 height=100%").
/// </summary>
[JsonPropertyName("attributesStyle")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CSS.CSSStyle? AttributesStyle{get;set;}
/// <summary>
/// CSS rules matching this node, from all applicable stylesheets.
/// </summary>
[JsonPropertyName("matchedCSSRules")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CSS.RuleMatch[]? MatchedCSSRules{get;set;}
/// <summary>
/// Pseudo style matches for this node.
/// </summary>
[JsonPropertyName("pseudoElements")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CSS.PseudoElementMatches[]? PseudoElements{get;set;}
/// <summary>
/// A chain of inherited styles (from the immediate node parent up to the DOM tree root).
/// </summary>
[JsonPropertyName("inherited")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CSS.InheritedStyleEntry[]? Inherited{get;set;}
/// <summary>
/// A chain of inherited pseudo element styles (from the immediate node parent up to the DOM tree root).
/// </summary>
[JsonPropertyName("inheritedPseudoElements")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CSS.InheritedPseudoElementMatches[]? InheritedPseudoElements{get;set;}
/// <summary>
/// A list of CSS keyframed animations matching this node.
/// </summary>
[JsonPropertyName("cssKeyframesRules")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CSS.CSSKeyframesRule[]? CssKeyframesRules{get;set;}
}
/// <summary>
/// Returns requested styles for a DOM node identified by `nodeId`.
/// </summary>
/// <param name="nodeId"></param>
public async Task<GetMatchedStylesForNodeReturn> GetMatchedStylesForNode(
 DOM.NodeId @nodeId) {
var resp = await _target.SendRequest("CSS.getMatchedStylesForNode",
new GetMatchedStylesForNodeParams {
NodeId=@nodeId,});
return _target.DeserializeResponse<GetMatchedStylesForNodeReturn>(resp);
}
public sealed partial class GetMediaQueriesReturn {
[JsonPropertyName("medias")]public CSS.CSSMedia[] Medias{get;set;}
}
/// <summary>
/// Returns all media queries parsed by the rendering engine.
/// </summary>
public async Task<GetMediaQueriesReturn> GetMediaQueries(
) {
var resp = await _target.SendRequest("CSS.getMediaQueries",
VoidData.Instance);
return _target.DeserializeResponse<GetMediaQueriesReturn>(resp);
}
public sealed partial class GetPlatformFontsForNodeParams {
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
public sealed partial class GetPlatformFontsForNodeReturn {
/// <summary>
/// Usage statistics for every employed platform font.
/// </summary>
[JsonPropertyName("fonts")]public CSS.PlatformFontUsage[] Fonts{get;set;}
}
/// <summary>
/// Requests information about platform fonts which we used to render child TextNodes in the given
/// node.
/// </summary>
/// <param name="nodeId"></param>
public async Task<GetPlatformFontsForNodeReturn> GetPlatformFontsForNode(
 DOM.NodeId @nodeId) {
var resp = await _target.SendRequest("CSS.getPlatformFontsForNode",
new GetPlatformFontsForNodeParams {
NodeId=@nodeId,});
return _target.DeserializeResponse<GetPlatformFontsForNodeReturn>(resp);
}
public sealed partial class GetStyleSheetTextParams {
[JsonPropertyName("styleSheetId")]public CSS.StyleSheetId StyleSheetId{get;set;}
}
public sealed partial class GetStyleSheetTextReturn {
/// <summary>
/// The stylesheet text.
/// </summary>
[JsonPropertyName("text")]public string Text{get;set;}
}
/// <summary>
/// Returns the current textual content for a stylesheet.
/// </summary>
/// <param name="styleSheetId"></param>
public async Task<GetStyleSheetTextReturn> GetStyleSheetText(
 CSS.StyleSheetId @styleSheetId) {
var resp = await _target.SendRequest("CSS.getStyleSheetText",
new GetStyleSheetTextParams {
StyleSheetId=@styleSheetId,});
return _target.DeserializeResponse<GetStyleSheetTextReturn>(resp);
}
public sealed partial class GetLayersForNodeParams {
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
}
public sealed partial class GetLayersForNodeReturn {
[JsonPropertyName("rootLayer")]public CSS.CSSLayerData RootLayer{get;set;}
}
/// <summary>
/// Returns all layers parsed by the rendering engine for the tree scope of a node.
/// Given a DOM element identified by nodeId, getLayersForNode returns the root
/// layer for the nearest ancestor document or shadow root. The layer root contains
/// the full layer tree for the tree scope and their ordering.
/// </summary>
/// <param name="nodeId"></param>
[Experimental]public async Task<GetLayersForNodeReturn> GetLayersForNode(
 DOM.NodeId @nodeId) {
var resp = await _target.SendRequest("CSS.getLayersForNode",
new GetLayersForNodeParams {
NodeId=@nodeId,});
return _target.DeserializeResponse<GetLayersForNodeReturn>(resp);
}
public sealed partial class TrackComputedStyleUpdatesParams {
[JsonPropertyName("propertiesToTrack")]public CSS.CSSComputedStyleProperty[] PropertiesToTrack{get;set;}
}
/// <summary>
/// Starts tracking the given computed styles for updates. The specified array of properties
/// replaces the one previously specified. Pass empty array to disable tracking.
/// Use takeComputedStyleUpdates to retrieve the list of nodes that had properties modified.
/// The changes to computed style properties are only tracked for nodes pushed to the front-end
/// by the DOM agent. If no changes to the tracked properties occur after the node has been pushed
/// to the front-end, no updates will be issued for the node.
/// </summary>
/// <param name="propertiesToTrack"></param>
[Experimental]public async Task TrackComputedStyleUpdates(
 CSS.CSSComputedStyleProperty[] @propertiesToTrack) {
var resp = await _target.SendRequest("CSS.trackComputedStyleUpdates",
new TrackComputedStyleUpdatesParams {
PropertiesToTrack=@propertiesToTrack,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class TakeComputedStyleUpdatesReturn {
/// <summary>
/// The list of node Ids that have their tracked computed styles updated
/// </summary>
[JsonPropertyName("nodeIds")]public DOM.NodeId[] NodeIds{get;set;}
}
/// <summary>
/// Polls the next batch of computed style updates.
/// </summary>
[Experimental]public async Task<TakeComputedStyleUpdatesReturn> TakeComputedStyleUpdates(
) {
var resp = await _target.SendRequest("CSS.takeComputedStyleUpdates",
VoidData.Instance);
return _target.DeserializeResponse<TakeComputedStyleUpdatesReturn>(resp);
}
public sealed partial class SetEffectivePropertyValueForNodeParams {
/// <summary>
/// The element id for which to set property.
/// </summary>
[JsonPropertyName("nodeId")]public DOM.NodeId NodeId{get;set;}
[JsonPropertyName("propertyName")]public string PropertyName{get;set;}
[JsonPropertyName("value")]public string Value{get;set;}
}
/// <summary>
/// Find a rule with the given active property for the given node and set the new value for this
/// property
/// </summary>
/// <param name="nodeId">The element id for which to set property.</param>
/// <param name="propertyName"></param>
/// <param name="value"></param>
public async Task SetEffectivePropertyValueForNode(
 DOM.NodeId @nodeId,string @propertyName,string @value) {
var resp = await _target.SendRequest("CSS.setEffectivePropertyValueForNode",
new SetEffectivePropertyValueForNodeParams {
NodeId=@nodeId,PropertyName=@propertyName,Value=@value,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetKeyframeKeyParams {
[JsonPropertyName("styleSheetId")]public CSS.StyleSheetId StyleSheetId{get;set;}
[JsonPropertyName("range")]public CSS.SourceRange Range{get;set;}
[JsonPropertyName("keyText")]public string KeyText{get;set;}
}
public sealed partial class SetKeyframeKeyReturn {
/// <summary>
/// The resulting key text after modification.
/// </summary>
[JsonPropertyName("keyText")]public CSS.Value KeyText{get;set;}
}
/// <summary>
/// Modifies the keyframe rule key text.
/// </summary>
/// <param name="styleSheetId"></param>
/// <param name="range"></param>
/// <param name="keyText"></param>
public async Task<SetKeyframeKeyReturn> SetKeyframeKey(
 CSS.StyleSheetId @styleSheetId,CSS.SourceRange @range,string @keyText) {
var resp = await _target.SendRequest("CSS.setKeyframeKey",
new SetKeyframeKeyParams {
StyleSheetId=@styleSheetId,Range=@range,KeyText=@keyText,});
return _target.DeserializeResponse<SetKeyframeKeyReturn>(resp);
}
public sealed partial class SetMediaTextParams {
[JsonPropertyName("styleSheetId")]public CSS.StyleSheetId StyleSheetId{get;set;}
[JsonPropertyName("range")]public CSS.SourceRange Range{get;set;}
[JsonPropertyName("text")]public string Text{get;set;}
}
public sealed partial class SetMediaTextReturn {
/// <summary>
/// The resulting CSS media rule after modification.
/// </summary>
[JsonPropertyName("media")]public CSS.CSSMedia Media{get;set;}
}
/// <summary>
/// Modifies the rule selector.
/// </summary>
/// <param name="styleSheetId"></param>
/// <param name="range"></param>
/// <param name="text"></param>
public async Task<SetMediaTextReturn> SetMediaText(
 CSS.StyleSheetId @styleSheetId,CSS.SourceRange @range,string @text) {
var resp = await _target.SendRequest("CSS.setMediaText",
new SetMediaTextParams {
StyleSheetId=@styleSheetId,Range=@range,Text=@text,});
return _target.DeserializeResponse<SetMediaTextReturn>(resp);
}
public sealed partial class SetContainerQueryTextParams {
[JsonPropertyName("styleSheetId")]public CSS.StyleSheetId StyleSheetId{get;set;}
[JsonPropertyName("range")]public CSS.SourceRange Range{get;set;}
[JsonPropertyName("text")]public string Text{get;set;}
}
public sealed partial class SetContainerQueryTextReturn {
/// <summary>
/// The resulting CSS container query rule after modification.
/// </summary>
[JsonPropertyName("containerQuery")]public CSS.CSSContainerQuery ContainerQuery{get;set;}
}
/// <summary>
/// Modifies the expression of a container query.
/// </summary>
/// <param name="styleSheetId"></param>
/// <param name="range"></param>
/// <param name="text"></param>
[Experimental]public async Task<SetContainerQueryTextReturn> SetContainerQueryText(
 CSS.StyleSheetId @styleSheetId,CSS.SourceRange @range,string @text) {
var resp = await _target.SendRequest("CSS.setContainerQueryText",
new SetContainerQueryTextParams {
StyleSheetId=@styleSheetId,Range=@range,Text=@text,});
return _target.DeserializeResponse<SetContainerQueryTextReturn>(resp);
}
public sealed partial class SetSupportsTextParams {
[JsonPropertyName("styleSheetId")]public CSS.StyleSheetId StyleSheetId{get;set;}
[JsonPropertyName("range")]public CSS.SourceRange Range{get;set;}
[JsonPropertyName("text")]public string Text{get;set;}
}
public sealed partial class SetSupportsTextReturn {
/// <summary>
/// The resulting CSS Supports rule after modification.
/// </summary>
[JsonPropertyName("supports")]public CSS.CSSSupports Supports{get;set;}
}
/// <summary>
/// Modifies the expression of a supports at-rule.
/// </summary>
/// <param name="styleSheetId"></param>
/// <param name="range"></param>
/// <param name="text"></param>
[Experimental]public async Task<SetSupportsTextReturn> SetSupportsText(
 CSS.StyleSheetId @styleSheetId,CSS.SourceRange @range,string @text) {
var resp = await _target.SendRequest("CSS.setSupportsText",
new SetSupportsTextParams {
StyleSheetId=@styleSheetId,Range=@range,Text=@text,});
return _target.DeserializeResponse<SetSupportsTextReturn>(resp);
}
public sealed partial class SetRuleSelectorParams {
[JsonPropertyName("styleSheetId")]public CSS.StyleSheetId StyleSheetId{get;set;}
[JsonPropertyName("range")]public CSS.SourceRange Range{get;set;}
[JsonPropertyName("selector")]public string Selector{get;set;}
}
public sealed partial class SetRuleSelectorReturn {
/// <summary>
/// The resulting selector list after modification.
/// </summary>
[JsonPropertyName("selectorList")]public CSS.SelectorList SelectorList{get;set;}
}
/// <summary>
/// Modifies the rule selector.
/// </summary>
/// <param name="styleSheetId"></param>
/// <param name="range"></param>
/// <param name="selector"></param>
public async Task<SetRuleSelectorReturn> SetRuleSelector(
 CSS.StyleSheetId @styleSheetId,CSS.SourceRange @range,string @selector) {
var resp = await _target.SendRequest("CSS.setRuleSelector",
new SetRuleSelectorParams {
StyleSheetId=@styleSheetId,Range=@range,Selector=@selector,});
return _target.DeserializeResponse<SetRuleSelectorReturn>(resp);
}
public sealed partial class SetStyleSheetTextParams {
[JsonPropertyName("styleSheetId")]public CSS.StyleSheetId StyleSheetId{get;set;}
[JsonPropertyName("text")]public string Text{get;set;}
}
public sealed partial class SetStyleSheetTextReturn {
/// <summary>
/// URL of source map associated with script (if any).
/// </summary>
[JsonPropertyName("sourceMapURL")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? SourceMapURL{get;set;}
}
/// <summary>
/// Sets the new stylesheet text.
/// </summary>
/// <param name="styleSheetId"></param>
/// <param name="text"></param>
public async Task<SetStyleSheetTextReturn> SetStyleSheetText(
 CSS.StyleSheetId @styleSheetId,string @text) {
var resp = await _target.SendRequest("CSS.setStyleSheetText",
new SetStyleSheetTextParams {
StyleSheetId=@styleSheetId,Text=@text,});
return _target.DeserializeResponse<SetStyleSheetTextReturn>(resp);
}
public sealed partial class SetStyleTextsParams {
[JsonPropertyName("edits")]public CSS.StyleDeclarationEdit[] Edits{get;set;}
}
public sealed partial class SetStyleTextsReturn {
/// <summary>
/// The resulting styles after modification.
/// </summary>
[JsonPropertyName("styles")]public CSS.CSSStyle[] Styles{get;set;}
}
/// <summary>
/// Applies specified style edits one after another in the given order.
/// </summary>
/// <param name="edits"></param>
public async Task<SetStyleTextsReturn> SetStyleTexts(
 CSS.StyleDeclarationEdit[] @edits) {
var resp = await _target.SendRequest("CSS.setStyleTexts",
new SetStyleTextsParams {
Edits=@edits,});
return _target.DeserializeResponse<SetStyleTextsReturn>(resp);
}
/// <summary>
/// Enables the selector recording.
/// </summary>
public async Task StartRuleUsageTracking(
) {
var resp = await _target.SendRequest("CSS.startRuleUsageTracking",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class StopRuleUsageTrackingReturn {
[JsonPropertyName("ruleUsage")]public CSS.RuleUsage[] RuleUsage{get;set;}
}
/// <summary>
/// Stop tracking rule usage and return the list of rules that were used since last call to
/// `takeCoverageDelta` (or since start of coverage instrumentation)
/// </summary>
public async Task<StopRuleUsageTrackingReturn> StopRuleUsageTracking(
) {
var resp = await _target.SendRequest("CSS.stopRuleUsageTracking",
VoidData.Instance);
return _target.DeserializeResponse<StopRuleUsageTrackingReturn>(resp);
}
public sealed partial class TakeCoverageDeltaReturn {
[JsonPropertyName("coverage")]public CSS.RuleUsage[] Coverage{get;set;}
/// <summary>
/// Monotonically increasing time, in seconds.
/// </summary>
[JsonPropertyName("timestamp")]public double Timestamp{get;set;}
}
/// <summary>
/// Obtain list of rules that became used since last call to this method (or since start of coverage
/// instrumentation)
/// </summary>
public async Task<TakeCoverageDeltaReturn> TakeCoverageDelta(
) {
var resp = await _target.SendRequest("CSS.takeCoverageDelta",
VoidData.Instance);
return _target.DeserializeResponse<TakeCoverageDeltaReturn>(resp);
}
public sealed partial class SetLocalFontsEnabledParams {
/// <summary>
/// Whether rendering of local fonts is enabled.
/// </summary>
[JsonPropertyName("enabled")]public bool Enabled{get;set;}
}
/// <summary>
/// Enables/disables rendering of local CSS fonts (enabled by default).
/// </summary>
/// <param name="enabled">Whether rendering of local fonts is enabled.</param>
[Experimental]public async Task SetLocalFontsEnabled(
 bool @enabled) {
var resp = await _target.SendRequest("CSS.setLocalFontsEnabled",
new SetLocalFontsEnabledParams {
Enabled=@enabled,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class FontsUpdatedParams {
/// <summary>
/// The web font that has loaded.
/// </summary>
[JsonPropertyName("font")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CSS.FontFace? Font{get;set;}
}
private Action<FontsUpdatedParams>? _onFontsUpdated;
/// <summary>
/// Fires whenever a web font is updated.  A non-empty font parameter indicates a successfully loaded
/// web font
/// </summary>
public event Action<FontsUpdatedParams> OnFontsUpdated {
add => _onFontsUpdated += value; remove => _onFontsUpdated -= value;}
private Action? _onMediaQueryResultChanged;
/// <summary>
/// Fires whenever a MediaQuery result changes (for example, after a browser window has been
/// resized.) The current implementation considers only viewport-dependent media features.
/// </summary>
public event Action OnMediaQueryResultChanged {
add => _onMediaQueryResultChanged += value; remove => _onMediaQueryResultChanged -= value;}
public sealed partial class StyleSheetAddedParams {
/// <summary>
/// Added stylesheet metainfo.
/// </summary>
[JsonPropertyName("header")]public CSS.CSSStyleSheetHeader Header{get;set;}
}
private Action<StyleSheetAddedParams>? _onStyleSheetAdded;
/// <summary>
/// Fired whenever an active document stylesheet is added.
/// </summary>
public event Action<StyleSheetAddedParams> OnStyleSheetAdded {
add => _onStyleSheetAdded += value; remove => _onStyleSheetAdded -= value;}
public sealed partial class StyleSheetChangedParams {
[JsonPropertyName("styleSheetId")]public CSS.StyleSheetId StyleSheetId{get;set;}
}
private Action<StyleSheetChangedParams>? _onStyleSheetChanged;
/// <summary>
/// Fired whenever a stylesheet is changed as a result of the client operation.
/// </summary>
public event Action<StyleSheetChangedParams> OnStyleSheetChanged {
add => _onStyleSheetChanged += value; remove => _onStyleSheetChanged -= value;}
public sealed partial class StyleSheetRemovedParams {
/// <summary>
/// Identifier of the removed stylesheet.
/// </summary>
[JsonPropertyName("styleSheetId")]public CSS.StyleSheetId StyleSheetId{get;set;}
}
private Action<StyleSheetRemovedParams>? _onStyleSheetRemoved;
/// <summary>
/// Fired whenever an active document stylesheet is removed.
/// </summary>
public event Action<StyleSheetRemovedParams> OnStyleSheetRemoved {
add => _onStyleSheetRemoved += value; remove => _onStyleSheetRemoved -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "CSS.fontsUpdated":
_onFontsUpdated?.Invoke(_target.DeserializeEvent<FontsUpdatedParams>(data));
break;
case "CSS.mediaQueryResultChanged":
_onMediaQueryResultChanged?.Invoke();
break;
case "CSS.styleSheetAdded":
_onStyleSheetAdded?.Invoke(_target.DeserializeEvent<StyleSheetAddedParams>(data));
break;
case "CSS.styleSheetChanged":
_onStyleSheetChanged?.Invoke(_target.DeserializeEvent<StyleSheetChangedParams>(data));
break;
case "CSS.styleSheetRemoved":
_onStyleSheetRemoved?.Invoke(_target.DeserializeEvent<StyleSheetRemovedParams>(data));
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
_onFontsUpdated = null;
_onMediaQueryResultChanged = null;
_onStyleSheetAdded = null;
_onStyleSheetChanged = null;
_onStyleSheetRemoved = null;
}
}
