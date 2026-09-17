using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Configurations;
using Split = LlamaCloud.Models.Beta.Split;

namespace LlamaCloud.Tests.Models.Configurations;

public class SplitV1ParametersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = SplitV1ParametersParseTier.Fast,
            SplittingStrategy = new()
            {
                AllowUncategorized = AllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },
            TargetPages = "1,3,5-7",
        };

        List<Split::SplitCategory> expectedCategories = [new() { Name = "x", Description = "x" }];
        JsonElement expectedProductType = JsonSerializer.SerializeToElement("split_v1");
        string expectedParseConfigID = "cfg-11111111-2222-3333-4444-555555555555";
        ApiEnum<string, SplitV1ParametersParseTier> expectedParseTier =
            SplitV1ParametersParseTier.Fast;
        SplittingStrategy expectedSplittingStrategy = new()
        {
            AllowUncategorized = AllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
        };
        string expectedTargetPages = "1,3,5-7";

        Assert.Equal(expectedCategories.Count, model.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], model.Categories[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedProductType, model.ProductType));
        Assert.Equal(expectedParseConfigID, model.ParseConfigID);
        Assert.Equal(expectedParseTier, model.ParseTier);
        Assert.Equal(expectedSplittingStrategy, model.SplittingStrategy);
        Assert.Equal(expectedTargetPages, model.TargetPages);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = SplitV1ParametersParseTier.Fast,
            SplittingStrategy = new()
            {
                AllowUncategorized = AllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },
            TargetPages = "1,3,5-7",
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
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = SplitV1ParametersParseTier.Fast,
            SplittingStrategy = new()
            {
                AllowUncategorized = AllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },
            TargetPages = "1,3,5-7",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitV1Parameters>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Split::SplitCategory> expectedCategories = [new() { Name = "x", Description = "x" }];
        JsonElement expectedProductType = JsonSerializer.SerializeToElement("split_v1");
        string expectedParseConfigID = "cfg-11111111-2222-3333-4444-555555555555";
        ApiEnum<string, SplitV1ParametersParseTier> expectedParseTier =
            SplitV1ParametersParseTier.Fast;
        SplittingStrategy expectedSplittingStrategy = new()
        {
            AllowUncategorized = AllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
        };
        string expectedTargetPages = "1,3,5-7";

        Assert.Equal(expectedCategories.Count, deserialized.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], deserialized.Categories[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedProductType, deserialized.ProductType));
        Assert.Equal(expectedParseConfigID, deserialized.ParseConfigID);
        Assert.Equal(expectedParseTier, deserialized.ParseTier);
        Assert.Equal(expectedSplittingStrategy, deserialized.SplittingStrategy);
        Assert.Equal(expectedTargetPages, deserialized.TargetPages);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = SplitV1ParametersParseTier.Fast,
            SplittingStrategy = new()
            {
                AllowUncategorized = AllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },
            TargetPages = "1,3,5-7",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = SplitV1ParametersParseTier.Fast,
            TargetPages = "1,3,5-7",
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
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = SplitV1ParametersParseTier.Fast,
            TargetPages = "1,3,5-7",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = SplitV1ParametersParseTier.Fast,
            TargetPages = "1,3,5-7",

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
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = SplitV1ParametersParseTier.Fast,
            TargetPages = "1,3,5-7",

            // Null should be interpreted as omitted for these properties
            SplittingStrategy = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new()
            {
                AllowUncategorized = AllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },
        };

        Assert.Null(model.ParseConfigID);
        Assert.False(model.RawData.ContainsKey("parse_config_id"));
        Assert.Null(model.ParseTier);
        Assert.False(model.RawData.ContainsKey("parse_tier"));
        Assert.Null(model.TargetPages);
        Assert.False(model.RawData.ContainsKey("target_pages"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new()
            {
                AllowUncategorized = AllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new()
            {
                AllowUncategorized = AllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },

            ParseConfigID = null,
            ParseTier = null,
            TargetPages = null,
        };

        Assert.Null(model.ParseConfigID);
        Assert.True(model.RawData.ContainsKey("parse_config_id"));
        Assert.Null(model.ParseTier);
        Assert.True(model.RawData.ContainsKey("parse_tier"));
        Assert.Null(model.TargetPages);
        Assert.True(model.RawData.ContainsKey("target_pages"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new()
            {
                AllowUncategorized = AllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },

            ParseConfigID = null,
            ParseTier = null,
            TargetPages = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplitV1Parameters
        {
            Categories = [new() { Name = "x", Description = "x" }],
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = SplitV1ParametersParseTier.Fast,
            SplittingStrategy = new()
            {
                AllowUncategorized = AllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },
            TargetPages = "1,3,5-7",
        };

        SplitV1Parameters copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitV1ParametersParseTierTest : TestBase
{
    [Theory]
    [InlineData(SplitV1ParametersParseTier.Agentic)]
    [InlineData(SplitV1ParametersParseTier.AgenticPlus)]
    [InlineData(SplitV1ParametersParseTier.CostEffective)]
    [InlineData(SplitV1ParametersParseTier.Fast)]
    public void Validation_Works(SplitV1ParametersParseTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitV1ParametersParseTier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitV1ParametersParseTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SplitV1ParametersParseTier.Agentic)]
    [InlineData(SplitV1ParametersParseTier.AgenticPlus)]
    [InlineData(SplitV1ParametersParseTier.CostEffective)]
    [InlineData(SplitV1ParametersParseTier.Fast)]
    public void SerializationRoundtrip_Works(SplitV1ParametersParseTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitV1ParametersParseTier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SplitV1ParametersParseTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitV1ParametersParseTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SplitV1ParametersParseTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SplittingStrategyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplittingStrategy
        {
            AllowUncategorized = AllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
        };

        ApiEnum<string, AllowUncategorized> expectedAllowUncategorized = AllowUncategorized.Forbid;
        string expectedCustomInstructions = "Start a new segment at every signature page.";
        long expectedMinPagesPerSplit = 1;

        Assert.Equal(expectedAllowUncategorized, model.AllowUncategorized);
        Assert.Equal(expectedCustomInstructions, model.CustomInstructions);
        Assert.Equal(expectedMinPagesPerSplit, model.MinPagesPerSplit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplittingStrategy
        {
            AllowUncategorized = AllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
        };

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
        var model = new SplittingStrategy
        {
            AllowUncategorized = AllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplittingStrategy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AllowUncategorized> expectedAllowUncategorized = AllowUncategorized.Forbid;
        string expectedCustomInstructions = "Start a new segment at every signature page.";
        long expectedMinPagesPerSplit = 1;

        Assert.Equal(expectedAllowUncategorized, deserialized.AllowUncategorized);
        Assert.Equal(expectedCustomInstructions, deserialized.CustomInstructions);
        Assert.Equal(expectedMinPagesPerSplit, deserialized.MinPagesPerSplit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SplittingStrategy
        {
            AllowUncategorized = AllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplittingStrategy
        {
            CustomInstructions = "Start a new segment at every signature page.",
        };

        Assert.Null(model.AllowUncategorized);
        Assert.False(model.RawData.ContainsKey("allow_uncategorized"));
        Assert.Null(model.MinPagesPerSplit);
        Assert.False(model.RawData.ContainsKey("min_pages_per_split"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplittingStrategy
        {
            CustomInstructions = "Start a new segment at every signature page.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplittingStrategy
        {
            CustomInstructions = "Start a new segment at every signature page.",

            // Null should be interpreted as omitted for these properties
            AllowUncategorized = null,
            MinPagesPerSplit = null,
        };

        Assert.Null(model.AllowUncategorized);
        Assert.False(model.RawData.ContainsKey("allow_uncategorized"));
        Assert.Null(model.MinPagesPerSplit);
        Assert.False(model.RawData.ContainsKey("min_pages_per_split"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SplittingStrategy
        {
            CustomInstructions = "Start a new segment at every signature page.",

            // Null should be interpreted as omitted for these properties
            AllowUncategorized = null,
            MinPagesPerSplit = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplittingStrategy
        {
            AllowUncategorized = AllowUncategorized.Forbid,
            MinPagesPerSplit = 1,
        };

        Assert.Null(model.CustomInstructions);
        Assert.False(model.RawData.ContainsKey("custom_instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplittingStrategy
        {
            AllowUncategorized = AllowUncategorized.Forbid,
            MinPagesPerSplit = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SplittingStrategy
        {
            AllowUncategorized = AllowUncategorized.Forbid,
            MinPagesPerSplit = 1,

            CustomInstructions = null,
        };

        Assert.Null(model.CustomInstructions);
        Assert.True(model.RawData.ContainsKey("custom_instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SplittingStrategy
        {
            AllowUncategorized = AllowUncategorized.Forbid,
            MinPagesPerSplit = 1,

            CustomInstructions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplittingStrategy
        {
            AllowUncategorized = AllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
        };

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
