using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Configurations;

namespace LlamaIndex.LlamaCloud.Services;

/// <inheritdoc/>
public sealed class ConfigurationService : IConfigurationService
{
    readonly Lazy<IConfigurationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IConfigurationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IConfigurationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ConfigurationService(this._client.WithOptions(modifier));
    }

    public ConfigurationService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ConfigurationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<ConfigurationResponse> Create(
        ConfigurationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ConfigurationResponse> Retrieve(
        ConfigurationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ConfigurationResponse> Retrieve(
        string configID,
        ConfigurationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ConfigID = configID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ConfigurationResponse> Update(
        ConfigurationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ConfigurationResponse> Update(
        string configID,
        ConfigurationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ConfigID = configID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ConfigurationListPage> List(
        ConfigurationListParams? parameters = null,
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
        ConfigurationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string configID,
        ConfigurationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ConfigID = configID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ConfigurationServiceWithRawResponse : IConfigurationServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IConfigurationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ConfigurationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ConfigurationServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConfigurationResponse>> Create(
        ConfigurationCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ConfigurationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var configurationResponse = await response
                    .Deserialize<ConfigurationResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    configurationResponse.Validate();
                }
                return configurationResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConfigurationResponse>> Retrieve(
        ConfigurationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConfigID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.ConfigID' cannot be null");
        }

        HttpRequest<ConfigurationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var configurationResponse = await response
                    .Deserialize<ConfigurationResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    configurationResponse.Validate();
                }
                return configurationResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ConfigurationResponse>> Retrieve(
        string configID,
        ConfigurationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ConfigID = configID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConfigurationResponse>> Update(
        ConfigurationUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConfigID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.ConfigID' cannot be null");
        }

        HttpRequest<ConfigurationUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var configurationResponse = await response
                    .Deserialize<ConfigurationResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    configurationResponse.Validate();
                }
                return configurationResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ConfigurationResponse>> Update(
        string configID,
        ConfigurationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ConfigID = configID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConfigurationListPage>> List(
        ConfigurationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ConfigurationListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<ConfigurationListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ConfigurationListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ConfigurationDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConfigID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.ConfigID' cannot be null");
        }

        HttpRequest<ConfigurationDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string configID,
        ConfigurationDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ConfigID = configID }, cancellationToken);
    }
}
