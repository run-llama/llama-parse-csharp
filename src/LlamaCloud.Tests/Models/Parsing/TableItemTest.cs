using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class TableItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TableItem
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

        string expectedCsv = "csv";
        string expectedHtml = "html";
        string expectedMd = "md";
        List<List<TableItemRow?>> expectedRows =
        [
            ["string"],
        ];
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
        List<long> expectedMergedFromPages = [0];
        long expectedMergedIntoPage = 0;
        List<ParseConcern> expectedParseConcerns = [new() { Details = "details", Type = "type" }];
        ApiEnum<string, TableItemType> expectedType = TableItemType.Table;

        Assert.Equal(expectedCsv, model.Csv);
        Assert.Equal(expectedHtml, model.Html);
        Assert.Equal(expectedMd, model.Md);
        Assert.Equal(expectedRows.Count, model.Rows.Count);
        for (int i = 0; i < expectedRows.Count; i++)
        {
            Assert.Equal(expectedRows[i].Count, model.Rows[i].Count);
            for (int i1 = 0; i1 < expectedRows[i].Count; i1++)
            {
                Assert.Equal(expectedRows[i][i1], model.Rows[i][i1]);
            }
        }
        Assert.NotNull(model.Bbox);
        Assert.Equal(expectedBbox.Count, model.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], model.Bbox[i]);
        }
        Assert.NotNull(model.MergedFromPages);
        Assert.Equal(expectedMergedFromPages.Count, model.MergedFromPages.Count);
        for (int i = 0; i < expectedMergedFromPages.Count; i++)
        {
            Assert.Equal(expectedMergedFromPages[i], model.MergedFromPages[i]);
        }
        Assert.Equal(expectedMergedIntoPage, model.MergedIntoPage);
        Assert.NotNull(model.ParseConcerns);
        Assert.Equal(expectedParseConcerns.Count, model.ParseConcerns.Count);
        for (int i = 0; i < expectedParseConcerns.Count; i++)
        {
            Assert.Equal(expectedParseConcerns[i], model.ParseConcerns[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TableItem
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TableItem>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TableItem
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TableItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCsv = "csv";
        string expectedHtml = "html";
        string expectedMd = "md";
        List<List<TableItemRow?>> expectedRows =
        [
            ["string"],
        ];
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
        List<long> expectedMergedFromPages = [0];
        long expectedMergedIntoPage = 0;
        List<ParseConcern> expectedParseConcerns = [new() { Details = "details", Type = "type" }];
        ApiEnum<string, TableItemType> expectedType = TableItemType.Table;

        Assert.Equal(expectedCsv, deserialized.Csv);
        Assert.Equal(expectedHtml, deserialized.Html);
        Assert.Equal(expectedMd, deserialized.Md);
        Assert.Equal(expectedRows.Count, deserialized.Rows.Count);
        for (int i = 0; i < expectedRows.Count; i++)
        {
            Assert.Equal(expectedRows[i].Count, deserialized.Rows[i].Count);
            for (int i1 = 0; i1 < expectedRows[i].Count; i1++)
            {
                Assert.Equal(expectedRows[i][i1], deserialized.Rows[i][i1]);
            }
        }
        Assert.NotNull(deserialized.Bbox);
        Assert.Equal(expectedBbox.Count, deserialized.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], deserialized.Bbox[i]);
        }
        Assert.NotNull(deserialized.MergedFromPages);
        Assert.Equal(expectedMergedFromPages.Count, deserialized.MergedFromPages.Count);
        for (int i = 0; i < expectedMergedFromPages.Count; i++)
        {
            Assert.Equal(expectedMergedFromPages[i], deserialized.MergedFromPages[i]);
        }
        Assert.Equal(expectedMergedIntoPage, deserialized.MergedIntoPage);
        Assert.NotNull(deserialized.ParseConcerns);
        Assert.Equal(expectedParseConcerns.Count, deserialized.ParseConcerns.Count);
        for (int i = 0; i < expectedParseConcerns.Count; i++)
        {
            Assert.Equal(expectedParseConcerns[i], deserialized.ParseConcerns[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TableItem
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TableItem
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
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TableItem
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TableItem
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

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TableItem
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

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TableItem
        {
            Csv = "csv",
            Html = "html",
            Md = "md",
            Rows =
            [
                ["string"],
            ],
            Type = TableItemType.Table,
        };

        Assert.Null(model.Bbox);
        Assert.False(model.RawData.ContainsKey("bbox"));
        Assert.Null(model.MergedFromPages);
        Assert.False(model.RawData.ContainsKey("merged_from_pages"));
        Assert.Null(model.MergedIntoPage);
        Assert.False(model.RawData.ContainsKey("merged_into_page"));
        Assert.Null(model.ParseConcerns);
        Assert.False(model.RawData.ContainsKey("parse_concerns"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TableItem
        {
            Csv = "csv",
            Html = "html",
            Md = "md",
            Rows =
            [
                ["string"],
            ],
            Type = TableItemType.Table,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TableItem
        {
            Csv = "csv",
            Html = "html",
            Md = "md",
            Rows =
            [
                ["string"],
            ],
            Type = TableItemType.Table,

            Bbox = null,
            MergedFromPages = null,
            MergedIntoPage = null,
            ParseConcerns = null,
        };

        Assert.Null(model.Bbox);
        Assert.True(model.RawData.ContainsKey("bbox"));
        Assert.Null(model.MergedFromPages);
        Assert.True(model.RawData.ContainsKey("merged_from_pages"));
        Assert.Null(model.MergedIntoPage);
        Assert.True(model.RawData.ContainsKey("merged_into_page"));
        Assert.Null(model.ParseConcerns);
        Assert.True(model.RawData.ContainsKey("parse_concerns"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TableItem
        {
            Csv = "csv",
            Html = "html",
            Md = "md",
            Rows =
            [
                ["string"],
            ],
            Type = TableItemType.Table,

            Bbox = null,
            MergedFromPages = null,
            MergedIntoPage = null,
            ParseConcerns = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TableItem
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

        TableItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TableItemRowTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        TableItemRow value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        TableItemRow value = 0;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        TableItemRow value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TableItemRow>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        TableItemRow value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TableItemRow>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ParseConcernTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ParseConcern { Details = "details", Type = "type" };

        string expectedDetails = "details";
        string expectedType = "type";

        Assert.Equal(expectedDetails, model.Details);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ParseConcern { Details = "details", Type = "type" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParseConcern>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ParseConcern { Details = "details", Type = "type" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParseConcern>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDetails = "details";
        string expectedType = "type";

        Assert.Equal(expectedDetails, deserialized.Details);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ParseConcern { Details = "details", Type = "type" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ParseConcern { Details = "details", Type = "type" };

        ParseConcern copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TableItemTypeTest : TestBase
{
    [Theory]
    [InlineData(TableItemType.Table)]
    public void Validation_Works(TableItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TableItemType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TableItemType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TableItemType.Table)]
    public void SerializationRoundtrip_Works(TableItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TableItemType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TableItemType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TableItemType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TableItemType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
