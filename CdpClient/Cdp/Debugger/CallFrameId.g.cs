using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Debugger;
/// <summary>
/// Call frame identifier.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct CallFrameId {
public string Value {get;set;}
public static implicit operator string(CallFrameId v) => v.Value;
public static implicit operator CallFrameId(string v) => new() {Value=v};
}
