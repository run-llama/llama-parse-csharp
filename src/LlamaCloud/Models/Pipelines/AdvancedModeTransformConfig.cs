using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Pipelines;

[JsonConverter(
    typeof(JsonModelConverter<AdvancedModeTransformConfig, AdvancedModeTransformConfigFromRaw>)
)]
public sealed record class AdvancedModeTransformConfig : JsonModel
{
    /// <summary>
    /// Configuration for the chunking.
    /// </summary>
    public ChunkingConfig? ChunkingConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ChunkingConfig>("chunking_config");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chunking_config", value);
        }
    }

    public ApiEnum<string, AdvancedModeTransformConfigMode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AdvancedModeTransformConfigMode>>(
                "mode"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <summary>
    /// Configuration for the segmentation.
    /// </summary>
    public SegmentationConfig? SegmentationConfig
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SegmentationConfig>("segmentation_config");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("segmentation_config", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ChunkingConfig?.Validate();
        this.Mode?.Validate();
        this.SegmentationConfig?.Validate();
    }

    public AdvancedModeTransformConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AdvancedModeTransformConfig(AdvancedModeTransformConfig advancedModeTransformConfig)
        : base(advancedModeTransformConfig) { }
#pragma warning restore CS8618

    public AdvancedModeTransformConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AdvancedModeTransformConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AdvancedModeTransformConfigFromRaw.FromRawUnchecked"/>
    public static AdvancedModeTransformConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AdvancedModeTransformConfigFromRaw : IFromRawJson<AdvancedModeTransformConfig>
{
    /// <inheritdoc/>
    public AdvancedModeTransformConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AdvancedModeTransformConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for the chunking.
/// </summary>
[JsonConverter(typeof(ChunkingConfigConverter))]
public record class ChunkingConfig : ModelBase
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

    public long? ChunkOverlap
    {
        get
        {
            return Match<long?>(
                none: (_) => null,
                character: (x) => x.ChunkOverlap,
                token: (x) => x.ChunkOverlap,
                sentence: (x) => x.ChunkOverlap,
                semantic: (_) => null
            );
        }
    }

    public long? ChunkSize
    {
        get
        {
            return Match<long?>(
                none: (_) => null,
                character: (x) => x.ChunkSize,
                token: (x) => x.ChunkSize,
                sentence: (x) => x.ChunkSize,
                semantic: (_) => null
            );
        }
    }

    public string? Separator
    {
        get
        {
            return Match<string?>(
                none: (_) => null,
                character: (_) => null,
                token: (x) => x.Separator,
                sentence: (x) => x.Separator,
                semantic: (_) => null
            );
        }
    }

    public ChunkingConfig(NoneChunkingConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChunkingConfig(CharacterChunkingConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChunkingConfig(TokenChunkingConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChunkingConfig(SentenceChunkingConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChunkingConfig(SemanticChunkingConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ChunkingConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NoneChunkingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNone(out var value)) {
    ///     // `value` is of type `NoneChunkingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNone([NotNullWhen(true)] out NoneChunkingConfig? value)
    {
        value = this.Value as NoneChunkingConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CharacterChunkingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCharacter(out var value)) {
    ///     // `value` is of type `CharacterChunkingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCharacter([NotNullWhen(true)] out CharacterChunkingConfig? value)
    {
        value = this.Value as CharacterChunkingConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TokenChunkingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickToken(out var value)) {
    ///     // `value` is of type `TokenChunkingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickToken([NotNullWhen(true)] out TokenChunkingConfig? value)
    {
        value = this.Value as TokenChunkingConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SentenceChunkingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSentence(out var value)) {
    ///     // `value` is of type `SentenceChunkingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSentence([NotNullWhen(true)] out SentenceChunkingConfig? value)
    {
        value = this.Value as SentenceChunkingConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SemanticChunkingConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSemantic(out var value)) {
    ///     // `value` is of type `SemanticChunkingConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSemantic([NotNullWhen(true)] out SemanticChunkingConfig? value)
    {
        value = this.Value as SemanticChunkingConfig;
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
    ///     (NoneChunkingConfig value) =&gt; {...},
    ///     (CharacterChunkingConfig value) =&gt; {...},
    ///     (TokenChunkingConfig value) =&gt; {...},
    ///     (SentenceChunkingConfig value) =&gt; {...},
    ///     (SemanticChunkingConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<NoneChunkingConfig> none,
        System::Action<CharacterChunkingConfig> character,
        System::Action<TokenChunkingConfig> token,
        System::Action<SentenceChunkingConfig> sentence,
        System::Action<SemanticChunkingConfig> semantic
    )
    {
        switch (this.Value)
        {
            case NoneChunkingConfig value:
                none(value);
                break;
            case CharacterChunkingConfig value:
                character(value);
                break;
            case TokenChunkingConfig value:
                token(value);
                break;
            case SentenceChunkingConfig value:
                sentence(value);
                break;
            case SemanticChunkingConfig value:
                semantic(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of ChunkingConfig"
                );
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
    ///     (NoneChunkingConfig value) =&gt; {...},
    ///     (CharacterChunkingConfig value) =&gt; {...},
    ///     (TokenChunkingConfig value) =&gt; {...},
    ///     (SentenceChunkingConfig value) =&gt; {...},
    ///     (SemanticChunkingConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<NoneChunkingConfig, T> none,
        System::Func<CharacterChunkingConfig, T> character,
        System::Func<TokenChunkingConfig, T> token,
        System::Func<SentenceChunkingConfig, T> sentence,
        System::Func<SemanticChunkingConfig, T> semantic
    )
    {
        return this.Value switch
        {
            NoneChunkingConfig value => none(value),
            CharacterChunkingConfig value => character(value),
            TokenChunkingConfig value => token(value),
            SentenceChunkingConfig value => sentence(value),
            SemanticChunkingConfig value => semantic(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of ChunkingConfig"
            ),
        };
    }

    public static implicit operator ChunkingConfig(NoneChunkingConfig value) => new(value);

    public static implicit operator ChunkingConfig(CharacterChunkingConfig value) => new(value);

    public static implicit operator ChunkingConfig(TokenChunkingConfig value) => new(value);

    public static implicit operator ChunkingConfig(SentenceChunkingConfig value) => new(value);

    public static implicit operator ChunkingConfig(SemanticChunkingConfig value) => new(value);

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
            throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of ChunkingConfig"
            );
        }
        this.Switch(
            (none) => none.Validate(),
            (character) => character.Validate(),
            (token) => token.Validate(),
            (sentence) => sentence.Validate(),
            (semantic) => semantic.Validate()
        );
    }

    public virtual bool Equals(ChunkingConfig? other) =>
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
            NoneChunkingConfig _ => 0,
            CharacterChunkingConfig _ => 1,
            TokenChunkingConfig _ => 2,
            SentenceChunkingConfig _ => 3,
            SemanticChunkingConfig _ => 4,
            _ => -1,
        };
    }
}

sealed class ChunkingConfigConverter : JsonConverter<ChunkingConfig>
{
    public override ChunkingConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<NoneChunkingConfig>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CharacterChunkingConfig>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<TokenChunkingConfig>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SentenceChunkingConfig>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<SemanticChunkingConfig>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChunkingConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<NoneChunkingConfig, NoneChunkingConfigFromRaw>))]
public sealed record class NoneChunkingConfig : JsonModel
{
    public ApiEnum<string, Mode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Mode>>("mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Mode?.Validate();
    }

    public NoneChunkingConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NoneChunkingConfig(NoneChunkingConfig noneChunkingConfig)
        : base(noneChunkingConfig) { }
#pragma warning restore CS8618

    public NoneChunkingConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NoneChunkingConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NoneChunkingConfigFromRaw.FromRawUnchecked"/>
    public static NoneChunkingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NoneChunkingConfigFromRaw : IFromRawJson<NoneChunkingConfig>
{
    /// <inheritdoc/>
    public NoneChunkingConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NoneChunkingConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModeConverter))]
public enum Mode
{
    None,
}

sealed class ModeConverter : JsonConverter<Mode>
{
    public override Mode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => Mode.None,
            _ => (Mode)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Mode value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Mode.None => "none",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<CharacterChunkingConfig, CharacterChunkingConfigFromRaw>))]
public sealed record class CharacterChunkingConfig : JsonModel
{
    public long? ChunkOverlap
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chunk_overlap");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chunk_overlap", value);
        }
    }

    public long? ChunkSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chunk_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chunk_size", value);
        }
    }

    public ApiEnum<string, CharacterChunkingConfigMode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CharacterChunkingConfigMode>>(
                "mode"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChunkOverlap;
        _ = this.ChunkSize;
        this.Mode?.Validate();
    }

    public CharacterChunkingConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CharacterChunkingConfig(CharacterChunkingConfig characterChunkingConfig)
        : base(characterChunkingConfig) { }
#pragma warning restore CS8618

    public CharacterChunkingConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CharacterChunkingConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CharacterChunkingConfigFromRaw.FromRawUnchecked"/>
    public static CharacterChunkingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CharacterChunkingConfigFromRaw : IFromRawJson<CharacterChunkingConfig>
{
    /// <inheritdoc/>
    public CharacterChunkingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CharacterChunkingConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CharacterChunkingConfigModeConverter))]
public enum CharacterChunkingConfigMode
{
    Character,
}

sealed class CharacterChunkingConfigModeConverter : JsonConverter<CharacterChunkingConfigMode>
{
    public override CharacterChunkingConfigMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "character" => CharacterChunkingConfigMode.Character,
            _ => (CharacterChunkingConfigMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CharacterChunkingConfigMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CharacterChunkingConfigMode.Character => "character",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<TokenChunkingConfig, TokenChunkingConfigFromRaw>))]
public sealed record class TokenChunkingConfig : JsonModel
{
    public long? ChunkOverlap
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chunk_overlap");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chunk_overlap", value);
        }
    }

    public long? ChunkSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chunk_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chunk_size", value);
        }
    }

    public ApiEnum<string, TokenChunkingConfigMode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TokenChunkingConfigMode>>("mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    public string? Separator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("separator");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("separator", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChunkOverlap;
        _ = this.ChunkSize;
        this.Mode?.Validate();
        _ = this.Separator;
    }

    public TokenChunkingConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TokenChunkingConfig(TokenChunkingConfig tokenChunkingConfig)
        : base(tokenChunkingConfig) { }
#pragma warning restore CS8618

    public TokenChunkingConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TokenChunkingConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TokenChunkingConfigFromRaw.FromRawUnchecked"/>
    public static TokenChunkingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TokenChunkingConfigFromRaw : IFromRawJson<TokenChunkingConfig>
{
    /// <inheritdoc/>
    public TokenChunkingConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TokenChunkingConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TokenChunkingConfigModeConverter))]
public enum TokenChunkingConfigMode
{
    Token,
}

sealed class TokenChunkingConfigModeConverter : JsonConverter<TokenChunkingConfigMode>
{
    public override TokenChunkingConfigMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "token" => TokenChunkingConfigMode.Token,
            _ => (TokenChunkingConfigMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TokenChunkingConfigMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TokenChunkingConfigMode.Token => "token",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<SentenceChunkingConfig, SentenceChunkingConfigFromRaw>))]
public sealed record class SentenceChunkingConfig : JsonModel
{
    public long? ChunkOverlap
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chunk_overlap");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chunk_overlap", value);
        }
    }

    public long? ChunkSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chunk_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chunk_size", value);
        }
    }

    public ApiEnum<string, SentenceChunkingConfigMode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SentenceChunkingConfigMode>>(
                "mode"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    public string? ParagraphSeparator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("paragraph_separator");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("paragraph_separator", value);
        }
    }

    public string? Separator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("separator");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("separator", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChunkOverlap;
        _ = this.ChunkSize;
        this.Mode?.Validate();
        _ = this.ParagraphSeparator;
        _ = this.Separator;
    }

    public SentenceChunkingConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SentenceChunkingConfig(SentenceChunkingConfig sentenceChunkingConfig)
        : base(sentenceChunkingConfig) { }
#pragma warning restore CS8618

    public SentenceChunkingConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SentenceChunkingConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SentenceChunkingConfigFromRaw.FromRawUnchecked"/>
    public static SentenceChunkingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SentenceChunkingConfigFromRaw : IFromRawJson<SentenceChunkingConfig>
{
    /// <inheritdoc/>
    public SentenceChunkingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SentenceChunkingConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SentenceChunkingConfigModeConverter))]
public enum SentenceChunkingConfigMode
{
    Sentence,
}

sealed class SentenceChunkingConfigModeConverter : JsonConverter<SentenceChunkingConfigMode>
{
    public override SentenceChunkingConfigMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sentence" => SentenceChunkingConfigMode.Sentence,
            _ => (SentenceChunkingConfigMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SentenceChunkingConfigMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SentenceChunkingConfigMode.Sentence => "sentence",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<SemanticChunkingConfig, SemanticChunkingConfigFromRaw>))]
public sealed record class SemanticChunkingConfig : JsonModel
{
    public long? BreakpointPercentileThreshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("breakpoint_percentile_threshold");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("breakpoint_percentile_threshold", value);
        }
    }

    public long? BufferSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("buffer_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("buffer_size", value);
        }
    }

    public ApiEnum<string, SemanticChunkingConfigMode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SemanticChunkingConfigMode>>(
                "mode"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BreakpointPercentileThreshold;
        _ = this.BufferSize;
        this.Mode?.Validate();
    }

    public SemanticChunkingConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SemanticChunkingConfig(SemanticChunkingConfig semanticChunkingConfig)
        : base(semanticChunkingConfig) { }
#pragma warning restore CS8618

    public SemanticChunkingConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SemanticChunkingConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SemanticChunkingConfigFromRaw.FromRawUnchecked"/>
    public static SemanticChunkingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SemanticChunkingConfigFromRaw : IFromRawJson<SemanticChunkingConfig>
{
    /// <inheritdoc/>
    public SemanticChunkingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SemanticChunkingConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SemanticChunkingConfigModeConverter))]
public enum SemanticChunkingConfigMode
{
    Semantic,
}

sealed class SemanticChunkingConfigModeConverter : JsonConverter<SemanticChunkingConfigMode>
{
    public override SemanticChunkingConfigMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "semantic" => SemanticChunkingConfigMode.Semantic,
            _ => (SemanticChunkingConfigMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SemanticChunkingConfigMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SemanticChunkingConfigMode.Semantic => "semantic",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AdvancedModeTransformConfigModeConverter))]
public enum AdvancedModeTransformConfigMode
{
    Advanced,
}

sealed class AdvancedModeTransformConfigModeConverter
    : JsonConverter<AdvancedModeTransformConfigMode>
{
    public override AdvancedModeTransformConfigMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "advanced" => AdvancedModeTransformConfigMode.Advanced,
            _ => (AdvancedModeTransformConfigMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdvancedModeTransformConfigMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AdvancedModeTransformConfigMode.Advanced => "advanced",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for the segmentation.
/// </summary>
[JsonConverter(typeof(SegmentationConfigConverter))]
public record class SegmentationConfig : ModelBase
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

    public SegmentationConfig(NoneSegmentationConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SegmentationConfig(PageSegmentationConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SegmentationConfig(ElementSegmentationConfig value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SegmentationConfig(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="NoneSegmentationConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNone(out var value)) {
    ///     // `value` is of type `NoneSegmentationConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNone([NotNullWhen(true)] out NoneSegmentationConfig? value)
    {
        value = this.Value as NoneSegmentationConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="PageSegmentationConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickPage(out var value)) {
    ///     // `value` is of type `PageSegmentationConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickPage([NotNullWhen(true)] out PageSegmentationConfig? value)
    {
        value = this.Value as PageSegmentationConfig;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ElementSegmentationConfig"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickElement(out var value)) {
    ///     // `value` is of type `ElementSegmentationConfig`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickElement([NotNullWhen(true)] out ElementSegmentationConfig? value)
    {
        value = this.Value as ElementSegmentationConfig;
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
    ///     (NoneSegmentationConfig value) =&gt; {...},
    ///     (PageSegmentationConfig value) =&gt; {...},
    ///     (ElementSegmentationConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<NoneSegmentationConfig> none,
        System::Action<PageSegmentationConfig> page,
        System::Action<ElementSegmentationConfig> element
    )
    {
        switch (this.Value)
        {
            case NoneSegmentationConfig value:
                none(value);
                break;
            case PageSegmentationConfig value:
                page(value);
                break;
            case ElementSegmentationConfig value:
                element(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of SegmentationConfig"
                );
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
    ///     (NoneSegmentationConfig value) =&gt; {...},
    ///     (PageSegmentationConfig value) =&gt; {...},
    ///     (ElementSegmentationConfig value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<NoneSegmentationConfig, T> none,
        System::Func<PageSegmentationConfig, T> page,
        System::Func<ElementSegmentationConfig, T> element
    )
    {
        return this.Value switch
        {
            NoneSegmentationConfig value => none(value),
            PageSegmentationConfig value => page(value),
            ElementSegmentationConfig value => element(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of SegmentationConfig"
            ),
        };
    }

    public static implicit operator SegmentationConfig(NoneSegmentationConfig value) => new(value);

    public static implicit operator SegmentationConfig(PageSegmentationConfig value) => new(value);

    public static implicit operator SegmentationConfig(ElementSegmentationConfig value) =>
        new(value);

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
            throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of SegmentationConfig"
            );
        }
        this.Switch(
            (none) => none.Validate(),
            (page) => page.Validate(),
            (element) => element.Validate()
        );
    }

    public virtual bool Equals(SegmentationConfig? other) =>
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
            NoneSegmentationConfig _ => 0,
            PageSegmentationConfig _ => 1,
            ElementSegmentationConfig _ => 2,
            _ => -1,
        };
    }
}

sealed class SegmentationConfigConverter : JsonConverter<SegmentationConfig>
{
    public override SegmentationConfig? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<NoneSegmentationConfig>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<PageSegmentationConfig>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ElementSegmentationConfig>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        SegmentationConfig value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<NoneSegmentationConfig, NoneSegmentationConfigFromRaw>))]
public sealed record class NoneSegmentationConfig : JsonModel
{
    public ApiEnum<string, NoneSegmentationConfigMode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, NoneSegmentationConfigMode>>(
                "mode"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Mode?.Validate();
    }

    public NoneSegmentationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public NoneSegmentationConfig(NoneSegmentationConfig noneSegmentationConfig)
        : base(noneSegmentationConfig) { }
#pragma warning restore CS8618

    public NoneSegmentationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NoneSegmentationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NoneSegmentationConfigFromRaw.FromRawUnchecked"/>
    public static NoneSegmentationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class NoneSegmentationConfigFromRaw : IFromRawJson<NoneSegmentationConfig>
{
    /// <inheritdoc/>
    public NoneSegmentationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => NoneSegmentationConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NoneSegmentationConfigModeConverter))]
public enum NoneSegmentationConfigMode
{
    None,
}

sealed class NoneSegmentationConfigModeConverter : JsonConverter<NoneSegmentationConfigMode>
{
    public override NoneSegmentationConfigMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => NoneSegmentationConfigMode.None,
            _ => (NoneSegmentationConfigMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NoneSegmentationConfigMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NoneSegmentationConfigMode.None => "none",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<PageSegmentationConfig, PageSegmentationConfigFromRaw>))]
public sealed record class PageSegmentationConfig : JsonModel
{
    public ApiEnum<string, PageSegmentationConfigMode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PageSegmentationConfigMode>>(
                "mode"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    public string? PageSeparator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("page_separator");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("page_separator", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Mode?.Validate();
        _ = this.PageSeparator;
    }

    public PageSegmentationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PageSegmentationConfig(PageSegmentationConfig pageSegmentationConfig)
        : base(pageSegmentationConfig) { }
#pragma warning restore CS8618

    public PageSegmentationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PageSegmentationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PageSegmentationConfigFromRaw.FromRawUnchecked"/>
    public static PageSegmentationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PageSegmentationConfigFromRaw : IFromRawJson<PageSegmentationConfig>
{
    /// <inheritdoc/>
    public PageSegmentationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PageSegmentationConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PageSegmentationConfigModeConverter))]
public enum PageSegmentationConfigMode
{
    Page,
}

sealed class PageSegmentationConfigModeConverter : JsonConverter<PageSegmentationConfigMode>
{
    public override PageSegmentationConfigMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "page" => PageSegmentationConfigMode.Page,
            _ => (PageSegmentationConfigMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PageSegmentationConfigMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PageSegmentationConfigMode.Page => "page",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<ElementSegmentationConfig, ElementSegmentationConfigFromRaw>)
)]
public sealed record class ElementSegmentationConfig : JsonModel
{
    public ApiEnum<string, ElementSegmentationConfigMode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ElementSegmentationConfigMode>>(
                "mode"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Mode?.Validate();
    }

    public ElementSegmentationConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ElementSegmentationConfig(ElementSegmentationConfig elementSegmentationConfig)
        : base(elementSegmentationConfig) { }
#pragma warning restore CS8618

    public ElementSegmentationConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ElementSegmentationConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ElementSegmentationConfigFromRaw.FromRawUnchecked"/>
    public static ElementSegmentationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ElementSegmentationConfigFromRaw : IFromRawJson<ElementSegmentationConfig>
{
    /// <inheritdoc/>
    public ElementSegmentationConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ElementSegmentationConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ElementSegmentationConfigModeConverter))]
public enum ElementSegmentationConfigMode
{
    Element,
}

sealed class ElementSegmentationConfigModeConverter : JsonConverter<ElementSegmentationConfigMode>
{
    public override ElementSegmentationConfigMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "element" => ElementSegmentationConfigMode.Element,
            _ => (ElementSegmentationConfigMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ElementSegmentationConfigMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ElementSegmentationConfigMode.Element => "element",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
