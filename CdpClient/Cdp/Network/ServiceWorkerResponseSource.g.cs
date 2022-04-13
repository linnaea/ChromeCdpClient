using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Source of serviceworker response.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum ServiceWorkerResponseSource {
[EnumMember(Value = "cache-storage")] CacheStorage,
[EnumMember(Value = "http-cache")] HttpCache,
[EnumMember(Value = "fallback-code")] FallbackCode,
[EnumMember(Value = "network")] Network,
}
