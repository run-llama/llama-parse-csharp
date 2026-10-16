using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class FormTextTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormText
        {
            Value = "value",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Grounding = new()
            {
                ID = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Label = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Value = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
            },
            Type = FormTextType.Text,
        };

        string expectedValue = "value";
        List<BBox> expectedBbox =
        [
            new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
        ];
        GroundingModel expectedGrounding = new()
        {
            ID = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
            Label = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
            Value = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
        };
        ApiEnum<string, FormTextType> expectedType = FormTextType.Text;

        Assert.Equal(expectedValue, model.Value);
        Assert.NotNull(model.Bbox);
        Assert.Equal(expectedBbox.Count, model.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], model.Bbox[i]);
        }
        Assert.Equal(expectedGrounding, model.Grounding);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FormText
        {
            Value = "value",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Grounding = new()
            {
                ID = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Label = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Value = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
            },
            Type = FormTextType.Text,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormText>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormText
        {
            Value = "value",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Grounding = new()
            {
                ID = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Label = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Value = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
            },
            Type = FormTextType.Text,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormText>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedValue = "value";
        List<BBox> expectedBbox =
        [
            new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
        ];
        GroundingModel expectedGrounding = new()
        {
            ID = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
            Label = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
            Value = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
        };
        ApiEnum<string, FormTextType> expectedType = FormTextType.Text;

        Assert.Equal(expectedValue, deserialized.Value);
        Assert.NotNull(deserialized.Bbox);
        Assert.Equal(expectedBbox.Count, deserialized.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], deserialized.Bbox[i]);
        }
        Assert.Equal(expectedGrounding, deserialized.Grounding);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FormText
        {
            Value = "value",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Grounding = new()
            {
                ID = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Label = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Value = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
            },
            Type = FormTextType.Text,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FormText
        {
            Value = "value",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Grounding = new()
            {
                ID = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Label = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Value = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
            },
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FormText
        {
            Value = "value",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Grounding = new()
            {
                ID = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Label = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Value = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FormText
        {
            Value = "value",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Grounding = new()
            {
                ID = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Label = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Value = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
            },

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FormText
        {
            Value = "value",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Grounding = new()
            {
                ID = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Label = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Value = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
            },

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FormText { Value = "value", Type = FormTextType.Text };

        Assert.Null(model.Bbox);
        Assert.False(model.RawData.ContainsKey("bbox"));
        Assert.Null(model.Grounding);
        Assert.False(model.RawData.ContainsKey("grounding"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FormText { Value = "value", Type = FormTextType.Text };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FormText
        {
            Value = "value",
            Type = FormTextType.Text,

            Bbox = null,
            Grounding = null,
        };

        Assert.Null(model.Bbox);
        Assert.True(model.RawData.ContainsKey("bbox"));
        Assert.Null(model.Grounding);
        Assert.True(model.RawData.ContainsKey("grounding"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FormText
        {
            Value = "value",
            Type = FormTextType.Text,

            Bbox = null,
            Grounding = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FormText
        {
            Value = "value",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Grounding = new()
            {
                ID = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Label = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
                Value = new(
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                            Words =
                            [
                                new()
                                {
                                    Bbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                    Span =
                                    [
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                        JsonSerializer.Deserialize<JsonElement>("{}"),
                                    ],
                                },
                            ],
                        },
                    ]
                ),
            },
            Type = FormTextType.Text,
        };

        FormText copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GroundingModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroundingModel
        {
            ID = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
            Label = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
            Value = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
        };

        GroundingModelID expectedID = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ]
        );
        GroundingModelLabel expectedLabel = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ]
        );
        GroundingModelValue expectedValue = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ]
        );

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedLabel, model.Label);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GroundingModel
        {
            ID = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
            Label = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
            Value = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GroundingModel
        {
            ID = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
            Label = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
            Value = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        GroundingModelID expectedID = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ]
        );
        GroundingModelLabel expectedLabel = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ]
        );
        GroundingModelValue expectedValue = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ]
        );

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedLabel, deserialized.Label);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GroundingModel
        {
            ID = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
            Label = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
            Value = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GroundingModel { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new GroundingModel { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new GroundingModel
        {
            ID = null,
            Label = null,
            Value = null,
        };

        Assert.Null(model.ID);
        Assert.True(model.RawData.ContainsKey("id"));
        Assert.Null(model.Label);
        Assert.True(model.RawData.ContainsKey("label"));
        Assert.Null(model.Value);
        Assert.True(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GroundingModel
        {
            ID = null,
            Label = null,
            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GroundingModel
        {
            ID = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
            Label = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
            Value = new(
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                        Words =
                        [
                            new()
                            {
                                Bbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                                Span =
                                [
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                ],
                            },
                        ],
                    },
                ]
            ),
        };

        GroundingModel copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GroundingModelIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroundingModelID
        {
            Lines =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ],
        };

        List<GroundingModelIDLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                    },
                ],
            },
        ];

        Assert.Equal(expectedLines.Count, model.Lines.Count);
        for (int i = 0; i < expectedLines.Count; i++)
        {
            Assert.Equal(expectedLines[i], model.Lines[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GroundingModelID
        {
            Lines =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelID>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GroundingModelID
        {
            Lines =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelID>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<GroundingModelIDLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                    },
                ],
            },
        ];

        Assert.Equal(expectedLines.Count, deserialized.Lines.Count);
        for (int i = 0; i < expectedLines.Count; i++)
        {
            Assert.Equal(expectedLines[i], deserialized.Lines[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GroundingModelID
        {
            Lines =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GroundingModelID
        {
            Lines =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ],
        };

        GroundingModelID copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GroundingModelIDLineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroundingModelIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                },
            ],
        };

        BBox expectedBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
            Confidence = 0,
            EndIndex = 0,
            Label = "label",
            R = 0,
            StartIndex = 0,
        };
        List<JsonElement> expectedSpan =
        [
            JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonSerializer.Deserialize<JsonElement>("{}"),
        ];
        List<GroundingModelIDLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
            },
        ];

        Assert.Equal(expectedBbox, model.Bbox);
        Assert.Equal(expectedSpan.Count, model.Span.Count);
        for (int i = 0; i < expectedSpan.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSpan[i], model.Span[i]));
        }
        Assert.NotNull(model.Words);
        Assert.Equal(expectedWords.Count, model.Words.Count);
        for (int i = 0; i < expectedWords.Count; i++)
        {
            Assert.Equal(expectedWords[i], model.Words[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GroundingModelIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelIDLine>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GroundingModelIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelIDLine>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BBox expectedBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
            Confidence = 0,
            EndIndex = 0,
            Label = "label",
            R = 0,
            StartIndex = 0,
        };
        List<JsonElement> expectedSpan =
        [
            JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonSerializer.Deserialize<JsonElement>("{}"),
        ];
        List<GroundingModelIDLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
            },
        ];

        Assert.Equal(expectedBbox, deserialized.Bbox);
        Assert.Equal(expectedSpan.Count, deserialized.Span.Count);
        for (int i = 0; i < expectedSpan.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSpan[i], deserialized.Span[i]));
        }
        Assert.NotNull(deserialized.Words);
        Assert.Equal(expectedWords.Count, deserialized.Words.Count);
        for (int i = 0; i < expectedWords.Count; i++)
        {
            Assert.Equal(expectedWords[i], deserialized.Words[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GroundingModelIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GroundingModelIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        Assert.Null(model.Words);
        Assert.False(model.RawData.ContainsKey("words"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new GroundingModelIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new GroundingModelIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],

            Words = null,
        };

        Assert.Null(model.Words);
        Assert.True(model.RawData.ContainsKey("words"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GroundingModelIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],

            Words = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GroundingModelIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                },
            ],
        };

        GroundingModelIDLine copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GroundingModelIDLineWordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroundingModelIDLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        BBox expectedBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
            Confidence = 0,
            EndIndex = 0,
            Label = "label",
            R = 0,
            StartIndex = 0,
        };
        List<JsonElement> expectedSpan =
        [
            JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonSerializer.Deserialize<JsonElement>("{}"),
        ];

        Assert.Equal(expectedBbox, model.Bbox);
        Assert.Equal(expectedSpan.Count, model.Span.Count);
        for (int i = 0; i < expectedSpan.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSpan[i], model.Span[i]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GroundingModelIDLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelIDLineWord>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GroundingModelIDLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelIDLineWord>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BBox expectedBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
            Confidence = 0,
            EndIndex = 0,
            Label = "label",
            R = 0,
            StartIndex = 0,
        };
        List<JsonElement> expectedSpan =
        [
            JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonSerializer.Deserialize<JsonElement>("{}"),
        ];

        Assert.Equal(expectedBbox, deserialized.Bbox);
        Assert.Equal(expectedSpan.Count, deserialized.Span.Count);
        for (int i = 0; i < expectedSpan.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSpan[i], deserialized.Span[i]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GroundingModelIDLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GroundingModelIDLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        GroundingModelIDLineWord copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GroundingModelLabelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroundingModelLabel
        {
            Lines =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ],
        };

        List<GroundingModelLabelLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                    },
                ],
            },
        ];

        Assert.Equal(expectedLines.Count, model.Lines.Count);
        for (int i = 0; i < expectedLines.Count; i++)
        {
            Assert.Equal(expectedLines[i], model.Lines[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GroundingModelLabel
        {
            Lines =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelLabel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GroundingModelLabel
        {
            Lines =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelLabel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<GroundingModelLabelLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                    },
                ],
            },
        ];

        Assert.Equal(expectedLines.Count, deserialized.Lines.Count);
        for (int i = 0; i < expectedLines.Count; i++)
        {
            Assert.Equal(expectedLines[i], deserialized.Lines[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GroundingModelLabel
        {
            Lines =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GroundingModelLabel
        {
            Lines =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ],
        };

        GroundingModelLabel copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GroundingModelLabelLineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroundingModelLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                },
            ],
        };

        BBox expectedBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
            Confidence = 0,
            EndIndex = 0,
            Label = "label",
            R = 0,
            StartIndex = 0,
        };
        List<JsonElement> expectedSpan =
        [
            JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonSerializer.Deserialize<JsonElement>("{}"),
        ];
        List<GroundingModelLabelLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
            },
        ];

        Assert.Equal(expectedBbox, model.Bbox);
        Assert.Equal(expectedSpan.Count, model.Span.Count);
        for (int i = 0; i < expectedSpan.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSpan[i], model.Span[i]));
        }
        Assert.NotNull(model.Words);
        Assert.Equal(expectedWords.Count, model.Words.Count);
        for (int i = 0; i < expectedWords.Count; i++)
        {
            Assert.Equal(expectedWords[i], model.Words[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GroundingModelLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelLabelLine>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GroundingModelLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelLabelLine>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BBox expectedBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
            Confidence = 0,
            EndIndex = 0,
            Label = "label",
            R = 0,
            StartIndex = 0,
        };
        List<JsonElement> expectedSpan =
        [
            JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonSerializer.Deserialize<JsonElement>("{}"),
        ];
        List<GroundingModelLabelLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
            },
        ];

        Assert.Equal(expectedBbox, deserialized.Bbox);
        Assert.Equal(expectedSpan.Count, deserialized.Span.Count);
        for (int i = 0; i < expectedSpan.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSpan[i], deserialized.Span[i]));
        }
        Assert.NotNull(deserialized.Words);
        Assert.Equal(expectedWords.Count, deserialized.Words.Count);
        for (int i = 0; i < expectedWords.Count; i++)
        {
            Assert.Equal(expectedWords[i], deserialized.Words[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GroundingModelLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GroundingModelLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        Assert.Null(model.Words);
        Assert.False(model.RawData.ContainsKey("words"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new GroundingModelLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new GroundingModelLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],

            Words = null,
        };

        Assert.Null(model.Words);
        Assert.True(model.RawData.ContainsKey("words"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GroundingModelLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],

            Words = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GroundingModelLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                },
            ],
        };

        GroundingModelLabelLine copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GroundingModelLabelLineWordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroundingModelLabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        BBox expectedBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
            Confidence = 0,
            EndIndex = 0,
            Label = "label",
            R = 0,
            StartIndex = 0,
        };
        List<JsonElement> expectedSpan =
        [
            JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonSerializer.Deserialize<JsonElement>("{}"),
        ];

        Assert.Equal(expectedBbox, model.Bbox);
        Assert.Equal(expectedSpan.Count, model.Span.Count);
        for (int i = 0; i < expectedSpan.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSpan[i], model.Span[i]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GroundingModelLabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelLabelLineWord>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GroundingModelLabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelLabelLineWord>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BBox expectedBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
            Confidence = 0,
            EndIndex = 0,
            Label = "label",
            R = 0,
            StartIndex = 0,
        };
        List<JsonElement> expectedSpan =
        [
            JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonSerializer.Deserialize<JsonElement>("{}"),
        ];

        Assert.Equal(expectedBbox, deserialized.Bbox);
        Assert.Equal(expectedSpan.Count, deserialized.Span.Count);
        for (int i = 0; i < expectedSpan.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSpan[i], deserialized.Span[i]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GroundingModelLabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GroundingModelLabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        GroundingModelLabelLineWord copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GroundingModelValueTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroundingModelValue
        {
            Lines =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ],
        };

        List<GroundingModelValueLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                    },
                ],
            },
        ];

        Assert.Equal(expectedLines.Count, model.Lines.Count);
        for (int i = 0; i < expectedLines.Count; i++)
        {
            Assert.Equal(expectedLines[i], model.Lines[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GroundingModelValue
        {
            Lines =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelValue>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GroundingModelValue
        {
            Lines =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelValue>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<GroundingModelValueLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                        Span =
                        [
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                            JsonSerializer.Deserialize<JsonElement>("{}"),
                        ],
                    },
                ],
            },
        ];

        Assert.Equal(expectedLines.Count, deserialized.Lines.Count);
        for (int i = 0; i < expectedLines.Count; i++)
        {
            Assert.Equal(expectedLines[i], deserialized.Lines[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GroundingModelValue
        {
            Lines =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GroundingModelValue
        {
            Lines =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                            Span =
                            [
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                                JsonSerializer.Deserialize<JsonElement>("{}"),
                            ],
                        },
                    ],
                },
            ],
        };

        GroundingModelValue copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GroundingModelValueLineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroundingModelValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                },
            ],
        };

        BBox expectedBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
            Confidence = 0,
            EndIndex = 0,
            Label = "label",
            R = 0,
            StartIndex = 0,
        };
        List<JsonElement> expectedSpan =
        [
            JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonSerializer.Deserialize<JsonElement>("{}"),
        ];
        List<GroundingModelValueLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
            },
        ];

        Assert.Equal(expectedBbox, model.Bbox);
        Assert.Equal(expectedSpan.Count, model.Span.Count);
        for (int i = 0; i < expectedSpan.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSpan[i], model.Span[i]));
        }
        Assert.NotNull(model.Words);
        Assert.Equal(expectedWords.Count, model.Words.Count);
        for (int i = 0; i < expectedWords.Count; i++)
        {
            Assert.Equal(expectedWords[i], model.Words[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GroundingModelValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelValueLine>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GroundingModelValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelValueLine>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BBox expectedBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
            Confidence = 0,
            EndIndex = 0,
            Label = "label",
            R = 0,
            StartIndex = 0,
        };
        List<JsonElement> expectedSpan =
        [
            JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonSerializer.Deserialize<JsonElement>("{}"),
        ];
        List<GroundingModelValueLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
            },
        ];

        Assert.Equal(expectedBbox, deserialized.Bbox);
        Assert.Equal(expectedSpan.Count, deserialized.Span.Count);
        for (int i = 0; i < expectedSpan.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSpan[i], deserialized.Span[i]));
        }
        Assert.NotNull(deserialized.Words);
        Assert.Equal(expectedWords.Count, deserialized.Words.Count);
        for (int i = 0; i < expectedWords.Count; i++)
        {
            Assert.Equal(expectedWords[i], deserialized.Words[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GroundingModelValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GroundingModelValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        Assert.Null(model.Words);
        Assert.False(model.RawData.ContainsKey("words"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new GroundingModelValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new GroundingModelValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],

            Words = null,
        };

        Assert.Null(model.Words);
        Assert.True(model.RawData.ContainsKey("words"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GroundingModelValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],

            Words = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GroundingModelValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                },
            ],
        };

        GroundingModelValueLine copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GroundingModelValueLineWordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GroundingModelValueLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        BBox expectedBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
            Confidence = 0,
            EndIndex = 0,
            Label = "label",
            R = 0,
            StartIndex = 0,
        };
        List<JsonElement> expectedSpan =
        [
            JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonSerializer.Deserialize<JsonElement>("{}"),
        ];

        Assert.Equal(expectedBbox, model.Bbox);
        Assert.Equal(expectedSpan.Count, model.Span.Count);
        for (int i = 0; i < expectedSpan.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSpan[i], model.Span[i]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GroundingModelValueLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelValueLineWord>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GroundingModelValueLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GroundingModelValueLineWord>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BBox expectedBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
            Confidence = 0,
            EndIndex = 0,
            Label = "label",
            R = 0,
            StartIndex = 0,
        };
        List<JsonElement> expectedSpan =
        [
            JsonSerializer.Deserialize<JsonElement>("{}"),
            JsonSerializer.Deserialize<JsonElement>("{}"),
        ];

        Assert.Equal(expectedBbox, deserialized.Bbox);
        Assert.Equal(expectedSpan.Count, deserialized.Span.Count);
        for (int i = 0; i < expectedSpan.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedSpan[i], deserialized.Span[i]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GroundingModelValueLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GroundingModelValueLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
        };

        GroundingModelValueLineWord copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTextTypeTest : TestBase
{
    [Theory]
    [InlineData(FormTextType.Text)]
    public void Validation_Works(FormTextType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FormTextType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FormTextType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FormTextType.Text)]
    public void SerializationRoundtrip_Works(FormTextType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FormTextType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FormTextType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FormTextType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FormTextType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
