using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
public sealed partial class ShorthandEntry {
/// <summary>
/// Shorthand name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Shorthand value.
/// </summary>
[JsonPropertyName("value")]public string Value{get;set;}
/// <summary>
/// Whether the property has "!important" annotation (implies `false` if absent).
/// </summary>
[JsonPropertyName("important")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Important{get;set;}
}
