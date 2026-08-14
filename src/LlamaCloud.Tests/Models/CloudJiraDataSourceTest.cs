using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models;

namespace LlamaCloud.Tests.Models;

public class CloudJiraDataSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudJiraDataSource
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

        string expectedAuthenticationMechanism = "authentication_mechanism";
        string expectedQuery = "query";
        string expectedApiToken = "api_token";
        string expectedClassName = "class_name";
        string expectedCloudID = "cloud_id";
        string expectedEmail = "email";
        string expectedServerUrl = "server_url";
        bool expectedSupportsAccessControl = true;

        Assert.Equal(expectedAuthenticationMechanism, model.AuthenticationMechanism);
        Assert.Equal(expectedQuery, model.Query);
        Assert.Equal(expectedApiToken, model.ApiToken);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedCloudID, model.CloudID);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedServerUrl, model.ServerUrl);
        Assert.Equal(expectedSupportsAccessControl, model.SupportsAccessControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudJiraDataSource
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudJiraDataSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudJiraDataSource
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudJiraDataSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAuthenticationMechanism = "authentication_mechanism";
        string expectedQuery = "query";
        string expectedApiToken = "api_token";
        string expectedClassName = "class_name";
        string expectedCloudID = "cloud_id";
        string expectedEmail = "email";
        string expectedServerUrl = "server_url";
        bool expectedSupportsAccessControl = true;

        Assert.Equal(expectedAuthenticationMechanism, deserialized.AuthenticationMechanism);
        Assert.Equal(expectedQuery, deserialized.Query);
        Assert.Equal(expectedApiToken, deserialized.ApiToken);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedCloudID, deserialized.CloudID);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedServerUrl, deserialized.ServerUrl);
        Assert.Equal(expectedSupportsAccessControl, deserialized.SupportsAccessControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudJiraDataSource
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudJiraDataSource
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ApiToken = "api_token",
            CloudID = "cloud_id",
            Email = "email",
            ServerUrl = "server_url",
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.SupportsAccessControl);
        Assert.False(model.RawData.ContainsKey("supports_access_control"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudJiraDataSource
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ApiToken = "api_token",
            CloudID = "cloud_id",
            Email = "email",
            ServerUrl = "server_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudJiraDataSource
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ApiToken = "api_token",
            CloudID = "cloud_id",
            Email = "email",
            ServerUrl = "server_url",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            SupportsAccessControl = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.SupportsAccessControl);
        Assert.False(model.RawData.ContainsKey("supports_access_control"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudJiraDataSource
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ApiToken = "api_token",
            CloudID = "cloud_id",
            Email = "email",
            ServerUrl = "server_url",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            SupportsAccessControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudJiraDataSource
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ClassName = "class_name",
            SupportsAccessControl = true,
        };

        Assert.Null(model.ApiToken);
        Assert.False(model.RawData.ContainsKey("api_token"));
        Assert.Null(model.CloudID);
        Assert.False(model.RawData.ContainsKey("cloud_id"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.ServerUrl);
        Assert.False(model.RawData.ContainsKey("server_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudJiraDataSource
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ClassName = "class_name",
            SupportsAccessControl = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudJiraDataSource
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ClassName = "class_name",
            SupportsAccessControl = true,

            ApiToken = null,
            CloudID = null,
            Email = null,
            ServerUrl = null,
        };

        Assert.Null(model.ApiToken);
        Assert.True(model.RawData.ContainsKey("api_token"));
        Assert.Null(model.CloudID);
        Assert.True(model.RawData.ContainsKey("cloud_id"));
        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
        Assert.Null(model.ServerUrl);
        Assert.True(model.RawData.ContainsKey("server_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudJiraDataSource
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ClassName = "class_name",
            SupportsAccessControl = true,

            ApiToken = null,
            CloudID = null,
            Email = null,
            ServerUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudJiraDataSource
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

        CloudJiraDataSource copied = new(model);

        Assert.Equal(model, copied);
    }
}
