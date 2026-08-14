using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.WebhookConfigs;

namespace LlamaCloud.Tests.Models.WebhookConfigs;

public class WebhookConfigCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookConfigCreateParams
        {
            WebhookUrl = "https://example.com/webhooks/llamacloud",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = WebhookOutputFormat.Json,
            WebhookSigningSecret = "whsec_...",
        };

        string expectedWebhookUrl = "https://example.com/webhooks/llamacloud";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<ApiEnum<string, WebhookEvent>> expectedWebhookEvents =
        [
            WebhookEvent.ParseSuccess,
            WebhookEvent.ParseError,
        ];
        Dictionary<string, string> expectedWebhookHeaders = new()
        {
            { "Authorization", "Bearer sk-..." },
        };
        ApiEnum<string, WebhookOutputFormat> expectedWebhookOutputFormat = WebhookOutputFormat.Json;
        string expectedWebhookSigningSecret = "whsec_...";

        Assert.Equal(expectedWebhookUrl, parameters.WebhookUrl);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.NotNull(parameters.WebhookEvents);
        Assert.Equal(expectedWebhookEvents.Count, parameters.WebhookEvents.Count);
        for (int i = 0; i < expectedWebhookEvents.Count; i++)
        {
            Assert.Equal(expectedWebhookEvents[i], parameters.WebhookEvents[i]);
        }
        Assert.NotNull(parameters.WebhookHeaders);
        Assert.Equal(expectedWebhookHeaders.Count, parameters.WebhookHeaders.Count);
        foreach (var item in expectedWebhookHeaders)
        {
            Assert.True(parameters.WebhookHeaders.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.WebhookHeaders[item.Key]);
        }
        Assert.Equal(expectedWebhookOutputFormat, parameters.WebhookOutputFormat);
        Assert.Equal(expectedWebhookSigningSecret, parameters.WebhookSigningSecret);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookConfigCreateParams
        {
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.WebhookEvents);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_events"));
        Assert.Null(parameters.WebhookHeaders);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_headers"));
        Assert.Null(parameters.WebhookOutputFormat);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_output_format"));
        Assert.Null(parameters.WebhookSigningSecret);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_signing_secret"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WebhookConfigCreateParams
        {
            WebhookUrl = "https://example.com/webhooks/llamacloud",

            OrganizationID = null,
            ProjectID = null,
            WebhookEvents = null,
            WebhookHeaders = null,
            WebhookOutputFormat = null,
            WebhookSigningSecret = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.WebhookEvents);
        Assert.True(parameters.RawBodyData.ContainsKey("webhook_events"));
        Assert.Null(parameters.WebhookHeaders);
        Assert.True(parameters.RawBodyData.ContainsKey("webhook_headers"));
        Assert.Null(parameters.WebhookOutputFormat);
        Assert.True(parameters.RawBodyData.ContainsKey("webhook_output_format"));
        Assert.Null(parameters.WebhookSigningSecret);
        Assert.True(parameters.RawBodyData.ContainsKey("webhook_signing_secret"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookConfigCreateParams parameters = new()
        {
            WebhookUrl = "https://example.com/webhooks/llamacloud",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/webhook-configs?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookConfigCreateParams
        {
            WebhookUrl = "https://example.com/webhooks/llamacloud",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = WebhookOutputFormat.Json,
            WebhookSigningSecret = "whsec_...",
        };

        WebhookConfigCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
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
