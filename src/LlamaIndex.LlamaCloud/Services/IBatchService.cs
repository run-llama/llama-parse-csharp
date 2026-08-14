using System;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Batches;

namespace LlamaIndex.LlamaCloud.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBatchService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBatchServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBatchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a batch over a source directory and start processing asynchronously.
    ///
    /// <para>To be notified as the batch progresses, pass `webhook_configurations` with
    /// inline endpoints and/or `webhook_configuration_ids` referencing saved
    /// configurations. Batches emit `batch.pending` on create, `batch.running` once
    /// processing starts, and a terminal `batch.success` or `batch.error`.</para>
    ///
    /// <para>`batch.success` means the batch finished mapping every source file to a
    /// job — individual files may still have failed, so read `results` (with
    /// `expand=results`) for per-file outcomes.</para>
    ///
    /// <para>Delivery order across events is not guaranteed; key on the `status` field
    /// in the payload rather than arrival order.</para>
    /// </summary>
    Task<BatchCreateResponse> Create(
        BatchCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List batches for the current project.
    /// </summary>
    Task<BatchListPage> List(
        BatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a running batch.
    ///
    /// <para>Returns immediately; the batch reaches `CANCELLED` once processing stops.
    /// Files that already finished keep their results. A batch in a terminal status
    /// cannot be cancelled.</para>
    /// </summary>
    Task<BatchCancelResponse> Cancel(
        BatchCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(BatchCancelParams, CancellationToken)"/>
    Task<BatchCancelResponse> Cancel(
        string batchID,
        BatchCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a batch by ID.
    /// </summary>
    Task<BatchGetResponse> Get(
        BatchGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(BatchGetParams, CancellationToken)"/>
    Task<BatchGetResponse> Get(
        string batchID,
        BatchGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBatchService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBatchServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBatchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v2/batches</c>, but is otherwise the
    /// same as <see cref="IBatchService.Create(BatchCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BatchCreateResponse>> Create(
        BatchCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v2/batches</c>, but is otherwise the
    /// same as <see cref="IBatchService.List(BatchListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BatchListPage>> List(
        BatchListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v2/batches/{batch_id}/cancel</c>, but is otherwise the
    /// same as <see cref="IBatchService.Cancel(BatchCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BatchCancelResponse>> Cancel(
        BatchCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(BatchCancelParams, CancellationToken)"/>
    Task<HttpResponse<BatchCancelResponse>> Cancel(
        string batchID,
        BatchCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v2/batches/{batch_id}</c>, but is otherwise the
    /// same as <see cref="IBatchService.Get(BatchGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BatchGetResponse>> Get(
        BatchGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(BatchGetParams, CancellationToken)"/>
    Task<HttpResponse<BatchGetResponse>> Get(
        string batchID,
        BatchGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
