using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOM;
/// <summary>
/// Pseudo element type.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum PseudoType {
[EnumMember(Value = "first-line")] FirstLine,
[EnumMember(Value = "first-letter")] FirstLetter,
[EnumMember(Value = "before")] Before,
[EnumMember(Value = "after")] After,
[EnumMember(Value = "marker")] Marker,
[EnumMember(Value = "backdrop")] Backdrop,
[EnumMember(Value = "selection")] Selection,
[EnumMember(Value = "target-text")] TargetText,
[EnumMember(Value = "spelling-error")] SpellingError,
[EnumMember(Value = "grammar-error")] GrammarError,
[EnumMember(Value = "highlight")] Highlight,
[EnumMember(Value = "first-line-inherited")] FirstLineInherited,
[EnumMember(Value = "scrollbar")] Scrollbar,
[EnumMember(Value = "scrollbar-thumb")] ScrollbarThumb,
[EnumMember(Value = "scrollbar-button")] ScrollbarButton,
[EnumMember(Value = "scrollbar-track")] ScrollbarTrack,
[EnumMember(Value = "scrollbar-track-piece")] ScrollbarTrackPiece,
[EnumMember(Value = "scrollbar-corner")] ScrollbarCorner,
[EnumMember(Value = "resizer")] Resizer,
[EnumMember(Value = "input-list-button")] InputListButton,
[EnumMember(Value = "page-transition")] PageTransition,
[EnumMember(Value = "page-transition-container")] PageTransitionContainer,
[EnumMember(Value = "page-transition-image-wrapper")] PageTransitionImageWrapper,
[EnumMember(Value = "page-transition-outgoing-image")] PageTransitionOutgoingImage,
[EnumMember(Value = "page-transition-incoming-image")] PageTransitionIncomingImage,
}
