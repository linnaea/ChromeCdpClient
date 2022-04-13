using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.ServiceWorker;
/// <summary>
/// ServiceWorker registration.
/// </summary>
public sealed partial class ServiceWorkerRegistration {
[JsonPropertyName("registrationId")]public RegistrationID RegistrationId{get;set;}
[JsonPropertyName("scopeURL")]public string ScopeURL{get;set;}
[JsonPropertyName("isDeleted")]public bool IsDeleted{get;set;}
}
