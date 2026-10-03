using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class FormTableTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTable
        {
            Rows =
            [
                ["string"],
            ],
            ID = "id",
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
            Columns = ["string"],
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
                Columns =
                [
                    new(
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
                ],
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
                Rows =
                [
                    [
                        new(
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
                    ],
                ],
            },
            Label = "label",
            Type = FormTableType.Table,
        };

        List<List<Row?>> expectedRows =
        [
            ["string"],
        ];
        string expectedID = "id";
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
        List<string> expectedColumns = ["string"];
        FormTableGrounding expectedGrounding = new()
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
            Columns =
            [
                new(
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
            ],
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
            Rows =
            [
                [
                    new(
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
                ],
            ],
        };
        string expectedLabel = "label";
        ApiEnum<string, FormTableType> expectedType = FormTableType.Table;

        Assert.Equal(expectedRows.Count, model.Rows.Count);
        for (int i = 0; i < expectedRows.Count; i++)
        {
            Assert.Equal(expectedRows[i].Count, model.Rows[i].Count);
            for (int i1 = 0; i1 < expectedRows[i].Count; i1++)
            {
                Assert.Equal(expectedRows[i][i1], model.Rows[i][i1]);
            }
        }
        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.Bbox);
        Assert.Equal(expectedBbox.Count, model.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], model.Bbox[i]);
        }
        Assert.NotNull(model.Columns);
        Assert.Equal(expectedColumns.Count, model.Columns.Count);
        for (int i = 0; i < expectedColumns.Count; i++)
        {
            Assert.Equal(expectedColumns[i], model.Columns[i]);
        }
        Assert.Equal(expectedGrounding, model.Grounding);
        Assert.Equal(expectedLabel, model.Label);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FormTable
        {
            Rows =
            [
                ["string"],
            ],
            ID = "id",
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
            Columns = ["string"],
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
                Columns =
                [
                    new(
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
                ],
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
                Rows =
                [
                    [
                        new(
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
                    ],
                ],
            },
            Label = "label",
            Type = FormTableType.Table,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormTable>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTable
        {
            Rows =
            [
                ["string"],
            ],
            ID = "id",
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
            Columns = ["string"],
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
                Columns =
                [
                    new(
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
                ],
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
                Rows =
                [
                    [
                        new(
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
                    ],
                ],
            },
            Label = "label",
            Type = FormTableType.Table,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormTable>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<List<Row?>> expectedRows =
        [
            ["string"],
        ];
        string expectedID = "id";
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
        List<string> expectedColumns = ["string"];
        FormTableGrounding expectedGrounding = new()
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
            Columns =
            [
                new(
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
            ],
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
            Rows =
            [
                [
                    new(
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
                ],
            ],
        };
        string expectedLabel = "label";
        ApiEnum<string, FormTableType> expectedType = FormTableType.Table;

        Assert.Equal(expectedRows.Count, deserialized.Rows.Count);
        for (int i = 0; i < expectedRows.Count; i++)
        {
            Assert.Equal(expectedRows[i].Count, deserialized.Rows[i].Count);
            for (int i1 = 0; i1 < expectedRows[i].Count; i1++)
            {
                Assert.Equal(expectedRows[i][i1], deserialized.Rows[i][i1]);
            }
        }
        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.Bbox);
        Assert.Equal(expectedBbox.Count, deserialized.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], deserialized.Bbox[i]);
        }
        Assert.NotNull(deserialized.Columns);
        Assert.Equal(expectedColumns.Count, deserialized.Columns.Count);
        for (int i = 0; i < expectedColumns.Count; i++)
        {
            Assert.Equal(expectedColumns[i], deserialized.Columns[i]);
        }
        Assert.Equal(expectedGrounding, deserialized.Grounding);
        Assert.Equal(expectedLabel, deserialized.Label);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FormTable
        {
            Rows =
            [
                ["string"],
            ],
            ID = "id",
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
            Columns = ["string"],
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
                Columns =
                [
                    new(
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
                ],
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
                Rows =
                [
                    [
                        new(
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
                    ],
                ],
            },
            Label = "label",
            Type = FormTableType.Table,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FormTable
        {
            Rows =
            [
                ["string"],
            ],
            ID = "id",
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
            Columns = ["string"],
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
                Columns =
                [
                    new(
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
                ],
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
                Rows =
                [
                    [
                        new(
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
                    ],
                ],
            },
            Label = "label",
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FormTable
        {
            Rows =
            [
                ["string"],
            ],
            ID = "id",
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
            Columns = ["string"],
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
                Columns =
                [
                    new(
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
                ],
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
                Rows =
                [
                    [
                        new(
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
                    ],
                ],
            },
            Label = "label",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FormTable
        {
            Rows =
            [
                ["string"],
            ],
            ID = "id",
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
            Columns = ["string"],
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
                Columns =
                [
                    new(
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
                ],
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
                Rows =
                [
                    [
                        new(
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
                    ],
                ],
            },
            Label = "label",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FormTable
        {
            Rows =
            [
                ["string"],
            ],
            ID = "id",
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
            Columns = ["string"],
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
                Columns =
                [
                    new(
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
                ],
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
                Rows =
                [
                    [
                        new(
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
                    ],
                ],
            },
            Label = "label",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FormTable
        {
            Rows =
            [
                ["string"],
            ],
            Type = FormTableType.Table,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Bbox);
        Assert.False(model.RawData.ContainsKey("bbox"));
        Assert.Null(model.Columns);
        Assert.False(model.RawData.ContainsKey("columns"));
        Assert.Null(model.Grounding);
        Assert.False(model.RawData.ContainsKey("grounding"));
        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FormTable
        {
            Rows =
            [
                ["string"],
            ],
            Type = FormTableType.Table,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FormTable
        {
            Rows =
            [
                ["string"],
            ],
            Type = FormTableType.Table,

            ID = null,
            Bbox = null,
            Columns = null,
            Grounding = null,
            Label = null,
        };

        Assert.Null(model.ID);
        Assert.True(model.RawData.ContainsKey("id"));
        Assert.Null(model.Bbox);
        Assert.True(model.RawData.ContainsKey("bbox"));
        Assert.Null(model.Columns);
        Assert.True(model.RawData.ContainsKey("columns"));
        Assert.Null(model.Grounding);
        Assert.True(model.RawData.ContainsKey("grounding"));
        Assert.Null(model.Label);
        Assert.True(model.RawData.ContainsKey("label"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FormTable
        {
            Rows =
            [
                ["string"],
            ],
            Type = FormTableType.Table,

            ID = null,
            Bbox = null,
            Columns = null,
            Grounding = null,
            Label = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FormTable
        {
            Rows =
            [
                ["string"],
            ],
            ID = "id",
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
            Columns = ["string"],
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
                Columns =
                [
                    new(
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
                ],
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
                Rows =
                [
                    [
                        new(
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
                    ],
                ],
            },
            Label = "label",
            Type = FormTableType.Table,
        };

        FormTable copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RowTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Row value = "string";
        value.Validate();
    }

    [Fact]
    public void FormTableCellItemsValidationWorks()
    {
        Row value = new FormTableCellItems(
            [
                new FormField()
                {
                    Field = Field.Checkbox,
                    ID = "id",
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
                    IsEmpty = true,
                    Label = "label",
                    Type = FormFieldType.Field,
                    Value = "string",
                    ValueItems =
                    [
                        new FormSection()
                        {
                            Items =
                            [
                                new FormTable()
                                {
                                    Rows =
                                    [
                                        ["string"],
                                    ],
                                    ID = "id",
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
                                    Columns = ["string"],
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
                                                        JsonSerializer.Deserialize<JsonElement>(
                                                            "{}"
                                                        ),
                                                        JsonSerializer.Deserialize<JsonElement>(
                                                            "{}"
                                                        ),
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
                                                                JsonSerializer.Deserialize<JsonElement>(
                                                                    "{}"
                                                                ),
                                                                JsonSerializer.Deserialize<JsonElement>(
                                                                    "{}"
                                                                ),
                                                            ],
                                                        },
                                                    ],
                                                },
                                            ]
                                        ),
                                        Columns =
                                        [
                                            new(
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
                                                            JsonSerializer.Deserialize<JsonElement>(
                                                                "{}"
                                                            ),
                                                            JsonSerializer.Deserialize<JsonElement>(
                                                                "{}"
                                                            ),
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
                                                                    JsonSerializer.Deserialize<JsonElement>(
                                                                        "{}"
                                                                    ),
                                                                    JsonSerializer.Deserialize<JsonElement>(
                                                                        "{}"
                                                                    ),
                                                                ],
                                                            },
                                                        ],
                                                    },
                                                ]
                                            ),
                                        ],
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
                                                        JsonSerializer.Deserialize<JsonElement>(
                                                            "{}"
                                                        ),
                                                        JsonSerializer.Deserialize<JsonElement>(
                                                            "{}"
                                                        ),
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
                                                                JsonSerializer.Deserialize<JsonElement>(
                                                                    "{}"
                                                                ),
                                                                JsonSerializer.Deserialize<JsonElement>(
                                                                    "{}"
                                                                ),
                                                            ],
                                                        },
                                                    ],
                                                },
                                            ]
                                        ),
                                        Rows =
                                        [
                                            [
                                                new(
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
                                                                JsonSerializer.Deserialize<JsonElement>(
                                                                    "{}"
                                                                ),
                                                                JsonSerializer.Deserialize<JsonElement>(
                                                                    "{}"
                                                                ),
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
                                                                        JsonSerializer.Deserialize<JsonElement>(
                                                                            "{}"
                                                                        ),
                                                                        JsonSerializer.Deserialize<JsonElement>(
                                                                            "{}"
                                                                        ),
                                                                    ],
                                                                },
                                                            ],
                                                        },
                                                    ]
                                                ),
                                            ],
                                        ],
                                    },
                                    Label = "label",
                                    Type = FormTableType.Table,
                                },
                            ],
                            ID = "id",
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
                                                        JsonSerializer.Deserialize<JsonElement>(
                                                            "{}"
                                                        ),
                                                        JsonSerializer.Deserialize<JsonElement>(
                                                            "{}"
                                                        ),
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
                                                        JsonSerializer.Deserialize<JsonElement>(
                                                            "{}"
                                                        ),
                                                        JsonSerializer.Deserialize<JsonElement>(
                                                            "{}"
                                                        ),
                                                    ],
                                                },
                                            ],
                                        },
                                    ]
                                ),
                            },
                            Label = "label",
                            Type = FormSectionType.Section,
                        },
                    ],
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Row value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Row>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FormTableCellItemsSerializationRoundtripWorks()
    {
        Row value = new FormTableCellItems(
            [
                new FormField()
                {
                    Field = Field.Checkbox,
                    ID = "id",
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
                    IsEmpty = true,
                    Label = "label",
                    Type = FormFieldType.Field,
                    Value = "string",
                    ValueItems =
                    [
                        new FormSection()
                        {
                            Items =
                            [
                                new FormTable()
                                {
                                    Rows =
                                    [
                                        ["string"],
                                    ],
                                    ID = "id",
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
                                    Columns = ["string"],
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
                                                        JsonSerializer.Deserialize<JsonElement>(
                                                            "{}"
                                                        ),
                                                        JsonSerializer.Deserialize<JsonElement>(
                                                            "{}"
                                                        ),
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
                                                                JsonSerializer.Deserialize<JsonElement>(
                                                                    "{}"
                                                                ),
                                                                JsonSerializer.Deserialize<JsonElement>(
                                                                    "{}"
                                                                ),
                                                            ],
                                                        },
                                                    ],
                                                },
                                            ]
                                        ),
                                        Columns =
                                        [
                                            new(
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
                                                            JsonSerializer.Deserialize<JsonElement>(
                                                                "{}"
                                                            ),
                                                            JsonSerializer.Deserialize<JsonElement>(
                                                                "{}"
                                                            ),
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
                                                                    JsonSerializer.Deserialize<JsonElement>(
                                                                        "{}"
                                                                    ),
                                                                    JsonSerializer.Deserialize<JsonElement>(
                                                                        "{}"
                                                                    ),
                                                                ],
                                                            },
                                                        ],
                                                    },
                                                ]
                                            ),
                                        ],
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
                                                        JsonSerializer.Deserialize<JsonElement>(
                                                            "{}"
                                                        ),
                                                        JsonSerializer.Deserialize<JsonElement>(
                                                            "{}"
                                                        ),
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
                                                                JsonSerializer.Deserialize<JsonElement>(
                                                                    "{}"
                                                                ),
                                                                JsonSerializer.Deserialize<JsonElement>(
                                                                    "{}"
                                                                ),
                                                            ],
                                                        },
                                                    ],
                                                },
                                            ]
                                        ),
                                        Rows =
                                        [
                                            [
                                                new(
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
                                                                JsonSerializer.Deserialize<JsonElement>(
                                                                    "{}"
                                                                ),
                                                                JsonSerializer.Deserialize<JsonElement>(
                                                                    "{}"
                                                                ),
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
                                                                        JsonSerializer.Deserialize<JsonElement>(
                                                                            "{}"
                                                                        ),
                                                                        JsonSerializer.Deserialize<JsonElement>(
                                                                            "{}"
                                                                        ),
                                                                    ],
                                                                },
                                                            ],
                                                        },
                                                    ]
                                                ),
                                            ],
                                        ],
                                    },
                                    Label = "label",
                                    Type = FormTableType.Table,
                                },
                            ],
                            ID = "id",
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
                                                        JsonSerializer.Deserialize<JsonElement>(
                                                            "{}"
                                                        ),
                                                        JsonSerializer.Deserialize<JsonElement>(
                                                            "{}"
                                                        ),
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
                                                        JsonSerializer.Deserialize<JsonElement>(
                                                            "{}"
                                                        ),
                                                        JsonSerializer.Deserialize<JsonElement>(
                                                            "{}"
                                                        ),
                                                    ],
                                                },
                                            ],
                                        },
                                    ]
                                ),
                            },
                            Label = "label",
                            Type = FormSectionType.Section,
                        },
                    ],
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Row>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FormTableGroundingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableGrounding
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
            Columns =
            [
                new(
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
            ],
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
            Rows =
            [
                [
                    new(
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
                ],
            ],
        };

        FormTableGroundingID expectedID = new(
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
        List<Column> expectedColumns =
        [
            new(
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
        ];
        FormTableGroundingLabel expectedLabel = new(
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
        List<List<FormTextGrounding>> expectedRows =
        [
            [
                new(
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
            ],
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.Columns);
        Assert.Equal(expectedColumns.Count, model.Columns.Count);
        for (int i = 0; i < expectedColumns.Count; i++)
        {
            Assert.Equal(expectedColumns[i], model.Columns[i]);
        }
        Assert.Equal(expectedLabel, model.Label);
        Assert.NotNull(model.Rows);
        Assert.Equal(expectedRows.Count, model.Rows.Count);
        for (int i = 0; i < expectedRows.Count; i++)
        {
            Assert.Equal(expectedRows[i].Count, model.Rows[i].Count);
            for (int i1 = 0; i1 < expectedRows[i].Count; i1++)
            {
                Assert.Equal(expectedRows[i][i1], model.Rows[i][i1]);
            }
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FormTableGrounding
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
            Columns =
            [
                new(
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
            ],
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
            Rows =
            [
                [
                    new(
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
                ],
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormTableGrounding>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableGrounding
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
            Columns =
            [
                new(
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
            ],
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
            Rows =
            [
                [
                    new(
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
                ],
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormTableGrounding>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FormTableGroundingID expectedID = new(
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
        List<Column> expectedColumns =
        [
            new(
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
        ];
        FormTableGroundingLabel expectedLabel = new(
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
        List<List<FormTextGrounding>> expectedRows =
        [
            [
                new(
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
            ],
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.Columns);
        Assert.Equal(expectedColumns.Count, deserialized.Columns.Count);
        for (int i = 0; i < expectedColumns.Count; i++)
        {
            Assert.Equal(expectedColumns[i], deserialized.Columns[i]);
        }
        Assert.Equal(expectedLabel, deserialized.Label);
        Assert.NotNull(deserialized.Rows);
        Assert.Equal(expectedRows.Count, deserialized.Rows.Count);
        for (int i = 0; i < expectedRows.Count; i++)
        {
            Assert.Equal(expectedRows[i].Count, deserialized.Rows[i].Count);
            for (int i1 = 0; i1 < expectedRows[i].Count; i1++)
            {
                Assert.Equal(expectedRows[i][i1], deserialized.Rows[i][i1]);
            }
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FormTableGrounding
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
            Columns =
            [
                new(
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
            ],
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
            Rows =
            [
                [
                    new(
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
                ],
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FormTableGrounding { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Columns);
        Assert.False(model.RawData.ContainsKey("columns"));
        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
        Assert.Null(model.Rows);
        Assert.False(model.RawData.ContainsKey("rows"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FormTableGrounding { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FormTableGrounding
        {
            ID = null,
            Columns = null,
            Label = null,
            Rows = null,
        };

        Assert.Null(model.ID);
        Assert.True(model.RawData.ContainsKey("id"));
        Assert.Null(model.Columns);
        Assert.True(model.RawData.ContainsKey("columns"));
        Assert.Null(model.Label);
        Assert.True(model.RawData.ContainsKey("label"));
        Assert.Null(model.Rows);
        Assert.True(model.RawData.ContainsKey("rows"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FormTableGrounding
        {
            ID = null,
            Columns = null,
            Label = null,
            Rows = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FormTableGrounding
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
            Columns =
            [
                new(
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
            ],
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
            Rows =
            [
                [
                    new(
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
                ],
            ],
        };

        FormTableGrounding copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableGroundingIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableGroundingID
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

        List<FormTableGroundingIDLine> expectedLines =
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
        var model = new FormTableGroundingID
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
        var deserialized = JsonSerializer.Deserialize<FormTableGroundingID>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableGroundingID
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
        var deserialized = JsonSerializer.Deserialize<FormTableGroundingID>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FormTableGroundingIDLine> expectedLines =
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
        var model = new FormTableGroundingID
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
        var model = new FormTableGroundingID
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

        FormTableGroundingID copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableGroundingIDLineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableGroundingIDLine
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
        List<FormTableGroundingIDLineWord> expectedWords =
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
        var model = new FormTableGroundingIDLine
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
        var deserialized = JsonSerializer.Deserialize<FormTableGroundingIDLine>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableGroundingIDLine
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
        var deserialized = JsonSerializer.Deserialize<FormTableGroundingIDLine>(
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
        List<FormTableGroundingIDLineWord> expectedWords =
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
        var model = new FormTableGroundingIDLine
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
        var model = new FormTableGroundingIDLine
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
        var model = new FormTableGroundingIDLine
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
        var model = new FormTableGroundingIDLine
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
        var model = new FormTableGroundingIDLine
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
        var model = new FormTableGroundingIDLine
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

        FormTableGroundingIDLine copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableGroundingIDLineWordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableGroundingIDLineWord
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
        var model = new FormTableGroundingIDLineWord
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
        var deserialized = JsonSerializer.Deserialize<FormTableGroundingIDLineWord>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableGroundingIDLineWord
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
        var deserialized = JsonSerializer.Deserialize<FormTableGroundingIDLineWord>(
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
        var model = new FormTableGroundingIDLineWord
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
        var model = new FormTableGroundingIDLineWord
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

        FormTableGroundingIDLineWord copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ColumnTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Column
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

        List<ColumnLine> expectedLines =
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
        var model = new Column
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
        var deserialized = JsonSerializer.Deserialize<Column>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Column
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
        var deserialized = JsonSerializer.Deserialize<Column>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<ColumnLine> expectedLines =
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
        var model = new Column
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
        var model = new Column
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

        Column copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ColumnLineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ColumnLine
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
        List<ColumnLineWord> expectedWords =
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
        var model = new ColumnLine
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
        var deserialized = JsonSerializer.Deserialize<ColumnLine>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ColumnLine
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
        var deserialized = JsonSerializer.Deserialize<ColumnLine>(
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
        List<ColumnLineWord> expectedWords =
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
        var model = new ColumnLine
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
        var model = new ColumnLine
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
        var model = new ColumnLine
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
        var model = new ColumnLine
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
        var model = new ColumnLine
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
        var model = new ColumnLine
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

        ColumnLine copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ColumnLineWordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ColumnLineWord
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
        var model = new ColumnLineWord
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
        var deserialized = JsonSerializer.Deserialize<ColumnLineWord>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ColumnLineWord
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
        var deserialized = JsonSerializer.Deserialize<ColumnLineWord>(
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
        var model = new ColumnLineWord
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
        var model = new ColumnLineWord
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

        ColumnLineWord copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableGroundingLabelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableGroundingLabel
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

        List<FormTableGroundingLabelLine> expectedLines =
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
        var model = new FormTableGroundingLabel
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
        var deserialized = JsonSerializer.Deserialize<FormTableGroundingLabel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableGroundingLabel
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
        var deserialized = JsonSerializer.Deserialize<FormTableGroundingLabel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FormTableGroundingLabelLine> expectedLines =
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
        var model = new FormTableGroundingLabel
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
        var model = new FormTableGroundingLabel
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

        FormTableGroundingLabel copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableGroundingLabelLineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableGroundingLabelLine
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
        List<FormTableGroundingLabelLineWord> expectedWords =
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
        var model = new FormTableGroundingLabelLine
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
        var deserialized = JsonSerializer.Deserialize<FormTableGroundingLabelLine>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableGroundingLabelLine
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
        var deserialized = JsonSerializer.Deserialize<FormTableGroundingLabelLine>(
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
        List<FormTableGroundingLabelLineWord> expectedWords =
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
        var model = new FormTableGroundingLabelLine
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
        var model = new FormTableGroundingLabelLine
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
        var model = new FormTableGroundingLabelLine
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
        var model = new FormTableGroundingLabelLine
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
        var model = new FormTableGroundingLabelLine
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
        var model = new FormTableGroundingLabelLine
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

        FormTableGroundingLabelLine copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableGroundingLabelLineWordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableGroundingLabelLineWord
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
        var model = new FormTableGroundingLabelLineWord
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
        var deserialized = JsonSerializer.Deserialize<FormTableGroundingLabelLineWord>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableGroundingLabelLineWord
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
        var deserialized = JsonSerializer.Deserialize<FormTableGroundingLabelLineWord>(
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
        var model = new FormTableGroundingLabelLineWord
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
        var model = new FormTableGroundingLabelLineWord
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

        FormTableGroundingLabelLineWord copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTextGroundingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTextGrounding
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

        List<FormTextGroundingLine> expectedLines =
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
        var model = new FormTextGrounding
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
        var deserialized = JsonSerializer.Deserialize<FormTextGrounding>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTextGrounding
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
        var deserialized = JsonSerializer.Deserialize<FormTextGrounding>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FormTextGroundingLine> expectedLines =
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
        var model = new FormTextGrounding
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
        var model = new FormTextGrounding
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

        FormTextGrounding copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTextGroundingLineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTextGroundingLine
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
        List<FormTextGroundingLineWord> expectedWords =
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
        var model = new FormTextGroundingLine
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
        var deserialized = JsonSerializer.Deserialize<FormTextGroundingLine>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTextGroundingLine
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
        var deserialized = JsonSerializer.Deserialize<FormTextGroundingLine>(
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
        List<FormTextGroundingLineWord> expectedWords =
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
        var model = new FormTextGroundingLine
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
        var model = new FormTextGroundingLine
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
        var model = new FormTextGroundingLine
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
        var model = new FormTextGroundingLine
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
        var model = new FormTextGroundingLine
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
        var model = new FormTextGroundingLine
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

        FormTextGroundingLine copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTextGroundingLineWordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTextGroundingLineWord
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
        var model = new FormTextGroundingLineWord
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
        var deserialized = JsonSerializer.Deserialize<FormTextGroundingLineWord>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTextGroundingLineWord
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
        var deserialized = JsonSerializer.Deserialize<FormTextGroundingLineWord>(
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
        var model = new FormTextGroundingLineWord
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
        var model = new FormTextGroundingLineWord
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

        FormTextGroundingLineWord copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableTypeTest : TestBase
{
    [Theory]
    [InlineData(FormTableType.Table)]
    public void Validation_Works(FormTableType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FormTableType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FormTableType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FormTableType.Table)]
    public void SerializationRoundtrip_Works(FormTableType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FormTableType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FormTableType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FormTableType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FormTableType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
