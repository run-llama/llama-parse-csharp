using System;
using System.Collections.Generic;
using LlamaCloud.Models.Extract.Review;

namespace LlamaCloud.Tests.Models.Extract.Review;

public class ReviewCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ReviewCreateParams
        {
            JobID = "job_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConfidenceThreshold = 0.8,
            FieldsInScope = ["/total", "/vendor/name"],
            RequiredFields = ["/vendor/name"],
        };

        string expectedJobID = "job_id";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        double expectedConfidenceThreshold = 0.8;
        List<string> expectedFieldsInScope = ["/total", "/vendor/name"];
        List<string> expectedRequiredFields = ["/vendor/name"];

        Assert.Equal(expectedJobID, parameters.JobID);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedConfidenceThreshold, parameters.ConfidenceThreshold);
        Assert.NotNull(parameters.FieldsInScope);
        Assert.Equal(expectedFieldsInScope.Count, parameters.FieldsInScope.Count);
        for (int i = 0; i < expectedFieldsInScope.Count; i++)
        {
            Assert.Equal(expectedFieldsInScope[i], parameters.FieldsInScope[i]);
        }
        Assert.NotNull(parameters.RequiredFields);
        Assert.Equal(expectedRequiredFields.Count, parameters.RequiredFields.Count);
        for (int i = 0; i < expectedRequiredFields.Count; i++)
        {
            Assert.Equal(expectedRequiredFields[i], parameters.RequiredFields[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ReviewCreateParams
        {
            JobID = "job_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RequiredFields = ["/vendor/name"],
        };

        Assert.Null(parameters.ConfidenceThreshold);
        Assert.False(parameters.RawBodyData.ContainsKey("confidence_threshold"));
        Assert.Null(parameters.FieldsInScope);
        Assert.False(parameters.RawBodyData.ContainsKey("fields_in_scope"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ReviewCreateParams
        {
            JobID = "job_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            RequiredFields = ["/vendor/name"],

            // Null should be interpreted as omitted for these properties
            ConfidenceThreshold = null,
            FieldsInScope = null,
        };

        Assert.Null(parameters.ConfidenceThreshold);
        Assert.False(parameters.RawBodyData.ContainsKey("confidence_threshold"));
        Assert.Null(parameters.FieldsInScope);
        Assert.False(parameters.RawBodyData.ContainsKey("fields_in_scope"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ReviewCreateParams
        {
            JobID = "job_id",
            ConfidenceThreshold = 0.8,
            FieldsInScope = ["/total", "/vendor/name"],
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.RequiredFields);
        Assert.False(parameters.RawBodyData.ContainsKey("required_fields"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ReviewCreateParams
        {
            JobID = "job_id",
            ConfidenceThreshold = 0.8,
            FieldsInScope = ["/total", "/vendor/name"],

            OrganizationID = null,
            ProjectID = null,
            RequiredFields = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.RequiredFields);
        Assert.True(parameters.RawBodyData.ContainsKey("required_fields"));
    }

    [Fact]
    public void Url_Works()
    {
        ReviewCreateParams parameters = new()
        {
            JobID = "job_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v2/extract/job_id/review?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ReviewCreateParams
        {
            JobID = "job_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConfidenceThreshold = 0.8,
            FieldsInScope = ["/total", "/vendor/name"],
            RequiredFields = ["/vendor/name"],
        };

        ReviewCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
