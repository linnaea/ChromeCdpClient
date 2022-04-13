using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// The SystemInfo domain defines methods and events for querying low-level system information.
/// </summary>
[Experimental]public sealed partial class SystemInfoDomain {
private readonly ConnectedTarget _target;
public SystemInfoDomain(ConnectedTarget target) => _target = target;
public sealed partial class GetInfoReturn {
/// <summary>
/// Information about the GPUs on the system.
/// </summary>
[JsonPropertyName("gpu")]public SystemInfo.GPUInfo Gpu{get;set;}
/// <summary>
/// A platform-dependent description of the model of the machine. On Mac OS, this is, for
/// example, 'MacBookPro'. Will be the empty string if not supported.
/// </summary>
[JsonPropertyName("modelName")]public string ModelName{get;set;}
/// <summary>
/// A platform-dependent description of the version of the machine. On Mac OS, this is, for
/// example, '10.1'. Will be the empty string if not supported.
/// </summary>
[JsonPropertyName("modelVersion")]public string ModelVersion{get;set;}
/// <summary>
/// The command line string used to launch the browser. Will be the empty string if not
/// supported.
/// </summary>
[JsonPropertyName("commandLine")]public string CommandLine{get;set;}
}
/// <summary>
/// Returns information about the system.
/// </summary>
public async Task<GetInfoReturn> GetInfo(
) {
var resp = await _target.SendRequest("SystemInfo.getInfo",
VoidData.Instance);
return _target.DeserializeResponse<GetInfoReturn>(resp);
}
public sealed partial class GetProcessInfoReturn {
/// <summary>
/// An array of process info blocks.
/// </summary>
[JsonPropertyName("processInfo")]public SystemInfo.ProcessInfo[] ProcessInfo{get;set;}
}
/// <summary>
/// Returns information about all running processes.
/// </summary>
public async Task<GetProcessInfoReturn> GetProcessInfo(
) {
var resp = await _target.SendRequest("SystemInfo.getProcessInfo",
VoidData.Instance);
return _target.DeserializeResponse<GetProcessInfoReturn>(resp);
}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
default:
_onUnknownEvent?.Invoke(method, data);
break;
}}
private Action<string, ArraySegment<byte>>? _onUnknownEvent;
public event Action<string, ArraySegment<byte>> OnUnknownEvent {
add => _onUnknownEvent += value; remove => _onUnknownEvent -= value;}
public void DisconnectEvents() {
_onUnknownEvent = null;
}
}
