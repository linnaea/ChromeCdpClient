using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
[Experimental]public sealed partial class CacheStorageDomain {
private readonly ConnectedTarget _target;
public CacheStorageDomain(ConnectedTarget target) => _target = target;
public sealed partial class DeleteCacheParams {
/// <summary>
/// Id of cache for deletion.
/// </summary>
[JsonPropertyName("cacheId")]public CacheStorage.CacheId CacheId{get;set;}
}
/// <summary>
/// Deletes a cache.
/// </summary>
/// <param name="cacheId">Id of cache for deletion.</param>
public async Task DeleteCache(
 CacheStorage.CacheId @cacheId) {
var resp = await _target.SendRequest("CacheStorage.deleteCache",
new DeleteCacheParams {
CacheId=@cacheId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class DeleteEntryParams {
/// <summary>
/// Id of cache where the entry will be deleted.
/// </summary>
[JsonPropertyName("cacheId")]public CacheStorage.CacheId CacheId{get;set;}
/// <summary>
/// URL spec of the request.
/// </summary>
[JsonPropertyName("request")]public string Request{get;set;}
}
/// <summary>
/// Deletes a cache entry.
/// </summary>
/// <param name="cacheId">Id of cache where the entry will be deleted.</param>
/// <param name="request">URL spec of the request.</param>
public async Task DeleteEntry(
 CacheStorage.CacheId @cacheId,string @request) {
var resp = await _target.SendRequest("CacheStorage.deleteEntry",
new DeleteEntryParams {
CacheId=@cacheId,Request=@request,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class RequestCacheNamesParams {
/// <summary>
/// Security origin.
/// </summary>
[JsonPropertyName("securityOrigin")]public string SecurityOrigin{get;set;}
}
public sealed partial class RequestCacheNamesReturn {
/// <summary>
/// Caches for the security origin.
/// </summary>
[JsonPropertyName("caches")]public CacheStorage.Cache[] Caches{get;set;}
}
/// <summary>
/// Requests cache names.
/// </summary>
/// <param name="securityOrigin">Security origin.</param>
public async Task<RequestCacheNamesReturn> RequestCacheNames(
 string @securityOrigin) {
var resp = await _target.SendRequest("CacheStorage.requestCacheNames",
new RequestCacheNamesParams {
SecurityOrigin=@securityOrigin,});
return _target.DeserializeResponse<RequestCacheNamesReturn>(resp);
}
public sealed partial class RequestCachedResponseParams {
/// <summary>
/// Id of cache that contains the entry.
/// </summary>
[JsonPropertyName("cacheId")]public CacheStorage.CacheId CacheId{get;set;}
/// <summary>
/// URL spec of the request.
/// </summary>
[JsonPropertyName("requestURL")]public string RequestURL{get;set;}
/// <summary>
/// headers of the request.
/// </summary>
[JsonPropertyName("requestHeaders")]public CacheStorage.Header[] RequestHeaders{get;set;}
}
public sealed partial class RequestCachedResponseReturn {
/// <summary>
/// Response read from the cache.
/// </summary>
[JsonPropertyName("response")]public CacheStorage.CachedResponse Response{get;set;}
}
/// <summary>
/// Fetches cache entry.
/// </summary>
/// <param name="cacheId">Id of cache that contains the entry.</param>
/// <param name="requestURL">URL spec of the request.</param>
/// <param name="requestHeaders">headers of the request.</param>
public async Task<RequestCachedResponseReturn> RequestCachedResponse(
 CacheStorage.CacheId @cacheId,string @requestURL,CacheStorage.Header[] @requestHeaders) {
var resp = await _target.SendRequest("CacheStorage.requestCachedResponse",
new RequestCachedResponseParams {
CacheId=@cacheId,RequestURL=@requestURL,RequestHeaders=@requestHeaders,});
return _target.DeserializeResponse<RequestCachedResponseReturn>(resp);
}
public sealed partial class RequestEntriesParams {
/// <summary>
/// ID of cache to get entries from.
/// </summary>
[JsonPropertyName("cacheId")]public CacheStorage.CacheId CacheId{get;set;}
/// <summary>
/// Number of records to skip.
/// </summary>
[JsonPropertyName("skipCount")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? SkipCount{get;set;}
/// <summary>
/// Number of records to fetch.
/// </summary>
[JsonPropertyName("pageSize")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? PageSize{get;set;}
/// <summary>
/// If present, only return the entries containing this substring in the path
/// </summary>
[JsonPropertyName("pathFilter")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? PathFilter{get;set;}
}
public sealed partial class RequestEntriesReturn {
/// <summary>
/// Array of object store data entries.
/// </summary>
[JsonPropertyName("cacheDataEntries")]public CacheStorage.DataEntry[] CacheDataEntries{get;set;}
/// <summary>
/// Count of returned entries from this storage. If pathFilter is empty, it
/// is the count of all entries from this storage.
/// </summary>
[JsonPropertyName("returnCount")]public double ReturnCount{get;set;}
}
/// <summary>
/// Requests data from cache.
/// </summary>
/// <param name="cacheId">ID of cache to get entries from.</param>
/// <param name="skipCount">Number of records to skip.</param>
/// <param name="pageSize">Number of records to fetch.</param>
/// <param name="pathFilter">If present, only return the entries containing this substring in the path</param>
public async Task<RequestEntriesReturn> RequestEntries(
 CacheStorage.CacheId @cacheId,long? @skipCount=default,long? @pageSize=default,string? @pathFilter=default) {
var resp = await _target.SendRequest("CacheStorage.requestEntries",
new RequestEntriesParams {
CacheId=@cacheId,SkipCount=@skipCount,PageSize=@pageSize,PathFilter=@pathFilter,});
return _target.DeserializeResponse<RequestEntriesReturn>(resp);
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
