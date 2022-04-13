using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.WebAudio;
/// <summary>
/// Protocol object for AudioNode
/// </summary>
public sealed partial class AudioNode {
[JsonPropertyName("nodeId")]public GraphObjectId NodeId{get;set;}
[JsonPropertyName("contextId")]public GraphObjectId ContextId{get;set;}
[JsonPropertyName("nodeType")]public NodeType NodeType{get;set;}
[JsonPropertyName("numberOfInputs")]public double NumberOfInputs{get;set;}
[JsonPropertyName("numberOfOutputs")]public double NumberOfOutputs{get;set;}
[JsonPropertyName("channelCount")]public double ChannelCount{get;set;}
[JsonPropertyName("channelCountMode")]public ChannelCountMode ChannelCountMode{get;set;}
[JsonPropertyName("channelInterpretation")]public ChannelInterpretation ChannelInterpretation{get;set;}
}
