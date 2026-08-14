using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Pipelines.DataSources;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines.DataSources;

public class DataSourceUpdateDataSourcesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DataSourceUpdateDataSourcesParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Body =
            [
                new() { DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e", SyncInterval = 0 },
            ],
        };

        string expectedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<Body> expectedBody =
        [
            new() { DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e", SyncInterval = 0 },
        ];

        Assert.Equal(expectedPipelineID, parameters.PipelineID);
        Assert.Equal(expectedBody.Count, parameters.Body.Count);
        for (int i = 0; i < expectedBody.Count; i++)
        {
            Assert.Equal(expectedBody[i], parameters.Body[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        DataSourceUpdateDataSourcesParams parameters = new()
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Body =
            [
                new() { DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e", SyncInterval = 0 },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/pipelines/182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e/data-sources"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DataSourceUpdateDataSourcesParams
        {
            PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Body =
            [
                new() { DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e", SyncInterval = 0 },
            ],
        };

        DataSourceUpdateDataSourcesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BodyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Body
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SyncInterval = 0,
        };

        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        double expectedSyncInterval = 0;

        Assert.Equal(expectedDataSourceID, model.DataSourceID);
        Assert.Equal(expectedSyncInterval, model.SyncInterval);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Body
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SyncInterval = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Body
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SyncInterval = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Body>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedDataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        double expectedSyncInterval = 0;

        Assert.Equal(expectedDataSourceID, deserialized.DataSourceID);
        Assert.Equal(expectedSyncInterval, deserialized.SyncInterval);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Body
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SyncInterval = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Body { DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        Assert.Null(model.SyncInterval);
        Assert.False(model.RawData.ContainsKey("sync_interval"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Body { DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Body
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            SyncInterval = null,
        };

        Assert.Null(model.SyncInterval);
        Assert.True(model.RawData.ContainsKey("sync_interval"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Body
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            SyncInterval = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Body
        {
            DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SyncInterval = 0,
        };

        Body copied = new(model);

        Assert.Equal(model, copied);
    }
}
