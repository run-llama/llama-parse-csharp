using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Beta.Sheets;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Sheets;

public class SheetCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SheetCreateParams
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Config = new()
            {
                ExtractionRange = "extraction_range",
                FlattenHierarchicalTables = true,
                GenerateAdditionalMetadata = true,
                IncludeHiddenCells = true,
                SheetNames = ["string"],
                Specialization = "specialization",
                TableMergeSensitivity = TableMergeSensitivity.Strong,
                Tier = Tier.Agentic,
                UseExperimentalProcessing = true,
            },
            Configuration = new()
            {
                ExtractionRange = "extraction_range",
                FlattenHierarchicalTables = true,
                GenerateAdditionalMetadata = true,
                IncludeHiddenCells = true,
                SheetNames = ["string"],
                Specialization = "specialization",
                TableMergeSensitivity = TableMergeSensitivity.Strong,
                Tier = Tier.Agentic,
                UseExperimentalProcessing = true,
            },
            ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
            WebhookConfigurationIds = ["whc-...", "whc-..."],
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
                    WebhookHeaders = new Dictionary<string, string>()
                    {
                        { "Authorization", "Bearer sk-..." },
                    },
                    WebhookOutputFormat = "json",
                    WebhookSigningSecret = "whsec_...",
                    WebhookUrl = "https://example.com/webhooks/llamacloud",
                },
            ],
        };

        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        SheetsParsingConfig expectedConfig = new()
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity = TableMergeSensitivity.Strong,
            Tier = Tier.Agentic,
            UseExperimentalProcessing = true,
        };
        SheetsParsingConfig expectedConfiguration = new()
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity = TableMergeSensitivity.Strong,
            Tier = Tier.Agentic,
            UseExperimentalProcessing = true,
        };
        string expectedConfigurationID = "cfg-11111111-2222-3333-4444-555555555555";
        List<string> expectedWebhookConfigurationIds = ["whc-...", "whc-..."];
        List<WebhookConfiguration> expectedWebhookConfigurations =
        [
            new()
            {
                WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
                WebhookHeaders = new Dictionary<string, string>()
                {
                    { "Authorization", "Bearer sk-..." },
                },
                WebhookOutputFormat = "json",
                WebhookSigningSecret = "whsec_...",
                WebhookUrl = "https://example.com/webhooks/llamacloud",
            },
        ];

        Assert.Equal(expectedFileID, parameters.FileID);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedConfig, parameters.Config);
        Assert.Equal(expectedConfiguration, parameters.Configuration);
        Assert.Equal(expectedConfigurationID, parameters.ConfigurationID);
        Assert.NotNull(parameters.WebhookConfigurationIds);
        Assert.Equal(
            expectedWebhookConfigurationIds.Count,
            parameters.WebhookConfigurationIds.Count
        );
        for (int i = 0; i < expectedWebhookConfigurationIds.Count; i++)
        {
            Assert.Equal(expectedWebhookConfigurationIds[i], parameters.WebhookConfigurationIds[i]);
        }
        Assert.NotNull(parameters.WebhookConfigurations);
        Assert.Equal(expectedWebhookConfigurations.Count, parameters.WebhookConfigurations.Count);
        for (int i = 0; i < expectedWebhookConfigurations.Count; i++)
        {
            Assert.Equal(expectedWebhookConfigurations[i], parameters.WebhookConfigurations[i]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SheetCreateParams { FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Config);
        Assert.False(parameters.RawBodyData.ContainsKey("config"));
        Assert.Null(parameters.Configuration);
        Assert.False(parameters.RawBodyData.ContainsKey("configuration"));
        Assert.Null(parameters.ConfigurationID);
        Assert.False(parameters.RawBodyData.ContainsKey("configuration_id"));
        Assert.Null(parameters.WebhookConfigurationIds);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_configuration_ids"));
        Assert.Null(parameters.WebhookConfigurations);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_configurations"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SheetCreateParams
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            OrganizationID = null,
            ProjectID = null,
            Config = null,
            Configuration = null,
            ConfigurationID = null,
            WebhookConfigurationIds = null,
            WebhookConfigurations = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Config);
        Assert.True(parameters.RawBodyData.ContainsKey("config"));
        Assert.Null(parameters.Configuration);
        Assert.True(parameters.RawBodyData.ContainsKey("configuration"));
        Assert.Null(parameters.ConfigurationID);
        Assert.True(parameters.RawBodyData.ContainsKey("configuration_id"));
        Assert.Null(parameters.WebhookConfigurationIds);
        Assert.True(parameters.RawBodyData.ContainsKey("webhook_configuration_ids"));
        Assert.Null(parameters.WebhookConfigurations);
        Assert.True(parameters.RawBodyData.ContainsKey("webhook_configurations"));
    }

    [Fact]
    public void Url_Works()
    {
        SheetCreateParams parameters = new()
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/sheets/jobs?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SheetCreateParams
        {
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Config = new()
            {
                ExtractionRange = "extraction_range",
                FlattenHierarchicalTables = true,
                GenerateAdditionalMetadata = true,
                IncludeHiddenCells = true,
                SheetNames = ["string"],
                Specialization = "specialization",
                TableMergeSensitivity = TableMergeSensitivity.Strong,
                Tier = Tier.Agentic,
                UseExperimentalProcessing = true,
            },
            Configuration = new()
            {
                ExtractionRange = "extraction_range",
                FlattenHierarchicalTables = true,
                GenerateAdditionalMetadata = true,
                IncludeHiddenCells = true,
                SheetNames = ["string"],
                Specialization = "specialization",
                TableMergeSensitivity = TableMergeSensitivity.Strong,
                Tier = Tier.Agentic,
                UseExperimentalProcessing = true,
            },
            ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
            WebhookConfigurationIds = ["whc-...", "whc-..."],
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
                    WebhookHeaders = new Dictionary<string, string>()
                    {
                        { "Authorization", "Bearer sk-..." },
                    },
                    WebhookOutputFormat = "json",
                    WebhookSigningSecret = "whsec_...",
                    WebhookUrl = "https://example.com/webhooks/llamacloud",
                },
            ],
        };

        SheetCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class WebhookConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookConfiguration
        {
            WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        List<ApiEnum<string, WebhookEvent>> expectedWebhookEvents =
        [
            WebhookEvent.ParseSuccess,
            WebhookEvent.ParseError,
        ];
        Dictionary<string, string> expectedWebhookHeaders = new()
        {
            { "Authorization", "Bearer sk-..." },
        };
        string expectedWebhookOutputFormat = "json";
        string expectedWebhookSigningSecret = "whsec_...";
        string expectedWebhookUrl = "https://example.com/webhooks/llamacloud";

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

            Assert.Equal(value, model.WebhookHeaders[item.Key]);
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
            WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
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
            WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ApiEnum<string, WebhookEvent>> expectedWebhookEvents =
        [
            WebhookEvent.ParseSuccess,
            WebhookEvent.ParseError,
        ];
        Dictionary<string, string> expectedWebhookHeaders = new()
        {
            { "Authorization", "Bearer sk-..." },
        };
        string expectedWebhookOutputFormat = "json";
        string expectedWebhookSigningSecret = "whsec_...";
        string expectedWebhookUrl = "https://example.com/webhooks/llamacloud";

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

            Assert.Equal(value, deserialized.WebhookHeaders[item.Key]);
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
            WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
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
            WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        WebhookConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookEventTest : TestBase
{
    [Theory]
    [InlineData(WebhookEvent.BatchCancelled)]
    [InlineData(WebhookEvent.BatchError)]
    [InlineData(WebhookEvent.BatchPending)]
    [InlineData(WebhookEvent.BatchRunning)]
    [InlineData(WebhookEvent.BatchSuccess)]
    [InlineData(WebhookEvent.ClassifyCancelled)]
    [InlineData(WebhookEvent.ClassifyError)]
    [InlineData(WebhookEvent.ClassifyPartialSuccess)]
    [InlineData(WebhookEvent.ClassifyPending)]
    [InlineData(WebhookEvent.ClassifyRunning)]
    [InlineData(WebhookEvent.ClassifySuccess)]
    [InlineData(WebhookEvent.ExtractCancelled)]
    [InlineData(WebhookEvent.ExtractError)]
    [InlineData(WebhookEvent.ExtractPartialSuccess)]
    [InlineData(WebhookEvent.ExtractPending)]
    [InlineData(WebhookEvent.ExtractSuccess)]
    [InlineData(WebhookEvent.ParseCancelled)]
    [InlineData(WebhookEvent.ParseError)]
    [InlineData(WebhookEvent.ParsePartialSuccess)]
    [InlineData(WebhookEvent.ParsePending)]
    [InlineData(WebhookEvent.ParseRunning)]
    [InlineData(WebhookEvent.ParseSuccess)]
    [InlineData(WebhookEvent.SheetsCancelled)]
    [InlineData(WebhookEvent.SheetsError)]
    [InlineData(WebhookEvent.SheetsPartialSuccess)]
    [InlineData(WebhookEvent.SheetsPending)]
    [InlineData(WebhookEvent.SheetsSuccess)]
    [InlineData(WebhookEvent.SplitCancelled)]
    [InlineData(WebhookEvent.SplitError)]
    [InlineData(WebhookEvent.SplitPending)]
    [InlineData(WebhookEvent.SplitProcessing)]
    [InlineData(WebhookEvent.SplitSuccess)]
    [InlineData(WebhookEvent.UnmappedEvent)]
    public void Validation_Works(WebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookEvent> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookEvent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookEvent.BatchCancelled)]
    [InlineData(WebhookEvent.BatchError)]
    [InlineData(WebhookEvent.BatchPending)]
    [InlineData(WebhookEvent.BatchRunning)]
    [InlineData(WebhookEvent.BatchSuccess)]
    [InlineData(WebhookEvent.ClassifyCancelled)]
    [InlineData(WebhookEvent.ClassifyError)]
    [InlineData(WebhookEvent.ClassifyPartialSuccess)]
    [InlineData(WebhookEvent.ClassifyPending)]
    [InlineData(WebhookEvent.ClassifyRunning)]
    [InlineData(WebhookEvent.ClassifySuccess)]
    [InlineData(WebhookEvent.ExtractCancelled)]
    [InlineData(WebhookEvent.ExtractError)]
    [InlineData(WebhookEvent.ExtractPartialSuccess)]
    [InlineData(WebhookEvent.ExtractPending)]
    [InlineData(WebhookEvent.ExtractSuccess)]
    [InlineData(WebhookEvent.ParseCancelled)]
    [InlineData(WebhookEvent.ParseError)]
    [InlineData(WebhookEvent.ParsePartialSuccess)]
    [InlineData(WebhookEvent.ParsePending)]
    [InlineData(WebhookEvent.ParseRunning)]
    [InlineData(WebhookEvent.ParseSuccess)]
    [InlineData(WebhookEvent.SheetsCancelled)]
    [InlineData(WebhookEvent.SheetsError)]
    [InlineData(WebhookEvent.SheetsPartialSuccess)]
    [InlineData(WebhookEvent.SheetsPending)]
    [InlineData(WebhookEvent.SheetsSuccess)]
    [InlineData(WebhookEvent.SplitCancelled)]
    [InlineData(WebhookEvent.SplitError)]
    [InlineData(WebhookEvent.SplitPending)]
    [InlineData(WebhookEvent.SplitProcessing)]
    [InlineData(WebhookEvent.SplitSuccess)]
    [InlineData(WebhookEvent.UnmappedEvent)]
    public void SerializationRoundtrip_Works(WebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookEvent> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookEvent>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookEvent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookEvent>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
