using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Alpha.Verify;

namespace LlamaCloud.Tests.Models.Alpha.Verify;

public class VerifyCancelResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyCancelResponse
        {
            ID = "id",
            Configuration = new()
            {
                TargetPages = "1,3,5-7",
                Tier = VerifyCancelResponseConfigurationTier.Agentic,
            },
            DocumentInputType = VerifyCancelResponseDocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = VerifyCancelResponseStatus.Cancelled,
            UserID = "user_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            Result = new()
            {
                DetectorVersion = "detector_version",
                OverallScore = 0,
                Verdict = VerifyCancelResponseResultVerdict.Authentic,
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
        VerifyCancelResponseConfiguration expectedConfiguration = new()
        {
            TargetPages = "1,3,5-7",
            Tier = VerifyCancelResponseConfigurationTier.Agentic,
        };
        ApiEnum<string, VerifyCancelResponseDocumentInputType> expectedDocumentInputType =
            VerifyCancelResponseDocumentInputType.FileID;
        string expectedFileInput = "file_input";
        string expectedProjectID = "project_id";
        ApiEnum<string, VerifyCancelResponseStatus> expectedStatus =
            VerifyCancelResponseStatus.Cancelled;
        string expectedUserID = "user_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        VerifyCancelResponseResult expectedResult = new()
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyCancelResponseResultVerdict.Authentic,
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
        var model = new VerifyCancelResponse
        {
            ID = "id",
            Configuration = new()
            {
                TargetPages = "1,3,5-7",
                Tier = VerifyCancelResponseConfigurationTier.Agentic,
            },
            DocumentInputType = VerifyCancelResponseDocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = VerifyCancelResponseStatus.Cancelled,
            UserID = "user_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            Result = new()
            {
                DetectorVersion = "detector_version",
                OverallScore = 0,
                Verdict = VerifyCancelResponseResultVerdict.Authentic,
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
        var deserialized = JsonSerializer.Deserialize<VerifyCancelResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyCancelResponse
        {
            ID = "id",
            Configuration = new()
            {
                TargetPages = "1,3,5-7",
                Tier = VerifyCancelResponseConfigurationTier.Agentic,
            },
            DocumentInputType = VerifyCancelResponseDocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = VerifyCancelResponseStatus.Cancelled,
            UserID = "user_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            Result = new()
            {
                DetectorVersion = "detector_version",
                OverallScore = 0,
                Verdict = VerifyCancelResponseResultVerdict.Authentic,
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
        var deserialized = JsonSerializer.Deserialize<VerifyCancelResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        VerifyCancelResponseConfiguration expectedConfiguration = new()
        {
            TargetPages = "1,3,5-7",
            Tier = VerifyCancelResponseConfigurationTier.Agentic,
        };
        ApiEnum<string, VerifyCancelResponseDocumentInputType> expectedDocumentInputType =
            VerifyCancelResponseDocumentInputType.FileID;
        string expectedFileInput = "file_input";
        string expectedProjectID = "project_id";
        ApiEnum<string, VerifyCancelResponseStatus> expectedStatus =
            VerifyCancelResponseStatus.Cancelled;
        string expectedUserID = "user_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        VerifyCancelResponseResult expectedResult = new()
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyCancelResponseResultVerdict.Authentic,
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
        var model = new VerifyCancelResponse
        {
            ID = "id",
            Configuration = new()
            {
                TargetPages = "1,3,5-7",
                Tier = VerifyCancelResponseConfigurationTier.Agentic,
            },
            DocumentInputType = VerifyCancelResponseDocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = VerifyCancelResponseStatus.Cancelled,
            UserID = "user_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            Result = new()
            {
                DetectorVersion = "detector_version",
                OverallScore = 0,
                Verdict = VerifyCancelResponseResultVerdict.Authentic,
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
        var model = new VerifyCancelResponse
        {
            ID = "id",
            Configuration = new()
            {
                TargetPages = "1,3,5-7",
                Tier = VerifyCancelResponseConfigurationTier.Agentic,
            },
            DocumentInputType = VerifyCancelResponseDocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = VerifyCancelResponseStatus.Cancelled,
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
        var model = new VerifyCancelResponse
        {
            ID = "id",
            Configuration = new()
            {
                TargetPages = "1,3,5-7",
                Tier = VerifyCancelResponseConfigurationTier.Agentic,
            },
            DocumentInputType = VerifyCancelResponseDocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = VerifyCancelResponseStatus.Cancelled,
            UserID = "user_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyCancelResponse
        {
            ID = "id",
            Configuration = new()
            {
                TargetPages = "1,3,5-7",
                Tier = VerifyCancelResponseConfigurationTier.Agentic,
            },
            DocumentInputType = VerifyCancelResponseDocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = VerifyCancelResponseStatus.Cancelled,
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
        var model = new VerifyCancelResponse
        {
            ID = "id",
            Configuration = new()
            {
                TargetPages = "1,3,5-7",
                Tier = VerifyCancelResponseConfigurationTier.Agentic,
            },
            DocumentInputType = VerifyCancelResponseDocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = VerifyCancelResponseStatus.Cancelled,
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
        var model = new VerifyCancelResponse
        {
            ID = "id",
            Configuration = new()
            {
                TargetPages = "1,3,5-7",
                Tier = VerifyCancelResponseConfigurationTier.Agentic,
            },
            DocumentInputType = VerifyCancelResponseDocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = VerifyCancelResponseStatus.Cancelled,
            UserID = "user_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            Result = new()
            {
                DetectorVersion = "detector_version",
                OverallScore = 0,
                Verdict = VerifyCancelResponseResultVerdict.Authentic,
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

        VerifyCancelResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyCancelResponseConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyCancelResponseConfiguration
        {
            TargetPages = "1,3,5-7",
            Tier = VerifyCancelResponseConfigurationTier.Agentic,
        };

        string expectedTargetPages = "1,3,5-7";
        ApiEnum<string, VerifyCancelResponseConfigurationTier> expectedTier =
            VerifyCancelResponseConfigurationTier.Agentic;

        Assert.Equal(expectedTargetPages, model.TargetPages);
        Assert.Equal(expectedTier, model.Tier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new VerifyCancelResponseConfiguration
        {
            TargetPages = "1,3,5-7",
            Tier = VerifyCancelResponseConfigurationTier.Agentic,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyCancelResponseConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyCancelResponseConfiguration
        {
            TargetPages = "1,3,5-7",
            Tier = VerifyCancelResponseConfigurationTier.Agentic,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyCancelResponseConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTargetPages = "1,3,5-7";
        ApiEnum<string, VerifyCancelResponseConfigurationTier> expectedTier =
            VerifyCancelResponseConfigurationTier.Agentic;

        Assert.Equal(expectedTargetPages, deserialized.TargetPages);
        Assert.Equal(expectedTier, deserialized.Tier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new VerifyCancelResponseConfiguration
        {
            TargetPages = "1,3,5-7",
            Tier = VerifyCancelResponseConfigurationTier.Agentic,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyCancelResponseConfiguration { TargetPages = "1,3,5-7" };

        Assert.Null(model.Tier);
        Assert.False(model.RawData.ContainsKey("tier"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyCancelResponseConfiguration { TargetPages = "1,3,5-7" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyCancelResponseConfiguration
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
        var model = new VerifyCancelResponseConfiguration
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
        var model = new VerifyCancelResponseConfiguration
        {
            Tier = VerifyCancelResponseConfigurationTier.Agentic,
        };

        Assert.Null(model.TargetPages);
        Assert.False(model.RawData.ContainsKey("target_pages"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyCancelResponseConfiguration
        {
            Tier = VerifyCancelResponseConfigurationTier.Agentic,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyCancelResponseConfiguration
        {
            Tier = VerifyCancelResponseConfigurationTier.Agentic,

            TargetPages = null,
        };

        Assert.Null(model.TargetPages);
        Assert.True(model.RawData.ContainsKey("target_pages"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new VerifyCancelResponseConfiguration
        {
            Tier = VerifyCancelResponseConfigurationTier.Agentic,

            TargetPages = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyCancelResponseConfiguration
        {
            TargetPages = "1,3,5-7",
            Tier = VerifyCancelResponseConfigurationTier.Agentic,
        };

        VerifyCancelResponseConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyCancelResponseConfigurationTierTest : TestBase
{
    [Theory]
    [InlineData(VerifyCancelResponseConfigurationTier.Agentic)]
    [InlineData(VerifyCancelResponseConfigurationTier.Fast)]
    public void Validation_Works(VerifyCancelResponseConfigurationTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifyCancelResponseConfigurationTier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyCancelResponseConfigurationTier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerifyCancelResponseConfigurationTier.Agentic)]
    [InlineData(VerifyCancelResponseConfigurationTier.Fast)]
    public void SerializationRoundtrip_Works(VerifyCancelResponseConfigurationTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifyCancelResponseConfigurationTier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyCancelResponseConfigurationTier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyCancelResponseConfigurationTier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyCancelResponseConfigurationTier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VerifyCancelResponseDocumentInputTypeTest : TestBase
{
    [Theory]
    [InlineData(VerifyCancelResponseDocumentInputType.FileID)]
    [InlineData(VerifyCancelResponseDocumentInputType.ParseJobID)]
    [InlineData(VerifyCancelResponseDocumentInputType.Url)]
    public void Validation_Works(VerifyCancelResponseDocumentInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifyCancelResponseDocumentInputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyCancelResponseDocumentInputType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerifyCancelResponseDocumentInputType.FileID)]
    [InlineData(VerifyCancelResponseDocumentInputType.ParseJobID)]
    [InlineData(VerifyCancelResponseDocumentInputType.Url)]
    public void SerializationRoundtrip_Works(VerifyCancelResponseDocumentInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifyCancelResponseDocumentInputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyCancelResponseDocumentInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyCancelResponseDocumentInputType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyCancelResponseDocumentInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VerifyCancelResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(VerifyCancelResponseStatus.Cancelled)]
    [InlineData(VerifyCancelResponseStatus.Completed)]
    [InlineData(VerifyCancelResponseStatus.Failed)]
    [InlineData(VerifyCancelResponseStatus.Pending)]
    [InlineData(VerifyCancelResponseStatus.Running)]
    public void Validation_Works(VerifyCancelResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifyCancelResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerifyCancelResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerifyCancelResponseStatus.Cancelled)]
    [InlineData(VerifyCancelResponseStatus.Completed)]
    [InlineData(VerifyCancelResponseStatus.Failed)]
    [InlineData(VerifyCancelResponseStatus.Pending)]
    [InlineData(VerifyCancelResponseStatus.Running)]
    public void SerializationRoundtrip_Works(VerifyCancelResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifyCancelResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VerifyCancelResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerifyCancelResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VerifyCancelResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VerifyCancelResponseResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyCancelResponseResult
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyCancelResponseResultVerdict.Authentic,
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
        ApiEnum<string, VerifyCancelResponseResultVerdict> expectedVerdict =
            VerifyCancelResponseResultVerdict.Authentic;
        VerifyCancelResponseResultCompositeScores expectedCompositeScores = new()
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
        List<VerifyCancelResponseResultPageDimension> expectedPageDimensions =
        [
            new()
            {
                Height = 0,
                Page = 0,
                Width = 0,
            },
        ];
        string expectedReasoning = "reasoning";
        List<VerifyCancelResponseResultSuspectRegion> expectedSuspectRegions =
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
        var model = new VerifyCancelResponseResult
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyCancelResponseResultVerdict.Authentic,
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
        var deserialized = JsonSerializer.Deserialize<VerifyCancelResponseResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyCancelResponseResult
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyCancelResponseResultVerdict.Authentic,
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
        var deserialized = JsonSerializer.Deserialize<VerifyCancelResponseResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDetectorVersion = "detector_version";
        double expectedOverallScore = 0;
        ApiEnum<string, VerifyCancelResponseResultVerdict> expectedVerdict =
            VerifyCancelResponseResultVerdict.Authentic;
        VerifyCancelResponseResultCompositeScores expectedCompositeScores = new()
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
        List<VerifyCancelResponseResultPageDimension> expectedPageDimensions =
        [
            new()
            {
                Height = 0,
                Page = 0,
                Width = 0,
            },
        ];
        string expectedReasoning = "reasoning";
        List<VerifyCancelResponseResultSuspectRegion> expectedSuspectRegions =
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
        var model = new VerifyCancelResponseResult
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyCancelResponseResultVerdict.Authentic,
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
        var model = new VerifyCancelResponseResult
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyCancelResponseResultVerdict.Authentic,
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
        var model = new VerifyCancelResponseResult
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyCancelResponseResultVerdict.Authentic,
            Error = "error",
            SyntheticScore = 0,
            TamperingScore = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyCancelResponseResult
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyCancelResponseResultVerdict.Authentic,
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
        var model = new VerifyCancelResponseResult
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyCancelResponseResultVerdict.Authentic,
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
        var model = new VerifyCancelResponseResult
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyCancelResponseResultVerdict.Authentic,
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
        var model = new VerifyCancelResponseResult
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyCancelResponseResultVerdict.Authentic,
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
        var model = new VerifyCancelResponseResult
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyCancelResponseResultVerdict.Authentic,
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
        var model = new VerifyCancelResponseResult
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyCancelResponseResultVerdict.Authentic,
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
        var model = new VerifyCancelResponseResult
        {
            DetectorVersion = "detector_version",
            OverallScore = 0,
            Verdict = VerifyCancelResponseResultVerdict.Authentic,
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

        VerifyCancelResponseResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyCancelResponseResultVerdictTest : TestBase
{
    [Theory]
    [InlineData(VerifyCancelResponseResultVerdict.Authentic)]
    [InlineData(VerifyCancelResponseResultVerdict.Doctored)]
    [InlineData(VerifyCancelResponseResultVerdict.LikelyDoctored)]
    [InlineData(VerifyCancelResponseResultVerdict.NoStrongSignal)]
    [InlineData(VerifyCancelResponseResultVerdict.Suspicious)]
    public void Validation_Works(VerifyCancelResponseResultVerdict rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifyCancelResponseResultVerdict> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerifyCancelResponseResultVerdict>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VerifyCancelResponseResultVerdict.Authentic)]
    [InlineData(VerifyCancelResponseResultVerdict.Doctored)]
    [InlineData(VerifyCancelResponseResultVerdict.LikelyDoctored)]
    [InlineData(VerifyCancelResponseResultVerdict.NoStrongSignal)]
    [InlineData(VerifyCancelResponseResultVerdict.Suspicious)]
    public void SerializationRoundtrip_Works(VerifyCancelResponseResultVerdict rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VerifyCancelResponseResultVerdict> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyCancelResponseResultVerdict>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VerifyCancelResponseResultVerdict>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, VerifyCancelResponseResultVerdict>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class VerifyCancelResponseResultCompositeScoresTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScores
        {
            AIGenerated = new() { Applicable = true, Score = 0 },
            DocumentCoherence = new() { Applicable = true, Score = 0 },
            DocumentMetadata = new() { Applicable = true, Score = 0 },
            KnownFraud = new() { Applicable = true, Score = 0 },
            ManuallyEdited = new() { Applicable = true, Score = 0 },
            Recapture = new() { Applicable = true, Score = 0 },
        };

        VerifyCancelResponseResultCompositeScoresAIGenerated expectedAIGenerated = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyCancelResponseResultCompositeScoresDocumentCoherence expectedDocumentCoherence = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyCancelResponseResultCompositeScoresDocumentMetadata expectedDocumentMetadata = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyCancelResponseResultCompositeScoresKnownFraud expectedKnownFraud = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyCancelResponseResultCompositeScoresManuallyEdited expectedManuallyEdited = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyCancelResponseResultCompositeScoresRecapture expectedRecapture = new()
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
        var model = new VerifyCancelResponseResultCompositeScores
        {
            AIGenerated = new() { Applicable = true, Score = 0 },
            DocumentCoherence = new() { Applicable = true, Score = 0 },
            DocumentMetadata = new() { Applicable = true, Score = 0 },
            KnownFraud = new() { Applicable = true, Score = 0 },
            ManuallyEdited = new() { Applicable = true, Score = 0 },
            Recapture = new() { Applicable = true, Score = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyCancelResponseResultCompositeScores>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScores
        {
            AIGenerated = new() { Applicable = true, Score = 0 },
            DocumentCoherence = new() { Applicable = true, Score = 0 },
            DocumentMetadata = new() { Applicable = true, Score = 0 },
            KnownFraud = new() { Applicable = true, Score = 0 },
            ManuallyEdited = new() { Applicable = true, Score = 0 },
            Recapture = new() { Applicable = true, Score = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyCancelResponseResultCompositeScores>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        VerifyCancelResponseResultCompositeScoresAIGenerated expectedAIGenerated = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyCancelResponseResultCompositeScoresDocumentCoherence expectedDocumentCoherence = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyCancelResponseResultCompositeScoresDocumentMetadata expectedDocumentMetadata = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyCancelResponseResultCompositeScoresKnownFraud expectedKnownFraud = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyCancelResponseResultCompositeScoresManuallyEdited expectedManuallyEdited = new()
        {
            Applicable = true,
            Score = 0,
        };
        VerifyCancelResponseResultCompositeScoresRecapture expectedRecapture = new()
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
        var model = new VerifyCancelResponseResultCompositeScores
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
        var model = new VerifyCancelResponseResultCompositeScores { };

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
        var model = new VerifyCancelResponseResultCompositeScores { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScores
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
        var model = new VerifyCancelResponseResultCompositeScores
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
        var model = new VerifyCancelResponseResultCompositeScores
        {
            AIGenerated = new() { Applicable = true, Score = 0 },
            DocumentCoherence = new() { Applicable = true, Score = 0 },
            DocumentMetadata = new() { Applicable = true, Score = 0 },
            KnownFraud = new() { Applicable = true, Score = 0 },
            ManuallyEdited = new() { Applicable = true, Score = 0 },
            Recapture = new() { Applicable = true, Score = 0 },
        };

        VerifyCancelResponseResultCompositeScores copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyCancelResponseResultCompositeScoresAIGeneratedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresAIGenerated
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
        var model = new VerifyCancelResponseResultCompositeScoresAIGenerated
        {
            Applicable = true,
            Score = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyCancelResponseResultCompositeScoresAIGenerated>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresAIGenerated
        {
            Applicable = true,
            Score = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyCancelResponseResultCompositeScoresAIGenerated>(
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
        var model = new VerifyCancelResponseResultCompositeScoresAIGenerated
        {
            Applicable = true,
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresAIGenerated { Score = 0 };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresAIGenerated { Score = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresAIGenerated
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
        var model = new VerifyCancelResponseResultCompositeScoresAIGenerated
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
        var model = new VerifyCancelResponseResultCompositeScoresAIGenerated { Applicable = true };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresAIGenerated { Applicable = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresAIGenerated
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
        var model = new VerifyCancelResponseResultCompositeScoresAIGenerated
        {
            Applicable = true,

            Score = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresAIGenerated
        {
            Applicable = true,
            Score = 0,
        };

        VerifyCancelResponseResultCompositeScoresAIGenerated copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyCancelResponseResultCompositeScoresDocumentCoherenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresDocumentCoherence
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
        var model = new VerifyCancelResponseResultCompositeScoresDocumentCoherence
        {
            Applicable = true,
            Score = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyCancelResponseResultCompositeScoresDocumentCoherence>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresDocumentCoherence
        {
            Applicable = true,
            Score = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyCancelResponseResultCompositeScoresDocumentCoherence>(
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
        var model = new VerifyCancelResponseResultCompositeScoresDocumentCoherence
        {
            Applicable = true,
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresDocumentCoherence { Score = 0 };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresDocumentCoherence { Score = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresDocumentCoherence
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
        var model = new VerifyCancelResponseResultCompositeScoresDocumentCoherence
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
        var model = new VerifyCancelResponseResultCompositeScoresDocumentCoherence
        {
            Applicable = true,
        };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresDocumentCoherence
        {
            Applicable = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresDocumentCoherence
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
        var model = new VerifyCancelResponseResultCompositeScoresDocumentCoherence
        {
            Applicable = true,

            Score = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresDocumentCoherence
        {
            Applicable = true,
            Score = 0,
        };

        VerifyCancelResponseResultCompositeScoresDocumentCoherence copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyCancelResponseResultCompositeScoresDocumentMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresDocumentMetadata
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
        var model = new VerifyCancelResponseResultCompositeScoresDocumentMetadata
        {
            Applicable = true,
            Score = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyCancelResponseResultCompositeScoresDocumentMetadata>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresDocumentMetadata
        {
            Applicable = true,
            Score = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyCancelResponseResultCompositeScoresDocumentMetadata>(
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
        var model = new VerifyCancelResponseResultCompositeScoresDocumentMetadata
        {
            Applicable = true,
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresDocumentMetadata { Score = 0 };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresDocumentMetadata { Score = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresDocumentMetadata
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
        var model = new VerifyCancelResponseResultCompositeScoresDocumentMetadata
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
        var model = new VerifyCancelResponseResultCompositeScoresDocumentMetadata
        {
            Applicable = true,
        };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresDocumentMetadata
        {
            Applicable = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresDocumentMetadata
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
        var model = new VerifyCancelResponseResultCompositeScoresDocumentMetadata
        {
            Applicable = true,

            Score = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresDocumentMetadata
        {
            Applicable = true,
            Score = 0,
        };

        VerifyCancelResponseResultCompositeScoresDocumentMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyCancelResponseResultCompositeScoresKnownFraudTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresKnownFraud
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
        var model = new VerifyCancelResponseResultCompositeScoresKnownFraud
        {
            Applicable = true,
            Score = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyCancelResponseResultCompositeScoresKnownFraud>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresKnownFraud
        {
            Applicable = true,
            Score = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyCancelResponseResultCompositeScoresKnownFraud>(
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
        var model = new VerifyCancelResponseResultCompositeScoresKnownFraud
        {
            Applicable = true,
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresKnownFraud { Score = 0 };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresKnownFraud { Score = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresKnownFraud
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
        var model = new VerifyCancelResponseResultCompositeScoresKnownFraud
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
        var model = new VerifyCancelResponseResultCompositeScoresKnownFraud { Applicable = true };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresKnownFraud { Applicable = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresKnownFraud
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
        var model = new VerifyCancelResponseResultCompositeScoresKnownFraud
        {
            Applicable = true,

            Score = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresKnownFraud
        {
            Applicable = true,
            Score = 0,
        };

        VerifyCancelResponseResultCompositeScoresKnownFraud copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyCancelResponseResultCompositeScoresManuallyEditedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresManuallyEdited
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
        var model = new VerifyCancelResponseResultCompositeScoresManuallyEdited
        {
            Applicable = true,
            Score = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyCancelResponseResultCompositeScoresManuallyEdited>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresManuallyEdited
        {
            Applicable = true,
            Score = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyCancelResponseResultCompositeScoresManuallyEdited>(
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
        var model = new VerifyCancelResponseResultCompositeScoresManuallyEdited
        {
            Applicable = true,
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresManuallyEdited { Score = 0 };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresManuallyEdited { Score = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresManuallyEdited
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
        var model = new VerifyCancelResponseResultCompositeScoresManuallyEdited
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
        var model = new VerifyCancelResponseResultCompositeScoresManuallyEdited
        {
            Applicable = true,
        };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresManuallyEdited
        {
            Applicable = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresManuallyEdited
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
        var model = new VerifyCancelResponseResultCompositeScoresManuallyEdited
        {
            Applicable = true,

            Score = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresManuallyEdited
        {
            Applicable = true,
            Score = 0,
        };

        VerifyCancelResponseResultCompositeScoresManuallyEdited copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyCancelResponseResultCompositeScoresRecaptureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresRecapture
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
        var model = new VerifyCancelResponseResultCompositeScoresRecapture
        {
            Applicable = true,
            Score = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyCancelResponseResultCompositeScoresRecapture>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresRecapture
        {
            Applicable = true,
            Score = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<VerifyCancelResponseResultCompositeScoresRecapture>(
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
        var model = new VerifyCancelResponseResultCompositeScoresRecapture
        {
            Applicable = true,
            Score = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresRecapture { Score = 0 };

        Assert.Null(model.Applicable);
        Assert.False(model.RawData.ContainsKey("applicable"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresRecapture { Score = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresRecapture
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
        var model = new VerifyCancelResponseResultCompositeScoresRecapture
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
        var model = new VerifyCancelResponseResultCompositeScoresRecapture { Applicable = true };

        Assert.Null(model.Score);
        Assert.False(model.RawData.ContainsKey("score"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresRecapture { Applicable = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresRecapture
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
        var model = new VerifyCancelResponseResultCompositeScoresRecapture
        {
            Applicable = true,

            Score = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new VerifyCancelResponseResultCompositeScoresRecapture
        {
            Applicable = true,
            Score = 0,
        };

        VerifyCancelResponseResultCompositeScoresRecapture copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyCancelResponseResultPageDimensionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyCancelResponseResultPageDimension
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
        var model = new VerifyCancelResponseResultPageDimension
        {
            Height = 0,
            Page = 0,
            Width = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyCancelResponseResultPageDimension>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyCancelResponseResultPageDimension
        {
            Height = 0,
            Page = 0,
            Width = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<VerifyCancelResponseResultPageDimension>(
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
        var model = new VerifyCancelResponseResultPageDimension
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
        var model = new VerifyCancelResponseResultPageDimension
        {
            Height = 0,
            Page = 0,
            Width = 0,
        };

        VerifyCancelResponseResultPageDimension copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerifyCancelResponseResultSuspectRegionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VerifyCancelResponseResultSuspectRegion
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
        var model = new VerifyCancelResponseResultSuspectRegion
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
        var deserialized = JsonSerializer.Deserialize<VerifyCancelResponseResultSuspectRegion>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new VerifyCancelResponseResultSuspectRegion
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
        var deserialized = JsonSerializer.Deserialize<VerifyCancelResponseResultSuspectRegion>(
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
        var model = new VerifyCancelResponseResultSuspectRegion
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
        var model = new VerifyCancelResponseResultSuspectRegion
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
        var model = new VerifyCancelResponseResultSuspectRegion
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
        var model = new VerifyCancelResponseResultSuspectRegion
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
        var model = new VerifyCancelResponseResultSuspectRegion
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
        var model = new VerifyCancelResponseResultSuspectRegion
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

        VerifyCancelResponseResultSuspectRegion copied = new(model);

        Assert.Equal(model, copied);
    }
}
