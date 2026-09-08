using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines.Files;

namespace LlamaCloud.Tests.Models.Pipelines.Files;

public class FileListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileListParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileNameContains = "file_name_contains",
            Limit = 0,
            Offset = 0,
            OnlyManuallyUploaded = true,
            OrderBy = "order_by",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Statuses = [Status.Cancelled, Status.Error],
        };

        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFileNameContains = "file_name_contains";
        long expectedLimit = 0;
        long expectedOffset = 0;
        bool expectedOnlyManuallyUploaded = true;
        string expectedOrderBy = "order_by";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<ApiEnum<string, Status>> expectedStatuses = [Status.Cancelled, Status.Error];

        Assert.Equal(expectedPipelineID, parameters.PipelineID);
        Assert.Equal(expectedDataSourceID, parameters.DataSourceID);
        Assert.Equal(expectedFileNameContains, parameters.FileNameContains);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedOnlyManuallyUploaded, parameters.OnlyManuallyUploaded);
        Assert.Equal(expectedOrderBy, parameters.OrderBy);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.NotNull(parameters.Statuses);
        Assert.Equal(expectedStatuses.Count, parameters.Statuses.Count);
        for (int i = 0; i < expectedStatuses.Count; i++)
        {
            Assert.Equal(expectedStatuses[i], parameters.Statuses[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileListParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileNameContains = "file_name_contains",
            Limit = 0,
            Offset = 0,
            OrderBy = "order_by",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Statuses = [Status.Cancelled, Status.Error],
        };

        Assert.Null(parameters.OnlyManuallyUploaded);
        Assert.False(parameters.RawQueryData.ContainsKey("only_manually_uploaded"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FileListParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileNameContains = "file_name_contains",
            Limit = 0,
            Offset = 0,
            OrderBy = "order_by",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Statuses = [Status.Cancelled, Status.Error],

            // Null should be interpreted as omitted for these properties
            OnlyManuallyUploaded = null,
        };

        Assert.Null(parameters.OnlyManuallyUploaded);
        Assert.False(parameters.RawQueryData.ContainsKey("only_manually_uploaded"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileListParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyManuallyUploaded = true,
        };

        Assert.Null(parameters.DataSourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("data_source_id"));
        Assert.Null(parameters.FileNameContains);
        Assert.False(parameters.RawQueryData.ContainsKey("file_name_contains"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawQueryData.ContainsKey("order_by"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Statuses);
        Assert.False(parameters.RawQueryData.ContainsKey("statuses"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new FileListParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyManuallyUploaded = true,

            DataSourceID = null,
            FileNameContains = null,
            Limit = null,
            Offset = null,
            OrderBy = null,
            ProjectID = null,
            Statuses = null,
        };

        Assert.Null(parameters.DataSourceID);
        Assert.True(parameters.RawQueryData.ContainsKey("data_source_id"));
        Assert.Null(parameters.FileNameContains);
        Assert.True(parameters.RawQueryData.ContainsKey("file_name_contains"));
        Assert.Null(parameters.Limit);
        Assert.True(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.True(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.OrderBy);
        Assert.True(parameters.RawQueryData.ContainsKey("order_by"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Statuses);
        Assert.True(parameters.RawQueryData.ContainsKey("statuses"));
    }

    [Fact]
    public void Url_Works()
    {
        FileListParams parameters = new()
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileNameContains = "file_name_contains",
            Limit = 0,
            Offset = 0,
            OnlyManuallyUploaded = true,
            OrderBy = "order_by",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Statuses = [Status.Cancelled, Status.Error],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/pipelines/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/files2?data_source_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&file_name_contains=file_name_contains&limit=0&offset=0&only_manually_uploaded=true&order_by=order_by&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&statuses=CANCELLED&statuses=ERROR"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileListParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileNameContains = "file_name_contains",
            Limit = 0,
            Offset = 0,
            OnlyManuallyUploaded = true,
            OrderBy = "order_by",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Statuses = [Status.Cancelled, Status.Error],
        };

        FileListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Cancelled)]
    [InlineData(Status.Error)]
    [InlineData(Status.InProgress)]
    [InlineData(Status.NotStarted)]
    [InlineData(Status.Success)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Cancelled)]
    [InlineData(Status.Error)]
    [InlineData(Status.InProgress)]
    [InlineData(Status.NotStarted)]
    [InlineData(Status.Success)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
