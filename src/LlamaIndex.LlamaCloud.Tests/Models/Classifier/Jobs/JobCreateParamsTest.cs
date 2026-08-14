using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Classifier.Jobs;
using Parsing = LlamaIndex.LlamaCloud.Models.Parsing;

namespace LlamaIndex.LlamaCloud.Tests.Models.Classifier.Jobs;

public class JobCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new JobCreateParams
        {
            FileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Mode = Mode.Fast,
            ParsingConfiguration = new()
            {
                Lang = Parsing::ParsingLanguages.Abq,
                MaxPages = 0,
                TargetPages = [0],
            },
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = ["parse.success", "parse.error"],
                    WebhookHeaders = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    WebhookOutputFormat = WebhookOutputFormat.Json,
                    WebhookSigningSecret = "webhook_signing_secret",
                    WebhookUrl = "https:",
                },
            ],
        };

        List<string> expectedFileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"];
        List<ClassifierRule> expectedRules =
        [
            new()
            {
                Description = "contains invoice number, line items, and total amount",
                Type = "invoice",
            },
        ];
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, Mode> expectedMode = Mode.Fast;
        ClassifyParsingConfiguration expectedParsingConfiguration = new()
        {
            Lang = Parsing::ParsingLanguages.Abq,
            MaxPages = 0,
            TargetPages = [0],
        };
        List<WebhookConfiguration> expectedWebhookConfigurations =
        [
            new()
            {
                WebhookEvents = ["parse.success", "parse.error"],
                WebhookHeaders = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                WebhookOutputFormat = WebhookOutputFormat.Json,
                WebhookSigningSecret = "webhook_signing_secret",
                WebhookUrl = "https:",
            },
        ];

        Assert.Equal(expectedFileIds.Count, parameters.FileIds.Count);
        for (int i = 0; i < expectedFileIds.Count; i++)
        {
            Assert.Equal(expectedFileIds[i], parameters.FileIds[i]);
        }
        Assert.Equal(expectedRules.Count, parameters.Rules.Count);
        for (int i = 0; i < expectedRules.Count; i++)
        {
            Assert.Equal(expectedRules[i], parameters.Rules[i]);
        }
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedMode, parameters.Mode);
        Assert.Equal(expectedParsingConfiguration, parameters.ParsingConfiguration);
        Assert.NotNull(parameters.WebhookConfigurations);
        Assert.Equal(expectedWebhookConfigurations.Count, parameters.WebhookConfigurations.Count);
        for (int i = 0; i < expectedWebhookConfigurations.Count; i++)
        {
            Assert.Equal(expectedWebhookConfigurations[i], parameters.WebhookConfigurations[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new JobCreateParams
        {
            FileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(parameters.Mode);
        Assert.False(parameters.RawBodyData.ContainsKey("mode"));
        Assert.Null(parameters.ParsingConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("parsing_configuration"));
        Assert.Null(parameters.WebhookConfigurations);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_configurations"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new JobCreateParams
        {
            FileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            Mode = null,
            ParsingConfiguration = null,
            WebhookConfigurations = null,
        };

        Assert.Null(parameters.Mode);
        Assert.False(parameters.RawBodyData.ContainsKey("mode"));
        Assert.Null(parameters.ParsingConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("parsing_configuration"));
        Assert.Null(parameters.WebhookConfigurations);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_configurations"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new JobCreateParams
        {
            FileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Mode = Mode.Fast,
            ParsingConfiguration = new()
            {
                Lang = Parsing::ParsingLanguages.Abq,
                MaxPages = 0,
                TargetPages = [0],
            },
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = ["parse.success", "parse.error"],
                    WebhookHeaders = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    WebhookOutputFormat = WebhookOutputFormat.Json,
                    WebhookSigningSecret = "webhook_signing_secret",
                    WebhookUrl = "https:",
                },
            ],
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new JobCreateParams
        {
            FileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Mode = Mode.Fast,
            ParsingConfiguration = new()
            {
                Lang = Parsing::ParsingLanguages.Abq,
                MaxPages = 0,
                TargetPages = [0],
            },
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = ["parse.success", "parse.error"],
                    WebhookHeaders = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    WebhookOutputFormat = WebhookOutputFormat.Json,
                    WebhookSigningSecret = "webhook_signing_secret",
                    WebhookUrl = "https:",
                },
            ],

            OrganizationID = null,
            ProjectID = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void Url_Works()
    {
        JobCreateParams parameters = new()
        {
            FileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/classifier/jobs?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new JobCreateParams
        {
            FileIds = ["182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"],
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Mode = Mode.Fast,
            ParsingConfiguration = new()
            {
                Lang = Parsing::ParsingLanguages.Abq,
                MaxPages = 0,
                TargetPages = [0],
            },
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = ["parse.success", "parse.error"],
                    WebhookHeaders = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    WebhookOutputFormat = WebhookOutputFormat.Json,
                    WebhookSigningSecret = "webhook_signing_secret",
                    WebhookUrl = "https:",
                },
            ],
        };

        JobCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ModeTest : TestBase
{
    [Theory]
    [InlineData(Mode.Fast)]
    [InlineData(Mode.Multimodal)]
    public void Validation_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Mode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Mode.Fast)]
    [InlineData(Mode.Multimodal)]
    public void SerializationRoundtrip_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Mode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class WebhookConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookConfiguration
        {
            WebhookEvents = ["parse.success", "parse.error"],
            WebhookHeaders = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            WebhookOutputFormat = WebhookOutputFormat.Json,
            WebhookSigningSecret = "webhook_signing_secret",
            WebhookUrl = "https:",
        };

        List<string> expectedWebhookEvents = ["parse.success", "parse.error"];
        Dictionary<string, JsonElement> expectedWebhookHeaders = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, WebhookOutputFormat> expectedWebhookOutputFormat = WebhookOutputFormat.Json;
        string expectedWebhookSigningSecret = "webhook_signing_secret";
        string expectedWebhookUrl = "https:";

        Assert.NotNull(model.WebhookEvents);
        Assert.Equal(expectedWebhookEvents.Count, model.WebhookEvents.Count);
        for (int i = 0; i < expectedWebhookEvents.Count; i++)
        {
            Assert.Equal(expectedWebhookEvents[i], model.WebhookEvents[i]);
        }
        Assert.NotNull(model.WebhookHeaders);
        Assert.Equal(expectedWebhookHeaders.Count, model.WebhookHeaders.Count);
        foreach (var item in expectedWebhookHeaders)
        {
            Assert.True(model.WebhookHeaders.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.WebhookHeaders[item.Key]));
        }
        Assert.Equal(expectedWebhookOutputFormat, model.WebhookOutputFormat);
        Assert.Equal(expectedWebhookSigningSecret, model.WebhookSigningSecret);
        Assert.Equal(expectedWebhookUrl, model.WebhookUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookConfiguration
        {
            WebhookEvents = ["parse.success", "parse.error"],
            WebhookHeaders = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            WebhookOutputFormat = WebhookOutputFormat.Json,
            WebhookSigningSecret = "webhook_signing_secret",
            WebhookUrl = "https:",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookConfiguration
        {
            WebhookEvents = ["parse.success", "parse.error"],
            WebhookHeaders = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            WebhookOutputFormat = WebhookOutputFormat.Json,
            WebhookSigningSecret = "webhook_signing_secret",
            WebhookUrl = "https:",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedWebhookEvents = ["parse.success", "parse.error"];
        Dictionary<string, JsonElement> expectedWebhookHeaders = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, WebhookOutputFormat> expectedWebhookOutputFormat = WebhookOutputFormat.Json;
        string expectedWebhookSigningSecret = "webhook_signing_secret";
        string expectedWebhookUrl = "https:";

        Assert.NotNull(deserialized.WebhookEvents);
        Assert.Equal(expectedWebhookEvents.Count, deserialized.WebhookEvents.Count);
        for (int i = 0; i < expectedWebhookEvents.Count; i++)
        {
            Assert.Equal(expectedWebhookEvents[i], deserialized.WebhookEvents[i]);
        }
        Assert.NotNull(deserialized.WebhookHeaders);
        Assert.Equal(expectedWebhookHeaders.Count, deserialized.WebhookHeaders.Count);
        foreach (var item in expectedWebhookHeaders)
        {
            Assert.True(deserialized.WebhookHeaders.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.WebhookHeaders[item.Key]));
        }
        Assert.Equal(expectedWebhookOutputFormat, deserialized.WebhookOutputFormat);
        Assert.Equal(expectedWebhookSigningSecret, deserialized.WebhookSigningSecret);
        Assert.Equal(expectedWebhookUrl, deserialized.WebhookUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookConfiguration
        {
            WebhookEvents = ["parse.success", "parse.error"],
            WebhookHeaders = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            WebhookOutputFormat = WebhookOutputFormat.Json,
            WebhookSigningSecret = "webhook_signing_secret",
            WebhookUrl = "https:",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookConfiguration { };

        Assert.Null(model.WebhookEvents);
        Assert.False(model.RawData.ContainsKey("webhook_events"));
        Assert.Null(model.WebhookHeaders);
        Assert.False(model.RawData.ContainsKey("webhook_headers"));
        Assert.Null(model.WebhookOutputFormat);
        Assert.False(model.RawData.ContainsKey("webhook_output_format"));
        Assert.Null(model.WebhookSigningSecret);
        Assert.False(model.RawData.ContainsKey("webhook_signing_secret"));
        Assert.Null(model.WebhookUrl);
        Assert.False(model.RawData.ContainsKey("webhook_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookConfiguration { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookConfiguration
        {
            WebhookEvents = null,
            WebhookHeaders = null,
            WebhookOutputFormat = null,
            WebhookSigningSecret = null,
            WebhookUrl = null,
        };

        Assert.Null(model.WebhookEvents);
        Assert.True(model.RawData.ContainsKey("webhook_events"));
        Assert.Null(model.WebhookHeaders);
        Assert.True(model.RawData.ContainsKey("webhook_headers"));
        Assert.Null(model.WebhookOutputFormat);
        Assert.True(model.RawData.ContainsKey("webhook_output_format"));
        Assert.Null(model.WebhookSigningSecret);
        Assert.True(model.RawData.ContainsKey("webhook_signing_secret"));
        Assert.Null(model.WebhookUrl);
        Assert.True(model.RawData.ContainsKey("webhook_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookConfiguration
        {
            WebhookEvents = null,
            WebhookHeaders = null,
            WebhookOutputFormat = null,
            WebhookSigningSecret = null,
            WebhookUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookConfiguration
        {
            WebhookEvents = ["parse.success", "parse.error"],
            WebhookHeaders = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            WebhookOutputFormat = WebhookOutputFormat.Json,
            WebhookSigningSecret = "webhook_signing_secret",
            WebhookUrl = "https:",
        };

        WebhookConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookOutputFormatTest : TestBase
{
    [Theory]
    [InlineData(WebhookOutputFormat.Json)]
    [InlineData(WebhookOutputFormat.String)]
    public void Validation_Works(WebhookOutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookOutputFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookOutputFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookOutputFormat.Json)]
    [InlineData(WebhookOutputFormat.String)]
    public void SerializationRoundtrip_Works(WebhookOutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookOutputFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookOutputFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookOutputFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookOutputFormat>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
