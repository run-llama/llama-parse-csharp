using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Pipelines.Documents;

/// <summary>
/// Provided for backward compatibility.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TextNode, TextNodeFromRaw>))]
public sealed record class TextNode : JsonModel
{
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
    /// Embedding of the node.
    /// </summary>
    public IReadOnlyList<double>? Embedding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<double>>("embedding");
        }
        init
        {
            this._rawData.Set<ImmutableArray<double>?>(
                "embedding",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// End char index of the node.
    /// </summary>
    public long? EndCharIdx
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("end_char_idx");
        }
        init { this._rawData.Set("end_char_idx", value); }
    }

    /// <summary>
    /// Metadata keys that are excluded from text for the embed model.
    /// </summary>
    public IReadOnlyList<string>? ExcludedEmbedMetadataKeys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "excluded_embed_metadata_keys"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "excluded_embed_metadata_keys",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Metadata keys that are excluded from text for the LLM.
    /// </summary>
    public IReadOnlyList<string>? ExcludedLlmMetadataKeys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "excluded_llm_metadata_keys"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "excluded_llm_metadata_keys",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A flat dictionary of metadata fields
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? ExtraInfo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "extra_info"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "extra_info",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Unique ID of the node.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id_");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id_", value);
        }
    }

    /// <summary>
    /// Separator between metadata fields when converting to string.
    /// </summary>
    public string? MetadataSeperator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("metadata_seperator");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata_seperator", value);
        }
    }

    /// <summary>
    /// Template for how metadata is formatted, with {key} and {value} placeholders.
    /// </summary>
    public string? MetadataTemplate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("metadata_template");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata_template", value);
        }
    }

    /// <summary>
    /// MIME type of the node content.
    /// </summary>
    public string? Mimetype
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mimetype");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mimetype", value);
        }
    }

    /// <summary>
    /// A mapping of relationships to other node information.
    /// </summary>
    public IReadOnlyDictionary<string, Relationship>? Relationships
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, Relationship>>(
                "relationships"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, Relationship>?>(
                "relationships",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Start char index of the node.
    /// </summary>
    public long? StartCharIdx
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("start_char_idx");
        }
        init { this._rawData.Set("start_char_idx", value); }
    }

    /// <summary>
    /// Text content of the node.
    /// </summary>
    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <summary>
    /// Template for how text is formatted, with {content} and {metadata_str} placeholders.
    /// </summary>
    public string? TextTemplate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_template");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text_template", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClassName;
        _ = this.Embedding;
        _ = this.EndCharIdx;
        _ = this.ExcludedEmbedMetadataKeys;
        _ = this.ExcludedLlmMetadataKeys;
        _ = this.ExtraInfo;
        _ = this.ID;
        _ = this.MetadataSeperator;
        _ = this.MetadataTemplate;
        _ = this.Mimetype;
        if (this.Relationships != null)
        {
            foreach (var item in this.Relationships.Values)
            {
                item.Validate();
            }
        }
        _ = this.StartCharIdx;
        _ = this.Text;
        _ = this.TextTemplate;
    }

    public TextNode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextNode(TextNode textNode)
        : base(textNode) { }
#pragma warning restore CS8618

    public TextNode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextNode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextNodeFromRaw.FromRawUnchecked"/>
    public static TextNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TextNodeFromRaw : IFromRawJson<TextNode>
{
    /// <inheritdoc/>
    public TextNode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TextNode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RelationshipConverter))]
public record class Relationship : ModelBase
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

    public Relationship(RelatedNodeInfo value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Relationship(
        IReadOnlyList<RelationshipRelatedNodeInfo> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Relationship(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RelatedNodeInfo"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRelatedNodeInfo(out var value)) {
    ///     // `value` is of type `RelatedNodeInfo`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRelatedNodeInfo([NotNullWhen(true)] out RelatedNodeInfo? value)
    {
        value = this.Value as RelatedNodeInfo;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>RelationshipRelatedNodeInfo</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRelationshipRelatedNodeInfos(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;RelationshipRelatedNodeInfo&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRelationshipRelatedNodeInfos(
        [NotNullWhen(true)] out IReadOnlyList<RelationshipRelatedNodeInfo>? value
    )
    {
        value = this.Value as IReadOnlyList<RelationshipRelatedNodeInfo>;
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
    ///     (RelatedNodeInfo value) =&gt; {...},
    ///     (IReadOnlyList&lt;RelationshipRelatedNodeInfo&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<RelatedNodeInfo> relatedNodeInfo,
        System::Action<IReadOnlyList<RelationshipRelatedNodeInfo>> relationshipRelatedNodeInfos
    )
    {
        switch (this.Value)
        {
            case RelatedNodeInfo value:
                relatedNodeInfo(value);
                break;
            case IReadOnlyList<RelationshipRelatedNodeInfo> value:
                relationshipRelatedNodeInfos(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of Relationship"
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
    ///     (RelatedNodeInfo value) =&gt; {...},
    ///     (IReadOnlyList&lt;RelationshipRelatedNodeInfo&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<RelatedNodeInfo, T> relatedNodeInfo,
        System::Func<IReadOnlyList<RelationshipRelatedNodeInfo>, T> relationshipRelatedNodeInfos
    )
    {
        return this.Value switch
        {
            RelatedNodeInfo value => relatedNodeInfo(value),
            IReadOnlyList<RelationshipRelatedNodeInfo> value => relationshipRelatedNodeInfos(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of Relationship"
            ),
        };
    }

    public static implicit operator Relationship(RelatedNodeInfo value) => new(value);

    public static implicit operator Relationship(List<RelationshipRelatedNodeInfo> value) =>
        new((IReadOnlyList<RelationshipRelatedNodeInfo>)value);

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
                "Data did not match any variant of Relationship"
            );
        }
        this.Switch(
            (relatedNodeInfo) => relatedNodeInfo.Validate(),
            (relationshipRelatedNodeInfos) =>
            {
                foreach (var item in relationshipRelatedNodeInfos)
                {
                    item.Validate();
                }
            }
        );
    }

    public virtual bool Equals(Relationship? other) =>
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
            RelatedNodeInfo _ => 0,
            IReadOnlyList<RelationshipRelatedNodeInfo> _ => 1,
            _ => -1,
        };
    }
}

sealed class RelationshipConverter : JsonConverter<Relationship>
{
    public override Relationship? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<RelatedNodeInfo>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<List<RelationshipRelatedNodeInfo>>(
                element,
                options
            );
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
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
        Relationship value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<RelatedNodeInfo, RelatedNodeInfoFromRaw>))]
public sealed record class RelatedNodeInfo : JsonModel
{
    public required string NodeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("node_id");
        }
        init { this._rawData.Set("node_id", value); }
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

    public string? Hash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("hash");
        }
        init { this._rawData.Set("hash", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public ApiEnum<string, NodeType>? NodeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, NodeType>>("node_type");
        }
        init { this._rawData.Set("node_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NodeID;
        _ = this.ClassName;
        _ = this.Hash;
        _ = this.Metadata;
        this.NodeType?.Raw();
    }

    public RelatedNodeInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RelatedNodeInfo(RelatedNodeInfo relatedNodeInfo)
        : base(relatedNodeInfo) { }
#pragma warning restore CS8618

    public RelatedNodeInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RelatedNodeInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RelatedNodeInfoFromRaw.FromRawUnchecked"/>
    public static RelatedNodeInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RelatedNodeInfo(string nodeID)
        : this()
    {
        this.NodeID = nodeID;
    }
}

class RelatedNodeInfoFromRaw : IFromRawJson<RelatedNodeInfo>
{
    /// <inheritdoc/>
    public RelatedNodeInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RelatedNodeInfo.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(NodeTypeConverter))]
public enum NodeType
{
    V1,
    V2,
    V3,
    V4,
    V5,
}

sealed class NodeTypeConverter : JsonConverter<NodeType>
{
    public override NodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1" => NodeType.V1,
            "2" => NodeType.V2,
            "3" => NodeType.V3,
            "4" => NodeType.V4,
            "5" => NodeType.V5,
            _ => (NodeType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, NodeType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                NodeType.V1 => "1",
                NodeType.V2 => "2",
                NodeType.V3 => "3",
                NodeType.V4 => "4",
                NodeType.V5 => "5",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<RelationshipRelatedNodeInfo, RelationshipRelatedNodeInfoFromRaw>)
)]
public sealed record class RelationshipRelatedNodeInfo : JsonModel
{
    public required string NodeID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("node_id");
        }
        init { this._rawData.Set("node_id", value); }
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

    public string? Hash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("hash");
        }
        init { this._rawData.Set("hash", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public ApiEnum<string, RelationshipRelatedNodeInfoNodeType>? NodeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, RelationshipRelatedNodeInfoNodeType>
            >("node_type");
        }
        init { this._rawData.Set("node_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NodeID;
        _ = this.ClassName;
        _ = this.Hash;
        _ = this.Metadata;
        this.NodeType?.Raw();
    }

    public RelationshipRelatedNodeInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RelationshipRelatedNodeInfo(RelationshipRelatedNodeInfo relationshipRelatedNodeInfo)
        : base(relationshipRelatedNodeInfo) { }
#pragma warning restore CS8618

    public RelationshipRelatedNodeInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RelationshipRelatedNodeInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RelationshipRelatedNodeInfoFromRaw.FromRawUnchecked"/>
    public static RelationshipRelatedNodeInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RelationshipRelatedNodeInfo(string nodeID)
        : this()
    {
        this.NodeID = nodeID;
    }
}

class RelationshipRelatedNodeInfoFromRaw : IFromRawJson<RelationshipRelatedNodeInfo>
{
    /// <inheritdoc/>
    public RelationshipRelatedNodeInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RelationshipRelatedNodeInfo.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RelationshipRelatedNodeInfoNodeTypeConverter))]
public enum RelationshipRelatedNodeInfoNodeType
{
    V1,
    V2,
    V3,
    V4,
    V5,
}

sealed class RelationshipRelatedNodeInfoNodeTypeConverter
    : JsonConverter<RelationshipRelatedNodeInfoNodeType>
{
    public override RelationshipRelatedNodeInfoNodeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1" => RelationshipRelatedNodeInfoNodeType.V1,
            "2" => RelationshipRelatedNodeInfoNodeType.V2,
            "3" => RelationshipRelatedNodeInfoNodeType.V3,
            "4" => RelationshipRelatedNodeInfoNodeType.V4,
            "5" => RelationshipRelatedNodeInfoNodeType.V5,
            _ => (RelationshipRelatedNodeInfoNodeType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RelationshipRelatedNodeInfoNodeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RelationshipRelatedNodeInfoNodeType.V1 => "1",
                RelationshipRelatedNodeInfoNodeType.V2 => "2",
                RelationshipRelatedNodeInfoNodeType.V3 => "3",
                RelationshipRelatedNodeInfoNodeType.V4 => "4",
                RelationshipRelatedNodeInfoNodeType.V5 => "5",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
