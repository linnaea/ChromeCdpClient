using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.SystemInfo;
/// <summary>
/// Describes a supported video encoding profile with its associated maximum
/// resolution and maximum framerate.
/// </summary>
public sealed partial class VideoEncodeAcceleratorCapability {
/// <summary>
/// Video codec profile that is supported, e.g H264 Main.
/// </summary>
[JsonPropertyName("profile")]public string Profile{get;set;}
/// <summary>
/// Maximum video dimensions in pixels supported for this |profile|.
/// </summary>
[JsonPropertyName("maxResolution")]public Size MaxResolution{get;set;}
/// <summary>
/// Maximum encoding framerate in frames per second supported for this
/// |profile|, as fraction's numerator and denominator, e.g. 24/1 fps,
/// 24000/1001 fps, etc.
/// </summary>
[JsonPropertyName("maxFramerateNumerator")]public long MaxFramerateNumerator{get;set;}
[JsonPropertyName("maxFramerateDenominator")]public long MaxFramerateDenominator{get;set;}
}
