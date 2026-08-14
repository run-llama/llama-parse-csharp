using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class ManagedIngestionStatusResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ManagedIngestionStatusResponse
        {
            Status = Status.Cancelled,
            DeploymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Error =
            [
                new()
                {
                    JobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Message = "message",
                    Step = Step.DataSource,
                },
            ],
            JobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ApiEnum<string, Status> expectedStatus = Status.Cancelled;
        DateTimeOffset expectedDeploymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Error> expectedError =
        [
            new()
            {
                JobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Message = "message",
                Step = Step.DataSource,
            },
        ];
        string expectedJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedDeploymentDate, model.DeploymentDate);
        Assert.Equal(expectedEffectiveAt, model.EffectiveAt);
        Assert.NotNull(model.Error);
        Assert.Equal(expectedError.Count, model.Error.Count);
        for (int i = 0; i < expectedError.Count; i++)
        {
            Assert.Equal(expectedError[i], model.Error[i]);
        }
        Assert.Equal(expectedJobID, model.JobID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ManagedIngestionStatusResponse
        {
            Status = Status.Cancelled,
            DeploymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Error =
            [
                new()
                {
                    JobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Message = "message",
                    Step = Step.DataSource,
                },
            ],
            JobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ManagedIngestionStatusResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ManagedIngestionStatusResponse
        {
            Status = Status.Cancelled,
            DeploymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Error =
            [
                new()
                {
                    JobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Message = "message",
                    Step = Step.DataSource,
                },
            ],
            JobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ManagedIngestionStatusResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Status> expectedStatus = Status.Cancelled;
        DateTimeOffset expectedDeploymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Error> expectedError =
        [
            new()
            {
                JobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Message = "message",
                Step = Step.DataSource,
            },
        ];
        string expectedJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedDeploymentDate, deserialized.DeploymentDate);
        Assert.Equal(expectedEffectiveAt, deserialized.EffectiveAt);
        Assert.NotNull(deserialized.Error);
        Assert.Equal(expectedError.Count, deserialized.Error.Count);
        for (int i = 0; i < expectedError.Count; i++)
        {
            Assert.Equal(expectedError[i], deserialized.Error[i]);
        }
        Assert.Equal(expectedJobID, deserialized.JobID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ManagedIngestionStatusResponse
        {
            Status = Status.Cancelled,
            DeploymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Error =
            [
                new()
                {
                    JobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Message = "message",
                    Step = Step.DataSource,
                },
            ],
            JobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ManagedIngestionStatusResponse { Status = Status.Cancelled };

        Assert.Null(model.DeploymentDate);
        Assert.False(model.RawData.ContainsKey("deployment_date"));
        Assert.Null(model.EffectiveAt);
        Assert.False(model.RawData.ContainsKey("effective_at"));
        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.JobID);
        Assert.False(model.RawData.ContainsKey("job_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ManagedIngestionStatusResponse { Status = Status.Cancelled };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ManagedIngestionStatusResponse
        {
            Status = Status.Cancelled,

            DeploymentDate = null,
            EffectiveAt = null,
            Error = null,
            JobID = null,
        };

        Assert.Null(model.DeploymentDate);
        Assert.True(model.RawData.ContainsKey("deployment_date"));
        Assert.Null(model.EffectiveAt);
        Assert.True(model.RawData.ContainsKey("effective_at"));
        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
        Assert.Null(model.JobID);
        Assert.True(model.RawData.ContainsKey("job_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ManagedIngestionStatusResponse
        {
            Status = Status.Cancelled,

            DeploymentDate = null,
            EffectiveAt = null,
            Error = null,
            JobID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ManagedIngestionStatusResponse
        {
            Status = Status.Cancelled,
            DeploymentDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Error =
            [
                new()
                {
                    JobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Message = "message",
                    Step = Step.DataSource,
                },
            ],
            JobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ManagedIngestionStatusResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Cancelled)]
    [InlineData(Status.Error)]
    [InlineData(Status.InProgress)]
    [InlineData(Status.NotStarted)]
    [InlineData(Status.PartialSuccess)]
    [InlineData(Status.Success)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Cancelled)]
    [InlineData(Status.Error)]
    [InlineData(Status.InProgress)]
    [InlineData(Status.NotStarted)]
    [InlineData(Status.PartialSuccess)]
    [InlineData(Status.Success)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Error
        {
            JobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Message = "message",
            Step = Step.DataSource,
        };

        string expectedJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedMessage = "message";
        ApiEnum<string, Step> expectedStep = Step.DataSource;

        Assert.Equal(expectedJobID, model.JobID);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedStep, model.Step);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Error
        {
            JobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Message = "message",
            Step = Step.DataSource,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Error
        {
            JobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Message = "message",
            Step = Step.DataSource,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedJobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedMessage = "message";
        ApiEnum<string, Step> expectedStep = Step.DataSource;

        Assert.Equal(expectedJobID, deserialized.JobID);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedStep, deserialized.Step);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Error
        {
            JobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Message = "message",
            Step = Step.DataSource,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Error
        {
            JobID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Message = "message",
            Step = Step.DataSource,
        };

        Error copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StepTest : TestBase
{
    [Theory]
    [InlineData(Step.DataSource)]
    [InlineData(Step.FileUpdater)]
    [InlineData(Step.Ingestion)]
    [InlineData(Step.ManagedIngestion)]
    [InlineData(Step.MetadataUpdate)]
    [InlineData(Step.Parse)]
    [InlineData(Step.Transform)]
    public void Validation_Works(Step rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Step> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Step>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Step.DataSource)]
    [InlineData(Step.FileUpdater)]
    [InlineData(Step.Ingestion)]
    [InlineData(Step.ManagedIngestion)]
    [InlineData(Step.MetadataUpdate)]
    [InlineData(Step.Parse)]
    [InlineData(Step.Transform)]
    public void SerializationRoundtrip_Works(Step rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Step> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Step>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Step>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Step>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
