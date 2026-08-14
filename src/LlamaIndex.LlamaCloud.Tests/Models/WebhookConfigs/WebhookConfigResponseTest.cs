using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.WebhookConfigs;

namespace LlamaIndex.LlamaCloud.Tests.Models.WebhookConfigs;

public class WebhookConfigResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookConfigResponse
        {
            ID = "id",
            HasSecret = true,
            TenantID = "tenant_id",
            WebhookUrl = "webhook_url",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookEvents = [WebhookConfigResponseWebhookEvent.BatchCancelled],
            WebhookHeaders = new Dictionary<string, string>() { { "foo", "string" } },
            WebhookOutputFormat = WebhookConfigResponseWebhookOutputFormat.Json,
        };

        string expectedID = "id";
        bool expectedHasSecret = true;
        string expectedTenantID = "tenant_id";
        JsonElement expectedTenantType = JsonSerializer.SerializeToElement("project");
        string expectedWebhookUrl = "webhook_url";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, WebhookConfigResponseWebhookEvent>> expectedWebhookEvents =
        [
            WebhookConfigResponseWebhookEvent.BatchCancelled,
        ];
        Dictionary<string, string> expectedWebhookHeaders = new() { { "foo", "string" } };
        ApiEnum<string, WebhookConfigResponseWebhookOutputFormat> expectedWebhookOutputFormat =
            WebhookConfigResponseWebhookOutputFormat.Json;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedHasSecret, model.HasSecret);
        Assert.Equal(expectedTenantID, model.TenantID);
        Assert.True(JsonElement.DeepEquals(expectedTenantType, model.TenantType));
        Assert.Equal(expectedWebhookUrl, model.WebhookUrl);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookConfigResponse
        {
            ID = "id",
            HasSecret = true,
            TenantID = "tenant_id",
            WebhookUrl = "webhook_url",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookEvents = [WebhookConfigResponseWebhookEvent.BatchCancelled],
            WebhookHeaders = new Dictionary<string, string>() { { "foo", "string" } },
            WebhookOutputFormat = WebhookConfigResponseWebhookOutputFormat.Json,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookConfigResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookConfigResponse
        {
            ID = "id",
            HasSecret = true,
            TenantID = "tenant_id",
            WebhookUrl = "webhook_url",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookEvents = [WebhookConfigResponseWebhookEvent.BatchCancelled],
            WebhookHeaders = new Dictionary<string, string>() { { "foo", "string" } },
            WebhookOutputFormat = WebhookConfigResponseWebhookOutputFormat.Json,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookConfigResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        bool expectedHasSecret = true;
        string expectedTenantID = "tenant_id";
        JsonElement expectedTenantType = JsonSerializer.SerializeToElement("project");
        string expectedWebhookUrl = "webhook_url";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, WebhookConfigResponseWebhookEvent>> expectedWebhookEvents =
        [
            WebhookConfigResponseWebhookEvent.BatchCancelled,
        ];
        Dictionary<string, string> expectedWebhookHeaders = new() { { "foo", "string" } };
        ApiEnum<string, WebhookConfigResponseWebhookOutputFormat> expectedWebhookOutputFormat =
            WebhookConfigResponseWebhookOutputFormat.Json;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedHasSecret, deserialized.HasSecret);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
        Assert.True(JsonElement.DeepEquals(expectedTenantType, deserialized.TenantType));
        Assert.Equal(expectedWebhookUrl, deserialized.WebhookUrl);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookConfigResponse
        {
            ID = "id",
            HasSecret = true,
            TenantID = "tenant_id",
            WebhookUrl = "webhook_url",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookEvents = [WebhookConfigResponseWebhookEvent.BatchCancelled],
            WebhookHeaders = new Dictionary<string, string>() { { "foo", "string" } },
            WebhookOutputFormat = WebhookConfigResponseWebhookOutputFormat.Json,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookConfigResponse
        {
            ID = "id",
            HasSecret = true,
            TenantID = "tenant_id",
            WebhookUrl = "webhook_url",
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.WebhookEvents);
        Assert.False(model.RawData.ContainsKey("webhook_events"));
        Assert.Null(model.WebhookHeaders);
        Assert.False(model.RawData.ContainsKey("webhook_headers"));
        Assert.Null(model.WebhookOutputFormat);
        Assert.False(model.RawData.ContainsKey("webhook_output_format"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookConfigResponse
        {
            ID = "id",
            HasSecret = true,
            TenantID = "tenant_id",
            WebhookUrl = "webhook_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookConfigResponse
        {
            ID = "id",
            HasSecret = true,
            TenantID = "tenant_id",
            WebhookUrl = "webhook_url",

            CreatedAt = null,
            UpdatedAt = null,
            WebhookEvents = null,
            WebhookHeaders = null,
            WebhookOutputFormat = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.WebhookEvents);
        Assert.True(model.RawData.ContainsKey("webhook_events"));
        Assert.Null(model.WebhookHeaders);
        Assert.True(model.RawData.ContainsKey("webhook_headers"));
        Assert.Null(model.WebhookOutputFormat);
        Assert.True(model.RawData.ContainsKey("webhook_output_format"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookConfigResponse
        {
            ID = "id",
            HasSecret = true,
            TenantID = "tenant_id",
            WebhookUrl = "webhook_url",

            CreatedAt = null,
            UpdatedAt = null,
            WebhookEvents = null,
            WebhookHeaders = null,
            WebhookOutputFormat = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookConfigResponse
        {
            ID = "id",
            HasSecret = true,
            TenantID = "tenant_id",
            WebhookUrl = "webhook_url",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WebhookEvents = [WebhookConfigResponseWebhookEvent.BatchCancelled],
            WebhookHeaders = new Dictionary<string, string>() { { "foo", "string" } },
            WebhookOutputFormat = WebhookConfigResponseWebhookOutputFormat.Json,
        };

        WebhookConfigResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookConfigResponseWebhookEventTest : TestBase
{
    [Theory]
    [InlineData(WebhookConfigResponseWebhookEvent.BatchCancelled)]
    [InlineData(WebhookConfigResponseWebhookEvent.BatchError)]
    [InlineData(WebhookConfigResponseWebhookEvent.BatchPending)]
    [InlineData(WebhookConfigResponseWebhookEvent.BatchRunning)]
    [InlineData(WebhookConfigResponseWebhookEvent.BatchSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.ClassifyCancelled)]
    [InlineData(WebhookConfigResponseWebhookEvent.ClassifyError)]
    [InlineData(WebhookConfigResponseWebhookEvent.ClassifyPartialSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.ClassifyPending)]
    [InlineData(WebhookConfigResponseWebhookEvent.ClassifyRunning)]
    [InlineData(WebhookConfigResponseWebhookEvent.ClassifySuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.ExtractCancelled)]
    [InlineData(WebhookConfigResponseWebhookEvent.ExtractError)]
    [InlineData(WebhookConfigResponseWebhookEvent.ExtractPartialSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.ExtractPending)]
    [InlineData(WebhookConfigResponseWebhookEvent.ExtractSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.ParseCancelled)]
    [InlineData(WebhookConfigResponseWebhookEvent.ParseError)]
    [InlineData(WebhookConfigResponseWebhookEvent.ParsePartialSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.ParsePending)]
    [InlineData(WebhookConfigResponseWebhookEvent.ParseRunning)]
    [InlineData(WebhookConfigResponseWebhookEvent.ParseSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.SheetsCancelled)]
    [InlineData(WebhookConfigResponseWebhookEvent.SheetsError)]
    [InlineData(WebhookConfigResponseWebhookEvent.SheetsPartialSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.SheetsPending)]
    [InlineData(WebhookConfigResponseWebhookEvent.SheetsSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.SplitCancelled)]
    [InlineData(WebhookConfigResponseWebhookEvent.SplitError)]
    [InlineData(WebhookConfigResponseWebhookEvent.SplitPending)]
    [InlineData(WebhookConfigResponseWebhookEvent.SplitProcessing)]
    [InlineData(WebhookConfigResponseWebhookEvent.SplitSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.UnmappedEvent)]
    public void Validation_Works(WebhookConfigResponseWebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookConfigResponseWebhookEvent> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookConfigResponseWebhookEvent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookConfigResponseWebhookEvent.BatchCancelled)]
    [InlineData(WebhookConfigResponseWebhookEvent.BatchError)]
    [InlineData(WebhookConfigResponseWebhookEvent.BatchPending)]
    [InlineData(WebhookConfigResponseWebhookEvent.BatchRunning)]
    [InlineData(WebhookConfigResponseWebhookEvent.BatchSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.ClassifyCancelled)]
    [InlineData(WebhookConfigResponseWebhookEvent.ClassifyError)]
    [InlineData(WebhookConfigResponseWebhookEvent.ClassifyPartialSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.ClassifyPending)]
    [InlineData(WebhookConfigResponseWebhookEvent.ClassifyRunning)]
    [InlineData(WebhookConfigResponseWebhookEvent.ClassifySuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.ExtractCancelled)]
    [InlineData(WebhookConfigResponseWebhookEvent.ExtractError)]
    [InlineData(WebhookConfigResponseWebhookEvent.ExtractPartialSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.ExtractPending)]
    [InlineData(WebhookConfigResponseWebhookEvent.ExtractSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.ParseCancelled)]
    [InlineData(WebhookConfigResponseWebhookEvent.ParseError)]
    [InlineData(WebhookConfigResponseWebhookEvent.ParsePartialSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.ParsePending)]
    [InlineData(WebhookConfigResponseWebhookEvent.ParseRunning)]
    [InlineData(WebhookConfigResponseWebhookEvent.ParseSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.SheetsCancelled)]
    [InlineData(WebhookConfigResponseWebhookEvent.SheetsError)]
    [InlineData(WebhookConfigResponseWebhookEvent.SheetsPartialSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.SheetsPending)]
    [InlineData(WebhookConfigResponseWebhookEvent.SheetsSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.SplitCancelled)]
    [InlineData(WebhookConfigResponseWebhookEvent.SplitError)]
    [InlineData(WebhookConfigResponseWebhookEvent.SplitPending)]
    [InlineData(WebhookConfigResponseWebhookEvent.SplitProcessing)]
    [InlineData(WebhookConfigResponseWebhookEvent.SplitSuccess)]
    [InlineData(WebhookConfigResponseWebhookEvent.UnmappedEvent)]
    public void SerializationRoundtrip_Works(WebhookConfigResponseWebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookConfigResponseWebhookEvent> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigResponseWebhookEvent>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookConfigResponseWebhookEvent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigResponseWebhookEvent>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class WebhookConfigResponseWebhookOutputFormatTest : TestBase
{
    [Theory]
    [InlineData(WebhookConfigResponseWebhookOutputFormat.Json)]
    [InlineData(WebhookConfigResponseWebhookOutputFormat.String)]
    public void Validation_Works(WebhookConfigResponseWebhookOutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookConfigResponseWebhookOutputFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigResponseWebhookOutputFormat>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookConfigResponseWebhookOutputFormat.Json)]
    [InlineData(WebhookConfigResponseWebhookOutputFormat.String)]
    public void SerializationRoundtrip_Works(WebhookConfigResponseWebhookOutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookConfigResponseWebhookOutputFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigResponseWebhookOutputFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigResponseWebhookOutputFormat>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, WebhookConfigResponseWebhookOutputFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
