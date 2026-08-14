using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models.DataSources;

[JsonConverter(
    typeof(JsonModelConverter<
        DataSourceReaderVersionMetadata,
        DataSourceReaderVersionMetadataFromRaw
    >)
)]
public sealed record class DataSourceReaderVersionMetadata : JsonModel
{
    /// <summary>
    /// The version of the reader to use for this data source.
    /// </summary>
    public ApiEnum<string, ReaderVersion>? ReaderVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ReaderVersion>>("reader_version");
        }
        init { this._rawData.Set("reader_version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ReaderVersion?.Validate();
    }

    public DataSourceReaderVersionMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataSourceReaderVersionMetadata(
        DataSourceReaderVersionMetadata dataSourceReaderVersionMetadata
    )
        : base(dataSourceReaderVersionMetadata) { }
#pragma warning restore CS8618

    public DataSourceReaderVersionMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DataSourceReaderVersionMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataSourceReaderVersionMetadataFromRaw.FromRawUnchecked"/>
    public static DataSourceReaderVersionMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataSourceReaderVersionMetadataFromRaw : IFromRawJson<DataSourceReaderVersionMetadata>
{
    /// <inheritdoc/>
    public DataSourceReaderVersionMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DataSourceReaderVersionMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// The version of the reader to use for this data source.
/// </summary>
[JsonConverter(typeof(ReaderVersionConverter))]
public enum ReaderVersion
{
    V1_0,
    V2_0,
    V2_1,
}

sealed class ReaderVersionConverter : JsonConverter<ReaderVersion>
{
    public override ReaderVersion Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1.0" => ReaderVersion.V1_0,
            "2.0" => ReaderVersion.V2_0,
            "2.1" => ReaderVersion.V2_1,
            _ => (ReaderVersion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReaderVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReaderVersion.V1_0 => "1.0",
                ReaderVersion.V2_0 => "2.0",
                ReaderVersion.V2_1 => "2.1",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
