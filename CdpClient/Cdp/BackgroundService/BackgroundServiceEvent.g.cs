using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.BackgroundService;
public sealed partial class BackgroundServiceEvent {
/// <summary>
/// Timestamp of the event (in seconds).
/// </summary>
[JsonPropertyName("timestamp")]public Network.TimeSinceEpoch Timestamp{get;set;}
/// <summary>
/// The origin this event belongs to.
/// </summary>
[JsonPropertyName("origin")]public string Origin{get;set;}
/// <summary>
/// The Service Worker ID that initiated the event.
/// </summary>
[JsonPropertyName("serviceWorkerRegistrationId")]public ServiceWorker.RegistrationID ServiceWorkerRegistrationId{get;set;}
/// <summary>
/// The Background Service this event belongs to.
/// </summary>
[JsonPropertyName("service")]public ServiceName Service{get;set;}
/// <summary>
/// A description of the event.
/// </summary>
[JsonPropertyName("eventName")]public string EventName{get;set;}
/// <summary>
/// An identifier that groups related events together.
/// </summary>
[JsonPropertyName("instanceId")]public string InstanceId{get;set;}
/// <summary>
/// A list of event-specific information.
/// </summary>
[JsonPropertyName("eventMetadata")]public EventMetadata[] EventMetadata{get;set;}
}
