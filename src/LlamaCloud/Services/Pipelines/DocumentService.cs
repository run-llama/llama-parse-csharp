using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines;
using LlamaCloud.Models.Pipelines.Documents;

namespace LlamaCloud.Services.Pipelines;

/// <inheritdoc/>
public sealed class DocumentService : IDocumentService
{
    readonly Lazy<IDocumentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDocumentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IDocumentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DocumentService(this._client.WithOptions(modifier));
    }

    public DocumentService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DocumentServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<List<CloudDocument>> Create(
        DocumentCreateParams parameters,
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
    public Task<List<CloudDocument>> Create(
        string pipelineID,
        DocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<DocumentListPage> List(
        DocumentListParams parameters,
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
    public Task<DocumentListPage> List(
        string pipelineID,
        DocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task Delete(
        DocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task Delete(
        string documentID,
        DocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { DocumentID = documentID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<CloudDocument> Get(
        DocumentGetParams parameters,
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
    public Task<CloudDocument> Get(
        string documentID,
        DocumentGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Get(parameters with { DocumentID = documentID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<List<TextNode>> GetChunks(
        DocumentGetChunksParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetChunks(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<List<TextNode>> GetChunks(
        string documentID,
        DocumentGetChunksParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetChunks(parameters with { DocumentID = documentID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<ManagedIngestionStatusResponse> GetStatus(
        DocumentGetStatusParams parameters,
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
        string documentID,
        DocumentGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetStatus(parameters with { DocumentID = documentID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<DocumentGetStatusCountsResponse> GetStatusCounts(
        DocumentGetStatusCountsParams parameters,
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
    public Task<DocumentGetStatusCountsResponse> GetStatusCounts(
        string pipelineID,
        DocumentGetStatusCountsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetStatusCounts(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<JsonElement> Sync(
        DocumentSyncParams parameters,
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
    public Task<JsonElement> Sync(
        string documentID,
        DocumentSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Sync(parameters with { DocumentID = documentID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<List<CloudDocument>> Upsert(
        DocumentUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Upsert(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<List<CloudDocument>> Upsert(
        string pipelineID,
        DocumentUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upsert(parameters with { PipelineID = pipelineID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DocumentServiceWithRawResponse : IDocumentServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDocumentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DocumentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DocumentServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<List<CloudDocument>>> Create(
        DocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<DocumentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cloudDocuments = await response
                    .Deserialize<List<CloudDocument>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in cloudDocuments)
                    {
                        item.Validate();
                    }
                }
                return cloudDocuments;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<List<CloudDocument>>> Create(
        string pipelineID,
        DocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<DocumentListPage>> List(
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<DocumentListParams> request = new()
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
                    .Deserialize<DocumentListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new DocumentListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<DocumentListPage>> List(
        string pipelineID,
        DocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse> Delete(
        DocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DocumentID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DocumentID' cannot be null");
        }

        HttpRequest<DocumentDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse> Delete(
        string documentID,
        DocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { DocumentID = documentID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<CloudDocument>> Get(
        DocumentGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DocumentID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DocumentID' cannot be null");
        }

        HttpRequest<DocumentGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cloudDocument = await response
                    .Deserialize<CloudDocument>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    cloudDocument.Validate();
                }
                return cloudDocument;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<CloudDocument>> Get(
        string documentID,
        DocumentGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Get(parameters with { DocumentID = documentID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<List<TextNode>>> GetChunks(
        DocumentGetChunksParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DocumentID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DocumentID' cannot be null");
        }

        HttpRequest<DocumentGetChunksParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var textNodes = await response
                    .Deserialize<List<TextNode>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in textNodes)
                    {
                        item.Validate();
                    }
                }
                return textNodes;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<List<TextNode>>> GetChunks(
        string documentID,
        DocumentGetChunksParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetChunks(parameters with { DocumentID = documentID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<ManagedIngestionStatusResponse>> GetStatus(
        DocumentGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DocumentID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DocumentID' cannot be null");
        }

        HttpRequest<DocumentGetStatusParams> request = new()
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
        string documentID,
        DocumentGetStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetStatus(parameters with { DocumentID = documentID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<DocumentGetStatusCountsResponse>> GetStatusCounts(
        DocumentGetStatusCountsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<DocumentGetStatusCountsParams> request = new()
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
                    .Deserialize<DocumentGetStatusCountsResponse>(token)
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
    public Task<HttpResponse<DocumentGetStatusCountsResponse>> GetStatusCounts(
        string pipelineID,
        DocumentGetStatusCountsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetStatusCounts(parameters with { PipelineID = pipelineID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<JsonElement>> Sync(
        DocumentSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DocumentID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.DocumentID' cannot be null");
        }

        HttpRequest<DocumentSyncParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<JsonElement>> Sync(
        string documentID,
        DocumentSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Sync(parameters with { DocumentID = documentID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<List<CloudDocument>>> Upsert(
        DocumentUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PipelineID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PipelineID' cannot be null");
        }

        HttpRequest<DocumentUpsertParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var cloudDocuments = await response
                    .Deserialize<List<CloudDocument>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in cloudDocuments)
                    {
                        item.Validate();
                    }
                }
                return cloudDocuments;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<List<CloudDocument>>> Upsert(
        string pipelineID,
        DocumentUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upsert(parameters with { PipelineID = pipelineID }, cancellationToken);
    }
}
