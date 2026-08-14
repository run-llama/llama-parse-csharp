using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Pipelines.Files;

namespace LlamaCloud.Tests.Models.Pipelines.Files;

public class FileGetStatusCountsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyManuallyUploaded = true,
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Dictionary<string, long> expectedCounts = new() { { "foo", 0 } };
        long expectedTotalCount = 0;
        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        bool expectedOnlyManuallyUploaded = true;
        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedCounts.Count, model.Counts.Count);
        foreach (var item in expectedCounts)
        {
            Assert.True(model.Counts.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Counts[item.Key]);
        }
        Assert.Equal(expectedTotalCount, model.TotalCount);
        Assert.Equal(expectedDataSourceID, model.DataSourceID);
        Assert.Equal(expectedOnlyManuallyUploaded, model.OnlyManuallyUploaded);
        Assert.Equal(expectedPipelineID, model.PipelineID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FileGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyManuallyUploaded = true,
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileGetStatusCountsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyManuallyUploaded = true,
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileGetStatusCountsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, long> expectedCounts = new() { { "foo", 0 } };
        long expectedTotalCount = 0;
        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        bool expectedOnlyManuallyUploaded = true;
        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedCounts.Count, deserialized.Counts.Count);
        foreach (var item in expectedCounts)
        {
            Assert.True(deserialized.Counts.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Counts[item.Key]);
        }
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
        Assert.Equal(expectedDataSourceID, deserialized.DataSourceID);
        Assert.Equal(expectedOnlyManuallyUploaded, deserialized.OnlyManuallyUploaded);
        Assert.Equal(expectedPipelineID, deserialized.PipelineID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FileGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyManuallyUploaded = true,
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(model.OnlyManuallyUploaded);
        Assert.False(model.RawData.ContainsKey("only_manually_uploaded"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FileGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            OnlyManuallyUploaded = null,
        };

        Assert.Null(model.OnlyManuallyUploaded);
        Assert.False(model.RawData.ContainsKey("only_manually_uploaded"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            // Null should be interpreted as omitted for these properties
            OnlyManuallyUploaded = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FileGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            TotalCount = 0,
            OnlyManuallyUploaded = true,
        };

        Assert.Null(model.DataSourceID);
        Assert.False(model.RawData.ContainsKey("data_source_id"));
        Assert.Null(model.PipelineID);
        Assert.False(model.RawData.ContainsKey("pipeline_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FileGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            TotalCount = 0,
            OnlyManuallyUploaded = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FileGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            TotalCount = 0,
            OnlyManuallyUploaded = true,

            DataSourceID = null,
            PipelineID = null,
        };

        Assert.Null(model.DataSourceID);
        Assert.True(model.RawData.ContainsKey("data_source_id"));
        Assert.Null(model.PipelineID);
        Assert.True(model.RawData.ContainsKey("pipeline_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FileGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            TotalCount = 0,
            OnlyManuallyUploaded = true,

            DataSourceID = null,
            PipelineID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FileGetStatusCountsResponse
        {
            Counts = new Dictionary<string, long>() { { "foo", 0 } },
            TotalCount = 0,
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            OnlyManuallyUploaded = true,
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        FileGetStatusCountsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
