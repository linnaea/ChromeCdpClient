using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.SystemInfo;
/// <summary>
/// Image format of a given image.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum ImageType {
[EnumMember(Value = "jpeg")] Jpeg,
[EnumMember(Value = "webp")] Webp,
[EnumMember(Value = "unknown")] Unknown,
}
