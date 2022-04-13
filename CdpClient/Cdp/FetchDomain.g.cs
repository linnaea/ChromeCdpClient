using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// A domain for letting clients substitute browser's network layer with client code.
/// </summary>
public sealed partial class FetchDomain {
private readonly ConnectedTarget _target;
public FetchDomain(ConnectedTarget target) => _target = target;
/// <summary>
/// Disables the fetch domain.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("Fetch.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class EnableParams {
/// <summary>
/// If specified, only requests matching any of these patterns will produce
/// fetchRequested event and will be paused until clients response. If not set,
/// all requests will be affected.
/// </summary>
[JsonPropertyName("patterns")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Fetch.RequestPattern[]? Patterns{get;set;}
/// <summary>
/// If true, authRequired events will be issued and requests will be paused
/// expecting a call to continueWithAuth.
/// </summary>
[JsonPropertyName("handleAuthRequests")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? HandleAuthRequests{get;set;}
}
/// <summary>
/// Enables issuing of requestPaused events. A request will be paused until client
/// calls one of failRequest, fulfillRequest or continueRequest/continueWithAuth.
/// </summary>
/// <param name="patterns">If specified, only requests matching any of these patterns will produce
/// fetchRequested event and will be paused until clients response. If not set,
/// all requests will be affected.</param>
/// <param name="handleAuthRequests">If true, authRequired events will be issued and requests will be paused
/// expecting a call to continueWithAuth.</param>
public async Task Enable(
 Fetch.RequestPattern[]? @patterns=default,bool? @handleAuthRequests=default) {
var resp = await _target.SendRequest("Fetch.enable",
new EnableParams {
Patterns=@patterns,HandleAuthRequests=@handleAuthRequests,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class FailRequestParams {
/// <summary>
/// An id the client received in requestPaused event.
/// </summary>
[JsonPropertyName("requestId")]public Fetch.RequestId RequestId{get;set;}
/// <summary>
/// Causes the request to fail with the given reason.
/// </summary>
[JsonPropertyName("errorReason")]public Network.ErrorReason ErrorReason{get;set;}
}
/// <summary>
/// Causes the request to fail with specified reason.
/// </summary>
/// <param name="requestId">An id the client received in requestPaused event.</param>
/// <param name="errorReason">Causes the request to fail with the given reason.</param>
public async Task FailRequest(
 Fetch.RequestId @requestId,Network.ErrorReason @errorReason) {
var resp = await _target.SendRequest("Fetch.failRequest",
new FailRequestParams {
RequestId=@requestId,ErrorReason=@errorReason,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class FulfillRequestParams {
/// <summary>
/// An id the client received in requestPaused event.
/// </summary>
[JsonPropertyName("requestId")]public Fetch.RequestId RequestId{get;set;}
/// <summary>
/// An HTTP response code.
/// </summary>
[JsonPropertyName("responseCode")]public long ResponseCode{get;set;}
/// <summary>
/// Response headers.
/// </summary>
[JsonPropertyName("responseHeaders")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Fetch.HeaderEntry[]? ResponseHeaders{get;set;}
/// <summary>
/// Alternative way of specifying response headers as a \0-separated
/// series of name: value pairs. Prefer the above method unless you
/// need to represent some non-UTF8 values that can't be transmitted
/// over the protocol as text. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("binaryResponseHeaders")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? BinaryResponseHeaders{get;set;}
/// <summary>
/// A response body. If absent, original response body will be used if
/// the request is intercepted at the response stage and empty body
/// will be used if the request is intercepted at the request stage. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("body")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Body{get;set;}
/// <summary>
/// A textual representation of responseCode.
/// If absent, a standard phrase matching responseCode is used.
/// </summary>
[JsonPropertyName("responsePhrase")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ResponsePhrase{get;set;}
}
/// <summary>
/// Provides response to the request.
/// </summary>
/// <param name="requestId">An id the client received in requestPaused event.</param>
/// <param name="responseCode">An HTTP response code.</param>
/// <param name="responseHeaders">Response headers.</param>
/// <param name="binaryResponseHeaders">Alternative way of specifying response headers as a \0-separated
/// series of name: value pairs. Prefer the above method unless you
/// need to represent some non-UTF8 values that can't be transmitted
/// over the protocol as text. (Encoded as a base64 string when passed over JSON)</param>
/// <param name="body">A response body. If absent, original response body will be used if
/// the request is intercepted at the response stage and empty body
/// will be used if the request is intercepted at the request stage. (Encoded as a base64 string when passed over JSON)</param>
/// <param name="responsePhrase">A textual representation of responseCode.
/// If absent, a standard phrase matching responseCode is used.</param>
public async Task FulfillRequest(
 Fetch.RequestId @requestId,long @responseCode,Fetch.HeaderEntry[]? @responseHeaders=default,string? @binaryResponseHeaders=default,string? @body=default,string? @responsePhrase=default) {
var resp = await _target.SendRequest("Fetch.fulfillRequest",
new FulfillRequestParams {
RequestId=@requestId,ResponseCode=@responseCode,ResponseHeaders=@responseHeaders,BinaryResponseHeaders=@binaryResponseHeaders,Body=@body,ResponsePhrase=@responsePhrase,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class ContinueRequestParams {
/// <summary>
/// An id the client received in requestPaused event.
/// </summary>
[JsonPropertyName("requestId")]public Fetch.RequestId RequestId{get;set;}
/// <summary>
/// If set, the request url will be modified in a way that's not observable by page.
/// </summary>
[JsonPropertyName("url")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Url{get;set;}
/// <summary>
/// If set, the request method is overridden.
/// </summary>
[JsonPropertyName("method")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Method{get;set;}
/// <summary>
/// If set, overrides the post data in the request. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("postData")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? PostData{get;set;}
/// <summary>
/// If set, overrides the request headers.
/// </summary>
[JsonPropertyName("headers")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Fetch.HeaderEntry[]? Headers{get;set;}
/// <summary>
/// If set, overrides response interception behavior for this request.
/// </summary>
[Experimental][JsonPropertyName("interceptResponse")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? InterceptResponse{get;set;}
}
/// <summary>
/// Continues the request, optionally modifying some of its parameters.
/// </summary>
/// <param name="requestId">An id the client received in requestPaused event.</param>
/// <param name="url">If set, the request url will be modified in a way that's not observable by page.</param>
/// <param name="method">If set, the request method is overridden.</param>
/// <param name="postData">If set, overrides the post data in the request. (Encoded as a base64 string when passed over JSON)</param>
/// <param name="headers">If set, overrides the request headers.</param>
/// <param name="interceptResponse">EXPERIMENTAL If set, overrides response interception behavior for this request.</param>
public async Task ContinueRequest(
 Fetch.RequestId @requestId,string? @url=default,string? @method=default,string? @postData=default,Fetch.HeaderEntry[]? @headers=default,bool? @interceptResponse=default) {
var resp = await _target.SendRequest("Fetch.continueRequest",
new ContinueRequestParams {
RequestId=@requestId,Url=@url,Method=@method,PostData=@postData,Headers=@headers,InterceptResponse=@interceptResponse,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class ContinueWithAuthParams {
/// <summary>
/// An id the client received in authRequired event.
/// </summary>
[JsonPropertyName("requestId")]public Fetch.RequestId RequestId{get;set;}
/// <summary>
/// Response to  with an authChallenge.
/// </summary>
[JsonPropertyName("authChallengeResponse")]public Fetch.AuthChallengeResponse AuthChallengeResponse{get;set;}
}
/// <summary>
/// Continues a request supplying authChallengeResponse following authRequired event.
/// </summary>
/// <param name="requestId">An id the client received in authRequired event.</param>
/// <param name="authChallengeResponse">Response to  with an authChallenge.</param>
public async Task ContinueWithAuth(
 Fetch.RequestId @requestId,Fetch.AuthChallengeResponse @authChallengeResponse) {
var resp = await _target.SendRequest("Fetch.continueWithAuth",
new ContinueWithAuthParams {
RequestId=@requestId,AuthChallengeResponse=@authChallengeResponse,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class ContinueResponseParams {
/// <summary>
/// An id the client received in requestPaused event.
/// </summary>
[JsonPropertyName("requestId")]public Fetch.RequestId RequestId{get;set;}
/// <summary>
/// An HTTP response code. If absent, original response code will be used.
/// </summary>
[JsonPropertyName("responseCode")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? ResponseCode{get;set;}
/// <summary>
/// A textual representation of responseCode.
/// If absent, a standard phrase matching responseCode is used.
/// </summary>
[JsonPropertyName("responsePhrase")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ResponsePhrase{get;set;}
/// <summary>
/// Response headers. If absent, original response headers will be used.
/// </summary>
[JsonPropertyName("responseHeaders")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Fetch.HeaderEntry[]? ResponseHeaders{get;set;}
/// <summary>
/// Alternative way of specifying response headers as a \0-separated
/// series of name: value pairs. Prefer the above method unless you
/// need to represent some non-UTF8 values that can't be transmitted
/// over the protocol as text. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("binaryResponseHeaders")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? BinaryResponseHeaders{get;set;}
}
/// <summary>
/// Continues loading of the paused response, optionally modifying the
/// response headers. If either responseCode or headers are modified, all of them
/// must be present.
/// </summary>
/// <param name="requestId">An id the client received in requestPaused event.</param>
/// <param name="responseCode">An HTTP response code. If absent, original response code will be used.</param>
/// <param name="responsePhrase">A textual representation of responseCode.
/// If absent, a standard phrase matching responseCode is used.</param>
/// <param name="responseHeaders">Response headers. If absent, original response headers will be used.</param>
/// <param name="binaryResponseHeaders">Alternative way of specifying response headers as a \0-separated
/// series of name: value pairs. Prefer the above method unless you
/// need to represent some non-UTF8 values that can't be transmitted
/// over the protocol as text. (Encoded as a base64 string when passed over JSON)</param>
[Experimental]public async Task ContinueResponse(
 Fetch.RequestId @requestId,long? @responseCode=default,string? @responsePhrase=default,Fetch.HeaderEntry[]? @responseHeaders=default,string? @binaryResponseHeaders=default) {
var resp = await _target.SendRequest("Fetch.continueResponse",
new ContinueResponseParams {
RequestId=@requestId,ResponseCode=@responseCode,ResponsePhrase=@responsePhrase,ResponseHeaders=@responseHeaders,BinaryResponseHeaders=@binaryResponseHeaders,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetResponseBodyParams {
/// <summary>
/// Identifier for the intercepted request to get body for.
/// </summary>
[JsonPropertyName("requestId")]public Fetch.RequestId RequestId{get;set;}
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
/// Causes the body of the response to be received from the server and
/// returned as a single string. May only be issued for a request that
/// is paused in the Response stage and is mutually exclusive with
/// takeResponseBodyForInterceptionAsStream. Calling other methods that
/// affect the request or disabling fetch domain before body is received
/// results in an undefined behavior.
/// </summary>
/// <param name="requestId">Identifier for the intercepted request to get body for.</param>
public async Task<GetResponseBodyReturn> GetResponseBody(
 Fetch.RequestId @requestId) {
var resp = await _target.SendRequest("Fetch.getResponseBody",
new GetResponseBodyParams {
RequestId=@requestId,});
return _target.DeserializeResponse<GetResponseBodyReturn>(resp);
}
public sealed partial class TakeResponseBodyAsStreamParams {
[JsonPropertyName("requestId")]public Fetch.RequestId RequestId{get;set;}
}
public sealed partial class TakeResponseBodyAsStreamReturn {
[JsonPropertyName("stream")]public IO.StreamHandle Stream{get;set;}
}
/// <summary>
/// Returns a handle to the stream representing the response body.
/// The request must be paused in the HeadersReceived stage.
/// Note that after this command the request can't be continued
/// as is -- client either needs to cancel it or to provide the
/// response body.
/// The stream only supports sequential read, IO.read will fail if the position
/// is specified.
/// This method is mutually exclusive with getResponseBody.
/// Calling other methods that affect the request or disabling fetch
/// domain before body is received results in an undefined behavior.
/// </summary>
/// <param name="requestId"></param>
public async Task<TakeResponseBodyAsStreamReturn> TakeResponseBodyAsStream(
 Fetch.RequestId @requestId) {
var resp = await _target.SendRequest("Fetch.takeResponseBodyAsStream",
new TakeResponseBodyAsStreamParams {
RequestId=@requestId,});
return _target.DeserializeResponse<TakeResponseBodyAsStreamReturn>(resp);
}
public sealed partial class RequestPausedParams {
/// <summary>
/// Each request the page makes will have a unique id.
/// </summary>
[JsonPropertyName("requestId")]public Fetch.RequestId RequestId{get;set;}
/// <summary>
/// The details of the request.
/// </summary>
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
/// Response error if intercepted at response stage.
/// </summary>
[JsonPropertyName("responseErrorReason")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Network.ErrorReason? ResponseErrorReason{get;set;}
/// <summary>
/// Response code if intercepted at response stage.
/// </summary>
[JsonPropertyName("responseStatusCode")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? ResponseStatusCode{get;set;}
/// <summary>
/// Response status text if intercepted at response stage.
/// </summary>
[JsonPropertyName("responseStatusText")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ResponseStatusText{get;set;}
/// <summary>
/// Response headers if intercepted at the response stage.
/// </summary>
[JsonPropertyName("responseHeaders")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Fetch.HeaderEntry[]? ResponseHeaders{get;set;}
/// <summary>
/// If the intercepted request had a corresponding Network.requestWillBeSent event fired for it,
/// then this networkId will be the same as the requestId present in the requestWillBeSent event.
/// </summary>
[JsonPropertyName("networkId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Fetch.RequestId? NetworkId{get;set;}
}
private Action<RequestPausedParams>? _onRequestPaused;
/// <summary>
/// Issued when the domain is enabled and the request URL matches the
/// specified filter. The request is paused until the client responds
/// with one of continueRequest, failRequest or fulfillRequest.
/// The stage of the request can be determined by presence of responseErrorReason
/// and responseStatusCode -- the request is at the response stage if either
/// of these fields is present and in the request stage otherwise.
/// </summary>
public event Action<RequestPausedParams> OnRequestPaused {
add => _onRequestPaused += value; remove => _onRequestPaused -= value;}
public sealed partial class AuthRequiredParams {
/// <summary>
/// Each request the page makes will have a unique id.
/// </summary>
[JsonPropertyName("requestId")]public Fetch.RequestId RequestId{get;set;}
/// <summary>
/// The details of the request.
/// </summary>
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
/// Details of the Authorization Challenge encountered.
/// If this is set, client should respond with continueRequest that
/// contains AuthChallengeResponse.
/// </summary>
[JsonPropertyName("authChallenge")]public Fetch.AuthChallenge AuthChallenge{get;set;}
}
private Action<AuthRequiredParams>? _onAuthRequired;
/// <summary>
/// Issued when the domain is enabled with handleAuthRequests set to true.
/// The request is paused until client responds with continueWithAuth.
/// </summary>
public event Action<AuthRequiredParams> OnAuthRequired {
add => _onAuthRequired += value; remove => _onAuthRequired -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Fetch.requestPaused":
_onRequestPaused?.Invoke(_target.DeserializeEvent<RequestPausedParams>(data));
break;
case "Fetch.authRequired":
_onAuthRequired?.Invoke(_target.DeserializeEvent<AuthRequiredParams>(data));
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
_onRequestPaused = null;
_onAuthRequired = null;
}
}
