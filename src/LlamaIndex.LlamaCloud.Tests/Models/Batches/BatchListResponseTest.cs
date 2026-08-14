using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Batches;

namespace LlamaIndex.LlamaCloud.Tests.Models.Batches;

public class BatchListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchListResponse
        {
            ID = "id",
            Config = new(
                new BatchListResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchListResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchListResponseStatus.Cancelled,
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
                        Type = BatchListResponseResultJobReferenceType.ParseV2,
                    },
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        BatchListResponseConfig expectedConfig = new(
            new BatchListResponseConfigJob()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchListResponseConfigJobType.ParseV2,
            }
        );
        string expectedProjectID = "project_id";
        string expectedSourceDirectoryID = "source_directory_id";
        ApiEnum<string, BatchListResponseStatus> expectedStatus = BatchListResponseStatus.Cancelled;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<BatchListResponseResult> expectedResults =
        [
            new()
            {
                SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ErrorMessage = "error_message",
                JobReference = new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Type = BatchListResponseResultJobReferenceType.ParseV2,
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
        var model = new BatchListResponse
        {
            ID = "id",
            Config = new(
                new BatchListResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchListResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchListResponseStatus.Cancelled,
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
                        Type = BatchListResponseResultJobReferenceType.ParseV2,
                    },
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchListResponse
        {
            ID = "id",
            Config = new(
                new BatchListResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchListResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchListResponseStatus.Cancelled,
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
                        Type = BatchListResponseResultJobReferenceType.ParseV2,
                    },
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        BatchListResponseConfig expectedConfig = new(
            new BatchListResponseConfigJob()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchListResponseConfigJobType.ParseV2,
            }
        );
        string expectedProjectID = "project_id";
        string expectedSourceDirectoryID = "source_directory_id";
        ApiEnum<string, BatchListResponseStatus> expectedStatus = BatchListResponseStatus.Cancelled;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<BatchListResponseResult> expectedResults =
        [
            new()
            {
                SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ErrorMessage = "error_message",
                JobReference = new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Type = BatchListResponseResultJobReferenceType.ParseV2,
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
        var model = new BatchListResponse
        {
            ID = "id",
            Config = new(
                new BatchListResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchListResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchListResponseStatus.Cancelled,
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
                        Type = BatchListResponseResultJobReferenceType.ParseV2,
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
        var model = new BatchListResponse
        {
            ID = "id",
            Config = new(
                new BatchListResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchListResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchListResponseStatus.Cancelled,
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
        var model = new BatchListResponse
        {
            ID = "id",
            Config = new(
                new BatchListResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchListResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchListResponseStatus.Cancelled,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BatchListResponse
        {
            ID = "id",
            Config = new(
                new BatchListResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchListResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchListResponseStatus.Cancelled,

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
        var model = new BatchListResponse
        {
            ID = "id",
            Config = new(
                new BatchListResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchListResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchListResponseStatus.Cancelled,

            CreatedAt = null,
            Results = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchListResponse
        {
            ID = "id",
            Config = new(
                new BatchListResponseConfigJob()
                {
                    ConfigurationID = "cfg-PARSE_AGENTIC",
                    Type = BatchListResponseConfigJobType.ParseV2,
                }
            ),
            ProjectID = "project_id",
            SourceDirectoryID = "source_directory_id",
            Status = BatchListResponseStatus.Cancelled,
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
                        Type = BatchListResponseResultJobReferenceType.ParseV2,
                    },
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BatchListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchListResponseConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchListResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchListResponseConfigJobType.ParseV2,
            },
        };

        BatchListResponseConfigJob expectedJob = new()
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchListResponseConfigJobType.ParseV2,
        };

        Assert.Equal(expectedJob, model.Job);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchListResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchListResponseConfigJobType.ParseV2,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchListResponseConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchListResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchListResponseConfigJobType.ParseV2,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchListResponseConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BatchListResponseConfigJob expectedJob = new()
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchListResponseConfigJobType.ParseV2,
        };

        Assert.Equal(expectedJob, deserialized.Job);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchListResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchListResponseConfigJobType.ParseV2,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchListResponseConfig
        {
            Job = new()
            {
                ConfigurationID = "cfg-PARSE_AGENTIC",
                Type = BatchListResponseConfigJobType.ParseV2,
            },
        };

        BatchListResponseConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchListResponseConfigJobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchListResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchListResponseConfigJobType.ParseV2,
        };

        string expectedConfigurationID = "cfg-PARSE_AGENTIC";
        ApiEnum<string, BatchListResponseConfigJobType> expectedType =
            BatchListResponseConfigJobType.ParseV2;

        Assert.Equal(expectedConfigurationID, model.ConfigurationID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchListResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchListResponseConfigJobType.ParseV2,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchListResponseConfigJob>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchListResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchListResponseConfigJobType.ParseV2,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchListResponseConfigJob>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedConfigurationID = "cfg-PARSE_AGENTIC";
        ApiEnum<string, BatchListResponseConfigJobType> expectedType =
            BatchListResponseConfigJobType.ParseV2;

        Assert.Equal(expectedConfigurationID, deserialized.ConfigurationID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchListResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchListResponseConfigJobType.ParseV2,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchListResponseConfigJob
        {
            ConfigurationID = "cfg-PARSE_AGENTIC",
            Type = BatchListResponseConfigJobType.ParseV2,
        };

        BatchListResponseConfigJob copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchListResponseConfigJobTypeTest : TestBase
{
    [Theory]
    [InlineData(BatchListResponseConfigJobType.ParseV2)]
    [InlineData(BatchListResponseConfigJobType.ExtractV2)]
    public void Validation_Works(BatchListResponseConfigJobType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchListResponseConfigJobType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchListResponseConfigJobType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BatchListResponseConfigJobType.ParseV2)]
    [InlineData(BatchListResponseConfigJobType.ExtractV2)]
    public void SerializationRoundtrip_Works(BatchListResponseConfigJobType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchListResponseConfigJobType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BatchListResponseConfigJobType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchListResponseConfigJobType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BatchListResponseConfigJobType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BatchListResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(BatchListResponseStatus.Cancelled)]
    [InlineData(BatchListResponseStatus.Completed)]
    [InlineData(BatchListResponseStatus.Failed)]
    [InlineData(BatchListResponseStatus.Pending)]
    [InlineData(BatchListResponseStatus.Running)]
    [InlineData(BatchListResponseStatus.Throttled)]
    public void Validation_Works(BatchListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchListResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BatchListResponseStatus.Cancelled)]
    [InlineData(BatchListResponseStatus.Completed)]
    [InlineData(BatchListResponseStatus.Failed)]
    [InlineData(BatchListResponseStatus.Pending)]
    [InlineData(BatchListResponseStatus.Running)]
    [InlineData(BatchListResponseStatus.Throttled)]
    public void SerializationRoundtrip_Works(BatchListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchListResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BatchListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BatchListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BatchListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BatchListResponseResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchListResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = BatchListResponseResultJobReferenceType.ParseV2,
            },
        };

        string expectedSourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedErrorMessage = "error_message";
        BatchListResponseResultJobReference expectedJobReference = new()
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchListResponseResultJobReferenceType.ParseV2,
        };

        Assert.Equal(expectedSourceDirectoryFileID, model.SourceDirectoryFileID);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedJobReference, model.JobReference);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchListResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = BatchListResponseResultJobReferenceType.ParseV2,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchListResponseResult>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchListResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = BatchListResponseResultJobReferenceType.ParseV2,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchListResponseResult>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedErrorMessage = "error_message";
        BatchListResponseResultJobReference expectedJobReference = new()
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchListResponseResultJobReferenceType.ParseV2,
        };

        Assert.Equal(expectedSourceDirectoryFileID, deserialized.SourceDirectoryFileID);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedJobReference, deserialized.JobReference);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchListResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = BatchListResponseResultJobReferenceType.ParseV2,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BatchListResponseResult
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
        var model = new BatchListResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BatchListResponseResult
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
        var model = new BatchListResponseResult
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
        var model = new BatchListResponseResult
        {
            SourceDirectoryFileID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ErrorMessage = "error_message",
            JobReference = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Type = BatchListResponseResultJobReferenceType.ParseV2,
            },
        };

        BatchListResponseResult copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchListResponseResultJobReferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BatchListResponseResultJobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchListResponseResultJobReferenceType.ParseV2,
        };

        string expectedID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        ApiEnum<string, BatchListResponseResultJobReferenceType> expectedType =
            BatchListResponseResultJobReferenceType.ParseV2;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BatchListResponseResultJobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchListResponseResultJobReferenceType.ParseV2,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchListResponseResultJobReference>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BatchListResponseResultJobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchListResponseResultJobReferenceType.ParseV2,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BatchListResponseResultJobReference>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        ApiEnum<string, BatchListResponseResultJobReferenceType> expectedType =
            BatchListResponseResultJobReferenceType.ParseV2;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BatchListResponseResultJobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchListResponseResultJobReferenceType.ParseV2,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BatchListResponseResultJobReference
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Type = BatchListResponseResultJobReferenceType.ParseV2,
        };

        BatchListResponseResultJobReference copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BatchListResponseResultJobReferenceTypeTest : TestBase
{
    [Theory]
    [InlineData(BatchListResponseResultJobReferenceType.ParseV2)]
    [InlineData(BatchListResponseResultJobReferenceType.ExtractV2)]
    public void Validation_Works(BatchListResponseResultJobReferenceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchListResponseResultJobReferenceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BatchListResponseResultJobReferenceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BatchListResponseResultJobReferenceType.ParseV2)]
    [InlineData(BatchListResponseResultJobReferenceType.ExtractV2)]
    public void SerializationRoundtrip_Works(BatchListResponseResultJobReferenceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BatchListResponseResultJobReferenceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BatchListResponseResultJobReferenceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BatchListResponseResultJobReferenceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BatchListResponseResultJobReferenceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
