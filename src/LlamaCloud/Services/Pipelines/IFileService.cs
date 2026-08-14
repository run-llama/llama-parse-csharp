using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Models.Pipelines;
using LlamaCloud.Models.Pipelines.Files;

namespace LlamaCloud.Services.Pipelines;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Add files to a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task<List<PipelineFile>> Create(
        FileCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(FileCreateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<List<PipelineFile>> Create(
        string pipelineID,
        FileCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a file for a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task<PipelineFile> Update(
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(FileUpdateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<PipelineFile> Update(
        string fileID,
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List files for a pipeline with optional filtering, sorting, and pagination.
    /// </summary>
    [Obsolete("deprecated")]
    Task<FileListPage> List(
        FileListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(FileListParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<FileListPage> List(
        string pipelineID,
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a file from a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task Delete(FileDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(FileDeleteParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task Delete(
        string fileID,
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get status of a file for a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task<ManagedIngestionStatusResponse> GetStatus(
        FileGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatus(FileGetStatusParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<ManagedIngestionStatusResponse> GetStatus(
        string fileID,
        FileGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get files for a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task<FileGetStatusCountsResponse> GetStatusCounts(
        FileGetStatusCountsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatusCounts(FileGetStatusCountsParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<FileGetStatusCountsResponse> GetStatusCounts(
        string pipelineID,
        FileGetStatusCountsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/pipelines/{pipeline_id}/files</c>, but is otherwise the
    /// same as <see cref="IFileService.Create(FileCreateParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<List<PipelineFile>>> Create(
        FileCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(FileCreateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<List<PipelineFile>>> Create(
        string pipelineID,
        FileCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/pipelines/{pipeline_id}/files/{file_id}</c>, but is otherwise the
    /// same as <see cref="IFileService.Update(FileUpdateParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<PipelineFile>> Update(
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(FileUpdateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<PipelineFile>> Update(
        string fileID,
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/pipelines/{pipeline_id}/files2</c>, but is otherwise the
    /// same as <see cref="IFileService.List(FileListParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<FileListPage>> List(
        FileListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(FileListParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<FileListPage>> List(
        string pipelineID,
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/pipelines/{pipeline_id}/files/{file_id}</c>, but is otherwise the
    /// same as <see cref="IFileService.Delete(FileDeleteParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse> Delete(
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(FileDeleteParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse> Delete(
        string fileID,
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/pipelines/{pipeline_id}/files/{file_id}/status</c>, but is otherwise the
    /// same as <see cref="IFileService.GetStatus(FileGetStatusParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<ManagedIngestionStatusResponse>> GetStatus(
        FileGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatus(FileGetStatusParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<ManagedIngestionStatusResponse>> GetStatus(
        string fileID,
        FileGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/pipelines/{pipeline_id}/files/status-counts</c>, but is otherwise the
    /// same as <see cref="IFileService.GetStatusCounts(FileGetStatusCountsParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<FileGetStatusCountsResponse>> GetStatusCounts(
        FileGetStatusCountsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatusCounts(FileGetStatusCountsParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<FileGetStatusCountsResponse>> GetStatusCounts(
        string pipelineID,
        FileGetStatusCountsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
