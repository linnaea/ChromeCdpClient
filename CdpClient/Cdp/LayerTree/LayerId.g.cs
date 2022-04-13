using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.LayerTree;
/// <summary>
/// Unique Layer identifier.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct LayerId {
public string Value {get;set;}
public static implicit operator string(LayerId v) => v.Value;
public static implicit operator LayerId(string v) => new() {Value=v};
}
