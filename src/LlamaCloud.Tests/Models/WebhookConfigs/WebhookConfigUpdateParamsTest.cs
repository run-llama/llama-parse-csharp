using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.WebhookConfigs;

namespace LlamaCloud.Tests.Models.WebhookConfigs;

public class WebhookConfigUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new WebhookConfigUpdateParams
        {
            ConfigID = "config_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WebhookEvents = [WebhookConfigUpdateParamsWebhookEvent.BatchCancelled],
            WebhookHeaders = new Dictionary<string, string>() { { "foo", "string" } },
            WebhookOutputFormat = WebhookConfigUpdateParamsWebhookOutputFormat.Json,
            WebhookSigningSecret = "webhook_signing_secret",
            WebhookUrl = "webhook_url",
        };

        string expectedConfigID = "config_id";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<ApiEnum<string, WebhookConfigUpdateParamsWebhookEvent>> expectedWebhookEvents =
        [
            WebhookConfigUpdateParamsWebhookEvent.BatchCancelled,
        ];
        Dictionary<string, string> expectedWebhookHeaders = new() { { "foo", "string" } };
        ApiEnum<string, WebhookConfigUpdateParamsWebhookOutputFormat> expectedWebhookOutputFormat =
            WebhookConfigUpdateParamsWebhookOutputFormat.Json;
        string expectedWebhookSigningSecret = "webhook_signing_secret";
        string expectedWebhookUrl = "webhook_url";

        Assert.Equal(expectedConfigID, parameters.ConfigID);
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
        Assert.Equal(expectedWebhookUrl, parameters.WebhookUrl);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new WebhookConfigUpdateParams { ConfigID = "config_id" };

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
        Assert.Null(parameters.WebhookUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_url"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new WebhookConfigUpdateParams
        {
            ConfigID = "config_id",

            OrganizationID = null,
            ProjectID = null,
            WebhookEvents = null,
            WebhookHeaders = null,
            WebhookOutputFormat = null,
            WebhookSigningSecret = null,
            WebhookUrl = null,
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
        Assert.Null(parameters.WebhookUrl);
        Assert.True(parameters.RawBodyData.ContainsKey("webhook_url"));
    }

    [Fact]
    public void Url_Works()
    {
        WebhookConfigUpdateParams parameters = new()
        {
            ConfigID = "config_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/webhook-configs/config_id?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookConfigUpdateParams
        {
            ConfigID = "config_id",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            WebhookEvents = [WebhookConfigUpdateParamsWebhookEvent.BatchCancelled],
            WebhookHeaders = new Dictionary<string, string>() { { "foo", "string" } },
            WebhookOutputFormat = WebhookConfigUpdateParamsWebhookOutputFormat.Json,
            WebhookSigningSecret = "webhook_signing_secret",
            WebhookUrl = "webhook_url",
        };

        WebhookConfigUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class WebhookConfigUpdateParamsWebhookEventTest : TestBase
{
    [Theory]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.BatchCancelled)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.BatchError)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.BatchPending)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.BatchRunning)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.BatchSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ClassifyCancelled)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ClassifyError)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ClassifyPartialSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ClassifyPending)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ClassifyRunning)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ClassifySuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ExtractCancelled)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ExtractError)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ExtractPartialSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ExtractPending)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ExtractSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ParseCancelled)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ParseError)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ParsePartialSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ParsePending)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ParseRunning)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ParseSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SheetsCancelled)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SheetsError)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SheetsPartialSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SheetsPending)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SheetsSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SplitCancelled)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SplitError)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SplitPending)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SplitProcessing)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SplitSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.UnmappedEvent)]
    public void Validation_Works(WebhookConfigUpdateParamsWebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookConfigUpdateParamsWebhookEvent> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigUpdateParamsWebhookEvent>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.BatchCancelled)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.BatchError)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.BatchPending)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.BatchRunning)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.BatchSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ClassifyCancelled)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ClassifyError)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ClassifyPartialSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ClassifyPending)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ClassifyRunning)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ClassifySuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ExtractCancelled)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ExtractError)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ExtractPartialSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ExtractPending)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ExtractSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ParseCancelled)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ParseError)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ParsePartialSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ParsePending)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ParseRunning)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.ParseSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SheetsCancelled)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SheetsError)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SheetsPartialSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SheetsPending)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SheetsSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SplitCancelled)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SplitError)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SplitPending)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SplitProcessing)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.SplitSuccess)]
    [InlineData(WebhookConfigUpdateParamsWebhookEvent.UnmappedEvent)]
    public void SerializationRoundtrip_Works(WebhookConfigUpdateParamsWebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookConfigUpdateParamsWebhookEvent> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigUpdateParamsWebhookEvent>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigUpdateParamsWebhookEvent>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigUpdateParamsWebhookEvent>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class WebhookConfigUpdateParamsWebhookOutputFormatTest : TestBase
{
    [Theory]
    [InlineData(WebhookConfigUpdateParamsWebhookOutputFormat.Json)]
    [InlineData(WebhookConfigUpdateParamsWebhookOutputFormat.String)]
    public void Validation_Works(WebhookConfigUpdateParamsWebhookOutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookConfigUpdateParamsWebhookOutputFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigUpdateParamsWebhookOutputFormat>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookConfigUpdateParamsWebhookOutputFormat.Json)]
    [InlineData(WebhookConfigUpdateParamsWebhookOutputFormat.String)]
    public void SerializationRoundtrip_Works(WebhookConfigUpdateParamsWebhookOutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookConfigUpdateParamsWebhookOutputFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigUpdateParamsWebhookOutputFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigUpdateParamsWebhookOutputFormat>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigUpdateParamsWebhookOutputFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
