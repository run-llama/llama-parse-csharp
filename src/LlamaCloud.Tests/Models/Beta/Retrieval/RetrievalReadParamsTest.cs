using System;
using LlamaCloud.Models.Beta.Retrieval;

namespace LlamaCloud.Tests.Models.Beta.Retrieval;

public class RetrievalReadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RetrievalReadParams
        {
            FileID = "file_id",
            IndexID = "idx-abc123",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MaxLength = 0,
            Offset = 0,
        };

        string expectedFileID = "file_id";
        string expectedIndexID = "idx-abc123";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedMaxLength = 0;
        long expectedOffset = 0;

        Assert.Equal(expectedFileID, parameters.FileID);
        Assert.Equal(expectedIndexID, parameters.IndexID);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedMaxLength, parameters.MaxLength);
        Assert.Equal(expectedOffset, parameters.Offset);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RetrievalReadParams
        {
            FileID = "file_id",
            IndexID = "idx-abc123",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MaxLength = 0,
        };

        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawBodyData.ContainsKey("offset"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RetrievalReadParams
        {
            FileID = "file_id",
            IndexID = "idx-abc123",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MaxLength = 0,

            // Null should be interpreted as omitted for these properties
            Offset = null,
        };

        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawBodyData.ContainsKey("offset"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RetrievalReadParams
        {
            FileID = "file_id",
            IndexID = "idx-abc123",
            Offset = 0,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.MaxLength);
        Assert.False(parameters.RawBodyData.ContainsKey("max_length"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RetrievalReadParams
        {
            FileID = "file_id",
            IndexID = "idx-abc123",
            Offset = 0,

            OrganizationID = null,
            ProjectID = null,
            MaxLength = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.MaxLength);
        Assert.True(parameters.RawBodyData.ContainsKey("max_length"));
    }

    [Fact]
    public void Url_Works()
    {
        RetrievalReadParams parameters = new()
        {
            FileID = "file_id",
            IndexID = "idx-abc123",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/retrieval/files/read?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RetrievalReadParams
        {
            FileID = "file_id",
            IndexID = "idx-abc123",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MaxLength = 0,
            Offset = 0,
        };

        RetrievalReadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
