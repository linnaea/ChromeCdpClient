using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Input;
[Experimental]public sealed partial class DragData {
[JsonPropertyName("items")]public DragDataItem[] Items{get;set;}
/// <summary>
/// List of filenames that should be included when dropping
/// </summary>
[JsonPropertyName("files")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string[]? Files{get;set;}
/// <summary>
/// Bit field representing allowed drag operations. Copy = 1, Link = 2, Move = 16
/// </summary>
[JsonPropertyName("dragOperationsMask")]public long DragOperationsMask{get;set;}
}
