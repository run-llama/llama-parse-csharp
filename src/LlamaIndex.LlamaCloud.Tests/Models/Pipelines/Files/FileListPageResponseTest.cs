using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines.Files;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines.Files;

public class FileListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileListPageResponse
        {
            Files =
            [
                new()
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
                },
            ],
            Limit = 0,
            Offset = 0,
            TotalCount = 0,
        };

        List<PipelineFile> expectedFiles =
        [
            new()
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
            },
        ];
        long expectedLimit = 0;
        long expectedOffset = 0;
        long expectedTotalCount = 0;

        Assert.Equal(expectedFiles.Count, model.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], model.Files[i]);
        }
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedOffset, model.Offset);
        Assert.Equal(expectedTotalCount, model.TotalCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileListPageResponse
        {
            Files =
            [
                new()
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
                },
            ],
            Limit = 0,
            Offset = 0,
            TotalCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileListPageResponse
        {
            Files =
            [
                new()
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
                },
            ],
            Limit = 0,
            Offset = 0,
            TotalCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<PipelineFile> expectedFiles =
        [
            new()
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
            },
        ];
        long expectedLimit = 0;
        long expectedOffset = 0;
        long expectedTotalCount = 0;

        Assert.Equal(expectedFiles.Count, deserialized.Files.Count);
        for (int i = 0; i < expectedFiles.Count; i++)
        {
            Assert.Equal(expectedFiles[i], deserialized.Files[i]);
        }
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedOffset, deserialized.Offset);
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileListPageResponse
        {
            Files =
            [
                new()
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
                },
            ],
            Limit = 0,
            Offset = 0,
            TotalCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileListPageResponse
        {
            Files =
            [
                new()
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
                },
            ],
            Limit = 0,
            Offset = 0,
            TotalCount = 0,
        };

        FileListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
