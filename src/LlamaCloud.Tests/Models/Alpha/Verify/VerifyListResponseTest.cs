using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Alpha.Verify;

namespace LlamaCloud.Tests.Models.Alpha.Verify;

public class VerifyListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyListResponse
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
        };

        string expectedID = "id";
        VerifyListResponseConfiguration expectedConfiguration = new()
        {
            TargetPages = "1,3,5-7",
            Tier = VerifyListResponseConfigurationTier.Agentic,
        };
        ApiEnum<string, VerifyListResponseDocumentInputType> expectedDocumentInputType =
            VerifyListResponseDocumentInputType.FileID;
        string expectedFileInput = "file_input";
        string expectedProjectID = "project_id";
        ApiEnum<string, VerifyListResponseStatus> expectedStatus =
            VerifyListResponseStatus.Cancelled;
        string expectedUserID = "user_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        VerifyListResponseResult expectedResult = new()
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
        };
        string expectedTransactionID = "transaction_id";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConfiguration, model.Configuration);
        Assert.Equal(expectedDocumentInputType, model.DocumentInputType);
        Assert.Equal(expectedFileInput, model.FileInput);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedTransactionID, model.TransactionID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerifyListResponse
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyListResponse
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        VerifyListResponseConfiguration expectedConfiguration = new()
        {
            TargetPages = "1,3,5-7",
            Tier = VerifyListResponseConfigurationTier.Agentic,
        };
        ApiEnum<string, VerifyListResponseDocumentInputType> expectedDocumentInputType =
            VerifyListResponseDocumentInputType.FileID;
        string expectedFileInput = "file_input";
        string expectedProjectID = "project_id";
        ApiEnum<string, VerifyListResponseStatus> expectedStatus =
            VerifyListResponseStatus.Cancelled;
        string expectedUserID = "user_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        VerifyListResponseResult expectedResult = new()
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
        };
        string expectedTransactionID = "transaction_id";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConfiguration, deserialized.Configuration);
        Assert.Equal(expectedDocumentInputType, deserialized.DocumentInputType);
        Assert.Equal(expectedFileInput, deserialized.FileInput);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerifyListResponse
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponse
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
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
        Assert.Null(model.TransactionID);
        Assert.False(model.RawData.ContainsKey("transaction_id"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponse
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyListResponse
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

            CreatedAt = null,
            ErrorMessage = null,
            Result = null,
            TransactionID = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.Result);
        Assert.True(model.RawData.ContainsKey("result"));
        Assert.Null(model.TransactionID);
        Assert.True(model.RawData.ContainsKey("transaction_id"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponse
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

            CreatedAt = null,
            ErrorMessage = null,
            Result = null,
            TransactionID = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyListResponse
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
        };

        VerifyListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyListResponseConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyListResponseConfiguration
        {
            TargetPages = "1,3,5-7",
            Tier = VerifyListResponseConfigurationTier.Agentic,
        };

        string expectedTargetPages = "1,3,5-7";
        ApiEnum<string, VerifyListResponseConfigurationTier> expectedTier =
            VerifyListResponseConfigurationTier.Agentic;

        Assert.Equal(expectedTargetPages, model.TargetPages);
        Assert.Equal(expectedTier, model.Tier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerifyListResponseConfiguration
        {
            TargetPages = "1,3,5-7",
            Tier = VerifyListResponseConfigurationTier.Agentic,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyListResponseConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyListResponseConfiguration
        {
            TargetPages = "1,3,5-7",
            Tier = VerifyListResponseConfigurationTier.Agentic,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyListResponseConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTargetPages = "1,3,5-7";
        ApiEnum<string, VerifyListResponseConfigurationTier> expectedTier =
            VerifyListResponseConfigurationTier.Agentic;

        Assert.Equal(expectedTargetPages, deserialized.TargetPages);
        Assert.Equal(expectedTier, deserialized.Tier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerifyListResponseConfiguration
        {
            TargetPages = "1,3,5-7",
            Tier = VerifyListResponseConfigurationTier.Agentic,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseConfiguration { TargetPages = "1,3,5-7" };

        Assert.Null(model.Tier);
        Assert.False(model.RawData.ContainsKey("tier"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseConfiguration { TargetPages = "1,3,5-7" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyListResponseConfiguration
        {
            TargetPages = "1,3,5-7",

            // Null should be interpreted as omitted for these properties
            Tier = null,
        };

        Assert.Null(model.Tier);
        Assert.False(model.RawData.ContainsKey("tier"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseConfiguration
        {
            TargetPages = "1,3,5-7",

            // Null should be interpreted as omitted for these properties
            Tier = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseConfiguration
        {
            Tier = VerifyListResponseConfigurationTier.Agentic,
        };

        Assert.Null(model.TargetPages);
        Assert.False(model.RawData.ContainsKey("target_pages"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseConfiguration
        {
            Tier = VerifyListResponseConfigurationTier.Agentic,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyListResponseConfiguration
        {
            Tier = VerifyListResponseConfigurationTier.Agentic,

            TargetPages = null,
        };

        Assert.Null(model.TargetPages);
        Assert.True(model.RawData.ContainsKey("target_pages"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseConfiguration
        {
            Tier = VerifyListResponseConfigurationTier.Agentic,

            TargetPages = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyListResponseConfiguration
        {
            TargetPages = "1,3,5-7",
            Tier = VerifyListResponseConfigurationTier.Agentic,
        };

        VerifyListResponseConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyListResponseConfigurationTierTest : TestBase
{
    [Theory]
    [InlineData(VerifyListResponseConfigurationTier.Agentic)]
    [InlineData(VerifyListResponseConfigurationTier.Fast)]
    public void Validation_Works(VerifyListResponseConfigurationTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifyListResponseConfigurationTier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyListResponseConfigurationTier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerifyListResponseConfigurationTier.Agentic)]
    [InlineData(VerifyListResponseConfigurationTier.Fast)]
    public void SerializationRoundtrip_Works(VerifyListResponseConfigurationTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifyListResponseConfigurationTier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyListResponseConfigurationTier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyListResponseConfigurationTier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyListResponseConfigurationTier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VerifyListResponseDocumentInputTypeTest : TestBase
{
    [Theory]
    [InlineData(VerifyListResponseDocumentInputType.FileID)]
    [InlineData(VerifyListResponseDocumentInputType.ParseJobID)]
    [InlineData(VerifyListResponseDocumentInputType.Url)]
    public void Validation_Works(VerifyListResponseDocumentInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifyListResponseDocumentInputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyListResponseDocumentInputType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerifyListResponseDocumentInputType.FileID)]
    [InlineData(VerifyListResponseDocumentInputType.ParseJobID)]
    [InlineData(VerifyListResponseDocumentInputType.Url)]
    public void SerializationRoundtrip_Works(VerifyListResponseDocumentInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifyListResponseDocumentInputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyListResponseDocumentInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyListResponseDocumentInputType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyListResponseDocumentInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VerifyListResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(VerifyListResponseStatus.Cancelled)]
    [InlineData(VerifyListResponseStatus.Completed)]
    [InlineData(VerifyListResponseStatus.Failed)]
    [InlineData(VerifyListResponseStatus.Pending)]
    [InlineData(VerifyListResponseStatus.Running)]
    public void Validation_Works(VerifyListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifyListResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerifyListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerifyListResponseStatus.Cancelled)]
    [InlineData(VerifyListResponseStatus.Completed)]
    [InlineData(VerifyListResponseStatus.Failed)]
    [InlineData(VerifyListResponseStatus.Pending)]
    [InlineData(VerifyListResponseStatus.Running)]
    public void SerializationRoundtrip_Works(VerifyListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifyListResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VerifyListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerifyListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VerifyListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VerifyListResponseResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyListResponseResult
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
        };

        string expectedDetectorVersion = "detector_version";
        double expectedOverallScore = 0;
        ApiEnum<string, VerifyListResponseResultVerdict> expectedVerdict =
            VerifyListResponseResultVerdict.Authentic;
        VerifyListResponseResultCompositeScores expectedCompositeScores = new()
        {
            AIGenerated = new() { Applicable = true, Score = 0 },
            DocumentCoherence = new() { Applicable = true, Score = 0 },
            DocumentMetadata = new() { Applicable = true, Score = 0 },
            KnownFraud = new() { Applicable = true, Score = 0 },
            ManuallyEdited = new() { Applicable = true, Score = 0 },
            Recapture = new() { Applicable = true, Score = 0 },
        };
        double expectedConfidence = 0;
        string expectedError = "error";
        long expectedPageCount = 1;
        List<VerifyListResponseResultPageDimension> expectedPageDimensions =
        [
            new()
            {
                Height = 0,
                Page = 0,
                Width = 0,
            },
        ];
        string expectedReasoning = "reasoning";
        List<VerifyListResponseResultSuspectRegion> expectedSuspectRegions =
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
        ];
        double expectedSyntheticScore = 0;
        double expectedTamperingScore = 0;

        Assert.Equal(expectedDetectorVersion, model.DetectorVersion);
        Assert.Equal(expectedOverallScore, model.OverallScore);
        Assert.Equal(expectedVerdict, model.Verdict);
        Assert.Equal(expectedCompositeScores, model.CompositeScores);
        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedPageCount, model.PageCount);
        Assert.NotNull(model.PageDimensions);
        Assert.Equal(expectedPageDimensions.Count, model.PageDimensions.Count);
        for (int i = 0; i < expectedPageDimensions.Count; i++)
        {
            Assert.Equal(expectedPageDimensions[i], model.PageDimensions[i]);
        }
        Assert.Equal(expectedReasoning, model.Reasoning);
        Assert.NotNull(model.SuspectRegions);
        Assert.Equal(expectedSuspectRegions.Count, model.SuspectRegions.Count);
        for (int i = 0; i < expectedSuspectRegions.Count; i++)
        {
            Assert.Equal(expectedSuspectRegions[i], model.SuspectRegions[i]);
        }
        Assert.Equal(expectedSyntheticScore, model.SyntheticScore);
        Assert.Equal(expectedTamperingScore, model.TamperingScore);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerifyListResponseResult
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyListResponseResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyListResponseResult
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyListResponseResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDetectorVersion = "detector_version";
        double expectedOverallScore = 0;
        ApiEnum<string, VerifyListResponseResultVerdict> expectedVerdict =
            VerifyListResponseResultVerdict.Authentic;
        VerifyListResponseResultCompositeScores expectedCompositeScores = new()
        {
            AIGenerated = new() { Applicable = true, Score = 0 },
            DocumentCoherence = new() { Applicable = true, Score = 0 },
            DocumentMetadata = new() { Applicable = true, Score = 0 },
            KnownFraud = new() { Applicable = true, Score = 0 },
            ManuallyEdited = new() { Applicable = true, Score = 0 },
            Recapture = new() { Applicable = true, Score = 0 },
        };
        double expectedConfidence = 0;
        string expectedError = "error";
        long expectedPageCount = 1;
        List<VerifyListResponseResultPageDimension> expectedPageDimensions =
        [
            new()
            {
                Height = 0,
                Page = 0,
                Width = 0,
            },
        ];
        string expectedReasoning = "reasoning";
        List<VerifyListResponseResultSuspectRegion> expectedSuspectRegions =
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
        ];
        double expectedSyntheticScore = 0;
        double expectedTamperingScore = 0;

        Assert.Equal(expectedDetectorVersion, deserialized.DetectorVersion);
        Assert.Equal(expectedOverallScore, deserialized.OverallScore);
        Assert.Equal(expectedVerdict, deserialized.Verdict);
        Assert.Equal(expectedCompositeScores, deserialized.CompositeScores);
        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedPageCount, deserialized.PageCount);
        Assert.NotNull(deserialized.PageDimensions);
        Assert.Equal(expectedPageDimensions.Count, deserialized.PageDimensions.Count);
        for (int i = 0; i < expectedPageDimensions.Count; i++)
        {
            Assert.Equal(expectedPageDimensions[i], deserialized.PageDimensions[i]);
        }
        Assert.Equal(expectedReasoning, deserialized.Reasoning);
        Assert.NotNull(deserialized.SuspectRegions);
        Assert.Equal(expectedSuspectRegions.Count, deserialized.SuspectRegions.Count);
        for (int i = 0; i < expectedSuspectRegions.Count; i++)
        {
            Assert.Equal(expectedSuspectRegions[i], deserialized.SuspectRegions[i]);
        }
        Assert.Equal(expectedSyntheticScore, deserialized.SyntheticScore);
        Assert.Equal(expectedTamperingScore, deserialized.TamperingScore);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerifyListResponseResult
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseResult
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyListResponseResultVerdict.Authentic,
            Error = "error",
            SyntheticScore = 0,
            TamperingScore = 0,
        };

        Assert.Null(model.CompositeScores);
        Assert.False(model.RawData.ContainsKey("composite_scores"));
        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.PageCount);
        Assert.False(model.RawData.ContainsKey("page_count"));
        Assert.Null(model.PageDimensions);
        Assert.False(model.RawData.ContainsKey("page_dimensions"));
        Assert.Null(model.Reasoning);
        Assert.False(model.RawData.ContainsKey("reasoning"));
        Assert.Null(model.SuspectRegions);
        Assert.False(model.RawData.ContainsKey("suspect_regions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseResult
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyListResponseResultVerdict.Authentic,
            Error = "error",
            SyntheticScore = 0,
            TamperingScore = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyListResponseResult
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyListResponseResultVerdict.Authentic,
            Error = "error",
            SyntheticScore = 0,
            TamperingScore = 0,

            // Null should be interpreted as omitted for these properties
            CompositeScores = null,
            Confidence = null,
            PageCount = null,
            PageDimensions = null,
            Reasoning = null,
            SuspectRegions = null,
        };

        Assert.Null(model.CompositeScores);
        Assert.False(model.RawData.ContainsKey("composite_scores"));
        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.PageCount);
        Assert.False(model.RawData.ContainsKey("page_count"));
        Assert.Null(model.PageDimensions);
        Assert.False(model.RawData.ContainsKey("page_dimensions"));
        Assert.Null(model.Reasoning);
        Assert.False(model.RawData.ContainsKey("reasoning"));
        Assert.Null(model.SuspectRegions);
        Assert.False(model.RawData.ContainsKey("suspect_regions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseResult
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyListResponseResultVerdict.Authentic,
            Error = "error",
            SyntheticScore = 0,
            TamperingScore = 0,

            // Null should be interpreted as omitted for these properties
            CompositeScores = null,
            Confidence = null,
            PageCount = null,
            PageDimensions = null,
            Reasoning = null,
            SuspectRegions = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseResult
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
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.SyntheticScore);
        Assert.False(model.RawData.ContainsKey("synthetic_score"));
        Assert.Null(model.TamperingScore);
        Assert.False(model.RawData.ContainsKey("tampering_score"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseResult
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyListResponseResult
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

            Error = null,
            SyntheticScore = null,
            TamperingScore = null,
        };

        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
        Assert.Null(model.SyntheticScore);
        Assert.True(model.RawData.ContainsKey("synthetic_score"));
        Assert.Null(model.TamperingScore);
        Assert.True(model.RawData.ContainsKey("tampering_score"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseResult
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

            Error = null,
            SyntheticScore = null,
            TamperingScore = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyListResponseResult
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
        };

        VerifyListResponseResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyListResponseResultVerdictTest : TestBase
{
    [Theory]
    [InlineData(VerifyListResponseResultVerdict.Authentic)]
    [InlineData(VerifyListResponseResultVerdict.Doctored)]
    [InlineData(VerifyListResponseResultVerdict.LikelyDoctored)]
    [InlineData(VerifyListResponseResultVerdict.NoStrongSignal)]
    [InlineData(VerifyListResponseResultVerdict.Suspicious)]
    public void Validation_Works(VerifyListResponseResultVerdict rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifyListResponseResultVerdict> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerifyListResponseResultVerdict>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerifyListResponseResultVerdict.Authentic)]
    [InlineData(VerifyListResponseResultVerdict.Doctored)]
    [InlineData(VerifyListResponseResultVerdict.LikelyDoctored)]
    [InlineData(VerifyListResponseResultVerdict.NoStrongSignal)]
    [InlineData(VerifyListResponseResultVerdict.Suspicious)]
    public void SerializationRoundtrip_Works(VerifyListResponseResultVerdict rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifyListResponseResultVerdict> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyListResponseResultVerdict>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerifyListResponseResultVerdict>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyListResponseResultVerdict>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VerifyListResponseResultCompositeScoresTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyListResponseResultCompositeScores
        {
            AIGenerated = new() { Applicable = true, Score = 0 },
            DocumentCoherence = new() { Applicable = true, Score = 0 },
            DocumentMetadata = new() { Applicable = true, Score = 0 },
            KnownFraud = new() { Applicable = true, Score = 0 },
            ManuallyEdited = new() { Applicable = true, Score = 0 },
            Recapture = new() { Applicable = true, Score = 0 },
        };

        VerifyListResponseResultCompositeScoresAIGenerated expectedAIGenerated = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyListResponseResultCompositeScoresDocumentCoherence expectedDocumentCoherence = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyListResponseResultCompositeScoresDocumentMetadata expectedDocumentMetadata = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyListResponseResultCompositeScoresKnownFraud expectedKnownFraud = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyListResponseResultCompositeScoresManuallyEdited expectedManuallyEdited = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyListResponseResultCompositeScoresRecapture expectedRecapture = new()
        {
            Applicable = true,
            Score = 0,
        };

        Assert.Equal(expectedAIGenerated, model.AIGenerated);
        Assert.Equal(expectedDocumentCoherence, model.DocumentCoherence);
        Assert.Equal(expectedDocumentMetadata, model.DocumentMetadata);
        Assert.Equal(expectedKnownFraud, model.KnownFraud);
        Assert.Equal(expectedManuallyEdited, model.ManuallyEdited);
        Assert.Equal(expectedRecapture, model.Recapture);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerifyListResponseResultCompositeScores
        {
            AIGenerated = new() { Applicable = true, Score = 0 },
            DocumentCoherence = new() { Applicable = true, Score = 0 },
            DocumentMetadata = new() { Applicable = true, Score = 0 },
            KnownFraud = new() { Applicable = true, Score = 0 },
            ManuallyEdited = new() { Applicable = true, Score = 0 },
            Recapture = new() { Applicable = true, Score = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyListResponseResultCompositeScores>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyListResponseResultCompositeScores
        {
            AIGenerated = new() { Applicable = true, Score = 0 },
            DocumentCoherence = new() { Applicable = true, Score = 0 },
            DocumentMetadata = new() { Applicable = true, Score = 0 },
            KnownFraud = new() { Applicable = true, Score = 0 },
            ManuallyEdited = new() { Applicable = true, Score = 0 },
            Recapture = new() { Applicable = true, Score = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyListResponseResultCompositeScores>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        VerifyListResponseResultCompositeScoresAIGenerated expectedAIGenerated = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyListResponseResultCompositeScoresDocumentCoherence expectedDocumentCoherence = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyListResponseResultCompositeScoresDocumentMetadata expectedDocumentMetadata = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyListResponseResultCompositeScoresKnownFraud expectedKnownFraud = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyListResponseResultCompositeScoresManuallyEdited expectedManuallyEdited = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyListResponseResultCompositeScoresRecapture expectedRecapture = new()
        {
            Applicable = true,
            Score = 0,
        };

        Assert.Equal(expectedAIGenerated, deserialized.AIGenerated);
        Assert.Equal(expectedDocumentCoherence, deserialized.DocumentCoherence);
        Assert.Equal(expectedDocumentMetadata, deserialized.DocumentMetadata);
        Assert.Equal(expectedKnownFraud, deserialized.KnownFraud);
        Assert.Equal(expectedManuallyEdited, deserialized.ManuallyEdited);
        Assert.Equal(expectedRecapture, deserialized.Recapture);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerifyListResponseResultCompositeScores
        {
            AIGenerated = new() { Applicable = true, Score = 0 },
            DocumentCoherence = new() { Applicable = true, Score = 0 },
            DocumentMetadata = new() { Applicable = true, Score = 0 },
            KnownFraud = new() { Applicable = true, Score = 0 },
            ManuallyEdited = new() { Applicable = true, Score = 0 },
            Recapture = new() { Applicable = true, Score = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScores { };

        Assert.Null(model.AIGenerated);
        Assert.False(model.RawData.ContainsKey("ai_generated"));
        Assert.Null(model.DocumentCoherence);
        Assert.False(model.RawData.ContainsKey("document_coherence"));
        Assert.Null(model.DocumentMetadata);
        Assert.False(model.RawData.ContainsKey("document_metadata"));
        Assert.Null(model.KnownFraud);
        Assert.False(model.RawData.ContainsKey("known_fraud"));
        Assert.Null(model.ManuallyEdited);
        Assert.False(model.RawData.ContainsKey("manually_edited"));
        Assert.Null(model.Recapture);
        Assert.False(model.RawData.ContainsKey("recapture"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScores { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScores
        {
            // Null should be interpreted as omitted for these properties
            AIGenerated = null,
            DocumentCoherence = null,
            DocumentMetadata = null,
            KnownFraud = null,
            ManuallyEdited = null,
            Recapture = null,
        };

        Assert.Null(model.AIGenerated);
        Assert.False(model.RawData.ContainsKey("ai_generated"));
        Assert.Null(model.DocumentCoherence);
        Assert.False(model.RawData.ContainsKey("document_coherence"));
        Assert.Null(model.DocumentMetadata);
        Assert.False(model.RawData.ContainsKey("document_metadata"));
        Assert.Null(model.KnownFraud);
        Assert.False(model.RawData.ContainsKey("known_fraud"));
        Assert.Null(model.ManuallyEdited);
        Assert.False(model.RawData.ContainsKey("manually_edited"));
        Assert.Null(model.Recapture);
        Assert.False(model.RawData.ContainsKey("recapture"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScores
        {
            // Null should be interpreted as omitted for these properties
            AIGenerated = null,
            DocumentCoherence = null,
            DocumentMetadata = null,
            KnownFraud = null,
            ManuallyEdited = null,
            Recapture = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyListResponseResultCompositeScores
        {
            AIGenerated = new() { Applicable = true, Score = 0 },
            DocumentCoherence = new() { Applicable = true, Score = 0 },
            DocumentMetadata = new() { Applicable = true, Score = 0 },
            KnownFraud = new() { Applicable = true, Score = 0 },
            ManuallyEdited = new() { Applicable = true, Score = 0 },
            Recapture = new() { Applicable = true, Score = 0 },
        };

        VerifyListResponseResultCompositeScores copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyListResponseResultCompositeScoresAIGeneratedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresAIGenerated
        {
            Applicable = true,
            Score = 0,
        };

        bool expectedApplicable = true;
        double expectedScore = 0;

        Assert.Equal(expectedApplicable, model.Applicable);
        Assert.Equal(expectedScore, model.Score);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresAIGenerated
        {
            Applicable = true,
            Score = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyListResponseResultCompositeScoresAIGenerated>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresAIGenerated
        {
            Applicable = true,
            Score = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyListResponseResultCompositeScoresAIGenerated>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        bool expectedApplicable = true;
        double expectedScore = 0;

        Assert.Equal(expectedApplicable, deserialized.Applicable);
        Assert.Equal(expectedScore, deserialized.Score);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresAIGenerated
        {
            Applicable = true,
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresAIGenerated { Score = 0 };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresAIGenerated { Score = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresAIGenerated
        {
            Score = 0,

            // Null should be interpreted as omitted for these properties
            Applicable = null,
        };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresAIGenerated
        {
            Score = 0,

            // Null should be interpreted as omitted for these properties
            Applicable = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresAIGenerated { Applicable = true };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresAIGenerated { Applicable = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresAIGenerated
        {
            Applicable = true,

            Score = null,
        };

        Assert.Null(model.Score);
        Assert.True(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresAIGenerated
        {
            Applicable = true,

            Score = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresAIGenerated
        {
            Applicable = true,
            Score = 0,
        };

        VerifyListResponseResultCompositeScoresAIGenerated copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyListResponseResultCompositeScoresDocumentCoherenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentCoherence
        {
            Applicable = true,
            Score = 0,
        };

        bool expectedApplicable = true;
        double expectedScore = 0;

        Assert.Equal(expectedApplicable, model.Applicable);
        Assert.Equal(expectedScore, model.Score);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentCoherence
        {
            Applicable = true,
            Score = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyListResponseResultCompositeScoresDocumentCoherence>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentCoherence
        {
            Applicable = true,
            Score = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyListResponseResultCompositeScoresDocumentCoherence>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        bool expectedApplicable = true;
        double expectedScore = 0;

        Assert.Equal(expectedApplicable, deserialized.Applicable);
        Assert.Equal(expectedScore, deserialized.Score);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentCoherence
        {
            Applicable = true,
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentCoherence { Score = 0 };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentCoherence { Score = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentCoherence
        {
            Score = 0,

            // Null should be interpreted as omitted for these properties
            Applicable = null,
        };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentCoherence
        {
            Score = 0,

            // Null should be interpreted as omitted for these properties
            Applicable = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentCoherence
        {
            Applicable = true,
        };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentCoherence
        {
            Applicable = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentCoherence
        {
            Applicable = true,

            Score = null,
        };

        Assert.Null(model.Score);
        Assert.True(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentCoherence
        {
            Applicable = true,

            Score = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentCoherence
        {
            Applicable = true,
            Score = 0,
        };

        VerifyListResponseResultCompositeScoresDocumentCoherence copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyListResponseResultCompositeScoresDocumentMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentMetadata
        {
            Applicable = true,
            Score = 0,
        };

        bool expectedApplicable = true;
        double expectedScore = 0;

        Assert.Equal(expectedApplicable, model.Applicable);
        Assert.Equal(expectedScore, model.Score);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentMetadata
        {
            Applicable = true,
            Score = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyListResponseResultCompositeScoresDocumentMetadata>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentMetadata
        {
            Applicable = true,
            Score = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyListResponseResultCompositeScoresDocumentMetadata>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        bool expectedApplicable = true;
        double expectedScore = 0;

        Assert.Equal(expectedApplicable, deserialized.Applicable);
        Assert.Equal(expectedScore, deserialized.Score);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentMetadata
        {
            Applicable = true,
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentMetadata { Score = 0 };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentMetadata { Score = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentMetadata
        {
            Score = 0,

            // Null should be interpreted as omitted for these properties
            Applicable = null,
        };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentMetadata
        {
            Score = 0,

            // Null should be interpreted as omitted for these properties
            Applicable = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentMetadata
        {
            Applicable = true,
        };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentMetadata
        {
            Applicable = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentMetadata
        {
            Applicable = true,

            Score = null,
        };

        Assert.Null(model.Score);
        Assert.True(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentMetadata
        {
            Applicable = true,

            Score = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresDocumentMetadata
        {
            Applicable = true,
            Score = 0,
        };

        VerifyListResponseResultCompositeScoresDocumentMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyListResponseResultCompositeScoresKnownFraudTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresKnownFraud
        {
            Applicable = true,
            Score = 0,
        };

        bool expectedApplicable = true;
        double expectedScore = 0;

        Assert.Equal(expectedApplicable, model.Applicable);
        Assert.Equal(expectedScore, model.Score);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresKnownFraud
        {
            Applicable = true,
            Score = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyListResponseResultCompositeScoresKnownFraud>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresKnownFraud
        {
            Applicable = true,
            Score = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyListResponseResultCompositeScoresKnownFraud>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        bool expectedApplicable = true;
        double expectedScore = 0;

        Assert.Equal(expectedApplicable, deserialized.Applicable);
        Assert.Equal(expectedScore, deserialized.Score);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresKnownFraud
        {
            Applicable = true,
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresKnownFraud { Score = 0 };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresKnownFraud { Score = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresKnownFraud
        {
            Score = 0,

            // Null should be interpreted as omitted for these properties
            Applicable = null,
        };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresKnownFraud
        {
            Score = 0,

            // Null should be interpreted as omitted for these properties
            Applicable = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresKnownFraud { Applicable = true };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresKnownFraud { Applicable = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresKnownFraud
        {
            Applicable = true,

            Score = null,
        };

        Assert.Null(model.Score);
        Assert.True(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresKnownFraud
        {
            Applicable = true,

            Score = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresKnownFraud
        {
            Applicable = true,
            Score = 0,
        };

        VerifyListResponseResultCompositeScoresKnownFraud copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyListResponseResultCompositeScoresManuallyEditedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresManuallyEdited
        {
            Applicable = true,
            Score = 0,
        };

        bool expectedApplicable = true;
        double expectedScore = 0;

        Assert.Equal(expectedApplicable, model.Applicable);
        Assert.Equal(expectedScore, model.Score);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresManuallyEdited
        {
            Applicable = true,
            Score = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyListResponseResultCompositeScoresManuallyEdited>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresManuallyEdited
        {
            Applicable = true,
            Score = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyListResponseResultCompositeScoresManuallyEdited>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        bool expectedApplicable = true;
        double expectedScore = 0;

        Assert.Equal(expectedApplicable, deserialized.Applicable);
        Assert.Equal(expectedScore, deserialized.Score);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresManuallyEdited
        {
            Applicable = true,
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresManuallyEdited { Score = 0 };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresManuallyEdited { Score = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresManuallyEdited
        {
            Score = 0,

            // Null should be interpreted as omitted for these properties
            Applicable = null,
        };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresManuallyEdited
        {
            Score = 0,

            // Null should be interpreted as omitted for these properties
            Applicable = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresManuallyEdited { Applicable = true };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresManuallyEdited { Applicable = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresManuallyEdited
        {
            Applicable = true,

            Score = null,
        };

        Assert.Null(model.Score);
        Assert.True(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresManuallyEdited
        {
            Applicable = true,

            Score = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresManuallyEdited
        {
            Applicable = true,
            Score = 0,
        };

        VerifyListResponseResultCompositeScoresManuallyEdited copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyListResponseResultCompositeScoresRecaptureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresRecapture
        {
            Applicable = true,
            Score = 0,
        };

        bool expectedApplicable = true;
        double expectedScore = 0;

        Assert.Equal(expectedApplicable, model.Applicable);
        Assert.Equal(expectedScore, model.Score);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresRecapture
        {
            Applicable = true,
            Score = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyListResponseResultCompositeScoresRecapture>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresRecapture
        {
            Applicable = true,
            Score = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyListResponseResultCompositeScoresRecapture>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        bool expectedApplicable = true;
        double expectedScore = 0;

        Assert.Equal(expectedApplicable, deserialized.Applicable);
        Assert.Equal(expectedScore, deserialized.Score);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresRecapture
        {
            Applicable = true,
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresRecapture { Score = 0 };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresRecapture { Score = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresRecapture
        {
            Score = 0,

            // Null should be interpreted as omitted for these properties
            Applicable = null,
        };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresRecapture
        {
            Score = 0,

            // Null should be interpreted as omitted for these properties
            Applicable = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresRecapture { Applicable = true };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresRecapture { Applicable = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresRecapture
        {
            Applicable = true,

            Score = null,
        };

        Assert.Null(model.Score);
        Assert.True(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresRecapture
        {
            Applicable = true,

            Score = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyListResponseResultCompositeScoresRecapture
        {
            Applicable = true,
            Score = 0,
        };

        VerifyListResponseResultCompositeScoresRecapture copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyListResponseResultPageDimensionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyListResponseResultPageDimension
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
        var model = new VerifyListResponseResultPageDimension
        {
            Height = 0,
            Page = 0,
            Width = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyListResponseResultPageDimension>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyListResponseResultPageDimension
        {
            Height = 0,
            Page = 0,
            Width = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyListResponseResultPageDimension>(
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
        var model = new VerifyListResponseResultPageDimension
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
        var model = new VerifyListResponseResultPageDimension
        {
            Height = 0,
            Page = 0,
            Width = 0,
        };

        VerifyListResponseResultPageDimension copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyListResponseResultSuspectRegionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyListResponseResultSuspectRegion
        {
            Bbox = [0, 0, 0, 0],
            Explanation = "explanation",
            Kind = "kind",
            Page = 0,
            Score = 0,
            Source = "source",
            Primary = true,
            Review = "review",
        };

        List<long> expectedBbox = [0, 0, 0, 0];
        string expectedExplanation = "explanation";
        string expectedKind = "kind";
        long expectedPage = 0;
        double expectedScore = 0;
        string expectedSource = "source";
        bool expectedPrimary = true;
        string expectedReview = "review";

        Assert.Equal(expectedBbox.Count, model.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], model.Bbox[i]);
        }
        Assert.Equal(expectedExplanation, model.Explanation);
        Assert.Equal(expectedKind, model.Kind);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedScore, model.Score);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedPrimary, model.Primary);
        Assert.Equal(expectedReview, model.Review);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerifyListResponseResultSuspectRegion
        {
            Bbox = [0, 0, 0, 0],
            Explanation = "explanation",
            Kind = "kind",
            Page = 0,
            Score = 0,
            Source = "source",
            Primary = true,
            Review = "review",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyListResponseResultSuspectRegion>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyListResponseResultSuspectRegion
        {
            Bbox = [0, 0, 0, 0],
            Explanation = "explanation",
            Kind = "kind",
            Page = 0,
            Score = 0,
            Source = "source",
            Primary = true,
            Review = "review",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyListResponseResultSuspectRegion>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<long> expectedBbox = [0, 0, 0, 0];
        string expectedExplanation = "explanation";
        string expectedKind = "kind";
        long expectedPage = 0;
        double expectedScore = 0;
        string expectedSource = "source";
        bool expectedPrimary = true;
        string expectedReview = "review";

        Assert.Equal(expectedBbox.Count, deserialized.Bbox.Count);
        for (int i = 0; i < expectedBbox.Count; i++)
        {
            Assert.Equal(expectedBbox[i], deserialized.Bbox[i]);
        }
        Assert.Equal(expectedExplanation, deserialized.Explanation);
        Assert.Equal(expectedKind, deserialized.Kind);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedScore, deserialized.Score);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedPrimary, deserialized.Primary);
        Assert.Equal(expectedReview, deserialized.Review);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerifyListResponseResultSuspectRegion
        {
            Bbox = [0, 0, 0, 0],
            Explanation = "explanation",
            Kind = "kind",
            Page = 0,
            Score = 0,
            Source = "source",
            Primary = true,
            Review = "review",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyListResponseResultSuspectRegion
        {
            Bbox = [0, 0, 0, 0],
            Explanation = "explanation",
            Kind = "kind",
            Page = 0,
            Score = 0,
            Source = "source",
        };

        Assert.Null(model.Primary);
        Assert.False(model.RawData.ContainsKey("primary"));
        Assert.Null(model.Review);
        Assert.False(model.RawData.ContainsKey("review"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyListResponseResultSuspectRegion
        {
            Bbox = [0, 0, 0, 0],
            Explanation = "explanation",
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
        var model = new VerifyListResponseResultSuspectRegion
        {
            Bbox = [0, 0, 0, 0],
            Explanation = "explanation",
            Kind = "kind",
            Page = 0,
            Score = 0,
            Source = "source",

            // Null should be interpreted as omitted for these properties
            Primary = null,
            Review = null,
        };

        Assert.Null(model.Primary);
        Assert.False(model.RawData.ContainsKey("primary"));
        Assert.Null(model.Review);
        Assert.False(model.RawData.ContainsKey("review"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyListResponseResultSuspectRegion
        {
            Bbox = [0, 0, 0, 0],
            Explanation = "explanation",
            Kind = "kind",
            Page = 0,
            Score = 0,
            Source = "source",

            // Null should be interpreted as omitted for these properties
            Primary = null,
            Review = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyListResponseResultSuspectRegion
        {
            Bbox = [0, 0, 0, 0],
            Explanation = "explanation",
            Kind = "kind",
            Page = 0,
            Score = 0,
            Source = "source",
            Primary = true,
            Review = "review",
        };

        VerifyListResponseResultSuspectRegion copied = new(model);

        Assert.Equal(model, copied);
    }
}
