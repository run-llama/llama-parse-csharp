using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines.Files;

namespace LlamaCloud.Tests.Models.Pipelines.Files;

public class PipelineFileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PipelineFile
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConfigHash = new Dictionary<string, ConfigHash?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomMetadata = new Dictionary<string, PipelineFileCustomMetadata?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExternalFileID = "external_file_id",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileSize = 0,
            FileType = "file_type",
            IndexedPageCount = 0,
            LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PermissionInfo = new Dictionary<string, PermissionInfo?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ResourceInfo = new Dictionary<string, ResourceInfo?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            Status = PipelineFileStatus.Cancelled,
            StatusUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Dictionary<string, ConfigHash?> expectedConfigHash = new()
        {
            {
                "foo",
                new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                )
            },
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, PipelineFileCustomMetadata?> expectedCustomMetadata = new()
        {
            {
                "foo",
                new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                )
            },
        };
        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedExternalFileID = "external_file_id";
        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedFileSize = 0;
        string expectedFileType = "file_type";
        long expectedIndexedPageCount = 0;
        DateTimeOffset expectedLastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        Dictionary<string, PermissionInfo?> expectedPermissionInfo = new()
        {
            {
                "foo",
                new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                )
            },
        };
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Dictionary<string, ResourceInfo?> expectedResourceInfo = new()
        {
            {
                "foo",
                new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                )
            },
        };
        ApiEnum<string, PipelineFileStatus> expectedStatus = PipelineFileStatus.Cancelled;
        DateTimeOffset expectedStatusUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedPipelineID, model.PipelineID);
        Assert.NotNull(model.ConfigHash);
        Assert.Equal(expectedConfigHash.Count, model.ConfigHash.Count);
        foreach (var item in expectedConfigHash)
        {
            Assert.True(model.ConfigHash.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.ConfigHash[item.Key]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.CustomMetadata);
        Assert.Equal(expectedCustomMetadata.Count, model.CustomMetadata.Count);
        foreach (var item in expectedCustomMetadata)
        {
            Assert.True(model.CustomMetadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.CustomMetadata[item.Key]);
        }
        Assert.Equal(expectedDataSourceID, model.DataSourceID);
        Assert.Equal(expectedExternalFileID, model.ExternalFileID);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedFileSize, model.FileSize);
        Assert.Equal(expectedFileType, model.FileType);
        Assert.Equal(expectedIndexedPageCount, model.IndexedPageCount);
        Assert.Equal(expectedLastModifiedAt, model.LastModifiedAt);
        Assert.Equal(expectedName, model.Name);
        Assert.NotNull(model.PermissionInfo);
        Assert.Equal(expectedPermissionInfo.Count, model.PermissionInfo.Count);
        foreach (var item in expectedPermissionInfo)
        {
            Assert.True(model.PermissionInfo.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.PermissionInfo[item.Key]);
        }
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.NotNull(model.ResourceInfo);
        Assert.Equal(expectedResourceInfo.Count, model.ResourceInfo.Count);
        foreach (var item in expectedResourceInfo)
        {
            Assert.True(model.ResourceInfo.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.ResourceInfo[item.Key]);
        }
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStatusUpdatedAt, model.StatusUpdatedAt);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PipelineFile
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConfigHash = new Dictionary<string, ConfigHash?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomMetadata = new Dictionary<string, PipelineFileCustomMetadata?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExternalFileID = "external_file_id",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileSize = 0,
            FileType = "file_type",
            IndexedPageCount = 0,
            LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PermissionInfo = new Dictionary<string, PermissionInfo?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ResourceInfo = new Dictionary<string, ResourceInfo?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            Status = PipelineFileStatus.Cancelled,
            StatusUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineFile>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PipelineFile
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConfigHash = new Dictionary<string, ConfigHash?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomMetadata = new Dictionary<string, PipelineFileCustomMetadata?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExternalFileID = "external_file_id",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileSize = 0,
            FileType = "file_type",
            IndexedPageCount = 0,
            LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PermissionInfo = new Dictionary<string, PermissionInfo?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ResourceInfo = new Dictionary<string, ResourceInfo?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            Status = PipelineFileStatus.Cancelled,
            StatusUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineFile>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Dictionary<string, ConfigHash?> expectedConfigHash = new()
        {
            {
                "foo",
                new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                )
            },
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, PipelineFileCustomMetadata?> expectedCustomMetadata = new()
        {
            {
                "foo",
                new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                )
            },
        };
        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedExternalFileID = "external_file_id";
        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedFileSize = 0;
        string expectedFileType = "file_type";
        long expectedIndexedPageCount = 0;
        DateTimeOffset expectedLastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        Dictionary<string, PermissionInfo?> expectedPermissionInfo = new()
        {
            {
                "foo",
                new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                )
            },
        };
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Dictionary<string, ResourceInfo?> expectedResourceInfo = new()
        {
            {
                "foo",
                new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                )
            },
        };
        ApiEnum<string, PipelineFileStatus> expectedStatus = PipelineFileStatus.Cancelled;
        DateTimeOffset expectedStatusUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedPipelineID, deserialized.PipelineID);
        Assert.NotNull(deserialized.ConfigHash);
        Assert.Equal(expectedConfigHash.Count, deserialized.ConfigHash.Count);
        foreach (var item in expectedConfigHash)
        {
            Assert.True(deserialized.ConfigHash.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.ConfigHash[item.Key]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.CustomMetadata);
        Assert.Equal(expectedCustomMetadata.Count, deserialized.CustomMetadata.Count);
        foreach (var item in expectedCustomMetadata)
        {
            Assert.True(deserialized.CustomMetadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.CustomMetadata[item.Key]);
        }
        Assert.Equal(expectedDataSourceID, deserialized.DataSourceID);
        Assert.Equal(expectedExternalFileID, deserialized.ExternalFileID);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedFileSize, deserialized.FileSize);
        Assert.Equal(expectedFileType, deserialized.FileType);
        Assert.Equal(expectedIndexedPageCount, deserialized.IndexedPageCount);
        Assert.Equal(expectedLastModifiedAt, deserialized.LastModifiedAt);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.NotNull(deserialized.PermissionInfo);
        Assert.Equal(expectedPermissionInfo.Count, deserialized.PermissionInfo.Count);
        foreach (var item in expectedPermissionInfo)
        {
            Assert.True(deserialized.PermissionInfo.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.PermissionInfo[item.Key]);
        }
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.NotNull(deserialized.ResourceInfo);
        Assert.Equal(expectedResourceInfo.Count, deserialized.ResourceInfo.Count);
        foreach (var item in expectedResourceInfo)
        {
            Assert.True(deserialized.ResourceInfo.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.ResourceInfo[item.Key]);
        }
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStatusUpdatedAt, deserialized.StatusUpdatedAt);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PipelineFile
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConfigHash = new Dictionary<string, ConfigHash?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomMetadata = new Dictionary<string, PipelineFileCustomMetadata?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExternalFileID = "external_file_id",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileSize = 0,
            FileType = "file_type",
            IndexedPageCount = 0,
            LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PermissionInfo = new Dictionary<string, PermissionInfo?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ResourceInfo = new Dictionary<string, ResourceInfo?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            Status = PipelineFileStatus.Cancelled,
            StatusUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PipelineFile
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(model.ConfigHash);
        Assert.False(model.RawData.ContainsKey("config_hash"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CustomMetadata);
        Assert.False(model.RawData.ContainsKey("custom_metadata"));
        Assert.Null(model.DataSourceID);
        Assert.False(model.RawData.ContainsKey("data_source_id"));
        Assert.Null(model.ExternalFileID);
        Assert.False(model.RawData.ContainsKey("external_file_id"));
        Assert.Null(model.FileID);
        Assert.False(model.RawData.ContainsKey("file_id"));
        Assert.Null(model.FileSize);
        Assert.False(model.RawData.ContainsKey("file_size"));
        Assert.Null(model.FileType);
        Assert.False(model.RawData.ContainsKey("file_type"));
        Assert.Null(model.IndexedPageCount);
        Assert.False(model.RawData.ContainsKey("indexed_page_count"));
        Assert.Null(model.LastModifiedAt);
        Assert.False(model.RawData.ContainsKey("last_modified_at"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.PermissionInfo);
        Assert.False(model.RawData.ContainsKey("permission_info"));
        Assert.Null(model.ProjectID);
        Assert.False(model.RawData.ContainsKey("project_id"));
        Assert.Null(model.ResourceInfo);
        Assert.False(model.RawData.ContainsKey("resource_info"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.StatusUpdatedAt);
        Assert.False(model.RawData.ContainsKey("status_updated_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PipelineFile
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PipelineFile
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            ConfigHash = null,
            CreatedAt = null,
            CustomMetadata = null,
            DataSourceID = null,
            ExternalFileID = null,
            FileID = null,
            FileSize = null,
            FileType = null,
            IndexedPageCount = null,
            LastModifiedAt = null,
            Name = null,
            PermissionInfo = null,
            ProjectID = null,
            ResourceInfo = null,
            Status = null,
            StatusUpdatedAt = null,
            UpdatedAt = null,
        };

        Assert.Null(model.ConfigHash);
        Assert.True(model.RawData.ContainsKey("config_hash"));
        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CustomMetadata);
        Assert.True(model.RawData.ContainsKey("custom_metadata"));
        Assert.Null(model.DataSourceID);
        Assert.True(model.RawData.ContainsKey("data_source_id"));
        Assert.Null(model.ExternalFileID);
        Assert.True(model.RawData.ContainsKey("external_file_id"));
        Assert.Null(model.FileID);
        Assert.True(model.RawData.ContainsKey("file_id"));
        Assert.Null(model.FileSize);
        Assert.True(model.RawData.ContainsKey("file_size"));
        Assert.Null(model.FileType);
        Assert.True(model.RawData.ContainsKey("file_type"));
        Assert.Null(model.IndexedPageCount);
        Assert.True(model.RawData.ContainsKey("indexed_page_count"));
        Assert.Null(model.LastModifiedAt);
        Assert.True(model.RawData.ContainsKey("last_modified_at"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.PermissionInfo);
        Assert.True(model.RawData.ContainsKey("permission_info"));
        Assert.Null(model.ProjectID);
        Assert.True(model.RawData.ContainsKey("project_id"));
        Assert.Null(model.ResourceInfo);
        Assert.True(model.RawData.ContainsKey("resource_info"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.StatusUpdatedAt);
        Assert.True(model.RawData.ContainsKey("status_updated_at"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PipelineFile
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            ConfigHash = null,
            CreatedAt = null,
            CustomMetadata = null,
            DataSourceID = null,
            ExternalFileID = null,
            FileID = null,
            FileSize = null,
            FileType = null,
            IndexedPageCount = null,
            LastModifiedAt = null,
            Name = null,
            PermissionInfo = null,
            ProjectID = null,
            ResourceInfo = null,
            Status = null,
            StatusUpdatedAt = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PipelineFile
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConfigHash = new Dictionary<string, ConfigHash?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomMetadata = new Dictionary<string, PipelineFileCustomMetadata?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExternalFileID = "external_file_id",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileSize = 0,
            FileType = "file_type",
            IndexedPageCount = 0,
            LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PermissionInfo = new Dictionary<string, PermissionInfo?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ResourceInfo = new Dictionary<string, ResourceInfo?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            Status = PipelineFileStatus.Cancelled,
            StatusUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        PipelineFile copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConfigHashTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        ConfigHash value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidationWorks1()
    {
        ConfigHash value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        ConfigHash value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ConfigHash value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ConfigHash value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        ConfigHash value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigHash>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        ConfigHash value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigHash>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ConfigHash value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigHash>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ConfigHash value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigHash>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ConfigHash value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigHash>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PipelineFileCustomMetadataTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        PipelineFileCustomMetadata value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidationWorks1()
    {
        PipelineFileCustomMetadata value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        PipelineFileCustomMetadata value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        PipelineFileCustomMetadata value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        PipelineFileCustomMetadata value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        PipelineFileCustomMetadata value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineFileCustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        PipelineFileCustomMetadata value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineFileCustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        PipelineFileCustomMetadata value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineFileCustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        PipelineFileCustomMetadata value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineFileCustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        PipelineFileCustomMetadata value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineFileCustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PermissionInfoTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        PermissionInfo value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidationWorks1()
    {
        PermissionInfo value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        PermissionInfo value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        PermissionInfo value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        PermissionInfo value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        PermissionInfo value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PermissionInfo>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        PermissionInfo value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PermissionInfo>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        PermissionInfo value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PermissionInfo>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        PermissionInfo value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PermissionInfo>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        PermissionInfo value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PermissionInfo>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ResourceInfoTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        ResourceInfo value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        value.Validate();
    }

    [Fact]
    public void JsonElementsValidationWorks1()
    {
        ResourceInfo value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        ResourceInfo value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ResourceInfo value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ResourceInfo value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        ResourceInfo value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResourceInfo>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        ResourceInfo value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResourceInfo>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ResourceInfo value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResourceInfo>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ResourceInfo value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResourceInfo>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ResourceInfo value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ResourceInfo>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PipelineFileStatusTest : TestBase
{
    [Theory]
    [InlineData(PipelineFileStatus.Cancelled)]
    [InlineData(PipelineFileStatus.Error)]
    [InlineData(PipelineFileStatus.InProgress)]
    [InlineData(PipelineFileStatus.NotStarted)]
    [InlineData(PipelineFileStatus.Success)]
    public void Validation_Works(PipelineFileStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PipelineFileStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PipelineFileStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PipelineFileStatus.Cancelled)]
    [InlineData(PipelineFileStatus.Error)]
    [InlineData(PipelineFileStatus.InProgress)]
    [InlineData(PipelineFileStatus.NotStarted)]
    [InlineData(PipelineFileStatus.Success)]
    public void SerializationRoundtrip_Works(PipelineFileStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PipelineFileStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PipelineFileStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PipelineFileStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PipelineFileStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
