using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// Audits domain allows investigation of page violations and possible improvements.
/// </summary>
[Experimental]public sealed partial class AuditsDomain {
private readonly ConnectedTarget _target;
public AuditsDomain(ConnectedTarget target) => _target = target;
public sealed partial class GetEncodedResponseParams {
/// <summary>
/// Identifier of the network request to get content for.
/// </summary>
[JsonPropertyName("requestId")]public Network.RequestId RequestId{get;set;}
/// <summary>
/// The encoding to use.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum EncodingEnum {
[EnumMember(Value = "webp")] Webp,
[EnumMember(Value = "jpeg")] Jpeg,
[EnumMember(Value = "png")] Png,
}
[JsonPropertyName("encoding")]public EncodingEnum Encoding{get;set;}
/// <summary>
/// The quality of the encoding (0-1). (defaults to 1)
/// </summary>
[JsonPropertyName("quality")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Quality{get;set;}
/// <summary>
/// Whether to only return the size information (defaults to false).
/// </summary>
[JsonPropertyName("sizeOnly")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? SizeOnly{get;set;}
}
public sealed partial class GetEncodedResponseReturn {
/// <summary>
/// The encoded body as a base64 string. Omitted if sizeOnly is true. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("body")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Body{get;set;}
/// <summary>
/// Size before re-encoding.
/// </summary>
[JsonPropertyName("originalSize")]public long OriginalSize{get;set;}
/// <summary>
/// Size after re-encoding.
/// </summary>
[JsonPropertyName("encodedSize")]public long EncodedSize{get;set;}
}
/// <summary>
/// Returns the response body and size if it were re-encoded with the specified settings. Only
/// applies to images.
/// </summary>
/// <param name="requestId">Identifier of the network request to get content for.</param>
/// <param name="encoding">The encoding to use.</param>
/// <param name="quality">The quality of the encoding (0-1). (defaults to 1)</param>
/// <param name="sizeOnly">Whether to only return the size information (defaults to false).</param>
public async Task<GetEncodedResponseReturn> GetEncodedResponse(
 Network.RequestId @requestId,GetEncodedResponseParams.EncodingEnum @encoding,double? @quality=default,bool? @sizeOnly=default) {
var resp = await _target.SendRequest("Audits.getEncodedResponse",
new GetEncodedResponseParams {
RequestId=@requestId,Encoding=@encoding,Quality=@quality,SizeOnly=@sizeOnly,});
return _target.DeserializeResponse<GetEncodedResponseReturn>(resp);
}
/// <summary>
/// Disables issues domain, prevents further issues from being reported to the client.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("Audits.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Enables issues domain, sends the issues collected so far to the client by means of the
/// `issueAdded` event.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("Audits.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class CheckContrastParams {
/// <summary>
/// Whether to report WCAG AAA level issues. Default is false.
/// </summary>
[JsonPropertyName("reportAAA")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ReportAAA{get;set;}
}
/// <summary>
/// Runs the contrast check for the target page. Found issues are reported
/// using Audits.issueAdded event.
/// </summary>
/// <param name="reportAAA">Whether to report WCAG AAA level issues. Default is false.</param>
public async Task CheckContrast(
 bool? @reportAAA=default) {
var resp = await _target.SendRequest("Audits.checkContrast",
new CheckContrastParams {
ReportAAA=@reportAAA,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class IssueAddedParams {
[JsonPropertyName("issue")]public Audits.InspectorIssue Issue{get;set;}
}
private Action<IssueAddedParams>? _onIssueAdded;
public event Action<IssueAddedParams> OnIssueAdded {
add => _onIssueAdded += value; remove => _onIssueAdded -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Audits.issueAdded":
_onIssueAdded?.Invoke(_target.DeserializeEvent<IssueAddedParams>(data));
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
_onIssueAdded = null;
}
}
