using System;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines;
using LlamaIndex.LlamaCloud.Models.Pipelines.Sync;

namespace LlamaIndex.LlamaCloud.Services.Pipelines;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISyncService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISyncServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISyncService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Trigger an incremental sync for a managed pipeline.
    ///
    /// <para>Processes new and updated documents from data sources and files, then
    /// updates the index for retrieval.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<Pipeline> Create(
        SyncCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(SyncCreateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<Pipeline> Create(
        string pipelineID,
        SyncCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel all running sync jobs for a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task<Pipeline> Cancel(
        SyncCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(SyncCancelParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<Pipeline> Cancel(
        string pipelineID,
        SyncCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISyncService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISyncServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISyncServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/pipelines/{pipeline_id}/sync</c>, but is otherwise the
    /// same as <see cref="ISyncService.Create(SyncCreateParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<Pipeline>> Create(
        SyncCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(SyncCreateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<Pipeline>> Create(
        string pipelineID,
        SyncCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/pipelines/{pipeline_id}/sync/cancel</c>, but is otherwise the
    /// same as <see cref="ISyncService.Cancel(SyncCancelParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<Pipeline>> Cancel(
        SyncCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(SyncCancelParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<Pipeline>> Cancel(
        string pipelineID,
        SyncCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
