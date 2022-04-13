using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// This domain allows detailed inspection of media elements
/// </summary>
[Experimental]public sealed partial class MediaDomain {
private readonly ConnectedTarget _target;
public MediaDomain(ConnectedTarget target) => _target = target;
/// <summary>
/// Enables the Media domain
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("Media.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Disables the Media domain.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("Media.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class PlayerPropertiesChangedParams {
[JsonPropertyName("playerId")]public Media.PlayerId PlayerId{get;set;}
[JsonPropertyName("properties")]public Media.PlayerProperty[] Properties{get;set;}
}
private Action<PlayerPropertiesChangedParams>? _onPlayerPropertiesChanged;
/// <summary>
/// This can be called multiple times, and can be used to set / override /
/// remove player properties. A null propValue indicates removal.
/// </summary>
public event Action<PlayerPropertiesChangedParams> OnPlayerPropertiesChanged {
add => _onPlayerPropertiesChanged += value; remove => _onPlayerPropertiesChanged -= value;}
public sealed partial class PlayerEventsAddedParams {
[JsonPropertyName("playerId")]public Media.PlayerId PlayerId{get;set;}
[JsonPropertyName("events")]public Media.PlayerEvent[] Events{get;set;}
}
private Action<PlayerEventsAddedParams>? _onPlayerEventsAdded;
/// <summary>
/// Send events as a list, allowing them to be batched on the browser for less
/// congestion. If batched, events must ALWAYS be in chronological order.
/// </summary>
public event Action<PlayerEventsAddedParams> OnPlayerEventsAdded {
add => _onPlayerEventsAdded += value; remove => _onPlayerEventsAdded -= value;}
public sealed partial class PlayerMessagesLoggedParams {
[JsonPropertyName("playerId")]public Media.PlayerId PlayerId{get;set;}
[JsonPropertyName("messages")]public Media.PlayerMessage[] Messages{get;set;}
}
private Action<PlayerMessagesLoggedParams>? _onPlayerMessagesLogged;
/// <summary>
/// Send a list of any messages that need to be delivered.
/// </summary>
public event Action<PlayerMessagesLoggedParams> OnPlayerMessagesLogged {
add => _onPlayerMessagesLogged += value; remove => _onPlayerMessagesLogged -= value;}
public sealed partial class PlayerErrorsRaisedParams {
[JsonPropertyName("playerId")]public Media.PlayerId PlayerId{get;set;}
[JsonPropertyName("errors")]public Media.PlayerError[] Errors{get;set;}
}
private Action<PlayerErrorsRaisedParams>? _onPlayerErrorsRaised;
/// <summary>
/// Send a list of any errors that need to be delivered.
/// </summary>
public event Action<PlayerErrorsRaisedParams> OnPlayerErrorsRaised {
add => _onPlayerErrorsRaised += value; remove => _onPlayerErrorsRaised -= value;}
public sealed partial class PlayersCreatedParams {
[JsonPropertyName("players")]public Media.PlayerId[] Players{get;set;}
}
private Action<PlayersCreatedParams>? _onPlayersCreated;
/// <summary>
/// Called whenever a player is created, or when a new agent joins and receives
/// a list of active players. If an agent is restored, it will receive the full
/// list of player ids and all events again.
/// </summary>
public event Action<PlayersCreatedParams> OnPlayersCreated {
add => _onPlayersCreated += value; remove => _onPlayersCreated -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Media.playerPropertiesChanged":
_onPlayerPropertiesChanged?.Invoke(_target.DeserializeEvent<PlayerPropertiesChangedParams>(data));
break;
case "Media.playerEventsAdded":
_onPlayerEventsAdded?.Invoke(_target.DeserializeEvent<PlayerEventsAddedParams>(data));
break;
case "Media.playerMessagesLogged":
_onPlayerMessagesLogged?.Invoke(_target.DeserializeEvent<PlayerMessagesLoggedParams>(data));
break;
case "Media.playerErrorsRaised":
_onPlayerErrorsRaised?.Invoke(_target.DeserializeEvent<PlayerErrorsRaisedParams>(data));
break;
case "Media.playersCreated":
_onPlayersCreated?.Invoke(_target.DeserializeEvent<PlayersCreatedParams>(data));
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
_onPlayerPropertiesChanged = null;
_onPlayerEventsAdded = null;
_onPlayerMessagesLogged = null;
_onPlayerErrorsRaised = null;
_onPlayersCreated = null;
}
}
