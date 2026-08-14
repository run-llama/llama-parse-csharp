using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Beta.Directories;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Directories;

public class DirectoryListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DirectoryListParams
        {
            IncludeDeleted = true,
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 0,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Type = DirectoryListParamsType.Ephemeral,
            Types = [TypeModel.Ephemeral, TypeModel.Index],
        };

        bool expectedIncludeDeleted = true;
        string expectedName = "name";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedPageSize = 0;
        string expectedPageToken = "page_token";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, DirectoryListParamsType> expectedType = DirectoryListParamsType.Ephemeral;
        List<ApiEnum<string, TypeModel>> expectedTypes = [TypeModel.Ephemeral, TypeModel.Index];

        Assert.Equal(expectedIncludeDeleted, parameters.IncludeDeleted);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedPageToken, parameters.PageToken);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedType, parameters.Type);
        Assert.NotNull(parameters.Types);
        Assert.Equal(expectedTypes.Count, parameters.Types.Count);
        for (int i = 0; i < expectedTypes.Count; i++)
        {
            Assert.Equal(expectedTypes[i], parameters.Types[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DirectoryListParams
        {
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 0,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Type = DirectoryListParamsType.Ephemeral,
            Types = [TypeModel.Ephemeral, TypeModel.Index],
        };

        Assert.Null(parameters.IncludeDeleted);
        Assert.False(parameters.RawQueryData.ContainsKey("include_deleted"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DirectoryListParams
        {
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 0,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Type = DirectoryListParamsType.Ephemeral,
            Types = [TypeModel.Ephemeral, TypeModel.Index],

            // Null should be interpreted as omitted for these properties
            IncludeDeleted = null,
        };

        Assert.Null(parameters.IncludeDeleted);
        Assert.False(parameters.RawQueryData.ContainsKey("include_deleted"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DirectoryListParams { IncludeDeleted = true };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawQueryData.ContainsKey("name"));
        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.False(parameters.RawQueryData.ContainsKey("page_token"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawQueryData.ContainsKey("type"));
        Assert.Null(parameters.Types);
        Assert.False(parameters.RawQueryData.ContainsKey("types"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new DirectoryListParams
        {
            IncludeDeleted = true,

            Name = null,
            OrganizationID = null,
            PageSize = null,
            PageToken = null,
            ProjectID = null,
            Type = null,
            Types = null,
        };

        Assert.Null(parameters.Name);
        Assert.True(parameters.RawQueryData.ContainsKey("name"));
        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PageSize);
        Assert.True(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.True(parameters.RawQueryData.ContainsKey("page_token"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Type);
        Assert.True(parameters.RawQueryData.ContainsKey("type"));
        Assert.Null(parameters.Types);
        Assert.True(parameters.RawQueryData.ContainsKey("types"));
    }

    [Fact]
    public void Url_Works()
    {
        DirectoryListParams parameters = new()
        {
            IncludeDeleted = true,
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 0,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Type = DirectoryListParamsType.Ephemeral,
            Types = [TypeModel.Ephemeral, TypeModel.Index],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/directories?include_deleted=true&name=name&organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&page_size=0&page_token=page_token&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&type=ephemeral&types=ephemeral&types=index"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DirectoryListParams
        {
            IncludeDeleted = true,
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 0,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Type = DirectoryListParamsType.Ephemeral,
            Types = [TypeModel.Ephemeral, TypeModel.Index],
        };

        DirectoryListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DirectoryListParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(DirectoryListParamsType.Ephemeral)]
    [InlineData(DirectoryListParamsType.Index)]
    [InlineData(DirectoryListParamsType.User)]
    public void Validation_Works(DirectoryListParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DirectoryListParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DirectoryListParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DirectoryListParamsType.Ephemeral)]
    [InlineData(DirectoryListParamsType.Index)]
    [InlineData(DirectoryListParamsType.User)]
    public void SerializationRoundtrip_Works(DirectoryListParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DirectoryListParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DirectoryListParamsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DirectoryListParamsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DirectoryListParamsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeModelTest : TestBase
{
    [Theory]
    [InlineData(TypeModel.Ephemeral)]
    [InlineData(TypeModel.Index)]
    [InlineData(TypeModel.User)]
    public void Validation_Works(TypeModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TypeModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TypeModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TypeModel.Ephemeral)]
    [InlineData(TypeModel.Index)]
    [InlineData(TypeModel.User)]
    public void SerializationRoundtrip_Works(TypeModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TypeModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TypeModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TypeModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TypeModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
