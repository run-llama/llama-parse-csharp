using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Beta.AgentData;

namespace LlamaCloud.Tests.Models.Beta.AgentData;

public class AgentDataAggregatePageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentDataAggregatePageResponse
        {
            Items =
            [
                new()
                {
                    GroupKey = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Count = 0,
                    FirstItem = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        List<AgentDataAggregateResponse> expectedItems =
        [
            new()
            {
                GroupKey = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Count = 0,
                FirstItem = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
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
        var model = new AgentDataAggregatePageResponse
        {
            Items =
            [
                new()
                {
                    GroupKey = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Count = 0,
                    FirstItem = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataAggregatePageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentDataAggregatePageResponse
        {
            Items =
            [
                new()
                {
                    GroupKey = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Count = 0,
                    FirstItem = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataAggregatePageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AgentDataAggregateResponse> expectedItems =
        [
            new()
            {
                GroupKey = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Count = 0,
                FirstItem = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
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
        var model = new AgentDataAggregatePageResponse
        {
            Items =
            [
                new()
                {
                    GroupKey = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Count = 0,
                    FirstItem = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
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
        var model = new AgentDataAggregatePageResponse
        {
            Items =
            [
                new()
                {
                    GroupKey = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Count = 0,
                    FirstItem = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
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
        var model = new AgentDataAggregatePageResponse
        {
            Items =
            [
                new()
                {
                    GroupKey = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Count = 0,
                    FirstItem = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AgentDataAggregatePageResponse
        {
            Items =
            [
                new()
                {
                    GroupKey = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Count = 0,
                    FirstItem = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
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
        var model = new AgentDataAggregatePageResponse
        {
            Items =
            [
                new()
                {
                    GroupKey = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Count = 0,
                    FirstItem = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
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
        var model = new AgentDataAggregatePageResponse
        {
            Items =
            [
                new()
                {
                    GroupKey = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Count = 0,
                    FirstItem = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        AgentDataAggregatePageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
