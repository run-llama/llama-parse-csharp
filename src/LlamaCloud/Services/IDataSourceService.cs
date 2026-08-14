using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Models.DataSources;

namespace LlamaCloud.Services;

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
    /// Create a new data source.
    /// </summary>
    Task<DataSource> Create(
        DataSourceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a data source by ID.
    /// </summary>
    Task<DataSource> Update(
        DataSourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DataSourceUpdateParams, CancellationToken)"/>
    Task<DataSource> Update(
        string dataSourceID,
        DataSourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List data sources for a given project. If project_id is not provided, uses the
    /// default project.
    /// </summary>
    Task<List<DataSource>> List(
        DataSourceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a data source by ID.
    /// </summary>
    Task Delete(DataSourceDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(DataSourceDeleteParams, CancellationToken)"/>
    Task Delete(
        string dataSourceID,
        DataSourceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a data source by ID.
    /// </summary>
    Task<DataSource> Get(
        DataSourceGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(DataSourceGetParams, CancellationToken)"/>
    Task<DataSource> Get(
        string dataSourceID,
        DataSourceGetParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>post /api/v1/data-sources</c>, but is otherwise the
    /// same as <see cref="IDataSourceService.Create(DataSourceCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DataSource>> Create(
        DataSourceCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/data-sources/{data_source_id}</c>, but is otherwise the
    /// same as <see cref="IDataSourceService.Update(DataSourceUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DataSource>> Update(
        DataSourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DataSourceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<DataSource>> Update(
        string dataSourceID,
        DataSourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/data-sources</c>, but is otherwise the
    /// same as <see cref="IDataSourceService.List(DataSourceListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<DataSource>>> List(
        DataSourceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/data-sources/{data_source_id}</c>, but is otherwise the
    /// same as <see cref="IDataSourceService.Delete(DataSourceDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        DataSourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(DataSourceDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string dataSourceID,
        DataSourceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/data-sources/{data_source_id}</c>, but is otherwise the
    /// same as <see cref="IDataSourceService.Get(DataSourceGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DataSource>> Get(
        DataSourceGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(DataSourceGetParams, CancellationToken)"/>
    Task<HttpResponse<DataSource>> Get(
        string dataSourceID,
        DataSourceGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
