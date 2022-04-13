using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.ServiceWorker;
[JsonConverter(typeof(StringEnumConverter))] public enum ServiceWorkerVersionStatus {
[EnumMember(Value = "new")] New,
[EnumMember(Value = "installing")] Installing,
[EnumMember(Value = "installed")] Installed,
[EnumMember(Value = "activating")] Activating,
[EnumMember(Value = "activated")] Activated,
[EnumMember(Value = "redundant")] Redundant,
}
