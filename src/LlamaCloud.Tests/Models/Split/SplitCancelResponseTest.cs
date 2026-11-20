using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Beta.Split;
using LlamaCloud.Models.Split;

namespace LlamaCloud.Tests.Models.Split;

public class SplitCancelResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitCancelResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitCancelResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            Version = "1.1.0",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            ParseConfigID = "parse_config_id",
            ParseTier = "parse_tier",
            Result = new(
                [
                    new()
                    {
                        Category = "category",
                        ConfidenceCategory = "confidence_category",
                        Pages = [0],
                    },
                ]
            ),
            SplittingStrategy = new()
            {
                AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
                SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
            },
            TargetPages = "target_pages",
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Warnings =
            [
                new()
                {
                    CategoryNames = ["string"],
                    Code = SplitCancelResponseWarningCode.CatchAllCategory,
                    Message = "message",
                },
            ],
        };

        string expectedID = "id";
        List<SplitCategory> expectedCategories = [new() { Name = "x", Description = "x" }];
        ApiEnum<string, SplitCancelResponseDocumentInputType> expectedDocumentInputType =
            SplitCancelResponseDocumentInputType.FileID;
        string expectedFileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedProjectID = "project_id";
        string expectedStatus = "status";
        string expectedUserID = "user_id";
        string expectedVersion = "1.1.0";
        string expectedConfigurationID = "configuration_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        string expectedParseConfigID = "parse_config_id";
        string expectedParseTier = "parse_tier";
        SplitResultResponse expectedResult = new(
            [
                new()
                {
                    Category = "category",
                    ConfidenceCategory = "confidence_category",
                    Pages = [0],
                },
            ]
        );
        SplitCancelResponseSplittingStrategy expectedSplittingStrategy = new()
        {
            AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
            SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
        };
        string expectedTargetPages = "target_pages";
        string expectedTransactionID = "transaction_id";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<SplitCancelResponseWarning> expectedWarnings =
        [
            new()
            {
                CategoryNames = ["string"],
                Code = SplitCancelResponseWarningCode.CatchAllCategory,
                Message = "message",
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCategories.Count, model.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], model.Categories[i]);
        }
        Assert.Equal(expectedDocumentInputType, model.DocumentInputType);
        Assert.Equal(expectedFileInput, model.FileInput);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedVersion, model.Version);
        Assert.Equal(expectedConfigurationID, model.ConfigurationID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedParseConfigID, model.ParseConfigID);
        Assert.Equal(expectedParseTier, model.ParseTier);
        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedSplittingStrategy, model.SplittingStrategy);
        Assert.Equal(expectedTargetPages, model.TargetPages);
        Assert.Equal(expectedTransactionID, model.TransactionID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.NotNull(model.Warnings);
        Assert.Equal(expectedWarnings.Count, model.Warnings.Count);
        for (int i = 0; i < expectedWarnings.Count; i++)
        {
            Assert.Equal(expectedWarnings[i], model.Warnings[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplitCancelResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitCancelResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            Version = "1.1.0",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            ParseConfigID = "parse_config_id",
            ParseTier = "parse_tier",
            Result = new(
                [
                    new()
                    {
                        Category = "category",
                        ConfidenceCategory = "confidence_category",
                        Pages = [0],
                    },
                ]
            ),
            SplittingStrategy = new()
            {
                AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
                SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
            },
            TargetPages = "target_pages",
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Warnings =
            [
                new()
                {
                    CategoryNames = ["string"],
                    Code = SplitCancelResponseWarningCode.CatchAllCategory,
                    Message = "message",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitCancelResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitCancelResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitCancelResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            Version = "1.1.0",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            ParseConfigID = "parse_config_id",
            ParseTier = "parse_tier",
            Result = new(
                [
                    new()
                    {
                        Category = "category",
                        ConfidenceCategory = "confidence_category",
                        Pages = [0],
                    },
                ]
            ),
            SplittingStrategy = new()
            {
                AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
                SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
            },
            TargetPages = "target_pages",
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Warnings =
            [
                new()
                {
                    CategoryNames = ["string"],
                    Code = SplitCancelResponseWarningCode.CatchAllCategory,
                    Message = "message",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitCancelResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<SplitCategory> expectedCategories = [new() { Name = "x", Description = "x" }];
        ApiEnum<string, SplitCancelResponseDocumentInputType> expectedDocumentInputType =
            SplitCancelResponseDocumentInputType.FileID;
        string expectedFileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedProjectID = "project_id";
        string expectedStatus = "status";
        string expectedUserID = "user_id";
        string expectedVersion = "1.1.0";
        string expectedConfigurationID = "configuration_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        string expectedParseConfigID = "parse_config_id";
        string expectedParseTier = "parse_tier";
        SplitResultResponse expectedResult = new(
            [
                new()
                {
                    Category = "category",
                    ConfidenceCategory = "confidence_category",
                    Pages = [0],
                },
            ]
        );
        SplitCancelResponseSplittingStrategy expectedSplittingStrategy = new()
        {
            AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
            SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
        };
        string expectedTargetPages = "target_pages";
        string expectedTransactionID = "transaction_id";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<SplitCancelResponseWarning> expectedWarnings =
        [
            new()
            {
                CategoryNames = ["string"],
                Code = SplitCancelResponseWarningCode.CatchAllCategory,
                Message = "message",
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCategories.Count, deserialized.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], deserialized.Categories[i]);
        }
        Assert.Equal(expectedDocumentInputType, deserialized.DocumentInputType);
        Assert.Equal(expectedFileInput, deserialized.FileInput);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedVersion, deserialized.Version);
        Assert.Equal(expectedConfigurationID, deserialized.ConfigurationID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedParseConfigID, deserialized.ParseConfigID);
        Assert.Equal(expectedParseTier, deserialized.ParseTier);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedSplittingStrategy, deserialized.SplittingStrategy);
        Assert.Equal(expectedTargetPages, deserialized.TargetPages);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.NotNull(deserialized.Warnings);
        Assert.Equal(expectedWarnings.Count, deserialized.Warnings.Count);
        for (int i = 0; i < expectedWarnings.Count; i++)
        {
            Assert.Equal(expectedWarnings[i], deserialized.Warnings[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SplitCancelResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitCancelResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            Version = "1.1.0",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            ParseConfigID = "parse_config_id",
            ParseTier = "parse_tier",
            Result = new(
                [
                    new()
                    {
                        Category = "category",
                        ConfidenceCategory = "confidence_category",
                        Pages = [0],
                    },
                ]
            ),
            SplittingStrategy = new()
            {
                AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
                SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
            },
            TargetPages = "target_pages",
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Warnings =
            [
                new()
                {
                    CategoryNames = ["string"],
                    Code = SplitCancelResponseWarningCode.CatchAllCategory,
                    Message = "message",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitCancelResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitCancelResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            Version = "1.1.0",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            ParseConfigID = "parse_config_id",
            ParseTier = "parse_tier",
            Result = new(
                [
                    new()
                    {
                        Category = "category",
                        ConfidenceCategory = "confidence_category",
                        Pages = [0],
                    },
                ]
            ),
            TargetPages = "target_pages",
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.SplittingStrategy);
        Assert.False(model.RawData.ContainsKey("splitting_strategy"));
        Assert.Null(model.Warnings);
        Assert.False(model.RawData.ContainsKey("warnings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplitCancelResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitCancelResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            Version = "1.1.0",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            ParseConfigID = "parse_config_id",
            ParseTier = "parse_tier",
            Result = new(
                [
                    new()
                    {
                        Category = "category",
                        ConfidenceCategory = "confidence_category",
                        Pages = [0],
                    },
                ]
            ),
            TargetPages = "target_pages",
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitCancelResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitCancelResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            Version = "1.1.0",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            ParseConfigID = "parse_config_id",
            ParseTier = "parse_tier",
            Result = new(
                [
                    new()
                    {
                        Category = "category",
                        ConfidenceCategory = "confidence_category",
                        Pages = [0],
                    },
                ]
            ),
            TargetPages = "target_pages",
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            SplittingStrategy = null,
            Warnings = null,
        };

        Assert.Null(model.SplittingStrategy);
        Assert.False(model.RawData.ContainsKey("splitting_strategy"));
        Assert.Null(model.Warnings);
        Assert.False(model.RawData.ContainsKey("warnings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SplitCancelResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitCancelResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            Version = "1.1.0",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            ParseConfigID = "parse_config_id",
            ParseTier = "parse_tier",
            Result = new(
                [
                    new()
                    {
                        Category = "category",
                        ConfidenceCategory = "confidence_category",
                        Pages = [0],
                    },
                ]
            ),
            TargetPages = "target_pages",
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            SplittingStrategy = null,
            Warnings = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitCancelResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitCancelResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            Version = "1.1.0",
            SplittingStrategy = new()
            {
                AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
                SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
            },
            Warnings =
            [
                new()
                {
                    CategoryNames = ["string"],
                    Code = SplitCancelResponseWarningCode.CatchAllCategory,
                    Message = "message",
                },
            ],
        };

        Assert.Null(model.ConfigurationID);
        Assert.False(model.RawData.ContainsKey("configuration_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.ParseConfigID);
        Assert.False(model.RawData.ContainsKey("parse_config_id"));
        Assert.Null(model.ParseTier);
        Assert.False(model.RawData.ContainsKey("parse_tier"));
        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
        Assert.Null(model.TargetPages);
        Assert.False(model.RawData.ContainsKey("target_pages"));
        Assert.Null(model.TransactionID);
        Assert.False(model.RawData.ContainsKey("transaction_id"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplitCancelResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitCancelResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            Version = "1.1.0",
            SplittingStrategy = new()
            {
                AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
                SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
            },
            Warnings =
            [
                new()
                {
                    CategoryNames = ["string"],
                    Code = SplitCancelResponseWarningCode.CatchAllCategory,
                    Message = "message",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SplitCancelResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitCancelResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            Version = "1.1.0",
            SplittingStrategy = new()
            {
                AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
                SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
            },
            Warnings =
            [
                new()
                {
                    CategoryNames = ["string"],
                    Code = SplitCancelResponseWarningCode.CatchAllCategory,
                    Message = "message",
                },
            ],

            ConfigurationID = null,
            CreatedAt = null,
            ErrorMessage = null,
            ParseConfigID = null,
            ParseTier = null,
            Result = null,
            TargetPages = null,
            TransactionID = null,
            UpdatedAt = null,
        };

        Assert.Null(model.ConfigurationID);
        Assert.True(model.RawData.ContainsKey("configuration_id"));
        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.ParseConfigID);
        Assert.True(model.RawData.ContainsKey("parse_config_id"));
        Assert.Null(model.ParseTier);
        Assert.True(model.RawData.ContainsKey("parse_tier"));
        Assert.Null(model.Result);
        Assert.True(model.RawData.ContainsKey("result"));
        Assert.Null(model.TargetPages);
        Assert.True(model.RawData.ContainsKey("target_pages"));
        Assert.Null(model.TransactionID);
        Assert.True(model.RawData.ContainsKey("transaction_id"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SplitCancelResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitCancelResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            Version = "1.1.0",
            SplittingStrategy = new()
            {
                AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
                SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
            },
            Warnings =
            [
                new()
                {
                    CategoryNames = ["string"],
                    Code = SplitCancelResponseWarningCode.CatchAllCategory,
                    Message = "message",
                },
            ],

            ConfigurationID = null,
            CreatedAt = null,
            ErrorMessage = null,
            ParseConfigID = null,
            ParseTier = null,
            Result = null,
            TargetPages = null,
            TransactionID = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplitCancelResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitCancelResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            Version = "1.1.0",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            ParseConfigID = "parse_config_id",
            ParseTier = "parse_tier",
            Result = new(
                [
                    new()
                    {
                        Category = "category",
                        ConfidenceCategory = "confidence_category",
                        Pages = [0],
                    },
                ]
            ),
            SplittingStrategy = new()
            {
                AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
                SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
            },
            TargetPages = "target_pages",
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Warnings =
            [
                new()
                {
                    CategoryNames = ["string"],
                    Code = SplitCancelResponseWarningCode.CatchAllCategory,
                    Message = "message",
                },
            ],
        };

        SplitCancelResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitCancelResponseDocumentInputTypeTest : TestBase
{
    [Theory]
    [InlineData(SplitCancelResponseDocumentInputType.FileID)]
    [InlineData(SplitCancelResponseDocumentInputType.ParseJobID)]
    [InlineData(SplitCancelResponseDocumentInputType.Url)]
    public void Validation_Works(SplitCancelResponseDocumentInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitCancelResponseDocumentInputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCancelResponseDocumentInputType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SplitCancelResponseDocumentInputType.FileID)]
    [InlineData(SplitCancelResponseDocumentInputType.ParseJobID)]
    [InlineData(SplitCancelResponseDocumentInputType.Url)]
    public void SerializationRoundtrip_Works(SplitCancelResponseDocumentInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitCancelResponseDocumentInputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCancelResponseDocumentInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCancelResponseDocumentInputType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCancelResponseDocumentInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SplitCancelResponseSplittingStrategyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitCancelResponseSplittingStrategy
        {
            AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
            SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
        };

        ApiEnum<
            string,
            SplitCancelResponseSplittingStrategyAllowUncategorized
        > expectedAllowUncategorized =
            SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid;
        string expectedCustomInstructions = "Start a new segment at every signature page.";
        long expectedMinPagesPerSplit = 1;
        ApiEnum<
            string,
            SplitCancelResponseSplittingStrategySegmentBoundary
        > expectedSegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category;

        Assert.Equal(expectedAllowUncategorized, model.AllowUncategorized);
        Assert.Equal(expectedCustomInstructions, model.CustomInstructions);
        Assert.Equal(expectedMinPagesPerSplit, model.MinPagesPerSplit);
        Assert.Equal(expectedSegmentBoundary, model.SegmentBoundary);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplitCancelResponseSplittingStrategy
        {
            AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
            SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitCancelResponseSplittingStrategy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitCancelResponseSplittingStrategy
        {
            AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
            SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitCancelResponseSplittingStrategy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            SplitCancelResponseSplittingStrategyAllowUncategorized
        > expectedAllowUncategorized =
            SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid;
        string expectedCustomInstructions = "Start a new segment at every signature page.";
        long expectedMinPagesPerSplit = 1;
        ApiEnum<
            string,
            SplitCancelResponseSplittingStrategySegmentBoundary
        > expectedSegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category;

        Assert.Equal(expectedAllowUncategorized, deserialized.AllowUncategorized);
        Assert.Equal(expectedCustomInstructions, deserialized.CustomInstructions);
        Assert.Equal(expectedMinPagesPerSplit, deserialized.MinPagesPerSplit);
        Assert.Equal(expectedSegmentBoundary, deserialized.SegmentBoundary);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SplitCancelResponseSplittingStrategy
        {
            AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
            SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitCancelResponseSplittingStrategy
        {
            CustomInstructions = "Start a new segment at every signature page.",
            SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
        };

        Assert.Null(model.AllowUncategorized);
        Assert.False(model.RawData.ContainsKey("allow_uncategorized"));
        Assert.Null(model.MinPagesPerSplit);
        Assert.False(model.RawData.ContainsKey("min_pages_per_split"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplitCancelResponseSplittingStrategy
        {
            CustomInstructions = "Start a new segment at every signature page.",
            SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitCancelResponseSplittingStrategy
        {
            CustomInstructions = "Start a new segment at every signature page.",
            SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,

            // Null should be interpreted as omitted for these properties
            AllowUncategorized = null,
            MinPagesPerSplit = null,
        };

        Assert.Null(model.AllowUncategorized);
        Assert.False(model.RawData.ContainsKey("allow_uncategorized"));
        Assert.Null(model.MinPagesPerSplit);
        Assert.False(model.RawData.ContainsKey("min_pages_per_split"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SplitCancelResponseSplittingStrategy
        {
            CustomInstructions = "Start a new segment at every signature page.",
            SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,

            // Null should be interpreted as omitted for these properties
            AllowUncategorized = null,
            MinPagesPerSplit = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitCancelResponseSplittingStrategy
        {
            AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
            MinPagesPerSplit = 1,
        };

        Assert.Null(model.CustomInstructions);
        Assert.False(model.RawData.ContainsKey("custom_instructions"));
        Assert.Null(model.SegmentBoundary);
        Assert.False(model.RawData.ContainsKey("segment_boundary"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplitCancelResponseSplittingStrategy
        {
            AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
            MinPagesPerSplit = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SplitCancelResponseSplittingStrategy
        {
            AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
            MinPagesPerSplit = 1,

            CustomInstructions = null,
            SegmentBoundary = null,
        };

        Assert.Null(model.CustomInstructions);
        Assert.True(model.RawData.ContainsKey("custom_instructions"));
        Assert.Null(model.SegmentBoundary);
        Assert.True(model.RawData.ContainsKey("segment_boundary"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SplitCancelResponseSplittingStrategy
        {
            AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
            MinPagesPerSplit = 1,

            CustomInstructions = null,
            SegmentBoundary = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplitCancelResponseSplittingStrategy
        {
            AllowUncategorized = SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
            SegmentBoundary = SplitCancelResponseSplittingStrategySegmentBoundary.Category,
        };

        SplitCancelResponseSplittingStrategy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitCancelResponseSplittingStrategyAllowUncategorizedTest : TestBase
{
    [Theory]
    [InlineData(SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid)]
    [InlineData(SplitCancelResponseSplittingStrategyAllowUncategorized.Include)]
    [InlineData(SplitCancelResponseSplittingStrategyAllowUncategorized.Omit)]
    public void Validation_Works(SplitCancelResponseSplittingStrategyAllowUncategorized rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitCancelResponseSplittingStrategyAllowUncategorized> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCancelResponseSplittingStrategyAllowUncategorized>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SplitCancelResponseSplittingStrategyAllowUncategorized.Forbid)]
    [InlineData(SplitCancelResponseSplittingStrategyAllowUncategorized.Include)]
    [InlineData(SplitCancelResponseSplittingStrategyAllowUncategorized.Omit)]
    public void SerializationRoundtrip_Works(
        SplitCancelResponseSplittingStrategyAllowUncategorized rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitCancelResponseSplittingStrategyAllowUncategorized> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCancelResponseSplittingStrategyAllowUncategorized>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCancelResponseSplittingStrategyAllowUncategorized>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCancelResponseSplittingStrategyAllowUncategorized>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SplitCancelResponseSplittingStrategySegmentBoundaryTest : TestBase
{
    [Theory]
    [InlineData(SplitCancelResponseSplittingStrategySegmentBoundary.Category)]
    [InlineData(SplitCancelResponseSplittingStrategySegmentBoundary.Document)]
    public void Validation_Works(SplitCancelResponseSplittingStrategySegmentBoundary rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitCancelResponseSplittingStrategySegmentBoundary> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCancelResponseSplittingStrategySegmentBoundary>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SplitCancelResponseSplittingStrategySegmentBoundary.Category)]
    [InlineData(SplitCancelResponseSplittingStrategySegmentBoundary.Document)]
    public void SerializationRoundtrip_Works(
        SplitCancelResponseSplittingStrategySegmentBoundary rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitCancelResponseSplittingStrategySegmentBoundary> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCancelResponseSplittingStrategySegmentBoundary>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCancelResponseSplittingStrategySegmentBoundary>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCancelResponseSplittingStrategySegmentBoundary>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SplitCancelResponseWarningTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitCancelResponseWarning
        {
            CategoryNames = ["string"],
            Code = SplitCancelResponseWarningCode.CatchAllCategory,
            Message = "message",
        };

        List<string> expectedCategoryNames = ["string"];
        ApiEnum<string, SplitCancelResponseWarningCode> expectedCode =
            SplitCancelResponseWarningCode.CatchAllCategory;
        string expectedMessage = "message";

        Assert.Equal(expectedCategoryNames.Count, model.CategoryNames.Count);
        for (int i = 0; i < expectedCategoryNames.Count; i++)
        {
            Assert.Equal(expectedCategoryNames[i], model.CategoryNames[i]);
        }
        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplitCancelResponseWarning
        {
            CategoryNames = ["string"],
            Code = SplitCancelResponseWarningCode.CatchAllCategory,
            Message = "message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitCancelResponseWarning>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitCancelResponseWarning
        {
            CategoryNames = ["string"],
            Code = SplitCancelResponseWarningCode.CatchAllCategory,
            Message = "message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitCancelResponseWarning>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedCategoryNames = ["string"];
        ApiEnum<string, SplitCancelResponseWarningCode> expectedCode =
            SplitCancelResponseWarningCode.CatchAllCategory;
        string expectedMessage = "message";

        Assert.Equal(expectedCategoryNames.Count, deserialized.CategoryNames.Count);
        for (int i = 0; i < expectedCategoryNames.Count; i++)
        {
            Assert.Equal(expectedCategoryNames[i], deserialized.CategoryNames[i]);
        }
        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SplitCancelResponseWarning
        {
            CategoryNames = ["string"],
            Code = SplitCancelResponseWarningCode.CatchAllCategory,
            Message = "message",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplitCancelResponseWarning
        {
            CategoryNames = ["string"],
            Code = SplitCancelResponseWarningCode.CatchAllCategory,
            Message = "message",
        };

        SplitCancelResponseWarning copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitCancelResponseWarningCodeTest : TestBase
{
    [Theory]
    [InlineData(SplitCancelResponseWarningCode.CatchAllCategory)]
    [InlineData(SplitCancelResponseWarningCode.MissingDescription)]
    [InlineData(SplitCancelResponseWarningCode.NearDuplicateDescription)]
    [InlineData(SplitCancelResponseWarningCode.NearDuplicateName)]
    public void Validation_Works(SplitCancelResponseWarningCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitCancelResponseWarningCode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitCancelResponseWarningCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SplitCancelResponseWarningCode.CatchAllCategory)]
    [InlineData(SplitCancelResponseWarningCode.MissingDescription)]
    [InlineData(SplitCancelResponseWarningCode.NearDuplicateDescription)]
    [InlineData(SplitCancelResponseWarningCode.NearDuplicateName)]
    public void SerializationRoundtrip_Works(SplitCancelResponseWarningCode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitCancelResponseWarningCode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCancelResponseWarningCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitCancelResponseWarningCode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitCancelResponseWarningCode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
