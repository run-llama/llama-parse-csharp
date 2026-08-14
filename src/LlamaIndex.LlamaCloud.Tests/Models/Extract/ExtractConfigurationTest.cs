using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Extract;

namespace LlamaIndex.LlamaCloud.Tests.Models.Extract;

public class ExtractConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractConfiguration
        {
            DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            CiteSources = true,
            ConfidenceScores = true,
            DisableCache = true,
            ExtractionTarget = ExtractionTarget.PerDoc,
            MaxPages = 10,
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = "fast",
            SheetNames = ["Sheet 1", "Q4 Summary"],
            SpreadsheetMode = true,
            SystemPrompt =
                "Extract all monetary values in USD. If a currency is not specified, assume USD.",
            TargetPages = "1,3,5-7",
            Tier = Tier.CostEffective,
            Version = "latest",
        };

        Dictionary<string, ExtractConfigurationDataSchema?> expectedDataSchema = new()
        {
            {
                "foo",
                new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                )
            },
        };
        bool expectedCiteSources = true;
        bool expectedConfidenceScores = true;
        bool expectedDisableCache = true;
        ApiEnum<string, ExtractionTarget> expectedExtractionTarget = ExtractionTarget.PerDoc;
        long expectedMaxPages = 10;
        string expectedParseConfigID = "cfg-11111111-2222-3333-4444-555555555555";
        string expectedParseTier = "fast";
        List<string> expectedSheetNames = ["Sheet 1", "Q4 Summary"];
        bool expectedSpreadsheetMode = true;
        string expectedSystemPrompt =
            "Extract all monetary values in USD. If a currency is not specified, assume USD.";
        string expectedTargetPages = "1,3,5-7";
        ApiEnum<string, Tier> expectedTier = Tier.CostEffective;
        string expectedVersion = "latest";

        Assert.Equal(expectedDataSchema.Count, model.DataSchema.Count);
        foreach (var item in expectedDataSchema)
        {
            Assert.True(model.DataSchema.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.DataSchema[item.Key]);
        }
        Assert.Equal(expectedCiteSources, model.CiteSources);
        Assert.Equal(expectedConfidenceScores, model.ConfidenceScores);
        Assert.Equal(expectedDisableCache, model.DisableCache);
        Assert.Equal(expectedExtractionTarget, model.ExtractionTarget);
        Assert.Equal(expectedMaxPages, model.MaxPages);
        Assert.Equal(expectedParseConfigID, model.ParseConfigID);
        Assert.Equal(expectedParseTier, model.ParseTier);
        Assert.NotNull(model.SheetNames);
        Assert.Equal(expectedSheetNames.Count, model.SheetNames.Count);
        for (int i = 0; i < expectedSheetNames.Count; i++)
        {
            Assert.Equal(expectedSheetNames[i], model.SheetNames[i]);
        }
        Assert.Equal(expectedSpreadsheetMode, model.SpreadsheetMode);
        Assert.Equal(expectedSystemPrompt, model.SystemPrompt);
        Assert.Equal(expectedTargetPages, model.TargetPages);
        Assert.Equal(expectedTier, model.Tier);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractConfiguration
        {
            DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            CiteSources = true,
            ConfidenceScores = true,
            DisableCache = true,
            ExtractionTarget = ExtractionTarget.PerDoc,
            MaxPages = 10,
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = "fast",
            SheetNames = ["Sheet 1", "Q4 Summary"],
            SpreadsheetMode = true,
            SystemPrompt =
                "Extract all monetary values in USD. If a currency is not specified, assume USD.",
            TargetPages = "1,3,5-7",
            Tier = Tier.CostEffective,
            Version = "latest",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractConfiguration
        {
            DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            CiteSources = true,
            ConfidenceScores = true,
            DisableCache = true,
            ExtractionTarget = ExtractionTarget.PerDoc,
            MaxPages = 10,
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = "fast",
            SheetNames = ["Sheet 1", "Q4 Summary"],
            SpreadsheetMode = true,
            SystemPrompt =
                "Extract all monetary values in USD. If a currency is not specified, assume USD.",
            TargetPages = "1,3,5-7",
            Tier = Tier.CostEffective,
            Version = "latest",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, ExtractConfigurationDataSchema?> expectedDataSchema = new()
        {
            {
                "foo",
                new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                )
            },
        };
        bool expectedCiteSources = true;
        bool expectedConfidenceScores = true;
        bool expectedDisableCache = true;
        ApiEnum<string, ExtractionTarget> expectedExtractionTarget = ExtractionTarget.PerDoc;
        long expectedMaxPages = 10;
        string expectedParseConfigID = "cfg-11111111-2222-3333-4444-555555555555";
        string expectedParseTier = "fast";
        List<string> expectedSheetNames = ["Sheet 1", "Q4 Summary"];
        bool expectedSpreadsheetMode = true;
        string expectedSystemPrompt =
            "Extract all monetary values in USD. If a currency is not specified, assume USD.";
        string expectedTargetPages = "1,3,5-7";
        ApiEnum<string, Tier> expectedTier = Tier.CostEffective;
        string expectedVersion = "latest";

        Assert.Equal(expectedDataSchema.Count, deserialized.DataSchema.Count);
        foreach (var item in expectedDataSchema)
        {
            Assert.True(deserialized.DataSchema.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.DataSchema[item.Key]);
        }
        Assert.Equal(expectedCiteSources, deserialized.CiteSources);
        Assert.Equal(expectedConfidenceScores, deserialized.ConfidenceScores);
        Assert.Equal(expectedDisableCache, deserialized.DisableCache);
        Assert.Equal(expectedExtractionTarget, deserialized.ExtractionTarget);
        Assert.Equal(expectedMaxPages, deserialized.MaxPages);
        Assert.Equal(expectedParseConfigID, deserialized.ParseConfigID);
        Assert.Equal(expectedParseTier, deserialized.ParseTier);
        Assert.NotNull(deserialized.SheetNames);
        Assert.Equal(expectedSheetNames.Count, deserialized.SheetNames.Count);
        for (int i = 0; i < expectedSheetNames.Count; i++)
        {
            Assert.Equal(expectedSheetNames[i], deserialized.SheetNames[i]);
        }
        Assert.Equal(expectedSpreadsheetMode, deserialized.SpreadsheetMode);
        Assert.Equal(expectedSystemPrompt, deserialized.SystemPrompt);
        Assert.Equal(expectedTargetPages, deserialized.TargetPages);
        Assert.Equal(expectedTier, deserialized.Tier);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractConfiguration
        {
            DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            CiteSources = true,
            ConfidenceScores = true,
            DisableCache = true,
            ExtractionTarget = ExtractionTarget.PerDoc,
            MaxPages = 10,
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = "fast",
            SheetNames = ["Sheet 1", "Q4 Summary"],
            SpreadsheetMode = true,
            SystemPrompt =
                "Extract all monetary values in USD. If a currency is not specified, assume USD.",
            TargetPages = "1,3,5-7",
            Tier = Tier.CostEffective,
            Version = "latest",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtractConfiguration
        {
            DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            MaxPages = 10,
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = "fast",
            SheetNames = ["Sheet 1", "Q4 Summary"],
            SystemPrompt =
                "Extract all monetary values in USD. If a currency is not specified, assume USD.",
            TargetPages = "1,3,5-7",
        };

        Assert.Null(model.CiteSources);
        Assert.False(model.RawData.ContainsKey("cite_sources"));
        Assert.Null(model.ConfidenceScores);
        Assert.False(model.RawData.ContainsKey("confidence_scores"));
        Assert.Null(model.DisableCache);
        Assert.False(model.RawData.ContainsKey("disable_cache"));
        Assert.Null(model.ExtractionTarget);
        Assert.False(model.RawData.ContainsKey("extraction_target"));
        Assert.Null(model.SpreadsheetMode);
        Assert.False(model.RawData.ContainsKey("spreadsheet_mode"));
        Assert.Null(model.Tier);
        Assert.False(model.RawData.ContainsKey("tier"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtractConfiguration
        {
            DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            MaxPages = 10,
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = "fast",
            SheetNames = ["Sheet 1", "Q4 Summary"],
            SystemPrompt =
                "Extract all monetary values in USD. If a currency is not specified, assume USD.",
            TargetPages = "1,3,5-7",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExtractConfiguration
        {
            DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            MaxPages = 10,
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = "fast",
            SheetNames = ["Sheet 1", "Q4 Summary"],
            SystemPrompt =
                "Extract all monetary values in USD. If a currency is not specified, assume USD.",
            TargetPages = "1,3,5-7",

            // Null should be interpreted as omitted for these properties
            CiteSources = null,
            ConfidenceScores = null,
            DisableCache = null,
            ExtractionTarget = null,
            SpreadsheetMode = null,
            Tier = null,
            Version = null,
        };

        Assert.Null(model.CiteSources);
        Assert.False(model.RawData.ContainsKey("cite_sources"));
        Assert.Null(model.ConfidenceScores);
        Assert.False(model.RawData.ContainsKey("confidence_scores"));
        Assert.Null(model.DisableCache);
        Assert.False(model.RawData.ContainsKey("disable_cache"));
        Assert.Null(model.ExtractionTarget);
        Assert.False(model.RawData.ContainsKey("extraction_target"));
        Assert.Null(model.SpreadsheetMode);
        Assert.False(model.RawData.ContainsKey("spreadsheet_mode"));
        Assert.Null(model.Tier);
        Assert.False(model.RawData.ContainsKey("tier"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtractConfiguration
        {
            DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            MaxPages = 10,
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = "fast",
            SheetNames = ["Sheet 1", "Q4 Summary"],
            SystemPrompt =
                "Extract all monetary values in USD. If a currency is not specified, assume USD.",
            TargetPages = "1,3,5-7",

            // Null should be interpreted as omitted for these properties
            CiteSources = null,
            ConfidenceScores = null,
            DisableCache = null,
            ExtractionTarget = null,
            SpreadsheetMode = null,
            Tier = null,
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtractConfiguration
        {
            DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            CiteSources = true,
            ConfidenceScores = true,
            DisableCache = true,
            ExtractionTarget = ExtractionTarget.PerDoc,
            SpreadsheetMode = true,
            Tier = Tier.CostEffective,
            Version = "latest",
        };

        Assert.Null(model.MaxPages);
        Assert.False(model.RawData.ContainsKey("max_pages"));
        Assert.Null(model.ParseConfigID);
        Assert.False(model.RawData.ContainsKey("parse_config_id"));
        Assert.Null(model.ParseTier);
        Assert.False(model.RawData.ContainsKey("parse_tier"));
        Assert.Null(model.SheetNames);
        Assert.False(model.RawData.ContainsKey("sheet_names"));
        Assert.Null(model.SystemPrompt);
        Assert.False(model.RawData.ContainsKey("system_prompt"));
        Assert.Null(model.TargetPages);
        Assert.False(model.RawData.ContainsKey("target_pages"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtractConfiguration
        {
            DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            CiteSources = true,
            ConfidenceScores = true,
            DisableCache = true,
            ExtractionTarget = ExtractionTarget.PerDoc,
            SpreadsheetMode = true,
            Tier = Tier.CostEffective,
            Version = "latest",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ExtractConfiguration
        {
            DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            CiteSources = true,
            ConfidenceScores = true,
            DisableCache = true,
            ExtractionTarget = ExtractionTarget.PerDoc,
            SpreadsheetMode = true,
            Tier = Tier.CostEffective,
            Version = "latest",

            MaxPages = null,
            ParseConfigID = null,
            ParseTier = null,
            SheetNames = null,
            SystemPrompt = null,
            TargetPages = null,
        };

        Assert.Null(model.MaxPages);
        Assert.True(model.RawData.ContainsKey("max_pages"));
        Assert.Null(model.ParseConfigID);
        Assert.True(model.RawData.ContainsKey("parse_config_id"));
        Assert.Null(model.ParseTier);
        Assert.True(model.RawData.ContainsKey("parse_tier"));
        Assert.Null(model.SheetNames);
        Assert.True(model.RawData.ContainsKey("sheet_names"));
        Assert.Null(model.SystemPrompt);
        Assert.True(model.RawData.ContainsKey("system_prompt"));
        Assert.Null(model.TargetPages);
        Assert.True(model.RawData.ContainsKey("target_pages"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtractConfiguration
        {
            DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            CiteSources = true,
            ConfidenceScores = true,
            DisableCache = true,
            ExtractionTarget = ExtractionTarget.PerDoc,
            SpreadsheetMode = true,
            Tier = Tier.CostEffective,
            Version = "latest",

            MaxPages = null,
            ParseConfigID = null,
            ParseTier = null,
            SheetNames = null,
            SystemPrompt = null,
            TargetPages = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractConfiguration
        {
            DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            CiteSources = true,
            ConfidenceScores = true,
            DisableCache = true,
            ExtractionTarget = ExtractionTarget.PerDoc,
            MaxPages = 10,
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = "fast",
            SheetNames = ["Sheet 1", "Q4 Summary"],
            SpreadsheetMode = true,
            SystemPrompt =
                "Extract all monetary values in USD. If a currency is not specified, assume USD.",
            TargetPages = "1,3,5-7",
            Tier = Tier.CostEffective,
            Version = "latest",
        };

        ExtractConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtractConfigurationDataSchemaTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        ExtractConfigurationDataSchema value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidationWorks1()
    {
        ExtractConfigurationDataSchema value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        ExtractConfigurationDataSchema value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ExtractConfigurationDataSchema value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ExtractConfigurationDataSchema value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        ExtractConfigurationDataSchema value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractConfigurationDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        ExtractConfigurationDataSchema value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractConfigurationDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExtractConfigurationDataSchema value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractConfigurationDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ExtractConfigurationDataSchema value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractConfigurationDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ExtractConfigurationDataSchema value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractConfigurationDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExtractionTargetTest : TestBase
{
    [Theory]
    [InlineData(ExtractionTarget.PerDoc)]
    [InlineData(ExtractionTarget.PerPage)]
    [InlineData(ExtractionTarget.PerTableRow)]
    public void Validation_Works(ExtractionTarget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionTarget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionTarget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExtractionTarget.PerDoc)]
    [InlineData(ExtractionTarget.PerPage)]
    [InlineData(ExtractionTarget.PerTableRow)]
    public void SerializationRoundtrip_Works(ExtractionTarget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionTarget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionTarget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionTarget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionTarget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TierTest : TestBase
{
    [Theory]
    [InlineData(Tier.Agentic)]
    [InlineData(Tier.AgenticPlus)]
    [InlineData(Tier.CostEffective)]
    public void Validation_Works(Tier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Tier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Tier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Tier.Agentic)]
    [InlineData(Tier.AgenticPlus)]
    [InlineData(Tier.CostEffective)]
    public void SerializationRoundtrip_Works(Tier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Tier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Tier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Tier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Tier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
