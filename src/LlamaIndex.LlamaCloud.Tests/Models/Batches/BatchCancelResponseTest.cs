using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Batches;

namespace LlamaIndex.LlamaCloud.Tests.Models.Batches;

public class BatchCancelResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchCancelResponse
        {
            ID = "id",
            Config = new(
                new BatchCancelResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCancelResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCancelResponseStatus.Cancelled,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Results =
            [
                new()
                {
                    SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ErrorMessage = "error_message",
                    JobReference = new()
                    {
                        ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                        Type = BatchCancelResponseResultJobReferenceType.ParseV2,
                    },
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        BatchCancelResponseConfig expectedConfig = new(
            new BatchCancelResponseConfigJob()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchCancelResponseConfigJobType.ParseV2,
            }
        );
        string expectedProjectID = "project_id";
        string expectedSourceDirectoryID = "source_directory_id";
        ApiEnum<string, BatchCancelResponseStatus> expectedStatus =
            BatchCancelResponseStatus.Cancelled;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<BatchCancelResponseResult> expectedResults =
        [
            new()
            {
                SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ErrorMessage = "error_message",
                JobReference = new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Type = BatchCancelResponseResultJobReferenceType.ParseV2,
                },
            },
        ];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConfig, model.Config);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedSourceDirectoryID, model.SourceDirectoryID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.Results);
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchCancelResponse
        {
            ID = "id",
            Config = new(
                new BatchCancelResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCancelResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCancelResponseStatus.Cancelled,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Results =
            [
                new()
                {
                    SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ErrorMessage = "error_message",
                    JobReference = new()
                    {
                        ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                        Type = BatchCancelResponseResultJobReferenceType.ParseV2,
                    },
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCancelResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchCancelResponse
        {
            ID = "id",
            Config = new(
                new BatchCancelResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCancelResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCancelResponseStatus.Cancelled,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Results =
            [
                new()
                {
                    SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ErrorMessage = "error_message",
                    JobReference = new()
                    {
                        ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                        Type = BatchCancelResponseResultJobReferenceType.ParseV2,
                    },
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCancelResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        BatchCancelResponseConfig expectedConfig = new(
            new BatchCancelResponseConfigJob()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchCancelResponseConfigJobType.ParseV2,
            }
        );
        string expectedProjectID = "project_id";
        string expectedSourceDirectoryID = "source_directory_id";
        ApiEnum<string, BatchCancelResponseStatus> expectedStatus =
            BatchCancelResponseStatus.Cancelled;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<BatchCancelResponseResult> expectedResults =
        [
            new()
            {
                SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ErrorMessage = "error_message",
                JobReference = new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Type = BatchCancelResponseResultJobReferenceType.ParseV2,
                },
            },
        ];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConfig, deserialized.Config);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedSourceDirectoryID, deserialized.SourceDirectoryID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.Results);
        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchCancelResponse
        {
            ID = "id",
            Config = new(
                new BatchCancelResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCancelResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCancelResponseStatus.Cancelled,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Results =
            [
                new()
                {
                    SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ErrorMessage = "error_message",
                    JobReference = new()
                    {
                        ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                        Type = BatchCancelResponseResultJobReferenceType.ParseV2,
                    },
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BatchCancelResponse
        {
            ID = "id",
            Config = new(
                new BatchCancelResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCancelResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCancelResponseStatus.Cancelled,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Results);
        Assert.False(model.RawData.ContainsKey("results"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BatchCancelResponse
        {
            ID = "id",
            Config = new(
                new BatchCancelResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCancelResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCancelResponseStatus.Cancelled,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BatchCancelResponse
        {
            ID = "id",
            Config = new(
                new BatchCancelResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCancelResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCancelResponseStatus.Cancelled,

            CreatedAt = null,
            Results = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Results);
        Assert.True(model.RawData.ContainsKey("results"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BatchCancelResponse
        {
            ID = "id",
            Config = new(
                new BatchCancelResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCancelResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCancelResponseStatus.Cancelled,

            CreatedAt = null,
            Results = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchCancelResponse
        {
            ID = "id",
            Config = new(
                new BatchCancelResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCancelResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCancelResponseStatus.Cancelled,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Results =
            [
                new()
                {
                    SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ErrorMessage = "error_message",
                    JobReference = new()
                    {
                        ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                        Type = BatchCancelResponseResultJobReferenceType.ParseV2,
                    },
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BatchCancelResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchCancelResponseConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchCancelResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchCancelResponseConfigJobType.ParseV2,
            },
        };

        BatchCancelResponseConfigJob expectedJob = new()
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchCancelResponseConfigJobType.ParseV2,
        };

        Assert.Equal(expectedJob, model.Job);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchCancelResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchCancelResponseConfigJobType.ParseV2,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCancelResponseConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchCancelResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchCancelResponseConfigJobType.ParseV2,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCancelResponseConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BatchCancelResponseConfigJob expectedJob = new()
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchCancelResponseConfigJobType.ParseV2,
        };

        Assert.Equal(expectedJob, deserialized.Job);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchCancelResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchCancelResponseConfigJobType.ParseV2,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchCancelResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchCancelResponseConfigJobType.ParseV2,
            },
        };

        BatchCancelResponseConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchCancelResponseConfigJobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchCancelResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchCancelResponseConfigJobType.ParseV2,
        };

        string expectedConfigurationID = "cfg-PARSE_AGENTIC";
        ApiEnum<string, BatchCancelResponseConfigJobType> expectedType =
            BatchCancelResponseConfigJobType.ParseV2;

        Assert.Equal(expectedConfigurationID, model.ConfigurationID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchCancelResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchCancelResponseConfigJobType.ParseV2,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCancelResponseConfigJob>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchCancelResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchCancelResponseConfigJobType.ParseV2,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCancelResponseConfigJob>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedConfigurationID = "cfg-PARSE_AGENTIC";
        ApiEnum<string, BatchCancelResponseConfigJobType> expectedType =
            BatchCancelResponseConfigJobType.ParseV2;

        Assert.Equal(expectedConfigurationID, deserialized.ConfigurationID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchCancelResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchCancelResponseConfigJobType.ParseV2,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchCancelResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchCancelResponseConfigJobType.ParseV2,
        };

        BatchCancelResponseConfigJob copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchCancelResponseConfigJobTypeTest : TestBase
{
    [Theory]
    [InlineData(BatchCancelResponseConfigJobType.ParseV2)]
    [InlineData(BatchCancelResponseConfigJobType.ExtractV2)]
    public void Validation_Works(BatchCancelResponseConfigJobType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchCancelResponseConfigJobType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchCancelResponseConfigJobType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BatchCancelResponseConfigJobType.ParseV2)]
    [InlineData(BatchCancelResponseConfigJobType.ExtractV2)]
    public void SerializationRoundtrip_Works(BatchCancelResponseConfigJobType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchCancelResponseConfigJobType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BatchCancelResponseConfigJobType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchCancelResponseConfigJobType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BatchCancelResponseConfigJobType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BatchCancelResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(BatchCancelResponseStatus.Cancelled)]
    [InlineData(BatchCancelResponseStatus.Completed)]
    [InlineData(BatchCancelResponseStatus.Failed)]
    [InlineData(BatchCancelResponseStatus.Pending)]
    [InlineData(BatchCancelResponseStatus.Running)]
    [InlineData(BatchCancelResponseStatus.Throttled)]
    public void Validation_Works(BatchCancelResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchCancelResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchCancelResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BatchCancelResponseStatus.Cancelled)]
    [InlineData(BatchCancelResponseStatus.Completed)]
    [InlineData(BatchCancelResponseStatus.Failed)]
    [InlineData(BatchCancelResponseStatus.Pending)]
    [InlineData(BatchCancelResponseStatus.Running)]
    [InlineData(BatchCancelResponseStatus.Throttled)]
    public void SerializationRoundtrip_Works(BatchCancelResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchCancelResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BatchCancelResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchCancelResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BatchCancelResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BatchCancelResponseResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchCancelResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = BatchCancelResponseResultJobReferenceType.ParseV2,
            },
        };

        string expectedSourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedErrorMessage = "error_message";
        BatchCancelResponseResultJobReference expectedJobReference = new()
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchCancelResponseResultJobReferenceType.ParseV2,
        };

        Assert.Equal(expectedSourceDirectoryFileID, model.SourceDirectoryFileID);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedJobReference, model.JobReference);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchCancelResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = BatchCancelResponseResultJobReferenceType.ParseV2,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCancelResponseResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchCancelResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = BatchCancelResponseResultJobReferenceType.ParseV2,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCancelResponseResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedErrorMessage = "error_message";
        BatchCancelResponseResultJobReference expectedJobReference = new()
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchCancelResponseResultJobReferenceType.ParseV2,
        };

        Assert.Equal(expectedSourceDirectoryFileID, deserialized.SourceDirectoryFileID);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedJobReference, deserialized.JobReference);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchCancelResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = BatchCancelResponseResultJobReferenceType.ParseV2,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BatchCancelResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.JobReference);
        Assert.False(model.RawData.ContainsKey("job_reference"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BatchCancelResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BatchCancelResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",

            ErrorMessage = null,
            JobReference = null,
        };

        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.JobReference);
        Assert.True(model.RawData.ContainsKey("job_reference"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BatchCancelResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",

            ErrorMessage = null,
            JobReference = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchCancelResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = BatchCancelResponseResultJobReferenceType.ParseV2,
            },
        };

        BatchCancelResponseResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchCancelResponseResultJobReferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchCancelResponseResultJobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchCancelResponseResultJobReferenceType.ParseV2,
        };

        string expectedID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        ApiEnum<string, BatchCancelResponseResultJobReferenceType> expectedType =
            BatchCancelResponseResultJobReferenceType.ParseV2;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchCancelResponseResultJobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchCancelResponseResultJobReferenceType.ParseV2,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCancelResponseResultJobReference>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchCancelResponseResultJobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchCancelResponseResultJobReferenceType.ParseV2,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCancelResponseResultJobReference>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        ApiEnum<string, BatchCancelResponseResultJobReferenceType> expectedType =
            BatchCancelResponseResultJobReferenceType.ParseV2;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchCancelResponseResultJobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchCancelResponseResultJobReferenceType.ParseV2,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchCancelResponseResultJobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchCancelResponseResultJobReferenceType.ParseV2,
        };

        BatchCancelResponseResultJobReference copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchCancelResponseResultJobReferenceTypeTest : TestBase
{
    [Theory]
    [InlineData(BatchCancelResponseResultJobReferenceType.ParseV2)]
    [InlineData(BatchCancelResponseResultJobReferenceType.ExtractV2)]
    public void Validation_Works(BatchCancelResponseResultJobReferenceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchCancelResponseResultJobReferenceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BatchCancelResponseResultJobReferenceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BatchCancelResponseResultJobReferenceType.ParseV2)]
    [InlineData(BatchCancelResponseResultJobReferenceType.ExtractV2)]
    public void SerializationRoundtrip_Works(BatchCancelResponseResultJobReferenceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchCancelResponseResultJobReferenceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BatchCancelResponseResultJobReferenceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BatchCancelResponseResultJobReferenceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BatchCancelResponseResultJobReferenceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
