using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Debugger;
/// <summary>
/// Breakpoint identifier.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct BreakpointId {
public string Value {get;set;}
public static implicit operator string(BreakpointId v) => v.Value;
public static implicit operator BreakpointId(string v) => new() {Value=v};
}
