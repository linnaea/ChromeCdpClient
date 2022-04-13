using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Indicates whether a frame has been identified as an ad.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum AdFrameType {
[EnumMember(Value = "none")] None,
[EnumMember(Value = "child")] Child,
[EnumMember(Value = "root")] Root,
}
