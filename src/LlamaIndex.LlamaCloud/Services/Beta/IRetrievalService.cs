using System;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.Retrieval;

namespace LlamaIndex.LlamaCloud.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRetrievalService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRetrievalServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRetrievalService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve relevant chunks via hybrid search (vector + full-text), with filtering
    /// on built-in or user-defined metadata.
    /// </summary>
    Task<RetrievalRetrieveResponse> Retrieve(
        RetrievalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Search for files by name.
    /// </summary>
    Task<RetrievalFindPage> Find(
        RetrievalFindParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Grep within a file's parsed content using a regex pattern.
    /// </summary>
    Task<RetrievalGrepPage> Grep(
        RetrievalGrepParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Read the parsed text content of a specific file.
    /// </summary>
    Task<RetrievalReadResponse> Read(
        RetrievalReadParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRetrievalService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRetrievalServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRetrievalServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/retrieval/retrieve</c>, but is otherwise the
    /// same as <see cref="IRetrievalService.Retrieve(RetrievalRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RetrievalRetrieveResponse>> Retrieve(
        RetrievalRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/retrieval/files/find</c>, but is otherwise the
    /// same as <see cref="IRetrievalService.Find(RetrievalFindParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RetrievalFindPage>> Find(
        RetrievalFindParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/retrieval/files/grep</c>, but is otherwise the
    /// same as <see cref="IRetrievalService.Grep(RetrievalGrepParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RetrievalGrepPage>> Grep(
        RetrievalGrepParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/retrieval/files/read</c>, but is otherwise the
    /// same as <see cref="IRetrievalService.Read(RetrievalReadParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RetrievalReadResponse>> Read(
        RetrievalReadParams parameters,
        CancellationToken cancellationToken = default
    );
}
