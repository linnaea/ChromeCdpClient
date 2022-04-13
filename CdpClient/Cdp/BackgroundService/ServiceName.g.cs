using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.BackgroundService;
/// <summary>
/// The Background Service that will be associated with the commands/events.
/// Every Background Service operates independently, but they share the same
/// API.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum ServiceName {
[EnumMember(Value = "backgroundFetch")] BackgroundFetch,
[EnumMember(Value = "backgroundSync")] BackgroundSync,
[EnumMember(Value = "pushMessaging")] PushMessaging,
[EnumMember(Value = "notifications")] Notifications,
[EnumMember(Value = "paymentHandler")] PaymentHandler,
[EnumMember(Value = "periodicBackgroundSync")] PeriodicBackgroundSync,
}
