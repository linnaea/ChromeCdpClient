using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Emulation;
/// <summary>
/// Enum of image types that can be disabled.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum DisabledImageType {
[EnumMember(Value = "avif")] Avif,
[EnumMember(Value = "jxl")] Jxl,
[EnumMember(Value = "webp")] Webp,
}
