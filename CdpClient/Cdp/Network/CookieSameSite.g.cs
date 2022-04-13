using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Represents the cookie's 'SameSite' status:
/// https://tools.ietf.org/html/draft-west-first-party-cookies
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum CookieSameSite {
[EnumMember(Value = "Strict")] Strict,
[EnumMember(Value = "Lax")] Lax,
[EnumMember(Value = "None")] None,
}
