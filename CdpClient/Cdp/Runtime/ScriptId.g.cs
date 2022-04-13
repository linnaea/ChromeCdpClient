using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
/// <summary>
/// Unique script identifier.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct ScriptId {
public string Value {get;set;}
public static implicit operator string(ScriptId v) => v.Value;
public static implicit operator ScriptId(string v) => new() {Value=v};
}
