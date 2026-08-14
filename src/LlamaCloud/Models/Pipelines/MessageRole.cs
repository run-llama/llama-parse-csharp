using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Pipelines;

/// <summary>
/// Message role.
/// </summary>
[JsonConverter(typeof(MessageRoleConverter))]
public enum MessageRole
{
    Assistant,
    Chatbot,
    Developer,
    Function,
    Model,
    System,
    Tool,
    User,
}

sealed class MessageRoleConverter : JsonConverter<MessageRole>
{
    public override MessageRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "assistant" => MessageRole.Assistant,
            "chatbot" => MessageRole.Chatbot,
            "developer" => MessageRole.Developer,
            "function" => MessageRole.Function,
            "model" => MessageRole.Model,
            "system" => MessageRole.System,
            "tool" => MessageRole.Tool,
            "user" => MessageRole.User,
            _ => (MessageRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MessageRole.Assistant => "assistant",
                MessageRole.Chatbot => "chatbot",
                MessageRole.Developer => "developer",
                MessageRole.Function => "function",
                MessageRole.Model => "model",
                MessageRole.System => "system",
                MessageRole.Tool => "tool",
                MessageRole.User => "user",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
