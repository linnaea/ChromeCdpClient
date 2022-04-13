using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Memory;
/// <summary>
/// Executable module information
/// </summary>
public sealed partial class Module {
/// <summary>
/// Name of the module.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// UUID of the module.
/// </summary>
[JsonPropertyName("uuid")]public string Uuid{get;set;}
/// <summary>
/// Base address where the module is loaded into memory. Encoded as a decimal
/// or hexadecimal (0x prefixed) string.
/// </summary>
[JsonPropertyName("baseAddress")]public string BaseAddress{get;set;}
/// <summary>
/// Size of the module in bytes.
/// </summary>
[JsonPropertyName("size")]public double Size{get;set;}
}
