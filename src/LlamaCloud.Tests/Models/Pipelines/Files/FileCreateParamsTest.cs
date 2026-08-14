using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Pipelines.Files;

namespace LlamaCloud.Tests.Models.Pipelines.Files;

public class FileCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileCreateParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Body =
            [
                new()
                {
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomMetadata = new Dictionary<string, CustomMetadata?>()
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
                },
            ],
        };

        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<Body> expectedBody =
        [
            new()
            {
                FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CustomMetadata = new Dictionary<string, CustomMetadata?>()
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
            },
        ];

        Assert.Equal(expectedPipelineID, parameters.PipelineID);
        Assert.Equal(expectedBody.Count, parameters.Body.Count);
        for (int i = 0; i < expectedBody.Count; i++)
        {
            Assert.Equal(expectedBody[i], parameters.Body[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        FileCreateParams parameters = new()
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Body =
            [
                new()
                {
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomMetadata = new Dictionary<string, CustomMetadata?>()
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
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/pipelines/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/files"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileCreateParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Body =
            [
                new()
                {
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CustomMetadata = new Dictionary<string, CustomMetadata?>()
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
                },
            ],
        };

        FileCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BodyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Body
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomMetadata = new Dictionary<string, CustomMetadata?>()
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

        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Dictionary<string, CustomMetadata?> expectedCustomMetadata = new()
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

        Assert.Equal(expectedFileID, model.FileID);
        Assert.NotNull(model.CustomMetadata);
        Assert.Equal(expectedCustomMetadata.Count, model.CustomMetadata.Count);
        foreach (var item in expectedCustomMetadata)
        {
            Assert.True(model.CustomMetadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.CustomMetadata[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Body
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomMetadata = new Dictionary<string, CustomMetadata?>()
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
        var deserialized = JsonSerializer.Deserialize<Body>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Body
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomMetadata = new Dictionary<string, CustomMetadata?>()
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
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Dictionary<string, CustomMetadata?> expectedCustomMetadata = new()
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

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.NotNull(deserialized.CustomMetadata);
        Assert.Equal(expectedCustomMetadata.Count, deserialized.CustomMetadata.Count);
        foreach (var item in expectedCustomMetadata)
        {
            Assert.True(deserialized.CustomMetadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.CustomMetadata[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Body
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomMetadata = new Dictionary<string, CustomMetadata?>()
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
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Body { FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        Assert.Null(model.CustomMetadata);
        Assert.False(model.RawData.ContainsKey("custom_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Body { FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Body
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            CustomMetadata = null,
        };

        Assert.Null(model.CustomMetadata);
        Assert.True(model.RawData.ContainsKey("custom_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Body
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            CustomMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Body
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomMetadata = new Dictionary<string, CustomMetadata?>()
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

        Body copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomMetadataTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        CustomMetadata value = new(
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
        CustomMetadata value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        CustomMetadata value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        CustomMetadata value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        CustomMetadata value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        CustomMetadata value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        CustomMetadata value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CustomMetadata value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CustomMetadata value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        CustomMetadata value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
