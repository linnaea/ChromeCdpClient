using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// Network domain allows tracking network activities of the page. It exposes information about http,
/// file, data and other requests and responses, their headers, bodies, timing, etc.
/// </summary>
public sealed partial class NetworkDomain {
private readonly ConnectedTarget _target;
public NetworkDomain(ConnectedTarget target) => _target = target;
public sealed partial class SetAcceptedEncodingsParams {
/// <summary>
/// List of accepted content encodings.
/// </summary>
[JsonPropertyName("encodings")]public Network.ContentEncoding[] Encodings{get;set;}
}
/// <summary>
/// Sets a list of content encodings that will be accepted. Empty list means no encoding is accepted.
/// </summary>
/// <param name="encodings">List of accepted content encodings.</param>
[Experimental]public async Task SetAcceptedEncodings(
 Network.ContentEncoding[] @encodings) {
var resp = await _target.SendRequest("Network.setAcceptedEncodings",
new SetAcceptedEncodingsParams {
Encodings=@encodings,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Clears accepted encodings set by setAcceptedEncodings
/// </summary>
[Experimental]public async Task ClearAcceptedEncodingsOverride(
) {
var resp = await _target.SendRequest("Network.clearAcceptedEncodingsOverride",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class CanClearBrowserCacheReturn {
/// <summary>
/// True if browser cache can be cleared.
/// </summary>
[JsonPropertyName("result")]public bool Result{get;set;}
}
/// <summary>
/// Tells whether clearing browser cache is supported.
/// </summary>
[Obsolete]public async Task<CanClearBrowserCacheReturn> CanClearBrowserCache(
) {
var resp = await _target.SendRequest("Network.canClearBrowserCache",
VoidData.Instance);
return _target.DeserializeResponse<CanClearBrowserCacheReturn>(resp);
}
public sealed partial class CanClearBrowserCookiesReturn {
/// <summary>
/// True if browser cookies can be cleared.
/// </summary>
[JsonPropertyName("result")]public bool Result{get;set;}
}
/// <summary>
/// Tells whether clearing browser cookies is supported.
/// </summary>
[Obsolete]public async Task<CanClearBrowserCookiesReturn> CanClearBrowserCookies(
) {
var resp = await _target.SendRequest("Network.canClearBrowserCookies",
VoidData.Instance);
return _target.DeserializeResponse<CanClearBrowserCookiesReturn>(resp);
}
public sealed partial class CanEmulateNetworkConditionsReturn {
/// <summary>
/// True if emulation of network conditions is supported.
/// </summary>
[JsonPropertyName("result")]public bool Result{get;set;}
}
/// <summary>
/// Tells whether emulation of network conditions is supported.
/// </summary>
[Obsolete]public async Task<CanEmulateNetworkConditionsReturn> CanEmulateNetworkConditions(
) {
var resp = await _target.SendRequest("Network.canEmulateNetworkConditions",
VoidData.Instance);
return _target.DeserializeResponse<CanEmulateNetworkConditionsReturn>(resp);
}
/// <summary>
/// Clears browser cache.
/// </summary>
public async Task ClearBrowserCache(
) {
var resp = await _target.SendRequest("Network.clearBrowserCache",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Clears browser cookies.
/// </summary>
public async Task ClearBrowserCookies(
) {
var resp = await _target.SendRequest("Network.clearBrowserCookies",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class ContinueInterceptedRequestParams {
[JsonPropertyName("interceptionId")]public Network.InterceptionId InterceptionId{get;set;}
/// <summary>
/// If set this causes the request to fail with the given reason. Passing `Aborted` for requests
/// marked with `isNavigationRequest` also cancels the navigation. Must not be set in response
/// to an authChallenge.
/// </summary>
[JsonPropertyName("errorReason")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.ErrorReason? ErrorReason{get;set;}
/// <summary>
/// If set the requests completes using with the provided base64 encoded raw response, including
/// HTTP status line and headers etc... Must not be set in response to an authChallenge. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("rawResponse")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? RawResponse{get;set;}
/// <summary>
/// If set the request url will be modified in a way that's not observable by page. Must not be
/// set in response to an authChallenge.
/// </summary>
[JsonPropertyName("url")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Url{get;set;}
/// <summary>
/// If set this allows the request method to be overridden. Must not be set in response to an
/// authChallenge.
/// </summary>
[JsonPropertyName("method")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Method{get;set;}
/// <summary>
/// If set this allows postData to be set. Must not be set in response to an authChallenge.
/// </summary>
[JsonPropertyName("postData")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? PostData{get;set;}
/// <summary>
/// If set this allows the request headers to be changed. Must not be set in response to an
/// authChallenge.
/// </summary>
[JsonPropertyName("headers")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.Headers? Headers{get;set;}
/// <summary>
/// Response to a requestIntercepted with an authChallenge. Must not be set otherwise.
/// </summary>
[JsonPropertyName("authChallengeResponse")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.AuthChallengeResponse? AuthChallengeResponse{get;set;}
}
/// <summary>
/// Response to Network.requestIntercepted which either modifies the request to continue with any
/// modifications, or blocks it, or completes it with the provided response bytes. If a network
/// fetch occurs as a result which encounters a redirect an additional Network.requestIntercepted
/// event will be sent with the same InterceptionId.
/// Deprecated, use Fetch.continueRequest, Fetch.fulfillRequest and Fetch.failRequest instead.
/// </summary>
/// <param name="interceptionId"></param>
/// <param name="errorReason">If set this causes the request to fail with the given reason. Passing `Aborted` for requests
/// marked with `isNavigationRequest` also cancels the navigation. Must not be set in response
/// to an authChallenge.</param>
/// <param name="rawResponse">If set the requests completes using with the provided base64 encoded raw response, including
/// HTTP status line and headers etc... Must not be set in response to an authChallenge. (Encoded as a base64 string when passed over JSON)</param>
/// <param name="url">If set the request url will be modified in a way that's not observable by page. Must not be
/// set in response to an authChallenge.</param>
/// <param name="method">If set this allows the request method to be overridden. Must not be set in response to an
/// authChallenge.</param>
/// <param name="postData">If set this allows postData to be set. Must not be set in response to an authChallenge.</param>
/// <param name="headers">If set this allows the request headers to be changed. Must not be set in response to an
/// authChallenge.</param>
/// <param name="authChallengeResponse">Response to a requestIntercepted with an authChallenge. Must not be set otherwise.</param>
[Experimental][Obsolete]public async Task ContinueInterceptedRequest(
 Network.InterceptionId @interceptionId,Network.ErrorReason? @errorReason=default,string? @rawResponse=default,string? @url=default,string? @method=default,string? @postData=default,Network.Headers? @headers=default,Network.AuthChallengeResponse? @authChallengeResponse=default) {
var resp = await _target.SendRequest("Network.continueInterceptedRequest",
new ContinueInterceptedRequestParams {
InterceptionId=@interceptionId,ErrorReason=@errorReason,RawResponse=@rawResponse,Url=@url,Method=@method,PostData=@postData,Headers=@headers,AuthChallengeResponse=@authChallengeResponse,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class DeleteCookiesParams {
/// <summary>
/// Name of the cookies to remove.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// If specified, deletes all the cookies with the given name where domain and path match
/// provided URL.
/// </summary>
[JsonPropertyName("url")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Url{get;set;}
/// <summary>
/// If specified, deletes only cookies with the exact domain.
/// </summary>
[JsonPropertyName("domain")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Domain{get;set;}
/// <summary>
/// If specified, deletes only cookies with the exact path.
/// </summary>
[JsonPropertyName("path")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Path{get;set;}
}
/// <summary>
/// Deletes browser cookies with matching name and url or domain/path pair.
/// </summary>
/// <param name="name">Name of the cookies to remove.</param>
/// <param name="url">If specified, deletes all the cookies with the given name where domain and path match
/// provided URL.</param>
/// <param name="domain">If specified, deletes only cookies with the exact domain.</param>
/// <param name="path">If specified, deletes only cookies with the exact path.</param>
public async Task DeleteCookies(
 string @name,string? @url=default,string? @domain=default,string? @path=default) {
var resp = await _target.SendRequest("Network.deleteCookies",
new DeleteCookiesParams {
Name=@name,Url=@url,Domain=@domain,Path=@path,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Disables network tracking, prevents network events from being sent to the client.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("Network.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class EmulateNetworkConditionsParams {
/// <summary>
/// True to emulate internet disconnection.
/// </summary>
[JsonPropertyName("offline")]public bool Offline{get;set;}
/// <summary>
/// Minimum latency from request sent to response headers received (ms).
/// </summary>
[JsonPropertyName("latency")]public double Latency{get;set;}
/// <summary>
/// Maximal aggregated download throughput (bytes/sec). -1 disables download throttling.
/// </summary>
[JsonPropertyName("downloadThroughput")]public double DownloadThroughput{get;set;}
/// <summary>
/// Maximal aggregated upload throughput (bytes/sec).  -1 disables upload throttling.
/// </summary>
[JsonPropertyName("uploadThroughput")]public double UploadThroughput{get;set;}
/// <summary>
/// Connection type if known.
/// </summary>
[JsonPropertyName("connectionType")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.ConnectionType? ConnectionType{get;set;}
}
/// <summary>
/// Activates emulation of network conditions.
/// </summary>
/// <param name="offline">True to emulate internet disconnection.</param>
/// <param name="latency">Minimum latency from request sent to response headers received (ms).</param>
/// <param name="downloadThroughput">Maximal aggregated download throughput (bytes/sec). -1 disables download throttling.</param>
/// <param name="uploadThroughput">Maximal aggregated upload throughput (bytes/sec).  -1 disables upload throttling.</param>
/// <param name="connectionType">Connection type if known.</param>
public async Task EmulateNetworkConditions(
 bool @offline,double @latency,double @downloadThroughput,double @uploadThroughput,Network.ConnectionType? @connectionType=default) {
var resp = await _target.SendRequest("Network.emulateNetworkConditions",
new EmulateNetworkConditionsParams {
Offline=@offline,Latency=@latency,DownloadThroughput=@downloadThroughput,UploadThroughput=@uploadThroughput,ConnectionType=@connectionType,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class EnableParams {
/// <summary>
/// Buffer size in bytes to use when preserving network payloads (XHRs, etc).
/// </summary>
[Experimental][JsonPropertyName("maxTotalBufferSize")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? MaxTotalBufferSize{get;set;}
/// <summary>
/// Per-resource buffer size in bytes to use when preserving network payloads (XHRs, etc).
/// </summary>
[Experimental][JsonPropertyName("maxResourceBufferSize")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? MaxResourceBufferSize{get;set;}
/// <summary>
/// Longest post body size (in bytes) that would be included in requestWillBeSent notification
/// </summary>
[JsonPropertyName("maxPostDataSize")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? MaxPostDataSize{get;set;}
}
/// <summary>
/// Enables network tracking, network events will now be delivered to the client.
/// </summary>
/// <param name="maxTotalBufferSize">EXPERIMENTAL Buffer size in bytes to use when preserving network payloads (XHRs, etc).</param>
/// <param name="maxResourceBufferSize">EXPERIMENTAL Per-resource buffer size in bytes to use when preserving network payloads (XHRs, etc).</param>
/// <param name="maxPostDataSize">Longest post body size (in bytes) that would be included in requestWillBeSent notification</param>
public async Task Enable(
 long? @maxTotalBufferSize=default,long? @maxResourceBufferSize=default,long? @maxPostDataSize=default) {
var resp = await _target.SendRequest("Network.enable",
new EnableParams {
MaxTotalBufferSize=@maxTotalBufferSize,MaxResourceBufferSize=@maxResourceBufferSize,MaxPostDataSize=@maxPostDataSize,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetAllCookiesReturn {
/// <summary>
/// Array of cookie objects.
/// </summary>
[JsonPropertyName("cookies")]public Network.Cookie[] Cookies{get;set;}
}
/// <summary>
/// Returns all browser cookies. Depending on the backend support, will return detailed cookie
/// information in the `cookies` field.
/// </summary>
public async Task<GetAllCookiesReturn> GetAllCookies(
) {
var resp = await _target.SendRequest("Network.getAllCookies",
VoidData.Instance);
return _target.DeserializeResponse<GetAllCookiesReturn>(resp);
}
public sealed partial class GetCertificateParams {
/// <summary>
/// Origin to get certificate for.
/// </summary>
[JsonPropertyName("origin")]public string Origin{get;set;}
}
public sealed partial class GetCertificateReturn {
[JsonPropertyName("tableNames")]public string[] TableNames{get;set;}
}
/// <summary>
/// Returns the DER-encoded certificate.
/// </summary>
/// <param name="origin">Origin to get certificate for.</param>
[Experimental]public async Task<GetCertificateReturn> GetCertificate(
 string @origin) {
var resp = await _target.SendRequest("Network.getCertificate",
new GetCertificateParams {
Origin=@origin,});
return _target.DeserializeResponse<GetCertificateReturn>(resp);
}
public sealed partial class GetCookiesParams {
/// <summary>
/// The list of URLs for which applicable cookies will be fetched.
/// If not specified, it's assumed to be set to the list containing
/// the URLs of the page and all of its subframes.
/// </summary>
[JsonPropertyName("urls")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string[]? Urls{get;set;}
}
public sealed partial class GetCookiesReturn {
/// <summary>
/// Array of cookie objects.
/// </summary>
[JsonPropertyName("cookies")]public Network.Cookie[] Cookies{get;set;}
}
/// <summary>
/// Returns all browser cookies for the current URL. Depending on the backend support, will return
/// detailed cookie information in the `cookies` field.
/// </summary>
/// <param name="urls">The list of URLs for which applicable cookies will be fetched.
/// If not specified, it's assumed to be set to the list containing
/// the URLs of the page and all of its subframes.</param>
public async Task<GetCookiesReturn> GetCookies(
 string[]? @urls=default) {
var resp = await _target.SendRequest("Network.getCookies",
new GetCookiesParams {
Urls=@urls,});
return _target.DeserializeResponse<GetCookiesReturn>(resp);
}
public sealed partial class GetResponseBodyParams {
/// <summary>
/// Identifier of the network request to get content for.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
}
public sealed partial class GetResponseBodyReturn {
/// <summary>
/// Response body.
/// </summary>
[JsonPropertyName("body")]public string Body{get;set;}
/// <summary>
/// True, if content was sent as base64.
/// </summary>
[JsonPropertyName("base64Encoded")]public bool Base64Encoded{get;set;}
}
/// <summary>
/// Returns content served for the given request.
/// </summary>
/// <param name="requestId">Identifier of the network request to get content for.</param>
public async Task<GetResponseBodyReturn> GetResponseBody(
 Network.RequestId @requestId) {
var resp = await _target.SendRequest("Network.getResponseBody",
new GetResponseBodyParams {
RequestId=@requestId,});
return _target.DeserializeResponse<GetResponseBodyReturn>(resp);
}
public sealed partial class GetRequestPostDataParams {
/// <summary>
/// Identifier of the network request to get content for.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
}
public sealed partial class GetRequestPostDataReturn {
/// <summary>
/// Request body string, omitting files from multipart requests
/// </summary>
[JsonPropertyName("postData")]public string PostData{get;set;}
}
/// <summary>
/// Returns post data sent with the request. Returns an error when no data was sent with the request.
/// </summary>
/// <param name="requestId">Identifier of the network request to get content for.</param>
public async Task<GetRequestPostDataReturn> GetRequestPostData(
 Network.RequestId @requestId) {
var resp = await _target.SendRequest("Network.getRequestPostData",
new GetRequestPostDataParams {
RequestId=@requestId,});
return _target.DeserializeResponse<GetRequestPostDataReturn>(resp);
}
public sealed partial class GetResponseBodyForInterceptionParams {
/// <summary>
/// Identifier for the intercepted request to get body for.
/// </summary>
[JsonPropertyName("interceptionId")]public Network.InterceptionId InterceptionId{get;set;}
}
public sealed partial class GetResponseBodyForInterceptionReturn {
/// <summary>
/// Response body.
/// </summary>
[JsonPropertyName("body")]public string Body{get;set;}
/// <summary>
/// True, if content was sent as base64.
/// </summary>
[JsonPropertyName("base64Encoded")]public bool Base64Encoded{get;set;}
}
/// <summary>
/// Returns content served for the given currently intercepted request.
/// </summary>
/// <param name="interceptionId">Identifier for the intercepted request to get body for.</param>
[Experimental]public async Task<GetResponseBodyForInterceptionReturn> GetResponseBodyForInterception(
 Network.InterceptionId @interceptionId) {
var resp = await _target.SendRequest("Network.getResponseBodyForInterception",
new GetResponseBodyForInterceptionParams {
InterceptionId=@interceptionId,});
return _target.DeserializeResponse<GetResponseBodyForInterceptionReturn>(resp);
}
public sealed partial class TakeResponseBodyForInterceptionAsStreamParams {
[JsonPropertyName("interceptionId")]public Network.InterceptionId InterceptionId{get;set;}
}
public sealed partial class TakeResponseBodyForInterceptionAsStreamReturn {
[JsonPropertyName("stream")]public IO.StreamHandle Stream{get;set;}
}
/// <summary>
/// Returns a handle to the stream representing the response body. Note that after this command,
/// the intercepted request can't be continued as is -- you either need to cancel it or to provide
/// the response body. The stream only supports sequential read, IO.read will fail if the position
/// is specified.
/// </summary>
/// <param name="interceptionId"></param>
[Experimental]public async Task<TakeResponseBodyForInterceptionAsStreamReturn> TakeResponseBodyForInterceptionAsStream(
 Network.InterceptionId @interceptionId) {
var resp = await _target.SendRequest("Network.takeResponseBodyForInterceptionAsStream",
new TakeResponseBodyForInterceptionAsStreamParams {
InterceptionId=@interceptionId,});
return _target.DeserializeResponse<TakeResponseBodyForInterceptionAsStreamReturn>(resp);
}
public sealed partial class ReplayXHRParams {
/// <summary>
/// Identifier of XHR to replay.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
}
/// <summary>
/// This method sends a new XMLHttpRequest which is identical to the original one. The following
/// parameters should be identical: method, url, async, request body, extra headers, withCredentials
/// attribute, user, password.
/// </summary>
/// <param name="requestId">Identifier of XHR to replay.</param>
[Experimental]public async Task ReplayXHR(
 Network.RequestId @requestId) {
var resp = await _target.SendRequest("Network.replayXHR",
new ReplayXHRParams {
RequestId=@requestId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SearchInResponseBodyParams {
/// <summary>
/// Identifier of the network response to search.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
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
public sealed partial class SearchInResponseBodyReturn {
/// <summary>
/// List of search matches.
/// </summary>
[JsonPropertyName("result")]public Debugger.SearchMatch[] Result{get;set;}
}
/// <summary>
/// Searches for given string in response content.
/// </summary>
/// <param name="requestId">Identifier of the network response to search.</param>
/// <param name="query">String to search for.</param>
/// <param name="caseSensitive">If true, search is case sensitive.</param>
/// <param name="isRegex">If true, treats string parameter as regex.</param>
[Experimental]public async Task<SearchInResponseBodyReturn> SearchInResponseBody(
 Network.RequestId @requestId,string @query,bool? @caseSensitive=default,bool? @isRegex=default) {
var resp = await _target.SendRequest("Network.searchInResponseBody",
new SearchInResponseBodyParams {
RequestId=@requestId,Query=@query,CaseSensitive=@caseSensitive,IsRegex=@isRegex,});
return _target.DeserializeResponse<SearchInResponseBodyReturn>(resp);
}
public sealed partial class SetBlockedURLsParams {
/// <summary>
/// URL patterns to block. Wildcards ('*') are allowed.
/// </summary>
[JsonPropertyName("urls")]public string[] Urls{get;set;}
}
/// <summary>
/// Blocks URLs from loading.
/// </summary>
/// <param name="urls">URL patterns to block. Wildcards ('*') are allowed.</param>
[Experimental]public async Task SetBlockedURLs(
 string[] @urls) {
var resp = await _target.SendRequest("Network.setBlockedURLs",
new SetBlockedURLsParams {
Urls=@urls,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetBypassServiceWorkerParams {
/// <summary>
/// Bypass service worker and load from network.
/// </summary>
[JsonPropertyName("bypass")]public bool Bypass{get;set;}
}
/// <summary>
/// Toggles ignoring of service worker for each request.
/// </summary>
/// <param name="bypass">Bypass service worker and load from network.</param>
[Experimental]public async Task SetBypassServiceWorker(
 bool @bypass) {
var resp = await _target.SendRequest("Network.setBypassServiceWorker",
new SetBypassServiceWorkerParams {
Bypass=@bypass,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetCacheDisabledParams {
/// <summary>
/// Cache disabled state.
/// </summary>
[JsonPropertyName("cacheDisabled")]public bool CacheDisabled{get;set;}
}
/// <summary>
/// Toggles ignoring cache for each request. If `true`, cache will not be used.
/// </summary>
/// <param name="cacheDisabled">Cache disabled state.</param>
public async Task SetCacheDisabled(
 bool @cacheDisabled) {
var resp = await _target.SendRequest("Network.setCacheDisabled",
new SetCacheDisabledParams {
CacheDisabled=@cacheDisabled,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetCookieParams {
/// <summary>
/// Cookie name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Cookie value.
/// </summary>
[JsonPropertyName("value")]public string Value{get;set;}
/// <summary>
/// The request-URI to associate with the setting of the cookie. This value can affect the
/// default domain, path, source port, and source scheme values of the created cookie.
/// </summary>
[JsonPropertyName("url")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Url{get;set;}
/// <summary>
/// Cookie domain.
/// </summary>
[JsonPropertyName("domain")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Domain{get;set;}
/// <summary>
/// Cookie path.
/// </summary>
[JsonPropertyName("path")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Path{get;set;}
/// <summary>
/// True if cookie is secure.
/// </summary>
[JsonPropertyName("secure")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Secure{get;set;}
/// <summary>
/// True if cookie is http-only.
/// </summary>
[JsonPropertyName("httpOnly")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? HttpOnly{get;set;}
/// <summary>
/// Cookie SameSite type.
/// </summary>
[JsonPropertyName("sameSite")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.CookieSameSite? SameSite{get;set;}
/// <summary>
/// Cookie expiration date, session cookie if not set
/// </summary>
[JsonPropertyName("expires")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.TimeSinceEpoch? Expires{get;set;}
/// <summary>
/// Cookie Priority type.
/// </summary>
[Experimental][JsonPropertyName("priority")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.CookiePriority? Priority{get;set;}
/// <summary>
/// True if cookie is SameParty.
/// </summary>
[Experimental][JsonPropertyName("sameParty")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? SameParty{get;set;}
/// <summary>
/// Cookie source scheme type.
/// </summary>
[Experimental][JsonPropertyName("sourceScheme")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.CookieSourceScheme? SourceScheme{get;set;}
/// <summary>
/// Cookie source port. Valid values are {-1, [1, 65535]}, -1 indicates an unspecified port.
/// An unspecified port value allows protocol clients to emulate legacy cookie scope for the port.
/// This is a temporary ability and it will be removed in the future.
/// </summary>
[Experimental][JsonPropertyName("sourcePort")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? SourcePort{get;set;}
/// <summary>
/// Cookie partition key. The site of the top-level URL the browser was visiting at the start
/// of the request to the endpoint that set the cookie.
/// If not set, the cookie will be set as not partitioned.
/// </summary>
[Experimental][JsonPropertyName("partitionKey")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? PartitionKey{get;set;}
}
public sealed partial class SetCookieReturn {
/// <summary>
/// Always set to true. If an error occurs, the response indicates protocol error.
/// </summary>
[Obsolete][JsonPropertyName("success")]public bool Success{get;set;}
}
/// <summary>
/// Sets a cookie with the given cookie data; may overwrite equivalent cookies if they exist.
/// </summary>
/// <param name="name">Cookie name.</param>
/// <param name="value">Cookie value.</param>
/// <param name="url">The request-URI to associate with the setting of the cookie. This value can affect the
/// default domain, path, source port, and source scheme values of the created cookie.</param>
/// <param name="domain">Cookie domain.</param>
/// <param name="path">Cookie path.</param>
/// <param name="secure">True if cookie is secure.</param>
/// <param name="httpOnly">True if cookie is http-only.</param>
/// <param name="sameSite">Cookie SameSite type.</param>
/// <param name="expires">Cookie expiration date, session cookie if not set</param>
/// <param name="priority">EXPERIMENTAL Cookie Priority type.</param>
/// <param name="sameParty">EXPERIMENTAL True if cookie is SameParty.</param>
/// <param name="sourceScheme">EXPERIMENTAL Cookie source scheme type.</param>
/// <param name="sourcePort">EXPERIMENTAL Cookie source port. Valid values are {-1, [1, 65535]}, -1 indicates an unspecified port.
/// An unspecified port value allows protocol clients to emulate legacy cookie scope for the port.
/// This is a temporary ability and it will be removed in the future.</param>
/// <param name="partitionKey">EXPERIMENTAL Cookie partition key. The site of the top-level URL the browser was visiting at the start
/// of the request to the endpoint that set the cookie.
/// If not set, the cookie will be set as not partitioned.</param>
public async Task<SetCookieReturn> SetCookie(
 string @name,string @value,string? @url=default,string? @domain=default,string? @path=default,bool? @secure=default,bool? @httpOnly=default,Network.CookieSameSite? @sameSite=default,Network.TimeSinceEpoch? @expires=default,Network.CookiePriority? @priority=default,bool? @sameParty=default,Network.CookieSourceScheme? @sourceScheme=default,long? @sourcePort=default,string? @partitionKey=default) {
var resp = await _target.SendRequest("Network.setCookie",
new SetCookieParams {
Name=@name,Value=@value,Url=@url,Domain=@domain,Path=@path,Secure=@secure,HttpOnly=@httpOnly,SameSite=@sameSite,Expires=@expires,Priority=@priority,SameParty=@sameParty,SourceScheme=@sourceScheme,SourcePort=@sourcePort,PartitionKey=@partitionKey,});
return _target.DeserializeResponse<SetCookieReturn>(resp);
}
public sealed partial class SetCookiesParams {
/// <summary>
/// Cookies to be set.
/// </summary>
[JsonPropertyName("cookies")]public Network.CookieParam[] Cookies{get;set;}
}
/// <summary>
/// Sets given cookies.
/// </summary>
/// <param name="cookies">Cookies to be set.</param>
public async Task SetCookies(
 Network.CookieParam[] @cookies) {
var resp = await _target.SendRequest("Network.setCookies",
new SetCookiesParams {
Cookies=@cookies,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetExtraHTTPHeadersParams {
/// <summary>
/// Map with extra HTTP headers.
/// </summary>
[JsonPropertyName("headers")]public Network.Headers Headers{get;set;}
}
/// <summary>
/// Specifies whether to always send extra HTTP headers with the requests from this page.
/// </summary>
/// <param name="headers">Map with extra HTTP headers.</param>
public async Task SetExtraHTTPHeaders(
 Network.Headers @headers) {
var resp = await _target.SendRequest("Network.setExtraHTTPHeaders",
new SetExtraHTTPHeadersParams {
Headers=@headers,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetAttachDebugStackParams {
/// <summary>
/// Whether to attach a page script stack for debugging purpose.
/// </summary>
[JsonPropertyName("enabled")]public bool Enabled{get;set;}
}
/// <summary>
/// Specifies whether to attach a page script stack id in requests
/// </summary>
/// <param name="enabled">Whether to attach a page script stack for debugging purpose.</param>
[Experimental]public async Task SetAttachDebugStack(
 bool @enabled) {
var resp = await _target.SendRequest("Network.setAttachDebugStack",
new SetAttachDebugStackParams {
Enabled=@enabled,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetRequestInterceptionParams {
/// <summary>
/// Requests matching any of these patterns will be forwarded and wait for the corresponding
/// continueInterceptedRequest call.
/// </summary>
[JsonPropertyName("patterns")]public Network.RequestPattern[] Patterns{get;set;}
}
/// <summary>
/// Sets the requests to intercept that match the provided patterns and optionally resource types.
/// Deprecated, please use Fetch.enable instead.
/// </summary>
/// <param name="patterns">Requests matching any of these patterns will be forwarded and wait for the corresponding
/// continueInterceptedRequest call.</param>
[Experimental][Obsolete]public async Task SetRequestInterception(
 Network.RequestPattern[] @patterns) {
var resp = await _target.SendRequest("Network.setRequestInterception",
new SetRequestInterceptionParams {
Patterns=@patterns,});
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
var resp = await _target.SendRequest("Network.setUserAgentOverride",
new SetUserAgentOverrideParams {
UserAgent=@userAgent,AcceptLanguage=@acceptLanguage,Platform=@platform,UserAgentMetadata=@userAgentMetadata,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetSecurityIsolationStatusParams {
/// <summary>
/// If no frameId is provided, the status of the target is provided.
/// </summary>
[JsonPropertyName("frameId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.FrameId? FrameId{get;set;}
}
public sealed partial class GetSecurityIsolationStatusReturn {
[JsonPropertyName("status")]public Network.SecurityIsolationStatus Status{get;set;}
}
/// <summary>
/// Returns information about the COEP/COOP isolation status.
/// </summary>
/// <param name="frameId">If no frameId is provided, the status of the target is provided.</param>
[Experimental]public async Task<GetSecurityIsolationStatusReturn> GetSecurityIsolationStatus(
 Page.FrameId? @frameId=default) {
var resp = await _target.SendRequest("Network.getSecurityIsolationStatus",
new GetSecurityIsolationStatusParams {
FrameId=@frameId,});
return _target.DeserializeResponse<GetSecurityIsolationStatusReturn>(resp);
}
public sealed partial class EnableReportingApiParams {
/// <summary>
/// Whether to enable or disable events for the Reporting API
/// </summary>
[JsonPropertyName("enable")]public bool Enable{get;set;}
}
/// <summary>
/// Enables tracking for the Reporting API, events generated by the Reporting API will now be delivered to the client.
/// Enabling triggers 'reportingApiReportAdded' for all existing reports.
/// </summary>
/// <param name="enable">Whether to enable or disable events for the Reporting API</param>
[Experimental]public async Task EnableReportingApi(
 bool @enable) {
var resp = await _target.SendRequest("Network.enableReportingApi",
new EnableReportingApiParams {
Enable=@enable,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class LoadNetworkResourceParams {
/// <summary>
/// Frame id to get the resource for. Mandatory for frame targets, and
/// should be omitted for worker targets.
/// </summary>
[JsonPropertyName("frameId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.FrameId? FrameId{get;set;}
/// <summary>
/// URL of the resource to get content for.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Options for the request.
/// </summary>
[JsonPropertyName("options")]public Network.LoadNetworkResourceOptions Options{get;set;}
}
public sealed partial class LoadNetworkResourceReturn {
[JsonPropertyName("resource")]public Network.LoadNetworkResourcePageResult Resource{get;set;}
}
/// <summary>
/// Fetches the resource and returns the content.
/// </summary>
/// <param name="frameId">Frame id to get the resource for. Mandatory for frame targets, and
/// should be omitted for worker targets.</param>
/// <param name="url">URL of the resource to get content for.</param>
/// <param name="options">Options for the request.</param>
[Experimental]public async Task<LoadNetworkResourceReturn> LoadNetworkResource(
 string @url,Network.LoadNetworkResourceOptions @options,Page.FrameId? @frameId=default) {
var resp = await _target.SendRequest("Network.loadNetworkResource",
new LoadNetworkResourceParams {
FrameId=@frameId,Url=@url,Options=@options,});
return _target.DeserializeResponse<LoadNetworkResourceReturn>(resp);
}
public sealed partial class DataReceivedParams {
/// <summary>
/// Request identifier.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// Timestamp.
/// </summary>
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
/// <summary>
/// Data chunk length.
/// </summary>
[JsonPropertyName("dataLength")]public long DataLength{get;set;}
/// <summary>
/// Actual bytes received (might be less than dataLength for compressed encodings).
/// </summary>
[JsonPropertyName("encodedDataLength")]public long EncodedDataLength{get;set;}
}
private Action<DataReceivedParams>? _onDataReceived;
/// <summary>
/// Fired when data chunk was received over the network.
/// </summary>
public event Action<DataReceivedParams> OnDataReceived {
add => _onDataReceived += value; remove => _onDataReceived -= value;}
public sealed partial class EventSourceMessageReceivedParams {
/// <summary>
/// Request identifier.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// Timestamp.
/// </summary>
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
/// <summary>
/// Message type.
/// </summary>
[JsonPropertyName("eventName")]public string EventName{get;set;}
/// <summary>
/// Message identifier.
/// </summary>
[JsonPropertyName("eventId")]public string EventId{get;set;}
/// <summary>
/// Message content.
/// </summary>
[JsonPropertyName("data")]public string Data{get;set;}
}
private Action<EventSourceMessageReceivedParams>? _onEventSourceMessageReceived;
/// <summary>
/// Fired when EventSource message is received.
/// </summary>
public event Action<EventSourceMessageReceivedParams> OnEventSourceMessageReceived {
add => _onEventSourceMessageReceived += value; remove => _onEventSourceMessageReceived -= value;}
public sealed partial class LoadingFailedParams {
/// <summary>
/// Request identifier.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// Timestamp.
/// </summary>
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
/// <summary>
/// Resource type.
/// </summary>
[JsonPropertyName("type")]public Network.ResourceType Type{get;set;}
/// <summary>
/// User friendly error message.
/// </summary>
[JsonPropertyName("errorText")]public string ErrorText{get;set;}
/// <summary>
/// True if loading was canceled.
/// </summary>
[JsonPropertyName("canceled")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Canceled{get;set;}
/// <summary>
/// The reason why loading was blocked, if any.
/// </summary>
[JsonPropertyName("blockedReason")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.BlockedReason? BlockedReason{get;set;}
/// <summary>
/// The reason why loading was blocked by CORS, if any.
/// </summary>
[JsonPropertyName("corsErrorStatus")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.CorsErrorStatus? CorsErrorStatus{get;set;}
}
private Action<LoadingFailedParams>? _onLoadingFailed;
/// <summary>
/// Fired when HTTP request has failed to load.
/// </summary>
public event Action<LoadingFailedParams> OnLoadingFailed {
add => _onLoadingFailed += value; remove => _onLoadingFailed -= value;}
public sealed partial class LoadingFinishedParams {
/// <summary>
/// Request identifier.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// Timestamp.
/// </summary>
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
/// <summary>
/// Total number of bytes received for this request.
/// </summary>
[JsonPropertyName("encodedDataLength")]public double EncodedDataLength{get;set;}
/// <summary>
/// Set when 1) response was blocked by Cross-Origin Read Blocking and also
/// 2) this needs to be reported to the DevTools console.
/// </summary>
[JsonPropertyName("shouldReportCorbBlocking")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ShouldReportCorbBlocking{get;set;}
}
private Action<LoadingFinishedParams>? _onLoadingFinished;
/// <summary>
/// Fired when HTTP request has finished loading.
/// </summary>
public event Action<LoadingFinishedParams> OnLoadingFinished {
add => _onLoadingFinished += value; remove => _onLoadingFinished -= value;}
public sealed partial class RequestInterceptedParams {
/// <summary>
/// Each request the page makes will have a unique id, however if any redirects are encountered
/// while processing that fetch, they will be reported with the same id as the original fetch.
/// Likewise if HTTP authentication is needed then the same fetch id will be used.
/// </summary>
[JsonPropertyName("interceptionId")]public Network.InterceptionId InterceptionId{get;set;}
[JsonPropertyName("request")]public Network.Request Request{get;set;}
/// <summary>
/// The id of the frame that initiated the request.
/// </summary>
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
/// <summary>
/// How the requested resource will be used.
/// </summary>
[JsonPropertyName("resourceType")]public Network.ResourceType ResourceType{get;set;}
/// <summary>
/// Whether this is a navigation request, which can abort the navigation completely.
/// </summary>
[JsonPropertyName("isNavigationRequest")]public bool IsNavigationRequest{get;set;}
/// <summary>
/// Set if the request is a navigation that will result in a download.
/// Only present after response is received from the server (i.e. HeadersReceived stage).
/// </summary>
[JsonPropertyName("isDownload")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IsDownload{get;set;}
/// <summary>
/// Redirect location, only sent if a redirect was intercepted.
/// </summary>
[JsonPropertyName("redirectUrl")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? RedirectUrl{get;set;}
/// <summary>
/// Details of the Authorization Challenge encountered. If this is set then
/// continueInterceptedRequest must contain an authChallengeResponse.
/// </summary>
[JsonPropertyName("authChallenge")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.AuthChallenge? AuthChallenge{get;set;}
/// <summary>
/// Response error if intercepted at response stage or if redirect occurred while intercepting
/// request.
/// </summary>
[JsonPropertyName("responseErrorReason")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.ErrorReason? ResponseErrorReason{get;set;}
/// <summary>
/// Response code if intercepted at response stage or if redirect occurred while intercepting
/// request or auth retry occurred.
/// </summary>
[JsonPropertyName("responseStatusCode")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? ResponseStatusCode{get;set;}
/// <summary>
/// Response headers if intercepted at the response stage or if redirect occurred while
/// intercepting request or auth retry occurred.
/// </summary>
[JsonPropertyName("responseHeaders")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.Headers? ResponseHeaders{get;set;}
/// <summary>
/// If the intercepted request had a corresponding requestWillBeSent event fired for it, then
/// this requestId will be the same as the requestId present in the requestWillBeSent event.
/// </summary>
[JsonPropertyName("requestId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.RequestId? RequestId{get;set;}
}
private Action<RequestInterceptedParams>? _onRequestIntercepted;
/// <summary>
/// Details of an intercepted HTTP request, which must be either allowed, blocked, modified or
/// mocked.
/// Deprecated, use Fetch.requestPaused instead.
/// </summary>
[Experimental][Obsolete]public event Action<RequestInterceptedParams> OnRequestIntercepted {
add => _onRequestIntercepted += value; remove => _onRequestIntercepted -= value;}
public sealed partial class RequestServedFromCacheParams {
/// <summary>
/// Request identifier.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
}
private Action<RequestServedFromCacheParams>? _onRequestServedFromCache;
/// <summary>
/// Fired if request ended up loading from cache.
/// </summary>
public event Action<RequestServedFromCacheParams> OnRequestServedFromCache {
add => _onRequestServedFromCache += value; remove => _onRequestServedFromCache -= value;}
public sealed partial class RequestWillBeSentParams {
/// <summary>
/// Request identifier.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// Loader identifier. Empty string if the request is fetched from worker.
/// </summary>
[JsonPropertyName("loaderId")]public Network.LoaderId LoaderId{get;set;}
/// <summary>
/// URL of the document this request is loaded for.
/// </summary>
[JsonPropertyName("documentURL")]public string DocumentURL{get;set;}
/// <summary>
/// Request data.
/// </summary>
[JsonPropertyName("request")]public Network.Request Request{get;set;}
/// <summary>
/// Timestamp.
/// </summary>
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
/// <summary>
/// Timestamp.
/// </summary>
[JsonPropertyName("wallTime")]public Network.TimeSinceEpoch WallTime{get;set;}
/// <summary>
/// Request initiator.
/// </summary>
[JsonPropertyName("initiator")]public Network.Initiator Initiator{get;set;}
/// <summary>
/// In the case that redirectResponse is populated, this flag indicates whether
/// requestWillBeSentExtraInfo and responseReceivedExtraInfo events will be or were emitted
/// for the request which was just redirected.
/// </summary>
[Experimental][JsonPropertyName("redirectHasExtraInfo")]public bool RedirectHasExtraInfo{get;set;}
/// <summary>
/// Redirect response data.
/// </summary>
[JsonPropertyName("redirectResponse")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.Response? RedirectResponse{get;set;}
/// <summary>
/// Type of this resource.
/// </summary>
[JsonPropertyName("type")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.ResourceType? Type{get;set;}
/// <summary>
/// Frame identifier.
/// </summary>
[JsonPropertyName("frameId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.FrameId? FrameId{get;set;}
/// <summary>
/// Whether the request is initiated by a user gesture. Defaults to false.
/// </summary>
[JsonPropertyName("hasUserGesture")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? HasUserGesture{get;set;}
}
private Action<RequestWillBeSentParams>? _onRequestWillBeSent;
/// <summary>
/// Fired when page is about to send HTTP request.
/// </summary>
public event Action<RequestWillBeSentParams> OnRequestWillBeSent {
add => _onRequestWillBeSent += value; remove => _onRequestWillBeSent -= value;}
public sealed partial class ResourceChangedPriorityParams {
/// <summary>
/// Request identifier.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// New priority
/// </summary>
[JsonPropertyName("newPriority")]public Network.ResourcePriority NewPriority{get;set;}
/// <summary>
/// Timestamp.
/// </summary>
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
}
private Action<ResourceChangedPriorityParams>? _onResourceChangedPriority;
/// <summary>
/// Fired when resource loading priority is changed
/// </summary>
[Experimental]public event Action<ResourceChangedPriorityParams> OnResourceChangedPriority {
add => _onResourceChangedPriority += value; remove => _onResourceChangedPriority -= value;}
public sealed partial class SignedExchangeReceivedParams {
/// <summary>
/// Request identifier.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// Information about the signed exchange response.
/// </summary>
[JsonPropertyName("info")]public Network.SignedExchangeInfo Info{get;set;}
}
private Action<SignedExchangeReceivedParams>? _onSignedExchangeReceived;
/// <summary>
/// Fired when a signed exchange was received over the network
/// </summary>
[Experimental]public event Action<SignedExchangeReceivedParams> OnSignedExchangeReceived {
add => _onSignedExchangeReceived += value; remove => _onSignedExchangeReceived -= value;}
public sealed partial class ResponseReceivedParams {
/// <summary>
/// Request identifier.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// Loader identifier. Empty string if the request is fetched from worker.
/// </summary>
[JsonPropertyName("loaderId")]public Network.LoaderId LoaderId{get;set;}
/// <summary>
/// Timestamp.
/// </summary>
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
/// <summary>
/// Resource type.
/// </summary>
[JsonPropertyName("type")]public Network.ResourceType Type{get;set;}
/// <summary>
/// Response data.
/// </summary>
[JsonPropertyName("response")]public Network.Response Response{get;set;}
/// <summary>
/// Indicates whether requestWillBeSentExtraInfo and responseReceivedExtraInfo events will be
/// or were emitted for this request.
/// </summary>
[Experimental][JsonPropertyName("hasExtraInfo")]public bool HasExtraInfo{get;set;}
/// <summary>
/// Frame identifier.
/// </summary>
[JsonPropertyName("frameId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.FrameId? FrameId{get;set;}
}
private Action<ResponseReceivedParams>? _onResponseReceived;
/// <summary>
/// Fired when HTTP response is available.
/// </summary>
public event Action<ResponseReceivedParams> OnResponseReceived {
add => _onResponseReceived += value; remove => _onResponseReceived -= value;}
public sealed partial class WebSocketClosedParams {
/// <summary>
/// Request identifier.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// Timestamp.
/// </summary>
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
}
private Action<WebSocketClosedParams>? _onWebSocketClosed;
/// <summary>
/// Fired when WebSocket is closed.
/// </summary>
public event Action<WebSocketClosedParams> OnWebSocketClosed {
add => _onWebSocketClosed += value; remove => _onWebSocketClosed -= value;}
public sealed partial class WebSocketCreatedParams {
/// <summary>
/// Request identifier.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// WebSocket request URL.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Request initiator.
/// </summary>
[JsonPropertyName("initiator")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.Initiator? Initiator{get;set;}
}
private Action<WebSocketCreatedParams>? _onWebSocketCreated;
/// <summary>
/// Fired upon WebSocket creation.
/// </summary>
public event Action<WebSocketCreatedParams> OnWebSocketCreated {
add => _onWebSocketCreated += value; remove => _onWebSocketCreated -= value;}
public sealed partial class WebSocketFrameErrorParams {
/// <summary>
/// Request identifier.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// Timestamp.
/// </summary>
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
/// <summary>
/// WebSocket error message.
/// </summary>
[JsonPropertyName("errorMessage")]public string ErrorMessage{get;set;}
}
private Action<WebSocketFrameErrorParams>? _onWebSocketFrameError;
/// <summary>
/// Fired when WebSocket message error occurs.
/// </summary>
public event Action<WebSocketFrameErrorParams> OnWebSocketFrameError {
add => _onWebSocketFrameError += value; remove => _onWebSocketFrameError -= value;}
public sealed partial class WebSocketFrameReceivedParams {
/// <summary>
/// Request identifier.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// Timestamp.
/// </summary>
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
/// <summary>
/// WebSocket response data.
/// </summary>
[JsonPropertyName("response")]public Network.WebSocketFrame Response{get;set;}
}
private Action<WebSocketFrameReceivedParams>? _onWebSocketFrameReceived;
/// <summary>
/// Fired when WebSocket message is received.
/// </summary>
public event Action<WebSocketFrameReceivedParams> OnWebSocketFrameReceived {
add => _onWebSocketFrameReceived += value; remove => _onWebSocketFrameReceived -= value;}
public sealed partial class WebSocketFrameSentParams {
/// <summary>
/// Request identifier.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// Timestamp.
/// </summary>
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
/// <summary>
/// WebSocket response data.
/// </summary>
[JsonPropertyName("response")]public Network.WebSocketFrame Response{get;set;}
}
private Action<WebSocketFrameSentParams>? _onWebSocketFrameSent;
/// <summary>
/// Fired when WebSocket message is sent.
/// </summary>
public event Action<WebSocketFrameSentParams> OnWebSocketFrameSent {
add => _onWebSocketFrameSent += value; remove => _onWebSocketFrameSent -= value;}
public sealed partial class WebSocketHandshakeResponseReceivedParams {
/// <summary>
/// Request identifier.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// Timestamp.
/// </summary>
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
/// <summary>
/// WebSocket response data.
/// </summary>
[JsonPropertyName("response")]public Network.WebSocketResponse Response{get;set;}
}
private Action<WebSocketHandshakeResponseReceivedParams>? _onWebSocketHandshakeResponseReceived;
/// <summary>
/// Fired when WebSocket handshake response becomes available.
/// </summary>
public event Action<WebSocketHandshakeResponseReceivedParams> OnWebSocketHandshakeResponseReceived {
add => _onWebSocketHandshakeResponseReceived += value; remove => _onWebSocketHandshakeResponseReceived -= value;}
public sealed partial class WebSocketWillSendHandshakeRequestParams {
/// <summary>
/// Request identifier.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// Timestamp.
/// </summary>
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
/// <summary>
/// UTC Timestamp.
/// </summary>
[JsonPropertyName("wallTime")]public Network.TimeSinceEpoch WallTime{get;set;}
/// <summary>
/// WebSocket request data.
/// </summary>
[JsonPropertyName("request")]public Network.WebSocketRequest Request{get;set;}
}
private Action<WebSocketWillSendHandshakeRequestParams>? _onWebSocketWillSendHandshakeRequest;
/// <summary>
/// Fired when WebSocket is about to initiate handshake.
/// </summary>
public event Action<WebSocketWillSendHandshakeRequestParams> OnWebSocketWillSendHandshakeRequest {
add => _onWebSocketWillSendHandshakeRequest += value; remove => _onWebSocketWillSendHandshakeRequest -= value;}
public sealed partial class WebTransportCreatedParams {
/// <summary>
/// WebTransport identifier.
/// </summary>
[JsonPropertyName("transportId")]public Network.RequestId TransportId{get;set;}
/// <summary>
/// WebTransport request URL.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Timestamp.
/// </summary>
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
/// <summary>
/// Request initiator.
/// </summary>
[JsonPropertyName("initiator")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.Initiator? Initiator{get;set;}
}
private Action<WebTransportCreatedParams>? _onWebTransportCreated;
/// <summary>
/// Fired upon WebTransport creation.
/// </summary>
public event Action<WebTransportCreatedParams> OnWebTransportCreated {
add => _onWebTransportCreated += value; remove => _onWebTransportCreated -= value;}
public sealed partial class WebTransportConnectionEstablishedParams {
/// <summary>
/// WebTransport identifier.
/// </summary>
[JsonPropertyName("transportId")]public Network.RequestId TransportId{get;set;}
/// <summary>
/// Timestamp.
/// </summary>
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
}
private Action<WebTransportConnectionEstablishedParams>? _onWebTransportConnectionEstablished;
/// <summary>
/// Fired when WebTransport handshake is finished.
/// </summary>
public event Action<WebTransportConnectionEstablishedParams> OnWebTransportConnectionEstablished {
add => _onWebTransportConnectionEstablished += value; remove => _onWebTransportConnectionEstablished -= value;}
public sealed partial class WebTransportClosedParams {
/// <summary>
/// WebTransport identifier.
/// </summary>
[JsonPropertyName("transportId")]public Network.RequestId TransportId{get;set;}
/// <summary>
/// Timestamp.
/// </summary>
[JsonPropertyName("timestamp")]public Network.MonotonicTime Timestamp{get;set;}
}
private Action<WebTransportClosedParams>? _onWebTransportClosed;
/// <summary>
/// Fired when WebTransport is disposed.
/// </summary>
public event Action<WebTransportClosedParams> OnWebTransportClosed {
add => _onWebTransportClosed += value; remove => _onWebTransportClosed -= value;}
public sealed partial class RequestWillBeSentExtraInfoParams {
/// <summary>
/// Request identifier. Used to match this information to an existing requestWillBeSent event.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// A list of cookies potentially associated to the requested URL. This includes both cookies sent with
/// the request and the ones not sent; the latter are distinguished by having blockedReason field set.
/// </summary>
[JsonPropertyName("associatedCookies")]public Network.BlockedCookieWithReason[] AssociatedCookies{get;set;}
/// <summary>
/// Raw request headers as they will be sent over the wire.
/// </summary>
[JsonPropertyName("headers")]public Network.Headers Headers{get;set;}
/// <summary>
/// Connection timing information for the request.
/// </summary>
[Experimental][JsonPropertyName("connectTiming")]public Network.ConnectTiming ConnectTiming{get;set;}
/// <summary>
/// The client security state set for the request.
/// </summary>
[JsonPropertyName("clientSecurityState")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.ClientSecurityState? ClientSecurityState{get;set;}
}
private Action<RequestWillBeSentExtraInfoParams>? _onRequestWillBeSentExtraInfo;
/// <summary>
/// Fired when additional information about a requestWillBeSent event is available from the
/// network stack. Not every requestWillBeSent event will have an additional
/// requestWillBeSentExtraInfo fired for it, and there is no guarantee whether requestWillBeSent
/// or requestWillBeSentExtraInfo will be fired first for the same request.
/// </summary>
[Experimental]public event Action<RequestWillBeSentExtraInfoParams> OnRequestWillBeSentExtraInfo {
add => _onRequestWillBeSentExtraInfo += value; remove => _onRequestWillBeSentExtraInfo -= value;}
public sealed partial class ResponseReceivedExtraInfoParams {
/// <summary>
/// Request identifier. Used to match this information to another responseReceived event.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// A list of cookies which were not stored from the response along with the corresponding
/// reasons for blocking. The cookies here may not be valid due to syntax errors, which
/// are represented by the invalid cookie line string instead of a proper cookie.
/// </summary>
[JsonPropertyName("blockedCookies")]public Network.BlockedSetCookieWithReason[] BlockedCookies{get;set;}
/// <summary>
/// Raw response headers as they were received over the wire.
/// </summary>
[JsonPropertyName("headers")]public Network.Headers Headers{get;set;}
/// <summary>
/// The IP address space of the resource. The address space can only be determined once the transport
/// established the connection, so we can't send it in `requestWillBeSentExtraInfo`.
/// </summary>
[JsonPropertyName("resourceIPAddressSpace")]public Network.IPAddressSpace ResourceIPAddressSpace{get;set;}
/// <summary>
/// The status code of the response. This is useful in cases the request failed and no responseReceived
/// event is triggered, which is the case for, e.g., CORS errors. This is also the correct status code
/// for cached requests, where the status in responseReceived is a 200 and this will be 304.
/// </summary>
[JsonPropertyName("statusCode")]public long StatusCode{get;set;}
/// <summary>
/// Raw response header text as it was received over the wire. The raw text may not always be
/// available, such as in the case of HTTP/2 or QUIC.
/// </summary>
[JsonPropertyName("headersText")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? HeadersText{get;set;}
}
private Action<ResponseReceivedExtraInfoParams>? _onResponseReceivedExtraInfo;
/// <summary>
/// Fired when additional information about a responseReceived event is available from the network
/// stack. Not every responseReceived event will have an additional responseReceivedExtraInfo for
/// it, and responseReceivedExtraInfo may be fired before or after responseReceived.
/// </summary>
[Experimental]public event Action<ResponseReceivedExtraInfoParams> OnResponseReceivedExtraInfo {
add => _onResponseReceivedExtraInfo += value; remove => _onResponseReceivedExtraInfo -= value;}
public sealed partial class TrustTokenOperationDoneParams {
/// <summary>
/// Detailed success or error status of the operation.
/// 'AlreadyExists' also signifies a successful operation, as the result
/// of the operation already exists und thus, the operation was abort
/// preemptively (e.g. a cache hit).
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum StatusEnum {
[EnumMember(Value = "Ok")] Ok,
[EnumMember(Value = "InvalidArgument")] InvalidArgument,
[EnumMember(Value = "FailedPrecondition")] FailedPrecondition,
[EnumMember(Value = "ResourceExhausted")] ResourceExhausted,
[EnumMember(Value = "AlreadyExists")] AlreadyExists,
[EnumMember(Value = "Unavailable")] Unavailable,
[EnumMember(Value = "BadResponse")] BadResponse,
[EnumMember(Value = "InternalError")] InternalError,
[EnumMember(Value = "UnknownError")] UnknownError,
[EnumMember(Value = "FulfilledLocally")] FulfilledLocally,
}
[JsonPropertyName("status")]public StatusEnum Status{get;set;}
[JsonPropertyName("type")]public Network.TrustTokenOperationType Type{get;set;}
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// Top level origin. The context in which the operation was attempted.
/// </summary>
[JsonPropertyName("topLevelOrigin")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? TopLevelOrigin{get;set;}
/// <summary>
/// Origin of the issuer in case of a "Issuance" or "Redemption" operation.
/// </summary>
[JsonPropertyName("issuerOrigin")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? IssuerOrigin{get;set;}
/// <summary>
/// The number of obtained Trust Tokens on a successful "Issuance" operation.
/// </summary>
[JsonPropertyName("issuedTokenCount")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? IssuedTokenCount{get;set;}
}
private Action<TrustTokenOperationDoneParams>? _onTrustTokenOperationDone;
/// <summary>
/// Fired exactly once for each Trust Token operation. Depending on
/// the type of the operation and whether the operation succeeded or
/// failed, the event is fired before the corresponding request was sent
/// or after the response was received.
/// </summary>
[Experimental]public event Action<TrustTokenOperationDoneParams> OnTrustTokenOperationDone {
add => _onTrustTokenOperationDone += value; remove => _onTrustTokenOperationDone -= value;}
public sealed partial class SubresourceWebBundleMetadataReceivedParams {
/// <summary>
/// Request identifier. Used to match this information to another event.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// A list of URLs of resources in the subresource Web Bundle.
/// </summary>
[JsonPropertyName("urls")]public string[] Urls{get;set;}
}
private Action<SubresourceWebBundleMetadataReceivedParams>? _onSubresourceWebBundleMetadataReceived;
/// <summary>
/// Fired once when parsing the .wbn file has succeeded.
/// The event contains the information about the web bundle contents.
/// </summary>
[Experimental]public event Action<SubresourceWebBundleMetadataReceivedParams> OnSubresourceWebBundleMetadataReceived {
add => _onSubresourceWebBundleMetadataReceived += value; remove => _onSubresourceWebBundleMetadataReceived -= value;}
public sealed partial class SubresourceWebBundleMetadataErrorParams {
/// <summary>
/// Request identifier. Used to match this information to another event.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// Error message
/// </summary>
[JsonPropertyName("errorMessage")]public string ErrorMessage{get;set;}
}
private Action<SubresourceWebBundleMetadataErrorParams>? _onSubresourceWebBundleMetadataError;
/// <summary>
/// Fired once when parsing the .wbn file has failed.
/// </summary>
[Experimental]public event Action<SubresourceWebBundleMetadataErrorParams> OnSubresourceWebBundleMetadataError {
add => _onSubresourceWebBundleMetadataError += value; remove => _onSubresourceWebBundleMetadataError -= value;}
public sealed partial class SubresourceWebBundleInnerResponseParsedParams {
/// <summary>
/// Request identifier of the subresource request
/// </summary>
[JsonPropertyName("innerRequestId")]public Network.RequestId InnerRequestId{get;set;}
/// <summary>
/// URL of the subresource resource.
/// </summary>
[JsonPropertyName("innerRequestURL")]public string InnerRequestURL{get;set;}
/// <summary>
/// Bundle request identifier. Used to match this information to another event.
/// This made be absent in case when the instrumentation was enabled only
/// after webbundle was parsed.
/// </summary>
[JsonPropertyName("bundleRequestId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.RequestId? BundleRequestId{get;set;}
}
private Action<SubresourceWebBundleInnerResponseParsedParams>? _onSubresourceWebBundleInnerResponseParsed;
/// <summary>
/// Fired when handling requests for resources within a .wbn file.
/// Note: this will only be fired for resources that are requested by the webpage.
/// </summary>
[Experimental]public event Action<SubresourceWebBundleInnerResponseParsedParams> OnSubresourceWebBundleInnerResponseParsed {
add => _onSubresourceWebBundleInnerResponseParsed += value; remove => _onSubresourceWebBundleInnerResponseParsed -= value;}
public sealed partial class SubresourceWebBundleInnerResponseErrorParams {
/// <summary>
/// Request identifier of the subresource request
/// </summary>
[JsonPropertyName("innerRequestId")]public Network.RequestId InnerRequestId{get;set;}
/// <summary>
/// URL of the subresource resource.
/// </summary>
[JsonPropertyName("innerRequestURL")]public string InnerRequestURL{get;set;}
/// <summary>
/// Error message
/// </summary>
[JsonPropertyName("errorMessage")]public string ErrorMessage{get;set;}
/// <summary>
/// Bundle request identifier. Used to match this information to another event.
/// This made be absent in case when the instrumentation was enabled only
/// after webbundle was parsed.
/// </summary>
[JsonPropertyName("bundleRequestId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.RequestId? BundleRequestId{get;set;}
}
private Action<SubresourceWebBundleInnerResponseErrorParams>? _onSubresourceWebBundleInnerResponseError;
/// <summary>
/// Fired when request for resources within a .wbn file failed.
/// </summary>
[Experimental]public event Action<SubresourceWebBundleInnerResponseErrorParams> OnSubresourceWebBundleInnerResponseError {
add => _onSubresourceWebBundleInnerResponseError += value; remove => _onSubresourceWebBundleInnerResponseError -= value;}
public sealed partial class ReportingApiReportAddedParams {
[JsonPropertyName("report")]public Network.ReportingApiReport Report{get;set;}
}
private Action<ReportingApiReportAddedParams>? _onReportingApiReportAdded;
/// <summary>
/// Is sent whenever a new report is added.
/// And after 'enableReportingApi' for all existing reports.
/// </summary>
[Experimental]public event Action<ReportingApiReportAddedParams> OnReportingApiReportAdded {
add => _onReportingApiReportAdded += value; remove => _onReportingApiReportAdded -= value;}
public sealed partial class ReportingApiReportUpdatedParams {
[JsonPropertyName("report")]public Network.ReportingApiReport Report{get;set;}
}
private Action<ReportingApiReportUpdatedParams>? _onReportingApiReportUpdated;
[Experimental]public event Action<ReportingApiReportUpdatedParams> OnReportingApiReportUpdated {
add => _onReportingApiReportUpdated += value; remove => _onReportingApiReportUpdated -= value;}
public sealed partial class ReportingApiEndpointsChangedForOriginParams {
/// <summary>
/// Origin of the document(s) which configured the endpoints.
/// </summary>
[JsonPropertyName("origin")]public string Origin{get;set;}
[JsonPropertyName("endpoints")]public Network.ReportingApiEndpoint[] Endpoints{get;set;}
}
private Action<ReportingApiEndpointsChangedForOriginParams>? _onReportingApiEndpointsChangedForOrigin;
[Experimental]public event Action<ReportingApiEndpointsChangedForOriginParams> OnReportingApiEndpointsChangedForOrigin {
add => _onReportingApiEndpointsChangedForOrigin += value; remove => _onReportingApiEndpointsChangedForOrigin -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Network.dataReceived":
_onDataReceived?.Invoke(_target.DeserializeEvent<DataReceivedParams>(data));
break;
case "Network.eventSourceMessageReceived":
_onEventSourceMessageReceived?.Invoke(_target.DeserializeEvent<EventSourceMessageReceivedParams>(data));
break;
case "Network.loadingFailed":
_onLoadingFailed?.Invoke(_target.DeserializeEvent<LoadingFailedParams>(data));
break;
case "Network.loadingFinished":
_onLoadingFinished?.Invoke(_target.DeserializeEvent<LoadingFinishedParams>(data));
break;
case "Network.requestIntercepted":
_onRequestIntercepted?.Invoke(_target.DeserializeEvent<RequestInterceptedParams>(data));
break;
case "Network.requestServedFromCache":
_onRequestServedFromCache?.Invoke(_target.DeserializeEvent<RequestServedFromCacheParams>(data));
break;
case "Network.requestWillBeSent":
_onRequestWillBeSent?.Invoke(_target.DeserializeEvent<RequestWillBeSentParams>(data));
break;
case "Network.resourceChangedPriority":
_onResourceChangedPriority?.Invoke(_target.DeserializeEvent<ResourceChangedPriorityParams>(data));
break;
case "Network.signedExchangeReceived":
_onSignedExchangeReceived?.Invoke(_target.DeserializeEvent<SignedExchangeReceivedParams>(data));
break;
case "Network.responseReceived":
_onResponseReceived?.Invoke(_target.DeserializeEvent<ResponseReceivedParams>(data));
break;
case "Network.webSocketClosed":
_onWebSocketClosed?.Invoke(_target.DeserializeEvent<WebSocketClosedParams>(data));
break;
case "Network.webSocketCreated":
_onWebSocketCreated?.Invoke(_target.DeserializeEvent<WebSocketCreatedParams>(data));
break;
case "Network.webSocketFrameError":
_onWebSocketFrameError?.Invoke(_target.DeserializeEvent<WebSocketFrameErrorParams>(data));
break;
case "Network.webSocketFrameReceived":
_onWebSocketFrameReceived?.Invoke(_target.DeserializeEvent<WebSocketFrameReceivedParams>(data));
break;
case "Network.webSocketFrameSent":
_onWebSocketFrameSent?.Invoke(_target.DeserializeEvent<WebSocketFrameSentParams>(data));
break;
case "Network.webSocketHandshakeResponseReceived":
_onWebSocketHandshakeResponseReceived?.Invoke(_target.DeserializeEvent<WebSocketHandshakeResponseReceivedParams>(data));
break;
case "Network.webSocketWillSendHandshakeRequest":
_onWebSocketWillSendHandshakeRequest?.Invoke(_target.DeserializeEvent<WebSocketWillSendHandshakeRequestParams>(data));
break;
case "Network.webTransportCreated":
_onWebTransportCreated?.Invoke(_target.DeserializeEvent<WebTransportCreatedParams>(data));
break;
case "Network.webTransportConnectionEstablished":
_onWebTransportConnectionEstablished?.Invoke(_target.DeserializeEvent<WebTransportConnectionEstablishedParams>(data));
break;
case "Network.webTransportClosed":
_onWebTransportClosed?.Invoke(_target.DeserializeEvent<WebTransportClosedParams>(data));
break;
case "Network.requestWillBeSentExtraInfo":
_onRequestWillBeSentExtraInfo?.Invoke(_target.DeserializeEvent<RequestWillBeSentExtraInfoParams>(data));
break;
case "Network.responseReceivedExtraInfo":
_onResponseReceivedExtraInfo?.Invoke(_target.DeserializeEvent<ResponseReceivedExtraInfoParams>(data));
break;
case "Network.trustTokenOperationDone":
_onTrustTokenOperationDone?.Invoke(_target.DeserializeEvent<TrustTokenOperationDoneParams>(data));
break;
case "Network.subresourceWebBundleMetadataReceived":
_onSubresourceWebBundleMetadataReceived?.Invoke(_target.DeserializeEvent<SubresourceWebBundleMetadataReceivedParams>(data));
break;
case "Network.subresourceWebBundleMetadataError":
_onSubresourceWebBundleMetadataError?.Invoke(_target.DeserializeEvent<SubresourceWebBundleMetadataErrorParams>(data));
break;
case "Network.subresourceWebBundleInnerResponseParsed":
_onSubresourceWebBundleInnerResponseParsed?.Invoke(_target.DeserializeEvent<SubresourceWebBundleInnerResponseParsedParams>(data));
break;
case "Network.subresourceWebBundleInnerResponseError":
_onSubresourceWebBundleInnerResponseError?.Invoke(_target.DeserializeEvent<SubresourceWebBundleInnerResponseErrorParams>(data));
break;
case "Network.reportingApiReportAdded":
_onReportingApiReportAdded?.Invoke(_target.DeserializeEvent<ReportingApiReportAddedParams>(data));
break;
case "Network.reportingApiReportUpdated":
_onReportingApiReportUpdated?.Invoke(_target.DeserializeEvent<ReportingApiReportUpdatedParams>(data));
break;
case "Network.reportingApiEndpointsChangedForOrigin":
_onReportingApiEndpointsChangedForOrigin?.Invoke(_target.DeserializeEvent<ReportingApiEndpointsChangedForOriginParams>(data));
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
_onDataReceived = null;
_onEventSourceMessageReceived = null;
_onLoadingFailed = null;
_onLoadingFinished = null;
_onRequestIntercepted = null;
_onRequestServedFromCache = null;
_onRequestWillBeSent = null;
_onResourceChangedPriority = null;
_onSignedExchangeReceived = null;
_onResponseReceived = null;
_onWebSocketClosed = null;
_onWebSocketCreated = null;
_onWebSocketFrameError = null;
_onWebSocketFrameReceived = null;
_onWebSocketFrameSent = null;
_onWebSocketHandshakeResponseReceived = null;
_onWebSocketWillSendHandshakeRequest = null;
_onWebTransportCreated = null;
_onWebTransportConnectionEstablished = null;
_onWebTransportClosed = null;
_onRequestWillBeSentExtraInfo = null;
_onResponseReceivedExtraInfo = null;
_onTrustTokenOperationDone = null;
_onSubresourceWebBundleMetadataReceived = null;
_onSubresourceWebBundleMetadataError = null;
_onSubresourceWebBundleInnerResponseParsed = null;
_onSubresourceWebBundleInnerResponseError = null;
_onReportingApiReportAdded = null;
_onReportingApiReportUpdated = null;
_onReportingApiEndpointsChangedForOrigin = null;
}
}
