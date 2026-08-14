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
    typeof(JsonModelConverter<
        HuggingFaceInferenceApiEmbedding,
        HuggingFaceInferenceApiEmbeddingFromRaw
    >)
)]
public sealed record class HuggingFaceInferenceApiEmbedding : JsonModel
{
    /// <summary>
    /// Hugging Face token. Will default to the locally saved token. Pass token=False
    /// if you don’t want to send your token to the server.
    /// </summary>
    public Token? Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Token>("token");
        }
        init { this._rawData.Set("token", value); }
    }

    public string? ClassName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("class_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("class_name", value);
        }
    }

    /// <summary>
    /// Additional cookies to send to the server.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Cookies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("cookies");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "cookies",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The batch size for embedding calls.
    /// </summary>
    public long? EmbedBatchSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("embed_batch_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("embed_batch_size", value);
        }
    }

    /// <summary>
    /// Additional headers to send to the server. By default only the authorization
    /// and user-agent headers are sent. Values in this dictionary will override the
    /// default values.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Headers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("headers");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Hugging Face model name. If None, the task will be used.
    /// </summary>
    public string? ModelName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model_name");
        }
        init { this._rawData.Set("model_name", value); }
    }

    /// <summary>
    /// The number of workers to use for async embedding calls.
    /// </summary>
    public long? NumWorkers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("num_workers");
        }
        init { this._rawData.Set("num_workers", value); }
    }

    /// <summary>
    /// Enum of possible pooling choices with pooling behaviors.
    /// </summary>
    public ApiEnum<string, Pooling>? Pooling
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Pooling>>("pooling");
        }
        init { this._rawData.Set("pooling", value); }
    }

    /// <summary>
    /// Instruction to prepend during query embedding.
    /// </summary>
    public string? QueryInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("query_instruction");
        }
        init { this._rawData.Set("query_instruction", value); }
    }

    /// <summary>
    /// Optional task to pick Hugging Face's recommended model, used when model_name
    /// is left as default of None.
    /// </summary>
    public string? Task
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("task");
        }
        init { this._rawData.Set("task", value); }
    }

    /// <summary>
    /// Instruction to prepend during text embedding.
    /// </summary>
    public string? TextInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_instruction");
        }
        init { this._rawData.Set("text_instruction", value); }
    }

    /// <summary>
    /// The maximum number of seconds to wait for a response from the server. Loading
    /// a new model in Inference API can take up to several minutes. Defaults to
    /// None, meaning it will loop until the server is available.
    /// </summary>
    public double? Timeout
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("timeout");
        }
        init { this._rawData.Set("timeout", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Token?.Validate();
        _ = this.ClassName;
        _ = this.Cookies;
        _ = this.EmbedBatchSize;
        _ = this.Headers;
        _ = this.ModelName;
        _ = this.NumWorkers;
        this.Pooling?.Validate();
        _ = this.QueryInstruction;
        _ = this.Task;
        _ = this.TextInstruction;
        _ = this.Timeout;
    }

    public HuggingFaceInferenceApiEmbedding() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public HuggingFaceInferenceApiEmbedding(
        HuggingFaceInferenceApiEmbedding huggingFaceInferenceApiEmbedding
    )
        : base(huggingFaceInferenceApiEmbedding) { }
#pragma warning restore CS8618

    public HuggingFaceInferenceApiEmbedding(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    HuggingFaceInferenceApiEmbedding(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="HuggingFaceInferenceApiEmbeddingFromRaw.FromRawUnchecked"/>
    public static HuggingFaceInferenceApiEmbedding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class HuggingFaceInferenceApiEmbeddingFromRaw : IFromRawJson<HuggingFaceInferenceApiEmbedding>
{
    /// <inheritdoc/>
    public HuggingFaceInferenceApiEmbedding FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => HuggingFaceInferenceApiEmbedding.FromRawUnchecked(rawData);
}

/// <summary>
/// Hugging Face token. Will default to the locally saved token. Pass token=False
/// if you don’t want to send your token to the server.
/// </summary>
[JsonConverter(typeof(TokenConverter))]
public record class Token : ModelBase
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

    public Token(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Token(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Token(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
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
    ///     (string value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<string> @string, System::Action<bool> @bool)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException("Data did not match any variant of Token");
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
    ///     (string value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<string, T> @string, System::Func<bool, T> @bool)
    {
        return this.Value switch
        {
            string value => @string(value),
            bool value => @bool(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of Token"
            ),
        };
    }

    public static implicit operator Token(string value) => new(value);

    public static implicit operator Token(bool value) => new(value);

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
            throw new LlamaCloudInvalidDataException("Data did not match any variant of Token");
        }
    }

    public virtual bool Equals(Token? other) =>
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
            string _ => 0,
            bool _ => 1,
            _ => -1,
        };
    }
}

sealed class TokenConverter : JsonConverter<Token?>
{
    public override Token? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Token? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Enum of possible pooling choices with pooling behaviors.
/// </summary>
[JsonConverter(typeof(PoolingConverter))]
public enum Pooling
{
    Cls,
    Last,
    Mean,
}

sealed class PoolingConverter : JsonConverter<Pooling>
{
    public override Pooling Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cls" => Pooling.Cls,
            "last" => Pooling.Last,
            "mean" => Pooling.Mean,
            _ => (Pooling)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Pooling value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Pooling.Cls => "cls",
                Pooling.Last => "last",
                Pooling.Mean => "mean",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
