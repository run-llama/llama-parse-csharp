using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Extract;

namespace LlamaCloud.Tests.Models.Extract;

public class ExtractV2SchemaGenerateRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractV2SchemaGenerateRequest
        {
            DataSchema = new Dictionary<string, ExtractV2SchemaGenerateRequestDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            FileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Name = "invoice_extraction",
            Prompt =
                "Extract vendor name, invoice number, date, line items with descriptions and amounts, and total amount from invoices.",
        };

        Dictionary<string, ExtractV2SchemaGenerateRequestDataSchema?> expectedDataSchema = new()
        {
            {
                "foo",
                new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                )
            },
        };
        string expectedFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedName = "invoice_extraction";
        string expectedPrompt =
            "Extract vendor name, invoice number, date, line items with descriptions and amounts, and total amount from invoices.";

        Assert.NotNull(model.DataSchema);
        Assert.Equal(expectedDataSchema.Count, model.DataSchema.Count);
        foreach (var item in expectedDataSchema)
        {
            Assert.True(model.DataSchema.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.DataSchema[item.Key]);
        }
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPrompt, model.Prompt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractV2SchemaGenerateRequest
        {
            DataSchema = new Dictionary<string, ExtractV2SchemaGenerateRequestDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            FileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Name = "invoice_extraction",
            Prompt =
                "Extract vendor name, invoice number, date, line items with descriptions and amounts, and total amount from invoices.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaGenerateRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractV2SchemaGenerateRequest
        {
            DataSchema = new Dictionary<string, ExtractV2SchemaGenerateRequestDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            FileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Name = "invoice_extraction",
            Prompt =
                "Extract vendor name, invoice number, date, line items with descriptions and amounts, and total amount from invoices.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaGenerateRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, ExtractV2SchemaGenerateRequestDataSchema?> expectedDataSchema = new()
        {
            {
                "foo",
                new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                )
            },
        };
        string expectedFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedName = "invoice_extraction";
        string expectedPrompt =
            "Extract vendor name, invoice number, date, line items with descriptions and amounts, and total amount from invoices.";

        Assert.NotNull(deserialized.DataSchema);
        Assert.Equal(expectedDataSchema.Count, deserialized.DataSchema.Count);
        foreach (var item in expectedDataSchema)
        {
            Assert.True(deserialized.DataSchema.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.DataSchema[item.Key]);
        }
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPrompt, deserialized.Prompt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractV2SchemaGenerateRequest
        {
            DataSchema = new Dictionary<string, ExtractV2SchemaGenerateRequestDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            FileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Name = "invoice_extraction",
            Prompt =
                "Extract vendor name, invoice number, date, line items with descriptions and amounts, and total amount from invoices.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtractV2SchemaGenerateRequest { };

        Assert.Null(model.DataSchema);
        Assert.False(model.RawData.ContainsKey("data_schema"));
        Assert.Null(model.FileID);
        Assert.False(model.RawData.ContainsKey("file_id"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Prompt);
        Assert.False(model.RawData.ContainsKey("prompt"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtractV2SchemaGenerateRequest { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ExtractV2SchemaGenerateRequest
        {
            DataSchema = null,
            FileID = null,
            Name = null,
            Prompt = null,
        };

        Assert.Null(model.DataSchema);
        Assert.True(model.RawData.ContainsKey("data_schema"));
        Assert.Null(model.FileID);
        Assert.True(model.RawData.ContainsKey("file_id"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.Prompt);
        Assert.True(model.RawData.ContainsKey("prompt"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtractV2SchemaGenerateRequest
        {
            DataSchema = null,
            FileID = null,
            Name = null,
            Prompt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractV2SchemaGenerateRequest
        {
            DataSchema = new Dictionary<string, ExtractV2SchemaGenerateRequestDataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            FileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Name = "invoice_extraction",
            Prompt =
                "Extract vendor name, invoice number, date, line items with descriptions and amounts, and total amount from invoices.",
        };

        ExtractV2SchemaGenerateRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtractV2SchemaGenerateRequestDataSchemaTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        ExtractV2SchemaGenerateRequestDataSchema value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidationWorks1()
    {
        ExtractV2SchemaGenerateRequestDataSchema value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        ExtractV2SchemaGenerateRequestDataSchema value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ExtractV2SchemaGenerateRequestDataSchema value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ExtractV2SchemaGenerateRequestDataSchema value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        ExtractV2SchemaGenerateRequestDataSchema value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaGenerateRequestDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        ExtractV2SchemaGenerateRequestDataSchema value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaGenerateRequestDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExtractV2SchemaGenerateRequestDataSchema value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaGenerateRequestDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ExtractV2SchemaGenerateRequestDataSchema value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaGenerateRequestDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ExtractV2SchemaGenerateRequestDataSchema value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaGenerateRequestDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
