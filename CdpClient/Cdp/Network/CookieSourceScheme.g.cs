using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Represents the source scheme of the origin that originally set the cookie.
/// A value of "Unset" allows protocol clients to emulate legacy cookie scope for the scheme.
/// This is a temporary ability and it will be removed in the future.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum CookieSourceScheme {
[EnumMember(Value = "Unset")] Unset,
[EnumMember(Value = "NonSecure")] NonSecure,
[EnumMember(Value = "Secure")] Secure,
}
