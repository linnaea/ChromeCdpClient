using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Security;
[Experimental]public sealed partial class SafetyTipInfo {
/// <summary>
/// Describes whether the page triggers any safety tips or reputation warnings. Default is unknown.
/// </summary>
[JsonPropertyName("safetyTipStatus")]public SafetyTipStatus SafetyTipStatus{get;set;}
/// <summary>
/// The URL the safety tip suggested ("Did you mean?"). Only filled in for lookalike matches.
/// </summary>
[JsonPropertyName("safeUrl")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? SafeUrl{get;set;}
}
