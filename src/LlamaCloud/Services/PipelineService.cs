using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines;
using Pipelines = LlamaCloud.Services.Pipelines;

namespace LlamaCloud.Services;

/// <inheritdoc/>
public sealed class PipelineService : IPipelineService
{
    readonly Lazy<IPipelineServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPipelineServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IPipelineService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PipelineService(this._client.WithOptions(modifier));
    }

    public PipelineService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PipelineServiceWithRawResponse(client.WithRawResponse));
        _sync = new(() => new Pipelines::SyncService(client));
        _dataSources = new(() => new Pipelines::DataSourceService(client));
        _images = new(() => new Pipelines::ImageService(client));
        _files = new(() => new Pipelines::FileService(client));
        _metadata = new(() => new Pipelines::MetadataService(client));
        _documents = new(() => new Pipelines::DocumentService(client));
    }

    readonly Lazy<Pipelines::ISyncService> _sync;
    public Pipelines::ISyncService Sync
    {
        get { return _sync.Value; }
    }

    readonly Lazy<Pipelines::IDataSourceService> _dataSources;
    public Pipelines::IDataSourceService DataSources
    {
        get { return _dataSources.Value; }
    }

    readonly Lazy<Pipelines::IImageService> _images;
    public Pipelines::IImageService Images
    {
        get { return _images.Value; }
    }

    readonly Lazy<Pipelines::IFileService> _files;
    public Pipelines::IFileService Files
    {
        get { return _files.Value; }
    }

    readonly Lazy<Pipelines::IMetadataService> _metadata;
    public Pipelines::IMetadataService Metadata
    {
        get { return _metadata.Value; }
    }

    readonly Lazy<Pipelines::IDocumentService> _documents;
    public Pipelines::IDocumentService Documents
    {
        get { return _documents.Value; }
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<Pipeline> Create(
        PipelineCreateParams parameters,
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
    public async Task<PipelineRetrieveResponse> Retrieve(
        PipelineRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<PipelineRetrieveResponse> Retrieve(
        string pipelineID,
        PipelineRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<Pipeline> Update(
        PipelineUpdateParams parameters,
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
    public Task<Pipeline> Update(
        string pipelineID,
        PipelineUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<List<Pipeline>> List(
        PipelineListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task Delete(
        PipelineDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task Delete(
        string pipelineID,
        PipelineDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { PipelineID = pipelineID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<Pipeline> Get(
        PipelineGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<Pipeline> Get(
        string pipelineID,
        PipelineGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<ManagedIngestionStatusResponse> GetStatus(
        PipelineGetStatusParams parameters,
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
        string pipelineID,
        PipelineGetStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetStatus(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<Pipeline> Upsert(
        PipelineUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Upsert(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PipelineServiceWithRawResponse : IPipelineServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPipelineServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PipelineServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PipelineServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;

        _sync = new(() => new Pipelines::SyncServiceWithRawResponse(client));
        _dataSources = new(() => new Pipelines::DataSourceServiceWithRawResponse(client));
        _images = new(() => new Pipelines::ImageServiceWithRawResponse(client));
        _files = new(() => new Pipelines::FileServiceWithRawResponse(client));
        _metadata = new(() => new Pipelines::MetadataServiceWithRawResponse(client));
        _documents = new(() => new Pipelines::DocumentServiceWithRawResponse(client));
    }

    readonly Lazy<Pipelines::ISyncServiceWithRawResponse> _sync;
    public Pipelines::ISyncServiceWithRawResponse Sync
    {
        get { return _sync.Value; }
    }

    readonly Lazy<Pipelines::IDataSourceServiceWithRawResponse> _dataSources;
    public Pipelines::IDataSourceServiceWithRawResponse DataSources
    {
        get { return _dataSources.Value; }
    }

    readonly Lazy<Pipelines::IImageServiceWithRawResponse> _images;
    public Pipelines::IImageServiceWithRawResponse Images
    {
        get { return _images.Value; }
    }

    readonly Lazy<Pipelines::IFileServiceWithRawResponse> _files;
    public Pipelines::IFileServiceWithRawResponse Files
    {
        get { return _files.Value; }
    }

    readonly Lazy<Pipelines::IMetadataServiceWithRawResponse> _metadata;
    public Pipelines::IMetadataServiceWithRawResponse Metadata
    {
        get { return _metadata.Value; }
    }

    readonly Lazy<Pipelines::IDocumentServiceWithRawResponse> _documents;
    public Pipelines::IDocumentServiceWithRawResponse Documents
    {
        get { return _documents.Value; }
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<Pipeline>> Create(
        PipelineCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PipelineCreateParams> request = new()
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
    public async Task<HttpResponse<PipelineRetrieveResponse>> Retrieve(
        PipelineRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<PipelineRetrieveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pipeline = await response
                    .Deserialize<PipelineRetrieveResponse>(token)
                    .ConfigureAwait(false);
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
    public Task<HttpResponse<PipelineRetrieveResponse>> Retrieve(
        string pipelineID,
        PipelineRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<Pipeline>> Update(
        PipelineUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<PipelineUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
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
    public Task<HttpResponse<Pipeline>> Update(
        string pipelineID,
        PipelineUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<List<Pipeline>>> List(
        PipelineListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PipelineListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pipelines = await response
                    .Deserialize<List<Pipeline>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in pipelines)
                    {
                        item.Validate();
                    }
                }
                return pipelines;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse> Delete(
        PipelineDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<PipelineDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse> Delete(
        string pipelineID,
        PipelineDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<Pipeline>> Get(
        PipelineGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<PipelineGetParams> request = new()
        {
            Method = HttpMethod.Get,
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
    public Task<HttpResponse<Pipeline>> Get(
        string pipelineID,
        PipelineGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<ManagedIngestionStatusResponse>> GetStatus(
        PipelineGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<PipelineGetStatusParams> request = new()
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
        string pipelineID,
        PipelineGetStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetStatus(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<Pipeline>> Upsert(
        PipelineUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PipelineUpsertParams> request = new()
        {
            Method = HttpMethod.Put,
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
}
