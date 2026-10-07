using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.WebhookConfigs;

namespace LlamaCloud.Tests.Models.WebhookConfigs;

public class WebhookConfigListPaginatedPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookConfigListPaginatedPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        List<WebhookConfigResponse> expectedItems =
        [
            new()
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
            },
        ];
        string expectedNextPageToken = "next_page_token";
        long expectedTotalSize = 0;

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextPageToken, model.NextPageToken);
        Assert.Equal(expectedTotalSize, model.TotalSize);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookConfigListPaginatedPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookConfigListPaginatedPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookConfigListPaginatedPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookConfigListPaginatedPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<WebhookConfigResponse> expectedItems =
        [
            new()
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
            },
        ];
        string expectedNextPageToken = "next_page_token";
        long expectedTotalSize = 0;

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextPageToken, deserialized.NextPageToken);
        Assert.Equal(expectedTotalSize, deserialized.TotalSize);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookConfigListPaginatedPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookConfigListPaginatedPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        Assert.Null(model.NextPageToken);
        Assert.False(model.RawData.ContainsKey("next_page_token"));
        Assert.Null(model.TotalSize);
        Assert.False(model.RawData.ContainsKey("total_size"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebhookConfigListPaginatedPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookConfigListPaginatedPageResponse
        {
            Items =
            [
                new()
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
                },
            ],

            NextPageToken = null,
            TotalSize = null,
        };

        Assert.Null(model.NextPageToken);
        Assert.True(model.RawData.ContainsKey("next_page_token"));
        Assert.Null(model.TotalSize);
        Assert.True(model.RawData.ContainsKey("total_size"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebhookConfigListPaginatedPageResponse
        {
            Items =
            [
                new()
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
                },
            ],

            NextPageToken = null,
            TotalSize = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookConfigListPaginatedPageResponse
        {
            Items =
            [
                new()
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
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        WebhookConfigListPaginatedPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
