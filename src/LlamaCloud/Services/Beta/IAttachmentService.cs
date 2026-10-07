using System;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Models.Beta.Attachments;
using LlamaCloud.Models.Files;

namespace LlamaCloud.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAttachmentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAttachmentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAttachmentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List the attachments associated with a file (e.g. per-page screenshots).
    /// </summary>
    Task<AttachmentListPage> List(
        AttachmentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Return a presigned download URL for a specific attachment.
    /// </summary>
    Task<PresignedUrl> Get(
        AttachmentGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(AttachmentGetParams, CancellationToken)"/>
    Task<PresignedUrl> Get(
        string attachmentName,
        AttachmentGetParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAttachmentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAttachmentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAttachmentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/attachments</c>, but is otherwise the
    /// same as <see cref="IAttachmentService.List(AttachmentListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AttachmentListPage>> List(
        AttachmentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/attachments/{attachment_name}</c>, but is otherwise the
    /// same as <see cref="IAttachmentService.Get(AttachmentGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PresignedUrl>> Get(
        AttachmentGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(AttachmentGetParams, CancellationToken)"/>
    Task<HttpResponse<PresignedUrl>> Get(
        string attachmentName,
        AttachmentGetParams parameters,
        CancellationToken cancellationToken = default
    );
}
