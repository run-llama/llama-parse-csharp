using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Models.DataSinks;

namespace LlamaCloud.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDataSinkService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDataSinkServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDataSinkService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a new data sink.
    /// </summary>
    Task<DataSink> Create(
        DataSinkCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a data sink by ID.
    /// </summary>
    Task<DataSink> Update(
        DataSinkUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DataSinkUpdateParams, CancellationToken)"/>
    Task<DataSink> Update(
        string dataSinkID,
        DataSinkUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List data sinks for a given project.
    /// </summary>
    Task<List<DataSink>> List(
        DataSinkListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a data sink by ID.
    /// </summary>
    Task Delete(DataSinkDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(DataSinkDeleteParams, CancellationToken)"/>
    Task Delete(
        string dataSinkID,
        DataSinkDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a data sink by ID.
    /// </summary>
    Task<DataSink> Get(DataSinkGetParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Get(DataSinkGetParams, CancellationToken)"/>
    Task<DataSink> Get(
        string dataSinkID,
        DataSinkGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDataSinkService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDataSinkServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDataSinkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/data-sinks</c>, but is otherwise the
    /// same as <see cref="IDataSinkService.Create(DataSinkCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DataSink>> Create(
        DataSinkCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/data-sinks/{data_sink_id}</c>, but is otherwise the
    /// same as <see cref="IDataSinkService.Update(DataSinkUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DataSink>> Update(
        DataSinkUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DataSinkUpdateParams, CancellationToken)"/>
    Task<HttpResponse<DataSink>> Update(
        string dataSinkID,
        DataSinkUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/data-sinks</c>, but is otherwise the
    /// same as <see cref="IDataSinkService.List(DataSinkListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<DataSink>>> List(
        DataSinkListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/data-sinks/{data_sink_id}</c>, but is otherwise the
    /// same as <see cref="IDataSinkService.Delete(DataSinkDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        DataSinkDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(DataSinkDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string dataSinkID,
        DataSinkDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/data-sinks/{data_sink_id}</c>, but is otherwise the
    /// same as <see cref="IDataSinkService.Get(DataSinkGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DataSink>> Get(
        DataSinkGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(DataSinkGetParams, CancellationToken)"/>
    Task<HttpResponse<DataSink>> Get(
        string dataSinkID,
        DataSinkGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
