using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Tests.Models.Pipelines;

public class AutoTransformConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutoTransformConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = AutoTransformConfigMode.Auto,
        };

        long expectedChunkOverlap = 0;
        long expectedChunkSize = 1;
        ApiEnum<string, AutoTransformConfigMode> expectedMode = AutoTransformConfigMode.Auto;

        Assert.Equal(expectedChunkOverlap, model.ChunkOverlap);
        Assert.Equal(expectedChunkSize, model.ChunkSize);
        Assert.Equal(expectedMode, model.Mode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutoTransformConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = AutoTransformConfigMode.Auto,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutoTransformConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutoTransformConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = AutoTransformConfigMode.Auto,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutoTransformConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedChunkOverlap = 0;
        long expectedChunkSize = 1;
        ApiEnum<string, AutoTransformConfigMode> expectedMode = AutoTransformConfigMode.Auto;

        Assert.Equal(expectedChunkOverlap, deserialized.ChunkOverlap);
        Assert.Equal(expectedChunkSize, deserialized.ChunkSize);
        Assert.Equal(expectedMode, deserialized.Mode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutoTransformConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = AutoTransformConfigMode.Auto,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AutoTransformConfig { };

        Assert.Null(model.ChunkOverlap);
        Assert.False(model.RawData.ContainsKey("chunk_overlap"));
        Assert.Null(model.ChunkSize);
        Assert.False(model.RawData.ContainsKey("chunk_size"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AutoTransformConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AutoTransformConfig
        {
            // Null should be interpreted as omitted for these properties
            ChunkOverlap = null,
            ChunkSize = null,
            Mode = null,
        };

        Assert.Null(model.ChunkOverlap);
        Assert.False(model.RawData.ContainsKey("chunk_overlap"));
        Assert.Null(model.ChunkSize);
        Assert.False(model.RawData.ContainsKey("chunk_size"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AutoTransformConfig
        {
            // Null should be interpreted as omitted for these properties
            ChunkOverlap = null,
            ChunkSize = null,
            Mode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutoTransformConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = AutoTransformConfigMode.Auto,
        };

        AutoTransformConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AutoTransformConfigModeTest : TestBase
{
    [Theory]
    [InlineData(AutoTransformConfigMode.Auto)]
    public void Validation_Works(AutoTransformConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutoTransformConfigMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutoTransformConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AutoTransformConfigMode.Auto)]
    public void SerializationRoundtrip_Works(AutoTransformConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AutoTransformConfigMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AutoTransformConfigMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AutoTransformConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AutoTransformConfigMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
