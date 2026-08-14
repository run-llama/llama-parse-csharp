using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Files;

namespace LlamaCloud.Services;

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
    public async Task<FileCreateResponse> Create(
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
    public async Task<FileRetrieveResponse> Retrieve(
        FileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FileRetrieveResponse> Retrieve(
        string fileID,
        FileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FileListPage> List(
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(FileDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string fileID,
        FileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { FileID = fileID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PresignedUrl> Content(
        FileContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Content(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PresignedUrl> Content(
        string fileID,
        FileContentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Content(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("Use the GET /files endpoint instead")]
    public async Task<FileQueryResponse> Query(
        FileQueryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Query(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
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
    public async Task<HttpResponse<FileCreateResponse>> Create(
        FileCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FileCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var file = await response
                    .Deserialize<FileCreateResponse>(token)
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
    public async Task<HttpResponse<FileRetrieveResponse>> Retrieve(
        FileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.FileID' cannot be null");
        }

        HttpRequest<FileRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var file = await response
                    .Deserialize<FileRetrieveResponse>(token)
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
    public Task<HttpResponse<FileRetrieveResponse>> Retrieve(
        string fileID,
        FileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FileListPage>> List(
        FileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

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
    public Task<HttpResponse> Delete(
        string fileID,
        FileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PresignedUrl>> Content(
        FileContentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FileID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.FileID' cannot be null");
        }

        HttpRequest<FileContentParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var presignedUrl = await response
                    .Deserialize<PresignedUrl>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    presignedUrl.Validate();
                }
                return presignedUrl;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PresignedUrl>> Content(
        string fileID,
        FileContentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Content(parameters with { FileID = fileID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("Use the GET /files endpoint instead")]
    public async Task<HttpResponse<FileQueryResponse>> Query(
        FileQueryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<FileQueryParams> request = new()
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
                    .Deserialize<FileQueryResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
