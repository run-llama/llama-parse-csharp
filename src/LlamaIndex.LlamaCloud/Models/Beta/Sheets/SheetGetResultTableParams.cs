using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;

namespace LlamaIndex.LlamaCloud.Models.Beta.Sheets;

/// <summary>
/// Generate a presigned URL to download a specific extracted region.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
[Obsolete("deprecated")]
public record class SheetGetResultTableParams : ParamsBase
{
    public required string SpreadsheetJobID { get; init; }

    public required string RegionID { get; init; }

    public ApiEnum<string, RegionType>? RegionType { get; init; }

    public long? ExpiresAtSeconds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("expires_at_seconds");
        }
        init { this._rawQueryData.Set("expires_at_seconds", value); }
    }

    public string? OrganizationID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("organization_id");
        }
        init { this._rawQueryData.Set("organization_id", value); }
    }

    public string? ProjectID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("project_id");
        }
        init { this._rawQueryData.Set("project_id", value); }
    }

    public SheetGetResultTableParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SheetGetResultTableParams(SheetGetResultTableParams sheetGetResultTableParams)
        : base(sheetGetResultTableParams)
    {
        this.SpreadsheetJobID = sheetGetResultTableParams.SpreadsheetJobID;
        this.RegionID = sheetGetResultTableParams.RegionID;
        this.RegionType = sheetGetResultTableParams.RegionType;
    }
#pragma warning restore CS8618

    public SheetGetResultTableParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SheetGetResultTableParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string spreadsheetJobID,
        string regionID,
        ApiEnum<string, RegionType> regionType
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.SpreadsheetJobID = spreadsheetJobID;
        this.RegionID = regionID;
        this.RegionType = regionType;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SheetGetResultTableParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string spreadsheetJobID,
        string regionID,
        ApiEnum<string, RegionType> regionType
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            spreadsheetJobID,
            regionID,
            regionType
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["SpreadsheetJobID"] = JsonSerializer.SerializeToElement(this.SpreadsheetJobID),
                    ["RegionID"] = JsonSerializer.SerializeToElement(this.RegionID),
                    ["RegionType"] = JsonSerializer.SerializeToElement(this.RegionType),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(SheetGetResultTableParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.SpreadsheetJobID.Equals(other.SpreadsheetJobID)
            && this.RegionID.Equals(other.RegionID)
            && (this.RegionType?.Equals(other.RegionType) ?? other.RegionType == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/api/v1/beta/sheets/jobs/{0}/regions/{1}/result/{2}",
                    this.SpreadsheetJobID,
                    this.RegionID,
                    this.RegionType?.Raw()
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(RegionTypeConverter))]
public enum RegionType
{
    CellMetadata,
    Extra,
    Table,
}

sealed class RegionTypeConverter : JsonConverter<RegionType>
{
    public override RegionType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cell_metadata" => RegionType.CellMetadata,
            "extra" => RegionType.Extra,
            "table" => RegionType.Table,
            _ => (RegionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RegionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RegionType.CellMetadata => "cell_metadata",
                RegionType.Extra => "extra",
                RegionType.Table => "table",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
