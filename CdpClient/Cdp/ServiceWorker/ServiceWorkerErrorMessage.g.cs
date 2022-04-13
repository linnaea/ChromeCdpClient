using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.ServiceWorker;
/// <summary>
/// ServiceWorker error message.
/// </summary>
public sealed partial class ServiceWorkerErrorMessage {
[JsonPropertyName("errorMessage")]public string ErrorMessage{get;set;}
[JsonPropertyName("registrationId")]public RegistrationID RegistrationId{get;set;}
[JsonPropertyName("versionId")]public string VersionId{get;set;}
[JsonPropertyName("sourceURL")]public string SourceURL{get;set;}
[JsonPropertyName("lineNumber")]public long LineNumber{get;set;}
[JsonPropertyName("columnNumber")]public long ColumnNumber{get;set;}
}
