using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.IndexedDB;
/// <summary>
/// Object store index.
/// </summary>
public sealed partial class ObjectStoreIndex {
/// <summary>
/// Index name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Index key path.
/// </summary>
[JsonPropertyName("keyPath")]public KeyPath KeyPath{get;set;}
/// <summary>
/// If true, index is unique.
/// </summary>
[JsonPropertyName("unique")]public bool Unique{get;set;}
/// <summary>
/// If true, index allows multiple entries for a key.
/// </summary>
[JsonPropertyName("multiEntry")]public bool MultiEntry{get;set;}
}
