using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// List of content encodings supported by the backend.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum ContentEncoding {
[EnumMember(Value = "deflate")] Deflate,
[EnumMember(Value = "gzip")] Gzip,
[EnumMember(Value = "br")] Br,
}
