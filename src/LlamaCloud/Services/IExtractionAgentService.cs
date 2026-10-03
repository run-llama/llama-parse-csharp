using System;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Models.ExtractionAgents;

namespace LlamaCloud.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IExtractionAgentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExtractionAgentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExtractionAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List the extraction agents in a project, newest first.
    /// </summary>
    Task<ExtractionAgentListPage> List(
        ExtractionAgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExtractionAgentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExtractionAgentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExtractionAgentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/extraction-agents</c>, but is otherwise the
    /// same as <see cref="IExtractionAgentService.List(ExtractionAgentListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExtractionAgentListPage>> List(
        ExtractionAgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
