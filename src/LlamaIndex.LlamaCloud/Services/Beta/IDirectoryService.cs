using System;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.Directories;
using Directories = LlamaIndex.LlamaCloud.Services.Beta.Directories;

namespace LlamaIndex.LlamaCloud.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDirectoryService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDirectoryServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDirectoryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Directories::IFileService Files { get; }

    /// <summary>
    /// Create a new directory within the specified project.
    /// </summary>
    Task<DirectoryCreateResponse> Create(
        DirectoryCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update directory metadata.
    /// </summary>
    Task<DirectoryUpdateResponse> Update(
        DirectoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DirectoryUpdateParams, CancellationToken)"/>
    Task<DirectoryUpdateResponse> Update(
        string directoryID,
        DirectoryUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Directories
    /// </summary>
    Task<DirectoryListPage> List(
        DirectoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently delete a directory.
    /// </summary>
    Task Delete(DirectoryDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(DirectoryDeleteParams, CancellationToken)"/>
    Task Delete(
        string directoryID,
        DirectoryDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a directory by its identifier.
    /// </summary>
    Task<DirectoryGetResponse> Get(
        DirectoryGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(DirectoryGetParams, CancellationToken)"/>
    Task<DirectoryGetResponse> Get(
        string directoryID,
        DirectoryGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDirectoryService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDirectoryServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDirectoryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Directories::IFileServiceWithRawResponse Files { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/beta/directories</c>, but is otherwise the
    /// same as <see cref="IDirectoryService.Create(DirectoryCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DirectoryCreateResponse>> Create(
        DirectoryCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /api/v1/beta/directories/{directory_id}</c>, but is otherwise the
    /// same as <see cref="IDirectoryService.Update(DirectoryUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DirectoryUpdateResponse>> Update(
        DirectoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DirectoryUpdateParams, CancellationToken)"/>
    Task<HttpResponse<DirectoryUpdateResponse>> Update(
        string directoryID,
        DirectoryUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/directories</c>, but is otherwise the
    /// same as <see cref="IDirectoryService.List(DirectoryListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DirectoryListPage>> List(
        DirectoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/beta/directories/{directory_id}</c>, but is otherwise the
    /// same as <see cref="IDirectoryService.Delete(DirectoryDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        DirectoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(DirectoryDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string directoryID,
        DirectoryDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/directories/{directory_id}</c>, but is otherwise the
    /// same as <see cref="IDirectoryService.Get(DirectoryGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DirectoryGetResponse>> Get(
        DirectoryGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(DirectoryGetParams, CancellationToken)"/>
    Task<HttpResponse<DirectoryGetResponse>> Get(
        string directoryID,
        DirectoryGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
