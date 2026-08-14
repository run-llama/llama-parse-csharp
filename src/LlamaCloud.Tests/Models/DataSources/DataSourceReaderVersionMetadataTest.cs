using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.DataSources;

namespace LlamaCloud.Tests.Models.DataSources;

public class DataSourceReaderVersionMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataSourceReaderVersionMetadata { ReaderVersion = ReaderVersion.V1_0 };

        ApiEnum<string, ReaderVersion> expectedReaderVersion = ReaderVersion.V1_0;

        Assert.Equal(expectedReaderVersion, model.ReaderVersion);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataSourceReaderVersionMetadata { ReaderVersion = ReaderVersion.V1_0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceReaderVersionMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataSourceReaderVersionMetadata { ReaderVersion = ReaderVersion.V1_0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceReaderVersionMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ReaderVersion> expectedReaderVersion = ReaderVersion.V1_0;

        Assert.Equal(expectedReaderVersion, deserialized.ReaderVersion);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataSourceReaderVersionMetadata { ReaderVersion = ReaderVersion.V1_0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DataSourceReaderVersionMetadata { };

        Assert.Null(model.ReaderVersion);
        Assert.False(model.RawData.ContainsKey("reader_version"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DataSourceReaderVersionMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DataSourceReaderVersionMetadata { ReaderVersion = null };

        Assert.Null(model.ReaderVersion);
        Assert.True(model.RawData.ContainsKey("reader_version"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DataSourceReaderVersionMetadata { ReaderVersion = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataSourceReaderVersionMetadata { ReaderVersion = ReaderVersion.V1_0 };

        DataSourceReaderVersionMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReaderVersionTest : TestBase
{
    [Theory]
    [InlineData(ReaderVersion.V1_0)]
    [InlineData(ReaderVersion.V2_0)]
    [InlineData(ReaderVersion.V2_1)]
    public void Validation_Works(ReaderVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReaderVersion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ReaderVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ReaderVersion.V1_0)]
    [InlineData(ReaderVersion.V2_0)]
    [InlineData(ReaderVersion.V2_1)]
    public void SerializationRoundtrip_Works(ReaderVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReaderVersion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ReaderVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ReaderVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ReaderVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
