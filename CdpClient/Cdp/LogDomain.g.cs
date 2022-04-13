using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// Provides access to log entries.
/// </summary>
public sealed partial class LogDomain {
private readonly ConnectedTarget _target;
public LogDomain(ConnectedTarget target) => _target = target;
/// <summary>
/// Clears the log.
/// </summary>
public async Task Clear(
) {
var resp = await _target.SendRequest("Log.clear",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Disables log domain, prevents further log entries from being reported to the client.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("Log.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Enables log domain, sends the entries collected so far to the client by means of the
/// `entryAdded` notification.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("Log.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class StartViolationsReportParams {
/// <summary>
/// Configuration for violations.
/// </summary>
[JsonPropertyName("config")]public Log.ViolationSetting[] Config{get;set;}
}
/// <summary>
/// start violation reporting.
/// </summary>
/// <param name="config">Configuration for violations.</param>
public async Task StartViolationsReport(
 Log.ViolationSetting[] @config) {
var resp = await _target.SendRequest("Log.startViolationsReport",
new StartViolationsReportParams {
Config=@config,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Stop violation reporting.
/// </summary>
public async Task StopViolationsReport(
) {
var resp = await _target.SendRequest("Log.stopViolationsReport",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class EntryAddedParams {
/// <summary>
/// The entry.
/// </summary>
[JsonPropertyName("entry")]public Log.LogEntry Entry{get;set;}
}
private Action<EntryAddedParams>? _onEntryAdded;
/// <summary>
/// Issued when new message was logged.
/// </summary>
public event Action<EntryAddedParams> OnEntryAdded {
add => _onEntryAdded += value; remove => _onEntryAdded -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Log.entryAdded":
_onEntryAdded?.Invoke(_target.DeserializeEvent<EntryAddedParams>(data));
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
_onEntryAdded = null;
}
}
