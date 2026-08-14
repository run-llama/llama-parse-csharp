using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Pipelines;
using LlamaIndex.LlamaCloud.Models.Pipelines.Files;

namespace LlamaIndex.LlamaCloud.Services.Pipelines;

/// <inheritdoc/>
public sealed class FileService : IFileService
{
    readonly Lazy<IFileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFileServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IFileService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FileService(this._client.WithOptions(modifier));
    }

    public FileService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FileServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<List<PipelineFile>> Create(
        FileCreateParams parameters,
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
    public Task<List<PipelineFile>> Create(
        string pipelineID,
        FileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<PipelineFile> Update(
        FileUpdateParams parameters,
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
    public Task<PipelineFile> Update(
        string fileID,
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<FileListPage> List(
        FileListParams parameters,
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
    public Task<FileListPage> List(
        string pipelineID,
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task Delete(FileDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task Delete(
        string fileID,
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { FileID = fileID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<ManagedIngestionStatusResponse> GetStatus(
        FileGetStatusParams parameters,
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
        string fileID,
        FileGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetStatus(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<FileGetStatusCountsResponse> GetStatusCounts(
        FileGetStatusCountsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetStatusCounts(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<FileGetStatusCountsResponse> GetStatusCounts(
        string pipelineID,
        FileGetStatusCountsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetStatusCounts(parameters with { PipelineID = pipelineID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class FileServiceWithRawResponse : IFileServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FileServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<List<PipelineFile>>> Create(
        FileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<FileCreateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pipelineFiles = await response
                    .Deserialize<List<PipelineFile>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in pipelineFiles)
                    {
                        item.Validate();
                    }
                }
                return pipelineFiles;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<List<PipelineFile>>> Create(
        string pipelineID,
        FileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<PipelineFile>> Update(
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.FileID' cannot be null");
        }

        HttpRequest<FileUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var pipelineFile = await response
                    .Deserialize<PipelineFile>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    pipelineFile.Validate();
                }
                return pipelineFile;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<PipelineFile>> Update(
        string fileID,
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<FileListPage>> List(
        FileListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<FileListParams> request = new()
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
                    .Deserialize<FileListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new FileListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<FileListPage>> List(
        string pipelineID,
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse> Delete(
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.FileID' cannot be null");
        }

        HttpRequest<FileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse> Delete(
        string fileID,
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<ManagedIngestionStatusResponse>> GetStatus(
        FileGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.FileID' cannot be null");
        }

        HttpRequest<FileGetStatusParams> request = new()
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
        string fileID,
        FileGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetStatus(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<FileGetStatusCountsResponse>> GetStatusCounts(
        FileGetStatusCountsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<FileGetStatusCountsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<FileGetStatusCountsResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<FileGetStatusCountsResponse>> GetStatusCounts(
        string pipelineID,
        FileGetStatusCountsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetStatusCounts(parameters with { PipelineID = pipelineID }, cancellationToken);
    }
}
