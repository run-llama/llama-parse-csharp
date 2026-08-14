using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Parsing;

/// <summary>
/// Enum for representing the mode of parsing to be used.
/// </summary>
[JsonConverter(typeof(ParsingModeConverter))]
public enum ParsingMode
{
    ParseDocumentWithAgent,
    ParseDocumentWithLlm,
    ParseDocumentWithLvm,
    ParsePageWithAgent,
    ParsePageWithLayoutAgent,
    ParsePageWithLlm,
    ParsePageWithLvm,
    ParsePageWithoutLlm,
}

sealed class ParsingModeConverter : JsonConverter<ParsingMode>
{
    public override ParsingMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "parse_document_with_agent" => ParsingMode.ParseDocumentWithAgent,
            "parse_document_with_llm" => ParsingMode.ParseDocumentWithLlm,
            "parse_document_with_lvm" => ParsingMode.ParseDocumentWithLvm,
            "parse_page_with_agent" => ParsingMode.ParsePageWithAgent,
            "parse_page_with_layout_agent" => ParsingMode.ParsePageWithLayoutAgent,
            "parse_page_with_llm" => ParsingMode.ParsePageWithLlm,
            "parse_page_with_lvm" => ParsingMode.ParsePageWithLvm,
            "parse_page_without_llm" => ParsingMode.ParsePageWithoutLlm,
            _ => (ParsingMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ParsingMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ParsingMode.ParseDocumentWithAgent => "parse_document_with_agent",
                ParsingMode.ParseDocumentWithLlm => "parse_document_with_llm",
                ParsingMode.ParseDocumentWithLvm => "parse_document_with_lvm",
                ParsingMode.ParsePageWithAgent => "parse_page_with_agent",
                ParsingMode.ParsePageWithLayoutAgent => "parse_page_with_layout_agent",
                ParsingMode.ParsePageWithLlm => "parse_page_with_llm",
                ParsingMode.ParsePageWithLvm => "parse_page_with_lvm",
                ParsingMode.ParsePageWithoutLlm => "parse_page_without_llm",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
