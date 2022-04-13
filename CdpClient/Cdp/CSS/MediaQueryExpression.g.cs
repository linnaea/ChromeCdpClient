using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// Media query expression descriptor.
/// </summary>
public sealed partial class MediaQueryExpression {
/// <summary>
/// Media query expression value.
/// </summary>
[JsonPropertyName("value")]public double Value{get;set;}
/// <summary>
/// Media query expression units.
/// </summary>
[JsonPropertyName("unit")]public string Unit{get;set;}
/// <summary>
/// Media query expression feature.
/// </summary>
[JsonPropertyName("feature")]public string Feature{get;set;}
/// <summary>
/// The associated range of the value text in the enclosing stylesheet (if available).
/// </summary>
[JsonPropertyName("valueRange")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public SourceRange? ValueRange{get;set;}
/// <summary>
/// Computed length of media query expression (if applicable).
/// </summary>
[JsonPropertyName("computedLength")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? ComputedLength{get;set;}
}
