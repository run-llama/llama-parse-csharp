using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.DataSources;

namespace LlamaCloud.Services;

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
    public async Task<DataSource> Create(
        DataSourceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DataSource> Update(
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
    public Task<DataSource> Update(
        string dataSourceID,
        DataSourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { DataSourceID = dataSourceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<DataSource>> List(
        DataSourceListParams? parameters = null,
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
        DataSourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string dataSourceID,
        DataSourceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { DataSourceID = dataSourceID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DataSource> Get(
        DataSourceGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DataSource> Get(
        string dataSourceID,
        DataSourceGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { DataSourceID = dataSourceID }, cancellationToken);
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
    public async Task<HttpResponse<DataSource>> Create(
        DataSourceCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DataSourceCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var dataSource = await response
                    .Deserialize<DataSource>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    dataSource.Validate();
                }
                return dataSource;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DataSource>> Update(
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
                var dataSource = await response
                    .Deserialize<DataSource>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    dataSource.Validate();
                }
                return dataSource;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DataSource>> Update(
        string dataSourceID,
        DataSourceUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { DataSourceID = dataSourceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<DataSource>>> List(
        DataSourceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DataSourceListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var dataSources = await response
                    .Deserialize<List<DataSource>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in dataSources)
                    {
                        item.Validate();
                    }
                }
                return dataSources;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        DataSourceDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DataSourceID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DataSourceID' cannot be null");
        }

        HttpRequest<DataSourceDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string dataSourceID,
        DataSourceDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { DataSourceID = dataSourceID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DataSource>> Get(
        DataSourceGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DataSourceID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DataSourceID' cannot be null");
        }

        HttpRequest<DataSourceGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var dataSource = await response
                    .Deserialize<DataSource>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    dataSource.Validate();
                }
                return dataSource;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DataSource>> Get(
        string dataSourceID,
        DataSourceGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { DataSourceID = dataSourceID }, cancellationToken);
    }
}
