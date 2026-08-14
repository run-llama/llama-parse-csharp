using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.WebhookConfigs;

namespace LlamaCloud.Services;

/// <inheritdoc/>
public sealed class WebhookConfigService : IWebhookConfigService
{
    readonly Lazy<IWebhookConfigServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWebhookConfigServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IWebhookConfigService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookConfigService(this._client.WithOptions(modifier));
    }

    public WebhookConfigService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new WebhookConfigServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<WebhookConfigResponse> Create(
        WebhookConfigCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WebhookConfigResponse> Retrieve(
        WebhookConfigRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WebhookConfigResponse> Retrieve(
        string configID,
        WebhookConfigRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ConfigID = configID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WebhookConfigResponse> Update(
        WebhookConfigUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WebhookConfigResponse> Update(
        string configID,
        WebhookConfigUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ConfigID = configID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<WebhookConfigResponse>> List(
        WebhookConfigListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        WebhookConfigDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string configID,
        WebhookConfigDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ConfigID = configID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class WebhookConfigServiceWithRawResponse : IWebhookConfigServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWebhookConfigServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WebhookConfigServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WebhookConfigServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookConfigResponse>> Create(
        WebhookConfigCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<WebhookConfigCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var webhookConfigResponse = await response
                    .Deserialize<WebhookConfigResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    webhookConfigResponse.Validate();
                }
                return webhookConfigResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookConfigResponse>> Retrieve(
        WebhookConfigRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConfigID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.ConfigID' cannot be null");
        }

        HttpRequest<WebhookConfigRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var webhookConfigResponse = await response
                    .Deserialize<WebhookConfigResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    webhookConfigResponse.Validate();
                }
                return webhookConfigResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WebhookConfigResponse>> Retrieve(
        string configID,
        WebhookConfigRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ConfigID = configID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookConfigResponse>> Update(
        WebhookConfigUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConfigID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.ConfigID' cannot be null");
        }

        HttpRequest<WebhookConfigUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var webhookConfigResponse = await response
                    .Deserialize<WebhookConfigResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    webhookConfigResponse.Validate();
                }
                return webhookConfigResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WebhookConfigResponse>> Update(
        string configID,
        WebhookConfigUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ConfigID = configID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<WebhookConfigResponse>>> List(
        WebhookConfigListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<WebhookConfigListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var webhookConfigResponses = await response
                    .Deserialize<List<WebhookConfigResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in webhookConfigResponses)
                    {
                        item.Validate();
                    }
                }
                return webhookConfigResponses;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        WebhookConfigDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConfigID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.ConfigID' cannot be null");
        }

        HttpRequest<WebhookConfigDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string configID,
        WebhookConfigDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ConfigID = configID }, cancellationToken);
    }
}
