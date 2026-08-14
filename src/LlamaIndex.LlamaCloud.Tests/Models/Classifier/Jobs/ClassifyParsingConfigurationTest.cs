using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Classifier.Jobs;
using LlamaIndex.LlamaCloud.Models.Parsing;

namespace LlamaIndex.LlamaCloud.Tests.Models.Classifier.Jobs;

public class ClassifyParsingConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClassifyParsingConfiguration
        {
            Lang = ParsingLanguages.Abq,
            MaxPages = 0,
            TargetPages = [0],
        };

        ApiEnum<string, ParsingLanguages> expectedLang = ParsingLanguages.Abq;
        long expectedMaxPages = 0;
        List<long> expectedTargetPages = [0];

        Assert.Equal(expectedLang, model.Lang);
        Assert.Equal(expectedMaxPages, model.MaxPages);
        Assert.NotNull(model.TargetPages);
        Assert.Equal(expectedTargetPages.Count, model.TargetPages.Count);
        for (int i = 0; i < expectedTargetPages.Count; i++)
        {
            Assert.Equal(expectedTargetPages[i], model.TargetPages[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClassifyParsingConfiguration
        {
            Lang = ParsingLanguages.Abq,
            MaxPages = 0,
            TargetPages = [0],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClassifyParsingConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClassifyParsingConfiguration
        {
            Lang = ParsingLanguages.Abq,
            MaxPages = 0,
            TargetPages = [0],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClassifyParsingConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ParsingLanguages> expectedLang = ParsingLanguages.Abq;
        long expectedMaxPages = 0;
        List<long> expectedTargetPages = [0];

        Assert.Equal(expectedLang, deserialized.Lang);
        Assert.Equal(expectedMaxPages, deserialized.MaxPages);
        Assert.NotNull(deserialized.TargetPages);
        Assert.Equal(expectedTargetPages.Count, deserialized.TargetPages.Count);
        for (int i = 0; i < expectedTargetPages.Count; i++)
        {
            Assert.Equal(expectedTargetPages[i], deserialized.TargetPages[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClassifyParsingConfiguration
        {
            Lang = ParsingLanguages.Abq,
            MaxPages = 0,
            TargetPages = [0],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ClassifyParsingConfiguration { MaxPages = 0, TargetPages = [0] };

        Assert.Null(model.Lang);
        Assert.False(model.RawData.ContainsKey("lang"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ClassifyParsingConfiguration { MaxPages = 0, TargetPages = [0] };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ClassifyParsingConfiguration
        {
            MaxPages = 0,
            TargetPages = [0],

            // Null should be interpreted as omitted for these properties
            Lang = null,
        };

        Assert.Null(model.Lang);
        Assert.False(model.RawData.ContainsKey("lang"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ClassifyParsingConfiguration
        {
            MaxPages = 0,
            TargetPages = [0],

            // Null should be interpreted as omitted for these properties
            Lang = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ClassifyParsingConfiguration { Lang = ParsingLanguages.Abq };

        Assert.Null(model.MaxPages);
        Assert.False(model.RawData.ContainsKey("max_pages"));
        Assert.Null(model.TargetPages);
        Assert.False(model.RawData.ContainsKey("target_pages"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ClassifyParsingConfiguration { Lang = ParsingLanguages.Abq };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ClassifyParsingConfiguration
        {
            Lang = ParsingLanguages.Abq,

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
        var model = new ClassifyParsingConfiguration
        {
            Lang = ParsingLanguages.Abq,

            MaxPages = null,
            TargetPages = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClassifyParsingConfiguration
        {
            Lang = ParsingLanguages.Abq,
            MaxPages = 0,
            TargetPages = [0],
        };

        ClassifyParsingConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}
