using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Overlay;
[JsonConverter(typeof(StringEnumConverter))] public enum ContrastAlgorithm {
[EnumMember(Value = "aa")] Aa,
[EnumMember(Value = "aaa")] Aaa,
[EnumMember(Value = "apca")] Apca,
}
