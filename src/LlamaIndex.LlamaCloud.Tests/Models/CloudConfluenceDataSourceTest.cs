using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models;

namespace LlamaIndex.LlamaCloud.Tests.Models;

public class CloudConfluenceDataSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudConfluenceDataSource
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

        string expectedAuthenticationMechanism = "authentication_mechanism";
        string expectedServerUrl = "server_url";
        string expectedApiToken = "api_token";
        string expectedClassName = "class_name";
        string expectedCql = "cql";
        FailureHandlingConfig expectedFailureHandling = new() { SkipListFailures = true };
        bool expectedIndexRestrictedPages = true;
        bool expectedKeepMarkdownFormat = true;
        string expectedLabel = "label";
        string expectedPageIds = "page_ids";
        string expectedSpaceKey = "space_key";
        bool expectedSupportsAccessControl = true;
        bool expectedSyncPermissions = true;
        string expectedUserName = "user_name";

        Assert.Equal(expectedAuthenticationMechanism, model.AuthenticationMechanism);
        Assert.Equal(expectedServerUrl, model.ServerUrl);
        Assert.Equal(expectedApiToken, model.ApiToken);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedCql, model.Cql);
        Assert.Equal(expectedFailureHandling, model.FailureHandling);
        Assert.Equal(expectedIndexRestrictedPages, model.IndexRestrictedPages);
        Assert.Equal(expectedKeepMarkdownFormat, model.KeepMarkdownFormat);
        Assert.Equal(expectedLabel, model.Label);
        Assert.Equal(expectedPageIds, model.PageIds);
        Assert.Equal(expectedSpaceKey, model.SpaceKey);
        Assert.Equal(expectedSupportsAccessControl, model.SupportsAccessControl);
        Assert.Equal(expectedSyncPermissions, model.SyncPermissions);
        Assert.Equal(expectedUserName, model.UserName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudConfluenceDataSource
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudConfluenceDataSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudConfluenceDataSource
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudConfluenceDataSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAuthenticationMechanism = "authentication_mechanism";
        string expectedServerUrl = "server_url";
        string expectedApiToken = "api_token";
        string expectedClassName = "class_name";
        string expectedCql = "cql";
        FailureHandlingConfig expectedFailureHandling = new() { SkipListFailures = true };
        bool expectedIndexRestrictedPages = true;
        bool expectedKeepMarkdownFormat = true;
        string expectedLabel = "label";
        string expectedPageIds = "page_ids";
        string expectedSpaceKey = "space_key";
        bool expectedSupportsAccessControl = true;
        bool expectedSyncPermissions = true;
        string expectedUserName = "user_name";

        Assert.Equal(expectedAuthenticationMechanism, deserialized.AuthenticationMechanism);
        Assert.Equal(expectedServerUrl, deserialized.ServerUrl);
        Assert.Equal(expectedApiToken, deserialized.ApiToken);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedCql, deserialized.Cql);
        Assert.Equal(expectedFailureHandling, deserialized.FailureHandling);
        Assert.Equal(expectedIndexRestrictedPages, deserialized.IndexRestrictedPages);
        Assert.Equal(expectedKeepMarkdownFormat, deserialized.KeepMarkdownFormat);
        Assert.Equal(expectedLabel, deserialized.Label);
        Assert.Equal(expectedPageIds, deserialized.PageIds);
        Assert.Equal(expectedSpaceKey, deserialized.SpaceKey);
        Assert.Equal(expectedSupportsAccessControl, deserialized.SupportsAccessControl);
        Assert.Equal(expectedSyncPermissions, deserialized.SyncPermissions);
        Assert.Equal(expectedUserName, deserialized.UserName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudConfluenceDataSource
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudConfluenceDataSource
        {
            AuthenticationMechanism = "authentication_mechanism",
            ServerUrl = "server_url",
            ApiToken = "api_token",
            Cql = "cql",
            Label = "label",
            PageIds = "page_ids",
            SpaceKey = "space_key",
            UserName = "user_name",
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.FailureHandling);
        Assert.False(model.RawData.ContainsKey("failure_handling"));
        Assert.Null(model.IndexRestrictedPages);
        Assert.False(model.RawData.ContainsKey("index_restricted_pages"));
        Assert.Null(model.KeepMarkdownFormat);
        Assert.False(model.RawData.ContainsKey("keep_markdown_format"));
        Assert.Null(model.SupportsAccessControl);
        Assert.False(model.RawData.ContainsKey("supports_access_control"));
        Assert.Null(model.SyncPermissions);
        Assert.False(model.RawData.ContainsKey("sync_permissions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudConfluenceDataSource
        {
            AuthenticationMechanism = "authentication_mechanism",
            ServerUrl = "server_url",
            ApiToken = "api_token",
            Cql = "cql",
            Label = "label",
            PageIds = "page_ids",
            SpaceKey = "space_key",
            UserName = "user_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudConfluenceDataSource
        {
            AuthenticationMechanism = "authentication_mechanism",
            ServerUrl = "server_url",
            ApiToken = "api_token",
            Cql = "cql",
            Label = "label",
            PageIds = "page_ids",
            SpaceKey = "space_key",
            UserName = "user_name",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            FailureHandling = null,
            IndexRestrictedPages = null,
            KeepMarkdownFormat = null,
            SupportsAccessControl = null,
            SyncPermissions = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.FailureHandling);
        Assert.False(model.RawData.ContainsKey("failure_handling"));
        Assert.Null(model.IndexRestrictedPages);
        Assert.False(model.RawData.ContainsKey("index_restricted_pages"));
        Assert.Null(model.KeepMarkdownFormat);
        Assert.False(model.RawData.ContainsKey("keep_markdown_format"));
        Assert.Null(model.SupportsAccessControl);
        Assert.False(model.RawData.ContainsKey("supports_access_control"));
        Assert.Null(model.SyncPermissions);
        Assert.False(model.RawData.ContainsKey("sync_permissions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudConfluenceDataSource
        {
            AuthenticationMechanism = "authentication_mechanism",
            ServerUrl = "server_url",
            ApiToken = "api_token",
            Cql = "cql",
            Label = "label",
            PageIds = "page_ids",
            SpaceKey = "space_key",
            UserName = "user_name",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            FailureHandling = null,
            IndexRestrictedPages = null,
            KeepMarkdownFormat = null,
            SupportsAccessControl = null,
            SyncPermissions = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudConfluenceDataSource
        {
            AuthenticationMechanism = "authentication_mechanism",
            ServerUrl = "server_url",
            ClassName = "class_name",
            FailureHandling = new() { SkipListFailures = true },
            IndexRestrictedPages = true,
            KeepMarkdownFormat = true,
            SupportsAccessControl = true,
            SyncPermissions = true,
        };

        Assert.Null(model.ApiToken);
        Assert.False(model.RawData.ContainsKey("api_token"));
        Assert.Null(model.Cql);
        Assert.False(model.RawData.ContainsKey("cql"));
        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
        Assert.Null(model.PageIds);
        Assert.False(model.RawData.ContainsKey("page_ids"));
        Assert.Null(model.SpaceKey);
        Assert.False(model.RawData.ContainsKey("space_key"));
        Assert.Null(model.UserName);
        Assert.False(model.RawData.ContainsKey("user_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudConfluenceDataSource
        {
            AuthenticationMechanism = "authentication_mechanism",
            ServerUrl = "server_url",
            ClassName = "class_name",
            FailureHandling = new() { SkipListFailures = true },
            IndexRestrictedPages = true,
            KeepMarkdownFormat = true,
            SupportsAccessControl = true,
            SyncPermissions = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudConfluenceDataSource
        {
            AuthenticationMechanism = "authentication_mechanism",
            ServerUrl = "server_url",
            ClassName = "class_name",
            FailureHandling = new() { SkipListFailures = true },
            IndexRestrictedPages = true,
            KeepMarkdownFormat = true,
            SupportsAccessControl = true,
            SyncPermissions = true,

            ApiToken = null,
            Cql = null,
            Label = null,
            PageIds = null,
            SpaceKey = null,
            UserName = null,
        };

        Assert.Null(model.ApiToken);
        Assert.True(model.RawData.ContainsKey("api_token"));
        Assert.Null(model.Cql);
        Assert.True(model.RawData.ContainsKey("cql"));
        Assert.Null(model.Label);
        Assert.True(model.RawData.ContainsKey("label"));
        Assert.Null(model.PageIds);
        Assert.True(model.RawData.ContainsKey("page_ids"));
        Assert.Null(model.SpaceKey);
        Assert.True(model.RawData.ContainsKey("space_key"));
        Assert.Null(model.UserName);
        Assert.True(model.RawData.ContainsKey("user_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudConfluenceDataSource
        {
            AuthenticationMechanism = "authentication_mechanism",
            ServerUrl = "server_url",
            ClassName = "class_name",
            FailureHandling = new() { SkipListFailures = true },
            IndexRestrictedPages = true,
            KeepMarkdownFormat = true,
            SupportsAccessControl = true,
            SyncPermissions = true,

            ApiToken = null,
            Cql = null,
            Label = null,
            PageIds = null,
            SpaceKey = null,
            UserName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudConfluenceDataSource
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

        CloudConfluenceDataSource copied = new(model);

        Assert.Equal(model, copied);
    }
}
