using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.Retrieval;

namespace LlamaIndex.LlamaCloud.Services.Beta;

/// <inheritdoc/>
public sealed class RetrievalService : IRetrievalService
{
    readonly Lazy<IRetrievalServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRetrievalServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IRetrievalService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RetrievalService(this._client.WithOptions(modifier));
    }

    public RetrievalService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RetrievalServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<RetrievalRetrieveResponse> Retrieve(
        RetrievalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RetrievalFindPage> Find(
        RetrievalFindParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Find(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RetrievalGrepPage> Grep(
        RetrievalGrepParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Grep(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RetrievalReadResponse> Read(
        RetrievalReadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Read(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RetrievalServiceWithRawResponse : IRetrievalServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRetrievalServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RetrievalServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RetrievalServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RetrievalRetrieveResponse>> Retrieve(
        RetrievalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RetrievalRetrieveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var retrieval = await response
                    .Deserialize<RetrievalRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    retrieval.Validate();
                }
                return retrieval;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RetrievalFindPage>> Find(
        RetrievalFindParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RetrievalFindParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<RetrievalFindPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new RetrievalFindPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RetrievalGrepPage>> Grep(
        RetrievalGrepParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RetrievalGrepParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<RetrievalGrepPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new RetrievalGrepPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RetrievalReadResponse>> Read(
        RetrievalReadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RetrievalReadParams> request = new()
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
                    .Deserialize<RetrievalReadResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
