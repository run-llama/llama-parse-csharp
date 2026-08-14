using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Classifier.Jobs;

namespace LlamaCloud.Tests.Models.Classifier.Jobs;

public class JobGetResultsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JobGetResultsResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Result = new()
                    {
                        Confidence = 0,
                        Reasoning = "reasoning",
                        Type = "type",
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        List<Item> expectedItems =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Result = new()
                {
                    Confidence = 0,
                    Reasoning = "reasoning",
                    Type = "type",
                },
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
        var model = new JobGetResultsResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Result = new()
                    {
                        Confidence = 0,
                        Reasoning = "reasoning",
                        Type = "type",
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JobGetResultsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JobGetResultsResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Result = new()
                    {
                        Confidence = 0,
                        Reasoning = "reasoning",
                        Type = "type",
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JobGetResultsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Item> expectedItems =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Result = new()
                {
                    Confidence = 0,
                    Reasoning = "reasoning",
                    Type = "type",
                },
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
        var model = new JobGetResultsResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Result = new()
                    {
                        Confidence = 0,
                        Reasoning = "reasoning",
                        Type = "type",
                    },
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
        var model = new JobGetResultsResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Result = new()
                    {
                        Confidence = 0,
                        Reasoning = "reasoning",
                        Type = "type",
                    },
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
        var model = new JobGetResultsResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Result = new()
                    {
                        Confidence = 0,
                        Reasoning = "reasoning",
                        Type = "type",
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new JobGetResultsResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Result = new()
                    {
                        Confidence = 0,
                        Reasoning = "reasoning",
                        Type = "type",
                    },
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
        var model = new JobGetResultsResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Result = new()
                    {
                        Confidence = 0,
                        Reasoning = "reasoning",
                        Type = "type",
                    },
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
        var model = new JobGetResultsResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Result = new()
                    {
                        Confidence = 0,
                        Reasoning = "reasoning",
                        Type = "type",
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        JobGetResultsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Result = new()
            {
                Confidence = 0,
                Reasoning = "reasoning",
                Type = "type",
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Result expectedResult = new()
        {
            Confidence = 0,
            Reasoning = "reasoning",
            Type = "type",
        };
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedClassifyJobID, model.ClassifyJobID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Result = new()
            {
                Confidence = 0,
                Reasoning = "reasoning",
                Type = "type",
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Result = new()
            {
                Confidence = 0,
                Reasoning = "reasoning",
                Type = "type",
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Result expectedResult = new()
        {
            Confidence = 0,
            Reasoning = "reasoning",
            Type = "type",
        };
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedClassifyJobID, deserialized.ClassifyJobID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Result = new()
            {
                Confidence = 0,
                Reasoning = "reasoning",
                Type = "type",
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.FileID);
        Assert.False(model.RawData.ContainsKey("file_id"));
        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Item
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            CreatedAt = null,
            FileID = null,
            Result = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.FileID);
        Assert.True(model.RawData.ContainsKey("file_id"));
        Assert.Null(model.Result);
        Assert.True(model.RawData.ContainsKey("result"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            CreatedAt = null,
            FileID = null,
            Result = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Item
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ClassifyJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Result = new()
            {
                Confidence = 0,
                Reasoning = "reasoning",
                Type = "type",
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Item copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            Confidence = 0,
            Reasoning = "reasoning",
            Type = "type",
        };

        double expectedConfidence = 0;
        string expectedReasoning = "reasoning";
        string expectedType = "type";

        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedReasoning, model.Reasoning);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Result
        {
            Confidence = 0,
            Reasoning = "reasoning",
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            Confidence = 0,
            Reasoning = "reasoning",
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedConfidence = 0;
        string expectedReasoning = "reasoning";
        string expectedType = "type";

        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedReasoning, deserialized.Reasoning);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Result
        {
            Confidence = 0,
            Reasoning = "reasoning",
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Result
        {
            Confidence = 0,
            Reasoning = "reasoning",
            Type = "type",
        };

        Result copied = new(model);

        Assert.Equal(model, copied);
    }
}
