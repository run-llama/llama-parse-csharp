using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Beta.Directories;
using Directories = LlamaCloud.Services.Beta.Directories;

namespace LlamaCloud.Services.Beta;

/// <inheritdoc/>
public sealed class DirectoryService : IDirectoryService
{
    readonly Lazy<IDirectoryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDirectoryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IDirectoryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DirectoryService(this._client.WithOptions(modifier));
    }

    public DirectoryService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DirectoryServiceWithRawResponse(client.WithRawResponse));
        _files = new(() => new Directories::FileService(client));
    }

    readonly Lazy<Directories::IFileService> _files;
    public Directories::IFileService Files
    {
        get { return _files.Value; }
    }

    /// <inheritdoc/>
    public async Task<DirectoryCreateResponse> Create(
        DirectoryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DirectoryUpdateResponse> Update(
        DirectoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DirectoryUpdateResponse> Update(
        string directoryID,
        DirectoryUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { DirectoryID = directoryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DirectoryListPage> List(
        DirectoryListParams? parameters = null,
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
        DirectoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string directoryID,
        DirectoryDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { DirectoryID = directoryID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DirectoryGetResponse> Get(
        DirectoryGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DirectoryGetResponse> Get(
        string directoryID,
        DirectoryGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { DirectoryID = directoryID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DirectoryServiceWithRawResponse : IDirectoryServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDirectoryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DirectoryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DirectoryServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;

        _files = new(() => new Directories::FileServiceWithRawResponse(client));
    }

    readonly Lazy<Directories::IFileServiceWithRawResponse> _files;
    public Directories::IFileServiceWithRawResponse Files
    {
        get { return _files.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DirectoryCreateResponse>> Create(
        DirectoryCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<DirectoryCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var directory = await response
                    .Deserialize<DirectoryCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    directory.Validate();
                }
                return directory;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DirectoryUpdateResponse>> Update(
        DirectoryUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirectoryID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DirectoryID' cannot be null");
        }

        HttpRequest<DirectoryUpdateParams> request = new()
        {
            Method = LlamaCloudClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var directory = await response
                    .Deserialize<DirectoryUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    directory.Validate();
                }
                return directory;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DirectoryUpdateResponse>> Update(
        string directoryID,
        DirectoryUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { DirectoryID = directoryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DirectoryListPage>> List(
        DirectoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DirectoryListParams> request = new()
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
                    .Deserialize<DirectoryListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new DirectoryListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        DirectoryDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirectoryID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DirectoryID' cannot be null");
        }

        HttpRequest<DirectoryDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string directoryID,
        DirectoryDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { DirectoryID = directoryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DirectoryGetResponse>> Get(
        DirectoryGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirectoryID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DirectoryID' cannot be null");
        }

        HttpRequest<DirectoryGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var directory = await response
                    .Deserialize<DirectoryGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    directory.Validate();
                }
                return directory;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DirectoryGetResponse>> Get(
        string directoryID,
        DirectoryGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { DirectoryID = directoryID }, cancellationToken);
    }
}
