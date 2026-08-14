using System;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Batches;

namespace LlamaIndex.LlamaCloud.Tests.Models.Batches;

public class BatchListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BatchListParams
        {
            CreatedAtOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 0,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceDirectoryID = "source_directory_id",
            Status = Status.Cancelled,
        };

        DateTimeOffset expectedCreatedAtOnOrAfter = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedCreatedAtOnOrBefore = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedPageSize = 0;
        string expectedPageToken = "page_token";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedSourceDirectoryID = "source_directory_id";
        ApiEnum<string, Status> expectedStatus = Status.Cancelled;

        Assert.Equal(expectedCreatedAtOnOrAfter, parameters.CreatedAtOnOrAfter);
        Assert.Equal(expectedCreatedAtOnOrBefore, parameters.CreatedAtOnOrBefore);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedPageToken, parameters.PageToken);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedSourceDirectoryID, parameters.SourceDirectoryID);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BatchListParams { };

        Assert.Null(parameters.CreatedAtOnOrAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_on_or_after"));
        Assert.Null(parameters.CreatedAtOnOrBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("created_at_on_or_before"));
        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.False(parameters.RawQueryData.ContainsKey("page_token"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.SourceDirectoryID);
        Assert.False(parameters.RawQueryData.ContainsKey("source_directory_id"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BatchListParams
        {
            CreatedAtOnOrAfter = null,
            CreatedAtOnOrBefore = null,
            OrganizationID = null,
            PageSize = null,
            PageToken = null,
            ProjectID = null,
            SourceDirectoryID = null,
            Status = null,
        };

        Assert.Null(parameters.CreatedAtOnOrAfter);
        Assert.True(parameters.RawQueryData.ContainsKey("created_at_on_or_after"));
        Assert.Null(parameters.CreatedAtOnOrBefore);
        Assert.True(parameters.RawQueryData.ContainsKey("created_at_on_or_before"));
        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PageSize);
        Assert.True(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.True(parameters.RawQueryData.ContainsKey("page_token"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.SourceDirectoryID);
        Assert.True(parameters.RawQueryData.ContainsKey("source_directory_id"));
        Assert.Null(parameters.Status);
        Assert.True(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        BatchListParams parameters = new()
        {
            CreatedAtOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 0,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceDirectoryID = "source_directory_id",
            Status = Status.Cancelled,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v2/batches?created_at_on_or_after=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at_on_or_before=2019-12-27T18%3a11%3a19.117%2b00%3a00&organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&page_size=0&page_token=page_token&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&source_directory_id=source_directory_id&status=CANCELLED"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BatchListParams
        {
            CreatedAtOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 0,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceDirectoryID = "source_directory_id",
            Status = Status.Cancelled,
        };

        BatchListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Cancelled)]
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Running)]
    [InlineData(Status.Throttled)]
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
    [InlineData(Status.Completed)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Running)]
    [InlineData(Status.Throttled)]
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
