using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// Actions and events related to the inspected page belong to the page domain.
/// </summary>
public sealed partial class PageDomain {
private readonly ConnectedTarget _target;
public PageDomain(ConnectedTarget target) => _target = target;
public sealed partial class AddScriptToEvaluateOnLoadParams {
[JsonPropertyName("scriptSource")]public string ScriptSource{get;set;}
}
public sealed partial class AddScriptToEvaluateOnLoadReturn {
/// <summary>
/// Identifier of the added script.
/// </summary>
[JsonPropertyName("identifier")]public Page.ScriptIdentifier Identifier{get;set;}
}
/// <summary>
/// Deprecated, please use addScriptToEvaluateOnNewDocument instead.
/// </summary>
/// <param name="scriptSource"></param>
[Experimental][Obsolete]public async Task<AddScriptToEvaluateOnLoadReturn> AddScriptToEvaluateOnLoad(
 string @scriptSource) {
var resp = await _target.SendRequest("Page.addScriptToEvaluateOnLoad",
new AddScriptToEvaluateOnLoadParams {
ScriptSource=@scriptSource,});
return _target.DeserializeResponse<AddScriptToEvaluateOnLoadReturn>(resp);
}
public sealed partial class AddScriptToEvaluateOnNewDocumentParams {
[JsonPropertyName("source")]public string Source{get;set;}
/// <summary>
/// If specified, creates an isolated world with the given name and evaluates given script in it.
/// This world name will be used as the ExecutionContextDescription::name when the corresponding
/// event is emitted.
/// </summary>
[Experimental][JsonPropertyName("worldName")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? WorldName{get;set;}
/// <summary>
/// Specifies whether command line API should be available to the script, defaults
/// to false.
/// </summary>
[Experimental][JsonPropertyName("includeCommandLineAPI")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IncludeCommandLineAPI{get;set;}
}
public sealed partial class AddScriptToEvaluateOnNewDocumentReturn {
/// <summary>
/// Identifier of the added script.
/// </summary>
[JsonPropertyName("identifier")]public Page.ScriptIdentifier Identifier{get;set;}
}
/// <summary>
/// Evaluates given script in every frame upon creation (before loading frame's scripts).
/// </summary>
/// <param name="source"></param>
/// <param name="worldName">EXPERIMENTAL If specified, creates an isolated world with the given name and evaluates given script in it.
/// This world name will be used as the ExecutionContextDescription::name when the corresponding
/// event is emitted.</param>
/// <param name="includeCommandLineAPI">EXPERIMENTAL Specifies whether command line API should be available to the script, defaults
/// to false.</param>
public async Task<AddScriptToEvaluateOnNewDocumentReturn> AddScriptToEvaluateOnNewDocument(
 string @source,string? @worldName=default,bool? @includeCommandLineAPI=default) {
var resp = await _target.SendRequest("Page.addScriptToEvaluateOnNewDocument",
new AddScriptToEvaluateOnNewDocumentParams {
Source=@source,WorldName=@worldName,IncludeCommandLineAPI=@includeCommandLineAPI,});
return _target.DeserializeResponse<AddScriptToEvaluateOnNewDocumentReturn>(resp);
}
/// <summary>
/// Brings page to front (activates tab).
/// </summary>
public async Task BringToFront(
) {
var resp = await _target.SendRequest("Page.bringToFront",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class CaptureScreenshotParams {
/// <summary>
/// Image compression format (defaults to png).
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum FormatEnum {
[EnumMember(Value = "jpeg")] Jpeg,
[EnumMember(Value = "png")] Png,
[EnumMember(Value = "webp")] Webp,
}
[JsonPropertyName("format")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public FormatEnum? Format{get;set;}
/// <summary>
/// Compression quality from range [0..100] (jpeg only).
/// </summary>
[JsonPropertyName("quality")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Quality{get;set;}
/// <summary>
/// Capture the screenshot of a given region only.
/// </summary>
[JsonPropertyName("clip")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.Viewport? Clip{get;set;}
/// <summary>
/// Capture the screenshot from the surface, rather than the view. Defaults to true.
/// </summary>
[Experimental][JsonPropertyName("fromSurface")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? FromSurface{get;set;}
/// <summary>
/// Capture the screenshot beyond the viewport. Defaults to false.
/// </summary>
[Experimental][JsonPropertyName("captureBeyondViewport")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? CaptureBeyondViewport{get;set;}
}
public sealed partial class CaptureScreenshotReturn {
/// <summary>
/// Base64-encoded image data. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("data")]public string Data{get;set;}
}
/// <summary>
/// Capture page screenshot.
/// </summary>
/// <param name="format">Image compression format (defaults to png).</param>
/// <param name="quality">Compression quality from range [0..100] (jpeg only).</param>
/// <param name="clip">Capture the screenshot of a given region only.</param>
/// <param name="fromSurface">EXPERIMENTAL Capture the screenshot from the surface, rather than the view. Defaults to true.</param>
/// <param name="captureBeyondViewport">EXPERIMENTAL Capture the screenshot beyond the viewport. Defaults to false.</param>
public async Task<CaptureScreenshotReturn> CaptureScreenshot(
 CaptureScreenshotParams.FormatEnum? @format=default,long? @quality=default,Page.Viewport? @clip=default,bool? @fromSurface=default,bool? @captureBeyondViewport=default) {
var resp = await _target.SendRequest("Page.captureScreenshot",
new CaptureScreenshotParams {
Format=@format,Quality=@quality,Clip=@clip,FromSurface=@fromSurface,CaptureBeyondViewport=@captureBeyondViewport,});
return _target.DeserializeResponse<CaptureScreenshotReturn>(resp);
}
public sealed partial class CaptureSnapshotParams {
/// <summary>
/// Format (defaults to mhtml).
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum FormatEnum {
[EnumMember(Value = "mhtml")] Mhtml,
}
[JsonPropertyName("format")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public FormatEnum? Format{get;set;}
}
public sealed partial class CaptureSnapshotReturn {
/// <summary>
/// Serialized page data.
/// </summary>
[JsonPropertyName("data")]public string Data{get;set;}
}
/// <summary>
/// Returns a snapshot of the page as a string. For MHTML format, the serialization includes
/// iframes, shadow DOM, external resources, and element-inline styles.
/// </summary>
/// <param name="format">Format (defaults to mhtml).</param>
[Experimental]public async Task<CaptureSnapshotReturn> CaptureSnapshot(
 CaptureSnapshotParams.FormatEnum? @format=default) {
var resp = await _target.SendRequest("Page.captureSnapshot",
new CaptureSnapshotParams {
Format=@format,});
return _target.DeserializeResponse<CaptureSnapshotReturn>(resp);
}
/// <summary>
/// Clears the overridden device metrics.
/// </summary>
[Experimental][Obsolete("Emulation")]public async Task ClearDeviceMetricsOverride(
) {
var resp = await _target.SendRequest("Page.clearDeviceMetricsOverride",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Clears the overridden Device Orientation.
/// </summary>
[Experimental][Obsolete("DeviceOrientation")]public async Task ClearDeviceOrientationOverride(
) {
var resp = await _target.SendRequest("Page.clearDeviceOrientationOverride",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Clears the overridden Geolocation Position and Error.
/// </summary>
[Obsolete("Emulation")]public async Task ClearGeolocationOverride(
) {
var resp = await _target.SendRequest("Page.clearGeolocationOverride",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class CreateIsolatedWorldParams {
/// <summary>
/// Id of the frame in which the isolated world should be created.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// An optional name which is reported in the Execution Context.
/// </summary>
[JsonPropertyName("worldName")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? WorldName{get;set;}
/// <summary>
/// Whether or not universal access should be granted to the isolated world. This is a powerful
/// option, use with caution.
/// </summary>
[JsonPropertyName("grantUniveralAccess")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? GrantUniveralAccess{get;set;}
}
public sealed partial class CreateIsolatedWorldReturn {
/// <summary>
/// Execution context of the isolated world.
/// </summary>
[JsonPropertyName("executionContextId")]public Runtime.ExecutionContextId ExecutionContextId{get;set;}
}
/// <summary>
/// Creates an isolated world for the given frame.
/// </summary>
/// <param name="frameId">Id of the frame in which the isolated world should be created.</param>
/// <param name="worldName">An optional name which is reported in the Execution Context.</param>
/// <param name="grantUniveralAccess">Whether or not universal access should be granted to the isolated world. This is a powerful
/// option, use with caution.</param>
public async Task<CreateIsolatedWorldReturn> CreateIsolatedWorld(
 Page.FrameId @frameId,string? @worldName=default,bool? @grantUniveralAccess=default) {
var resp = await _target.SendRequest("Page.createIsolatedWorld",
new CreateIsolatedWorldParams {
FrameId=@frameId,WorldName=@worldName,GrantUniveralAccess=@grantUniveralAccess,});
return _target.DeserializeResponse<CreateIsolatedWorldReturn>(resp);
}
public sealed partial class DeleteCookieParams {
/// <summary>
/// Name of the cookie to remove.
/// </summary>
[JsonPropertyName("cookieName")]public string CookieName{get;set;}
/// <summary>
/// URL to match cooke domain and path.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
}
/// <summary>
/// Deletes browser cookie with given name, domain and path.
/// </summary>
/// <param name="cookieName">Name of the cookie to remove.</param>
/// <param name="url">URL to match cooke domain and path.</param>
[Experimental][Obsolete("Network")]public async Task DeleteCookie(
 string @cookieName,string @url) {
var resp = await _target.SendRequest("Page.deleteCookie",
new DeleteCookieParams {
CookieName=@cookieName,Url=@url,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Disables page domain notifications.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("Page.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Enables page domain notifications.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("Page.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetAppManifestReturn {
/// <summary>
/// Manifest location.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
[JsonPropertyName("errors")]public Page.AppManifestError[] Errors{get;set;}
/// <summary>
/// Manifest content.
/// </summary>
[JsonPropertyName("data")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Data{get;set;}
/// <summary>
/// Parsed manifest properties
/// </summary>
[Experimental][JsonPropertyName("parsed")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.AppManifestParsedProperties? Parsed{get;set;}
}
public async Task<GetAppManifestReturn> GetAppManifest(
) {
var resp = await _target.SendRequest("Page.getAppManifest",
VoidData.Instance);
return _target.DeserializeResponse<GetAppManifestReturn>(resp);
}
public sealed partial class GetInstallabilityErrorsReturn {
[JsonPropertyName("installabilityErrors")]public Page.InstallabilityError[] InstallabilityErrors{get;set;}
}
[Experimental]public async Task<GetInstallabilityErrorsReturn> GetInstallabilityErrors(
) {
var resp = await _target.SendRequest("Page.getInstallabilityErrors",
VoidData.Instance);
return _target.DeserializeResponse<GetInstallabilityErrorsReturn>(resp);
}
public sealed partial class GetManifestIconsReturn {
[JsonPropertyName("primaryIcon")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? PrimaryIcon{get;set;}
}
[Experimental]public async Task<GetManifestIconsReturn> GetManifestIcons(
) {
var resp = await _target.SendRequest("Page.getManifestIcons",
VoidData.Instance);
return _target.DeserializeResponse<GetManifestIconsReturn>(resp);
}
public sealed partial class GetAppIdReturn {
/// <summary>
/// App id, either from manifest's id attribute or computed from start_url
/// </summary>
[JsonPropertyName("appId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? AppId{get;set;}
/// <summary>
/// Recommendation for manifest's id attribute to match current id computed from start_url
/// </summary>
[JsonPropertyName("recommendedId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? RecommendedId{get;set;}
}
/// <summary>
/// Returns the unique (PWA) app id.
/// Only returns values if the feature flag 'WebAppEnableManifestId' is enabled
/// </summary>
[Experimental]public async Task<GetAppIdReturn> GetAppId(
) {
var resp = await _target.SendRequest("Page.getAppId",
VoidData.Instance);
return _target.DeserializeResponse<GetAppIdReturn>(resp);
}
public sealed partial class GetCookiesReturn {
/// <summary>
/// Array of cookie objects.
/// </summary>
[JsonPropertyName("cookies")]public Network.Cookie[] Cookies{get;set;}
}
/// <summary>
/// Returns all browser cookies. Depending on the backend support, will return detailed cookie
/// information in the `cookies` field.
/// </summary>
[Experimental][Obsolete("Network")]public async Task<GetCookiesReturn> GetCookies(
) {
var resp = await _target.SendRequest("Page.getCookies",
VoidData.Instance);
return _target.DeserializeResponse<GetCookiesReturn>(resp);
}
public sealed partial class GetFrameTreeReturn {
/// <summary>
/// Present frame tree structure.
/// </summary>
[JsonPropertyName("frameTree")]public Page.FrameTree FrameTree{get;set;}
}
/// <summary>
/// Returns present frame tree structure.
/// </summary>
public async Task<GetFrameTreeReturn> GetFrameTree(
) {
var resp = await _target.SendRequest("Page.getFrameTree",
VoidData.Instance);
return _target.DeserializeResponse<GetFrameTreeReturn>(resp);
}
public sealed partial class GetLayoutMetricsReturn {
/// <summary>
/// Deprecated metrics relating to the layout viewport. Can be in DP or in CSS pixels depending on the `enable-use-zoom-for-dsf` flag. Use `cssLayoutViewport` instead.
/// </summary>
[Obsolete][JsonPropertyName("layoutViewport")]public Page.LayoutViewport LayoutViewport{get;set;}
/// <summary>
/// Deprecated metrics relating to the visual viewport. Can be in DP or in CSS pixels depending on the `enable-use-zoom-for-dsf` flag. Use `cssVisualViewport` instead.
/// </summary>
[Obsolete][JsonPropertyName("visualViewport")]public Page.VisualViewport VisualViewport{get;set;}
/// <summary>
/// Deprecated size of scrollable area. Can be in DP or in CSS pixels depending on the `enable-use-zoom-for-dsf` flag. Use `cssContentSize` instead.
/// </summary>
[Obsolete][JsonPropertyName("contentSize")]public DOM.Rect ContentSize{get;set;}
/// <summary>
/// Metrics relating to the layout viewport in CSS pixels.
/// </summary>
[JsonPropertyName("cssLayoutViewport")]public Page.LayoutViewport CssLayoutViewport{get;set;}
/// <summary>
/// Metrics relating to the visual viewport in CSS pixels.
/// </summary>
[JsonPropertyName("cssVisualViewport")]public Page.VisualViewport CssVisualViewport{get;set;}
/// <summary>
/// Size of scrollable area in CSS pixels.
/// </summary>
[JsonPropertyName("cssContentSize")]public DOM.Rect CssContentSize{get;set;}
}
/// <summary>
/// Returns metrics relating to the layouting of the page, such as viewport bounds/scale.
/// </summary>
public async Task<GetLayoutMetricsReturn> GetLayoutMetrics(
) {
var resp = await _target.SendRequest("Page.getLayoutMetrics",
VoidData.Instance);
return _target.DeserializeResponse<GetLayoutMetricsReturn>(resp);
}
public sealed partial class GetNavigationHistoryReturn {
/// <summary>
/// Index of the current navigation history entry.
/// </summary>
[JsonPropertyName("currentIndex")]public long CurrentIndex{get;set;}
/// <summary>
/// Array of navigation history entries.
/// </summary>
[JsonPropertyName("entries")]public Page.NavigationEntry[] Entries{get;set;}
}
/// <summary>
/// Returns navigation history for the current page.
/// </summary>
public async Task<GetNavigationHistoryReturn> GetNavigationHistory(
) {
var resp = await _target.SendRequest("Page.getNavigationHistory",
VoidData.Instance);
return _target.DeserializeResponse<GetNavigationHistoryReturn>(resp);
}
/// <summary>
/// Resets navigation history for the current page.
/// </summary>
public async Task ResetNavigationHistory(
) {
var resp = await _target.SendRequest("Page.resetNavigationHistory",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetResourceContentParams {
/// <summary>
/// Frame id to get resource for.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// URL of the resource to get content for.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
}
public sealed partial class GetResourceContentReturn {
/// <summary>
/// Resource content.
/// </summary>
[JsonPropertyName("content")]public string Content{get;set;}
/// <summary>
/// True, if content was served as base64.
/// </summary>
[JsonPropertyName("base64Encoded")]public bool Base64Encoded{get;set;}
}
/// <summary>
/// Returns content of the given resource.
/// </summary>
/// <param name="frameId">Frame id to get resource for.</param>
/// <param name="url">URL of the resource to get content for.</param>
[Experimental]public async Task<GetResourceContentReturn> GetResourceContent(
 Page.FrameId @frameId,string @url) {
var resp = await _target.SendRequest("Page.getResourceContent",
new GetResourceContentParams {
FrameId=@frameId,Url=@url,});
return _target.DeserializeResponse<GetResourceContentReturn>(resp);
}
public sealed partial class GetResourceTreeReturn {
/// <summary>
/// Present frame / resource tree structure.
/// </summary>
[JsonPropertyName("frameTree")]public Page.FrameResourceTree FrameTree{get;set;}
}
/// <summary>
/// Returns present frame / resource tree structure.
/// </summary>
[Experimental]public async Task<GetResourceTreeReturn> GetResourceTree(
) {
var resp = await _target.SendRequest("Page.getResourceTree",
VoidData.Instance);
return _target.DeserializeResponse<GetResourceTreeReturn>(resp);
}
public sealed partial class HandleJavaScriptDialogParams {
/// <summary>
/// Whether to accept or dismiss the dialog.
/// </summary>
[JsonPropertyName("accept")]public bool Accept{get;set;}
/// <summary>
/// The text to enter into the dialog prompt before accepting. Used only if this is a prompt
/// dialog.
/// </summary>
[JsonPropertyName("promptText")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? PromptText{get;set;}
}
/// <summary>
/// Accepts or dismisses a JavaScript initiated dialog (alert, confirm, prompt, or onbeforeunload).
/// </summary>
/// <param name="accept">Whether to accept or dismiss the dialog.</param>
/// <param name="promptText">The text to enter into the dialog prompt before accepting. Used only if this is a prompt
/// dialog.</param>
public async Task HandleJavaScriptDialog(
 bool @accept,string? @promptText=default) {
var resp = await _target.SendRequest("Page.handleJavaScriptDialog",
new HandleJavaScriptDialogParams {
Accept=@accept,PromptText=@promptText,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class NavigateParams {
/// <summary>
/// URL to navigate the page to.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Referrer URL.
/// </summary>
[JsonPropertyName("referrer")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Referrer{get;set;}
/// <summary>
/// Intended transition type.
/// </summary>
[JsonPropertyName("transitionType")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.TransitionType? TransitionType{get;set;}
/// <summary>
/// Frame id to navigate, if not specified navigates the top frame.
/// </summary>
[JsonPropertyName("frameId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.FrameId? FrameId{get;set;}
/// <summary>
/// Referrer-policy used for the navigation.
/// </summary>
[Experimental][JsonPropertyName("referrerPolicy")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.ReferrerPolicy? ReferrerPolicy{get;set;}
}
public sealed partial class NavigateReturn {
/// <summary>
/// Frame id that has navigated (or failed to navigate)
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// Loader identifier.
/// </summary>
[JsonPropertyName("loaderId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.LoaderId? LoaderId{get;set;}
/// <summary>
/// User friendly error message, present if and only if navigation has failed.
/// </summary>
[JsonPropertyName("errorText")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ErrorText{get;set;}
}
/// <summary>
/// Navigates current page to the given URL.
/// </summary>
/// <param name="url">URL to navigate the page to.</param>
/// <param name="referrer">Referrer URL.</param>
/// <param name="transitionType">Intended transition type.</param>
/// <param name="frameId">Frame id to navigate, if not specified navigates the top frame.</param>
/// <param name="referrerPolicy">EXPERIMENTAL Referrer-policy used for the navigation.</param>
public async Task<NavigateReturn> Navigate(
 string @url,string? @referrer=default,Page.TransitionType? @transitionType=default,Page.FrameId? @frameId=default,Page.ReferrerPolicy? @referrerPolicy=default) {
var resp = await _target.SendRequest("Page.navigate",
new NavigateParams {
Url=@url,Referrer=@referrer,TransitionType=@transitionType,FrameId=@frameId,ReferrerPolicy=@referrerPolicy,});
return _target.DeserializeResponse<NavigateReturn>(resp);
}
public sealed partial class NavigateToHistoryEntryParams {
/// <summary>
/// Unique id of the entry to navigate to.
/// </summary>
[JsonPropertyName("entryId")]public long EntryId{get;set;}
}
/// <summary>
/// Navigates current page to the given history entry.
/// </summary>
/// <param name="entryId">Unique id of the entry to navigate to.</param>
public async Task NavigateToHistoryEntry(
 long @entryId) {
var resp = await _target.SendRequest("Page.navigateToHistoryEntry",
new NavigateToHistoryEntryParams {
EntryId=@entryId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class PrintToPDFParams {
/// <summary>
/// Paper orientation. Defaults to false.
/// </summary>
[JsonPropertyName("landscape")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Landscape{get;set;}
/// <summary>
/// Display header and footer. Defaults to false.
/// </summary>
[JsonPropertyName("displayHeaderFooter")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? DisplayHeaderFooter{get;set;}
/// <summary>
/// Print background graphics. Defaults to false.
/// </summary>
[JsonPropertyName("printBackground")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? PrintBackground{get;set;}
/// <summary>
/// Scale of the webpage rendering. Defaults to 1.
/// </summary>
[JsonPropertyName("scale")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Scale{get;set;}
/// <summary>
/// Paper width in inches. Defaults to 8.5 inches.
/// </summary>
[JsonPropertyName("paperWidth")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? PaperWidth{get;set;}
/// <summary>
/// Paper height in inches. Defaults to 11 inches.
/// </summary>
[JsonPropertyName("paperHeight")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? PaperHeight{get;set;}
/// <summary>
/// Top margin in inches. Defaults to 1cm (~0.4 inches).
/// </summary>
[JsonPropertyName("marginTop")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? MarginTop{get;set;}
/// <summary>
/// Bottom margin in inches. Defaults to 1cm (~0.4 inches).
/// </summary>
[JsonPropertyName("marginBottom")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? MarginBottom{get;set;}
/// <summary>
/// Left margin in inches. Defaults to 1cm (~0.4 inches).
/// </summary>
[JsonPropertyName("marginLeft")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? MarginLeft{get;set;}
/// <summary>
/// Right margin in inches. Defaults to 1cm (~0.4 inches).
/// </summary>
[JsonPropertyName("marginRight")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? MarginRight{get;set;}
/// <summary>
/// Paper ranges to print, e.g., '1-5, 8, 11-13'. Defaults to the empty string, which means
/// print all pages.
/// </summary>
[JsonPropertyName("pageRanges")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? PageRanges{get;set;}
/// <summary>
/// Whether to silently ignore invalid but successfully parsed page ranges, such as '3-2'.
/// Defaults to false.
/// </summary>
[JsonPropertyName("ignoreInvalidPageRanges")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IgnoreInvalidPageRanges{get;set;}
/// <summary>
/// HTML template for the print header. Should be valid HTML markup with following
/// classes used to inject printing values into them:
/// - `date`: formatted print date
/// - `title`: document title
/// - `url`: document location
/// - `pageNumber`: current page number
/// - `totalPages`: total pages in the document
/// 
/// For example, `<span class=title></span>` would generate span containing the title.
/// </summary>
[JsonPropertyName("headerTemplate")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? HeaderTemplate{get;set;}
/// <summary>
/// HTML template for the print footer. Should use the same format as the `headerTemplate`.
/// </summary>
[JsonPropertyName("footerTemplate")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? FooterTemplate{get;set;}
/// <summary>
/// Whether or not to prefer page size as defined by css. Defaults to false,
/// in which case the content will be scaled to fit the paper size.
/// </summary>
[JsonPropertyName("preferCSSPageSize")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? PreferCSSPageSize{get;set;}
/// <summary>
/// return as stream
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum TransferModeEnum {
[EnumMember(Value = "ReturnAsBase64")] ReturnAsBase64,
[EnumMember(Value = "ReturnAsStream")] ReturnAsStream,
}
[JsonPropertyName("transferMode")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public TransferModeEnum? TransferMode{get;set;}
}
public sealed partial class PrintToPDFReturn {
/// <summary>
/// Base64-encoded pdf data. Empty if |returnAsStream| is specified. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("data")]public string Data{get;set;}
/// <summary>
/// A handle of the stream that holds resulting PDF data.
/// </summary>
[Experimental][JsonPropertyName("stream")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public IO.StreamHandle? Stream{get;set;}
}
/// <summary>
/// Print page as PDF.
/// </summary>
/// <param name="landscape">Paper orientation. Defaults to false.</param>
/// <param name="displayHeaderFooter">Display header and footer. Defaults to false.</param>
/// <param name="printBackground">Print background graphics. Defaults to false.</param>
/// <param name="scale">Scale of the webpage rendering. Defaults to 1.</param>
/// <param name="paperWidth">Paper width in inches. Defaults to 8.5 inches.</param>
/// <param name="paperHeight">Paper height in inches. Defaults to 11 inches.</param>
/// <param name="marginTop">Top margin in inches. Defaults to 1cm (~0.4 inches).</param>
/// <param name="marginBottom">Bottom margin in inches. Defaults to 1cm (~0.4 inches).</param>
/// <param name="marginLeft">Left margin in inches. Defaults to 1cm (~0.4 inches).</param>
/// <param name="marginRight">Right margin in inches. Defaults to 1cm (~0.4 inches).</param>
/// <param name="pageRanges">Paper ranges to print, e.g., '1-5, 8, 11-13'. Defaults to the empty string, which means
/// print all pages.</param>
/// <param name="ignoreInvalidPageRanges">Whether to silently ignore invalid but successfully parsed page ranges, such as '3-2'.
/// Defaults to false.</param>
/// <param name="headerTemplate">HTML template for the print header. Should be valid HTML markup with following
/// classes used to inject printing values into them:
/// - `date`: formatted print date
/// - `title`: document title
/// - `url`: document location
/// - `pageNumber`: current page number
/// - `totalPages`: total pages in the document
/// 
/// For example, `<span class=title></span>` would generate span containing the title.</param>
/// <param name="footerTemplate">HTML template for the print footer. Should use the same format as the `headerTemplate`.</param>
/// <param name="preferCSSPageSize">Whether or not to prefer page size as defined by css. Defaults to false,
/// in which case the content will be scaled to fit the paper size.</param>
/// <param name="transferMode">EXPERIMENTAL return as stream</param>
public async Task<PrintToPDFReturn> PrintToPDF(
 bool? @landscape=default,bool? @displayHeaderFooter=default,bool? @printBackground=default,double? @scale=default,double? @paperWidth=default,double? @paperHeight=default,double? @marginTop=default,double? @marginBottom=default,double? @marginLeft=default,double? @marginRight=default,string? @pageRanges=default,bool? @ignoreInvalidPageRanges=default,string? @headerTemplate=default,string? @footerTemplate=default,bool? @preferCSSPageSize=default,PrintToPDFParams.TransferModeEnum? @transferMode=default) {
var resp = await _target.SendRequest("Page.printToPDF",
new PrintToPDFParams {
Landscape=@landscape,DisplayHeaderFooter=@displayHeaderFooter,PrintBackground=@printBackground,Scale=@scale,PaperWidth=@paperWidth,PaperHeight=@paperHeight,MarginTop=@marginTop,MarginBottom=@marginBottom,MarginLeft=@marginLeft,MarginRight=@marginRight,PageRanges=@pageRanges,IgnoreInvalidPageRanges=@ignoreInvalidPageRanges,HeaderTemplate=@headerTemplate,FooterTemplate=@footerTemplate,PreferCSSPageSize=@preferCSSPageSize,TransferMode=@transferMode,});
return _target.DeserializeResponse<PrintToPDFReturn>(resp);
}
public sealed partial class ReloadParams {
/// <summary>
/// If true, browser cache is ignored (as if the user pressed Shift+refresh).
/// </summary>
[JsonPropertyName("ignoreCache")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IgnoreCache{get;set;}
/// <summary>
/// If set, the script will be injected into all frames of the inspected page after reload.
/// Argument will be ignored if reloading dataURL origin.
/// </summary>
[JsonPropertyName("scriptToEvaluateOnLoad")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ScriptToEvaluateOnLoad{get;set;}
}
/// <summary>
/// Reloads given page optionally ignoring the cache.
/// </summary>
/// <param name="ignoreCache">If true, browser cache is ignored (as if the user pressed Shift+refresh).</param>
/// <param name="scriptToEvaluateOnLoad">If set, the script will be injected into all frames of the inspected page after reload.
/// Argument will be ignored if reloading dataURL origin.</param>
public async Task Reload(
 bool? @ignoreCache=default,string? @scriptToEvaluateOnLoad=default) {
var resp = await _target.SendRequest("Page.reload",
new ReloadParams {
IgnoreCache=@ignoreCache,ScriptToEvaluateOnLoad=@scriptToEvaluateOnLoad,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class RemoveScriptToEvaluateOnLoadParams {
[JsonPropertyName("identifier")]public Page.ScriptIdentifier Identifier{get;set;}
}
/// <summary>
/// Deprecated, please use removeScriptToEvaluateOnNewDocument instead.
/// </summary>
/// <param name="identifier"></param>
[Experimental][Obsolete]public async Task RemoveScriptToEvaluateOnLoad(
 Page.ScriptIdentifier @identifier) {
var resp = await _target.SendRequest("Page.removeScriptToEvaluateOnLoad",
new RemoveScriptToEvaluateOnLoadParams {
Identifier=@identifier,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class RemoveScriptToEvaluateOnNewDocumentParams {
[JsonPropertyName("identifier")]public Page.ScriptIdentifier Identifier{get;set;}
}
/// <summary>
/// Removes given script from the list.
/// </summary>
/// <param name="identifier"></param>
public async Task RemoveScriptToEvaluateOnNewDocument(
 Page.ScriptIdentifier @identifier) {
var resp = await _target.SendRequest("Page.removeScriptToEvaluateOnNewDocument",
new RemoveScriptToEvaluateOnNewDocumentParams {
Identifier=@identifier,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class ScreencastFrameAckParams {
/// <summary>
/// Frame number.
/// </summary>
[JsonPropertyName("sessionId")]public long SessionId{get;set;}
}
/// <summary>
/// Acknowledges that a screencast frame has been received by the frontend.
/// </summary>
/// <param name="sessionId">Frame number.</param>
[Experimental]public async Task ScreencastFrameAck(
 long @sessionId) {
var resp = await _target.SendRequest("Page.screencastFrameAck",
new ScreencastFrameAckParams {
SessionId=@sessionId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SearchInResourceParams {
/// <summary>
/// Frame id for resource to search in.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// URL of the resource to search in.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// String to search for.
/// </summary>
[JsonPropertyName("query")]public string Query{get;set;}
/// <summary>
/// If true, search is case sensitive.
/// </summary>
[JsonPropertyName("caseSensitive")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? CaseSensitive{get;set;}
/// <summary>
/// If true, treats string parameter as regex.
/// </summary>
[JsonPropertyName("isRegex")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IsRegex{get;set;}
}
public sealed partial class SearchInResourceReturn {
/// <summary>
/// List of search matches.
/// </summary>
[JsonPropertyName("result")]public Debugger.SearchMatch[] Result{get;set;}
}
/// <summary>
/// Searches for given string in resource content.
/// </summary>
/// <param name="frameId">Frame id for resource to search in.</param>
/// <param name="url">URL of the resource to search in.</param>
/// <param name="query">String to search for.</param>
/// <param name="caseSensitive">If true, search is case sensitive.</param>
/// <param name="isRegex">If true, treats string parameter as regex.</param>
[Experimental]public async Task<SearchInResourceReturn> SearchInResource(
 Page.FrameId @frameId,string @url,string @query,bool? @caseSensitive=default,bool? @isRegex=default) {
var resp = await _target.SendRequest("Page.searchInResource",
new SearchInResourceParams {
FrameId=@frameId,Url=@url,Query=@query,CaseSensitive=@caseSensitive,IsRegex=@isRegex,});
return _target.DeserializeResponse<SearchInResourceReturn>(resp);
}
public sealed partial class SetAdBlockingEnabledParams {
/// <summary>
/// Whether to block ads.
/// </summary>
[JsonPropertyName("enabled")]public bool Enabled{get;set;}
}
/// <summary>
/// Enable Chrome's experimental ad filter on all sites.
/// </summary>
/// <param name="enabled">Whether to block ads.</param>
[Experimental]public async Task SetAdBlockingEnabled(
 bool @enabled) {
var resp = await _target.SendRequest("Page.setAdBlockingEnabled",
new SetAdBlockingEnabledParams {
Enabled=@enabled,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetBypassCSPParams {
/// <summary>
/// Whether to bypass page CSP.
/// </summary>
[JsonPropertyName("enabled")]public bool Enabled{get;set;}
}
/// <summary>
/// Enable page Content Security Policy by-passing.
/// </summary>
/// <param name="enabled">Whether to bypass page CSP.</param>
[Experimental]public async Task SetBypassCSP(
 bool @enabled) {
var resp = await _target.SendRequest("Page.setBypassCSP",
new SetBypassCSPParams {
Enabled=@enabled,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetPermissionsPolicyStateParams {
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
}
public sealed partial class GetPermissionsPolicyStateReturn {
[JsonPropertyName("states")]public Page.PermissionsPolicyFeatureState[] States{get;set;}
}
/// <summary>
/// Get Permissions Policy state on given frame.
/// </summary>
/// <param name="frameId"></param>
[Experimental]public async Task<GetPermissionsPolicyStateReturn> GetPermissionsPolicyState(
 Page.FrameId @frameId) {
var resp = await _target.SendRequest("Page.getPermissionsPolicyState",
new GetPermissionsPolicyStateParams {
FrameId=@frameId,});
return _target.DeserializeResponse<GetPermissionsPolicyStateReturn>(resp);
}
public sealed partial class GetOriginTrialsParams {
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
}
public sealed partial class GetOriginTrialsReturn {
[JsonPropertyName("originTrials")]public Page.OriginTrial[] OriginTrials{get;set;}
}
/// <summary>
/// Get Origin Trials on given frame.
/// </summary>
/// <param name="frameId"></param>
[Experimental]public async Task<GetOriginTrialsReturn> GetOriginTrials(
 Page.FrameId @frameId) {
var resp = await _target.SendRequest("Page.getOriginTrials",
new GetOriginTrialsParams {
FrameId=@frameId,});
return _target.DeserializeResponse<GetOriginTrialsReturn>(resp);
}
public sealed partial class SetDeviceMetricsOverrideParams {
/// <summary>
/// Overriding width value in pixels (minimum 0, maximum 10000000). 0 disables the override.
/// </summary>
[JsonPropertyName("width")]public long Width{get;set;}
/// <summary>
/// Overriding height value in pixels (minimum 0, maximum 10000000). 0 disables the override.
/// </summary>
[JsonPropertyName("height")]public long Height{get;set;}
/// <summary>
/// Overriding device scale factor value. 0 disables the override.
/// </summary>
[JsonPropertyName("deviceScaleFactor")]public double DeviceScaleFactor{get;set;}
/// <summary>
/// Whether to emulate mobile device. This includes viewport meta tag, overlay scrollbars, text
/// autosizing and more.
/// </summary>
[JsonPropertyName("mobile")]public bool Mobile{get;set;}
/// <summary>
/// Scale to apply to resulting view image.
/// </summary>
[JsonPropertyName("scale")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Scale{get;set;}
/// <summary>
/// Overriding screen width value in pixels (minimum 0, maximum 10000000).
/// </summary>
[JsonPropertyName("screenWidth")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? ScreenWidth{get;set;}
/// <summary>
/// Overriding screen height value in pixels (minimum 0, maximum 10000000).
/// </summary>
[JsonPropertyName("screenHeight")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? ScreenHeight{get;set;}
/// <summary>
/// Overriding view X position on screen in pixels (minimum 0, maximum 10000000).
/// </summary>
[JsonPropertyName("positionX")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? PositionX{get;set;}
/// <summary>
/// Overriding view Y position on screen in pixels (minimum 0, maximum 10000000).
/// </summary>
[JsonPropertyName("positionY")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? PositionY{get;set;}
/// <summary>
/// Do not set visible view size, rely upon explicit setVisibleSize call.
/// </summary>
[JsonPropertyName("dontSetVisibleSize")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? DontSetVisibleSize{get;set;}
/// <summary>
/// Screen orientation override.
/// </summary>
[JsonPropertyName("screenOrientation")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Emulation.ScreenOrientation? ScreenOrientation{get;set;}
/// <summary>
/// The viewport dimensions and scale. If not set, the override is cleared.
/// </summary>
[JsonPropertyName("viewport")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.Viewport? Viewport{get;set;}
}
/// <summary>
/// Overrides the values of device screen dimensions (window.screen.width, window.screen.height,
/// window.innerWidth, window.innerHeight, and "device-width"/"device-height"-related CSS media
/// query results).
/// </summary>
/// <param name="width">Overriding width value in pixels (minimum 0, maximum 10000000). 0 disables the override.</param>
/// <param name="height">Overriding height value in pixels (minimum 0, maximum 10000000). 0 disables the override.</param>
/// <param name="deviceScaleFactor">Overriding device scale factor value. 0 disables the override.</param>
/// <param name="mobile">Whether to emulate mobile device. This includes viewport meta tag, overlay scrollbars, text
/// autosizing and more.</param>
/// <param name="scale">Scale to apply to resulting view image.</param>
/// <param name="screenWidth">Overriding screen width value in pixels (minimum 0, maximum 10000000).</param>
/// <param name="screenHeight">Overriding screen height value in pixels (minimum 0, maximum 10000000).</param>
/// <param name="positionX">Overriding view X position on screen in pixels (minimum 0, maximum 10000000).</param>
/// <param name="positionY">Overriding view Y position on screen in pixels (minimum 0, maximum 10000000).</param>
/// <param name="dontSetVisibleSize">Do not set visible view size, rely upon explicit setVisibleSize call.</param>
/// <param name="screenOrientation">Screen orientation override.</param>
/// <param name="viewport">The viewport dimensions and scale. If not set, the override is cleared.</param>
[Experimental][Obsolete("Emulation")]public async Task SetDeviceMetricsOverride(
 long @width,long @height,double @deviceScaleFactor,bool @mobile,double? @scale=default,long? @screenWidth=default,long? @screenHeight=default,long? @positionX=default,long? @positionY=default,bool? @dontSetVisibleSize=default,Emulation.ScreenOrientation? @screenOrientation=default,Page.Viewport? @viewport=default) {
var resp = await _target.SendRequest("Page.setDeviceMetricsOverride",
new SetDeviceMetricsOverrideParams {
Width=@width,Height=@height,DeviceScaleFactor=@deviceScaleFactor,Mobile=@mobile,Scale=@scale,ScreenWidth=@screenWidth,ScreenHeight=@screenHeight,PositionX=@positionX,PositionY=@positionY,DontSetVisibleSize=@dontSetVisibleSize,ScreenOrientation=@screenOrientation,Viewport=@viewport,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetDeviceOrientationOverrideParams {
/// <summary>
/// Mock alpha
/// </summary>
[JsonPropertyName("alpha")]public double Alpha{get;set;}
/// <summary>
/// Mock beta
/// </summary>
[JsonPropertyName("beta")]public double Beta{get;set;}
/// <summary>
/// Mock gamma
/// </summary>
[JsonPropertyName("gamma")]public double Gamma{get;set;}
}
/// <summary>
/// Overrides the Device Orientation.
/// </summary>
/// <param name="alpha">Mock alpha</param>
/// <param name="beta">Mock beta</param>
/// <param name="gamma">Mock gamma</param>
[Experimental][Obsolete("DeviceOrientation")]public async Task SetDeviceOrientationOverride(
 double @alpha,double @beta,double @gamma) {
var resp = await _target.SendRequest("Page.setDeviceOrientationOverride",
new SetDeviceOrientationOverrideParams {
Alpha=@alpha,Beta=@beta,Gamma=@gamma,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetFontFamiliesParams {
/// <summary>
/// Specifies font families to set. If a font family is not specified, it won't be changed.
/// </summary>
[JsonPropertyName("fontFamilies")]public Page.FontFamilies FontFamilies{get;set;}
/// <summary>
/// Specifies font families to set for individual scripts.
/// </summary>
[JsonPropertyName("forScripts")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.ScriptFontFamilies[]? ForScripts{get;set;}
}
/// <summary>
/// Set generic font families.
/// </summary>
/// <param name="fontFamilies">Specifies font families to set. If a font family is not specified, it won't be changed.</param>
/// <param name="forScripts">Specifies font families to set for individual scripts.</param>
[Experimental]public async Task SetFontFamilies(
 Page.FontFamilies @fontFamilies,Page.ScriptFontFamilies[]? @forScripts=default) {
var resp = await _target.SendRequest("Page.setFontFamilies",
new SetFontFamiliesParams {
FontFamilies=@fontFamilies,ForScripts=@forScripts,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetFontSizesParams {
/// <summary>
/// Specifies font sizes to set. If a font size is not specified, it won't be changed.
/// </summary>
[JsonPropertyName("fontSizes")]public Page.FontSizes FontSizes{get;set;}
}
/// <summary>
/// Set default font sizes.
/// </summary>
/// <param name="fontSizes">Specifies font sizes to set. If a font size is not specified, it won't be changed.</param>
[Experimental]public async Task SetFontSizes(
 Page.FontSizes @fontSizes) {
var resp = await _target.SendRequest("Page.setFontSizes",
new SetFontSizesParams {
FontSizes=@fontSizes,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetDocumentContentParams {
/// <summary>
/// Frame id to set HTML for.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// HTML content to set.
/// </summary>
[JsonPropertyName("html")]public string Html{get;set;}
}
/// <summary>
/// Sets given markup as the document's HTML.
/// </summary>
/// <param name="frameId">Frame id to set HTML for.</param>
/// <param name="html">HTML content to set.</param>
public async Task SetDocumentContent(
 Page.FrameId @frameId,string @html) {
var resp = await _target.SendRequest("Page.setDocumentContent",
new SetDocumentContentParams {
FrameId=@frameId,Html=@html,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetDownloadBehaviorParams {
/// <summary>
/// Whether to allow all or deny all download requests, or use default Chrome behavior if
/// available (otherwise deny).
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum BehaviorEnum {
[EnumMember(Value = "deny")] Deny,
[EnumMember(Value = "allow")] Allow,
[EnumMember(Value = "default")] Default,
}
[JsonPropertyName("behavior")]public BehaviorEnum Behavior{get;set;}
/// <summary>
/// The default path to save downloaded files to. This is required if behavior is set to 'allow'
/// </summary>
[JsonPropertyName("downloadPath")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? DownloadPath{get;set;}
}
/// <summary>
/// Set the behavior when downloading a file.
/// </summary>
/// <param name="behavior">Whether to allow all or deny all download requests, or use default Chrome behavior if
/// available (otherwise deny).</param>
/// <param name="downloadPath">The default path to save downloaded files to. This is required if behavior is set to 'allow'</param>
[Experimental][Obsolete]public async Task SetDownloadBehavior(
 SetDownloadBehaviorParams.BehaviorEnum @behavior,string? @downloadPath=default) {
var resp = await _target.SendRequest("Page.setDownloadBehavior",
new SetDownloadBehaviorParams {
Behavior=@behavior,DownloadPath=@downloadPath,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetGeolocationOverrideParams {
/// <summary>
/// Mock latitude
/// </summary>
[JsonPropertyName("latitude")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Latitude{get;set;}
/// <summary>
/// Mock longitude
/// </summary>
[JsonPropertyName("longitude")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Longitude{get;set;}
/// <summary>
/// Mock accuracy
/// </summary>
[JsonPropertyName("accuracy")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Accuracy{get;set;}
}
/// <summary>
/// Overrides the Geolocation Position or Error. Omitting any of the parameters emulates position
/// unavailable.
/// </summary>
/// <param name="latitude">Mock latitude</param>
/// <param name="longitude">Mock longitude</param>
/// <param name="accuracy">Mock accuracy</param>
[Obsolete("Emulation")]public async Task SetGeolocationOverride(
 double? @latitude=default,double? @longitude=default,double? @accuracy=default) {
var resp = await _target.SendRequest("Page.setGeolocationOverride",
new SetGeolocationOverrideParams {
Latitude=@latitude,Longitude=@longitude,Accuracy=@accuracy,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetLifecycleEventsEnabledParams {
/// <summary>
/// If true, starts emitting lifecycle events.
/// </summary>
[JsonPropertyName("enabled")]public bool Enabled{get;set;}
}
/// <summary>
/// Controls whether page will emit lifecycle events.
/// </summary>
/// <param name="enabled">If true, starts emitting lifecycle events.</param>
[Experimental]public async Task SetLifecycleEventsEnabled(
 bool @enabled) {
var resp = await _target.SendRequest("Page.setLifecycleEventsEnabled",
new SetLifecycleEventsEnabledParams {
Enabled=@enabled,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetTouchEmulationEnabledParams {
/// <summary>
/// Whether the touch event emulation should be enabled.
/// </summary>
[JsonPropertyName("enabled")]public bool Enabled{get;set;}
/// <summary>
/// Touch/gesture events configuration. Default: current platform.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum ConfigurationEnum {
[EnumMember(Value = "mobile")] Mobile,
[EnumMember(Value = "desktop")] Desktop,
}
[JsonPropertyName("configuration")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public ConfigurationEnum? Configuration{get;set;}
}
/// <summary>
/// Toggles mouse event-based touch event emulation.
/// </summary>
/// <param name="enabled">Whether the touch event emulation should be enabled.</param>
/// <param name="configuration">Touch/gesture events configuration. Default: current platform.</param>
[Experimental][Obsolete("Emulation")]public async Task SetTouchEmulationEnabled(
 bool @enabled,SetTouchEmulationEnabledParams.ConfigurationEnum? @configuration=default) {
var resp = await _target.SendRequest("Page.setTouchEmulationEnabled",
new SetTouchEmulationEnabledParams {
Enabled=@enabled,Configuration=@configuration,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class StartScreencastParams {
/// <summary>
/// Image compression format.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum FormatEnum {
[EnumMember(Value = "jpeg")] Jpeg,
[EnumMember(Value = "png")] Png,
}
[JsonPropertyName("format")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public FormatEnum? Format{get;set;}
/// <summary>
/// Compression quality from range [0..100].
/// </summary>
[JsonPropertyName("quality")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Quality{get;set;}
/// <summary>
/// Maximum screenshot width.
/// </summary>
[JsonPropertyName("maxWidth")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? MaxWidth{get;set;}
/// <summary>
/// Maximum screenshot height.
/// </summary>
[JsonPropertyName("maxHeight")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? MaxHeight{get;set;}
/// <summary>
/// Send every n-th frame.
/// </summary>
[JsonPropertyName("everyNthFrame")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? EveryNthFrame{get;set;}
}
/// <summary>
/// Starts sending each frame using the `screencastFrame` event.
/// </summary>
/// <param name="format">Image compression format.</param>
/// <param name="quality">Compression quality from range [0..100].</param>
/// <param name="maxWidth">Maximum screenshot width.</param>
/// <param name="maxHeight">Maximum screenshot height.</param>
/// <param name="everyNthFrame">Send every n-th frame.</param>
[Experimental]public async Task StartScreencast(
 StartScreencastParams.FormatEnum? @format=default,long? @quality=default,long? @maxWidth=default,long? @maxHeight=default,long? @everyNthFrame=default) {
var resp = await _target.SendRequest("Page.startScreencast",
new StartScreencastParams {
Format=@format,Quality=@quality,MaxWidth=@maxWidth,MaxHeight=@maxHeight,EveryNthFrame=@everyNthFrame,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Force the page stop all navigations and pending resource fetches.
/// </summary>
public async Task StopLoading(
) {
var resp = await _target.SendRequest("Page.stopLoading",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Crashes renderer on the IO thread, generates minidumps.
/// </summary>
[Experimental]public async Task Crash(
) {
var resp = await _target.SendRequest("Page.crash",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Tries to close page, running its beforeunload hooks, if any.
/// </summary>
[Experimental]public async Task Close(
) {
var resp = await _target.SendRequest("Page.close",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetWebLifecycleStateParams {
/// <summary>
/// Target lifecycle state
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum StateEnum {
[EnumMember(Value = "frozen")] Frozen,
[EnumMember(Value = "active")] Active,
}
[JsonPropertyName("state")]public StateEnum State{get;set;}
}
/// <summary>
/// Tries to update the web lifecycle state of the page.
/// It will transition the page to the given state according to:
/// https://github.com/WICG/web-lifecycle/
/// </summary>
/// <param name="state">Target lifecycle state</param>
[Experimental]public async Task SetWebLifecycleState(
 SetWebLifecycleStateParams.StateEnum @state) {
var resp = await _target.SendRequest("Page.setWebLifecycleState",
new SetWebLifecycleStateParams {
State=@state,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Stops sending each frame in the `screencastFrame`.
/// </summary>
[Experimental]public async Task StopScreencast(
) {
var resp = await _target.SendRequest("Page.stopScreencast",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class ProduceCompilationCacheParams {
[JsonPropertyName("scripts")]public Page.CompilationCacheParams[] Scripts{get;set;}
}
/// <summary>
/// Requests backend to produce compilation cache for the specified scripts.
/// `scripts` are appeneded to the list of scripts for which the cache
/// would be produced. The list may be reset during page navigation.
/// When script with a matching URL is encountered, the cache is optionally
/// produced upon backend discretion, based on internal heuristics.
/// See also: `Page.compilationCacheProduced`.
/// </summary>
/// <param name="scripts"></param>
[Experimental]public async Task ProduceCompilationCache(
 Page.CompilationCacheParams[] @scripts) {
var resp = await _target.SendRequest("Page.produceCompilationCache",
new ProduceCompilationCacheParams {
Scripts=@scripts,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class AddCompilationCacheParams {
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Base64-encoded data (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("data")]public string Data{get;set;}
}
/// <summary>
/// Seeds compilation cache for given url. Compilation cache does not survive
/// cross-process navigation.
/// </summary>
/// <param name="url"></param>
/// <param name="data">Base64-encoded data (Encoded as a base64 string when passed over JSON)</param>
[Experimental]public async Task AddCompilationCache(
 string @url,string @data) {
var resp = await _target.SendRequest("Page.addCompilationCache",
new AddCompilationCacheParams {
Url=@url,Data=@data,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Clears seeded compilation cache.
/// </summary>
[Experimental]public async Task ClearCompilationCache(
) {
var resp = await _target.SendRequest("Page.clearCompilationCache",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetSPCTransactionModeParams {
[JsonConverter(typeof(StringEnumConverter))] public enum ModeEnum {
[EnumMember(Value = "none")] None,
[EnumMember(Value = "autoaccept")] Autoaccept,
[EnumMember(Value = "autoreject")] Autoreject,
}
[JsonPropertyName("mode")]public ModeEnum Mode{get;set;}
}
/// <summary>
/// Sets the Secure Payment Confirmation transaction mode.
/// https://w3c.github.io/secure-payment-confirmation/#sctn-automation-set-spc-transaction-mode
/// </summary>
/// <param name="mode"></param>
[Experimental]public async Task SetSPCTransactionMode(
 SetSPCTransactionModeParams.ModeEnum @mode) {
var resp = await _target.SendRequest("Page.setSPCTransactionMode",
new SetSPCTransactionModeParams {
Mode=@mode,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GenerateTestReportParams {
/// <summary>
/// Message to be displayed in the report.
/// </summary>
[JsonPropertyName("message")]public string Message{get;set;}
/// <summary>
/// Specifies the endpoint group to deliver the report to.
/// </summary>
[JsonPropertyName("group")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Group{get;set;}
}
/// <summary>
/// Generates a report for testing.
/// </summary>
/// <param name="message">Message to be displayed in the report.</param>
/// <param name="group">Specifies the endpoint group to deliver the report to.</param>
[Experimental]public async Task GenerateTestReport(
 string @message,string? @group=default) {
var resp = await _target.SendRequest("Page.generateTestReport",
new GenerateTestReportParams {
Message=@message,Group=@group,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Pauses page execution. Can be resumed using generic Runtime.runIfWaitingForDebugger.
/// </summary>
[Experimental]public async Task WaitForDebugger(
) {
var resp = await _target.SendRequest("Page.waitForDebugger",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetInterceptFileChooserDialogParams {
[JsonPropertyName("enabled")]public bool Enabled{get;set;}
}
/// <summary>
/// Intercept file chooser requests and transfer control to protocol clients.
/// When file chooser interception is enabled, native file chooser dialog is not shown.
/// Instead, a protocol event `Page.fileChooserOpened` is emitted.
/// </summary>
/// <param name="enabled"></param>
[Experimental]public async Task SetInterceptFileChooserDialog(
 bool @enabled) {
var resp = await _target.SendRequest("Page.setInterceptFileChooserDialog",
new SetInterceptFileChooserDialogParams {
Enabled=@enabled,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class DomContentEventFiredParams {
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
}
private Action<DomContentEventFiredParams>? _onDomContentEventFired;
public event Action<DomContentEventFiredParams> OnDomContentEventFired {
add => _onDomContentEventFired += value; remove => _onDomContentEventFired -= value;}
public sealed partial class FileChooserOpenedParams {
/// <summary>
/// Id of the frame containing input node.
/// </summary>
[Experimental][JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// Input node id.
/// </summary>
[Experimental][JsonPropertyName("backendNodeId")]public DOM.BackendNodeId BackendNodeId{get;set;}
/// <summary>
/// Input mode.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum ModeEnum {
[EnumMember(Value = "selectSingle")] SelectSingle,
[EnumMember(Value = "selectMultiple")] SelectMultiple,
}
[JsonPropertyName("mode")]public ModeEnum Mode{get;set;}
}
private Action<FileChooserOpenedParams>? _onFileChooserOpened;
/// <summary>
/// Emitted only when `page.interceptFileChooser` is enabled.
/// </summary>
public event Action<FileChooserOpenedParams> OnFileChooserOpened {
add => _onFileChooserOpened += value; remove => _onFileChooserOpened -= value;}
public sealed partial class FrameAttachedParams {
/// <summary>
/// Id of the frame that has been attached.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// Parent frame identifier.
/// </summary>
[JsonPropertyName("parentFrameId")]public Page.FrameId ParentFrameId{get;set;}
/// <summary>
/// JavaScript stack trace of when frame was attached, only set if frame initiated from script.
/// </summary>
[JsonPropertyName("stack")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.StackTrace? Stack{get;set;}
}
private Action<FrameAttachedParams>? _onFrameAttached;
/// <summary>
/// Fired when frame has been attached to its parent.
/// </summary>
public event Action<FrameAttachedParams> OnFrameAttached {
add => _onFrameAttached += value; remove => _onFrameAttached -= value;}
public sealed partial class FrameClearedScheduledNavigationParams {
/// <summary>
/// Id of the frame that has cleared its scheduled navigation.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
}
private Action<FrameClearedScheduledNavigationParams>? _onFrameClearedScheduledNavigation;
/// <summary>
/// Fired when frame no longer has a scheduled navigation.
/// </summary>
[Obsolete]public event Action<FrameClearedScheduledNavigationParams> OnFrameClearedScheduledNavigation {
add => _onFrameClearedScheduledNavigation += value; remove => _onFrameClearedScheduledNavigation -= value;}
public sealed partial class FrameDetachedParams {
/// <summary>
/// Id of the frame that has been detached.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum ReasonEnum {
[EnumMember(Value = "remove")] Remove,
[EnumMember(Value = "swap")] Swap,
}
[JsonPropertyName("reason")]public ReasonEnum Reason{get;set;}
}
private Action<FrameDetachedParams>? _onFrameDetached;
/// <summary>
/// Fired when frame has been detached from its parent.
/// </summary>
public event Action<FrameDetachedParams> OnFrameDetached {
add => _onFrameDetached += value; remove => _onFrameDetached -= value;}
public sealed partial class FrameNavigatedParams {
/// <summary>
/// Frame object.
/// </summary>
[JsonPropertyName("frame")]public Page.Frame Frame{get;set;}
[Experimental][JsonPropertyName("type")]public Page.NavigationType Type{get;set;}
}
private Action<FrameNavigatedParams>? _onFrameNavigated;
/// <summary>
/// Fired once navigation of the frame has completed. Frame is now associated with the new loader.
/// </summary>
public event Action<FrameNavigatedParams> OnFrameNavigated {
add => _onFrameNavigated += value; remove => _onFrameNavigated -= value;}
public sealed partial class DocumentOpenedParams {
/// <summary>
/// Frame object.
/// </summary>
[JsonPropertyName("frame")]public Page.Frame Frame{get;set;}
}
private Action<DocumentOpenedParams>? _onDocumentOpened;
/// <summary>
/// Fired when opening document to write to.
/// </summary>
[Experimental]public event Action<DocumentOpenedParams> OnDocumentOpened {
add => _onDocumentOpened += value; remove => _onDocumentOpened -= value;}
private Action? _onFrameResized;
[Experimental]public event Action OnFrameResized {
add => _onFrameResized += value; remove => _onFrameResized -= value;}
public sealed partial class FrameRequestedNavigationParams {
/// <summary>
/// Id of the frame that is being navigated.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// The reason for the navigation.
/// </summary>
[JsonPropertyName("reason")]public Page.ClientNavigationReason Reason{get;set;}
/// <summary>
/// The destination URL for the requested navigation.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// The disposition for the navigation.
/// </summary>
[JsonPropertyName("disposition")]public Page.ClientNavigationDisposition Disposition{get;set;}
}
private Action<FrameRequestedNavigationParams>? _onFrameRequestedNavigation;
/// <summary>
/// Fired when a renderer-initiated navigation is requested.
/// Navigation may still be cancelled after the event is issued.
/// </summary>
[Experimental]public event Action<FrameRequestedNavigationParams> OnFrameRequestedNavigation {
add => _onFrameRequestedNavigation += value; remove => _onFrameRequestedNavigation -= value;}
public sealed partial class FrameScheduledNavigationParams {
/// <summary>
/// Id of the frame that has scheduled a navigation.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// Delay (in seconds) until the navigation is scheduled to begin. The navigation is not
/// guaranteed to start.
/// </summary>
[JsonPropertyName("delay")]public double Delay{get;set;}
/// <summary>
/// The reason for the navigation.
/// </summary>
[JsonPropertyName("reason")]public Page.ClientNavigationReason Reason{get;set;}
/// <summary>
/// The destination URL for the scheduled navigation.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
}
private Action<FrameScheduledNavigationParams>? _onFrameScheduledNavigation;
/// <summary>
/// Fired when frame schedules a potential navigation.
/// </summary>
[Obsolete]public event Action<FrameScheduledNavigationParams> OnFrameScheduledNavigation {
add => _onFrameScheduledNavigation += value; remove => _onFrameScheduledNavigation -= value;}
public sealed partial class FrameStartedLoadingParams {
/// <summary>
/// Id of the frame that has started loading.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
}
private Action<FrameStartedLoadingParams>? _onFrameStartedLoading;
/// <summary>
/// Fired when frame has started loading.
/// </summary>
[Experimental]public event Action<FrameStartedLoadingParams> OnFrameStartedLoading {
add => _onFrameStartedLoading += value; remove => _onFrameStartedLoading -= value;}
public sealed partial class FrameStoppedLoadingParams {
/// <summary>
/// Id of the frame that has stopped loading.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
}
private Action<FrameStoppedLoadingParams>? _onFrameStoppedLoading;
/// <summary>
/// Fired when frame has stopped loading.
/// </summary>
[Experimental]public event Action<FrameStoppedLoadingParams> OnFrameStoppedLoading {
add => _onFrameStoppedLoading += value; remove => _onFrameStoppedLoading -= value;}
public sealed partial class DownloadWillBeginParams {
/// <summary>
/// Id of the frame that caused download to begin.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// Global unique identifier of the download.
/// </summary>
[JsonPropertyName("guid")]public string Guid{get;set;}
/// <summary>
/// URL of the resource being downloaded.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Suggested file name of the resource (the actual name of the file saved on disk may differ).
/// </summary>
[JsonPropertyName("suggestedFilename")]public string SuggestedFilename{get;set;}
}
private Action<DownloadWillBeginParams>? _onDownloadWillBegin;
/// <summary>
/// Fired when page is about to start a download.
/// Deprecated. Use Browser.downloadWillBegin instead.
/// </summary>
[Experimental][Obsolete]public event Action<DownloadWillBeginParams> OnDownloadWillBegin {
add => _onDownloadWillBegin += value; remove => _onDownloadWillBegin -= value;}
public sealed partial class DownloadProgressParams {
/// <summary>
/// Global unique identifier of the download.
/// </summary>
[JsonPropertyName("guid")]public string Guid{get;set;}
/// <summary>
/// Total expected bytes to download.
/// </summary>
[JsonPropertyName("totalBytes")]public double TotalBytes{get;set;}
/// <summary>
/// Total bytes received.
/// </summary>
[JsonPropertyName("receivedBytes")]public double ReceivedBytes{get;set;}
/// <summary>
/// Download status.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum StateEnum {
[EnumMember(Value = "inProgress")] InProgress,
[EnumMember(Value = "completed")] Completed,
[EnumMember(Value = "canceled")] Canceled,
}
[JsonPropertyName("state")]public StateEnum State{get;set;}
}
private Action<DownloadProgressParams>? _onDownloadProgress;
/// <summary>
/// Fired when download makes progress. Last call has |done| == true.
/// Deprecated. Use Browser.downloadProgress instead.
/// </summary>
[Experimental][Obsolete]public event Action<DownloadProgressParams> OnDownloadProgress {
add => _onDownloadProgress += value; remove => _onDownloadProgress -= value;}
private Action? _onInterstitialHidden;
/// <summary>
/// Fired when interstitial page was hidden
/// </summary>
public event Action OnInterstitialHidden {
add => _onInterstitialHidden += value; remove => _onInterstitialHidden -= value;}
private Action? _onInterstitialShown;
/// <summary>
/// Fired when interstitial page was shown
/// </summary>
public event Action OnInterstitialShown {
add => _onInterstitialShown += value; remove => _onInterstitialShown -= value;}
public sealed partial class JavascriptDialogClosedParams {
/// <summary>
/// Whether dialog was confirmed.
/// </summary>
[JsonPropertyName("result")]public bool Result{get;set;}
/// <summary>
/// User input in case of prompt.
/// </summary>
[JsonPropertyName("userInput")]public string UserInput{get;set;}
}
private Action<JavascriptDialogClosedParams>? _onJavascriptDialogClosed;
/// <summary>
/// Fired when a JavaScript initiated dialog (alert, confirm, prompt, or onbeforeunload) has been
/// closed.
/// </summary>
public event Action<JavascriptDialogClosedParams> OnJavascriptDialogClosed {
add => _onJavascriptDialogClosed += value; remove => _onJavascriptDialogClosed -= value;}
public sealed partial class JavascriptDialogOpeningParams {
/// <summary>
/// Frame url.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Message that will be displayed by the dialog.
/// </summary>
[JsonPropertyName("message")]public string Message{get;set;}
/// <summary>
/// Dialog type.
/// </summary>
[JsonPropertyName("type")]public Page.DialogType Type{get;set;}
/// <summary>
/// True iff browser is capable showing or acting on the given dialog. When browser has no
/// dialog handler for given target, calling alert while Page domain is engaged will stall
/// the page execution. Execution can be resumed via calling Page.handleJavaScriptDialog.
/// </summary>
[JsonPropertyName("hasBrowserHandler")]public bool HasBrowserHandler{get;set;}
/// <summary>
/// Default dialog prompt.
/// </summary>
[JsonPropertyName("defaultPrompt")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? DefaultPrompt{get;set;}
}
private Action<JavascriptDialogOpeningParams>? _onJavascriptDialogOpening;
/// <summary>
/// Fired when a JavaScript initiated dialog (alert, confirm, prompt, or onbeforeunload) is about to
/// open.
/// </summary>
public event Action<JavascriptDialogOpeningParams> OnJavascriptDialogOpening {
add => _onJavascriptDialogOpening += value; remove => _onJavascriptDialogOpening -= value;}
public sealed partial class LifecycleEventParams {
/// <summary>
/// Id of the frame.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// Loader identifier. Empty string if the request is fetched from worker.
/// </summary>
[JsonPropertyName("loaderId")]public Network.LoaderId LoaderId{get;set;}
[JsonPropertyName("name")]public string Name{get;set;}
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
}
private Action<LifecycleEventParams>? _onLifecycleEvent;
/// <summary>
/// Fired for top level page lifecycle events such as navigation, load, paint, etc.
/// </summary>
public event Action<LifecycleEventParams> OnLifecycleEvent {
add => _onLifecycleEvent += value; remove => _onLifecycleEvent -= value;}
public sealed partial class BackForwardCacheNotUsedParams {
/// <summary>
/// The loader id for the associated navgation.
/// </summary>
[JsonPropertyName("loaderId")]public Network.LoaderId LoaderId{get;set;}
/// <summary>
/// The frame id of the associated frame.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// Array of reasons why the page could not be cached. This must not be empty.
/// </summary>
[JsonPropertyName("notRestoredExplanations")]public Page.BackForwardCacheNotRestoredExplanation[] NotRestoredExplanations{get;set;}
/// <summary>
/// Tree structure of reasons why the page could not be cached for each frame.
/// </summary>
[JsonPropertyName("notRestoredExplanationsTree")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.BackForwardCacheNotRestoredExplanationTree? NotRestoredExplanationsTree{get;set;}
}
private Action<BackForwardCacheNotUsedParams>? _onBackForwardCacheNotUsed;
/// <summary>
/// Fired for failed bfcache history navigations if BackForwardCache feature is enabled. Do
/// not assume any ordering with the Page.frameNavigated event. This event is fired only for
/// main-frame history navigation where the document changes (non-same-document navigations),
/// when bfcache navigation fails.
/// </summary>
[Experimental]public event Action<BackForwardCacheNotUsedParams> OnBackForwardCacheNotUsed {
add => _onBackForwardCacheNotUsed += value; remove => _onBackForwardCacheNotUsed -= value;}
public sealed partial class LoadEventFiredParams {
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
}
private Action<LoadEventFiredParams>? _onLoadEventFired;
public event Action<LoadEventFiredParams> OnLoadEventFired {
add => _onLoadEventFired += value; remove => _onLoadEventFired -= value;}
public sealed partial class NavigatedWithinDocumentParams {
/// <summary>
/// Id of the frame.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// Frame's new url.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
}
private Action<NavigatedWithinDocumentParams>? _onNavigatedWithinDocument;
/// <summary>
/// Fired when same-document navigation happens, e.g. due to history API usage or anchor navigation.
/// </summary>
[Experimental]public event Action<NavigatedWithinDocumentParams> OnNavigatedWithinDocument {
add => _onNavigatedWithinDocument += value; remove => _onNavigatedWithinDocument -= value;}
public sealed partial class ScreencastFrameParams {
/// <summary>
/// Base64-encoded compressed image. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("data")]public string Data{get;set;}
/// <summary>
/// Screencast frame metadata.
/// </summary>
[JsonPropertyName("metadata")]public Page.ScreencastFrameMetadata Metadata{get;set;}
/// <summary>
/// Frame number.
/// </summary>
[JsonPropertyName("sessionId")]public long SessionId{get;set;}
}
private Action<ScreencastFrameParams>? _onScreencastFrame;
/// <summary>
/// Compressed image data requested by the `startScreencast`.
/// </summary>
[Experimental]public event Action<ScreencastFrameParams> OnScreencastFrame {
add => _onScreencastFrame += value; remove => _onScreencastFrame -= value;}
public sealed partial class ScreencastVisibilityChangedParams {
/// <summary>
/// True if the page is visible.
/// </summary>
[JsonPropertyName("visible")]public bool Visible{get;set;}
}
private Action<ScreencastVisibilityChangedParams>? _onScreencastVisibilityChanged;
/// <summary>
/// Fired when the page with currently enabled screencast was shown or hidden `.
/// </summary>
[Experimental]public event Action<ScreencastVisibilityChangedParams> OnScreencastVisibilityChanged {
add => _onScreencastVisibilityChanged += value; remove => _onScreencastVisibilityChanged -= value;}
public sealed partial class WindowOpenParams {
/// <summary>
/// The URL for the new window.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Window name.
/// </summary>
[JsonPropertyName("windowName")]public string WindowName{get;set;}
/// <summary>
/// An array of enabled window features.
/// </summary>
[JsonPropertyName("windowFeatures")]public string[] WindowFeatures{get;set;}
/// <summary>
/// Whether or not it was triggered by user gesture.
/// </summary>
[JsonPropertyName("userGesture")]public bool UserGesture{get;set;}
}
private Action<WindowOpenParams>? _onWindowOpen;
/// <summary>
/// Fired when a new window is going to be opened, via window.open(), link click, form submission,
/// etc.
/// </summary>
public event Action<WindowOpenParams> OnWindowOpen {
add => _onWindowOpen += value; remove => _onWindowOpen -= value;}
public sealed partial class CompilationCacheProducedParams {
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Base64-encoded data (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("data")]public string Data{get;set;}
}
private Action<CompilationCacheProducedParams>? _onCompilationCacheProduced;
/// <summary>
/// Issued for every compilation cache generated. Is only available
/// if Page.setGenerateCompilationCache is enabled.
/// </summary>
[Experimental]public event Action<CompilationCacheProducedParams> OnCompilationCacheProduced {
add => _onCompilationCacheProduced += value; remove => _onCompilationCacheProduced -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Page.domContentEventFired":
_onDomContentEventFired?.Invoke(_target.DeserializeEvent<DomContentEventFiredParams>(data));
break;
case "Page.fileChooserOpened":
_onFileChooserOpened?.Invoke(_target.DeserializeEvent<FileChooserOpenedParams>(data));
break;
case "Page.frameAttached":
_onFrameAttached?.Invoke(_target.DeserializeEvent<FrameAttachedParams>(data));
break;
case "Page.frameClearedScheduledNavigation":
_onFrameClearedScheduledNavigation?.Invoke(_target.DeserializeEvent<FrameClearedScheduledNavigationParams>(data));
break;
case "Page.frameDetached":
_onFrameDetached?.Invoke(_target.DeserializeEvent<FrameDetachedParams>(data));
break;
case "Page.frameNavigated":
_onFrameNavigated?.Invoke(_target.DeserializeEvent<FrameNavigatedParams>(data));
break;
case "Page.documentOpened":
_onDocumentOpened?.Invoke(_target.DeserializeEvent<DocumentOpenedParams>(data));
break;
case "Page.frameResized":
_onFrameResized?.Invoke();
break;
case "Page.frameRequestedNavigation":
_onFrameRequestedNavigation?.Invoke(_target.DeserializeEvent<FrameRequestedNavigationParams>(data));
break;
case "Page.frameScheduledNavigation":
_onFrameScheduledNavigation?.Invoke(_target.DeserializeEvent<FrameScheduledNavigationParams>(data));
break;
case "Page.frameStartedLoading":
_onFrameStartedLoading?.Invoke(_target.DeserializeEvent<FrameStartedLoadingParams>(data));
break;
case "Page.frameStoppedLoading":
_onFrameStoppedLoading?.Invoke(_target.DeserializeEvent<FrameStoppedLoadingParams>(data));
break;
case "Page.downloadWillBegin":
_onDownloadWillBegin?.Invoke(_target.DeserializeEvent<DownloadWillBeginParams>(data));
break;
case "Page.downloadProgress":
_onDownloadProgress?.Invoke(_target.DeserializeEvent<DownloadProgressParams>(data));
break;
case "Page.interstitialHidden":
_onInterstitialHidden?.Invoke();
break;
case "Page.interstitialShown":
_onInterstitialShown?.Invoke();
break;
case "Page.javascriptDialogClosed":
_onJavascriptDialogClosed?.Invoke(_target.DeserializeEvent<JavascriptDialogClosedParams>(data));
break;
case "Page.javascriptDialogOpening":
_onJavascriptDialogOpening?.Invoke(_target.DeserializeEvent<JavascriptDialogOpeningParams>(data));
break;
case "Page.lifecycleEvent":
_onLifecycleEvent?.Invoke(_target.DeserializeEvent<LifecycleEventParams>(data));
break;
case "Page.backForwardCacheNotUsed":
_onBackForwardCacheNotUsed?.Invoke(_target.DeserializeEvent<BackForwardCacheNotUsedParams>(data));
break;
case "Page.loadEventFired":
_onLoadEventFired?.Invoke(_target.DeserializeEvent<LoadEventFiredParams>(data));
break;
case "Page.navigatedWithinDocument":
_onNavigatedWithinDocument?.Invoke(_target.DeserializeEvent<NavigatedWithinDocumentParams>(data));
break;
case "Page.screencastFrame":
_onScreencastFrame?.Invoke(_target.DeserializeEvent<ScreencastFrameParams>(data));
break;
case "Page.screencastVisibilityChanged":
_onScreencastVisibilityChanged?.Invoke(_target.DeserializeEvent<ScreencastVisibilityChangedParams>(data));
break;
case "Page.windowOpen":
_onWindowOpen?.Invoke(_target.DeserializeEvent<WindowOpenParams>(data));
break;
case "Page.compilationCacheProduced":
_onCompilationCacheProduced?.Invoke(_target.DeserializeEvent<CompilationCacheProducedParams>(data));
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
_onDomContentEventFired = null;
_onFileChooserOpened = null;
_onFrameAttached = null;
_onFrameClearedScheduledNavigation = null;
_onFrameDetached = null;
_onFrameNavigated = null;
_onDocumentOpened = null;
_onFrameResized = null;
_onFrameRequestedNavigation = null;
_onFrameScheduledNavigation = null;
_onFrameStartedLoading = null;
_onFrameStoppedLoading = null;
_onDownloadWillBegin = null;
_onDownloadProgress = null;
_onInterstitialHidden = null;
_onInterstitialShown = null;
_onJavascriptDialogClosed = null;
_onJavascriptDialogOpening = null;
_onLifecycleEvent = null;
_onBackForwardCacheNotUsed = null;
_onLoadEventFired = null;
_onNavigatedWithinDocument = null;
_onScreencastFrame = null;
_onScreencastVisibilityChanged = null;
_onWindowOpen = null;
_onCompilationCacheProduced = null;
}
}
