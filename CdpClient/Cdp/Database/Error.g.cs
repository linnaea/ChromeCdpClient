using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Database;
/// <summary>
/// Database error.
/// </summary>
public sealed partial class Error {
/// <summary>
/// Error message.
/// </summary>
[JsonPropertyName("message")]public string Message{get;set;}
/// <summary>
/// Error code.
/// </summary>
[JsonPropertyName("code")]public long Code{get;set;}
}
