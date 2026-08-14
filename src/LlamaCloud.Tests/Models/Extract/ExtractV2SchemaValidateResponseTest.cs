using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Extract;

namespace LlamaCloud.Tests.Models.Extract;

public class ExtractV2SchemaValidateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractV2SchemaValidateResponse
        {
            DataSchema = new Dictionary<string, ExtractV2SchemaValidateResponseDataSchema?>()
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
        };

        Dictionary<string, ExtractV2SchemaValidateResponseDataSchema?> expectedDataSchema = new()
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
        var model = new ExtractV2SchemaValidateResponse
        {
            DataSchema = new Dictionary<string, ExtractV2SchemaValidateResponseDataSchema?>()
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaValidateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractV2SchemaValidateResponse
        {
            DataSchema = new Dictionary<string, ExtractV2SchemaValidateResponseDataSchema?>()
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaValidateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, ExtractV2SchemaValidateResponseDataSchema?> expectedDataSchema = new()
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
        var model = new ExtractV2SchemaValidateResponse
        {
            DataSchema = new Dictionary<string, ExtractV2SchemaValidateResponseDataSchema?>()
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractV2SchemaValidateResponse
        {
            DataSchema = new Dictionary<string, ExtractV2SchemaValidateResponseDataSchema?>()
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
        };

        ExtractV2SchemaValidateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtractV2SchemaValidateResponseDataSchemaTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        ExtractV2SchemaValidateResponseDataSchema value = new(
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
        ExtractV2SchemaValidateResponseDataSchema value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        ExtractV2SchemaValidateResponseDataSchema value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ExtractV2SchemaValidateResponseDataSchema value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ExtractV2SchemaValidateResponseDataSchema value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        ExtractV2SchemaValidateResponseDataSchema value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaValidateResponseDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        ExtractV2SchemaValidateResponseDataSchema value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaValidateResponseDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExtractV2SchemaValidateResponseDataSchema value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaValidateResponseDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ExtractV2SchemaValidateResponseDataSchema value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaValidateResponseDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ExtractV2SchemaValidateResponseDataSchema value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2SchemaValidateResponseDataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
