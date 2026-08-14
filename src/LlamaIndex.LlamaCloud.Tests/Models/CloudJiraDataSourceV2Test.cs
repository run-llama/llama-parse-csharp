using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models;

namespace LlamaIndex.LlamaCloud.Tests.Models;

public class CloudJiraDataSourceV2Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudJiraDataSourceV2
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

        string expectedAuthenticationMechanism = "authentication_mechanism";
        string expectedQuery = "query";
        string expectedServerUrl = "server_url";
        string expectedApiToken = "api_token";
        ApiEnum<string, ApiVersion> expectedApiVersion = ApiVersion.V2;
        string expectedClassName = "class_name";
        string expectedCloudID = "cloud_id";
        string expectedEmail = "email";
        string expectedExpand = "expand";
        List<string> expectedFields = ["string"];
        bool expectedGetPermissions = true;
        long expectedRequestsPerMinute = 0;
        bool expectedSupportsAccessControl = true;

        Assert.Equal(expectedAuthenticationMechanism, model.AuthenticationMechanism);
        Assert.Equal(expectedQuery, model.Query);
        Assert.Equal(expectedServerUrl, model.ServerUrl);
        Assert.Equal(expectedApiToken, model.ApiToken);
        Assert.Equal(expectedApiVersion, model.ApiVersion);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedCloudID, model.CloudID);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedExpand, model.Expand);
        Assert.NotNull(model.Fields);
        Assert.Equal(expectedFields.Count, model.Fields.Count);
        for (int i = 0; i < expectedFields.Count; i++)
        {
            Assert.Equal(expectedFields[i], model.Fields[i]);
        }
        Assert.Equal(expectedGetPermissions, model.GetPermissions);
        Assert.Equal(expectedRequestsPerMinute, model.RequestsPerMinute);
        Assert.Equal(expectedSupportsAccessControl, model.SupportsAccessControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudJiraDataSourceV2
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudJiraDataSourceV2>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudJiraDataSourceV2
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudJiraDataSourceV2>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAuthenticationMechanism = "authentication_mechanism";
        string expectedQuery = "query";
        string expectedServerUrl = "server_url";
        string expectedApiToken = "api_token";
        ApiEnum<string, ApiVersion> expectedApiVersion = ApiVersion.V2;
        string expectedClassName = "class_name";
        string expectedCloudID = "cloud_id";
        string expectedEmail = "email";
        string expectedExpand = "expand";
        List<string> expectedFields = ["string"];
        bool expectedGetPermissions = true;
        long expectedRequestsPerMinute = 0;
        bool expectedSupportsAccessControl = true;

        Assert.Equal(expectedAuthenticationMechanism, deserialized.AuthenticationMechanism);
        Assert.Equal(expectedQuery, deserialized.Query);
        Assert.Equal(expectedServerUrl, deserialized.ServerUrl);
        Assert.Equal(expectedApiToken, deserialized.ApiToken);
        Assert.Equal(expectedApiVersion, deserialized.ApiVersion);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedCloudID, deserialized.CloudID);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedExpand, deserialized.Expand);
        Assert.NotNull(deserialized.Fields);
        Assert.Equal(expectedFields.Count, deserialized.Fields.Count);
        for (int i = 0; i < expectedFields.Count; i++)
        {
            Assert.Equal(expectedFields[i], deserialized.Fields[i]);
        }
        Assert.Equal(expectedGetPermissions, deserialized.GetPermissions);
        Assert.Equal(expectedRequestsPerMinute, deserialized.RequestsPerMinute);
        Assert.Equal(expectedSupportsAccessControl, deserialized.SupportsAccessControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudJiraDataSourceV2
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudJiraDataSourceV2
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ServerUrl = "server_url",
            ApiToken = "api_token",
            CloudID = "cloud_id",
            Email = "email",
            Expand = "expand",
            Fields = ["string"],
            RequestsPerMinute = 0,
        };

        Assert.Null(model.ApiVersion);
        Assert.False(model.RawData.ContainsKey("api_version"));
        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.GetPermissions);
        Assert.False(model.RawData.ContainsKey("get_permissions"));
        Assert.Null(model.SupportsAccessControl);
        Assert.False(model.RawData.ContainsKey("supports_access_control"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudJiraDataSourceV2
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ServerUrl = "server_url",
            ApiToken = "api_token",
            CloudID = "cloud_id",
            Email = "email",
            Expand = "expand",
            Fields = ["string"],
            RequestsPerMinute = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudJiraDataSourceV2
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ServerUrl = "server_url",
            ApiToken = "api_token",
            CloudID = "cloud_id",
            Email = "email",
            Expand = "expand",
            Fields = ["string"],
            RequestsPerMinute = 0,

            // Null should be interpreted as omitted for these properties
            ApiVersion = null,
            ClassName = null,
            GetPermissions = null,
            SupportsAccessControl = null,
        };

        Assert.Null(model.ApiVersion);
        Assert.False(model.RawData.ContainsKey("api_version"));
        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.GetPermissions);
        Assert.False(model.RawData.ContainsKey("get_permissions"));
        Assert.Null(model.SupportsAccessControl);
        Assert.False(model.RawData.ContainsKey("supports_access_control"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudJiraDataSourceV2
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ServerUrl = "server_url",
            ApiToken = "api_token",
            CloudID = "cloud_id",
            Email = "email",
            Expand = "expand",
            Fields = ["string"],
            RequestsPerMinute = 0,

            // Null should be interpreted as omitted for these properties
            ApiVersion = null,
            ClassName = null,
            GetPermissions = null,
            SupportsAccessControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudJiraDataSourceV2
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ServerUrl = "server_url",
            ApiVersion = ApiVersion.V2,
            ClassName = "class_name",
            GetPermissions = true,
            SupportsAccessControl = true,
        };

        Assert.Null(model.ApiToken);
        Assert.False(model.RawData.ContainsKey("api_token"));
        Assert.Null(model.CloudID);
        Assert.False(model.RawData.ContainsKey("cloud_id"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Expand);
        Assert.False(model.RawData.ContainsKey("expand"));
        Assert.Null(model.Fields);
        Assert.False(model.RawData.ContainsKey("fields"));
        Assert.Null(model.RequestsPerMinute);
        Assert.False(model.RawData.ContainsKey("requests_per_minute"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudJiraDataSourceV2
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ServerUrl = "server_url",
            ApiVersion = ApiVersion.V2,
            ClassName = "class_name",
            GetPermissions = true,
            SupportsAccessControl = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudJiraDataSourceV2
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ServerUrl = "server_url",
            ApiVersion = ApiVersion.V2,
            ClassName = "class_name",
            GetPermissions = true,
            SupportsAccessControl = true,

            ApiToken = null,
            CloudID = null,
            Email = null,
            Expand = null,
            Fields = null,
            RequestsPerMinute = null,
        };

        Assert.Null(model.ApiToken);
        Assert.True(model.RawData.ContainsKey("api_token"));
        Assert.Null(model.CloudID);
        Assert.True(model.RawData.ContainsKey("cloud_id"));
        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
        Assert.Null(model.Expand);
        Assert.True(model.RawData.ContainsKey("expand"));
        Assert.Null(model.Fields);
        Assert.True(model.RawData.ContainsKey("fields"));
        Assert.Null(model.RequestsPerMinute);
        Assert.True(model.RawData.ContainsKey("requests_per_minute"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudJiraDataSourceV2
        {
            AuthenticationMechanism = "authentication_mechanism",
            Query = "query",
            ServerUrl = "server_url",
            ApiVersion = ApiVersion.V2,
            ClassName = "class_name",
            GetPermissions = true,
            SupportsAccessControl = true,

            ApiToken = null,
            CloudID = null,
            Email = null,
            Expand = null,
            Fields = null,
            RequestsPerMinute = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudJiraDataSourceV2
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

        CloudJiraDataSourceV2 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ApiVersionTest : TestBase
{
    [Theory]
    [InlineData(ApiVersion.V2)]
    [InlineData(ApiVersion.V3)]
    public void Validation_Works(ApiVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiVersion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApiVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ApiVersion.V2)]
    [InlineData(ApiVersion.V3)]
    public void SerializationRoundtrip_Works(ApiVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiVersion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApiVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
