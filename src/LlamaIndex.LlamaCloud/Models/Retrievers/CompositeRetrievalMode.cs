using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Retrievers;

/// <summary>
/// Enum for the mode of composite retrieval.
/// </summary>
[JsonConverter(typeof(CompositeRetrievalModeConverter))]
public enum CompositeRetrievalMode
{
    Full,
    Routing,
}

sealed class CompositeRetrievalModeConverter : JsonConverter<CompositeRetrievalMode>
{
    public override CompositeRetrievalMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "full" => CompositeRetrievalMode.Full,
            "routing" => CompositeRetrievalMode.Routing,
            _ => (CompositeRetrievalMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CompositeRetrievalMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CompositeRetrievalMode.Full => "full",
                CompositeRetrievalMode.Routing => "routing",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
