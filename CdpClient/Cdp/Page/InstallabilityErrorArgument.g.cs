using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
[Experimental]public sealed partial class InstallabilityErrorArgument {
/// <summary>
/// Argument name (e.g. name:'minimum-icon-size-in-pixels').
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Argument value (e.g. value:'64').
/// </summary>
[JsonPropertyName("value")]public string Value{get;set;}
}
