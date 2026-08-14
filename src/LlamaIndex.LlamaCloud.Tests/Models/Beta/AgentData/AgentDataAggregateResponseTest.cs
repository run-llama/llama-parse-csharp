using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.AgentData;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.AgentData;

public class AgentDataAggregateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentDataAggregateResponse
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
        };

        Dictionary<string, JsonElement> expectedGroupKey = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        long expectedCount = 0;
        Dictionary<string, JsonElement> expectedFirstItem = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedGroupKey.Count, model.GroupKey.Count);
        foreach (var item in expectedGroupKey)
        {
            Assert.True(model.GroupKey.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.GroupKey[item.Key]));
        }
        Assert.Equal(expectedCount, model.Count);
        Assert.NotNull(model.FirstItem);
        Assert.Equal(expectedFirstItem.Count, model.FirstItem.Count);
        foreach (var item in expectedFirstItem)
        {
            Assert.True(model.FirstItem.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.FirstItem[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AgentDataAggregateResponse
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataAggregateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentDataAggregateResponse
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataAggregateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, JsonElement> expectedGroupKey = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        long expectedCount = 0;
        Dictionary<string, JsonElement> expectedFirstItem = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedGroupKey.Count, deserialized.GroupKey.Count);
        foreach (var item in expectedGroupKey)
        {
            Assert.True(deserialized.GroupKey.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.GroupKey[item.Key]));
        }
        Assert.Equal(expectedCount, deserialized.Count);
        Assert.NotNull(deserialized.FirstItem);
        Assert.Equal(expectedFirstItem.Count, deserialized.FirstItem.Count);
        foreach (var item in expectedFirstItem)
        {
            Assert.True(deserialized.FirstItem.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.FirstItem[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AgentDataAggregateResponse
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AgentDataAggregateResponse
        {
            GroupKey = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Null(model.Count);
        Assert.False(model.RawData.ContainsKey("count"));
        Assert.Null(model.FirstItem);
        Assert.False(model.RawData.ContainsKey("first_item"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AgentDataAggregateResponse
        {
            GroupKey = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AgentDataAggregateResponse
        {
            GroupKey = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            Count = null,
            FirstItem = null,
        };

        Assert.Null(model.Count);
        Assert.True(model.RawData.ContainsKey("count"));
        Assert.Null(model.FirstItem);
        Assert.True(model.RawData.ContainsKey("first_item"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AgentDataAggregateResponse
        {
            GroupKey = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            Count = null,
            FirstItem = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AgentDataAggregateResponse
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
        };

        AgentDataAggregateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
