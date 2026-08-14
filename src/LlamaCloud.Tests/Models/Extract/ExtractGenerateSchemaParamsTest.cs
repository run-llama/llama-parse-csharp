using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Extract;

namespace LlamaCloud.Tests.Models.Extract;

public class ExtractGenerateSchemaParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExtractGenerateSchemaParams
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSchema = new Dictionary<string, DataSchema?>()
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

        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Dictionary<string, DataSchema?> expectedDataSchema = new()
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

        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.NotNull(parameters.DataSchema);
        Assert.Equal(expectedDataSchema.Count, parameters.DataSchema.Count);
        foreach (var item in expectedDataSchema)
        {
            Assert.True(parameters.DataSchema.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.DataSchema[item.Key]);
        }
        Assert.Equal(expectedFileID, parameters.FileID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPrompt, parameters.Prompt);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExtractGenerateSchemaParams { };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.DataSchema);
        Assert.False(parameters.RawBodyData.ContainsKey("data_schema"));
        Assert.Null(parameters.FileID);
        Assert.False(parameters.RawBodyData.ContainsKey("file_id"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Prompt);
        Assert.False(parameters.RawBodyData.ContainsKey("prompt"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ExtractGenerateSchemaParams
        {
            OrganizationID = null,
            ProjectID = null,
            DataSchema = null,
            FileID = null,
            Name = null,
            Prompt = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.DataSchema);
        Assert.True(parameters.RawBodyData.ContainsKey("data_schema"));
        Assert.Null(parameters.FileID);
        Assert.True(parameters.RawBodyData.ContainsKey("file_id"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Prompt);
        Assert.True(parameters.RawBodyData.ContainsKey("prompt"));
    }

    [Fact]
    public void Url_Works()
    {
        ExtractGenerateSchemaParams parameters = new()
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v2/extract/schema/generate?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExtractGenerateSchemaParams
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSchema = new Dictionary<string, DataSchema?>()
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

        ExtractGenerateSchemaParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DataSchemaTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        DataSchema value = new(
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
        DataSchema value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        DataSchema value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        DataSchema value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        DataSchema value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        DataSchema value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        DataSchema value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        DataSchema value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        DataSchema value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        DataSchema value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSchema>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
