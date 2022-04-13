using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// Query and modify DOM storage.
/// </summary>
[Experimental]public sealed partial class DOMStorageDomain {
private readonly ConnectedTarget _target;
public DOMStorageDomain(ConnectedTarget target) => _target = target;
public sealed partial class ClearParams {
[JsonPropertyName("storageId")]public DOMStorage.StorageId StorageId{get;set;}
}
/// <param name="storageId"></param>
public async Task Clear(
 DOMStorage.StorageId @storageId) {
var resp = await _target.SendRequest("DOMStorage.clear",
new ClearParams {
StorageId=@storageId,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Disables storage tracking, prevents storage events from being sent to the client.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("DOMStorage.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Enables storage tracking, storage events will now be delivered to the client.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("DOMStorage.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetDOMStorageItemsParams {
[JsonPropertyName("storageId")]public DOMStorage.StorageId StorageId{get;set;}
}
public sealed partial class GetDOMStorageItemsReturn {
[JsonPropertyName("entries")]public DOMStorage.Item[] Entries{get;set;}
}
/// <param name="storageId"></param>
public async Task<GetDOMStorageItemsReturn> GetDOMStorageItems(
 DOMStorage.StorageId @storageId) {
var resp = await _target.SendRequest("DOMStorage.getDOMStorageItems",
new GetDOMStorageItemsParams {
StorageId=@storageId,});
return _target.DeserializeResponse<GetDOMStorageItemsReturn>(resp);
}
public sealed partial class RemoveDOMStorageItemParams {
[JsonPropertyName("storageId")]public DOMStorage.StorageId StorageId{get;set;}
[JsonPropertyName("key")]public string Key{get;set;}
}
/// <param name="storageId"></param>
/// <param name="key"></param>
public async Task RemoveDOMStorageItem(
 DOMStorage.StorageId @storageId,string @key) {
var resp = await _target.SendRequest("DOMStorage.removeDOMStorageItem",
new RemoveDOMStorageItemParams {
StorageId=@storageId,Key=@key,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetDOMStorageItemParams {
[JsonPropertyName("storageId")]public DOMStorage.StorageId StorageId{get;set;}
[JsonPropertyName("key")]public string Key{get;set;}
[JsonPropertyName("value")]public string Value{get;set;}
}
/// <param name="storageId"></param>
/// <param name="key"></param>
/// <param name="value"></param>
public async Task SetDOMStorageItem(
 DOMStorage.StorageId @storageId,string @key,string @value) {
var resp = await _target.SendRequest("DOMStorage.setDOMStorageItem",
new SetDOMStorageItemParams {
StorageId=@storageId,Key=@key,Value=@value,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class DomStorageItemAddedParams {
[JsonPropertyName("storageId")]public DOMStorage.StorageId StorageId{get;set;}
[JsonPropertyName("key")]public string Key{get;set;}
[JsonPropertyName("newValue")]public string NewValue{get;set;}
}
private Action<DomStorageItemAddedParams>? _onDomStorageItemAdded;
public event Action<DomStorageItemAddedParams> OnDomStorageItemAdded {
add => _onDomStorageItemAdded += value; remove => _onDomStorageItemAdded -= value;}
public sealed partial class DomStorageItemRemovedParams {
[JsonPropertyName("storageId")]public DOMStorage.StorageId StorageId{get;set;}
[JsonPropertyName("key")]public string Key{get;set;}
}
private Action<DomStorageItemRemovedParams>? _onDomStorageItemRemoved;
public event Action<DomStorageItemRemovedParams> OnDomStorageItemRemoved {
add => _onDomStorageItemRemoved += value; remove => _onDomStorageItemRemoved -= value;}
public sealed partial class DomStorageItemUpdatedParams {
[JsonPropertyName("storageId")]public DOMStorage.StorageId StorageId{get;set;}
[JsonPropertyName("key")]public string Key{get;set;}
[JsonPropertyName("oldValue")]public string OldValue{get;set;}
[JsonPropertyName("newValue")]public string NewValue{get;set;}
}
private Action<DomStorageItemUpdatedParams>? _onDomStorageItemUpdated;
public event Action<DomStorageItemUpdatedParams> OnDomStorageItemUpdated {
add => _onDomStorageItemUpdated += value; remove => _onDomStorageItemUpdated -= value;}
public sealed partial class DomStorageItemsClearedParams {
[JsonPropertyName("storageId")]public DOMStorage.StorageId StorageId{get;set;}
}
private Action<DomStorageItemsClearedParams>? _onDomStorageItemsCleared;
public event Action<DomStorageItemsClearedParams> OnDomStorageItemsCleared {
add => _onDomStorageItemsCleared += value; remove => _onDomStorageItemsCleared -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "DOMStorage.domStorageItemAdded":
_onDomStorageItemAdded?.Invoke(_target.DeserializeEvent<DomStorageItemAddedParams>(data));
break;
case "DOMStorage.domStorageItemRemoved":
_onDomStorageItemRemoved?.Invoke(_target.DeserializeEvent<DomStorageItemRemovedParams>(data));
break;
case "DOMStorage.domStorageItemUpdated":
_onDomStorageItemUpdated?.Invoke(_target.DeserializeEvent<DomStorageItemUpdatedParams>(data));
break;
case "DOMStorage.domStorageItemsCleared":
_onDomStorageItemsCleared?.Invoke(_target.DeserializeEvent<DomStorageItemsClearedParams>(data));
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
_onDomStorageItemAdded = null;
_onDomStorageItemRemoved = null;
_onDomStorageItemUpdated = null;
_onDomStorageItemsCleared = null;
}
}
