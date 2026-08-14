using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Configurations;
using Split = LlamaIndex.LlamaCloud.Models.Beta.Split;

namespace LlamaIndex.LlamaCloud.Tests.Models.Configurations;

public class SplitV1ParametersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new() { AllowUncategorized = AllowUncategorized.Forbid },
        };

        List<Split::SplitCategory> expectedCategories = [new() { Name = "x", Description = "x" }];
        JsonElement expectedProductType = JsonSerializer.SerializeToElement("split_v1");
        SplittingStrategy expectedSplittingStrategy = new()
        {
            AllowUncategorized = AllowUncategorized.Forbid,
        };

        Assert.Equal(expectedCategories.Count, model.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], model.Categories[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedProductType, model.ProductType));
        Assert.Equal(expectedSplittingStrategy, model.SplittingStrategy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new() { AllowUncategorized = AllowUncategorized.Forbid },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitV1Parameters>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new() { AllowUncategorized = AllowUncategorized.Forbid },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitV1Parameters>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Split::SplitCategory> expectedCategories = [new() { Name = "x", Description = "x" }];
        JsonElement expectedProductType = JsonSerializer.SerializeToElement("split_v1");
        SplittingStrategy expectedSplittingStrategy = new()
        {
            AllowUncategorized = AllowUncategorized.Forbid,
        };

        Assert.Equal(expectedCategories.Count, deserialized.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], deserialized.Categories[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedProductType, deserialized.ProductType));
        Assert.Equal(expectedSplittingStrategy, deserialized.SplittingStrategy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new() { AllowUncategorized = AllowUncategorized.Forbid },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],
        };

        Assert.Null(model.SplittingStrategy);
        Assert.False(model.RawData.ContainsKey("splitting_strategy"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],

            // Null should be interpreted as omitted for these properties
            SplittingStrategy = null,
        };

        Assert.Null(model.SplittingStrategy);
        Assert.False(model.RawData.ContainsKey("splitting_strategy"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],

            // Null should be interpreted as omitted for these properties
            SplittingStrategy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new() { AllowUncategorized = AllowUncategorized.Forbid },
        };

        SplitV1Parameters copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplittingStrategyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplittingStrategy { AllowUncategorized = AllowUncategorized.Forbid };

        ApiEnum<string, AllowUncategorized> expectedAllowUncategorized = AllowUncategorized.Forbid;

        Assert.Equal(expectedAllowUncategorized, model.AllowUncategorized);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplittingStrategy { AllowUncategorized = AllowUncategorized.Forbid };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplittingStrategy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplittingStrategy { AllowUncategorized = AllowUncategorized.Forbid };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplittingStrategy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AllowUncategorized> expectedAllowUncategorized = AllowUncategorized.Forbid;

        Assert.Equal(expectedAllowUncategorized, deserialized.AllowUncategorized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SplittingStrategy { AllowUncategorized = AllowUncategorized.Forbid };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplittingStrategy { };

        Assert.Null(model.AllowUncategorized);
        Assert.False(model.RawData.ContainsKey("allow_uncategorized"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplittingStrategy { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplittingStrategy
        {
            // Null should be interpreted as omitted for these properties
            AllowUncategorized = null,
        };

        Assert.Null(model.AllowUncategorized);
        Assert.False(model.RawData.ContainsKey("allow_uncategorized"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SplittingStrategy
        {
            // Null should be interpreted as omitted for these properties
            AllowUncategorized = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplittingStrategy { AllowUncategorized = AllowUncategorized.Forbid };

        SplittingStrategy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AllowUncategorizedTest : TestBase
{
    [Theory]
    [InlineData(AllowUncategorized.Forbid)]
    [InlineData(AllowUncategorized.Include)]
    [InlineData(AllowUncategorized.Omit)]
    public void Validation_Works(AllowUncategorized rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AllowUncategorized> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AllowUncategorized>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AllowUncategorized.Forbid)]
    [InlineData(AllowUncategorized.Include)]
    [InlineData(AllowUncategorized.Omit)]
    public void SerializationRoundtrip_Works(AllowUncategorized rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AllowUncategorized> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AllowUncategorized>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AllowUncategorized>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AllowUncategorized>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
