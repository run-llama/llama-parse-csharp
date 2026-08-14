using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Classifier.Jobs;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Classifier.Jobs;

public class ClassifyJobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClassifyJob
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Status = StatusEnum.Cancelled,
            UserID = "user_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            JobRecordID = "job_record_id",
            Mode = ClassifyJobMode.Fast,
            ParsingConfiguration = new()
            {
                Lang = ParsingLanguages.Abq,
                MaxPages = 0,
                TargetPages = [0],
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<ClassifierRule> expectedRules =
        [
            new()
            {
                Description = "contains invoice number, line items, and total amount",
                Type = "invoice",
            },
        ];
        ApiEnum<string, StatusEnum> expectedStatus = StatusEnum.Cancelled;
        string expectedUserID = "user_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        string expectedJobRecordID = "job_record_id";
        ApiEnum<string, ClassifyJobMode> expectedMode = ClassifyJobMode.Fast;
        ClassifyParsingConfiguration expectedParsingConfiguration = new()
        {
            Lang = ParsingLanguages.Abq,
            MaxPages = 0,
            TargetPages = [0],
        };
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedRules.Count, model.Rules.Count);
        for (int i = 0; i < expectedRules.Count; i++)
        {
            Assert.Equal(expectedRules[i], model.Rules[i]);
        }
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedEffectiveAt, model.EffectiveAt);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedJobRecordID, model.JobRecordID);
        Assert.Equal(expectedMode, model.Mode);
        Assert.Equal(expectedParsingConfiguration, model.ParsingConfiguration);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClassifyJob
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Status = StatusEnum.Cancelled,
            UserID = "user_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            JobRecordID = "job_record_id",
            Mode = ClassifyJobMode.Fast,
            ParsingConfiguration = new()
            {
                Lang = ParsingLanguages.Abq,
                MaxPages = 0,
                TargetPages = [0],
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClassifyJob>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClassifyJob
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Status = StatusEnum.Cancelled,
            UserID = "user_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            JobRecordID = "job_record_id",
            Mode = ClassifyJobMode.Fast,
            ParsingConfiguration = new()
            {
                Lang = ParsingLanguages.Abq,
                MaxPages = 0,
                TargetPages = [0],
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClassifyJob>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        List<ClassifierRule> expectedRules =
        [
            new()
            {
                Description = "contains invoice number, line items, and total amount",
                Type = "invoice",
            },
        ];
        ApiEnum<string, StatusEnum> expectedStatus = StatusEnum.Cancelled;
        string expectedUserID = "user_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        string expectedJobRecordID = "job_record_id";
        ApiEnum<string, ClassifyJobMode> expectedMode = ClassifyJobMode.Fast;
        ClassifyParsingConfiguration expectedParsingConfiguration = new()
        {
            Lang = ParsingLanguages.Abq,
            MaxPages = 0,
            TargetPages = [0],
        };
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedRules.Count, deserialized.Rules.Count);
        for (int i = 0; i < expectedRules.Count; i++)
        {
            Assert.Equal(expectedRules[i], deserialized.Rules[i]);
        }
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedEffectiveAt, deserialized.EffectiveAt);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedJobRecordID, deserialized.JobRecordID);
        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.Equal(expectedParsingConfiguration, deserialized.ParsingConfiguration);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClassifyJob
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Status = StatusEnum.Cancelled,
            UserID = "user_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            JobRecordID = "job_record_id",
            Mode = ClassifyJobMode.Fast,
            ParsingConfiguration = new()
            {
                Lang = ParsingLanguages.Abq,
                MaxPages = 0,
                TargetPages = [0],
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ClassifyJob
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Status = StatusEnum.Cancelled,
            UserID = "user_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            JobRecordID = "job_record_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.EffectiveAt);
        Assert.False(model.RawData.ContainsKey("effective_at"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.ParsingConfiguration);
        Assert.False(model.RawData.ContainsKey("parsing_configuration"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ClassifyJob
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Status = StatusEnum.Cancelled,
            UserID = "user_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            JobRecordID = "job_record_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ClassifyJob
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Status = StatusEnum.Cancelled,
            UserID = "user_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            JobRecordID = "job_record_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            EffectiveAt = null,
            Mode = null,
            ParsingConfiguration = null,
        };

        Assert.Null(model.EffectiveAt);
        Assert.False(model.RawData.ContainsKey("effective_at"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.ParsingConfiguration);
        Assert.False(model.RawData.ContainsKey("parsing_configuration"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ClassifyJob
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Status = StatusEnum.Cancelled,
            UserID = "user_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            JobRecordID = "job_record_id",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            EffectiveAt = null,
            Mode = null,
            ParsingConfiguration = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ClassifyJob
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Status = StatusEnum.Cancelled,
            UserID = "user_id",
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Mode = ClassifyJobMode.Fast,
            ParsingConfiguration = new()
            {
                Lang = ParsingLanguages.Abq,
                MaxPages = 0,
                TargetPages = [0],
            },
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.JobRecordID);
        Assert.False(model.RawData.ContainsKey("job_record_id"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ClassifyJob
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Status = StatusEnum.Cancelled,
            UserID = "user_id",
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Mode = ClassifyJobMode.Fast,
            ParsingConfiguration = new()
            {
                Lang = ParsingLanguages.Abq,
                MaxPages = 0,
                TargetPages = [0],
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ClassifyJob
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Status = StatusEnum.Cancelled,
            UserID = "user_id",
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Mode = ClassifyJobMode.Fast,
            ParsingConfiguration = new()
            {
                Lang = ParsingLanguages.Abq,
                MaxPages = 0,
                TargetPages = [0],
            },

            CreatedAt = null,
            ErrorMessage = null,
            JobRecordID = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.JobRecordID);
        Assert.True(model.RawData.ContainsKey("job_record_id"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ClassifyJob
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Status = StatusEnum.Cancelled,
            UserID = "user_id",
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Mode = ClassifyJobMode.Fast,
            ParsingConfiguration = new()
            {
                Lang = ParsingLanguages.Abq,
                MaxPages = 0,
                TargetPages = [0],
            },

            CreatedAt = null,
            ErrorMessage = null,
            JobRecordID = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClassifyJob
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Status = StatusEnum.Cancelled,
            UserID = "user_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            JobRecordID = "job_record_id",
            Mode = ClassifyJobMode.Fast,
            ParsingConfiguration = new()
            {
                Lang = ParsingLanguages.Abq,
                MaxPages = 0,
                TargetPages = [0],
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ClassifyJob copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ClassifyJobModeTest : TestBase
{
    [Theory]
    [InlineData(ClassifyJobMode.Fast)]
    [InlineData(ClassifyJobMode.Multimodal)]
    public void Validation_Works(ClassifyJobMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClassifyJobMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClassifyJobMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ClassifyJobMode.Fast)]
    [InlineData(ClassifyJobMode.Multimodal)]
    public void SerializationRoundtrip_Works(ClassifyJobMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClassifyJobMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ClassifyJobMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClassifyJobMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ClassifyJobMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
