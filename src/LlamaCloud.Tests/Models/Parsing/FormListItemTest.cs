using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class FormListItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormListItem
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

        List<FormListItemItem> expectedItems =
        [
            new FormListTextItem()
            {
                Md = "md",
                Value = "value",
                Type = FormListTextItemType.Text,
            },
        ];
        string expectedMd = "md";
        bool expectedOrdered = true;
        ApiEnum<string, FormListItemType> expectedType = FormListItemType.List;

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedMd, model.Md);
        Assert.Equal(expectedOrdered, model.Ordered);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FormListItem
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormListItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormListItem
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormListItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FormListItemItem> expectedItems =
        [
            new FormListTextItem()
            {
                Md = "md",
                Value = "value",
                Type = FormListTextItemType.Text,
            },
        ];
        string expectedMd = "md";
        bool expectedOrdered = true;
        ApiEnum<string, FormListItemType> expectedType = FormListItemType.List;

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedMd, deserialized.Md);
        Assert.Equal(expectedOrdered, deserialized.Ordered);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FormListItem
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FormListItem
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
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FormListItem
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FormListItem
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

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FormListItem
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

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FormListItem
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

        FormListItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormListItemItemTest : TestBase
{
    [Fact]
    public void FormListTextValidationWorks()
    {
        FormListItemItem value = new FormListTextItem()
        {
            Md = "md",
            Value = "value",
            Type = FormListTextItemType.Text,
        };
        value.Validate();
    }

    [Fact]
    public void FormListValidationWorks()
    {
        FormListItemItem value = new FormListItem()
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
        value.Validate();
    }

    [Fact]
    public void FormListTextSerializationRoundtripWorks()
    {
        FormListItemItem value = new FormListTextItem()
        {
            Md = "md",
            Value = "value",
            Type = FormListTextItemType.Text,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormListItemItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FormListSerializationRoundtripWorks()
    {
        FormListItemItem value = new FormListItem()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormListItemItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FormListItemTypeTest : TestBase
{
    [Theory]
    [InlineData(FormListItemType.List)]
    public void Validation_Works(FormListItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FormListItemType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FormListItemType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FormListItemType.List)]
    public void SerializationRoundtrip_Works(FormListItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FormListItemType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FormListItemType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FormListItemType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FormListItemType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
