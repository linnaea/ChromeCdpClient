using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
/// <summary>
/// Information about the frame affected by an inspector issue.
/// </summary>
public sealed partial class AffectedFrame {
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
}
