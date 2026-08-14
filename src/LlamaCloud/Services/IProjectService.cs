using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Models.Projects;

namespace LlamaCloud.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IProjectService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProjectServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProjectService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List projects or get one by name
    /// </summary>
    Task<List<Project>> List(
        ProjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a project by ID.
    /// </summary>
    Task<Project> Get(ProjectGetParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Get(ProjectGetParams, CancellationToken)"/>
    Task<Project> Get(
        string projectID,
        ProjectGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IProjectService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProjectServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProjectServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/projects</c>, but is otherwise the
    /// same as <see cref="IProjectService.List(ProjectListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<Project>>> List(
        ProjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/projects/{project_id}</c>, but is otherwise the
    /// same as <see cref="IProjectService.Get(ProjectGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Project>> Get(
        ProjectGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(ProjectGetParams, CancellationToken)"/>
    Task<HttpResponse<Project>> Get(
        string projectID,
        ProjectGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
