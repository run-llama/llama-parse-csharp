using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.AgentData;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.AgentData;

public class AgentDataDeleteByQueryResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentDataDeleteByQueryResponse { DeletedCount = 0 };

        long expectedDeletedCount = 0;

        Assert.Equal(expectedDeletedCount, model.DeletedCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentDataDeleteByQueryResponse { DeletedCount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentDataDeleteByQueryResponse { DeletedCount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDeletedCount = 0;

        Assert.Equal(expectedDeletedCount, deserialized.DeletedCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentDataDeleteByQueryResponse { DeletedCount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentDataDeleteByQueryResponse { DeletedCount = 0 };

        AgentDataDeleteByQueryResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
