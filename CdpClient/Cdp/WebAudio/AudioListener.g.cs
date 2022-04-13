using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.WebAudio;
/// <summary>
/// Protocol object for AudioListener
/// </summary>
public sealed partial class AudioListener {
[JsonPropertyName("listenerId")]public GraphObjectId ListenerId{get;set;}
[JsonPropertyName("contextId")]public GraphObjectId ContextId{get;set;}
}
