using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Memory;
/// <summary>
/// Memory pressure level.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum PressureLevel {
[EnumMember(Value = "moderate")] Moderate,
[EnumMember(Value = "critical")] Critical,
}
