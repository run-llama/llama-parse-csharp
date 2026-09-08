using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Split;
using Split = LlamaCloud.Models.Beta.Split;

namespace LlamaCloud.Tests.Models.Split;

public class SplitListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitListResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitListResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
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
                AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        List<Split::SplitCategory> expectedCategories = [new() { Name = "x", Description = "x" }];
        ApiEnum<string, SplitListResponseDocumentInputType> expectedDocumentInputType =
            SplitListResponseDocumentInputType.FileID;
        string expectedFileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedProjectID = "project_id";
        string expectedStatus = "status";
        string expectedUserID = "user_id";
        string expectedConfigurationID = "configuration_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        Split::SplitResultResponse expectedResult = new(
            [
                new()
                {
                    Category = "category",
                    ConfidenceCategory = "confidence_category",
                    Pages = [0],
                },
            ]
        );
        SplitListResponseSplittingStrategy expectedSplittingStrategy = new()
        {
            AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
        };
        string expectedTransactionID = "transaction_id";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

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
        Assert.Equal(expectedConfigurationID, model.ConfigurationID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedSplittingStrategy, model.SplittingStrategy);
        Assert.Equal(expectedTransactionID, model.TransactionID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplitListResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitListResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
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
                AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitListResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitListResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
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
                AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<Split::SplitCategory> expectedCategories = [new() { Name = "x", Description = "x" }];
        ApiEnum<string, SplitListResponseDocumentInputType> expectedDocumentInputType =
            SplitListResponseDocumentInputType.FileID;
        string expectedFileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedProjectID = "project_id";
        string expectedStatus = "status";
        string expectedUserID = "user_id";
        string expectedConfigurationID = "configuration_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        Split::SplitResultResponse expectedResult = new(
            [
                new()
                {
                    Category = "category",
                    ConfidenceCategory = "confidence_category",
                    Pages = [0],
                },
            ]
        );
        SplitListResponseSplittingStrategy expectedSplittingStrategy = new()
        {
            AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
        };
        string expectedTransactionID = "transaction_id";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

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
        Assert.Equal(expectedConfigurationID, deserialized.ConfigurationID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedSplittingStrategy, deserialized.SplittingStrategy);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SplitListResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitListResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
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
                AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitListResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitListResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
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
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.SplittingStrategy);
        Assert.False(model.RawData.ContainsKey("splitting_strategy"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplitListResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitListResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
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
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitListResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitListResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
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
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            SplittingStrategy = null,
        };

        Assert.Null(model.SplittingStrategy);
        Assert.False(model.RawData.ContainsKey("splitting_strategy"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SplitListResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitListResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
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
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            SplittingStrategy = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitListResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitListResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            SplittingStrategy = new()
            {
                AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },
        };

        Assert.Null(model.ConfigurationID);
        Assert.False(model.RawData.ContainsKey("configuration_id"));
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
        var model = new SplitListResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitListResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            SplittingStrategy = new()
            {
                AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SplitListResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitListResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            SplittingStrategy = new()
            {
                AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },

            ConfigurationID = null,
            CreatedAt = null,
            ErrorMessage = null,
            Result = null,
            TransactionID = null,
            UpdatedAt = null,
        };

        Assert.Null(model.ConfigurationID);
        Assert.True(model.RawData.ContainsKey("configuration_id"));
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
        var model = new SplitListResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitListResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            SplittingStrategy = new()
            {
                AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },

            ConfigurationID = null,
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
        var model = new SplitListResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitListResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
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
                AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        SplitListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitListResponseDocumentInputTypeTest : TestBase
{
    [Theory]
    [InlineData(SplitListResponseDocumentInputType.FileID)]
    [InlineData(SplitListResponseDocumentInputType.ParseJobID)]
    [InlineData(SplitListResponseDocumentInputType.Url)]
    public void Validation_Works(SplitListResponseDocumentInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitListResponseDocumentInputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitListResponseDocumentInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SplitListResponseDocumentInputType.FileID)]
    [InlineData(SplitListResponseDocumentInputType.ParseJobID)]
    [InlineData(SplitListResponseDocumentInputType.Url)]
    public void SerializationRoundtrip_Works(SplitListResponseDocumentInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitListResponseDocumentInputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitListResponseDocumentInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitListResponseDocumentInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitListResponseDocumentInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SplitListResponseSplittingStrategyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitListResponseSplittingStrategy
        {
            AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
        };

        ApiEnum<
            string,
            SplitListResponseSplittingStrategyAllowUncategorized
        > expectedAllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid;
        string expectedCustomInstructions = "Start a new segment at every signature page.";
        long expectedMinPagesPerSplit = 1;

        Assert.Equal(expectedAllowUncategorized, model.AllowUncategorized);
        Assert.Equal(expectedCustomInstructions, model.CustomInstructions);
        Assert.Equal(expectedMinPagesPerSplit, model.MinPagesPerSplit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplitListResponseSplittingStrategy
        {
            AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitListResponseSplittingStrategy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitListResponseSplittingStrategy
        {
            AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitListResponseSplittingStrategy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            SplitListResponseSplittingStrategyAllowUncategorized
        > expectedAllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid;
        string expectedCustomInstructions = "Start a new segment at every signature page.";
        long expectedMinPagesPerSplit = 1;

        Assert.Equal(expectedAllowUncategorized, deserialized.AllowUncategorized);
        Assert.Equal(expectedCustomInstructions, deserialized.CustomInstructions);
        Assert.Equal(expectedMinPagesPerSplit, deserialized.MinPagesPerSplit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SplitListResponseSplittingStrategy
        {
            AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitListResponseSplittingStrategy
        {
            CustomInstructions = "Start a new segment at every signature page.",
        };

        Assert.Null(model.AllowUncategorized);
        Assert.False(model.RawData.ContainsKey("allow_uncategorized"));
        Assert.Null(model.MinPagesPerSplit);
        Assert.False(model.RawData.ContainsKey("min_pages_per_split"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplitListResponseSplittingStrategy
        {
            CustomInstructions = "Start a new segment at every signature page.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitListResponseSplittingStrategy
        {
            CustomInstructions = "Start a new segment at every signature page.",

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
        var model = new SplitListResponseSplittingStrategy
        {
            CustomInstructions = "Start a new segment at every signature page.",

            // Null should be interpreted as omitted for these properties
            AllowUncategorized = null,
            MinPagesPerSplit = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitListResponseSplittingStrategy
        {
            AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
            MinPagesPerSplit = 1,
        };

        Assert.Null(model.CustomInstructions);
        Assert.False(model.RawData.ContainsKey("custom_instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplitListResponseSplittingStrategy
        {
            AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
            MinPagesPerSplit = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SplitListResponseSplittingStrategy
        {
            AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
            MinPagesPerSplit = 1,

            CustomInstructions = null,
        };

        Assert.Null(model.CustomInstructions);
        Assert.True(model.RawData.ContainsKey("custom_instructions"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SplitListResponseSplittingStrategy
        {
            AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
            MinPagesPerSplit = 1,

            CustomInstructions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplitListResponseSplittingStrategy
        {
            AllowUncategorized = SplitListResponseSplittingStrategyAllowUncategorized.Forbid,
            CustomInstructions = "Start a new segment at every signature page.",
            MinPagesPerSplit = 1,
        };

        SplitListResponseSplittingStrategy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitListResponseSplittingStrategyAllowUncategorizedTest : TestBase
{
    [Theory]
    [InlineData(SplitListResponseSplittingStrategyAllowUncategorized.Forbid)]
    [InlineData(SplitListResponseSplittingStrategyAllowUncategorized.Include)]
    [InlineData(SplitListResponseSplittingStrategyAllowUncategorized.Omit)]
    public void Validation_Works(SplitListResponseSplittingStrategyAllowUncategorized rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitListResponseSplittingStrategyAllowUncategorized> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SplitListResponseSplittingStrategyAllowUncategorized>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SplitListResponseSplittingStrategyAllowUncategorized.Forbid)]
    [InlineData(SplitListResponseSplittingStrategyAllowUncategorized.Include)]
    [InlineData(SplitListResponseSplittingStrategyAllowUncategorized.Omit)]
    public void SerializationRoundtrip_Works(
        SplitListResponseSplittingStrategyAllowUncategorized rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitListResponseSplittingStrategyAllowUncategorized> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitListResponseSplittingStrategyAllowUncategorized>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SplitListResponseSplittingStrategyAllowUncategorized>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitListResponseSplittingStrategyAllowUncategorized>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
