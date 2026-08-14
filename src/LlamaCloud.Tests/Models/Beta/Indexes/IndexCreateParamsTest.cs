using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Beta.Indexes;

namespace LlamaCloud.Tests.Models.Beta.Indexes;

public class IndexCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IndexCreateParams
        {
            SourceDirectoryID = "dir-abc123",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            Name = "name",
            Products = [new() { ProductConfigID = "cfg-abc123", ProductType = "parse" }],
            StoreAttachments = ["screenshots"],
            SyncFrequency = "manual",
            VectorTarget = VectorTarget.Default,
        };

        string expectedSourceDirectoryID = "dir-abc123";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDescription = "description";
        string expectedName = "name";
        List<Product> expectedProducts =
        [
            new() { ProductConfigID = "cfg-abc123", ProductType = "parse" },
        ];
        List<string> expectedStoreAttachments = ["screenshots"];
        string expectedSyncFrequency = "manual";
        ApiEnum<string, VectorTarget> expectedVectorTarget = VectorTarget.Default;

        Assert.Equal(expectedSourceDirectoryID, parameters.SourceDirectoryID);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.Products);
        Assert.Equal(expectedProducts.Count, parameters.Products.Count);
        for (int i = 0; i < expectedProducts.Count; i++)
        {
            Assert.Equal(expectedProducts[i], parameters.Products[i]);
        }
        Assert.NotNull(parameters.StoreAttachments);
        Assert.Equal(expectedStoreAttachments.Count, parameters.StoreAttachments.Count);
        for (int i = 0; i < expectedStoreAttachments.Count; i++)
        {
            Assert.Equal(expectedStoreAttachments[i], parameters.StoreAttachments[i]);
        }
        Assert.Equal(expectedSyncFrequency, parameters.SyncFrequency);
        Assert.Equal(expectedVectorTarget, parameters.VectorTarget);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IndexCreateParams
        {
            SourceDirectoryID = "dir-abc123",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            Name = "name",
            Products = [new() { ProductConfigID = "cfg-abc123", ProductType = "parse" }],
            StoreAttachments = ["screenshots"],
        };

        Assert.Null(parameters.SyncFrequency);
        Assert.False(parameters.RawBodyData.ContainsKey("sync_frequency"));
        Assert.Null(parameters.VectorTarget);
        Assert.False(parameters.RawBodyData.ContainsKey("vector_target"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IndexCreateParams
        {
            SourceDirectoryID = "dir-abc123",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            Name = "name",
            Products = [new() { ProductConfigID = "cfg-abc123", ProductType = "parse" }],
            StoreAttachments = ["screenshots"],

            // Null should be interpreted as omitted for these properties
            SyncFrequency = null,
            VectorTarget = null,
        };

        Assert.Null(parameters.SyncFrequency);
        Assert.False(parameters.RawBodyData.ContainsKey("sync_frequency"));
        Assert.Null(parameters.VectorTarget);
        Assert.False(parameters.RawBodyData.ContainsKey("vector_target"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IndexCreateParams
        {
            SourceDirectoryID = "dir-abc123",
            SyncFrequency = "manual",
            VectorTarget = VectorTarget.Default,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Products);
        Assert.False(parameters.RawBodyData.ContainsKey("products"));
        Assert.Null(parameters.StoreAttachments);
        Assert.False(parameters.RawBodyData.ContainsKey("store_attachments"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new IndexCreateParams
        {
            SourceDirectoryID = "dir-abc123",
            SyncFrequency = "manual",
            VectorTarget = VectorTarget.Default,

            OrganizationID = null,
            ProjectID = null,
            Description = null,
            Name = null,
            Products = null,
            StoreAttachments = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Products);
        Assert.True(parameters.RawBodyData.ContainsKey("products"));
        Assert.Null(parameters.StoreAttachments);
        Assert.True(parameters.RawBodyData.ContainsKey("store_attachments"));
    }

    [Fact]
    public void Url_Works()
    {
        IndexCreateParams parameters = new()
        {
            SourceDirectoryID = "dir-abc123",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/indexes?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IndexCreateParams
        {
            SourceDirectoryID = "dir-abc123",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            Name = "name",
            Products = [new() { ProductConfigID = "cfg-abc123", ProductType = "parse" }],
            StoreAttachments = ["screenshots"],
            SyncFrequency = "manual",
            VectorTarget = VectorTarget.Default,
        };

        IndexCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ProductTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Product { ProductConfigID = "product_config_id", ProductType = "parse" };

        string expectedProductConfigID = "product_config_id";
        string expectedProductType = "parse";

        Assert.Equal(expectedProductConfigID, model.ProductConfigID);
        Assert.Equal(expectedProductType, model.ProductType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Product { ProductConfigID = "product_config_id", ProductType = "parse" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Product>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Product { ProductConfigID = "product_config_id", ProductType = "parse" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Product>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedProductConfigID = "product_config_id";
        string expectedProductType = "parse";

        Assert.Equal(expectedProductConfigID, deserialized.ProductConfigID);
        Assert.Equal(expectedProductType, deserialized.ProductType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Product { ProductConfigID = "product_config_id", ProductType = "parse" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Product { ProductConfigID = "product_config_id", ProductType = "parse" };

        Product copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VectorTargetTest : TestBase
{
    [Theory]
    [InlineData(VectorTarget.Default)]
    [InlineData(VectorTarget.Disabled)]
    public void Validation_Works(VectorTarget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VectorTarget> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VectorTarget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VectorTarget.Default)]
    [InlineData(VectorTarget.Disabled)]
    public void SerializationRoundtrip_Works(VectorTarget rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VectorTarget> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VectorTarget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VectorTarget>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VectorTarget>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
