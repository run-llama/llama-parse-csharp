using System;
using LlamaCloud.Core;

namespace LlamaCloud.Services.Classifier;

/// <inheritdoc/>
public sealed class JobService : IJobService
{
    readonly Lazy<IJobServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IJobServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IJobService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new JobService(this._client.WithOptions(modifier));
    }

    public JobService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new JobServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class JobServiceWithRawResponse : IJobServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IJobServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new JobServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public JobServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }
}
