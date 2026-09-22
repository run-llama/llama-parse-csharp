using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.ExtractionAgents;

namespace LlamaCloud.Tests.Models.ExtractionAgents;

public class ExtractionAgentListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractionAgentListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        List<ExtractAgent> expectedItems =
        [
            new()
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
            },
        ];
        string expectedNextPageToken = "next_page_token";
        long expectedTotalSize = 0;

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextPageToken, model.NextPageToken);
        Assert.Equal(expectedTotalSize, model.TotalSize);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractionAgentListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractionAgentListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractionAgentListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractionAgentListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ExtractAgent> expectedItems =
        [
            new()
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
            },
        ];
        string expectedNextPageToken = "next_page_token";
        long expectedTotalSize = 0;

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextPageToken, deserialized.NextPageToken);
        Assert.Equal(expectedTotalSize, deserialized.TotalSize);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractionAgentListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtractionAgentListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        Assert.Null(model.NextPageToken);
        Assert.False(model.RawData.ContainsKey("next_page_token"));
        Assert.Null(model.TotalSize);
        Assert.False(model.RawData.ContainsKey("total_size"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtractionAgentListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ExtractionAgentListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],

            NextPageToken = null,
            TotalSize = null,
        };

        Assert.Null(model.NextPageToken);
        Assert.True(model.RawData.ContainsKey("next_page_token"));
        Assert.Null(model.TotalSize);
        Assert.True(model.RawData.ContainsKey("total_size"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtractionAgentListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],

            NextPageToken = null,
            TotalSize = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractionAgentListPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        ExtractionAgentListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
