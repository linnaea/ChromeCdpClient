using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
[Experimental][JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct ReportId {
public string Value {get;set;}
public static implicit operator string(ReportId v) => v.Value;
public static implicit operator ReportId(string v) => new() {Value=v};
}
