using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Services;

/// <inheritdoc/>
public sealed class ParsingService : IParsingService
{
    readonly Lazy<IParsingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IParsingServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IParsingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ParsingService(this._client.WithOptions(modifier));
    }

    public ParsingService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ParsingServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ParsingCreateResponse> Create(
        ParsingCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ParsingListPage> List(
        ParsingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ParsingCancelResponse> Cancel(
        ParsingCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ParsingCancelResponse> Cancel(
        string jobID,
        ParsingCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ParsingGetResponse> Get(
        ParsingGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ParsingGetResponse> Get(
        string jobID,
        ParsingGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ParsingListVersionsResponse> ListVersions(
        ParsingListVersionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListVersions(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ParsingServiceWithRawResponse : IParsingServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IParsingServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ParsingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ParsingServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ParsingCreateResponse>> Create(
        ParsingCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ParsingCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var parsing = await response
                    .Deserialize<ParsingCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    parsing.Validate();
                }
                return parsing;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ParsingListPage>> List(
        ParsingListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ParsingListParams> request = new()
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
                    .Deserialize<ParsingListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ParsingListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ParsingCancelResponse>> Cancel(
        ParsingCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<ParsingCancelParams> request = new()
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
                    .Deserialize<ParsingCancelResponse>(token)
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
    public Task<HttpResponse<ParsingCancelResponse>> Cancel(
        string jobID,
        ParsingCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ParsingGetResponse>> Get(
        ParsingGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<ParsingGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var parsing = await response
                    .Deserialize<ParsingGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    parsing.Validate();
                }
                return parsing;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ParsingGetResponse>> Get(
        string jobID,
        ParsingGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ParsingListVersionsResponse>> ListVersions(
        ParsingListVersionsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ParsingListVersionsParams> request = new()
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
                    .Deserialize<ParsingListVersionsResponse>(token)
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
