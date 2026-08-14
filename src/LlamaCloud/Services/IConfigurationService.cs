using System;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Models.Configurations;

namespace LlamaCloud.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IConfigurationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IConfigurationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConfigurationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Upsert a product configuration; updates if one with the same name + product type
    /// + project exists, otherwise creates.
    /// </summary>
    Task<ConfigurationResponse> Create(
        ConfigurationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single product configuration by ID.
    /// </summary>
    Task<ConfigurationResponse> Retrieve(
        ConfigurationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ConfigurationRetrieveParams, CancellationToken)"/>
    Task<ConfigurationResponse> Retrieve(
        string configID,
        ConfigurationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing product configuration.
    /// </summary>
    Task<ConfigurationResponse> Update(
        ConfigurationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ConfigurationUpdateParams, CancellationToken)"/>
    Task<ConfigurationResponse> Update(
        string configID,
        ConfigurationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List product configurations for the current project.
    /// </summary>
    Task<ConfigurationListPage> List(
        ConfigurationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a product configuration.
    /// </summary>
    Task Delete(
        ConfigurationDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ConfigurationDeleteParams, CancellationToken)"/>
    Task Delete(
        string configID,
        ConfigurationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IConfigurationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IConfigurationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConfigurationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/beta/configurations</c>, but is otherwise the
    /// same as <see cref="IConfigurationService.Create(ConfigurationCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ConfigurationResponse>> Create(
        ConfigurationCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/configurations/{config_id}</c>, but is otherwise the
    /// same as <see cref="IConfigurationService.Retrieve(ConfigurationRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ConfigurationResponse>> Retrieve(
        ConfigurationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ConfigurationRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ConfigurationResponse>> Retrieve(
        string configID,
        ConfigurationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/beta/configurations/{config_id}</c>, but is otherwise the
    /// same as <see cref="IConfigurationService.Update(ConfigurationUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ConfigurationResponse>> Update(
        ConfigurationUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ConfigurationUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ConfigurationResponse>> Update(
        string configID,
        ConfigurationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/configurations</c>, but is otherwise the
    /// same as <see cref="IConfigurationService.List(ConfigurationListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ConfigurationListPage>> List(
        ConfigurationListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/beta/configurations/{config_id}</c>, but is otherwise the
    /// same as <see cref="IConfigurationService.Delete(ConfigurationDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ConfigurationDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ConfigurationDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string configID,
        ConfigurationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
