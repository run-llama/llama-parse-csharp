using System;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Files;

namespace LlamaIndex.LlamaCloud.Services;

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
    /// Upload a file using multipart/form-data.
    ///
    /// <para>Set `purpose` to indicate how the file will be used: `user_data`, `parse`,
    /// `extract`, `classify`, `split`, `sheet`, or `agent_app`.</para>
    ///
    /// <para>Returns the created file metadata including its ID for use in subsequent
    /// parse, extract, or classify operations.</para>
    /// </summary>
    Task<FileCreateResponse> Create(
        FileCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get file metadata by ID.
    /// </summary>
    Task<FileRetrieveResponse> Retrieve(
        FileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FileRetrieveParams, CancellationToken)"/>
    Task<FileRetrieveResponse> Retrieve(
        string fileID,
        FileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List files with optional filtering and pagination.
    ///
    /// <para>Filter by `file_name`, `file_ids`, or `external_file_id`. Supports
    /// cursor-based pagination and custom ordering.</para>
    /// </summary>
    Task<FileListPage> List(
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a file from the project.
    /// </summary>
    Task Delete(FileDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(FileDeleteParams, CancellationToken)"/>
    Task Delete(
        string fileID,
        FileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a presigned URL to download the file content.
    /// </summary>
    Task<PresignedUrl> Content(
        FileContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Content(FileContentParams, CancellationToken)"/>
    Task<PresignedUrl> Content(
        string fileID,
        FileContentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Query files with filtering and pagination. Deprecated: use `GET /files`.
    /// </summary>
    [Obsolete("Use the GET /files endpoint instead")]
    Task<FileQueryResponse> Query(
        FileQueryParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /api/v1/beta/files</c>, but is otherwise the
    /// same as <see cref="IFileService.Create(FileCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileCreateResponse>> Create(
        FileCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/files/{file_id}</c>, but is otherwise the
    /// same as <see cref="IFileService.Retrieve(FileRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileRetrieveResponse>> Retrieve(
        FileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FileRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<FileRetrieveResponse>> Retrieve(
        string fileID,
        FileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/files</c>, but is otherwise the
    /// same as <see cref="IFileService.List(FileListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileListPage>> List(
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/beta/files/{file_id}</c>, but is otherwise the
    /// same as <see cref="IFileService.Delete(FileDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(FileDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string fileID,
        FileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/files/{file_id}/content</c>, but is otherwise the
    /// same as <see cref="IFileService.Content(FileContentParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PresignedUrl>> Content(
        FileContentParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Content(FileContentParams, CancellationToken)"/>
    Task<HttpResponse<PresignedUrl>> Content(
        string fileID,
        FileContentParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/beta/files/query</c>, but is otherwise the
    /// same as <see cref="IFileService.Query(FileQueryParams?, CancellationToken)"/>.
    /// </summary>
    [Obsolete("Use the GET /files endpoint instead")]
    Task<HttpResponse<FileQueryResponse>> Query(
        FileQueryParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
