using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.V2Projects;

namespace LlamaCloud.Services;

/// <inheritdoc/>
public sealed class V2ProjectService : IV2ProjectService
{
    readonly Lazy<IV2ProjectServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IV2ProjectServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IV2ProjectService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V2ProjectService(this._client.WithOptions(modifier));
    }

    public V2ProjectService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new V2ProjectServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<V2ProjectListPage> List(
        V2ProjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<V2ProjectGetResponse> Get(
        V2ProjectGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<V2ProjectGetResponse> Get(
        string projectID,
        V2ProjectGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ProjectID = projectID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class V2ProjectServiceWithRawResponse : IV2ProjectServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IV2ProjectServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V2ProjectServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public V2ProjectServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<V2ProjectListPage>> List(
        V2ProjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<V2ProjectListParams> request = new()
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
                    .Deserialize<V2ProjectListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new V2ProjectListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<V2ProjectGetResponse>> Get(
        V2ProjectGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProjectID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.ProjectID' cannot be null");
        }

        HttpRequest<V2ProjectGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var v2Project = await response
                    .Deserialize<V2ProjectGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    v2Project.Validate();
                }
                return v2Project;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<V2ProjectGetResponse>> Get(
        string projectID,
        V2ProjectGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ProjectID = projectID }, cancellationToken);
    }
}
