using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// The referring-policy used for the navigation.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum ReferrerPolicy {
[EnumMember(Value = "noReferrer")] NoReferrer,
[EnumMember(Value = "noReferrerWhenDowngrade")] NoReferrerWhenDowngrade,
[EnumMember(Value = "origin")] Origin,
[EnumMember(Value = "originWhenCrossOrigin")] OriginWhenCrossOrigin,
[EnumMember(Value = "sameOrigin")] SameOrigin,
[EnumMember(Value = "strictOrigin")] StrictOrigin,
[EnumMember(Value = "strictOriginWhenCrossOrigin")] StrictOriginWhenCrossOrigin,
[EnumMember(Value = "unsafeUrl")] UnsafeUrl,
}
