using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// Media query descriptor.
/// </summary>
public sealed partial class MediaQuery {
/// <summary>
/// Array of media query expressions.
/// </summary>
[JsonPropertyName("expressions")]public MediaQueryExpression[] Expressions{get;set;}
/// <summary>
/// Whether the media query condition is satisfied.
/// </summary>
[JsonPropertyName("active")]public bool Active{get;set;}
}
