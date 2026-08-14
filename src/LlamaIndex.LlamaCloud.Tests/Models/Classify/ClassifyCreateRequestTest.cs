using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Classify;

namespace LlamaIndex.LlamaCloud.Tests.Models.Classify;

public class ClassifyCreateRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClassifyCreateRequest
        {
            Configuration = new()
            {
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
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
            ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
            FileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ParseJobID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            TransactionID = "tx-unique-idempotency-key",
            WebhookConfigurationIds = ["whc-...", "whc-..."],
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents =
                    [
                        ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess,
                        ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError,
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

        ClassifyConfiguration expectedConfiguration = new()
        {
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
                Lang = "en",
                MaxPages = 10,
                TargetPages = "1,3,5-7",
            },
        };
        string expectedConfigurationID = "cfg-11111111-2222-3333-4444-555555555555";
        string expectedFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedFileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedParseJobID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedTransactionID = "tx-unique-idempotency-key";
        List<string> expectedWebhookConfigurationIds = ["whc-...", "whc-..."];
        List<ClassifyCreateRequestWebhookConfiguration> expectedWebhookConfigurations =
        [
            new()
            {
                WebhookEvents =
                [
                    ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess,
                    ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError,
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

        Assert.Equal(expectedConfiguration, model.Configuration);
        Assert.Equal(expectedConfigurationID, model.ConfigurationID);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedFileInput, model.FileInput);
        Assert.Equal(expectedParseJobID, model.ParseJobID);
        Assert.Equal(expectedTransactionID, model.TransactionID);
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
        var model = new ClassifyCreateRequest
        {
            Configuration = new()
            {
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
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
            ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
            FileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ParseJobID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            TransactionID = "tx-unique-idempotency-key",
            WebhookConfigurationIds = ["whc-...", "whc-..."],
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents =
                    [
                        ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess,
                        ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError,
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
        var deserialized = JsonSerializer.Deserialize<ClassifyCreateRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClassifyCreateRequest
        {
            Configuration = new()
            {
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
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
            ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
            FileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ParseJobID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            TransactionID = "tx-unique-idempotency-key",
            WebhookConfigurationIds = ["whc-...", "whc-..."],
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents =
                    [
                        ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess,
                        ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError,
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
        var deserialized = JsonSerializer.Deserialize<ClassifyCreateRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ClassifyConfiguration expectedConfiguration = new()
        {
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
                Lang = "en",
                MaxPages = 10,
                TargetPages = "1,3,5-7",
            },
        };
        string expectedConfigurationID = "cfg-11111111-2222-3333-4444-555555555555";
        string expectedFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedFileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedParseJobID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedTransactionID = "tx-unique-idempotency-key";
        List<string> expectedWebhookConfigurationIds = ["whc-...", "whc-..."];
        List<ClassifyCreateRequestWebhookConfiguration> expectedWebhookConfigurations =
        [
            new()
            {
                WebhookEvents =
                [
                    ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess,
                    ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError,
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

        Assert.Equal(expectedConfiguration, deserialized.Configuration);
        Assert.Equal(expectedConfigurationID, deserialized.ConfigurationID);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedFileInput, deserialized.FileInput);
        Assert.Equal(expectedParseJobID, deserialized.ParseJobID);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
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
        var model = new ClassifyCreateRequest
        {
            Configuration = new()
            {
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
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
            ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
            FileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ParseJobID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            TransactionID = "tx-unique-idempotency-key",
            WebhookConfigurationIds = ["whc-...", "whc-..."],
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents =
                    [
                        ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess,
                        ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError,
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
        var model = new ClassifyCreateRequest { };

        Assert.Null(model.Configuration);
        Assert.False(model.RawData.ContainsKey("configuration"));
        Assert.Null(model.ConfigurationID);
        Assert.False(model.RawData.ContainsKey("configuration_id"));
        Assert.Null(model.FileID);
        Assert.False(model.RawData.ContainsKey("file_id"));
        Assert.Null(model.FileInput);
        Assert.False(model.RawData.ContainsKey("file_input"));
        Assert.Null(model.ParseJobID);
        Assert.False(model.RawData.ContainsKey("parse_job_id"));
        Assert.Null(model.TransactionID);
        Assert.False(model.RawData.ContainsKey("transaction_id"));
        Assert.Null(model.WebhookConfigurationIds);
        Assert.False(model.RawData.ContainsKey("webhook_configuration_ids"));
        Assert.Null(model.WebhookConfigurations);
        Assert.False(model.RawData.ContainsKey("webhook_configurations"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ClassifyCreateRequest { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ClassifyCreateRequest
        {
            Configuration = null,
            ConfigurationID = null,
            FileID = null,
            FileInput = null,
            ParseJobID = null,
            TransactionID = null,
            WebhookConfigurationIds = null,
            WebhookConfigurations = null,
        };

        Assert.Null(model.Configuration);
        Assert.True(model.RawData.ContainsKey("configuration"));
        Assert.Null(model.ConfigurationID);
        Assert.True(model.RawData.ContainsKey("configuration_id"));
        Assert.Null(model.FileID);
        Assert.True(model.RawData.ContainsKey("file_id"));
        Assert.Null(model.FileInput);
        Assert.True(model.RawData.ContainsKey("file_input"));
        Assert.Null(model.ParseJobID);
        Assert.True(model.RawData.ContainsKey("parse_job_id"));
        Assert.Null(model.TransactionID);
        Assert.True(model.RawData.ContainsKey("transaction_id"));
        Assert.Null(model.WebhookConfigurationIds);
        Assert.True(model.RawData.ContainsKey("webhook_configuration_ids"));
        Assert.Null(model.WebhookConfigurations);
        Assert.True(model.RawData.ContainsKey("webhook_configurations"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ClassifyCreateRequest
        {
            Configuration = null,
            ConfigurationID = null,
            FileID = null,
            FileInput = null,
            ParseJobID = null,
            TransactionID = null,
            WebhookConfigurationIds = null,
            WebhookConfigurations = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClassifyCreateRequest
        {
            Configuration = new()
            {
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
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
            ConfigurationID = "cfg-11111111-2222-3333-4444-555555555555",
            FileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ParseJobID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            TransactionID = "tx-unique-idempotency-key",
            WebhookConfigurationIds = ["whc-...", "whc-..."],
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents =
                    [
                        ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess,
                        ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError,
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

        ClassifyCreateRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ClassifyCreateRequestWebhookConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClassifyCreateRequestWebhookConfiguration
        {
            WebhookEvents =
            [
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess,
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError,
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
            ApiEnum<string, ClassifyCreateRequestWebhookConfigurationWebhookEvent>
        > expectedWebhookEvents =
        [
            ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess,
            ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError,
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
        var model = new ClassifyCreateRequestWebhookConfiguration
        {
            WebhookEvents =
            [
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess,
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError,
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
        var deserialized = JsonSerializer.Deserialize<ClassifyCreateRequestWebhookConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClassifyCreateRequestWebhookConfiguration
        {
            WebhookEvents =
            [
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess,
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError,
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
        var deserialized = JsonSerializer.Deserialize<ClassifyCreateRequestWebhookConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<
            ApiEnum<string, ClassifyCreateRequestWebhookConfigurationWebhookEvent>
        > expectedWebhookEvents =
        [
            ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess,
            ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError,
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
        var model = new ClassifyCreateRequestWebhookConfiguration
        {
            WebhookEvents =
            [
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess,
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError,
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
        var model = new ClassifyCreateRequestWebhookConfiguration { };

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
        var model = new ClassifyCreateRequestWebhookConfiguration { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ClassifyCreateRequestWebhookConfiguration
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
        var model = new ClassifyCreateRequestWebhookConfiguration
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
        var model = new ClassifyCreateRequestWebhookConfiguration
        {
            WebhookEvents =
            [
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess,
                ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError,
            ],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        ClassifyCreateRequestWebhookConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ClassifyCreateRequestWebhookConfigurationWebhookEventTest : TestBase
{
    [Theory]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchCancelled)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchError)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchPending)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchRunning)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyCancelled)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyError)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyPartialSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyPending)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyRunning)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifySuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractCancelled)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractError)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractPartialSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractPending)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseCancelled)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParsePartialSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParsePending)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseRunning)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsCancelled)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsError)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsPartialSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsPending)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitCancelled)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitError)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitPending)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitProcessing)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.UnmappedEvent)]
    public void Validation_Works(ClassifyCreateRequestWebhookConfigurationWebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClassifyCreateRequestWebhookConfigurationWebhookEvent> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ClassifyCreateRequestWebhookConfigurationWebhookEvent>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchCancelled)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchError)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchPending)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchRunning)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.BatchSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyCancelled)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyError)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyPartialSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyPending)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifyRunning)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ClassifySuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractCancelled)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractError)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractPartialSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractPending)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ExtractSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseCancelled)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseError)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParsePartialSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParsePending)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseRunning)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.ParseSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsCancelled)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsError)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsPartialSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsPending)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SheetsSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitCancelled)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitError)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitPending)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitProcessing)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.SplitSuccess)]
    [InlineData(ClassifyCreateRequestWebhookConfigurationWebhookEvent.UnmappedEvent)]
    public void SerializationRoundtrip_Works(
        ClassifyCreateRequestWebhookConfigurationWebhookEvent rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClassifyCreateRequestWebhookConfigurationWebhookEvent> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ClassifyCreateRequestWebhookConfigurationWebhookEvent>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ClassifyCreateRequestWebhookConfigurationWebhookEvent>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ClassifyCreateRequestWebhookConfigurationWebhookEvent>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
