using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Pipelines;

/// <summary>
/// Enum for representing the type of a pipeline
/// </summary>
[JsonConverter(typeof(PipelineTypeConverter))]
public enum PipelineType
{
    Managed,
    Playground,
}

sealed class PipelineTypeConverter : JsonConverter<PipelineType>
{
    public override PipelineType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MANAGED" => PipelineType.Managed,
            "PLAYGROUND" => PipelineType.Playground,
            _ => (PipelineType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PipelineType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PipelineType.Managed => "MANAGED",
                PipelineType.Playground => "PLAYGROUND",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
