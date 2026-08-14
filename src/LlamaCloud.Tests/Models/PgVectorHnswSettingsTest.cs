using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models;

namespace LlamaCloud.Tests.Models;

public class PgVectorHnswSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PgVectorHnswSettings
        {
            DistanceMethod = DistanceMethod.Cosine,
            EfConstruction = 1,
            EfSearch = 1,
            M = 1,
            VectorType = VectorType.Bit,
        };

        ApiEnum<string, DistanceMethod> expectedDistanceMethod = DistanceMethod.Cosine;
        long expectedEfConstruction = 1;
        long expectedEfSearch = 1;
        long expectedM = 1;
        ApiEnum<string, VectorType> expectedVectorType = VectorType.Bit;

        Assert.Equal(expectedDistanceMethod, model.DistanceMethod);
        Assert.Equal(expectedEfConstruction, model.EfConstruction);
        Assert.Equal(expectedEfSearch, model.EfSearch);
        Assert.Equal(expectedM, model.M);
        Assert.Equal(expectedVectorType, model.VectorType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PgVectorHnswSettings
        {
            DistanceMethod = DistanceMethod.Cosine,
            EfConstruction = 1,
            EfSearch = 1,
            M = 1,
            VectorType = VectorType.Bit,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PgVectorHnswSettings>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PgVectorHnswSettings
        {
            DistanceMethod = DistanceMethod.Cosine,
            EfConstruction = 1,
            EfSearch = 1,
            M = 1,
            VectorType = VectorType.Bit,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PgVectorHnswSettings>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, DistanceMethod> expectedDistanceMethod = DistanceMethod.Cosine;
        long expectedEfConstruction = 1;
        long expectedEfSearch = 1;
        long expectedM = 1;
        ApiEnum<string, VectorType> expectedVectorType = VectorType.Bit;

        Assert.Equal(expectedDistanceMethod, deserialized.DistanceMethod);
        Assert.Equal(expectedEfConstruction, deserialized.EfConstruction);
        Assert.Equal(expectedEfSearch, deserialized.EfSearch);
        Assert.Equal(expectedM, deserialized.M);
        Assert.Equal(expectedVectorType, deserialized.VectorType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PgVectorHnswSettings
        {
            DistanceMethod = DistanceMethod.Cosine,
            EfConstruction = 1,
            EfSearch = 1,
            M = 1,
            VectorType = VectorType.Bit,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PgVectorHnswSettings { };

        Assert.Null(model.DistanceMethod);
        Assert.False(model.RawData.ContainsKey("distance_method"));
        Assert.Null(model.EfConstruction);
        Assert.False(model.RawData.ContainsKey("ef_construction"));
        Assert.Null(model.EfSearch);
        Assert.False(model.RawData.ContainsKey("ef_search"));
        Assert.Null(model.M);
        Assert.False(model.RawData.ContainsKey("m"));
        Assert.Null(model.VectorType);
        Assert.False(model.RawData.ContainsKey("vector_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PgVectorHnswSettings { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PgVectorHnswSettings
        {
            // Null should be interpreted as omitted for these properties
            DistanceMethod = null,
            EfConstruction = null,
            EfSearch = null,
            M = null,
            VectorType = null,
        };

        Assert.Null(model.DistanceMethod);
        Assert.False(model.RawData.ContainsKey("distance_method"));
        Assert.Null(model.EfConstruction);
        Assert.False(model.RawData.ContainsKey("ef_construction"));
        Assert.Null(model.EfSearch);
        Assert.False(model.RawData.ContainsKey("ef_search"));
        Assert.Null(model.M);
        Assert.False(model.RawData.ContainsKey("m"));
        Assert.Null(model.VectorType);
        Assert.False(model.RawData.ContainsKey("vector_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PgVectorHnswSettings
        {
            // Null should be interpreted as omitted for these properties
            DistanceMethod = null,
            EfConstruction = null,
            EfSearch = null,
            M = null,
            VectorType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PgVectorHnswSettings
        {
            DistanceMethod = DistanceMethod.Cosine,
            EfConstruction = 1,
            EfSearch = 1,
            M = 1,
            VectorType = VectorType.Bit,
        };

        PgVectorHnswSettings copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DistanceMethodTest : TestBase
{
    [Theory]
    [InlineData(DistanceMethod.Cosine)]
    [InlineData(DistanceMethod.Hamming)]
    [InlineData(DistanceMethod.IP)]
    [InlineData(DistanceMethod.Jaccard)]
    [InlineData(DistanceMethod.L1)]
    [InlineData(DistanceMethod.L2)]
    public void Validation_Works(DistanceMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DistanceMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DistanceMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DistanceMethod.Cosine)]
    [InlineData(DistanceMethod.Hamming)]
    [InlineData(DistanceMethod.IP)]
    [InlineData(DistanceMethod.Jaccard)]
    [InlineData(DistanceMethod.L1)]
    [InlineData(DistanceMethod.L2)]
    public void SerializationRoundtrip_Works(DistanceMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DistanceMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DistanceMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DistanceMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DistanceMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VectorTypeTest : TestBase
{
    [Theory]
    [InlineData(VectorType.Bit)]
    [InlineData(VectorType.HalfVec)]
    [InlineData(VectorType.SparseVec)]
    [InlineData(VectorType.Vector)]
    public void Validation_Works(VectorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VectorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VectorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VectorType.Bit)]
    [InlineData(VectorType.HalfVec)]
    [InlineData(VectorType.SparseVec)]
    [InlineData(VectorType.Vector)]
    public void SerializationRoundtrip_Works(VectorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VectorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VectorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VectorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VectorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
