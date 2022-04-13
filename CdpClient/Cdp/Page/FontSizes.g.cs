using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Default font sizes.
/// </summary>
[Experimental]public sealed partial class FontSizes {
/// <summary>
/// Default standard font size.
/// </summary>
[JsonPropertyName("standard")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Standard{get;set;}
/// <summary>
/// Default fixed font size.
/// </summary>
[JsonPropertyName("fixed")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Fixed{get;set;}
}
