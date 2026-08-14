using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class FooterItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FooterItem
        {
            Items =
            [
                new CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
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
                    Language = "language",
                    Type = Type.Code,
                },
            ],
            Md = "md",
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
            Type = FooterItemType.Footer,
        };

        List<Item> expectedItems =
        [
            new CodeItem()
            {
                Md = "md",
                ValueValue = "value",
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
                Language = "language",
                Type = Type.Code,
            },
        ];
        string expectedMd = "md";
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
        ApiEnum<string, FooterItemType> expectedType = FooterItemType.Footer;

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedMd, model.Md);
        Assert.NotNull(model.Bbox);
        Assert.Equal(expectedBbox.Count, model.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], model.Bbox[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FooterItem
        {
            Items =
            [
                new CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
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
                    Language = "language",
                    Type = Type.Code,
                },
            ],
            Md = "md",
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
            Type = FooterItemType.Footer,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FooterItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FooterItem
        {
            Items =
            [
                new CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
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
                    Language = "language",
                    Type = Type.Code,
                },
            ],
            Md = "md",
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
            Type = FooterItemType.Footer,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FooterItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Item> expectedItems =
        [
            new CodeItem()
            {
                Md = "md",
                ValueValue = "value",
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
                Language = "language",
                Type = Type.Code,
            },
        ];
        string expectedMd = "md";
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
        ApiEnum<string, FooterItemType> expectedType = FooterItemType.Footer;

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedMd, deserialized.Md);
        Assert.NotNull(deserialized.Bbox);
        Assert.Equal(expectedBbox.Count, deserialized.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], deserialized.Bbox[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FooterItem
        {
            Items =
            [
                new CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
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
                    Language = "language",
                    Type = Type.Code,
                },
            ],
            Md = "md",
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
            Type = FooterItemType.Footer,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FooterItem
        {
            Items =
            [
                new CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
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
                    Language = "language",
                    Type = Type.Code,
                },
            ],
            Md = "md",
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
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FooterItem
        {
            Items =
            [
                new CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
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
                    Language = "language",
                    Type = Type.Code,
                },
            ],
            Md = "md",
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FooterItem
        {
            Items =
            [
                new CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
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
                    Language = "language",
                    Type = Type.Code,
                },
            ],
            Md = "md",
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

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FooterItem
        {
            Items =
            [
                new CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
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
                    Language = "language",
                    Type = Type.Code,
                },
            ],
            Md = "md",
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

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FooterItem
        {
            Items =
            [
                new CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
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
                    Language = "language",
                    Type = Type.Code,
                },
            ],
            Md = "md",
            Type = FooterItemType.Footer,
        };

        Assert.Null(model.Bbox);
        Assert.False(model.RawData.ContainsKey("bbox"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FooterItem
        {
            Items =
            [
                new CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
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
                    Language = "language",
                    Type = Type.Code,
                },
            ],
            Md = "md",
            Type = FooterItemType.Footer,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FooterItem
        {
            Items =
            [
                new CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
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
                    Language = "language",
                    Type = Type.Code,
                },
            ],
            Md = "md",
            Type = FooterItemType.Footer,

            Bbox = null,
        };

        Assert.Null(model.Bbox);
        Assert.True(model.RawData.ContainsKey("bbox"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FooterItem
        {
            Items =
            [
                new CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
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
                    Language = "language",
                    Type = Type.Code,
                },
            ],
            Md = "md",
            Type = FooterItemType.Footer,

            Bbox = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FooterItem
        {
            Items =
            [
                new CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
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
                    Language = "language",
                    Type = Type.Code,
                },
            ],
            Md = "md",
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
            Type = FooterItemType.Footer,
        };

        FooterItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void CodeValidationWorks()
    {
        Item value = new CodeItem()
        {
            Md = "md",
            ValueValue = "value",
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
            Language = "language",
            Type = Type.Code,
        };
        value.Validate();
    }

    [Fact]
    public void HeadingValidationWorks()
    {
        Item value = new HeadingItem()
        {
            Level = 0,
            Md = "md",
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
            Type = HeadingItemType.Heading,
        };
        value.Validate();
    }

    [Fact]
    public void ImageValidationWorks()
    {
        Item value = new ImageItem()
        {
            Caption = "caption",
            Md = "md",
            Url = "url",
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
            Type = ImageItemType.Image,
        };
        value.Validate();
    }

    [Fact]
    public void LinkValidationWorks()
    {
        Item value = new LinkItem()
        {
            Md = "md",
            Text = "text",
            Url = "url",
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
            Type = LinkItemType.Link,
        };
        value.Validate();
    }

    [Fact]
    public void ListValidationWorks()
    {
        Item value = new ListItem()
        {
            Items =
            [
                new TextItem()
                {
                    Md = "md",
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
                    Type = TextItemType.Text,
                },
            ],
            Md = "md",
            Ordered = true,
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
            Type = ListItemType.List,
        };
        value.Validate();
    }

    [Fact]
    public void TableValidationWorks()
    {
        Item value = new TableItem()
        {
            Csv = "csv",
            Html = "html",
            Md = "md",
            Rows =
            [
                ["string"],
            ],
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
            MergedFromPages = [0],
            MergedIntoPage = 0,
            ParseConcerns = [new() { Details = "details", Type = "type" }],
            Type = TableItemType.Table,
        };
        value.Validate();
    }

    [Fact]
    public void TextValidationWorks()
    {
        Item value = new TextItem()
        {
            Md = "md",
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
            Type = TextItemType.Text,
        };
        value.Validate();
    }

    [Fact]
    public void CodeSerializationRoundtripWorks()
    {
        Item value = new CodeItem()
        {
            Md = "md",
            ValueValue = "value",
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
            Language = "language",
            Type = Type.Code,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void HeadingSerializationRoundtripWorks()
    {
        Item value = new HeadingItem()
        {
            Level = 0,
            Md = "md",
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
            Type = HeadingItemType.Heading,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageSerializationRoundtripWorks()
    {
        Item value = new ImageItem()
        {
            Caption = "caption",
            Md = "md",
            Url = "url",
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
            Type = ImageItemType.Image,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LinkSerializationRoundtripWorks()
    {
        Item value = new LinkItem()
        {
            Md = "md",
            Text = "text",
            Url = "url",
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
            Type = LinkItemType.Link,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ListSerializationRoundtripWorks()
    {
        Item value = new ListItem()
        {
            Items =
            [
                new TextItem()
                {
                    Md = "md",
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
                    Type = TextItemType.Text,
                },
            ],
            Md = "md",
            Ordered = true,
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
            Type = ListItemType.List,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TableSerializationRoundtripWorks()
    {
        Item value = new TableItem()
        {
            Csv = "csv",
            Html = "html",
            Md = "md",
            Rows =
            [
                ["string"],
            ],
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
            MergedFromPages = [0],
            MergedIntoPage = 0,
            ParseConcerns = [new() { Details = "details", Type = "type" }],
            Type = TableItemType.Table,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        Item value = new TextItem()
        {
            Md = "md",
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
            Type = TextItemType.Text,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class FooterItemTypeTest : TestBase
{
    [Theory]
    [InlineData(FooterItemType.Footer)]
    public void Validation_Works(FooterItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FooterItemType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FooterItemType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FooterItemType.Footer)]
    public void SerializationRoundtrip_Works(FooterItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FooterItemType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FooterItemType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FooterItemType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FooterItemType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
