using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.Retrieval;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Retrieval;

public class RetrievalGrepPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RetrievalGrepPageResponse
        {
            Items =
            [
                new()
                {
                    Content = "content",
                    EndChar = 0,
                    StartChar = 0,
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        List<RetrievalGrepResponse> expectedItems =
        [
            new()
            {
                Content = "content",
                EndChar = 0,
                StartChar = 0,
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
        var model = new RetrievalGrepPageResponse
        {
            Items =
            [
                new()
                {
                    Content = "content",
                    EndChar = 0,
                    StartChar = 0,
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrievalGrepPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RetrievalGrepPageResponse
        {
            Items =
            [
                new()
                {
                    Content = "content",
                    EndChar = 0,
                    StartChar = 0,
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrievalGrepPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<RetrievalGrepResponse> expectedItems =
        [
            new()
            {
                Content = "content",
                EndChar = 0,
                StartChar = 0,
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
        var model = new RetrievalGrepPageResponse
        {
            Items =
            [
                new()
                {
                    Content = "content",
                    EndChar = 0,
                    StartChar = 0,
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
        var model = new RetrievalGrepPageResponse
        {
            Items =
            [
                new()
                {
                    Content = "content",
                    EndChar = 0,
                    StartChar = 0,
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
        var model = new RetrievalGrepPageResponse
        {
            Items =
            [
                new()
                {
                    Content = "content",
                    EndChar = 0,
                    StartChar = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RetrievalGrepPageResponse
        {
            Items =
            [
                new()
                {
                    Content = "content",
                    EndChar = 0,
                    StartChar = 0,
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
        var model = new RetrievalGrepPageResponse
        {
            Items =
            [
                new()
                {
                    Content = "content",
                    EndChar = 0,
                    StartChar = 0,
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
        var model = new RetrievalGrepPageResponse
        {
            Items =
            [
                new()
                {
                    Content = "content",
                    EndChar = 0,
                    StartChar = 0,
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        RetrievalGrepPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
