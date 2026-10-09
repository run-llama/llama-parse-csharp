using System;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Models.Alpha.Verify;

namespace LlamaCloud.Services.Alpha;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IVerifyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVerifyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerifyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Verify job.
    ///
    /// <para>Analyzes a document for signs of doctoring (splicing, copy-move, AI
    /// generation, metadata tampering, ...). Set `file_input` to a file ID (`dfl-...`).
    /// Optionally provide a `configuration` object to control the semantic agent.</para>
    ///
    /// <para>The job runs asynchronously. Poll `GET /verify/{job_id}` with
    /// `expand=result` to check status and retrieve results.</para>
    /// </summary>
    Task<VerifyCreateResponse> Create(
        VerifyCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Verify jobs with optional filtering and pagination.
    ///
    /// <para>Filter by `status`, specific `job_ids`, or creation date range.</para>
    /// </summary>
    Task<VerifyListPage> List(
        VerifyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a running Verify job.
    ///
    /// <para>Stops processing and marks the job as CANCELLED. Returns the updated job.
    /// Jobs already in a terminal state (COMPLETED, FAILED, CANCELLED) cannot be
    /// cancelled.</para>
    /// </summary>
    Task<VerifyCancelResponse> Cancel(
        VerifyCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(VerifyCancelParams, CancellationToken)"/>
    Task<VerifyCancelResponse> Cancel(
        string jobID,
        VerifyCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a Verify job by ID.
    ///
    /// <para>Returns the job status and configuration. Pass `expand=result` to include
    /// the Verify result (overall score, verdict, confidence, composite scores, and
    /// suspect regions) when the job is complete.</para>
    ///
    /// <para>Raw per-signal detail is available via `GET /verify/{job_id}/details`.</para>
    /// </summary>
    Task<VerifyGetResponse> Get(
        VerifyGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(VerifyGetParams, CancellationToken)"/>
    Task<VerifyGetResponse> Get(
        string jobID,
        VerifyGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the raw per-signal detail for a completed Verify job.
    ///
    /// <para>Forensic drill-down behind the simplified result: the full evidence list,
    /// per-family sub-scores, raw localized regions, and per-page forensic heatmap
    /// overlays (presigned image URLs).</para>
    /// </summary>
    Task<VerifyGetDetailsResponse> GetDetails(
        VerifyGetDetailsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetDetails(VerifyGetDetailsParams, CancellationToken)"/>
    Task<VerifyGetDetailsResponse> GetDetails(
        string jobID,
        VerifyGetDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IVerifyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVerifyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVerifyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/alpha/verify</c>, but is otherwise the
    /// same as <see cref="IVerifyService.Create(VerifyCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VerifyCreateResponse>> Create(
        VerifyCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/alpha/verify</c>, but is otherwise the
    /// same as <see cref="IVerifyService.List(VerifyListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VerifyListPage>> List(
        VerifyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/alpha/verify/{job_id}/cancel</c>, but is otherwise the
    /// same as <see cref="IVerifyService.Cancel(VerifyCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VerifyCancelResponse>> Cancel(
        VerifyCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(VerifyCancelParams, CancellationToken)"/>
    Task<HttpResponse<VerifyCancelResponse>> Cancel(
        string jobID,
        VerifyCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/alpha/verify/{job_id}</c>, but is otherwise the
    /// same as <see cref="IVerifyService.Get(VerifyGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VerifyGetResponse>> Get(
        VerifyGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(VerifyGetParams, CancellationToken)"/>
    Task<HttpResponse<VerifyGetResponse>> Get(
        string jobID,
        VerifyGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/alpha/verify/{job_id}/details</c>, but is otherwise the
    /// same as <see cref="IVerifyService.GetDetails(VerifyGetDetailsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VerifyGetDetailsResponse>> GetDetails(
        VerifyGetDetailsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetDetails(VerifyGetDetailsParams, CancellationToken)"/>
    Task<HttpResponse<VerifyGetDetailsResponse>> GetDetails(
        string jobID,
        VerifyGetDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
