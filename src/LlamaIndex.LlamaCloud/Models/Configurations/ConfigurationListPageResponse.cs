using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Configurations;

/// <summary>
/// Paginated list of product configurations.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ConfigurationListPageResponse, ConfigurationListPageResponseFromRaw>)
)]
public sealed record class ConfigurationListPageResponse : JsonModel
{
    /// <summary>
    /// The list of items.
    /// </summary>
    public required IReadOnlyList<ConfigurationResponse> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ConfigurationResponse>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ConfigurationResponse>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A token, which can be sent as page_token to retrieve the next page. If this
    /// field is omitted, there are no subsequent pages.
    /// </summary>
    public string? NextPageToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_page_token");
        }
        init { this._rawData.Set("next_page_token", value); }
    }

    /// <summary>
    /// The total number of items available. This is only populated when specifically
    /// requested. The value may be an estimate and can be used for display purposes only.
    /// </summary>
    public long? TotalSize
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total_size");
        }
        init { this._rawData.Set("total_size", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.NextPageToken;
        _ = this.TotalSize;
    }

    public ConfigurationListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConfigurationListPageResponse(
        ConfigurationListPageResponse configurationListPageResponse
    )
        : base(configurationListPageResponse) { }
#pragma warning restore CS8618

    public ConfigurationListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConfigurationListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConfigurationListPageResponseFromRaw.FromRawUnchecked"/>
    public static ConfigurationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ConfigurationListPageResponse(IReadOnlyList<ConfigurationResponse> items)
        : this()
    {
        this.Items = items;
    }
}

class ConfigurationListPageResponseFromRaw : IFromRawJson<ConfigurationListPageResponse>
{
    /// <inheritdoc/>
    public ConfigurationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConfigurationListPageResponse.FromRawUnchecked(rawData);
}
