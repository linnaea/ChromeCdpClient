using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
[Experimental]public sealed partial class PermissionsPolicyFeatureState {
[JsonPropertyName("feature")]public PermissionsPolicyFeature Feature{get;set;}
[JsonPropertyName("allowed")]public bool Allowed{get;set;}
[JsonPropertyName("locator")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public PermissionsPolicyBlockLocator? Locator{get;set;}
}
