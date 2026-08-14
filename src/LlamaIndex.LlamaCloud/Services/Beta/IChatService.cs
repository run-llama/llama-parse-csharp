using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.Chat;

namespace LlamaIndex.LlamaCloud.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IChatService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IChatServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChatService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a chat session, optionally bound to indexes (locked after the first
    /// message).
    /// </summary>
    Task<ChatCreateResponse> Create(
        ChatCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a full session by ID, including its event history.
    /// </summary>
    Task<ChatRetrieveResponse> Retrieve(
        ChatRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ChatRetrieveParams, CancellationToken)"/>
    Task<ChatRetrieveResponse> Retrieve(
        string sessionID,
        ChatRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all chat sessions for the current project.
    /// </summary>
    Task<ChatListPage> List(
        ChatListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a session.
    /// </summary>
    Task Delete(ChatDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ChatDeleteParams, CancellationToken)"/>
    Task Delete(
        string sessionID,
        ChatDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a session summary by ID.
    /// </summary>
    Task<ChatGetSummaryResponse> GetSummary(
        ChatGetSummaryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetSummary(ChatGetSummaryParams, CancellationToken)"/>
    Task<ChatGetSummaryResponse> GetSummary(
        string sessionID,
        ChatGetSummaryParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stream agent events for a chat turn as Server-Sent Events.
    /// </summary>
    Task<JsonElement> Stream(
        ChatStreamParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Stream(ChatStreamParams, CancellationToken)"/>
    Task<JsonElement> Stream(
        string sessionID,
        ChatStreamParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IChatService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IChatServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChatServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/chat</c>, but is otherwise the
    /// same as <see cref="IChatService.Create(ChatCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChatCreateResponse>> Create(
        ChatCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/chat/{session_id}</c>, but is otherwise the
    /// same as <see cref="IChatService.Retrieve(ChatRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChatRetrieveResponse>> Retrieve(
        ChatRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ChatRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ChatRetrieveResponse>> Retrieve(
        string sessionID,
        ChatRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/chat</c>, but is otherwise the
    /// same as <see cref="IChatService.List(ChatListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChatListPage>> List(
        ChatListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/chat/{session_id}</c>, but is otherwise the
    /// same as <see cref="IChatService.Delete(ChatDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ChatDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ChatDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string sessionID,
        ChatDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/chat/{session_id}/summary</c>, but is otherwise the
    /// same as <see cref="IChatService.GetSummary(ChatGetSummaryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChatGetSummaryResponse>> GetSummary(
        ChatGetSummaryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetSummary(ChatGetSummaryParams, CancellationToken)"/>
    Task<HttpResponse<ChatGetSummaryResponse>> GetSummary(
        string sessionID,
        ChatGetSummaryParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/chat/{session_id}/messages/stream</c>, but is otherwise the
    /// same as <see cref="IChatService.Stream(ChatStreamParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JsonElement>> Stream(
        ChatStreamParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Stream(ChatStreamParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> Stream(
        string sessionID,
        ChatStreamParams parameters,
        CancellationToken cancellationToken = default
    );
}
