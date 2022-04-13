using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.SystemInfo;
/// <summary>
/// Describes a single graphics processor (GPU).
/// </summary>
public sealed partial class GPUDevice {
/// <summary>
/// PCI ID of the GPU vendor, if available; 0 otherwise.
/// </summary>
[JsonPropertyName("vendorId")]public double VendorId{get;set;}
/// <summary>
/// PCI ID of the GPU device, if available; 0 otherwise.
/// </summary>
[JsonPropertyName("deviceId")]public double DeviceId{get;set;}
/// <summary>
/// Sub sys ID of the GPU, only available on Windows.
/// </summary>
[JsonPropertyName("subSysId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? SubSysId{get;set;}
/// <summary>
/// Revision of the GPU, only available on Windows.
/// </summary>
[JsonPropertyName("revision")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Revision{get;set;}
/// <summary>
/// String description of the GPU vendor, if the PCI ID is not available.
/// </summary>
[JsonPropertyName("vendorString")]public string VendorString{get;set;}
/// <summary>
/// String description of the GPU device, if the PCI ID is not available.
/// </summary>
[JsonPropertyName("deviceString")]public string DeviceString{get;set;}
/// <summary>
/// String description of the GPU driver vendor.
/// </summary>
[JsonPropertyName("driverVendor")]public string DriverVendor{get;set;}
/// <summary>
/// String description of the GPU driver version.
/// </summary>
[JsonPropertyName("driverVersion")]public string DriverVersion{get;set;}
}
