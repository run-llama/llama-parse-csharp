using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models;

namespace LlamaIndex.LlamaCloud.Tests.Models;

public class CloudSharepointDataSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudSharepointDataSource
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

        string expectedClientID = "client_id";
        string expectedClientSecret = "client_secret";
        string expectedTenantID = "tenant_id";
        string expectedClassName = "class_name";
        string expectedDriveName = "drive_name";
        List<string> expectedExcludePathPatterns = ["string"];
        string expectedFolderID = "folder_id";
        string expectedFolderPath = "folder_path";
        bool expectedGetPermissions = true;
        List<string> expectedIncludePathPatterns = ["string"];
        List<string> expectedRequiredExts = ["string"];
        string expectedSiteID = "site_id";
        string expectedSiteName = "site_name";
        ApiEnum<
            bool,
            CloudSharepointDataSourceSupportsAccessControl
        > expectedSupportsAccessControl = CloudSharepointDataSourceSupportsAccessControl.True;

        Assert.Equal(expectedClientID, model.ClientID);
        Assert.Equal(expectedClientSecret, model.ClientSecret);
        Assert.Equal(expectedTenantID, model.TenantID);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedDriveName, model.DriveName);
        Assert.NotNull(model.ExcludePathPatterns);
        Assert.Equal(expectedExcludePathPatterns.Count, model.ExcludePathPatterns.Count);
        for (int i = 0; i < expectedExcludePathPatterns.Count; i++)
        {
            Assert.Equal(expectedExcludePathPatterns[i], model.ExcludePathPatterns[i]);
        }
        Assert.Equal(expectedFolderID, model.FolderID);
        Assert.Equal(expectedFolderPath, model.FolderPath);
        Assert.Equal(expectedGetPermissions, model.GetPermissions);
        Assert.NotNull(model.IncludePathPatterns);
        Assert.Equal(expectedIncludePathPatterns.Count, model.IncludePathPatterns.Count);
        for (int i = 0; i < expectedIncludePathPatterns.Count; i++)
        {
            Assert.Equal(expectedIncludePathPatterns[i], model.IncludePathPatterns[i]);
        }
        Assert.NotNull(model.RequiredExts);
        Assert.Equal(expectedRequiredExts.Count, model.RequiredExts.Count);
        for (int i = 0; i < expectedRequiredExts.Count; i++)
        {
            Assert.Equal(expectedRequiredExts[i], model.RequiredExts[i]);
        }
        Assert.Equal(expectedSiteID, model.SiteID);
        Assert.Equal(expectedSiteName, model.SiteName);
        Assert.Equal(expectedSupportsAccessControl, model.SupportsAccessControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudSharepointDataSource
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudSharepointDataSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudSharepointDataSource
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudSharepointDataSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClientID = "client_id";
        string expectedClientSecret = "client_secret";
        string expectedTenantID = "tenant_id";
        string expectedClassName = "class_name";
        string expectedDriveName = "drive_name";
        List<string> expectedExcludePathPatterns = ["string"];
        string expectedFolderID = "folder_id";
        string expectedFolderPath = "folder_path";
        bool expectedGetPermissions = true;
        List<string> expectedIncludePathPatterns = ["string"];
        List<string> expectedRequiredExts = ["string"];
        string expectedSiteID = "site_id";
        string expectedSiteName = "site_name";
        ApiEnum<
            bool,
            CloudSharepointDataSourceSupportsAccessControl
        > expectedSupportsAccessControl = CloudSharepointDataSourceSupportsAccessControl.True;

        Assert.Equal(expectedClientID, deserialized.ClientID);
        Assert.Equal(expectedClientSecret, deserialized.ClientSecret);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedDriveName, deserialized.DriveName);
        Assert.NotNull(deserialized.ExcludePathPatterns);
        Assert.Equal(expectedExcludePathPatterns.Count, deserialized.ExcludePathPatterns.Count);
        for (int i = 0; i < expectedExcludePathPatterns.Count; i++)
        {
            Assert.Equal(expectedExcludePathPatterns[i], deserialized.ExcludePathPatterns[i]);
        }
        Assert.Equal(expectedFolderID, deserialized.FolderID);
        Assert.Equal(expectedFolderPath, deserialized.FolderPath);
        Assert.Equal(expectedGetPermissions, deserialized.GetPermissions);
        Assert.NotNull(deserialized.IncludePathPatterns);
        Assert.Equal(expectedIncludePathPatterns.Count, deserialized.IncludePathPatterns.Count);
        for (int i = 0; i < expectedIncludePathPatterns.Count; i++)
        {
            Assert.Equal(expectedIncludePathPatterns[i], deserialized.IncludePathPatterns[i]);
        }
        Assert.NotNull(deserialized.RequiredExts);
        Assert.Equal(expectedRequiredExts.Count, deserialized.RequiredExts.Count);
        for (int i = 0; i < expectedRequiredExts.Count; i++)
        {
            Assert.Equal(expectedRequiredExts[i], deserialized.RequiredExts[i]);
        }
        Assert.Equal(expectedSiteID, deserialized.SiteID);
        Assert.Equal(expectedSiteName, deserialized.SiteName);
        Assert.Equal(expectedSupportsAccessControl, deserialized.SupportsAccessControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudSharepointDataSource
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudSharepointDataSource
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            DriveName = "drive_name",
            ExcludePathPatterns = ["string"],
            FolderID = "folder_id",
            FolderPath = "folder_path",
            IncludePathPatterns = ["string"],
            RequiredExts = ["string"],
            SiteID = "site_id",
            SiteName = "site_name",
        };

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
        var model = new CloudSharepointDataSource
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            DriveName = "drive_name",
            ExcludePathPatterns = ["string"],
            FolderID = "folder_id",
            FolderPath = "folder_path",
            IncludePathPatterns = ["string"],
            RequiredExts = ["string"],
            SiteID = "site_id",
            SiteName = "site_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudSharepointDataSource
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            DriveName = "drive_name",
            ExcludePathPatterns = ["string"],
            FolderID = "folder_id",
            FolderPath = "folder_path",
            IncludePathPatterns = ["string"],
            RequiredExts = ["string"],
            SiteID = "site_id",
            SiteName = "site_name",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            GetPermissions = null,
            SupportsAccessControl = null,
        };

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
        var model = new CloudSharepointDataSource
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            DriveName = "drive_name",
            ExcludePathPatterns = ["string"],
            FolderID = "folder_id",
            FolderPath = "folder_path",
            IncludePathPatterns = ["string"],
            RequiredExts = ["string"],
            SiteID = "site_id",
            SiteName = "site_name",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            GetPermissions = null,
            SupportsAccessControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudSharepointDataSource
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            ClassName = "class_name",
            GetPermissions = true,
            SupportsAccessControl = CloudSharepointDataSourceSupportsAccessControl.True,
        };

        Assert.Null(model.DriveName);
        Assert.False(model.RawData.ContainsKey("drive_name"));
        Assert.Null(model.ExcludePathPatterns);
        Assert.False(model.RawData.ContainsKey("exclude_path_patterns"));
        Assert.Null(model.FolderID);
        Assert.False(model.RawData.ContainsKey("folder_id"));
        Assert.Null(model.FolderPath);
        Assert.False(model.RawData.ContainsKey("folder_path"));
        Assert.Null(model.IncludePathPatterns);
        Assert.False(model.RawData.ContainsKey("include_path_patterns"));
        Assert.Null(model.RequiredExts);
        Assert.False(model.RawData.ContainsKey("required_exts"));
        Assert.Null(model.SiteID);
        Assert.False(model.RawData.ContainsKey("site_id"));
        Assert.Null(model.SiteName);
        Assert.False(model.RawData.ContainsKey("site_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudSharepointDataSource
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            ClassName = "class_name",
            GetPermissions = true,
            SupportsAccessControl = CloudSharepointDataSourceSupportsAccessControl.True,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudSharepointDataSource
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            ClassName = "class_name",
            GetPermissions = true,
            SupportsAccessControl = CloudSharepointDataSourceSupportsAccessControl.True,

            DriveName = null,
            ExcludePathPatterns = null,
            FolderID = null,
            FolderPath = null,
            IncludePathPatterns = null,
            RequiredExts = null,
            SiteID = null,
            SiteName = null,
        };

        Assert.Null(model.DriveName);
        Assert.True(model.RawData.ContainsKey("drive_name"));
        Assert.Null(model.ExcludePathPatterns);
        Assert.True(model.RawData.ContainsKey("exclude_path_patterns"));
        Assert.Null(model.FolderID);
        Assert.True(model.RawData.ContainsKey("folder_id"));
        Assert.Null(model.FolderPath);
        Assert.True(model.RawData.ContainsKey("folder_path"));
        Assert.Null(model.IncludePathPatterns);
        Assert.True(model.RawData.ContainsKey("include_path_patterns"));
        Assert.Null(model.RequiredExts);
        Assert.True(model.RawData.ContainsKey("required_exts"));
        Assert.Null(model.SiteID);
        Assert.True(model.RawData.ContainsKey("site_id"));
        Assert.Null(model.SiteName);
        Assert.True(model.RawData.ContainsKey("site_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudSharepointDataSource
        {
            ClientID = "client_id",
            ClientSecret = "client_secret",
            TenantID = "tenant_id",
            ClassName = "class_name",
            GetPermissions = true,
            SupportsAccessControl = CloudSharepointDataSourceSupportsAccessControl.True,

            DriveName = null,
            ExcludePathPatterns = null,
            FolderID = null,
            FolderPath = null,
            IncludePathPatterns = null,
            RequiredExts = null,
            SiteID = null,
            SiteName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudSharepointDataSource
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

        CloudSharepointDataSource copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CloudSharepointDataSourceSupportsAccessControlTest : TestBase
{
    [Theory]
    [InlineData(CloudSharepointDataSourceSupportsAccessControl.True)]
    public void Validation_Works(CloudSharepointDataSourceSupportsAccessControl rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, CloudSharepointDataSourceSupportsAccessControl> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<bool, CloudSharepointDataSourceSupportsAccessControl>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CloudSharepointDataSourceSupportsAccessControl.True)]
    public void SerializationRoundtrip_Works(
        CloudSharepointDataSourceSupportsAccessControl rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<bool, CloudSharepointDataSourceSupportsAccessControl> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<bool, CloudSharepointDataSourceSupportsAccessControl>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<bool, CloudSharepointDataSourceSupportsAccessControl>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<bool, CloudSharepointDataSourceSupportsAccessControl>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
