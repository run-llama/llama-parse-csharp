using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Split;

namespace LlamaIndex.LlamaCloud.Services;

/// <inheritdoc/>
public sealed class SplitService : ISplitService
{
    readonly Lazy<ISplitServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISplitServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public ISplitService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SplitService(this._client.WithOptions(modifier));
    }

    public SplitService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SplitServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<SplitCreateResponse> Create(
        SplitCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SplitListPage> List(
        SplitListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Delete(
        SplitDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JsonElement> Delete(
        string splitJobID,
        SplitDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { SplitJobID = splitJobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SplitCancelResponse> Cancel(
        SplitCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SplitCancelResponse> Cancel(
        string splitJobID,
        SplitCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { SplitJobID = splitJobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SplitGetResponse> Get(
        SplitGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SplitGetResponse> Get(
        string splitJobID,
        SplitGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { SplitJobID = splitJobID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SplitServiceWithRawResponse : ISplitServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISplitServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SplitServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SplitServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SplitCreateResponse>> Create(
        SplitCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SplitCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var split = await response
                    .Deserialize<SplitCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    split.Validate();
                }
                return split;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SplitListPage>> List(
        SplitListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SplitListParams> request = new()
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
                    .Deserialize<SplitListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SplitListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> Delete(
        SplitDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SplitJobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.SplitJobID' cannot be null");
        }

        HttpRequest<SplitDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
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
    public Task<HttpResponse<JsonElement>> Delete(
        string splitJobID,
        SplitDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { SplitJobID = splitJobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SplitCancelResponse>> Cancel(
        SplitCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SplitJobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.SplitJobID' cannot be null");
        }

        HttpRequest<SplitCancelParams> request = new()
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
                    .Deserialize<SplitCancelResponse>(token)
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
    public Task<HttpResponse<SplitCancelResponse>> Cancel(
        string splitJobID,
        SplitCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { SplitJobID = splitJobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SplitGetResponse>> Get(
        SplitGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SplitJobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.SplitJobID' cannot be null");
        }

        HttpRequest<SplitGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var split = await response
                    .Deserialize<SplitGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    split.Validate();
                }
                return split;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SplitGetResponse>> Get(
        string splitJobID,
        SplitGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { SplitJobID = splitJobID }, cancellationToken);
    }
}
