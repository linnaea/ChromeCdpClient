using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Fetch;
/// <summary>
/// Stages of the request to handle. Request will intercept before the request is
/// sent. Response will intercept after the response is received (but before response
/// body is received).
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum RequestStage {
[EnumMember(Value = "Request")] Request,
[EnumMember(Value = "Response")] Response,
}
