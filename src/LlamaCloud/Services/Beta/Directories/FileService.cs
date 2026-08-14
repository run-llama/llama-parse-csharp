using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Beta.Directories.Files;

namespace LlamaCloud.Services.Beta.Directories;

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
    public async Task<FileUpdateResponse> Update(
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
    public Task<FileUpdateResponse> Update(
        string directoryFileID,
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(
            parameters with
            {
                DirectoryFileID = directoryFileID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
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
    public Task<FileListPage> List(
        string directoryID,
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { DirectoryID = directoryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(FileDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string directoryFileID,
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { DirectoryFileID = directoryFileID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FileAddResponse> Add(
        FileAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Add(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FileAddResponse> Add(
        string directoryID,
        FileAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { DirectoryID = directoryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FileGetResponse> Get(
        FileGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FileGetResponse> Get(
        string directoryFileID,
        FileGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Get(parameters with { DirectoryFileID = directoryFileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FileUploadResponse> Upload(
        FileUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Upload(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FileUploadResponse> Upload(
        string directoryID,
        FileUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upload(parameters with { DirectoryID = directoryID }, cancellationToken);
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
    public async Task<HttpResponse<FileUpdateResponse>> Update(
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirectoryFileID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DirectoryFileID' cannot be null");
        }

        HttpRequest<FileUpdateParams> request = new()
        {
            Method = LlamaCloudClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var file = await response
                    .Deserialize<FileUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    file.Validate();
                }
                return file;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FileUpdateResponse>> Update(
        string directoryFileID,
        FileUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(
            parameters with
            {
                DirectoryFileID = directoryFileID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileListPage>> List(
        FileListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirectoryID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DirectoryID' cannot be null");
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
    public Task<HttpResponse<FileListPage>> List(
        string directoryID,
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { DirectoryID = directoryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirectoryFileID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DirectoryFileID' cannot be null");
        }

        HttpRequest<FileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string directoryFileID,
        FileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(
            parameters with
            {
                DirectoryFileID = directoryFileID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileAddResponse>> Add(
        FileAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirectoryID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DirectoryID' cannot be null");
        }

        HttpRequest<FileAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<FileAddResponse>(token)
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
    public Task<HttpResponse<FileAddResponse>> Add(
        string directoryID,
        FileAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { DirectoryID = directoryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileGetResponse>> Get(
        FileGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirectoryFileID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DirectoryFileID' cannot be null");
        }

        HttpRequest<FileGetParams> request = new() { Method = HttpMethod.Get, Params = parameters };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var file = await response.Deserialize<FileGetResponse>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    file.Validate();
                }
                return file;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FileGetResponse>> Get(
        string directoryFileID,
        FileGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Get(parameters with { DirectoryFileID = directoryFileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileUploadResponse>> Upload(
        FileUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirectoryID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DirectoryID' cannot be null");
        }

        HttpRequest<FileUploadParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<FileUploadResponse>(token)
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
    public Task<HttpResponse<FileUploadResponse>> Upload(
        string directoryID,
        FileUploadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upload(parameters with { DirectoryID = directoryID }, cancellationToken);
    }
}
