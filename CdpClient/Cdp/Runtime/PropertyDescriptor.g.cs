using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
/// <summary>
/// Object property descriptor.
/// </summary>
public sealed partial class PropertyDescriptor {
/// <summary>
/// Property name or symbol description.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// The value associated with the property.
/// </summary>
[JsonPropertyName("value")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public RemoteObject? Value{get;set;}
/// <summary>
/// True if the value associated with the property may be changed (data descriptors only).
/// </summary>
[JsonPropertyName("writable")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Writable{get;set;}
/// <summary>
/// A function which serves as a getter for the property, or `undefined` if there is no getter
/// (accessor descriptors only).
/// </summary>
[JsonPropertyName("get")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public RemoteObject? Get{get;set;}
/// <summary>
/// A function which serves as a setter for the property, or `undefined` if there is no setter
/// (accessor descriptors only).
/// </summary>
[JsonPropertyName("set")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public RemoteObject? Set{get;set;}
/// <summary>
/// True if the type of this property descriptor may be changed and if the property may be
/// deleted from the corresponding object.
/// </summary>
[JsonPropertyName("configurable")]public bool Configurable{get;set;}
/// <summary>
/// True if this property shows up during enumeration of the properties on the corresponding
/// object.
/// </summary>
[JsonPropertyName("enumerable")]public bool Enumerable{get;set;}
/// <summary>
/// True if the result was thrown during the evaluation.
/// </summary>
[JsonPropertyName("wasThrown")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? WasThrown{get;set;}
/// <summary>
/// True if the property is owned for the object.
/// </summary>
[JsonPropertyName("isOwn")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IsOwn{get;set;}
/// <summary>
/// Property symbol object, if the property is of the `symbol` type.
/// </summary>
[JsonPropertyName("symbol")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public RemoteObject? Symbol{get;set;}
}
