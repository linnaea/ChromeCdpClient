using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
/// <summary>
/// Details for issues about documents in Quirks Mode
/// or Limited Quirks Mode that affects page layouting.
/// </summary>
public sealed partial class QuirksModeIssueDetails {
/// <summary>
/// If false, it means the document's mode is "quirks"
/// instead of "limited-quirks".
/// </summary>
[JsonPropertyName("isLimitedQuirksMode")]public bool IsLimitedQuirksMode{get;set;}
[JsonPropertyName("documentNodeId")]public DOM.BackendNodeId DocumentNodeId{get;set;}
[JsonPropertyName("url")]public string Url{get;set;}
[JsonPropertyName("frameId")]public Page.FrameId FrameId{get;set;}
[JsonPropertyName("loaderId")]public Network.LoaderId LoaderId{get;set;}
}
