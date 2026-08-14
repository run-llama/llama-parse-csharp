using System;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Models.Beta.Split;

namespace LlamaCloud.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISplitService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISplitServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISplitService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a document split job.
    /// </summary>
    Task<SplitCreateResponse> Create(
        SplitCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List document split jobs.
    /// </summary>
    Task<SplitListPage> List(
        SplitListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a document split job.
    /// </summary>
    Task<SplitGetResponse> Get(
        SplitGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(SplitGetParams, CancellationToken)"/>
    Task<SplitGetResponse> Get(
        string splitJobID,
        SplitGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISplitService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISplitServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISplitServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/beta/split/jobs</c>, but is otherwise the
    /// same as <see cref="ISplitService.Create(SplitCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SplitCreateResponse>> Create(
        SplitCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/split/jobs</c>, but is otherwise the
    /// same as <see cref="ISplitService.List(SplitListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SplitListPage>> List(
        SplitListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/split/jobs/{split_job_id}</c>, but is otherwise the
    /// same as <see cref="ISplitService.Get(SplitGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SplitGetResponse>> Get(
        SplitGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(SplitGetParams, CancellationToken)"/>
    Task<HttpResponse<SplitGetResponse>> Get(
        string splitJobID,
        SplitGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
