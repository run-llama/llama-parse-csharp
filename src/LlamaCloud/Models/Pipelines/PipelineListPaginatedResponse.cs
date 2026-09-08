using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Pipelines;

/// <summary>
/// A pipeline in a project.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PipelineListPaginatedResponse, PipelineListPaginatedResponseFromRaw>)
)]
public sealed record class PipelineListPaginatedResponse : JsonModel
{
    /// <summary>
    /// The pipeline's unique identifier.
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
    /// The pipeline's display name.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The pipeline's type.
    /// </summary>
    public required ApiEnum<string, PipelineListPaginatedResponsePipelineType> PipelineType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, PipelineListPaginatedResponsePipelineType>
            >("pipeline_type");
        }
        init { this._rawData.Set("pipeline_type", value); }
    }

    /// <summary>
    /// The project the pipeline belongs to.
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
    /// The pipeline's current status.
    /// </summary>
    public ApiEnum<string, PipelineListPaginatedResponseStatus>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, PipelineListPaginatedResponseStatus>
            >("status");
        }
        init { this._rawData.Set("status", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
        this.PipelineType.Validate();
        _ = this.ProjectID;
        _ = this.CreatedAt;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public PipelineListPaginatedResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PipelineListPaginatedResponse(
        PipelineListPaginatedResponse pipelineListPaginatedResponse
    )
        : base(pipelineListPaginatedResponse) { }
#pragma warning restore CS8618

    public PipelineListPaginatedResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PipelineListPaginatedResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PipelineListPaginatedResponseFromRaw.FromRawUnchecked"/>
    public static PipelineListPaginatedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PipelineListPaginatedResponseFromRaw : IFromRawJson<PipelineListPaginatedResponse>
{
    /// <inheritdoc/>
    public PipelineListPaginatedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PipelineListPaginatedResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The pipeline's type.
/// </summary>
[JsonConverter(typeof(PipelineListPaginatedResponsePipelineTypeConverter))]
public enum PipelineListPaginatedResponsePipelineType
{
    Managed,
    Playground,
}

sealed class PipelineListPaginatedResponsePipelineTypeConverter
    : JsonConverter<PipelineListPaginatedResponsePipelineType>
{
    public override PipelineListPaginatedResponsePipelineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MANAGED" => PipelineListPaginatedResponsePipelineType.Managed,
            "PLAYGROUND" => PipelineListPaginatedResponsePipelineType.Playground,
            _ => (PipelineListPaginatedResponsePipelineType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PipelineListPaginatedResponsePipelineType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PipelineListPaginatedResponsePipelineType.Managed => "MANAGED",
                PipelineListPaginatedResponsePipelineType.Playground => "PLAYGROUND",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The pipeline's current status.
/// </summary>
[JsonConverter(typeof(PipelineListPaginatedResponseStatusConverter))]
public enum PipelineListPaginatedResponseStatus
{
    Created,
    Deleting,
}

sealed class PipelineListPaginatedResponseStatusConverter
    : JsonConverter<PipelineListPaginatedResponseStatus>
{
    public override PipelineListPaginatedResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CREATED" => PipelineListPaginatedResponseStatus.Created,
            "DELETING" => PipelineListPaginatedResponseStatus.Deleting,
            _ => (PipelineListPaginatedResponseStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PipelineListPaginatedResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PipelineListPaginatedResponseStatus.Created => "CREATED",
                PipelineListPaginatedResponseStatus.Deleting => "DELETING",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
