using System;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.JobDataPoints;

namespace LlamaCloud.Tests.Models.JobDataPoints;

public class JobDataPointTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JobDataPoint
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
        };

        string expectedID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z");
        string expectedCustomTag = "premium";
        string expectedProjectID = "11111111-1111-1111-1111-111111111111";
        string expectedStatus = "completed";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z");
        string expectedErrorMessage = "Failed to process file.";
        StateTransitions expectedStateTransitions = new()
        {
            CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
            RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
            ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomTag, model.CustomTag);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedStateTransitions, model.StateTransitions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JobDataPoint
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JobDataPoint>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JobDataPoint
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JobDataPoint>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z");
        string expectedCustomTag = "premium";
        string expectedProjectID = "11111111-1111-1111-1111-111111111111";
        string expectedStatus = "completed";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z");
        string expectedErrorMessage = "Failed to process file.";
        StateTransitions expectedStateTransitions = new()
        {
            CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
            RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
            ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomTag, deserialized.CustomTag);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedStateTransitions, deserialized.StateTransitions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JobDataPoint
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JobDataPoint
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
            CustomTag = "premium",
            ProjectID = "11111111-1111-1111-1111-111111111111",
            Status = "completed",
            UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            ErrorMessage = "Failed to process file.",
        };

        Assert.Null(model.StateTransitions);
        Assert.False(model.RawData.ContainsKey("state_transitions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JobDataPoint
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
            CustomTag = "premium",
            ProjectID = "11111111-1111-1111-1111-111111111111",
            Status = "completed",
            UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            ErrorMessage = "Failed to process file.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JobDataPoint
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
            CustomTag = "premium",
            ProjectID = "11111111-1111-1111-1111-111111111111",
            Status = "completed",
            UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            ErrorMessage = "Failed to process file.",

            // Null should be interpreted as omitted for these properties
            StateTransitions = null,
        };

        Assert.Null(model.StateTransitions);
        Assert.False(model.RawData.ContainsKey("state_transitions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JobDataPoint
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
            CustomTag = "premium",
            ProjectID = "11111111-1111-1111-1111-111111111111",
            Status = "completed",
            UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            ErrorMessage = "Failed to process file.",

            // Null should be interpreted as omitted for these properties
            StateTransitions = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JobDataPoint
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
            CustomTag = "premium",
            ProjectID = "11111111-1111-1111-1111-111111111111",
            Status = "completed",
            UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            StateTransitions = new()
            {
                CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
                ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
            },
        };

        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new JobDataPoint
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
            CustomTag = "premium",
            ProjectID = "11111111-1111-1111-1111-111111111111",
            Status = "completed",
            UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            StateTransitions = new()
            {
                CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
                ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new JobDataPoint
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
            CustomTag = "premium",
            ProjectID = "11111111-1111-1111-1111-111111111111",
            Status = "completed",
            UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            StateTransitions = new()
            {
                CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
                ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
            },

            ErrorMessage = null,
        };

        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JobDataPoint
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            CreatedAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
            CustomTag = "premium",
            ProjectID = "11111111-1111-1111-1111-111111111111",
            Status = "completed",
            UpdatedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            StateTransitions = new()
            {
                CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
                PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
                RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
                ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
            },

            ErrorMessage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JobDataPoint
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
        };

        JobDataPoint copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StateTransitionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StateTransitions
        {
            CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
            RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
            ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
        };

        DateTimeOffset expectedCancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z");
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z");
        DateTimeOffset expectedFailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z");
        DateTimeOffset expectedPendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z");
        DateTimeOffset expectedRunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z");
        DateTimeOffset expectedThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z");

        Assert.Equal(expectedCancelledAt, model.CancelledAt);
        Assert.Equal(expectedCompletedAt, model.CompletedAt);
        Assert.Equal(expectedFailedAt, model.FailedAt);
        Assert.Equal(expectedPendingAt, model.PendingAt);
        Assert.Equal(expectedRunningAt, model.RunningAt);
        Assert.Equal(expectedThrottledAt, model.ThrottledAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StateTransitions
        {
            CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
            RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
            ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StateTransitions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StateTransitions
        {
            CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
            RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
            ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StateTransitions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z");
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z");
        DateTimeOffset expectedFailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z");
        DateTimeOffset expectedPendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z");
        DateTimeOffset expectedRunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z");
        DateTimeOffset expectedThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z");

        Assert.Equal(expectedCancelledAt, deserialized.CancelledAt);
        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
        Assert.Equal(expectedFailedAt, deserialized.FailedAt);
        Assert.Equal(expectedPendingAt, deserialized.PendingAt);
        Assert.Equal(expectedRunningAt, deserialized.RunningAt);
        Assert.Equal(expectedThrottledAt, deserialized.ThrottledAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StateTransitions
        {
            CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
            RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
            ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StateTransitions { };

        Assert.Null(model.CancelledAt);
        Assert.False(model.RawData.ContainsKey("cancelled_at"));
        Assert.Null(model.CompletedAt);
        Assert.False(model.RawData.ContainsKey("completed_at"));
        Assert.Null(model.FailedAt);
        Assert.False(model.RawData.ContainsKey("failed_at"));
        Assert.Null(model.PendingAt);
        Assert.False(model.RawData.ContainsKey("pending_at"));
        Assert.Null(model.RunningAt);
        Assert.False(model.RawData.ContainsKey("running_at"));
        Assert.Null(model.ThrottledAt);
        Assert.False(model.RawData.ContainsKey("throttled_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new StateTransitions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new StateTransitions
        {
            CancelledAt = null,
            CompletedAt = null,
            FailedAt = null,
            PendingAt = null,
            RunningAt = null,
            ThrottledAt = null,
        };

        Assert.Null(model.CancelledAt);
        Assert.True(model.RawData.ContainsKey("cancelled_at"));
        Assert.Null(model.CompletedAt);
        Assert.True(model.RawData.ContainsKey("completed_at"));
        Assert.Null(model.FailedAt);
        Assert.True(model.RawData.ContainsKey("failed_at"));
        Assert.Null(model.PendingAt);
        Assert.True(model.RawData.ContainsKey("pending_at"));
        Assert.Null(model.RunningAt);
        Assert.True(model.RawData.ContainsKey("running_at"));
        Assert.Null(model.ThrottledAt);
        Assert.True(model.RawData.ContainsKey("throttled_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StateTransitions
        {
            CancelledAt = null,
            CompletedAt = null,
            FailedAt = null,
            PendingAt = null,
            RunningAt = null,
            ThrottledAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StateTransitions
        {
            CancelledAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            CompletedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            FailedAt = DateTimeOffset.Parse("2026-04-29T18:01:00Z"),
            PendingAt = DateTimeOffset.Parse("2026-04-29T18:00:00Z"),
            RunningAt = DateTimeOffset.Parse("2026-04-29T18:00:05Z"),
            ThrottledAt = DateTimeOffset.Parse("2026-04-29T18:00:02Z"),
        };

        StateTransitions copied = new(model);

        Assert.Equal(model, copied);
    }
}
