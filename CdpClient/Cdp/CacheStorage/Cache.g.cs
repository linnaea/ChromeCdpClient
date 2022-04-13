using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CacheStorage;
/// <summary>
/// Cache identifier.
/// </summary>
public sealed partial class Cache {
/// <summary>
/// An opaque unique id of the cache.
/// </summary>
[JsonPropertyName("cacheId")]public CacheId CacheId{get;set;}
/// <summary>
/// Security origin of the cache.
/// </summary>
[JsonPropertyName("securityOrigin")]public string SecurityOrigin{get;set;}
/// <summary>
/// The name of the cache.
/// </summary>
[JsonPropertyName("cacheName")]public string CacheName{get;set;}
}
