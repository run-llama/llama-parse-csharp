using System;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.Directories.Files;

namespace LlamaIndex.LlamaCloud.Services.Beta.Directories;

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
    /// Update directory-file metadata by `directory_file_id`; set `directory_id` to
    /// move the file to a different directory. To resolve from `unique_id`, list with a
    /// filter first.
    /// </summary>
    Task<FileUpdateResponse> Update(
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(FileUpdateParams, CancellationToken)"/>
    Task<FileUpdateResponse> Update(
        string directoryFileID,
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all files within the specified directory with optional filtering and
    /// pagination.
    /// </summary>
    Task<FileListPage> List(
        FileListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(FileListParams, CancellationToken)"/>
    Task<FileListPage> List(
        string directoryID,
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a directory file by `directory_file_id`; to resolve from `unique_id`,
    /// list with a filter first.
    /// </summary>
    Task Delete(FileDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(FileDeleteParams, CancellationToken)"/>
    Task Delete(
        string directoryFileID,
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new file within the specified directory; the directory must exist in
    /// the project and `file_id` must reference an existing file.
    /// </summary>
    Task<FileAddResponse> Add(
        FileAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(FileAddParams, CancellationToken)"/>
    Task<FileAddResponse> Add(
        string directoryID,
        FileAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a directory file by `directory_file_id`; to look up by `unique_id`, use the
    /// list endpoint with a filter.
    /// </summary>
    Task<FileGetResponse> Get(
        FileGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(FileGetParams, CancellationToken)"/>
    Task<FileGetResponse> Get(
        string directoryFileID,
        FileGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upload a file and create its directory entry in one call; `unique_id` /
    /// `display_name` default to values derived from file metadata.
    /// </summary>
    Task<FileUploadResponse> Upload(
        FileUploadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upload(FileUploadParams, CancellationToken)"/>
    Task<FileUploadResponse> Upload(
        string directoryID,
        FileUploadParams parameters,
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
    /// Returns a raw HTTP response for <c>patch /api/v1/beta/directories/{directory_id}/files/{directory_file_id}</c>, but is otherwise the
    /// same as <see cref="IFileService.Update(FileUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileUpdateResponse>> Update(
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(FileUpdateParams, CancellationToken)"/>
    Task<HttpResponse<FileUpdateResponse>> Update(
        string directoryFileID,
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/directories/{directory_id}/files</c>, but is otherwise the
    /// same as <see cref="IFileService.List(FileListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileListPage>> List(
        FileListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(FileListParams, CancellationToken)"/>
    Task<HttpResponse<FileListPage>> List(
        string directoryID,
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/beta/directories/{directory_id}/files/{directory_file_id}</c>, but is otherwise the
    /// same as <see cref="IFileService.Delete(FileDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(FileDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string directoryFileID,
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/beta/directories/{directory_id}/files</c>, but is otherwise the
    /// same as <see cref="IFileService.Add(FileAddParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileAddResponse>> Add(
        FileAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(FileAddParams, CancellationToken)"/>
    Task<HttpResponse<FileAddResponse>> Add(
        string directoryID,
        FileAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/directories/{directory_id}/files/{directory_file_id}</c>, but is otherwise the
    /// same as <see cref="IFileService.Get(FileGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileGetResponse>> Get(
        FileGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(FileGetParams, CancellationToken)"/>
    Task<HttpResponse<FileGetResponse>> Get(
        string directoryFileID,
        FileGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/beta/directories/{directory_id}/files/upload</c>, but is otherwise the
    /// same as <see cref="IFileService.Upload(FileUploadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FileUploadResponse>> Upload(
        FileUploadParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upload(FileUploadParams, CancellationToken)"/>
    Task<HttpResponse<FileUploadResponse>> Upload(
        string directoryID,
        FileUploadParams parameters,
        CancellationToken cancellationToken = default
    );
}
