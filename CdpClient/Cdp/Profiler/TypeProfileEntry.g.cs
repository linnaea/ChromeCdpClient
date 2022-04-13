using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Profiler;
/// <summary>
/// Source offset and types for a parameter or return value.
/// </summary>
[Experimental]public sealed partial class TypeProfileEntry {
/// <summary>
/// Source offset of the parameter or end of function for return values.
/// </summary>
[JsonPropertyName("offset")]public long Offset{get;set;}
/// <summary>
/// The types for this parameter or return value.
/// </summary>
[JsonPropertyName("types")]public TypeObject[] Types{get;set;}
}
