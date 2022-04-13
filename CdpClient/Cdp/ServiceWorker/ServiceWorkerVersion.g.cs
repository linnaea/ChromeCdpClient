using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.ServiceWorker;
/// <summary>
/// ServiceWorker version.
/// </summary>
public sealed partial class ServiceWorkerVersion {
[JsonPropertyName("versionId")]public string VersionId{get;set;}
[JsonPropertyName("registrationId")]public RegistrationID RegistrationId{get;set;}
[JsonPropertyName("scriptURL")]public string ScriptURL{get;set;}
[JsonPropertyName("runningStatus")]public ServiceWorkerVersionRunningStatus RunningStatus{get;set;}
[JsonPropertyName("status")]public ServiceWorkerVersionStatus Status{get;set;}
/// <summary>
/// The Last-Modified header value of the main script.
/// </summary>
[JsonPropertyName("scriptLastModified")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? ScriptLastModified{get;set;}
/// <summary>
/// The time at which the response headers of the main script were received from the server.
/// For cached script it is the last time the cache entry was validated.
/// </summary>
[JsonPropertyName("scriptResponseTime")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? ScriptResponseTime{get;set;}
[JsonPropertyName("controlledClients")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Target.TargetID[]? ControlledClients{get;set;}
[JsonPropertyName("targetId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Target.TargetID? TargetId{get;set;}
}
