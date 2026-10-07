using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class FormTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Form
        {
            Json =
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
                                    Html = "html",
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
            ],
            List = new()
            {
                Items =
                [
                    new FormListTextItem()
                    {
                        Md = "md",
                        Value = "value",
                        Type = FormListTextItemType.Text,
                    },
                ],
                Md = "md",
                Ordered = true,
                Type = FormListItemType.List,
            },
        };

        List<FormJson> expectedJson =
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
                                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                                ],
                                                Words =
                                                [
                                                    new()
                                                    {
                                                        Bbox = new()
                                                        {
                                                            H = 0,
                                                            W = 0,
                                                            X = 0,
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
                                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                                ],
                                                Words =
                                                [
                                                    new()
                                                    {
                                                        Bbox = new()
                                                        {
                                                            H = 0,
                                                            W = 0,
                                                            X = 0,
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
                                Html = "html",
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
            },
        ];
        FormListItem expectedList = new()
        {
            Items =
            [
                new FormListTextItem()
                {
                    Md = "md",
                    Value = "value",
                    Type = FormListTextItemType.Text,
                },
            ],
            Md = "md",
            Ordered = true,
            Type = FormListItemType.List,
        };

        Assert.Equal(expectedJson.Count, model.Json.Count);
        for (int i = 0; i < expectedJson.Count; i++)
        {
            Assert.Equal(expectedJson[i], model.Json[i]);
        }
        Assert.Equal(expectedList, model.List);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Form
        {
            Json =
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
                                    Html = "html",
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
            ],
            List = new()
            {
                Items =
                [
                    new FormListTextItem()
                    {
                        Md = "md",
                        Value = "value",
                        Type = FormListTextItemType.Text,
                    },
                ],
                Md = "md",
                Ordered = true,
                Type = FormListItemType.List,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Form>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Form
        {
            Json =
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
                                    Html = "html",
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
            ],
            List = new()
            {
                Items =
                [
                    new FormListTextItem()
                    {
                        Md = "md",
                        Value = "value",
                        Type = FormListTextItemType.Text,
                    },
                ],
                Md = "md",
                Ordered = true,
                Type = FormListItemType.List,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Form>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<FormJson> expectedJson =
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
                                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                                ],
                                                Words =
                                                [
                                                    new()
                                                    {
                                                        Bbox = new()
                                                        {
                                                            H = 0,
                                                            W = 0,
                                                            X = 0,
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
                                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                                    JsonSerializer.Deserialize<JsonElement>("{}"),
                                                ],
                                                Words =
                                                [
                                                    new()
                                                    {
                                                        Bbox = new()
                                                        {
                                                            H = 0,
                                                            W = 0,
                                                            X = 0,
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
                                Html = "html",
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
            },
        ];
        FormListItem expectedList = new()
        {
            Items =
            [
                new FormListTextItem()
                {
                    Md = "md",
                    Value = "value",
                    Type = FormListTextItemType.Text,
                },
            ],
            Md = "md",
            Ordered = true,
            Type = FormListItemType.List,
        };

        Assert.Equal(expectedJson.Count, deserialized.Json.Count);
        for (int i = 0; i < expectedJson.Count; i++)
        {
            Assert.Equal(expectedJson[i], deserialized.Json[i]);
        }
        Assert.Equal(expectedList, deserialized.List);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Form
        {
            Json =
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
                                    Html = "html",
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
            ],
            List = new()
            {
                Items =
                [
                    new FormListTextItem()
                    {
                        Md = "md",
                        Value = "value",
                        Type = FormListTextItemType.Text,
                    },
                ],
                Md = "md",
                Ordered = true,
                Type = FormListItemType.List,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Form
        {
            Json =
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
                                    Html = "html",
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
            ],
            List = new()
            {
                Items =
                [
                    new FormListTextItem()
                    {
                        Md = "md",
                        Value = "value",
                        Type = FormListTextItemType.Text,
                    },
                ],
                Md = "md",
                Ordered = true,
                Type = FormListItemType.List,
            },
        };

        Form copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormJsonTest : TestBase
{
    [Fact]
    public void FormFieldValidationWorks()
    {
        FormJson value = new FormField()
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
                            Html = "html",
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
        FormJson value = new FormSection()
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
                            Html = "html",
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
        FormJson value = new FormTable()
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
            Html = "html",
            Label = "label",
            Type = FormTableType.Table,
        };
        value.Validate();
    }

    [Fact]
    public void TextValidationWorks()
    {
        FormJson value = new Text()
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
            Type = TextType.Text,
        };
        value.Validate();
    }

    [Fact]
    public void FormFieldSerializationRoundtripWorks()
    {
        FormJson value = new FormField()
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
                            Html = "html",
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
        var deserialized = JsonSerializer.Deserialize<FormJson>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FormSectionSerializationRoundtripWorks()
    {
        FormJson value = new FormSection()
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
                            Html = "html",
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
        var deserialized = JsonSerializer.Deserialize<FormJson>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FormTableSerializationRoundtripWorks()
    {
        FormJson value = new FormTable()
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
            Html = "html",
            Label = "label",
            Type = FormTableType.Table,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormJson>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        FormJson value = new Text()
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
            Type = TextType.Text,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormJson>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TextTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Text
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
            Type = TextType.Text,
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
        Grounding expectedGrounding = new()
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
        ApiEnum<string, TextType> expectedType = TextType.Text;

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
        var model = new Text
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
            Type = TextType.Text,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Text>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Text
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
            Type = TextType.Text,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Text>(element, ModelBase.SerializerOptions);
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
        Grounding expectedGrounding = new()
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
        ApiEnum<string, TextType> expectedType = TextType.Text;

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
        var model = new Text
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
            Type = TextType.Text,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Text
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
        var model = new Text
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
        var model = new Text
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
        var model = new Text
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
        var model = new Text { Value = "value", Type = TextType.Text };

        Assert.Null(model.Bbox);
        Assert.False(model.RawData.ContainsKey("bbox"));
        Assert.Null(model.Grounding);
        Assert.False(model.RawData.ContainsKey("grounding"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Text { Value = "value", Type = TextType.Text };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Text
        {
            Value = "value",
            Type = TextType.Text,

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
        var model = new Text
        {
            Value = "value",
            Type = TextType.Text,

            Bbox = null,
            Grounding = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Text
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
            Type = TextType.Text,
        };

        Text copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GroundingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Grounding
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

        ID expectedID = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
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
        Label expectedLabel = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
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
        Value expectedValue = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
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
        var model = new Grounding
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
        var deserialized = JsonSerializer.Deserialize<Grounding>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Grounding
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
        var deserialized = JsonSerializer.Deserialize<Grounding>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ID expectedID = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
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
        Label expectedLabel = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
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
        Value expectedValue = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
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
        var model = new Grounding
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
        var model = new Grounding { };

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
        var model = new Grounding { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Grounding
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
        var model = new Grounding
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
        var model = new Grounding
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

        Grounding copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ID
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

        List<Line> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
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
        var model = new ID
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
        var deserialized = JsonSerializer.Deserialize<ID>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ID
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
        var deserialized = JsonSerializer.Deserialize<ID>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<Line> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
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
        var model = new ID
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
        var model = new ID
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

        ID copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Line
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        List<Word> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
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
        var model = new Line
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var deserialized = JsonSerializer.Deserialize<Line>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Line
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var deserialized = JsonSerializer.Deserialize<Line>(element, ModelBase.SerializerOptions);
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
        List<Word> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
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
        var model = new Line
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var model = new Line
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new Line
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new Line
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new Line
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new Line
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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

        Line copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Word
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new Word
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized = JsonSerializer.Deserialize<Word>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Word
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized = JsonSerializer.Deserialize<Word>(element, ModelBase.SerializerOptions);
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
        var model = new Word
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new Word
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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

        Word copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LabelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Label
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

        List<LabelLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
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
        var model = new Label
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
        var deserialized = JsonSerializer.Deserialize<Label>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Label
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
        var deserialized = JsonSerializer.Deserialize<Label>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<LabelLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
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
        var model = new Label
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
        var model = new Label
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

        Label copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LabelLineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        List<LabelLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
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
        var model = new LabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var deserialized = JsonSerializer.Deserialize<LabelLine>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var deserialized = JsonSerializer.Deserialize<LabelLine>(
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
        List<LabelLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
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
        var model = new LabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var model = new LabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new LabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new LabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new LabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new LabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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

        LabelLine copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LabelLineWordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new LabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized = JsonSerializer.Deserialize<LabelLineWord>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized = JsonSerializer.Deserialize<LabelLineWord>(
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
        var model = new LabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new LabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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

        LabelLineWord copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ValueTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Value
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

        List<ValueLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
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
        var model = new Value
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
        var deserialized = JsonSerializer.Deserialize<Value>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Value
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
        var deserialized = JsonSerializer.Deserialize<Value>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<ValueLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
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
        var model = new Value
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
        var model = new Value
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

        Value copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ValueLineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        List<ValueLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
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
        var model = new ValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var deserialized = JsonSerializer.Deserialize<ValueLine>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var deserialized = JsonSerializer.Deserialize<ValueLine>(
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
        List<ValueLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
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
        var model = new ValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var model = new ValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new ValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new ValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new ValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new ValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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

        ValueLine copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ValueLineWordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ValueLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new ValueLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized = JsonSerializer.Deserialize<ValueLineWord>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ValueLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized = JsonSerializer.Deserialize<ValueLineWord>(
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
        var model = new ValueLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new ValueLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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

        ValueLineWord copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TextTypeTest : TestBase
{
    [Theory]
    [InlineData(TextType.Text)]
    public void Validation_Works(TextType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TextType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TextType.Text)]
    public void SerializationRoundtrip_Works(TextType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TextType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TextType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TextType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
