using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Profiler;
/// <summary>
/// Describes a type collected during runtime.
/// </summary>
[Experimental]public sealed partial class TypeObject {
/// <summary>
/// Name of a type collected with type profiling.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
}
