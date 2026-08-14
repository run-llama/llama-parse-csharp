using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Batches;

namespace LlamaIndex.LlamaCloud.Tests.Models.Batches;

public class BatchGetResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchGetResponse
        {
            ID = "id",
            Config = new(
                new BatchGetResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchGetResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchGetResponseStatus.Cancelled,
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
                        Type = BatchGetResponseResultJobReferenceType.ParseV2,
                    },
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        BatchGetResponseConfig expectedConfig = new(
            new BatchGetResponseConfigJob()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchGetResponseConfigJobType.ParseV2,
            }
        );
        string expectedProjectID = "project_id";
        string expectedSourceDirectoryID = "source_directory_id";
        ApiEnum<string, BatchGetResponseStatus> expectedStatus = BatchGetResponseStatus.Cancelled;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<BatchGetResponseResult> expectedResults =
        [
            new()
            {
                SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ErrorMessage = "error_message",
                JobReference = new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Type = BatchGetResponseResultJobReferenceType.ParseV2,
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
        var model = new BatchGetResponse
        {
            ID = "id",
            Config = new(
                new BatchGetResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchGetResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchGetResponseStatus.Cancelled,
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
                        Type = BatchGetResponseResultJobReferenceType.ParseV2,
                    },
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchGetResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchGetResponse
        {
            ID = "id",
            Config = new(
                new BatchGetResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchGetResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchGetResponseStatus.Cancelled,
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
                        Type = BatchGetResponseResultJobReferenceType.ParseV2,
                    },
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchGetResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        BatchGetResponseConfig expectedConfig = new(
            new BatchGetResponseConfigJob()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchGetResponseConfigJobType.ParseV2,
            }
        );
        string expectedProjectID = "project_id";
        string expectedSourceDirectoryID = "source_directory_id";
        ApiEnum<string, BatchGetResponseStatus> expectedStatus = BatchGetResponseStatus.Cancelled;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<BatchGetResponseResult> expectedResults =
        [
            new()
            {
                SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ErrorMessage = "error_message",
                JobReference = new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Type = BatchGetResponseResultJobReferenceType.ParseV2,
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
        var model = new BatchGetResponse
        {
            ID = "id",
            Config = new(
                new BatchGetResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchGetResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchGetResponseStatus.Cancelled,
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
                        Type = BatchGetResponseResultJobReferenceType.ParseV2,
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
        var model = new BatchGetResponse
        {
            ID = "id",
            Config = new(
                new BatchGetResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchGetResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchGetResponseStatus.Cancelled,
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
        var model = new BatchGetResponse
        {
            ID = "id",
            Config = new(
                new BatchGetResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchGetResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchGetResponseStatus.Cancelled,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BatchGetResponse
        {
            ID = "id",
            Config = new(
                new BatchGetResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchGetResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchGetResponseStatus.Cancelled,

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
        var model = new BatchGetResponse
        {
            ID = "id",
            Config = new(
                new BatchGetResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchGetResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchGetResponseStatus.Cancelled,

            CreatedAt = null,
            Results = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchGetResponse
        {
            ID = "id",
            Config = new(
                new BatchGetResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchGetResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchGetResponseStatus.Cancelled,
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
                        Type = BatchGetResponseResultJobReferenceType.ParseV2,
                    },
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BatchGetResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchGetResponseConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchGetResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchGetResponseConfigJobType.ParseV2,
            },
        };

        BatchGetResponseConfigJob expectedJob = new()
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchGetResponseConfigJobType.ParseV2,
        };

        Assert.Equal(expectedJob, model.Job);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchGetResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchGetResponseConfigJobType.ParseV2,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchGetResponseConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchGetResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchGetResponseConfigJobType.ParseV2,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchGetResponseConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BatchGetResponseConfigJob expectedJob = new()
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchGetResponseConfigJobType.ParseV2,
        };

        Assert.Equal(expectedJob, deserialized.Job);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchGetResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchGetResponseConfigJobType.ParseV2,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchGetResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchGetResponseConfigJobType.ParseV2,
            },
        };

        BatchGetResponseConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchGetResponseConfigJobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchGetResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchGetResponseConfigJobType.ParseV2,
        };

        string expectedConfigurationID = "cfg-PARSE_AGENTIC";
        ApiEnum<string, BatchGetResponseConfigJobType> expectedType =
            BatchGetResponseConfigJobType.ParseV2;

        Assert.Equal(expectedConfigurationID, model.ConfigurationID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchGetResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchGetResponseConfigJobType.ParseV2,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchGetResponseConfigJob>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchGetResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchGetResponseConfigJobType.ParseV2,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchGetResponseConfigJob>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedConfigurationID = "cfg-PARSE_AGENTIC";
        ApiEnum<string, BatchGetResponseConfigJobType> expectedType =
            BatchGetResponseConfigJobType.ParseV2;

        Assert.Equal(expectedConfigurationID, deserialized.ConfigurationID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchGetResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchGetResponseConfigJobType.ParseV2,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchGetResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchGetResponseConfigJobType.ParseV2,
        };

        BatchGetResponseConfigJob copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchGetResponseConfigJobTypeTest : TestBase
{
    [Theory]
    [InlineData(BatchGetResponseConfigJobType.ParseV2)]
    [InlineData(BatchGetResponseConfigJobType.ExtractV2)]
    public void Validation_Works(BatchGetResponseConfigJobType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchGetResponseConfigJobType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchGetResponseConfigJobType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BatchGetResponseConfigJobType.ParseV2)]
    [InlineData(BatchGetResponseConfigJobType.ExtractV2)]
    public void SerializationRoundtrip_Works(BatchGetResponseConfigJobType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchGetResponseConfigJobType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BatchGetResponseConfigJobType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchGetResponseConfigJobType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BatchGetResponseConfigJobType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BatchGetResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(BatchGetResponseStatus.Cancelled)]
    [InlineData(BatchGetResponseStatus.Completed)]
    [InlineData(BatchGetResponseStatus.Failed)]
    [InlineData(BatchGetResponseStatus.Pending)]
    [InlineData(BatchGetResponseStatus.Running)]
    [InlineData(BatchGetResponseStatus.Throttled)]
    public void Validation_Works(BatchGetResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchGetResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchGetResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BatchGetResponseStatus.Cancelled)]
    [InlineData(BatchGetResponseStatus.Completed)]
    [InlineData(BatchGetResponseStatus.Failed)]
    [InlineData(BatchGetResponseStatus.Pending)]
    [InlineData(BatchGetResponseStatus.Running)]
    [InlineData(BatchGetResponseStatus.Throttled)]
    public void SerializationRoundtrip_Works(BatchGetResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchGetResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BatchGetResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchGetResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BatchGetResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BatchGetResponseResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchGetResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = BatchGetResponseResultJobReferenceType.ParseV2,
            },
        };

        string expectedSourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedErrorMessage = "error_message";
        BatchGetResponseResultJobReference expectedJobReference = new()
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchGetResponseResultJobReferenceType.ParseV2,
        };

        Assert.Equal(expectedSourceDirectoryFileID, model.SourceDirectoryFileID);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedJobReference, model.JobReference);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchGetResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = BatchGetResponseResultJobReferenceType.ParseV2,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchGetResponseResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchGetResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = BatchGetResponseResultJobReferenceType.ParseV2,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchGetResponseResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedErrorMessage = "error_message";
        BatchGetResponseResultJobReference expectedJobReference = new()
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchGetResponseResultJobReferenceType.ParseV2,
        };

        Assert.Equal(expectedSourceDirectoryFileID, deserialized.SourceDirectoryFileID);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedJobReference, deserialized.JobReference);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchGetResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = BatchGetResponseResultJobReferenceType.ParseV2,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BatchGetResponseResult
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
        var model = new BatchGetResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BatchGetResponseResult
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
        var model = new BatchGetResponseResult
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
        var model = new BatchGetResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = BatchGetResponseResultJobReferenceType.ParseV2,
            },
        };

        BatchGetResponseResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchGetResponseResultJobReferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchGetResponseResultJobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchGetResponseResultJobReferenceType.ParseV2,
        };

        string expectedID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        ApiEnum<string, BatchGetResponseResultJobReferenceType> expectedType =
            BatchGetResponseResultJobReferenceType.ParseV2;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchGetResponseResultJobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchGetResponseResultJobReferenceType.ParseV2,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchGetResponseResultJobReference>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchGetResponseResultJobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchGetResponseResultJobReferenceType.ParseV2,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchGetResponseResultJobReference>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        ApiEnum<string, BatchGetResponseResultJobReferenceType> expectedType =
            BatchGetResponseResultJobReferenceType.ParseV2;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchGetResponseResultJobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchGetResponseResultJobReferenceType.ParseV2,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchGetResponseResultJobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchGetResponseResultJobReferenceType.ParseV2,
        };

        BatchGetResponseResultJobReference copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchGetResponseResultJobReferenceTypeTest : TestBase
{
    [Theory]
    [InlineData(BatchGetResponseResultJobReferenceType.ParseV2)]
    [InlineData(BatchGetResponseResultJobReferenceType.ExtractV2)]
    public void Validation_Works(BatchGetResponseResultJobReferenceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchGetResponseResultJobReferenceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BatchGetResponseResultJobReferenceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BatchGetResponseResultJobReferenceType.ParseV2)]
    [InlineData(BatchGetResponseResultJobReferenceType.ExtractV2)]
    public void SerializationRoundtrip_Works(BatchGetResponseResultJobReferenceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchGetResponseResultJobReferenceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BatchGetResponseResultJobReferenceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BatchGetResponseResultJobReferenceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BatchGetResponseResultJobReferenceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
