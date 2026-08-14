using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class PageFigureNodeWithScoreTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PageFigureNodeWithScore
        {
            Node = new()
            {
                Confidence = 0,
                FigureName = "figure_name",
                FigureSize = 0,
                FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PageIndex = 0,
                IsLikelyNoise = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Score = 0,
            ClassName = "class_name",
        };

        Node expectedNode = new()
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        double expectedScore = 0;
        string expectedClassName = "class_name";

        Assert.Equal(expectedNode, model.Node);
        Assert.Equal(expectedScore, model.Score);
        Assert.Equal(expectedClassName, model.ClassName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PageFigureNodeWithScore
        {
            Node = new()
            {
                Confidence = 0,
                FigureName = "figure_name",
                FigureSize = 0,
                FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PageIndex = 0,
                IsLikelyNoise = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Score = 0,
            ClassName = "class_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PageFigureNodeWithScore>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PageFigureNodeWithScore
        {
            Node = new()
            {
                Confidence = 0,
                FigureName = "figure_name",
                FigureSize = 0,
                FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PageIndex = 0,
                IsLikelyNoise = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Score = 0,
            ClassName = "class_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PageFigureNodeWithScore>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Node expectedNode = new()
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        double expectedScore = 0;
        string expectedClassName = "class_name";

        Assert.Equal(expectedNode, deserialized.Node);
        Assert.Equal(expectedScore, deserialized.Score);
        Assert.Equal(expectedClassName, deserialized.ClassName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PageFigureNodeWithScore
        {
            Node = new()
            {
                Confidence = 0,
                FigureName = "figure_name",
                FigureSize = 0,
                FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PageIndex = 0,
                IsLikelyNoise = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Score = 0,
            ClassName = "class_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PageFigureNodeWithScore
        {
            Node = new()
            {
                Confidence = 0,
                FigureName = "figure_name",
                FigureSize = 0,
                FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PageIndex = 0,
                IsLikelyNoise = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Score = 0,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PageFigureNodeWithScore
        {
            Node = new()
            {
                Confidence = 0,
                FigureName = "figure_name",
                FigureSize = 0,
                FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PageIndex = 0,
                IsLikelyNoise = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PageFigureNodeWithScore
        {
            Node = new()
            {
                Confidence = 0,
                FigureName = "figure_name",
                FigureSize = 0,
                FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PageIndex = 0,
                IsLikelyNoise = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Score = 0,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PageFigureNodeWithScore
        {
            Node = new()
            {
                Confidence = 0,
                FigureName = "figure_name",
                FigureSize = 0,
                FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PageIndex = 0,
                IsLikelyNoise = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Score = 0,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PageFigureNodeWithScore
        {
            Node = new()
            {
                Confidence = 0,
                FigureName = "figure_name",
                FigureSize = 0,
                FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                PageIndex = 0,
                IsLikelyNoise = true,
                Metadata = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            Score = 0,
            ClassName = "class_name",
        };

        PageFigureNodeWithScore copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Node
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        double expectedConfidence = 0;
        string expectedFigureName = "figure_name";
        long expectedFigureSize = 0;
        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedPageIndex = 0;
        bool expectedIsLikelyNoise = true;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedFigureName, model.FigureName);
        Assert.Equal(expectedFigureSize, model.FigureSize);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedPageIndex, model.PageIndex);
        Assert.Equal(expectedIsLikelyNoise, model.IsLikelyNoise);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Metadata[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Node
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Node>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Node
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Node>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedConfidence = 0;
        string expectedFigureName = "figure_name";
        long expectedFigureSize = 0;
        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedPageIndex = 0;
        bool expectedIsLikelyNoise = true;
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedFigureName, deserialized.FigureName);
        Assert.Equal(expectedFigureSize, deserialized.FigureSize);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedPageIndex, deserialized.PageIndex);
        Assert.Equal(expectedIsLikelyNoise, deserialized.IsLikelyNoise);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Metadata[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Node
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Node
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Null(model.IsLikelyNoise);
        Assert.False(model.RawData.ContainsKey("is_likely_noise"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Node
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Node
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            // Null should be interpreted as omitted for these properties
            IsLikelyNoise = null,
        };

        Assert.Null(model.IsLikelyNoise);
        Assert.False(model.RawData.ContainsKey("is_likely_noise"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Node
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            // Null should be interpreted as omitted for these properties
            IsLikelyNoise = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Node
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Node
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Node
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,

            Metadata = null,
        };

        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Node
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,

            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Node
        {
            Confidence = 0,
            FigureName = "figure_name",
            FigureSize = 0,
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PageIndex = 0,
            IsLikelyNoise = true,
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Node copied = new(model);

        Assert.Equal(model, copied);
    }
}
