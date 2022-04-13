using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// This domain allows inspection of Web Audio API.
/// https://webaudio.github.io/web-audio-api/
/// </summary>
[Experimental]public sealed partial class WebAudioDomain {
private readonly ConnectedTarget _target;
public WebAudioDomain(ConnectedTarget target) => _target = target;
/// <summary>
/// Enables the WebAudio domain and starts sending context lifetime events.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("WebAudio.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Disables the WebAudio domain.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("WebAudio.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetRealtimeDataParams {
[JsonPropertyName("contextId")]public WebAudio.GraphObjectId ContextId{get;set;}
}
public sealed partial class GetRealtimeDataReturn {
[JsonPropertyName("realtimeData")]public WebAudio.ContextRealtimeData RealtimeData{get;set;}
}
/// <summary>
/// Fetch the realtime data from the registered contexts.
/// </summary>
/// <param name="contextId"></param>
public async Task<GetRealtimeDataReturn> GetRealtimeData(
 WebAudio.GraphObjectId @contextId) {
var resp = await _target.SendRequest("WebAudio.getRealtimeData",
new GetRealtimeDataParams {
ContextId=@contextId,});
return _target.DeserializeResponse<GetRealtimeDataReturn>(resp);
}
public sealed partial class ContextCreatedParams {
[JsonPropertyName("context")]public WebAudio.BaseAudioContext Context{get;set;}
}
private Action<ContextCreatedParams>? _onContextCreated;
/// <summary>
/// Notifies that a new BaseAudioContext has been created.
/// </summary>
public event Action<ContextCreatedParams> OnContextCreated {
add => _onContextCreated += value; remove => _onContextCreated -= value;}
public sealed partial class ContextWillBeDestroyedParams {
[JsonPropertyName("contextId")]public WebAudio.GraphObjectId ContextId{get;set;}
}
private Action<ContextWillBeDestroyedParams>? _onContextWillBeDestroyed;
/// <summary>
/// Notifies that an existing BaseAudioContext will be destroyed.
/// </summary>
public event Action<ContextWillBeDestroyedParams> OnContextWillBeDestroyed {
add => _onContextWillBeDestroyed += value; remove => _onContextWillBeDestroyed -= value;}
public sealed partial class ContextChangedParams {
[JsonPropertyName("context")]public WebAudio.BaseAudioContext Context{get;set;}
}
private Action<ContextChangedParams>? _onContextChanged;
/// <summary>
/// Notifies that existing BaseAudioContext has changed some properties (id stays the same)..
/// </summary>
public event Action<ContextChangedParams> OnContextChanged {
add => _onContextChanged += value; remove => _onContextChanged -= value;}
public sealed partial class AudioListenerCreatedParams {
[JsonPropertyName("listener")]public WebAudio.AudioListener Listener{get;set;}
}
private Action<AudioListenerCreatedParams>? _onAudioListenerCreated;
/// <summary>
/// Notifies that the construction of an AudioListener has finished.
/// </summary>
public event Action<AudioListenerCreatedParams> OnAudioListenerCreated {
add => _onAudioListenerCreated += value; remove => _onAudioListenerCreated -= value;}
public sealed partial class AudioListenerWillBeDestroyedParams {
[JsonPropertyName("contextId")]public WebAudio.GraphObjectId ContextId{get;set;}
[JsonPropertyName("listenerId")]public WebAudio.GraphObjectId ListenerId{get;set;}
}
private Action<AudioListenerWillBeDestroyedParams>? _onAudioListenerWillBeDestroyed;
/// <summary>
/// Notifies that a new AudioListener has been created.
/// </summary>
public event Action<AudioListenerWillBeDestroyedParams> OnAudioListenerWillBeDestroyed {
add => _onAudioListenerWillBeDestroyed += value; remove => _onAudioListenerWillBeDestroyed -= value;}
public sealed partial class AudioNodeCreatedParams {
[JsonPropertyName("node")]public WebAudio.AudioNode Node{get;set;}
}
private Action<AudioNodeCreatedParams>? _onAudioNodeCreated;
/// <summary>
/// Notifies that a new AudioNode has been created.
/// </summary>
public event Action<AudioNodeCreatedParams> OnAudioNodeCreated {
add => _onAudioNodeCreated += value; remove => _onAudioNodeCreated -= value;}
public sealed partial class AudioNodeWillBeDestroyedParams {
[JsonPropertyName("contextId")]public WebAudio.GraphObjectId ContextId{get;set;}
[JsonPropertyName("nodeId")]public WebAudio.GraphObjectId NodeId{get;set;}
}
private Action<AudioNodeWillBeDestroyedParams>? _onAudioNodeWillBeDestroyed;
/// <summary>
/// Notifies that an existing AudioNode has been destroyed.
/// </summary>
public event Action<AudioNodeWillBeDestroyedParams> OnAudioNodeWillBeDestroyed {
add => _onAudioNodeWillBeDestroyed += value; remove => _onAudioNodeWillBeDestroyed -= value;}
public sealed partial class AudioParamCreatedParams {
[JsonPropertyName("param")]public WebAudio.AudioParam Param{get;set;}
}
private Action<AudioParamCreatedParams>? _onAudioParamCreated;
/// <summary>
/// Notifies that a new AudioParam has been created.
/// </summary>
public event Action<AudioParamCreatedParams> OnAudioParamCreated {
add => _onAudioParamCreated += value; remove => _onAudioParamCreated -= value;}
public sealed partial class AudioParamWillBeDestroyedParams {
[JsonPropertyName("contextId")]public WebAudio.GraphObjectId ContextId{get;set;}
[JsonPropertyName("nodeId")]public WebAudio.GraphObjectId NodeId{get;set;}
[JsonPropertyName("paramId")]public WebAudio.GraphObjectId ParamId{get;set;}
}
private Action<AudioParamWillBeDestroyedParams>? _onAudioParamWillBeDestroyed;
/// <summary>
/// Notifies that an existing AudioParam has been destroyed.
/// </summary>
public event Action<AudioParamWillBeDestroyedParams> OnAudioParamWillBeDestroyed {
add => _onAudioParamWillBeDestroyed += value; remove => _onAudioParamWillBeDestroyed -= value;}
public sealed partial class NodesConnectedParams {
[JsonPropertyName("contextId")]public WebAudio.GraphObjectId ContextId{get;set;}
[JsonPropertyName("sourceId")]public WebAudio.GraphObjectId SourceId{get;set;}
[JsonPropertyName("destinationId")]public WebAudio.GraphObjectId DestinationId{get;set;}
[JsonPropertyName("sourceOutputIndex")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? SourceOutputIndex{get;set;}
[JsonPropertyName("destinationInputIndex")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? DestinationInputIndex{get;set;}
}
private Action<NodesConnectedParams>? _onNodesConnected;
/// <summary>
/// Notifies that two AudioNodes are connected.
/// </summary>
public event Action<NodesConnectedParams> OnNodesConnected {
add => _onNodesConnected += value; remove => _onNodesConnected -= value;}
public sealed partial class NodesDisconnectedParams {
[JsonPropertyName("contextId")]public WebAudio.GraphObjectId ContextId{get;set;}
[JsonPropertyName("sourceId")]public WebAudio.GraphObjectId SourceId{get;set;}
[JsonPropertyName("destinationId")]public WebAudio.GraphObjectId DestinationId{get;set;}
[JsonPropertyName("sourceOutputIndex")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? SourceOutputIndex{get;set;}
[JsonPropertyName("destinationInputIndex")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? DestinationInputIndex{get;set;}
}
private Action<NodesDisconnectedParams>? _onNodesDisconnected;
/// <summary>
/// Notifies that AudioNodes are disconnected. The destination can be null, and it means all the outgoing connections from the source are disconnected.
/// </summary>
public event Action<NodesDisconnectedParams> OnNodesDisconnected {
add => _onNodesDisconnected += value; remove => _onNodesDisconnected -= value;}
public sealed partial class NodeParamConnectedParams {
[JsonPropertyName("contextId")]public WebAudio.GraphObjectId ContextId{get;set;}
[JsonPropertyName("sourceId")]public WebAudio.GraphObjectId SourceId{get;set;}
[JsonPropertyName("destinationId")]public WebAudio.GraphObjectId DestinationId{get;set;}
[JsonPropertyName("sourceOutputIndex")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? SourceOutputIndex{get;set;}
}
private Action<NodeParamConnectedParams>? _onNodeParamConnected;
/// <summary>
/// Notifies that an AudioNode is connected to an AudioParam.
/// </summary>
public event Action<NodeParamConnectedParams> OnNodeParamConnected {
add => _onNodeParamConnected += value; remove => _onNodeParamConnected -= value;}
public sealed partial class NodeParamDisconnectedParams {
[JsonPropertyName("contextId")]public WebAudio.GraphObjectId ContextId{get;set;}
[JsonPropertyName("sourceId")]public WebAudio.GraphObjectId SourceId{get;set;}
[JsonPropertyName("destinationId")]public WebAudio.GraphObjectId DestinationId{get;set;}
[JsonPropertyName("sourceOutputIndex")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? SourceOutputIndex{get;set;}
}
private Action<NodeParamDisconnectedParams>? _onNodeParamDisconnected;
/// <summary>
/// Notifies that an AudioNode is disconnected to an AudioParam.
/// </summary>
public event Action<NodeParamDisconnectedParams> OnNodeParamDisconnected {
add => _onNodeParamDisconnected += value; remove => _onNodeParamDisconnected -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "WebAudio.contextCreated":
_onContextCreated?.Invoke(_target.DeserializeEvent<ContextCreatedParams>(data));
break;
case "WebAudio.contextWillBeDestroyed":
_onContextWillBeDestroyed?.Invoke(_target.DeserializeEvent<ContextWillBeDestroyedParams>(data));
break;
case "WebAudio.contextChanged":
_onContextChanged?.Invoke(_target.DeserializeEvent<ContextChangedParams>(data));
break;
case "WebAudio.audioListenerCreated":
_onAudioListenerCreated?.Invoke(_target.DeserializeEvent<AudioListenerCreatedParams>(data));
break;
case "WebAudio.audioListenerWillBeDestroyed":
_onAudioListenerWillBeDestroyed?.Invoke(_target.DeserializeEvent<AudioListenerWillBeDestroyedParams>(data));
break;
case "WebAudio.audioNodeCreated":
_onAudioNodeCreated?.Invoke(_target.DeserializeEvent<AudioNodeCreatedParams>(data));
break;
case "WebAudio.audioNodeWillBeDestroyed":
_onAudioNodeWillBeDestroyed?.Invoke(_target.DeserializeEvent<AudioNodeWillBeDestroyedParams>(data));
break;
case "WebAudio.audioParamCreated":
_onAudioParamCreated?.Invoke(_target.DeserializeEvent<AudioParamCreatedParams>(data));
break;
case "WebAudio.audioParamWillBeDestroyed":
_onAudioParamWillBeDestroyed?.Invoke(_target.DeserializeEvent<AudioParamWillBeDestroyedParams>(data));
break;
case "WebAudio.nodesConnected":
_onNodesConnected?.Invoke(_target.DeserializeEvent<NodesConnectedParams>(data));
break;
case "WebAudio.nodesDisconnected":
_onNodesDisconnected?.Invoke(_target.DeserializeEvent<NodesDisconnectedParams>(data));
break;
case "WebAudio.nodeParamConnected":
_onNodeParamConnected?.Invoke(_target.DeserializeEvent<NodeParamConnectedParams>(data));
break;
case "WebAudio.nodeParamDisconnected":
_onNodeParamDisconnected?.Invoke(_target.DeserializeEvent<NodeParamDisconnectedParams>(data));
break;
default:
_onUnknownEvent?.Invoke(method, data);
break;
}}
private Action<string, ArraySegment<byte>>? _onUnknownEvent;
public event Action<string, ArraySegment<byte>> OnUnknownEvent {
add => _onUnknownEvent += value; remove => _onUnknownEvent -= value;}
public void DisconnectEvents() {
_onUnknownEvent = null;
_onContextCreated = null;
_onContextWillBeDestroyed = null;
_onContextChanged = null;
_onAudioListenerCreated = null;
_onAudioListenerWillBeDestroyed = null;
_onAudioNodeCreated = null;
_onAudioNodeWillBeDestroyed = null;
_onAudioParamCreated = null;
_onAudioParamWillBeDestroyed = null;
_onNodesConnected = null;
_onNodesDisconnected = null;
_onNodeParamConnected = null;
_onNodeParamDisconnected = null;
}
}
