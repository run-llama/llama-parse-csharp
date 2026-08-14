using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using Parsing = LlamaCloud.Models.Parsing;

namespace LlamaCloud.Models.Classifier.Jobs;

/// <summary>
/// A classify job.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ClassifyJob, ClassifyJobFromRaw>))]
public sealed record class ClassifyJob : JsonModel
{
    /// <summary>
    /// Unique identifier
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
    /// The ID of the project
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
    /// The rules to classify the files
    /// </summary>
    public required IReadOnlyList<ClassifierRule> Rules
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ClassifierRule>>("rules");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ClassifierRule>>(
                "rules",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The status of the classify job
    /// </summary>
    public required ApiEnum<string, Parsing::StatusEnum> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Parsing::StatusEnum>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The ID of the user
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <summary>
    /// Creation datetime
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public DateTimeOffset? EffectiveAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("effective_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("effective_at", value);
        }
    }

    /// <summary>
    /// Error message for the latest job attempt, if any.
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
    /// The job record ID associated with this status, if any.
    /// </summary>
    public string? JobRecordID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("job_record_id");
        }
        init { this._rawData.Set("job_record_id", value); }
    }

    /// <summary>
    /// The classification mode to use
    /// </summary>
    public ApiEnum<string, ClassifyJobMode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ClassifyJobMode>>("mode");
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

    /// <summary>
    /// The configuration for the parsing job
    /// </summary>
    public ClassifyParsingConfiguration? ParsingConfiguration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ClassifyParsingConfiguration>(
                "parsing_configuration"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("parsing_configuration", value);
        }
    }

    /// <summary>
    /// Update datetime
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ProjectID;
        foreach (var item in this.Rules)
        {
            item.Validate();
        }
        this.Status.Validate();
        _ = this.UserID;
        _ = this.CreatedAt;
        _ = this.EffectiveAt;
        _ = this.ErrorMessage;
        _ = this.JobRecordID;
        this.Mode?.Validate();
        this.ParsingConfiguration?.Validate();
        _ = this.UpdatedAt;
    }

    public ClassifyJob() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClassifyJob(ClassifyJob classifyJob)
        : base(classifyJob) { }
#pragma warning restore CS8618

    public ClassifyJob(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClassifyJob(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClassifyJobFromRaw.FromRawUnchecked"/>
    public static ClassifyJob FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ClassifyJobFromRaw : IFromRawJson<ClassifyJob>
{
    /// <inheritdoc/>
    public ClassifyJob FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ClassifyJob.FromRawUnchecked(rawData);
}

/// <summary>
/// The classification mode to use
/// </summary>
[JsonConverter(typeof(ClassifyJobModeConverter))]
public enum ClassifyJobMode
{
    Fast,
    Multimodal,
}

sealed class ClassifyJobModeConverter : JsonConverter<ClassifyJobMode>
{
    public override ClassifyJobMode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FAST" => ClassifyJobMode.Fast,
            "MULTIMODAL" => ClassifyJobMode.Multimodal,
            _ => (ClassifyJobMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ClassifyJobMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ClassifyJobMode.Fast => "FAST",
                ClassifyJobMode.Multimodal => "MULTIMODAL",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
