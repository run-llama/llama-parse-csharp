using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Configurations;

namespace LlamaCloud.Tests.Models.Configurations;

public class UntypedParametersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UntypedParameters { };

        JsonElement expectedProductType = JsonSerializer.SerializeToElement("unknown");

        Assert.True(JsonElement.DeepEquals(expectedProductType, model.ProductType));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UntypedParameters { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UntypedParameters>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UntypedParameters { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UntypedParameters>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedProductType = JsonSerializer.SerializeToElement("unknown");

        Assert.True(JsonElement.DeepEquals(expectedProductType, deserialized.ProductType));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UntypedParameters { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UntypedParameters { };

        UntypedParameters copied = new(model);

        Assert.Equal(model, copied);
    }
}
