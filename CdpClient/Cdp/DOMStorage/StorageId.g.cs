using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOMStorage;
/// <summary>
/// DOM Storage identifier.
/// </summary>
public sealed partial class StorageId {
/// <summary>
/// Security origin for the storage.
/// </summary>
[JsonPropertyName("securityOrigin")]public string SecurityOrigin{get;set;}
/// <summary>
/// Whether the storage is local storage (not session storage).
/// </summary>
[JsonPropertyName("isLocalStorage")]public bool IsLocalStorage{get;set;}
}
