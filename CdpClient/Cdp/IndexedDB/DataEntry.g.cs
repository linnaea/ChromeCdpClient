using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.IndexedDB;
/// <summary>
/// Data entry.
/// </summary>
public sealed partial class DataEntry {
/// <summary>
/// Key object.
/// </summary>
[JsonPropertyName("key")]public Runtime.RemoteObject Key{get;set;}
/// <summary>
/// Primary key object.
/// </summary>
[JsonPropertyName("primaryKey")]public Runtime.RemoteObject PrimaryKey{get;set;}
/// <summary>
/// Value object.
/// </summary>
[JsonPropertyName("value")]public Runtime.RemoteObject Value{get;set;}
}
