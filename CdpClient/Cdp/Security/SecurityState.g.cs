using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Security;
/// <summary>
/// The security level of a page or resource.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum SecurityState {
[EnumMember(Value = "unknown")] Unknown,
[EnumMember(Value = "neutral")] Neutral,
[EnumMember(Value = "insecure")] Insecure,
[EnumMember(Value = "secure")] Secure,
[EnumMember(Value = "info")] Info,
[EnumMember(Value = "insecure-broken")] InsecureBroken,
}
