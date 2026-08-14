using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Parsing;

/// <summary>
/// A parse job.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ParsingCancelResponse, ParsingCancelResponseFromRaw>))]
public sealed record class ParsingCancelResponse : JsonModel
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
    public required ApiEnum<string, ParsingCancelResponseStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ParsingCancelResponseStatus>>(
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
    public ParsingCancelResponseUsage? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ParsingCancelResponseUsage>("usage");
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

    public ParsingCancelResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingCancelResponse(ParsingCancelResponse parsingCancelResponse)
        : base(parsingCancelResponse) { }
#pragma warning restore CS8618

    public ParsingCancelResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsingCancelResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParsingCancelResponseFromRaw.FromRawUnchecked"/>
    public static ParsingCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParsingCancelResponseFromRaw : IFromRawJson<ParsingCancelResponse>
{
    /// <inheritdoc/>
    public ParsingCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ParsingCancelResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Current job status: PENDING, RUNNING, COMPLETED, FAILED, or CANCELLED
/// </summary>
[JsonConverter(typeof(ParsingCancelResponseStatusConverter))]
public enum ParsingCancelResponseStatus
{
    Cancelled,
    Completed,
    Failed,
    Pending,
    Running,
}

sealed class ParsingCancelResponseStatusConverter : JsonConverter<ParsingCancelResponseStatus>
{
    public override ParsingCancelResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CANCELLED" => ParsingCancelResponseStatus.Cancelled,
            "COMPLETED" => ParsingCancelResponseStatus.Completed,
            "FAILED" => ParsingCancelResponseStatus.Failed,
            "PENDING" => ParsingCancelResponseStatus.Pending,
            "RUNNING" => ParsingCancelResponseStatus.Running,
            _ => (ParsingCancelResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ParsingCancelResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ParsingCancelResponseStatus.Cancelled => "CANCELLED",
                ParsingCancelResponseStatus.Completed => "COMPLETED",
                ParsingCancelResponseStatus.Failed => "FAILED",
                ParsingCancelResponseStatus.Pending => "PENDING",
                ParsingCancelResponseStatus.Running => "RUNNING",
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
    typeof(JsonModelConverter<ParsingCancelResponseUsage, ParsingCancelResponseUsageFromRaw>)
)]
public sealed record class ParsingCancelResponseUsage : JsonModel
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

    public ParsingCancelResponseUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingCancelResponseUsage(ParsingCancelResponseUsage parsingCancelResponseUsage)
        : base(parsingCancelResponseUsage) { }
#pragma warning restore CS8618

    public ParsingCancelResponseUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsingCancelResponseUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParsingCancelResponseUsageFromRaw.FromRawUnchecked"/>
    public static ParsingCancelResponseUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ParsingCancelResponseUsageFromRaw : IFromRawJson<ParsingCancelResponseUsage>
{
    /// <inheritdoc/>
    public ParsingCancelResponseUsage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ParsingCancelResponseUsage.FromRawUnchecked(rawData);
}
