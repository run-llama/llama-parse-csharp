using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Models.Beta.Chat;

namespace LlamaCloud.Services.Beta;

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
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task<ChatCreateResponse> Create(
        ChatCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a full session by ID, including its event history.
    /// </summary>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task<ChatRetrieveResponse> Retrieve(
        ChatRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ChatRetrieveParams, CancellationToken)"/>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task<ChatRetrieveResponse> Retrieve(
        string sessionID,
        ChatRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all chat sessions for the current project.
    /// </summary>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task<ChatListPage> List(
        ChatListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a session.
    /// </summary>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task Delete(ChatDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ChatDeleteParams, CancellationToken)"/>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task Delete(
        string sessionID,
        ChatDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a session summary by ID.
    /// </summary>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task<ChatGetSummaryResponse> GetSummary(
        ChatGetSummaryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetSummary(ChatGetSummaryParams, CancellationToken)"/>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task<ChatGetSummaryResponse> GetSummary(
        string sessionID,
        ChatGetSummaryParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stream agent events for a chat turn as Server-Sent Events.
    /// </summary>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task<JsonElement> Stream(
        ChatStreamParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Stream(ChatStreamParams, CancellationToken)"/>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
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
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task<HttpResponse<ChatCreateResponse>> Create(
        ChatCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/chat/{session_id}</c>, but is otherwise the
    /// same as <see cref="IChatService.Retrieve(ChatRetrieveParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task<HttpResponse<ChatRetrieveResponse>> Retrieve(
        ChatRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ChatRetrieveParams, CancellationToken)"/>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task<HttpResponse<ChatRetrieveResponse>> Retrieve(
        string sessionID,
        ChatRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/chat</c>, but is otherwise the
    /// same as <see cref="IChatService.List(ChatListParams?, CancellationToken)"/>.
    /// </summary>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task<HttpResponse<ChatListPage>> List(
        ChatListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/chat/{session_id}</c>, but is otherwise the
    /// same as <see cref="IChatService.Delete(ChatDeleteParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task<HttpResponse> Delete(
        ChatDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ChatDeleteParams, CancellationToken)"/>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task<HttpResponse> Delete(
        string sessionID,
        ChatDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/chat/{session_id}/summary</c>, but is otherwise the
    /// same as <see cref="IChatService.GetSummary(ChatGetSummaryParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task<HttpResponse<ChatGetSummaryResponse>> GetSummary(
        ChatGetSummaryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetSummary(ChatGetSummaryParams, CancellationToken)"/>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task<HttpResponse<ChatGetSummaryResponse>> GetSummary(
        string sessionID,
        ChatGetSummaryParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/chat/{session_id}/messages/stream</c>, but is otherwise the
    /// same as <see cref="IChatService.Stream(ChatStreamParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task<HttpResponse<JsonElement>> Stream(
        ChatStreamParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Stream(ChatStreamParams, CancellationToken)"/>
    [Obsolete("Moved out of beta. Use the top-level chat resource instead")]
    Task<HttpResponse<JsonElement>> Stream(
        string sessionID,
        ChatStreamParams parameters,
        CancellationToken cancellationToken = default
    );
}
