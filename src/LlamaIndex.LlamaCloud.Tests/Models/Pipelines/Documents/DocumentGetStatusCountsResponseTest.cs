using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines.Documents;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines.Documents;

public class DocumentGetStatusCountsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DocumentGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyDirectUpload = true,
        };

        Dictionary<string, long> expectedCounts = new() { { "foo", 0 } };
        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedTotalCount = 0;
        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        bool expectedOnlyDirectUpload = true;

        Assert.Equal(expectedCounts.Count, model.Counts.Count);
        foreach (var item in expectedCounts)
        {
            Assert.True(model.Counts.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Counts[item.Key]);
        }
        Assert.Equal(expectedPipelineID, model.PipelineID);
        Assert.Equal(expectedTotalCount, model.TotalCount);
        Assert.Equal(expectedDataSourceID, model.DataSourceID);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedOnlyDirectUpload, model.OnlyDirectUpload);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DocumentGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyDirectUpload = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocumentGetStatusCountsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DocumentGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyDirectUpload = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DocumentGetStatusCountsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, long> expectedCounts = new() { { "foo", 0 } };
        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedTotalCount = 0;
        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        bool expectedOnlyDirectUpload = true;

        Assert.Equal(expectedCounts.Count, deserialized.Counts.Count);
        foreach (var item in expectedCounts)
        {
            Assert.True(deserialized.Counts.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Counts[item.Key]);
        }
        Assert.Equal(expectedPipelineID, deserialized.PipelineID);
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
        Assert.Equal(expectedDataSourceID, deserialized.DataSourceID);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedOnlyDirectUpload, deserialized.OnlyDirectUpload);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DocumentGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyDirectUpload = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DocumentGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(model.OnlyDirectUpload);
        Assert.False(model.RawData.ContainsKey("only_direct_upload"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DocumentGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DocumentGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            OnlyDirectUpload = null,
        };

        Assert.Null(model.OnlyDirectUpload);
        Assert.False(model.RawData.ContainsKey("only_direct_upload"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DocumentGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            OnlyDirectUpload = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DocumentGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TotalCount = 0,
            OnlyDirectUpload = true,
        };

        Assert.Null(model.DataSourceID);
        Assert.False(model.RawData.ContainsKey("data_source_id"));
        Assert.Null(model.FileID);
        Assert.False(model.RawData.ContainsKey("file_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DocumentGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TotalCount = 0,
            OnlyDirectUpload = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DocumentGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TotalCount = 0,
            OnlyDirectUpload = true,

            DataSourceID = null,
            FileID = null,
        };

        Assert.Null(model.DataSourceID);
        Assert.True(model.RawData.ContainsKey("data_source_id"));
        Assert.Null(model.FileID);
        Assert.True(model.RawData.ContainsKey("file_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DocumentGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TotalCount = 0,
            OnlyDirectUpload = true,

            DataSourceID = null,
            FileID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DocumentGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyDirectUpload = true,
        };

        DocumentGetStatusCountsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
