using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.JobDataPoints;

namespace LlamaCloud.Tests.Models.JobDataPoints;

public class JobDataPointListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JobDataPointListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                    CustomTag = "premium",
                    ProjectID = "11111111-1111-1111-1111-111111111111",
                    Status = "completed",
                    UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                    ErrorMessage = "Failed to process file.",
                    StateTransitions = new()
                    {
                        CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                        RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
                        ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
                    },
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        List<JobDataPoint> expectedItems =
        [
            new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                CustomTag = "premium",
                ProjectID = "11111111-1111-1111-1111-111111111111",
                Status = "completed",
                UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                ErrorMessage = "Failed to process file.",
                StateTransitions = new()
                {
                    CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                    CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                    FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                    PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                    RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
                    ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
                },
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
        var model = new JobDataPointListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                    CustomTag = "premium",
                    ProjectID = "11111111-1111-1111-1111-111111111111",
                    Status = "completed",
                    UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                    ErrorMessage = "Failed to process file.",
                    StateTransitions = new()
                    {
                        CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                        RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
                        ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
                    },
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JobDataPointListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JobDataPointListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                    CustomTag = "premium",
                    ProjectID = "11111111-1111-1111-1111-111111111111",
                    Status = "completed",
                    UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                    ErrorMessage = "Failed to process file.",
                    StateTransitions = new()
                    {
                        CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                        RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
                        ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
                    },
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JobDataPointListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<JobDataPoint> expectedItems =
        [
            new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                CustomTag = "premium",
                ProjectID = "11111111-1111-1111-1111-111111111111",
                Status = "completed",
                UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                ErrorMessage = "Failed to process file.",
                StateTransitions = new()
                {
                    CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                    CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                    FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                    PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                    RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
                    ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
                },
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
        var model = new JobDataPointListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                    CustomTag = "premium",
                    ProjectID = "11111111-1111-1111-1111-111111111111",
                    Status = "completed",
                    UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                    ErrorMessage = "Failed to process file.",
                    StateTransitions = new()
                    {
                        CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                        RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
                        ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
                    },
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
        var model = new JobDataPointListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                    CustomTag = "premium",
                    ProjectID = "11111111-1111-1111-1111-111111111111",
                    Status = "completed",
                    UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                    ErrorMessage = "Failed to process file.",
                    StateTransitions = new()
                    {
                        CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                        RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
                        ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
                    },
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
        var model = new JobDataPointListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                    CustomTag = "premium",
                    ProjectID = "11111111-1111-1111-1111-111111111111",
                    Status = "completed",
                    UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                    ErrorMessage = "Failed to process file.",
                    StateTransitions = new()
                    {
                        CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                        RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
                        ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new JobDataPointListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                    CustomTag = "premium",
                    ProjectID = "11111111-1111-1111-1111-111111111111",
                    Status = "completed",
                    UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                    ErrorMessage = "Failed to process file.",
                    StateTransitions = new()
                    {
                        CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                        RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
                        ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
                    },
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
        var model = new JobDataPointListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                    CustomTag = "premium",
                    ProjectID = "11111111-1111-1111-1111-111111111111",
                    Status = "completed",
                    UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                    ErrorMessage = "Failed to process file.",
                    StateTransitions = new()
                    {
                        CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                        RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
                        ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
                    },
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
        var model = new JobDataPointListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                    CustomTag = "premium",
                    ProjectID = "11111111-1111-1111-1111-111111111111",
                    Status = "completed",
                    UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                    ErrorMessage = "Failed to process file.",
                    StateTransitions = new()
                    {
                        CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                        PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                        RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
                        ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
                    },
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        JobDataPointListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
