using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Fetch;
/// <summary>
/// Response to an AuthChallenge.
/// </summary>
public sealed partial class AuthChallengeResponse {
/// <summary>
/// The decision on what to do in response to the authorization challenge.  Default means
/// deferring to the default behavior of the net stack, which will likely either the Cancel
/// authentication or display a popup dialog box.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum ResponseEnum {
[EnumMember(Value = "Default")] Default,
[EnumMember(Value = "CancelAuth")] CancelAuth,
[EnumMember(Value = "ProvideCredentials")] ProvideCredentials,
}
[JsonPropertyName("response")]public ResponseEnum Response{get;set;}
/// <summary>
/// The username to provide, possibly empty. Should only be set if response is
/// ProvideCredentials.
/// </summary>
[JsonPropertyName("username")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Username{get;set;}
/// <summary>
/// The password to provide, possibly empty. Should only be set if response is
/// ProvideCredentials.
/// </summary>
[JsonPropertyName("password")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Password{get;set;}
}
