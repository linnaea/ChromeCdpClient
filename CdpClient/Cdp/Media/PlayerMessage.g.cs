using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Media;
/// <summary>
/// Have one type per entry in MediaLogRecord::Type
/// Corresponds to kMessage
/// </summary>
public sealed partial class PlayerMessage {
/// <summary>
/// Keep in sync with MediaLogMessageLevel
/// We are currently keeping the message level 'error' separate from the
/// PlayerError type because right now they represent different things,
/// this one being a DVLOG(ERROR) style log message that gets printed
/// based on what log level is selected in the UI, and the other is a
/// representation of a media::PipelineStatus object. Soon however we're
/// going to be moving away from using PipelineStatus for errors and
/// introducing a new error type which should hopefully let us integrate
/// the error log level into the PlayerError type.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum LevelEnum {
[EnumMember(Value = "error")] Error,
[EnumMember(Value = "warning")] Warning,
[EnumMember(Value = "info")] Info,
[EnumMember(Value = "debug")] Debug,
}
[JsonPropertyName("level")]public LevelEnum Level{get;set;}
[JsonPropertyName("message")]public string Message{get;set;}
}
