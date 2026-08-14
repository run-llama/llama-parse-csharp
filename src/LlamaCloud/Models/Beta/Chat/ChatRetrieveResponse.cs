using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Beta.Chat;

/// <summary>
/// Full chat session including its complete event history.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ChatRetrieveResponse, ChatRetrieveResponseFromRaw>))]
public sealed record class ChatRetrieveResponse : JsonModel
{
    /// <summary>
    /// Ordered list of events that make up the conversation history.
    /// </summary>
    public required IReadOnlyList<Event> Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Event>>("events");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Event>>(
                "events",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO-format timestamp showing when the session was last updated.
    /// </summary>
    public required string LastUpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("last_updated_at");
        }
        init { this._rawData.Set("last_updated_at", value); }
    }

    /// <summary>
    /// Unique session identifier.
    /// </summary>
    public required string SessionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("session_id");
        }
        init { this._rawData.Set("session_id", value); }
    }

    /// <summary>
    /// Auto-generated title derived from the first user message.
    /// </summary>
    public string? GeneratedTitle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("generated_title");
        }
        init { this._rawData.Set("generated_title", value); }
    }

    /// <summary>
    /// Indexes this session is bound to. Null on unbound sessions.
    /// </summary>
    public IReadOnlyList<string>? IndexIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("index_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "index_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Token usage and status from the most recent run. Null if the session has
    /// not been run yet.
    /// </summary>
    public ChatRetrieveResponseJobMetadata? JobMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChatRetrieveResponseJobMetadata>("job_metadata");
        }
        init { this._rawData.Set("job_metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Events)
        {
            item.Validate();
        }
        _ = this.LastUpdatedAt;
        _ = this.SessionID;
        _ = this.GeneratedTitle;
        _ = this.IndexIds;
        this.JobMetadata?.Validate();
    }

    public ChatRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatRetrieveResponse(ChatRetrieveResponse chatRetrieveResponse)
        : base(chatRetrieveResponse) { }
#pragma warning restore CS8618

    public ChatRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ChatRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatRetrieveResponseFromRaw : IFromRawJson<ChatRetrieveResponse>
{
    /// <inheritdoc/>
    public ChatRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(EventConverter))]
public record class Event : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Content
    {
        get
        {
            return Match<string?>(
                stop: (_) => null,
                textDelta: (x) => x.Content,
                text: (x) => x.Content,
                thinkingDelta: (x) => x.Content,
                thinking: (x) => x.Content,
                toolCall: (_) => null,
                toolResult: (_) => null,
                userInput: (x) => x.Content
            );
        }
    }

    public string? CallID
    {
        get
        {
            return Match<string?>(
                stop: (_) => null,
                textDelta: (_) => null,
                text: (_) => null,
                thinkingDelta: (_) => null,
                thinking: (_) => null,
                toolCall: (x) => x.CallID,
                toolResult: (x) => x.CallID,
                userInput: (_) => null
            );
        }
    }

    public string? Name
    {
        get
        {
            return Match<string?>(
                stop: (_) => null,
                textDelta: (_) => null,
                text: (_) => null,
                thinkingDelta: (_) => null,
                thinking: (_) => null,
                toolCall: (x) => x.Name,
                toolResult: (x) => x.Name,
                userInput: (_) => null
            );
        }
    }

    public Event(Stop value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Event(TextDelta value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Event(Text value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Event(ThinkingDelta value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Event(Thinking value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Event(ToolCall value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Event(ToolResult value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Event(UserInput value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Event(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Stop"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStop(out var value)) {
    ///     // `value` is of type `Stop`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStop([NotNullWhen(true)] out Stop? value)
    {
        value = this.Value as Stop;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextDelta"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextDelta(out var value)) {
    ///     // `value` is of type `TextDelta`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextDelta([NotNullWhen(true)] out TextDelta? value)
    {
        value = this.Value as TextDelta;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Text"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickText(out var value)) {
    ///     // `value` is of type `Text`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickText([NotNullWhen(true)] out Text? value)
    {
        value = this.Value as Text;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ThinkingDelta"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThinkingDelta(out var value)) {
    ///     // `value` is of type `ThinkingDelta`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThinkingDelta([NotNullWhen(true)] out ThinkingDelta? value)
    {
        value = this.Value as ThinkingDelta;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Thinking"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThinking(out var value)) {
    ///     // `value` is of type `Thinking`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThinking([NotNullWhen(true)] out Thinking? value)
    {
        value = this.Value as Thinking;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolCall"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickToolCall(out var value)) {
    ///     // `value` is of type `ToolCall`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickToolCall([NotNullWhen(true)] out ToolCall? value)
    {
        value = this.Value as ToolCall;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolResult"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickToolResult(out var value)) {
    ///     // `value` is of type `ToolResult`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickToolResult([NotNullWhen(true)] out ToolResult? value)
    {
        value = this.Value as ToolResult;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UserInput"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUserInput(out var value)) {
    ///     // `value` is of type `UserInput`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUserInput([NotNullWhen(true)] out UserInput? value)
    {
        value = this.Value as UserInput;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (Stop value) =&gt; {...},
    ///     (TextDelta value) =&gt; {...},
    ///     (Text value) =&gt; {...},
    ///     (ThinkingDelta value) =&gt; {...},
    ///     (Thinking value) =&gt; {...},
    ///     (ToolCall value) =&gt; {...},
    ///     (ToolResult value) =&gt; {...},
    ///     (UserInput value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<Stop> stop,
        System::Action<TextDelta> textDelta,
        System::Action<Text> text,
        System::Action<ThinkingDelta> thinkingDelta,
        System::Action<Thinking> thinking,
        System::Action<ToolCall> toolCall,
        System::Action<ToolResult> toolResult,
        System::Action<UserInput> userInput
    )
    {
        switch (this.Value)
        {
            case Stop value:
                stop(value);
                break;
            case TextDelta value:
                textDelta(value);
                break;
            case Text value:
                text(value);
                break;
            case ThinkingDelta value:
                thinkingDelta(value);
                break;
            case Thinking value:
                thinking(value);
                break;
            case ToolCall value:
                toolCall(value);
                break;
            case ToolResult value:
                toolResult(value);
                break;
            case UserInput value:
                userInput(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException("Data did not match any variant of Event");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (Stop value) =&gt; {...},
    ///     (TextDelta value) =&gt; {...},
    ///     (Text value) =&gt; {...},
    ///     (ThinkingDelta value) =&gt; {...},
    ///     (Thinking value) =&gt; {...},
    ///     (ToolCall value) =&gt; {...},
    ///     (ToolResult value) =&gt; {...},
    ///     (UserInput value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<Stop, T> stop,
        System::Func<TextDelta, T> textDelta,
        System::Func<Text, T> text,
        System::Func<ThinkingDelta, T> thinkingDelta,
        System::Func<Thinking, T> thinking,
        System::Func<ToolCall, T> toolCall,
        System::Func<ToolResult, T> toolResult,
        System::Func<UserInput, T> userInput
    )
    {
        return this.Value switch
        {
            Stop value => stop(value),
            TextDelta value => textDelta(value),
            Text value => text(value),
            ThinkingDelta value => thinkingDelta(value),
            Thinking value => thinking(value),
            ToolCall value => toolCall(value),
            ToolResult value => toolResult(value),
            UserInput value => userInput(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of Event"
            ),
        };
    }

    public static implicit operator Event(Stop value) => new(value);

    public static implicit operator Event(TextDelta value) => new(value);

    public static implicit operator Event(Text value) => new(value);

    public static implicit operator Event(ThinkingDelta value) => new(value);

    public static implicit operator Event(Thinking value) => new(value);

    public static implicit operator Event(ToolCall value) => new(value);

    public static implicit operator Event(ToolResult value) => new(value);

    public static implicit operator Event(UserInput value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new LlamaCloudInvalidDataException("Data did not match any variant of Event");
        }
        this.Switch(
            (stop) => stop.Validate(),
            (textDelta) => textDelta.Validate(),
            (text) => text.Validate(),
            (thinkingDelta) => thinkingDelta.Validate(),
            (thinking) => thinking.Validate(),
            (toolCall) => toolCall.Validate(),
            (toolResult) => toolResult.Validate(),
            (userInput) => userInput.Validate()
        );
    }

    public virtual bool Equals(Event? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            Stop _ => 0,
            TextDelta _ => 1,
            Text _ => 2,
            ThinkingDelta _ => 3,
            Thinking _ => 4,
            ToolCall _ => 5,
            ToolResult _ => 6,
            UserInput _ => 7,
            _ => -1,
        };
    }
}

sealed class EventConverter : JsonConverter<Event>
{
    public override Event? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "stop":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Stop>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "text_delta":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TextDelta>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "text":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Text>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "thinking_delta":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThinkingDelta>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "thinking":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Thinking>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tool_call":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolCall>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolResult>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "user_input":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UserInput>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Event(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Event value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Stop, StopFromRaw>))]
public sealed record class Stop : JsonModel
{
    public required string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    public required bool IsError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_error");
        }
        init { this._rawData.Set("is_error", value); }
    }

    public required Usage Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Usage>("usage");
        }
        init { this._rawData.Set("usage", value); }
    }

    public ApiEnum<string, global::LlamaCloud.Models.Beta.Chat.Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::LlamaCloud.Models.Beta.Chat.Type>
            >("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Error;
        _ = this.IsError;
        this.Usage.Validate();
        this.Type?.Validate();
    }

    public Stop() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Stop(Stop stop)
        : base(stop) { }
#pragma warning restore CS8618

    public Stop(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Stop(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StopFromRaw.FromRawUnchecked"/>
    public static Stop FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StopFromRaw : IFromRawJson<Stop>
{
    /// <inheritdoc/>
    public Stop FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Stop.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Usage, UsageFromRaw>))]
public sealed record class Usage : JsonModel
{
    public double? DurationMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("duration_ms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("duration_ms", value);
        }
    }

    public long? TotalInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_input_tokens");
        }
        init { this._rawData.Set("total_input_tokens", value); }
    }

    public long? TotalOutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_output_tokens");
        }
        init { this._rawData.Set("total_output_tokens", value); }
    }

    public long? Turns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("turns");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("turns", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DurationMs;
        _ = this.TotalInputTokens;
        _ = this.TotalOutputTokens;
        _ = this.Turns;
    }

    public Usage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Usage(Usage usage)
        : base(usage) { }
#pragma warning restore CS8618

    public Usage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Usage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageFromRaw.FromRawUnchecked"/>
    public static Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageFromRaw : IFromRawJson<Usage>
{
    /// <inheritdoc/>
    public Usage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Usage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Stop,
}

sealed class TypeConverter : JsonConverter<global::LlamaCloud.Models.Beta.Chat.Type>
{
    public override global::LlamaCloud.Models.Beta.Chat.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stop" => global::LlamaCloud.Models.Beta.Chat.Type.Stop,
            _ => (global::LlamaCloud.Models.Beta.Chat.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::LlamaCloud.Models.Beta.Chat.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::LlamaCloud.Models.Beta.Chat.Type.Stop => "stop",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<TextDelta, TextDeltaFromRaw>))]
public sealed record class TextDelta : JsonModel
{
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public ApiEnum<string, TextDeltaType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TextDeltaType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.Type?.Validate();
    }

    public TextDelta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextDelta(TextDelta textDelta)
        : base(textDelta) { }
#pragma warning restore CS8618

    public TextDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextDeltaFromRaw.FromRawUnchecked"/>
    public static TextDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TextDelta(string content)
        : this()
    {
        this.Content = content;
    }
}

class TextDeltaFromRaw : IFromRawJson<TextDelta>
{
    /// <inheritdoc/>
    public TextDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TextDelta.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TextDeltaTypeConverter))]
public enum TextDeltaType
{
    TextDelta,
}

sealed class TextDeltaTypeConverter : JsonConverter<TextDeltaType>
{
    public override TextDeltaType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text_delta" => TextDeltaType.TextDelta,
            _ => (TextDeltaType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TextDeltaType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TextDeltaType.TextDelta => "text_delta",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Text, TextFromRaw>))]
public sealed record class Text : JsonModel
{
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public ApiEnum<string, TextType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TextType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.Type?.Validate();
    }

    public Text() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Text(Text text)
        : base(text) { }
#pragma warning restore CS8618

    public Text(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Text(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextFromRaw.FromRawUnchecked"/>
    public static Text FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Text(string content)
        : this()
    {
        this.Content = content;
    }
}

class TextFromRaw : IFromRawJson<Text>
{
    /// <inheritdoc/>
    public Text FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Text.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TextTypeConverter))]
public enum TextType
{
    Text,
}

sealed class TextTypeConverter : JsonConverter<TextType>
{
    public override TextType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => TextType.Text,
            _ => (TextType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, TextType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TextType.Text => "text",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<ThinkingDelta, ThinkingDeltaFromRaw>))]
public sealed record class ThinkingDelta : JsonModel
{
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public ApiEnum<string, ThinkingDeltaType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ThinkingDeltaType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.Type?.Validate();
    }

    public ThinkingDelta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThinkingDelta(ThinkingDelta thinkingDelta)
        : base(thinkingDelta) { }
#pragma warning restore CS8618

    public ThinkingDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThinkingDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThinkingDeltaFromRaw.FromRawUnchecked"/>
    public static ThinkingDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ThinkingDelta(string content)
        : this()
    {
        this.Content = content;
    }
}

class ThinkingDeltaFromRaw : IFromRawJson<ThinkingDelta>
{
    /// <inheritdoc/>
    public ThinkingDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ThinkingDelta.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ThinkingDeltaTypeConverter))]
public enum ThinkingDeltaType
{
    ThinkingDelta,
}

sealed class ThinkingDeltaTypeConverter : JsonConverter<ThinkingDeltaType>
{
    public override ThinkingDeltaType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "thinking_delta" => ThinkingDeltaType.ThinkingDelta,
            _ => (ThinkingDeltaType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ThinkingDeltaType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ThinkingDeltaType.ThinkingDelta => "thinking_delta",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Thinking, ThinkingFromRaw>))]
public sealed record class Thinking : JsonModel
{
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public ApiEnum<string, ThinkingType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ThinkingType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.Type?.Validate();
    }

    public Thinking() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Thinking(Thinking thinking)
        : base(thinking) { }
#pragma warning restore CS8618

    public Thinking(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Thinking(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThinkingFromRaw.FromRawUnchecked"/>
    public static Thinking FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Thinking(string content)
        : this()
    {
        this.Content = content;
    }
}

class ThinkingFromRaw : IFromRawJson<Thinking>
{
    /// <inheritdoc/>
    public Thinking FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Thinking.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ThinkingTypeConverter))]
public enum ThinkingType
{
    Thinking,
}

sealed class ThinkingTypeConverter : JsonConverter<ThinkingType>
{
    public override ThinkingType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "thinking" => ThinkingType.Thinking,
            _ => (ThinkingType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ThinkingType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ThinkingType.Thinking => "thinking",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<ToolCall, ToolCallFromRaw>))]
public sealed record class ToolCall : JsonModel
{
    public required IReadOnlyDictionary<string, JsonElement> Arguments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "arguments"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "arguments",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required string CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("call_id");
        }
        init { this._rawData.Set("call_id", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public ApiEnum<string, ToolCallType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ToolCallType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Arguments;
        _ = this.CallID;
        _ = this.Name;
        this.Type?.Validate();
    }

    public ToolCall() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolCall(ToolCall toolCall)
        : base(toolCall) { }
#pragma warning restore CS8618

    public ToolCall(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolCall(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolCallFromRaw.FromRawUnchecked"/>
    public static ToolCall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolCallFromRaw : IFromRawJson<ToolCall>
{
    /// <inheritdoc/>
    public ToolCall FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ToolCall.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ToolCallTypeConverter))]
public enum ToolCallType
{
    ToolCall,
}

sealed class ToolCallTypeConverter : JsonConverter<ToolCallType>
{
    public override ToolCallType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tool_call" => ToolCallType.ToolCall,
            _ => (ToolCallType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToolCallType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ToolCallType.ToolCall => "tool_call",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<ToolResult, ToolResultFromRaw>))]
public sealed record class ToolResult : JsonModel
{
    public required string CallID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("call_id");
        }
        init { this._rawData.Set("call_id", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required JsonElement Result
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("result");
        }
        init { this._rawData.Set("result", value); }
    }

    /// <summary>
    /// Coordinates for lazily resolving a page screenshot presigned URL.
    /// </summary>
    public ImageAttachment? ImageAttachment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ImageAttachment>("image_attachment");
        }
        init { this._rawData.Set("image_attachment", value); }
    }

    public ApiEnum<string, ToolResultType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ToolResultType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallID;
        _ = this.Name;
        _ = this.Result;
        this.ImageAttachment?.Validate();
        this.Type?.Validate();
    }

    public ToolResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolResult(ToolResult toolResult)
        : base(toolResult) { }
#pragma warning restore CS8618

    public ToolResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolResultFromRaw.FromRawUnchecked"/>
    public static ToolResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolResultFromRaw : IFromRawJson<ToolResult>
{
    /// <inheritdoc/>
    public ToolResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ToolResult.FromRawUnchecked(rawData);
}

/// <summary>
/// Coordinates for lazily resolving a page screenshot presigned URL.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ImageAttachment, ImageAttachmentFromRaw>))]
public sealed record class ImageAttachment : JsonModel
{
    public required string AttachmentName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("attachment_name");
        }
        init { this._rawData.Set("attachment_name", value); }
    }

    public required string SourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source_id");
        }
        init { this._rawData.Set("source_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AttachmentName;
        _ = this.SourceID;
    }

    public ImageAttachment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAttachment(ImageAttachment imageAttachment)
        : base(imageAttachment) { }
#pragma warning restore CS8618

    public ImageAttachment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAttachment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAttachmentFromRaw.FromRawUnchecked"/>
    public static ImageAttachment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageAttachmentFromRaw : IFromRawJson<ImageAttachment>
{
    /// <inheritdoc/>
    public ImageAttachment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ImageAttachment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ToolResultTypeConverter))]
public enum ToolResultType
{
    ToolResult,
}

sealed class ToolResultTypeConverter : JsonConverter<ToolResultType>
{
    public override ToolResultType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tool_result" => ToolResultType.ToolResult,
            _ => (ToolResultType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToolResultType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ToolResultType.ToolResult => "tool_result",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<UserInput, UserInputFromRaw>))]
public sealed record class UserInput : JsonModel
{
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public ApiEnum<string, UserInputType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UserInputType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.Type?.Validate();
    }

    public UserInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserInput(UserInput userInput)
        : base(userInput) { }
#pragma warning restore CS8618

    public UserInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserInputFromRaw.FromRawUnchecked"/>
    public static UserInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UserInput(string content)
        : this()
    {
        this.Content = content;
    }
}

class UserInputFromRaw : IFromRawJson<UserInput>
{
    /// <inheritdoc/>
    public UserInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UserInput.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UserInputTypeConverter))]
public enum UserInputType
{
    UserInput,
}

sealed class UserInputTypeConverter : JsonConverter<UserInputType>
{
    public override UserInputType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user_input" => UserInputType.UserInput,
            _ => (UserInputType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserInputType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UserInputType.UserInput => "user_input",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Token usage and status from the most recent run. Null if the session has not been
/// run yet.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ChatRetrieveResponseJobMetadata,
        ChatRetrieveResponseJobMetadataFromRaw
    >)
)]
public sealed record class ChatRetrieveResponseJobMetadata : JsonModel
{
    public double? DurationMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("duration_ms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("duration_ms", value);
        }
    }

    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    public IReadOnlyList<string>? ExportConfigIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("export_config_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "export_config_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? IsError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_error", value);
        }
    }

    public long? TotalInputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_input_tokens");
        }
        init { this._rawData.Set("total_input_tokens", value); }
    }

    public long? TotalOutputTokens
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_output_tokens");
        }
        init { this._rawData.Set("total_output_tokens", value); }
    }

    public long? Turns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("turns");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("turns", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DurationMs;
        _ = this.Error;
        _ = this.ExportConfigIds;
        _ = this.IsError;
        _ = this.TotalInputTokens;
        _ = this.TotalOutputTokens;
        _ = this.Turns;
    }

    public ChatRetrieveResponseJobMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChatRetrieveResponseJobMetadata(
        ChatRetrieveResponseJobMetadata chatRetrieveResponseJobMetadata
    )
        : base(chatRetrieveResponseJobMetadata) { }
#pragma warning restore CS8618

    public ChatRetrieveResponseJobMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChatRetrieveResponseJobMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChatRetrieveResponseJobMetadataFromRaw.FromRawUnchecked"/>
    public static ChatRetrieveResponseJobMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChatRetrieveResponseJobMetadataFromRaw : IFromRawJson<ChatRetrieveResponseJobMetadata>
{
    /// <inheritdoc/>
    public ChatRetrieveResponseJobMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChatRetrieveResponseJobMetadata.FromRawUnchecked(rawData);
}
