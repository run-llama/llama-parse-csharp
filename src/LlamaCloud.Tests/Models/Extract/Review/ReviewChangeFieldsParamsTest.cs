using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Extract.Review;

namespace LlamaCloud.Tests.Models.Extract.Review;

public class ReviewChangeFieldsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ReviewChangeFieldsParams
        {
            JobID = "job_id",
            Changes =
            [
                new()
                {
                    ChangeValue = ChangeChange.Correct,
                    Path = "/total",
                    Value = JsonSerializer.SerializeToElement(1250.5),
                },
            ],
            Revision = 0,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedJobID = "job_id";
        List<Change> expectedChanges =
        [
            new()
            {
                ChangeValue = ChangeChange.Correct,
                Path = "/total",
                Value = JsonSerializer.SerializeToElement(1250.5),
            },
        ];
        long expectedRevision = 0;
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedJobID, parameters.JobID);
        Assert.Equal(expectedChanges.Count, parameters.Changes.Count);
        for (int i = 0; i < expectedChanges.Count; i++)
        {
            Assert.Equal(expectedChanges[i], parameters.Changes[i]);
        }
        Assert.Equal(expectedRevision, parameters.Revision);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ReviewChangeFieldsParams
        {
            JobID = "job_id",
            Changes =
            [
                new()
                {
                    ChangeValue = ChangeChange.Correct,
                    Path = "/total",
                    Value = JsonSerializer.SerializeToElement(1250.5),
                },
            ],
            Revision = 0,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ReviewChangeFieldsParams
        {
            JobID = "job_id",
            Changes =
            [
                new()
                {
                    ChangeValue = ChangeChange.Correct,
                    Path = "/total",
                    Value = JsonSerializer.SerializeToElement(1250.5),
                },
            ],
            Revision = 0,

            OrganizationID = null,
            ProjectID = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void Url_Works()
    {
        ReviewChangeFieldsParams parameters = new()
        {
            JobID = "job_id",
            Changes =
            [
                new()
                {
                    ChangeValue = ChangeChange.Correct,
                    Path = "/total",
                    Value = JsonSerializer.SerializeToElement(1250.5),
                },
            ],
            Revision = 0,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v2/extract/job_id/review/fields?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ReviewChangeFieldsParams
        {
            JobID = "job_id",
            Changes =
            [
                new()
                {
                    ChangeValue = ChangeChange.Correct,
                    Path = "/total",
                    Value = JsonSerializer.SerializeToElement(1250.5),
                },
            ],
            Revision = 0,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        ReviewChangeFieldsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ChangeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Change
        {
            ChangeValue = ChangeChange.Correct,
            Path = "/total",
            Value = JsonSerializer.SerializeToElement(1250.5),
        };

        ApiEnum<string, ChangeChange> expectedChangeValue = ChangeChange.Correct;
        string expectedPath = "/total";
        JsonElement expectedValue = JsonSerializer.SerializeToElement(1250.5);

        Assert.Equal(expectedChangeValue, model.ChangeValue);
        Assert.Equal(expectedPath, model.Path);
        Assert.NotNull(model.Value);
        Assert.True(JsonElement.DeepEquals(expectedValue, model.Value.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Change
        {
            ChangeValue = ChangeChange.Correct,
            Path = "/total",
            Value = JsonSerializer.SerializeToElement(1250.5),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Change>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Change
        {
            ChangeValue = ChangeChange.Correct,
            Path = "/total",
            Value = JsonSerializer.SerializeToElement(1250.5),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Change>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApiEnum<string, ChangeChange> expectedChangeValue = ChangeChange.Correct;
        string expectedPath = "/total";
        JsonElement expectedValue = JsonSerializer.SerializeToElement(1250.5);

        Assert.Equal(expectedChangeValue, deserialized.ChangeValue);
        Assert.Equal(expectedPath, deserialized.Path);
        Assert.NotNull(deserialized.Value);
        Assert.True(JsonElement.DeepEquals(expectedValue, deserialized.Value.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Change
        {
            ChangeValue = ChangeChange.Correct,
            Path = "/total",
            Value = JsonSerializer.SerializeToElement(1250.5),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Change { ChangeValue = ChangeChange.Correct, Path = "/total" };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Change { ChangeValue = ChangeChange.Correct, Path = "/total" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Change
        {
            ChangeValue = ChangeChange.Correct,
            Path = "/total",

            // Null should be interpreted as omitted for these properties
            Value = null,
        };

        Assert.Null(model.Value);
        Assert.False(model.RawData.ContainsKey("value"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Change
        {
            ChangeValue = ChangeChange.Correct,
            Path = "/total",

            // Null should be interpreted as omitted for these properties
            Value = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Change
        {
            ChangeValue = ChangeChange.Correct,
            Path = "/total",
            Value = JsonSerializer.SerializeToElement(1250.5),
        };

        Change copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChangeChangeTest : TestBase
{
    [Theory]
    [InlineData(ChangeChange.Clear)]
    [InlineData(ChangeChange.Confirm)]
    [InlineData(ChangeChange.Correct)]
    [InlineData(ChangeChange.Restore)]
    [InlineData(ChangeChange.Undo)]
    public void Validation_Works(ChangeChange rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChangeChange> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChangeChange>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChangeChange.Clear)]
    [InlineData(ChangeChange.Confirm)]
    [InlineData(ChangeChange.Correct)]
    [InlineData(ChangeChange.Restore)]
    [InlineData(ChangeChange.Undo)]
    public void SerializationRoundtrip_Works(ChangeChange rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChangeChange> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChangeChange>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChangeChange>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChangeChange>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
