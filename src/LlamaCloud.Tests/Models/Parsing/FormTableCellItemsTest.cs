using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class FormTableCellItemsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableCellItems
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
        };

        List<FormTableCellItemsItem> expectedItems =
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

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FormTableCellItems
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormTableCellItems>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableCellItems
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormTableCellItems>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FormTableCellItemsItem> expectedItems =
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

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FormTableCellItems
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FormTableCellItems
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
        };

        FormTableCellItems copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableCellItemsItemTest : TestBase
{
    [Fact]
    public void FormFieldValidationWorks()
    {
        FormTableCellItemsItem value = new FormField()
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
        FormTableCellItemsItem value = new FormSection()
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
        FormTableCellItemsItem value = new FormTable()
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
        FormTableCellItemsItem value = new FormTableCellItemsItemText()
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
            Type = FormTableCellItemsItemTextType.Text,
        };
        value.Validate();
    }

    [Fact]
    public void FormFieldSerializationRoundtripWorks()
    {
        FormTableCellItemsItem value = new FormField()
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
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FormSectionSerializationRoundtripWorks()
    {
        FormTableCellItemsItem value = new FormSection()
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
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FormTableSerializationRoundtripWorks()
    {
        FormTableCellItemsItem value = new FormTable()
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
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        FormTableCellItemsItem value = new FormTableCellItemsItemText()
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
            Type = FormTableCellItemsItemTextType.Text,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FormTableCellItemsItemTextTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableCellItemsItemText
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
            Type = FormTableCellItemsItemTextType.Text,
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
        FormTableCellItemsItemTextGrounding expectedGrounding = new()
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
        ApiEnum<string, FormTableCellItemsItemTextType> expectedType =
            FormTableCellItemsItemTextType.Text;

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
        var model = new FormTableCellItemsItemText
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
            Type = FormTableCellItemsItemTextType.Text,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItemText>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableCellItemsItemText
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
            Type = FormTableCellItemsItemTextType.Text,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItemText>(
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
        FormTableCellItemsItemTextGrounding expectedGrounding = new()
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
        ApiEnum<string, FormTableCellItemsItemTextType> expectedType =
            FormTableCellItemsItemTextType.Text;

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
        var model = new FormTableCellItemsItemText
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
            Type = FormTableCellItemsItemTextType.Text,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FormTableCellItemsItemText
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
        var model = new FormTableCellItemsItemText
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
        var model = new FormTableCellItemsItemText
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
        var model = new FormTableCellItemsItemText
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
        var model = new FormTableCellItemsItemText
        {
            Value = "value",
            Type = FormTableCellItemsItemTextType.Text,
        };

        Assert.Null(model.Bbox);
        Assert.False(model.RawData.ContainsKey("bbox"));
        Assert.Null(model.Grounding);
        Assert.False(model.RawData.ContainsKey("grounding"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FormTableCellItemsItemText
        {
            Value = "value",
            Type = FormTableCellItemsItemTextType.Text,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FormTableCellItemsItemText
        {
            Value = "value",
            Type = FormTableCellItemsItemTextType.Text,

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
        var model = new FormTableCellItemsItemText
        {
            Value = "value",
            Type = FormTableCellItemsItemTextType.Text,

            Bbox = null,
            Grounding = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FormTableCellItemsItemText
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
            Type = FormTableCellItemsItemTextType.Text,
        };

        FormTableCellItemsItemText copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableCellItemsItemTextGroundingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableCellItemsItemTextGrounding
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

        FormTableCellItemsItemTextGroundingID expectedID = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
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
        FormTableCellItemsItemTextGroundingLabel expectedLabel = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
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
        FormTableCellItemsItemTextGroundingValue expectedValue = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
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
        var model = new FormTableCellItemsItemTextGrounding
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
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItemTextGrounding>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableCellItemsItemTextGrounding
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
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItemTextGrounding>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        FormTableCellItemsItemTextGroundingID expectedID = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
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
        FormTableCellItemsItemTextGroundingLabel expectedLabel = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
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
        FormTableCellItemsItemTextGroundingValue expectedValue = new(
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                    Span =
                    [
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                        JsonSerializer.Deserialize<JsonElement>("{}"),
                    ],
                    Words =
                    [
                        new()
                        {
                            Bbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
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
        var model = new FormTableCellItemsItemTextGrounding
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
        var model = new FormTableCellItemsItemTextGrounding { };

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
        var model = new FormTableCellItemsItemTextGrounding { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FormTableCellItemsItemTextGrounding
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
        var model = new FormTableCellItemsItemTextGrounding
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
        var model = new FormTableCellItemsItemTextGrounding
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

        FormTableCellItemsItemTextGrounding copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableCellItemsItemTextGroundingIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingID
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

        List<FormTableCellItemsItemTextGroundingIDLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingID
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
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingID>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingID
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
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingID>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FormTableCellItemsItemTextGroundingIDLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingID
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
        var model = new FormTableCellItemsItemTextGroundingID
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

        FormTableCellItemsItemTextGroundingID copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableCellItemsItemTextGroundingIDLineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        List<FormTableCellItemsItemTextGroundingIDLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
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
        var model = new FormTableCellItemsItemTextGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingIDLine>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingIDLine>(
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
        List<FormTableCellItemsItemTextGroundingIDLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
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
        var model = new FormTableCellItemsItemTextGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var model = new FormTableCellItemsItemTextGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingIDLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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

        FormTableCellItemsItemTextGroundingIDLine copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableCellItemsItemTextGroundingIDLineWordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingIDLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingIDLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized =
            JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingIDLineWord>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingIDLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized =
            JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingIDLineWord>(
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
        var model = new FormTableCellItemsItemTextGroundingIDLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingIDLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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

        FormTableCellItemsItemTextGroundingIDLineWord copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableCellItemsItemTextGroundingLabelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingLabel
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

        List<FormTableCellItemsItemTextGroundingLabelLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingLabel
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
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingLabel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingLabel
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
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingLabel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FormTableCellItemsItemTextGroundingLabelLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingLabel
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
        var model = new FormTableCellItemsItemTextGroundingLabel
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

        FormTableCellItemsItemTextGroundingLabel copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableCellItemsItemTextGroundingLabelLineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        List<FormTableCellItemsItemTextGroundingLabelLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
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
        var model = new FormTableCellItemsItemTextGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingLabelLine>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingLabelLine>(
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
        List<FormTableCellItemsItemTextGroundingLabelLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
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
        var model = new FormTableCellItemsItemTextGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var model = new FormTableCellItemsItemTextGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingLabelLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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

        FormTableCellItemsItemTextGroundingLabelLine copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableCellItemsItemTextGroundingLabelLineWordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingLabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingLabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized =
            JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingLabelLineWord>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingLabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized =
            JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingLabelLineWord>(
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
        var model = new FormTableCellItemsItemTextGroundingLabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingLabelLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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

        FormTableCellItemsItemTextGroundingLabelLineWord copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableCellItemsItemTextGroundingValueTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingValue
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

        List<FormTableCellItemsItemTextGroundingValueLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingValue
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
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingValue>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingValue
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
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingValue>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FormTableCellItemsItemTextGroundingValueLine> expectedLines =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
                Span =
                [
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                    JsonSerializer.Deserialize<JsonElement>("{}"),
                ],
                Words =
                [
                    new()
                    {
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingValue
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
        var model = new FormTableCellItemsItemTextGroundingValue
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

        FormTableCellItemsItemTextGroundingValue copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableCellItemsItemTextGroundingValueLineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        List<FormTableCellItemsItemTextGroundingValueLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
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
        var model = new FormTableCellItemsItemTextGroundingValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingValueLine>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var deserialized = JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingValueLine>(
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
        List<FormTableCellItemsItemTextGroundingValueLineWord> expectedWords =
        [
            new()
            {
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
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
        var model = new FormTableCellItemsItemTextGroundingValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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
        var model = new FormTableCellItemsItemTextGroundingValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingValueLine
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
            Span =
            [
                JsonSerializer.Deserialize<JsonElement>("{}"),
                JsonSerializer.Deserialize<JsonElement>("{}"),
            ],
            Words =
            [
                new()
                {
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
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

        FormTableCellItemsItemTextGroundingValueLine copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableCellItemsItemTextGroundingValueLineWordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingValueLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingValueLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized =
            JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingValueLineWord>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormTableCellItemsItemTextGroundingValueLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var deserialized =
            JsonSerializer.Deserialize<FormTableCellItemsItemTextGroundingValueLineWord>(
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
        var model = new FormTableCellItemsItemTextGroundingValueLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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
        var model = new FormTableCellItemsItemTextGroundingValueLineWord
        {
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
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

        FormTableCellItemsItemTextGroundingValueLineWord copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormTableCellItemsItemTextTypeTest : TestBase
{
    [Theory]
    [InlineData(FormTableCellItemsItemTextType.Text)]
    public void Validation_Works(FormTableCellItemsItemTextType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FormTableCellItemsItemTextType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FormTableCellItemsItemTextType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FormTableCellItemsItemTextType.Text)]
    public void SerializationRoundtrip_Works(FormTableCellItemsItemTextType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FormTableCellItemsItemTextType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FormTableCellItemsItemTextType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FormTableCellItemsItemTextType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, FormTableCellItemsItemTextType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
