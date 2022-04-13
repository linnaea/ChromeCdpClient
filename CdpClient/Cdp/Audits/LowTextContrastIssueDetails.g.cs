using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
public sealed partial class LowTextContrastIssueDetails {
[JsonPropertyName("violatingNodeId")]public DOM.BackendNodeId ViolatingNodeId{get;set;}
[JsonPropertyName("violatingNodeSelector")]public string ViolatingNodeSelector{get;set;}
[JsonPropertyName("contrastRatio")]public double ContrastRatio{get;set;}
[JsonPropertyName("thresholdAA")]public double ThresholdAA{get;set;}
[JsonPropertyName("thresholdAAA")]public double ThresholdAAA{get;set;}
[JsonPropertyName("fontSize")]public string FontSize{get;set;}
[JsonPropertyName("fontWeight")]public string FontWeight{get;set;}
}
