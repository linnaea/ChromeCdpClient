using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
[Experimental]public sealed partial class IndexedDBDomain {
private readonly ConnectedTarget _target;
public IndexedDBDomain(ConnectedTarget target) => _target = target;
public sealed partial class ClearObjectStoreParams {
/// <summary>
/// Security origin.
/// </summary>
[JsonPropertyName("securityOrigin")]public string SecurityOrigin{get;set;}
/// <summary>
/// Database name.
/// </summary>
[JsonPropertyName("databaseName")]public string DatabaseName{get;set;}
/// <summary>
/// Object store name.
/// </summary>
[JsonPropertyName("objectStoreName")]public string ObjectStoreName{get;set;}
}
/// <summary>
/// Clears all entries from an object store.
/// </summary>
/// <param name="securityOrigin">Security origin.</param>
/// <param name="databaseName">Database name.</param>
/// <param name="objectStoreName">Object store name.</param>
public async Task ClearObjectStore(
 string @securityOrigin,string @databaseName,string @objectStoreName) {
var resp = await _target.SendRequest("IndexedDB.clearObjectStore",
new ClearObjectStoreParams {
SecurityOrigin=@securityOrigin,DatabaseName=@databaseName,ObjectStoreName=@objectStoreName,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class DeleteDatabaseParams {
/// <summary>
/// Security origin.
/// </summary>
[JsonPropertyName("securityOrigin")]public string SecurityOrigin{get;set;}
/// <summary>
/// Database name.
/// </summary>
[JsonPropertyName("databaseName")]public string DatabaseName{get;set;}
}
/// <summary>
/// Deletes a database.
/// </summary>
/// <param name="securityOrigin">Security origin.</param>
/// <param name="databaseName">Database name.</param>
public async Task DeleteDatabase(
 string @securityOrigin,string @databaseName) {
var resp = await _target.SendRequest("IndexedDB.deleteDatabase",
new DeleteDatabaseParams {
SecurityOrigin=@securityOrigin,DatabaseName=@databaseName,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class DeleteObjectStoreEntriesParams {
[JsonPropertyName("securityOrigin")]public string SecurityOrigin{get;set;}
[JsonPropertyName("databaseName")]public string DatabaseName{get;set;}
[JsonPropertyName("objectStoreName")]public string ObjectStoreName{get;set;}
/// <summary>
/// Range of entry keys to delete
/// </summary>
[JsonPropertyName("keyRange")]public IndexedDB.KeyRange KeyRange{get;set;}
}
/// <summary>
/// Delete a range of entries from an object store
/// </summary>
/// <param name="securityOrigin"></param>
/// <param name="databaseName"></param>
/// <param name="objectStoreName"></param>
/// <param name="keyRange">Range of entry keys to delete</param>
public async Task DeleteObjectStoreEntries(
 string @securityOrigin,string @databaseName,string @objectStoreName,IndexedDB.KeyRange @keyRange) {
var resp = await _target.SendRequest("IndexedDB.deleteObjectStoreEntries",
new DeleteObjectStoreEntriesParams {
SecurityOrigin=@securityOrigin,DatabaseName=@databaseName,ObjectStoreName=@objectStoreName,KeyRange=@keyRange,});
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Disables events from backend.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("IndexedDB.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Enables events from backend.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("IndexedDB.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class RequestDataParams {
/// <summary>
/// Security origin.
/// </summary>
[JsonPropertyName("securityOrigin")]public string SecurityOrigin{get;set;}
/// <summary>
/// Database name.
/// </summary>
[JsonPropertyName("databaseName")]public string DatabaseName{get;set;}
/// <summary>
/// Object store name.
/// </summary>
[JsonPropertyName("objectStoreName")]public string ObjectStoreName{get;set;}
/// <summary>
/// Index name, empty string for object store data requests.
/// </summary>
[JsonPropertyName("indexName")]public string IndexName{get;set;}
/// <summary>
/// Number of records to skip.
/// </summary>
[JsonPropertyName("skipCount")]public long SkipCount{get;set;}
/// <summary>
/// Number of records to fetch.
/// </summary>
[JsonPropertyName("pageSize")]public long PageSize{get;set;}
/// <summary>
/// Key range.
/// </summary>
[JsonPropertyName("keyRange")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public IndexedDB.KeyRange? KeyRange{get;set;}
}
public sealed partial class RequestDataReturn {
/// <summary>
/// Array of object store data entries.
/// </summary>
[JsonPropertyName("objectStoreDataEntries")]public IndexedDB.DataEntry[] ObjectStoreDataEntries{get;set;}
/// <summary>
/// If true, there are more entries to fetch in the given range.
/// </summary>
[JsonPropertyName("hasMore")]public bool HasMore{get;set;}
}
/// <summary>
/// Requests data from object store or index.
/// </summary>
/// <param name="securityOrigin">Security origin.</param>
/// <param name="databaseName">Database name.</param>
/// <param name="objectStoreName">Object store name.</param>
/// <param name="indexName">Index name, empty string for object store data requests.</param>
/// <param name="skipCount">Number of records to skip.</param>
/// <param name="pageSize">Number of records to fetch.</param>
/// <param name="keyRange">Key range.</param>
public async Task<RequestDataReturn> RequestData(
 string @securityOrigin,string @databaseName,string @objectStoreName,string @indexName,long @skipCount,long @pageSize,IndexedDB.KeyRange? @keyRange=default) {
var resp = await _target.SendRequest("IndexedDB.requestData",
new RequestDataParams {
SecurityOrigin=@securityOrigin,DatabaseName=@databaseName,ObjectStoreName=@objectStoreName,IndexName=@indexName,SkipCount=@skipCount,PageSize=@pageSize,KeyRange=@keyRange,});
return _target.DeserializeResponse<RequestDataReturn>(resp);
}
public sealed partial class GetMetadataParams {
/// <summary>
/// Security origin.
/// </summary>
[JsonPropertyName("securityOrigin")]public string SecurityOrigin{get;set;}
/// <summary>
/// Database name.
/// </summary>
[JsonPropertyName("databaseName")]public string DatabaseName{get;set;}
/// <summary>
/// Object store name.
/// </summary>
[JsonPropertyName("objectStoreName")]public string ObjectStoreName{get;set;}
}
public sealed partial class GetMetadataReturn {
/// <summary>
/// the entries count
/// </summary>
[JsonPropertyName("entriesCount")]public double EntriesCount{get;set;}
/// <summary>
/// the current value of key generator, to become the next inserted
/// key into the object store. Valid if objectStore.autoIncrement
/// is true.
/// </summary>
[JsonPropertyName("keyGeneratorValue")]public double KeyGeneratorValue{get;set;}
}
/// <summary>
/// Gets metadata of an object store
/// </summary>
/// <param name="securityOrigin">Security origin.</param>
/// <param name="databaseName">Database name.</param>
/// <param name="objectStoreName">Object store name.</param>
public async Task<GetMetadataReturn> GetMetadata(
 string @securityOrigin,string @databaseName,string @objectStoreName) {
var resp = await _target.SendRequest("IndexedDB.getMetadata",
new GetMetadataParams {
SecurityOrigin=@securityOrigin,DatabaseName=@databaseName,ObjectStoreName=@objectStoreName,});
return _target.DeserializeResponse<GetMetadataReturn>(resp);
}
public sealed partial class RequestDatabaseParams {
/// <summary>
/// Security origin.
/// </summary>
[JsonPropertyName("securityOrigin")]public string SecurityOrigin{get;set;}
/// <summary>
/// Database name.
/// </summary>
[JsonPropertyName("databaseName")]public string DatabaseName{get;set;}
}
public sealed partial class RequestDatabaseReturn {
/// <summary>
/// Database with an array of object stores.
/// </summary>
[JsonPropertyName("databaseWithObjectStores")]public IndexedDB.DatabaseWithObjectStores DatabaseWithObjectStores{get;set;}
}
/// <summary>
/// Requests database with given name in given frame.
/// </summary>
/// <param name="securityOrigin">Security origin.</param>
/// <param name="databaseName">Database name.</param>
public async Task<RequestDatabaseReturn> RequestDatabase(
 string @securityOrigin,string @databaseName) {
var resp = await _target.SendRequest("IndexedDB.requestDatabase",
new RequestDatabaseParams {
SecurityOrigin=@securityOrigin,DatabaseName=@databaseName,});
return _target.DeserializeResponse<RequestDatabaseReturn>(resp);
}
public sealed partial class RequestDatabaseNamesParams {
/// <summary>
/// Security origin.
/// </summary>
[JsonPropertyName("securityOrigin")]public string SecurityOrigin{get;set;}
}
public sealed partial class RequestDatabaseNamesReturn {
/// <summary>
/// Database names for origin.
/// </summary>
[JsonPropertyName("databaseNames")]public string[] DatabaseNames{get;set;}
}
/// <summary>
/// Requests database names for given security origin.
/// </summary>
/// <param name="securityOrigin">Security origin.</param>
public async Task<RequestDatabaseNamesReturn> RequestDatabaseNames(
 string @securityOrigin) {
var resp = await _target.SendRequest("IndexedDB.requestDatabaseNames",
new RequestDatabaseNamesParams {
SecurityOrigin=@securityOrigin,});
return _target.DeserializeResponse<RequestDatabaseNamesReturn>(resp);
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
