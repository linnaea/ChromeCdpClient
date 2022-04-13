using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Unique loader identifier.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct LoaderId {
public string Value {get;set;}
public static implicit operator string(LoaderId v) => v.Value;
public static implicit operator LoaderId(string v) => new() {Value=v};
}
