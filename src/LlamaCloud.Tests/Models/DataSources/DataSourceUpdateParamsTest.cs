using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models;
using LlamaCloud.Models.DataSources;

namespace LlamaCloud.Tests.Models.DataSources;

public class DataSourceUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DataSourceUpdateParams
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = DataSourceUpdateParamsSourceType.AzureStorageBlob,
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            CustomMetadata = new Dictionary<string, DataSourceUpdateParamsCustomMetadata?>()
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
            Name = "name",
        };

        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, DataSourceUpdateParamsSourceType> expectedSourceType =
            DataSourceUpdateParamsSourceType.AzureStorageBlob;
        DataSourceUpdateParamsComponent expectedComponent = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        Dictionary<string, DataSourceUpdateParamsCustomMetadata?> expectedCustomMetadata = new()
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
        string expectedName = "name";

        Assert.Equal(expectedDataSourceID, parameters.DataSourceID);
        Assert.Equal(expectedSourceType, parameters.SourceType);
        Assert.Equal(expectedComponent, parameters.Component);
        Assert.NotNull(parameters.CustomMetadata);
        Assert.Equal(expectedCustomMetadata.Count, parameters.CustomMetadata.Count);
        foreach (var item in expectedCustomMetadata)
        {
            Assert.True(parameters.CustomMetadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.CustomMetadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DataSourceUpdateParams
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = DataSourceUpdateParamsSourceType.AzureStorageBlob,
        };

        Assert.Null(parameters.Component);
        Assert.False(parameters.RawBodyData.ContainsKey("component"));
        Assert.Null(parameters.CustomMetadata);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_metadata"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new DataSourceUpdateParams
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = DataSourceUpdateParamsSourceType.AzureStorageBlob,

            Component = null,
            CustomMetadata = null,
            Name = null,
        };

        Assert.Null(parameters.Component);
        Assert.True(parameters.RawBodyData.ContainsKey("component"));
        Assert.Null(parameters.CustomMetadata);
        Assert.True(parameters.RawBodyData.ContainsKey("custom_metadata"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        DataSourceUpdateParams parameters = new()
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = DataSourceUpdateParamsSourceType.AzureStorageBlob,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/data-sources/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DataSourceUpdateParams
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SourceType = DataSourceUpdateParamsSourceType.AzureStorageBlob,
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            CustomMetadata = new Dictionary<string, DataSourceUpdateParamsCustomMetadata?>()
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
            Name = "name",
        };

        DataSourceUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DataSourceUpdateParamsSourceTypeTest : TestBase
{
    [Theory]
    [InlineData(DataSourceUpdateParamsSourceType.AzureStorageBlob)]
    [InlineData(DataSourceUpdateParamsSourceType.Box)]
    [InlineData(DataSourceUpdateParamsSourceType.Confluence)]
    [InlineData(DataSourceUpdateParamsSourceType.GoogleDrive)]
    [InlineData(DataSourceUpdateParamsSourceType.Jira)]
    [InlineData(DataSourceUpdateParamsSourceType.JiraV2)]
    [InlineData(DataSourceUpdateParamsSourceType.MicrosoftOnedrive)]
    [InlineData(DataSourceUpdateParamsSourceType.MicrosoftSharepoint)]
    [InlineData(DataSourceUpdateParamsSourceType.NotionPage)]
    [InlineData(DataSourceUpdateParamsSourceType.S3)]
    [InlineData(DataSourceUpdateParamsSourceType.Slack)]
    public void Validation_Works(DataSourceUpdateParamsSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataSourceUpdateParamsSourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataSourceUpdateParamsSourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataSourceUpdateParamsSourceType.AzureStorageBlob)]
    [InlineData(DataSourceUpdateParamsSourceType.Box)]
    [InlineData(DataSourceUpdateParamsSourceType.Confluence)]
    [InlineData(DataSourceUpdateParamsSourceType.GoogleDrive)]
    [InlineData(DataSourceUpdateParamsSourceType.Jira)]
    [InlineData(DataSourceUpdateParamsSourceType.JiraV2)]
    [InlineData(DataSourceUpdateParamsSourceType.MicrosoftOnedrive)]
    [InlineData(DataSourceUpdateParamsSourceType.MicrosoftSharepoint)]
    [InlineData(DataSourceUpdateParamsSourceType.NotionPage)]
    [InlineData(DataSourceUpdateParamsSourceType.S3)]
    [InlineData(DataSourceUpdateParamsSourceType.Slack)]
    public void SerializationRoundtrip_Works(DataSourceUpdateParamsSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataSourceUpdateParamsSourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataSourceUpdateParamsSourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataSourceUpdateParamsSourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataSourceUpdateParamsSourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DataSourceUpdateParamsComponentTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        DataSourceUpdateParamsComponent value = new(
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
        DataSourceUpdateParamsComponent value = new CloudS3DataSource()
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
        DataSourceUpdateParamsComponent value = new CloudAzStorageBlobDataSource()
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
        DataSourceUpdateParamsComponent value = new CloudGoogleDriveDataSource()
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
        DataSourceUpdateParamsComponent value = new CloudOneDriveDataSource()
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
        DataSourceUpdateParamsComponent value = new CloudSharepointDataSource()
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
        DataSourceUpdateParamsComponent value = new CloudSlackDataSource()
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
        DataSourceUpdateParamsComponent value = new CloudNotionPageDataSource()
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
        DataSourceUpdateParamsComponent value = new CloudConfluenceDataSource()
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
        DataSourceUpdateParamsComponent value = new CloudJiraDataSource()
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
        DataSourceUpdateParamsComponent value = new CloudJiraDataSourceV2()
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
        DataSourceUpdateParamsComponent value = new CloudBoxDataSource()
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
        DataSourceUpdateParamsComponent value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudS3DataSourceSerializationRoundtripWorks()
    {
        DataSourceUpdateParamsComponent value = new CloudS3DataSource()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudAzStorageBlobDataSourceSerializationRoundtripWorks()
    {
        DataSourceUpdateParamsComponent value = new CloudAzStorageBlobDataSource()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudGoogleDriveDataSourceSerializationRoundtripWorks()
    {
        DataSourceUpdateParamsComponent value = new CloudGoogleDriveDataSource()
        {
            FolderID = "folder_id",
            ClassName = "class_name",
            FolderName = "folder_name",
            ServiceAccountKey = new Dictionary<string, string>() { { "foo", "string" } },
            SupportsAccessControl = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudOneDriveDataSourceSerializationRoundtripWorks()
    {
        DataSourceUpdateParamsComponent value = new CloudOneDriveDataSource()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudSharepointDataSourceSerializationRoundtripWorks()
    {
        DataSourceUpdateParamsComponent value = new CloudSharepointDataSource()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudSlackDataSourceSerializationRoundtripWorks()
    {
        DataSourceUpdateParamsComponent value = new CloudSlackDataSource()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudNotionPageDataSourceSerializationRoundtripWorks()
    {
        DataSourceUpdateParamsComponent value = new CloudNotionPageDataSource()
        {
            IntegrationToken = "integration_token",
            ClassName = "class_name",
            DatabaseIds = "database_ids",
            PageIds = "page_ids",
            SupportsAccessControl = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudConfluenceDataSourceSerializationRoundtripWorks()
    {
        DataSourceUpdateParamsComponent value = new CloudConfluenceDataSource()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudJiraDataSourceSerializationRoundtripWorks()
    {
        DataSourceUpdateParamsComponent value = new CloudJiraDataSource()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudJiraDataSourceV2SerializationRoundtripWorks()
    {
        DataSourceUpdateParamsComponent value = new CloudJiraDataSourceV2()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloudBoxDataSourceSerializationRoundtripWorks()
    {
        DataSourceUpdateParamsComponent value = new CloudBoxDataSource()
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
        var deserialized = JsonSerializer.Deserialize<DataSourceUpdateParamsComponent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataSourceUpdateParamsCustomMetadataTest : TestBase
{
    [Fact]
    public void JsonElementsValidationWorks()
    {
        DataSourceUpdateParamsCustomMetadata value = new(
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
        DataSourceUpdateParamsCustomMetadata value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        DataSourceUpdateParamsCustomMetadata value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        DataSourceUpdateParamsCustomMetadata value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        DataSourceUpdateParamsCustomMetadata value = true;
        value.Validate();
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks()
    {
        DataSourceUpdateParamsCustomMetadata value = new(
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceUpdateParamsCustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JsonElementsSerializationRoundtripWorks1()
    {
        DataSourceUpdateParamsCustomMetadata value = new(
            [JsonSerializer.Deserialize<JsonElement>("{}")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceUpdateParamsCustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        DataSourceUpdateParamsCustomMetadata value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceUpdateParamsCustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        DataSourceUpdateParamsCustomMetadata value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceUpdateParamsCustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        DataSourceUpdateParamsCustomMetadata value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataSourceUpdateParamsCustomMetadata>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
