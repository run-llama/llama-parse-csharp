using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Extract;

namespace LlamaCloud.Tests.Models.Extract;

public class ExtractV2JobQueryResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractV2JobQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "ext-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = "COMPLETED",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Configuration = new()
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
                        ParseTier = ParseTier.Fast,
                        SheetNames = ["Sheet 1", "Q4 Summary"],
                        SpreadsheetMode = true,
                        SystemPrompt =
                            "Extract all monetary values in USD. If a currency is not specified, assume USD.",
                        TargetPages = "1,3,5-7",
                        Tier = Tier.CostEffective,
                        Version = "latest",
                    },
                    ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
                    ErrorMessage = "error_message",
                    ExtractMetadata = new()
                    {
                        FieldMetadata = new()
                        {
                            DocumentMetadata = new Dictionary<string, DocumentMetadata?>()
                            {
                                {
                                    "items",
                                    new(
                                        [
                                            JsonSerializer.Deserialize<JsonElement>(
                                                """
                                                {
                                                  "amount": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10.00",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 1
                                                  },
                                                  "description": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10/month",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 0.998
                                                  }
                                                }
                                                """
                                            ),
                                        ]
                                    )
                                },
                                {
                                    "total",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                                {
                                    "vendor",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "extraction_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "parsing_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                            },
                            PageMetadata =
                            [
                                new Dictionary<string, PageMetadata?>()
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
                            ],
                            RowMetadata =
                            [
                                new Dictionary<string, RowMetadata?>()
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
                            ],
                        },
                        ParseJobID = "parse_job_id",
                        ParseTier = "parse_tier",
                    },
                    ExtractResult = new(
                        new Dictionary<string, UnionMember0Item?>()
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
                        }
                    ),
                    Metadata = new()
                    {
                        Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
                    },
                    Usage = new()
                    {
                        Credits = 30,
                        ExtractCredits = 45,
                        ParseCredits = 30,
                    },
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        List<ExtractV2Job> expectedItems =
        [
            new()
            {
                ID = "ext-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Status = "COMPLETED",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Configuration = new()
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
                    ParseTier = ParseTier.Fast,
                    SheetNames = ["Sheet 1", "Q4 Summary"],
                    SpreadsheetMode = true,
                    SystemPrompt =
                        "Extract all monetary values in USD. If a currency is not specified, assume USD.",
                    TargetPages = "1,3,5-7",
                    Tier = Tier.CostEffective,
                    Version = "latest",
                },
                ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
                ErrorMessage = "error_message",
                ExtractMetadata = new()
                {
                    FieldMetadata = new()
                    {
                        DocumentMetadata = new Dictionary<string, DocumentMetadata?>()
                        {
                            {
                                "items",
                                new(
                                    [
                                        JsonSerializer.Deserialize<JsonElement>(
                                            """
                                            {
                                              "amount": {
                                                "citation": [
                                                  {
                                                    "matching_text": "$10.00",
                                                    "page": 1
                                                  }
                                                ],
                                                "confidence": 1
                                              },
                                              "description": {
                                                "citation": [
                                                  {
                                                    "matching_text": "$10/month",
                                                    "page": 1
                                                  }
                                                ],
                                                "confidence": 0.998
                                              }
                                            }
                                            """
                                        ),
                                    ]
                                )
                            },
                            {
                                "total",
                                new(
                                    new Dictionary<string, JsonElement>()
                                    {
                                        { "citation", JsonSerializer.SerializeToElement("bar") },
                                        { "confidence", JsonSerializer.SerializeToElement("bar") },
                                    }
                                )
                            },
                            {
                                "vendor",
                                new(
                                    new Dictionary<string, JsonElement>()
                                    {
                                        { "citation", JsonSerializer.SerializeToElement("bar") },
                                        { "confidence", JsonSerializer.SerializeToElement("bar") },
                                        {
                                            "extraction_confidence",
                                            JsonSerializer.SerializeToElement("bar")
                                        },
                                        {
                                            "parsing_confidence",
                                            JsonSerializer.SerializeToElement("bar")
                                        },
                                    }
                                )
                            },
                        },
                        PageMetadata =
                        [
                            new Dictionary<string, PageMetadata?>()
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
                        ],
                        RowMetadata =
                        [
                            new Dictionary<string, RowMetadata?>()
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
                        ],
                    },
                    ParseJobID = "parse_job_id",
                    ParseTier = "parse_tier",
                },
                ExtractResult = new(
                    new Dictionary<string, UnionMember0Item?>()
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
                    }
                ),
                Metadata = new()
                {
                    Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
                },
                Usage = new()
                {
                    Credits = 30,
                    ExtractCredits = 45,
                    ParseCredits = 30,
                },
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
        var model = new ExtractV2JobQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "ext-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = "COMPLETED",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Configuration = new()
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
                        ParseTier = ParseTier.Fast,
                        SheetNames = ["Sheet 1", "Q4 Summary"],
                        SpreadsheetMode = true,
                        SystemPrompt =
                            "Extract all monetary values in USD. If a currency is not specified, assume USD.",
                        TargetPages = "1,3,5-7",
                        Tier = Tier.CostEffective,
                        Version = "latest",
                    },
                    ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
                    ErrorMessage = "error_message",
                    ExtractMetadata = new()
                    {
                        FieldMetadata = new()
                        {
                            DocumentMetadata = new Dictionary<string, DocumentMetadata?>()
                            {
                                {
                                    "items",
                                    new(
                                        [
                                            JsonSerializer.Deserialize<JsonElement>(
                                                """
                                                {
                                                  "amount": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10.00",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 1
                                                  },
                                                  "description": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10/month",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 0.998
                                                  }
                                                }
                                                """
                                            ),
                                        ]
                                    )
                                },
                                {
                                    "total",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                                {
                                    "vendor",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "extraction_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "parsing_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                            },
                            PageMetadata =
                            [
                                new Dictionary<string, PageMetadata?>()
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
                            ],
                            RowMetadata =
                            [
                                new Dictionary<string, RowMetadata?>()
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
                            ],
                        },
                        ParseJobID = "parse_job_id",
                        ParseTier = "parse_tier",
                    },
                    ExtractResult = new(
                        new Dictionary<string, UnionMember0Item?>()
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
                        }
                    ),
                    Metadata = new()
                    {
                        Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
                    },
                    Usage = new()
                    {
                        Credits = 30,
                        ExtractCredits = 45,
                        ParseCredits = 30,
                    },
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2JobQueryResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractV2JobQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "ext-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = "COMPLETED",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Configuration = new()
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
                        ParseTier = ParseTier.Fast,
                        SheetNames = ["Sheet 1", "Q4 Summary"],
                        SpreadsheetMode = true,
                        SystemPrompt =
                            "Extract all monetary values in USD. If a currency is not specified, assume USD.",
                        TargetPages = "1,3,5-7",
                        Tier = Tier.CostEffective,
                        Version = "latest",
                    },
                    ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
                    ErrorMessage = "error_message",
                    ExtractMetadata = new()
                    {
                        FieldMetadata = new()
                        {
                            DocumentMetadata = new Dictionary<string, DocumentMetadata?>()
                            {
                                {
                                    "items",
                                    new(
                                        [
                                            JsonSerializer.Deserialize<JsonElement>(
                                                """
                                                {
                                                  "amount": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10.00",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 1
                                                  },
                                                  "description": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10/month",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 0.998
                                                  }
                                                }
                                                """
                                            ),
                                        ]
                                    )
                                },
                                {
                                    "total",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                                {
                                    "vendor",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "extraction_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "parsing_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                            },
                            PageMetadata =
                            [
                                new Dictionary<string, PageMetadata?>()
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
                            ],
                            RowMetadata =
                            [
                                new Dictionary<string, RowMetadata?>()
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
                            ],
                        },
                        ParseJobID = "parse_job_id",
                        ParseTier = "parse_tier",
                    },
                    ExtractResult = new(
                        new Dictionary<string, UnionMember0Item?>()
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
                        }
                    ),
                    Metadata = new()
                    {
                        Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
                    },
                    Usage = new()
                    {
                        Credits = 30,
                        ExtractCredits = 45,
                        ParseCredits = 30,
                    },
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2JobQueryResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ExtractV2Job> expectedItems =
        [
            new()
            {
                ID = "ext-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Status = "COMPLETED",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Configuration = new()
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
                    ParseTier = ParseTier.Fast,
                    SheetNames = ["Sheet 1", "Q4 Summary"],
                    SpreadsheetMode = true,
                    SystemPrompt =
                        "Extract all monetary values in USD. If a currency is not specified, assume USD.",
                    TargetPages = "1,3,5-7",
                    Tier = Tier.CostEffective,
                    Version = "latest",
                },
                ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
                ErrorMessage = "error_message",
                ExtractMetadata = new()
                {
                    FieldMetadata = new()
                    {
                        DocumentMetadata = new Dictionary<string, DocumentMetadata?>()
                        {
                            {
                                "items",
                                new(
                                    [
                                        JsonSerializer.Deserialize<JsonElement>(
                                            """
                                            {
                                              "amount": {
                                                "citation": [
                                                  {
                                                    "matching_text": "$10.00",
                                                    "page": 1
                                                  }
                                                ],
                                                "confidence": 1
                                              },
                                              "description": {
                                                "citation": [
                                                  {
                                                    "matching_text": "$10/month",
                                                    "page": 1
                                                  }
                                                ],
                                                "confidence": 0.998
                                              }
                                            }
                                            """
                                        ),
                                    ]
                                )
                            },
                            {
                                "total",
                                new(
                                    new Dictionary<string, JsonElement>()
                                    {
                                        { "citation", JsonSerializer.SerializeToElement("bar") },
                                        { "confidence", JsonSerializer.SerializeToElement("bar") },
                                    }
                                )
                            },
                            {
                                "vendor",
                                new(
                                    new Dictionary<string, JsonElement>()
                                    {
                                        { "citation", JsonSerializer.SerializeToElement("bar") },
                                        { "confidence", JsonSerializer.SerializeToElement("bar") },
                                        {
                                            "extraction_confidence",
                                            JsonSerializer.SerializeToElement("bar")
                                        },
                                        {
                                            "parsing_confidence",
                                            JsonSerializer.SerializeToElement("bar")
                                        },
                                    }
                                )
                            },
                        },
                        PageMetadata =
                        [
                            new Dictionary<string, PageMetadata?>()
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
                        ],
                        RowMetadata =
                        [
                            new Dictionary<string, RowMetadata?>()
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
                        ],
                    },
                    ParseJobID = "parse_job_id",
                    ParseTier = "parse_tier",
                },
                ExtractResult = new(
                    new Dictionary<string, UnionMember0Item?>()
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
                    }
                ),
                Metadata = new()
                {
                    Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
                },
                Usage = new()
                {
                    Credits = 30,
                    ExtractCredits = 45,
                    ParseCredits = 30,
                },
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
        var model = new ExtractV2JobQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "ext-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = "COMPLETED",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Configuration = new()
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
                        ParseTier = ParseTier.Fast,
                        SheetNames = ["Sheet 1", "Q4 Summary"],
                        SpreadsheetMode = true,
                        SystemPrompt =
                            "Extract all monetary values in USD. If a currency is not specified, assume USD.",
                        TargetPages = "1,3,5-7",
                        Tier = Tier.CostEffective,
                        Version = "latest",
                    },
                    ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
                    ErrorMessage = "error_message",
                    ExtractMetadata = new()
                    {
                        FieldMetadata = new()
                        {
                            DocumentMetadata = new Dictionary<string, DocumentMetadata?>()
                            {
                                {
                                    "items",
                                    new(
                                        [
                                            JsonSerializer.Deserialize<JsonElement>(
                                                """
                                                {
                                                  "amount": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10.00",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 1
                                                  },
                                                  "description": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10/month",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 0.998
                                                  }
                                                }
                                                """
                                            ),
                                        ]
                                    )
                                },
                                {
                                    "total",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                                {
                                    "vendor",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "extraction_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "parsing_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                            },
                            PageMetadata =
                            [
                                new Dictionary<string, PageMetadata?>()
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
                            ],
                            RowMetadata =
                            [
                                new Dictionary<string, RowMetadata?>()
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
                            ],
                        },
                        ParseJobID = "parse_job_id",
                        ParseTier = "parse_tier",
                    },
                    ExtractResult = new(
                        new Dictionary<string, UnionMember0Item?>()
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
                        }
                    ),
                    Metadata = new()
                    {
                        Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
                    },
                    Usage = new()
                    {
                        Credits = 30,
                        ExtractCredits = 45,
                        ParseCredits = 30,
                    },
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
        var model = new ExtractV2JobQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "ext-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = "COMPLETED",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Configuration = new()
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
                        ParseTier = ParseTier.Fast,
                        SheetNames = ["Sheet 1", "Q4 Summary"],
                        SpreadsheetMode = true,
                        SystemPrompt =
                            "Extract all monetary values in USD. If a currency is not specified, assume USD.",
                        TargetPages = "1,3,5-7",
                        Tier = Tier.CostEffective,
                        Version = "latest",
                    },
                    ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
                    ErrorMessage = "error_message",
                    ExtractMetadata = new()
                    {
                        FieldMetadata = new()
                        {
                            DocumentMetadata = new Dictionary<string, DocumentMetadata?>()
                            {
                                {
                                    "items",
                                    new(
                                        [
                                            JsonSerializer.Deserialize<JsonElement>(
                                                """
                                                {
                                                  "amount": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10.00",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 1
                                                  },
                                                  "description": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10/month",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 0.998
                                                  }
                                                }
                                                """
                                            ),
                                        ]
                                    )
                                },
                                {
                                    "total",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                                {
                                    "vendor",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "extraction_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "parsing_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                            },
                            PageMetadata =
                            [
                                new Dictionary<string, PageMetadata?>()
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
                            ],
                            RowMetadata =
                            [
                                new Dictionary<string, RowMetadata?>()
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
                            ],
                        },
                        ParseJobID = "parse_job_id",
                        ParseTier = "parse_tier",
                    },
                    ExtractResult = new(
                        new Dictionary<string, UnionMember0Item?>()
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
                        }
                    ),
                    Metadata = new()
                    {
                        Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
                    },
                    Usage = new()
                    {
                        Credits = 30,
                        ExtractCredits = 45,
                        ParseCredits = 30,
                    },
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
        var model = new ExtractV2JobQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "ext-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = "COMPLETED",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Configuration = new()
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
                        ParseTier = ParseTier.Fast,
                        SheetNames = ["Sheet 1", "Q4 Summary"],
                        SpreadsheetMode = true,
                        SystemPrompt =
                            "Extract all monetary values in USD. If a currency is not specified, assume USD.",
                        TargetPages = "1,3,5-7",
                        Tier = Tier.CostEffective,
                        Version = "latest",
                    },
                    ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
                    ErrorMessage = "error_message",
                    ExtractMetadata = new()
                    {
                        FieldMetadata = new()
                        {
                            DocumentMetadata = new Dictionary<string, DocumentMetadata?>()
                            {
                                {
                                    "items",
                                    new(
                                        [
                                            JsonSerializer.Deserialize<JsonElement>(
                                                """
                                                {
                                                  "amount": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10.00",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 1
                                                  },
                                                  "description": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10/month",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 0.998
                                                  }
                                                }
                                                """
                                            ),
                                        ]
                                    )
                                },
                                {
                                    "total",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                                {
                                    "vendor",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "extraction_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "parsing_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                            },
                            PageMetadata =
                            [
                                new Dictionary<string, PageMetadata?>()
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
                            ],
                            RowMetadata =
                            [
                                new Dictionary<string, RowMetadata?>()
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
                            ],
                        },
                        ParseJobID = "parse_job_id",
                        ParseTier = "parse_tier",
                    },
                    ExtractResult = new(
                        new Dictionary<string, UnionMember0Item?>()
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
                        }
                    ),
                    Metadata = new()
                    {
                        Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
                    },
                    Usage = new()
                    {
                        Credits = 30,
                        ExtractCredits = 45,
                        ParseCredits = 30,
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ExtractV2JobQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "ext-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = "COMPLETED",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Configuration = new()
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
                        ParseTier = ParseTier.Fast,
                        SheetNames = ["Sheet 1", "Q4 Summary"],
                        SpreadsheetMode = true,
                        SystemPrompt =
                            "Extract all monetary values in USD. If a currency is not specified, assume USD.",
                        TargetPages = "1,3,5-7",
                        Tier = Tier.CostEffective,
                        Version = "latest",
                    },
                    ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
                    ErrorMessage = "error_message",
                    ExtractMetadata = new()
                    {
                        FieldMetadata = new()
                        {
                            DocumentMetadata = new Dictionary<string, DocumentMetadata?>()
                            {
                                {
                                    "items",
                                    new(
                                        [
                                            JsonSerializer.Deserialize<JsonElement>(
                                                """
                                                {
                                                  "amount": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10.00",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 1
                                                  },
                                                  "description": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10/month",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 0.998
                                                  }
                                                }
                                                """
                                            ),
                                        ]
                                    )
                                },
                                {
                                    "total",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                                {
                                    "vendor",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "extraction_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "parsing_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                            },
                            PageMetadata =
                            [
                                new Dictionary<string, PageMetadata?>()
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
                            ],
                            RowMetadata =
                            [
                                new Dictionary<string, RowMetadata?>()
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
                            ],
                        },
                        ParseJobID = "parse_job_id",
                        ParseTier = "parse_tier",
                    },
                    ExtractResult = new(
                        new Dictionary<string, UnionMember0Item?>()
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
                        }
                    ),
                    Metadata = new()
                    {
                        Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
                    },
                    Usage = new()
                    {
                        Credits = 30,
                        ExtractCredits = 45,
                        ParseCredits = 30,
                    },
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
        var model = new ExtractV2JobQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "ext-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = "COMPLETED",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Configuration = new()
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
                        ParseTier = ParseTier.Fast,
                        SheetNames = ["Sheet 1", "Q4 Summary"],
                        SpreadsheetMode = true,
                        SystemPrompt =
                            "Extract all monetary values in USD. If a currency is not specified, assume USD.",
                        TargetPages = "1,3,5-7",
                        Tier = Tier.CostEffective,
                        Version = "latest",
                    },
                    ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
                    ErrorMessage = "error_message",
                    ExtractMetadata = new()
                    {
                        FieldMetadata = new()
                        {
                            DocumentMetadata = new Dictionary<string, DocumentMetadata?>()
                            {
                                {
                                    "items",
                                    new(
                                        [
                                            JsonSerializer.Deserialize<JsonElement>(
                                                """
                                                {
                                                  "amount": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10.00",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 1
                                                  },
                                                  "description": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10/month",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 0.998
                                                  }
                                                }
                                                """
                                            ),
                                        ]
                                    )
                                },
                                {
                                    "total",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                                {
                                    "vendor",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "extraction_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "parsing_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                            },
                            PageMetadata =
                            [
                                new Dictionary<string, PageMetadata?>()
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
                            ],
                            RowMetadata =
                            [
                                new Dictionary<string, RowMetadata?>()
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
                            ],
                        },
                        ParseJobID = "parse_job_id",
                        ParseTier = "parse_tier",
                    },
                    ExtractResult = new(
                        new Dictionary<string, UnionMember0Item?>()
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
                        }
                    ),
                    Metadata = new()
                    {
                        Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
                    },
                    Usage = new()
                    {
                        Credits = 30,
                        ExtractCredits = 45,
                        ParseCredits = 30,
                    },
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
        var model = new ExtractV2JobQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "ext-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = "COMPLETED",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Configuration = new()
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
                        ParseTier = ParseTier.Fast,
                        SheetNames = ["Sheet 1", "Q4 Summary"],
                        SpreadsheetMode = true,
                        SystemPrompt =
                            "Extract all monetary values in USD. If a currency is not specified, assume USD.",
                        TargetPages = "1,3,5-7",
                        Tier = Tier.CostEffective,
                        Version = "latest",
                    },
                    ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
                    ErrorMessage = "error_message",
                    ExtractMetadata = new()
                    {
                        FieldMetadata = new()
                        {
                            DocumentMetadata = new Dictionary<string, DocumentMetadata?>()
                            {
                                {
                                    "items",
                                    new(
                                        [
                                            JsonSerializer.Deserialize<JsonElement>(
                                                """
                                                {
                                                  "amount": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10.00",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 1
                                                  },
                                                  "description": {
                                                    "citation": [
                                                      {
                                                        "matching_text": "$10/month",
                                                        "page": 1
                                                      }
                                                    ],
                                                    "confidence": 0.998
                                                  }
                                                }
                                                """
                                            ),
                                        ]
                                    )
                                },
                                {
                                    "total",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                                {
                                    "vendor",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            {
                                                "citation",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "extraction_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                            {
                                                "parsing_confidence",
                                                JsonSerializer.SerializeToElement("bar")
                                            },
                                        }
                                    )
                                },
                            },
                            PageMetadata =
                            [
                                new Dictionary<string, PageMetadata?>()
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
                            ],
                            RowMetadata =
                            [
                                new Dictionary<string, RowMetadata?>()
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
                            ],
                        },
                        ParseJobID = "parse_job_id",
                        ParseTier = "parse_tier",
                    },
                    ExtractResult = new(
                        new Dictionary<string, UnionMember0Item?>()
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
                        }
                    ),
                    Metadata = new()
                    {
                        Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
                    },
                    Usage = new()
                    {
                        Credits = 30,
                        ExtractCredits = 45,
                        ParseCredits = 30,
                    },
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        ExtractV2JobQueryResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
