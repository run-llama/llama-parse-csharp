using System;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.JobDataPoints;

namespace LlamaIndex.LlamaCloud.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IJobDataPointService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IJobDataPointServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJobDataPointService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns paginated job data points for the current project.
    /// </summary>
    Task<JobDataPointListPage> List(
        JobDataPointListParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IJobDataPointService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IJobDataPointServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IJobDataPointServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/job-data-points</c>, but is otherwise the
    /// same as <see cref="IJobDataPointService.List(JobDataPointListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JobDataPointListPage>> List(
        JobDataPointListParams parameters,
        CancellationToken cancellationToken = default
    );
}
