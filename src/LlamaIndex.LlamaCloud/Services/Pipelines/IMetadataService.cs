using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines.Metadata;

namespace LlamaIndex.LlamaCloud.Services.Pipelines;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMetadataService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMetadataServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMetadataService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Import metadata for a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task<Dictionary<string, string>> Create(
        MetadataCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(MetadataCreateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<Dictionary<string, string>> Create(
        string pipelineID,
        MetadataCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete metadata for all files in a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task DeleteAll(
        MetadataDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteAll(MetadataDeleteAllParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task DeleteAll(
        string pipelineID,
        MetadataDeleteAllParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMetadataService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMetadataServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMetadataServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/pipelines/{pipeline_id}/metadata</c>, but is otherwise the
    /// same as <see cref="IMetadataService.Create(MetadataCreateParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<Dictionary<string, string>>> Create(
        MetadataCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(MetadataCreateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<Dictionary<string, string>>> Create(
        string pipelineID,
        MetadataCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/pipelines/{pipeline_id}/metadata</c>, but is otherwise the
    /// same as <see cref="IMetadataService.DeleteAll(MetadataDeleteAllParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse> DeleteAll(
        MetadataDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteAll(MetadataDeleteAllParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse> DeleteAll(
        string pipelineID,
        MetadataDeleteAllParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
