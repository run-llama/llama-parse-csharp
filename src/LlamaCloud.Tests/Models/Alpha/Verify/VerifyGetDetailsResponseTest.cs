using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Alpha.Verify;

namespace LlamaCloud.Tests.Models.Alpha.Verify;

public class VerifyGetDetailsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyGetDetailsResponse
        {
            JobID = "job_id",
            DegradedTools = [new() { Tool = "tool", Reason = "reason" }],
            Evidence =
            [
                new()
                {
                    Code = "code",
                    Detail = "detail",
                    Family = "family",
                    Score = 0,
                    Tool = "tool",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Hard = true,
                },
            ],
            Heatmaps =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = "kind",
                    Page = 0,
                    Url = "url",
                    Score = 0,
                },
            ],
            PageDimensions =
            [
                new()
                {
                    Height = 0,
                    Page = 0,
                    Width = 0,
                },
            ],
            Regions =
            [
                new()
                {
                    Bbox = [0, 0, 0, 0],
                    Detail = "detail",
                    Kind = "kind",
                    Page = 0,
                    Score = 0,
                    Source = "source",
                    Primary = true,
                    Review = "review",
                    ReviewNote = "review_note",
                },
            ],
            SubScores = new Dictionary<string, double>() { { "foo", 0 } },
        };

        string expectedJobID = "job_id";
        List<DegradedTool> expectedDegradedTools = [new() { Tool = "tool", Reason = "reason" }];
        List<Evidence> expectedEvidence =
        [
            new()
            {
                Code = "code",
                Detail = "detail",
                Family = "family",
                Score = 0,
                Tool = "tool",
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Hard = true,
            },
        ];
        List<Heatmap> expectedHeatmaps =
        [
            new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Kind = "kind",
                Page = 0,
                Url = "url",
                Score = 0,
            },
        ];
        List<VerifyGetDetailsResponsePageDimension> expectedPageDimensions =
        [
            new()
            {
                Height = 0,
                Page = 0,
                Width = 0,
            },
        ];
        List<Region> expectedRegions =
        [
            new()
            {
                Bbox = [0, 0, 0, 0],
                Detail = "detail",
                Kind = "kind",
                Page = 0,
                Score = 0,
                Source = "source",
                Primary = true,
                Review = "review",
                ReviewNote = "review_note",
            },
        ];
        Dictionary<string, double> expectedSubScores = new() { { "foo", 0 } };

        Assert.Equal(expectedJobID, model.JobID);
        Assert.NotNull(model.DegradedTools);
        Assert.Equal(expectedDegradedTools.Count, model.DegradedTools.Count);
        for (int i = 0; i < expectedDegradedTools.Count; i++)
        {
            Assert.Equal(expectedDegradedTools[i], model.DegradedTools[i]);
        }
        Assert.NotNull(model.Evidence);
        Assert.Equal(expectedEvidence.Count, model.Evidence.Count);
        for (int i = 0; i < expectedEvidence.Count; i++)
        {
            Assert.Equal(expectedEvidence[i], model.Evidence[i]);
        }
        Assert.NotNull(model.Heatmaps);
        Assert.Equal(expectedHeatmaps.Count, model.Heatmaps.Count);
        for (int i = 0; i < expectedHeatmaps.Count; i++)
        {
            Assert.Equal(expectedHeatmaps[i], model.Heatmaps[i]);
        }
        Assert.NotNull(model.PageDimensions);
        Assert.Equal(expectedPageDimensions.Count, model.PageDimensions.Count);
        for (int i = 0; i < expectedPageDimensions.Count; i++)
        {
            Assert.Equal(expectedPageDimensions[i], model.PageDimensions[i]);
        }
        Assert.NotNull(model.Regions);
        Assert.Equal(expectedRegions.Count, model.Regions.Count);
        for (int i = 0; i < expectedRegions.Count; i++)
        {
            Assert.Equal(expectedRegions[i], model.Regions[i]);
        }
        Assert.NotNull(model.SubScores);
        Assert.Equal(expectedSubScores.Count, model.SubScores.Count);
        foreach (var item in expectedSubScores)
        {
            Assert.True(model.SubScores.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.SubScores[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerifyGetDetailsResponse
        {
            JobID = "job_id",
            DegradedTools = [new() { Tool = "tool", Reason = "reason" }],
            Evidence =
            [
                new()
                {
                    Code = "code",
                    Detail = "detail",
                    Family = "family",
                    Score = 0,
                    Tool = "tool",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Hard = true,
                },
            ],
            Heatmaps =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = "kind",
                    Page = 0,
                    Url = "url",
                    Score = 0,
                },
            ],
            PageDimensions =
            [
                new()
                {
                    Height = 0,
                    Page = 0,
                    Width = 0,
                },
            ],
            Regions =
            [
                new()
                {
                    Bbox = [0, 0, 0, 0],
                    Detail = "detail",
                    Kind = "kind",
                    Page = 0,
                    Score = 0,
                    Source = "source",
                    Primary = true,
                    Review = "review",
                    ReviewNote = "review_note",
                },
            ],
            SubScores = new Dictionary<string, double>() { { "foo", 0 } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyGetDetailsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyGetDetailsResponse
        {
            JobID = "job_id",
            DegradedTools = [new() { Tool = "tool", Reason = "reason" }],
            Evidence =
            [
                new()
                {
                    Code = "code",
                    Detail = "detail",
                    Family = "family",
                    Score = 0,
                    Tool = "tool",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Hard = true,
                },
            ],
            Heatmaps =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = "kind",
                    Page = 0,
                    Url = "url",
                    Score = 0,
                },
            ],
            PageDimensions =
            [
                new()
                {
                    Height = 0,
                    Page = 0,
                    Width = 0,
                },
            ],
            Regions =
            [
                new()
                {
                    Bbox = [0, 0, 0, 0],
                    Detail = "detail",
                    Kind = "kind",
                    Page = 0,
                    Score = 0,
                    Source = "source",
                    Primary = true,
                    Review = "review",
                    ReviewNote = "review_note",
                },
            ],
            SubScores = new Dictionary<string, double>() { { "foo", 0 } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyGetDetailsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedJobID = "job_id";
        List<DegradedTool> expectedDegradedTools = [new() { Tool = "tool", Reason = "reason" }];
        List<Evidence> expectedEvidence =
        [
            new()
            {
                Code = "code",
                Detail = "detail",
                Family = "family",
                Score = 0,
                Tool = "tool",
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Hard = true,
            },
        ];
        List<Heatmap> expectedHeatmaps =
        [
            new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Kind = "kind",
                Page = 0,
                Url = "url",
                Score = 0,
            },
        ];
        List<VerifyGetDetailsResponsePageDimension> expectedPageDimensions =
        [
            new()
            {
                Height = 0,
                Page = 0,
                Width = 0,
            },
        ];
        List<Region> expectedRegions =
        [
            new()
            {
                Bbox = [0, 0, 0, 0],
                Detail = "detail",
                Kind = "kind",
                Page = 0,
                Score = 0,
                Source = "source",
                Primary = true,
                Review = "review",
                ReviewNote = "review_note",
            },
        ];
        Dictionary<string, double> expectedSubScores = new() { { "foo", 0 } };

        Assert.Equal(expectedJobID, deserialized.JobID);
        Assert.NotNull(deserialized.DegradedTools);
        Assert.Equal(expectedDegradedTools.Count, deserialized.DegradedTools.Count);
        for (int i = 0; i < expectedDegradedTools.Count; i++)
        {
            Assert.Equal(expectedDegradedTools[i], deserialized.DegradedTools[i]);
        }
        Assert.NotNull(deserialized.Evidence);
        Assert.Equal(expectedEvidence.Count, deserialized.Evidence.Count);
        for (int i = 0; i < expectedEvidence.Count; i++)
        {
            Assert.Equal(expectedEvidence[i], deserialized.Evidence[i]);
        }
        Assert.NotNull(deserialized.Heatmaps);
        Assert.Equal(expectedHeatmaps.Count, deserialized.Heatmaps.Count);
        for (int i = 0; i < expectedHeatmaps.Count; i++)
        {
            Assert.Equal(expectedHeatmaps[i], deserialized.Heatmaps[i]);
        }
        Assert.NotNull(deserialized.PageDimensions);
        Assert.Equal(expectedPageDimensions.Count, deserialized.PageDimensions.Count);
        for (int i = 0; i < expectedPageDimensions.Count; i++)
        {
            Assert.Equal(expectedPageDimensions[i], deserialized.PageDimensions[i]);
        }
        Assert.NotNull(deserialized.Regions);
        Assert.Equal(expectedRegions.Count, deserialized.Regions.Count);
        for (int i = 0; i < expectedRegions.Count; i++)
        {
            Assert.Equal(expectedRegions[i], deserialized.Regions[i]);
        }
        Assert.NotNull(deserialized.SubScores);
        Assert.Equal(expectedSubScores.Count, deserialized.SubScores.Count);
        foreach (var item in expectedSubScores)
        {
            Assert.True(deserialized.SubScores.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.SubScores[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerifyGetDetailsResponse
        {
            JobID = "job_id",
            DegradedTools = [new() { Tool = "tool", Reason = "reason" }],
            Evidence =
            [
                new()
                {
                    Code = "code",
                    Detail = "detail",
                    Family = "family",
                    Score = 0,
                    Tool = "tool",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Hard = true,
                },
            ],
            Heatmaps =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = "kind",
                    Page = 0,
                    Url = "url",
                    Score = 0,
                },
            ],
            PageDimensions =
            [
                new()
                {
                    Height = 0,
                    Page = 0,
                    Width = 0,
                },
            ],
            Regions =
            [
                new()
                {
                    Bbox = [0, 0, 0, 0],
                    Detail = "detail",
                    Kind = "kind",
                    Page = 0,
                    Score = 0,
                    Source = "source",
                    Primary = true,
                    Review = "review",
                    ReviewNote = "review_note",
                },
            ],
            SubScores = new Dictionary<string, double>() { { "foo", 0 } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyGetDetailsResponse { JobID = "job_id" };

        Assert.Null(model.DegradedTools);
        Assert.False(model.RawData.ContainsKey("degraded_tools"));
        Assert.Null(model.Evidence);
        Assert.False(model.RawData.ContainsKey("evidence"));
        Assert.Null(model.Heatmaps);
        Assert.False(model.RawData.ContainsKey("heatmaps"));
        Assert.Null(model.PageDimensions);
        Assert.False(model.RawData.ContainsKey("page_dimensions"));
        Assert.Null(model.Regions);
        Assert.False(model.RawData.ContainsKey("regions"));
        Assert.Null(model.SubScores);
        Assert.False(model.RawData.ContainsKey("sub_scores"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyGetDetailsResponse { JobID = "job_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyGetDetailsResponse
        {
            JobID = "job_id",

            // Null should be interpreted as omitted for these properties
            DegradedTools = null,
            Evidence = null,
            Heatmaps = null,
            PageDimensions = null,
            Regions = null,
            SubScores = null,
        };

        Assert.Null(model.DegradedTools);
        Assert.False(model.RawData.ContainsKey("degraded_tools"));
        Assert.Null(model.Evidence);
        Assert.False(model.RawData.ContainsKey("evidence"));
        Assert.Null(model.Heatmaps);
        Assert.False(model.RawData.ContainsKey("heatmaps"));
        Assert.Null(model.PageDimensions);
        Assert.False(model.RawData.ContainsKey("page_dimensions"));
        Assert.Null(model.Regions);
        Assert.False(model.RawData.ContainsKey("regions"));
        Assert.Null(model.SubScores);
        Assert.False(model.RawData.ContainsKey("sub_scores"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyGetDetailsResponse
        {
            JobID = "job_id",

            // Null should be interpreted as omitted for these properties
            DegradedTools = null,
            Evidence = null,
            Heatmaps = null,
            PageDimensions = null,
            Regions = null,
            SubScores = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyGetDetailsResponse
        {
            JobID = "job_id",
            DegradedTools = [new() { Tool = "tool", Reason = "reason" }],
            Evidence =
            [
                new()
                {
                    Code = "code",
                    Detail = "detail",
                    Family = "family",
                    Score = 0,
                    Tool = "tool",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Hard = true,
                },
            ],
            Heatmaps =
            [
                new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Kind = "kind",
                    Page = 0,
                    Url = "url",
                    Score = 0,
                },
            ],
            PageDimensions =
            [
                new()
                {
                    Height = 0,
                    Page = 0,
                    Width = 0,
                },
            ],
            Regions =
            [
                new()
                {
                    Bbox = [0, 0, 0, 0],
                    Detail = "detail",
                    Kind = "kind",
                    Page = 0,
                    Score = 0,
                    Source = "source",
                    Primary = true,
                    Review = "review",
                    ReviewNote = "review_note",
                },
            ],
            SubScores = new Dictionary<string, double>() { { "foo", 0 } },
        };

        VerifyGetDetailsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DegradedToolTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DegradedTool { Tool = "tool", Reason = "reason" };

        string expectedTool = "tool";
        string expectedReason = "reason";

        Assert.Equal(expectedTool, model.Tool);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DegradedTool { Tool = "tool", Reason = "reason" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DegradedTool>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DegradedTool { Tool = "tool", Reason = "reason" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DegradedTool>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTool = "tool";
        string expectedReason = "reason";

        Assert.Equal(expectedTool, deserialized.Tool);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DegradedTool { Tool = "tool", Reason = "reason" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DegradedTool { Tool = "tool" };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DegradedTool { Tool = "tool" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DegradedTool
        {
            Tool = "tool",

            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DegradedTool
        {
            Tool = "tool",

            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DegradedTool { Tool = "tool", Reason = "reason" };

        DegradedTool copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EvidenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Evidence
        {
            Code = "code",
            Detail = "detail",
            Family = "family",
            Score = 0,
            Tool = "tool",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Hard = true,
        };

        string expectedCode = "code";
        string expectedDetail = "detail";
        string expectedFamily = "family";
        double expectedScore = 0;
        string expectedTool = "tool";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        bool expectedHard = true;

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedDetail, model.Detail);
        Assert.Equal(expectedFamily, model.Family);
        Assert.Equal(expectedScore, model.Score);
        Assert.Equal(expectedTool, model.Tool);
        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(model.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Data[item.Key]));
        }
        Assert.Equal(expectedHard, model.Hard);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Evidence
        {
            Code = "code",
            Detail = "detail",
            Family = "family",
            Score = 0,
            Tool = "tool",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Hard = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Evidence>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Evidence
        {
            Code = "code",
            Detail = "detail",
            Family = "family",
            Score = 0,
            Tool = "tool",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Hard = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Evidence>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCode = "code";
        string expectedDetail = "detail";
        string expectedFamily = "family";
        double expectedScore = 0;
        string expectedTool = "tool";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        bool expectedHard = true;

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedDetail, deserialized.Detail);
        Assert.Equal(expectedFamily, deserialized.Family);
        Assert.Equal(expectedScore, deserialized.Score);
        Assert.Equal(expectedTool, deserialized.Tool);
        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(deserialized.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Data[item.Key]));
        }
        Assert.Equal(expectedHard, deserialized.Hard);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Evidence
        {
            Code = "code",
            Detail = "detail",
            Family = "family",
            Score = 0,
            Tool = "tool",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Hard = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Evidence
        {
            Code = "code",
            Detail = "detail",
            Family = "family",
            Score = 0,
            Tool = "tool",
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Hard);
        Assert.False(model.RawData.ContainsKey("hard"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Evidence
        {
            Code = "code",
            Detail = "detail",
            Family = "family",
            Score = 0,
            Tool = "tool",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Evidence
        {
            Code = "code",
            Detail = "detail",
            Family = "family",
            Score = 0,
            Tool = "tool",

            // Null should be interpreted as omitted for these properties
            Data = null,
            Hard = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Hard);
        Assert.False(model.RawData.ContainsKey("hard"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Evidence
        {
            Code = "code",
            Detail = "detail",
            Family = "family",
            Score = 0,
            Tool = "tool",

            // Null should be interpreted as omitted for these properties
            Data = null,
            Hard = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Evidence
        {
            Code = "code",
            Detail = "detail",
            Family = "family",
            Score = 0,
            Tool = "tool",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Hard = true,
        };

        Evidence copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class HeatmapTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Heatmap
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = "kind",
            Page = 0,
            Url = "url",
            Score = 0,
        };

        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedKind = "kind";
        long expectedPage = 0;
        string expectedUrl = "url";
        double expectedScore = 0;

        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedKind, model.Kind);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedScore, model.Score);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Heatmap
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = "kind",
            Page = 0,
            Url = "url",
            Score = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Heatmap>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Heatmap
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = "kind",
            Page = 0,
            Url = "url",
            Score = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Heatmap>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedKind = "kind";
        long expectedPage = 0;
        string expectedUrl = "url";
        double expectedScore = 0;

        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedKind, deserialized.Kind);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedScore, deserialized.Score);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Heatmap
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = "kind",
            Page = 0,
            Url = "url",
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Heatmap
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = "kind",
            Page = 0,
            Url = "url",
        };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Heatmap
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = "kind",
            Page = 0,
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Heatmap
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = "kind",
            Page = 0,
            Url = "url",

            // Null should be interpreted as omitted for these properties
            Score = null,
        };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Heatmap
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = "kind",
            Page = 0,
            Url = "url",

            // Null should be interpreted as omitted for these properties
            Score = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Heatmap
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Kind = "kind",
            Page = 0,
            Url = "url",
            Score = 0,
        };

        Heatmap copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyGetDetailsResponsePageDimensionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyGetDetailsResponsePageDimension
        {
            Height = 0,
            Page = 0,
            Width = 0,
        };

        long expectedHeight = 0;
        long expectedPage = 0;
        long expectedWidth = 0;

        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerifyGetDetailsResponsePageDimension
        {
            Height = 0,
            Page = 0,
            Width = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyGetDetailsResponsePageDimension>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyGetDetailsResponsePageDimension
        {
            Height = 0,
            Page = 0,
            Width = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyGetDetailsResponsePageDimension>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedHeight = 0;
        long expectedPage = 0;
        long expectedWidth = 0;

        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerifyGetDetailsResponsePageDimension
        {
            Height = 0,
            Page = 0,
            Width = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyGetDetailsResponsePageDimension
        {
            Height = 0,
            Page = 0,
            Width = 0,
        };

        VerifyGetDetailsResponsePageDimension copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RegionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Region
        {
            Bbox = [0, 0, 0, 0],
            Detail = "detail",
            Kind = "kind",
            Page = 0,
            Score = 0,
            Source = "source",
            Primary = true,
            Review = "review",
            ReviewNote = "review_note",
        };

        List<long> expectedBbox = [0, 0, 0, 0];
        string expectedDetail = "detail";
        string expectedKind = "kind";
        long expectedPage = 0;
        double expectedScore = 0;
        string expectedSource = "source";
        bool expectedPrimary = true;
        string expectedReview = "review";
        string expectedReviewNote = "review_note";

        Assert.Equal(expectedBbox.Count, model.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], model.Bbox[i]);
        }
        Assert.Equal(expectedDetail, model.Detail);
        Assert.Equal(expectedKind, model.Kind);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedScore, model.Score);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedPrimary, model.Primary);
        Assert.Equal(expectedReview, model.Review);
        Assert.Equal(expectedReviewNote, model.ReviewNote);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Region
        {
            Bbox = [0, 0, 0, 0],
            Detail = "detail",
            Kind = "kind",
            Page = 0,
            Score = 0,
            Source = "source",
            Primary = true,
            Review = "review",
            ReviewNote = "review_note",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Region>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Region
        {
            Bbox = [0, 0, 0, 0],
            Detail = "detail",
            Kind = "kind",
            Page = 0,
            Score = 0,
            Source = "source",
            Primary = true,
            Review = "review",
            ReviewNote = "review_note",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Region>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<long> expectedBbox = [0, 0, 0, 0];
        string expectedDetail = "detail";
        string expectedKind = "kind";
        long expectedPage = 0;
        double expectedScore = 0;
        string expectedSource = "source";
        bool expectedPrimary = true;
        string expectedReview = "review";
        string expectedReviewNote = "review_note";

        Assert.Equal(expectedBbox.Count, deserialized.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], deserialized.Bbox[i]);
        }
        Assert.Equal(expectedDetail, deserialized.Detail);
        Assert.Equal(expectedKind, deserialized.Kind);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedScore, deserialized.Score);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedPrimary, deserialized.Primary);
        Assert.Equal(expectedReview, deserialized.Review);
        Assert.Equal(expectedReviewNote, deserialized.ReviewNote);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Region
        {
            Bbox = [0, 0, 0, 0],
            Detail = "detail",
            Kind = "kind",
            Page = 0,
            Score = 0,
            Source = "source",
            Primary = true,
            Review = "review",
            ReviewNote = "review_note",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Region
        {
            Bbox = [0, 0, 0, 0],
            Detail = "detail",
            Kind = "kind",
            Page = 0,
            Score = 0,
            Source = "source",
        };

        Assert.Null(model.Primary);
        Assert.False(model.RawData.ContainsKey("primary"));
        Assert.Null(model.Review);
        Assert.False(model.RawData.ContainsKey("review"));
        Assert.Null(model.ReviewNote);
        Assert.False(model.RawData.ContainsKey("review_note"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Region
        {
            Bbox = [0, 0, 0, 0],
            Detail = "detail",
            Kind = "kind",
            Page = 0,
            Score = 0,
            Source = "source",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Region
        {
            Bbox = [0, 0, 0, 0],
            Detail = "detail",
            Kind = "kind",
            Page = 0,
            Score = 0,
            Source = "source",

            // Null should be interpreted as omitted for these properties
            Primary = null,
            Review = null,
            ReviewNote = null,
        };

        Assert.Null(model.Primary);
        Assert.False(model.RawData.ContainsKey("primary"));
        Assert.Null(model.Review);
        Assert.False(model.RawData.ContainsKey("review"));
        Assert.Null(model.ReviewNote);
        Assert.False(model.RawData.ContainsKey("review_note"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Region
        {
            Bbox = [0, 0, 0, 0],
            Detail = "detail",
            Kind = "kind",
            Page = 0,
            Score = 0,
            Source = "source",

            // Null should be interpreted as omitted for these properties
            Primary = null,
            Review = null,
            ReviewNote = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Region
        {
            Bbox = [0, 0, 0, 0],
            Detail = "detail",
            Kind = "kind",
            Page = 0,
            Score = 0,
            Source = "source",
            Primary = true,
            Review = "review",
            ReviewNote = "review_note",
        };

        Region copied = new(model);

        Assert.Equal(model, copied);
    }
}
