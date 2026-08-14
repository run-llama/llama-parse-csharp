using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.Indexes;

namespace LlamaIndex.LlamaCloud.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IIndexService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IIndexServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIndexService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a searchable index over a source directory.
    /// </summary>
    Task<IndexCreateResponse> Create(
        IndexCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List indexes for the current project.
    /// </summary>
    Task<IndexListPage> List(
        IndexListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an index.
    /// </summary>
    Task Delete(IndexDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(IndexDeleteParams, CancellationToken)"/>
    Task Delete(
        string indexID,
        IndexDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get an index by ID.
    /// </summary>
    Task<IndexGetResponse> Get(
        IndexGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(IndexGetParams, CancellationToken)"/>
    Task<IndexGetResponse> Get(
        string indexID,
        IndexGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Trigger a sync and export for an existing index, re-parsing changed files and
    /// exporting updated chunks.
    /// </summary>
    Task<JsonElement> Sync(
        IndexSyncParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Sync(IndexSyncParams, CancellationToken)"/>
    Task<JsonElement> Sync(
        string indexID,
        IndexSyncParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IIndexService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IIndexServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IIndexServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/indexes</c>, but is otherwise the
    /// same as <see cref="IIndexService.Create(IndexCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IndexCreateResponse>> Create(
        IndexCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/indexes</c>, but is otherwise the
    /// same as <see cref="IIndexService.List(IndexListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IndexListPage>> List(
        IndexListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/indexes/{index_id}</c>, but is otherwise the
    /// same as <see cref="IIndexService.Delete(IndexDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        IndexDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(IndexDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string indexID,
        IndexDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/indexes/{index_id}</c>, but is otherwise the
    /// same as <see cref="IIndexService.Get(IndexGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<IndexGetResponse>> Get(
        IndexGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(IndexGetParams, CancellationToken)"/>
    Task<HttpResponse<IndexGetResponse>> Get(
        string indexID,
        IndexGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/indexes/{index_id}/sync</c>, but is otherwise the
    /// same as <see cref="IIndexService.Sync(IndexSyncParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JsonElement>> Sync(
        IndexSyncParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Sync(IndexSyncParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> Sync(
        string indexID,
        IndexSyncParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
