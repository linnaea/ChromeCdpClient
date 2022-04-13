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
/// Missing optional values will be filled in by the target with what it would normally use.
/// </summary>
[Experimental]public sealed partial class UserAgentMetadata {
[JsonPropertyName("brands")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public UserAgentBrandVersion[]? Brands{get;set;}
[JsonPropertyName("fullVersionList")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public UserAgentBrandVersion[]? FullVersionList{get;set;}
[Obsolete][JsonPropertyName("fullVersion")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? FullVersion{get;set;}
[JsonPropertyName("platform")]public string Platform{get;set;}
[JsonPropertyName("platformVersion")]public string PlatformVersion{get;set;}
[JsonPropertyName("architecture")]public string Architecture{get;set;}
[JsonPropertyName("model")]public string Model{get;set;}
[JsonPropertyName("mobile")]public bool Mobile{get;set;}
}
