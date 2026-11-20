using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using Review = LlamaCloud.Models.Extract.Review;

namespace LlamaCloud.Tests.Models.Extract.Review;

public class ExtractReviewTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Review::ExtractReview
        {
            ID = "id",
            ConfidenceThreshold = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DecidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DecidedBy = "decided_by",
            DecidedReason = "decided_reason",
            FieldActions = new Dictionary<string, Review::FieldActionsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Action = Review::Action.Clear,
                        ActorID = "actor_id",
                        At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Value = JsonSerializer.Deserialize<JsonElement>("{}"),
                    }
                },
            },
            FieldsInScope = ["string"],
            Flags =
            [
                new()
                {
                    Handled = true,
                    Path = "path",
                    Reason = Review::Reason.BelowThreshold,
                    Cell = new() { Row = 0, Column = "column" },
                    Confidence = 0,
                },
            ],
            JobID = "job_id",
            OpenFlags = ["string"],
            OriginalResult = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            RequiredFields = ["string"],
            RetainUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReviewedResult = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Revision = 0,
            SourceFileID = "source_file_id",
            Status = Review::Status.Approved,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        double expectedConfidenceThreshold = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedDecidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDecidedBy = "decided_by";
        string expectedDecidedReason = "decided_reason";
        Dictionary<string, Review::FieldActionsItem> expectedFieldActions = new()
        {
            {
                "foo",
                new()
                {
                    Action = Review::Action.Clear,
                    ActorID = "actor_id",
                    At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = JsonSerializer.Deserialize<JsonElement>("{}"),
                }
            },
        };
        List<string> expectedFieldsInScope = ["string"];
        List<Review::Flag> expectedFlags =
        [
            new()
            {
                Handled = true,
                Path = "path",
                Reason = Review::Reason.BelowThreshold,
                Cell = new() { Row = 0, Column = "column" },
                Confidence = 0,
            },
        ];
        string expectedJobID = "job_id";
        List<string> expectedOpenFlags = ["string"];
        Dictionary<string, JsonElement> expectedOriginalResult = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<string> expectedRequiredFields = ["string"];
        DateTimeOffset expectedRetainUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, JsonElement> expectedReviewedResult = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        long expectedRevision = 0;
        string expectedSourceFileID = "source_file_id";
        ApiEnum<string, Review::Status> expectedStatus = Review::Status.Approved;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConfidenceThreshold, model.ConfidenceThreshold);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDecidedAt, model.DecidedAt);
        Assert.Equal(expectedDecidedBy, model.DecidedBy);
        Assert.Equal(expectedDecidedReason, model.DecidedReason);
        Assert.Equal(expectedFieldActions.Count, model.FieldActions.Count);
        foreach (var item in expectedFieldActions)
        {
            Assert.True(model.FieldActions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.FieldActions[item.Key]);
        }
        Assert.Equal(expectedFieldsInScope.Count, model.FieldsInScope.Count);
        for (int i = 0; i < expectedFieldsInScope.Count; i++)
        {
            Assert.Equal(expectedFieldsInScope[i], model.FieldsInScope[i]);
        }
        Assert.Equal(expectedFlags.Count, model.Flags.Count);
        for (int i = 0; i < expectedFlags.Count; i++)
        {
            Assert.Equal(expectedFlags[i], model.Flags[i]);
        }
        Assert.Equal(expectedJobID, model.JobID);
        Assert.Equal(expectedOpenFlags.Count, model.OpenFlags.Count);
        for (int i = 0; i < expectedOpenFlags.Count; i++)
        {
            Assert.Equal(expectedOpenFlags[i], model.OpenFlags[i]);
        }
        Assert.NotNull(model.OriginalResult);
        Assert.Equal(expectedOriginalResult.Count, model.OriginalResult.Count);
        foreach (var item in expectedOriginalResult)
        {
            Assert.True(model.OriginalResult.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.OriginalResult[item.Key]));
        }
        Assert.Equal(expectedRequiredFields.Count, model.RequiredFields.Count);
        for (int i = 0; i < expectedRequiredFields.Count; i++)
        {
            Assert.Equal(expectedRequiredFields[i], model.RequiredFields[i]);
        }
        Assert.Equal(expectedRetainUntil, model.RetainUntil);
        Assert.Equal(expectedReviewedResult.Count, model.ReviewedResult.Count);
        foreach (var item in expectedReviewedResult)
        {
            Assert.True(model.ReviewedResult.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.ReviewedResult[item.Key]));
        }
        Assert.Equal(expectedRevision, model.Revision);
        Assert.Equal(expectedSourceFileID, model.SourceFileID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Review::ExtractReview
        {
            ID = "id",
            ConfidenceThreshold = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DecidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DecidedBy = "decided_by",
            DecidedReason = "decided_reason",
            FieldActions = new Dictionary<string, Review::FieldActionsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Action = Review::Action.Clear,
                        ActorID = "actor_id",
                        At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Value = JsonSerializer.Deserialize<JsonElement>("{}"),
                    }
                },
            },
            FieldsInScope = ["string"],
            Flags =
            [
                new()
                {
                    Handled = true,
                    Path = "path",
                    Reason = Review::Reason.BelowThreshold,
                    Cell = new() { Row = 0, Column = "column" },
                    Confidence = 0,
                },
            ],
            JobID = "job_id",
            OpenFlags = ["string"],
            OriginalResult = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            RequiredFields = ["string"],
            RetainUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReviewedResult = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Revision = 0,
            SourceFileID = "source_file_id",
            Status = Review::Status.Approved,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Review::ExtractReview>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Review::ExtractReview
        {
            ID = "id",
            ConfidenceThreshold = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DecidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DecidedBy = "decided_by",
            DecidedReason = "decided_reason",
            FieldActions = new Dictionary<string, Review::FieldActionsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Action = Review::Action.Clear,
                        ActorID = "actor_id",
                        At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Value = JsonSerializer.Deserialize<JsonElement>("{}"),
                    }
                },
            },
            FieldsInScope = ["string"],
            Flags =
            [
                new()
                {
                    Handled = true,
                    Path = "path",
                    Reason = Review::Reason.BelowThreshold,
                    Cell = new() { Row = 0, Column = "column" },
                    Confidence = 0,
                },
            ],
            JobID = "job_id",
            OpenFlags = ["string"],
            OriginalResult = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            RequiredFields = ["string"],
            RetainUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReviewedResult = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Revision = 0,
            SourceFileID = "source_file_id",
            Status = Review::Status.Approved,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Review::ExtractReview>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedConfidenceThreshold = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedDecidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDecidedBy = "decided_by";
        string expectedDecidedReason = "decided_reason";
        Dictionary<string, Review::FieldActionsItem> expectedFieldActions = new()
        {
            {
                "foo",
                new()
                {
                    Action = Review::Action.Clear,
                    ActorID = "actor_id",
                    At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Value = JsonSerializer.Deserialize<JsonElement>("{}"),
                }
            },
        };
        List<string> expectedFieldsInScope = ["string"];
        List<Review::Flag> expectedFlags =
        [
            new()
            {
                Handled = true,
                Path = "path",
                Reason = Review::Reason.BelowThreshold,
                Cell = new() { Row = 0, Column = "column" },
                Confidence = 0,
            },
        ];
        string expectedJobID = "job_id";
        List<string> expectedOpenFlags = ["string"];
        Dictionary<string, JsonElement> expectedOriginalResult = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<string> expectedRequiredFields = ["string"];
        DateTimeOffset expectedRetainUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, JsonElement> expectedReviewedResult = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        long expectedRevision = 0;
        string expectedSourceFileID = "source_file_id";
        ApiEnum<string, Review::Status> expectedStatus = Review::Status.Approved;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConfidenceThreshold, deserialized.ConfidenceThreshold);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDecidedAt, deserialized.DecidedAt);
        Assert.Equal(expectedDecidedBy, deserialized.DecidedBy);
        Assert.Equal(expectedDecidedReason, deserialized.DecidedReason);
        Assert.Equal(expectedFieldActions.Count, deserialized.FieldActions.Count);
        foreach (var item in expectedFieldActions)
        {
            Assert.True(deserialized.FieldActions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.FieldActions[item.Key]);
        }
        Assert.Equal(expectedFieldsInScope.Count, deserialized.FieldsInScope.Count);
        for (int i = 0; i < expectedFieldsInScope.Count; i++)
        {
            Assert.Equal(expectedFieldsInScope[i], deserialized.FieldsInScope[i]);
        }
        Assert.Equal(expectedFlags.Count, deserialized.Flags.Count);
        for (int i = 0; i < expectedFlags.Count; i++)
        {
            Assert.Equal(expectedFlags[i], deserialized.Flags[i]);
        }
        Assert.Equal(expectedJobID, deserialized.JobID);
        Assert.Equal(expectedOpenFlags.Count, deserialized.OpenFlags.Count);
        for (int i = 0; i < expectedOpenFlags.Count; i++)
        {
            Assert.Equal(expectedOpenFlags[i], deserialized.OpenFlags[i]);
        }
        Assert.NotNull(deserialized.OriginalResult);
        Assert.Equal(expectedOriginalResult.Count, deserialized.OriginalResult.Count);
        foreach (var item in expectedOriginalResult)
        {
            Assert.True(deserialized.OriginalResult.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.OriginalResult[item.Key]));
        }
        Assert.Equal(expectedRequiredFields.Count, deserialized.RequiredFields.Count);
        for (int i = 0; i < expectedRequiredFields.Count; i++)
        {
            Assert.Equal(expectedRequiredFields[i], deserialized.RequiredFields[i]);
        }
        Assert.Equal(expectedRetainUntil, deserialized.RetainUntil);
        Assert.Equal(expectedReviewedResult.Count, deserialized.ReviewedResult.Count);
        foreach (var item in expectedReviewedResult)
        {
            Assert.True(deserialized.ReviewedResult.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.ReviewedResult[item.Key]));
        }
        Assert.Equal(expectedRevision, deserialized.Revision);
        Assert.Equal(expectedSourceFileID, deserialized.SourceFileID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Review::ExtractReview
        {
            ID = "id",
            ConfidenceThreshold = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DecidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DecidedBy = "decided_by",
            DecidedReason = "decided_reason",
            FieldActions = new Dictionary<string, Review::FieldActionsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Action = Review::Action.Clear,
                        ActorID = "actor_id",
                        At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Value = JsonSerializer.Deserialize<JsonElement>("{}"),
                    }
                },
            },
            FieldsInScope = ["string"],
            Flags =
            [
                new()
                {
                    Handled = true,
                    Path = "path",
                    Reason = Review::Reason.BelowThreshold,
                    Cell = new() { Row = 0, Column = "column" },
                    Confidence = 0,
                },
            ],
            JobID = "job_id",
            OpenFlags = ["string"],
            OriginalResult = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            RequiredFields = ["string"],
            RetainUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReviewedResult = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Revision = 0,
            SourceFileID = "source_file_id",
            Status = Review::Status.Approved,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Review::ExtractReview
        {
            ID = "id",
            ConfidenceThreshold = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DecidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DecidedBy = "decided_by",
            DecidedReason = "decided_reason",
            FieldActions = new Dictionary<string, Review::FieldActionsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Action = Review::Action.Clear,
                        ActorID = "actor_id",
                        At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Value = JsonSerializer.Deserialize<JsonElement>("{}"),
                    }
                },
            },
            FieldsInScope = ["string"],
            Flags =
            [
                new()
                {
                    Handled = true,
                    Path = "path",
                    Reason = Review::Reason.BelowThreshold,
                    Cell = new() { Row = 0, Column = "column" },
                    Confidence = 0,
                },
            ],
            JobID = "job_id",
            OpenFlags = ["string"],
            OriginalResult = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            RequiredFields = ["string"],
            RetainUntil = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReviewedResult = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Revision = 0,
            SourceFileID = "source_file_id",
            Status = Review::Status.Approved,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Review::ExtractReview copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FieldActionsItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Review::FieldActionsItem
        {
            Action = Review::Action.Clear,
            ActorID = "actor_id",
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        ApiEnum<string, Review::Action> expectedAction = Review::Action.Clear;
        string expectedActorID = "actor_id";
        DateTimeOffset expectedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedValue = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedActorID, model.ActorID);
        Assert.Equal(expectedAt, model.At);
        Assert.NotNull(model.Value);
        Assert.True(JsonElement.DeepEquals(expectedValue, model.Value.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Review::FieldActionsItem
        {
            Action = Review::Action.Clear,
            ActorID = "actor_id",
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Review::FieldActionsItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Review::FieldActionsItem
        {
            Action = Review::Action.Clear,
            ActorID = "actor_id",
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Review::FieldActionsItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Review::Action> expectedAction = Review::Action.Clear;
        string expectedActorID = "actor_id";
        DateTimeOffset expectedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedValue = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedActorID, deserialized.ActorID);
        Assert.Equal(expectedAt, deserialized.At);
        Assert.NotNull(deserialized.Value);
        Assert.True(JsonElement.DeepEquals(expectedValue, deserialized.Value.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Review::FieldActionsItem
        {
            Action = Review::Action.Clear,
            ActorID = "actor_id",
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Review::FieldActionsItem
        {
            Action = Review::Action.Clear,
            ActorID = "actor_id",
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Review::FieldActionsItem
        {
            Action = Review::Action.Clear,
            ActorID = "actor_id",
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Review::FieldActionsItem
        {
            Action = Review::Action.Clear,
            ActorID = "actor_id",
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Value = null,
        };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Review::FieldActionsItem
        {
            Action = Review::Action.Clear,
            ActorID = "actor_id",
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Review::FieldActionsItem
        {
            Action = Review::Action.Clear,
            ActorID = "actor_id",
            At = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Value = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Review::FieldActionsItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ActionTest : TestBase
{
    [Theory]
    [InlineData(Review::Action.Clear)]
    [InlineData(Review::Action.Confirm)]
    [InlineData(Review::Action.Correct)]
    public void Validation_Works(Review::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Review::Action> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Review::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Review::Action.Clear)]
    [InlineData(Review::Action.Confirm)]
    [InlineData(Review::Action.Correct)]
    public void SerializationRoundtrip_Works(Review::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Review::Action> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Review::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Review::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Review::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FlagTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Review::Flag
        {
            Handled = true,
            Path = "path",
            Reason = Review::Reason.BelowThreshold,
            Cell = new() { Row = 0, Column = "column" },
            Confidence = 0,
        };

        bool expectedHandled = true;
        string expectedPath = "path";
        ApiEnum<string, Review::Reason> expectedReason = Review::Reason.BelowThreshold;
        Review::Cell expectedCell = new() { Row = 0, Column = "column" };
        double expectedConfidence = 0;

        Assert.Equal(expectedHandled, model.Handled);
        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedCell, model.Cell);
        Assert.Equal(expectedConfidence, model.Confidence);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Review::Flag
        {
            Handled = true,
            Path = "path",
            Reason = Review::Reason.BelowThreshold,
            Cell = new() { Row = 0, Column = "column" },
            Confidence = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Review::Flag>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Review::Flag
        {
            Handled = true,
            Path = "path",
            Reason = Review::Reason.BelowThreshold,
            Cell = new() { Row = 0, Column = "column" },
            Confidence = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Review::Flag>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHandled = true;
        string expectedPath = "path";
        ApiEnum<string, Review::Reason> expectedReason = Review::Reason.BelowThreshold;
        Review::Cell expectedCell = new() { Row = 0, Column = "column" };
        double expectedConfidence = 0;

        Assert.Equal(expectedHandled, deserialized.Handled);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedCell, deserialized.Cell);
        Assert.Equal(expectedConfidence, deserialized.Confidence);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Review::Flag
        {
            Handled = true,
            Path = "path",
            Reason = Review::Reason.BelowThreshold,
            Cell = new() { Row = 0, Column = "column" },
            Confidence = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Review::Flag
        {
            Handled = true,
            Path = "path",
            Reason = Review::Reason.BelowThreshold,
        };

        Assert.Null(model.Cell);
        Assert.False(model.RawData.ContainsKey("cell"));
        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Review::Flag
        {
            Handled = true,
            Path = "path",
            Reason = Review::Reason.BelowThreshold,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Review::Flag
        {
            Handled = true,
            Path = "path",
            Reason = Review::Reason.BelowThreshold,

            Cell = null,
            Confidence = null,
        };

        Assert.Null(model.Cell);
        Assert.True(model.RawData.ContainsKey("cell"));
        Assert.Null(model.Confidence);
        Assert.True(model.RawData.ContainsKey("confidence"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Review::Flag
        {
            Handled = true,
            Path = "path",
            Reason = Review::Reason.BelowThreshold,

            Cell = null,
            Confidence = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Review::Flag
        {
            Handled = true,
            Path = "path",
            Reason = Review::Reason.BelowThreshold,
            Cell = new() { Row = 0, Column = "column" },
            Confidence = 0,
        };

        Review::Flag copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Review::Reason.BelowThreshold)]
    [InlineData(Review::Reason.RequiredEmpty)]
    public void Validation_Works(Review::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Review::Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Review::Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Review::Reason.BelowThreshold)]
    [InlineData(Review::Reason.RequiredEmpty)]
    public void SerializationRoundtrip_Works(Review::Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Review::Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Review::Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Review::Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Review::Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CellTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Review::Cell { Row = 0, Column = "column" };

        long expectedRow = 0;
        string expectedColumn = "column";

        Assert.Equal(expectedRow, model.Row);
        Assert.Equal(expectedColumn, model.Column);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Review::Cell { Row = 0, Column = "column" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Review::Cell>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Review::Cell { Row = 0, Column = "column" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Review::Cell>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedRow = 0;
        string expectedColumn = "column";

        Assert.Equal(expectedRow, deserialized.Row);
        Assert.Equal(expectedColumn, deserialized.Column);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Review::Cell { Row = 0, Column = "column" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Review::Cell { Row = 0 };

        Assert.Null(model.Column);
        Assert.False(model.RawData.ContainsKey("column"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Review::Cell { Row = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Review::Cell
        {
            Row = 0,

            Column = null,
        };

        Assert.Null(model.Column);
        Assert.True(model.RawData.ContainsKey("column"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Review::Cell
        {
            Row = 0,

            Column = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Review::Cell { Row = 0, Column = "column" };

        Review::Cell copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Review::Status.Approved)]
    [InlineData(Review::Status.Pending)]
    [InlineData(Review::Status.Rejected)]
    public void Validation_Works(Review::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Review::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Review::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Review::Status.Approved)]
    [InlineData(Review::Status.Pending)]
    [InlineData(Review::Status.Rejected)]
    public void SerializationRoundtrip_Works(Review::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Review::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Review::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Review::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Review::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
