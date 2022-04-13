using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
[JsonConverter(typeof(StringEnumConverter))] public enum CookieWarningReason {
[EnumMember(Value = "WarnSameSiteUnspecifiedCrossSiteContext")] WarnSameSiteUnspecifiedCrossSiteContext,
[EnumMember(Value = "WarnSameSiteNoneInsecure")] WarnSameSiteNoneInsecure,
[EnumMember(Value = "WarnSameSiteUnspecifiedLaxAllowUnsafe")] WarnSameSiteUnspecifiedLaxAllowUnsafe,
[EnumMember(Value = "WarnSameSiteStrictLaxDowngradeStrict")] WarnSameSiteStrictLaxDowngradeStrict,
[EnumMember(Value = "WarnSameSiteStrictCrossDowngradeStrict")] WarnSameSiteStrictCrossDowngradeStrict,
[EnumMember(Value = "WarnSameSiteStrictCrossDowngradeLax")] WarnSameSiteStrictCrossDowngradeLax,
[EnumMember(Value = "WarnSameSiteLaxCrossDowngradeStrict")] WarnSameSiteLaxCrossDowngradeStrict,
[EnumMember(Value = "WarnSameSiteLaxCrossDowngradeLax")] WarnSameSiteLaxCrossDowngradeLax,
[EnumMember(Value = "WarnAttributeValueExceedsMaxSize")] WarnAttributeValueExceedsMaxSize,
}
