using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.WebhookConfigs;

namespace LlamaIndex.LlamaCloud.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWebhookConfigService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWebhookConfigServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookConfigService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a reusable webhook configuration for the current project.
    /// </summary>
    Task<WebhookConfigResponse> Create(
        WebhookConfigCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single webhook configuration by ID.
    /// </summary>
    Task<WebhookConfigResponse> Retrieve(
        WebhookConfigRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WebhookConfigRetrieveParams, CancellationToken)"/>
    Task<WebhookConfigResponse> Retrieve(
        string configID,
        WebhookConfigRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a webhook configuration. Only fields present in the request change.
    /// </summary>
    Task<WebhookConfigResponse> Update(
        WebhookConfigUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WebhookConfigUpdateParams, CancellationToken)"/>
    Task<WebhookConfigResponse> Update(
        string configID,
        WebhookConfigUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the webhook configurations for the current project, newest first.
    /// </summary>
    Task<List<WebhookConfigResponse>> List(
        WebhookConfigListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a webhook configuration.
    /// </summary>
    Task Delete(
        WebhookConfigDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(WebhookConfigDeleteParams, CancellationToken)"/>
    Task Delete(
        string configID,
        WebhookConfigDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWebhookConfigService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWebhookConfigServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookConfigServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/beta/webhook-configs</c>, but is otherwise the
    /// same as <see cref="IWebhookConfigService.Create(WebhookConfigCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookConfigResponse>> Create(
        WebhookConfigCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/webhook-configs/{config_id}</c>, but is otherwise the
    /// same as <see cref="IWebhookConfigService.Retrieve(WebhookConfigRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookConfigResponse>> Retrieve(
        WebhookConfigRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(WebhookConfigRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<WebhookConfigResponse>> Retrieve(
        string configID,
        WebhookConfigRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/beta/webhook-configs/{config_id}</c>, but is otherwise the
    /// same as <see cref="IWebhookConfigService.Update(WebhookConfigUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookConfigResponse>> Update(
        WebhookConfigUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(WebhookConfigUpdateParams, CancellationToken)"/>
    Task<HttpResponse<WebhookConfigResponse>> Update(
        string configID,
        WebhookConfigUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/webhook-configs</c>, but is otherwise the
    /// same as <see cref="IWebhookConfigService.List(WebhookConfigListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<WebhookConfigResponse>>> List(
        WebhookConfigListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/beta/webhook-configs/{config_id}</c>, but is otherwise the
    /// same as <see cref="IWebhookConfigService.Delete(WebhookConfigDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        WebhookConfigDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(WebhookConfigDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string configID,
        WebhookConfigDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
