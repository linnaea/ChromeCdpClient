using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
/// <summary>
/// Id of an execution context.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct ExecutionContextId {
public long Value {get;set;}
public static implicit operator long(ExecutionContextId v) => v.Value;
public static implicit operator ExecutionContextId(long v) => new() {Value=v};
}
