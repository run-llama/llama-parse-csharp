using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Pipelines;

/// <summary>
/// Enum for representing the type of a pipeline
/// </summary>
[JsonConverter(typeof(PipelinePipelineTypeConverter))]
public enum PipelinePipelineType
{
    Managed,
    Playground,
}

sealed class PipelinePipelineTypeConverter : JsonConverter<PipelinePipelineType>
{
    public override PipelinePipelineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MANAGED" => PipelinePipelineType.Managed,
            "PLAYGROUND" => PipelinePipelineType.Playground,
            _ => (PipelinePipelineType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PipelinePipelineType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PipelinePipelineType.Managed => "MANAGED",
                PipelinePipelineType.Playground => "PLAYGROUND",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
