using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models;

namespace LlamaIndex.LlamaCloud.Tests.Models;

public class CloudGoogleDriveDataSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudGoogleDriveDataSource
        {
            FolderID = "folder_id",
            ClassName = "class_name",
            FolderName = "folder_name",
            ServiceAccountKey = new Dictionary<string, string>() { { "foo", "string" } },
            SupportsAccessControl = true,
        };

        string expectedFolderID = "folder_id";
        string expectedClassName = "class_name";
        string expectedFolderName = "folder_name";
        Dictionary<string, string> expectedServiceAccountKey = new() { { "foo", "string" } };
        bool expectedSupportsAccessControl = true;

        Assert.Equal(expectedFolderID, model.FolderID);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedFolderName, model.FolderName);
        Assert.NotNull(model.ServiceAccountKey);
        Assert.Equal(expectedServiceAccountKey.Count, model.ServiceAccountKey.Count);
        foreach (var item in expectedServiceAccountKey)
        {
            Assert.True(model.ServiceAccountKey.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.ServiceAccountKey[item.Key]);
        }
        Assert.Equal(expectedSupportsAccessControl, model.SupportsAccessControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudGoogleDriveDataSource
        {
            FolderID = "folder_id",
            ClassName = "class_name",
            FolderName = "folder_name",
            ServiceAccountKey = new Dictionary<string, string>() { { "foo", "string" } },
            SupportsAccessControl = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudGoogleDriveDataSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudGoogleDriveDataSource
        {
            FolderID = "folder_id",
            ClassName = "class_name",
            FolderName = "folder_name",
            ServiceAccountKey = new Dictionary<string, string>() { { "foo", "string" } },
            SupportsAccessControl = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudGoogleDriveDataSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFolderID = "folder_id";
        string expectedClassName = "class_name";
        string expectedFolderName = "folder_name";
        Dictionary<string, string> expectedServiceAccountKey = new() { { "foo", "string" } };
        bool expectedSupportsAccessControl = true;

        Assert.Equal(expectedFolderID, deserialized.FolderID);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedFolderName, deserialized.FolderName);
        Assert.NotNull(deserialized.ServiceAccountKey);
        Assert.Equal(expectedServiceAccountKey.Count, deserialized.ServiceAccountKey.Count);
        foreach (var item in expectedServiceAccountKey)
        {
            Assert.True(deserialized.ServiceAccountKey.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.ServiceAccountKey[item.Key]);
        }
        Assert.Equal(expectedSupportsAccessControl, deserialized.SupportsAccessControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudGoogleDriveDataSource
        {
            FolderID = "folder_id",
            ClassName = "class_name",
            FolderName = "folder_name",
            ServiceAccountKey = new Dictionary<string, string>() { { "foo", "string" } },
            SupportsAccessControl = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudGoogleDriveDataSource
        {
            FolderID = "folder_id",
            FolderName = "folder_name",
            ServiceAccountKey = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.SupportsAccessControl);
        Assert.False(model.RawData.ContainsKey("supports_access_control"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudGoogleDriveDataSource
        {
            FolderID = "folder_id",
            FolderName = "folder_name",
            ServiceAccountKey = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudGoogleDriveDataSource
        {
            FolderID = "folder_id",
            FolderName = "folder_name",
            ServiceAccountKey = new Dictionary<string, string>() { { "foo", "string" } },

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
        var model = new CloudGoogleDriveDataSource
        {
            FolderID = "folder_id",
            FolderName = "folder_name",
            ServiceAccountKey = new Dictionary<string, string>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            SupportsAccessControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudGoogleDriveDataSource
        {
            FolderID = "folder_id",
            ClassName = "class_name",
            SupportsAccessControl = true,
        };

        Assert.Null(model.FolderName);
        Assert.False(model.RawData.ContainsKey("folder_name"));
        Assert.Null(model.ServiceAccountKey);
        Assert.False(model.RawData.ContainsKey("service_account_key"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudGoogleDriveDataSource
        {
            FolderID = "folder_id",
            ClassName = "class_name",
            SupportsAccessControl = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudGoogleDriveDataSource
        {
            FolderID = "folder_id",
            ClassName = "class_name",
            SupportsAccessControl = true,

            FolderName = null,
            ServiceAccountKey = null,
        };

        Assert.Null(model.FolderName);
        Assert.True(model.RawData.ContainsKey("folder_name"));
        Assert.Null(model.ServiceAccountKey);
        Assert.True(model.RawData.ContainsKey("service_account_key"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudGoogleDriveDataSource
        {
            FolderID = "folder_id",
            ClassName = "class_name",
            SupportsAccessControl = true,

            FolderName = null,
            ServiceAccountKey = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudGoogleDriveDataSource
        {
            FolderID = "folder_id",
            ClassName = "class_name",
            FolderName = "folder_name",
            ServiceAccountKey = new Dictionary<string, string>() { { "foo", "string" } },
            SupportsAccessControl = true,
        };

        CloudGoogleDriveDataSource copied = new(model);

        Assert.Equal(model, copied);
    }
}
