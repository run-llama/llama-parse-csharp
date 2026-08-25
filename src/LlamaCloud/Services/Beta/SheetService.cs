using System;
using LlamaCloud.Core;

namespace LlamaCloud.Services.Beta;

/// <inheritdoc/>
public sealed class SheetService : ISheetService
{
    readonly Lazy<ISheetServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISheetServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public ISheetService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SheetService(this._client.WithOptions(modifier));
    }

    public SheetService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SheetServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class SheetServiceWithRawResponse : ISheetServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISheetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SheetServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SheetServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }
}
