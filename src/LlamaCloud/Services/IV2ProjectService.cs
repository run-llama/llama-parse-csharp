using System;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Models.V2Projects;

namespace LlamaCloud.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IV2ProjectService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IV2ProjectServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV2ProjectService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List projects in an organization. Requires `organization_id` or a project-scoped
    /// API key.
    /// </summary>
    Task<V2ProjectListPage> List(
        V2ProjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a project by ID.
    /// </summary>
    Task<V2ProjectGetResponse> Get(
        V2ProjectGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(V2ProjectGetParams, CancellationToken)"/>
    Task<V2ProjectGetResponse> Get(
        string projectID,
        V2ProjectGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IV2ProjectService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IV2ProjectServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV2ProjectServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v2/projects</c>, but is otherwise the
    /// same as <see cref="IV2ProjectService.List(V2ProjectListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V2ProjectListPage>> List(
        V2ProjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v2/projects/{project_id}</c>, but is otherwise the
    /// same as <see cref="IV2ProjectService.Get(V2ProjectGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V2ProjectGetResponse>> Get(
        V2ProjectGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(V2ProjectGetParams, CancellationToken)"/>
    Task<HttpResponse<V2ProjectGetResponse>> Get(
        string projectID,
        V2ProjectGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
