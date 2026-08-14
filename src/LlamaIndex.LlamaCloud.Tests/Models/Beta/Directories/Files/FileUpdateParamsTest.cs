using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.Directories.Files;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Directories.Files;

public class FileUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileUpdateParams
        {
            DirectoryID = "directory_id",
            DirectoryFileID = "directory_file_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DisplayName = "display_name",
            Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
            TargetDirectoryID = "target_directory_id",
            UniqueID = "x",
        };

        string expectedDirectoryID = "directory_id";
        string expectedDirectoryFileID = "directory_file_id";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDisplayName = "display_name";
        Dictionary<string, Metadata?> expectedMetadata = new() { { "foo", "string" } };
        string expectedTargetDirectoryID = "target_directory_id";
        string expectedUniqueID = "x";

        Assert.Equal(expectedDirectoryID, parameters.DirectoryID);
        Assert.Equal(expectedDirectoryFileID, parameters.DirectoryFileID);
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
        Assert.Equal(expectedTargetDirectoryID, parameters.TargetDirectoryID);
        Assert.Equal(expectedUniqueID, parameters.UniqueID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileUpdateParams
        {
            DirectoryID = "directory_id",
            DirectoryFileID = "directory_file_id",
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("display_name"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.TargetDirectoryID);
        Assert.False(parameters.RawBodyData.ContainsKey("target_directory_id"));
        Assert.Null(parameters.UniqueID);
        Assert.False(parameters.RawBodyData.ContainsKey("unique_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new FileUpdateParams
        {
            DirectoryID = "directory_id",
            DirectoryFileID = "directory_file_id",

            OrganizationID = null,
            ProjectID = null,
            DisplayName = null,
            Metadata = null,
            TargetDirectoryID = null,
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
        Assert.Null(parameters.TargetDirectoryID);
        Assert.True(parameters.RawBodyData.ContainsKey("target_directory_id"));
        Assert.Null(parameters.UniqueID);
        Assert.True(parameters.RawBodyData.ContainsKey("unique_id"));
    }

    [Fact]
    public void Url_Works()
    {
        FileUpdateParams parameters = new()
        {
            DirectoryID = "directory_id",
            DirectoryFileID = "directory_file_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/directories/directory_id/files/directory_file_id?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileUpdateParams
        {
            DirectoryID = "directory_id",
            DirectoryFileID = "directory_file_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DisplayName = "display_name",
            Metadata = new Dictionary<string, Metadata?>() { { "foo", "string" } },
            TargetDirectoryID = "target_directory_id",
            UniqueID = "x",
        };

        FileUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class MetadataTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Metadata value = "string";
        value.Validate();
    }

    [Fact]
    public void LongValidationWorks()
    {
        Metadata value = 0;
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        Metadata value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        Metadata value = true;
        value.Validate();
    }

    [Fact]
    public void ListValueValidationWorks()
    {
        Metadata value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Metadata value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Metadata value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Metadata value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        Metadata value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ListValueSerializationRoundtripWorks()
    {
        Metadata value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
