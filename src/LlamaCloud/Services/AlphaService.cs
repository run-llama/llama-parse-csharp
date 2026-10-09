using System;
using LlamaCloud.Core;
using LlamaCloud.Services.Alpha;

namespace LlamaCloud.Services;

/// <inheritdoc/>
public sealed class AlphaService : IAlphaService
{
    readonly Lazy<IAlphaServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAlphaServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IAlphaService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AlphaService(this._client.WithOptions(modifier));
    }

    public AlphaService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AlphaServiceWithRawResponse(client.WithRawResponse));
        _verify = new(() => new VerifyService(client));
    }

    readonly Lazy<IVerifyService> _verify;
    public IVerifyService Verify
    {
        get { return _verify.Value; }
    }
}

/// <inheritdoc/>
public sealed class AlphaServiceWithRawResponse : IAlphaServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAlphaServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AlphaServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AlphaServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;

        _verify = new(() => new VerifyServiceWithRawResponse(client));
    }

    readonly Lazy<IVerifyServiceWithRawResponse> _verify;
    public IVerifyServiceWithRawResponse Verify
    {
        get { return _verify.Value; }
    }
}
