using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Beta.Split;

namespace LlamaCloud.Tests.Models.Beta.Split;

public class SplitCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SplitCreateParams
        {
            DocumentInput = new() { Type = "type", Value = "value" },
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Configuration = new()
            {
                Categories = [new() { Name = "x", Description = "x" }],
                SplittingStrategy = new() { AllowUncategorized = AllowUncategorized.Forbid },
            },
            ConfigurationID = "configuration_id",
        };

        SplitDocumentInput expectedDocumentInput = new() { Type = "type", Value = "value" };
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Configuration expectedConfiguration = new()
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new() { AllowUncategorized = AllowUncategorized.Forbid },
        };
        string expectedConfigurationID = "configuration_id";

        Assert.Equal(expectedDocumentInput, parameters.DocumentInput);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedConfiguration, parameters.Configuration);
        Assert.Equal(expectedConfigurationID, parameters.ConfigurationID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SplitCreateParams
        {
            DocumentInput = new() { Type = "type", Value = "value" },
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Configuration);
        Assert.False(parameters.RawBodyData.ContainsKey("configuration"));
        Assert.Null(parameters.ConfigurationID);
        Assert.False(parameters.RawBodyData.ContainsKey("configuration_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SplitCreateParams
        {
            DocumentInput = new() { Type = "type", Value = "value" },

            OrganizationID = null,
            ProjectID = null,
            Configuration = null,
            ConfigurationID = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Configuration);
        Assert.True(parameters.RawBodyData.ContainsKey("configuration"));
        Assert.Null(parameters.ConfigurationID);
        Assert.True(parameters.RawBodyData.ContainsKey("configuration_id"));
    }

    [Fact]
    public void Url_Works()
    {
        SplitCreateParams parameters = new()
        {
            DocumentInput = new() { Type = "type", Value = "value" },
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/split/jobs?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SplitCreateParams
        {
            DocumentInput = new() { Type = "type", Value = "value" },
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Configuration = new()
            {
                Categories = [new() { Name = "x", Description = "x" }],
                SplittingStrategy = new() { AllowUncategorized = AllowUncategorized.Forbid },
            },
            ConfigurationID = "configuration_id",
        };

        SplitCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Configuration
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new() { AllowUncategorized = AllowUncategorized.Forbid },
        };

        List<SplitCategory> expectedCategories = [new() { Name = "x", Description = "x" }];
        SplittingStrategy expectedSplittingStrategy = new()
        {
            AllowUncategorized = AllowUncategorized.Forbid,
        };

        Assert.Equal(expectedCategories.Count, model.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], model.Categories[i]);
        }
        Assert.Equal(expectedSplittingStrategy, model.SplittingStrategy);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Configuration
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new() { AllowUncategorized = AllowUncategorized.Forbid },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Configuration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Configuration
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new() { AllowUncategorized = AllowUncategorized.Forbid },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Configuration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<SplitCategory> expectedCategories = [new() { Name = "x", Description = "x" }];
        SplittingStrategy expectedSplittingStrategy = new()
        {
            AllowUncategorized = AllowUncategorized.Forbid,
        };

        Assert.Equal(expectedCategories.Count, deserialized.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], deserialized.Categories[i]);
        }
        Assert.Equal(expectedSplittingStrategy, deserialized.SplittingStrategy);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Configuration
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new() { AllowUncategorized = AllowUncategorized.Forbid },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Configuration { Categories = [new() { Name = "x", Description = "x" }] };

        Assert.Null(model.SplittingStrategy);
        Assert.False(model.RawData.ContainsKey("splitting_strategy"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Configuration { Categories = [new() { Name = "x", Description = "x" }] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Configuration
        {
            Categories = [new() { Name = "x", Description = "x" }],

            // Null should be interpreted as omitted for these properties
            SplittingStrategy = null,
        };

        Assert.Null(model.SplittingStrategy);
        Assert.False(model.RawData.ContainsKey("splitting_strategy"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Configuration
        {
            Categories = [new() { Name = "x", Description = "x" }],

            // Null should be interpreted as omitted for these properties
            SplittingStrategy = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Configuration
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new() { AllowUncategorized = AllowUncategorized.Forbid },
        };

        Configuration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplittingStrategyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplittingStrategy { AllowUncategorized = AllowUncategorized.Forbid };

        ApiEnum<string, AllowUncategorized> expectedAllowUncategorized = AllowUncategorized.Forbid;

        Assert.Equal(expectedAllowUncategorized, model.AllowUncategorized);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplittingStrategy { AllowUncategorized = AllowUncategorized.Forbid };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplittingStrategy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplittingStrategy { AllowUncategorized = AllowUncategorized.Forbid };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplittingStrategy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, AllowUncategorized> expectedAllowUncategorized = AllowUncategorized.Forbid;

        Assert.Equal(expectedAllowUncategorized, deserialized.AllowUncategorized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SplittingStrategy { AllowUncategorized = AllowUncategorized.Forbid };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplittingStrategy { };

        Assert.Null(model.AllowUncategorized);
        Assert.False(model.RawData.ContainsKey("allow_uncategorized"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplittingStrategy { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplittingStrategy
        {
            // Null should be interpreted as omitted for these properties
            AllowUncategorized = null,
        };

        Assert.Null(model.AllowUncategorized);
        Assert.False(model.RawData.ContainsKey("allow_uncategorized"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SplittingStrategy
        {
            // Null should be interpreted as omitted for these properties
            AllowUncategorized = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplittingStrategy { AllowUncategorized = AllowUncategorized.Forbid };

        SplittingStrategy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AllowUncategorizedTest : TestBase
{
    [Theory]
    [InlineData(AllowUncategorized.Forbid)]
    [InlineData(AllowUncategorized.Include)]
    [InlineData(AllowUncategorized.Omit)]
    public void Validation_Works(AllowUncategorized rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AllowUncategorized> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AllowUncategorized>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AllowUncategorized.Forbid)]
    [InlineData(AllowUncategorized.Include)]
    [InlineData(AllowUncategorized.Omit)]
    public void SerializationRoundtrip_Works(AllowUncategorized rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AllowUncategorized> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AllowUncategorized>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AllowUncategorized>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AllowUncategorized>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
