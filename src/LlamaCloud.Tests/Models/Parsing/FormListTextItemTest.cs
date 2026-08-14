using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class FormListTextItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FormListTextItem
        {
            Md = "md",
            Value = "value",
            Type = FormListTextItemType.Text,
        };

        string expectedMd = "md";
        string expectedValue = "value";
        ApiEnum<string, FormListTextItemType> expectedType = FormListTextItemType.Text;

        Assert.Equal(expectedMd, model.Md);
        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FormListTextItem
        {
            Md = "md",
            Value = "value",
            Type = FormListTextItemType.Text,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormListTextItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FormListTextItem
        {
            Md = "md",
            Value = "value",
            Type = FormListTextItemType.Text,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FormListTextItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMd = "md";
        string expectedValue = "value";
        ApiEnum<string, FormListTextItemType> expectedType = FormListTextItemType.Text;

        Assert.Equal(expectedMd, deserialized.Md);
        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FormListTextItem
        {
            Md = "md",
            Value = "value",
            Type = FormListTextItemType.Text,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FormListTextItem { Md = "md", Value = "value" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FormListTextItem { Md = "md", Value = "value" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FormListTextItem
        {
            Md = "md",
            Value = "value",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FormListTextItem
        {
            Md = "md",
            Value = "value",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FormListTextItem
        {
            Md = "md",
            Value = "value",
            Type = FormListTextItemType.Text,
        };

        FormListTextItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormListTextItemTypeTest : TestBase
{
    [Theory]
    [InlineData(FormListTextItemType.Text)]
    public void Validation_Works(FormListTextItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FormListTextItemType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FormListTextItemType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FormListTextItemType.Text)]
    public void SerializationRoundtrip_Works(FormListTextItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FormListTextItemType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FormListTextItemType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FormListTextItemType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FormListTextItemType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
