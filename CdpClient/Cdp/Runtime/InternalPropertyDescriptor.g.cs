using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
/// <summary>
/// Object internal property descriptor. This property isn't normally visible in JavaScript code.
/// </summary>
public sealed partial class InternalPropertyDescriptor {
/// <summary>
/// Conventional property name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// The value associated with the property.
/// </summary>
[JsonPropertyName("value")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public RemoteObject? Value{get;set;}
}
