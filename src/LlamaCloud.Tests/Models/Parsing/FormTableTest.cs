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
            Label = null,
        };

        Assert.Null(model.ID);
        Assert.True(model.RawData.ContainsKey("id"));
        Assert.Null(model.Bbox);
        Assert.True(model.RawData.ContainsKey("bbox"));
        Assert.Null(model.Columns);
        Assert.True(model.RawData.ContainsKey("columns"));
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
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Row>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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
