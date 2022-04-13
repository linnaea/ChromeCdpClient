using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.SystemInfo;
/// <summary>
/// Describes a supported image decoding profile with its associated minimum and
/// maximum resolutions and subsampling.
/// </summary>
public sealed partial class ImageDecodeAcceleratorCapability {
/// <summary>
/// Image coded, e.g. Jpeg.
/// </summary>
[JsonPropertyName("imageType")]public ImageType ImageType{get;set;}
/// <summary>
/// Maximum supported dimensions of the image in pixels.
/// </summary>
[JsonPropertyName("maxDimensions")]public Size MaxDimensions{get;set;}
/// <summary>
/// Minimum supported dimensions of the image in pixels.
/// </summary>
[JsonPropertyName("minDimensions")]public Size MinDimensions{get;set;}
/// <summary>
/// Optional array of supported subsampling formats, e.g. 4:2:0, if known.
/// </summary>
[JsonPropertyName("subsamplings")]public SubsamplingFormat[] Subsamplings{get;set;}
}
