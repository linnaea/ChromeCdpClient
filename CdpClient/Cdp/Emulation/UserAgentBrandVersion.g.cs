using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Emulation;
/// <summary>
/// Used to specify User Agent Cient Hints to emulate. See https://wicg.github.io/ua-client-hints
/// </summary>
[Experimental]public sealed partial class UserAgentBrandVersion {
[JsonPropertyName("brand")]public string Brand{get;set;}
[JsonPropertyName("version")]public string Version{get;set;}
}
