using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
[Experimental]public sealed partial class PermissionsPolicyBlockLocator {
[JsonPropertyName("frameId")]public FrameId FrameId{get;set;}
[JsonPropertyName("blockReason")]public PermissionsPolicyBlockReason BlockReason{get;set;}
}
