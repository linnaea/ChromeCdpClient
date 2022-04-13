using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOM;
/// <summary>
/// Unique DOM node identifier.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct NodeId {
public long Value {get;set;}
public static implicit operator long(NodeId v) => v.Value;
public static implicit operator NodeId(long v) => new() {Value=v};
}
