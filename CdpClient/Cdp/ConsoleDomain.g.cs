using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// This domain is deprecated - use Runtime or Log instead.
/// </summary>
[Obsolete]public sealed partial class ConsoleDomain {
private readonly ConnectedTarget _target;
public ConsoleDomain(ConnectedTarget target) => _target = target;
/// <summary>
/// Does nothing.
/// </summary>
public async Task ClearMessages(
) {
var resp = await _target.SendRequest("Console.clearMessages",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Disables console domain, prevents further console messages from being reported to the client.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("Console.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Enables console domain, sends the messages collected so far to the client by means of the
/// `messageAdded` notification.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("Console.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class MessageAddedParams {
/// <summary>
/// Console message that has been added.
/// </summary>
[JsonPropertyName("message")]public Console.ConsoleMessage Message{get;set;}
}
private Action<MessageAddedParams>? _onMessageAdded;
/// <summary>
/// Issued when new console message is added.
/// </summary>
public event Action<MessageAddedParams> OnMessageAdded {
add => _onMessageAdded += value; remove => _onMessageAdded -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Console.messageAdded":
_onMessageAdded?.Invoke(_target.DeserializeEvent<MessageAddedParams>(data));
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
_onMessageAdded = null;
}
}
