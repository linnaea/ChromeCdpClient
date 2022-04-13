using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOM;
/// <summary>
/// Unique DOM node identifier used to reference a node that may not have been pushed to the
/// front-end.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct BackendNodeId {
public long Value {get;set;}
public static implicit operator long(BackendNodeId v) => v.Value;
public static implicit operator BackendNodeId(long v) => new() {Value=v};
}
