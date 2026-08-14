using System;
using LlamaIndex.LlamaCloud.Models.Pipelines.Images;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines.Images;

public class ImageGetPageFigureParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ImageGetPageFigureParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            FigureName = "figure_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedPageIndex = 0;
        string expectedFigureName = "figure_name";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedPageIndex, parameters.PageIndex);
        Assert.Equal(expectedFigureName, parameters.FigureName);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ImageGetPageFigureParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            FigureName = "figure_name",
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ImageGetPageFigureParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            FigureName = "figure_name",

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
        ImageGetPageFigureParams parameters = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            FigureName = "figure_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/files/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/page-figures/0/figure_name?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ImageGetPageFigureParams
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            FigureName = "figure_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ImageGetPageFigureParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
