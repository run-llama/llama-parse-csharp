using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Beta.Indexes;

namespace LlamaCloud.Tests.Models.Beta.Indexes;

public class IndexGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IndexGetParams
        {
            IndexID = "index_id",
            Expand = [Expand.SyncInProgress],
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedIndexID = "index_id";
        List<ApiEnum<string, Expand>> expectedExpand = [Expand.SyncInProgress];
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedIndexID, parameters.IndexID);
        Assert.NotNull(parameters.Expand);
        Assert.Equal(expectedExpand.Count, parameters.Expand.Count);
        for (int i = 0; i < expectedExpand.Count; i++)
        {
            Assert.Equal(expectedExpand[i], parameters.Expand[i]);
        }
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IndexGetParams
        {
            IndexID = "index_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.Expand);
        Assert.False(parameters.RawQueryData.ContainsKey("expand"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IndexGetParams
        {
            IndexID = "index_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            Expand = null,
        };

        Assert.Null(parameters.Expand);
        Assert.False(parameters.RawQueryData.ContainsKey("expand"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IndexGetParams
        {
            IndexID = "index_id",
            Expand = [Expand.SyncInProgress],
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new IndexGetParams
        {
            IndexID = "index_id",
            Expand = [Expand.SyncInProgress],

            OrganizationID = null,
            ProjectID = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void Url_Works()
    {
        IndexGetParams parameters = new()
        {
            IndexID = "index_id",
            Expand = [Expand.SyncInProgress],
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/indexes/index_id?expand=sync_in_progress&organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IndexGetParams
        {
            IndexID = "index_id",
            Expand = [Expand.SyncInProgress],
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        IndexGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ExpandTest : TestBase
{
    [Theory]
    [InlineData(Expand.SyncInProgress)]
    public void Validation_Works(Expand rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Expand> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Expand>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Expand.SyncInProgress)]
    public void SerializationRoundtrip_Works(Expand rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Expand> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Expand>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Expand>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Expand>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
