using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Extract.Review;

namespace LlamaCloud.Tests.Models.Extract.Review;

public class ReviewListEventsPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReviewListEventsPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    ActorID = "actor_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = Kind.Approved,
                    Detail = new ExtractReviewCreatedDetail()
                    {
                        ConfidenceThreshold = 0,
                        FieldsInScope = ["string"],
                        Origin = Origin.Api,
                        RequiredFields = ["string"],
                    },
                    Path = "path",
                    ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        List<ExtractReviewEvent> expectedItems =
        [
            new()
            {
                ID = "id",
                ActorID = "actor_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Kind = Kind.Approved,
                Detail = new ExtractReviewCreatedDetail()
                {
                    ConfidenceThreshold = 0,
                    FieldsInScope = ["string"],
                    Origin = Origin.Api,
                    RequiredFields = ["string"],
                },
                Path = "path",
                ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
                ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new ReviewListEventsPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    ActorID = "actor_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = Kind.Approved,
                    Detail = new ExtractReviewCreatedDetail()
                    {
                        ConfidenceThreshold = 0,
                        FieldsInScope = ["string"],
                        Origin = Origin.Api,
                        RequiredFields = ["string"],
                    },
                    Path = "path",
                    ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReviewListEventsPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReviewListEventsPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    ActorID = "actor_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = Kind.Approved,
                    Detail = new ExtractReviewCreatedDetail()
                    {
                        ConfidenceThreshold = 0,
                        FieldsInScope = ["string"],
                        Origin = Origin.Api,
                        RequiredFields = ["string"],
                    },
                    Path = "path",
                    ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReviewListEventsPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ExtractReviewEvent> expectedItems =
        [
            new()
            {
                ID = "id",
                ActorID = "actor_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Kind = Kind.Approved,
                Detail = new ExtractReviewCreatedDetail()
                {
                    ConfidenceThreshold = 0,
                    FieldsInScope = ["string"],
                    Origin = Origin.Api,
                    RequiredFields = ["string"],
                },
                Path = "path",
                ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
                ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new ReviewListEventsPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    ActorID = "actor_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = Kind.Approved,
                    Detail = new ExtractReviewCreatedDetail()
                    {
                        ConfidenceThreshold = 0,
                        FieldsInScope = ["string"],
                        Origin = Origin.Api,
                        RequiredFields = ["string"],
                    },
                    Path = "path",
                    ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new ReviewListEventsPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    ActorID = "actor_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = Kind.Approved,
                    Detail = new ExtractReviewCreatedDetail()
                    {
                        ConfidenceThreshold = 0,
                        FieldsInScope = ["string"],
                        Origin = Origin.Api,
                        RequiredFields = ["string"],
                    },
                    Path = "path",
                    ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new ReviewListEventsPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    ActorID = "actor_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = Kind.Approved,
                    Detail = new ExtractReviewCreatedDetail()
                    {
                        ConfidenceThreshold = 0,
                        FieldsInScope = ["string"],
                        Origin = Origin.Api,
                        RequiredFields = ["string"],
                    },
                    Path = "path",
                    ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReviewListEventsPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    ActorID = "actor_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = Kind.Approved,
                    Detail = new ExtractReviewCreatedDetail()
                    {
                        ConfidenceThreshold = 0,
                        FieldsInScope = ["string"],
                        Origin = Origin.Api,
                        RequiredFields = ["string"],
                    },
                    Path = "path",
                    ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new ReviewListEventsPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    ActorID = "actor_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = Kind.Approved,
                    Detail = new ExtractReviewCreatedDetail()
                    {
                        ConfidenceThreshold = 0,
                        FieldsInScope = ["string"],
                        Origin = Origin.Api,
                        RequiredFields = ["string"],
                    },
                    Path = "path",
                    ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        var model = new ReviewListEventsPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    ActorID = "actor_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = Kind.Approved,
                    Detail = new ExtractReviewCreatedDetail()
                    {
                        ConfidenceThreshold = 0,
                        FieldsInScope = ["string"],
                        Origin = Origin.Api,
                        RequiredFields = ["string"],
                    },
                    Path = "path",
                    ValueAfter = JsonSerializer.Deserialize<JsonElement>("{}"),
                    ValueBefore = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        ReviewListEventsPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
