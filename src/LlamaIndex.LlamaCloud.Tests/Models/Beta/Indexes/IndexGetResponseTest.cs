using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.Indexes;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Indexes;

public class IndexGetResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IndexGetResponse
        {
            ID = "id",
            ExportConfigID = "export_config_id",
            Name = "name",
            OutputDirectoryID = "output_directory_id",
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            SyncConfigID = "sync_config_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            LastExportedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedExportConfigID = "export_config_id";
        string expectedName = "name";
        string expectedOutputDirectoryID = "output_directory_id";
        string expectedProjectID = "project_id";
        string expectedSourceDirectoryID = "source_directory_id";
        string expectedSyncConfigID = "sync_config_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        DateTimeOffset expectedLastExportedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExportConfigID, model.ExportConfigID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOutputDirectoryID, model.OutputDirectoryID);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedSourceDirectoryID, model.SourceDirectoryID);
        Assert.Equal(expectedSyncConfigID, model.SyncConfigID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedLastExportedAt, model.LastExportedAt);
        Assert.Equal(expectedLastSyncedAt, model.LastSyncedAt);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Metadata[item.Key]));
        }
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IndexGetResponse
        {
            ID = "id",
            ExportConfigID = "export_config_id",
            Name = "name",
            OutputDirectoryID = "output_directory_id",
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            SyncConfigID = "sync_config_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            LastExportedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IndexGetResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IndexGetResponse
        {
            ID = "id",
            ExportConfigID = "export_config_id",
            Name = "name",
            OutputDirectoryID = "output_directory_id",
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            SyncConfigID = "sync_config_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            LastExportedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IndexGetResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedExportConfigID = "export_config_id";
        string expectedName = "name";
        string expectedOutputDirectoryID = "output_directory_id";
        string expectedProjectID = "project_id";
        string expectedSourceDirectoryID = "source_directory_id";
        string expectedSyncConfigID = "sync_config_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        DateTimeOffset expectedLastExportedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedExportConfigID, deserialized.ExportConfigID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOutputDirectoryID, deserialized.OutputDirectoryID);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedSourceDirectoryID, deserialized.SourceDirectoryID);
        Assert.Equal(expectedSyncConfigID, deserialized.SyncConfigID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedLastExportedAt, deserialized.LastExportedAt);
        Assert.Equal(expectedLastSyncedAt, deserialized.LastSyncedAt);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Metadata[item.Key]));
        }
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IndexGetResponse
        {
            ID = "id",
            ExportConfigID = "export_config_id",
            Name = "name",
            OutputDirectoryID = "output_directory_id",
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            SyncConfigID = "sync_config_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            LastExportedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IndexGetResponse
        {
            ID = "id",
            ExportConfigID = "export_config_id",
            Name = "name",
            OutputDirectoryID = "output_directory_id",
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            SyncConfigID = "sync_config_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            LastExportedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new IndexGetResponse
        {
            ID = "id",
            ExportConfigID = "export_config_id",
            Name = "name",
            OutputDirectoryID = "output_directory_id",
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            SyncConfigID = "sync_config_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            LastExportedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new IndexGetResponse
        {
            ID = "id",
            ExportConfigID = "export_config_id",
            Name = "name",
            OutputDirectoryID = "output_directory_id",
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            SyncConfigID = "sync_config_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            LastExportedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new IndexGetResponse
        {
            ID = "id",
            ExportConfigID = "export_config_id",
            Name = "name",
            OutputDirectoryID = "output_directory_id",
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            SyncConfigID = "sync_config_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            LastExportedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IndexGetResponse
        {
            ID = "id",
            ExportConfigID = "export_config_id",
            Name = "name",
            OutputDirectoryID = "output_directory_id",
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            SyncConfigID = "sync_config_id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.LastExportedAt);
        Assert.False(model.RawData.ContainsKey("last_exported_at"));
        Assert.Null(model.LastSyncedAt);
        Assert.False(model.RawData.ContainsKey("last_synced_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new IndexGetResponse
        {
            ID = "id",
            ExportConfigID = "export_config_id",
            Name = "name",
            OutputDirectoryID = "output_directory_id",
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            SyncConfigID = "sync_config_id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new IndexGetResponse
        {
            ID = "id",
            ExportConfigID = "export_config_id",
            Name = "name",
            OutputDirectoryID = "output_directory_id",
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            SyncConfigID = "sync_config_id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            CreatedAt = null,
            Description = null,
            LastExportedAt = null,
            LastSyncedAt = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.LastExportedAt);
        Assert.True(model.RawData.ContainsKey("last_exported_at"));
        Assert.Null(model.LastSyncedAt);
        Assert.True(model.RawData.ContainsKey("last_synced_at"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IndexGetResponse
        {
            ID = "id",
            ExportConfigID = "export_config_id",
            Name = "name",
            OutputDirectoryID = "output_directory_id",
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            SyncConfigID = "sync_config_id",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            CreatedAt = null,
            Description = null,
            LastExportedAt = null,
            LastSyncedAt = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IndexGetResponse
        {
            ID = "id",
            ExportConfigID = "export_config_id",
            Name = "name",
            OutputDirectoryID = "output_directory_id",
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            SyncConfigID = "sync_config_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            LastExportedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        IndexGetResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
