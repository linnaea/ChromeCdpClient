using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Types of reasons why a cookie may not be sent with a request.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum CookieBlockedReason {
[EnumMember(Value = "SecureOnly")] SecureOnly,
[EnumMember(Value = "NotOnPath")] NotOnPath,
[EnumMember(Value = "DomainMismatch")] DomainMismatch,
[EnumMember(Value = "SameSiteStrict")] SameSiteStrict,
[EnumMember(Value = "SameSiteLax")] SameSiteLax,
[EnumMember(Value = "SameSiteUnspecifiedTreatedAsLax")] SameSiteUnspecifiedTreatedAsLax,
[EnumMember(Value = "SameSiteNoneInsecure")] SameSiteNoneInsecure,
[EnumMember(Value = "UserPreferences")] UserPreferences,
[EnumMember(Value = "UnknownError")] UnknownError,
[EnumMember(Value = "SchemefulSameSiteStrict")] SchemefulSameSiteStrict,
[EnumMember(Value = "SchemefulSameSiteLax")] SchemefulSameSiteLax,
[EnumMember(Value = "SchemefulSameSiteUnspecifiedTreatedAsLax")] SchemefulSameSiteUnspecifiedTreatedAsLax,
[EnumMember(Value = "SamePartyFromCrossPartyContext")] SamePartyFromCrossPartyContext,
[EnumMember(Value = "NameValuePairExceedsMaxSize")] NameValuePairExceedsMaxSize,
}
