using System;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Classify;

namespace LlamaIndex.LlamaCloud.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IClassifyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IClassifyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IClassifyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a classify job.
    ///
    /// <para>Classifies a document against a set of rules. Set `file_input` to a file
    /// ID (`dfl-...`) or parse job ID (`pjb-...`), and provide either inline
    /// `configuration` with rules or a `configuration_id` referencing a saved preset.</para>
    ///
    /// <para>Each rule has a `type` (the label to assign) and a `description` (natural
    /// language criteria). The classifier returns the best matching rule with a
    /// confidence score.</para>
    ///
    /// <para>The job runs asynchronously. Poll `GET /classify/{job_id}` to check status
    /// and retrieve results.</para>
    /// </summary>
    Task<ClassifyCreateResponse> Create(
        ClassifyCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List classify jobs with optional filtering and pagination.
    ///
    /// <para>Filter by `status`, `configuration_id`, specific `job_ids`, or creation
    /// date range.</para>
    /// </summary>
    Task<ClassifyListPage> List(
        ClassifyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a running classify job.
    ///
    /// <para>Stops processing and marks the job as CANCELLED. Returns the updated job.
    /// Jobs already in a terminal state (COMPLETED, FAILED, CANCELLED) cannot be
    /// cancelled.</para>
    /// </summary>
    Task<ClassifyCancelResponse> Cancel(
        ClassifyCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(ClassifyCancelParams, CancellationToken)"/>
    Task<ClassifyCancelResponse> Cancel(
        string jobID,
        ClassifyCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a classify job by ID.
    ///
    /// <para>Returns the job status, configuration, and classify result when complete.
    /// The result includes the matched document type, confidence score, and reasoning.</para>
    /// </summary>
    Task<ClassifyGetResponse> Get(
        ClassifyGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(ClassifyGetParams, CancellationToken)"/>
    Task<ClassifyGetResponse> Get(
        string jobID,
        ClassifyGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IClassifyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IClassifyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IClassifyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v2/classify</c>, but is otherwise the
    /// same as <see cref="IClassifyService.Create(ClassifyCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ClassifyCreateResponse>> Create(
        ClassifyCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v2/classify</c>, but is otherwise the
    /// same as <see cref="IClassifyService.List(ClassifyListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ClassifyListPage>> List(
        ClassifyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v2/classify/{job_id}/cancel</c>, but is otherwise the
    /// same as <see cref="IClassifyService.Cancel(ClassifyCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ClassifyCancelResponse>> Cancel(
        ClassifyCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(ClassifyCancelParams, CancellationToken)"/>
    Task<HttpResponse<ClassifyCancelResponse>> Cancel(
        string jobID,
        ClassifyCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v2/classify/{job_id}</c>, but is otherwise the
    /// same as <see cref="IClassifyService.Get(ClassifyGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ClassifyGetResponse>> Get(
        ClassifyGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(ClassifyGetParams, CancellationToken)"/>
    Task<HttpResponse<ClassifyGetResponse>> Get(
        string jobID,
        ClassifyGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
