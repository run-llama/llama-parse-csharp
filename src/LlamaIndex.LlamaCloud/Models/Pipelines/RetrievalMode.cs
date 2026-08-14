using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Pipelines;

[JsonConverter(typeof(RetrievalModeConverter))]
public enum RetrievalMode
{
    AutoRouted,
    Chunks,
    FilesViaContent,
    FilesViaMetadata,
}

sealed class RetrievalModeConverter : JsonConverter<RetrievalMode>
{
    public override RetrievalMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto_routed" => RetrievalMode.AutoRouted,
            "chunks" => RetrievalMode.Chunks,
            "files_via_content" => RetrievalMode.FilesViaContent,
            "files_via_metadata" => RetrievalMode.FilesViaMetadata,
            _ => (RetrievalMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RetrievalMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RetrievalMode.AutoRouted => "auto_routed",
                RetrievalMode.Chunks => "chunks",
                RetrievalMode.FilesViaContent => "files_via_content",
                RetrievalMode.FilesViaMetadata => "files_via_metadata",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
