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
