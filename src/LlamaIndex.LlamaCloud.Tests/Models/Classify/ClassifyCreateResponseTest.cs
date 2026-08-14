using System;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Classify;

namespace LlamaIndex.LlamaCloud.Tests.Models.Classify;

public class ClassifyCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClassifyCreateResponse
        {
            ID = "id",
            Configuration = new()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
            DocumentInputType = DocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = ClassifyCreateResponseStatus.Completed,
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            ParseJobID = "parse_job_id",
            Result = new()
            {
                Confidence = 0,
                Reasoning = "reasoning",
                Type = "type",
            },
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        ClassifyConfiguration expectedConfiguration = new()
        {
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Mode = Mode.Fast,
            ParsingConfiguration = new()
            {
                Lang = "en",
                MaxPages = 10,
                TargetPages = "1,3,5-7",
            },
        };
        ApiEnum<string, DocumentInputType> expectedDocumentInputType = DocumentInputType.FileID;
        string expectedFileInput = "file_input";
        string expectedProjectID = "project_id";
        ApiEnum<string, ClassifyCreateResponseStatus> expectedStatus =
            ClassifyCreateResponseStatus.Completed;
        string expectedUserID = "user_id";
        string expectedConfigurationID = "configuration_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        string expectedParseJobID = "parse_job_id";
        ClassifyResult expectedResult = new()
        {
            Confidence = 0,
            Reasoning = "reasoning",
            Type = "type",
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
        Assert.Equal(expectedConfigurationID, model.ConfigurationID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedParseJobID, model.ParseJobID);
        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedTransactionID, model.TransactionID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClassifyCreateResponse
        {
            ID = "id",
            Configuration = new()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
            DocumentInputType = DocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = ClassifyCreateResponseStatus.Completed,
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            ParseJobID = "parse_job_id",
            Result = new()
            {
                Confidence = 0,
                Reasoning = "reasoning",
                Type = "type",
            },
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClassifyCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClassifyCreateResponse
        {
            ID = "id",
            Configuration = new()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
            DocumentInputType = DocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = ClassifyCreateResponseStatus.Completed,
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            ParseJobID = "parse_job_id",
            Result = new()
            {
                Confidence = 0,
                Reasoning = "reasoning",
                Type = "type",
            },
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClassifyCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ClassifyConfiguration expectedConfiguration = new()
        {
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Mode = Mode.Fast,
            ParsingConfiguration = new()
            {
                Lang = "en",
                MaxPages = 10,
                TargetPages = "1,3,5-7",
            },
        };
        ApiEnum<string, DocumentInputType> expectedDocumentInputType = DocumentInputType.FileID;
        string expectedFileInput = "file_input";
        string expectedProjectID = "project_id";
        ApiEnum<string, ClassifyCreateResponseStatus> expectedStatus =
            ClassifyCreateResponseStatus.Completed;
        string expectedUserID = "user_id";
        string expectedConfigurationID = "configuration_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        string expectedParseJobID = "parse_job_id";
        ClassifyResult expectedResult = new()
        {
            Confidence = 0,
            Reasoning = "reasoning",
            Type = "type",
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
        Assert.Equal(expectedConfigurationID, deserialized.ConfigurationID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedParseJobID, deserialized.ParseJobID);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClassifyCreateResponse
        {
            ID = "id",
            Configuration = new()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
            DocumentInputType = DocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = ClassifyCreateResponseStatus.Completed,
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            ParseJobID = "parse_job_id",
            Result = new()
            {
                Confidence = 0,
                Reasoning = "reasoning",
                Type = "type",
            },
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ClassifyCreateResponse
        {
            ID = "id",
            Configuration = new()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
            DocumentInputType = DocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = ClassifyCreateResponseStatus.Completed,
            UserID = "user_id",
        };

        Assert.Null(model.ConfigurationID);
        Assert.False(model.RawData.ContainsKey("configuration_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.ParseJobID);
        Assert.False(model.RawData.ContainsKey("parse_job_id"));
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
        var model = new ClassifyCreateResponse
        {
            ID = "id",
            Configuration = new()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
            DocumentInputType = DocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = ClassifyCreateResponseStatus.Completed,
            UserID = "user_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ClassifyCreateResponse
        {
            ID = "id",
            Configuration = new()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
            DocumentInputType = DocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = ClassifyCreateResponseStatus.Completed,
            UserID = "user_id",

            ConfigurationID = null,
            CreatedAt = null,
            ErrorMessage = null,
            ParseJobID = null,
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
        Assert.Null(model.ParseJobID);
        Assert.True(model.RawData.ContainsKey("parse_job_id"));
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
        var model = new ClassifyCreateResponse
        {
            ID = "id",
            Configuration = new()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
            DocumentInputType = DocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = ClassifyCreateResponseStatus.Completed,
            UserID = "user_id",

            ConfigurationID = null,
            CreatedAt = null,
            ErrorMessage = null,
            ParseJobID = null,
            Result = null,
            TransactionID = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClassifyCreateResponse
        {
            ID = "id",
            Configuration = new()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
            DocumentInputType = DocumentInputType.FileID,
            FileInput = "file_input",
            ProjectID = "project_id",
            Status = ClassifyCreateResponseStatus.Completed,
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            ParseJobID = "parse_job_id",
            Result = new()
            {
                Confidence = 0,
                Reasoning = "reasoning",
                Type = "type",
            },
            TransactionID = "transaction_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ClassifyCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DocumentInputTypeTest : TestBase
{
    [Theory]
    [InlineData(DocumentInputType.FileID)]
    [InlineData(DocumentInputType.ParseJobID)]
    [InlineData(DocumentInputType.Url)]
    public void Validation_Works(DocumentInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DocumentInputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DocumentInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DocumentInputType.FileID)]
    [InlineData(DocumentInputType.ParseJobID)]
    [InlineData(DocumentInputType.Url)]
    public void SerializationRoundtrip_Works(DocumentInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DocumentInputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DocumentInputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DocumentInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DocumentInputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ClassifyCreateResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(ClassifyCreateResponseStatus.Completed)]
    [InlineData(ClassifyCreateResponseStatus.Failed)]
    [InlineData(ClassifyCreateResponseStatus.Pending)]
    [InlineData(ClassifyCreateResponseStatus.Running)]
    public void Validation_Works(ClassifyCreateResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClassifyCreateResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClassifyCreateResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ClassifyCreateResponseStatus.Completed)]
    [InlineData(ClassifyCreateResponseStatus.Failed)]
    [InlineData(ClassifyCreateResponseStatus.Pending)]
    [InlineData(ClassifyCreateResponseStatus.Running)]
    public void SerializationRoundtrip_Works(ClassifyCreateResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClassifyCreateResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ClassifyCreateResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClassifyCreateResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ClassifyCreateResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
