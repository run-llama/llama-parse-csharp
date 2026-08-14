using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Retrievers.Retriever;
using Retrievers = LlamaIndex.LlamaCloud.Models.Retrievers;

namespace LlamaIndex.LlamaCloud.Services.Retrievers;

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
    }

    /// <inheritdoc/>
    public async Task<Retrievers::CompositeRetrievalResult> Search(
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
    public Task<Retrievers::CompositeRetrievalResult> Search(
        string retrieverID,
        RetrieverSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Search(parameters with { RetrieverID = retrieverID }, cancellationToken);
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
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Retrievers::CompositeRetrievalResult>> Search(
        RetrieverSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RetrieverID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.RetrieverID' cannot be null");
        }

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
                    .Deserialize<Retrievers::CompositeRetrievalResult>(token)
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
    public Task<HttpResponse<Retrievers::CompositeRetrievalResult>> Search(
        string retrieverID,
        RetrieverSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Search(parameters with { RetrieverID = retrieverID }, cancellationToken);
    }
}
