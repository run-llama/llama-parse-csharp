using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class FormSectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormSection
        {
            Items =
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
                            Items = [],
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
            },
            Label = "label",
            Type = FormSectionType.Section,
        };

        List<FormSectionItem> expectedItems =
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
                        Items = [],
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
                        },
                        Label = "label",
                        Type = FormSectionType.Section,
                    },
                ],
            },
        ];
        string expectedID = "id";
        FormSectionGrounding expectedGrounding = new()
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
        };
        string expectedLabel = "label";
        ApiEnum<string, FormSectionType> expectedType = FormSectionType.Section;

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedGrounding, model.Grounding);
        Assert.Equal(expectedLabel, model.Label);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FormSection
        {
            Items =
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
                            Items = [],
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
            },
            Label = "label",
            Type = FormSectionType.Section,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormSection>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormSection
        {
            Items =
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
                            Items = [],
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
            },
            Label = "label",
            Type = FormSectionType.Section,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormSection>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FormSectionItem> expectedItems =
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
                        Items = [],
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
                        },
                        Label = "label",
                        Type = FormSectionType.Section,
                    },
                ],
            },
        ];
        string expectedID = "id";
        FormSectionGrounding expectedGrounding = new()
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
        };
        string expectedLabel = "label";
        ApiEnum<string, FormSectionType> expectedType = FormSectionType.Section;

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedGrounding, deserialized.Grounding);
        Assert.Equal(expectedLabel, deserialized.Label);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FormSection
        {
            Items =
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
                            Items = [],
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
            },
            Label = "label",
            Type = FormSectionType.Section,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FormSection
        {
            Items =
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
                            Items = [],
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
            },
            Label = "label",
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FormSection
        {
            Items =
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
                            Items = [],
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
            },
            Label = "label",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FormSection
        {
            Items =
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
                            Items = [],
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
        var model = new FormSection
        {
            Items =
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
                            Items = [],
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
        var model = new FormSection
        {
            Items =
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
                            Items = [],
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
            ],
            Type = FormSectionType.Section,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Grounding);
        Assert.False(model.RawData.ContainsKey("grounding"));
        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FormSection
        {
            Items =
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
                            Items = [],
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
            ],
            Type = FormSectionType.Section,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FormSection
        {
            Items =
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
                            Items = [],
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
            ],
            Type = FormSectionType.Section,

            ID = null,
            Grounding = null,
            Label = null,
        };

        Assert.Null(model.ID);
        Assert.True(model.RawData.ContainsKey("id"));
        Assert.Null(model.Grounding);
        Assert.True(model.RawData.ContainsKey("grounding"));
        Assert.Null(model.Label);
        Assert.True(model.RawData.ContainsKey("label"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FormSection
        {
            Items =
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
                            Items = [],
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
            ],
            Type = FormSectionType.Section,

            ID = null,
            Grounding = null,
            Label = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FormSection
        {
            Items =
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
                            Items = [],
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
            },
            Label = "label",
            Type = FormSectionType.Section,
        };

        FormSection copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormSectionItemTest : TestBase
{
    [Fact]
    public void FormFieldValidationWorks()
    {
        FormSectionItem value = new FormField()
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
                    },
                    Label = "label",
                    Type = FormSectionType.Section,
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void FormSectionValidationWorks()
    {
        FormSectionItem value = new FormSection()
        {
            Items =
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
            },
            Label = "label",
            Type = FormSectionType.Section,
        };
        value.Validate();
    }

    [Fact]
    public void FormTableValidationWorks()
    {
        FormSectionItem value = new FormTable()
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
        value.Validate();
    }

    [Fact]
    public void FormFieldSerializationRoundtripWorks()
    {
        FormSectionItem value = new FormField()
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
                    },
                    Label = "label",
                    Type = FormSectionType.Section,
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormSectionItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FormSectionSerializationRoundtripWorks()
    {
        FormSectionItem value = new FormSection()
        {
            Items =
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
            },
            Label = "label",
            Type = FormSectionType.Section,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormSectionItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FormTableSerializationRoundtripWorks()
    {
        FormSectionItem value = new FormTable()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormSectionItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FormSectionGroundingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormSectionGrounding
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
        };

        FormSectionGroundingID expectedID = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
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
        FormSectionGroundingLabel expectedLabel = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FormSectionGrounding
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormSectionGrounding>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormSectionGrounding
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormSectionGrounding>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FormSectionGroundingID expectedID = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
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
        FormSectionGroundingLabel expectedLabel = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FormSectionGrounding
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FormSectionGrounding { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FormSectionGrounding { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FormSectionGrounding { ID = null, Label = null };

        Assert.Null(model.ID);
        Assert.True(model.RawData.ContainsKey("id"));
        Assert.Null(model.Label);
        Assert.True(model.RawData.ContainsKey("label"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FormSectionGrounding { ID = null, Label = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FormSectionGrounding
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
        };

        FormSectionGrounding copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormSectionGroundingIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormSectionGroundingID
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

        List<FormSectionGroundingIDLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
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
        var model = new FormSectionGroundingID
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
        var deserialized = JsonSerializer.Deserialize<FormSectionGroundingID>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormSectionGroundingID
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
        var deserialized = JsonSerializer.Deserialize<FormSectionGroundingID>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FormSectionGroundingIDLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
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
        var model = new FormSectionGroundingID
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
        var model = new FormSectionGroundingID
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

        FormSectionGroundingID copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormSectionGroundingIDLineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormSectionGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        List<FormSectionGroundingIDLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
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
        var model = new FormSectionGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized = JsonSerializer.Deserialize<FormSectionGroundingIDLine>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormSectionGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized = JsonSerializer.Deserialize<FormSectionGroundingIDLine>(
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
        List<FormSectionGroundingIDLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
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
        var model = new FormSectionGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormSectionGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormSectionGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormSectionGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormSectionGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormSectionGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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

        FormSectionGroundingIDLine copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormSectionGroundingIDLineWordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormSectionGroundingIDLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormSectionGroundingIDLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized = JsonSerializer.Deserialize<FormSectionGroundingIDLineWord>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormSectionGroundingIDLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized = JsonSerializer.Deserialize<FormSectionGroundingIDLineWord>(
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
        var model = new FormSectionGroundingIDLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormSectionGroundingIDLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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

        FormSectionGroundingIDLineWord copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormSectionGroundingLabelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormSectionGroundingLabel
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

        List<FormSectionGroundingLabelLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
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
        var model = new FormSectionGroundingLabel
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
        var deserialized = JsonSerializer.Deserialize<FormSectionGroundingLabel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormSectionGroundingLabel
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
        var deserialized = JsonSerializer.Deserialize<FormSectionGroundingLabel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FormSectionGroundingLabelLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
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
        var model = new FormSectionGroundingLabel
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
        var model = new FormSectionGroundingLabel
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

        FormSectionGroundingLabel copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormSectionGroundingLabelLineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormSectionGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        List<FormSectionGroundingLabelLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
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
        var model = new FormSectionGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized = JsonSerializer.Deserialize<FormSectionGroundingLabelLine>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormSectionGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized = JsonSerializer.Deserialize<FormSectionGroundingLabelLine>(
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
        List<FormSectionGroundingLabelLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
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
        var model = new FormSectionGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormSectionGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormSectionGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormSectionGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormSectionGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormSectionGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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

        FormSectionGroundingLabelLine copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormSectionGroundingLabelLineWordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormSectionGroundingLabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormSectionGroundingLabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized = JsonSerializer.Deserialize<FormSectionGroundingLabelLineWord>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormSectionGroundingLabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized = JsonSerializer.Deserialize<FormSectionGroundingLabelLineWord>(
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
        var model = new FormSectionGroundingLabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormSectionGroundingLabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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

        FormSectionGroundingLabelLineWord copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormSectionTypeTest : TestBase
{
    [Theory]
    [InlineData(FormSectionType.Section)]
    public void Validation_Works(FormSectionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FormSectionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FormSectionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FormSectionType.Section)]
    public void SerializationRoundtrip_Works(FormSectionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FormSectionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FormSectionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FormSectionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FormSectionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
