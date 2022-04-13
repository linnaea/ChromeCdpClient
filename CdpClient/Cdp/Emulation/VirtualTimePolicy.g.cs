using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Emulation;
/// <summary>
/// advance: If the scheduler runs out of immediate work, the virtual time base may fast forward to
/// allow the next delayed task (if any) to run; pause: The virtual time base may not advance;
/// pauseIfNetworkFetchesPending: The virtual time base may not advance if there are any pending
/// resource fetches.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum VirtualTimePolicy {
[EnumMember(Value = "advance")] Advance,
[EnumMember(Value = "pause")] Pause,
[EnumMember(Value = "pauseIfNetworkFetchesPending")] PauseIfNetworkFetchesPending,
}
