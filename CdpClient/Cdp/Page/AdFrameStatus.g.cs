using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Indicates whether a frame has been identified as an ad and why.
/// </summary>
[Experimental]public sealed partial class AdFrameStatus {
[JsonPropertyName("adFrameType")]public AdFrameType AdFrameType{get;set;}
[JsonPropertyName("explanations")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AdFrameExplanation[]? Explanations{get;set;}
}
