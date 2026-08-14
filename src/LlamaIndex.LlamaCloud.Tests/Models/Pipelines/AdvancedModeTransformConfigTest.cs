using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class AdvancedModeTransformConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AdvancedModeTransformConfig
        {
            ChunkingConfig = new NoneChunkingConfig() { Mode = Mode.None },
            Mode = AdvancedModeTransformConfigMode.Advanced,
            SegmentationConfig = new NoneSegmentationConfig()
            {
                Mode = NoneSegmentationConfigMode.None,
            },
        };

        ChunkingConfig expectedChunkingConfig = new NoneChunkingConfig() { Mode = Mode.None };
        ApiEnum<string, AdvancedModeTransformConfigMode> expectedMode =
            AdvancedModeTransformConfigMode.Advanced;
        SegmentationConfig expectedSegmentationConfig = new NoneSegmentationConfig()
        {
            Mode = NoneSegmentationConfigMode.None,
        };

        Assert.Equal(expectedChunkingConfig, model.ChunkingConfig);
        Assert.Equal(expectedMode, model.Mode);
        Assert.Equal(expectedSegmentationConfig, model.SegmentationConfig);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AdvancedModeTransformConfig
        {
            ChunkingConfig = new NoneChunkingConfig() { Mode = Mode.None },
            Mode = AdvancedModeTransformConfigMode.Advanced,
            SegmentationConfig = new NoneSegmentationConfig()
            {
                Mode = NoneSegmentationConfigMode.None,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AdvancedModeTransformConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AdvancedModeTransformConfig
        {
            ChunkingConfig = new NoneChunkingConfig() { Mode = Mode.None },
            Mode = AdvancedModeTransformConfigMode.Advanced,
            SegmentationConfig = new NoneSegmentationConfig()
            {
                Mode = NoneSegmentationConfigMode.None,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AdvancedModeTransformConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ChunkingConfig expectedChunkingConfig = new NoneChunkingConfig() { Mode = Mode.None };
        ApiEnum<string, AdvancedModeTransformConfigMode> expectedMode =
            AdvancedModeTransformConfigMode.Advanced;
        SegmentationConfig expectedSegmentationConfig = new NoneSegmentationConfig()
        {
            Mode = NoneSegmentationConfigMode.None,
        };

        Assert.Equal(expectedChunkingConfig, deserialized.ChunkingConfig);
        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.Equal(expectedSegmentationConfig, deserialized.SegmentationConfig);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AdvancedModeTransformConfig
        {
            ChunkingConfig = new NoneChunkingConfig() { Mode = Mode.None },
            Mode = AdvancedModeTransformConfigMode.Advanced,
            SegmentationConfig = new NoneSegmentationConfig()
            {
                Mode = NoneSegmentationConfigMode.None,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AdvancedModeTransformConfig { };

        Assert.Null(model.ChunkingConfig);
        Assert.False(model.RawData.ContainsKey("chunking_config"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.SegmentationConfig);
        Assert.False(model.RawData.ContainsKey("segmentation_config"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AdvancedModeTransformConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AdvancedModeTransformConfig
        {
            // Null should be interpreted as omitted for these properties
            ChunkingConfig = null,
            Mode = null,
            SegmentationConfig = null,
        };

        Assert.Null(model.ChunkingConfig);
        Assert.False(model.RawData.ContainsKey("chunking_config"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.SegmentationConfig);
        Assert.False(model.RawData.ContainsKey("segmentation_config"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AdvancedModeTransformConfig
        {
            // Null should be interpreted as omitted for these properties
            ChunkingConfig = null,
            Mode = null,
            SegmentationConfig = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AdvancedModeTransformConfig
        {
            ChunkingConfig = new NoneChunkingConfig() { Mode = Mode.None },
            Mode = AdvancedModeTransformConfigMode.Advanced,
            SegmentationConfig = new NoneSegmentationConfig()
            {
                Mode = NoneSegmentationConfigMode.None,
            },
        };

        AdvancedModeTransformConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChunkingConfigTest : TestBase
{
    [Fact]
    public void NoneValidationWorks()
    {
        ChunkingConfig value = new NoneChunkingConfig() { Mode = Mode.None };
        value.Validate();
    }

    [Fact]
    public void CharacterValidationWorks()
    {
        ChunkingConfig value = new CharacterChunkingConfig()
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = CharacterChunkingConfigMode.Character,
        };
        value.Validate();
    }

    [Fact]
    public void TokenValidationWorks()
    {
        ChunkingConfig value = new TokenChunkingConfig()
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = TokenChunkingConfigMode.Token,
            Separator = "separator",
        };
        value.Validate();
    }

    [Fact]
    public void SentenceValidationWorks()
    {
        ChunkingConfig value = new SentenceChunkingConfig()
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = SentenceChunkingConfigMode.Sentence,
            ParagraphSeparator = "paragraph_separator",
            Separator = "separator",
        };
        value.Validate();
    }

    [Fact]
    public void SemanticValidationWorks()
    {
        ChunkingConfig value = new SemanticChunkingConfig()
        {
            BreakpointPercentileThreshold = 0,
            BufferSize = 0,
            Mode = SemanticChunkingConfigMode.Semantic,
        };
        value.Validate();
    }

    [Fact]
    public void NoneSerializationRoundtripWorks()
    {
        ChunkingConfig value = new NoneChunkingConfig() { Mode = Mode.None };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChunkingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CharacterSerializationRoundtripWorks()
    {
        ChunkingConfig value = new CharacterChunkingConfig()
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = CharacterChunkingConfigMode.Character,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChunkingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TokenSerializationRoundtripWorks()
    {
        ChunkingConfig value = new TokenChunkingConfig()
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = TokenChunkingConfigMode.Token,
            Separator = "separator",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChunkingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SentenceSerializationRoundtripWorks()
    {
        ChunkingConfig value = new SentenceChunkingConfig()
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = SentenceChunkingConfigMode.Sentence,
            ParagraphSeparator = "paragraph_separator",
            Separator = "separator",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChunkingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SemanticSerializationRoundtripWorks()
    {
        ChunkingConfig value = new SemanticChunkingConfig()
        {
            BreakpointPercentileThreshold = 0,
            BufferSize = 0,
            Mode = SemanticChunkingConfigMode.Semantic,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChunkingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NoneChunkingConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NoneChunkingConfig { Mode = Mode.None };

        ApiEnum<string, Mode> expectedMode = Mode.None;

        Assert.Equal(expectedMode, model.Mode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NoneChunkingConfig { Mode = Mode.None };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NoneChunkingConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NoneChunkingConfig { Mode = Mode.None };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NoneChunkingConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Mode> expectedMode = Mode.None;

        Assert.Equal(expectedMode, deserialized.Mode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NoneChunkingConfig { Mode = Mode.None };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NoneChunkingConfig { };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NoneChunkingConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NoneChunkingConfig
        {
            // Null should be interpreted as omitted for these properties
            Mode = null,
        };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NoneChunkingConfig
        {
            // Null should be interpreted as omitted for these properties
            Mode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NoneChunkingConfig { Mode = Mode.None };

        NoneChunkingConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModeTest : TestBase
{
    [Theory]
    [InlineData(Mode.None)]
    public void Validation_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Mode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Mode.None)]
    public void SerializationRoundtrip_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Mode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CharacterChunkingConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CharacterChunkingConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = CharacterChunkingConfigMode.Character,
        };

        long expectedChunkOverlap = 0;
        long expectedChunkSize = 1;
        ApiEnum<string, CharacterChunkingConfigMode> expectedMode =
            CharacterChunkingConfigMode.Character;

        Assert.Equal(expectedChunkOverlap, model.ChunkOverlap);
        Assert.Equal(expectedChunkSize, model.ChunkSize);
        Assert.Equal(expectedMode, model.Mode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CharacterChunkingConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = CharacterChunkingConfigMode.Character,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CharacterChunkingConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CharacterChunkingConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = CharacterChunkingConfigMode.Character,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CharacterChunkingConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedChunkOverlap = 0;
        long expectedChunkSize = 1;
        ApiEnum<string, CharacterChunkingConfigMode> expectedMode =
            CharacterChunkingConfigMode.Character;

        Assert.Equal(expectedChunkOverlap, deserialized.ChunkOverlap);
        Assert.Equal(expectedChunkSize, deserialized.ChunkSize);
        Assert.Equal(expectedMode, deserialized.Mode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CharacterChunkingConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = CharacterChunkingConfigMode.Character,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CharacterChunkingConfig { };

        Assert.Null(model.ChunkOverlap);
        Assert.False(model.RawData.ContainsKey("chunk_overlap"));
        Assert.Null(model.ChunkSize);
        Assert.False(model.RawData.ContainsKey("chunk_size"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CharacterChunkingConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CharacterChunkingConfig
        {
            // Null should be interpreted as omitted for these properties
            ChunkOverlap = null,
            ChunkSize = null,
            Mode = null,
        };

        Assert.Null(model.ChunkOverlap);
        Assert.False(model.RawData.ContainsKey("chunk_overlap"));
        Assert.Null(model.ChunkSize);
        Assert.False(model.RawData.ContainsKey("chunk_size"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CharacterChunkingConfig
        {
            // Null should be interpreted as omitted for these properties
            ChunkOverlap = null,
            ChunkSize = null,
            Mode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CharacterChunkingConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = CharacterChunkingConfigMode.Character,
        };

        CharacterChunkingConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CharacterChunkingConfigModeTest : TestBase
{
    [Theory]
    [InlineData(CharacterChunkingConfigMode.Character)]
    public void Validation_Works(CharacterChunkingConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CharacterChunkingConfigMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CharacterChunkingConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CharacterChunkingConfigMode.Character)]
    public void SerializationRoundtrip_Works(CharacterChunkingConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CharacterChunkingConfigMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CharacterChunkingConfigMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CharacterChunkingConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CharacterChunkingConfigMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TokenChunkingConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TokenChunkingConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = TokenChunkingConfigMode.Token,
            Separator = "separator",
        };

        long expectedChunkOverlap = 0;
        long expectedChunkSize = 1;
        ApiEnum<string, TokenChunkingConfigMode> expectedMode = TokenChunkingConfigMode.Token;
        string expectedSeparator = "separator";

        Assert.Equal(expectedChunkOverlap, model.ChunkOverlap);
        Assert.Equal(expectedChunkSize, model.ChunkSize);
        Assert.Equal(expectedMode, model.Mode);
        Assert.Equal(expectedSeparator, model.Separator);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TokenChunkingConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = TokenChunkingConfigMode.Token,
            Separator = "separator",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TokenChunkingConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TokenChunkingConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = TokenChunkingConfigMode.Token,
            Separator = "separator",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TokenChunkingConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedChunkOverlap = 0;
        long expectedChunkSize = 1;
        ApiEnum<string, TokenChunkingConfigMode> expectedMode = TokenChunkingConfigMode.Token;
        string expectedSeparator = "separator";

        Assert.Equal(expectedChunkOverlap, deserialized.ChunkOverlap);
        Assert.Equal(expectedChunkSize, deserialized.ChunkSize);
        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.Equal(expectedSeparator, deserialized.Separator);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TokenChunkingConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = TokenChunkingConfigMode.Token,
            Separator = "separator",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TokenChunkingConfig { };

        Assert.Null(model.ChunkOverlap);
        Assert.False(model.RawData.ContainsKey("chunk_overlap"));
        Assert.Null(model.ChunkSize);
        Assert.False(model.RawData.ContainsKey("chunk_size"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.Separator);
        Assert.False(model.RawData.ContainsKey("separator"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TokenChunkingConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TokenChunkingConfig
        {
            // Null should be interpreted as omitted for these properties
            ChunkOverlap = null,
            ChunkSize = null,
            Mode = null,
            Separator = null,
        };

        Assert.Null(model.ChunkOverlap);
        Assert.False(model.RawData.ContainsKey("chunk_overlap"));
        Assert.Null(model.ChunkSize);
        Assert.False(model.RawData.ContainsKey("chunk_size"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.Separator);
        Assert.False(model.RawData.ContainsKey("separator"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TokenChunkingConfig
        {
            // Null should be interpreted as omitted for these properties
            ChunkOverlap = null,
            ChunkSize = null,
            Mode = null,
            Separator = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TokenChunkingConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = TokenChunkingConfigMode.Token,
            Separator = "separator",
        };

        TokenChunkingConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TokenChunkingConfigModeTest : TestBase
{
    [Theory]
    [InlineData(TokenChunkingConfigMode.Token)]
    public void Validation_Works(TokenChunkingConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TokenChunkingConfigMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TokenChunkingConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TokenChunkingConfigMode.Token)]
    public void SerializationRoundtrip_Works(TokenChunkingConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TokenChunkingConfigMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TokenChunkingConfigMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TokenChunkingConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TokenChunkingConfigMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SentenceChunkingConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SentenceChunkingConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = SentenceChunkingConfigMode.Sentence,
            ParagraphSeparator = "paragraph_separator",
            Separator = "separator",
        };

        long expectedChunkOverlap = 0;
        long expectedChunkSize = 1;
        ApiEnum<string, SentenceChunkingConfigMode> expectedMode =
            SentenceChunkingConfigMode.Sentence;
        string expectedParagraphSeparator = "paragraph_separator";
        string expectedSeparator = "separator";

        Assert.Equal(expectedChunkOverlap, model.ChunkOverlap);
        Assert.Equal(expectedChunkSize, model.ChunkSize);
        Assert.Equal(expectedMode, model.Mode);
        Assert.Equal(expectedParagraphSeparator, model.ParagraphSeparator);
        Assert.Equal(expectedSeparator, model.Separator);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SentenceChunkingConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = SentenceChunkingConfigMode.Sentence,
            ParagraphSeparator = "paragraph_separator",
            Separator = "separator",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SentenceChunkingConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SentenceChunkingConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = SentenceChunkingConfigMode.Sentence,
            ParagraphSeparator = "paragraph_separator",
            Separator = "separator",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SentenceChunkingConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedChunkOverlap = 0;
        long expectedChunkSize = 1;
        ApiEnum<string, SentenceChunkingConfigMode> expectedMode =
            SentenceChunkingConfigMode.Sentence;
        string expectedParagraphSeparator = "paragraph_separator";
        string expectedSeparator = "separator";

        Assert.Equal(expectedChunkOverlap, deserialized.ChunkOverlap);
        Assert.Equal(expectedChunkSize, deserialized.ChunkSize);
        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.Equal(expectedParagraphSeparator, deserialized.ParagraphSeparator);
        Assert.Equal(expectedSeparator, deserialized.Separator);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SentenceChunkingConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = SentenceChunkingConfigMode.Sentence,
            ParagraphSeparator = "paragraph_separator",
            Separator = "separator",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SentenceChunkingConfig { };

        Assert.Null(model.ChunkOverlap);
        Assert.False(model.RawData.ContainsKey("chunk_overlap"));
        Assert.Null(model.ChunkSize);
        Assert.False(model.RawData.ContainsKey("chunk_size"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.ParagraphSeparator);
        Assert.False(model.RawData.ContainsKey("paragraph_separator"));
        Assert.Null(model.Separator);
        Assert.False(model.RawData.ContainsKey("separator"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SentenceChunkingConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SentenceChunkingConfig
        {
            // Null should be interpreted as omitted for these properties
            ChunkOverlap = null,
            ChunkSize = null,
            Mode = null,
            ParagraphSeparator = null,
            Separator = null,
        };

        Assert.Null(model.ChunkOverlap);
        Assert.False(model.RawData.ContainsKey("chunk_overlap"));
        Assert.Null(model.ChunkSize);
        Assert.False(model.RawData.ContainsKey("chunk_size"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.ParagraphSeparator);
        Assert.False(model.RawData.ContainsKey("paragraph_separator"));
        Assert.Null(model.Separator);
        Assert.False(model.RawData.ContainsKey("separator"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SentenceChunkingConfig
        {
            // Null should be interpreted as omitted for these properties
            ChunkOverlap = null,
            ChunkSize = null,
            Mode = null,
            ParagraphSeparator = null,
            Separator = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SentenceChunkingConfig
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = SentenceChunkingConfigMode.Sentence,
            ParagraphSeparator = "paragraph_separator",
            Separator = "separator",
        };

        SentenceChunkingConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SentenceChunkingConfigModeTest : TestBase
{
    [Theory]
    [InlineData(SentenceChunkingConfigMode.Sentence)]
    public void Validation_Works(SentenceChunkingConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SentenceChunkingConfigMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SentenceChunkingConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SentenceChunkingConfigMode.Sentence)]
    public void SerializationRoundtrip_Works(SentenceChunkingConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SentenceChunkingConfigMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SentenceChunkingConfigMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SentenceChunkingConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SentenceChunkingConfigMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SemanticChunkingConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SemanticChunkingConfig
        {
            BreakpointPercentileThreshold = 0,
            BufferSize = 0,
            Mode = SemanticChunkingConfigMode.Semantic,
        };

        long expectedBreakpointPercentileThreshold = 0;
        long expectedBufferSize = 0;
        ApiEnum<string, SemanticChunkingConfigMode> expectedMode =
            SemanticChunkingConfigMode.Semantic;

        Assert.Equal(expectedBreakpointPercentileThreshold, model.BreakpointPercentileThreshold);
        Assert.Equal(expectedBufferSize, model.BufferSize);
        Assert.Equal(expectedMode, model.Mode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SemanticChunkingConfig
        {
            BreakpointPercentileThreshold = 0,
            BufferSize = 0,
            Mode = SemanticChunkingConfigMode.Semantic,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SemanticChunkingConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SemanticChunkingConfig
        {
            BreakpointPercentileThreshold = 0,
            BufferSize = 0,
            Mode = SemanticChunkingConfigMode.Semantic,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SemanticChunkingConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedBreakpointPercentileThreshold = 0;
        long expectedBufferSize = 0;
        ApiEnum<string, SemanticChunkingConfigMode> expectedMode =
            SemanticChunkingConfigMode.Semantic;

        Assert.Equal(
            expectedBreakpointPercentileThreshold,
            deserialized.BreakpointPercentileThreshold
        );
        Assert.Equal(expectedBufferSize, deserialized.BufferSize);
        Assert.Equal(expectedMode, deserialized.Mode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SemanticChunkingConfig
        {
            BreakpointPercentileThreshold = 0,
            BufferSize = 0,
            Mode = SemanticChunkingConfigMode.Semantic,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SemanticChunkingConfig { };

        Assert.Null(model.BreakpointPercentileThreshold);
        Assert.False(model.RawData.ContainsKey("breakpoint_percentile_threshold"));
        Assert.Null(model.BufferSize);
        Assert.False(model.RawData.ContainsKey("buffer_size"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SemanticChunkingConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SemanticChunkingConfig
        {
            // Null should be interpreted as omitted for these properties
            BreakpointPercentileThreshold = null,
            BufferSize = null,
            Mode = null,
        };

        Assert.Null(model.BreakpointPercentileThreshold);
        Assert.False(model.RawData.ContainsKey("breakpoint_percentile_threshold"));
        Assert.Null(model.BufferSize);
        Assert.False(model.RawData.ContainsKey("buffer_size"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SemanticChunkingConfig
        {
            // Null should be interpreted as omitted for these properties
            BreakpointPercentileThreshold = null,
            BufferSize = null,
            Mode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SemanticChunkingConfig
        {
            BreakpointPercentileThreshold = 0,
            BufferSize = 0,
            Mode = SemanticChunkingConfigMode.Semantic,
        };

        SemanticChunkingConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SemanticChunkingConfigModeTest : TestBase
{
    [Theory]
    [InlineData(SemanticChunkingConfigMode.Semantic)]
    public void Validation_Works(SemanticChunkingConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SemanticChunkingConfigMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SemanticChunkingConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SemanticChunkingConfigMode.Semantic)]
    public void SerializationRoundtrip_Works(SemanticChunkingConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SemanticChunkingConfigMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SemanticChunkingConfigMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SemanticChunkingConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SemanticChunkingConfigMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AdvancedModeTransformConfigModeTest : TestBase
{
    [Theory]
    [InlineData(AdvancedModeTransformConfigMode.Advanced)]
    public void Validation_Works(AdvancedModeTransformConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AdvancedModeTransformConfigMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AdvancedModeTransformConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AdvancedModeTransformConfigMode.Advanced)]
    public void SerializationRoundtrip_Works(AdvancedModeTransformConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AdvancedModeTransformConfigMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AdvancedModeTransformConfigMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AdvancedModeTransformConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AdvancedModeTransformConfigMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SegmentationConfigTest : TestBase
{
    [Fact]
    public void NoneValidationWorks()
    {
        SegmentationConfig value = new NoneSegmentationConfig()
        {
            Mode = NoneSegmentationConfigMode.None,
        };
        value.Validate();
    }

    [Fact]
    public void PageValidationWorks()
    {
        SegmentationConfig value = new PageSegmentationConfig()
        {
            Mode = PageSegmentationConfigMode.Page,
            PageSeparator = "page_separator",
        };
        value.Validate();
    }

    [Fact]
    public void ElementValidationWorks()
    {
        SegmentationConfig value = new ElementSegmentationConfig()
        {
            Mode = ElementSegmentationConfigMode.Element,
        };
        value.Validate();
    }

    [Fact]
    public void NoneSerializationRoundtripWorks()
    {
        SegmentationConfig value = new NoneSegmentationConfig()
        {
            Mode = NoneSegmentationConfigMode.None,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SegmentationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void PageSerializationRoundtripWorks()
    {
        SegmentationConfig value = new PageSegmentationConfig()
        {
            Mode = PageSegmentationConfigMode.Page,
            PageSeparator = "page_separator",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SegmentationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ElementSerializationRoundtripWorks()
    {
        SegmentationConfig value = new ElementSegmentationConfig()
        {
            Mode = ElementSegmentationConfigMode.Element,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SegmentationConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NoneSegmentationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NoneSegmentationConfig { Mode = NoneSegmentationConfigMode.None };

        ApiEnum<string, NoneSegmentationConfigMode> expectedMode = NoneSegmentationConfigMode.None;

        Assert.Equal(expectedMode, model.Mode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NoneSegmentationConfig { Mode = NoneSegmentationConfigMode.None };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NoneSegmentationConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NoneSegmentationConfig { Mode = NoneSegmentationConfigMode.None };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NoneSegmentationConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, NoneSegmentationConfigMode> expectedMode = NoneSegmentationConfigMode.None;

        Assert.Equal(expectedMode, deserialized.Mode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NoneSegmentationConfig { Mode = NoneSegmentationConfigMode.None };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NoneSegmentationConfig { };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new NoneSegmentationConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new NoneSegmentationConfig
        {
            // Null should be interpreted as omitted for these properties
            Mode = null,
        };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NoneSegmentationConfig
        {
            // Null should be interpreted as omitted for these properties
            Mode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NoneSegmentationConfig { Mode = NoneSegmentationConfigMode.None };

        NoneSegmentationConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NoneSegmentationConfigModeTest : TestBase
{
    [Theory]
    [InlineData(NoneSegmentationConfigMode.None)]
    public void Validation_Works(NoneSegmentationConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NoneSegmentationConfigMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NoneSegmentationConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NoneSegmentationConfigMode.None)]
    public void SerializationRoundtrip_Works(NoneSegmentationConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NoneSegmentationConfigMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NoneSegmentationConfigMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NoneSegmentationConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NoneSegmentationConfigMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageSegmentationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PageSegmentationConfig
        {
            Mode = PageSegmentationConfigMode.Page,
            PageSeparator = "page_separator",
        };

        ApiEnum<string, PageSegmentationConfigMode> expectedMode = PageSegmentationConfigMode.Page;
        string expectedPageSeparator = "page_separator";

        Assert.Equal(expectedMode, model.Mode);
        Assert.Equal(expectedPageSeparator, model.PageSeparator);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PageSegmentationConfig
        {
            Mode = PageSegmentationConfigMode.Page,
            PageSeparator = "page_separator",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PageSegmentationConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PageSegmentationConfig
        {
            Mode = PageSegmentationConfigMode.Page,
            PageSeparator = "page_separator",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PageSegmentationConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, PageSegmentationConfigMode> expectedMode = PageSegmentationConfigMode.Page;
        string expectedPageSeparator = "page_separator";

        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.Equal(expectedPageSeparator, deserialized.PageSeparator);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PageSegmentationConfig
        {
            Mode = PageSegmentationConfigMode.Page,
            PageSeparator = "page_separator",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PageSegmentationConfig { };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.PageSeparator);
        Assert.False(model.RawData.ContainsKey("page_separator"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PageSegmentationConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PageSegmentationConfig
        {
            // Null should be interpreted as omitted for these properties
            Mode = null,
            PageSeparator = null,
        };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.PageSeparator);
        Assert.False(model.RawData.ContainsKey("page_separator"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PageSegmentationConfig
        {
            // Null should be interpreted as omitted for these properties
            Mode = null,
            PageSeparator = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PageSegmentationConfig
        {
            Mode = PageSegmentationConfigMode.Page,
            PageSeparator = "page_separator",
        };

        PageSegmentationConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PageSegmentationConfigModeTest : TestBase
{
    [Theory]
    [InlineData(PageSegmentationConfigMode.Page)]
    public void Validation_Works(PageSegmentationConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PageSegmentationConfigMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PageSegmentationConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PageSegmentationConfigMode.Page)]
    public void SerializationRoundtrip_Works(PageSegmentationConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PageSegmentationConfigMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PageSegmentationConfigMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PageSegmentationConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PageSegmentationConfigMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ElementSegmentationConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementSegmentationConfig { Mode = ElementSegmentationConfigMode.Element };

        ApiEnum<string, ElementSegmentationConfigMode> expectedMode =
            ElementSegmentationConfigMode.Element;

        Assert.Equal(expectedMode, model.Mode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementSegmentationConfig { Mode = ElementSegmentationConfigMode.Element };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementSegmentationConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementSegmentationConfig { Mode = ElementSegmentationConfigMode.Element };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementSegmentationConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ElementSegmentationConfigMode> expectedMode =
            ElementSegmentationConfigMode.Element;

        Assert.Equal(expectedMode, deserialized.Mode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementSegmentationConfig { Mode = ElementSegmentationConfigMode.Element };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementSegmentationConfig { };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementSegmentationConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ElementSegmentationConfig
        {
            // Null should be interpreted as omitted for these properties
            Mode = null,
        };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementSegmentationConfig
        {
            // Null should be interpreted as omitted for these properties
            Mode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElementSegmentationConfig { Mode = ElementSegmentationConfigMode.Element };

        ElementSegmentationConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ElementSegmentationConfigModeTest : TestBase
{
    [Theory]
    [InlineData(ElementSegmentationConfigMode.Element)]
    public void Validation_Works(ElementSegmentationConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ElementSegmentationConfigMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ElementSegmentationConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ElementSegmentationConfigMode.Element)]
    public void SerializationRoundtrip_Works(ElementSegmentationConfigMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ElementSegmentationConfigMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ElementSegmentationConfigMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ElementSegmentationConfigMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ElementSegmentationConfigMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
