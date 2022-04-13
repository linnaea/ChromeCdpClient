using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct StyleSheetId {
public string Value {get;set;}
public static implicit operator string(StyleSheetId v) => v.Value;
public static implicit operator StyleSheetId(string v) => new() {Value=v};
}
