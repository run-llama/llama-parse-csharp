using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Parsing;

/// <summary>
/// Enum for representing the status of a job
/// </summary>
[JsonConverter(typeof(StatusEnumConverter))]
public enum StatusEnum
{
    Cancelled,
    Error,
    PartialSuccess,
    Pending,
    Success,
}

sealed class StatusEnumConverter : JsonConverter<StatusEnum>
{
    public override StatusEnum Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CANCELLED" => StatusEnum.Cancelled,
            "ERROR" => StatusEnum.Error,
            "PARTIAL_SUCCESS" => StatusEnum.PartialSuccess,
            "PENDING" => StatusEnum.Pending,
            "SUCCESS" => StatusEnum.Success,
            _ => (StatusEnum)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StatusEnum value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StatusEnum.Cancelled => "CANCELLED",
                StatusEnum.Error => "ERROR",
                StatusEnum.PartialSuccess => "PARTIAL_SUCCESS",
                StatusEnum.Pending => "PENDING",
                StatusEnum.Success => "SUCCESS",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
