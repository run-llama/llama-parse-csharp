using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using Batches = LlamaCloud.Models.Batches;

namespace LlamaCloud.Tests.Models.Batches;

public class BatchCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Batches::BatchCreateParams
        {
            Config = new(
                new Batches::Job()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = Batches::Type.ParseV2,
                }
            ),
            SourceDirectoryID = "dir-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WebhookConfigurationIds = ["whc-...", "whc-..."],
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents =
                    [
                        Batches::WebhookEvent.ParseSuccess,
                        Batches::WebhookEvent.ParseError,
                    ],
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

        Batches::Config expectedConfig = new(
            new Batches::Job()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = Batches::Type.ParseV2,
            }
        );
        string expectedSourceDirectoryID = "dir-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<string> expectedWebhookConfigurationIds = ["whc-...", "whc-..."];
        List<Batches::WebhookConfiguration> expectedWebhookConfigurations =
        [
            new()
            {
                WebhookEvents =
                [
                    Batches::WebhookEvent.ParseSuccess,
                    Batches::WebhookEvent.ParseError,
                ],
                WebhookHeaders = new Dictionary<string, string>()
                {
                    { "Authorization", "Bearer sk-..." },
                },
                WebhookOutputFormat = "json",
                WebhookSigningSecret = "whsec_...",
                WebhookUrl = "https://example.com/webhooks/llamacloud",
            },
        ];

        Assert.Equal(expectedConfig, parameters.Config);
        Assert.Equal(expectedSourceDirectoryID, parameters.SourceDirectoryID);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
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
        var parameters = new Batches::BatchCreateParams
        {
            Config = new(
                new Batches::Job()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = Batches::Type.ParseV2,
                }
            ),
            SourceDirectoryID = "dir-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.WebhookConfigurationIds);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_configuration_ids"));
        Assert.Null(parameters.WebhookConfigurations);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_configurations"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Batches::BatchCreateParams
        {
            Config = new(
                new Batches::Job()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = Batches::Type.ParseV2,
                }
            ),
            SourceDirectoryID = "dir-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",

            OrganizationID = null,
            ProjectID = null,
            WebhookConfigurationIds = null,
            WebhookConfigurations = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.WebhookConfigurationIds);
        Assert.True(parameters.RawBodyData.ContainsKey("webhook_configuration_ids"));
        Assert.Null(parameters.WebhookConfigurations);
        Assert.True(parameters.RawBodyData.ContainsKey("webhook_configurations"));
    }

    [Fact]
    public void Url_Works()
    {
        Batches::BatchCreateParams parameters = new()
        {
            Config = new(
                new Batches::Job()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = Batches::Type.ParseV2,
                }
            ),
            SourceDirectoryID = "dir-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v2/batches?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Batches::BatchCreateParams
        {
            Config = new(
                new Batches::Job()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = Batches::Type.ParseV2,
                }
            ),
            SourceDirectoryID = "dir-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WebhookConfigurationIds = ["whc-...", "whc-..."],
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents =
                    [
                        Batches::WebhookEvent.ParseSuccess,
                        Batches::WebhookEvent.ParseError,
                    ],
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

        Batches::BatchCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Batches::Config
        {
            Job = new() { ConfigurationID = "cfg-PARSE_AGENTIC", Type = Batches::Type.ParseV2 },
        };

        Batches::Job expectedJob = new()
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = Batches::Type.ParseV2,
        };

        Assert.Equal(expectedJob, model.Job);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Batches::Config
        {
            Job = new() { ConfigurationID = "cfg-PARSE_AGENTIC", Type = Batches::Type.ParseV2 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Batches::Config>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Batches::Config
        {
            Job = new() { ConfigurationID = "cfg-PARSE_AGENTIC", Type = Batches::Type.ParseV2 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Batches::Config>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Batches::Job expectedJob = new()
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = Batches::Type.ParseV2,
        };

        Assert.Equal(expectedJob, deserialized.Job);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Batches::Config
        {
            Job = new() { ConfigurationID = "cfg-PARSE_AGENTIC", Type = Batches::Type.ParseV2 },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Batches::Config
        {
            Job = new() { ConfigurationID = "cfg-PARSE_AGENTIC", Type = Batches::Type.ParseV2 },
        };

        Batches::Config copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Batches::Job
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = Batches::Type.ParseV2,
        };

        string expectedConfigurationID = "cfg-PARSE_AGENTIC";
        ApiEnum<string, Batches::Type> expectedType = Batches::Type.ParseV2;

        Assert.Equal(expectedConfigurationID, model.ConfigurationID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Batches::Job
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = Batches::Type.ParseV2,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Batches::Job>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Batches::Job
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = Batches::Type.ParseV2,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Batches::Job>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedConfigurationID = "cfg-PARSE_AGENTIC";
        ApiEnum<string, Batches::Type> expectedType = Batches::Type.ParseV2;

        Assert.Equal(expectedConfigurationID, deserialized.ConfigurationID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Batches::Job
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = Batches::Type.ParseV2,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Batches::Job
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = Batches::Type.ParseV2,
        };

        Batches::Job copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Batches::Type.ParseV2)]
    [InlineData(Batches::Type.ExtractV2)]
    public void Validation_Works(Batches::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Batches::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Batches::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Batches::Type.ParseV2)]
    [InlineData(Batches::Type.ExtractV2)]
    public void SerializationRoundtrip_Works(Batches::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Batches::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Batches::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Batches::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Batches::Type>>(
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
        var model = new Batches::WebhookConfiguration
        {
            WebhookEvents = [Batches::WebhookEvent.ParseSuccess, Batches::WebhookEvent.ParseError],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        List<ApiEnum<string, Batches::WebhookEvent>> expectedWebhookEvents =
        [
            Batches::WebhookEvent.ParseSuccess,
            Batches::WebhookEvent.ParseError,
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
        var model = new Batches::WebhookConfiguration
        {
            WebhookEvents = [Batches::WebhookEvent.ParseSuccess, Batches::WebhookEvent.ParseError],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Batches::WebhookConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Batches::WebhookConfiguration
        {
            WebhookEvents = [Batches::WebhookEvent.ParseSuccess, Batches::WebhookEvent.ParseError],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Batches::WebhookConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ApiEnum<string, Batches::WebhookEvent>> expectedWebhookEvents =
        [
            Batches::WebhookEvent.ParseSuccess,
            Batches::WebhookEvent.ParseError,
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
        var model = new Batches::WebhookConfiguration
        {
            WebhookEvents = [Batches::WebhookEvent.ParseSuccess, Batches::WebhookEvent.ParseError],
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
        var model = new Batches::WebhookConfiguration { };

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
        var model = new Batches::WebhookConfiguration { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Batches::WebhookConfiguration
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
        var model = new Batches::WebhookConfiguration
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
        var model = new Batches::WebhookConfiguration
        {
            WebhookEvents = [Batches::WebhookEvent.ParseSuccess, Batches::WebhookEvent.ParseError],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        Batches::WebhookConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookEventTest : TestBase
{
    [Theory]
    [InlineData(Batches::WebhookEvent.BatchCancelled)]
    [InlineData(Batches::WebhookEvent.BatchError)]
    [InlineData(Batches::WebhookEvent.BatchPending)]
    [InlineData(Batches::WebhookEvent.BatchRunning)]
    [InlineData(Batches::WebhookEvent.BatchSuccess)]
    [InlineData(Batches::WebhookEvent.ClassifyCancelled)]
    [InlineData(Batches::WebhookEvent.ClassifyError)]
    [InlineData(Batches::WebhookEvent.ClassifyPartialSuccess)]
    [InlineData(Batches::WebhookEvent.ClassifyPending)]
    [InlineData(Batches::WebhookEvent.ClassifyRunning)]
    [InlineData(Batches::WebhookEvent.ClassifySuccess)]
    [InlineData(Batches::WebhookEvent.ExtractCancelled)]
    [InlineData(Batches::WebhookEvent.ExtractError)]
    [InlineData(Batches::WebhookEvent.ExtractPartialSuccess)]
    [InlineData(Batches::WebhookEvent.ExtractPending)]
    [InlineData(Batches::WebhookEvent.ExtractSuccess)]
    [InlineData(Batches::WebhookEvent.ParseCancelled)]
    [InlineData(Batches::WebhookEvent.ParseError)]
    [InlineData(Batches::WebhookEvent.ParsePartialSuccess)]
    [InlineData(Batches::WebhookEvent.ParsePending)]
    [InlineData(Batches::WebhookEvent.ParseRunning)]
    [InlineData(Batches::WebhookEvent.ParseSuccess)]
    [InlineData(Batches::WebhookEvent.SheetsCancelled)]
    [InlineData(Batches::WebhookEvent.SheetsError)]
    [InlineData(Batches::WebhookEvent.SheetsPartialSuccess)]
    [InlineData(Batches::WebhookEvent.SheetsPending)]
    [InlineData(Batches::WebhookEvent.SheetsSuccess)]
    [InlineData(Batches::WebhookEvent.SplitCancelled)]
    [InlineData(Batches::WebhookEvent.SplitError)]
    [InlineData(Batches::WebhookEvent.SplitPending)]
    [InlineData(Batches::WebhookEvent.SplitProcessing)]
    [InlineData(Batches::WebhookEvent.SplitSuccess)]
    [InlineData(Batches::WebhookEvent.UnmappedEvent)]
    public void Validation_Works(Batches::WebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Batches::WebhookEvent> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Batches::WebhookEvent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Batches::WebhookEvent.BatchCancelled)]
    [InlineData(Batches::WebhookEvent.BatchError)]
    [InlineData(Batches::WebhookEvent.BatchPending)]
    [InlineData(Batches::WebhookEvent.BatchRunning)]
    [InlineData(Batches::WebhookEvent.BatchSuccess)]
    [InlineData(Batches::WebhookEvent.ClassifyCancelled)]
    [InlineData(Batches::WebhookEvent.ClassifyError)]
    [InlineData(Batches::WebhookEvent.ClassifyPartialSuccess)]
    [InlineData(Batches::WebhookEvent.ClassifyPending)]
    [InlineData(Batches::WebhookEvent.ClassifyRunning)]
    [InlineData(Batches::WebhookEvent.ClassifySuccess)]
    [InlineData(Batches::WebhookEvent.ExtractCancelled)]
    [InlineData(Batches::WebhookEvent.ExtractError)]
    [InlineData(Batches::WebhookEvent.ExtractPartialSuccess)]
    [InlineData(Batches::WebhookEvent.ExtractPending)]
    [InlineData(Batches::WebhookEvent.ExtractSuccess)]
    [InlineData(Batches::WebhookEvent.ParseCancelled)]
    [InlineData(Batches::WebhookEvent.ParseError)]
    [InlineData(Batches::WebhookEvent.ParsePartialSuccess)]
    [InlineData(Batches::WebhookEvent.ParsePending)]
    [InlineData(Batches::WebhookEvent.ParseRunning)]
    [InlineData(Batches::WebhookEvent.ParseSuccess)]
    [InlineData(Batches::WebhookEvent.SheetsCancelled)]
    [InlineData(Batches::WebhookEvent.SheetsError)]
    [InlineData(Batches::WebhookEvent.SheetsPartialSuccess)]
    [InlineData(Batches::WebhookEvent.SheetsPending)]
    [InlineData(Batches::WebhookEvent.SheetsSuccess)]
    [InlineData(Batches::WebhookEvent.SplitCancelled)]
    [InlineData(Batches::WebhookEvent.SplitError)]
    [InlineData(Batches::WebhookEvent.SplitPending)]
    [InlineData(Batches::WebhookEvent.SplitProcessing)]
    [InlineData(Batches::WebhookEvent.SplitSuccess)]
    [InlineData(Batches::WebhookEvent.UnmappedEvent)]
    public void SerializationRoundtrip_Works(Batches::WebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Batches::WebhookEvent> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Batches::WebhookEvent>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Batches::WebhookEvent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Batches::WebhookEvent>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
