using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.DataSinks;

namespace LlamaCloud.Services;

/// <inheritdoc/>
public sealed class DataSinkService : IDataSinkService
{
    readonly Lazy<IDataSinkServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDataSinkServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IDataSinkService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DataSinkService(this._client.WithOptions(modifier));
    }

    public DataSinkService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DataSinkServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<DataSink> Create(
        DataSinkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DataSink> Update(
        DataSinkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DataSink> Update(
        string dataSinkID,
        DataSinkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { DataSinkID = dataSinkID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<DataSink>> List(
        DataSinkListParams? parameters = null,
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
        DataSinkDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string dataSinkID,
        DataSinkDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { DataSinkID = dataSinkID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DataSink> Get(
        DataSinkGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DataSink> Get(
        string dataSinkID,
        DataSinkGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { DataSinkID = dataSinkID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DataSinkServiceWithRawResponse : IDataSinkServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDataSinkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DataSinkServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DataSinkServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DataSink>> Create(
        DataSinkCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DataSinkCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var dataSink = await response.Deserialize<DataSink>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    dataSink.Validate();
                }
                return dataSink;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DataSink>> Update(
        DataSinkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DataSinkID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DataSinkID' cannot be null");
        }

        HttpRequest<DataSinkUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var dataSink = await response.Deserialize<DataSink>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    dataSink.Validate();
                }
                return dataSink;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DataSink>> Update(
        string dataSinkID,
        DataSinkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { DataSinkID = dataSinkID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<DataSink>>> List(
        DataSinkListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DataSinkListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var dataSinks = await response
                    .Deserialize<List<DataSink>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in dataSinks)
                    {
                        item.Validate();
                    }
                }
                return dataSinks;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        DataSinkDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DataSinkID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DataSinkID' cannot be null");
        }

        HttpRequest<DataSinkDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string dataSinkID,
        DataSinkDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { DataSinkID = dataSinkID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DataSink>> Get(
        DataSinkGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DataSinkID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DataSinkID' cannot be null");
        }

        HttpRequest<DataSinkGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var dataSink = await response.Deserialize<DataSink>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    dataSink.Validate();
                }
                return dataSink;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DataSink>> Get(
        string dataSinkID,
        DataSinkGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { DataSinkID = dataSinkID }, cancellationToken);
    }
}
