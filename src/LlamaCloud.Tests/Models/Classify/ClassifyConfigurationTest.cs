using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Classify;

namespace LlamaCloud.Tests.Models.Classify;

public class ClassifyConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClassifyConfiguration
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

        List<Rule> expectedRules =
        [
            new()
            {
                Description = "contains invoice number, line items, and total amount",
                Type = "invoice",
            },
        ];
        ApiEnum<string, Mode> expectedMode = Mode.Fast;
        ParsingConfiguration expectedParsingConfiguration = new()
        {
            Lang = "en",
            MaxPages = 10,
            TargetPages = "1,3,5-7",
        };

        Assert.Equal(expectedRules.Count, model.Rules.Count);
        for (int i = 0; i < expectedRules.Count; i++)
        {
            Assert.Equal(expectedRules[i], model.Rules[i]);
        }
        Assert.Equal(expectedMode, model.Mode);
        Assert.Equal(expectedParsingConfiguration, model.ParsingConfiguration);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClassifyConfiguration
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClassifyConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClassifyConfiguration
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClassifyConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Rule> expectedRules =
        [
            new()
            {
                Description = "contains invoice number, line items, and total amount",
                Type = "invoice",
            },
        ];
        ApiEnum<string, Mode> expectedMode = Mode.Fast;
        ParsingConfiguration expectedParsingConfiguration = new()
        {
            Lang = "en",
            MaxPages = 10,
            TargetPages = "1,3,5-7",
        };

        Assert.Equal(expectedRules.Count, deserialized.Rules.Count);
        for (int i = 0; i < expectedRules.Count; i++)
        {
            Assert.Equal(expectedRules[i], deserialized.Rules[i]);
        }
        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.Equal(expectedParsingConfiguration, deserialized.ParsingConfiguration);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClassifyConfiguration
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ClassifyConfiguration
        {
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            ParsingConfiguration = new()
            {
                Lang = "en",
                MaxPages = 10,
                TargetPages = "1,3,5-7",
            },
        };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ClassifyConfiguration
        {
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            ParsingConfiguration = new()
            {
                Lang = "en",
                MaxPages = 10,
                TargetPages = "1,3,5-7",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ClassifyConfiguration
        {
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            ParsingConfiguration = new()
            {
                Lang = "en",
                MaxPages = 10,
                TargetPages = "1,3,5-7",
            },

            // Null should be interpreted as omitted for these properties
            Mode = null,
        };

        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ClassifyConfiguration
        {
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            ParsingConfiguration = new()
            {
                Lang = "en",
                MaxPages = 10,
                TargetPages = "1,3,5-7",
            },

            // Null should be interpreted as omitted for these properties
            Mode = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ClassifyConfiguration
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
        };

        Assert.Null(model.ParsingConfiguration);
        Assert.False(model.RawData.ContainsKey("parsing_configuration"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ClassifyConfiguration
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ClassifyConfiguration
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

            ParsingConfiguration = null,
        };

        Assert.Null(model.ParsingConfiguration);
        Assert.True(model.RawData.ContainsKey("parsing_configuration"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ClassifyConfiguration
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

            ParsingConfiguration = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClassifyConfiguration
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

        ClassifyConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RuleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Rule
        {
            Description = "contains invoice number, line items, and total amount",
            Type = "invoice",
        };

        string expectedDescription = "contains invoice number, line items, and total amount";
        string expectedType = "invoice";

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Rule
        {
            Description = "contains invoice number, line items, and total amount",
            Type = "invoice",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rule>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Rule
        {
            Description = "contains invoice number, line items, and total amount",
            Type = "invoice",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rule>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedDescription = "contains invoice number, line items, and total amount";
        string expectedType = "invoice";

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Rule
        {
            Description = "contains invoice number, line items, and total amount",
            Type = "invoice",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Rule
        {
            Description = "contains invoice number, line items, and total amount",
            Type = "invoice",
        };

        Rule copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModeTest : TestBase
{
    [Theory]
    [InlineData(Mode.Fast)]
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
    [InlineData(Mode.Fast)]
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

public class ParsingConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ParsingConfiguration
        {
            Lang = "en",
            MaxPages = 10,
            TargetPages = "1,3,5-7",
        };

        string expectedLang = "en";
        long expectedMaxPages = 10;
        string expectedTargetPages = "1,3,5-7";

        Assert.Equal(expectedLang, model.Lang);
        Assert.Equal(expectedMaxPages, model.MaxPages);
        Assert.Equal(expectedTargetPages, model.TargetPages);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ParsingConfiguration
        {
            Lang = "en",
            MaxPages = 10,
            TargetPages = "1,3,5-7",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsingConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ParsingConfiguration
        {
            Lang = "en",
            MaxPages = 10,
            TargetPages = "1,3,5-7",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsingConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedLang = "en";
        long expectedMaxPages = 10;
        string expectedTargetPages = "1,3,5-7";

        Assert.Equal(expectedLang, deserialized.Lang);
        Assert.Equal(expectedMaxPages, deserialized.MaxPages);
        Assert.Equal(expectedTargetPages, deserialized.TargetPages);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ParsingConfiguration
        {
            Lang = "en",
            MaxPages = 10,
            TargetPages = "1,3,5-7",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ParsingConfiguration { MaxPages = 10, TargetPages = "1,3,5-7" };

        Assert.Null(model.Lang);
        Assert.False(model.RawData.ContainsKey("lang"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ParsingConfiguration { MaxPages = 10, TargetPages = "1,3,5-7" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ParsingConfiguration
        {
            MaxPages = 10,
            TargetPages = "1,3,5-7",

            // Null should be interpreted as omitted for these properties
            Lang = null,
        };

        Assert.Null(model.Lang);
        Assert.False(model.RawData.ContainsKey("lang"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ParsingConfiguration
        {
            MaxPages = 10,
            TargetPages = "1,3,5-7",

            // Null should be interpreted as omitted for these properties
            Lang = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ParsingConfiguration { Lang = "en" };

        Assert.Null(model.MaxPages);
        Assert.False(model.RawData.ContainsKey("max_pages"));
        Assert.Null(model.TargetPages);
        Assert.False(model.RawData.ContainsKey("target_pages"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ParsingConfiguration { Lang = "en" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ParsingConfiguration
        {
            Lang = "en",

            MaxPages = null,
            TargetPages = null,
        };

        Assert.Null(model.MaxPages);
        Assert.True(model.RawData.ContainsKey("max_pages"));
        Assert.Null(model.TargetPages);
        Assert.True(model.RawData.ContainsKey("target_pages"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ParsingConfiguration
        {
            Lang = "en",

            MaxPages = null,
            TargetPages = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ParsingConfiguration
        {
            Lang = "en",
            MaxPages = 10,
            TargetPages = "1,3,5-7",
        };

        ParsingConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}
