using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Generic font families collection.
/// </summary>
[Experimental]public sealed partial class FontFamilies {
/// <summary>
/// The standard font-family.
/// </summary>
[JsonPropertyName("standard")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Standard{get;set;}
/// <summary>
/// The fixed font-family.
/// </summary>
[JsonPropertyName("fixed")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Fixed{get;set;}
/// <summary>
/// The serif font-family.
/// </summary>
[JsonPropertyName("serif")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Serif{get;set;}
/// <summary>
/// The sansSerif font-family.
/// </summary>
[JsonPropertyName("sansSerif")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? SansSerif{get;set;}
/// <summary>
/// The cursive font-family.
/// </summary>
[JsonPropertyName("cursive")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Cursive{get;set;}
/// <summary>
/// The fantasy font-family.
/// </summary>
[JsonPropertyName("fantasy")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Fantasy{get;set;}
/// <summary>
/// The pictograph font-family.
/// </summary>
[JsonPropertyName("pictograph")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Pictograph{get;set;}
}
