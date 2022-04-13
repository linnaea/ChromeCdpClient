using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Tracing;
/// <summary>
/// Compression type to use for traces returned via streams.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum StreamCompression {
[EnumMember(Value = "none")] None,
[EnumMember(Value = "gzip")] Gzip,
}
