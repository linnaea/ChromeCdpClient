using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.IndexedDB;
/// <summary>
/// Key range.
/// </summary>
public sealed partial class KeyRange {
/// <summary>
/// Lower bound.
/// </summary>
[JsonPropertyName("lower")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Key? Lower{get;set;}
/// <summary>
/// Upper bound.
/// </summary>
[JsonPropertyName("upper")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Key? Upper{get;set;}
/// <summary>
/// If true lower bound is open.
/// </summary>
[JsonPropertyName("lowerOpen")]public bool LowerOpen{get;set;}
/// <summary>
/// If true upper bound is open.
/// </summary>
[JsonPropertyName("upperOpen")]public bool UpperOpen{get;set;}
}
