using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.AgentData;

namespace LlamaIndex.LlamaCloud.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAgentDataService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAgentDataServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentDataService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create new agent data.
    /// </summary>
    Task<AgentDataAgentData> Create(
        AgentDataCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update agent data by ID (overwrites).
    /// </summary>
    Task<AgentDataAgentData> Update(
        AgentDataUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AgentDataUpdateParams, CancellationToken)"/>
    Task<AgentDataAgentData> Update(
        string itemID,
        AgentDataUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete agent data by ID.
    /// </summary>
    Task<Dictionary<string, string>> Delete(
        AgentDataDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(AgentDataDeleteParams, CancellationToken)"/>
    Task<Dictionary<string, string>> Delete(
        string itemID,
        AgentDataDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Aggregate agent data with grouping and optional counting/first item retrieval.
    /// </summary>
    Task<AgentDataAggregatePage> Aggregate(
        AgentDataAggregateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Bulk delete agent data by query (deployment_name, collection, optional filters).
    /// </summary>
    Task<AgentDataDeleteByQueryResponse> DeleteByQuery(
        AgentDataDeleteByQueryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get agent data by ID.
    /// </summary>
    Task<AgentDataAgentData> Get(
        AgentDataGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(AgentDataGetParams, CancellationToken)"/>
    Task<AgentDataAgentData> Get(
        string itemID,
        AgentDataGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Search agent data with filtering, sorting, and pagination.
    /// </summary>
    Task<AgentDataSearchPage> Search(
        AgentDataSearchParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAgentDataService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAgentDataServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentDataServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/beta/agent-data</c>, but is otherwise the
    /// same as <see cref="IAgentDataService.Create(AgentDataCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentDataAgentData>> Create(
        AgentDataCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/beta/agent-data/{item_id}</c>, but is otherwise the
    /// same as <see cref="IAgentDataService.Update(AgentDataUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentDataAgentData>> Update(
        AgentDataUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AgentDataUpdateParams, CancellationToken)"/>
    Task<HttpResponse<AgentDataAgentData>> Update(
        string itemID,
        AgentDataUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/beta/agent-data/{item_id}</c>, but is otherwise the
    /// same as <see cref="IAgentDataService.Delete(AgentDataDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Dictionary<string, string>>> Delete(
        AgentDataDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(AgentDataDeleteParams, CancellationToken)"/>
    Task<HttpResponse<Dictionary<string, string>>> Delete(
        string itemID,
        AgentDataDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/beta/agent-data/:aggregate</c>, but is otherwise the
    /// same as <see cref="IAgentDataService.Aggregate(AgentDataAggregateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentDataAggregatePage>> Aggregate(
        AgentDataAggregateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/beta/agent-data/:delete</c>, but is otherwise the
    /// same as <see cref="IAgentDataService.DeleteByQuery(AgentDataDeleteByQueryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentDataDeleteByQueryResponse>> DeleteByQuery(
        AgentDataDeleteByQueryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/agent-data/{item_id}</c>, but is otherwise the
    /// same as <see cref="IAgentDataService.Get(AgentDataGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentDataAgentData>> Get(
        AgentDataGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(AgentDataGetParams, CancellationToken)"/>
    Task<HttpResponse<AgentDataAgentData>> Get(
        string itemID,
        AgentDataGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/beta/agent-data/:search</c>, but is otherwise the
    /// same as <see cref="IAgentDataService.Search(AgentDataSearchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentDataSearchPage>> Search(
        AgentDataSearchParams parameters,
        CancellationToken cancellationToken = default
    );
}
