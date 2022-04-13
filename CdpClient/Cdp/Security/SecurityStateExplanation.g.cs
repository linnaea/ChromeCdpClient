using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Security;
/// <summary>
/// An explanation of an factor contributing to the security state.
/// </summary>
public sealed partial class SecurityStateExplanation {
/// <summary>
/// Security state representing the severity of the factor being explained.
/// </summary>
[JsonPropertyName("securityState")]public SecurityState SecurityState{get;set;}
/// <summary>
/// Title describing the type of factor.
/// </summary>
[JsonPropertyName("title")]public string Title{get;set;}
/// <summary>
/// Short phrase describing the type of factor.
/// </summary>
[JsonPropertyName("summary")]public string Summary{get;set;}
/// <summary>
/// Full text explanation of the factor.
/// </summary>
[JsonPropertyName("description")]public string Description{get;set;}
/// <summary>
/// The type of mixed content described by the explanation.
/// </summary>
[JsonPropertyName("mixedContentType")]public MixedContentType MixedContentType{get;set;}
/// <summary>
/// Page certificate.
/// </summary>
[JsonPropertyName("certificate")]public string[] Certificate{get;set;}
/// <summary>
/// Recommendations to fix any issues.
/// </summary>
[JsonPropertyName("recommendations")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string[]? Recommendations{get;set;}
}
