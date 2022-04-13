using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.ServiceWorker;
[JsonConverter(typeof(StringEnumConverter))] public enum ServiceWorkerVersionRunningStatus {
[EnumMember(Value = "stopped")] Stopped,
[EnumMember(Value = "starting")] Starting,
[EnumMember(Value = "running")] Running,
[EnumMember(Value = "stopping")] Stopping,
}
