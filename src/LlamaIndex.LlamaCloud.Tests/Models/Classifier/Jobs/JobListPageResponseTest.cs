using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Classifier.Jobs;
using LlamaIndex.LlamaCloud.Models.Parsing;

namespace LlamaIndex.LlamaCloud.Tests.Models.Classifier.Jobs;

public class JobListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JobListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Rules =
                    [
                        new()
                        {
                            Description = "contains invoice number, line items, and total amount",
                            Type = "invoice",
                        },
                    ],
                    Status = StatusEnum.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    JobRecordID = "job_record_id",
                    Mode = ClassifyJobMode.Fast,
                    ParsingConfiguration = new()
                    {
                        Lang = ParsingLanguages.Abq,
                        MaxPages = 0,
                        TargetPages = [0],
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        List<ClassifyJob> expectedItems =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Status = StatusEnum.Cancelled,
                UserID = "user_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "error_message",
                JobRecordID = "job_record_id",
                Mode = ClassifyJobMode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = ParsingLanguages.Abq,
                    MaxPages = 0,
                    TargetPages = [0],
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
        var model = new JobListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Rules =
                    [
                        new()
                        {
                            Description = "contains invoice number, line items, and total amount",
                            Type = "invoice",
                        },
                    ],
                    Status = StatusEnum.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    JobRecordID = "job_record_id",
                    Mode = ClassifyJobMode.Fast,
                    ParsingConfiguration = new()
                    {
                        Lang = ParsingLanguages.Abq,
                        MaxPages = 0,
                        TargetPages = [0],
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JobListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JobListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Rules =
                    [
                        new()
                        {
                            Description = "contains invoice number, line items, and total amount",
                            Type = "invoice",
                        },
                    ],
                    Status = StatusEnum.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    JobRecordID = "job_record_id",
                    Mode = ClassifyJobMode.Fast,
                    ParsingConfiguration = new()
                    {
                        Lang = ParsingLanguages.Abq,
                        MaxPages = 0,
                        TargetPages = [0],
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JobListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ClassifyJob> expectedItems =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Status = StatusEnum.Cancelled,
                UserID = "user_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "error_message",
                JobRecordID = "job_record_id",
                Mode = ClassifyJobMode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = ParsingLanguages.Abq,
                    MaxPages = 0,
                    TargetPages = [0],
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
        var model = new JobListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Rules =
                    [
                        new()
                        {
                            Description = "contains invoice number, line items, and total amount",
                            Type = "invoice",
                        },
                    ],
                    Status = StatusEnum.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    JobRecordID = "job_record_id",
                    Mode = ClassifyJobMode.Fast,
                    ParsingConfiguration = new()
                    {
                        Lang = ParsingLanguages.Abq,
                        MaxPages = 0,
                        TargetPages = [0],
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
        var model = new JobListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Rules =
                    [
                        new()
                        {
                            Description = "contains invoice number, line items, and total amount",
                            Type = "invoice",
                        },
                    ],
                    Status = StatusEnum.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    JobRecordID = "job_record_id",
                    Mode = ClassifyJobMode.Fast,
                    ParsingConfiguration = new()
                    {
                        Lang = ParsingLanguages.Abq,
                        MaxPages = 0,
                        TargetPages = [0],
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
        var model = new JobListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Rules =
                    [
                        new()
                        {
                            Description = "contains invoice number, line items, and total amount",
                            Type = "invoice",
                        },
                    ],
                    Status = StatusEnum.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    JobRecordID = "job_record_id",
                    Mode = ClassifyJobMode.Fast,
                    ParsingConfiguration = new()
                    {
                        Lang = ParsingLanguages.Abq,
                        MaxPages = 0,
                        TargetPages = [0],
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
        var model = new JobListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Rules =
                    [
                        new()
                        {
                            Description = "contains invoice number, line items, and total amount",
                            Type = "invoice",
                        },
                    ],
                    Status = StatusEnum.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    JobRecordID = "job_record_id",
                    Mode = ClassifyJobMode.Fast,
                    ParsingConfiguration = new()
                    {
                        Lang = ParsingLanguages.Abq,
                        MaxPages = 0,
                        TargetPages = [0],
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
        var model = new JobListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Rules =
                    [
                        new()
                        {
                            Description = "contains invoice number, line items, and total amount",
                            Type = "invoice",
                        },
                    ],
                    Status = StatusEnum.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    JobRecordID = "job_record_id",
                    Mode = ClassifyJobMode.Fast,
                    ParsingConfiguration = new()
                    {
                        Lang = ParsingLanguages.Abq,
                        MaxPages = 0,
                        TargetPages = [0],
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
        var model = new JobListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Rules =
                    [
                        new()
                        {
                            Description = "contains invoice number, line items, and total amount",
                            Type = "invoice",
                        },
                    ],
                    Status = StatusEnum.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    JobRecordID = "job_record_id",
                    Mode = ClassifyJobMode.Fast,
                    ParsingConfiguration = new()
                    {
                        Lang = ParsingLanguages.Abq,
                        MaxPages = 0,
                        TargetPages = [0],
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        JobListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
