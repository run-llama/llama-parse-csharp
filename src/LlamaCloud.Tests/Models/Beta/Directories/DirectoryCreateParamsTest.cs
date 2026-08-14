using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using Directories = LlamaCloud.Models.Beta.Directories;

namespace LlamaCloud.Tests.Models.Beta.Directories;

public class DirectoryCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Directories::DirectoryCreateParams
        {
            Name = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConnectorSubscriptionID = "csub-abc123",
            Description = "description",
            SystemMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Directories::Type.User,
        };

        string expectedName = "x";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedConnectorSubscriptionID = "csub-abc123";
        string expectedDescription = "description";
        Dictionary<string, JsonElement> expectedSystemMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, Directories::Type> expectedType = Directories::Type.User;

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedConnectorSubscriptionID, parameters.ConnectorSubscriptionID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.SystemMetadata);
        Assert.Equal(expectedSystemMetadata.Count, parameters.SystemMetadata.Count);
        foreach (var item in expectedSystemMetadata)
        {
            Assert.True(parameters.SystemMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.SystemMetadata[item.Key]));
        }
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Directories::DirectoryCreateParams
        {
            Name = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConnectorSubscriptionID = "csub-abc123",
            Description = "description",
            SystemMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Directories::DirectoryCreateParams
        {
            Name = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConnectorSubscriptionID = "csub-abc123",
            Description = "description",
            SystemMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Directories::DirectoryCreateParams
        {
            Name = "x",
            Type = Directories::Type.User,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.ConnectorSubscriptionID);
        Assert.False(parameters.RawBodyData.ContainsKey("connector_subscription_id"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.SystemMetadata);
        Assert.False(parameters.RawBodyData.ContainsKey("system_metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Directories::DirectoryCreateParams
        {
            Name = "x",
            Type = Directories::Type.User,

            OrganizationID = null,
            ProjectID = null,
            ConnectorSubscriptionID = null,
            Description = null,
            SystemMetadata = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.ConnectorSubscriptionID);
        Assert.True(parameters.RawBodyData.ContainsKey("connector_subscription_id"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.SystemMetadata);
        Assert.True(parameters.RawBodyData.ContainsKey("system_metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        Directories::DirectoryCreateParams parameters = new()
        {
            Name = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/directories?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Directories::DirectoryCreateParams
        {
            Name = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConnectorSubscriptionID = "csub-abc123",
            Description = "description",
            SystemMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Directories::Type.User,
        };

        Directories::DirectoryCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Directories::Type.Ephemeral)]
    [InlineData(Directories::Type.User)]
    public void Validation_Works(Directories::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Directories::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Directories::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Directories::Type.Ephemeral)]
    [InlineData(Directories::Type.User)]
    public void SerializationRoundtrip_Works(Directories::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Directories::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Directories::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Directories::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Directories::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
