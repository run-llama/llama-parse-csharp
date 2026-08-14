using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.WebhookConfigs;

namespace LlamaCloud.Tests.Models.WebhookConfigs;

public class WebhookConfigCreateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookConfigCreate
        {
            WebhookUrl = "https://example.com/webhooks/llamacloud",
            WebhookEvents =
            [
                WebhookConfigCreateWebhookEvent.ParseSuccess,
                WebhookConfigCreateWebhookEvent.ParseError,
            ],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = WebhookConfigCreateWebhookOutputFormat.Json,
            WebhookSigningSecret = "whsec_...",
        };

        string expectedWebhookUrl = "https://example.com/webhooks/llamacloud";
        List<ApiEnum<string, WebhookConfigCreateWebhookEvent>> expectedWebhookEvents =
        [
            WebhookConfigCreateWebhookEvent.ParseSuccess,
            WebhookConfigCreateWebhookEvent.ParseError,
        ];
        Dictionary<string, string> expectedWebhookHeaders = new()
        {
            { "Authorization", "Bearer sk-..." },
        };
        ApiEnum<string, WebhookConfigCreateWebhookOutputFormat> expectedWebhookOutputFormat =
            WebhookConfigCreateWebhookOutputFormat.Json;
        string expectedWebhookSigningSecret = "whsec_...";

        Assert.Equal(expectedWebhookUrl, model.WebhookUrl);
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookConfigCreate
        {
            WebhookUrl = "https://example.com/webhooks/llamacloud",
            WebhookEvents =
            [
                WebhookConfigCreateWebhookEvent.ParseSuccess,
                WebhookConfigCreateWebhookEvent.ParseError,
            ],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = WebhookConfigCreateWebhookOutputFormat.Json,
            WebhookSigningSecret = "whsec_...",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookConfigCreate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookConfigCreate
        {
            WebhookUrl = "https://example.com/webhooks/llamacloud",
            WebhookEvents =
            [
                WebhookConfigCreateWebhookEvent.ParseSuccess,
                WebhookConfigCreateWebhookEvent.ParseError,
            ],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = WebhookConfigCreateWebhookOutputFormat.Json,
            WebhookSigningSecret = "whsec_...",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookConfigCreate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedWebhookUrl = "https://example.com/webhooks/llamacloud";
        List<ApiEnum<string, WebhookConfigCreateWebhookEvent>> expectedWebhookEvents =
        [
            WebhookConfigCreateWebhookEvent.ParseSuccess,
            WebhookConfigCreateWebhookEvent.ParseError,
        ];
        Dictionary<string, string> expectedWebhookHeaders = new()
        {
            { "Authorization", "Bearer sk-..." },
        };
        ApiEnum<string, WebhookConfigCreateWebhookOutputFormat> expectedWebhookOutputFormat =
            WebhookConfigCreateWebhookOutputFormat.Json;
        string expectedWebhookSigningSecret = "whsec_...";

        Assert.Equal(expectedWebhookUrl, deserialized.WebhookUrl);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookConfigCreate
        {
            WebhookUrl = "https://example.com/webhooks/llamacloud",
            WebhookEvents =
            [
                WebhookConfigCreateWebhookEvent.ParseSuccess,
                WebhookConfigCreateWebhookEvent.ParseError,
            ],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = WebhookConfigCreateWebhookOutputFormat.Json,
            WebhookSigningSecret = "whsec_...",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookConfigCreate
        {
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        Assert.Null(model.WebhookEvents);
        Assert.False(model.RawData.ContainsKey("webhook_events"));
        Assert.Null(model.WebhookHeaders);
        Assert.False(model.RawData.ContainsKey("webhook_headers"));
        Assert.Null(model.WebhookOutputFormat);
        Assert.False(model.RawData.ContainsKey("webhook_output_format"));
        Assert.Null(model.WebhookSigningSecret);
        Assert.False(model.RawData.ContainsKey("webhook_signing_secret"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookConfigCreate
        {
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookConfigCreate
        {
            WebhookUrl = "https://example.com/webhooks/llamacloud",

            WebhookEvents = null,
            WebhookHeaders = null,
            WebhookOutputFormat = null,
            WebhookSigningSecret = null,
        };

        Assert.Null(model.WebhookEvents);
        Assert.True(model.RawData.ContainsKey("webhook_events"));
        Assert.Null(model.WebhookHeaders);
        Assert.True(model.RawData.ContainsKey("webhook_headers"));
        Assert.Null(model.WebhookOutputFormat);
        Assert.True(model.RawData.ContainsKey("webhook_output_format"));
        Assert.Null(model.WebhookSigningSecret);
        Assert.True(model.RawData.ContainsKey("webhook_signing_secret"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookConfigCreate
        {
            WebhookUrl = "https://example.com/webhooks/llamacloud",

            WebhookEvents = null,
            WebhookHeaders = null,
            WebhookOutputFormat = null,
            WebhookSigningSecret = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookConfigCreate
        {
            WebhookUrl = "https://example.com/webhooks/llamacloud",
            WebhookEvents =
            [
                WebhookConfigCreateWebhookEvent.ParseSuccess,
                WebhookConfigCreateWebhookEvent.ParseError,
            ],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = WebhookConfigCreateWebhookOutputFormat.Json,
            WebhookSigningSecret = "whsec_...",
        };

        WebhookConfigCreate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookConfigCreateWebhookEventTest : TestBase
{
    [Theory]
    [InlineData(WebhookConfigCreateWebhookEvent.BatchCancelled)]
    [InlineData(WebhookConfigCreateWebhookEvent.BatchError)]
    [InlineData(WebhookConfigCreateWebhookEvent.BatchPending)]
    [InlineData(WebhookConfigCreateWebhookEvent.BatchRunning)]
    [InlineData(WebhookConfigCreateWebhookEvent.BatchSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.ClassifyCancelled)]
    [InlineData(WebhookConfigCreateWebhookEvent.ClassifyError)]
    [InlineData(WebhookConfigCreateWebhookEvent.ClassifyPartialSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.ClassifyPending)]
    [InlineData(WebhookConfigCreateWebhookEvent.ClassifyRunning)]
    [InlineData(WebhookConfigCreateWebhookEvent.ClassifySuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.ExtractCancelled)]
    [InlineData(WebhookConfigCreateWebhookEvent.ExtractError)]
    [InlineData(WebhookConfigCreateWebhookEvent.ExtractPartialSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.ExtractPending)]
    [InlineData(WebhookConfigCreateWebhookEvent.ExtractSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.ParseCancelled)]
    [InlineData(WebhookConfigCreateWebhookEvent.ParseError)]
    [InlineData(WebhookConfigCreateWebhookEvent.ParsePartialSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.ParsePending)]
    [InlineData(WebhookConfigCreateWebhookEvent.ParseRunning)]
    [InlineData(WebhookConfigCreateWebhookEvent.ParseSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.SheetsCancelled)]
    [InlineData(WebhookConfigCreateWebhookEvent.SheetsError)]
    [InlineData(WebhookConfigCreateWebhookEvent.SheetsPartialSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.SheetsPending)]
    [InlineData(WebhookConfigCreateWebhookEvent.SheetsSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.SplitCancelled)]
    [InlineData(WebhookConfigCreateWebhookEvent.SplitError)]
    [InlineData(WebhookConfigCreateWebhookEvent.SplitPending)]
    [InlineData(WebhookConfigCreateWebhookEvent.SplitProcessing)]
    [InlineData(WebhookConfigCreateWebhookEvent.SplitSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.UnmappedEvent)]
    public void Validation_Works(WebhookConfigCreateWebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookConfigCreateWebhookEvent> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookConfigCreateWebhookEvent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookConfigCreateWebhookEvent.BatchCancelled)]
    [InlineData(WebhookConfigCreateWebhookEvent.BatchError)]
    [InlineData(WebhookConfigCreateWebhookEvent.BatchPending)]
    [InlineData(WebhookConfigCreateWebhookEvent.BatchRunning)]
    [InlineData(WebhookConfigCreateWebhookEvent.BatchSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.ClassifyCancelled)]
    [InlineData(WebhookConfigCreateWebhookEvent.ClassifyError)]
    [InlineData(WebhookConfigCreateWebhookEvent.ClassifyPartialSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.ClassifyPending)]
    [InlineData(WebhookConfigCreateWebhookEvent.ClassifyRunning)]
    [InlineData(WebhookConfigCreateWebhookEvent.ClassifySuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.ExtractCancelled)]
    [InlineData(WebhookConfigCreateWebhookEvent.ExtractError)]
    [InlineData(WebhookConfigCreateWebhookEvent.ExtractPartialSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.ExtractPending)]
    [InlineData(WebhookConfigCreateWebhookEvent.ExtractSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.ParseCancelled)]
    [InlineData(WebhookConfigCreateWebhookEvent.ParseError)]
    [InlineData(WebhookConfigCreateWebhookEvent.ParsePartialSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.ParsePending)]
    [InlineData(WebhookConfigCreateWebhookEvent.ParseRunning)]
    [InlineData(WebhookConfigCreateWebhookEvent.ParseSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.SheetsCancelled)]
    [InlineData(WebhookConfigCreateWebhookEvent.SheetsError)]
    [InlineData(WebhookConfigCreateWebhookEvent.SheetsPartialSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.SheetsPending)]
    [InlineData(WebhookConfigCreateWebhookEvent.SheetsSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.SplitCancelled)]
    [InlineData(WebhookConfigCreateWebhookEvent.SplitError)]
    [InlineData(WebhookConfigCreateWebhookEvent.SplitPending)]
    [InlineData(WebhookConfigCreateWebhookEvent.SplitProcessing)]
    [InlineData(WebhookConfigCreateWebhookEvent.SplitSuccess)]
    [InlineData(WebhookConfigCreateWebhookEvent.UnmappedEvent)]
    public void SerializationRoundtrip_Works(WebhookConfigCreateWebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookConfigCreateWebhookEvent> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigCreateWebhookEvent>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookConfigCreateWebhookEvent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigCreateWebhookEvent>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class WebhookConfigCreateWebhookOutputFormatTest : TestBase
{
    [Theory]
    [InlineData(WebhookConfigCreateWebhookOutputFormat.Json)]
    [InlineData(WebhookConfigCreateWebhookOutputFormat.String)]
    public void Validation_Works(WebhookConfigCreateWebhookOutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookConfigCreateWebhookOutputFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigCreateWebhookOutputFormat>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookConfigCreateWebhookOutputFormat.Json)]
    [InlineData(WebhookConfigCreateWebhookOutputFormat.String)]
    public void SerializationRoundtrip_Works(WebhookConfigCreateWebhookOutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookConfigCreateWebhookOutputFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigCreateWebhookOutputFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigCreateWebhookOutputFormat>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigCreateWebhookOutputFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
