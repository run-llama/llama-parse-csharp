using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Beta.Retrieval;

namespace LlamaCloud.Tests.Models.Beta.Retrieval;

public class RetrievalRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RetrievalRetrieveResponse
        {
            Results =
            [
                new()
                {
                    Content = "content",
                    Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
                    RerankScore = 0,
                    Score = 0,
                    StaticFields = new()
                    {
                        Attachments =
                        [
                            new()
                            {
                                AttachmentName = "attachment_name",
                                SourceID = "source_id",
                                Type = "type",
                            },
                        ],
                        ChunkEndChar = 0,
                        ChunkIndex = 0,
                        ChunkStartChar = 0,
                        ChunkTokenCount = 0,
                        PageRangeEnd = 0,
                        PageRangeStart = 0,
                        ParsedDirectoryFileID = "parsed_directory_file_id",
                    },
                },
            ],
        };

        List<Result> expectedResults =
        [
            new()
            {
                Content = "content",
                Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
                RerankScore = 0,
                Score = 0,
                StaticFields = new()
                {
                    Attachments =
                    [
                        new()
                        {
                            AttachmentName = "attachment_name",
                            SourceID = "source_id",
                            Type = "type",
                        },
                    ],
                    ChunkEndChar = 0,
                    ChunkIndex = 0,
                    ChunkStartChar = 0,
                    ChunkTokenCount = 0,
                    PageRangeEnd = 0,
                    PageRangeStart = 0,
                    ParsedDirectoryFileID = "parsed_directory_file_id",
                },
            },
        ];

        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RetrievalRetrieveResponse
        {
            Results =
            [
                new()
                {
                    Content = "content",
                    Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
                    RerankScore = 0,
                    Score = 0,
                    StaticFields = new()
                    {
                        Attachments =
                        [
                            new()
                            {
                                AttachmentName = "attachment_name",
                                SourceID = "source_id",
                                Type = "type",
                            },
                        ],
                        ChunkEndChar = 0,
                        ChunkIndex = 0,
                        ChunkStartChar = 0,
                        ChunkTokenCount = 0,
                        PageRangeEnd = 0,
                        PageRangeStart = 0,
                        ParsedDirectoryFileID = "parsed_directory_file_id",
                    },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrievalRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RetrievalRetrieveResponse
        {
            Results =
            [
                new()
                {
                    Content = "content",
                    Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
                    RerankScore = 0,
                    Score = 0,
                    StaticFields = new()
                    {
                        Attachments =
                        [
                            new()
                            {
                                AttachmentName = "attachment_name",
                                SourceID = "source_id",
                                Type = "type",
                            },
                        ],
                        ChunkEndChar = 0,
                        ChunkIndex = 0,
                        ChunkStartChar = 0,
                        ChunkTokenCount = 0,
                        PageRangeEnd = 0,
                        PageRangeStart = 0,
                        ParsedDirectoryFileID = "parsed_directory_file_id",
                    },
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrievalRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Result> expectedResults =
        [
            new()
            {
                Content = "content",
                Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
                RerankScore = 0,
                Score = 0,
                StaticFields = new()
                {
                    Attachments =
                    [
                        new()
                        {
                            AttachmentName = "attachment_name",
                            SourceID = "source_id",
                            Type = "type",
                        },
                    ],
                    ChunkEndChar = 0,
                    ChunkIndex = 0,
                    ChunkStartChar = 0,
                    ChunkTokenCount = 0,
                    PageRangeEnd = 0,
                    PageRangeStart = 0,
                    ParsedDirectoryFileID = "parsed_directory_file_id",
                },
            },
        ];

        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RetrievalRetrieveResponse
        {
            Results =
            [
                new()
                {
                    Content = "content",
                    Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
                    RerankScore = 0,
                    Score = 0,
                    StaticFields = new()
                    {
                        Attachments =
                        [
                            new()
                            {
                                AttachmentName = "attachment_name",
                                SourceID = "source_id",
                                Type = "type",
                            },
                        ],
                        ChunkEndChar = 0,
                        ChunkIndex = 0,
                        ChunkStartChar = 0,
                        ChunkTokenCount = 0,
                        PageRangeEnd = 0,
                        PageRangeStart = 0,
                        ParsedDirectoryFileID = "parsed_directory_file_id",
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RetrievalRetrieveResponse
        {
            Results =
            [
                new()
                {
                    Content = "content",
                    Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
                    RerankScore = 0,
                    Score = 0,
                    StaticFields = new()
                    {
                        Attachments =
                        [
                            new()
                            {
                                AttachmentName = "attachment_name",
                                SourceID = "source_id",
                                Type = "type",
                            },
                        ],
                        ChunkEndChar = 0,
                        ChunkIndex = 0,
                        ChunkStartChar = 0,
                        ChunkTokenCount = 0,
                        PageRangeEnd = 0,
                        PageRangeStart = 0,
                        ParsedDirectoryFileID = "parsed_directory_file_id",
                    },
                },
            ],
        };

        RetrievalRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            Content = "content",
            Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
            RerankScore = 0,
            Score = 0,
            StaticFields = new()
            {
                Attachments =
                [
                    new()
                    {
                        AttachmentName = "attachment_name",
                        SourceID = "source_id",
                        Type = "type",
                    },
                ],
                ChunkEndChar = 0,
                ChunkIndex = 0,
                ChunkStartChar = 0,
                ChunkTokenCount = 0,
                PageRangeEnd = 0,
                PageRangeStart = 0,
                ParsedDirectoryFileID = "parsed_directory_file_id",
            },
        };

        string expectedContent = "content";
        Dictionary<string, Metadata?> expectedMetadata = new() { { "foo", "string" } };
        double expectedRerankScore = 0;
        double expectedScore = 0;
        StaticFields expectedStaticFields = new()
        {
            Attachments =
            [
                new()
                {
                    AttachmentName = "attachment_name",
                    SourceID = "source_id",
                    Type = "type",
                },
            ],
            ChunkEndChar = 0,
            ChunkIndex = 0,
            ChunkStartChar = 0,
            ChunkTokenCount = 0,
            PageRangeEnd = 0,
            PageRangeStart = 0,
            ParsedDirectoryFileID = "parsed_directory_file_id",
        };

        Assert.Equal(expectedContent, model.Content);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedRerankScore, model.RerankScore);
        Assert.Equal(expectedScore, model.Score);
        Assert.Equal(expectedStaticFields, model.StaticFields);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Result
        {
            Content = "content",
            Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
            RerankScore = 0,
            Score = 0,
            StaticFields = new()
            {
                Attachments =
                [
                    new()
                    {
                        AttachmentName = "attachment_name",
                        SourceID = "source_id",
                        Type = "type",
                    },
                ],
                ChunkEndChar = 0,
                ChunkIndex = 0,
                ChunkStartChar = 0,
                ChunkTokenCount = 0,
                PageRangeEnd = 0,
                PageRangeStart = 0,
                ParsedDirectoryFileID = "parsed_directory_file_id",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            Content = "content",
            Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
            RerankScore = 0,
            Score = 0,
            StaticFields = new()
            {
                Attachments =
                [
                    new()
                    {
                        AttachmentName = "attachment_name",
                        SourceID = "source_id",
                        Type = "type",
                    },
                ],
                ChunkEndChar = 0,
                ChunkIndex = 0,
                ChunkStartChar = 0,
                ChunkTokenCount = 0,
                PageRangeEnd = 0,
                PageRangeStart = 0,
                ParsedDirectoryFileID = "parsed_directory_file_id",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        Dictionary<string, Metadata?> expectedMetadata = new() { { "foo", "string" } };
        double expectedRerankScore = 0;
        double expectedScore = 0;
        StaticFields expectedStaticFields = new()
        {
            Attachments =
            [
                new()
                {
                    AttachmentName = "attachment_name",
                    SourceID = "source_id",
                    Type = "type",
                },
            ],
            ChunkEndChar = 0,
            ChunkIndex = 0,
            ChunkStartChar = 0,
            ChunkTokenCount = 0,
            PageRangeEnd = 0,
            PageRangeStart = 0,
            ParsedDirectoryFileID = "parsed_directory_file_id",
        };

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedRerankScore, deserialized.RerankScore);
        Assert.Equal(expectedScore, deserialized.Score);
        Assert.Equal(expectedStaticFields, deserialized.StaticFields);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Result
        {
            Content = "content",
            Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
            RerankScore = 0,
            Score = 0,
            StaticFields = new()
            {
                Attachments =
                [
                    new()
                    {
                        AttachmentName = "attachment_name",
                        SourceID = "source_id",
                        Type = "type",
                    },
                ],
                ChunkEndChar = 0,
                ChunkIndex = 0,
                ChunkStartChar = 0,
                ChunkTokenCount = 0,
                PageRangeEnd = 0,
                PageRangeStart = 0,
                ParsedDirectoryFileID = "parsed_directory_file_id",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Result
        {
            Content = "content",
            Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
            RerankScore = 0,
            Score = 0,
        };

        Assert.Null(model.StaticFields);
        Assert.False(model.RawData.ContainsKey("static_fields"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Result
        {
            Content = "content",
            Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
            RerankScore = 0,
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Result
        {
            Content = "content",
            Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
            RerankScore = 0,
            Score = 0,

            // Null should be interpreted as omitted for these properties
            StaticFields = null,
        };

        Assert.Null(model.StaticFields);
        Assert.False(model.RawData.ContainsKey("static_fields"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Result
        {
            Content = "content",
            Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
            RerankScore = 0,
            Score = 0,

            // Null should be interpreted as omitted for these properties
            StaticFields = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Result
        {
            Content = "content",
            StaticFields = new()
            {
                Attachments =
                [
                    new()
                    {
                        AttachmentName = "attachment_name",
                        SourceID = "source_id",
                        Type = "type",
                    },
                ],
                ChunkEndChar = 0,
                ChunkIndex = 0,
                ChunkStartChar = 0,
                ChunkTokenCount = 0,
                PageRangeEnd = 0,
                PageRangeStart = 0,
                ParsedDirectoryFileID = "parsed_directory_file_id",
            },
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.RerankScore);
        Assert.False(model.RawData.ContainsKey("rerank_score"));
        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Result
        {
            Content = "content",
            StaticFields = new()
            {
                Attachments =
                [
                    new()
                    {
                        AttachmentName = "attachment_name",
                        SourceID = "source_id",
                        Type = "type",
                    },
                ],
                ChunkEndChar = 0,
                ChunkIndex = 0,
                ChunkStartChar = 0,
                ChunkTokenCount = 0,
                PageRangeEnd = 0,
                PageRangeStart = 0,
                ParsedDirectoryFileID = "parsed_directory_file_id",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Result
        {
            Content = "content",
            StaticFields = new()
            {
                Attachments =
                [
                    new()
                    {
                        AttachmentName = "attachment_name",
                        SourceID = "source_id",
                        Type = "type",
                    },
                ],
                ChunkEndChar = 0,
                ChunkIndex = 0,
                ChunkStartChar = 0,
                ChunkTokenCount = 0,
                PageRangeEnd = 0,
                PageRangeStart = 0,
                ParsedDirectoryFileID = "parsed_directory_file_id",
            },

            Metadata = null,
            RerankScore = null,
            Score = null,
        };

        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.RerankScore);
        Assert.True(model.RawData.ContainsKey("rerank_score"));
        Assert.Null(model.Score);
        Assert.True(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Result
        {
            Content = "content",
            StaticFields = new()
            {
                Attachments =
                [
                    new()
                    {
                        AttachmentName = "attachment_name",
                        SourceID = "source_id",
                        Type = "type",
                    },
                ],
                ChunkEndChar = 0,
                ChunkIndex = 0,
                ChunkStartChar = 0,
                ChunkTokenCount = 0,
                PageRangeEnd = 0,
                PageRangeStart = 0,
                ParsedDirectoryFileID = "parsed_directory_file_id",
            },

            Metadata = null,
            RerankScore = null,
            Score = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Result
        {
            Content = "content",
            Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
            RerankScore = 0,
            Score = 0,
            StaticFields = new()
            {
                Attachments =
                [
                    new()
                    {
                        AttachmentName = "attachment_name",
                        SourceID = "source_id",
                        Type = "type",
                    },
                ],
                ChunkEndChar = 0,
                ChunkIndex = 0,
                ChunkStartChar = 0,
                ChunkTokenCount = 0,
                PageRangeEnd = 0,
                PageRangeStart = 0,
                ParsedDirectoryFileID = "parsed_directory_file_id",
            },
        };

        Result copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MetadataTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Metadata value = "string";
        value.Validate();
    }

    [Fact]
    public void LongValidationWorks()
    {
        Metadata value = 0;
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        Metadata value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        Metadata value = true;
        value.Validate();
    }

    [Fact]
    public void ListValueValidationWorks()
    {
        Metadata value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Metadata value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Metadata value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Metadata value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        Metadata value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ListValueSerializationRoundtripWorks()
    {
        Metadata value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StaticFieldsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StaticFields
        {
            Attachments =
            [
                new()
                {
                    AttachmentName = "attachment_name",
                    SourceID = "source_id",
                    Type = "type",
                },
            ],
            ChunkEndChar = 0,
            ChunkIndex = 0,
            ChunkStartChar = 0,
            ChunkTokenCount = 0,
            PageRangeEnd = 0,
            PageRangeStart = 0,
            ParsedDirectoryFileID = "parsed_directory_file_id",
        };

        List<Attachment> expectedAttachments =
        [
            new()
            {
                AttachmentName = "attachment_name",
                SourceID = "source_id",
                Type = "type",
            },
        ];
        long expectedChunkEndChar = 0;
        long expectedChunkIndex = 0;
        long expectedChunkStartChar = 0;
        long expectedChunkTokenCount = 0;
        long expectedPageRangeEnd = 0;
        long expectedPageRangeStart = 0;
        string expectedParsedDirectoryFileID = "parsed_directory_file_id";

        Assert.NotNull(model.Attachments);
        Assert.Equal(expectedAttachments.Count, model.Attachments.Count);
        for (int i = 0; i < expectedAttachments.Count; i++)
        {
            Assert.Equal(expectedAttachments[i], model.Attachments[i]);
        }
        Assert.Equal(expectedChunkEndChar, model.ChunkEndChar);
        Assert.Equal(expectedChunkIndex, model.ChunkIndex);
        Assert.Equal(expectedChunkStartChar, model.ChunkStartChar);
        Assert.Equal(expectedChunkTokenCount, model.ChunkTokenCount);
        Assert.Equal(expectedPageRangeEnd, model.PageRangeEnd);
        Assert.Equal(expectedPageRangeStart, model.PageRangeStart);
        Assert.Equal(expectedParsedDirectoryFileID, model.ParsedDirectoryFileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StaticFields
        {
            Attachments =
            [
                new()
                {
                    AttachmentName = "attachment_name",
                    SourceID = "source_id",
                    Type = "type",
                },
            ],
            ChunkEndChar = 0,
            ChunkIndex = 0,
            ChunkStartChar = 0,
            ChunkTokenCount = 0,
            PageRangeEnd = 0,
            PageRangeStart = 0,
            ParsedDirectoryFileID = "parsed_directory_file_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StaticFields>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StaticFields
        {
            Attachments =
            [
                new()
                {
                    AttachmentName = "attachment_name",
                    SourceID = "source_id",
                    Type = "type",
                },
            ],
            ChunkEndChar = 0,
            ChunkIndex = 0,
            ChunkStartChar = 0,
            ChunkTokenCount = 0,
            PageRangeEnd = 0,
            PageRangeStart = 0,
            ParsedDirectoryFileID = "parsed_directory_file_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StaticFields>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Attachment> expectedAttachments =
        [
            new()
            {
                AttachmentName = "attachment_name",
                SourceID = "source_id",
                Type = "type",
            },
        ];
        long expectedChunkEndChar = 0;
        long expectedChunkIndex = 0;
        long expectedChunkStartChar = 0;
        long expectedChunkTokenCount = 0;
        long expectedPageRangeEnd = 0;
        long expectedPageRangeStart = 0;
        string expectedParsedDirectoryFileID = "parsed_directory_file_id";

        Assert.NotNull(deserialized.Attachments);
        Assert.Equal(expectedAttachments.Count, deserialized.Attachments.Count);
        for (int i = 0; i < expectedAttachments.Count; i++)
        {
            Assert.Equal(expectedAttachments[i], deserialized.Attachments[i]);
        }
        Assert.Equal(expectedChunkEndChar, deserialized.ChunkEndChar);
        Assert.Equal(expectedChunkIndex, deserialized.ChunkIndex);
        Assert.Equal(expectedChunkStartChar, deserialized.ChunkStartChar);
        Assert.Equal(expectedChunkTokenCount, deserialized.ChunkTokenCount);
        Assert.Equal(expectedPageRangeEnd, deserialized.PageRangeEnd);
        Assert.Equal(expectedPageRangeStart, deserialized.PageRangeStart);
        Assert.Equal(expectedParsedDirectoryFileID, deserialized.ParsedDirectoryFileID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StaticFields
        {
            Attachments =
            [
                new()
                {
                    AttachmentName = "attachment_name",
                    SourceID = "source_id",
                    Type = "type",
                },
            ],
            ChunkEndChar = 0,
            ChunkIndex = 0,
            ChunkStartChar = 0,
            ChunkTokenCount = 0,
            PageRangeEnd = 0,
            PageRangeStart = 0,
            ParsedDirectoryFileID = "parsed_directory_file_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StaticFields
        {
            ChunkEndChar = 0,
            ChunkIndex = 0,
            ChunkStartChar = 0,
            ChunkTokenCount = 0,
            PageRangeEnd = 0,
            PageRangeStart = 0,
            ParsedDirectoryFileID = "parsed_directory_file_id",
        };

        Assert.Null(model.Attachments);
        Assert.False(model.RawData.ContainsKey("attachments"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new StaticFields
        {
            ChunkEndChar = 0,
            ChunkIndex = 0,
            ChunkStartChar = 0,
            ChunkTokenCount = 0,
            PageRangeEnd = 0,
            PageRangeStart = 0,
            ParsedDirectoryFileID = "parsed_directory_file_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new StaticFields
        {
            ChunkEndChar = 0,
            ChunkIndex = 0,
            ChunkStartChar = 0,
            ChunkTokenCount = 0,
            PageRangeEnd = 0,
            PageRangeStart = 0,
            ParsedDirectoryFileID = "parsed_directory_file_id",

            // Null should be interpreted as omitted for these properties
            Attachments = null,
        };

        Assert.Null(model.Attachments);
        Assert.False(model.RawData.ContainsKey("attachments"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StaticFields
        {
            ChunkEndChar = 0,
            ChunkIndex = 0,
            ChunkStartChar = 0,
            ChunkTokenCount = 0,
            PageRangeEnd = 0,
            PageRangeStart = 0,
            ParsedDirectoryFileID = "parsed_directory_file_id",

            // Null should be interpreted as omitted for these properties
            Attachments = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StaticFields
        {
            Attachments =
            [
                new()
                {
                    AttachmentName = "attachment_name",
                    SourceID = "source_id",
                    Type = "type",
                },
            ],
        };

        Assert.Null(model.ChunkEndChar);
        Assert.False(model.RawData.ContainsKey("chunk_end_char"));
        Assert.Null(model.ChunkIndex);
        Assert.False(model.RawData.ContainsKey("chunk_index"));
        Assert.Null(model.ChunkStartChar);
        Assert.False(model.RawData.ContainsKey("chunk_start_char"));
        Assert.Null(model.ChunkTokenCount);
        Assert.False(model.RawData.ContainsKey("chunk_token_count"));
        Assert.Null(model.PageRangeEnd);
        Assert.False(model.RawData.ContainsKey("page_range_end"));
        Assert.Null(model.PageRangeStart);
        Assert.False(model.RawData.ContainsKey("page_range_start"));
        Assert.Null(model.ParsedDirectoryFileID);
        Assert.False(model.RawData.ContainsKey("parsed_directory_file_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new StaticFields
        {
            Attachments =
            [
                new()
                {
                    AttachmentName = "attachment_name",
                    SourceID = "source_id",
                    Type = "type",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new StaticFields
        {
            Attachments =
            [
                new()
                {
                    AttachmentName = "attachment_name",
                    SourceID = "source_id",
                    Type = "type",
                },
            ],

            ChunkEndChar = null,
            ChunkIndex = null,
            ChunkStartChar = null,
            ChunkTokenCount = null,
            PageRangeEnd = null,
            PageRangeStart = null,
            ParsedDirectoryFileID = null,
        };

        Assert.Null(model.ChunkEndChar);
        Assert.True(model.RawData.ContainsKey("chunk_end_char"));
        Assert.Null(model.ChunkIndex);
        Assert.True(model.RawData.ContainsKey("chunk_index"));
        Assert.Null(model.ChunkStartChar);
        Assert.True(model.RawData.ContainsKey("chunk_start_char"));
        Assert.Null(model.ChunkTokenCount);
        Assert.True(model.RawData.ContainsKey("chunk_token_count"));
        Assert.Null(model.PageRangeEnd);
        Assert.True(model.RawData.ContainsKey("page_range_end"));
        Assert.Null(model.PageRangeStart);
        Assert.True(model.RawData.ContainsKey("page_range_start"));
        Assert.Null(model.ParsedDirectoryFileID);
        Assert.True(model.RawData.ContainsKey("parsed_directory_file_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StaticFields
        {
            Attachments =
            [
                new()
                {
                    AttachmentName = "attachment_name",
                    SourceID = "source_id",
                    Type = "type",
                },
            ],

            ChunkEndChar = null,
            ChunkIndex = null,
            ChunkStartChar = null,
            ChunkTokenCount = null,
            PageRangeEnd = null,
            PageRangeStart = null,
            ParsedDirectoryFileID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StaticFields
        {
            Attachments =
            [
                new()
                {
                    AttachmentName = "attachment_name",
                    SourceID = "source_id",
                    Type = "type",
                },
            ],
            ChunkEndChar = 0,
            ChunkIndex = 0,
            ChunkStartChar = 0,
            ChunkTokenCount = 0,
            PageRangeEnd = 0,
            PageRangeStart = 0,
            ParsedDirectoryFileID = "parsed_directory_file_id",
        };

        StaticFields copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AttachmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Attachment
        {
            AttachmentName = "attachment_name",
            SourceID = "source_id",
            Type = "type",
        };

        string expectedAttachmentName = "attachment_name";
        string expectedSourceID = "source_id";
        string expectedType = "type";

        Assert.Equal(expectedAttachmentName, model.AttachmentName);
        Assert.Equal(expectedSourceID, model.SourceID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Attachment
        {
            AttachmentName = "attachment_name",
            SourceID = "source_id",
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attachment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Attachment
        {
            AttachmentName = "attachment_name",
            SourceID = "source_id",
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Attachment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAttachmentName = "attachment_name";
        string expectedSourceID = "source_id";
        string expectedType = "type";

        Assert.Equal(expectedAttachmentName, deserialized.AttachmentName);
        Assert.Equal(expectedSourceID, deserialized.SourceID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Attachment
        {
            AttachmentName = "attachment_name",
            SourceID = "source_id",
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Attachment
        {
            AttachmentName = "attachment_name",
            SourceID = "source_id",
            Type = "type",
        };

        Attachment copied = new(model);

        Assert.Equal(model, copied);
    }
}
