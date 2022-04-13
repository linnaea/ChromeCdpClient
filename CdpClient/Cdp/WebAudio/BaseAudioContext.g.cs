using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.WebAudio;
/// <summary>
/// Protocol object for BaseAudioContext
/// </summary>
public sealed partial class BaseAudioContext {
[JsonPropertyName("contextId")]public GraphObjectId ContextId{get;set;}
[JsonPropertyName("contextType")]public ContextType ContextType{get;set;}
[JsonPropertyName("contextState")]public ContextState ContextState{get;set;}
[JsonPropertyName("realtimeData")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public ContextRealtimeData? RealtimeData{get;set;}
/// <summary>
/// Platform-dependent callback buffer size.
/// </summary>
[JsonPropertyName("callbackBufferSize")]public double CallbackBufferSize{get;set;}
/// <summary>
/// Number of output channels supported by audio hardware in use.
/// </summary>
[JsonPropertyName("maxOutputChannelCount")]public double MaxOutputChannelCount{get;set;}
/// <summary>
/// Context sample rate.
/// </summary>
[JsonPropertyName("sampleRate")]public double SampleRate{get;set;}
}
