using System;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Services.Classifier;

namespace LlamaIndex.LlamaCloud.Services;

/// <inheritdoc/>
public sealed class ClassifierService : IClassifierService
{
    readonly Lazy<IClassifierServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IClassifierServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IClassifierService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ClassifierService(this._client.WithOptions(modifier));
    }

    public ClassifierService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ClassifierServiceWithRawResponse(client.WithRawResponse));
        _jobs = new(() => new JobService(client));
    }

    readonly Lazy<IJobService> _jobs;
    public IJobService Jobs
    {
        get { return _jobs.Value; }
    }
}

/// <inheritdoc/>
public sealed class ClassifierServiceWithRawResponse : IClassifierServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IClassifierServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ClassifierServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ClassifierServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;

        _jobs = new(() => new JobServiceWithRawResponse(client));
    }

    readonly Lazy<IJobServiceWithRawResponse> _jobs;
    public IJobServiceWithRawResponse Jobs
    {
        get { return _jobs.Value; }
    }
}
