using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
/// <summary>
/// Unique identifier of current debugger.
/// </summary>
[Experimental][JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct UniqueDebuggerId {
public string Value {get;set;}
public static implicit operator string(UniqueDebuggerId v) => v.Value;
public static implicit operator UniqueDebuggerId(string v) => new() {Value=v};
}
