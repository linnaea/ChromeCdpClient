using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Unique script identifier.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct ScriptIdentifier {
public string Value {get;set;}
public static implicit operator string(ScriptIdentifier v) => v.Value;
public static implicit operator ScriptIdentifier(string v) => new() {Value=v};
}
