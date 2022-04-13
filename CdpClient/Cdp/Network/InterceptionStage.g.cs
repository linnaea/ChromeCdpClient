using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Stages of the interception to begin intercepting. Request will intercept before the request is
/// sent. Response will intercept after the response is received.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum InterceptionStage {
[EnumMember(Value = "Request")] Request,
[EnumMember(Value = "HeadersReceived")] HeadersReceived,
}
