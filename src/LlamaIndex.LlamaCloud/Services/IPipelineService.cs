using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines;
using Pipelines = LlamaIndex.LlamaCloud.Services.Pipelines;

namespace LlamaIndex.LlamaCloud.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPipelineService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPipelineServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPipelineService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Pipelines::ISyncService Sync { get; }

    Pipelines::IDataSourceService DataSources { get; }

    Pipelines::IImageService Images { get; }

    Pipelines::IFileService Files { get; }

    Pipelines::IMetadataService Metadata { get; }

    Pipelines::IDocumentService Documents { get; }

    /// <summary>
    /// Create a new managed ingestion pipeline.
    ///
    /// <para>A pipeline connects data sources to a vector store for RAG. After
    /// creation, call `POST /pipelines/{id}/sync` to start ingesting documents.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<Pipeline> Create(
        PipelineCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Run a retrieval query against a managed pipeline.
    ///
    /// <para>Searches the pipeline's vector store using the provided query and
    /// retrieval parameters. Supports dense, sparse, and hybrid search modes with
    /// configurable top-k and reranking.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<PipelineRetrieveResponse> Retrieve(
        PipelineRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PipelineRetrieveParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<PipelineRetrieveResponse> Retrieve(
        string pipelineID,
        PipelineRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing pipeline's configuration.
    /// </summary>
    [Obsolete("deprecated")]
    Task<Pipeline> Update(
        PipelineUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PipelineUpdateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<Pipeline> Update(
        string pipelineID,
        PipelineUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Search for pipelines by name, type, or project.
    /// </summary>
    [Obsolete("deprecated")]
    Task<List<Pipeline>> List(
        PipelineListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a pipeline and all associated resources.
    ///
    /// <para>Removes pipeline files, data sources, and vector store data. This
    /// operation is irreversible.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task Delete(PipelineDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(PipelineDeleteParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task Delete(
        string pipelineID,
        PipelineDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a pipeline by ID.
    /// </summary>
    [Obsolete("deprecated")]
    Task<Pipeline> Get(PipelineGetParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Get(PipelineGetParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<Pipeline> Get(
        string pipelineID,
        PipelineGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the ingestion status of a managed pipeline.
    ///
    /// <para>Returns document counts, sync progress, and the last effective timestamp.
    /// Only available for managed pipelines.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<ManagedIngestionStatusResponse> GetStatus(
        PipelineGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatus(PipelineGetStatusParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<ManagedIngestionStatusResponse> GetStatus(
        string pipelineID,
        PipelineGetStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Upsert a pipeline.
    ///
    /// <para>Updates the pipeline if one with the same name and project already exists,
    /// otherwise creates a new one.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<Pipeline> Upsert(
        PipelineUpsertParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPipelineService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPipelineServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPipelineServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Pipelines::ISyncServiceWithRawResponse Sync { get; }

    Pipelines::IDataSourceServiceWithRawResponse DataSources { get; }

    Pipelines::IImageServiceWithRawResponse Images { get; }

    Pipelines::IFileServiceWithRawResponse Files { get; }

    Pipelines::IMetadataServiceWithRawResponse Metadata { get; }

    Pipelines::IDocumentServiceWithRawResponse Documents { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/pipelines</c>, but is otherwise the
    /// same as <see cref="IPipelineService.Create(PipelineCreateParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<Pipeline>> Create(
        PipelineCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/pipelines/{pipeline_id}/retrieve</c>, but is otherwise the
    /// same as <see cref="IPipelineService.Retrieve(PipelineRetrieveParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<PipelineRetrieveResponse>> Retrieve(
        PipelineRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PipelineRetrieveParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<PipelineRetrieveResponse>> Retrieve(
        string pipelineID,
        PipelineRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/pipelines/{pipeline_id}</c>, but is otherwise the
    /// same as <see cref="IPipelineService.Update(PipelineUpdateParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<Pipeline>> Update(
        PipelineUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PipelineUpdateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<Pipeline>> Update(
        string pipelineID,
        PipelineUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/pipelines</c>, but is otherwise the
    /// same as <see cref="IPipelineService.List(PipelineListParams?, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<List<Pipeline>>> List(
        PipelineListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/pipelines/{pipeline_id}</c>, but is otherwise the
    /// same as <see cref="IPipelineService.Delete(PipelineDeleteParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse> Delete(
        PipelineDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(PipelineDeleteParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse> Delete(
        string pipelineID,
        PipelineDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/pipelines/{pipeline_id}</c>, but is otherwise the
    /// same as <see cref="IPipelineService.Get(PipelineGetParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<Pipeline>> Get(
        PipelineGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(PipelineGetParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<Pipeline>> Get(
        string pipelineID,
        PipelineGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/pipelines/{pipeline_id}/status</c>, but is otherwise the
    /// same as <see cref="IPipelineService.GetStatus(PipelineGetStatusParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<ManagedIngestionStatusResponse>> GetStatus(
        PipelineGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatus(PipelineGetStatusParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<ManagedIngestionStatusResponse>> GetStatus(
        string pipelineID,
        PipelineGetStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/pipelines</c>, but is otherwise the
    /// same as <see cref="IPipelineService.Upsert(PipelineUpsertParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<Pipeline>> Upsert(
        PipelineUpsertParams parameters,
        CancellationToken cancellationToken = default
    );
}
