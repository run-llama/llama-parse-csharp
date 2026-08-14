using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Classifier.Jobs;

namespace LlamaIndex.LlamaCloud.Services.Classifier;

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

    /// <inheritdoc/>
    [Obsolete("Please use `client.classify.create()`")]
    public async Task<ClassifyJob> Create(
        JobCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("Please use `client.classify.list()`")]
    public async Task<JobListPage> List(
        JobListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("Please use `client.classify.get()`")]
    public async Task<ClassifyJob> Get(
        JobGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("Please use `client.classify.get()`")]
    public Task<ClassifyJob> Get(
        string classifyJobID,
        JobGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ClassifyJobID = classifyJobID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("Please use `client.classify.get()`")]
    public async Task<JobGetResultsResponse> GetResults(
        JobGetResultsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetResults(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("Please use `client.classify.get()`")]
    public Task<JobGetResultsResponse> GetResults(
        string classifyJobID,
        JobGetResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetResults(
            parameters with
            {
                ClassifyJobID = classifyJobID,
            },
            cancellationToken
        );
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

    /// <inheritdoc/>
    [Obsolete("Please use `client.classify.create()`")]
    public async Task<HttpResponse<ClassifyJob>> Create(
        JobCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<JobCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var classifyJob = await response
                    .Deserialize<ClassifyJob>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    classifyJob.Validate();
                }
                return classifyJob;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("Please use `client.classify.list()`")]
    public async Task<HttpResponse<JobListPage>> List(
        JobListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<JobListParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<JobListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new JobListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("Please use `client.classify.get()`")]
    public async Task<HttpResponse<ClassifyJob>> Get(
        JobGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ClassifyJobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.ClassifyJobID' cannot be null");
        }

        HttpRequest<JobGetParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var classifyJob = await response
                    .Deserialize<ClassifyJob>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    classifyJob.Validate();
                }
                return classifyJob;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("Please use `client.classify.get()`")]
    public Task<HttpResponse<ClassifyJob>> Get(
        string classifyJobID,
        JobGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ClassifyJobID = classifyJobID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("Please use `client.classify.get()`")]
    public async Task<HttpResponse<JobGetResultsResponse>> GetResults(
        JobGetResultsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ClassifyJobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.ClassifyJobID' cannot be null");
        }

        HttpRequest<JobGetResultsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<JobGetResultsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("Please use `client.classify.get()`")]
    public Task<HttpResponse<JobGetResultsResponse>> GetResults(
        string classifyJobID,
        JobGetResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetResults(
            parameters with
            {
                ClassifyJobID = classifyJobID,
            },
            cancellationToken
        );
    }
}
