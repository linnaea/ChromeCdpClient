using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
public sealed partial class TrustedWebActivityIssueDetails {
/// <summary>
/// The url that triggers the violation.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
[JsonPropertyName("violationType")]public TwaQualityEnforcementViolationType ViolationType{get;set;}
[JsonPropertyName("httpStatusCode")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? HttpStatusCode{get;set;}
/// <summary>
/// The package name of the Trusted Web Activity client app. This field is
/// only used when violation type is kDigitalAssetLinks.
/// </summary>
[JsonPropertyName("packageName")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? PackageName{get;set;}
/// <summary>
/// The signature of the Trusted Web Activity client app. This field is only
/// used when violation type is kDigitalAssetLinks.
/// </summary>
[JsonPropertyName("signature")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Signature{get;set;}
}
