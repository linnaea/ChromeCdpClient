using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
public sealed partial class HeavyAdIssueDetails {
/// <summary>
/// The resolution status, either blocking the content or warning.
/// </summary>
[JsonPropertyName("resolution")]public HeavyAdResolutionStatus Resolution{get;set;}
/// <summary>
/// The reason the ad was blocked, total network or cpu or peak cpu.
/// </summary>
[JsonPropertyName("reason")]public HeavyAdReason Reason{get;set;}
/// <summary>
/// The frame that was blocked.
/// </summary>
[JsonPropertyName("frame")]public AffectedFrame Frame{get;set;}
}
