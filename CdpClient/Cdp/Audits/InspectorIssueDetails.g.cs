using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
/// <summary>
/// This struct holds a list of optional fields with additional information
/// specific to the kind of issue. When adding a new issue code, please also
/// add a new optional field to this type.
/// </summary>
public sealed partial class InspectorIssueDetails {
[JsonPropertyName("cookieIssueDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CookieIssueDetails? CookieIssueDetails{get;set;}
[JsonPropertyName("mixedContentIssueDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public MixedContentIssueDetails? MixedContentIssueDetails{get;set;}
[JsonPropertyName("blockedByResponseIssueDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public BlockedByResponseIssueDetails? BlockedByResponseIssueDetails{get;set;}
[JsonPropertyName("heavyAdIssueDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public HeavyAdIssueDetails? HeavyAdIssueDetails{get;set;}
[JsonPropertyName("contentSecurityPolicyIssueDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public ContentSecurityPolicyIssueDetails? ContentSecurityPolicyIssueDetails{get;set;}
[JsonPropertyName("sharedArrayBufferIssueDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public SharedArrayBufferIssueDetails? SharedArrayBufferIssueDetails{get;set;}
[JsonPropertyName("twaQualityEnforcementDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public TrustedWebActivityIssueDetails? TwaQualityEnforcementDetails{get;set;}
[JsonPropertyName("lowTextContrastIssueDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public LowTextContrastIssueDetails? LowTextContrastIssueDetails{get;set;}
[JsonPropertyName("corsIssueDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CorsIssueDetails? CorsIssueDetails{get;set;}
[JsonPropertyName("attributionReportingIssueDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AttributionReportingIssueDetails? AttributionReportingIssueDetails{get;set;}
[JsonPropertyName("quirksModeIssueDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public QuirksModeIssueDetails? QuirksModeIssueDetails{get;set;}
[JsonPropertyName("navigatorUserAgentIssueDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public NavigatorUserAgentIssueDetails? NavigatorUserAgentIssueDetails{get;set;}
[JsonPropertyName("genericIssueDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public GenericIssueDetails? GenericIssueDetails{get;set;}
[JsonPropertyName("deprecationIssueDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DeprecationIssueDetails? DeprecationIssueDetails{get;set;}
[JsonPropertyName("clientHintIssueDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public ClientHintIssueDetails? ClientHintIssueDetails{get;set;}
[JsonPropertyName("federatedAuthRequestIssueDetails")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public FederatedAuthRequestIssueDetails? FederatedAuthRequestIssueDetails{get;set;}
}
