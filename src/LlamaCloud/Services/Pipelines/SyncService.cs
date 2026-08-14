using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines;
using LlamaCloud.Models.Pipelines.Sync;

namespace LlamaCloud.Services.Pipelines;

/// <inheritdoc/>
public sealed class SyncService : ISyncService
{
    readonly Lazy<ISyncServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISyncServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public ISyncService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SyncService(this._client.WithOptions(modifier));
    }

    public SyncService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SyncServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<Pipeline> Create(
        SyncCreateParams parameters,
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
    public Task<Pipeline> Create(
        string pipelineID,
        SyncCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<Pipeline> Cancel(
        SyncCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<Pipeline> Cancel(
        string pipelineID,
        SyncCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { PipelineID = pipelineID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SyncServiceWithRawResponse : ISyncServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISyncServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SyncServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SyncServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<Pipeline>> Create(
        SyncCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<SyncCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pipeline = await response.Deserialize<Pipeline>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    pipeline.Validate();
                }
                return pipeline;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<Pipeline>> Create(
        string pipelineID,
        SyncCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<Pipeline>> Cancel(
        SyncCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<SyncCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pipeline = await response.Deserialize<Pipeline>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    pipeline.Validate();
                }
                return pipeline;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<Pipeline>> Cancel(
        string pipelineID,
        SyncCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { PipelineID = pipelineID }, cancellationToken);
    }
}
