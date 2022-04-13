using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Font families collection for a script.
/// </summary>
[Experimental]public sealed partial class ScriptFontFamilies {
/// <summary>
/// Name of the script which these font families are defined for.
/// </summary>
[JsonPropertyName("script")]public string Script{get;set;}
/// <summary>
/// Generic font families collection for the script.
/// </summary>
[JsonPropertyName("fontFamilies")]public FontFamilies FontFamilies{get;set;}
}
