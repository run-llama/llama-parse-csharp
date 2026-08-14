using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Extract;

namespace LlamaIndex.LlamaCloud.Tests.Models.Extract;

public class ExtractV2JobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractV2Job
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
                ParseTier = "fast",
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
        };

        string expectedID = "ext-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedStatus = "COMPLETED";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ExtractConfiguration expectedConfiguration = new()
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
        string expectedConfigurationID = "cfg-11111111-2222-3333-4444-555555555555";
        string expectedErrorMessage = "error_message";
        ExtractJobMetadata expectedExtractMetadata = new()
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
                                { "parsing_confidence", JsonSerializer.SerializeToElement("bar") },
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
        };
        ExtractResult expectedExtractResult = new(
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
        );
        Metadata expectedMetadata = new()
        {
            Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
        };
        Usage expectedUsage = new()
        {
            Credits = 30,
            ExtractCredits = 45,
            ParseCredits = 30,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFileInput, model.FileInput);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedConfiguration, model.Configuration);
        Assert.Equal(expectedConfigurationID, model.ConfigurationID);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedExtractMetadata, model.ExtractMetadata);
        Assert.Equal(expectedExtractResult, model.ExtractResult);
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractV2Job
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
                ParseTier = "fast",
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2Job>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractV2Job
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
                ParseTier = "fast",
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2Job>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "ext-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedStatus = "COMPLETED";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ExtractConfiguration expectedConfiguration = new()
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
        string expectedConfigurationID = "cfg-11111111-2222-3333-4444-555555555555";
        string expectedErrorMessage = "error_message";
        ExtractJobMetadata expectedExtractMetadata = new()
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
                                { "parsing_confidence", JsonSerializer.SerializeToElement("bar") },
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
        };
        ExtractResult expectedExtractResult = new(
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
        );
        Metadata expectedMetadata = new()
        {
            Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
        };
        Usage expectedUsage = new()
        {
            Credits = 30,
            ExtractCredits = 45,
            ParseCredits = 30,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFileInput, deserialized.FileInput);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedConfiguration, deserialized.Configuration);
        Assert.Equal(expectedConfigurationID, deserialized.ConfigurationID);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedExtractMetadata, deserialized.ExtractMetadata);
        Assert.Equal(expectedExtractResult, deserialized.ExtractResult);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractV2Job
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
                ParseTier = "fast",
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtractV2Job
        {
            ID = "ext-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = "COMPLETED",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Configuration);
        Assert.False(model.RawData.ContainsKey("configuration"));
        Assert.Null(model.ConfigurationID);
        Assert.False(model.RawData.ContainsKey("configuration_id"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.ExtractMetadata);
        Assert.False(model.RawData.ContainsKey("extract_metadata"));
        Assert.Null(model.ExtractResult);
        Assert.False(model.RawData.ContainsKey("extract_result"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtractV2Job
        {
            ID = "ext-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = "COMPLETED",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ExtractV2Job
        {
            ID = "ext-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = "COMPLETED",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Configuration = null,
            ConfigurationID = null,
            ErrorMessage = null,
            ExtractMetadata = null,
            ExtractResult = null,
            Metadata = null,
            Usage = null,
        };

        Assert.Null(model.Configuration);
        Assert.True(model.RawData.ContainsKey("configuration"));
        Assert.Null(model.ConfigurationID);
        Assert.True(model.RawData.ContainsKey("configuration_id"));
        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.ExtractMetadata);
        Assert.True(model.RawData.ContainsKey("extract_metadata"));
        Assert.Null(model.ExtractResult);
        Assert.True(model.RawData.ContainsKey("extract_result"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Usage);
        Assert.True(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtractV2Job
        {
            ID = "ext-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = "COMPLETED",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Configuration = null,
            ConfigurationID = null,
            ErrorMessage = null,
            ExtractMetadata = null,
            ExtractResult = null,
            Metadata = null,
            Usage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractV2Job
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
                ParseTier = "fast",
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
        };

        ExtractV2Job copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtractResultTest : TestBase
{
    [Fact]
    public void UnionMember0ItemsValidationWorks()
    {
        ExtractResult value = new(
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
        );
        value.Validate();
    }

    [Fact]
    public void UnnamedSchemaWithArrayParent3ItemsValidationWorks()
    {
        ExtractResult value = new(
            [
                new Dictionary<string, UnnamedSchemaWithArrayParent3Item?>()
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
            ]
        );
        value.Validate();
    }

    [Fact]
    public void UnionMember0ItemsSerializationRoundtripWorks()
    {
        ExtractResult value = new(
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
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnnamedSchemaWithArrayParent3ItemsSerializationRoundtripWorks()
    {
        ExtractResult value = new(
            [
                new Dictionary<string, UnnamedSchemaWithArrayParent3Item?>()
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
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember0ItemTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        UnionMember0Item value = new(
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
        UnionMember0Item value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        UnionMember0Item value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        UnionMember0Item value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        UnionMember0Item value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        UnionMember0Item value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember0Item>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        UnionMember0Item value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember0Item>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        UnionMember0Item value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember0Item>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        UnionMember0Item value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember0Item>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        UnionMember0Item value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember0Item>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnnamedSchemaWithArrayParent3ItemTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        UnnamedSchemaWithArrayParent3Item value = new(
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
        UnnamedSchemaWithArrayParent3Item value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        UnnamedSchemaWithArrayParent3Item value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        UnnamedSchemaWithArrayParent3Item value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        UnnamedSchemaWithArrayParent3Item value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent3Item value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent3Item>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        UnnamedSchemaWithArrayParent3Item value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent3Item>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent3Item value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent3Item>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent3Item value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent3Item>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent3Item value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent3Item>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Metadata
        {
            Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
        };

        ExtractJobUsage expectedUsage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 };

        Assert.Equal(expectedUsage, model.Usage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Metadata
        {
            Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Metadata
        {
            Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ExtractJobUsage expectedUsage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 };

        Assert.Equal(expectedUsage, deserialized.Usage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Metadata
        {
            Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Metadata { };

        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Metadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Metadata { Usage = null };

        Assert.Null(model.Usage);
        Assert.True(model.RawData.ContainsKey("usage"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Metadata { Usage = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Metadata
        {
            Usage = new() { NumPagesBilled = 0, NumPagesExtracted = 0 },
        };

        Metadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Usage
        {
            Credits = 30,
            ExtractCredits = 45,
            ParseCredits = 30,
        };

        double expectedCredits = 30;
        double expectedExtractCredits = 45;
        double expectedParseCredits = 30;

        Assert.Equal(expectedCredits, model.Credits);
        Assert.Equal(expectedExtractCredits, model.ExtractCredits);
        Assert.Equal(expectedParseCredits, model.ParseCredits);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Usage
        {
            Credits = 30,
            ExtractCredits = 45,
            ParseCredits = 30,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Usage
        {
            Credits = 30,
            ExtractCredits = 45,
            ParseCredits = 30,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Usage>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedCredits = 30;
        double expectedExtractCredits = 45;
        double expectedParseCredits = 30;

        Assert.Equal(expectedCredits, deserialized.Credits);
        Assert.Equal(expectedExtractCredits, deserialized.ExtractCredits);
        Assert.Equal(expectedParseCredits, deserialized.ParseCredits);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Usage
        {
            Credits = 30,
            ExtractCredits = 45,
            ParseCredits = 30,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Usage { };

        Assert.Null(model.Credits);
        Assert.False(model.RawData.ContainsKey("credits"));
        Assert.Null(model.ExtractCredits);
        Assert.False(model.RawData.ContainsKey("extract_credits"));
        Assert.Null(model.ParseCredits);
        Assert.False(model.RawData.ContainsKey("parse_credits"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Usage { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Usage
        {
            Credits = null,
            ExtractCredits = null,
            ParseCredits = null,
        };

        Assert.Null(model.Credits);
        Assert.True(model.RawData.ContainsKey("credits"));
        Assert.Null(model.ExtractCredits);
        Assert.True(model.RawData.ContainsKey("extract_credits"));
        Assert.Null(model.ParseCredits);
        Assert.True(model.RawData.ContainsKey("parse_credits"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Usage
        {
            Credits = null,
            ExtractCredits = null,
            ParseCredits = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Usage
        {
            Credits = 30,
            ExtractCredits = 45,
            ParseCredits = 30,
        };

        Usage copied = new(model);

        Assert.Equal(model, copied);
    }
}
