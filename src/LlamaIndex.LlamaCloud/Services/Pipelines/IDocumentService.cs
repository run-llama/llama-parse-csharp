using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines;
using LlamaIndex.LlamaCloud.Models.Pipelines.Documents;

namespace LlamaIndex.LlamaCloud.Services.Pipelines;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDocumentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDocumentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDocumentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Batch create documents for a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task<List<CloudDocument>> Create(
        DocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(DocumentCreateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<List<CloudDocument>> Create(
        string pipelineID,
        DocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Return a list of documents for a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task<DocumentListPage> List(
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(DocumentListParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<DocumentListPage> List(
        string pipelineID,
        DocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a document from a pipeline; runs async (vectors first, then MongoDB
    /// record).
    /// </summary>
    [Obsolete("deprecated")]
    Task Delete(DocumentDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(DocumentDeleteParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task Delete(
        string documentID,
        DocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Return a single document for a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task<CloudDocument> Get(
        DocumentGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(DocumentGetParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<CloudDocument> Get(
        string documentID,
        DocumentGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Return a list of chunks for a pipeline document.
    /// </summary>
    [Obsolete("deprecated")]
    Task<List<TextNode>> GetChunks(
        DocumentGetChunksParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetChunks(DocumentGetChunksParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<List<TextNode>> GetChunks(
        string documentID,
        DocumentGetChunksParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Return a single document for a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task<ManagedIngestionStatusResponse> GetStatus(
        DocumentGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatus(DocumentGetStatusParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<ManagedIngestionStatusResponse> GetStatus(
        string documentID,
        DocumentGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Count the documents in a pipeline, grouped by ingestion status.
    ///
    /// <para>Counts reflect each document's last recorded status rather than a freshly
    /// computed one, so a document that changed status in the last few moments may
    /// still be counted under its previous one. Use `GET
    /// /pipelines/{pipeline_id}/documents/{document_id}/status` when a single
    /// document's status has to be up to the moment.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<DocumentGetStatusCountsResponse> GetStatusCounts(
        DocumentGetStatusCountsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatusCounts(DocumentGetStatusCountsParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<DocumentGetStatusCountsResponse> GetStatusCounts(
        string pipelineID,
        DocumentGetStatusCountsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sync a specific document for a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task<JsonElement> Sync(
        DocumentSyncParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Sync(DocumentSyncParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<JsonElement> Sync(
        string documentID,
        DocumentSyncParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Batch create or update a document for a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task<List<CloudDocument>> Upsert(
        DocumentUpsertParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upsert(DocumentUpsertParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<List<CloudDocument>> Upsert(
        string pipelineID,
        DocumentUpsertParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDocumentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDocumentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDocumentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/pipelines/{pipeline_id}/documents</c>, but is otherwise the
    /// same as <see cref="IDocumentService.Create(DocumentCreateParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<List<CloudDocument>>> Create(
        DocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(DocumentCreateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<List<CloudDocument>>> Create(
        string pipelineID,
        DocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/pipelines/{pipeline_id}/documents/paginated</c>, but is otherwise the
    /// same as <see cref="IDocumentService.List(DocumentListParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<DocumentListPage>> List(
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(DocumentListParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<DocumentListPage>> List(
        string pipelineID,
        DocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/pipelines/{pipeline_id}/documents/{document_id}</c>, but is otherwise the
    /// same as <see cref="IDocumentService.Delete(DocumentDeleteParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse> Delete(
        DocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(DocumentDeleteParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse> Delete(
        string documentID,
        DocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/pipelines/{pipeline_id}/documents/{document_id}</c>, but is otherwise the
    /// same as <see cref="IDocumentService.Get(DocumentGetParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<CloudDocument>> Get(
        DocumentGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(DocumentGetParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<CloudDocument>> Get(
        string documentID,
        DocumentGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/pipelines/{pipeline_id}/documents/{document_id}/chunks</c>, but is otherwise the
    /// same as <see cref="IDocumentService.GetChunks(DocumentGetChunksParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<List<TextNode>>> GetChunks(
        DocumentGetChunksParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetChunks(DocumentGetChunksParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<List<TextNode>>> GetChunks(
        string documentID,
        DocumentGetChunksParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/pipelines/{pipeline_id}/documents/{document_id}/status</c>, but is otherwise the
    /// same as <see cref="IDocumentService.GetStatus(DocumentGetStatusParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<ManagedIngestionStatusResponse>> GetStatus(
        DocumentGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatus(DocumentGetStatusParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<ManagedIngestionStatusResponse>> GetStatus(
        string documentID,
        DocumentGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/pipelines/{pipeline_id}/documents/status-counts</c>, but is otherwise the
    /// same as <see cref="IDocumentService.GetStatusCounts(DocumentGetStatusCountsParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<DocumentGetStatusCountsResponse>> GetStatusCounts(
        DocumentGetStatusCountsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatusCounts(DocumentGetStatusCountsParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<DocumentGetStatusCountsResponse>> GetStatusCounts(
        string pipelineID,
        DocumentGetStatusCountsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/pipelines/{pipeline_id}/documents/{document_id}/sync</c>, but is otherwise the
    /// same as <see cref="IDocumentService.Sync(DocumentSyncParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<JsonElement>> Sync(
        DocumentSyncParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Sync(DocumentSyncParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<JsonElement>> Sync(
        string documentID,
        DocumentSyncParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/pipelines/{pipeline_id}/documents</c>, but is otherwise the
    /// same as <see cref="IDocumentService.Upsert(DocumentUpsertParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<List<CloudDocument>>> Upsert(
        DocumentUpsertParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upsert(DocumentUpsertParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<List<CloudDocument>>> Upsert(
        string pipelineID,
        DocumentUpsertParams parameters,
        CancellationToken cancellationToken = default
    );
}
