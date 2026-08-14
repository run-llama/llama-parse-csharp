using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models;
using LlamaCloud.Models.Pipelines.DataSources;
using DataSources = LlamaCloud.Models.DataSources;

namespace LlamaCloud.Tests.Models.Pipelines.DataSources;

public class PipelineDataSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PipelineDataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = SourceType.AzureStorageBlob,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomMetadata = new Dictionary<string, CustomMetadata?>()
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
            Status = Status.Cancelled,
            StatusUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SyncInterval = 0,
            SyncScheduleSetBy = "sync_schedule_set_by",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionMetadata = new() { ReaderVersion = DataSources::ReaderVersion.V1_0 },
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Component expectedComponent = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedLastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, SourceType> expectedSourceType = SourceType.AzureStorageBlob;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, CustomMetadata?> expectedCustomMetadata = new()
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
        ApiEnum<string, Status> expectedStatus = Status.Cancelled;
        DateTimeOffset expectedStatusUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedSyncInterval = 0;
        string expectedSyncScheduleSetBy = "sync_schedule_set_by";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DataSources::DataSourceReaderVersionMetadata expectedVersionMetadata = new()
        {
            ReaderVersion = DataSources::ReaderVersion.V1_0,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedComponent, model.Component);
        Assert.Equal(expectedDataSourceID, model.DataSourceID);
        Assert.Equal(expectedLastSyncedAt, model.LastSyncedAt);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPipelineID, model.PipelineID);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedSourceType, model.SourceType);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.CustomMetadata);
        Assert.Equal(expectedCustomMetadata.Count, model.CustomMetadata.Count);
        foreach (var item in expectedCustomMetadata)
        {
            Assert.True(model.CustomMetadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.CustomMetadata[item.Key]);
        }
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedStatusUpdatedAt, model.StatusUpdatedAt);
        Assert.Equal(expectedSyncInterval, model.SyncInterval);
        Assert.Equal(expectedSyncScheduleSetBy, model.SyncScheduleSetBy);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVersionMetadata, model.VersionMetadata);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PipelineDataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = SourceType.AzureStorageBlob,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomMetadata = new Dictionary<string, CustomMetadata?>()
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
            Status = Status.Cancelled,
            StatusUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SyncInterval = 0,
            SyncScheduleSetBy = "sync_schedule_set_by",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionMetadata = new() { ReaderVersion = DataSources::ReaderVersion.V1_0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineDataSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PipelineDataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = SourceType.AzureStorageBlob,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomMetadata = new Dictionary<string, CustomMetadata?>()
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
            Status = Status.Cancelled,
            StatusUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SyncInterval = 0,
            SyncScheduleSetBy = "sync_schedule_set_by",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionMetadata = new() { ReaderVersion = DataSources::ReaderVersion.V1_0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineDataSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Component expectedComponent = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedLastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedName = "name";
        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, SourceType> expectedSourceType = SourceType.AzureStorageBlob;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, CustomMetadata?> expectedCustomMetadata = new()
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
        ApiEnum<string, Status> expectedStatus = Status.Cancelled;
        DateTimeOffset expectedStatusUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedSyncInterval = 0;
        string expectedSyncScheduleSetBy = "sync_schedule_set_by";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DataSources::DataSourceReaderVersionMetadata expectedVersionMetadata = new()
        {
            ReaderVersion = DataSources::ReaderVersion.V1_0,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedComponent, deserialized.Component);
        Assert.Equal(expectedDataSourceID, deserialized.DataSourceID);
        Assert.Equal(expectedLastSyncedAt, deserialized.LastSyncedAt);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPipelineID, deserialized.PipelineID);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedSourceType, deserialized.SourceType);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.CustomMetadata);
        Assert.Equal(expectedCustomMetadata.Count, deserialized.CustomMetadata.Count);
        foreach (var item in expectedCustomMetadata)
        {
            Assert.True(deserialized.CustomMetadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.CustomMetadata[item.Key]);
        }
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedStatusUpdatedAt, deserialized.StatusUpdatedAt);
        Assert.Equal(expectedSyncInterval, deserialized.SyncInterval);
        Assert.Equal(expectedSyncScheduleSetBy, deserialized.SyncScheduleSetBy);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVersionMetadata, deserialized.VersionMetadata);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PipelineDataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = SourceType.AzureStorageBlob,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomMetadata = new Dictionary<string, CustomMetadata?>()
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
            Status = Status.Cancelled,
            StatusUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SyncInterval = 0,
            SyncScheduleSetBy = "sync_schedule_set_by",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionMetadata = new() { ReaderVersion = DataSources::ReaderVersion.V1_0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PipelineDataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = SourceType.AzureStorageBlob,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CustomMetadata);
        Assert.False(model.RawData.ContainsKey("custom_metadata"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.StatusUpdatedAt);
        Assert.False(model.RawData.ContainsKey("status_updated_at"));
        Assert.Null(model.SyncInterval);
        Assert.False(model.RawData.ContainsKey("sync_interval"));
        Assert.Null(model.SyncScheduleSetBy);
        Assert.False(model.RawData.ContainsKey("sync_schedule_set_by"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.VersionMetadata);
        Assert.False(model.RawData.ContainsKey("version_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PipelineDataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = SourceType.AzureStorageBlob,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PipelineDataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = SourceType.AzureStorageBlob,

            CreatedAt = null,
            CustomMetadata = null,
            Status = null,
            StatusUpdatedAt = null,
            SyncInterval = null,
            SyncScheduleSetBy = null,
            UpdatedAt = null,
            VersionMetadata = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CustomMetadata);
        Assert.True(model.RawData.ContainsKey("custom_metadata"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.StatusUpdatedAt);
        Assert.True(model.RawData.ContainsKey("status_updated_at"));
        Assert.Null(model.SyncInterval);
        Assert.True(model.RawData.ContainsKey("sync_interval"));
        Assert.Null(model.SyncScheduleSetBy);
        Assert.True(model.RawData.ContainsKey("sync_schedule_set_by"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.VersionMetadata);
        Assert.True(model.RawData.ContainsKey("version_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PipelineDataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = SourceType.AzureStorageBlob,

            CreatedAt = null,
            CustomMetadata = null,
            Status = null,
            StatusUpdatedAt = null,
            SyncInterval = null,
            SyncScheduleSetBy = null,
            UpdatedAt = null,
            VersionMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PipelineDataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LastSyncedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = SourceType.AzureStorageBlob,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomMetadata = new Dictionary<string, CustomMetadata?>()
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
            Status = Status.Cancelled,
            StatusUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SyncInterval = 0,
            SyncScheduleSetBy = "sync_schedule_set_by",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionMetadata = new() { ReaderVersion = DataSources::ReaderVersion.V1_0 },
        };

        PipelineDataSource copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ComponentTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        Component value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        value.Validate();
    }

    [Fact]
    public void CloudS3DataSourceValidationWorks()
    {
        Component value = new CloudS3DataSource()
        {
            Bucket = "bucket",
            AwsAccessID = "aws_access_id",
            AwsAccessSecret = "aws_access_secret",
            ClassName = "class_name",
            Prefix = "prefix",
            RegexPattern = "regex_pattern",
            S3EndpointUrl = "s3_endpoint_url",
            SupportsAccessControl = true,
        };
        value.Validate();
    }

    [Fact]
    public void CloudAzStorageBlobDataSourceValidationWorks()
    {
        Component value = new CloudAzStorageBlobDataSource()
        {
            AccountUrl = "account_url",
            ContainerName = "container_name",
            AccountKey = "account_key",
            AccountName = "account_name",
            Blob = "blob",
            ClassName = "class_name",
            ClientID = "client_id",
            ClientSecret = "client_secret",
            Prefix = "prefix",
            SupportsAccessControl = true,
            TenantID = "tenant_id",
        };
        value.Validate();
    }

    [Fact]
    public void CloudGoogleDriveDataSourceValidationWorks()
    {
        Component value = new CloudGoogleDriveDataSource()
        {
            FolderID = "folder_id",
            ClassName = "class_name",
            FolderName = "folder_name",
            ServiceAccountKey = new Dictionary<string, string>() { { "foo", "string" } },
            SupportsAccessControl = true,
        };
        value.Validate();
    }

    [Fact]
    public void CloudOneDriveDataSourceValidationWorks()
    {
        Component value = new CloudOneDriveDataSource()
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            UserPrincipalName = "user_principal_name",
            ClassName = "class_name",
            FolderID = "folder_id",
            FolderPath = "folder_path",
            RequiredExts = ["string"],
            SupportsAccessControl = SupportsAccessControl.True,
        };
        value.Validate();
    }

    [Fact]
    public void CloudSharepointDataSourceValidationWorks()
    {
        Component value = new CloudSharepointDataSource()
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            ClassName = "class_name",
            DriveName = "drive_name",
            ExcludePathPatterns = ["string"],
            FolderID = "folder_id",
            FolderPath = "folder_path",
            GetPermissions = true,
            IncludePathPatterns = ["string"],
            RequiredExts = ["string"],
            SiteID = "site_id",
            SiteName = "site_name",
            SupportsAccessControl = CloudSharepointDataSourceSupportsAccessControl.True,
        };
        value.Validate();
    }

    [Fact]
    public void CloudSlackDataSourceValidationWorks()
    {
        Component value = new CloudSlackDataSource()
        {
            SlackToken = "slack_token",
            ChannelIds = "channel_ids",
            ChannelPatterns = "channel_patterns",
            ClassName = "class_name",
            EarliestDate = "earliest_date",
            EarliestDateTimestamp = 0,
            LatestDate = "latest_date",
            LatestDateTimestamp = 0,
            SupportsAccessControl = true,
        };
        value.Validate();
    }

    [Fact]
    public void CloudNotionPageDataSourceValidationWorks()
    {
        Component value = new CloudNotionPageDataSource()
        {
            IntegrationToken = "integration_token",
            ClassName = "class_name",
            DatabaseIds = "database_ids",
            PageIds = "page_ids",
            SupportsAccessControl = true,
        };
        value.Validate();
    }

    [Fact]
    public void CloudConfluenceDataSourceValidationWorks()
    {
        Component value = new CloudConfluenceDataSource()
        {
            AuthenticationMechanism = "authentication_mechanism",
            ServerUrl = "server_url",
            ApiToken = "api_token",
            ClassName = "class_name",
            Cql = "cql",
            FailureHandling = new() { SkipListFailures = true },
            IndexRestrictedPages = true,
            KeepMarkdownFormat = true,
            Label = "label",
            PageIds = "page_ids",
            SpaceKey = "space_key",
            SupportsAccessControl = true,
            SyncPermissions = true,
            UserName = "user_name",
        };
        value.Validate();
    }

    [Fact]
    public void CloudJiraDataSourceValidationWorks()
    {
        Component value = new CloudJiraDataSource()
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ApiToken = "api_token",
            ClassName = "class_name",
            CloudID = "cloud_id",
            Email = "email",
            ServerUrl = "server_url",
            SupportsAccessControl = true,
        };
        value.Validate();
    }

    [Fact]
    public void CloudJiraDataSourceV2ValidationWorks()
    {
        Component value = new CloudJiraDataSourceV2()
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ServerUrl = "server_url",
            ApiToken = "api_token",
            ApiVersion = ApiVersion.V2,
            ClassName = "class_name",
            CloudID = "cloud_id",
            Email = "email",
            Expand = "expand",
            Fields = ["string"],
            GetPermissions = true,
            RequestsPerMinute = 0,
            SupportsAccessControl = true,
        };
        value.Validate();
    }

    [Fact]
    public void CloudBoxDataSourceValidationWorks()
    {
        Component value = new CloudBoxDataSource()
        {
            AuthenticationMechanism = AuthenticationMechanism.Ccg,
            ClassName = "class_name",
            ClientID = "client_id",
            ClientSecret = "client_secret",
            DeveloperToken = "developer_token",
            EnterpriseID = "enterprise_id",
            FolderID = "folder_id",
            SupportsAccessControl = true,
            UserID = "user_id",
        };
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        Component value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudS3DataSourceSerializationRoundtripWorks()
    {
        Component value = new CloudS3DataSource()
        {
            Bucket = "bucket",
            AwsAccessID = "aws_access_id",
            AwsAccessSecret = "aws_access_secret",
            ClassName = "class_name",
            Prefix = "prefix",
            RegexPattern = "regex_pattern",
            S3EndpointUrl = "s3_endpoint_url",
            SupportsAccessControl = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudAzStorageBlobDataSourceSerializationRoundtripWorks()
    {
        Component value = new CloudAzStorageBlobDataSource()
        {
            AccountUrl = "account_url",
            ContainerName = "container_name",
            AccountKey = "account_key",
            AccountName = "account_name",
            Blob = "blob",
            ClassName = "class_name",
            ClientID = "client_id",
            ClientSecret = "client_secret",
            Prefix = "prefix",
            SupportsAccessControl = true,
            TenantID = "tenant_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudGoogleDriveDataSourceSerializationRoundtripWorks()
    {
        Component value = new CloudGoogleDriveDataSource()
        {
            FolderID = "folder_id",
            ClassName = "class_name",
            FolderName = "folder_name",
            ServiceAccountKey = new Dictionary<string, string>() { { "foo", "string" } },
            SupportsAccessControl = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudOneDriveDataSourceSerializationRoundtripWorks()
    {
        Component value = new CloudOneDriveDataSource()
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            UserPrincipalName = "user_principal_name",
            ClassName = "class_name",
            FolderID = "folder_id",
            FolderPath = "folder_path",
            RequiredExts = ["string"],
            SupportsAccessControl = SupportsAccessControl.True,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudSharepointDataSourceSerializationRoundtripWorks()
    {
        Component value = new CloudSharepointDataSource()
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            ClassName = "class_name",
            DriveName = "drive_name",
            ExcludePathPatterns = ["string"],
            FolderID = "folder_id",
            FolderPath = "folder_path",
            GetPermissions = true,
            IncludePathPatterns = ["string"],
            RequiredExts = ["string"],
            SiteID = "site_id",
            SiteName = "site_name",
            SupportsAccessControl = CloudSharepointDataSourceSupportsAccessControl.True,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudSlackDataSourceSerializationRoundtripWorks()
    {
        Component value = new CloudSlackDataSource()
        {
            SlackToken = "slack_token",
            ChannelIds = "channel_ids",
            ChannelPatterns = "channel_patterns",
            ClassName = "class_name",
            EarliestDate = "earliest_date",
            EarliestDateTimestamp = 0,
            LatestDate = "latest_date",
            LatestDateTimestamp = 0,
            SupportsAccessControl = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudNotionPageDataSourceSerializationRoundtripWorks()
    {
        Component value = new CloudNotionPageDataSource()
        {
            IntegrationToken = "integration_token",
            ClassName = "class_name",
            DatabaseIds = "database_ids",
            PageIds = "page_ids",
            SupportsAccessControl = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudConfluenceDataSourceSerializationRoundtripWorks()
    {
        Component value = new CloudConfluenceDataSource()
        {
            AuthenticationMechanism = "authentication_mechanism",
            ServerUrl = "server_url",
            ApiToken = "api_token",
            ClassName = "class_name",
            Cql = "cql",
            FailureHandling = new() { SkipListFailures = true },
            IndexRestrictedPages = true,
            KeepMarkdownFormat = true,
            Label = "label",
            PageIds = "page_ids",
            SpaceKey = "space_key",
            SupportsAccessControl = true,
            SyncPermissions = true,
            UserName = "user_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudJiraDataSourceSerializationRoundtripWorks()
    {
        Component value = new CloudJiraDataSource()
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ApiToken = "api_token",
            ClassName = "class_name",
            CloudID = "cloud_id",
            Email = "email",
            ServerUrl = "server_url",
            SupportsAccessControl = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudJiraDataSourceV2SerializationRoundtripWorks()
    {
        Component value = new CloudJiraDataSourceV2()
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ServerUrl = "server_url",
            ApiToken = "api_token",
            ApiVersion = ApiVersion.V2,
            ClassName = "class_name",
            CloudID = "cloud_id",
            Email = "email",
            Expand = "expand",
            Fields = ["string"],
            GetPermissions = true,
            RequestsPerMinute = 0,
            SupportsAccessControl = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudBoxDataSourceSerializationRoundtripWorks()
    {
        Component value = new CloudBoxDataSource()
        {
            AuthenticationMechanism = AuthenticationMechanism.Ccg,
            ClassName = "class_name",
            ClientID = "client_id",
            ClientSecret = "client_secret",
            DeveloperToken = "developer_token",
            EnterpriseID = "enterprise_id",
            FolderID = "folder_id",
            SupportsAccessControl = true,
            UserID = "user_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Component>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SourceTypeTest : TestBase
{
    [Theory]
    [InlineData(SourceType.AzureStorageBlob)]
    [InlineData(SourceType.Box)]
    [InlineData(SourceType.Confluence)]
    [InlineData(SourceType.GoogleDrive)]
    [InlineData(SourceType.Jira)]
    [InlineData(SourceType.JiraV2)]
    [InlineData(SourceType.MicrosoftOnedrive)]
    [InlineData(SourceType.MicrosoftSharepoint)]
    [InlineData(SourceType.NotionPage)]
    [InlineData(SourceType.S3)]
    [InlineData(SourceType.Slack)]
    public void Validation_Works(SourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SourceType.AzureStorageBlob)]
    [InlineData(SourceType.Box)]
    [InlineData(SourceType.Confluence)]
    [InlineData(SourceType.GoogleDrive)]
    [InlineData(SourceType.Jira)]
    [InlineData(SourceType.JiraV2)]
    [InlineData(SourceType.MicrosoftOnedrive)]
    [InlineData(SourceType.MicrosoftSharepoint)]
    [InlineData(SourceType.NotionPage)]
    [InlineData(SourceType.S3)]
    [InlineData(SourceType.Slack)]
    public void SerializationRoundtrip_Works(SourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CustomMetadataTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        CustomMetadata value = new(
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
        CustomMetadata value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        CustomMetadata value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        CustomMetadata value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        CustomMetadata value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        CustomMetadata value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        CustomMetadata value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CustomMetadata value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CustomMetadata value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        CustomMetadata value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Cancelled)]
    [InlineData(Status.Error)]
    [InlineData(Status.InProgress)]
    [InlineData(Status.NotStarted)]
    [InlineData(Status.Success)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Cancelled)]
    [InlineData(Status.Error)]
    [InlineData(Status.InProgress)]
    [InlineData(Status.NotStarted)]
    [InlineData(Status.Success)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
