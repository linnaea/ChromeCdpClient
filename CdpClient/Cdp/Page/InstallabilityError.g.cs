using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// The installability error
/// </summary>
[Experimental]public sealed partial class InstallabilityError {
/// <summary>
/// The error id (e.g. 'manifest-missing-suitable-icon').
/// </summary>
[JsonPropertyName("errorId")]public string ErrorId{get;set;}
/// <summary>
/// The list of error arguments (e.g. {name:'minimum-icon-size-in-pixels', value:'64'}).
/// </summary>
[JsonPropertyName("errorArguments")]public InstallabilityErrorArgument[] ErrorArguments{get;set;}
}
