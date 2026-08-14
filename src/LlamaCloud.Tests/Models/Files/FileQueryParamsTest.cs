using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Files;

namespace LlamaCloud.Tests.Models.Files;

public class FileQueryParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileQueryParams
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Filter = new()
            {
                DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ExternalFileID = "external_file_id",
                FileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
                FileName = "file_name",
                OnlyManuallyUploaded = true,
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
            OrderBy = "order_by",
            PageSize = 0,
            PageToken = "page_token",
        };

        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Filter expectedFilter = new()
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExternalFileID = "external_file_id",
            FileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            FileName = "file_name",
            OnlyManuallyUploaded = true,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };
        string expectedOrderBy = "order_by";
        long expectedPageSize = 0;
        string expectedPageToken = "page_token";

        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedFilter, parameters.Filter);
        Assert.Equal(expectedOrderBy, parameters.OrderBy);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedPageToken, parameters.PageToken);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileQueryParams { };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawBodyData.ContainsKey("filter"));
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawBodyData.ContainsKey("order_by"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawBodyData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.False(parameters.RawBodyData.ContainsKey("page_token"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new FileQueryParams
        {
            OrganizationID = null,
            ProjectID = null,
            Filter = null,
            OrderBy = null,
            PageSize = null,
            PageToken = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Filter);
        Assert.True(parameters.RawBodyData.ContainsKey("filter"));
        Assert.Null(parameters.OrderBy);
        Assert.True(parameters.RawBodyData.ContainsKey("order_by"));
        Assert.Null(parameters.PageSize);
        Assert.True(parameters.RawBodyData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.True(parameters.RawBodyData.ContainsKey("page_token"));
    }

    [Fact]
    public void Url_Works()
    {
        FileQueryParams parameters = new()
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/files/query?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileQueryParams
        {
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Filter = new()
            {
                DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ExternalFileID = "external_file_id",
                FileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
                FileName = "file_name",
                OnlyManuallyUploaded = true,
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
            OrderBy = "order_by",
            PageSize = 0,
            PageToken = "page_token",
        };

        FileQueryParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Filter
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExternalFileID = "external_file_id",
            FileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            FileName = "file_name",
            OnlyManuallyUploaded = true,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedExternalFileID = "external_file_id";
        List<string> expectedFileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"];
        string expectedFileName = "file_name";
        bool expectedOnlyManuallyUploaded = true;
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedDataSourceID, model.DataSourceID);
        Assert.Equal(expectedExternalFileID, model.ExternalFileID);
        Assert.NotNull(model.FileIds);
        Assert.Equal(expectedFileIds.Count, model.FileIds.Count);
        for (int i = 0; i < expectedFileIds.Count; i++)
        {
            Assert.Equal(expectedFileIds[i], model.FileIds[i]);
        }
        Assert.Equal(expectedFileName, model.FileName);
        Assert.Equal(expectedOnlyManuallyUploaded, model.OnlyManuallyUploaded);
        Assert.Equal(expectedProjectID, model.ProjectID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Filter
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExternalFileID = "external_file_id",
            FileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            FileName = "file_name",
            OnlyManuallyUploaded = true,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Filter>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Filter
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExternalFileID = "external_file_id",
            FileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            FileName = "file_name",
            OnlyManuallyUploaded = true,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Filter>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedExternalFileID = "external_file_id";
        List<string> expectedFileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"];
        string expectedFileName = "file_name";
        bool expectedOnlyManuallyUploaded = true;
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedDataSourceID, deserialized.DataSourceID);
        Assert.Equal(expectedExternalFileID, deserialized.ExternalFileID);
        Assert.NotNull(deserialized.FileIds);
        Assert.Equal(expectedFileIds.Count, deserialized.FileIds.Count);
        for (int i = 0; i < expectedFileIds.Count; i++)
        {
            Assert.Equal(expectedFileIds[i], deserialized.FileIds[i]);
        }
        Assert.Equal(expectedFileName, deserialized.FileName);
        Assert.Equal(expectedOnlyManuallyUploaded, deserialized.OnlyManuallyUploaded);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Filter
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExternalFileID = "external_file_id",
            FileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            FileName = "file_name",
            OnlyManuallyUploaded = true,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Filter { };

        Assert.Null(model.DataSourceID);
        Assert.False(model.RawData.ContainsKey("data_source_id"));
        Assert.Null(model.ExternalFileID);
        Assert.False(model.RawData.ContainsKey("external_file_id"));
        Assert.Null(model.FileIds);
        Assert.False(model.RawData.ContainsKey("file_ids"));
        Assert.Null(model.FileName);
        Assert.False(model.RawData.ContainsKey("file_name"));
        Assert.Null(model.OnlyManuallyUploaded);
        Assert.False(model.RawData.ContainsKey("only_manually_uploaded"));
        Assert.Null(model.ProjectID);
        Assert.False(model.RawData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Filter { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Filter
        {
            DataSourceID = null,
            ExternalFileID = null,
            FileIds = null,
            FileName = null,
            OnlyManuallyUploaded = null,
            ProjectID = null,
        };

        Assert.Null(model.DataSourceID);
        Assert.True(model.RawData.ContainsKey("data_source_id"));
        Assert.Null(model.ExternalFileID);
        Assert.True(model.RawData.ContainsKey("external_file_id"));
        Assert.Null(model.FileIds);
        Assert.True(model.RawData.ContainsKey("file_ids"));
        Assert.Null(model.FileName);
        Assert.True(model.RawData.ContainsKey("file_name"));
        Assert.Null(model.OnlyManuallyUploaded);
        Assert.True(model.RawData.ContainsKey("only_manually_uploaded"));
        Assert.Null(model.ProjectID);
        Assert.True(model.RawData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Filter
        {
            DataSourceID = null,
            ExternalFileID = null,
            FileIds = null,
            FileName = null,
            OnlyManuallyUploaded = null,
            ProjectID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Filter
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExternalFileID = "external_file_id",
            FileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            FileName = "file_name",
            OnlyManuallyUploaded = true,
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Filter copied = new(model);

        Assert.Equal(model, copied);
    }
}
