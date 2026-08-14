using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models;

namespace LlamaCloud.Tests.Models;

public class CloudNotionPageDataSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudNotionPageDataSource
        {
            IntegrationToken = "integration_token",
            ClassName = "class_name",
            DatabaseIds = "database_ids",
            PageIds = "page_ids",
            SupportsAccessControl = true,
        };

        string expectedIntegrationToken = "integration_token";
        string expectedClassName = "class_name";
        string expectedDatabaseIds = "database_ids";
        string expectedPageIds = "page_ids";
        bool expectedSupportsAccessControl = true;

        Assert.Equal(expectedIntegrationToken, model.IntegrationToken);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedDatabaseIds, model.DatabaseIds);
        Assert.Equal(expectedPageIds, model.PageIds);
        Assert.Equal(expectedSupportsAccessControl, model.SupportsAccessControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudNotionPageDataSource
        {
            IntegrationToken = "integration_token",
            ClassName = "class_name",
            DatabaseIds = "database_ids",
            PageIds = "page_ids",
            SupportsAccessControl = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudNotionPageDataSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudNotionPageDataSource
        {
            IntegrationToken = "integration_token",
            ClassName = "class_name",
            DatabaseIds = "database_ids",
            PageIds = "page_ids",
            SupportsAccessControl = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudNotionPageDataSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedIntegrationToken = "integration_token";
        string expectedClassName = "class_name";
        string expectedDatabaseIds = "database_ids";
        string expectedPageIds = "page_ids";
        bool expectedSupportsAccessControl = true;

        Assert.Equal(expectedIntegrationToken, deserialized.IntegrationToken);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedDatabaseIds, deserialized.DatabaseIds);
        Assert.Equal(expectedPageIds, deserialized.PageIds);
        Assert.Equal(expectedSupportsAccessControl, deserialized.SupportsAccessControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudNotionPageDataSource
        {
            IntegrationToken = "integration_token",
            ClassName = "class_name",
            DatabaseIds = "database_ids",
            PageIds = "page_ids",
            SupportsAccessControl = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudNotionPageDataSource
        {
            IntegrationToken = "integration_token",
            DatabaseIds = "database_ids",
            PageIds = "page_ids",
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.SupportsAccessControl);
        Assert.False(model.RawData.ContainsKey("supports_access_control"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudNotionPageDataSource
        {
            IntegrationToken = "integration_token",
            DatabaseIds = "database_ids",
            PageIds = "page_ids",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudNotionPageDataSource
        {
            IntegrationToken = "integration_token",
            DatabaseIds = "database_ids",
            PageIds = "page_ids",

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
        var model = new CloudNotionPageDataSource
        {
            IntegrationToken = "integration_token",
            DatabaseIds = "database_ids",
            PageIds = "page_ids",

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            SupportsAccessControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudNotionPageDataSource
        {
            IntegrationToken = "integration_token",
            ClassName = "class_name",
            SupportsAccessControl = true,
        };

        Assert.Null(model.DatabaseIds);
        Assert.False(model.RawData.ContainsKey("database_ids"));
        Assert.Null(model.PageIds);
        Assert.False(model.RawData.ContainsKey("page_ids"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudNotionPageDataSource
        {
            IntegrationToken = "integration_token",
            ClassName = "class_name",
            SupportsAccessControl = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudNotionPageDataSource
        {
            IntegrationToken = "integration_token",
            ClassName = "class_name",
            SupportsAccessControl = true,

            DatabaseIds = null,
            PageIds = null,
        };

        Assert.Null(model.DatabaseIds);
        Assert.True(model.RawData.ContainsKey("database_ids"));
        Assert.Null(model.PageIds);
        Assert.True(model.RawData.ContainsKey("page_ids"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudNotionPageDataSource
        {
            IntegrationToken = "integration_token",
            ClassName = "class_name",
            SupportsAccessControl = true,

            DatabaseIds = null,
            PageIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudNotionPageDataSource
        {
            IntegrationToken = "integration_token",
            ClassName = "class_name",
            DatabaseIds = "database_ids",
            PageIds = "page_ids",
            SupportsAccessControl = true,
        };

        CloudNotionPageDataSource copied = new(model);

        Assert.Equal(model, copied);
    }
}
