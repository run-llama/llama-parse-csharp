using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Extract;

namespace LlamaCloud.Tests.Models.Extract;

public class ExtractV2SchemaValidateRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractV2SchemaValidateRequest
        {
            DataSchema = new Dictionary<string, ExtractV2SchemaValidateRequestDataSchema?>()
            {
                {
                    "properties",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "invoice_number", JsonSerializer.SerializeToElement("bar") },
                            { "line_items", JsonSerializer.SerializeToElement("bar") },
                            { "total_amount", JsonSerializer.SerializeToElement("bar") },
                            { "vendor_name", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
                {
                    "required",
                    new(
                        [
                            JsonSerializer.SerializeToElement("invoice_number"),
                            JsonSerializer.SerializeToElement("total_amount"),
                            JsonSerializer.SerializeToElement("vendor_name"),
                        ]
                    )
                },
                { "type", "object" },
            },
        };

        Dictionary<string, ExtractV2SchemaValidateRequestDataSchema?> expectedDataSchema = new()
        {
            {
                "properties",
                new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "invoice_number", JsonSerializer.SerializeToElement("bar") },
                        { "line_items", JsonSerializer.SerializeToElement("bar") },
                        { "total_amount", JsonSerializer.SerializeToElement("bar") },
                        { "vendor_name", JsonSerializer.SerializeToElement("bar") },
                    }
                )
            },
            {
                "required",
                new(
                    [
                        JsonSerializer.SerializeToElement("invoice_number"),
                        JsonSerializer.SerializeToElement("total_amount"),
                        JsonSerializer.SerializeToElement("vendor_name"),
                    ]
                )
            },
            { "type", "object" },
        };

        Assert.Equal(expectedDataSchema.Count, model.DataSchema.Count);
        foreach (var item in expectedDataSchema)
        {
            Assert.True(model.DataSchema.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.DataSchema[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractV2SchemaValidateRequest
        {
            DataSchema = new Dictionary<string, ExtractV2SchemaValidateRequestDataSchema?>()
            {
                {
                    "properties",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "invoice_number", JsonSerializer.SerializeToElement("bar") },
                            { "line_items", JsonSerializer.SerializeToElement("bar") },
                            { "total_amount", JsonSerializer.SerializeToElement("bar") },
                            { "vendor_name", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
                {
                    "required",
                    new(
                        [
                            JsonSerializer.SerializeToElement("invoice_number"),
                            JsonSerializer.SerializeToElement("total_amount"),
                            JsonSerializer.SerializeToElement("vendor_name"),
                        ]
                    )
                },
                { "type", "object" },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaValidateRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractV2SchemaValidateRequest
        {
            DataSchema = new Dictionary<string, ExtractV2SchemaValidateRequestDataSchema?>()
            {
                {
                    "properties",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "invoice_number", JsonSerializer.SerializeToElement("bar") },
                            { "line_items", JsonSerializer.SerializeToElement("bar") },
                            { "total_amount", JsonSerializer.SerializeToElement("bar") },
                            { "vendor_name", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
                {
                    "required",
                    new(
                        [
                            JsonSerializer.SerializeToElement("invoice_number"),
                            JsonSerializer.SerializeToElement("total_amount"),
                            JsonSerializer.SerializeToElement("vendor_name"),
                        ]
                    )
                },
                { "type", "object" },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaValidateRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, ExtractV2SchemaValidateRequestDataSchema?> expectedDataSchema = new()
        {
            {
                "properties",
                new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "invoice_number", JsonSerializer.SerializeToElement("bar") },
                        { "line_items", JsonSerializer.SerializeToElement("bar") },
                        { "total_amount", JsonSerializer.SerializeToElement("bar") },
                        { "vendor_name", JsonSerializer.SerializeToElement("bar") },
                    }
                )
            },
            {
                "required",
                new(
                    [
                        JsonSerializer.SerializeToElement("invoice_number"),
                        JsonSerializer.SerializeToElement("total_amount"),
                        JsonSerializer.SerializeToElement("vendor_name"),
                    ]
                )
            },
            { "type", "object" },
        };

        Assert.Equal(expectedDataSchema.Count, deserialized.DataSchema.Count);
        foreach (var item in expectedDataSchema)
        {
            Assert.True(deserialized.DataSchema.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.DataSchema[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractV2SchemaValidateRequest
        {
            DataSchema = new Dictionary<string, ExtractV2SchemaValidateRequestDataSchema?>()
            {
                {
                    "properties",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "invoice_number", JsonSerializer.SerializeToElement("bar") },
                            { "line_items", JsonSerializer.SerializeToElement("bar") },
                            { "total_amount", JsonSerializer.SerializeToElement("bar") },
                            { "vendor_name", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
                {
                    "required",
                    new(
                        [
                            JsonSerializer.SerializeToElement("invoice_number"),
                            JsonSerializer.SerializeToElement("total_amount"),
                            JsonSerializer.SerializeToElement("vendor_name"),
                        ]
                    )
                },
                { "type", "object" },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractV2SchemaValidateRequest
        {
            DataSchema = new Dictionary<string, ExtractV2SchemaValidateRequestDataSchema?>()
            {
                {
                    "properties",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "invoice_number", JsonSerializer.SerializeToElement("bar") },
                            { "line_items", JsonSerializer.SerializeToElement("bar") },
                            { "total_amount", JsonSerializer.SerializeToElement("bar") },
                            { "vendor_name", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
                {
                    "required",
                    new(
                        [
                            JsonSerializer.SerializeToElement("invoice_number"),
                            JsonSerializer.SerializeToElement("total_amount"),
                            JsonSerializer.SerializeToElement("vendor_name"),
                        ]
                    )
                },
                { "type", "object" },
            },
        };

        ExtractV2SchemaValidateRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtractV2SchemaValidateRequestDataSchemaTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        ExtractV2SchemaValidateRequestDataSchema value = new(
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
        ExtractV2SchemaValidateRequestDataSchema value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        ExtractV2SchemaValidateRequestDataSchema value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ExtractV2SchemaValidateRequestDataSchema value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ExtractV2SchemaValidateRequestDataSchema value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        ExtractV2SchemaValidateRequestDataSchema value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaValidateRequestDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        ExtractV2SchemaValidateRequestDataSchema value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaValidateRequestDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExtractV2SchemaValidateRequestDataSchema value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaValidateRequestDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ExtractV2SchemaValidateRequestDataSchema value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaValidateRequestDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ExtractV2SchemaValidateRequestDataSchema value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaValidateRequestDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
