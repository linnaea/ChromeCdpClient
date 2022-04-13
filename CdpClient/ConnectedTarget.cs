using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CdpClient;

public partial class ConnectedTarget : IDisposable
{
    private readonly WebSocket _connectTarget;
    private readonly CancellationTokenSource _stop = new();
    private readonly CancellationToken _stopToken;
    private readonly ConcurrentDictionary<uint, TaskCompletionSource<byte[]>> _pending = new();
    private int _requestCounter;

    public ConnectedTarget(WebSocket connectTarget)
    {
        _stopToken = _stop.Token;
        _connectTarget = connectTarget;
        ReceiveThread();
    }

    private async void ReceiveThread()
    {
        var buf = new byte[4096];
        var bufLen = 0;
        try {
            while (!_stop.IsCancellationRequested) {
                var r = await _connectTarget.ReceiveAsync(
                            new ArraySegment<byte>(buf, bufLen, buf.Length - bufLen), _stopToken);

                if (r.MessageType == WebSocketMessageType.Close)
                    return;

                bufLen += r.Count;

                if (!r.EndOfMessage) {
                    if (bufLen == buf.Length) {
                        Array.Resize(ref buf, buf.Length + 4096);
                    }

                    continue;
                }

                var data = new ArraySegment<byte>(buf, 0, bufLen);
                var meta = JsonSerializer.Deserialize<JsonRpcMeta>(data);
                switch (meta) {
                case { Id: { }, Method: null }:
                    if (_pending.TryRemove(meta.Id.Value, out var pendingTask)) {
                        var tr = new byte[bufLen];
                        Array.Copy(buf, 0, tr, 0, bufLen);
                        pendingTask.SetResult(tr);
                    }

                    break;
                case { Id: null, Method: { } }:
                    DispatchEvent(meta.Method, data);
                    break;
                }

                bufLen = 0;
            }
        }
        catch (WebSocketException e) {
            foreach (var tcs in _pending.Values) {
                tcs.SetException(e);
            }
        }
        finally {
            try {
                _stop.Cancel();
            }
            catch (ObjectDisposedException) { }
        }
    }

    public T DeserializeResponse<T>(byte[] resp)
    {
        return JsonSerializer.Deserialize<JsonRpcResponse<T, object>>(resp)!.Result;
    }

    public T DeserializeEvent<T>(ArraySegment<byte> resp)
    {
        return JsonSerializer.Deserialize<JsonRpcRequest<T>>(resp)!.Params;
    }

    public Task<byte[]> SendRequest<T>(string method, T param, bool fireAndForget = false)
    {
        var rpc = new JsonRpcRequest<T> {
            Id = fireAndForget ? null : unchecked((uint)Interlocked.Increment(ref _requestCounter)),
            Method = method, Params = param
        };
        var tcs = new TaskCompletionSource<byte[]>();
        if (_stop.IsCancellationRequested) {
            tcs.SetCanceled();
        } else {
            if (rpc.Id.HasValue)
                _pending.TryAdd(rpc.Id.Value, tcs);

            SendRequest(rpc, tcs);
        }

        return tcs.Task;
    }

    private async void SendRequest<T>(JsonRpcRequest<T> rpc, TaskCompletionSource<byte[]> tcs)
    {
        try {
            await _connectTarget.SendAsync(new ArraySegment<byte>(JsonSerializer.SerializeToUtf8Bytes(rpc)),
                                           WebSocketMessageType.Text, true, _stopToken);

            if (!rpc.Id.HasValue)
                tcs.SetResult(Array.Empty<byte>());
        }
        catch (Exception e) {
            if (rpc.Id.HasValue)
                _pending.TryRemove(rpc.Id.Value, out _);

            tcs.SetException(e);
        }
    }

    partial void DispatchEvent(string method, ArraySegment<byte> data);
    partial void DisconnectEvents();

    private void ReleaseUnmanagedResources()
    {
        try {
            _stop.Cancel();
        }
        catch (ObjectDisposedException) { }
        DisconnectEvents();
    }

    private void Dispose(bool disposing)
    {
        ReleaseUnmanagedResources();
        if (disposing) {
            _connectTarget.Dispose();
            _stop.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~ConnectedTarget()
    {
        Dispose(false);
    }
}
