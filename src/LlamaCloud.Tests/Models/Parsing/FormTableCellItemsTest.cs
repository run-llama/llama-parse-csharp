using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
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
            Label = "label",
            Type = FormTableType.Table,
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
}
