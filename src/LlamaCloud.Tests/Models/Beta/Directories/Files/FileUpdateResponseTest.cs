using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Beta.Directories.Files;
using LlamaCloud.Models.Files;

namespace LlamaCloud.Tests.Models.Beta.Directories.Files;

public class FileUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileUpdateResponse
        {
            ID = "id",
            DirectoryID = "directory_id",
            DisplayName = "x",
            ProjectID = "project_id",
            UniqueID = "x",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "https://example.com",
                FormFields = new Dictionary<string, string>() { { "foo", "string" } },
            },
            FileID = "file_id",
            Metadata = new Dictionary<string, FileUpdateResponseMetadata?>()
            {
                { "foo", "string" },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedDirectoryID = "directory_id";
        string expectedDisplayName = "x";
        string expectedProjectID = "project_id";
        string expectedUniqueID = "x";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedDeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        PresignedUrl expectedDownloadUrl = new()
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            FormFields = new Dictionary<string, string>() { { "foo", "string" } },
        };
        string expectedFileID = "file_id";
        Dictionary<string, FileUpdateResponseMetadata?> expectedMetadata = new()
        {
            { "foo", "string" },
        };
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDirectoryID, model.DirectoryID);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedUniqueID, model.UniqueID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDeletedAt, model.DeletedAt);
        Assert.Equal(expectedDownloadUrl, model.DownloadUrl);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileUpdateResponse
        {
            ID = "id",
            DirectoryID = "directory_id",
            DisplayName = "x",
            ProjectID = "project_id",
            UniqueID = "x",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "https://example.com",
                FormFields = new Dictionary<string, string>() { { "foo", "string" } },
            },
            FileID = "file_id",
            Metadata = new Dictionary<string, FileUpdateResponseMetadata?>()
            {
                { "foo", "string" },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileUpdateResponse
        {
            ID = "id",
            DirectoryID = "directory_id",
            DisplayName = "x",
            ProjectID = "project_id",
            UniqueID = "x",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "https://example.com",
                FormFields = new Dictionary<string, string>() { { "foo", "string" } },
            },
            FileID = "file_id",
            Metadata = new Dictionary<string, FileUpdateResponseMetadata?>()
            {
                { "foo", "string" },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDirectoryID = "directory_id";
        string expectedDisplayName = "x";
        string expectedProjectID = "project_id";
        string expectedUniqueID = "x";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedDeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        PresignedUrl expectedDownloadUrl = new()
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            FormFields = new Dictionary<string, string>() { { "foo", "string" } },
        };
        string expectedFileID = "file_id";
        Dictionary<string, FileUpdateResponseMetadata?> expectedMetadata = new()
        {
            { "foo", "string" },
        };
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDirectoryID, deserialized.DirectoryID);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedUniqueID, deserialized.UniqueID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDeletedAt, deserialized.DeletedAt);
        Assert.Equal(expectedDownloadUrl, deserialized.DownloadUrl);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileUpdateResponse
        {
            ID = "id",
            DirectoryID = "directory_id",
            DisplayName = "x",
            ProjectID = "project_id",
            UniqueID = "x",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "https://example.com",
                FormFields = new Dictionary<string, string>() { { "foo", "string" } },
            },
            FileID = "file_id",
            Metadata = new Dictionary<string, FileUpdateResponseMetadata?>()
            {
                { "foo", "string" },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileUpdateResponse
        {
            ID = "id",
            DirectoryID = "directory_id",
            DisplayName = "x",
            ProjectID = "project_id",
            UniqueID = "x",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "https://example.com",
                FormFields = new Dictionary<string, string>() { { "foo", "string" } },
            },
            FileID = "file_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileUpdateResponse
        {
            ID = "id",
            DirectoryID = "directory_id",
            DisplayName = "x",
            ProjectID = "project_id",
            UniqueID = "x",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "https://example.com",
                FormFields = new Dictionary<string, string>() { { "foo", "string" } },
            },
            FileID = "file_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FileUpdateResponse
        {
            ID = "id",
            DirectoryID = "directory_id",
            DisplayName = "x",
            ProjectID = "project_id",
            UniqueID = "x",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "https://example.com",
                FormFields = new Dictionary<string, string>() { { "foo", "string" } },
            },
            FileID = "file_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileUpdateResponse
        {
            ID = "id",
            DirectoryID = "directory_id",
            DisplayName = "x",
            ProjectID = "project_id",
            UniqueID = "x",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "https://example.com",
                FormFields = new Dictionary<string, string>() { { "foo", "string" } },
            },
            FileID = "file_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileUpdateResponse
        {
            ID = "id",
            DirectoryID = "directory_id",
            DisplayName = "x",
            ProjectID = "project_id",
            UniqueID = "x",
            Metadata = new Dictionary<string, FileUpdateResponseMetadata?>()
            {
                { "foo", "string" },
            },
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DeletedAt);
        Assert.False(model.RawData.ContainsKey("deleted_at"));
        Assert.Null(model.DownloadUrl);
        Assert.False(model.RawData.ContainsKey("download_url"));
        Assert.Null(model.FileID);
        Assert.False(model.RawData.ContainsKey("file_id"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileUpdateResponse
        {
            ID = "id",
            DirectoryID = "directory_id",
            DisplayName = "x",
            ProjectID = "project_id",
            UniqueID = "x",
            Metadata = new Dictionary<string, FileUpdateResponseMetadata?>()
            {
                { "foo", "string" },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FileUpdateResponse
        {
            ID = "id",
            DirectoryID = "directory_id",
            DisplayName = "x",
            ProjectID = "project_id",
            UniqueID = "x",
            Metadata = new Dictionary<string, FileUpdateResponseMetadata?>()
            {
                { "foo", "string" },
            },

            CreatedAt = null,
            DeletedAt = null,
            DownloadUrl = null,
            FileID = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DeletedAt);
        Assert.True(model.RawData.ContainsKey("deleted_at"));
        Assert.Null(model.DownloadUrl);
        Assert.True(model.RawData.ContainsKey("download_url"));
        Assert.Null(model.FileID);
        Assert.True(model.RawData.ContainsKey("file_id"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileUpdateResponse
        {
            ID = "id",
            DirectoryID = "directory_id",
            DisplayName = "x",
            ProjectID = "project_id",
            UniqueID = "x",
            Metadata = new Dictionary<string, FileUpdateResponseMetadata?>()
            {
                { "foo", "string" },
            },

            CreatedAt = null,
            DeletedAt = null,
            DownloadUrl = null,
            FileID = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileUpdateResponse
        {
            ID = "id",
            DirectoryID = "directory_id",
            DisplayName = "x",
            ProjectID = "project_id",
            UniqueID = "x",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DeletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DownloadUrl = new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "https://example.com",
                FormFields = new Dictionary<string, string>() { { "foo", "string" } },
            },
            FileID = "file_id",
            Metadata = new Dictionary<string, FileUpdateResponseMetadata?>()
            {
                { "foo", "string" },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        FileUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FileUpdateResponseMetadataTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        FileUpdateResponseMetadata value = "string";
        value.Validate();
    }

    [Fact]
    public void LongValidationWorks()
    {
        FileUpdateResponseMetadata value = 0;
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        FileUpdateResponseMetadata value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        FileUpdateResponseMetadata value = true;
        value.Validate();
    }

    [Fact]
    public void ListValueValidationWorks()
    {
        FileUpdateResponseMetadata value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        FileUpdateResponseMetadata value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileUpdateResponseMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        FileUpdateResponseMetadata value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileUpdateResponseMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        FileUpdateResponseMetadata value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileUpdateResponseMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        FileUpdateResponseMetadata value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileUpdateResponseMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ListValueSerializationRoundtripWorks()
    {
        FileUpdateResponseMetadata value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileUpdateResponseMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
