using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Tests.Models.Pipelines;

public class PipelineListPaginatedPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PipelineListPaginatedPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
                    ProjectID = "project_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = PipelineListPaginatedResponseStatus.Created,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        List<PipelineListPaginatedResponse> expectedItems =
        [
            new()
            {
                ID = "id",
                Name = "name",
                PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
                ProjectID = "project_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = PipelineListPaginatedResponseStatus.Created,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new PipelineListPaginatedPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
                    ProjectID = "project_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = PipelineListPaginatedResponseStatus.Created,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineListPaginatedPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PipelineListPaginatedPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
                    ProjectID = "project_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = PipelineListPaginatedResponseStatus.Created,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineListPaginatedPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<PipelineListPaginatedResponse> expectedItems =
        [
            new()
            {
                ID = "id",
                Name = "name",
                PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
                ProjectID = "project_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = PipelineListPaginatedResponseStatus.Created,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new PipelineListPaginatedPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
                    ProjectID = "project_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = PipelineListPaginatedResponseStatus.Created,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new PipelineListPaginatedPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
                    ProjectID = "project_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = PipelineListPaginatedResponseStatus.Created,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new PipelineListPaginatedPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
                    ProjectID = "project_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = PipelineListPaginatedResponseStatus.Created,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PipelineListPaginatedPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
                    ProjectID = "project_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = PipelineListPaginatedResponseStatus.Created,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new PipelineListPaginatedPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
                    ProjectID = "project_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = PipelineListPaginatedResponseStatus.Created,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new PipelineListPaginatedPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
                    ProjectID = "project_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = PipelineListPaginatedResponseStatus.Created,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        PipelineListPaginatedPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
