using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace CdpClient;

public class DevToolsClient
{
    private static readonly HttpClient httpClient = new();
    private readonly Uri _target;

    public DevToolsClient(Uri target)
    {
        _target = target;
    }

    public async Task<IReadOnlyList<DevToolsTarget>> GetTargets()
    {
        using var targetStream = await httpClient.GetStreamAsync(new Uri(_target, "json/list"));
        return (await JsonSerializer.DeserializeAsync<List<DevToolsTarget>>(targetStream))!;
    }

    public async Task<DevToolsTarget> Open(string uri)
    {
        uri = UrlEncoder.Default.Encode(uri);
        using var targetStream = await httpClient.GetStreamAsync(new Uri(_target, $"json/new?{uri}"));
        return (await JsonSerializer.DeserializeAsync<DevToolsTarget>(targetStream))!;
    }

    public async Task<bool> Close(string targetId)
    {
        targetId = UrlEncoder.Default.Encode(targetId);
        using var targetResult = await httpClient.GetAsync(new Uri(_target, $"json/close/{targetId}"));
        return targetResult.IsSuccessStatusCode;
    }

    public async Task<bool> Activate(string targetId)
    {
        targetId = UrlEncoder.Default.Encode(targetId);
        using var targetResult = await httpClient.GetAsync(new Uri(_target, $"json/activate/{targetId}"));
        return targetResult.IsSuccessStatusCode;
    }

    public async Task<ConnectedTarget> Connect(Uri target)
    {
        var ws = new ClientWebSocket();
        await ws.ConnectAsync(target, CancellationToken.None);
        return new ConnectedTarget(ws);
    }

    public Task<ConnectedTarget> Connect(DevToolsTarget target) => Connect(new Uri(target.WebSocketDebuggerUrl));
    public Task<ConnectedTarget> Connect(string targetId)
    {
        targetId = UrlEncoder.Default.Encode(targetId);
        return Connect(new Uri(_target, $"devtools/page/{targetId}"));
    }
}

public class DevToolsTarget
{
    [JsonPropertyName("description")] public string Description { get; init; } = default!;
    [JsonPropertyName("devtoolsFrontendUrl")] public string DevToolsFrontendUrl { get; init; } = default!;
    [JsonPropertyName("id")] public string Id { get; init; } = default!;
    [JsonPropertyName("title")] public string Title { get; init; } = default!;
    [JsonPropertyName("type")] public string Type { get; init; } = default!;
    [JsonPropertyName("url")] public string Url { get; init; } = default!;
    [JsonPropertyName("webSocketDebuggerUrl")] public string WebSocketDebuggerUrl { get; init; } = default!;

    public override string ToString()
    {
        return $"DevToolsTarget {Type}/{Id} URL={Url} Title={Title} {Description}";
    }
}
