using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models;

[JsonConverter(typeof(JsonModelConverter<CloudSlackDataSource, CloudSlackDataSourceFromRaw>))]
public sealed record class CloudSlackDataSource : JsonModel
{
    /// <summary>
    /// Slack Bot Token.
    /// </summary>
    public required string SlackToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("slack_token");
        }
        init { this._rawData.Set("slack_token", value); }
    }

    /// <summary>
    /// Slack Channel.
    /// </summary>
    public string? ChannelIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("channel_ids");
        }
        init { this._rawData.Set("channel_ids", value); }
    }

    /// <summary>
    /// Slack Channel name pattern.
    /// </summary>
    public string? ChannelPatterns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("channel_patterns");
        }
        init { this._rawData.Set("channel_patterns", value); }
    }

    public string? ClassName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("class_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("class_name", value);
        }
    }

    /// <summary>
    /// Earliest date.
    /// </summary>
    public string? EarliestDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("earliest_date");
        }
        init { this._rawData.Set("earliest_date", value); }
    }

    /// <summary>
    /// Earliest date timestamp.
    /// </summary>
    public double? EarliestDateTimestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("earliest_date_timestamp");
        }
        init { this._rawData.Set("earliest_date_timestamp", value); }
    }

    /// <summary>
    /// Latest date.
    /// </summary>
    public string? LatestDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("latest_date");
        }
        init { this._rawData.Set("latest_date", value); }
    }

    /// <summary>
    /// Latest date timestamp.
    /// </summary>
    public double? LatestDateTimestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("latest_date_timestamp");
        }
        init { this._rawData.Set("latest_date_timestamp", value); }
    }

    public bool? SupportsAccessControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("supports_access_control");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("supports_access_control", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SlackToken;
        _ = this.ChannelIds;
        _ = this.ChannelPatterns;
        _ = this.ClassName;
        _ = this.EarliestDate;
        _ = this.EarliestDateTimestamp;
        _ = this.LatestDate;
        _ = this.LatestDateTimestamp;
        _ = this.SupportsAccessControl;
    }

    public CloudSlackDataSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudSlackDataSource(CloudSlackDataSource cloudSlackDataSource)
        : base(cloudSlackDataSource) { }
#pragma warning restore CS8618

    public CloudSlackDataSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudSlackDataSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudSlackDataSourceFromRaw.FromRawUnchecked"/>
    public static CloudSlackDataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CloudSlackDataSource(string slackToken)
        : this()
    {
        this.SlackToken = slackToken;
    }
}

class CloudSlackDataSourceFromRaw : IFromRawJson<CloudSlackDataSource>
{
    /// <inheritdoc/>
    public CloudSlackDataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CloudSlackDataSource.FromRawUnchecked(rawData);
}
