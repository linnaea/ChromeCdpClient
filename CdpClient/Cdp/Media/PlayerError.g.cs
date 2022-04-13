using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Media;
/// <summary>
/// Corresponds to kMediaError
/// </summary>
public sealed partial class PlayerError {
[JsonConverter(typeof(StringEnumConverter))] public enum TypeEnum {
[EnumMember(Value = "pipeline_error")] Pipeline_error,
[EnumMember(Value = "media_error")] Media_error,
}
[JsonPropertyName("type")]public TypeEnum Type{get;set;}
/// <summary>
/// When this switches to using media::Status instead of PipelineStatus
/// we can remove "errorCode" and replace it with the fields from
/// a Status instance. This also seems like a duplicate of the error
/// level enum - there is a todo bug to have that level removed and
/// use this instead. (crbug.com/1068454)
/// </summary>
[JsonPropertyName("errorCode")]public string ErrorCode{get;set;}
}
