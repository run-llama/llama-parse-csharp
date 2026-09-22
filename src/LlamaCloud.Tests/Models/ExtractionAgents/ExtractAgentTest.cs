using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.ExtractionAgents;

namespace LlamaCloud.Tests.Models.ExtractionAgents;

public class ExtractAgentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractAgent
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Config = new()
            {
                ChunkMode = ChunkMode.Page,
                CitationBbox = true,
                CiteSources = true,
                ConfidenceScores = true,
                ExtractModel = ExtractModel.Gemini2_0Flash,
                ExtractionMode = ExtractionMode.Balanced,
                ExtractionTarget = ExtractionTarget.PerDoc,
                HighResolutionMode = true,
                InvalidateCache = true,
                MultimodalFastMode = true,
                NumPagesContext = 1,
                PageRange = "page_range",
                ParseModel = ParseModel.AnthropicHaiku3_5,
                Priority = Priority.Critical,
                SystemPrompt = "system_prompt",
                UseReasoning = true,
            },
            DataSchema = new Dictionary<string, DataSchema?>()
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomConfiguration = CustomConfiguration.Default,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Config expectedConfig = new()
        {
            ChunkMode = ChunkMode.Page,
            CitationBbox = true,
            CiteSources = true,
            ConfidenceScores = true,
            ExtractModel = ExtractModel.Gemini2_0Flash,
            ExtractionMode = ExtractionMode.Balanced,
            ExtractionTarget = ExtractionTarget.PerDoc,
            HighResolutionMode = true,
            InvalidateCache = true,
            MultimodalFastMode = true,
            NumPagesContext = 1,
            PageRange = "page_range",
            ParseModel = ParseModel.AnthropicHaiku3_5,
            Priority = Priority.Critical,
            SystemPrompt = "system_prompt",
            UseReasoning = true,
        };
        Dictionary<string, DataSchema?> expectedDataSchema = new()
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
        string expectedName = "name";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CustomConfiguration> expectedCustomConfiguration =
            CustomConfiguration.Default;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConfig, model.Config);
        Assert.Equal(expectedDataSchema.Count, model.DataSchema.Count);
        foreach (var item in expectedDataSchema)
        {
            Assert.True(model.DataSchema.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.DataSchema[item.Key]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomConfiguration, model.CustomConfiguration);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractAgent
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Config = new()
            {
                ChunkMode = ChunkMode.Page,
                CitationBbox = true,
                CiteSources = true,
                ConfidenceScores = true,
                ExtractModel = ExtractModel.Gemini2_0Flash,
                ExtractionMode = ExtractionMode.Balanced,
                ExtractionTarget = ExtractionTarget.PerDoc,
                HighResolutionMode = true,
                InvalidateCache = true,
                MultimodalFastMode = true,
                NumPagesContext = 1,
                PageRange = "page_range",
                ParseModel = ParseModel.AnthropicHaiku3_5,
                Priority = Priority.Critical,
                SystemPrompt = "system_prompt",
                UseReasoning = true,
            },
            DataSchema = new Dictionary<string, DataSchema?>()
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomConfiguration = CustomConfiguration.Default,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractAgent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractAgent
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Config = new()
            {
                ChunkMode = ChunkMode.Page,
                CitationBbox = true,
                CiteSources = true,
                ConfidenceScores = true,
                ExtractModel = ExtractModel.Gemini2_0Flash,
                ExtractionMode = ExtractionMode.Balanced,
                ExtractionTarget = ExtractionTarget.PerDoc,
                HighResolutionMode = true,
                InvalidateCache = true,
                MultimodalFastMode = true,
                NumPagesContext = 1,
                PageRange = "page_range",
                ParseModel = ParseModel.AnthropicHaiku3_5,
                Priority = Priority.Critical,
                SystemPrompt = "system_prompt",
                UseReasoning = true,
            },
            DataSchema = new Dictionary<string, DataSchema?>()
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomConfiguration = CustomConfiguration.Default,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractAgent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Config expectedConfig = new()
        {
            ChunkMode = ChunkMode.Page,
            CitationBbox = true,
            CiteSources = true,
            ConfidenceScores = true,
            ExtractModel = ExtractModel.Gemini2_0Flash,
            ExtractionMode = ExtractionMode.Balanced,
            ExtractionTarget = ExtractionTarget.PerDoc,
            HighResolutionMode = true,
            InvalidateCache = true,
            MultimodalFastMode = true,
            NumPagesContext = 1,
            PageRange = "page_range",
            ParseModel = ParseModel.AnthropicHaiku3_5,
            Priority = Priority.Critical,
            SystemPrompt = "system_prompt",
            UseReasoning = true,
        };
        Dictionary<string, DataSchema?> expectedDataSchema = new()
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
        string expectedName = "name";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CustomConfiguration> expectedCustomConfiguration =
            CustomConfiguration.Default;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConfig, deserialized.Config);
        Assert.Equal(expectedDataSchema.Count, deserialized.DataSchema.Count);
        foreach (var item in expectedDataSchema)
        {
            Assert.True(deserialized.DataSchema.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.DataSchema[item.Key]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomConfiguration, deserialized.CustomConfiguration);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractAgent
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Config = new()
            {
                ChunkMode = ChunkMode.Page,
                CitationBbox = true,
                CiteSources = true,
                ConfidenceScores = true,
                ExtractModel = ExtractModel.Gemini2_0Flash,
                ExtractionMode = ExtractionMode.Balanced,
                ExtractionTarget = ExtractionTarget.PerDoc,
                HighResolutionMode = true,
                InvalidateCache = true,
                MultimodalFastMode = true,
                NumPagesContext = 1,
                PageRange = "page_range",
                ParseModel = ParseModel.AnthropicHaiku3_5,
                Priority = Priority.Critical,
                SystemPrompt = "system_prompt",
                UseReasoning = true,
            },
            DataSchema = new Dictionary<string, DataSchema?>()
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomConfiguration = CustomConfiguration.Default,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtractAgent
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Config = new()
            {
                ChunkMode = ChunkMode.Page,
                CitationBbox = true,
                CiteSources = true,
                ConfidenceScores = true,
                ExtractModel = ExtractModel.Gemini2_0Flash,
                ExtractionMode = ExtractionMode.Balanced,
                ExtractionTarget = ExtractionTarget.PerDoc,
                HighResolutionMode = true,
                InvalidateCache = true,
                MultimodalFastMode = true,
                NumPagesContext = 1,
                PageRange = "page_range",
                ParseModel = ParseModel.AnthropicHaiku3_5,
                Priority = Priority.Critical,
                SystemPrompt = "system_prompt",
                UseReasoning = true,
            },
            DataSchema = new Dictionary<string, DataSchema?>()
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CustomConfiguration);
        Assert.False(model.RawData.ContainsKey("custom_configuration"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtractAgent
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Config = new()
            {
                ChunkMode = ChunkMode.Page,
                CitationBbox = true,
                CiteSources = true,
                ConfidenceScores = true,
                ExtractModel = ExtractModel.Gemini2_0Flash,
                ExtractionMode = ExtractionMode.Balanced,
                ExtractionTarget = ExtractionTarget.PerDoc,
                HighResolutionMode = true,
                InvalidateCache = true,
                MultimodalFastMode = true,
                NumPagesContext = 1,
                PageRange = "page_range",
                ParseModel = ParseModel.AnthropicHaiku3_5,
                Priority = Priority.Critical,
                SystemPrompt = "system_prompt",
                UseReasoning = true,
            },
            DataSchema = new Dictionary<string, DataSchema?>()
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ExtractAgent
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Config = new()
            {
                ChunkMode = ChunkMode.Page,
                CitationBbox = true,
                CiteSources = true,
                ConfidenceScores = true,
                ExtractModel = ExtractModel.Gemini2_0Flash,
                ExtractionMode = ExtractionMode.Balanced,
                ExtractionTarget = ExtractionTarget.PerDoc,
                HighResolutionMode = true,
                InvalidateCache = true,
                MultimodalFastMode = true,
                NumPagesContext = 1,
                PageRange = "page_range",
                ParseModel = ParseModel.AnthropicHaiku3_5,
                Priority = Priority.Critical,
                SystemPrompt = "system_prompt",
                UseReasoning = true,
            },
            DataSchema = new Dictionary<string, DataSchema?>()
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            CreatedAt = null,
            CustomConfiguration = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CustomConfiguration);
        Assert.True(model.RawData.ContainsKey("custom_configuration"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtractAgent
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Config = new()
            {
                ChunkMode = ChunkMode.Page,
                CitationBbox = true,
                CiteSources = true,
                ConfidenceScores = true,
                ExtractModel = ExtractModel.Gemini2_0Flash,
                ExtractionMode = ExtractionMode.Balanced,
                ExtractionTarget = ExtractionTarget.PerDoc,
                HighResolutionMode = true,
                InvalidateCache = true,
                MultimodalFastMode = true,
                NumPagesContext = 1,
                PageRange = "page_range",
                ParseModel = ParseModel.AnthropicHaiku3_5,
                Priority = Priority.Critical,
                SystemPrompt = "system_prompt",
                UseReasoning = true,
            },
            DataSchema = new Dictionary<string, DataSchema?>()
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            CreatedAt = null,
            CustomConfiguration = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractAgent
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Config = new()
            {
                ChunkMode = ChunkMode.Page,
                CitationBbox = true,
                CiteSources = true,
                ConfidenceScores = true,
                ExtractModel = ExtractModel.Gemini2_0Flash,
                ExtractionMode = ExtractionMode.Balanced,
                ExtractionTarget = ExtractionTarget.PerDoc,
                HighResolutionMode = true,
                InvalidateCache = true,
                MultimodalFastMode = true,
                NumPagesContext = 1,
                PageRange = "page_range",
                ParseModel = ParseModel.AnthropicHaiku3_5,
                Priority = Priority.Critical,
                SystemPrompt = "system_prompt",
                UseReasoning = true,
            },
            DataSchema = new Dictionary<string, DataSchema?>()
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomConfiguration = CustomConfiguration.Default,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ExtractAgent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Config
        {
            ChunkMode = ChunkMode.Page,
            CitationBbox = true,
            CiteSources = true,
            ConfidenceScores = true,
            ExtractModel = ExtractModel.Gemini2_0Flash,
            ExtractionMode = ExtractionMode.Balanced,
            ExtractionTarget = ExtractionTarget.PerDoc,
            HighResolutionMode = true,
            InvalidateCache = true,
            MultimodalFastMode = true,
            NumPagesContext = 1,
            PageRange = "page_range",
            ParseModel = ParseModel.AnthropicHaiku3_5,
            Priority = Priority.Critical,
            SystemPrompt = "system_prompt",
            UseReasoning = true,
        };

        ApiEnum<string, ChunkMode> expectedChunkMode = ChunkMode.Page;
        bool expectedCitationBbox = true;
        bool expectedCiteSources = true;
        bool expectedConfidenceScores = true;
        ApiEnum<string, ExtractModel> expectedExtractModel = ExtractModel.Gemini2_0Flash;
        ApiEnum<string, ExtractionMode> expectedExtractionMode = ExtractionMode.Balanced;
        ApiEnum<string, ExtractionTarget> expectedExtractionTarget = ExtractionTarget.PerDoc;
        bool expectedHighResolutionMode = true;
        bool expectedInvalidateCache = true;
        bool expectedMultimodalFastMode = true;
        long expectedNumPagesContext = 1;
        string expectedPageRange = "page_range";
        ApiEnum<string, ParseModel> expectedParseModel = ParseModel.AnthropicHaiku3_5;
        ApiEnum<string, Priority> expectedPriority = Priority.Critical;
        string expectedSystemPrompt = "system_prompt";
        bool expectedUseReasoning = true;

        Assert.Equal(expectedChunkMode, model.ChunkMode);
        Assert.Equal(expectedCitationBbox, model.CitationBbox);
        Assert.Equal(expectedCiteSources, model.CiteSources);
        Assert.Equal(expectedConfidenceScores, model.ConfidenceScores);
        Assert.Equal(expectedExtractModel, model.ExtractModel);
        Assert.Equal(expectedExtractionMode, model.ExtractionMode);
        Assert.Equal(expectedExtractionTarget, model.ExtractionTarget);
        Assert.Equal(expectedHighResolutionMode, model.HighResolutionMode);
        Assert.Equal(expectedInvalidateCache, model.InvalidateCache);
        Assert.Equal(expectedMultimodalFastMode, model.MultimodalFastMode);
        Assert.Equal(expectedNumPagesContext, model.NumPagesContext);
        Assert.Equal(expectedPageRange, model.PageRange);
        Assert.Equal(expectedParseModel, model.ParseModel);
        Assert.Equal(expectedPriority, model.Priority);
        Assert.Equal(expectedSystemPrompt, model.SystemPrompt);
        Assert.Equal(expectedUseReasoning, model.UseReasoning);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Config
        {
            ChunkMode = ChunkMode.Page,
            CitationBbox = true,
            CiteSources = true,
            ConfidenceScores = true,
            ExtractModel = ExtractModel.Gemini2_0Flash,
            ExtractionMode = ExtractionMode.Balanced,
            ExtractionTarget = ExtractionTarget.PerDoc,
            HighResolutionMode = true,
            InvalidateCache = true,
            MultimodalFastMode = true,
            NumPagesContext = 1,
            PageRange = "page_range",
            ParseModel = ParseModel.AnthropicHaiku3_5,
            Priority = Priority.Critical,
            SystemPrompt = "system_prompt",
            UseReasoning = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Config>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Config
        {
            ChunkMode = ChunkMode.Page,
            CitationBbox = true,
            CiteSources = true,
            ConfidenceScores = true,
            ExtractModel = ExtractModel.Gemini2_0Flash,
            ExtractionMode = ExtractionMode.Balanced,
            ExtractionTarget = ExtractionTarget.PerDoc,
            HighResolutionMode = true,
            InvalidateCache = true,
            MultimodalFastMode = true,
            NumPagesContext = 1,
            PageRange = "page_range",
            ParseModel = ParseModel.AnthropicHaiku3_5,
            Priority = Priority.Critical,
            SystemPrompt = "system_prompt",
            UseReasoning = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Config>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, ChunkMode> expectedChunkMode = ChunkMode.Page;
        bool expectedCitationBbox = true;
        bool expectedCiteSources = true;
        bool expectedConfidenceScores = true;
        ApiEnum<string, ExtractModel> expectedExtractModel = ExtractModel.Gemini2_0Flash;
        ApiEnum<string, ExtractionMode> expectedExtractionMode = ExtractionMode.Balanced;
        ApiEnum<string, ExtractionTarget> expectedExtractionTarget = ExtractionTarget.PerDoc;
        bool expectedHighResolutionMode = true;
        bool expectedInvalidateCache = true;
        bool expectedMultimodalFastMode = true;
        long expectedNumPagesContext = 1;
        string expectedPageRange = "page_range";
        ApiEnum<string, ParseModel> expectedParseModel = ParseModel.AnthropicHaiku3_5;
        ApiEnum<string, Priority> expectedPriority = Priority.Critical;
        string expectedSystemPrompt = "system_prompt";
        bool expectedUseReasoning = true;

        Assert.Equal(expectedChunkMode, deserialized.ChunkMode);
        Assert.Equal(expectedCitationBbox, deserialized.CitationBbox);
        Assert.Equal(expectedCiteSources, deserialized.CiteSources);
        Assert.Equal(expectedConfidenceScores, deserialized.ConfidenceScores);
        Assert.Equal(expectedExtractModel, deserialized.ExtractModel);
        Assert.Equal(expectedExtractionMode, deserialized.ExtractionMode);
        Assert.Equal(expectedExtractionTarget, deserialized.ExtractionTarget);
        Assert.Equal(expectedHighResolutionMode, deserialized.HighResolutionMode);
        Assert.Equal(expectedInvalidateCache, deserialized.InvalidateCache);
        Assert.Equal(expectedMultimodalFastMode, deserialized.MultimodalFastMode);
        Assert.Equal(expectedNumPagesContext, deserialized.NumPagesContext);
        Assert.Equal(expectedPageRange, deserialized.PageRange);
        Assert.Equal(expectedParseModel, deserialized.ParseModel);
        Assert.Equal(expectedPriority, deserialized.Priority);
        Assert.Equal(expectedSystemPrompt, deserialized.SystemPrompt);
        Assert.Equal(expectedUseReasoning, deserialized.UseReasoning);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Config
        {
            ChunkMode = ChunkMode.Page,
            CitationBbox = true,
            CiteSources = true,
            ConfidenceScores = true,
            ExtractModel = ExtractModel.Gemini2_0Flash,
            ExtractionMode = ExtractionMode.Balanced,
            ExtractionTarget = ExtractionTarget.PerDoc,
            HighResolutionMode = true,
            InvalidateCache = true,
            MultimodalFastMode = true,
            NumPagesContext = 1,
            PageRange = "page_range",
            ParseModel = ParseModel.AnthropicHaiku3_5,
            Priority = Priority.Critical,
            SystemPrompt = "system_prompt",
            UseReasoning = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Config
        {
            ExtractModel = ExtractModel.Gemini2_0Flash,
            NumPagesContext = 1,
            PageRange = "page_range",
            ParseModel = ParseModel.AnthropicHaiku3_5,
            Priority = Priority.Critical,
            SystemPrompt = "system_prompt",
        };

        Assert.Null(model.ChunkMode);
        Assert.False(model.RawData.ContainsKey("chunk_mode"));
        Assert.Null(model.CitationBbox);
        Assert.False(model.RawData.ContainsKey("citation_bbox"));
        Assert.Null(model.CiteSources);
        Assert.False(model.RawData.ContainsKey("cite_sources"));
        Assert.Null(model.ConfidenceScores);
        Assert.False(model.RawData.ContainsKey("confidence_scores"));
        Assert.Null(model.ExtractionMode);
        Assert.False(model.RawData.ContainsKey("extraction_mode"));
        Assert.Null(model.ExtractionTarget);
        Assert.False(model.RawData.ContainsKey("extraction_target"));
        Assert.Null(model.HighResolutionMode);
        Assert.False(model.RawData.ContainsKey("high_resolution_mode"));
        Assert.Null(model.InvalidateCache);
        Assert.False(model.RawData.ContainsKey("invalidate_cache"));
        Assert.Null(model.MultimodalFastMode);
        Assert.False(model.RawData.ContainsKey("multimodal_fast_mode"));
        Assert.Null(model.UseReasoning);
        Assert.False(model.RawData.ContainsKey("use_reasoning"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Config
        {
            ExtractModel = ExtractModel.Gemini2_0Flash,
            NumPagesContext = 1,
            PageRange = "page_range",
            ParseModel = ParseModel.AnthropicHaiku3_5,
            Priority = Priority.Critical,
            SystemPrompt = "system_prompt",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Config
        {
            ExtractModel = ExtractModel.Gemini2_0Flash,
            NumPagesContext = 1,
            PageRange = "page_range",
            ParseModel = ParseModel.AnthropicHaiku3_5,
            Priority = Priority.Critical,
            SystemPrompt = "system_prompt",

            // Null should be interpreted as omitted for these properties
            ChunkMode = null,
            CitationBbox = null,
            CiteSources = null,
            ConfidenceScores = null,
            ExtractionMode = null,
            ExtractionTarget = null,
            HighResolutionMode = null,
            InvalidateCache = null,
            MultimodalFastMode = null,
            UseReasoning = null,
        };

        Assert.Null(model.ChunkMode);
        Assert.False(model.RawData.ContainsKey("chunk_mode"));
        Assert.Null(model.CitationBbox);
        Assert.False(model.RawData.ContainsKey("citation_bbox"));
        Assert.Null(model.CiteSources);
        Assert.False(model.RawData.ContainsKey("cite_sources"));
        Assert.Null(model.ConfidenceScores);
        Assert.False(model.RawData.ContainsKey("confidence_scores"));
        Assert.Null(model.ExtractionMode);
        Assert.False(model.RawData.ContainsKey("extraction_mode"));
        Assert.Null(model.ExtractionTarget);
        Assert.False(model.RawData.ContainsKey("extraction_target"));
        Assert.Null(model.HighResolutionMode);
        Assert.False(model.RawData.ContainsKey("high_resolution_mode"));
        Assert.Null(model.InvalidateCache);
        Assert.False(model.RawData.ContainsKey("invalidate_cache"));
        Assert.Null(model.MultimodalFastMode);
        Assert.False(model.RawData.ContainsKey("multimodal_fast_mode"));
        Assert.Null(model.UseReasoning);
        Assert.False(model.RawData.ContainsKey("use_reasoning"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Config
        {
            ExtractModel = ExtractModel.Gemini2_0Flash,
            NumPagesContext = 1,
            PageRange = "page_range",
            ParseModel = ParseModel.AnthropicHaiku3_5,
            Priority = Priority.Critical,
            SystemPrompt = "system_prompt",

            // Null should be interpreted as omitted for these properties
            ChunkMode = null,
            CitationBbox = null,
            CiteSources = null,
            ConfidenceScores = null,
            ExtractionMode = null,
            ExtractionTarget = null,
            HighResolutionMode = null,
            InvalidateCache = null,
            MultimodalFastMode = null,
            UseReasoning = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Config
        {
            ChunkMode = ChunkMode.Page,
            CitationBbox = true,
            CiteSources = true,
            ConfidenceScores = true,
            ExtractionMode = ExtractionMode.Balanced,
            ExtractionTarget = ExtractionTarget.PerDoc,
            HighResolutionMode = true,
            InvalidateCache = true,
            MultimodalFastMode = true,
            UseReasoning = true,
        };

        Assert.Null(model.ExtractModel);
        Assert.False(model.RawData.ContainsKey("extract_model"));
        Assert.Null(model.NumPagesContext);
        Assert.False(model.RawData.ContainsKey("num_pages_context"));
        Assert.Null(model.PageRange);
        Assert.False(model.RawData.ContainsKey("page_range"));
        Assert.Null(model.ParseModel);
        Assert.False(model.RawData.ContainsKey("parse_model"));
        Assert.Null(model.Priority);
        Assert.False(model.RawData.ContainsKey("priority"));
        Assert.Null(model.SystemPrompt);
        Assert.False(model.RawData.ContainsKey("system_prompt"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Config
        {
            ChunkMode = ChunkMode.Page,
            CitationBbox = true,
            CiteSources = true,
            ConfidenceScores = true,
            ExtractionMode = ExtractionMode.Balanced,
            ExtractionTarget = ExtractionTarget.PerDoc,
            HighResolutionMode = true,
            InvalidateCache = true,
            MultimodalFastMode = true,
            UseReasoning = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Config
        {
            ChunkMode = ChunkMode.Page,
            CitationBbox = true,
            CiteSources = true,
            ConfidenceScores = true,
            ExtractionMode = ExtractionMode.Balanced,
            ExtractionTarget = ExtractionTarget.PerDoc,
            HighResolutionMode = true,
            InvalidateCache = true,
            MultimodalFastMode = true,
            UseReasoning = true,

            ExtractModel = null,
            NumPagesContext = null,
            PageRange = null,
            ParseModel = null,
            Priority = null,
            SystemPrompt = null,
        };

        Assert.Null(model.ExtractModel);
        Assert.True(model.RawData.ContainsKey("extract_model"));
        Assert.Null(model.NumPagesContext);
        Assert.True(model.RawData.ContainsKey("num_pages_context"));
        Assert.Null(model.PageRange);
        Assert.True(model.RawData.ContainsKey("page_range"));
        Assert.Null(model.ParseModel);
        Assert.True(model.RawData.ContainsKey("parse_model"));
        Assert.Null(model.Priority);
        Assert.True(model.RawData.ContainsKey("priority"));
        Assert.Null(model.SystemPrompt);
        Assert.True(model.RawData.ContainsKey("system_prompt"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Config
        {
            ChunkMode = ChunkMode.Page,
            CitationBbox = true,
            CiteSources = true,
            ConfidenceScores = true,
            ExtractionMode = ExtractionMode.Balanced,
            ExtractionTarget = ExtractionTarget.PerDoc,
            HighResolutionMode = true,
            InvalidateCache = true,
            MultimodalFastMode = true,
            UseReasoning = true,

            ExtractModel = null,
            NumPagesContext = null,
            PageRange = null,
            ParseModel = null,
            Priority = null,
            SystemPrompt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Config
        {
            ChunkMode = ChunkMode.Page,
            CitationBbox = true,
            CiteSources = true,
            ConfidenceScores = true,
            ExtractModel = ExtractModel.Gemini2_0Flash,
            ExtractionMode = ExtractionMode.Balanced,
            ExtractionTarget = ExtractionTarget.PerDoc,
            HighResolutionMode = true,
            InvalidateCache = true,
            MultimodalFastMode = true,
            NumPagesContext = 1,
            PageRange = "page_range",
            ParseModel = ParseModel.AnthropicHaiku3_5,
            Priority = Priority.Critical,
            SystemPrompt = "system_prompt",
            UseReasoning = true,
        };

        Config copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChunkModeTest : TestBase
{
    [Theory]
    [InlineData(ChunkMode.Page)]
    [InlineData(ChunkMode.Section)]
    public void Validation_Works(ChunkMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChunkMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChunkMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChunkMode.Page)]
    [InlineData(ChunkMode.Section)]
    public void SerializationRoundtrip_Works(ChunkMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChunkMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChunkMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChunkMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChunkMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExtractModelTest : TestBase
{
    [Theory]
    [InlineData(ExtractModel.Gemini2_0Flash)]
    [InlineData(ExtractModel.Gemini2_5Flash)]
    [InlineData(ExtractModel.Gemini2_5FlashLite)]
    [InlineData(ExtractModel.Gemini2_5Pro)]
    [InlineData(ExtractModel.OpenAIGpt4_1)]
    [InlineData(ExtractModel.OpenAIGpt4_1Mini)]
    [InlineData(ExtractModel.OpenAIGpt4_1Nano)]
    [InlineData(ExtractModel.OpenAIGpt4o)]
    [InlineData(ExtractModel.OpenAIGpt4oMini)]
    [InlineData(ExtractModel.OpenAIGpt5)]
    [InlineData(ExtractModel.OpenAIGpt5Mini)]
    public void Validation_Works(ExtractModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExtractModel.Gemini2_0Flash)]
    [InlineData(ExtractModel.Gemini2_5Flash)]
    [InlineData(ExtractModel.Gemini2_5FlashLite)]
    [InlineData(ExtractModel.Gemini2_5Pro)]
    [InlineData(ExtractModel.OpenAIGpt4_1)]
    [InlineData(ExtractModel.OpenAIGpt4_1Mini)]
    [InlineData(ExtractModel.OpenAIGpt4_1Nano)]
    [InlineData(ExtractModel.OpenAIGpt4o)]
    [InlineData(ExtractModel.OpenAIGpt4oMini)]
    [InlineData(ExtractModel.OpenAIGpt5)]
    [InlineData(ExtractModel.OpenAIGpt5Mini)]
    public void SerializationRoundtrip_Works(ExtractModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ExtractionModeTest : TestBase
{
    [Theory]
    [InlineData(ExtractionMode.Balanced)]
    [InlineData(ExtractionMode.Fast)]
    [InlineData(ExtractionMode.Multimodal)]
    [InlineData(ExtractionMode.Premium)]
    public void Validation_Works(ExtractionMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExtractionMode.Balanced)]
    [InlineData(ExtractionMode.Fast)]
    [InlineData(ExtractionMode.Multimodal)]
    [InlineData(ExtractionMode.Premium)]
    public void SerializationRoundtrip_Works(ExtractionMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractionMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ExtractionMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ExtractionMode>>(
            json,
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

public class ParseModelTest : TestBase
{
    [Theory]
    [InlineData(ParseModel.AnthropicHaiku3_5)]
    [InlineData(ParseModel.AnthropicHaiku4_5)]
    [InlineData(ParseModel.AnthropicSonnet3_5)]
    [InlineData(ParseModel.AnthropicSonnet3_5V2)]
    [InlineData(ParseModel.AnthropicSonnet3_7)]
    [InlineData(ParseModel.AnthropicSonnet4_0)]
    [InlineData(ParseModel.AnthropicSonnet4_5)]
    [InlineData(ParseModel.Gemini2_0Flash)]
    [InlineData(ParseModel.Gemini2_0FlashLite)]
    [InlineData(ParseModel.Gemini2_5Flash)]
    [InlineData(ParseModel.Gemini2_5FlashLite)]
    [InlineData(ParseModel.Gemini2_5Pro)]
    [InlineData(ParseModel.Gemini3_0Pro)]
    [InlineData(ParseModel.Gemini3_1Pro)]
    [InlineData(ParseModel.OpenAIGpt4_1)]
    [InlineData(ParseModel.OpenAIGpt4_1Mini)]
    [InlineData(ParseModel.OpenAIGpt4_1Nano)]
    [InlineData(ParseModel.OpenAIGpt4o)]
    [InlineData(ParseModel.OpenAIGpt4oMini)]
    [InlineData(ParseModel.OpenAIGpt5)]
    [InlineData(ParseModel.OpenAIGpt5Mini)]
    [InlineData(ParseModel.OpenAIGpt5Nano)]
    [InlineData(ParseModel.OpenAITextEmbedding3Large)]
    [InlineData(ParseModel.OpenAITextEmbedding3Small)]
    [InlineData(ParseModel.OpenAIWhisper1)]
    public void Validation_Works(ParseModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ParseModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ParseModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ParseModel.AnthropicHaiku3_5)]
    [InlineData(ParseModel.AnthropicHaiku4_5)]
    [InlineData(ParseModel.AnthropicSonnet3_5)]
    [InlineData(ParseModel.AnthropicSonnet3_5V2)]
    [InlineData(ParseModel.AnthropicSonnet3_7)]
    [InlineData(ParseModel.AnthropicSonnet4_0)]
    [InlineData(ParseModel.AnthropicSonnet4_5)]
    [InlineData(ParseModel.Gemini2_0Flash)]
    [InlineData(ParseModel.Gemini2_0FlashLite)]
    [InlineData(ParseModel.Gemini2_5Flash)]
    [InlineData(ParseModel.Gemini2_5FlashLite)]
    [InlineData(ParseModel.Gemini2_5Pro)]
    [InlineData(ParseModel.Gemini3_0Pro)]
    [InlineData(ParseModel.Gemini3_1Pro)]
    [InlineData(ParseModel.OpenAIGpt4_1)]
    [InlineData(ParseModel.OpenAIGpt4_1Mini)]
    [InlineData(ParseModel.OpenAIGpt4_1Nano)]
    [InlineData(ParseModel.OpenAIGpt4o)]
    [InlineData(ParseModel.OpenAIGpt4oMini)]
    [InlineData(ParseModel.OpenAIGpt5)]
    [InlineData(ParseModel.OpenAIGpt5Mini)]
    [InlineData(ParseModel.OpenAIGpt5Nano)]
    [InlineData(ParseModel.OpenAITextEmbedding3Large)]
    [InlineData(ParseModel.OpenAITextEmbedding3Small)]
    [InlineData(ParseModel.OpenAIWhisper1)]
    public void SerializationRoundtrip_Works(ParseModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ParseModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ParseModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ParseModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ParseModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PriorityTest : TestBase
{
    [Theory]
    [InlineData(Priority.Critical)]
    [InlineData(Priority.High)]
    [InlineData(Priority.Low)]
    [InlineData(Priority.Medium)]
    public void Validation_Works(Priority rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Priority> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Priority>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Priority.Critical)]
    [InlineData(Priority.High)]
    [InlineData(Priority.Low)]
    [InlineData(Priority.Medium)]
    public void SerializationRoundtrip_Works(Priority rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Priority> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Priority>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Priority>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Priority>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataSchemaTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        DataSchema value = new(
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
        DataSchema value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        DataSchema value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        DataSchema value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        DataSchema value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        DataSchema value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        DataSchema value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        DataSchema value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        DataSchema value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        DataSchema value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CustomConfigurationTest : TestBase
{
    [Theory]
    [InlineData(CustomConfiguration.Default)]
    public void Validation_Works(CustomConfiguration rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomConfiguration> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomConfiguration>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomConfiguration.Default)]
    public void SerializationRoundtrip_Works(CustomConfiguration rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomConfiguration> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CustomConfiguration>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomConfiguration>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CustomConfiguration>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
