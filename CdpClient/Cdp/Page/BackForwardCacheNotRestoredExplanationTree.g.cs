using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
[Experimental]public sealed partial class BackForwardCacheNotRestoredExplanationTree {
/// <summary>
/// URL of each frame
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Not restored reasons of each frame
/// </summary>
[JsonPropertyName("explanations")]public BackForwardCacheNotRestoredExplanation[] Explanations{get;set;}
/// <summary>
/// Array of children frame
/// </summary>
[JsonPropertyName("children")]public BackForwardCacheNotRestoredExplanationTree[] Children{get;set;}
}
