using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOMSnapshot;
/// <summary>
/// A name/value pair.
/// </summary>
public sealed partial class NameValue {
/// <summary>
/// Attribute/property name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Attribute/property value.
/// </summary>
[JsonPropertyName("value")]public string Value{get;set;}
}
