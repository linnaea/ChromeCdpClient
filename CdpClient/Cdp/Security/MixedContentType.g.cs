using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Security;
/// <summary>
/// A description of mixed content (HTTP resources on HTTPS pages), as defined by
/// https://www.w3.org/TR/mixed-content/#categories
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum MixedContentType {
[EnumMember(Value = "blockable")] Blockable,
[EnumMember(Value = "optionally-blockable")] OptionallyBlockable,
[EnumMember(Value = "none")] None,
}
