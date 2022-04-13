using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
[Experimental]public sealed partial class BackForwardCacheNotRestoredExplanation {
/// <summary>
/// Type of the reason
/// </summary>
[JsonPropertyName("type")]public BackForwardCacheNotRestoredReasonType Type{get;set;}
/// <summary>
/// Not restored reason
/// </summary>
[JsonPropertyName("reason")]public BackForwardCacheNotRestoredReason Reason{get;set;}
/// <summary>
/// Context associated with the reason. The meaning of this context is
/// dependent on the reason:
/// - EmbedderExtensionSentMessageToCachedFrame: the extension ID.
/// </summary>
[JsonPropertyName("context")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Context{get;set;}
}
