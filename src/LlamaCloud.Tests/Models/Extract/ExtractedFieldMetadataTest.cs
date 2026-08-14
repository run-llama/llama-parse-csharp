using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Extract;

namespace LlamaCloud.Tests.Models.Extract;

public class ExtractedFieldMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractedFieldMetadata
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

        Dictionary<string, DocumentMetadata?> expectedDocumentMetadata = new()
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
        };
        List<Dictionary<string, PageMetadata?>> expectedPageMetadata =
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
        ];
        List<Dictionary<string, RowMetadata?>> expectedRowMetadata =
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
        ];

        Assert.NotNull(model.DocumentMetadata);
        Assert.Equal(expectedDocumentMetadata.Count, model.DocumentMetadata.Count);
        foreach (var item in expectedDocumentMetadata)
        {
            Assert.True(model.DocumentMetadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.DocumentMetadata[item.Key]);
        }
        Assert.NotNull(model.PageMetadata);
        Assert.Equal(expectedPageMetadata.Count, model.PageMetadata.Count);
        for (int i = 0; i < expectedPageMetadata.Count; i++)
        {
            Assert.Equal(expectedPageMetadata[i].Count, model.PageMetadata[i].Count);
            foreach (var item in expectedPageMetadata[i])
            {
                Assert.True(model.PageMetadata[i].TryGetValue(item.Key, out var value));

                Assert.Equal(value, model.PageMetadata[i][item.Key]);
            }
        }
        Assert.NotNull(model.RowMetadata);
        Assert.Equal(expectedRowMetadata.Count, model.RowMetadata.Count);
        for (int i = 0; i < expectedRowMetadata.Count; i++)
        {
            Assert.Equal(expectedRowMetadata[i].Count, model.RowMetadata[i].Count);
            foreach (var item in expectedRowMetadata[i])
            {
                Assert.True(model.RowMetadata[i].TryGetValue(item.Key, out var value));

                Assert.Equal(value, model.RowMetadata[i][item.Key]);
            }
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractedFieldMetadata
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractedFieldMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractedFieldMetadata
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractedFieldMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, DocumentMetadata?> expectedDocumentMetadata = new()
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
        };
        List<Dictionary<string, PageMetadata?>> expectedPageMetadata =
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
        ];
        List<Dictionary<string, RowMetadata?>> expectedRowMetadata =
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
        ];

        Assert.NotNull(deserialized.DocumentMetadata);
        Assert.Equal(expectedDocumentMetadata.Count, deserialized.DocumentMetadata.Count);
        foreach (var item in expectedDocumentMetadata)
        {
            Assert.True(deserialized.DocumentMetadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.DocumentMetadata[item.Key]);
        }
        Assert.NotNull(deserialized.PageMetadata);
        Assert.Equal(expectedPageMetadata.Count, deserialized.PageMetadata.Count);
        for (int i = 0; i < expectedPageMetadata.Count; i++)
        {
            Assert.Equal(expectedPageMetadata[i].Count, deserialized.PageMetadata[i].Count);
            foreach (var item in expectedPageMetadata[i])
            {
                Assert.True(deserialized.PageMetadata[i].TryGetValue(item.Key, out var value));

                Assert.Equal(value, deserialized.PageMetadata[i][item.Key]);
            }
        }
        Assert.NotNull(deserialized.RowMetadata);
        Assert.Equal(expectedRowMetadata.Count, deserialized.RowMetadata.Count);
        for (int i = 0; i < expectedRowMetadata.Count; i++)
        {
            Assert.Equal(expectedRowMetadata[i].Count, deserialized.RowMetadata[i].Count);
            foreach (var item in expectedRowMetadata[i])
            {
                Assert.True(deserialized.RowMetadata[i].TryGetValue(item.Key, out var value));

                Assert.Equal(value, deserialized.RowMetadata[i][item.Key]);
            }
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractedFieldMetadata
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtractedFieldMetadata { };

        Assert.Null(model.DocumentMetadata);
        Assert.False(model.RawData.ContainsKey("document_metadata"));
        Assert.Null(model.PageMetadata);
        Assert.False(model.RawData.ContainsKey("page_metadata"));
        Assert.Null(model.RowMetadata);
        Assert.False(model.RawData.ContainsKey("row_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtractedFieldMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ExtractedFieldMetadata
        {
            DocumentMetadata = null,
            PageMetadata = null,
            RowMetadata = null,
        };

        Assert.Null(model.DocumentMetadata);
        Assert.True(model.RawData.ContainsKey("document_metadata"));
        Assert.Null(model.PageMetadata);
        Assert.True(model.RawData.ContainsKey("page_metadata"));
        Assert.Null(model.RowMetadata);
        Assert.True(model.RawData.ContainsKey("row_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtractedFieldMetadata
        {
            DocumentMetadata = null,
            PageMetadata = null,
            RowMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractedFieldMetadata
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

        ExtractedFieldMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DocumentMetadataTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        DocumentMetadata value = new(
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
        DocumentMetadata value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        DocumentMetadata value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        DocumentMetadata value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        DocumentMetadata value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        DocumentMetadata value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocumentMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        DocumentMetadata value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocumentMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        DocumentMetadata value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocumentMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        DocumentMetadata value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocumentMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        DocumentMetadata value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocumentMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageMetadataTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        PageMetadata value = new(
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
        PageMetadata value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        PageMetadata value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        PageMetadata value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        PageMetadata value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        PageMetadata value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PageMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        PageMetadata value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PageMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        PageMetadata value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PageMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        PageMetadata value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PageMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        PageMetadata value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PageMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RowMetadataTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        RowMetadata value = new(
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
        RowMetadata value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        RowMetadata value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        RowMetadata value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        RowMetadata value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        RowMetadata value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RowMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        RowMetadata value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RowMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        RowMetadata value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RowMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        RowMetadata value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RowMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        RowMetadata value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RowMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
