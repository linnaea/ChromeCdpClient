using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.IndexedDB;
/// <summary>
/// Database with an array of object stores.
/// </summary>
public sealed partial class DatabaseWithObjectStores {
/// <summary>
/// Database name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Database version (type is not 'integer', as the standard
/// requires the version number to be 'unsigned long long')
/// </summary>
[JsonPropertyName("version")]public double Version{get;set;}
/// <summary>
/// Object stores in this database.
/// </summary>
[JsonPropertyName("objectStores")]public ObjectStore[] ObjectStores{get;set;}
}
