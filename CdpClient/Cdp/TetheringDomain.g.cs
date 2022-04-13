using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// The Tethering domain defines methods and events for browser port binding.
/// </summary>
[Experimental]public sealed partial class TetheringDomain {
private readonly ConnectedTarget _target;
public TetheringDomain(ConnectedTarget target) => _target = target;
public sealed partial class BindParams {
/// <summary>
/// Port number to bind.
/// </summary>
[JsonPropertyName("port")]public long Port{get;set;}
}
/// <summary>
/// Request browser port binding.
/// </summary>
/// <param name="port">Port number to bind.</param>
public async Task Bind(
 long @port) {
var resp = await _target.SendRequest("Tethering.bind",
new BindParams {
Port=@port,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class UnbindParams {
/// <summary>
/// Port number to unbind.
/// </summary>
[JsonPropertyName("port")]public long Port{get;set;}
}
/// <summary>
/// Request browser port unbinding.
/// </summary>
/// <param name="port">Port number to unbind.</param>
public async Task Unbind(
 long @port) {
var resp = await _target.SendRequest("Tethering.unbind",
new UnbindParams {
Port=@port,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class AcceptedParams {
/// <summary>
/// Port number that was successfully bound.
/// </summary>
[JsonPropertyName("port")]public long Port{get;set;}
/// <summary>
/// Connection id to be used.
/// </summary>
[JsonPropertyName("connectionId")]public string ConnectionId{get;set;}
}
private Action<AcceptedParams>? _onAccepted;
/// <summary>
/// Informs that port was successfully bound and got a specified connection id.
/// </summary>
public event Action<AcceptedParams> OnAccepted {
add => _onAccepted += value; remove => _onAccepted -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Tethering.accepted":
_onAccepted?.Invoke(_target.DeserializeEvent<AcceptedParams>(data));
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
_onAccepted = null;
}
}
