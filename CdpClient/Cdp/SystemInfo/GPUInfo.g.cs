using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.SystemInfo;
/// <summary>
/// Provides information about the GPU(s) on the system.
/// </summary>
public sealed partial class GPUInfo {
/// <summary>
/// The graphics devices on the system. Element 0 is the primary GPU.
/// </summary>
[JsonPropertyName("devices")]public GPUDevice[] Devices{get;set;}
/// <summary>
/// An optional dictionary of additional GPU related attributes.
/// </summary>
[JsonPropertyName("auxAttributes")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public object? AuxAttributes{get;set;}
/// <summary>
/// An optional dictionary of graphics features and their status.
/// </summary>
[JsonPropertyName("featureStatus")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public object? FeatureStatus{get;set;}
/// <summary>
/// An optional array of GPU driver bug workarounds.
/// </summary>
[JsonPropertyName("driverBugWorkarounds")]public string[] DriverBugWorkarounds{get;set;}
/// <summary>
/// Supported accelerated video decoding capabilities.
/// </summary>
[JsonPropertyName("videoDecoding")]public VideoDecodeAcceleratorCapability[] VideoDecoding{get;set;}
/// <summary>
/// Supported accelerated video encoding capabilities.
/// </summary>
[JsonPropertyName("videoEncoding")]public VideoEncodeAcceleratorCapability[] VideoEncoding{get;set;}
/// <summary>
/// Supported accelerated image decoding capabilities.
/// </summary>
[JsonPropertyName("imageDecoding")]public ImageDecodeAcceleratorCapability[] ImageDecoding{get;set;}
}
