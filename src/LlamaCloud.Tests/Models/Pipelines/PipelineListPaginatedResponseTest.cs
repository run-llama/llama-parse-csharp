using System;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Tests.Models.Pipelines;

public class PipelineListPaginatedResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PipelineListPaginatedResponse
        {
            ID = "id",
            Name = "name",
            PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
            ProjectID = "project_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PipelineListPaginatedResponseStatus.Created,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedName = "name";
        ApiEnum<string, PipelineListPaginatedResponsePipelineType> expectedPipelineType =
            PipelineListPaginatedResponsePipelineType.Managed;
        string expectedProjectID = "project_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, PipelineListPaginatedResponseStatus> expectedStatus =
            PipelineListPaginatedResponseStatus.Created;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPipelineType, model.PipelineType);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PipelineListPaginatedResponse
        {
            ID = "id",
            Name = "name",
            PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
            ProjectID = "project_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PipelineListPaginatedResponseStatus.Created,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineListPaginatedResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PipelineListPaginatedResponse
        {
            ID = "id",
            Name = "name",
            PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
            ProjectID = "project_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PipelineListPaginatedResponseStatus.Created,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineListPaginatedResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";
        ApiEnum<string, PipelineListPaginatedResponsePipelineType> expectedPipelineType =
            PipelineListPaginatedResponsePipelineType.Managed;
        string expectedProjectID = "project_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, PipelineListPaginatedResponseStatus> expectedStatus =
            PipelineListPaginatedResponseStatus.Created;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPipelineType, deserialized.PipelineType);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PipelineListPaginatedResponse
        {
            ID = "id",
            Name = "name",
            PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
            ProjectID = "project_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PipelineListPaginatedResponseStatus.Created,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PipelineListPaginatedResponse
        {
            ID = "id",
            Name = "name",
            PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
            ProjectID = "project_id",
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PipelineListPaginatedResponse
        {
            ID = "id",
            Name = "name",
            PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
            ProjectID = "project_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PipelineListPaginatedResponse
        {
            ID = "id",
            Name = "name",
            PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
            ProjectID = "project_id",

            CreatedAt = null,
            Status = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PipelineListPaginatedResponse
        {
            ID = "id",
            Name = "name",
            PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
            ProjectID = "project_id",

            CreatedAt = null,
            Status = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PipelineListPaginatedResponse
        {
            ID = "id",
            Name = "name",
            PipelineType = PipelineListPaginatedResponsePipelineType.Managed,
            ProjectID = "project_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = PipelineListPaginatedResponseStatus.Created,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        PipelineListPaginatedResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PipelineListPaginatedResponsePipelineTypeTest : TestBase
{
    [Theory]
    [InlineData(PipelineListPaginatedResponsePipelineType.Managed)]
    [InlineData(PipelineListPaginatedResponsePipelineType.Playground)]
    public void Validation_Works(PipelineListPaginatedResponsePipelineType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PipelineListPaginatedResponsePipelineType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PipelineListPaginatedResponsePipelineType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PipelineListPaginatedResponsePipelineType.Managed)]
    [InlineData(PipelineListPaginatedResponsePipelineType.Playground)]
    public void SerializationRoundtrip_Works(PipelineListPaginatedResponsePipelineType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PipelineListPaginatedResponsePipelineType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PipelineListPaginatedResponsePipelineType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PipelineListPaginatedResponsePipelineType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PipelineListPaginatedResponsePipelineType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PipelineListPaginatedResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(PipelineListPaginatedResponseStatus.Created)]
    [InlineData(PipelineListPaginatedResponseStatus.Deleting)]
    public void Validation_Works(PipelineListPaginatedResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PipelineListPaginatedResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PipelineListPaginatedResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PipelineListPaginatedResponseStatus.Created)]
    [InlineData(PipelineListPaginatedResponseStatus.Deleting)]
    public void SerializationRoundtrip_Works(PipelineListPaginatedResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PipelineListPaginatedResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PipelineListPaginatedResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PipelineListPaginatedResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PipelineListPaginatedResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
