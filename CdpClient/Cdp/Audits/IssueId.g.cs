using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
/// <summary>
/// A unique id for a DevTools inspector issue. Allows other entities (e.g.
/// exceptions, CDP message, console messages, etc.) to reference an issue.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct IssueId {
public string Value {get;set;}
public static implicit operator string(IssueId v) => v.Value;
public static implicit operator IssueId(string v) => new() {Value=v};
}
