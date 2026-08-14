using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models;

namespace LlamaIndex.LlamaCloud.Tests.Models;

public class CloudBoxDataSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudBoxDataSource
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

        ApiEnum<string, AuthenticationMechanism> expectedAuthenticationMechanism =
            AuthenticationMechanism.Ccg;
        string expectedClassName = "class_name";
        string expectedClientID = "client_id";
        string expectedClientSecret = "client_secret";
        string expectedDeveloperToken = "developer_token";
        string expectedEnterpriseID = "enterprise_id";
        string expectedFolderID = "folder_id";
        bool expectedSupportsAccessControl = true;
        string expectedUserID = "user_id";

        Assert.Equal(expectedAuthenticationMechanism, model.AuthenticationMechanism);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedClientID, model.ClientID);
        Assert.Equal(expectedClientSecret, model.ClientSecret);
        Assert.Equal(expectedDeveloperToken, model.DeveloperToken);
        Assert.Equal(expectedEnterpriseID, model.EnterpriseID);
        Assert.Equal(expectedFolderID, model.FolderID);
        Assert.Equal(expectedSupportsAccessControl, model.SupportsAccessControl);
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudBoxDataSource
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudBoxDataSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudBoxDataSource
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudBoxDataSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AuthenticationMechanism> expectedAuthenticationMechanism =
            AuthenticationMechanism.Ccg;
        string expectedClassName = "class_name";
        string expectedClientID = "client_id";
        string expectedClientSecret = "client_secret";
        string expectedDeveloperToken = "developer_token";
        string expectedEnterpriseID = "enterprise_id";
        string expectedFolderID = "folder_id";
        bool expectedSupportsAccessControl = true;
        string expectedUserID = "user_id";

        Assert.Equal(expectedAuthenticationMechanism, deserialized.AuthenticationMechanism);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedClientID, deserialized.ClientID);
        Assert.Equal(expectedClientSecret, deserialized.ClientSecret);
        Assert.Equal(expectedDeveloperToken, deserialized.DeveloperToken);
        Assert.Equal(expectedEnterpriseID, deserialized.EnterpriseID);
        Assert.Equal(expectedFolderID, deserialized.FolderID);
        Assert.Equal(expectedSupportsAccessControl, deserialized.SupportsAccessControl);
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudBoxDataSource
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudBoxDataSource
        {
            AuthenticationMechanism = AuthenticationMechanism.Ccg,
            ClientID = "client_id",
            ClientSecret = "client_secret",
            DeveloperToken = "developer_token",
            EnterpriseID = "enterprise_id",
            FolderID = "folder_id",
            UserID = "user_id",
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.SupportsAccessControl);
        Assert.False(model.RawData.ContainsKey("supports_access_control"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudBoxDataSource
        {
            AuthenticationMechanism = AuthenticationMechanism.Ccg,
            ClientID = "client_id",
            ClientSecret = "client_secret",
            DeveloperToken = "developer_token",
            EnterpriseID = "enterprise_id",
            FolderID = "folder_id",
            UserID = "user_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudBoxDataSource
        {
            AuthenticationMechanism = AuthenticationMechanism.Ccg,
            ClientID = "client_id",
            ClientSecret = "client_secret",
            DeveloperToken = "developer_token",
            EnterpriseID = "enterprise_id",
            FolderID = "folder_id",
            UserID = "user_id",

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
        var model = new CloudBoxDataSource
        {
            AuthenticationMechanism = AuthenticationMechanism.Ccg,
            ClientID = "client_id",
            ClientSecret = "client_secret",
            DeveloperToken = "developer_token",
            EnterpriseID = "enterprise_id",
            FolderID = "folder_id",
            UserID = "user_id",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            SupportsAccessControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudBoxDataSource
        {
            AuthenticationMechanism = AuthenticationMechanism.Ccg,
            ClassName = "class_name",
            SupportsAccessControl = true,
        };

        Assert.Null(model.ClientID);
        Assert.False(model.RawData.ContainsKey("client_id"));
        Assert.Null(model.ClientSecret);
        Assert.False(model.RawData.ContainsKey("client_secret"));
        Assert.Null(model.DeveloperToken);
        Assert.False(model.RawData.ContainsKey("developer_token"));
        Assert.Null(model.EnterpriseID);
        Assert.False(model.RawData.ContainsKey("enterprise_id"));
        Assert.Null(model.FolderID);
        Assert.False(model.RawData.ContainsKey("folder_id"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudBoxDataSource
        {
            AuthenticationMechanism = AuthenticationMechanism.Ccg,
            ClassName = "class_name",
            SupportsAccessControl = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudBoxDataSource
        {
            AuthenticationMechanism = AuthenticationMechanism.Ccg,
            ClassName = "class_name",
            SupportsAccessControl = true,

            ClientID = null,
            ClientSecret = null,
            DeveloperToken = null,
            EnterpriseID = null,
            FolderID = null,
            UserID = null,
        };

        Assert.Null(model.ClientID);
        Assert.True(model.RawData.ContainsKey("client_id"));
        Assert.Null(model.ClientSecret);
        Assert.True(model.RawData.ContainsKey("client_secret"));
        Assert.Null(model.DeveloperToken);
        Assert.True(model.RawData.ContainsKey("developer_token"));
        Assert.Null(model.EnterpriseID);
        Assert.True(model.RawData.ContainsKey("enterprise_id"));
        Assert.Null(model.FolderID);
        Assert.True(model.RawData.ContainsKey("folder_id"));
        Assert.Null(model.UserID);
        Assert.True(model.RawData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudBoxDataSource
        {
            AuthenticationMechanism = AuthenticationMechanism.Ccg,
            ClassName = "class_name",
            SupportsAccessControl = true,

            ClientID = null,
            ClientSecret = null,
            DeveloperToken = null,
            EnterpriseID = null,
            FolderID = null,
            UserID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudBoxDataSource
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

        CloudBoxDataSource copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AuthenticationMechanismTest : TestBase
{
    [Theory]
    [InlineData(AuthenticationMechanism.Ccg)]
    [InlineData(AuthenticationMechanism.DeveloperToken)]
    public void Validation_Works(AuthenticationMechanism rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuthenticationMechanism> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuthenticationMechanism>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AuthenticationMechanism.Ccg)]
    [InlineData(AuthenticationMechanism.DeveloperToken)]
    public void SerializationRoundtrip_Works(AuthenticationMechanism rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AuthenticationMechanism> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuthenticationMechanism>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AuthenticationMechanism>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AuthenticationMechanism>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
