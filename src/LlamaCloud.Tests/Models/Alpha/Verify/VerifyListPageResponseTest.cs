using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Alpha.Verify;

namespace LlamaCloud.Tests.Models.Alpha.Verify;

public class VerifyListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        TargetPages = "1,3,5-7",
                        Tier = VerifyListResponseConfigurationTier.Agentic,
                    },
                    DocumentInputType = VerifyListResponseDocumentInputType.FileID,
                    FileInput = "file_input",
                    ProjectID = "project_id",
                    Status = VerifyListResponseStatus.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Result = new()
                    {
                        DetectorVersion = "detector_version",
                        OverallScore = 0,
                        Verdict = VerifyListResponseResultVerdict.Authentic,
                        CompositeScores = new()
                        {
                            AIGenerated = new() { Applicable = true, Score = 0 },
                            DocumentCoherence = new() { Applicable = true, Score = 0 },
                            DocumentMetadata = new() { Applicable = true, Score = 0 },
                            KnownFraud = new() { Applicable = true, Score = 0 },
                            ManuallyEdited = new() { Applicable = true, Score = 0 },
                            Recapture = new() { Applicable = true, Score = 0 },
                        },
                        Confidence = 0,
                        Error = "error",
                        PageCount = 1,
                        PageDimensions =
                        [
                            new()
                            {
                                Height = 0,
                                Page = 0,
                                Width = 0,
                            },
                        ],
                        Reasoning = "reasoning",
                        SuspectRegions =
                        [
                            new()
                            {
                                Bbox = [0, 0, 0, 0],
                                Explanation = "explanation",
                                Kind = "kind",
                                Page = 0,
                                Score = 0,
                                Source = "source",
                                Primary = true,
                                Review = "review",
                            },
                        ],
                        SyntheticScore = 0,
                        TamperingScore = 0,
                    },
                    TransactionID = "transaction_id",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        List<VerifyListResponse> expectedItems =
        [
            new()
            {
                ID = "id",
                Configuration = new()
                {
                    TargetPages = "1,3,5-7",
                    Tier = VerifyListResponseConfigurationTier.Agentic,
                },
                DocumentInputType = VerifyListResponseDocumentInputType.FileID,
                FileInput = "file_input",
                ProjectID = "project_id",
                Status = VerifyListResponseStatus.Cancelled,
                UserID = "user_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "error_message",
                Result = new()
                {
                    DetectorVersion = "detector_version",
                    OverallScore = 0,
                    Verdict = VerifyListResponseResultVerdict.Authentic,
                    CompositeScores = new()
                    {
                        AIGenerated = new() { Applicable = true, Score = 0 },
                        DocumentCoherence = new() { Applicable = true, Score = 0 },
                        DocumentMetadata = new() { Applicable = true, Score = 0 },
                        KnownFraud = new() { Applicable = true, Score = 0 },
                        ManuallyEdited = new() { Applicable = true, Score = 0 },
                        Recapture = new() { Applicable = true, Score = 0 },
                    },
                    Confidence = 0,
                    Error = "error",
                    PageCount = 1,
                    PageDimensions =
                    [
                        new()
                        {
                            Height = 0,
                            Page = 0,
                            Width = 0,
                        },
                    ],
                    Reasoning = "reasoning",
                    SuspectRegions =
                    [
                        new()
                        {
                            Bbox = [0, 0, 0, 0],
                            Explanation = "explanation",
                            Kind = "kind",
                            Page = 0,
                            Score = 0,
                            Source = "source",
                            Primary = true,
                            Review = "review",
                        },
                    ],
                    SyntheticScore = 0,
                    TamperingScore = 0,
                },
                TransactionID = "transaction_id",
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
        var model = new VerifyListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        TargetPages = "1,3,5-7",
                        Tier = VerifyListResponseConfigurationTier.Agentic,
                    },
                    DocumentInputType = VerifyListResponseDocumentInputType.FileID,
                    FileInput = "file_input",
                    ProjectID = "project_id",
                    Status = VerifyListResponseStatus.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Result = new()
                    {
                        DetectorVersion = "detector_version",
                        OverallScore = 0,
                        Verdict = VerifyListResponseResultVerdict.Authentic,
                        CompositeScores = new()
                        {
                            AIGenerated = new() { Applicable = true, Score = 0 },
                            DocumentCoherence = new() { Applicable = true, Score = 0 },
                            DocumentMetadata = new() { Applicable = true, Score = 0 },
                            KnownFraud = new() { Applicable = true, Score = 0 },
                            ManuallyEdited = new() { Applicable = true, Score = 0 },
                            Recapture = new() { Applicable = true, Score = 0 },
                        },
                        Confidence = 0,
                        Error = "error",
                        PageCount = 1,
                        PageDimensions =
                        [
                            new()
                            {
                                Height = 0,
                                Page = 0,
                                Width = 0,
                            },
                        ],
                        Reasoning = "reasoning",
                        SuspectRegions =
                        [
                            new()
                            {
                                Bbox = [0, 0, 0, 0],
                                Explanation = "explanation",
                                Kind = "kind",
                                Page = 0,
                                Score = 0,
                                Source = "source",
                                Primary = true,
                                Review = "review",
                            },
                        ],
                        SyntheticScore = 0,
                        TamperingScore = 0,
                    },
                    TransactionID = "transaction_id",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        TargetPages = "1,3,5-7",
                        Tier = VerifyListResponseConfigurationTier.Agentic,
                    },
                    DocumentInputType = VerifyListResponseDocumentInputType.FileID,
                    FileInput = "file_input",
                    ProjectID = "project_id",
                    Status = VerifyListResponseStatus.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Result = new()
                    {
                        DetectorVersion = "detector_version",
                        OverallScore = 0,
                        Verdict = VerifyListResponseResultVerdict.Authentic,
                        CompositeScores = new()
                        {
                            AIGenerated = new() { Applicable = true, Score = 0 },
                            DocumentCoherence = new() { Applicable = true, Score = 0 },
                            DocumentMetadata = new() { Applicable = true, Score = 0 },
                            KnownFraud = new() { Applicable = true, Score = 0 },
                            ManuallyEdited = new() { Applicable = true, Score = 0 },
                            Recapture = new() { Applicable = true, Score = 0 },
                        },
                        Confidence = 0,
                        Error = "error",
                        PageCount = 1,
                        PageDimensions =
                        [
                            new()
                            {
                                Height = 0,
                                Page = 0,
                                Width = 0,
                            },
                        ],
                        Reasoning = "reasoning",
                        SuspectRegions =
                        [
                            new()
                            {
                                Bbox = [0, 0, 0, 0],
                                Explanation = "explanation",
                                Kind = "kind",
                                Page = 0,
                                Score = 0,
                                Source = "source",
                                Primary = true,
                                Review = "review",
                            },
                        ],
                        SyntheticScore = 0,
                        TamperingScore = 0,
                    },
                    TransactionID = "transaction_id",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<VerifyListResponse> expectedItems =
        [
            new()
            {
                ID = "id",
                Configuration = new()
                {
                    TargetPages = "1,3,5-7",
                    Tier = VerifyListResponseConfigurationTier.Agentic,
                },
                DocumentInputType = VerifyListResponseDocumentInputType.FileID,
                FileInput = "file_input",
                ProjectID = "project_id",
                Status = VerifyListResponseStatus.Cancelled,
                UserID = "user_id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "error_message",
                Result = new()
                {
                    DetectorVersion = "detector_version",
                    OverallScore = 0,
                    Verdict = VerifyListResponseResultVerdict.Authentic,
                    CompositeScores = new()
                    {
                        AIGenerated = new() { Applicable = true, Score = 0 },
                        DocumentCoherence = new() { Applicable = true, Score = 0 },
                        DocumentMetadata = new() { Applicable = true, Score = 0 },
                        KnownFraud = new() { Applicable = true, Score = 0 },
                        ManuallyEdited = new() { Applicable = true, Score = 0 },
                        Recapture = new() { Applicable = true, Score = 0 },
                    },
                    Confidence = 0,
                    Error = "error",
                    PageCount = 1,
                    PageDimensions =
                    [
                        new()
                        {
                            Height = 0,
                            Page = 0,
                            Width = 0,
                        },
                    ],
                    Reasoning = "reasoning",
                    SuspectRegions =
                    [
                        new()
                        {
                            Bbox = [0, 0, 0, 0],
                            Explanation = "explanation",
                            Kind = "kind",
                            Page = 0,
                            Score = 0,
                            Source = "source",
                            Primary = true,
                            Review = "review",
                        },
                    ],
                    SyntheticScore = 0,
                    TamperingScore = 0,
                },
                TransactionID = "transaction_id",
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
        var model = new VerifyListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        TargetPages = "1,3,5-7",
                        Tier = VerifyListResponseConfigurationTier.Agentic,
                    },
                    DocumentInputType = VerifyListResponseDocumentInputType.FileID,
                    FileInput = "file_input",
                    ProjectID = "project_id",
                    Status = VerifyListResponseStatus.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Result = new()
                    {
                        DetectorVersion = "detector_version",
                        OverallScore = 0,
                        Verdict = VerifyListResponseResultVerdict.Authentic,
                        CompositeScores = new()
                        {
                            AIGenerated = new() { Applicable = true, Score = 0 },
                            DocumentCoherence = new() { Applicable = true, Score = 0 },
                            DocumentMetadata = new() { Applicable = true, Score = 0 },
                            KnownFraud = new() { Applicable = true, Score = 0 },
                            ManuallyEdited = new() { Applicable = true, Score = 0 },
                            Recapture = new() { Applicable = true, Score = 0 },
                        },
                        Confidence = 0,
                        Error = "error",
                        PageCount = 1,
                        PageDimensions =
                        [
                            new()
                            {
                                Height = 0,
                                Page = 0,
                                Width = 0,
                            },
                        ],
                        Reasoning = "reasoning",
                        SuspectRegions =
                        [
                            new()
                            {
                                Bbox = [0, 0, 0, 0],
                                Explanation = "explanation",
                                Kind = "kind",
                                Page = 0,
                                Score = 0,
                                Source = "source",
                                Primary = true,
                                Review = "review",
                            },
                        ],
                        SyntheticScore = 0,
                        TamperingScore = 0,
                    },
                    TransactionID = "transaction_id",
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
        var model = new VerifyListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        TargetPages = "1,3,5-7",
                        Tier = VerifyListResponseConfigurationTier.Agentic,
                    },
                    DocumentInputType = VerifyListResponseDocumentInputType.FileID,
                    FileInput = "file_input",
                    ProjectID = "project_id",
                    Status = VerifyListResponseStatus.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Result = new()
                    {
                        DetectorVersion = "detector_version",
                        OverallScore = 0,
                        Verdict = VerifyListResponseResultVerdict.Authentic,
                        CompositeScores = new()
                        {
                            AIGenerated = new() { Applicable = true, Score = 0 },
                            DocumentCoherence = new() { Applicable = true, Score = 0 },
                            DocumentMetadata = new() { Applicable = true, Score = 0 },
                            KnownFraud = new() { Applicable = true, Score = 0 },
                            ManuallyEdited = new() { Applicable = true, Score = 0 },
                            Recapture = new() { Applicable = true, Score = 0 },
                        },
                        Confidence = 0,
                        Error = "error",
                        PageCount = 1,
                        PageDimensions =
                        [
                            new()
                            {
                                Height = 0,
                                Page = 0,
                                Width = 0,
                            },
                        ],
                        Reasoning = "reasoning",
                        SuspectRegions =
                        [
                            new()
                            {
                                Bbox = [0, 0, 0, 0],
                                Explanation = "explanation",
                                Kind = "kind",
                                Page = 0,
                                Score = 0,
                                Source = "source",
                                Primary = true,
                                Review = "review",
                            },
                        ],
                        SyntheticScore = 0,
                        TamperingScore = 0,
                    },
                    TransactionID = "transaction_id",
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
        var model = new VerifyListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        TargetPages = "1,3,5-7",
                        Tier = VerifyListResponseConfigurationTier.Agentic,
                    },
                    DocumentInputType = VerifyListResponseDocumentInputType.FileID,
                    FileInput = "file_input",
                    ProjectID = "project_id",
                    Status = VerifyListResponseStatus.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Result = new()
                    {
                        DetectorVersion = "detector_version",
                        OverallScore = 0,
                        Verdict = VerifyListResponseResultVerdict.Authentic,
                        CompositeScores = new()
                        {
                            AIGenerated = new() { Applicable = true, Score = 0 },
                            DocumentCoherence = new() { Applicable = true, Score = 0 },
                            DocumentMetadata = new() { Applicable = true, Score = 0 },
                            KnownFraud = new() { Applicable = true, Score = 0 },
                            ManuallyEdited = new() { Applicable = true, Score = 0 },
                            Recapture = new() { Applicable = true, Score = 0 },
                        },
                        Confidence = 0,
                        Error = "error",
                        PageCount = 1,
                        PageDimensions =
                        [
                            new()
                            {
                                Height = 0,
                                Page = 0,
                                Width = 0,
                            },
                        ],
                        Reasoning = "reasoning",
                        SuspectRegions =
                        [
                            new()
                            {
                                Bbox = [0, 0, 0, 0],
                                Explanation = "explanation",
                                Kind = "kind",
                                Page = 0,
                                Score = 0,
                                Source = "source",
                                Primary = true,
                                Review = "review",
                            },
                        ],
                        SyntheticScore = 0,
                        TamperingScore = 0,
                    },
                    TransactionID = "transaction_id",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        TargetPages = "1,3,5-7",
                        Tier = VerifyListResponseConfigurationTier.Agentic,
                    },
                    DocumentInputType = VerifyListResponseDocumentInputType.FileID,
                    FileInput = "file_input",
                    ProjectID = "project_id",
                    Status = VerifyListResponseStatus.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Result = new()
                    {
                        DetectorVersion = "detector_version",
                        OverallScore = 0,
                        Verdict = VerifyListResponseResultVerdict.Authentic,
                        CompositeScores = new()
                        {
                            AIGenerated = new() { Applicable = true, Score = 0 },
                            DocumentCoherence = new() { Applicable = true, Score = 0 },
                            DocumentMetadata = new() { Applicable = true, Score = 0 },
                            KnownFraud = new() { Applicable = true, Score = 0 },
                            ManuallyEdited = new() { Applicable = true, Score = 0 },
                            Recapture = new() { Applicable = true, Score = 0 },
                        },
                        Confidence = 0,
                        Error = "error",
                        PageCount = 1,
                        PageDimensions =
                        [
                            new()
                            {
                                Height = 0,
                                Page = 0,
                                Width = 0,
                            },
                        ],
                        Reasoning = "reasoning",
                        SuspectRegions =
                        [
                            new()
                            {
                                Bbox = [0, 0, 0, 0],
                                Explanation = "explanation",
                                Kind = "kind",
                                Page = 0,
                                Score = 0,
                                Source = "source",
                                Primary = true,
                                Review = "review",
                            },
                        ],
                        SyntheticScore = 0,
                        TamperingScore = 0,
                    },
                    TransactionID = "transaction_id",
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
        var model = new VerifyListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        TargetPages = "1,3,5-7",
                        Tier = VerifyListResponseConfigurationTier.Agentic,
                    },
                    DocumentInputType = VerifyListResponseDocumentInputType.FileID,
                    FileInput = "file_input",
                    ProjectID = "project_id",
                    Status = VerifyListResponseStatus.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Result = new()
                    {
                        DetectorVersion = "detector_version",
                        OverallScore = 0,
                        Verdict = VerifyListResponseResultVerdict.Authentic,
                        CompositeScores = new()
                        {
                            AIGenerated = new() { Applicable = true, Score = 0 },
                            DocumentCoherence = new() { Applicable = true, Score = 0 },
                            DocumentMetadata = new() { Applicable = true, Score = 0 },
                            KnownFraud = new() { Applicable = true, Score = 0 },
                            ManuallyEdited = new() { Applicable = true, Score = 0 },
                            Recapture = new() { Applicable = true, Score = 0 },
                        },
                        Confidence = 0,
                        Error = "error",
                        PageCount = 1,
                        PageDimensions =
                        [
                            new()
                            {
                                Height = 0,
                                Page = 0,
                                Width = 0,
                            },
                        ],
                        Reasoning = "reasoning",
                        SuspectRegions =
                        [
                            new()
                            {
                                Bbox = [0, 0, 0, 0],
                                Explanation = "explanation",
                                Kind = "kind",
                                Page = 0,
                                Score = 0,
                                Source = "source",
                                Primary = true,
                                Review = "review",
                            },
                        ],
                        SyntheticScore = 0,
                        TamperingScore = 0,
                    },
                    TransactionID = "transaction_id",
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
        var model = new VerifyListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        TargetPages = "1,3,5-7",
                        Tier = VerifyListResponseConfigurationTier.Agentic,
                    },
                    DocumentInputType = VerifyListResponseDocumentInputType.FileID,
                    FileInput = "file_input",
                    ProjectID = "project_id",
                    Status = VerifyListResponseStatus.Cancelled,
                    UserID = "user_id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Result = new()
                    {
                        DetectorVersion = "detector_version",
                        OverallScore = 0,
                        Verdict = VerifyListResponseResultVerdict.Authentic,
                        CompositeScores = new()
                        {
                            AIGenerated = new() { Applicable = true, Score = 0 },
                            DocumentCoherence = new() { Applicable = true, Score = 0 },
                            DocumentMetadata = new() { Applicable = true, Score = 0 },
                            KnownFraud = new() { Applicable = true, Score = 0 },
                            ManuallyEdited = new() { Applicable = true, Score = 0 },
                            Recapture = new() { Applicable = true, Score = 0 },
                        },
                        Confidence = 0,
                        Error = "error",
                        PageCount = 1,
                        PageDimensions =
                        [
                            new()
                            {
                                Height = 0,
                                Page = 0,
                                Width = 0,
                            },
                        ],
                        Reasoning = "reasoning",
                        SuspectRegions =
                        [
                            new()
                            {
                                Bbox = [0, 0, 0, 0],
                                Explanation = "explanation",
                                Kind = "kind",
                                Page = 0,
                                Score = 0,
                                Source = "source",
                                Primary = true,
                                Review = "review",
                            },
                        ],
                        SyntheticScore = 0,
                        TamperingScore = 0,
                    },
                    TransactionID = "transaction_id",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        VerifyListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
