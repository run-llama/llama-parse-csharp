using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Parsing;

namespace LlamaIndex.LlamaCloud.Tests.Models.Parsing;

public class FormFieldTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormField
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
                    ValueItems = [],
                },
            ],
        };

        ApiEnum<string, Field> expectedField = Field.Checkbox;
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
        bool expectedIsEmpty = true;
        string expectedLabel = "label";
        ApiEnum<string, FormFieldType> expectedType = FormFieldType.Field;
        FormFieldValue expectedValue = "string";
        List<ValueItem> expectedValueItems =
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
                ValueItems = [],
            },
        ];

        Assert.Equal(expectedField, model.Field);
        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.Bbox);
        Assert.Equal(expectedBbox.Count, model.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], model.Bbox[i]);
        }
        Assert.Equal(expectedIsEmpty, model.IsEmpty);
        Assert.Equal(expectedLabel, model.Label);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
        Assert.NotNull(model.ValueItems);
        Assert.Equal(expectedValueItems.Count, model.ValueItems.Count);
        for (int i = 0; i < expectedValueItems.Count; i++)
        {
            Assert.Equal(expectedValueItems[i], model.ValueItems[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FormField
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
                    ValueItems = [],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormField>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormField
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
                    ValueItems = [],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormField>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Field> expectedField = Field.Checkbox;
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
        bool expectedIsEmpty = true;
        string expectedLabel = "label";
        ApiEnum<string, FormFieldType> expectedType = FormFieldType.Field;
        FormFieldValue expectedValue = "string";
        List<ValueItem> expectedValueItems =
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
                ValueItems = [],
            },
        ];

        Assert.Equal(expectedField, deserialized.Field);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.Bbox);
        Assert.Equal(expectedBbox.Count, deserialized.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], deserialized.Bbox[i]);
        }
        Assert.Equal(expectedIsEmpty, deserialized.IsEmpty);
        Assert.Equal(expectedLabel, deserialized.Label);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
        Assert.NotNull(deserialized.ValueItems);
        Assert.Equal(expectedValueItems.Count, deserialized.ValueItems.Count);
        for (int i = 0; i < expectedValueItems.Count; i++)
        {
            Assert.Equal(expectedValueItems[i], deserialized.ValueItems[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FormField
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
                    ValueItems = [],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FormField
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
            Value = "string",
            ValueItems =
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
                    ValueItems = [],
                },
            ],
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FormField
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
            Value = "string",
            ValueItems =
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
                    ValueItems = [],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FormField
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
            Value = "string",
            ValueItems =
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
                    ValueItems = [],
                },
            ],

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FormField
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
            Value = "string",
            ValueItems =
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
                    ValueItems = [],
                },
            ],

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FormField { Field = Field.Checkbox, Type = FormFieldType.Field };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Bbox);
        Assert.False(model.RawData.ContainsKey("bbox"));
        Assert.Null(model.IsEmpty);
        Assert.False(model.RawData.ContainsKey("isEmpty"));
        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
        Assert.Null(model.ValueItems);
        Assert.False(model.RawData.ContainsKey("valueItems"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FormField { Field = Field.Checkbox, Type = FormFieldType.Field };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FormField
        {
            Field = Field.Checkbox,
            Type = FormFieldType.Field,

            ID = null,
            Bbox = null,
            IsEmpty = null,
            Label = null,
            Value = null,
            ValueItems = null,
        };

        Assert.Null(model.ID);
        Assert.True(model.RawData.ContainsKey("id"));
        Assert.Null(model.Bbox);
        Assert.True(model.RawData.ContainsKey("bbox"));
        Assert.Null(model.IsEmpty);
        Assert.True(model.RawData.ContainsKey("isEmpty"));
        Assert.Null(model.Label);
        Assert.True(model.RawData.ContainsKey("label"));
        Assert.Null(model.Value);
        Assert.True(model.RawData.ContainsKey("value"));
        Assert.Null(model.ValueItems);
        Assert.True(model.RawData.ContainsKey("valueItems"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FormField
        {
            Field = Field.Checkbox,
            Type = FormFieldType.Field,

            ID = null,
            Bbox = null,
            IsEmpty = null,
            Label = null,
            Value = null,
            ValueItems = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FormField
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
                    ValueItems = [],
                },
            ],
        };

        FormField copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FieldTest : TestBase
{
    [Theory]
    [InlineData(Field.Checkbox)]
    [InlineData(Field.MultiSelect)]
    [InlineData(Field.Signature)]
    [InlineData(Field.SingleSelect)]
    [InlineData(Field.Text)]
    public void Validation_Works(Field rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Field> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Field.Checkbox)]
    [InlineData(Field.MultiSelect)]
    [InlineData(Field.Signature)]
    [InlineData(Field.SingleSelect)]
    [InlineData(Field.Text)]
    public void SerializationRoundtrip_Works(Field rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Field> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Field>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FormFieldTypeTest : TestBase
{
    [Theory]
    [InlineData(FormFieldType.Field)]
    public void Validation_Works(FormFieldType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FormFieldType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FormFieldType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FormFieldType.Field)]
    public void SerializationRoundtrip_Works(FormFieldType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FormFieldType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FormFieldType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FormFieldType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FormFieldType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FormFieldValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        FormFieldValue value = "string";
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        FormFieldValue value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        FormFieldValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormFieldValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        FormFieldValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormFieldValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ValueItemTest : TestBase
{
    [Fact]
    public void FormFieldValidationWorks()
    {
        ValueItem value = new FormField()
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
        ValueItem value = new FormSection()
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
        ValueItem value = new FormTable()
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
        ValueItem value = new FormField()
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
        var deserialized = JsonSerializer.Deserialize<ValueItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FormSectionSerializationRoundtripWorks()
    {
        ValueItem value = new FormSection()
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
        var deserialized = JsonSerializer.Deserialize<ValueItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FormTableSerializationRoundtripWorks()
    {
        ValueItem value = new FormTable()
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
        var deserialized = JsonSerializer.Deserialize<ValueItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
