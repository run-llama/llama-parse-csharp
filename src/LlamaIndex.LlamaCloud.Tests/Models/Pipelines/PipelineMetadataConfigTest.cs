using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class PipelineMetadataConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PipelineMetadataConfig
        {
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
        };

        List<string> expectedExcludedEmbedMetadataKeys = ["string"];
        List<string> expectedExcludedLlmMetadataKeys = ["string"];

        Assert.NotNull(model.ExcludedEmbedMetadataKeys);
        Assert.Equal(
            expectedExcludedEmbedMetadataKeys.Count,
            model.ExcludedEmbedMetadataKeys.Count
        );
        for (int i = 0; i < expectedExcludedEmbedMetadataKeys.Count; i++)
        {
            Assert.Equal(expectedExcludedEmbedMetadataKeys[i], model.ExcludedEmbedMetadataKeys[i]);
        }
        Assert.NotNull(model.ExcludedLlmMetadataKeys);
        Assert.Equal(expectedExcludedLlmMetadataKeys.Count, model.ExcludedLlmMetadataKeys.Count);
        for (int i = 0; i < expectedExcludedLlmMetadataKeys.Count; i++)
        {
            Assert.Equal(expectedExcludedLlmMetadataKeys[i], model.ExcludedLlmMetadataKeys[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PipelineMetadataConfig
        {
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineMetadataConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PipelineMetadataConfig
        {
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineMetadataConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedExcludedEmbedMetadataKeys = ["string"];
        List<string> expectedExcludedLlmMetadataKeys = ["string"];

        Assert.NotNull(deserialized.ExcludedEmbedMetadataKeys);
        Assert.Equal(
            expectedExcludedEmbedMetadataKeys.Count,
            deserialized.ExcludedEmbedMetadataKeys.Count
        );
        for (int i = 0; i < expectedExcludedEmbedMetadataKeys.Count; i++)
        {
            Assert.Equal(
                expectedExcludedEmbedMetadataKeys[i],
                deserialized.ExcludedEmbedMetadataKeys[i]
            );
        }
        Assert.NotNull(deserialized.ExcludedLlmMetadataKeys);
        Assert.Equal(
            expectedExcludedLlmMetadataKeys.Count,
            deserialized.ExcludedLlmMetadataKeys.Count
        );
        for (int i = 0; i < expectedExcludedLlmMetadataKeys.Count; i++)
        {
            Assert.Equal(
                expectedExcludedLlmMetadataKeys[i],
                deserialized.ExcludedLlmMetadataKeys[i]
            );
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PipelineMetadataConfig
        {
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PipelineMetadataConfig { };

        Assert.Null(model.ExcludedEmbedMetadataKeys);
        Assert.False(model.RawData.ContainsKey("excluded_embed_metadata_keys"));
        Assert.Null(model.ExcludedLlmMetadataKeys);
        Assert.False(model.RawData.ContainsKey("excluded_llm_metadata_keys"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PipelineMetadataConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PipelineMetadataConfig
        {
            // Null should be interpreted as omitted for these properties
            ExcludedEmbedMetadataKeys = null,
            ExcludedLlmMetadataKeys = null,
        };

        Assert.Null(model.ExcludedEmbedMetadataKeys);
        Assert.False(model.RawData.ContainsKey("excluded_embed_metadata_keys"));
        Assert.Null(model.ExcludedLlmMetadataKeys);
        Assert.False(model.RawData.ContainsKey("excluded_llm_metadata_keys"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PipelineMetadataConfig
        {
            // Null should be interpreted as omitted for these properties
            ExcludedEmbedMetadataKeys = null,
            ExcludedLlmMetadataKeys = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PipelineMetadataConfig
        {
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
        };

        PipelineMetadataConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}
