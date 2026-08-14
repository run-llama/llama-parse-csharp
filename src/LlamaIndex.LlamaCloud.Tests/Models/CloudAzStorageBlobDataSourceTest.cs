using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models;

namespace LlamaIndex.LlamaCloud.Tests.Models;

public class CloudAzStorageBlobDataSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudAzStorageBlobDataSource
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

        string expectedAccountUrl = "account_url";
        string expectedContainerName = "container_name";
        string expectedAccountKey = "account_key";
        string expectedAccountName = "account_name";
        string expectedBlob = "blob";
        string expectedClassName = "class_name";
        string expectedClientID = "client_id";
        string expectedClientSecret = "client_secret";
        string expectedPrefix = "prefix";
        bool expectedSupportsAccessControl = true;
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedAccountUrl, model.AccountUrl);
        Assert.Equal(expectedContainerName, model.ContainerName);
        Assert.Equal(expectedAccountKey, model.AccountKey);
        Assert.Equal(expectedAccountName, model.AccountName);
        Assert.Equal(expectedBlob, model.Blob);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedClientID, model.ClientID);
        Assert.Equal(expectedClientSecret, model.ClientSecret);
        Assert.Equal(expectedPrefix, model.Prefix);
        Assert.Equal(expectedSupportsAccessControl, model.SupportsAccessControl);
        Assert.Equal(expectedTenantID, model.TenantID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudAzStorageBlobDataSource
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudAzStorageBlobDataSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudAzStorageBlobDataSource
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudAzStorageBlobDataSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccountUrl = "account_url";
        string expectedContainerName = "container_name";
        string expectedAccountKey = "account_key";
        string expectedAccountName = "account_name";
        string expectedBlob = "blob";
        string expectedClassName = "class_name";
        string expectedClientID = "client_id";
        string expectedClientSecret = "client_secret";
        string expectedPrefix = "prefix";
        bool expectedSupportsAccessControl = true;
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedAccountUrl, deserialized.AccountUrl);
        Assert.Equal(expectedContainerName, deserialized.ContainerName);
        Assert.Equal(expectedAccountKey, deserialized.AccountKey);
        Assert.Equal(expectedAccountName, deserialized.AccountName);
        Assert.Equal(expectedBlob, deserialized.Blob);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedClientID, deserialized.ClientID);
        Assert.Equal(expectedClientSecret, deserialized.ClientSecret);
        Assert.Equal(expectedPrefix, deserialized.Prefix);
        Assert.Equal(expectedSupportsAccessControl, deserialized.SupportsAccessControl);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudAzStorageBlobDataSource
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudAzStorageBlobDataSource
        {
            AccountUrl = "account_url",
            ContainerName = "container_name",
            AccountKey = "account_key",
            AccountName = "account_name",
            Blob = "blob",
            ClientID = "client_id",
            ClientSecret = "client_secret",
            Prefix = "prefix",
            TenantID = "tenant_id",
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.SupportsAccessControl);
        Assert.False(model.RawData.ContainsKey("supports_access_control"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudAzStorageBlobDataSource
        {
            AccountUrl = "account_url",
            ContainerName = "container_name",
            AccountKey = "account_key",
            AccountName = "account_name",
            Blob = "blob",
            ClientID = "client_id",
            ClientSecret = "client_secret",
            Prefix = "prefix",
            TenantID = "tenant_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudAzStorageBlobDataSource
        {
            AccountUrl = "account_url",
            ContainerName = "container_name",
            AccountKey = "account_key",
            AccountName = "account_name",
            Blob = "blob",
            ClientID = "client_id",
            ClientSecret = "client_secret",
            Prefix = "prefix",
            TenantID = "tenant_id",

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
        var model = new CloudAzStorageBlobDataSource
        {
            AccountUrl = "account_url",
            ContainerName = "container_name",
            AccountKey = "account_key",
            AccountName = "account_name",
            Blob = "blob",
            ClientID = "client_id",
            ClientSecret = "client_secret",
            Prefix = "prefix",
            TenantID = "tenant_id",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            SupportsAccessControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudAzStorageBlobDataSource
        {
            AccountUrl = "account_url",
            ContainerName = "container_name",
            ClassName = "class_name",
            SupportsAccessControl = true,
        };

        Assert.Null(model.AccountKey);
        Assert.False(model.RawData.ContainsKey("account_key"));
        Assert.Null(model.AccountName);
        Assert.False(model.RawData.ContainsKey("account_name"));
        Assert.Null(model.Blob);
        Assert.False(model.RawData.ContainsKey("blob"));
        Assert.Null(model.ClientID);
        Assert.False(model.RawData.ContainsKey("client_id"));
        Assert.Null(model.ClientSecret);
        Assert.False(model.RawData.ContainsKey("client_secret"));
        Assert.Null(model.Prefix);
        Assert.False(model.RawData.ContainsKey("prefix"));
        Assert.Null(model.TenantID);
        Assert.False(model.RawData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudAzStorageBlobDataSource
        {
            AccountUrl = "account_url",
            ContainerName = "container_name",
            ClassName = "class_name",
            SupportsAccessControl = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudAzStorageBlobDataSource
        {
            AccountUrl = "account_url",
            ContainerName = "container_name",
            ClassName = "class_name",
            SupportsAccessControl = true,

            AccountKey = null,
            AccountName = null,
            Blob = null,
            ClientID = null,
            ClientSecret = null,
            Prefix = null,
            TenantID = null,
        };

        Assert.Null(model.AccountKey);
        Assert.True(model.RawData.ContainsKey("account_key"));
        Assert.Null(model.AccountName);
        Assert.True(model.RawData.ContainsKey("account_name"));
        Assert.Null(model.Blob);
        Assert.True(model.RawData.ContainsKey("blob"));
        Assert.Null(model.ClientID);
        Assert.True(model.RawData.ContainsKey("client_id"));
        Assert.Null(model.ClientSecret);
        Assert.True(model.RawData.ContainsKey("client_secret"));
        Assert.Null(model.Prefix);
        Assert.True(model.RawData.ContainsKey("prefix"));
        Assert.Null(model.TenantID);
        Assert.True(model.RawData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudAzStorageBlobDataSource
        {
            AccountUrl = "account_url",
            ContainerName = "container_name",
            ClassName = "class_name",
            SupportsAccessControl = true,

            AccountKey = null,
            AccountName = null,
            Blob = null,
            ClientID = null,
            ClientSecret = null,
            Prefix = null,
            TenantID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudAzStorageBlobDataSource
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

        CloudAzStorageBlobDataSource copied = new(model);

        Assert.Equal(model, copied);
    }
}
