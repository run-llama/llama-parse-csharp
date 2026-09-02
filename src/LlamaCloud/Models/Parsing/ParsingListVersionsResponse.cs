using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Parsing;

/// <summary>
/// Versions accepted by the parse API, grouped by tier.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ParsingListVersionsResponse, ParsingListVersionsResponseFromRaw>)
)]
public sealed record class ParsingListVersionsResponse : JsonModel
{
    /// <summary>
    /// Versions for the agentic tier
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, Agentic>> Agentic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ApiEnum<string, Agentic>>>(
                "agentic"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, Agentic>>>(
                "agentic",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Versions for the agentic_plus tier
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, AgenticPlus>> AgenticPlus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ApiEnum<string, AgenticPlus>>>(
                "agentic_plus"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, AgenticPlus>>>(
                "agentic_plus",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Versions for the cost_effective tier
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, CostEffective>> CostEffective
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ApiEnum<string, CostEffective>>>(
                "cost_effective"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, CostEffective>>>(
                "cost_effective",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Versions for the fast tier
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, Fast>> Fast
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ApiEnum<string, Fast>>>("fast");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, Fast>>>(
                "fast",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Version `latest` currently resolves to, per tier
    /// </summary>
    public required Latest Latest
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Latest>("latest");
        }
        init { this._rawData.Set("latest", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Agentic)
        {
            item.Validate();
        }
        foreach (var item in this.AgenticPlus)
        {
            item.Validate();
        }
        foreach (var item in this.CostEffective)
        {
            item.Validate();
        }
        foreach (var item in this.Fast)
        {
            item.Validate();
        }
        this.Latest.Validate();
    }

    public ParsingListVersionsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingListVersionsResponse(ParsingListVersionsResponse parsingListVersionsResponse)
        : base(parsingListVersionsResponse) { }
#pragma warning restore CS8618

    public ParsingListVersionsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsingListVersionsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParsingListVersionsResponseFromRaw.FromRawUnchecked"/>
    public static ParsingListVersionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParsingListVersionsResponseFromRaw : IFromRawJson<ParsingListVersionsResponse>
{
    /// <inheritdoc/>
    public ParsingListVersionsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ParsingListVersionsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AgenticConverter))]
public enum Agentic
{
    V2026_08_19,
    V2026_07_24,
    V2026_07_23,
    V2026_07_15,
    V2026_06_18,
    V2026_06_11,
    V2026_06_04,
    V2026_06_01,
    V2026_05_26,
    V2026_05_21,
    V2026_05_20,
    V2026_05_19,
    V2026_05_13,
    V2026_05_11,
    V2026_05_06,
    V2026_05_04,
    V2026_04_27,
    V2026_04_22,
    V2026_04_09,
    V2026_04_06,
    V2026_04_02,
    V2026_03_31,
    V2026_03_30,
    V2026_03_27,
    V2026_03_25,
    V2026_03_23,
    V2026_03_22,
    V2026_03_20,
    V2026_03_11,
    V2026_03_10,
    V2026_03_09,
    V2026_03_03,
    V2026_03_02,
    V2026_02_26,
    V2026_02_24,
    V2026_01_30,
    V2026_01_22,
    V2026_01_21,
    V2026_01_16,
    V2026_01_08,
    V2025_12_31,
    V2025_12_18,
    V2025_12_11,
}

sealed class AgenticConverter : JsonConverter<Agentic>
{
    public override Agentic Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "2026-08-19" => Agentic.V2026_08_19,
            "2026-07-24" => Agentic.V2026_07_24,
            "2026-07-23" => Agentic.V2026_07_23,
            "2026-07-15" => Agentic.V2026_07_15,
            "2026-06-18" => Agentic.V2026_06_18,
            "2026-06-11" => Agentic.V2026_06_11,
            "2026-06-04" => Agentic.V2026_06_04,
            "2026-06-01" => Agentic.V2026_06_01,
            "2026-05-26" => Agentic.V2026_05_26,
            "2026-05-21" => Agentic.V2026_05_21,
            "2026-05-20" => Agentic.V2026_05_20,
            "2026-05-19" => Agentic.V2026_05_19,
            "2026-05-13" => Agentic.V2026_05_13,
            "2026-05-11" => Agentic.V2026_05_11,
            "2026-05-06" => Agentic.V2026_05_06,
            "2026-05-04" => Agentic.V2026_05_04,
            "2026-04-27" => Agentic.V2026_04_27,
            "2026-04-22" => Agentic.V2026_04_22,
            "2026-04-09" => Agentic.V2026_04_09,
            "2026-04-06" => Agentic.V2026_04_06,
            "2026-04-02" => Agentic.V2026_04_02,
            "2026-03-31" => Agentic.V2026_03_31,
            "2026-03-30" => Agentic.V2026_03_30,
            "2026-03-27" => Agentic.V2026_03_27,
            "2026-03-25" => Agentic.V2026_03_25,
            "2026-03-23" => Agentic.V2026_03_23,
            "2026-03-22" => Agentic.V2026_03_22,
            "2026-03-20" => Agentic.V2026_03_20,
            "2026-03-11" => Agentic.V2026_03_11,
            "2026-03-10" => Agentic.V2026_03_10,
            "2026-03-09" => Agentic.V2026_03_09,
            "2026-03-03" => Agentic.V2026_03_03,
            "2026-03-02" => Agentic.V2026_03_02,
            "2026-02-26" => Agentic.V2026_02_26,
            "2026-02-24" => Agentic.V2026_02_24,
            "2026-01-30" => Agentic.V2026_01_30,
            "2026-01-22" => Agentic.V2026_01_22,
            "2026-01-21" => Agentic.V2026_01_21,
            "2026-01-16" => Agentic.V2026_01_16,
            "2026-01-08" => Agentic.V2026_01_08,
            "2025-12-31" => Agentic.V2025_12_31,
            "2025-12-18" => Agentic.V2025_12_18,
            "2025-12-11" => Agentic.V2025_12_11,
            _ => (Agentic)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Agentic value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Agentic.V2026_08_19 => "2026-08-19",
                Agentic.V2026_07_24 => "2026-07-24",
                Agentic.V2026_07_23 => "2026-07-23",
                Agentic.V2026_07_15 => "2026-07-15",
                Agentic.V2026_06_18 => "2026-06-18",
                Agentic.V2026_06_11 => "2026-06-11",
                Agentic.V2026_06_04 => "2026-06-04",
                Agentic.V2026_06_01 => "2026-06-01",
                Agentic.V2026_05_26 => "2026-05-26",
                Agentic.V2026_05_21 => "2026-05-21",
                Agentic.V2026_05_20 => "2026-05-20",
                Agentic.V2026_05_19 => "2026-05-19",
                Agentic.V2026_05_13 => "2026-05-13",
                Agentic.V2026_05_11 => "2026-05-11",
                Agentic.V2026_05_06 => "2026-05-06",
                Agentic.V2026_05_04 => "2026-05-04",
                Agentic.V2026_04_27 => "2026-04-27",
                Agentic.V2026_04_22 => "2026-04-22",
                Agentic.V2026_04_09 => "2026-04-09",
                Agentic.V2026_04_06 => "2026-04-06",
                Agentic.V2026_04_02 => "2026-04-02",
                Agentic.V2026_03_31 => "2026-03-31",
                Agentic.V2026_03_30 => "2026-03-30",
                Agentic.V2026_03_27 => "2026-03-27",
                Agentic.V2026_03_25 => "2026-03-25",
                Agentic.V2026_03_23 => "2026-03-23",
                Agentic.V2026_03_22 => "2026-03-22",
                Agentic.V2026_03_20 => "2026-03-20",
                Agentic.V2026_03_11 => "2026-03-11",
                Agentic.V2026_03_10 => "2026-03-10",
                Agentic.V2026_03_09 => "2026-03-09",
                Agentic.V2026_03_03 => "2026-03-03",
                Agentic.V2026_03_02 => "2026-03-02",
                Agentic.V2026_02_26 => "2026-02-26",
                Agentic.V2026_02_24 => "2026-02-24",
                Agentic.V2026_01_30 => "2026-01-30",
                Agentic.V2026_01_22 => "2026-01-22",
                Agentic.V2026_01_21 => "2026-01-21",
                Agentic.V2026_01_16 => "2026-01-16",
                Agentic.V2026_01_08 => "2026-01-08",
                Agentic.V2025_12_31 => "2025-12-31",
                Agentic.V2025_12_18 => "2025-12-18",
                Agentic.V2025_12_11 => "2025-12-11",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AgenticPlusConverter))]
public enum AgenticPlus
{
    V2026_08_19,
    V2026_07_08,
    V2026_06_18,
    V2026_06_11,
    V2026_06_04,
    V2026_06_01,
    V2026_05_26,
    V2026_05_21,
    V2026_05_20,
    V2026_05_19,
    V2026_05_11,
    V2026_05_06,
    V2026_05_04,
    V2026_05_01,
    V2026_04_27,
    V2026_04_19,
    V2026_04_14,
    V2026_04_09,
    V2026_04_02,
    V2026_03_31,
    V2026_03_26,
    V2026_03_25,
    V2026_03_22,
    V2026_03_20,
    V2026_03_17,
    V2026_03_12,
    V2026_03_10,
    V2026_03_09,
    V2026_03_02,
    V2026_02_26,
    V2026_02_24,
    V2026_01_30,
    V2026_01_29,
    V2026_01_24,
    V2026_01_22,
    V2026_01_21,
    V2026_01_16,
    V2025_12_31,
    V2025_12_18,
    V2025_12_11,
}

sealed class AgenticPlusConverter : JsonConverter<AgenticPlus>
{
    public override AgenticPlus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "2026-08-19" => AgenticPlus.V2026_08_19,
            "2026-07-08" => AgenticPlus.V2026_07_08,
            "2026-06-18" => AgenticPlus.V2026_06_18,
            "2026-06-11" => AgenticPlus.V2026_06_11,
            "2026-06-04" => AgenticPlus.V2026_06_04,
            "2026-06-01" => AgenticPlus.V2026_06_01,
            "2026-05-26" => AgenticPlus.V2026_05_26,
            "2026-05-21" => AgenticPlus.V2026_05_21,
            "2026-05-20" => AgenticPlus.V2026_05_20,
            "2026-05-19" => AgenticPlus.V2026_05_19,
            "2026-05-11" => AgenticPlus.V2026_05_11,
            "2026-05-06" => AgenticPlus.V2026_05_06,
            "2026-05-04" => AgenticPlus.V2026_05_04,
            "2026-05-01" => AgenticPlus.V2026_05_01,
            "2026-04-27" => AgenticPlus.V2026_04_27,
            "2026-04-19" => AgenticPlus.V2026_04_19,
            "2026-04-14" => AgenticPlus.V2026_04_14,
            "2026-04-09" => AgenticPlus.V2026_04_09,
            "2026-04-02" => AgenticPlus.V2026_04_02,
            "2026-03-31" => AgenticPlus.V2026_03_31,
            "2026-03-26" => AgenticPlus.V2026_03_26,
            "2026-03-25" => AgenticPlus.V2026_03_25,
            "2026-03-22" => AgenticPlus.V2026_03_22,
            "2026-03-20" => AgenticPlus.V2026_03_20,
            "2026-03-17" => AgenticPlus.V2026_03_17,
            "2026-03-12" => AgenticPlus.V2026_03_12,
            "2026-03-10" => AgenticPlus.V2026_03_10,
            "2026-03-09" => AgenticPlus.V2026_03_09,
            "2026-03-02" => AgenticPlus.V2026_03_02,
            "2026-02-26" => AgenticPlus.V2026_02_26,
            "2026-02-24" => AgenticPlus.V2026_02_24,
            "2026-01-30" => AgenticPlus.V2026_01_30,
            "2026-01-29" => AgenticPlus.V2026_01_29,
            "2026-01-24" => AgenticPlus.V2026_01_24,
            "2026-01-22" => AgenticPlus.V2026_01_22,
            "2026-01-21" => AgenticPlus.V2026_01_21,
            "2026-01-16" => AgenticPlus.V2026_01_16,
            "2025-12-31" => AgenticPlus.V2025_12_31,
            "2025-12-18" => AgenticPlus.V2025_12_18,
            "2025-12-11" => AgenticPlus.V2025_12_11,
            _ => (AgenticPlus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgenticPlus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AgenticPlus.V2026_08_19 => "2026-08-19",
                AgenticPlus.V2026_07_08 => "2026-07-08",
                AgenticPlus.V2026_06_18 => "2026-06-18",
                AgenticPlus.V2026_06_11 => "2026-06-11",
                AgenticPlus.V2026_06_04 => "2026-06-04",
                AgenticPlus.V2026_06_01 => "2026-06-01",
                AgenticPlus.V2026_05_26 => "2026-05-26",
                AgenticPlus.V2026_05_21 => "2026-05-21",
                AgenticPlus.V2026_05_20 => "2026-05-20",
                AgenticPlus.V2026_05_19 => "2026-05-19",
                AgenticPlus.V2026_05_11 => "2026-05-11",
                AgenticPlus.V2026_05_06 => "2026-05-06",
                AgenticPlus.V2026_05_04 => "2026-05-04",
                AgenticPlus.V2026_05_01 => "2026-05-01",
                AgenticPlus.V2026_04_27 => "2026-04-27",
                AgenticPlus.V2026_04_19 => "2026-04-19",
                AgenticPlus.V2026_04_14 => "2026-04-14",
                AgenticPlus.V2026_04_09 => "2026-04-09",
                AgenticPlus.V2026_04_02 => "2026-04-02",
                AgenticPlus.V2026_03_31 => "2026-03-31",
                AgenticPlus.V2026_03_26 => "2026-03-26",
                AgenticPlus.V2026_03_25 => "2026-03-25",
                AgenticPlus.V2026_03_22 => "2026-03-22",
                AgenticPlus.V2026_03_20 => "2026-03-20",
                AgenticPlus.V2026_03_17 => "2026-03-17",
                AgenticPlus.V2026_03_12 => "2026-03-12",
                AgenticPlus.V2026_03_10 => "2026-03-10",
                AgenticPlus.V2026_03_09 => "2026-03-09",
                AgenticPlus.V2026_03_02 => "2026-03-02",
                AgenticPlus.V2026_02_26 => "2026-02-26",
                AgenticPlus.V2026_02_24 => "2026-02-24",
                AgenticPlus.V2026_01_30 => "2026-01-30",
                AgenticPlus.V2026_01_29 => "2026-01-29",
                AgenticPlus.V2026_01_24 => "2026-01-24",
                AgenticPlus.V2026_01_22 => "2026-01-22",
                AgenticPlus.V2026_01_21 => "2026-01-21",
                AgenticPlus.V2026_01_16 => "2026-01-16",
                AgenticPlus.V2025_12_31 => "2025-12-31",
                AgenticPlus.V2025_12_18 => "2025-12-18",
                AgenticPlus.V2025_12_11 => "2025-12-11",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(CostEffectiveConverter))]
public enum CostEffective
{
    V2026_08_19,
    V2026_08_11,
    V2026_08_08,
    V2026_07_23,
    V2026_06_26,
    V2026_06_18,
    V2026_06_17,
    V2026_06_11,
    V2026_06_08,
    V2026_06_05,
    V2026_05_28,
    V2026_04_09,
    V2026_03_31,
    V2026_03_27,
    V2026_03_25,
}

sealed class CostEffectiveConverter : JsonConverter<CostEffective>
{
    public override CostEffective Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "2026-08-19" => CostEffective.V2026_08_19,
            "2026-08-11" => CostEffective.V2026_08_11,
            "2026-08-08" => CostEffective.V2026_08_08,
            "2026-07-23" => CostEffective.V2026_07_23,
            "2026-06-26" => CostEffective.V2026_06_26,
            "2026-06-18" => CostEffective.V2026_06_18,
            "2026-06-17" => CostEffective.V2026_06_17,
            "2026-06-11" => CostEffective.V2026_06_11,
            "2026-06-08" => CostEffective.V2026_06_08,
            "2026-06-05" => CostEffective.V2026_06_05,
            "2026-05-28" => CostEffective.V2026_05_28,
            "2026-04-09" => CostEffective.V2026_04_09,
            "2026-03-31" => CostEffective.V2026_03_31,
            "2026-03-27" => CostEffective.V2026_03_27,
            "2026-03-25" => CostEffective.V2026_03_25,
            _ => (CostEffective)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CostEffective value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CostEffective.V2026_08_19 => "2026-08-19",
                CostEffective.V2026_08_11 => "2026-08-11",
                CostEffective.V2026_08_08 => "2026-08-08",
                CostEffective.V2026_07_23 => "2026-07-23",
                CostEffective.V2026_06_26 => "2026-06-26",
                CostEffective.V2026_06_18 => "2026-06-18",
                CostEffective.V2026_06_17 => "2026-06-17",
                CostEffective.V2026_06_11 => "2026-06-11",
                CostEffective.V2026_06_08 => "2026-06-08",
                CostEffective.V2026_06_05 => "2026-06-05",
                CostEffective.V2026_05_28 => "2026-05-28",
                CostEffective.V2026_04_09 => "2026-04-09",
                CostEffective.V2026_03_31 => "2026-03-31",
                CostEffective.V2026_03_27 => "2026-03-27",
                CostEffective.V2026_03_25 => "2026-03-25",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(FastConverter))]
public enum Fast
{
    V2026_06_15,
    V2025_12_11,
}

sealed class FastConverter : JsonConverter<Fast>
{
    public override Fast Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "2026-06-15" => Fast.V2026_06_15,
            "2025-12-11" => Fast.V2025_12_11,
            _ => (Fast)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Fast value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Fast.V2026_06_15 => "2026-06-15",
                Fast.V2025_12_11 => "2025-12-11",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Version `latest` currently resolves to, per tier
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Latest, LatestFromRaw>))]
public sealed record class Latest : JsonModel
{
    /// <summary>
    /// Version `latest` resolves to for the agentic tier
    /// </summary>
    public required string Agentic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("agentic");
        }
        init { this._rawData.Set("agentic", value); }
    }

    /// <summary>
    /// Version `latest` resolves to for the agentic_plus tier
    /// </summary>
    public required string AgenticPlus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("agentic_plus");
        }
        init { this._rawData.Set("agentic_plus", value); }
    }

    /// <summary>
    /// Version `latest` resolves to for the cost_effective tier
    /// </summary>
    public required string CostEffective
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("cost_effective");
        }
        init { this._rawData.Set("cost_effective", value); }
    }

    /// <summary>
    /// Version `latest` resolves to for the fast tier
    /// </summary>
    public required string Fast
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("fast");
        }
        init { this._rawData.Set("fast", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Agentic;
        _ = this.AgenticPlus;
        _ = this.CostEffective;
        _ = this.Fast;
    }

    public Latest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Latest(Latest latest)
        : base(latest) { }
#pragma warning restore CS8618

    public Latest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Latest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LatestFromRaw.FromRawUnchecked"/>
    public static Latest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LatestFromRaw : IFromRawJson<Latest>
{
    /// <inheritdoc/>
    public Latest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Latest.FromRawUnchecked(rawData);
}
