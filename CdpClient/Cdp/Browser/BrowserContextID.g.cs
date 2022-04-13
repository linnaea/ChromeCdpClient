using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Browser;
[Experimental][JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct BrowserContextID {
public string Value {get;set;}
public static implicit operator string(BrowserContextID v) => v.Value;
public static implicit operator BrowserContextID(string v) => new() {Value=v};
}
