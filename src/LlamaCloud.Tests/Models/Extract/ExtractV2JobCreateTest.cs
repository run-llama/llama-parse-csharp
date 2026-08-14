using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Extract;

namespace LlamaCloud.Tests.Models.Extract;

public class ExtractV2JobCreateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractV2JobCreate
        {
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Configuration = new()
            {
                DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
                {
                    {
                        "properties",
                        new(
                            new Dictionary<string, JsonElement>()
                            {
                                { "total_amount", JsonSerializer.SerializeToElement("bar") },
                                { "vendor_name", JsonSerializer.SerializeToElement("bar") },
                            }
                        )
                    },
                    {
                        "required",
                        new(
                            [
                                JsonSerializer.SerializeToElement("total_amount"),
                                JsonSerializer.SerializeToElement("vendor_name"),
                            ]
                        )
                    },
                    { "type", "object" },
                },
                CiteSources = true,
                ConfidenceScores = true,
                DisableCache = true,
                ExtractionTarget = ExtractionTarget.PerDoc,
                MaxPages = 10,
                ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
                ParseTier = "fast",
                SheetNames = ["Sheet 1", "Q4 Summary"],
                SpreadsheetMode = true,
                SystemPrompt =
                    "Extract all monetary values in USD. If a currency is not specified, assume USD.",
                TargetPages = "1,3,5-7",
                Tier = Tier.CostEffective,
                Version = "latest",
            },
            ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
            WebhookConfigurationIds = ["whc-...", "whc-..."],
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents =
                    [
                        ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess,
                        ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError,
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

        string expectedFileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        ExtractConfiguration expectedConfiguration = new()
        {
            DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
            {
                {
                    "properties",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "total_amount", JsonSerializer.SerializeToElement("bar") },
                            { "vendor_name", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
                {
                    "required",
                    new(
                        [
                            JsonSerializer.SerializeToElement("total_amount"),
                            JsonSerializer.SerializeToElement("vendor_name"),
                        ]
                    )
                },
                { "type", "object" },
            },
            CiteSources = true,
            ConfidenceScores = true,
            DisableCache = true,
            ExtractionTarget = ExtractionTarget.PerDoc,
            MaxPages = 10,
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = "fast",
            SheetNames = ["Sheet 1", "Q4 Summary"],
            SpreadsheetMode = true,
            SystemPrompt =
                "Extract all monetary values in USD. If a currency is not specified, assume USD.",
            TargetPages = "1,3,5-7",
            Tier = Tier.CostEffective,
            Version = "latest",
        };
        string expectedConfigurationID = "cfg-11111111-2222-3333-4444-555555555555";
        List<string> expectedWebhookConfigurationIds = ["whc-...", "whc-..."];
        List<ExtractV2JobCreateWebhookConfiguration> expectedWebhookConfigurations =
        [
            new()
            {
                WebhookEvents =
                [
                    ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess,
                    ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError,
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

        Assert.Equal(expectedFileInput, model.FileInput);
        Assert.Equal(expectedConfiguration, model.Configuration);
        Assert.Equal(expectedConfigurationID, model.ConfigurationID);
        Assert.NotNull(model.WebhookConfigurationIds);
        Assert.Equal(expectedWebhookConfigurationIds.Count, model.WebhookConfigurationIds.Count);
        for (int i = 0; i < expectedWebhookConfigurationIds.Count; i++)
        {
            Assert.Equal(expectedWebhookConfigurationIds[i], model.WebhookConfigurationIds[i]);
        }
        Assert.NotNull(model.WebhookConfigurations);
        Assert.Equal(expectedWebhookConfigurations.Count, model.WebhookConfigurations.Count);
        for (int i = 0; i < expectedWebhookConfigurations.Count; i++)
        {
            Assert.Equal(expectedWebhookConfigurations[i], model.WebhookConfigurations[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExtractV2JobCreate
        {
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Configuration = new()
            {
                DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
                {
                    {
                        "properties",
                        new(
                            new Dictionary<string, JsonElement>()
                            {
                                { "total_amount", JsonSerializer.SerializeToElement("bar") },
                                { "vendor_name", JsonSerializer.SerializeToElement("bar") },
                            }
                        )
                    },
                    {
                        "required",
                        new(
                            [
                                JsonSerializer.SerializeToElement("total_amount"),
                                JsonSerializer.SerializeToElement("vendor_name"),
                            ]
                        )
                    },
                    { "type", "object" },
                },
                CiteSources = true,
                ConfidenceScores = true,
                DisableCache = true,
                ExtractionTarget = ExtractionTarget.PerDoc,
                MaxPages = 10,
                ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
                ParseTier = "fast",
                SheetNames = ["Sheet 1", "Q4 Summary"],
                SpreadsheetMode = true,
                SystemPrompt =
                    "Extract all monetary values in USD. If a currency is not specified, assume USD.",
                TargetPages = "1,3,5-7",
                Tier = Tier.CostEffective,
                Version = "latest",
            },
            ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
            WebhookConfigurationIds = ["whc-...", "whc-..."],
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents =
                    [
                        ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess,
                        ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError,
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2JobCreate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractV2JobCreate
        {
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Configuration = new()
            {
                DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
                {
                    {
                        "properties",
                        new(
                            new Dictionary<string, JsonElement>()
                            {
                                { "total_amount", JsonSerializer.SerializeToElement("bar") },
                                { "vendor_name", JsonSerializer.SerializeToElement("bar") },
                            }
                        )
                    },
                    {
                        "required",
                        new(
                            [
                                JsonSerializer.SerializeToElement("total_amount"),
                                JsonSerializer.SerializeToElement("vendor_name"),
                            ]
                        )
                    },
                    { "type", "object" },
                },
                CiteSources = true,
                ConfidenceScores = true,
                DisableCache = true,
                ExtractionTarget = ExtractionTarget.PerDoc,
                MaxPages = 10,
                ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
                ParseTier = "fast",
                SheetNames = ["Sheet 1", "Q4 Summary"],
                SpreadsheetMode = true,
                SystemPrompt =
                    "Extract all monetary values in USD. If a currency is not specified, assume USD.",
                TargetPages = "1,3,5-7",
                Tier = Tier.CostEffective,
                Version = "latest",
            },
            ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
            WebhookConfigurationIds = ["whc-...", "whc-..."],
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents =
                    [
                        ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess,
                        ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError,
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2JobCreate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        ExtractConfiguration expectedConfiguration = new()
        {
            DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
            {
                {
                    "properties",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "total_amount", JsonSerializer.SerializeToElement("bar") },
                            { "vendor_name", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
                {
                    "required",
                    new(
                        [
                            JsonSerializer.SerializeToElement("total_amount"),
                            JsonSerializer.SerializeToElement("vendor_name"),
                        ]
                    )
                },
                { "type", "object" },
            },
            CiteSources = true,
            ConfidenceScores = true,
            DisableCache = true,
            ExtractionTarget = ExtractionTarget.PerDoc,
            MaxPages = 10,
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = "fast",
            SheetNames = ["Sheet 1", "Q4 Summary"],
            SpreadsheetMode = true,
            SystemPrompt =
                "Extract all monetary values in USD. If a currency is not specified, assume USD.",
            TargetPages = "1,3,5-7",
            Tier = Tier.CostEffective,
            Version = "latest",
        };
        string expectedConfigurationID = "cfg-11111111-2222-3333-4444-555555555555";
        List<string> expectedWebhookConfigurationIds = ["whc-...", "whc-..."];
        List<ExtractV2JobCreateWebhookConfiguration> expectedWebhookConfigurations =
        [
            new()
            {
                WebhookEvents =
                [
                    ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess,
                    ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError,
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

        Assert.Equal(expectedFileInput, deserialized.FileInput);
        Assert.Equal(expectedConfiguration, deserialized.Configuration);
        Assert.Equal(expectedConfigurationID, deserialized.ConfigurationID);
        Assert.NotNull(deserialized.WebhookConfigurationIds);
        Assert.Equal(
            expectedWebhookConfigurationIds.Count,
            deserialized.WebhookConfigurationIds.Count
        );
        for (int i = 0; i < expectedWebhookConfigurationIds.Count; i++)
        {
            Assert.Equal(
                expectedWebhookConfigurationIds[i],
                deserialized.WebhookConfigurationIds[i]
            );
        }
        Assert.NotNull(deserialized.WebhookConfigurations);
        Assert.Equal(expectedWebhookConfigurations.Count, deserialized.WebhookConfigurations.Count);
        for (int i = 0; i < expectedWebhookConfigurations.Count; i++)
        {
            Assert.Equal(expectedWebhookConfigurations[i], deserialized.WebhookConfigurations[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExtractV2JobCreate
        {
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Configuration = new()
            {
                DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
                {
                    {
                        "properties",
                        new(
                            new Dictionary<string, JsonElement>()
                            {
                                { "total_amount", JsonSerializer.SerializeToElement("bar") },
                                { "vendor_name", JsonSerializer.SerializeToElement("bar") },
                            }
                        )
                    },
                    {
                        "required",
                        new(
                            [
                                JsonSerializer.SerializeToElement("total_amount"),
                                JsonSerializer.SerializeToElement("vendor_name"),
                            ]
                        )
                    },
                    { "type", "object" },
                },
                CiteSources = true,
                ConfidenceScores = true,
                DisableCache = true,
                ExtractionTarget = ExtractionTarget.PerDoc,
                MaxPages = 10,
                ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
                ParseTier = "fast",
                SheetNames = ["Sheet 1", "Q4 Summary"],
                SpreadsheetMode = true,
                SystemPrompt =
                    "Extract all monetary values in USD. If a currency is not specified, assume USD.",
                TargetPages = "1,3,5-7",
                Tier = Tier.CostEffective,
                Version = "latest",
            },
            ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
            WebhookConfigurationIds = ["whc-...", "whc-..."],
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents =
                    [
                        ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess,
                        ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError,
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExtractV2JobCreate
        {
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        Assert.Null(model.Configuration);
        Assert.False(model.RawData.ContainsKey("configuration"));
        Assert.Null(model.ConfigurationID);
        Assert.False(model.RawData.ContainsKey("configuration_id"));
        Assert.Null(model.WebhookConfigurationIds);
        Assert.False(model.RawData.ContainsKey("webhook_configuration_ids"));
        Assert.Null(model.WebhookConfigurations);
        Assert.False(model.RawData.ContainsKey("webhook_configurations"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExtractV2JobCreate
        {
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ExtractV2JobCreate
        {
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",

            Configuration = null,
            ConfigurationID = null,
            WebhookConfigurationIds = null,
            WebhookConfigurations = null,
        };

        Assert.Null(model.Configuration);
        Assert.True(model.RawData.ContainsKey("configuration"));
        Assert.Null(model.ConfigurationID);
        Assert.True(model.RawData.ContainsKey("configuration_id"));
        Assert.Null(model.WebhookConfigurationIds);
        Assert.True(model.RawData.ContainsKey("webhook_configuration_ids"));
        Assert.Null(model.WebhookConfigurations);
        Assert.True(model.RawData.ContainsKey("webhook_configurations"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExtractV2JobCreate
        {
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",

            Configuration = null,
            ConfigurationID = null,
            WebhookConfigurationIds = null,
            WebhookConfigurations = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExtractV2JobCreate
        {
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Configuration = new()
            {
                DataSchema = new Dictionary<string, ExtractConfigurationDataSchema?>()
                {
                    {
                        "properties",
                        new(
                            new Dictionary<string, JsonElement>()
                            {
                                { "total_amount", JsonSerializer.SerializeToElement("bar") },
                                { "vendor_name", JsonSerializer.SerializeToElement("bar") },
                            }
                        )
                    },
                    {
                        "required",
                        new(
                            [
                                JsonSerializer.SerializeToElement("total_amount"),
                                JsonSerializer.SerializeToElement("vendor_name"),
                            ]
                        )
                    },
                    { "type", "object" },
                },
                CiteSources = true,
                ConfidenceScores = true,
                DisableCache = true,
                ExtractionTarget = ExtractionTarget.PerDoc,
                MaxPages = 10,
                ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
                ParseTier = "fast",
                SheetNames = ["Sheet 1", "Q4 Summary"],
                SpreadsheetMode = true,
                SystemPrompt =
                    "Extract all monetary values in USD. If a currency is not specified, assume USD.",
                TargetPages = "1,3,5-7",
                Tier = Tier.CostEffective,
                Version = "latest",
            },
            ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
            WebhookConfigurationIds = ["whc-...", "whc-..."],
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents =
                    [
                        ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess,
                        ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError,
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

        ExtractV2JobCreate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtractV2JobCreateWebhookConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExtractV2JobCreateWebhookConfiguration
        {
            WebhookEvents =
            [
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess,
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError,
            ],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        List<
            ApiEnum<string, ExtractV2JobCreateWebhookConfigurationWebhookEvent>
        > expectedWebhookEvents =
        [
            ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess,
            ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError,
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
        var model = new ExtractV2JobCreateWebhookConfiguration
        {
            WebhookEvents =
            [
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess,
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError,
            ],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2JobCreateWebhookConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExtractV2JobCreateWebhookConfiguration
        {
            WebhookEvents =
            [
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess,
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError,
            ],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExtractV2JobCreateWebhookConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<
            ApiEnum<string, ExtractV2JobCreateWebhookConfigurationWebhookEvent>
        > expectedWebhookEvents =
        [
            ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess,
            ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError,
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
        var model = new ExtractV2JobCreateWebhookConfiguration
        {
            WebhookEvents =
            [
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess,
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError,
            ],
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
        var model = new ExtractV2JobCreateWebhookConfiguration { };

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
        var model = new ExtractV2JobCreateWebhookConfiguration { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ExtractV2JobCreateWebhookConfiguration
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
        var model = new ExtractV2JobCreateWebhookConfiguration
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
        var model = new ExtractV2JobCreateWebhookConfiguration
        {
            WebhookEvents =
            [
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess,
                ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError,
            ],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        ExtractV2JobCreateWebhookConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ExtractV2JobCreateWebhookConfigurationWebhookEventTest : TestBase
{
    [Theory]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchCancelled)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchError)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchPending)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchRunning)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyCancelled)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyError)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyPartialSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyPending)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyRunning)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifySuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractCancelled)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractError)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractPartialSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractPending)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseCancelled)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParsePartialSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParsePending)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseRunning)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsCancelled)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsError)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsPartialSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsPending)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitCancelled)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitError)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitPending)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitProcessing)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.UnmappedEvent)]
    public void Validation_Works(ExtractV2JobCreateWebhookConfigurationWebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractV2JobCreateWebhookConfigurationWebhookEvent> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExtractV2JobCreateWebhookConfigurationWebhookEvent>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchCancelled)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchError)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchPending)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchRunning)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.BatchSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyCancelled)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyError)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyPartialSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyPending)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifyRunning)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ClassifySuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractCancelled)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractError)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractPartialSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractPending)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ExtractSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseCancelled)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseError)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParsePartialSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParsePending)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseRunning)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.ParseSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsCancelled)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsError)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsPartialSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsPending)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SheetsSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitCancelled)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitError)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitPending)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitProcessing)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.SplitSuccess)]
    [InlineData(ExtractV2JobCreateWebhookConfigurationWebhookEvent.UnmappedEvent)]
    public void SerializationRoundtrip_Works(
        ExtractV2JobCreateWebhookConfigurationWebhookEvent rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ExtractV2JobCreateWebhookConfigurationWebhookEvent> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExtractV2JobCreateWebhookConfigurationWebhookEvent>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ExtractV2JobCreateWebhookConfigurationWebhookEvent>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ExtractV2JobCreateWebhookConfigurationWebhookEvent>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
