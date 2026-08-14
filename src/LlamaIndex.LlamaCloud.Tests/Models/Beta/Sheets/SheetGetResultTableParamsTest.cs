using System;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Beta.Sheets;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Sheets;

public class SheetGetResultTableParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SheetGetResultTableParams
        {
            SpreadsheetJobID = "spreadsheet_job_id",
            RegionID = "region_id",
            RegionType = RegionType.CellMetadata,
            ExpiresAtSeconds = 0,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedSpreadsheetJobID = "spreadsheet_job_id";
        string expectedRegionID = "region_id";
        ApiEnum<string, RegionType> expectedRegionType = RegionType.CellMetadata;
        long expectedExpiresAtSeconds = 0;
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedSpreadsheetJobID, parameters.SpreadsheetJobID);
        Assert.Equal(expectedRegionID, parameters.RegionID);
        Assert.Equal(expectedRegionType, parameters.RegionType);
        Assert.Equal(expectedExpiresAtSeconds, parameters.ExpiresAtSeconds);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SheetGetResultTableParams
        {
            SpreadsheetJobID = "spreadsheet_job_id",
            RegionID = "region_id",
            RegionType = RegionType.CellMetadata,
        };

        Assert.Null(parameters.ExpiresAtSeconds);
        Assert.False(parameters.RawQueryData.ContainsKey("expires_at_seconds"));
        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SheetGetResultTableParams
        {
            SpreadsheetJobID = "spreadsheet_job_id",
            RegionID = "region_id",
            RegionType = RegionType.CellMetadata,

            ExpiresAtSeconds = null,
            OrganizationID = null,
            ProjectID = null,
        };

        Assert.Null(parameters.ExpiresAtSeconds);
        Assert.True(parameters.RawQueryData.ContainsKey("expires_at_seconds"));
        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void Url_Works()
    {
        SheetGetResultTableParams parameters = new()
        {
            SpreadsheetJobID = "spreadsheet_job_id",
            RegionID = "region_id",
            RegionType = RegionType.CellMetadata,
            ExpiresAtSeconds = 0,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/sheets/jobs/spreadsheet_job_id/regions/region_id/result/cell_metadata?expires_at_seconds=0&organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SheetGetResultTableParams
        {
            SpreadsheetJobID = "spreadsheet_job_id",
            RegionID = "region_id",
            RegionType = RegionType.CellMetadata,
            ExpiresAtSeconds = 0,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        SheetGetResultTableParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class RegionTypeTest : TestBase
{
    [Theory]
    [InlineData(RegionType.CellMetadata)]
    [InlineData(RegionType.Extra)]
    [InlineData(RegionType.Table)]
    public void Validation_Works(RegionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RegionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RegionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RegionType.CellMetadata)]
    [InlineData(RegionType.Extra)]
    [InlineData(RegionType.Table)]
    public void SerializationRoundtrip_Works(RegionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RegionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RegionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RegionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RegionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
