using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models;

/// <summary>
/// HNSW settings for PGVector.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PgVectorHnswSettings, PgVectorHnswSettingsFromRaw>))]
public sealed record class PgVectorHnswSettings : JsonModel
{
    /// <summary>
    /// The distance method to use.
    /// </summary>
    public ApiEnum<string, DistanceMethod>? DistanceMethod
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DistanceMethod>>(
                "distance_method"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("distance_method", value);
        }
    }

    /// <summary>
    /// The number of edges to use during the construction phase.
    /// </summary>
    public long? EfConstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ef_construction");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ef_construction", value);
        }
    }

    /// <summary>
    /// The number of edges to use during the search phase.
    /// </summary>
    public long? EfSearch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ef_search");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ef_search", value);
        }
    }

    /// <summary>
    /// The number of bi-directional links created for each new element.
    /// </summary>
    public long? M
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("m");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("m", value);
        }
    }

    /// <summary>
    /// The type of vector to use.
    /// </summary>
    public ApiEnum<string, VectorType>? VectorType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VectorType>>("vector_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("vector_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DistanceMethod?.Validate();
        _ = this.EfConstruction;
        _ = this.EfSearch;
        _ = this.M;
        this.VectorType?.Validate();
    }

    public PgVectorHnswSettings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PgVectorHnswSettings(PgVectorHnswSettings pgVectorHnswSettings)
        : base(pgVectorHnswSettings) { }
#pragma warning restore CS8618

    public PgVectorHnswSettings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PgVectorHnswSettings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PgVectorHnswSettingsFromRaw.FromRawUnchecked"/>
    public static PgVectorHnswSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PgVectorHnswSettingsFromRaw : IFromRawJson<PgVectorHnswSettings>
{
    /// <inheritdoc/>
    public PgVectorHnswSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PgVectorHnswSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// The distance method to use.
/// </summary>
[JsonConverter(typeof(DistanceMethodConverter))]
public enum DistanceMethod
{
    Cosine,
    Hamming,
    IP,
    Jaccard,
    L1,
    L2,
}

sealed class DistanceMethodConverter : JsonConverter<DistanceMethod>
{
    public override DistanceMethod Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cosine" => DistanceMethod.Cosine,
            "hamming" => DistanceMethod.Hamming,
            "ip" => DistanceMethod.IP,
            "jaccard" => DistanceMethod.Jaccard,
            "l1" => DistanceMethod.L1,
            "l2" => DistanceMethod.L2,
            _ => (DistanceMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DistanceMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DistanceMethod.Cosine => "cosine",
                DistanceMethod.Hamming => "hamming",
                DistanceMethod.IP => "ip",
                DistanceMethod.Jaccard => "jaccard",
                DistanceMethod.L1 => "l1",
                DistanceMethod.L2 => "l2",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of vector to use.
/// </summary>
[JsonConverter(typeof(VectorTypeConverter))]
public enum VectorType
{
    Bit,
    HalfVec,
    SparseVec,
    Vector,
}

sealed class VectorTypeConverter : JsonConverter<VectorType>
{
    public override VectorType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "bit" => VectorType.Bit,
            "half_vec" => VectorType.HalfVec,
            "sparse_vec" => VectorType.SparseVec,
            "vector" => VectorType.Vector,
            _ => (VectorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VectorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VectorType.Bit => "bit",
                VectorType.HalfVec => "half_vec",
                VectorType.SparseVec => "sparse_vec",
                VectorType.Vector => "vector",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
