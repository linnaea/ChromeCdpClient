using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// This domain is deprecated.
/// </summary>
[Obsolete]public sealed partial class SchemaDomain {
private readonly ConnectedTarget _target;
public SchemaDomain(ConnectedTarget target) => _target = target;
public sealed partial class GetDomainsReturn {
/// <summary>
/// List of supported domains.
/// </summary>
[JsonPropertyName("domains")]public Schema.Domain[] Domains{get;set;}
}
/// <summary>
/// Returns supported domains.
/// </summary>
public async Task<GetDomainsReturn> GetDomains(
) {
var resp = await _target.SendRequest("Schema.getDomains",
VoidData.Instance);
return _target.DeserializeResponse<GetDomainsReturn>(resp);
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
