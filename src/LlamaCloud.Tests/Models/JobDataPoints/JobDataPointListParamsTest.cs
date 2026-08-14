using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.JobDataPoints;

namespace LlamaCloud.Tests.Models.JobDataPoints;

public class JobDataPointListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new JobDataPointListParams
        {
            JobType = JobType.Parse,
            CreatedAtOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Hours = 24,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 100,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = ["completed", "failed"],
        };

        ApiEnum<string, JobType> expectedJobType = JobType.Parse;
        DateTimeOffset expectedCreatedAtOnOrAfter = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedCreatedAtOnOrBefore = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        long expectedHours = 24;
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedPageSize = 100;
        string expectedPageToken = "page_token";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<string> expectedStatus = ["completed", "failed"];

        Assert.Equal(expectedJobType, parameters.JobType);
        Assert.Equal(expectedCreatedAtOnOrAfter, parameters.CreatedAtOnOrAfter);
        Assert.Equal(expectedCreatedAtOnOrBefore, parameters.CreatedAtOnOrBefore);
        Assert.Equal(expectedHours, parameters.Hours);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedPageToken, parameters.PageToken);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.NotNull(parameters.Status);
        Assert.Equal(expectedStatus.Count, parameters.Status.Count);
        for (int i = 0; i < expectedStatus.Count; i++)
        {
            Assert.Equal(expectedStatus[i], parameters.Status[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new JobDataPointListParams
        {
            JobType = JobType.Parse,
            CreatedAtOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 100,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = ["completed", "failed"],
        };

        Assert.Null(parameters.Hours);
        Assert.False(parameters.RawQueryData.ContainsKey("hours"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new JobDataPointListParams
        {
            JobType = JobType.Parse,
            CreatedAtOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 100,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = ["completed", "failed"],

            // Null should be interpreted as omitted for these properties
            Hours = null,
        };

        Assert.Null(parameters.Hours);
        Assert.False(parameters.RawQueryData.ContainsKey("hours"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new JobDataPointListParams { JobType = JobType.Parse, Hours = 24 };

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
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new JobDataPointListParams
        {
            JobType = JobType.Parse,
            Hours = 24,

            CreatedAtOnOrAfter = null,
            CreatedAtOnOrBefore = null,
            OrganizationID = null,
            PageSize = null,
            PageToken = null,
            ProjectID = null,
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
        Assert.Null(parameters.Status);
        Assert.True(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        JobDataPointListParams parameters = new()
        {
            JobType = JobType.Parse,
            CreatedAtOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            CreatedAtOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            Hours = 24,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 100,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = ["completed", "failed"],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/job-data-points?job_type=parse&created_at_on_or_after=2019-12-27T18%3a11%3a19.117%2b00%3a00&created_at_on_or_before=2019-12-27T18%3a11%3a19.117%2b00%3a00&hours=24&organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&page_size=100&page_token=page_token&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&status=completed&status=failed"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new JobDataPointListParams
        {
            JobType = JobType.Parse,
            CreatedAtOnOrAfter = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAtOnOrBefore = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Hours = 24,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 100,
            PageToken = "page_token",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Status = ["completed", "failed"],
        };

        JobDataPointListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class JobTypeTest : TestBase
{
    [Theory]
    [InlineData(JobType.Classify)]
    [InlineData(JobType.Extract)]
    [InlineData(JobType.Parse)]
    public void Validation_Works(JobType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JobType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JobType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JobType.Classify)]
    [InlineData(JobType.Extract)]
    [InlineData(JobType.Parse)]
    public void SerializationRoundtrip_Works(JobType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JobType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JobType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JobType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JobType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
