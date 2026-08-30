using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Configurations;

namespace LlamaCloud.Tests.Models.Configurations;

public class ConfigurationListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ConfigurationListParams
        {
            LatestOnly = true,
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 1,
            PageToken = "page_token",
            ProductType = [ProductType.ClassifyV2, ProductType.ExtractV2],
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        bool expectedLatestOnly = true;
        string expectedName = "name";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedPageSize = 1;
        string expectedPageToken = "page_token";
        List<ApiEnum<string, ProductType>> expectedProductType =
        [
            ProductType.ClassifyV2,
            ProductType.ExtractV2,
        ];
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedLatestOnly, parameters.LatestOnly);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedPageToken, parameters.PageToken);
        Assert.NotNull(parameters.ProductType);
        Assert.Equal(expectedProductType.Count, parameters.ProductType.Count);
        for (int i = 0; i < expectedProductType.Count; i++)
        {
            Assert.Equal(expectedProductType[i], parameters.ProductType[i]);
        }
        Assert.Equal(expectedProjectID, parameters.ProjectID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ConfigurationListParams
        {
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 1,
            PageToken = "page_token",
            ProductType = [ProductType.ClassifyV2, ProductType.ExtractV2],
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.LatestOnly);
        Assert.False(parameters.RawQueryData.ContainsKey("latest_only"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ConfigurationListParams
        {
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 1,
            PageToken = "page_token",
            ProductType = [ProductType.ClassifyV2, ProductType.ExtractV2],
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            LatestOnly = null,
        };

        Assert.Null(parameters.LatestOnly);
        Assert.False(parameters.RawQueryData.ContainsKey("latest_only"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ConfigurationListParams { LatestOnly = true };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawQueryData.ContainsKey("name"));
        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.False(parameters.RawQueryData.ContainsKey("page_token"));
        Assert.Null(parameters.ProductType);
        Assert.False(parameters.RawQueryData.ContainsKey("product_type"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ConfigurationListParams
        {
            LatestOnly = true,

            Name = null,
            OrganizationID = null,
            PageSize = null,
            PageToken = null,
            ProductType = null,
            ProjectID = null,
        };

        Assert.Null(parameters.Name);
        Assert.True(parameters.RawQueryData.ContainsKey("name"));
        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.PageSize);
        Assert.True(parameters.RawQueryData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.True(parameters.RawQueryData.ContainsKey("page_token"));
        Assert.Null(parameters.ProductType);
        Assert.True(parameters.RawQueryData.ContainsKey("product_type"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void Url_Works()
    {
        ConfigurationListParams parameters = new()
        {
            LatestOnly = true,
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 1,
            PageToken = "page_token",
            ProductType = [ProductType.ClassifyV2, ProductType.ExtractV2],
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/configurations?latest_only=true&name=name&organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&page_size=1&page_token=page_token&product_type=classify_v2&product_type=extract_v2&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ConfigurationListParams
        {
            LatestOnly = true,
            Name = "name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageSize = 1,
            PageToken = "page_token",
            ProductType = [ProductType.ClassifyV2, ProductType.ExtractV2],
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ConfigurationListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ProductTypeTest : TestBase
{
    [Theory]
    [InlineData(ProductType.ClassifyV2)]
    [InlineData(ProductType.ExtractV2)]
    [InlineData(ProductType.ParseV2)]
    [InlineData(ProductType.SplitV1)]
    [InlineData(ProductType.SpreadsheetV1)]
    [InlineData(ProductType.Unknown)]
    public void Validation_Works(ProductType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProductType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductType.ClassifyV2)]
    [InlineData(ProductType.ExtractV2)]
    [InlineData(ProductType.ParseV2)]
    [InlineData(ProductType.SplitV1)]
    [InlineData(ProductType.SpreadsheetV1)]
    [InlineData(ProductType.Unknown)]
    public void SerializationRoundtrip_Works(ProductType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProductType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProductType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ProductType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
