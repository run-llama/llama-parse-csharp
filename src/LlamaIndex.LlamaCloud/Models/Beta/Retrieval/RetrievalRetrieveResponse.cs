using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;

namespace LlamaIndex.LlamaCloud.Models.Beta.Retrieval;

/// <summary>
/// Response containing retrieval results.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<RetrievalRetrieveResponse, RetrievalRetrieveResponseFromRaw>)
)]
public sealed record class RetrievalRetrieveResponse : JsonModel
{
    /// <summary>
    /// Ordered list of retrieved chunks.
    /// </summary>
    public required IReadOnlyList<Result> Results
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Result>>("results");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Result>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Results)
        {
            item.Validate();
        }
    }

    public RetrievalRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RetrievalRetrieveResponse(RetrievalRetrieveResponse retrievalRetrieveResponse)
        : base(retrievalRetrieveResponse) { }
#pragma warning restore CS8618

    public RetrievalRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RetrievalRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RetrievalRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static RetrievalRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RetrievalRetrieveResponse(IReadOnlyList<Result> results)
        : this()
    {
        this.Results = results;
    }
}

class RetrievalRetrieveResponseFromRaw : IFromRawJson<RetrievalRetrieveResponse>
{
    /// <inheritdoc/>
    public RetrievalRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RetrievalRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A single retrieval result.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// Text content of the retrieved chunk.
    /// </summary>
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// User-defined metadata associated with the chunk.
    /// </summary>
    public IReadOnlyDictionary<string, Metadata?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, Metadata?>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, Metadata?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Relevance score from the reranker, if reranking was applied.
    /// </summary>
    public double? RerankScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("rerank_score");
        }
        init { this._rawData.Set("rerank_score", value); }
    }

    /// <summary>
    /// Hybrid search relevance score.
    /// </summary>
    public double? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("score");
        }
        init { this._rawData.Set("score", value); }
    }

    /// <summary>
    /// Built-in fields stored for every exported chunk.
    /// </summary>
    public StaticFields? StaticFields
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StaticFields>("static_fields");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("static_fields", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        if (this.Metadata != null)
        {
            foreach (var item in this.Metadata.Values)
            {
                item?.Validate();
            }
        }
        _ = this.RerankScore;
        _ = this.Score;
        this.StaticFields?.Validate();
    }

    public Result() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result(Result result)
        : base(result) { }
#pragma warning restore CS8618

    public Result(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Result(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Result(string content)
        : this()
    {
        this.Content = content;
    }
}

class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Result.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MetadataConverter))]
public record class Metadata : ModelBase
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

    public Metadata(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Metadata(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Metadata(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Metadata(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Metadata(IReadOnlyList<string> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Metadata(JsonElement element)
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
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
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
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>string</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickListValue(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;string&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickListValue([NotNullWhen(true)] out IReadOnlyList<string>? value)
    {
        value = this.Value as IReadOnlyList<string>;
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
    ///     (long value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<string> @string,
        Action<long> @long,
        Action<double> @double,
        Action<bool> @bool,
        Action<IReadOnlyList<string>> metadataListValue
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case long value:
                @long(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            case IReadOnlyList<string> value:
                metadataListValue(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of Metadata"
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
    ///     (string value) =&gt; {...},
    ///     (long value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<string, T> @string,
        Func<long, T> @long,
        Func<double, T> @double,
        Func<bool, T> @bool,
        Func<IReadOnlyList<string>, T> metadataListValue
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            long value => @long(value),
            double value => @double(value),
            bool value => @bool(value),
            IReadOnlyList<string> value => metadataListValue(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of Metadata"
            ),
        };
    }

    public static implicit operator Metadata(string value) => new(value);

    public static implicit operator Metadata(long value) => new(value);

    public static implicit operator Metadata(double value) => new(value);

    public static implicit operator Metadata(bool value) => new(value);

    public static implicit operator Metadata(List<string> value) =>
        new((IReadOnlyList<string>)value);

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
            throw new LlamaCloudInvalidDataException("Data did not match any variant of Metadata");
        }
    }

    public virtual bool Equals(Metadata? other) =>
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
            long _ => 1,
            double _ => 2,
            bool _ => 3,
            IReadOnlyList<string> _ => 4,
            _ => -1,
        };
    }
}

sealed class MetadataConverter : JsonConverter<Metadata>
{
    public override Metadata? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Metadata value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Built-in fields stored for every exported chunk.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StaticFields, StaticFieldsFromRaw>))]
public sealed record class StaticFields : JsonModel
{
    /// <summary>
    /// Attachments associated with the chunk
    /// </summary>
    public IReadOnlyList<Attachment>? Attachments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Attachment>>("attachments");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Attachment>?>(
                "attachments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// End character offset of the chunk.
    /// </summary>
    public long? ChunkEndChar
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chunk_end_char");
        }
        init { this._rawData.Set("chunk_end_char", value); }
    }

    /// <summary>
    /// Index of the chunk within the file.
    /// </summary>
    public long? ChunkIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chunk_index");
        }
        init { this._rawData.Set("chunk_index", value); }
    }

    /// <summary>
    /// Start character offset of the chunk.
    /// </summary>
    public long? ChunkStartChar
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chunk_start_char");
        }
        init { this._rawData.Set("chunk_start_char", value); }
    }

    /// <summary>
    /// Token count of the chunk.
    /// </summary>
    public long? ChunkTokenCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chunk_token_count");
        }
        init { this._rawData.Set("chunk_token_count", value); }
    }

    /// <summary>
    /// Last page number covered by this chunk.
    /// </summary>
    public long? PageRangeEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("page_range_end");
        }
        init { this._rawData.Set("page_range_end", value); }
    }

    /// <summary>
    /// First page number covered by this chunk.
    /// </summary>
    public long? PageRangeStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("page_range_start");
        }
        init { this._rawData.Set("page_range_start", value); }
    }

    /// <summary>
    /// ID of the parsed file.
    /// </summary>
    public string? ParsedDirectoryFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parsed_directory_file_id");
        }
        init { this._rawData.Set("parsed_directory_file_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Attachments ?? [])
        {
            item.Validate();
        }
        _ = this.ChunkEndChar;
        _ = this.ChunkIndex;
        _ = this.ChunkStartChar;
        _ = this.ChunkTokenCount;
        _ = this.PageRangeEnd;
        _ = this.PageRangeStart;
        _ = this.ParsedDirectoryFileID;
    }

    public StaticFields() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StaticFields(StaticFields staticFields)
        : base(staticFields) { }
#pragma warning restore CS8618

    public StaticFields(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StaticFields(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StaticFieldsFromRaw.FromRawUnchecked"/>
    public static StaticFields FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StaticFieldsFromRaw : IFromRawJson<StaticFields>
{
    /// <inheritdoc/>
    public StaticFields FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StaticFields.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to a file attachment, retrievable via ``GET /api/v1/beta/attachments/{attachment_name}?source_id=...``.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Attachment, AttachmentFromRaw>))]
public sealed record class Attachment : JsonModel
{
    /// <summary>
    /// Attachment-relative path, e.g. 'screenshots/page_7.jpg'.
    /// </summary>
    public required string AttachmentName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("attachment_name");
        }
        init { this._rawData.Set("attachment_name", value); }
    }

    /// <summary>
    /// File ID to pass as source_id when fetching the attachment.
    /// </summary>
    public required string SourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source_id");
        }
        init { this._rawData.Set("source_id", value); }
    }

    /// <summary>
    /// Attachment kind, e.g. 'screenshot', 'items'.
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AttachmentName;
        _ = this.SourceID;
        _ = this.Type;
    }

    public Attachment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Attachment(Attachment attachment)
        : base(attachment) { }
#pragma warning restore CS8618

    public Attachment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Attachment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttachmentFromRaw.FromRawUnchecked"/>
    public static Attachment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AttachmentFromRaw : IFromRawJson<Attachment>
{
    /// <inheritdoc/>
    public Attachment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Attachment.FromRawUnchecked(rawData);
}
