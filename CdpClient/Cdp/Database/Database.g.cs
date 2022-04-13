using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Database;
/// <summary>
/// Database object.
/// </summary>
public sealed partial class Database {
/// <summary>
/// Database ID.
/// </summary>
[JsonPropertyName("id")]public DatabaseId Id{get;set;}
/// <summary>
/// Database domain.
/// </summary>
[JsonPropertyName("domain")]public string Domain{get;set;}
/// <summary>
/// Database name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Database version.
/// </summary>
[JsonPropertyName("version")]public string Version{get;set;}
}
