using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.WebAudio;
/// <summary>
/// Protocol object for AudioParam
/// </summary>
public sealed partial class AudioParam {
[JsonPropertyName("paramId")]public GraphObjectId ParamId{get;set;}
[JsonPropertyName("nodeId")]public GraphObjectId NodeId{get;set;}
[JsonPropertyName("contextId")]public GraphObjectId ContextId{get;set;}
[JsonPropertyName("paramType")]public ParamType ParamType{get;set;}
[JsonPropertyName("rate")]public AutomationRate Rate{get;set;}
[JsonPropertyName("defaultValue")]public double DefaultValue{get;set;}
[JsonPropertyName("minValue")]public double MinValue{get;set;}
[JsonPropertyName("maxValue")]public double MaxValue{get;set;}
}
