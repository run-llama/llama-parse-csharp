using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Beta.Directories;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Directories;

public class DirectoryGetResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DirectoryGetResponse
        {
            ID = "id",
            Name = "x",
            ProjectID = "project_id",
            ConnectorSubscriptionID = "csub-abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SystemMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = DirectoryGetResponseType.Ephemeral,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedName = "x";
        string expectedProjectID = "project_id";
        string expectedConnectorSubscriptionID = "csub-abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedDeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, JsonElement> expectedSystemMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, DirectoryGetResponseType> expectedType = DirectoryGetResponseType.Ephemeral;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedConnectorSubscriptionID, model.ConnectorSubscriptionID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDeletedAt, model.DeletedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.NotNull(model.SystemMetadata);
        Assert.Equal(expectedSystemMetadata.Count, model.SystemMetadata.Count);
        foreach (var item in expectedSystemMetadata)
        {
            Assert.True(model.SystemMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.SystemMetadata[item.Key]));
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DirectoryGetResponse
        {
            ID = "id",
            Name = "x",
            ProjectID = "project_id",
            ConnectorSubscriptionID = "csub-abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SystemMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = DirectoryGetResponseType.Ephemeral,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DirectoryGetResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DirectoryGetResponse
        {
            ID = "id",
            Name = "x",
            ProjectID = "project_id",
            ConnectorSubscriptionID = "csub-abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SystemMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = DirectoryGetResponseType.Ephemeral,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DirectoryGetResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "x";
        string expectedProjectID = "project_id";
        string expectedConnectorSubscriptionID = "csub-abc123";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedDeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, JsonElement> expectedSystemMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, DirectoryGetResponseType> expectedType = DirectoryGetResponseType.Ephemeral;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedConnectorSubscriptionID, deserialized.ConnectorSubscriptionID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDeletedAt, deserialized.DeletedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.NotNull(deserialized.SystemMetadata);
        Assert.Equal(expectedSystemMetadata.Count, deserialized.SystemMetadata.Count);
        foreach (var item in expectedSystemMetadata)
        {
            Assert.True(deserialized.SystemMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.SystemMetadata[item.Key]));
        }
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DirectoryGetResponse
        {
            ID = "id",
            Name = "x",
            ProjectID = "project_id",
            ConnectorSubscriptionID = "csub-abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SystemMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = DirectoryGetResponseType.Ephemeral,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DirectoryGetResponse
        {
            ID = "id",
            Name = "x",
            ProjectID = "project_id",
        };

        Assert.Null(model.ConnectorSubscriptionID);
        Assert.False(model.RawData.ContainsKey("connector_subscription_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DeletedAt);
        Assert.False(model.RawData.ContainsKey("deleted_at"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.SystemMetadata);
        Assert.False(model.RawData.ContainsKey("system_metadata"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DirectoryGetResponse
        {
            ID = "id",
            Name = "x",
            ProjectID = "project_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DirectoryGetResponse
        {
            ID = "id",
            Name = "x",
            ProjectID = "project_id",

            ConnectorSubscriptionID = null,
            CreatedAt = null,
            DeletedAt = null,
            Description = null,
            ExpiresAt = null,
            SystemMetadata = null,
            Type = null,
            UpdatedAt = null,
        };

        Assert.Null(model.ConnectorSubscriptionID);
        Assert.True(model.RawData.ContainsKey("connector_subscription_id"));
        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DeletedAt);
        Assert.True(model.RawData.ContainsKey("deleted_at"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.ExpiresAt);
        Assert.True(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.SystemMetadata);
        Assert.True(model.RawData.ContainsKey("system_metadata"));
        Assert.Null(model.Type);
        Assert.True(model.RawData.ContainsKey("type"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DirectoryGetResponse
        {
            ID = "id",
            Name = "x",
            ProjectID = "project_id",

            ConnectorSubscriptionID = null,
            CreatedAt = null,
            DeletedAt = null,
            Description = null,
            ExpiresAt = null,
            SystemMetadata = null,
            Type = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DirectoryGetResponse
        {
            ID = "id",
            Name = "x",
            ProjectID = "project_id",
            ConnectorSubscriptionID = "csub-abc123",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SystemMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = DirectoryGetResponseType.Ephemeral,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DirectoryGetResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DirectoryGetResponseTypeTest : TestBase
{
    [Theory]
    [InlineData(DirectoryGetResponseType.Ephemeral)]
    [InlineData(DirectoryGetResponseType.Index)]
    [InlineData(DirectoryGetResponseType.User)]
    public void Validation_Works(DirectoryGetResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DirectoryGetResponseType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DirectoryGetResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DirectoryGetResponseType.Ephemeral)]
    [InlineData(DirectoryGetResponseType.Index)]
    [InlineData(DirectoryGetResponseType.User)]
    public void SerializationRoundtrip_Works(DirectoryGetResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DirectoryGetResponseType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DirectoryGetResponseType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DirectoryGetResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DirectoryGetResponseType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
