using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class ImageItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageItem
        {
            Caption = "caption",
            Md = "md",
            Url = "url",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = ImageItemType.Image,
        };

        string expectedCaption = "caption";
        string expectedMd = "md";
        string expectedUrl = "url";
        List<BBox> expectedBbox =
        [
            new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
        ];
        ApiEnum<string, ImageItemType> expectedType = ImageItemType.Image;

        Assert.Equal(expectedCaption, model.Caption);
        Assert.Equal(expectedMd, model.Md);
        Assert.Equal(expectedUrl, model.Url);
        Assert.NotNull(model.Bbox);
        Assert.Equal(expectedBbox.Count, model.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], model.Bbox[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageItem
        {
            Caption = "caption",
            Md = "md",
            Url = "url",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = ImageItemType.Image,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageItem>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageItem
        {
            Caption = "caption",
            Md = "md",
            Url = "url",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = ImageItemType.Image,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImageItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCaption = "caption";
        string expectedMd = "md";
        string expectedUrl = "url";
        List<BBox> expectedBbox =
        [
            new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
                Confidence = 0,
                EndIndex = 0,
                Label = "label",
                R = 0,
                StartIndex = 0,
            },
        ];
        ApiEnum<string, ImageItemType> expectedType = ImageItemType.Image;

        Assert.Equal(expectedCaption, deserialized.Caption);
        Assert.Equal(expectedMd, deserialized.Md);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.NotNull(deserialized.Bbox);
        Assert.Equal(expectedBbox.Count, deserialized.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], deserialized.Bbox[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageItem
        {
            Caption = "caption",
            Md = "md",
            Url = "url",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = ImageItemType.Image,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImageItem
        {
            Caption = "caption",
            Md = "md",
            Url = "url",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ImageItem
        {
            Caption = "caption",
            Md = "md",
            Url = "url",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ImageItem
        {
            Caption = "caption",
            Md = "md",
            Url = "url",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ImageItem
        {
            Caption = "caption",
            Md = "md",
            Url = "url",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImageItem
        {
            Caption = "caption",
            Md = "md",
            Url = "url",
            Type = ImageItemType.Image,
        };

        Assert.Null(model.Bbox);
        Assert.False(model.RawData.ContainsKey("bbox"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ImageItem
        {
            Caption = "caption",
            Md = "md",
            Url = "url",
            Type = ImageItemType.Image,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ImageItem
        {
            Caption = "caption",
            Md = "md",
            Url = "url",
            Type = ImageItemType.Image,

            Bbox = null,
        };

        Assert.Null(model.Bbox);
        Assert.True(model.RawData.ContainsKey("bbox"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ImageItem
        {
            Caption = "caption",
            Md = "md",
            Url = "url",
            Type = ImageItemType.Image,

            Bbox = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ImageItem
        {
            Caption = "caption",
            Md = "md",
            Url = "url",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = ImageItemType.Image,
        };

        ImageItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageItemTypeTest : TestBase
{
    [Theory]
    [InlineData(ImageItemType.Image)]
    public void Validation_Works(ImageItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ImageItemType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ImageItemType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ImageItemType.Image)]
    public void SerializationRoundtrip_Works(ImageItemType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ImageItemType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ImageItemType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ImageItemType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ImageItemType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
