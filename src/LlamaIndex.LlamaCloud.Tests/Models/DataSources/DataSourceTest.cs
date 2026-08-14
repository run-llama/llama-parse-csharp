using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models;
using LlamaIndex.LlamaCloud.Models.DataSources;

namespace LlamaIndex.LlamaCloud.Tests.Models.DataSources;

public class DataSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = DataSourceSourceType.AzureStorageBlob,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomMetadata = new Dictionary<string, DataSourceCustomMetadata?>()
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
            VersionMetadata = new() { ReaderVersion = ReaderVersion.V1_0 },
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DataSourceComponent expectedComponent = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string expectedName = "name";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, DataSourceSourceType> expectedSourceType =
            DataSourceSourceType.AzureStorageBlob;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, DataSourceCustomMetadata?> expectedCustomMetadata = new()
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
        DataSourceReaderVersionMetadata expectedVersionMetadata = new()
        {
            ReaderVersion = ReaderVersion.V1_0,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedComponent, model.Component);
        Assert.Equal(expectedName, model.Name);
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
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVersionMetadata, model.VersionMetadata);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = DataSourceSourceType.AzureStorageBlob,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomMetadata = new Dictionary<string, DataSourceCustomMetadata?>()
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
            VersionMetadata = new() { ReaderVersion = ReaderVersion.V1_0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = DataSourceSourceType.AzureStorageBlob,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomMetadata = new Dictionary<string, DataSourceCustomMetadata?>()
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
            VersionMetadata = new() { ReaderVersion = ReaderVersion.V1_0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DataSourceComponent expectedComponent = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string expectedName = "name";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, DataSourceSourceType> expectedSourceType =
            DataSourceSourceType.AzureStorageBlob;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, DataSourceCustomMetadata?> expectedCustomMetadata = new()
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
        DataSourceReaderVersionMetadata expectedVersionMetadata = new()
        {
            ReaderVersion = ReaderVersion.V1_0,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedComponent, deserialized.Component);
        Assert.Equal(expectedName, deserialized.Name);
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
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVersionMetadata, deserialized.VersionMetadata);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = DataSourceSourceType.AzureStorageBlob,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomMetadata = new Dictionary<string, DataSourceCustomMetadata?>()
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
            VersionMetadata = new() { ReaderVersion = ReaderVersion.V1_0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = DataSourceSourceType.AzureStorageBlob,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CustomMetadata);
        Assert.False(model.RawData.ContainsKey("custom_metadata"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.VersionMetadata);
        Assert.False(model.RawData.ContainsKey("version_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = DataSourceSourceType.AzureStorageBlob,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = DataSourceSourceType.AzureStorageBlob,

            CreatedAt = null,
            CustomMetadata = null,
            UpdatedAt = null,
            VersionMetadata = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.CustomMetadata);
        Assert.True(model.RawData.ContainsKey("custom_metadata"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.VersionMetadata);
        Assert.True(model.RawData.ContainsKey("version_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = DataSourceSourceType.AzureStorageBlob,

            CreatedAt = null,
            CustomMetadata = null,
            UpdatedAt = null,
            VersionMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataSource
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = DataSourceSourceType.AzureStorageBlob,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomMetadata = new Dictionary<string, DataSourceCustomMetadata?>()
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
            VersionMetadata = new() { ReaderVersion = ReaderVersion.V1_0 },
        };

        DataSource copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataSourceComponentTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        DataSourceComponent value = new(
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
        DataSourceComponent value = new CloudS3DataSource()
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
        DataSourceComponent value = new CloudAzStorageBlobDataSource()
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
        DataSourceComponent value = new CloudGoogleDriveDataSource()
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
        DataSourceComponent value = new CloudOneDriveDataSource()
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
        DataSourceComponent value = new CloudSharepointDataSource()
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
        DataSourceComponent value = new CloudSlackDataSource()
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
        DataSourceComponent value = new CloudNotionPageDataSource()
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
        DataSourceComponent value = new CloudConfluenceDataSource()
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
        DataSourceComponent value = new CloudJiraDataSource()
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
        DataSourceComponent value = new CloudJiraDataSourceV2()
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
        DataSourceComponent value = new CloudBoxDataSource()
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
        DataSourceComponent value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudS3DataSourceSerializationRoundtripWorks()
    {
        DataSourceComponent value = new CloudS3DataSource()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudAzStorageBlobDataSourceSerializationRoundtripWorks()
    {
        DataSourceComponent value = new CloudAzStorageBlobDataSource()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudGoogleDriveDataSourceSerializationRoundtripWorks()
    {
        DataSourceComponent value = new CloudGoogleDriveDataSource()
        {
            FolderID = "folder_id",
            ClassName = "class_name",
            FolderName = "folder_name",
            ServiceAccountKey = new Dictionary<string, string>() { { "foo", "string" } },
            SupportsAccessControl = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudOneDriveDataSourceSerializationRoundtripWorks()
    {
        DataSourceComponent value = new CloudOneDriveDataSource()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudSharepointDataSourceSerializationRoundtripWorks()
    {
        DataSourceComponent value = new CloudSharepointDataSource()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudSlackDataSourceSerializationRoundtripWorks()
    {
        DataSourceComponent value = new CloudSlackDataSource()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudNotionPageDataSourceSerializationRoundtripWorks()
    {
        DataSourceComponent value = new CloudNotionPageDataSource()
        {
            IntegrationToken = "integration_token",
            ClassName = "class_name",
            DatabaseIds = "database_ids",
            PageIds = "page_ids",
            SupportsAccessControl = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudConfluenceDataSourceSerializationRoundtripWorks()
    {
        DataSourceComponent value = new CloudConfluenceDataSource()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudJiraDataSourceSerializationRoundtripWorks()
    {
        DataSourceComponent value = new CloudJiraDataSource()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudJiraDataSourceV2SerializationRoundtripWorks()
    {
        DataSourceComponent value = new CloudJiraDataSourceV2()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudBoxDataSourceSerializationRoundtripWorks()
    {
        DataSourceComponent value = new CloudBoxDataSource()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataSourceSourceTypeTest : TestBase
{
    [Theory]
    [InlineData(DataSourceSourceType.AzureStorageBlob)]
    [InlineData(DataSourceSourceType.Box)]
    [InlineData(DataSourceSourceType.Confluence)]
    [InlineData(DataSourceSourceType.GoogleDrive)]
    [InlineData(DataSourceSourceType.Jira)]
    [InlineData(DataSourceSourceType.JiraV2)]
    [InlineData(DataSourceSourceType.MicrosoftOnedrive)]
    [InlineData(DataSourceSourceType.MicrosoftSharepoint)]
    [InlineData(DataSourceSourceType.NotionPage)]
    [InlineData(DataSourceSourceType.S3)]
    [InlineData(DataSourceSourceType.Slack)]
    public void Validation_Works(DataSourceSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataSourceSourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataSourceSourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataSourceSourceType.AzureStorageBlob)]
    [InlineData(DataSourceSourceType.Box)]
    [InlineData(DataSourceSourceType.Confluence)]
    [InlineData(DataSourceSourceType.GoogleDrive)]
    [InlineData(DataSourceSourceType.Jira)]
    [InlineData(DataSourceSourceType.JiraV2)]
    [InlineData(DataSourceSourceType.MicrosoftOnedrive)]
    [InlineData(DataSourceSourceType.MicrosoftSharepoint)]
    [InlineData(DataSourceSourceType.NotionPage)]
    [InlineData(DataSourceSourceType.S3)]
    [InlineData(DataSourceSourceType.Slack)]
    public void SerializationRoundtrip_Works(DataSourceSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataSourceSourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataSourceSourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataSourceSourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataSourceSourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataSourceCustomMetadataTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        DataSourceCustomMetadata value = new(
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
        DataSourceCustomMetadata value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        DataSourceCustomMetadata value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        DataSourceCustomMetadata value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        DataSourceCustomMetadata value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        DataSourceCustomMetadata value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceCustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        DataSourceCustomMetadata value = new([JsonSerializer.Deserialize<JsonElement>("{}")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceCustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        DataSourceCustomMetadata value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceCustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        DataSourceCustomMetadata value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceCustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        DataSourceCustomMetadata value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceCustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
