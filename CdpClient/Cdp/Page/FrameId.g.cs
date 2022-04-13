using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Unique frame identifier.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct FrameId {
public string Value {get;set;}
public static implicit operator string(FrameId v) => v.Value;
public static implicit operator FrameId(string v) => new() {Value=v};
}
