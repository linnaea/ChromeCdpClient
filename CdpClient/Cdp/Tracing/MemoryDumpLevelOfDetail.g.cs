using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Tracing;
/// <summary>
/// Details exposed when memory request explicitly declared.
/// Keep consistent with memory_dump_request_args.h and
/// memory_instrumentation.mojom
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum MemoryDumpLevelOfDetail {
[EnumMember(Value = "background")] Background,
[EnumMember(Value = "light")] Light,
[EnumMember(Value = "detailed")] Detailed,
}
