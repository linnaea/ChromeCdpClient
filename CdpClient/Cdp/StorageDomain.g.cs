using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
[Experimental]public sealed partial class StorageDomain {
private readonly ConnectedTarget _target;
public StorageDomain(ConnectedTarget target) => _target = target;
public sealed partial class ClearDataForOriginParams {
/// <summary>
/// Security origin.
/// </summary>
[JsonPropertyName("origin")]public string Origin{get;set;}
/// <summary>
/// Comma separated list of StorageType to clear.
/// </summary>
[JsonPropertyName("storageTypes")]public string StorageTypes{get;set;}
}
/// <summary>
/// Clears storage for origin.
/// </summary>
/// <param name="origin">Security origin.</param>
/// <param name="storageTypes">Comma separated list of StorageType to clear.</param>
public async Task ClearDataForOrigin(
 string @origin,string @storageTypes) {
var resp = await _target.SendRequest("Storage.clearDataForOrigin",
new ClearDataForOriginParams {
Origin=@origin,StorageTypes=@storageTypes,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetCookiesParams {
/// <summary>
/// Browser context to use when called on the browser endpoint.
/// </summary>
[JsonPropertyName("browserContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Browser.BrowserContextID? BrowserContextId{get;set;}
}
public sealed partial class GetCookiesReturn {
/// <summary>
/// Array of cookie objects.
/// </summary>
[JsonPropertyName("cookies")]public Network.Cookie[] Cookies{get;set;}
}
/// <summary>
/// Returns all browser cookies.
/// </summary>
/// <param name="browserContextId">Browser context to use when called on the browser endpoint.</param>
public async Task<GetCookiesReturn> GetCookies(
 Browser.BrowserContextID? @browserContextId=default) {
var resp = await _target.SendRequest("Storage.getCookies",
new GetCookiesParams {
BrowserContextId=@browserContextId,});
return _target.DeserializeResponse<GetCookiesReturn>(resp);
}
public sealed partial class SetCookiesParams {
/// <summary>
/// Cookies to be set.
/// </summary>
[JsonPropertyName("cookies")]public Network.CookieParam[] Cookies{get;set;}
/// <summary>
/// Browser context to use when called on the browser endpoint.
/// </summary>
[JsonPropertyName("browserContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Browser.BrowserContextID? BrowserContextId{get;set;}
}
/// <summary>
/// Sets given cookies.
/// </summary>
/// <param name="cookies">Cookies to be set.</param>
/// <param name="browserContextId">Browser context to use when called on the browser endpoint.</param>
public async Task SetCookies(
 Network.CookieParam[] @cookies,Browser.BrowserContextID? @browserContextId=default) {
var resp = await _target.SendRequest("Storage.setCookies",
new SetCookiesParams {
Cookies=@cookies,BrowserContextId=@browserContextId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class ClearCookiesParams {
/// <summary>
/// Browser context to use when called on the browser endpoint.
/// </summary>
[JsonPropertyName("browserContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Browser.BrowserContextID? BrowserContextId{get;set;}
}
/// <summary>
/// Clears cookies.
/// </summary>
/// <param name="browserContextId">Browser context to use when called on the browser endpoint.</param>
public async Task ClearCookies(
 Browser.BrowserContextID? @browserContextId=default) {
var resp = await _target.SendRequest("Storage.clearCookies",
new ClearCookiesParams {
BrowserContextId=@browserContextId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetUsageAndQuotaParams {
/// <summary>
/// Security origin.
/// </summary>
[JsonPropertyName("origin")]public string Origin{get;set;}
}
public sealed partial class GetUsageAndQuotaReturn {
/// <summary>
/// Storage usage (bytes).
/// </summary>
[JsonPropertyName("usage")]public double Usage{get;set;}
/// <summary>
/// Storage quota (bytes).
/// </summary>
[JsonPropertyName("quota")]public double Quota{get;set;}
/// <summary>
/// Whether or not the origin has an active storage quota override
/// </summary>
[JsonPropertyName("overrideActive")]public bool OverrideActive{get;set;}
/// <summary>
/// Storage usage per type (bytes).
/// </summary>
[JsonPropertyName("usageBreakdown")]public Storage.UsageForType[] UsageBreakdown{get;set;}
}
/// <summary>
/// Returns usage and quota in bytes.
/// </summary>
/// <param name="origin">Security origin.</param>
public async Task<GetUsageAndQuotaReturn> GetUsageAndQuota(
 string @origin) {
var resp = await _target.SendRequest("Storage.getUsageAndQuota",
new GetUsageAndQuotaParams {
Origin=@origin,});
return _target.DeserializeResponse<GetUsageAndQuotaReturn>(resp);
}
public sealed partial class OverrideQuotaForOriginParams {
/// <summary>
/// Security origin.
/// </summary>
[JsonPropertyName("origin")]public string Origin{get;set;}
/// <summary>
/// The quota size (in bytes) to override the original quota with.
/// If this is called multiple times, the overridden quota will be equal to
/// the quotaSize provided in the final call. If this is called without
/// specifying a quotaSize, the quota will be reset to the default value for
/// the specified origin. If this is called multiple times with different
/// origins, the override will be maintained for each origin until it is
/// disabled (called without a quotaSize).
/// </summary>
[JsonPropertyName("quotaSize")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? QuotaSize{get;set;}
}
/// <summary>
/// Override quota for the specified origin
/// </summary>
/// <param name="origin">Security origin.</param>
/// <param name="quotaSize">The quota size (in bytes) to override the original quota with.
/// If this is called multiple times, the overridden quota will be equal to
/// the quotaSize provided in the final call. If this is called without
/// specifying a quotaSize, the quota will be reset to the default value for
/// the specified origin. If this is called multiple times with different
/// origins, the override will be maintained for each origin until it is
/// disabled (called without a quotaSize).</param>
[Experimental]public async Task OverrideQuotaForOrigin(
 string @origin,double? @quotaSize=default) {
var resp = await _target.SendRequest("Storage.overrideQuotaForOrigin",
new OverrideQuotaForOriginParams {
Origin=@origin,QuotaSize=@quotaSize,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class TrackCacheStorageForOriginParams {
/// <summary>
/// Security origin.
/// </summary>
[JsonPropertyName("origin")]public string Origin{get;set;}
}
/// <summary>
/// Registers origin to be notified when an update occurs to its cache storage list.
/// </summary>
/// <param name="origin">Security origin.</param>
public async Task TrackCacheStorageForOrigin(
 string @origin) {
var resp = await _target.SendRequest("Storage.trackCacheStorageForOrigin",
new TrackCacheStorageForOriginParams {
Origin=@origin,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class TrackIndexedDBForOriginParams {
/// <summary>
/// Security origin.
/// </summary>
[JsonPropertyName("origin")]public string Origin{get;set;}
}
/// <summary>
/// Registers origin to be notified when an update occurs to its IndexedDB.
/// </summary>
/// <param name="origin">Security origin.</param>
public async Task TrackIndexedDBForOrigin(
 string @origin) {
var resp = await _target.SendRequest("Storage.trackIndexedDBForOrigin",
new TrackIndexedDBForOriginParams {
Origin=@origin,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class UntrackCacheStorageForOriginParams {
/// <summary>
/// Security origin.
/// </summary>
[JsonPropertyName("origin")]public string Origin{get;set;}
}
/// <summary>
/// Unregisters origin from receiving notifications for cache storage.
/// </summary>
/// <param name="origin">Security origin.</param>
public async Task UntrackCacheStorageForOrigin(
 string @origin) {
var resp = await _target.SendRequest("Storage.untrackCacheStorageForOrigin",
new UntrackCacheStorageForOriginParams {
Origin=@origin,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class UntrackIndexedDBForOriginParams {
/// <summary>
/// Security origin.
/// </summary>
[JsonPropertyName("origin")]public string Origin{get;set;}
}
/// <summary>
/// Unregisters origin from receiving notifications for IndexedDB.
/// </summary>
/// <param name="origin">Security origin.</param>
public async Task UntrackIndexedDBForOrigin(
 string @origin) {
var resp = await _target.SendRequest("Storage.untrackIndexedDBForOrigin",
new UntrackIndexedDBForOriginParams {
Origin=@origin,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetTrustTokensReturn {
[JsonPropertyName("tokens")]public Storage.TrustTokens[] Tokens{get;set;}
}
/// <summary>
/// Returns the number of stored Trust Tokens per issuer for the
/// current browsing context.
/// </summary>
[Experimental]public async Task<GetTrustTokensReturn> GetTrustTokens(
) {
var resp = await _target.SendRequest("Storage.getTrustTokens",
VoidData.Instance);
return _target.DeserializeResponse<GetTrustTokensReturn>(resp);
}
public sealed partial class ClearTrustTokensParams {
[JsonPropertyName("issuerOrigin")]public string IssuerOrigin{get;set;}
}
public sealed partial class ClearTrustTokensReturn {
/// <summary>
/// True if any tokens were deleted, false otherwise.
/// </summary>
[JsonPropertyName("didDeleteTokens")]public bool DidDeleteTokens{get;set;}
}
/// <summary>
/// Removes all Trust Tokens issued by the provided issuerOrigin.
/// Leaves other stored data, including the issuer's Redemption Records, intact.
/// </summary>
/// <param name="issuerOrigin"></param>
[Experimental]public async Task<ClearTrustTokensReturn> ClearTrustTokens(
 string @issuerOrigin) {
var resp = await _target.SendRequest("Storage.clearTrustTokens",
new ClearTrustTokensParams {
IssuerOrigin=@issuerOrigin,});
return _target.DeserializeResponse<ClearTrustTokensReturn>(resp);
}
public sealed partial class GetInterestGroupDetailsParams {
[JsonPropertyName("ownerOrigin")]public string OwnerOrigin{get;set;}
[JsonPropertyName("name")]public string Name{get;set;}
}
public sealed partial class GetInterestGroupDetailsReturn {
[JsonPropertyName("details")]public Storage.InterestGroupDetails Details{get;set;}
}
/// <summary>
/// Gets details for a named interest group.
/// </summary>
/// <param name="ownerOrigin"></param>
/// <param name="name"></param>
[Experimental]public async Task<GetInterestGroupDetailsReturn> GetInterestGroupDetails(
 string @ownerOrigin,string @name) {
var resp = await _target.SendRequest("Storage.getInterestGroupDetails",
new GetInterestGroupDetailsParams {
OwnerOrigin=@ownerOrigin,Name=@name,});
return _target.DeserializeResponse<GetInterestGroupDetailsReturn>(resp);
}
public sealed partial class SetInterestGroupTrackingParams {
[JsonPropertyName("enable")]public bool Enable{get;set;}
}
/// <summary>
/// Enables/Disables issuing of interestGroupAccessed events.
/// </summary>
/// <param name="enable"></param>
[Experimental]public async Task SetInterestGroupTracking(
 bool @enable) {
var resp = await _target.SendRequest("Storage.setInterestGroupTracking",
new SetInterestGroupTrackingParams {
Enable=@enable,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class CacheStorageContentUpdatedParams {
/// <summary>
/// Origin to update.
/// </summary>
[JsonPropertyName("origin")]public string Origin{get;set;}
/// <summary>
/// Name of cache in origin.
/// </summary>
[JsonPropertyName("cacheName")]public string CacheName{get;set;}
}
private Action<CacheStorageContentUpdatedParams>? _onCacheStorageContentUpdated;
/// <summary>
/// A cache's contents have been modified.
/// </summary>
public event Action<CacheStorageContentUpdatedParams> OnCacheStorageContentUpdated {
add => _onCacheStorageContentUpdated += value; remove => _onCacheStorageContentUpdated -= value;}
public sealed partial class CacheStorageListUpdatedParams {
/// <summary>
/// Origin to update.
/// </summary>
[JsonPropertyName("origin")]public string Origin{get;set;}
}
private Action<CacheStorageListUpdatedParams>? _onCacheStorageListUpdated;
/// <summary>
/// A cache has been added/deleted.
/// </summary>
public event Action<CacheStorageListUpdatedParams> OnCacheStorageListUpdated {
add => _onCacheStorageListUpdated += value; remove => _onCacheStorageListUpdated -= value;}
public sealed partial class IndexedDBContentUpdatedParams {
/// <summary>
/// Origin to update.
/// </summary>
[JsonPropertyName("origin")]public string Origin{get;set;}
/// <summary>
/// Database to update.
/// </summary>
[JsonPropertyName("databaseName")]public string DatabaseName{get;set;}
/// <summary>
/// ObjectStore to update.
/// </summary>
[JsonPropertyName("objectStoreName")]public string ObjectStoreName{get;set;}
}
private Action<IndexedDBContentUpdatedParams>? _onIndexedDBContentUpdated;
/// <summary>
/// The origin's IndexedDB object store has been modified.
/// </summary>
public event Action<IndexedDBContentUpdatedParams> OnIndexedDBContentUpdated {
add => _onIndexedDBContentUpdated += value; remove => _onIndexedDBContentUpdated -= value;}
public sealed partial class IndexedDBListUpdatedParams {
/// <summary>
/// Origin to update.
/// </summary>
[JsonPropertyName("origin")]public string Origin{get;set;}
}
private Action<IndexedDBListUpdatedParams>? _onIndexedDBListUpdated;
/// <summary>
/// The origin's IndexedDB database list has been modified.
/// </summary>
public event Action<IndexedDBListUpdatedParams> OnIndexedDBListUpdated {
add => _onIndexedDBListUpdated += value; remove => _onIndexedDBListUpdated -= value;}
public sealed partial class InterestGroupAccessedParams {
[JsonPropertyName("accessTime")]public Network.TimeSinceEpoch AccessTime{get;set;}
[JsonPropertyName("type")]public Storage.InterestGroupAccessType Type{get;set;}
[JsonPropertyName("ownerOrigin")]public string OwnerOrigin{get;set;}
[JsonPropertyName("name")]public string Name{get;set;}
}
private Action<InterestGroupAccessedParams>? _onInterestGroupAccessed;
/// <summary>
/// One of the interest groups was accessed by the associated page.
/// </summary>
public event Action<InterestGroupAccessedParams> OnInterestGroupAccessed {
add => _onInterestGroupAccessed += value; remove => _onInterestGroupAccessed -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Storage.cacheStorageContentUpdated":
_onCacheStorageContentUpdated?.Invoke(_target.DeserializeEvent<CacheStorageContentUpdatedParams>(data));
break;
case "Storage.cacheStorageListUpdated":
_onCacheStorageListUpdated?.Invoke(_target.DeserializeEvent<CacheStorageListUpdatedParams>(data));
break;
case "Storage.indexedDBContentUpdated":
_onIndexedDBContentUpdated?.Invoke(_target.DeserializeEvent<IndexedDBContentUpdatedParams>(data));
break;
case "Storage.indexedDBListUpdated":
_onIndexedDBListUpdated?.Invoke(_target.DeserializeEvent<IndexedDBListUpdatedParams>(data));
break;
case "Storage.interestGroupAccessed":
_onInterestGroupAccessed?.Invoke(_target.DeserializeEvent<InterestGroupAccessedParams>(data));
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
_onCacheStorageContentUpdated = null;
_onCacheStorageListUpdated = null;
_onIndexedDBContentUpdated = null;
_onIndexedDBListUpdated = null;
_onInterestGroupAccessed = null;
}
}
