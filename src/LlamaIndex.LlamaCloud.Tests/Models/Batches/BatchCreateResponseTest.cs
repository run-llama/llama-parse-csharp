using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Batches;

namespace LlamaIndex.LlamaCloud.Tests.Models.Batches;

public class BatchCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchCreateResponse
        {
            ID = "id",
            Config = new(
                new BatchCreateResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCreateResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCreateResponseStatus.Cancelled,
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
                        Type = JobReferenceType.ParseV2,
                    },
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        BatchCreateResponseConfig expectedConfig = new(
            new BatchCreateResponseConfigJob()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchCreateResponseConfigJobType.ParseV2,
            }
        );
        string expectedProjectID = "project_id";
        string expectedSourceDirectoryID = "source_directory_id";
        ApiEnum<string, BatchCreateResponseStatus> expectedStatus =
            BatchCreateResponseStatus.Cancelled;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Result> expectedResults =
        [
            new()
            {
                SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ErrorMessage = "error_message",
                JobReference = new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Type = JobReferenceType.ParseV2,
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
        var model = new BatchCreateResponse
        {
            ID = "id",
            Config = new(
                new BatchCreateResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCreateResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCreateResponseStatus.Cancelled,
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
                        Type = JobReferenceType.ParseV2,
                    },
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchCreateResponse
        {
            ID = "id",
            Config = new(
                new BatchCreateResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCreateResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCreateResponseStatus.Cancelled,
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
                        Type = JobReferenceType.ParseV2,
                    },
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        BatchCreateResponseConfig expectedConfig = new(
            new BatchCreateResponseConfigJob()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchCreateResponseConfigJobType.ParseV2,
            }
        );
        string expectedProjectID = "project_id";
        string expectedSourceDirectoryID = "source_directory_id";
        ApiEnum<string, BatchCreateResponseStatus> expectedStatus =
            BatchCreateResponseStatus.Cancelled;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Result> expectedResults =
        [
            new()
            {
                SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ErrorMessage = "error_message",
                JobReference = new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Type = JobReferenceType.ParseV2,
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
        var model = new BatchCreateResponse
        {
            ID = "id",
            Config = new(
                new BatchCreateResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCreateResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCreateResponseStatus.Cancelled,
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
                        Type = JobReferenceType.ParseV2,
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
        var model = new BatchCreateResponse
        {
            ID = "id",
            Config = new(
                new BatchCreateResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCreateResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCreateResponseStatus.Cancelled,
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
        var model = new BatchCreateResponse
        {
            ID = "id",
            Config = new(
                new BatchCreateResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCreateResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCreateResponseStatus.Cancelled,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BatchCreateResponse
        {
            ID = "id",
            Config = new(
                new BatchCreateResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCreateResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCreateResponseStatus.Cancelled,

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
        var model = new BatchCreateResponse
        {
            ID = "id",
            Config = new(
                new BatchCreateResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCreateResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCreateResponseStatus.Cancelled,

            CreatedAt = null,
            Results = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchCreateResponse
        {
            ID = "id",
            Config = new(
                new BatchCreateResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchCreateResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchCreateResponseStatus.Cancelled,
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
                        Type = JobReferenceType.ParseV2,
                    },
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BatchCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchCreateResponseConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchCreateResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchCreateResponseConfigJobType.ParseV2,
            },
        };

        BatchCreateResponseConfigJob expectedJob = new()
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchCreateResponseConfigJobType.ParseV2,
        };

        Assert.Equal(expectedJob, model.Job);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchCreateResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchCreateResponseConfigJobType.ParseV2,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCreateResponseConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchCreateResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchCreateResponseConfigJobType.ParseV2,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCreateResponseConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BatchCreateResponseConfigJob expectedJob = new()
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchCreateResponseConfigJobType.ParseV2,
        };

        Assert.Equal(expectedJob, deserialized.Job);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchCreateResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchCreateResponseConfigJobType.ParseV2,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchCreateResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchCreateResponseConfigJobType.ParseV2,
            },
        };

        BatchCreateResponseConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchCreateResponseConfigJobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchCreateResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchCreateResponseConfigJobType.ParseV2,
        };

        string expectedConfigurationID = "cfg-PARSE_AGENTIC";
        ApiEnum<string, BatchCreateResponseConfigJobType> expectedType =
            BatchCreateResponseConfigJobType.ParseV2;

        Assert.Equal(expectedConfigurationID, model.ConfigurationID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchCreateResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchCreateResponseConfigJobType.ParseV2,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCreateResponseConfigJob>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchCreateResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchCreateResponseConfigJobType.ParseV2,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchCreateResponseConfigJob>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedConfigurationID = "cfg-PARSE_AGENTIC";
        ApiEnum<string, BatchCreateResponseConfigJobType> expectedType =
            BatchCreateResponseConfigJobType.ParseV2;

        Assert.Equal(expectedConfigurationID, deserialized.ConfigurationID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchCreateResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchCreateResponseConfigJobType.ParseV2,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchCreateResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchCreateResponseConfigJobType.ParseV2,
        };

        BatchCreateResponseConfigJob copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchCreateResponseConfigJobTypeTest : TestBase
{
    [Theory]
    [InlineData(BatchCreateResponseConfigJobType.ParseV2)]
    [InlineData(BatchCreateResponseConfigJobType.ExtractV2)]
    public void Validation_Works(BatchCreateResponseConfigJobType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchCreateResponseConfigJobType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchCreateResponseConfigJobType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BatchCreateResponseConfigJobType.ParseV2)]
    [InlineData(BatchCreateResponseConfigJobType.ExtractV2)]
    public void SerializationRoundtrip_Works(BatchCreateResponseConfigJobType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchCreateResponseConfigJobType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BatchCreateResponseConfigJobType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchCreateResponseConfigJobType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BatchCreateResponseConfigJobType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BatchCreateResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(BatchCreateResponseStatus.Cancelled)]
    [InlineData(BatchCreateResponseStatus.Completed)]
    [InlineData(BatchCreateResponseStatus.Failed)]
    [InlineData(BatchCreateResponseStatus.Pending)]
    [InlineData(BatchCreateResponseStatus.Running)]
    [InlineData(BatchCreateResponseStatus.Throttled)]
    public void Validation_Works(BatchCreateResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchCreateResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchCreateResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BatchCreateResponseStatus.Cancelled)]
    [InlineData(BatchCreateResponseStatus.Completed)]
    [InlineData(BatchCreateResponseStatus.Failed)]
    [InlineData(BatchCreateResponseStatus.Pending)]
    [InlineData(BatchCreateResponseStatus.Running)]
    [InlineData(BatchCreateResponseStatus.Throttled)]
    public void SerializationRoundtrip_Works(BatchCreateResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchCreateResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BatchCreateResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchCreateResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BatchCreateResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = JobReferenceType.ParseV2,
            },
        };

        string expectedSourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedErrorMessage = "error_message";
        JobReference expectedJobReference = new()
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = JobReferenceType.ParseV2,
        };

        Assert.Equal(expectedSourceDirectoryFileID, model.SourceDirectoryFileID);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedJobReference, model.JobReference);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Result
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = JobReferenceType.ParseV2,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = JobReferenceType.ParseV2,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedSourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedErrorMessage = "error_message";
        JobReference expectedJobReference = new()
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = JobReferenceType.ParseV2,
        };

        Assert.Equal(expectedSourceDirectoryFileID, deserialized.SourceDirectoryFileID);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedJobReference, deserialized.JobReference);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Result
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = JobReferenceType.ParseV2,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Result
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
        var model = new Result
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Result
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
        var model = new Result
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
        var model = new Result
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = JobReferenceType.ParseV2,
            },
        };

        Result copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JobReferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = JobReferenceType.ParseV2,
        };

        string expectedID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        ApiEnum<string, JobReferenceType> expectedType = JobReferenceType.ParseV2;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = JobReferenceType.ParseV2,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JobReference>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = JobReferenceType.ParseV2,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JobReference>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        ApiEnum<string, JobReferenceType> expectedType = JobReferenceType.ParseV2;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = JobReferenceType.ParseV2,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = JobReferenceType.ParseV2,
        };

        JobReference copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JobReferenceTypeTest : TestBase
{
    [Theory]
    [InlineData(JobReferenceType.ParseV2)]
    [InlineData(JobReferenceType.ExtractV2)]
    public void Validation_Works(JobReferenceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JobReferenceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JobReferenceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JobReferenceType.ParseV2)]
    [InlineData(JobReferenceType.ExtractV2)]
    public void SerializationRoundtrip_Works(JobReferenceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JobReferenceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JobReferenceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JobReferenceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JobReferenceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
