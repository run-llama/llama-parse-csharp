using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines;
using LlamaCloud.Models.Pipelines.DataSources;

namespace LlamaCloud.Services.Pipelines;

/// <inheritdoc/>
public sealed class DataSourceService : IDataSourceService
{
    readonly Lazy<IDataSourceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDataSourceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IDataSourceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DataSourceService(this._client.WithOptions(modifier));
    }

    public DataSourceService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DataSourceServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<PipelineDataSource> Update(
        DataSourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<PipelineDataSource> Update(
        string dataSourceID,
        DataSourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { DataSourceID = dataSourceID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<List<PipelineDataSource>> GetDataSources(
        DataSourceGetDataSourcesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetDataSources(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<List<PipelineDataSource>> GetDataSources(
        string pipelineID,
        DataSourceGetDataSourcesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetDataSources(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<ManagedIngestionStatusResponse> GetStatus(
        DataSourceGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetStatus(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<ManagedIngestionStatusResponse> GetStatus(
        string dataSourceID,
        DataSourceGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetStatus(parameters with { DataSourceID = dataSourceID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<Pipeline> Sync(
        DataSourceSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Sync(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<Pipeline> Sync(
        string dataSourceID,
        DataSourceSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Sync(parameters with { DataSourceID = dataSourceID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<List<PipelineDataSource>> UpdateDataSources(
        DataSourceUpdateDataSourcesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateDataSources(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<List<PipelineDataSource>> UpdateDataSources(
        string pipelineID,
        DataSourceUpdateDataSourcesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateDataSources(
            parameters with
            {
                PipelineID = pipelineID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class DataSourceServiceWithRawResponse : IDataSourceServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDataSourceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DataSourceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DataSourceServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<PipelineDataSource>> Update(
        DataSourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DataSourceID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DataSourceID' cannot be null");
        }

        HttpRequest<DataSourceUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pipelineDataSource = await response
                    .Deserialize<PipelineDataSource>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    pipelineDataSource.Validate();
                }
                return pipelineDataSource;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<PipelineDataSource>> Update(
        string dataSourceID,
        DataSourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { DataSourceID = dataSourceID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<List<PipelineDataSource>>> GetDataSources(
        DataSourceGetDataSourcesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<DataSourceGetDataSourcesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pipelineDataSources = await response
                    .Deserialize<List<PipelineDataSource>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in pipelineDataSources)
                    {
                        item.Validate();
                    }
                }
                return pipelineDataSources;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<List<PipelineDataSource>>> GetDataSources(
        string pipelineID,
        DataSourceGetDataSourcesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetDataSources(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<ManagedIngestionStatusResponse>> GetStatus(
        DataSourceGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DataSourceID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DataSourceID' cannot be null");
        }

        HttpRequest<DataSourceGetStatusParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var managedIngestionStatusResponse = await response
                    .Deserialize<ManagedIngestionStatusResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    managedIngestionStatusResponse.Validate();
                }
                return managedIngestionStatusResponse;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<ManagedIngestionStatusResponse>> GetStatus(
        string dataSourceID,
        DataSourceGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetStatus(parameters with { DataSourceID = dataSourceID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<Pipeline>> Sync(
        DataSourceSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DataSourceID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DataSourceID' cannot be null");
        }

        HttpRequest<DataSourceSyncParams> request = new()
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
    public Task<HttpResponse<Pipeline>> Sync(
        string dataSourceID,
        DataSourceSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Sync(parameters with { DataSourceID = dataSourceID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<List<PipelineDataSource>>> UpdateDataSources(
        DataSourceUpdateDataSourcesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<DataSourceUpdateDataSourcesParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pipelineDataSources = await response
                    .Deserialize<List<PipelineDataSource>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in pipelineDataSources)
                    {
                        item.Validate();
                    }
                }
                return pipelineDataSources;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<List<PipelineDataSource>>> UpdateDataSources(
        string pipelineID,
        DataSourceUpdateDataSourcesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateDataSources(
            parameters with
            {
                PipelineID = pipelineID,
            },
            cancellationToken
        );
    }
}
