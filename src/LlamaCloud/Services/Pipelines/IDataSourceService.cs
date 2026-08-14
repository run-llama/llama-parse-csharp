using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Models.Pipelines;
using LlamaCloud.Models.Pipelines.DataSources;

namespace LlamaCloud.Services.Pipelines;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDataSourceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDataSourceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDataSourceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Update the configuration of a data source in a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task<PipelineDataSource> Update(
        DataSourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DataSourceUpdateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<PipelineDataSource> Update(
        string dataSourceID,
        DataSourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get data sources for a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task<List<PipelineDataSource>> GetDataSources(
        DataSourceGetDataSourcesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetDataSources(DataSourceGetDataSourcesParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<List<PipelineDataSource>> GetDataSources(
        string pipelineID,
        DataSourceGetDataSourcesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the status of a data source for a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task<ManagedIngestionStatusResponse> GetStatus(
        DataSourceGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatus(DataSourceGetStatusParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<ManagedIngestionStatusResponse> GetStatus(
        string dataSourceID,
        DataSourceGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Run incremental ingestion: pull upstream changes from the data source into the
    /// data sink.
    /// </summary>
    [Obsolete("deprecated")]
    Task<Pipeline> Sync(
        DataSourceSyncParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Sync(DataSourceSyncParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<Pipeline> Sync(
        string dataSourceID,
        DataSourceSyncParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add data sources to a pipeline.
    /// </summary>
    [Obsolete("deprecated")]
    Task<List<PipelineDataSource>> UpdateDataSources(
        DataSourceUpdateDataSourcesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateDataSources(DataSourceUpdateDataSourcesParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<List<PipelineDataSource>> UpdateDataSources(
        string pipelineID,
        DataSourceUpdateDataSourcesParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDataSourceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDataSourceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDataSourceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/pipelines/{pipeline_id}/data-sources/{data_source_id}</c>, but is otherwise the
    /// same as <see cref="IDataSourceService.Update(DataSourceUpdateParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<PipelineDataSource>> Update(
        DataSourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DataSourceUpdateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<PipelineDataSource>> Update(
        string dataSourceID,
        DataSourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/pipelines/{pipeline_id}/data-sources</c>, but is otherwise the
    /// same as <see cref="IDataSourceService.GetDataSources(DataSourceGetDataSourcesParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<List<PipelineDataSource>>> GetDataSources(
        DataSourceGetDataSourcesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetDataSources(DataSourceGetDataSourcesParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<List<PipelineDataSource>>> GetDataSources(
        string pipelineID,
        DataSourceGetDataSourcesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/pipelines/{pipeline_id}/data-sources/{data_source_id}/status</c>, but is otherwise the
    /// same as <see cref="IDataSourceService.GetStatus(DataSourceGetStatusParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<ManagedIngestionStatusResponse>> GetStatus(
        DataSourceGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetStatus(DataSourceGetStatusParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<ManagedIngestionStatusResponse>> GetStatus(
        string dataSourceID,
        DataSourceGetStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/pipelines/{pipeline_id}/data-sources/{data_source_id}/sync</c>, but is otherwise the
    /// same as <see cref="IDataSourceService.Sync(DataSourceSyncParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<Pipeline>> Sync(
        DataSourceSyncParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Sync(DataSourceSyncParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<Pipeline>> Sync(
        string dataSourceID,
        DataSourceSyncParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/pipelines/{pipeline_id}/data-sources</c>, but is otherwise the
    /// same as <see cref="IDataSourceService.UpdateDataSources(DataSourceUpdateDataSourcesParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<List<PipelineDataSource>>> UpdateDataSources(
        DataSourceUpdateDataSourcesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateDataSources(DataSourceUpdateDataSourcesParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<List<PipelineDataSource>>> UpdateDataSources(
        string pipelineID,
        DataSourceUpdateDataSourcesParams parameters,
        CancellationToken cancellationToken = default
    );
}
