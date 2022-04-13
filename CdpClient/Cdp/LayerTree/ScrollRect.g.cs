using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.LayerTree;
/// <summary>
/// Rectangle where scrolling happens on the main thread.
/// </summary>
public sealed partial class ScrollRect {
/// <summary>
/// Rectangle itself.
/// </summary>
[JsonPropertyName("rect")]public DOM.Rect Rect{get;set;}
/// <summary>
/// Reason for rectangle to force scrolling on the main thread
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum TypeEnum {
[EnumMember(Value = "RepaintsOnScroll")] RepaintsOnScroll,
[EnumMember(Value = "TouchEventHandler")] TouchEventHandler,
[EnumMember(Value = "WheelEventHandler")] WheelEventHandler,
}
[JsonPropertyName("type")]public TypeEnum Type{get;set;}
}
