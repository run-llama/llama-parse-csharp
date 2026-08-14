using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class SparseModelConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SparseModelConfig { ClassName = "class_name", ModelType = ModelType.Auto };

        string expectedClassName = "class_name";
        ApiEnum<string, ModelType> expectedModelType = ModelType.Auto;

        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedModelType, model.ModelType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SparseModelConfig { ClassName = "class_name", ModelType = ModelType.Auto };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SparseModelConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SparseModelConfig { ClassName = "class_name", ModelType = ModelType.Auto };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SparseModelConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClassName = "class_name";
        ApiEnum<string, ModelType> expectedModelType = ModelType.Auto;

        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedModelType, deserialized.ModelType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SparseModelConfig { ClassName = "class_name", ModelType = ModelType.Auto };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SparseModelConfig { };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.ModelType);
        Assert.False(model.RawData.ContainsKey("model_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SparseModelConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SparseModelConfig
        {
            // Null should be interpreted as omitted for these properties
            ClassName = null,
            ModelType = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.ModelType);
        Assert.False(model.RawData.ContainsKey("model_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SparseModelConfig
        {
            // Null should be interpreted as omitted for these properties
            ClassName = null,
            ModelType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SparseModelConfig { ClassName = "class_name", ModelType = ModelType.Auto };

        SparseModelConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModelTypeTest : TestBase
{
    [Theory]
    [InlineData(ModelType.Auto)]
    [InlineData(ModelType.Bm25)]
    [InlineData(ModelType.Splade)]
    public void Validation_Works(ModelType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ModelType.Auto)]
    [InlineData(ModelType.Bm25)]
    [InlineData(ModelType.Splade)]
    public void SerializationRoundtrip_Works(ModelType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ModelType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ModelType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ModelType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
