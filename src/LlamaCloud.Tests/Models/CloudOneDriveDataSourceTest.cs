using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models;

namespace LlamaCloud.Tests.Models;

public class CloudOneDriveDataSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudOneDriveDataSource
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

        string expectedClientID = "client_id";
        string expectedClientSecret = "client_secret";
        string expectedTenantID = "tenant_id";
        string expectedUserPrincipalName = "user_principal_name";
        string expectedClassName = "class_name";
        string expectedFolderID = "folder_id";
        string expectedFolderPath = "folder_path";
        List<string> expectedRequiredExts = ["string"];
        ApiEnum<bool, SupportsAccessControl> expectedSupportsAccessControl =
            SupportsAccessControl.True;

        Assert.Equal(expectedClientID, model.ClientID);
        Assert.Equal(expectedClientSecret, model.ClientSecret);
        Assert.Equal(expectedTenantID, model.TenantID);
        Assert.Equal(expectedUserPrincipalName, model.UserPrincipalName);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedFolderID, model.FolderID);
        Assert.Equal(expectedFolderPath, model.FolderPath);
        Assert.NotNull(model.RequiredExts);
        Assert.Equal(expectedRequiredExts.Count, model.RequiredExts.Count);
        for (int i = 0; i < expectedRequiredExts.Count; i++)
        {
            Assert.Equal(expectedRequiredExts[i], model.RequiredExts[i]);
        }
        Assert.Equal(expectedSupportsAccessControl, model.SupportsAccessControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudOneDriveDataSource
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudOneDriveDataSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudOneDriveDataSource
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudOneDriveDataSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClientID = "client_id";
        string expectedClientSecret = "client_secret";
        string expectedTenantID = "tenant_id";
        string expectedUserPrincipalName = "user_principal_name";
        string expectedClassName = "class_name";
        string expectedFolderID = "folder_id";
        string expectedFolderPath = "folder_path";
        List<string> expectedRequiredExts = ["string"];
        ApiEnum<bool, SupportsAccessControl> expectedSupportsAccessControl =
            SupportsAccessControl.True;

        Assert.Equal(expectedClientID, deserialized.ClientID);
        Assert.Equal(expectedClientSecret, deserialized.ClientSecret);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
        Assert.Equal(expectedUserPrincipalName, deserialized.UserPrincipalName);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedFolderID, deserialized.FolderID);
        Assert.Equal(expectedFolderPath, deserialized.FolderPath);
        Assert.NotNull(deserialized.RequiredExts);
        Assert.Equal(expectedRequiredExts.Count, deserialized.RequiredExts.Count);
        for (int i = 0; i < expectedRequiredExts.Count; i++)
        {
            Assert.Equal(expectedRequiredExts[i], deserialized.RequiredExts[i]);
        }
        Assert.Equal(expectedSupportsAccessControl, deserialized.SupportsAccessControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudOneDriveDataSource
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudOneDriveDataSource
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            UserPrincipalName = "user_principal_name",
            FolderID = "folder_id",
            FolderPath = "folder_path",
            RequiredExts = ["string"],
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.SupportsAccessControl);
        Assert.False(model.RawData.ContainsKey("supports_access_control"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudOneDriveDataSource
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            UserPrincipalName = "user_principal_name",
            FolderID = "folder_id",
            FolderPath = "folder_path",
            RequiredExts = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudOneDriveDataSource
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            UserPrincipalName = "user_principal_name",
            FolderID = "folder_id",
            FolderPath = "folder_path",
            RequiredExts = ["string"],

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
        var model = new CloudOneDriveDataSource
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            UserPrincipalName = "user_principal_name",
            FolderID = "folder_id",
            FolderPath = "folder_path",
            RequiredExts = ["string"],

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            SupportsAccessControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudOneDriveDataSource
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            UserPrincipalName = "user_principal_name",
            ClassName = "class_name",
            SupportsAccessControl = SupportsAccessControl.True,
        };

        Assert.Null(model.FolderID);
        Assert.False(model.RawData.ContainsKey("folder_id"));
        Assert.Null(model.FolderPath);
        Assert.False(model.RawData.ContainsKey("folder_path"));
        Assert.Null(model.RequiredExts);
        Assert.False(model.RawData.ContainsKey("required_exts"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudOneDriveDataSource
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            UserPrincipalName = "user_principal_name",
            ClassName = "class_name",
            SupportsAccessControl = SupportsAccessControl.True,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudOneDriveDataSource
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            UserPrincipalName = "user_principal_name",
            ClassName = "class_name",
            SupportsAccessControl = SupportsAccessControl.True,

            FolderID = null,
            FolderPath = null,
            RequiredExts = null,
        };

        Assert.Null(model.FolderID);
        Assert.True(model.RawData.ContainsKey("folder_id"));
        Assert.Null(model.FolderPath);
        Assert.True(model.RawData.ContainsKey("folder_path"));
        Assert.Null(model.RequiredExts);
        Assert.True(model.RawData.ContainsKey("required_exts"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudOneDriveDataSource
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            UserPrincipalName = "user_principal_name",
            ClassName = "class_name",
            SupportsAccessControl = SupportsAccessControl.True,

            FolderID = null,
            FolderPath = null,
            RequiredExts = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudOneDriveDataSource
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

        CloudOneDriveDataSource copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SupportsAccessControlTest : TestBase
{
    [Theory]
    [InlineData(SupportsAccessControl.True)]
    public void Validation_Works(SupportsAccessControl rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, SupportsAccessControl> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, SupportsAccessControl>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SupportsAccessControl.True)]
    public void SerializationRoundtrip_Works(SupportsAccessControl rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, SupportsAccessControl> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, SupportsAccessControl>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<bool, SupportsAccessControl>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<bool, SupportsAccessControl>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
