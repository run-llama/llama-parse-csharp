using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models.Configurations;

/// <summary>
/// Typed parameters for a *classify v2* product configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ClassifyV2Parameters, ClassifyV2ParametersFromRaw>))]
public sealed record class ClassifyV2Parameters : JsonModel
{
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
    /// Classify rules to evaluate against the document (at least one required)
    /// </summary>
    public required IReadOnlyList<Rule> Rules
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Rule>>("rules");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Rule>>(
                "rules",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Classify execution mode
    /// </summary>
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

    /// <summary>
    /// Parsing configuration for classify jobs.
    /// </summary>
    public ParsingConfiguration? ParsingConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ParsingConfiguration>("parsing_configuration");
        }
        init { this._rawData.Set("parsing_configuration", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ProductType,
                JsonSerializer.SerializeToElement("classify_v2")
            )
        )
        {
            throw new LlamaCloudInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.Rules)
        {
            item.Validate();
        }
        this.Mode?.Validate();
        this.ParsingConfiguration?.Validate();
    }

    public ClassifyV2Parameters()
    {
        this.ProductType = JsonSerializer.SerializeToElement("classify_v2");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClassifyV2Parameters(ClassifyV2Parameters classifyV2Parameters)
        : base(classifyV2Parameters) { }
#pragma warning restore CS8618

    public ClassifyV2Parameters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ProductType = JsonSerializer.SerializeToElement("classify_v2");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClassifyV2Parameters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClassifyV2ParametersFromRaw.FromRawUnchecked"/>
    public static ClassifyV2Parameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ClassifyV2Parameters(IReadOnlyList<Rule> rules)
        : this()
    {
        this.Rules = rules;
    }
}

class ClassifyV2ParametersFromRaw : IFromRawJson<ClassifyV2Parameters>
{
    /// <inheritdoc/>
    public ClassifyV2Parameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClassifyV2Parameters.FromRawUnchecked(rawData);
}

/// <summary>
/// A rule for classifying documents.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Rule, RuleFromRaw>))]
public sealed record class Rule : JsonModel
{
    /// <summary>
    /// Natural language criteria for matching this rule
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Document type to assign when rule matches
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
        _ = this.Description;
        _ = this.Type;
    }

    public Rule() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Rule(Rule rule)
        : base(rule) { }
#pragma warning restore CS8618

    public Rule(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Rule(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RuleFromRaw.FromRawUnchecked"/>
    public static Rule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RuleFromRaw : IFromRawJson<Rule>
{
    /// <inheritdoc/>
    public Rule FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Rule.FromRawUnchecked(rawData);
}

/// <summary>
/// Classify execution mode
/// </summary>
[JsonConverter(typeof(ModeConverter))]
public enum Mode
{
    Fast,
}

sealed class ModeConverter : JsonConverter<Mode>
{
    public override Mode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FAST" => Mode.Fast,
            _ => (Mode)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Mode value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Mode.Fast => "FAST",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Parsing configuration for classify jobs.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ParsingConfiguration, ParsingConfigurationFromRaw>))]
public sealed record class ParsingConfiguration : JsonModel
{
    /// <summary>
    /// ISO 639-1 language code for the document
    /// </summary>
    public string? Lang
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lang");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lang", value);
        }
    }

    /// <summary>
    /// Maximum number of pages to process. Omit for no limit.
    /// </summary>
    public long? MaxPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_pages");
        }
        init { this._rawData.Set("max_pages", value); }
    }

    /// <summary>
    /// Comma-separated page numbers or ranges to process (1-based). Omit to process
    /// all pages.
    /// </summary>
    public string? TargetPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("target_pages");
        }
        init { this._rawData.Set("target_pages", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Lang;
        _ = this.MaxPages;
        _ = this.TargetPages;
    }

    public ParsingConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingConfiguration(ParsingConfiguration parsingConfiguration)
        : base(parsingConfiguration) { }
#pragma warning restore CS8618

    public ParsingConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsingConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParsingConfigurationFromRaw.FromRawUnchecked"/>
    public static ParsingConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParsingConfigurationFromRaw : IFromRawJson<ParsingConfiguration>
{
    /// <inheritdoc/>
    public ParsingConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ParsingConfiguration.FromRawUnchecked(rawData);
}
