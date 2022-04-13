using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Fetch;
/// <summary>
/// Authorization challenge for HTTP status code 401 or 407.
/// </summary>
public sealed partial class AuthChallenge {
/// <summary>
/// Source of the authentication challenge.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum SourceEnum {
[EnumMember(Value = "Server")] Server,
[EnumMember(Value = "Proxy")] Proxy,
}
[JsonPropertyName("source")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public SourceEnum? Source{get;set;}
/// <summary>
/// Origin of the challenger.
/// </summary>
[JsonPropertyName("origin")]public string Origin{get;set;}
/// <summary>
/// The authentication scheme used, such as basic or digest
/// </summary>
[JsonPropertyName("scheme")]public string Scheme{get;set;}
/// <summary>
/// The realm of the challenge. May be empty.
/// </summary>
[JsonPropertyName("realm")]public string Realm{get;set;}
}
