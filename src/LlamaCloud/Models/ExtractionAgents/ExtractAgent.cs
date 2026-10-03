using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models.ExtractionAgents;

/// <summary>
/// Schema and configuration for an extraction agent.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExtractAgent, ExtractAgentFromRaw>))]
public sealed record class ExtractAgent : JsonModel
{
    /// <summary>
    /// The id of the extraction agent.
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
    /// The configuration parameters for the extraction agent.
    /// </summary>
    public required Config Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Config>("config");
        }
        init { this._rawData.Set("config", value); }
    }

    /// <summary>
    /// The schema of the data.
    /// </summary>
    public required IReadOnlyDictionary<string, DataSchema?> DataSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, DataSchema?>>(
                "data_schema"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, DataSchema?>>(
                "data_schema",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The name of the extraction agent.
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

    /// <summary>
    /// The ID of the project that the extraction agent belongs to.
    /// </summary>
    public required string ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("project_id");
        }
        init { this._rawData.Set("project_id", value); }
    }

    /// <summary>
    /// The creation time of the extraction agent.
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
    /// Custom configuration type for the extraction agent. Currently supports 'default'.
    /// </summary>
    public ApiEnum<string, CustomConfiguration>? CustomConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CustomConfiguration>>(
                "custom_configuration"
            );
        }
        init { this._rawData.Set("custom_configuration", value); }
    }

    /// <summary>
    /// The last update time of the extraction agent.
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
        this.Config.Validate();
        foreach (var item in this.DataSchema.Values)
        {
            item?.Validate();
        }
        _ = this.Name;
        _ = this.ProjectID;
        _ = this.CreatedAt;
        this.CustomConfiguration?.Validate();
        _ = this.UpdatedAt;
    }

    public ExtractAgent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractAgent(ExtractAgent extractAgent)
        : base(extractAgent) { }
#pragma warning restore CS8618

    public ExtractAgent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractAgent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractAgentFromRaw.FromRawUnchecked"/>
    public static ExtractAgent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractAgentFromRaw : IFromRawJson<ExtractAgent>
{
    /// <inheritdoc/>
    public ExtractAgent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExtractAgent.FromRawUnchecked(rawData);
}

/// <summary>
/// The configuration parameters for the extraction agent.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Config, ConfigFromRaw>))]
public sealed record class Config : JsonModel
{
    /// <summary>
    /// The mode to use for chunking the document.
    /// </summary>
    public ApiEnum<string, ChunkMode>? ChunkMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ChunkMode>>("chunk_mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chunk_mode", value);
        }
    }

    /// <summary>
    /// Whether to fetch citation bounding boxes for the extraction. Only available
    /// in PREMIUM mode. Deprecated: this is now synonymous with cite_sources.
    /// </summary>
    [Obsolete("deprecated")]
    public bool? CitationBbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("citation_bbox");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("citation_bbox", value);
        }
    }

    /// <summary>
    /// Whether to cite sources for the extraction.
    /// </summary>
    public bool? CiteSources
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("cite_sources");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cite_sources", value);
        }
    }

    /// <summary>
    /// Whether to fetch confidence scores for the extraction.
    /// </summary>
    public bool? ConfidenceScores
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("confidence_scores");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confidence_scores", value);
        }
    }

    /// <summary>
    /// The extract model to use for data extraction. If not provided, uses the default
    /// for the extraction mode.
    /// </summary>
    public ApiEnum<string, ExtractModel>? ExtractModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ExtractModel>>("extract_model");
        }
        init { this._rawData.Set("extract_model", value); }
    }

    /// <summary>
    /// The extraction mode specified (FAST, BALANCED, MULTIMODAL, PREMIUM).
    /// </summary>
    public ApiEnum<string, ExtractionMode>? ExtractionMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ExtractionMode>>(
                "extraction_mode"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("extraction_mode", value);
        }
    }

    /// <summary>
    /// The extraction target specified.
    /// </summary>
    public ApiEnum<string, ExtractionTarget>? ExtractionTarget
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ExtractionTarget>>(
                "extraction_target"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("extraction_target", value);
        }
    }

    /// <summary>
    /// Whether to use high resolution mode for the extraction.
    /// </summary>
    public bool? HighResolutionMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("high_resolution_mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("high_resolution_mode", value);
        }
    }

    /// <summary>
    /// Whether to invalidate the cache for the extraction.
    /// </summary>
    public bool? InvalidateCache
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("invalidate_cache");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("invalidate_cache", value);
        }
    }

    /// <summary>
    /// DEPRECATED: Whether to use fast mode for multimodal extraction.
    /// </summary>
    public bool? MultimodalFastMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("multimodal_fast_mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("multimodal_fast_mode", value);
        }
    }

    /// <summary>
    /// Number of pages to pass as context on long document extraction.
    /// </summary>
    public long? NumPagesContext
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("num_pages_context");
        }
        init { this._rawData.Set("num_pages_context", value); }
    }

    /// <summary>
    /// Comma-separated list of page numbers or ranges to extract from (1-based, e.g.,
    /// '1,3,5-7,9' or '1-3,8-10').
    /// </summary>
    public string? PageRange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("page_range");
        }
        init { this._rawData.Set("page_range", value); }
    }

    /// <summary>
    /// Public model names.
    /// </summary>
    public ApiEnum<string, ParseModel>? ParseModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ParseModel>>("parse_model");
        }
        init { this._rawData.Set("parse_model", value); }
    }

    /// <summary>
    /// The priority for the request. This field may be ignored or overwritten depending
    /// on the organization tier.
    /// </summary>
    public ApiEnum<string, Priority>? Priority
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Priority>>("priority");
        }
        init { this._rawData.Set("priority", value); }
    }

    /// <summary>
    /// The system prompt to use for the extraction.
    /// </summary>
    public string? SystemPrompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("system_prompt");
        }
        init { this._rawData.Set("system_prompt", value); }
    }

    /// <summary>
    /// Whether to use reasoning for the extraction.
    /// </summary>
    public bool? UseReasoning
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("use_reasoning");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("use_reasoning", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ChunkMode?.Validate();
        _ = this.CitationBbox;
        _ = this.CiteSources;
        _ = this.ConfidenceScores;
        this.ExtractModel?.Raw();
        this.ExtractionMode?.Validate();
        this.ExtractionTarget?.Validate();
        _ = this.HighResolutionMode;
        _ = this.InvalidateCache;
        _ = this.MultimodalFastMode;
        _ = this.NumPagesContext;
        _ = this.PageRange;
        this.ParseModel?.Validate();
        this.Priority?.Validate();
        _ = this.SystemPrompt;
        _ = this.UseReasoning;
    }

    public Config() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Config(Config config)
        : base(config) { }
#pragma warning restore CS8618

    public Config(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Config(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConfigFromRaw.FromRawUnchecked"/>
    public static Config FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConfigFromRaw : IFromRawJson<Config>
{
    /// <inheritdoc/>
    public Config FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Config.FromRawUnchecked(rawData);
}

/// <summary>
/// The mode to use for chunking the document.
/// </summary>
[JsonConverter(typeof(ChunkModeConverter))]
public enum ChunkMode
{
    Page,
    Section,
}

sealed class ChunkModeConverter : JsonConverter<ChunkMode>
{
    public override ChunkMode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PAGE" => ChunkMode.Page,
            "SECTION" => ChunkMode.Section,
            _ => (ChunkMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChunkMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChunkMode.Page => "PAGE",
                ChunkMode.Section => "SECTION",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Extract model options.
/// </summary>
[JsonConverter(typeof(ExtractModelConverter))]
public enum ExtractModel
{
    Gemini2_0Flash,
    Gemini2_5Flash,
    Gemini2_5FlashLite,
    Gemini2_5Pro,
    OpenAIGpt4_1,
    OpenAIGpt4_1Mini,
    OpenAIGpt4_1Nano,
    OpenAIGpt4o,
    OpenAIGpt4oMini,
    OpenAIGpt5,
    OpenAIGpt5Mini,
}

sealed class ExtractModelConverter : JsonConverter<ExtractModel>
{
    public override ExtractModel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "gemini-2.0-flash" => ExtractModel.Gemini2_0Flash,
            "gemini-2.5-flash" => ExtractModel.Gemini2_5Flash,
            "gemini-2.5-flash-lite" => ExtractModel.Gemini2_5FlashLite,
            "gemini-2.5-pro" => ExtractModel.Gemini2_5Pro,
            "openai-gpt-4-1" => ExtractModel.OpenAIGpt4_1,
            "openai-gpt-4-1-mini" => ExtractModel.OpenAIGpt4_1Mini,
            "openai-gpt-4-1-nano" => ExtractModel.OpenAIGpt4_1Nano,
            "openai-gpt-4o" => ExtractModel.OpenAIGpt4o,
            "openai-gpt-4o-mini" => ExtractModel.OpenAIGpt4oMini,
            "openai-gpt-5" => ExtractModel.OpenAIGpt5,
            "openai-gpt-5-mini" => ExtractModel.OpenAIGpt5Mini,
            _ => (ExtractModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractModel.Gemini2_0Flash => "gemini-2.0-flash",
                ExtractModel.Gemini2_5Flash => "gemini-2.5-flash",
                ExtractModel.Gemini2_5FlashLite => "gemini-2.5-flash-lite",
                ExtractModel.Gemini2_5Pro => "gemini-2.5-pro",
                ExtractModel.OpenAIGpt4_1 => "openai-gpt-4-1",
                ExtractModel.OpenAIGpt4_1Mini => "openai-gpt-4-1-mini",
                ExtractModel.OpenAIGpt4_1Nano => "openai-gpt-4-1-nano",
                ExtractModel.OpenAIGpt4o => "openai-gpt-4o",
                ExtractModel.OpenAIGpt4oMini => "openai-gpt-4o-mini",
                ExtractModel.OpenAIGpt5 => "openai-gpt-5",
                ExtractModel.OpenAIGpt5Mini => "openai-gpt-5-mini",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The extraction mode specified (FAST, BALANCED, MULTIMODAL, PREMIUM).
/// </summary>
[JsonConverter(typeof(ExtractionModeConverter))]
public enum ExtractionMode
{
    Balanced,
    Fast,
    Multimodal,
    Premium,
}

sealed class ExtractionModeConverter : JsonConverter<ExtractionMode>
{
    public override ExtractionMode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "BALANCED" => ExtractionMode.Balanced,
            "FAST" => ExtractionMode.Fast,
            "MULTIMODAL" => ExtractionMode.Multimodal,
            "PREMIUM" => ExtractionMode.Premium,
            _ => (ExtractionMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionMode.Balanced => "BALANCED",
                ExtractionMode.Fast => "FAST",
                ExtractionMode.Multimodal => "MULTIMODAL",
                ExtractionMode.Premium => "PREMIUM",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The extraction target specified.
/// </summary>
[JsonConverter(typeof(ExtractionTargetConverter))]
public enum ExtractionTarget
{
    PerDoc,
    PerPage,
    PerTableRow,
}

sealed class ExtractionTargetConverter : JsonConverter<ExtractionTarget>
{
    public override ExtractionTarget Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PER_DOC" => ExtractionTarget.PerDoc,
            "PER_PAGE" => ExtractionTarget.PerPage,
            "PER_TABLE_ROW" => ExtractionTarget.PerTableRow,
            _ => (ExtractionTarget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ExtractionTarget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ExtractionTarget.PerDoc => "PER_DOC",
                ExtractionTarget.PerPage => "PER_PAGE",
                ExtractionTarget.PerTableRow => "PER_TABLE_ROW",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Public model names.
/// </summary>
[JsonConverter(typeof(ParseModelConverter))]
public enum ParseModel
{
    AnthropicHaiku3_5,
    AnthropicHaiku4_5,
    AnthropicSonnet3_5,
    AnthropicSonnet3_5V2,
    AnthropicSonnet3_7,
    AnthropicSonnet4_0,
    AnthropicSonnet4_5,
    Gemini2_0Flash,
    Gemini2_0FlashLite,
    Gemini2_5Flash,
    Gemini2_5FlashLite,
    Gemini2_5Pro,
    Gemini3_0Pro,
    Gemini3_1Pro,
    OpenAIGpt4_1,
    OpenAIGpt4_1Mini,
    OpenAIGpt4_1Nano,
    OpenAIGpt4o,
    OpenAIGpt4oMini,
    OpenAIGpt5,
    OpenAIGpt5Mini,
    OpenAIGpt5Nano,
    OpenAITextEmbedding3Large,
    OpenAITextEmbedding3Small,
    OpenAIWhisper1,
}

sealed class ParseModelConverter : JsonConverter<ParseModel>
{
    public override ParseModel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "anthropic-haiku-3.5" => ParseModel.AnthropicHaiku3_5,
            "anthropic-haiku-4.5" => ParseModel.AnthropicHaiku4_5,
            "anthropic-sonnet-3.5" => ParseModel.AnthropicSonnet3_5,
            "anthropic-sonnet-3.5-v2" => ParseModel.AnthropicSonnet3_5V2,
            "anthropic-sonnet-3.7" => ParseModel.AnthropicSonnet3_7,
            "anthropic-sonnet-4.0" => ParseModel.AnthropicSonnet4_0,
            "anthropic-sonnet-4.5" => ParseModel.AnthropicSonnet4_5,
            "gemini-2.0-flash" => ParseModel.Gemini2_0Flash,
            "gemini-2.0-flash-lite" => ParseModel.Gemini2_0FlashLite,
            "gemini-2.5-flash" => ParseModel.Gemini2_5Flash,
            "gemini-2.5-flash-lite" => ParseModel.Gemini2_5FlashLite,
            "gemini-2.5-pro" => ParseModel.Gemini2_5Pro,
            "gemini-3.0-pro" => ParseModel.Gemini3_0Pro,
            "gemini-3.1-pro" => ParseModel.Gemini3_1Pro,
            "openai-gpt-4-1" => ParseModel.OpenAIGpt4_1,
            "openai-gpt-4-1-mini" => ParseModel.OpenAIGpt4_1Mini,
            "openai-gpt-4-1-nano" => ParseModel.OpenAIGpt4_1Nano,
            "openai-gpt-4o" => ParseModel.OpenAIGpt4o,
            "openai-gpt-4o-mini" => ParseModel.OpenAIGpt4oMini,
            "openai-gpt-5" => ParseModel.OpenAIGpt5,
            "openai-gpt-5-mini" => ParseModel.OpenAIGpt5Mini,
            "openai-gpt-5-nano" => ParseModel.OpenAIGpt5Nano,
            "openai-text-embedding-3-large" => ParseModel.OpenAITextEmbedding3Large,
            "openai-text-embedding-3-small" => ParseModel.OpenAITextEmbedding3Small,
            "openai-whisper-1" => ParseModel.OpenAIWhisper1,
            _ => (ParseModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ParseModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ParseModel.AnthropicHaiku3_5 => "anthropic-haiku-3.5",
                ParseModel.AnthropicHaiku4_5 => "anthropic-haiku-4.5",
                ParseModel.AnthropicSonnet3_5 => "anthropic-sonnet-3.5",
                ParseModel.AnthropicSonnet3_5V2 => "anthropic-sonnet-3.5-v2",
                ParseModel.AnthropicSonnet3_7 => "anthropic-sonnet-3.7",
                ParseModel.AnthropicSonnet4_0 => "anthropic-sonnet-4.0",
                ParseModel.AnthropicSonnet4_5 => "anthropic-sonnet-4.5",
                ParseModel.Gemini2_0Flash => "gemini-2.0-flash",
                ParseModel.Gemini2_0FlashLite => "gemini-2.0-flash-lite",
                ParseModel.Gemini2_5Flash => "gemini-2.5-flash",
                ParseModel.Gemini2_5FlashLite => "gemini-2.5-flash-lite",
                ParseModel.Gemini2_5Pro => "gemini-2.5-pro",
                ParseModel.Gemini3_0Pro => "gemini-3.0-pro",
                ParseModel.Gemini3_1Pro => "gemini-3.1-pro",
                ParseModel.OpenAIGpt4_1 => "openai-gpt-4-1",
                ParseModel.OpenAIGpt4_1Mini => "openai-gpt-4-1-mini",
                ParseModel.OpenAIGpt4_1Nano => "openai-gpt-4-1-nano",
                ParseModel.OpenAIGpt4o => "openai-gpt-4o",
                ParseModel.OpenAIGpt4oMini => "openai-gpt-4o-mini",
                ParseModel.OpenAIGpt5 => "openai-gpt-5",
                ParseModel.OpenAIGpt5Mini => "openai-gpt-5-mini",
                ParseModel.OpenAIGpt5Nano => "openai-gpt-5-nano",
                ParseModel.OpenAITextEmbedding3Large => "openai-text-embedding-3-large",
                ParseModel.OpenAITextEmbedding3Small => "openai-text-embedding-3-small",
                ParseModel.OpenAIWhisper1 => "openai-whisper-1",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The priority for the request. This field may be ignored or overwritten depending
/// on the organization tier.
/// </summary>
[JsonConverter(typeof(PriorityConverter))]
public enum Priority
{
    Critical,
    High,
    Low,
    Medium,
}

sealed class PriorityConverter : JsonConverter<Priority>
{
    public override Priority Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "critical" => Priority.Critical,
            "high" => Priority.High,
            "low" => Priority.Low,
            "medium" => Priority.Medium,
            _ => (Priority)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Priority value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Priority.Critical => "critical",
                Priority.High => "high",
                Priority.Low => "low",
                Priority.Medium => "medium",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(DataSchemaConverter))]
public record class DataSchema : ModelBase
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

    public DataSchema(IReadOnlyDictionary<string, JsonElement> value, JsonElement? element = null)
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public DataSchema(IReadOnlyList<JsonElement> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public DataSchema(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DataSchema(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DataSchema(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public DataSchema(JsonElement element)
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
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>JsonElement</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements1(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;JsonElement&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements1([NotNullWhen(true)] out IReadOnlyList<JsonElement>? value)
    {
        value = this.Value as IReadOnlyList<JsonElement>;
        return value != null;
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
    ///     (IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<IReadOnlyDictionary<string, JsonElement>> jsonElements,
        Action<IReadOnlyList<JsonElement>> jsonElements1,
        Action<string> @string,
        Action<double> @double,
        Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case IReadOnlyDictionary<string, JsonElement> value:
                jsonElements(value);
                break;
            case IReadOnlyList<JsonElement> value:
                jsonElements1(value);
                break;
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of DataSchema"
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
    ///     (IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<IReadOnlyDictionary<string, JsonElement>, T> jsonElements,
        Func<IReadOnlyList<JsonElement>, T> jsonElements1,
        Func<string, T> @string,
        Func<double, T> @double,
        Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            IReadOnlyDictionary<string, JsonElement> value => jsonElements(value),
            IReadOnlyList<JsonElement> value => jsonElements1(value),
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of DataSchema"
            ),
        };
    }

    public static implicit operator DataSchema(Dictionary<string, JsonElement> value) =>
        new((IReadOnlyDictionary<string, JsonElement>)value);

    public static implicit operator DataSchema(List<JsonElement> value) =>
        new((IReadOnlyList<JsonElement>)value);

    public static implicit operator DataSchema(string value) => new(value);

    public static implicit operator DataSchema(double value) => new(value);

    public static implicit operator DataSchema(bool value) => new(value);

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
                "Data did not match any variant of DataSchema"
            );
        }
    }

    public virtual bool Equals(DataSchema? other) =>
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
            IReadOnlyList<JsonElement> _ => 1,
            string _ => 2,
            double _ => 3,
            bool _ => 4,
            _ => -1,
        };
    }
}

sealed class DataSchemaConverter : JsonConverter<DataSchema?>
{
    public override DataSchema? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
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

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<JsonElement>>(element, options);
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

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataSchema? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Custom configuration type for the extraction agent. Currently supports 'default'.
/// </summary>
[JsonConverter(typeof(CustomConfigurationConverter))]
public enum CustomConfiguration
{
    Default,
}

sealed class CustomConfigurationConverter : JsonConverter<CustomConfiguration>
{
    public override CustomConfiguration Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "default" => CustomConfiguration.Default,
            _ => (CustomConfiguration)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomConfiguration value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CustomConfiguration.Default => "default",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
