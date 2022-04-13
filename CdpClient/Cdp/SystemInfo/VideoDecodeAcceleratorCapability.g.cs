using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.SystemInfo;
/// <summary>
/// Describes a supported video decoding profile with its associated minimum and
/// maximum resolutions.
/// </summary>
public sealed partial class VideoDecodeAcceleratorCapability {
/// <summary>
/// Video codec profile that is supported, e.g. VP9 Profile 2.
/// </summary>
[JsonPropertyName("profile")]public string Profile{get;set;}
/// <summary>
/// Maximum video dimensions in pixels supported for this |profile|.
/// </summary>
[JsonPropertyName("maxResolution")]public Size MaxResolution{get;set;}
/// <summary>
/// Minimum video dimensions in pixels supported for this |profile|.
/// </summary>
[JsonPropertyName("minResolution")]public Size MinResolution{get;set;}
}
