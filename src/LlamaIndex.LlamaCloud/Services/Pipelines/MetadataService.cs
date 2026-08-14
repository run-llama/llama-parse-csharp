using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Pipelines.Metadata;

namespace LlamaIndex.LlamaCloud.Services.Pipelines;

/// <inheritdoc/>
public sealed class MetadataService : IMetadataService
{
    readonly Lazy<IMetadataServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMetadataServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IMetadataService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MetadataService(this._client.WithOptions(modifier));
    }

    public MetadataService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MetadataServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<Dictionary<string, string>> Create(
        MetadataCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<Dictionary<string, string>> Create(
        string pipelineID,
        MetadataCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task DeleteAll(
        MetadataDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.DeleteAll(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task DeleteAll(
        string pipelineID,
        MetadataDeleteAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.DeleteAll(parameters with { PipelineID = pipelineID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MetadataServiceWithRawResponse : IMetadataServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMetadataServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MetadataServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MetadataServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<Dictionary<string, string>>> Create(
        MetadataCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<MetadataCreateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response
                    .Deserialize<Dictionary<string, string>>(token)
                    .ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<Dictionary<string, string>>> Create(
        string pipelineID,
        MetadataCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse> DeleteAll(
        MetadataDeleteAllParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<MetadataDeleteAllParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse> DeleteAll(
        string pipelineID,
        MetadataDeleteAllParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DeleteAll(parameters with { PipelineID = pipelineID }, cancellationToken);
    }
}
