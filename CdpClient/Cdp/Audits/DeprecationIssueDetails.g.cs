using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
/// <summary>
/// This issue tracks information needed to print a deprecation message.
/// The formatting is inherited from the old console.log version, see more at:
/// https://source.chromium.org/chromium/chromium/src/+/main:third_party/blink/renderer/core/frame/deprecation.cc
/// TODO(crbug.com/1264960): Re-work format to add i18n support per:
/// https://source.chromium.org/chromium/chromium/src/+/main:third_party/blink/public/devtools_protocol/README.md
/// </summary>
public sealed partial class DeprecationIssueDetails {
[JsonPropertyName("affectedFrame")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AffectedFrame? AffectedFrame{get;set;}
[JsonPropertyName("sourceCodeLocation")]public SourceCodeLocation SourceCodeLocation{get;set;}
/// <summary>
/// The content of an untranslated deprecation issue,
/// e.g. "window.inefficientLegacyStorageMethod will be removed in M97,
/// around January 2022. Please use Web Storage or Indexed Database
/// instead. This standard was abandoned in January, 1970. See
/// https://www.chromestatus.com/feature/5684870116278272 for more details."
/// </summary>
[Obsolete][JsonPropertyName("message")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Message{get;set;}
/// <summary>
/// The id of an untranslated deprecation issue e.g. PrefixedStorageInfo.
/// </summary>
[Obsolete][JsonPropertyName("deprecationType")]public string DeprecationType{get;set;}
}
