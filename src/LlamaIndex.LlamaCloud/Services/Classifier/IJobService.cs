using System;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Classifier.Jobs;

namespace LlamaIndex.LlamaCloud.Services.Classifier;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IJobService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IJobServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJobService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a classify job. Experimental: not production-ready and subject to change.
    /// </summary>
    [Obsolete("Please use `client.classify.create()`")]
    Task<ClassifyJob> Create(
        JobCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List classify jobs. Experimental: not production-ready and subject to change.
    /// </summary>
    [Obsolete("Please use `client.classify.list()`")]
    Task<JobListPage> List(
        JobListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a classify job. Experimental: not production-ready and subject to change.
    /// </summary>
    [Obsolete("Please use `client.classify.get()`")]
    Task<ClassifyJob> Get(JobGetParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Get(JobGetParams, CancellationToken)"/>
    [Obsolete("Please use `client.classify.get()`")]
    Task<ClassifyJob> Get(
        string classifyJobID,
        JobGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the results of a classify job. Experimental: not production-ready and
    /// subject to change.
    /// </summary>
    [Obsolete("Please use `client.classify.get()`")]
    Task<JobGetResultsResponse> GetResults(
        JobGetResultsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetResults(JobGetResultsParams, CancellationToken)"/>
    [Obsolete("Please use `client.classify.get()`")]
    Task<JobGetResultsResponse> GetResults(
        string classifyJobID,
        JobGetResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IJobService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IJobServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJobServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/classifier/jobs</c>, but is otherwise the
    /// same as <see cref="IJobService.Create(JobCreateParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("Please use `client.classify.create()`")]
    Task<HttpResponse<ClassifyJob>> Create(
        JobCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/classifier/jobs</c>, but is otherwise the
    /// same as <see cref="IJobService.List(JobListParams?, CancellationToken)"/>.
    /// </summary>
    [Obsolete("Please use `client.classify.list()`")]
    Task<HttpResponse<JobListPage>> List(
        JobListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/classifier/jobs/{classify_job_id}</c>, but is otherwise the
    /// same as <see cref="IJobService.Get(JobGetParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("Please use `client.classify.get()`")]
    Task<HttpResponse<ClassifyJob>> Get(
        JobGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(JobGetParams, CancellationToken)"/>
    [Obsolete("Please use `client.classify.get()`")]
    Task<HttpResponse<ClassifyJob>> Get(
        string classifyJobID,
        JobGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/classifier/jobs/{classify_job_id}/results</c>, but is otherwise the
    /// same as <see cref="IJobService.GetResults(JobGetResultsParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("Please use `client.classify.get()`")]
    Task<HttpResponse<JobGetResultsResponse>> GetResults(
        JobGetResultsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetResults(JobGetResultsParams, CancellationToken)"/>
    [Obsolete("Please use `client.classify.get()`")]
    Task<HttpResponse<JobGetResultsResponse>> GetResults(
        string classifyJobID,
        JobGetResultsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
