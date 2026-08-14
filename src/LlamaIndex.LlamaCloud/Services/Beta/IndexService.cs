using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Beta.Indexes;

namespace LlamaIndex.LlamaCloud.Services.Beta;

/// <inheritdoc/>
public sealed class IndexService : IIndexService
{
    readonly Lazy<IIndexServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IIndexServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IIndexService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IndexService(this._client.WithOptions(modifier));
    }

    public IndexService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new IndexServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<IndexCreateResponse> Create(
        IndexCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<IndexListPage> List(
        IndexListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(IndexDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string indexID,
        IndexDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { IndexID = indexID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<IndexGetResponse> Get(
        IndexGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<IndexGetResponse> Get(
        string indexID,
        IndexGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { IndexID = indexID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Sync(
        IndexSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Sync(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JsonElement> Sync(
        string indexID,
        IndexSyncParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Sync(parameters with { IndexID = indexID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class IndexServiceWithRawResponse : IIndexServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IIndexServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IndexServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public IndexServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IndexCreateResponse>> Create(
        IndexCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IndexCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var index = await response
                    .Deserialize<IndexCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    index.Validate();
                }
                return index;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IndexListPage>> List(
        IndexListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<IndexListParams> request = new()
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
                    .Deserialize<IndexListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new IndexListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        IndexDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.IndexID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.IndexID' cannot be null");
        }

        HttpRequest<IndexDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string indexID,
        IndexDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { IndexID = indexID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IndexGetResponse>> Get(
        IndexGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.IndexID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.IndexID' cannot be null");
        }

        HttpRequest<IndexGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var index = await response
                    .Deserialize<IndexGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    index.Validate();
                }
                return index;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<IndexGetResponse>> Get(
        string indexID,
        IndexGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { IndexID = indexID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> Sync(
        IndexSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.IndexID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.IndexID' cannot be null");
        }

        HttpRequest<IndexSyncParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> Sync(
        string indexID,
        IndexSyncParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Sync(parameters with { IndexID = indexID }, cancellationToken);
    }
}
