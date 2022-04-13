using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Console;
/// <summary>
/// Console message.
/// </summary>
public sealed partial class ConsoleMessage {
/// <summary>
/// Message source.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum SourceEnum {
[EnumMember(Value = "xml")] Xml,
[EnumMember(Value = "javascript")] Javascript,
[EnumMember(Value = "network")] Network,
[EnumMember(Value = "console-api")] ConsoleApi,
[EnumMember(Value = "storage")] Storage,
[EnumMember(Value = "appcache")] Appcache,
[EnumMember(Value = "rendering")] Rendering,
[EnumMember(Value = "security")] Security,
[EnumMember(Value = "other")] Other,
[EnumMember(Value = "deprecation")] Deprecation,
[EnumMember(Value = "worker")] Worker,
}
[JsonPropertyName("source")]public SourceEnum Source{get;set;}
/// <summary>
/// Message severity.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum LevelEnum {
[EnumMember(Value = "log")] Log,
[EnumMember(Value = "warning")] Warning,
[EnumMember(Value = "error")] Error,
[EnumMember(Value = "debug")] Debug,
[EnumMember(Value = "info")] Info,
}
[JsonPropertyName("level")]public LevelEnum Level{get;set;}
/// <summary>
/// Message text.
/// </summary>
[JsonPropertyName("text")]public string Text{get;set;}
/// <summary>
/// URL of the message origin.
/// </summary>
[JsonPropertyName("url")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Url{get;set;}
/// <summary>
/// Line number in the resource that generated this message (1-based).
/// </summary>
[JsonPropertyName("line")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Line{get;set;}
/// <summary>
/// Column number in the resource that generated this message (1-based).
/// </summary>
[JsonPropertyName("column")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Column{get;set;}
}
