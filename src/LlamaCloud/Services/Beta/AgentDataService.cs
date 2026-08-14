using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Beta.AgentData;

namespace LlamaCloud.Services.Beta;

/// <inheritdoc/>
public sealed class AgentDataService : IAgentDataService
{
    readonly Lazy<IAgentDataServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAgentDataServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IAgentDataService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AgentDataService(this._client.WithOptions(modifier));
    }

    public AgentDataService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AgentDataServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AgentDataAgentData> Create(
        AgentDataCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AgentDataAgentData> Update(
        AgentDataUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AgentDataAgentData> Update(
        string itemID,
        AgentDataUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Dictionary<string, string>> Delete(
        AgentDataDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Dictionary<string, string>> Delete(
        string itemID,
        AgentDataDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AgentDataAggregatePage> Aggregate(
        AgentDataAggregateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Aggregate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AgentDataDeleteByQueryResponse> DeleteByQuery(
        AgentDataDeleteByQueryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.DeleteByQuery(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AgentDataAgentData> Get(
        AgentDataGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AgentDataAgentData> Get(
        string itemID,
        AgentDataGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AgentDataSearchPage> Search(
        AgentDataSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Search(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AgentDataServiceWithRawResponse : IAgentDataServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAgentDataServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AgentDataServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AgentDataServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentDataAgentData>> Create(
        AgentDataCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AgentDataCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var agentData = await response
                    .Deserialize<AgentDataAgentData>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    agentData.Validate();
                }
                return agentData;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentDataAgentData>> Update(
        AgentDataUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ItemID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.ItemID' cannot be null");
        }

        HttpRequest<AgentDataUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var agentData = await response
                    .Deserialize<AgentDataAgentData>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    agentData.Validate();
                }
                return agentData;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AgentDataAgentData>> Update(
        string itemID,
        AgentDataUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dictionary<string, string>>> Delete(
        AgentDataDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ItemID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.ItemID' cannot be null");
        }

        HttpRequest<AgentDataDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response
                    .Deserialize<Dictionary<string, string>>(token)
                    .ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Dictionary<string, string>>> Delete(
        string itemID,
        AgentDataDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentDataAggregatePage>> Aggregate(
        AgentDataAggregateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AgentDataAggregateParams> request = new()
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
                    .Deserialize<AgentDataAggregatePageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AgentDataAggregatePage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentDataDeleteByQueryResponse>> DeleteByQuery(
        AgentDataDeleteByQueryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AgentDataDeleteByQueryParams> request = new()
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
                    .Deserialize<AgentDataDeleteByQueryResponse>(token)
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
    public async Task<HttpResponse<AgentDataAgentData>> Get(
        AgentDataGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ItemID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.ItemID' cannot be null");
        }

        HttpRequest<AgentDataGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var agentData = await response
                    .Deserialize<AgentDataAgentData>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    agentData.Validate();
                }
                return agentData;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AgentDataAgentData>> Get(
        string itemID,
        AgentDataGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ItemID = itemID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentDataSearchPage>> Search(
        AgentDataSearchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AgentDataSearchParams> request = new()
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
                    .Deserialize<AgentDataSearchPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AgentDataSearchPage(this, parameters, page);
            }
        );
    }
}
