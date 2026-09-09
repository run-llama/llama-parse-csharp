using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models.Beta.Sheets;

/// <summary>
/// Configuration for spreadsheet parsing and region extraction
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SheetsParsingConfig, SheetsParsingConfigFromRaw>))]
public sealed record class SheetsParsingConfig : JsonModel
{
    /// <summary>
    /// A1 notation of the range to extract a single region from. If None, the entire
    /// sheet is used.
    /// </summary>
    public string? ExtractionRange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("extraction_range");
        }
        init { this._rawData.Set("extraction_range", value); }
    }

    /// <summary>
    /// Return a flattened dataframe when a detected table is recognized as hierarchical.
    /// </summary>
    public bool? FlattenHierarchicalTables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("flatten_hierarchical_tables");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("flatten_hierarchical_tables", value);
        }
    }

    /// <summary>
    /// Deprecated: controlled by `tier`. Whether to generate additional metadata
    /// (title, description) for each extracted region. Honored only on `agentic`.
    /// </summary>
    public bool? GenerateAdditionalMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("generate_additional_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("generate_additional_metadata", value);
        }
    }

    /// <summary>
    /// Whether to include hidden cells when extracting regions from the spreadsheet.
    /// </summary>
    public bool? IncludeHiddenCells
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("include_hidden_cells");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("include_hidden_cells", value);
        }
    }

    /// <summary>
    /// The names of the sheets to extract regions from. If empty, all sheets will
    /// be processed.
    /// </summary>
    public IReadOnlyList<string>? SheetNames
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("sheet_names");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "sheet_names",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Deprecated: controlled by `tier`. Optional specialization mode for domain-specific
    /// extraction. Supported values: 'financial-standard', 'financial-enhanced',
    /// 'financial-precise'. Default None uses the general-purpose pipeline. Honored
    /// only on `agentic`.
    /// </summary>
    public string? Specialization
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("specialization");
        }
        init { this._rawData.Set("specialization", value); }
    }

    /// <summary>
    /// Deprecated: controlled by `tier`. Influences how likely similar-looking regions
    /// are merged into a single table. Honored only on `agentic`.
    /// </summary>
    public ApiEnum<string, TableMergeSensitivity>? TableMergeSensitivity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TableMergeSensitivity>>(
                "table_merge_sensitivity"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("table_merge_sensitivity", value);
        }
    }

    /// <summary>
    /// Spreadsheet extraction tier. `cost_effective` uses the rule-based/ML-only
    /// pipeline; `agentic` uses the full pipeline.
    /// </summary>
    public ApiEnum<string, Tier>? Tier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Tier>>("tier");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tier", value);
        }
    }

    /// <summary>
    /// Deprecated: controlled by `tier`. Enables experimental processing. Honored
    /// only on `agentic`.
    /// </summary>
    public bool? UseExperimentalProcessing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("use_experimental_processing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("use_experimental_processing", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExtractionRange;
        _ = this.FlattenHierarchicalTables;
        _ = this.GenerateAdditionalMetadata;
        _ = this.IncludeHiddenCells;
        _ = this.SheetNames;
        _ = this.Specialization;
        this.TableMergeSensitivity?.Validate();
        this.Tier?.Validate();
        _ = this.UseExperimentalProcessing;
    }

    public SheetsParsingConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SheetsParsingConfig(SheetsParsingConfig sheetsParsingConfig)
        : base(sheetsParsingConfig) { }
#pragma warning restore CS8618

    public SheetsParsingConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SheetsParsingConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SheetsParsingConfigFromRaw.FromRawUnchecked"/>
    public static SheetsParsingConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SheetsParsingConfigFromRaw : IFromRawJson<SheetsParsingConfig>
{
    /// <inheritdoc/>
    public SheetsParsingConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SheetsParsingConfig.FromRawUnchecked(rawData);
}

/// <summary>
/// Deprecated: controlled by `tier`. Influences how likely similar-looking regions
/// are merged into a single table. Honored only on `agentic`.
/// </summary>
[JsonConverter(typeof(TableMergeSensitivityConverter))]
public enum TableMergeSensitivity
{
    Strong,
    Weak,
}

sealed class TableMergeSensitivityConverter : JsonConverter<TableMergeSensitivity>
{
    public override TableMergeSensitivity Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "strong" => TableMergeSensitivity.Strong,
            "weak" => TableMergeSensitivity.Weak,
            _ => (TableMergeSensitivity)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TableMergeSensitivity value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TableMergeSensitivity.Strong => "strong",
                TableMergeSensitivity.Weak => "weak",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Spreadsheet extraction tier. `cost_effective` uses the rule-based/ML-only pipeline;
/// `agentic` uses the full pipeline.
/// </summary>
[JsonConverter(typeof(TierConverter))]
public enum Tier
{
    Agentic,
    CostEffective,
}

sealed class TierConverter : JsonConverter<Tier>
{
    public override Tier Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agentic" => Tier.Agentic,
            "cost_effective" => Tier.CostEffective,
            _ => (Tier)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Tier value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Tier.Agentic => "agentic",
                Tier.CostEffective => "cost_effective",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
