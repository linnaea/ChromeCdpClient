using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Browser;
/// <summary>
/// Browser window bounds information
/// </summary>
[Experimental]public sealed partial class Bounds {
/// <summary>
/// The offset from the left edge of the screen to the window in pixels.
/// </summary>
[JsonPropertyName("left")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Left{get;set;}
/// <summary>
/// The offset from the top edge of the screen to the window in pixels.
/// </summary>
[JsonPropertyName("top")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Top{get;set;}
/// <summary>
/// The window width in pixels.
/// </summary>
[JsonPropertyName("width")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Width{get;set;}
/// <summary>
/// The window height in pixels.
/// </summary>
[JsonPropertyName("height")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Height{get;set;}
/// <summary>
/// The window state. Default to normal.
/// </summary>
[JsonPropertyName("windowState")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public WindowState? WindowState{get;set;}
}
