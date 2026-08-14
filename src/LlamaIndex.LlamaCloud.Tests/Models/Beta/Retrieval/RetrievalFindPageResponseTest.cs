using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.Retrieval;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Retrieval;

public class RetrievalFindPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RetrievalFindPageResponse
        {
            Items = [new() { FileID = "file_id", FileName = "file_name" }],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        List<RetrievalFindResponse> expectedItems =
        [
            new() { FileID = "file_id", FileName = "file_name" },
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
        var model = new RetrievalFindPageResponse
        {
            Items = [new() { FileID = "file_id", FileName = "file_name" }],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrievalFindPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RetrievalFindPageResponse
        {
            Items = [new() { FileID = "file_id", FileName = "file_name" }],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetrievalFindPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<RetrievalFindResponse> expectedItems =
        [
            new() { FileID = "file_id", FileName = "file_name" },
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
        var model = new RetrievalFindPageResponse
        {
            Items = [new() { FileID = "file_id", FileName = "file_name" }],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RetrievalFindPageResponse
        {
            Items = [new() { FileID = "file_id", FileName = "file_name" }],
        };

        Assert.Null(model.NextPageToken);
        Assert.False(model.RawData.ContainsKey("next_page_token"));
        Assert.Null(model.TotalSize);
        Assert.False(model.RawData.ContainsKey("total_size"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RetrievalFindPageResponse
        {
            Items = [new() { FileID = "file_id", FileName = "file_name" }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RetrievalFindPageResponse
        {
            Items = [new() { FileID = "file_id", FileName = "file_name" }],

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
        var model = new RetrievalFindPageResponse
        {
            Items = [new() { FileID = "file_id", FileName = "file_name" }],

            NextPageToken = null,
            TotalSize = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RetrievalFindPageResponse
        {
            Items = [new() { FileID = "file_id", FileName = "file_name" }],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        RetrievalFindPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
