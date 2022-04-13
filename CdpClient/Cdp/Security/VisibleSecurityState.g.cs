using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Security;
/// <summary>
/// Security state information about the page.
/// </summary>
[Experimental]public sealed partial class VisibleSecurityState {
/// <summary>
/// The security level of the page.
/// </summary>
[JsonPropertyName("securityState")]public SecurityState SecurityState{get;set;}
/// <summary>
/// Security state details about the page certificate.
/// </summary>
[JsonPropertyName("certificateSecurityState")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CertificateSecurityState? CertificateSecurityState{get;set;}
/// <summary>
/// The type of Safety Tip triggered on the page. Note that this field will be set even if the Safety Tip UI was not actually shown.
/// </summary>
[JsonPropertyName("safetyTipInfo")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public SafetyTipInfo? SafetyTipInfo{get;set;}
/// <summary>
/// Array of security state issues ids.
/// </summary>
[JsonPropertyName("securityStateIssueIds")]public string[] SecurityStateIssueIds{get;set;}
}
