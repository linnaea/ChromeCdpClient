using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.WebAudio;
/// <summary>
/// Fields in AudioContext that change in real-time.
/// </summary>
public sealed partial class ContextRealtimeData {
/// <summary>
/// The current context time in second in BaseAudioContext.
/// </summary>
[JsonPropertyName("currentTime")]public double CurrentTime{get;set;}
/// <summary>
/// The time spent on rendering graph divided by render quantum duration,
/// and multiplied by 100. 100 means the audio renderer reached the full
/// capacity and glitch may occur.
/// </summary>
[JsonPropertyName("renderCapacity")]public double RenderCapacity{get;set;}
/// <summary>
/// A running mean of callback interval.
/// </summary>
[JsonPropertyName("callbackIntervalMean")]public double CallbackIntervalMean{get;set;}
/// <summary>
/// A running variance of callback interval.
/// </summary>
[JsonPropertyName("callbackIntervalVariance")]public double CallbackIntervalVariance{get;set;}
}
