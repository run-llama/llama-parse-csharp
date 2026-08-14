using System;
using System.Collections.Generic;
using LlamaIndex.LlamaCloud.Models.Beta.Sheets;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Sheets;

public class SheetGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SheetGetParams
        {
            SpreadsheetJobID = "spreadsheet_job_id",
            Expand = ["string"],
            IncludeResults = true,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedSpreadsheetJobID = "spreadsheet_job_id";
        List<string> expectedExpand = ["string"];
        bool expectedIncludeResults = true;
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedSpreadsheetJobID, parameters.SpreadsheetJobID);
        Assert.NotNull(parameters.Expand);
        Assert.Equal(expectedExpand.Count, parameters.Expand.Count);
        for (int i = 0; i < expectedExpand.Count; i++)
        {
            Assert.Equal(expectedExpand[i], parameters.Expand[i]);
        }
        Assert.Equal(expectedIncludeResults, parameters.IncludeResults);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SheetGetParams
        {
            SpreadsheetJobID = "spreadsheet_job_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.Expand);
        Assert.False(parameters.RawQueryData.ContainsKey("expand"));
        Assert.Null(parameters.IncludeResults);
        Assert.False(parameters.RawQueryData.ContainsKey("include_results"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SheetGetParams
        {
            SpreadsheetJobID = "spreadsheet_job_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            Expand = null,
            IncludeResults = null,
        };

        Assert.Null(parameters.Expand);
        Assert.False(parameters.RawQueryData.ContainsKey("expand"));
        Assert.Null(parameters.IncludeResults);
        Assert.False(parameters.RawQueryData.ContainsKey("include_results"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SheetGetParams
        {
            SpreadsheetJobID = "spreadsheet_job_id",
            Expand = ["string"],
            IncludeResults = true,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SheetGetParams
        {
            SpreadsheetJobID = "spreadsheet_job_id",
            Expand = ["string"],
            IncludeResults = true,

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
        SheetGetParams parameters = new()
        {
            SpreadsheetJobID = "spreadsheet_job_id",
            Expand = ["string"],
            IncludeResults = true,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/sheets/jobs/spreadsheet_job_id?expand=string&include_results=true&organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SheetGetParams
        {
            SpreadsheetJobID = "spreadsheet_job_id",
            Expand = ["string"],
            IncludeResults = true,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        SheetGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
