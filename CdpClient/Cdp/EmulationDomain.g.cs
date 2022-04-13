using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// This domain emulates different environments for the page.
/// </summary>
public sealed partial class EmulationDomain {
private readonly ConnectedTarget _target;
public EmulationDomain(ConnectedTarget target) => _target = target;
public sealed partial class CanEmulateReturn {
/// <summary>
/// True if emulation is supported.
/// </summary>
[JsonPropertyName("result")]public bool Result{get;set;}
}
/// <summary>
/// Tells whether emulation is supported.
/// </summary>
public async Task<CanEmulateReturn> CanEmulate(
) {
var resp = await _target.SendRequest("Emulation.canEmulate",
VoidData.Instance);
return _target.DeserializeResponse<CanEmulateReturn>(resp);
}
/// <summary>
/// Clears the overridden device metrics.
/// </summary>
public async Task ClearDeviceMetricsOverride(
) {
var resp = await _target.SendRequest("Emulation.clearDeviceMetricsOverride",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Clears the overridden Geolocation Position and Error.
/// </summary>
public async Task ClearGeolocationOverride(
) {
var resp = await _target.SendRequest("Emulation.clearGeolocationOverride",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Requests that page scale factor is reset to initial values.
/// </summary>
[Experimental]public async Task ResetPageScaleFactor(
) {
var resp = await _target.SendRequest("Emulation.resetPageScaleFactor",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetFocusEmulationEnabledParams {
/// <summary>
/// Whether to enable to disable focus emulation.
/// </summary>
[JsonPropertyName("enabled")]public bool Enabled{get;set;}
}
/// <summary>
/// Enables or disables simulating a focused and active page.
/// </summary>
/// <param name="enabled">Whether to enable to disable focus emulation.</param>
[Experimental]public async Task SetFocusEmulationEnabled(
 bool @enabled) {
var resp = await _target.SendRequest("Emulation.setFocusEmulationEnabled",
new SetFocusEmulationEnabledParams {
Enabled=@enabled,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetAutoDarkModeOverrideParams {
/// <summary>
/// Whether to enable or disable automatic dark mode.
/// If not specified, any existing override will be cleared.
/// </summary>
[JsonPropertyName("enabled")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Enabled{get;set;}
}
/// <summary>
/// Automatically render all web contents using a dark theme.
/// </summary>
/// <param name="enabled">Whether to enable or disable automatic dark mode.
/// If not specified, any existing override will be cleared.</param>
[Experimental]public async Task SetAutoDarkModeOverride(
 bool? @enabled=default) {
var resp = await _target.SendRequest("Emulation.setAutoDarkModeOverride",
new SetAutoDarkModeOverrideParams {
Enabled=@enabled,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetCPUThrottlingRateParams {
/// <summary>
/// Throttling rate as a slowdown factor (1 is no throttle, 2 is 2x slowdown, etc).
/// </summary>
[JsonPropertyName("rate")]public double Rate{get;set;}
}
/// <summary>
/// Enables CPU throttling to emulate slow CPUs.
/// </summary>
/// <param name="rate">Throttling rate as a slowdown factor (1 is no throttle, 2 is 2x slowdown, etc).</param>
[Experimental]public async Task SetCPUThrottlingRate(
 double @rate) {
var resp = await _target.SendRequest("Emulation.setCPUThrottlingRate",
new SetCPUThrottlingRateParams {
Rate=@rate,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetDefaultBackgroundColorOverrideParams {
/// <summary>
/// RGBA of the default background color. If not specified, any existing override will be
/// cleared.
/// </summary>
[JsonPropertyName("color")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? Color{get;set;}
}
/// <summary>
/// Sets or clears an override of the default background color of the frame. This override is used
/// if the content does not specify one.
/// </summary>
/// <param name="color">RGBA of the default background color. If not specified, any existing override will be
/// cleared.</param>
public async Task SetDefaultBackgroundColorOverride(
 DOM.RGBA? @color=default) {
var resp = await _target.SendRequest("Emulation.setDefaultBackgroundColorOverride",
new SetDefaultBackgroundColorOverrideParams {
Color=@color,});
_target.DeserializeResponse<VoidData>(resp);
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
[Experimental][JsonPropertyName("scale")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Scale{get;set;}
/// <summary>
/// Overriding screen width value in pixels (minimum 0, maximum 10000000).
/// </summary>
[Experimental][JsonPropertyName("screenWidth")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? ScreenWidth{get;set;}
/// <summary>
/// Overriding screen height value in pixels (minimum 0, maximum 10000000).
/// </summary>
[Experimental][JsonPropertyName("screenHeight")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? ScreenHeight{get;set;}
/// <summary>
/// Overriding view X position on screen in pixels (minimum 0, maximum 10000000).
/// </summary>
[Experimental][JsonPropertyName("positionX")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? PositionX{get;set;}
/// <summary>
/// Overriding view Y position on screen in pixels (minimum 0, maximum 10000000).
/// </summary>
[Experimental][JsonPropertyName("positionY")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? PositionY{get;set;}
/// <summary>
/// Do not set visible view size, rely upon explicit setVisibleSize call.
/// </summary>
[Experimental][JsonPropertyName("dontSetVisibleSize")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? DontSetVisibleSize{get;set;}
/// <summary>
/// Screen orientation override.
/// </summary>
[JsonPropertyName("screenOrientation")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Emulation.ScreenOrientation? ScreenOrientation{get;set;}
/// <summary>
/// If set, the visible area of the page will be overridden to this viewport. This viewport
/// change is not observed by the page, e.g. viewport-relative elements do not change positions.
/// </summary>
[Experimental][JsonPropertyName("viewport")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.Viewport? Viewport{get;set;}
/// <summary>
/// If set, the display feature of a multi-segment screen. If not set, multi-segment support
/// is turned-off.
/// </summary>
[Experimental][JsonPropertyName("displayFeature")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Emulation.DisplayFeature? DisplayFeature{get;set;}
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
/// <param name="scale">EXPERIMENTAL Scale to apply to resulting view image.</param>
/// <param name="screenWidth">EXPERIMENTAL Overriding screen width value in pixels (minimum 0, maximum 10000000).</param>
/// <param name="screenHeight">EXPERIMENTAL Overriding screen height value in pixels (minimum 0, maximum 10000000).</param>
/// <param name="positionX">EXPERIMENTAL Overriding view X position on screen in pixels (minimum 0, maximum 10000000).</param>
/// <param name="positionY">EXPERIMENTAL Overriding view Y position on screen in pixels (minimum 0, maximum 10000000).</param>
/// <param name="dontSetVisibleSize">EXPERIMENTAL Do not set visible view size, rely upon explicit setVisibleSize call.</param>
/// <param name="screenOrientation">Screen orientation override.</param>
/// <param name="viewport">EXPERIMENTAL If set, the visible area of the page will be overridden to this viewport. This viewport
/// change is not observed by the page, e.g. viewport-relative elements do not change positions.</param>
/// <param name="displayFeature">EXPERIMENTAL If set, the display feature of a multi-segment screen. If not set, multi-segment support
/// is turned-off.</param>
public async Task SetDeviceMetricsOverride(
 long @width,long @height,double @deviceScaleFactor,bool @mobile,double? @scale=default,long? @screenWidth=default,long? @screenHeight=default,long? @positionX=default,long? @positionY=default,bool? @dontSetVisibleSize=default,Emulation.ScreenOrientation? @screenOrientation=default,Page.Viewport? @viewport=default,Emulation.DisplayFeature? @displayFeature=default) {
var resp = await _target.SendRequest("Emulation.setDeviceMetricsOverride",
new SetDeviceMetricsOverrideParams {
Width=@width,Height=@height,DeviceScaleFactor=@deviceScaleFactor,Mobile=@mobile,Scale=@scale,ScreenWidth=@screenWidth,ScreenHeight=@screenHeight,PositionX=@positionX,PositionY=@positionY,DontSetVisibleSize=@dontSetVisibleSize,ScreenOrientation=@screenOrientation,Viewport=@viewport,DisplayFeature=@displayFeature,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetScrollbarsHiddenParams {
/// <summary>
/// Whether scrollbars should be always hidden.
/// </summary>
[JsonPropertyName("hidden")]public bool Hidden{get;set;}
}
/// <param name="hidden">Whether scrollbars should be always hidden.</param>
[Experimental]public async Task SetScrollbarsHidden(
 bool @hidden) {
var resp = await _target.SendRequest("Emulation.setScrollbarsHidden",
new SetScrollbarsHiddenParams {
Hidden=@hidden,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetDocumentCookieDisabledParams {
/// <summary>
/// Whether document.coookie API should be disabled.
/// </summary>
[JsonPropertyName("disabled")]public bool Disabled{get;set;}
}
/// <param name="disabled">Whether document.coookie API should be disabled.</param>
[Experimental]public async Task SetDocumentCookieDisabled(
 bool @disabled) {
var resp = await _target.SendRequest("Emulation.setDocumentCookieDisabled",
new SetDocumentCookieDisabledParams {
Disabled=@disabled,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetEmitTouchEventsForMouseParams {
/// <summary>
/// Whether touch emulation based on mouse input should be enabled.
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
/// <param name="enabled">Whether touch emulation based on mouse input should be enabled.</param>
/// <param name="configuration">Touch/gesture events configuration. Default: current platform.</param>
[Experimental]public async Task SetEmitTouchEventsForMouse(
 bool @enabled,SetEmitTouchEventsForMouseParams.ConfigurationEnum? @configuration=default) {
var resp = await _target.SendRequest("Emulation.setEmitTouchEventsForMouse",
new SetEmitTouchEventsForMouseParams {
Enabled=@enabled,Configuration=@configuration,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetEmulatedMediaParams {
/// <summary>
/// Media type to emulate. Empty string disables the override.
/// </summary>
[JsonPropertyName("media")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Media{get;set;}
/// <summary>
/// Media features to emulate.
/// </summary>
[JsonPropertyName("features")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Emulation.MediaFeature[]? Features{get;set;}
}
/// <summary>
/// Emulates the given media type or media feature for CSS media queries.
/// </summary>
/// <param name="media">Media type to emulate. Empty string disables the override.</param>
/// <param name="features">Media features to emulate.</param>
public async Task SetEmulatedMedia(
 string? @media=default,Emulation.MediaFeature[]? @features=default) {
var resp = await _target.SendRequest("Emulation.setEmulatedMedia",
new SetEmulatedMediaParams {
Media=@media,Features=@features,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetEmulatedVisionDeficiencyParams {
/// <summary>
/// Vision deficiency to emulate.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum TypeEnum {
[EnumMember(Value = "none")] None,
[EnumMember(Value = "achromatopsia")] Achromatopsia,
[EnumMember(Value = "blurredVision")] BlurredVision,
[EnumMember(Value = "deuteranopia")] Deuteranopia,
[EnumMember(Value = "protanopia")] Protanopia,
[EnumMember(Value = "tritanopia")] Tritanopia,
}
[JsonPropertyName("type")]public TypeEnum Type{get;set;}
}
/// <summary>
/// Emulates the given vision deficiency.
/// </summary>
/// <param name="type">Vision deficiency to emulate.</param>
[Experimental]public async Task SetEmulatedVisionDeficiency(
 SetEmulatedVisionDeficiencyParams.TypeEnum @type) {
var resp = await _target.SendRequest("Emulation.setEmulatedVisionDeficiency",
new SetEmulatedVisionDeficiencyParams {
Type=@type,});
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
public async Task SetGeolocationOverride(
 double? @latitude=default,double? @longitude=default,double? @accuracy=default) {
var resp = await _target.SendRequest("Emulation.setGeolocationOverride",
new SetGeolocationOverrideParams {
Latitude=@latitude,Longitude=@longitude,Accuracy=@accuracy,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetIdleOverrideParams {
/// <summary>
/// Mock isUserActive
/// </summary>
[JsonPropertyName("isUserActive")]public bool IsUserActive{get;set;}
/// <summary>
/// Mock isScreenUnlocked
/// </summary>
[JsonPropertyName("isScreenUnlocked")]public bool IsScreenUnlocked{get;set;}
}
/// <summary>
/// Overrides the Idle state.
/// </summary>
/// <param name="isUserActive">Mock isUserActive</param>
/// <param name="isScreenUnlocked">Mock isScreenUnlocked</param>
[Experimental]public async Task SetIdleOverride(
 bool @isUserActive,bool @isScreenUnlocked) {
var resp = await _target.SendRequest("Emulation.setIdleOverride",
new SetIdleOverrideParams {
IsUserActive=@isUserActive,IsScreenUnlocked=@isScreenUnlocked,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Clears Idle state overrides.
/// </summary>
[Experimental]public async Task ClearIdleOverride(
) {
var resp = await _target.SendRequest("Emulation.clearIdleOverride",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetNavigatorOverridesParams {
/// <summary>
/// The platform navigator.platform should return.
/// </summary>
[JsonPropertyName("platform")]public string Platform{get;set;}
}
/// <summary>
/// Overrides value returned by the javascript navigator object.
/// </summary>
/// <param name="platform">The platform navigator.platform should return.</param>
[Experimental][Obsolete]public async Task SetNavigatorOverrides(
 string @platform) {
var resp = await _target.SendRequest("Emulation.setNavigatorOverrides",
new SetNavigatorOverridesParams {
Platform=@platform,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetPageScaleFactorParams {
/// <summary>
/// Page scale factor.
/// </summary>
[JsonPropertyName("pageScaleFactor")]public double PageScaleFactor{get;set;}
}
/// <summary>
/// Sets a specified page scale factor.
/// </summary>
/// <param name="pageScaleFactor">Page scale factor.</param>
[Experimental]public async Task SetPageScaleFactor(
 double @pageScaleFactor) {
var resp = await _target.SendRequest("Emulation.setPageScaleFactor",
new SetPageScaleFactorParams {
PageScaleFactor=@pageScaleFactor,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetScriptExecutionDisabledParams {
/// <summary>
/// Whether script execution should be disabled in the page.
/// </summary>
[JsonPropertyName("value")]public bool Value{get;set;}
}
/// <summary>
/// Switches script execution in the page.
/// </summary>
/// <param name="value">Whether script execution should be disabled in the page.</param>
public async Task SetScriptExecutionDisabled(
 bool @value) {
var resp = await _target.SendRequest("Emulation.setScriptExecutionDisabled",
new SetScriptExecutionDisabledParams {
Value=@value,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetTouchEmulationEnabledParams {
/// <summary>
/// Whether the touch event emulation should be enabled.
/// </summary>
[JsonPropertyName("enabled")]public bool Enabled{get;set;}
/// <summary>
/// Maximum touch points supported. Defaults to one.
/// </summary>
[JsonPropertyName("maxTouchPoints")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? MaxTouchPoints{get;set;}
}
/// <summary>
/// Enables touch on platforms which do not support them.
/// </summary>
/// <param name="enabled">Whether the touch event emulation should be enabled.</param>
/// <param name="maxTouchPoints">Maximum touch points supported. Defaults to one.</param>
public async Task SetTouchEmulationEnabled(
 bool @enabled,long? @maxTouchPoints=default) {
var resp = await _target.SendRequest("Emulation.setTouchEmulationEnabled",
new SetTouchEmulationEnabledParams {
Enabled=@enabled,MaxTouchPoints=@maxTouchPoints,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetVirtualTimePolicyParams {
[JsonPropertyName("policy")]public Emulation.VirtualTimePolicy Policy{get;set;}
/// <summary>
/// If set, after this many virtual milliseconds have elapsed virtual time will be paused and a
/// virtualTimeBudgetExpired event is sent.
/// </summary>
[JsonPropertyName("budget")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Budget{get;set;}
/// <summary>
/// If set this specifies the maximum number of tasks that can be run before virtual is forced
/// forwards to prevent deadlock.
/// </summary>
[JsonPropertyName("maxVirtualTimeTaskStarvationCount")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? MaxVirtualTimeTaskStarvationCount{get;set;}
/// <summary>
/// If set, base::Time::Now will be overridden to initially return this value.
/// </summary>
[JsonPropertyName("initialVirtualTime")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.TimeSinceEpoch? InitialVirtualTime{get;set;}
}
public sealed partial class SetVirtualTimePolicyReturn {
/// <summary>
/// Absolute timestamp at which virtual time was first enabled (up time in milliseconds).
/// </summary>
[JsonPropertyName("virtualTimeTicksBase")]public double VirtualTimeTicksBase{get;set;}
}
/// <summary>
/// Turns on virtual time for all frames (replacing real-time with a synthetic time source) and sets
/// the current virtual time policy.  Note this supersedes any previous time budget.
/// </summary>
/// <param name="policy"></param>
/// <param name="budget">If set, after this many virtual milliseconds have elapsed virtual time will be paused and a
/// virtualTimeBudgetExpired event is sent.</param>
/// <param name="maxVirtualTimeTaskStarvationCount">If set this specifies the maximum number of tasks that can be run before virtual is forced
/// forwards to prevent deadlock.</param>
/// <param name="initialVirtualTime">If set, base::Time::Now will be overridden to initially return this value.</param>
[Experimental]public async Task<SetVirtualTimePolicyReturn> SetVirtualTimePolicy(
 Emulation.VirtualTimePolicy @policy,double? @budget=default,long? @maxVirtualTimeTaskStarvationCount=default,Network.TimeSinceEpoch? @initialVirtualTime=default) {
var resp = await _target.SendRequest("Emulation.setVirtualTimePolicy",
new SetVirtualTimePolicyParams {
Policy=@policy,Budget=@budget,MaxVirtualTimeTaskStarvationCount=@maxVirtualTimeTaskStarvationCount,InitialVirtualTime=@initialVirtualTime,});
return _target.DeserializeResponse<SetVirtualTimePolicyReturn>(resp);
}
public sealed partial class SetLocaleOverrideParams {
/// <summary>
/// ICU style C locale (e.g. "en_US"). If not specified or empty, disables the override and
/// restores default host system locale.
/// </summary>
[JsonPropertyName("locale")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Locale{get;set;}
}
/// <summary>
/// Overrides default host system locale with the specified one.
/// </summary>
/// <param name="locale">ICU style C locale (e.g. "en_US"). If not specified or empty, disables the override and
/// restores default host system locale.</param>
[Experimental]public async Task SetLocaleOverride(
 string? @locale=default) {
var resp = await _target.SendRequest("Emulation.setLocaleOverride",
new SetLocaleOverrideParams {
Locale=@locale,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetTimezoneOverrideParams {
/// <summary>
/// The timezone identifier. If empty, disables the override and
/// restores default host system timezone.
/// </summary>
[JsonPropertyName("timezoneId")]public string TimezoneId{get;set;}
}
/// <summary>
/// Overrides default host system timezone with the specified one.
/// </summary>
/// <param name="timezoneId">The timezone identifier. If empty, disables the override and
/// restores default host system timezone.</param>
[Experimental]public async Task SetTimezoneOverride(
 string @timezoneId) {
var resp = await _target.SendRequest("Emulation.setTimezoneOverride",
new SetTimezoneOverrideParams {
TimezoneId=@timezoneId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetVisibleSizeParams {
/// <summary>
/// Frame width (DIP).
/// </summary>
[JsonPropertyName("width")]public long Width{get;set;}
/// <summary>
/// Frame height (DIP).
/// </summary>
[JsonPropertyName("height")]public long Height{get;set;}
}
/// <summary>
/// Resizes the frame/viewport of the page. Note that this does not affect the frame's container
/// (e.g. browser window). Can be used to produce screenshots of the specified size. Not supported
/// on Android.
/// </summary>
/// <param name="width">Frame width (DIP).</param>
/// <param name="height">Frame height (DIP).</param>
[Experimental][Obsolete]public async Task SetVisibleSize(
 long @width,long @height) {
var resp = await _target.SendRequest("Emulation.setVisibleSize",
new SetVisibleSizeParams {
Width=@width,Height=@height,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetDisabledImageTypesParams {
/// <summary>
/// Image types to disable.
/// </summary>
[JsonPropertyName("imageTypes")]public Emulation.DisabledImageType[] ImageTypes{get;set;}
}
/// <param name="imageTypes">Image types to disable.</param>
[Experimental]public async Task SetDisabledImageTypes(
 Emulation.DisabledImageType[] @imageTypes) {
var resp = await _target.SendRequest("Emulation.setDisabledImageTypes",
new SetDisabledImageTypesParams {
ImageTypes=@imageTypes,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetUserAgentOverrideParams {
/// <summary>
/// User agent to use.
/// </summary>
[JsonPropertyName("userAgent")]public string UserAgent{get;set;}
/// <summary>
/// Browser langugage to emulate.
/// </summary>
[JsonPropertyName("acceptLanguage")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? AcceptLanguage{get;set;}
/// <summary>
/// The platform navigator.platform should return.
/// </summary>
[JsonPropertyName("platform")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Platform{get;set;}
/// <summary>
/// To be sent in Sec-CH-UA-* headers and returned in navigator.userAgentData
/// </summary>
[Experimental][JsonPropertyName("userAgentMetadata")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Emulation.UserAgentMetadata? UserAgentMetadata{get;set;}
}
/// <summary>
/// Allows overriding user agent with the given string.
/// </summary>
/// <param name="userAgent">User agent to use.</param>
/// <param name="acceptLanguage">Browser langugage to emulate.</param>
/// <param name="platform">The platform navigator.platform should return.</param>
/// <param name="userAgentMetadata">EXPERIMENTAL To be sent in Sec-CH-UA-* headers and returned in navigator.userAgentData</param>
public async Task SetUserAgentOverride(
 string @userAgent,string? @acceptLanguage=default,string? @platform=default,Emulation.UserAgentMetadata? @userAgentMetadata=default) {
var resp = await _target.SendRequest("Emulation.setUserAgentOverride",
new SetUserAgentOverrideParams {
UserAgent=@userAgent,AcceptLanguage=@acceptLanguage,Platform=@platform,UserAgentMetadata=@userAgentMetadata,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetAutomationOverrideParams {
/// <summary>
/// Whether the override should be enabled.
/// </summary>
[JsonPropertyName("enabled")]public bool Enabled{get;set;}
}
/// <summary>
/// Allows overriding the automation flag.
/// </summary>
/// <param name="enabled">Whether the override should be enabled.</param>
[Experimental]public async Task SetAutomationOverride(
 bool @enabled) {
var resp = await _target.SendRequest("Emulation.setAutomationOverride",
new SetAutomationOverrideParams {
Enabled=@enabled,});
_target.DeserializeResponse<VoidData>(resp);
}
private Action? _onVirtualTimeBudgetExpired;
/// <summary>
/// Notification sent after the virtual time budget for the current VirtualTimePolicy has run out.
/// </summary>
[Experimental]public event Action OnVirtualTimeBudgetExpired {
add => _onVirtualTimeBudgetExpired += value; remove => _onVirtualTimeBudgetExpired -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Emulation.virtualTimeBudgetExpired":
_onVirtualTimeBudgetExpired?.Invoke();
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
_onVirtualTimeBudgetExpired = null;
}
}
