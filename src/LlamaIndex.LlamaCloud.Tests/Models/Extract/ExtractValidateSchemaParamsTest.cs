using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Extract;

namespace LlamaIndex.LlamaCloud.Tests.Models.Extract;

public class ExtractValidateSchemaParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExtractValidateSchemaParams
        {
            DataSchema = new Dictionary<string, ExtractValidateSchemaParamsDataSchema?>()
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

        Dictionary<string, ExtractValidateSchemaParamsDataSchema?> expectedDataSchema = new()
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

        Assert.Equal(expectedDataSchema.Count, parameters.DataSchema.Count);
        foreach (var item in expectedDataSchema)
        {
            Assert.True(parameters.DataSchema.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.DataSchema[item.Key]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        ExtractValidateSchemaParams parameters = new()
        {
            DataSchema = new Dictionary<string, ExtractValidateSchemaParamsDataSchema?>()
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

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.cloud.llamaindex.ai/api/v2/extract/schema/validation"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExtractValidateSchemaParams
        {
            DataSchema = new Dictionary<string, ExtractValidateSchemaParamsDataSchema?>()
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

        ExtractValidateSchemaParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ExtractValidateSchemaParamsDataSchemaTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        ExtractValidateSchemaParamsDataSchema value = new(
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
        ExtractValidateSchemaParamsDataSchema value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        ExtractValidateSchemaParamsDataSchema value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ExtractValidateSchemaParamsDataSchema value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ExtractValidateSchemaParamsDataSchema value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        ExtractValidateSchemaParamsDataSchema value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractValidateSchemaParamsDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        ExtractValidateSchemaParamsDataSchema value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractValidateSchemaParamsDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExtractValidateSchemaParamsDataSchema value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractValidateSchemaParamsDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ExtractValidateSchemaParamsDataSchema value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractValidateSchemaParamsDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ExtractValidateSchemaParamsDataSchema value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractValidateSchemaParamsDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
