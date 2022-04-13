using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Media;
/// <summary>
/// Players will get an ID that is unique within the agent context.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct PlayerId {
public string Value {get;set;}
public static implicit operator string(PlayerId v) => v.Value;
public static implicit operator PlayerId(string v) => new() {Value=v};
}
