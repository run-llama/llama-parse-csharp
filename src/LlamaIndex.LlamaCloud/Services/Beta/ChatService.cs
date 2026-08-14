using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Beta.Chat;

namespace LlamaIndex.LlamaCloud.Services.Beta;

/// <inheritdoc/>
public sealed class ChatService : IChatService
{
    readonly Lazy<IChatServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IChatServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IChatService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChatService(this._client.WithOptions(modifier));
    }

    public ChatService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ChatServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ChatCreateResponse> Create(
        ChatCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ChatRetrieveResponse> Retrieve(
        ChatRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ChatRetrieveResponse> Retrieve(
        string sessionID,
        ChatRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ChatListPage> List(
        ChatListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(ChatDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string sessionID,
        ChatDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { SessionID = sessionID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ChatGetSummaryResponse> GetSummary(
        ChatGetSummaryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetSummary(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ChatGetSummaryResponse> GetSummary(
        string sessionID,
        ChatGetSummaryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetSummary(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Stream(
        ChatStreamParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Stream(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JsonElement> Stream(
        string sessionID,
        ChatStreamParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Stream(parameters with { SessionID = sessionID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ChatServiceWithRawResponse : IChatServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IChatServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChatServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ChatServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChatCreateResponse>> Create(
        ChatCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ChatCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var chat = await response
                    .Deserialize<ChatCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    chat.Validate();
                }
                return chat;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChatRetrieveResponse>> Retrieve(
        ChatRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<ChatRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var chat = await response
                    .Deserialize<ChatRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    chat.Validate();
                }
                return chat;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ChatRetrieveResponse>> Retrieve(
        string sessionID,
        ChatRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChatListPage>> List(
        ChatListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ChatListParams> request = new()
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
                    .Deserialize<ChatListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ChatListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ChatDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<ChatDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string sessionID,
        ChatDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChatGetSummaryResponse>> GetSummary(
        ChatGetSummaryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<ChatGetSummaryParams> request = new()
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
                    .Deserialize<ChatGetSummaryResponse>(token)
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
    public Task<HttpResponse<ChatGetSummaryResponse>> GetSummary(
        string sessionID,
        ChatGetSummaryParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetSummary(parameters with { SessionID = sessionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> Stream(
        ChatStreamParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SessionID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.SessionID' cannot be null");
        }

        HttpRequest<ChatStreamParams> request = new()
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
    public Task<HttpResponse<JsonElement>> Stream(
        string sessionID,
        ChatStreamParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Stream(parameters with { SessionID = sessionID }, cancellationToken);
    }
}
