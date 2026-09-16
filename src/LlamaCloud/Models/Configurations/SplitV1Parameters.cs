using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Beta.Split;

namespace LlamaCloud.Models.Configurations;

/// <summary>
/// Typed parameters for a *split v1* product configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SplitV1Parameters, SplitV1ParametersFromRaw>))]
public sealed record class SplitV1Parameters : JsonModel
{
    /// <summary>
    /// Categories to split documents into.
    /// </summary>
    public required IReadOnlyList<SplitCategory> Categories
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SplitCategory>>("categories");
        }
        init
        {
            this._rawData.Set<ImmutableArray<SplitCategory>>(
                "categories",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public JsonElement ProductType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("product_type");
        }
        init { this._rawData.Set("product_type", value); }
    }

    /// <summary>
    /// Saved parse configuration ID controlling how the document is read before splitting.
    /// Takes precedence over parse_tier. Configurations restricted to a page subset
    /// (target_pages or max_pages) are rejected, since split results always number
    /// pages relative to the full document. Ignored when a completed parse job is
    /// supplied as file_input.
    /// </summary>
    public string? ParseConfigID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parse_config_id");
        }
        init { this._rawData.Set("parse_config_id", value); }
    }

    /// <summary>
    /// Parse tier used to read the document before splitting. Defaults to fast.
    /// Ignored when a completed parse job is supplied as file_input.
    /// </summary>
    public ApiEnum<string, SplitV1ParametersParseTier>? ParseTier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SplitV1ParametersParseTier>>(
                "parse_tier"
            );
        }
        init { this._rawData.Set("parse_tier", value); }
    }

    /// <summary>
    /// Strategy for splitting documents.
    /// </summary>
    public global::LlamaCloud.Models.Configurations.SplittingStrategy? SplittingStrategy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::LlamaCloud.Models.Configurations.SplittingStrategy>(
                "splitting_strategy"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("splitting_strategy", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Categories)
        {
            item.Validate();
        }
        if (
            !JsonElement.DeepEquals(this.ProductType, JsonSerializer.SerializeToElement("split_v1"))
        )
        {
            throw new LlamaCloudInvalidDataException("Invalid value given for constant");
        }
        _ = this.ParseConfigID;
        this.ParseTier?.Validate();
        this.SplittingStrategy?.Validate();
    }

    public SplitV1Parameters()
    {
        this.ProductType = JsonSerializer.SerializeToElement("split_v1");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplitV1Parameters(SplitV1Parameters splitV1Parameters)
        : base(splitV1Parameters) { }
#pragma warning restore CS8618

    public SplitV1Parameters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ProductType = JsonSerializer.SerializeToElement("split_v1");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplitV1Parameters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SplitV1ParametersFromRaw.FromRawUnchecked"/>
    public static SplitV1Parameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SplitV1Parameters(IReadOnlyList<SplitCategory> categories)
        : this()
    {
        this.Categories = categories;
    }
}

class SplitV1ParametersFromRaw : IFromRawJson<SplitV1Parameters>
{
    /// <inheritdoc/>
    public SplitV1Parameters FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SplitV1Parameters.FromRawUnchecked(rawData);
}

/// <summary>
/// Parse tier used to read the document before splitting. Defaults to fast. Ignored
/// when a completed parse job is supplied as file_input.
/// </summary>
[JsonConverter(typeof(SplitV1ParametersParseTierConverter))]
public enum SplitV1ParametersParseTier
{
    Agentic,
    AgenticPlus,
    CostEffective,
    Fast,
}

sealed class SplitV1ParametersParseTierConverter : JsonConverter<SplitV1ParametersParseTier>
{
    public override SplitV1ParametersParseTier Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agentic" => SplitV1ParametersParseTier.Agentic,
            "agentic_plus" => SplitV1ParametersParseTier.AgenticPlus,
            "cost_effective" => SplitV1ParametersParseTier.CostEffective,
            "fast" => SplitV1ParametersParseTier.Fast,
            _ => (SplitV1ParametersParseTier)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SplitV1ParametersParseTier value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SplitV1ParametersParseTier.Agentic => "agentic",
                SplitV1ParametersParseTier.AgenticPlus => "agentic_plus",
                SplitV1ParametersParseTier.CostEffective => "cost_effective",
                SplitV1ParametersParseTier.Fast => "fast",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Strategy for splitting documents.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::LlamaCloud.Models.Configurations.SplittingStrategy,
        global::LlamaCloud.Models.Configurations.SplittingStrategyFromRaw
    >)
)]
public sealed record class SplittingStrategy : JsonModel
{
    /// <summary>
    /// Controls handling of pages that don't match any category. 'include': pages
    /// can be grouped as 'uncategorized' and included in results. 'forbid': all
    /// pages must be assigned to a defined category. 'omit': pages can be classified
    /// as 'uncategorized' but are excluded from results.
    /// </summary>
    public ApiEnum<
        string,
        global::LlamaCloud.Models.Configurations.AllowUncategorized
    >? AllowUncategorized
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::LlamaCloud.Models.Configurations.AllowUncategorized>
            >("allow_uncategorized");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("allow_uncategorized", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AllowUncategorized?.Validate();
    }

    public SplittingStrategy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SplittingStrategy(
        global::LlamaCloud.Models.Configurations.SplittingStrategy splittingStrategy
    )
        : base(splittingStrategy) { }
#pragma warning restore CS8618

    public SplittingStrategy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SplittingStrategy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::LlamaCloud.Models.Configurations.SplittingStrategyFromRaw.FromRawUnchecked"/>
    public static global::LlamaCloud.Models.Configurations.SplittingStrategy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SplittingStrategyFromRaw
    : IFromRawJson<global::LlamaCloud.Models.Configurations.SplittingStrategy>
{
    /// <inheritdoc/>
    public global::LlamaCloud.Models.Configurations.SplittingStrategy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::LlamaCloud.Models.Configurations.SplittingStrategy.FromRawUnchecked(rawData);
}

/// <summary>
/// Controls handling of pages that don't match any category. 'include': pages can
/// be grouped as 'uncategorized' and included in results. 'forbid': all pages must
/// be assigned to a defined category. 'omit': pages can be classified as 'uncategorized'
/// but are excluded from results.
/// </summary>
[JsonConverter(typeof(global::LlamaCloud.Models.Configurations.AllowUncategorizedConverter))]
public enum AllowUncategorized
{
    Forbid,
    Include,
    Omit,
}

sealed class AllowUncategorizedConverter
    : JsonConverter<global::LlamaCloud.Models.Configurations.AllowUncategorized>
{
    public override global::LlamaCloud.Models.Configurations.AllowUncategorized Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "forbid" => global::LlamaCloud.Models.Configurations.AllowUncategorized.Forbid,
            "include" => global::LlamaCloud.Models.Configurations.AllowUncategorized.Include,
            "omit" => global::LlamaCloud.Models.Configurations.AllowUncategorized.Omit,
            _ => (global::LlamaCloud.Models.Configurations.AllowUncategorized)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::LlamaCloud.Models.Configurations.AllowUncategorized value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::LlamaCloud.Models.Configurations.AllowUncategorized.Forbid => "forbid",
                global::LlamaCloud.Models.Configurations.AllowUncategorized.Include => "include",
                global::LlamaCloud.Models.Configurations.AllowUncategorized.Omit => "omit",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
