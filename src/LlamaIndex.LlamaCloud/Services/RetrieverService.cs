using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Retrievers;
using Retrievers = LlamaIndex.LlamaCloud.Services.Retrievers;

namespace LlamaIndex.LlamaCloud.Services;

/// <inheritdoc/>
public sealed class RetrieverService : IRetrieverService
{
    readonly Lazy<IRetrieverServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRetrieverServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IRetrieverService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RetrieverService(this._client.WithOptions(modifier));
    }

    public RetrieverService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RetrieverServiceWithRawResponse(client.WithRawResponse));
        _retriever = new(() => new Retrievers::RetrieverService(client));
    }

    readonly Lazy<Retrievers::IRetrieverService> _retriever;
    public Retrievers::IRetrieverService Retriever
    {
        get { return _retriever.Value; }
    }

    /// <inheritdoc/>
    public async Task<RetrieverRetriever> Create(
        RetrieverCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RetrieverRetriever> Update(
        RetrieverUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RetrieverRetriever> Update(
        string retrieverID,
        RetrieverUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { RetrieverID = retrieverID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<RetrieverRetriever>> List(
        RetrieverListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        RetrieverDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string retrieverID,
        RetrieverDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { RetrieverID = retrieverID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RetrieverRetriever> Get(
        RetrieverGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RetrieverRetriever> Get(
        string retrieverID,
        RetrieverGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { RetrieverID = retrieverID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CompositeRetrievalResult> Search(
        RetrieverSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Search(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RetrieverRetriever> Upsert(
        RetrieverUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Upsert(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RetrieverServiceWithRawResponse : IRetrieverServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRetrieverServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RetrieverServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RetrieverServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;

        _retriever = new(() => new Retrievers::RetrieverServiceWithRawResponse(client));
    }

    readonly Lazy<Retrievers::IRetrieverServiceWithRawResponse> _retriever;
    public Retrievers::IRetrieverServiceWithRawResponse Retriever
    {
        get { return _retriever.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RetrieverRetriever>> Create(
        RetrieverCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RetrieverCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var retriever = await response
                    .Deserialize<RetrieverRetriever>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    retriever.Validate();
                }
                return retriever;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RetrieverRetriever>> Update(
        RetrieverUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RetrieverID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.RetrieverID' cannot be null");
        }

        HttpRequest<RetrieverUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var retriever = await response
                    .Deserialize<RetrieverRetriever>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    retriever.Validate();
                }
                return retriever;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RetrieverRetriever>> Update(
        string retrieverID,
        RetrieverUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { RetrieverID = retrieverID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<RetrieverRetriever>>> List(
        RetrieverListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RetrieverListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var retrievers = await response
                    .Deserialize<List<RetrieverRetriever>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in retrievers)
                    {
                        item.Validate();
                    }
                }
                return retrievers;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        RetrieverDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RetrieverID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.RetrieverID' cannot be null");
        }

        HttpRequest<RetrieverDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string retrieverID,
        RetrieverDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { RetrieverID = retrieverID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RetrieverRetriever>> Get(
        RetrieverGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RetrieverID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.RetrieverID' cannot be null");
        }

        HttpRequest<RetrieverGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var retriever = await response
                    .Deserialize<RetrieverRetriever>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    retriever.Validate();
                }
                return retriever;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RetrieverRetriever>> Get(
        string retrieverID,
        RetrieverGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { RetrieverID = retrieverID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CompositeRetrievalResult>> Search(
        RetrieverSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RetrieverSearchParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var compositeRetrievalResult = await response
                    .Deserialize<CompositeRetrievalResult>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    compositeRetrievalResult.Validate();
                }
                return compositeRetrievalResult;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RetrieverRetriever>> Upsert(
        RetrieverUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RetrieverUpsertParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var retriever = await response
                    .Deserialize<RetrieverRetriever>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    retriever.Validate();
                }
                return retriever;
            }
        );
    }
}
