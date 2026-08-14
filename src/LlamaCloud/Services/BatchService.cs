using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Batches;

namespace LlamaCloud.Services;

/// <inheritdoc/>
public sealed class BatchService : IBatchService
{
    readonly Lazy<IBatchServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBatchServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BatchService(this._client.WithOptions(modifier));
    }

    public BatchService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BatchServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BatchCreateResponse> Create(
        BatchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BatchListPage> List(
        BatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BatchCancelResponse> Cancel(
        BatchCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BatchCancelResponse> Cancel(
        string batchID,
        BatchCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { BatchID = batchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BatchGetResponse> Get(
        BatchGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BatchGetResponse> Get(
        string batchID,
        BatchGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { BatchID = batchID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class BatchServiceWithRawResponse : IBatchServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBatchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BatchServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BatchServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BatchCreateResponse>> Create(
        BatchCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BatchCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var batch = await response
                    .Deserialize<BatchCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    batch.Validate();
                }
                return batch;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BatchListPage>> List(
        BatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BatchListParams> request = new()
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
                    .Deserialize<BatchListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new BatchListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BatchCancelResponse>> Cancel(
        BatchCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BatchID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.BatchID' cannot be null");
        }

        HttpRequest<BatchCancelParams> request = new()
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
                    .Deserialize<BatchCancelResponse>(token)
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
    public Task<HttpResponse<BatchCancelResponse>> Cancel(
        string batchID,
        BatchCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { BatchID = batchID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BatchGetResponse>> Get(
        BatchGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BatchID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.BatchID' cannot be null");
        }

        HttpRequest<BatchGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var batch = await response
                    .Deserialize<BatchGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    batch.Validate();
                }
                return batch;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BatchGetResponse>> Get(
        string batchID,
        BatchGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { BatchID = batchID }, cancellationToken);
    }
}
