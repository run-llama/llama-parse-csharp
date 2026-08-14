using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models;
using LlamaIndex.LlamaCloud.Models.DataSources;

namespace LlamaIndex.LlamaCloud.Tests.Models.DataSources;

public class DataSourceCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DataSourceCreateParams
        {
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            SourceType = SourceType.AzureStorageBlob,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
        };

        Component expectedComponent = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string expectedName = "name";
        ApiEnum<string, SourceType> expectedSourceType = SourceType.AzureStorageBlob;
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
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

        Assert.Equal(expectedComponent, parameters.Component);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedSourceType, parameters.SourceType);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.NotNull(parameters.CustomMetadata);
        Assert.Equal(expectedCustomMetadata.Count, parameters.CustomMetadata.Count);
        foreach (var item in expectedCustomMetadata)
        {
            Assert.True(parameters.CustomMetadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.CustomMetadata[item.Key]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DataSourceCreateParams
        {
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            SourceType = SourceType.AzureStorageBlob,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.CustomMetadata);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new DataSourceCreateParams
        {
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            SourceType = SourceType.AzureStorageBlob,

            OrganizationID = null,
            ProjectID = null,
            CustomMetadata = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.CustomMetadata);
        Assert.True(parameters.RawBodyData.ContainsKey("custom_metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        DataSourceCreateParams parameters = new()
        {
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            SourceType = SourceType.AzureStorageBlob,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/data-sources?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DataSourceCreateParams
        {
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            SourceType = SourceType.AzureStorageBlob,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
        };

        DataSourceCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
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
