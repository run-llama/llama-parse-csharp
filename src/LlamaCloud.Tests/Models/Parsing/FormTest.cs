using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
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
                                    Label = "label",
                                    Type = FormTableType.Table,
                                },
                            ],
                            ID = "id",
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
                                Label = "label",
                                Type = FormTableType.Table,
                            },
                        ],
                        ID = "id",
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
                                    Label = "label",
                                    Type = FormTableType.Table,
                                },
                            ],
                            ID = "id",
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
                                    Label = "label",
                                    Type = FormTableType.Table,
                                },
                            ],
                            ID = "id",
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
                                Label = "label",
                                Type = FormTableType.Table,
                            },
                        ],
                        ID = "id",
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
                                    Label = "label",
                                    Type = FormTableType.Table,
                                },
                            ],
                            ID = "id",
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
                                    Label = "label",
                                    Type = FormTableType.Table,
                                },
                            ],
                            ID = "id",
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
                            Label = "label",
                            Type = FormTableType.Table,
                        },
                    ],
                    ID = "id",
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
                            Label = "label",
                            Type = FormTableType.Table,
                        },
                    ],
                },
            ],
            ID = "id",
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
            Label = "label",
            Type = FormTableType.Table,
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
                            Label = "label",
                            Type = FormTableType.Table,
                        },
                    ],
                    ID = "id",
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
                            Label = "label",
                            Type = FormTableType.Table,
                        },
                    ],
                },
            ],
            ID = "id",
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
}
