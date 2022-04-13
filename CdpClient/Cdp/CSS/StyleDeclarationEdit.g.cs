using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// A descriptor of operation to mutate style declaration text.
/// </summary>
public sealed partial class StyleDeclarationEdit {
/// <summary>
/// The css style sheet identifier.
/// </summary>
[JsonPropertyName("styleSheetId")]public StyleSheetId StyleSheetId{get;set;}
/// <summary>
/// The range of the style text in the enclosing stylesheet.
/// </summary>
[JsonPropertyName("range")]public SourceRange Range{get;set;}
/// <summary>
/// New style text.
/// </summary>
[JsonPropertyName("text")]public string Text{get;set;}
}
