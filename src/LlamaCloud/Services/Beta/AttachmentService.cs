using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Beta.Attachments;
using LlamaCloud.Models.Files;

namespace LlamaCloud.Services.Beta;

/// <inheritdoc/>
public sealed class AttachmentService : IAttachmentService
{
    readonly Lazy<IAttachmentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAttachmentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IAttachmentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AttachmentService(this._client.WithOptions(modifier));
    }

    public AttachmentService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AttachmentServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AttachmentListPage> List(
        AttachmentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PresignedUrl> Get(
        AttachmentGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PresignedUrl> Get(
        string attachmentName,
        AttachmentGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Get(parameters with { AttachmentName = attachmentName }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AttachmentServiceWithRawResponse : IAttachmentServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAttachmentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AttachmentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AttachmentServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AttachmentListPage>> List(
        AttachmentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AttachmentListParams> request = new()
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
                    .Deserialize<AttachmentListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AttachmentListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PresignedUrl>> Get(
        AttachmentGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AttachmentName == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.AttachmentName' cannot be null");
        }

        HttpRequest<AttachmentGetParams> request = new()
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
    public Task<HttpResponse<PresignedUrl>> Get(
        string attachmentName,
        AttachmentGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Get(parameters with { AttachmentName = attachmentName }, cancellationToken);
    }
}
