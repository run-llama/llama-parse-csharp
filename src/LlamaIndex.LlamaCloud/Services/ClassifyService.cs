using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Classify;

namespace LlamaIndex.LlamaCloud.Services;

/// <inheritdoc/>
public sealed class ClassifyService : IClassifyService
{
    readonly Lazy<IClassifyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IClassifyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IClassifyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ClassifyService(this._client.WithOptions(modifier));
    }

    public ClassifyService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ClassifyServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ClassifyCreateResponse> Create(
        ClassifyCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ClassifyListPage> List(
        ClassifyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ClassifyCancelResponse> Cancel(
        ClassifyCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ClassifyCancelResponse> Cancel(
        string jobID,
        ClassifyCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ClassifyGetResponse> Get(
        ClassifyGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ClassifyGetResponse> Get(
        string jobID,
        ClassifyGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { JobID = jobID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ClassifyServiceWithRawResponse : IClassifyServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IClassifyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ClassifyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ClassifyServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ClassifyCreateResponse>> Create(
        ClassifyCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ClassifyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var classify = await response
                    .Deserialize<ClassifyCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    classify.Validate();
                }
                return classify;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ClassifyListPage>> List(
        ClassifyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ClassifyListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<ClassifyListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ClassifyListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ClassifyCancelResponse>> Cancel(
        ClassifyCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<ClassifyCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<ClassifyCancelResponse>(token)
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
    public Task<HttpResponse<ClassifyCancelResponse>> Cancel(
        string jobID,
        ClassifyCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ClassifyGetResponse>> Get(
        ClassifyGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<ClassifyGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var classify = await response
                    .Deserialize<ClassifyGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    classify.Validate();
                }
                return classify;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ClassifyGetResponse>> Get(
        string jobID,
        ClassifyGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { JobID = jobID }, cancellationToken);
    }
}
