using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// A cookie with was not sent with a request with the corresponding reason.
/// </summary>
[Experimental]public sealed partial class BlockedCookieWithReason {
/// <summary>
/// The reason(s) the cookie was blocked.
/// </summary>
[JsonPropertyName("blockedReasons")]public CookieBlockedReason[] BlockedReasons{get;set;}
/// <summary>
/// The cookie object representing the cookie which was not sent.
/// </summary>
[JsonPropertyName("cookie")]public Cookie Cookie{get;set;}
}
