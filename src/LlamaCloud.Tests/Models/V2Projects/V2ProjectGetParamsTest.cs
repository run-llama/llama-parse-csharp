using System;
using LlamaCloud.Models.V2Projects;

namespace LlamaCloud.Tests.Models.V2Projects;

public class V2ProjectGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V2ProjectGetParams
        {
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new V2ProjectGetParams
        {
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new V2ProjectGetParams
        {
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            OrganizationID = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
    }

    [Fact]
    public void Url_Works()
    {
        V2ProjectGetParams parameters = new()
        {
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v2/projects/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V2ProjectGetParams
        {
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        V2ProjectGetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
