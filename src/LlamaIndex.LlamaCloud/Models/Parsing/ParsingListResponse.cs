using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Parsing;

/// <summary>
/// A parse job.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ParsingListResponse, ParsingListResponseFromRaw>))]
public sealed record class ParsingListResponse : JsonModel
{
    /// <summary>
    /// Unique parse job identifier
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
    /// Project this job belongs to
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
    /// Current job status: PENDING, RUNNING, COMPLETED, FAILED, or CANCELLED
    /// </summary>
    public required ApiEnum<string, ParsingListResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ParsingListResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Creation datetime
    /// </summary>
    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Error details when status is FAILED
    /// </summary>
    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_message");
        }
        init { this._rawData.Set("error_message", value); }
    }

    /// <summary>
    /// Optional display name for this parse job
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Parsing tier used for this job
    /// </summary>
    public string? Tier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tier");
        }
        init { this._rawData.Set("tier", value); }
    }

    /// <summary>
    /// Update datetime
    /// </summary>
    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Usage recorded against a job.
    /// </summary>
    public ParsingListResponseUsage? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ParsingListResponseUsage>("usage");
        }
        init { this._rawData.Set("usage", value); }
    }

    /// <summary>
    /// Key/value tags associated with this job.
    /// </summary>
    public IReadOnlyDictionary<string, string>? UserMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "user_metadata"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "user_metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ProjectID;
        this.Status.Validate();
        _ = this.CreatedAt;
        _ = this.ErrorMessage;
        _ = this.Name;
        _ = this.Tier;
        _ = this.UpdatedAt;
        this.Usage?.Validate();
        _ = this.UserMetadata;
    }

    public ParsingListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingListResponse(ParsingListResponse parsingListResponse)
        : base(parsingListResponse) { }
#pragma warning restore CS8618

    public ParsingListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsingListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParsingListResponseFromRaw.FromRawUnchecked"/>
    public static ParsingListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParsingListResponseFromRaw : IFromRawJson<ParsingListResponse>
{
    /// <inheritdoc/>
    public ParsingListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ParsingListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Current job status: PENDING, RUNNING, COMPLETED, FAILED, or CANCELLED
/// </summary>
[JsonConverter(typeof(ParsingListResponseStatusConverter))]
public enum ParsingListResponseStatus
{
    Cancelled,
    Completed,
    Failed,
    Pending,
    Running,
}

sealed class ParsingListResponseStatusConverter : JsonConverter<ParsingListResponseStatus>
{
    public override ParsingListResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CANCELLED" => ParsingListResponseStatus.Cancelled,
            "COMPLETED" => ParsingListResponseStatus.Completed,
            "FAILED" => ParsingListResponseStatus.Failed,
            "PENDING" => ParsingListResponseStatus.Pending,
            "RUNNING" => ParsingListResponseStatus.Running,
            _ => (ParsingListResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ParsingListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ParsingListResponseStatus.Cancelled => "CANCELLED",
                ParsingListResponseStatus.Completed => "COMPLETED",
                ParsingListResponseStatus.Failed => "FAILED",
                ParsingListResponseStatus.Pending => "PENDING",
                ParsingListResponseStatus.Running => "RUNNING",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Usage recorded against a job.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ParsingListResponseUsage, ParsingListResponseUsageFromRaw>)
)]
public sealed record class ParsingListResponseUsage : JsonModel
{
    /// <summary>
    /// Total credits billed against this job. Null until billing has recorded it.
    /// </summary>
    public double? Credits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("credits");
        }
        init { this._rawData.Set("credits", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Credits;
    }

    public ParsingListResponseUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingListResponseUsage(ParsingListResponseUsage parsingListResponseUsage)
        : base(parsingListResponseUsage) { }
#pragma warning restore CS8618

    public ParsingListResponseUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsingListResponseUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParsingListResponseUsageFromRaw.FromRawUnchecked"/>
    public static ParsingListResponseUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParsingListResponseUsageFromRaw : IFromRawJson<ParsingListResponseUsage>
{
    /// <inheritdoc/>
    public ParsingListResponseUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ParsingListResponseUsage.FromRawUnchecked(rawData);
}
