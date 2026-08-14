using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.Directories.Files;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Directories.Files;

public class FileAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileAddParams
        {
            DirectoryID = "directory_id",
            FileID = "file_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DisplayName = "display_name",
            Metadata = new Dictionary<string, FileAddParamsMetadata?>() { { "foo", "string" } },
            UniqueID = "unique_id",
        };

        string expectedDirectoryID = "directory_id";
        string expectedFileID = "file_id";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDisplayName = "display_name";
        Dictionary<string, FileAddParamsMetadata?> expectedMetadata = new() { { "foo", "string" } };
        string expectedUniqueID = "unique_id";

        Assert.Equal(expectedDirectoryID, parameters.DirectoryID);
        Assert.Equal(expectedFileID, parameters.FileID);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedUniqueID, parameters.UniqueID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileAddParams { DirectoryID = "directory_id", FileID = "file_id" };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.UniqueID);
        Assert.False(parameters.RawBodyData.ContainsKey("unique_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new FileAddParams
        {
            DirectoryID = "directory_id",
            FileID = "file_id",

            OrganizationID = null,
            ProjectID = null,
            DisplayName = null,
            Metadata = null,
            UniqueID = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.DisplayName);
        Assert.True(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.UniqueID);
        Assert.True(parameters.RawBodyData.ContainsKey("unique_id"));
    }

    [Fact]
    public void Url_Works()
    {
        FileAddParams parameters = new()
        {
            DirectoryID = "directory_id",
            FileID = "file_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/directories/directory_id/files?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileAddParams
        {
            DirectoryID = "directory_id",
            FileID = "file_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DisplayName = "display_name",
            Metadata = new Dictionary<string, FileAddParamsMetadata?>() { { "foo", "string" } },
            UniqueID = "unique_id",
        };

        FileAddParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FileAddParamsMetadataTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        FileAddParamsMetadata value = "string";
        value.Validate();
    }

    [Fact]
    public void LongValidationWorks()
    {
        FileAddParamsMetadata value = 0;
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        FileAddParamsMetadata value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        FileAddParamsMetadata value = true;
        value.Validate();
    }

    [Fact]
    public void ListValueValidationWorks()
    {
        FileAddParamsMetadata value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        FileAddParamsMetadata value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileAddParamsMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        FileAddParamsMetadata value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileAddParamsMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        FileAddParamsMetadata value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileAddParamsMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        FileAddParamsMetadata value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileAddParamsMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ListValueSerializationRoundtripWorks()
    {
        FileAddParamsMetadata value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileAddParamsMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
