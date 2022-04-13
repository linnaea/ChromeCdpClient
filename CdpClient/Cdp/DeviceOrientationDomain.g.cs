using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
[Experimental]public sealed partial class DeviceOrientationDomain {
private readonly ConnectedTarget _target;
public DeviceOrientationDomain(ConnectedTarget target) => _target = target;
/// <summary>
/// Clears the overridden Device Orientation.
/// </summary>
public async Task ClearDeviceOrientationOverride(
) {
var resp = await _target.SendRequest("DeviceOrientation.clearDeviceOrientationOverride",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetDeviceOrientationOverrideParams {
/// <summary>
/// Mock alpha
/// </summary>
[JsonPropertyName("alpha")]public double Alpha{get;set;}
/// <summary>
/// Mock beta
/// </summary>
[JsonPropertyName("beta")]public double Beta{get;set;}
/// <summary>
/// Mock gamma
/// </summary>
[JsonPropertyName("gamma")]public double Gamma{get;set;}
}
/// <summary>
/// Overrides the Device Orientation.
/// </summary>
/// <param name="alpha">Mock alpha</param>
/// <param name="beta">Mock beta</param>
/// <param name="gamma">Mock gamma</param>
public async Task SetDeviceOrientationOverride(
 double @alpha,double @beta,double @gamma) {
var resp = await _target.SendRequest("DeviceOrientation.setDeviceOrientationOverride",
new SetDeviceOrientationOverrideParams {
Alpha=@alpha,Beta=@beta,Gamma=@gamma,});
_target.DeserializeResponse<VoidData>(resp);
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
