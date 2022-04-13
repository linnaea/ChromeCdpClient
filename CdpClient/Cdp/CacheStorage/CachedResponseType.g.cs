using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CacheStorage;
/// <summary>
/// type of HTTP response cached
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum CachedResponseType {
[EnumMember(Value = "basic")] Basic,
[EnumMember(Value = "cors")] Cors,
[EnumMember(Value = "default")] Default,
[EnumMember(Value = "error")] Error,
[EnumMember(Value = "opaqueResponse")] OpaqueResponse,
[EnumMember(Value = "opaqueRedirect")] OpaqueRedirect,
}
