using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Files;

namespace LlamaIndex.LlamaCloud.Tests.Models.Files;

public class FileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new File
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalFileID = "external_file_id",
            FileSize = 0,
            FileType = "x",
            LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Purpose = "purpose",
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedName = "x";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalFileID = "external_file_id";
        long expectedFileSize = 0;
        string expectedFileType = "x";
        DateTimeOffset expectedLastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
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
        string expectedPurpose = "purpose";
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
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDataSourceID, model.DataSourceID);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedExternalFileID, model.ExternalFileID);
        Assert.Equal(expectedFileSize, model.FileSize);
        Assert.Equal(expectedFileType, model.FileType);
        Assert.Equal(expectedLastModifiedAt, model.LastModifiedAt);
        Assert.NotNull(model.PermissionInfo);
        Assert.Equal(expectedPermissionInfo.Count, model.PermissionInfo.Count);
        foreach (var item in expectedPermissionInfo)
        {
            Assert.True(model.PermissionInfo.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.PermissionInfo[item.Key]);
        }
        Assert.Equal(expectedPurpose, model.Purpose);
        Assert.NotNull(model.ResourceInfo);
        Assert.Equal(expectedResourceInfo.Count, model.ResourceInfo.Count);
        foreach (var item in expectedResourceInfo)
        {
            Assert.True(model.ResourceInfo.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.ResourceInfo[item.Key]);
        }
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new File
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalFileID = "external_file_id",
            FileSize = 0,
            FileType = "x",
            LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Purpose = "purpose",
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<File>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new File
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalFileID = "external_file_id",
            FileSize = 0,
            FileType = "x",
            LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Purpose = "purpose",
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<File>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedName = "x";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalFileID = "external_file_id";
        long expectedFileSize = 0;
        string expectedFileType = "x";
        DateTimeOffset expectedLastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
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
        string expectedPurpose = "purpose";
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
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDataSourceID, deserialized.DataSourceID);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedExternalFileID, deserialized.ExternalFileID);
        Assert.Equal(expectedFileSize, deserialized.FileSize);
        Assert.Equal(expectedFileType, deserialized.FileType);
        Assert.Equal(expectedLastModifiedAt, deserialized.LastModifiedAt);
        Assert.NotNull(deserialized.PermissionInfo);
        Assert.Equal(expectedPermissionInfo.Count, deserialized.PermissionInfo.Count);
        foreach (var item in expectedPermissionInfo)
        {
            Assert.True(deserialized.PermissionInfo.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.PermissionInfo[item.Key]);
        }
        Assert.Equal(expectedPurpose, deserialized.Purpose);
        Assert.NotNull(deserialized.ResourceInfo);
        Assert.Equal(expectedResourceInfo.Count, deserialized.ResourceInfo.Count);
        foreach (var item in expectedResourceInfo)
        {
            Assert.True(deserialized.ResourceInfo.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.ResourceInfo[item.Key]);
        }
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new File
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalFileID = "external_file_id",
            FileSize = 0,
            FileType = "x",
            LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Purpose = "purpose",
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new File
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DataSourceID);
        Assert.False(model.RawData.ContainsKey("data_source_id"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.ExternalFileID);
        Assert.False(model.RawData.ContainsKey("external_file_id"));
        Assert.Null(model.FileSize);
        Assert.False(model.RawData.ContainsKey("file_size"));
        Assert.Null(model.FileType);
        Assert.False(model.RawData.ContainsKey("file_type"));
        Assert.Null(model.LastModifiedAt);
        Assert.False(model.RawData.ContainsKey("last_modified_at"));
        Assert.Null(model.PermissionInfo);
        Assert.False(model.RawData.ContainsKey("permission_info"));
        Assert.Null(model.Purpose);
        Assert.False(model.RawData.ContainsKey("purpose"));
        Assert.Null(model.ResourceInfo);
        Assert.False(model.RawData.ContainsKey("resource_info"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new File
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new File
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            CreatedAt = null,
            DataSourceID = null,
            ExpiresAt = null,
            ExternalFileID = null,
            FileSize = null,
            FileType = null,
            LastModifiedAt = null,
            PermissionInfo = null,
            Purpose = null,
            ResourceInfo = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DataSourceID);
        Assert.True(model.RawData.ContainsKey("data_source_id"));
        Assert.Null(model.ExpiresAt);
        Assert.True(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.ExternalFileID);
        Assert.True(model.RawData.ContainsKey("external_file_id"));
        Assert.Null(model.FileSize);
        Assert.True(model.RawData.ContainsKey("file_size"));
        Assert.Null(model.FileType);
        Assert.True(model.RawData.ContainsKey("file_type"));
        Assert.Null(model.LastModifiedAt);
        Assert.True(model.RawData.ContainsKey("last_modified_at"));
        Assert.Null(model.PermissionInfo);
        Assert.True(model.RawData.ContainsKey("permission_info"));
        Assert.Null(model.Purpose);
        Assert.True(model.RawData.ContainsKey("purpose"));
        Assert.Null(model.ResourceInfo);
        Assert.True(model.RawData.ContainsKey("resource_info"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new File
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            CreatedAt = null,
            DataSourceID = null,
            ExpiresAt = null,
            ExternalFileID = null,
            FileSize = null,
            FileType = null,
            LastModifiedAt = null,
            PermissionInfo = null,
            Purpose = null,
            ResourceInfo = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new File
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Name = "x",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalFileID = "external_file_id",
            FileSize = 0,
            FileType = "x",
            LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Purpose = "purpose",
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        File copied = new(model);

        Assert.Equal(model, copied);
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
