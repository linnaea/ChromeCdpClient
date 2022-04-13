using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Overlay;
[JsonConverter(typeof(StringEnumConverter))] public enum ColorFormat {
[EnumMember(Value = "rgb")] Rgb,
[EnumMember(Value = "hsl")] Hsl,
[EnumMember(Value = "hwb")] Hwb,
[EnumMember(Value = "hex")] Hex,
}
