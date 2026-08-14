using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models.DataSinks;

/// <summary>
/// Schema for a data sink.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataSink, DataSinkFromRaw>))]
public sealed record class DataSink : JsonModel
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Component that implements the data sink
    /// </summary>
    public required DataSinkComponent Component
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DataSinkComponent>("component");
        }
        init { this._rawData.Set("component", value); }
    }

    /// <summary>
    /// The name of the data sink.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("project_id");
        }
        init { this._rawData.Set("project_id", value); }
    }

    public required ApiEnum<string, DataSinkSinkType> SinkType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, DataSinkSinkType>>("sink_type");
        }
        init { this._rawData.Set("sink_type", value); }
    }

    /// <summary>
    /// Creation datetime
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Update datetime
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Component.Validate();
        _ = this.Name;
        _ = this.ProjectID;
        this.SinkType.Validate();
        _ = this.CreatedAt;
        _ = this.UpdatedAt;
    }

    public DataSink() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataSink(DataSink dataSink)
        : base(dataSink) { }
#pragma warning restore CS8618

    public DataSink(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataSink(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataSinkFromRaw.FromRawUnchecked"/>
    public static DataSink FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataSinkFromRaw : IFromRawJson<DataSink>
{
    /// <inheritdoc/>
    public DataSink FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DataSink.FromRawUnchecked(rawData);
}

/// <summary>
/// Component that implements the data sink
/// </summary>
[JsonConverter(typeof(DataSinkComponentConverter))]
public record class DataSinkComponent : ModelBase
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

    public string? ApiKey
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudPineconeVectorStore: (x) => x.ApiKey,
                cloudPostgresVectorStore: (_) => null,
                cloudQdrantVectorStore: (x) => x.ApiKey,
                cloudAzureAISearchVectorStore: (_) => null,
                cloudMongoDBAtlasVectorSearch: (_) => null,
                cloudMilvusVectorStore: (_) => null,
                cloudAstraDBVectorStore: (_) => null
            );
        }
    }

    public string? IndexName
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudPineconeVectorStore: (x) => x.IndexName,
                cloudPostgresVectorStore: (_) => null,
                cloudQdrantVectorStore: (_) => null,
                cloudAzureAISearchVectorStore: (x) => x.IndexName,
                cloudMongoDBAtlasVectorSearch: (_) => null,
                cloudMilvusVectorStore: (_) => null,
                cloudAstraDBVectorStore: (_) => null
            );
        }
    }

    public string? ClassName
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudPineconeVectorStore: (x) => x.ClassName,
                cloudPostgresVectorStore: (x) => x.ClassName,
                cloudQdrantVectorStore: (x) => x.ClassName,
                cloudAzureAISearchVectorStore: (x) => x.ClassName,
                cloudMongoDBAtlasVectorSearch: (x) => x.ClassName,
                cloudMilvusVectorStore: (x) => x.ClassName,
                cloudAstraDBVectorStore: (x) => x.ClassName
            );
        }
    }

    public string? CollectionName
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudPineconeVectorStore: (_) => null,
                cloudPostgresVectorStore: (_) => null,
                cloudQdrantVectorStore: (x) => x.CollectionName,
                cloudAzureAISearchVectorStore: (_) => null,
                cloudMongoDBAtlasVectorSearch: (x) => x.CollectionName,
                cloudMilvusVectorStore: (x) => x.CollectionName,
                cloudAstraDBVectorStore: (x) => x.CollectionName
            );
        }
    }

    public long? EmbeddingDimension
    {
        get
        {
            return Match<long?>(
                jsonElements: (_) => null,
                cloudPineconeVectorStore: (_) => null,
                cloudPostgresVectorStore: (_) => null,
                cloudQdrantVectorStore: (_) => null,
                cloudAzureAISearchVectorStore: (x) => x.EmbeddingDimension,
                cloudMongoDBAtlasVectorSearch: (x) => x.EmbeddingDimension,
                cloudMilvusVectorStore: (x) => x.EmbeddingDimension,
                cloudAstraDBVectorStore: (x) => x.EmbeddingDimension
            );
        }
    }

    public string? Token
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudPineconeVectorStore: (_) => null,
                cloudPostgresVectorStore: (_) => null,
                cloudQdrantVectorStore: (_) => null,
                cloudAzureAISearchVectorStore: (_) => null,
                cloudMongoDBAtlasVectorSearch: (_) => null,
                cloudMilvusVectorStore: (x) => x.Token,
                cloudAstraDBVectorStore: (x) => x.Token
            );
        }
    }

    public DataSinkComponent(
        IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public DataSinkComponent(CloudPineconeVectorStore value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DataSinkComponent(CloudPostgresVectorStore value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DataSinkComponent(CloudQdrantVectorStore value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DataSinkComponent(CloudAzureAISearchVectorStore value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DataSinkComponent(CloudMongoDBAtlasVectorSearch value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DataSinkComponent(CloudMilvusVectorStore value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DataSinkComponent(CloudAstraDBVectorStore value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DataSinkComponent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>JsonElement</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements(out var value)) {
    ///     // `value` is of type `IReadOnlyDictionary&lt;string, JsonElement&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value = this.Value as IReadOnlyDictionary<string, JsonElement>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudPineconeVectorStore"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudPineconeVectorStore(out var value)) {
    ///     // `value` is of type `CloudPineconeVectorStore`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudPineconeVectorStore(
        [NotNullWhen(true)] out CloudPineconeVectorStore? value
    )
    {
        value = this.Value as CloudPineconeVectorStore;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudPostgresVectorStore"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudPostgresVectorStore(out var value)) {
    ///     // `value` is of type `CloudPostgresVectorStore`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudPostgresVectorStore(
        [NotNullWhen(true)] out CloudPostgresVectorStore? value
    )
    {
        value = this.Value as CloudPostgresVectorStore;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudQdrantVectorStore"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudQdrantVectorStore(out var value)) {
    ///     // `value` is of type `CloudQdrantVectorStore`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudQdrantVectorStore([NotNullWhen(true)] out CloudQdrantVectorStore? value)
    {
        value = this.Value as CloudQdrantVectorStore;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudAzureAISearchVectorStore"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudAzureAISearchVectorStore(out var value)) {
    ///     // `value` is of type `CloudAzureAISearchVectorStore`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudAzureAISearchVectorStore(
        [NotNullWhen(true)] out CloudAzureAISearchVectorStore? value
    )
    {
        value = this.Value as CloudAzureAISearchVectorStore;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudMongoDBAtlasVectorSearch"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudMongoDBAtlasVectorSearch(out var value)) {
    ///     // `value` is of type `CloudMongoDBAtlasVectorSearch`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudMongoDBAtlasVectorSearch(
        [NotNullWhen(true)] out CloudMongoDBAtlasVectorSearch? value
    )
    {
        value = this.Value as CloudMongoDBAtlasVectorSearch;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudMilvusVectorStore"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudMilvusVectorStore(out var value)) {
    ///     // `value` is of type `CloudMilvusVectorStore`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudMilvusVectorStore([NotNullWhen(true)] out CloudMilvusVectorStore? value)
    {
        value = this.Value as CloudMilvusVectorStore;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudAstraDBVectorStore"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudAstraDBVectorStore(out var value)) {
    ///     // `value` is of type `CloudAstraDBVectorStore`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudAstraDBVectorStore(
        [NotNullWhen(true)] out CloudAstraDBVectorStore? value
    )
    {
        value = this.Value as CloudAstraDBVectorStore;
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
    ///     (IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
    ///     (CloudPineconeVectorStore value) =&gt; {...},
    ///     (CloudPostgresVectorStore value) =&gt; {...},
    ///     (CloudQdrantVectorStore value) =&gt; {...},
    ///     (CloudAzureAISearchVectorStore value) =&gt; {...},
    ///     (CloudMongoDBAtlasVectorSearch value) =&gt; {...},
    ///     (CloudMilvusVectorStore value) =&gt; {...},
    ///     (CloudAstraDBVectorStore value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<IReadOnlyDictionary<string, JsonElement>> jsonElements,
        Action<CloudPineconeVectorStore> cloudPineconeVectorStore,
        Action<CloudPostgresVectorStore> cloudPostgresVectorStore,
        Action<CloudQdrantVectorStore> cloudQdrantVectorStore,
        Action<CloudAzureAISearchVectorStore> cloudAzureAISearchVectorStore,
        Action<CloudMongoDBAtlasVectorSearch> cloudMongoDBAtlasVectorSearch,
        Action<CloudMilvusVectorStore> cloudMilvusVectorStore,
        Action<CloudAstraDBVectorStore> cloudAstraDBVectorStore
    )
    {
        switch (this.Value)
        {
            case IReadOnlyDictionary<string, JsonElement> value:
                jsonElements(value);
                break;
            case CloudPineconeVectorStore value:
                cloudPineconeVectorStore(value);
                break;
            case CloudPostgresVectorStore value:
                cloudPostgresVectorStore(value);
                break;
            case CloudQdrantVectorStore value:
                cloudQdrantVectorStore(value);
                break;
            case CloudAzureAISearchVectorStore value:
                cloudAzureAISearchVectorStore(value);
                break;
            case CloudMongoDBAtlasVectorSearch value:
                cloudMongoDBAtlasVectorSearch(value);
                break;
            case CloudMilvusVectorStore value:
                cloudMilvusVectorStore(value);
                break;
            case CloudAstraDBVectorStore value:
                cloudAstraDBVectorStore(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of DataSinkComponent"
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
    ///     (IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
    ///     (CloudPineconeVectorStore value) =&gt; {...},
    ///     (CloudPostgresVectorStore value) =&gt; {...},
    ///     (CloudQdrantVectorStore value) =&gt; {...},
    ///     (CloudAzureAISearchVectorStore value) =&gt; {...},
    ///     (CloudMongoDBAtlasVectorSearch value) =&gt; {...},
    ///     (CloudMilvusVectorStore value) =&gt; {...},
    ///     (CloudAstraDBVectorStore value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<IReadOnlyDictionary<string, JsonElement>, T> jsonElements,
        Func<CloudPineconeVectorStore, T> cloudPineconeVectorStore,
        Func<CloudPostgresVectorStore, T> cloudPostgresVectorStore,
        Func<CloudQdrantVectorStore, T> cloudQdrantVectorStore,
        Func<CloudAzureAISearchVectorStore, T> cloudAzureAISearchVectorStore,
        Func<CloudMongoDBAtlasVectorSearch, T> cloudMongoDBAtlasVectorSearch,
        Func<CloudMilvusVectorStore, T> cloudMilvusVectorStore,
        Func<CloudAstraDBVectorStore, T> cloudAstraDBVectorStore
    )
    {
        return this.Value switch
        {
            IReadOnlyDictionary<string, JsonElement> value => jsonElements(value),
            CloudPineconeVectorStore value => cloudPineconeVectorStore(value),
            CloudPostgresVectorStore value => cloudPostgresVectorStore(value),
            CloudQdrantVectorStore value => cloudQdrantVectorStore(value),
            CloudAzureAISearchVectorStore value => cloudAzureAISearchVectorStore(value),
            CloudMongoDBAtlasVectorSearch value => cloudMongoDBAtlasVectorSearch(value),
            CloudMilvusVectorStore value => cloudMilvusVectorStore(value),
            CloudAstraDBVectorStore value => cloudAstraDBVectorStore(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of DataSinkComponent"
            ),
        };
    }

    public static implicit operator DataSinkComponent(Dictionary<string, JsonElement> value) =>
        new((IReadOnlyDictionary<string, JsonElement>)value);

    public static implicit operator DataSinkComponent(CloudPineconeVectorStore value) => new(value);

    public static implicit operator DataSinkComponent(CloudPostgresVectorStore value) => new(value);

    public static implicit operator DataSinkComponent(CloudQdrantVectorStore value) => new(value);

    public static implicit operator DataSinkComponent(CloudAzureAISearchVectorStore value) =>
        new(value);

    public static implicit operator DataSinkComponent(CloudMongoDBAtlasVectorSearch value) =>
        new(value);

    public static implicit operator DataSinkComponent(CloudMilvusVectorStore value) => new(value);

    public static implicit operator DataSinkComponent(CloudAstraDBVectorStore value) => new(value);

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
                "Data did not match any variant of DataSinkComponent"
            );
        }
        this.Switch(
            (_) => { },
            (cloudPineconeVectorStore) => cloudPineconeVectorStore.Validate(),
            (cloudPostgresVectorStore) => cloudPostgresVectorStore.Validate(),
            (cloudQdrantVectorStore) => cloudQdrantVectorStore.Validate(),
            (cloudAzureAISearchVectorStore) => cloudAzureAISearchVectorStore.Validate(),
            (cloudMongoDBAtlasVectorSearch) => cloudMongoDBAtlasVectorSearch.Validate(),
            (cloudMilvusVectorStore) => cloudMilvusVectorStore.Validate(),
            (cloudAstraDBVectorStore) => cloudAstraDBVectorStore.Validate()
        );
    }

    public virtual bool Equals(DataSinkComponent? other) =>
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
            IReadOnlyDictionary<string, JsonElement> _ => 0,
            CloudPineconeVectorStore _ => 1,
            CloudPostgresVectorStore _ => 2,
            CloudQdrantVectorStore _ => 3,
            CloudAzureAISearchVectorStore _ => 4,
            CloudMongoDBAtlasVectorSearch _ => 5,
            CloudMilvusVectorStore _ => 6,
            CloudAstraDBVectorStore _ => 7,
            _ => -1,
        };
    }
}

sealed class DataSinkComponentConverter : JsonConverter<DataSinkComponent>
{
    public override DataSinkComponent? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<CloudPineconeVectorStore>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CloudPostgresVectorStore>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CloudQdrantVectorStore>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CloudAzureAISearchVectorStore>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CloudMongoDBAtlasVectorSearch>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CloudMilvusVectorStore>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<CloudAstraDBVectorStore>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                element,
                options
            );
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

    public override void Write(
        Utf8JsonWriter writer,
        DataSinkComponent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(DataSinkSinkTypeConverter))]
public enum DataSinkSinkType
{
    AstraDB,
    AzureaiSearch,
    Milvus,
    MongoDBAtlas,
    Pinecone,
    Postgres,
    Qdrant,
}

sealed class DataSinkSinkTypeConverter : JsonConverter<DataSinkSinkType>
{
    public override DataSinkSinkType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ASTRA_DB" => DataSinkSinkType.AstraDB,
            "AZUREAI_SEARCH" => DataSinkSinkType.AzureaiSearch,
            "MILVUS" => DataSinkSinkType.Milvus,
            "MONGODB_ATLAS" => DataSinkSinkType.MongoDBAtlas,
            "PINECONE" => DataSinkSinkType.Pinecone,
            "POSTGRES" => DataSinkSinkType.Postgres,
            "QDRANT" => DataSinkSinkType.Qdrant,
            _ => (DataSinkSinkType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataSinkSinkType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DataSinkSinkType.AstraDB => "ASTRA_DB",
                DataSinkSinkType.AzureaiSearch => "AZUREAI_SEARCH",
                DataSinkSinkType.Milvus => "MILVUS",
                DataSinkSinkType.MongoDBAtlas => "MONGODB_ATLAS",
                DataSinkSinkType.Pinecone => "PINECONE",
                DataSinkSinkType.Postgres => "POSTGRES",
                DataSinkSinkType.Qdrant => "QDRANT",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
