using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOMSnapshot;
/// <summary>
/// Table of details of the post layout rendered text positions. The exact layout should not be regarded as
/// stable and may change between versions.
/// </summary>
public sealed partial class TextBoxSnapshot {
/// <summary>
/// Index of the layout tree node that owns this box collection.
/// </summary>
[JsonPropertyName("layoutIndex")]public long[] LayoutIndex{get;set;}
/// <summary>
/// The absolute position bounding box.
/// </summary>
[JsonPropertyName("bounds")]public Rectangle[] Bounds{get;set;}
/// <summary>
/// The starting index in characters, for this post layout textbox substring. Characters that
/// would be represented as a surrogate pair in UTF-16 have length 2.
/// </summary>
[JsonPropertyName("start")]public long[] Start{get;set;}
/// <summary>
/// The number of characters in this post layout textbox substring. Characters that would be
/// represented as a surrogate pair in UTF-16 have length 2.
/// </summary>
[JsonPropertyName("length")]public long[] Length{get;set;}
}
