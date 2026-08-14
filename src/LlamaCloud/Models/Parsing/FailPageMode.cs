using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Parsing;

/// <summary>
/// Enum for representing the different available page error handling modes.
/// </summary>
[JsonConverter(typeof(FailPageModeConverter))]
public enum FailPageMode
{
    BlankPage,
    ErrorMessage,
    RawText,
}

sealed class FailPageModeConverter : JsonConverter<FailPageMode>
{
    public override FailPageMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "blank_page" => FailPageMode.BlankPage,
            "error_message" => FailPageMode.ErrorMessage,
            "raw_text" => FailPageMode.RawText,
            _ => (FailPageMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FailPageMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FailPageMode.BlankPage => "blank_page",
                FailPageMode.ErrorMessage => "error_message",
                FailPageMode.RawText => "raw_text",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
