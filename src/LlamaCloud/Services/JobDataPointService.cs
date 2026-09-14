using System;
using LlamaCloud.Core;

namespace LlamaCloud.Services;

/// <inheritdoc/>
public sealed class JobDataPointService : IJobDataPointService
{
    readonly Lazy<IJobDataPointServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IJobDataPointServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IJobDataPointService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new JobDataPointService(this._client.WithOptions(modifier));
    }

    public JobDataPointService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new JobDataPointServiceWithRawResponse(client.WithRawResponse)
        );
    }
}

/// <inheritdoc/>
public sealed class JobDataPointServiceWithRawResponse : IJobDataPointServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IJobDataPointServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new JobDataPointServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public JobDataPointServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }
}
