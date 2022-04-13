using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.IndexedDB;
/// <summary>
/// Object store.
/// </summary>
public sealed partial class ObjectStore {
/// <summary>
/// Object store name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Object store key path.
/// </summary>
[JsonPropertyName("keyPath")]public KeyPath KeyPath{get;set;}
/// <summary>
/// If true, object store has auto increment flag set.
/// </summary>
[JsonPropertyName("autoIncrement")]public bool AutoIncrement{get;set;}
/// <summary>
/// Indexes in this object store.
/// </summary>
[JsonPropertyName("indexes")]public ObjectStoreIndex[] Indexes{get;set;}
}
