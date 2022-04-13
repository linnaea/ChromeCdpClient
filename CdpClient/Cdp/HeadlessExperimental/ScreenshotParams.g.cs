using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.HeadlessExperimental;
/// <summary>
/// Encoding options for a screenshot.
/// </summary>
public sealed partial class ScreenshotParams {
/// <summary>
/// Image compression format (defaults to png).
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum FormatEnum {
[EnumMember(Value = "jpeg")] Jpeg,
[EnumMember(Value = "png")] Png,
}
[JsonPropertyName("format")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public FormatEnum? Format{get;set;}
/// <summary>
/// Compression quality from range [0..100] (jpeg only).
/// </summary>
[JsonPropertyName("quality")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Quality{get;set;}
}
