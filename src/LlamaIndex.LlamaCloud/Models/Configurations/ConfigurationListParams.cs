using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;

namespace LlamaIndex.LlamaCloud.Models.Configurations;

/// <summary>
/// List product configurations for the current project.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ConfigurationListParams : ParamsBase
{
    /// <summary>
    /// Return only the latest version per configuration name.
    /// </summary>
    public bool? LatestOnly
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>("latest_only");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("latest_only", value);
        }
    }

    /// <summary>
    /// Filter by configuration name.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("name");
        }
        init { this._rawQueryData.Set("name", value); }
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

    /// <summary>
    /// Number of items per page.
    /// </summary>
    public long? PageSize
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("page_size");
        }
        init { this._rawQueryData.Set("page_size", value); }
    }

    /// <summary>
    /// Pagination token.
    /// </summary>
    public string? PageToken
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("page_token");
        }
        init { this._rawQueryData.Set("page_token", value); }
    }

    /// <summary>
    /// Filter by one or more product types. Repeat the parameter for multiple values.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, ProductType>>? ProductType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, ProductType>>
            >("product_type");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<ApiEnum<string, ProductType>>?>(
                "product_type",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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

    public ConfigurationListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConfigurationListParams(ConfigurationListParams configurationListParams)
        : base(configurationListParams) { }
#pragma warning restore CS8618

    public ConfigurationListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConfigurationListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ConfigurationListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(ConfigurationListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/beta/configurations"
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

[JsonConverter(typeof(ProductTypeConverter))]
public enum ProductType
{
    ClassifyV2,
    ExtractV2,
    ParseV2,
    SplitV1,
    SpreadsheetV1,
    Unknown,
}

sealed class ProductTypeConverter : JsonConverter<ProductType>
{
    public override ProductType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "classify_v2" => ProductType.ClassifyV2,
            "extract_v2" => ProductType.ExtractV2,
            "parse_v2" => ProductType.ParseV2,
            "split_v1" => ProductType.SplitV1,
            "spreadsheet_v1" => ProductType.SpreadsheetV1,
            "unknown" => ProductType.Unknown,
            _ => (ProductType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ProductType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ProductType.ClassifyV2 => "classify_v2",
                ProductType.ExtractV2 => "extract_v2",
                ProductType.ParseV2 => "parse_v2",
                ProductType.SplitV1 => "split_v1",
                ProductType.SpreadsheetV1 => "spreadsheet_v1",
                ProductType.Unknown => "unknown",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
