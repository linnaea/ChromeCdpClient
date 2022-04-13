using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
[Experimental]public sealed partial class DatabaseDomain {
private readonly ConnectedTarget _target;
public DatabaseDomain(ConnectedTarget target) => _target = target;
/// <summary>
/// Disables database tracking, prevents database events from being sent to the client.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("Database.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Enables database tracking, database events will now be delivered to the client.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("Database.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class ExecuteSQLParams {
[JsonPropertyName("databaseId")]public Database.DatabaseId DatabaseId{get;set;}
[JsonPropertyName("query")]public string Query{get;set;}
}
public sealed partial class ExecuteSQLReturn {
[JsonPropertyName("columnNames")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string[]? ColumnNames{get;set;}
[JsonPropertyName("values")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public object[]? Values{get;set;}
[JsonPropertyName("sqlError")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Database.Error? SqlError{get;set;}
}
/// <param name="databaseId"></param>
/// <param name="query"></param>
public async Task<ExecuteSQLReturn> ExecuteSQL(
 Database.DatabaseId @databaseId,string @query) {
var resp = await _target.SendRequest("Database.executeSQL",
new ExecuteSQLParams {
DatabaseId=@databaseId,Query=@query,});
return _target.DeserializeResponse<ExecuteSQLReturn>(resp);
}
public sealed partial class GetDatabaseTableNamesParams {
[JsonPropertyName("databaseId")]public Database.DatabaseId DatabaseId{get;set;}
}
public sealed partial class GetDatabaseTableNamesReturn {
[JsonPropertyName("tableNames")]public string[] TableNames{get;set;}
}
/// <param name="databaseId"></param>
public async Task<GetDatabaseTableNamesReturn> GetDatabaseTableNames(
 Database.DatabaseId @databaseId) {
var resp = await _target.SendRequest("Database.getDatabaseTableNames",
new GetDatabaseTableNamesParams {
DatabaseId=@databaseId,});
return _target.DeserializeResponse<GetDatabaseTableNamesReturn>(resp);
}
public sealed partial class AddDatabaseParams {
[JsonPropertyName("database")]public Database.Database Database{get;set;}
}
private Action<AddDatabaseParams>? _onAddDatabase;
public event Action<AddDatabaseParams> OnAddDatabase {
add => _onAddDatabase += value; remove => _onAddDatabase -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Database.addDatabase":
_onAddDatabase?.Invoke(_target.DeserializeEvent<AddDatabaseParams>(data));
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
_onAddDatabase = null;
}
}
