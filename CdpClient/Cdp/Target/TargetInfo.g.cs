using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Target;
public sealed partial class TargetInfo {
[JsonPropertyName("targetId")]public TargetID TargetId{get;set;}
[JsonPropertyName("type")]public string Type{get;set;}
[JsonPropertyName("title")]public string Title{get;set;}
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Whether the target has an attached client.
/// </summary>
[JsonPropertyName("attached")]public bool Attached{get;set;}
/// <summary>
/// Opener target Id
/// </summary>
[JsonPropertyName("openerId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public TargetID? OpenerId{get;set;}
/// <summary>
/// Whether the target has access to the originating window.
/// </summary>
[Experimental][JsonPropertyName("canAccessOpener")]public bool CanAccessOpener{get;set;}
/// <summary>
/// Frame id of originating window (is only set if target has an opener).
/// </summary>
[Experimental][JsonPropertyName("openerFrameId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.FrameId? OpenerFrameId{get;set;}
[Experimental][JsonPropertyName("browserContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Browser.BrowserContextID? BrowserContextId{get;set;}
}
