using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Tracing;
/// <summary>
/// Data format of a trace. Can be either the legacy JSON format or the
/// protocol buffer format. Note that the JSON format will be deprecated soon.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum StreamFormat {
[EnumMember(Value = "json")] Json,
[EnumMember(Value = "proto")] Proto,
}
