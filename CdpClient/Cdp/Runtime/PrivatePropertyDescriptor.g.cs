using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
/// <summary>
/// Object private field descriptor.
/// </summary>
[Experimental]public sealed partial class PrivatePropertyDescriptor {
/// <summary>
/// Private property name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// The value associated with the private property.
/// </summary>
[JsonPropertyName("value")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public RemoteObject? Value{get;set;}
/// <summary>
/// A function which serves as a getter for the private property,
/// or `undefined` if there is no getter (accessor descriptors only).
/// </summary>
[JsonPropertyName("get")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public RemoteObject? Get{get;set;}
/// <summary>
/// A function which serves as a setter for the private property,
/// or `undefined` if there is no setter (accessor descriptors only).
/// </summary>
[JsonPropertyName("set")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public RemoteObject? Set{get;set;}
}
