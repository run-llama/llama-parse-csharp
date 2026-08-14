using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Models.Retrievers;
using Retrievers = LlamaCloud.Services.Retrievers;

namespace LlamaCloud.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRetrieverService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRetrieverServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRetrieverService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Retrievers::IRetrieverService Retriever { get; }

    /// <summary>
    /// Create a new Retriever.
    /// </summary>
    Task<RetrieverRetriever> Create(
        RetrieverCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing Retriever.
    /// </summary>
    Task<RetrieverRetriever> Update(
        RetrieverUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(RetrieverUpdateParams, CancellationToken)"/>
    Task<RetrieverRetriever> Update(
        string retrieverID,
        RetrieverUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Retrievers for a project.
    /// </summary>
    Task<List<RetrieverRetriever>> List(
        RetrieverListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a Retriever by ID.
    /// </summary>
    Task Delete(RetrieverDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(RetrieverDeleteParams, CancellationToken)"/>
    Task Delete(
        string retrieverID,
        RetrieverDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a Retriever by ID.
    /// </summary>
    Task<RetrieverRetriever> Get(
        RetrieverGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(RetrieverGetParams, CancellationToken)"/>
    Task<RetrieverRetriever> Get(
        string retrieverID,
        RetrieverGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve data using specified pipelines without creating a persistent retriever.
    /// </summary>
    Task<CompositeRetrievalResult> Search(
        RetrieverSearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upsert a new Retriever.
    /// </summary>
    Task<RetrieverRetriever> Upsert(
        RetrieverUpsertParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRetrieverService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRetrieverServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRetrieverServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Retrievers::IRetrieverServiceWithRawResponse Retriever { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/retrievers</c>, but is otherwise the
    /// same as <see cref="IRetrieverService.Create(RetrieverCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RetrieverRetriever>> Create(
        RetrieverCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/retrievers/{retriever_id}</c>, but is otherwise the
    /// same as <see cref="IRetrieverService.Update(RetrieverUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RetrieverRetriever>> Update(
        RetrieverUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(RetrieverUpdateParams, CancellationToken)"/>
    Task<HttpResponse<RetrieverRetriever>> Update(
        string retrieverID,
        RetrieverUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/retrievers</c>, but is otherwise the
    /// same as <see cref="IRetrieverService.List(RetrieverListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<RetrieverRetriever>>> List(
        RetrieverListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/retrievers/{retriever_id}</c>, but is otherwise the
    /// same as <see cref="IRetrieverService.Delete(RetrieverDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        RetrieverDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(RetrieverDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string retrieverID,
        RetrieverDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/retrievers/{retriever_id}</c>, but is otherwise the
    /// same as <see cref="IRetrieverService.Get(RetrieverGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RetrieverRetriever>> Get(
        RetrieverGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(RetrieverGetParams, CancellationToken)"/>
    Task<HttpResponse<RetrieverRetriever>> Get(
        string retrieverID,
        RetrieverGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/retrievers/retrieve</c>, but is otherwise the
    /// same as <see cref="IRetrieverService.Search(RetrieverSearchParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CompositeRetrievalResult>> Search(
        RetrieverSearchParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/retrievers</c>, but is otherwise the
    /// same as <see cref="IRetrieverService.Upsert(RetrieverUpsertParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RetrieverRetriever>> Upsert(
        RetrieverUpsertParams parameters,
        CancellationToken cancellationToken = default
    );
}
