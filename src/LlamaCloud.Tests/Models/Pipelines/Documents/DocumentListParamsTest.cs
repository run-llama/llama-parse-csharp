using System;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines.Documents;

namespace LlamaCloud.Tests.Models.Pipelines.Documents;

public class DocumentListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DocumentListParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 0,
            OnlyApiDataSourceDocuments = true,
            OnlyDirectUpload = true,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Skip = 0,
            StatusRefreshPolicy = StatusRefreshPolicy.Cached,
        };

        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedLimit = 0;
        bool expectedOnlyApiDataSourceDocuments = true;
        bool expectedOnlyDirectUpload = true;
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedSkip = 0;
        ApiEnum<string, StatusRefreshPolicy> expectedStatusRefreshPolicy =
            StatusRefreshPolicy.Cached;

        Assert.Equal(expectedPipelineID, parameters.PipelineID);
        Assert.Equal(expectedFileID, parameters.FileID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOnlyApiDataSourceDocuments, parameters.OnlyApiDataSourceDocuments);
        Assert.Equal(expectedOnlyDirectUpload, parameters.OnlyDirectUpload);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedSkip, parameters.Skip);
        Assert.Equal(expectedStatusRefreshPolicy, parameters.StatusRefreshPolicy);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DocumentListParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyApiDataSourceDocuments = true,
            OnlyDirectUpload = true,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
        Assert.Null(parameters.StatusRefreshPolicy);
        Assert.False(parameters.RawQueryData.ContainsKey("status_refresh_policy"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DocumentListParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyApiDataSourceDocuments = true,
            OnlyDirectUpload = true,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Skip = null,
            StatusRefreshPolicy = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
        Assert.Null(parameters.StatusRefreshPolicy);
        Assert.False(parameters.RawQueryData.ContainsKey("status_refresh_policy"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DocumentListParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 0,
            Skip = 0,
            StatusRefreshPolicy = StatusRefreshPolicy.Cached,
        };

        Assert.Null(parameters.FileID);
        Assert.False(parameters.RawQueryData.ContainsKey("file_id"));
        Assert.Null(parameters.OnlyApiDataSourceDocuments);
        Assert.False(parameters.RawQueryData.ContainsKey("only_api_data_source_documents"));
        Assert.Null(parameters.OnlyDirectUpload);
        Assert.False(parameters.RawQueryData.ContainsKey("only_direct_upload"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new DocumentListParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 0,
            Skip = 0,
            StatusRefreshPolicy = StatusRefreshPolicy.Cached,

            FileID = null,
            OnlyApiDataSourceDocuments = null,
            OnlyDirectUpload = null,
            ProjectID = null,
        };

        Assert.Null(parameters.FileID);
        Assert.True(parameters.RawQueryData.ContainsKey("file_id"));
        Assert.Null(parameters.OnlyApiDataSourceDocuments);
        Assert.True(parameters.RawQueryData.ContainsKey("only_api_data_source_documents"));
        Assert.Null(parameters.OnlyDirectUpload);
        Assert.True(parameters.RawQueryData.ContainsKey("only_direct_upload"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void Url_Works()
    {
        DocumentListParams parameters = new()
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 0,
            OnlyApiDataSourceDocuments = true,
            OnlyDirectUpload = true,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Skip = 0,
            StatusRefreshPolicy = StatusRefreshPolicy.Cached,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/pipelines/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/documents/paginated?file_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&limit=0&only_api_data_source_documents=true&only_direct_upload=true&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&skip=0&status_refresh_policy=cached"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DocumentListParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 0,
            OnlyApiDataSourceDocuments = true,
            OnlyDirectUpload = true,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Skip = 0,
            StatusRefreshPolicy = StatusRefreshPolicy.Cached,
        };

        DocumentListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusRefreshPolicyTest : TestBase
{
    [Theory]
    [InlineData(StatusRefreshPolicy.Cached)]
    [InlineData(StatusRefreshPolicy.Ttl)]
    public void Validation_Works(StatusRefreshPolicy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StatusRefreshPolicy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StatusRefreshPolicy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(StatusRefreshPolicy.Cached)]
    [InlineData(StatusRefreshPolicy.Ttl)]
    public void SerializationRoundtrip_Works(StatusRefreshPolicy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, StatusRefreshPolicy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StatusRefreshPolicy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, StatusRefreshPolicy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, StatusRefreshPolicy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
