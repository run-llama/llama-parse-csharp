using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Pipelines;

[JsonConverter(typeof(JsonModelConverter<AutoTransformConfig, AutoTransformConfigFromRaw>))]
public sealed record class AutoTransformConfig : JsonModel
{
    /// <summary>
    /// Chunk overlap for the transformation.
    /// </summary>
    public long? ChunkOverlap
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chunk_overlap");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chunk_overlap", value);
        }
    }

    /// <summary>
    /// Chunk size for the transformation.
    /// </summary>
    public long? ChunkSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("chunk_size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("chunk_size", value);
        }
    }

    public ApiEnum<string, AutoTransformConfigMode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AutoTransformConfigMode>>("mode");
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChunkOverlap;
        _ = this.ChunkSize;
        this.Mode?.Validate();
    }

    public AutoTransformConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutoTransformConfig(AutoTransformConfig autoTransformConfig)
        : base(autoTransformConfig) { }
#pragma warning restore CS8618

    public AutoTransformConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutoTransformConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AutoTransformConfigFromRaw.FromRawUnchecked"/>
    public static AutoTransformConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AutoTransformConfigFromRaw : IFromRawJson<AutoTransformConfig>
{
    /// <inheritdoc/>
    public AutoTransformConfig FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AutoTransformConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AutoTransformConfigModeConverter))]
public enum AutoTransformConfigMode
{
    Auto,
}

sealed class AutoTransformConfigModeConverter : JsonConverter<AutoTransformConfigMode>
{
    public override AutoTransformConfigMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => AutoTransformConfigMode.Auto,
            _ => (AutoTransformConfigMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AutoTransformConfigMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AutoTransformConfigMode.Auto => "auto",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
