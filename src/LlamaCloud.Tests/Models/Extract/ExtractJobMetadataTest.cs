using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Extract;

namespace LlamaCloud.Tests.Models.Extract;

public class ExtractJobMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractJobMetadata
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

        ExtractedFieldMetadata expectedFieldMetadata = new()
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
                            { "extraction_confidence", JsonSerializer.SerializeToElement("bar") },
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
        };
        string expectedParseJobID = "parse_job_id";
        string expectedParseTier = "parse_tier";

        Assert.Equal(expectedFieldMetadata, model.FieldMetadata);
        Assert.Equal(expectedParseJobID, model.ParseJobID);
        Assert.Equal(expectedParseTier, model.ParseTier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractJobMetadata
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractJobMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractJobMetadata
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractJobMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ExtractedFieldMetadata expectedFieldMetadata = new()
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
                            { "extraction_confidence", JsonSerializer.SerializeToElement("bar") },
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
        };
        string expectedParseJobID = "parse_job_id";
        string expectedParseTier = "parse_tier";

        Assert.Equal(expectedFieldMetadata, deserialized.FieldMetadata);
        Assert.Equal(expectedParseJobID, deserialized.ParseJobID);
        Assert.Equal(expectedParseTier, deserialized.ParseTier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractJobMetadata
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtractJobMetadata { };

        Assert.Null(model.FieldMetadata);
        Assert.False(model.RawData.ContainsKey("field_metadata"));
        Assert.Null(model.ParseJobID);
        Assert.False(model.RawData.ContainsKey("parse_job_id"));
        Assert.Null(model.ParseTier);
        Assert.False(model.RawData.ContainsKey("parse_tier"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtractJobMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ExtractJobMetadata
        {
            FieldMetadata = null,
            ParseJobID = null,
            ParseTier = null,
        };

        Assert.Null(model.FieldMetadata);
        Assert.True(model.RawData.ContainsKey("field_metadata"));
        Assert.Null(model.ParseJobID);
        Assert.True(model.RawData.ContainsKey("parse_job_id"));
        Assert.Null(model.ParseTier);
        Assert.True(model.RawData.ContainsKey("parse_tier"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtractJobMetadata
        {
            FieldMetadata = null,
            ParseJobID = null,
            ParseTier = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractJobMetadata
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

        ExtractJobMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
