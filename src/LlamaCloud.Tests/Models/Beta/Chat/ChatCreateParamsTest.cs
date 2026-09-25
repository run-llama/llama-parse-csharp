using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Beta.Chat;

namespace LlamaCloud.Tests.Models.Beta.Chat;

public class ChatCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChatCreateParams
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            IndexIds = ["idx-abc123", "idx-def456"],
            SharedAccess = SharedAccess.ReadOnly,
        };

        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<string> expectedIndexIds = ["idx-abc123", "idx-def456"];
        ApiEnum<string, SharedAccess> expectedSharedAccess = SharedAccess.ReadOnly;

        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.NotNull(parameters.IndexIds);
        Assert.Equal(expectedIndexIds.Count, parameters.IndexIds.Count);
        for (int i = 0; i < expectedIndexIds.Count; i++)
        {
            Assert.Equal(expectedIndexIds[i], parameters.IndexIds[i]);
        }
        Assert.Equal(expectedSharedAccess, parameters.SharedAccess);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChatCreateParams { };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.IndexIds);
        Assert.False(parameters.RawBodyData.ContainsKey("index_ids"));
        Assert.Null(parameters.SharedAccess);
        Assert.False(parameters.RawBodyData.ContainsKey("shared_access"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ChatCreateParams
        {
            OrganizationID = null,
            ProjectID = null,
            IndexIds = null,
            SharedAccess = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.IndexIds);
        Assert.True(parameters.RawBodyData.ContainsKey("index_ids"));
        Assert.Null(parameters.SharedAccess);
        Assert.True(parameters.RawBodyData.ContainsKey("shared_access"));
    }

    [Fact]
    public void Url_Works()
    {
        ChatCreateParams parameters = new()
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/chat?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChatCreateParams
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            IndexIds = ["idx-abc123", "idx-def456"],
            SharedAccess = SharedAccess.ReadOnly,
        };

        ChatCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SharedAccessTest : TestBase
{
    [Theory]
    [InlineData(SharedAccess.Query)]
    [InlineData(SharedAccess.ReadOnly)]
    public void Validation_Works(SharedAccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SharedAccess> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SharedAccess>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SharedAccess.Query)]
    [InlineData(SharedAccess.ReadOnly)]
    public void SerializationRoundtrip_Works(SharedAccess rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SharedAccess> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SharedAccess>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SharedAccess>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SharedAccess>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
