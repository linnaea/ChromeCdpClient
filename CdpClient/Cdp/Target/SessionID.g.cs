using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Target;
/// <summary>
/// Unique identifier of attached debugging session.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct SessionID {
public string Value {get;set;}
public static implicit operator string(SessionID v) => v.Value;
public static implicit operator SessionID(string v) => new() {Value=v};
}
