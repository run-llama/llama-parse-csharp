using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class ParsingListVersionsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ParsingListVersionsResponse
        {
            Agentic = [Agentic.V2026_08_19],
            AgenticPlus = [AgenticPlus.V2026_08_19],
            CostEffective = [CostEffective.V2026_08_19],
            Fast = [Fast.V2026_06_15],
        };

        List<ApiEnum<string, Agentic>> expectedAgentic = [Agentic.V2026_08_19];
        List<ApiEnum<string, AgenticPlus>> expectedAgenticPlus = [AgenticPlus.V2026_08_19];
        List<ApiEnum<string, CostEffective>> expectedCostEffective = [CostEffective.V2026_08_19];
        List<ApiEnum<string, Fast>> expectedFast = [Fast.V2026_06_15];

        Assert.Equal(expectedAgentic.Count, model.Agentic.Count);
        for (int i = 0; i < expectedAgentic.Count; i++)
        {
            Assert.Equal(expectedAgentic[i], model.Agentic[i]);
        }
        Assert.Equal(expectedAgenticPlus.Count, model.AgenticPlus.Count);
        for (int i = 0; i < expectedAgenticPlus.Count; i++)
        {
            Assert.Equal(expectedAgenticPlus[i], model.AgenticPlus[i]);
        }
        Assert.Equal(expectedCostEffective.Count, model.CostEffective.Count);
        for (int i = 0; i < expectedCostEffective.Count; i++)
        {
            Assert.Equal(expectedCostEffective[i], model.CostEffective[i]);
        }
        Assert.Equal(expectedFast.Count, model.Fast.Count);
        for (int i = 0; i < expectedFast.Count; i++)
        {
            Assert.Equal(expectedFast[i], model.Fast[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ParsingListVersionsResponse
        {
            Agentic = [Agentic.V2026_08_19],
            AgenticPlus = [AgenticPlus.V2026_08_19],
            CostEffective = [CostEffective.V2026_08_19],
            Fast = [Fast.V2026_06_15],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsingListVersionsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ParsingListVersionsResponse
        {
            Agentic = [Agentic.V2026_08_19],
            AgenticPlus = [AgenticPlus.V2026_08_19],
            CostEffective = [CostEffective.V2026_08_19],
            Fast = [Fast.V2026_06_15],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsingListVersionsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ApiEnum<string, Agentic>> expectedAgentic = [Agentic.V2026_08_19];
        List<ApiEnum<string, AgenticPlus>> expectedAgenticPlus = [AgenticPlus.V2026_08_19];
        List<ApiEnum<string, CostEffective>> expectedCostEffective = [CostEffective.V2026_08_19];
        List<ApiEnum<string, Fast>> expectedFast = [Fast.V2026_06_15];

        Assert.Equal(expectedAgentic.Count, deserialized.Agentic.Count);
        for (int i = 0; i < expectedAgentic.Count; i++)
        {
            Assert.Equal(expectedAgentic[i], deserialized.Agentic[i]);
        }
        Assert.Equal(expectedAgenticPlus.Count, deserialized.AgenticPlus.Count);
        for (int i = 0; i < expectedAgenticPlus.Count; i++)
        {
            Assert.Equal(expectedAgenticPlus[i], deserialized.AgenticPlus[i]);
        }
        Assert.Equal(expectedCostEffective.Count, deserialized.CostEffective.Count);
        for (int i = 0; i < expectedCostEffective.Count; i++)
        {
            Assert.Equal(expectedCostEffective[i], deserialized.CostEffective[i]);
        }
        Assert.Equal(expectedFast.Count, deserialized.Fast.Count);
        for (int i = 0; i < expectedFast.Count; i++)
        {
            Assert.Equal(expectedFast[i], deserialized.Fast[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ParsingListVersionsResponse
        {
            Agentic = [Agentic.V2026_08_19],
            AgenticPlus = [AgenticPlus.V2026_08_19],
            CostEffective = [CostEffective.V2026_08_19],
            Fast = [Fast.V2026_06_15],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ParsingListVersionsResponse
        {
            Agentic = [Agentic.V2026_08_19],
            AgenticPlus = [AgenticPlus.V2026_08_19],
            CostEffective = [CostEffective.V2026_08_19],
            Fast = [Fast.V2026_06_15],
        };

        ParsingListVersionsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgenticTest : TestBase
{
    [Theory]
    [InlineData(Agentic.V2026_08_19)]
    [InlineData(Agentic.V2026_07_24)]
    [InlineData(Agentic.V2026_07_23)]
    [InlineData(Agentic.V2026_07_15)]
    [InlineData(Agentic.V2026_06_18)]
    [InlineData(Agentic.V2026_06_11)]
    [InlineData(Agentic.V2026_06_04)]
    [InlineData(Agentic.V2026_06_01)]
    [InlineData(Agentic.V2026_05_26)]
    [InlineData(Agentic.V2026_05_21)]
    [InlineData(Agentic.V2026_05_20)]
    [InlineData(Agentic.V2026_05_19)]
    [InlineData(Agentic.V2026_05_13)]
    [InlineData(Agentic.V2026_05_11)]
    [InlineData(Agentic.V2026_05_06)]
    [InlineData(Agentic.V2026_05_04)]
    [InlineData(Agentic.V2026_04_27)]
    [InlineData(Agentic.V2026_04_22)]
    [InlineData(Agentic.V2026_04_09)]
    [InlineData(Agentic.V2026_04_06)]
    [InlineData(Agentic.V2026_04_02)]
    [InlineData(Agentic.V2026_03_31)]
    [InlineData(Agentic.V2026_03_30)]
    [InlineData(Agentic.V2026_03_27)]
    [InlineData(Agentic.V2026_03_25)]
    [InlineData(Agentic.V2026_03_23)]
    [InlineData(Agentic.V2026_03_22)]
    [InlineData(Agentic.V2026_03_20)]
    [InlineData(Agentic.V2026_03_11)]
    [InlineData(Agentic.V2026_03_10)]
    [InlineData(Agentic.V2026_03_09)]
    [InlineData(Agentic.V2026_03_03)]
    [InlineData(Agentic.V2026_03_02)]
    [InlineData(Agentic.V2026_02_26)]
    [InlineData(Agentic.V2026_02_24)]
    [InlineData(Agentic.V2026_01_30)]
    [InlineData(Agentic.V2026_01_22)]
    [InlineData(Agentic.V2026_01_21)]
    [InlineData(Agentic.V2026_01_16)]
    [InlineData(Agentic.V2026_01_08)]
    [InlineData(Agentic.V2025_12_31)]
    [InlineData(Agentic.V2025_12_18)]
    [InlineData(Agentic.V2025_12_11)]
    public void Validation_Works(Agentic rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Agentic> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Agentic>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Agentic.V2026_08_19)]
    [InlineData(Agentic.V2026_07_24)]
    [InlineData(Agentic.V2026_07_23)]
    [InlineData(Agentic.V2026_07_15)]
    [InlineData(Agentic.V2026_06_18)]
    [InlineData(Agentic.V2026_06_11)]
    [InlineData(Agentic.V2026_06_04)]
    [InlineData(Agentic.V2026_06_01)]
    [InlineData(Agentic.V2026_05_26)]
    [InlineData(Agentic.V2026_05_21)]
    [InlineData(Agentic.V2026_05_20)]
    [InlineData(Agentic.V2026_05_19)]
    [InlineData(Agentic.V2026_05_13)]
    [InlineData(Agentic.V2026_05_11)]
    [InlineData(Agentic.V2026_05_06)]
    [InlineData(Agentic.V2026_05_04)]
    [InlineData(Agentic.V2026_04_27)]
    [InlineData(Agentic.V2026_04_22)]
    [InlineData(Agentic.V2026_04_09)]
    [InlineData(Agentic.V2026_04_06)]
    [InlineData(Agentic.V2026_04_02)]
    [InlineData(Agentic.V2026_03_31)]
    [InlineData(Agentic.V2026_03_30)]
    [InlineData(Agentic.V2026_03_27)]
    [InlineData(Agentic.V2026_03_25)]
    [InlineData(Agentic.V2026_03_23)]
    [InlineData(Agentic.V2026_03_22)]
    [InlineData(Agentic.V2026_03_20)]
    [InlineData(Agentic.V2026_03_11)]
    [InlineData(Agentic.V2026_03_10)]
    [InlineData(Agentic.V2026_03_09)]
    [InlineData(Agentic.V2026_03_03)]
    [InlineData(Agentic.V2026_03_02)]
    [InlineData(Agentic.V2026_02_26)]
    [InlineData(Agentic.V2026_02_24)]
    [InlineData(Agentic.V2026_01_30)]
    [InlineData(Agentic.V2026_01_22)]
    [InlineData(Agentic.V2026_01_21)]
    [InlineData(Agentic.V2026_01_16)]
    [InlineData(Agentic.V2026_01_08)]
    [InlineData(Agentic.V2025_12_31)]
    [InlineData(Agentic.V2025_12_18)]
    [InlineData(Agentic.V2025_12_11)]
    public void SerializationRoundtrip_Works(Agentic rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Agentic> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Agentic>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Agentic>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Agentic>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AgenticPlusTest : TestBase
{
    [Theory]
    [InlineData(AgenticPlus.V2026_08_19)]
    [InlineData(AgenticPlus.V2026_07_08)]
    [InlineData(AgenticPlus.V2026_06_18)]
    [InlineData(AgenticPlus.V2026_06_11)]
    [InlineData(AgenticPlus.V2026_06_04)]
    [InlineData(AgenticPlus.V2026_06_01)]
    [InlineData(AgenticPlus.V2026_05_26)]
    [InlineData(AgenticPlus.V2026_05_21)]
    [InlineData(AgenticPlus.V2026_05_20)]
    [InlineData(AgenticPlus.V2026_05_19)]
    [InlineData(AgenticPlus.V2026_05_11)]
    [InlineData(AgenticPlus.V2026_05_06)]
    [InlineData(AgenticPlus.V2026_05_04)]
    [InlineData(AgenticPlus.V2026_05_01)]
    [InlineData(AgenticPlus.V2026_04_27)]
    [InlineData(AgenticPlus.V2026_04_19)]
    [InlineData(AgenticPlus.V2026_04_14)]
    [InlineData(AgenticPlus.V2026_04_09)]
    [InlineData(AgenticPlus.V2026_04_02)]
    [InlineData(AgenticPlus.V2026_03_31)]
    [InlineData(AgenticPlus.V2026_03_26)]
    [InlineData(AgenticPlus.V2026_03_25)]
    [InlineData(AgenticPlus.V2026_03_22)]
    [InlineData(AgenticPlus.V2026_03_20)]
    [InlineData(AgenticPlus.V2026_03_17)]
    [InlineData(AgenticPlus.V2026_03_12)]
    [InlineData(AgenticPlus.V2026_03_10)]
    [InlineData(AgenticPlus.V2026_03_09)]
    [InlineData(AgenticPlus.V2026_03_02)]
    [InlineData(AgenticPlus.V2026_02_26)]
    [InlineData(AgenticPlus.V2026_02_24)]
    [InlineData(AgenticPlus.V2026_01_30)]
    [InlineData(AgenticPlus.V2026_01_29)]
    [InlineData(AgenticPlus.V2026_01_24)]
    [InlineData(AgenticPlus.V2026_01_22)]
    [InlineData(AgenticPlus.V2026_01_21)]
    [InlineData(AgenticPlus.V2026_01_16)]
    [InlineData(AgenticPlus.V2025_12_31)]
    [InlineData(AgenticPlus.V2025_12_18)]
    [InlineData(AgenticPlus.V2025_12_11)]
    public void Validation_Works(AgenticPlus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgenticPlus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AgenticPlus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AgenticPlus.V2026_08_19)]
    [InlineData(AgenticPlus.V2026_07_08)]
    [InlineData(AgenticPlus.V2026_06_18)]
    [InlineData(AgenticPlus.V2026_06_11)]
    [InlineData(AgenticPlus.V2026_06_04)]
    [InlineData(AgenticPlus.V2026_06_01)]
    [InlineData(AgenticPlus.V2026_05_26)]
    [InlineData(AgenticPlus.V2026_05_21)]
    [InlineData(AgenticPlus.V2026_05_20)]
    [InlineData(AgenticPlus.V2026_05_19)]
    [InlineData(AgenticPlus.V2026_05_11)]
    [InlineData(AgenticPlus.V2026_05_06)]
    [InlineData(AgenticPlus.V2026_05_04)]
    [InlineData(AgenticPlus.V2026_05_01)]
    [InlineData(AgenticPlus.V2026_04_27)]
    [InlineData(AgenticPlus.V2026_04_19)]
    [InlineData(AgenticPlus.V2026_04_14)]
    [InlineData(AgenticPlus.V2026_04_09)]
    [InlineData(AgenticPlus.V2026_04_02)]
    [InlineData(AgenticPlus.V2026_03_31)]
    [InlineData(AgenticPlus.V2026_03_26)]
    [InlineData(AgenticPlus.V2026_03_25)]
    [InlineData(AgenticPlus.V2026_03_22)]
    [InlineData(AgenticPlus.V2026_03_20)]
    [InlineData(AgenticPlus.V2026_03_17)]
    [InlineData(AgenticPlus.V2026_03_12)]
    [InlineData(AgenticPlus.V2026_03_10)]
    [InlineData(AgenticPlus.V2026_03_09)]
    [InlineData(AgenticPlus.V2026_03_02)]
    [InlineData(AgenticPlus.V2026_02_26)]
    [InlineData(AgenticPlus.V2026_02_24)]
    [InlineData(AgenticPlus.V2026_01_30)]
    [InlineData(AgenticPlus.V2026_01_29)]
    [InlineData(AgenticPlus.V2026_01_24)]
    [InlineData(AgenticPlus.V2026_01_22)]
    [InlineData(AgenticPlus.V2026_01_21)]
    [InlineData(AgenticPlus.V2026_01_16)]
    [InlineData(AgenticPlus.V2025_12_31)]
    [InlineData(AgenticPlus.V2025_12_18)]
    [InlineData(AgenticPlus.V2025_12_11)]
    public void SerializationRoundtrip_Works(AgenticPlus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgenticPlus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AgenticPlus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AgenticPlus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AgenticPlus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CostEffectiveTest : TestBase
{
    [Theory]
    [InlineData(CostEffective.V2026_08_19)]
    [InlineData(CostEffective.V2026_08_11)]
    [InlineData(CostEffective.V2026_08_08)]
    [InlineData(CostEffective.V2026_07_23)]
    [InlineData(CostEffective.V2026_06_26)]
    [InlineData(CostEffective.V2026_06_18)]
    [InlineData(CostEffective.V2026_06_17)]
    [InlineData(CostEffective.V2026_06_11)]
    [InlineData(CostEffective.V2026_06_08)]
    [InlineData(CostEffective.V2026_06_05)]
    [InlineData(CostEffective.V2026_05_28)]
    [InlineData(CostEffective.V2026_04_09)]
    [InlineData(CostEffective.V2026_03_31)]
    [InlineData(CostEffective.V2026_03_27)]
    [InlineData(CostEffective.V2026_03_25)]
    public void Validation_Works(CostEffective rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CostEffective> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CostEffective>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CostEffective.V2026_08_19)]
    [InlineData(CostEffective.V2026_08_11)]
    [InlineData(CostEffective.V2026_08_08)]
    [InlineData(CostEffective.V2026_07_23)]
    [InlineData(CostEffective.V2026_06_26)]
    [InlineData(CostEffective.V2026_06_18)]
    [InlineData(CostEffective.V2026_06_17)]
    [InlineData(CostEffective.V2026_06_11)]
    [InlineData(CostEffective.V2026_06_08)]
    [InlineData(CostEffective.V2026_06_05)]
    [InlineData(CostEffective.V2026_05_28)]
    [InlineData(CostEffective.V2026_04_09)]
    [InlineData(CostEffective.V2026_03_31)]
    [InlineData(CostEffective.V2026_03_27)]
    [InlineData(CostEffective.V2026_03_25)]
    public void SerializationRoundtrip_Works(CostEffective rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CostEffective> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CostEffective>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CostEffective>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CostEffective>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FastTest : TestBase
{
    [Theory]
    [InlineData(Fast.V2026_06_15)]
    [InlineData(Fast.V2025_12_11)]
    public void Validation_Works(Fast rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Fast> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Fast>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Fast.V2026_06_15)]
    [InlineData(Fast.V2025_12_11)]
    public void SerializationRoundtrip_Works(Fast rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Fast> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Fast>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Fast>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Fast>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
