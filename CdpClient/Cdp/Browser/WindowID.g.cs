using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Browser;
[Experimental][JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct WindowID {
public long Value {get;set;}
public static implicit operator long(WindowID v) => v.Value;
public static implicit operator WindowID(long v) => new() {Value=v};
}
