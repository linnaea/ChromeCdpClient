using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Storage;
/// <summary>
/// Usage for a storage type.
/// </summary>
public sealed partial class UsageForType {
/// <summary>
/// Name of storage type.
/// </summary>
[JsonPropertyName("storageType")]public StorageType StorageType{get;set;}
/// <summary>
/// Storage usage (bytes).
/// </summary>
[JsonPropertyName("usage")]public double Usage{get;set;}
}
