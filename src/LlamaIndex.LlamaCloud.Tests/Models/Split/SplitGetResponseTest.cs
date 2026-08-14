using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Split;
using Split = LlamaIndex.LlamaCloud.Models.Beta.Split;

namespace LlamaIndex.LlamaCloud.Tests.Models.Split;

public class SplitGetResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitGetResponseDocumentInputType.FileID,
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
                AllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid,
            },
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        List<Split::SplitCategory> expectedCategories = [new() { Name = "x", Description = "x" }];
        ApiEnum<string, SplitGetResponseDocumentInputType> expectedDocumentInputType =
            SplitGetResponseDocumentInputType.FileID;
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
        SplitGetResponseSplittingStrategy expectedSplittingStrategy = new()
        {
            AllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid,
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
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitGetResponseDocumentInputType.FileID,
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
                AllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid,
            },
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitGetResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitGetResponseDocumentInputType.FileID,
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
                AllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid,
            },
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitGetResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<Split::SplitCategory> expectedCategories = [new() { Name = "x", Description = "x" }];
        ApiEnum<string, SplitGetResponseDocumentInputType> expectedDocumentInputType =
            SplitGetResponseDocumentInputType.FileID;
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
        SplitGetResponseSplittingStrategy expectedSplittingStrategy = new()
        {
            AllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid,
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
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitGetResponseDocumentInputType.FileID,
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
                AllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid,
            },
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitGetResponseDocumentInputType.FileID,
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
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitGetResponseDocumentInputType.FileID,
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
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitGetResponseDocumentInputType.FileID,
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
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitGetResponseDocumentInputType.FileID,
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
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitGetResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            SplittingStrategy = new()
            {
                AllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid,
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
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitGetResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            SplittingStrategy = new()
            {
                AllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitGetResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            SplittingStrategy = new()
            {
                AllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid,
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
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitGetResponseDocumentInputType.FileID,
            FileInput = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            SplittingStrategy = new()
            {
                AllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid,
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
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInputType = SplitGetResponseDocumentInputType.FileID,
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
                AllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid,
            },
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        SplitGetResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitGetResponseDocumentInputTypeTest : TestBase
{
    [Theory]
    [InlineData(SplitGetResponseDocumentInputType.FileID)]
    [InlineData(SplitGetResponseDocumentInputType.ParseJobID)]
    [InlineData(SplitGetResponseDocumentInputType.Url)]
    public void Validation_Works(SplitGetResponseDocumentInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitGetResponseDocumentInputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitGetResponseDocumentInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SplitGetResponseDocumentInputType.FileID)]
    [InlineData(SplitGetResponseDocumentInputType.ParseJobID)]
    [InlineData(SplitGetResponseDocumentInputType.Url)]
    public void SerializationRoundtrip_Works(SplitGetResponseDocumentInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitGetResponseDocumentInputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitGetResponseDocumentInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SplitGetResponseDocumentInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitGetResponseDocumentInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SplitGetResponseSplittingStrategyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitGetResponseSplittingStrategy
        {
            AllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid,
        };

        ApiEnum<
            string,
            SplitGetResponseSplittingStrategyAllowUncategorized
        > expectedAllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid;

        Assert.Equal(expectedAllowUncategorized, model.AllowUncategorized);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplitGetResponseSplittingStrategy
        {
            AllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitGetResponseSplittingStrategy>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitGetResponseSplittingStrategy
        {
            AllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitGetResponseSplittingStrategy>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            SplitGetResponseSplittingStrategyAllowUncategorized
        > expectedAllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid;

        Assert.Equal(expectedAllowUncategorized, deserialized.AllowUncategorized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SplitGetResponseSplittingStrategy
        {
            AllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitGetResponseSplittingStrategy { };

        Assert.Null(model.AllowUncategorized);
        Assert.False(model.RawData.ContainsKey("allow_uncategorized"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplitGetResponseSplittingStrategy { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SplitGetResponseSplittingStrategy
        {
            // Null should be interpreted as omitted for these properties
            AllowUncategorized = null,
        };

        Assert.Null(model.AllowUncategorized);
        Assert.False(model.RawData.ContainsKey("allow_uncategorized"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SplitGetResponseSplittingStrategy
        {
            // Null should be interpreted as omitted for these properties
            AllowUncategorized = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplitGetResponseSplittingStrategy
        {
            AllowUncategorized = SplitGetResponseSplittingStrategyAllowUncategorized.Forbid,
        };

        SplitGetResponseSplittingStrategy copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SplitGetResponseSplittingStrategyAllowUncategorizedTest : TestBase
{
    [Theory]
    [InlineData(SplitGetResponseSplittingStrategyAllowUncategorized.Forbid)]
    [InlineData(SplitGetResponseSplittingStrategyAllowUncategorized.Include)]
    [InlineData(SplitGetResponseSplittingStrategyAllowUncategorized.Omit)]
    public void Validation_Works(SplitGetResponseSplittingStrategyAllowUncategorized rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitGetResponseSplittingStrategyAllowUncategorized> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SplitGetResponseSplittingStrategyAllowUncategorized>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SplitGetResponseSplittingStrategyAllowUncategorized.Forbid)]
    [InlineData(SplitGetResponseSplittingStrategyAllowUncategorized.Include)]
    [InlineData(SplitGetResponseSplittingStrategyAllowUncategorized.Omit)]
    public void SerializationRoundtrip_Works(
        SplitGetResponseSplittingStrategyAllowUncategorized rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SplitGetResponseSplittingStrategyAllowUncategorized> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitGetResponseSplittingStrategyAllowUncategorized>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SplitGetResponseSplittingStrategyAllowUncategorized>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SplitGetResponseSplittingStrategyAllowUncategorized>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
