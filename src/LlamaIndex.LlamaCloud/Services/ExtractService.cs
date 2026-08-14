using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Configurations;
using LlamaIndex.LlamaCloud.Models.Extract;

namespace LlamaIndex.LlamaCloud.Services;

/// <inheritdoc/>
public sealed class ExtractService : IExtractService
{
    readonly Lazy<IExtractServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExtractServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IExtractService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExtractService(this._client.WithOptions(modifier));
    }

    public ExtractService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ExtractServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ExtractV2Job> Create(
        ExtractCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ExtractListPage> List(
        ExtractListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Delete(
        ExtractDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JsonElement> Delete(
        string jobID,
        ExtractDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExtractV2Job> Cancel(
        ExtractCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExtractV2Job> Cancel(
        string jobID,
        ExtractCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ConfigurationCreate> GenerateSchema(
        ExtractGenerateSchemaParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GenerateSchema(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ExtractV2Job> Get(
        ExtractGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExtractV2Job> Get(
        string jobID,
        ExtractGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExtractV2SchemaValidateResponse> ValidateSchema(
        ExtractValidateSchemaParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ValidateSchema(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ExtractServiceWithRawResponse : IExtractServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExtractServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExtractServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExtractServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExtractV2Job>> Create(
        ExtractCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExtractCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var extractV2Job = await response
                    .Deserialize<ExtractV2Job>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    extractV2Job.Validate();
                }
                return extractV2Job;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExtractListPage>> List(
        ExtractListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExtractListParams> request = new()
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
                    .Deserialize<ExtractV2JobQueryResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ExtractListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> Delete(
        ExtractDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<ExtractDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> Delete(
        string jobID,
        ExtractDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExtractV2Job>> Cancel(
        ExtractCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<ExtractCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var extractV2Job = await response
                    .Deserialize<ExtractV2Job>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    extractV2Job.Validate();
                }
                return extractV2Job;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ExtractV2Job>> Cancel(
        string jobID,
        ExtractCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConfigurationCreate>> GenerateSchema(
        ExtractGenerateSchemaParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExtractGenerateSchemaParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var configurationCreate = await response
                    .Deserialize<ConfigurationCreate>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    configurationCreate.Validate();
                }
                return configurationCreate;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExtractV2Job>> Get(
        ExtractGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<ExtractGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var extractV2Job = await response
                    .Deserialize<ExtractV2Job>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    extractV2Job.Validate();
                }
                return extractV2Job;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ExtractV2Job>> Get(
        string jobID,
        ExtractGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExtractV2SchemaValidateResponse>> ValidateSchema(
        ExtractValidateSchemaParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ExtractValidateSchemaParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var extractV2SchemaValidateResponse = await response
                    .Deserialize<ExtractV2SchemaValidateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    extractV2SchemaValidateResponse.Validate();
                }
                return extractV2SchemaValidateResponse;
            }
        );
    }
}
