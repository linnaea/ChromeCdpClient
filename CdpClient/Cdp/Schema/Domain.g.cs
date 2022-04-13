using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Schema;
/// <summary>
/// Description of the protocol domain.
/// </summary>
public sealed partial class Domain {
/// <summary>
/// Domain name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Domain version.
/// </summary>
[JsonPropertyName("version")]public string Version{get;set;}
}
