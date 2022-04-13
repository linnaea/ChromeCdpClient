using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.SystemInfo;
/// <summary>
/// YUV subsampling type of the pixels of a given image.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum SubsamplingFormat {
[EnumMember(Value = "yuv420")] Yuv420,
[EnumMember(Value = "yuv422")] Yuv422,
[EnumMember(Value = "yuv444")] Yuv444,
}
