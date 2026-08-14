using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Parsing;

namespace LlamaIndex.LlamaCloud.Tests.Models.Parsing;

public class ParsingListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ParsingListResponse
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = ParsingListResponseStatus.Cancelled,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            Name = "Q4 Financial Report",
            Tier = "fast",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Usage = new() { Credits = 30 },
            UserMetadata = new Dictionary<string, string>()
            {
                { "owner", "jerry" },
                { "team", "research" },
            },
        };

        string expectedID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        ApiEnum<string, ParsingListResponseStatus> expectedStatus =
            ParsingListResponseStatus.Cancelled;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        string expectedName = "Q4 Financial Report";
        string expectedTier = "fast";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ParsingListResponseUsage expectedUsage = new() { Credits = 30 };
        Dictionary<string, string> expectedUserMetadata = new()
        {
            { "owner", "jerry" },
            { "team", "research" },
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTier, model.Tier);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUsage, model.Usage);
        Assert.NotNull(model.UserMetadata);
        Assert.Equal(expectedUserMetadata.Count, model.UserMetadata.Count);
        foreach (var item in expectedUserMetadata)
        {
            Assert.True(model.UserMetadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.UserMetadata[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ParsingListResponse
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = ParsingListResponseStatus.Cancelled,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            Name = "Q4 Financial Report",
            Tier = "fast",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Usage = new() { Credits = 30 },
            UserMetadata = new Dictionary<string, string>()
            {
                { "owner", "jerry" },
                { "team", "research" },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsingListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ParsingListResponse
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = ParsingListResponseStatus.Cancelled,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            Name = "Q4 Financial Report",
            Tier = "fast",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Usage = new() { Credits = 30 },
            UserMetadata = new Dictionary<string, string>()
            {
                { "owner", "jerry" },
                { "team", "research" },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsingListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        ApiEnum<string, ParsingListResponseStatus> expectedStatus =
            ParsingListResponseStatus.Cancelled;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        string expectedName = "Q4 Financial Report";
        string expectedTier = "fast";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ParsingListResponseUsage expectedUsage = new() { Credits = 30 };
        Dictionary<string, string> expectedUserMetadata = new()
        {
            { "owner", "jerry" },
            { "team", "research" },
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTier, deserialized.Tier);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUsage, deserialized.Usage);
        Assert.NotNull(deserialized.UserMetadata);
        Assert.Equal(expectedUserMetadata.Count, deserialized.UserMetadata.Count);
        foreach (var item in expectedUserMetadata)
        {
            Assert.True(deserialized.UserMetadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.UserMetadata[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ParsingListResponse
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = ParsingListResponseStatus.Cancelled,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            Name = "Q4 Financial Report",
            Tier = "fast",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Usage = new() { Credits = 30 },
            UserMetadata = new Dictionary<string, string>()
            {
                { "owner", "jerry" },
                { "team", "research" },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ParsingListResponse
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = ParsingListResponseStatus.Cancelled,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Tier);
        Assert.False(model.RawData.ContainsKey("tier"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
        Assert.Null(model.UserMetadata);
        Assert.False(model.RawData.ContainsKey("user_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ParsingListResponse
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = ParsingListResponseStatus.Cancelled,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ParsingListResponse
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = ParsingListResponseStatus.Cancelled,

            CreatedAt = null,
            ErrorMessage = null,
            Name = null,
            Tier = null,
            UpdatedAt = null,
            Usage = null,
            UserMetadata = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.Tier);
        Assert.True(model.RawData.ContainsKey("tier"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Usage);
        Assert.True(model.RawData.ContainsKey("usage"));
        Assert.Null(model.UserMetadata);
        Assert.True(model.RawData.ContainsKey("user_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ParsingListResponse
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = ParsingListResponseStatus.Cancelled,

            CreatedAt = null,
            ErrorMessage = null,
            Name = null,
            Tier = null,
            UpdatedAt = null,
            Usage = null,
            UserMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ParsingListResponse
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = ParsingListResponseStatus.Cancelled,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            Name = "Q4 Financial Report",
            Tier = "fast",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Usage = new() { Credits = 30 },
            UserMetadata = new Dictionary<string, string>()
            {
                { "owner", "jerry" },
                { "team", "research" },
            },
        };

        ParsingListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ParsingListResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(ParsingListResponseStatus.Cancelled)]
    [InlineData(ParsingListResponseStatus.Completed)]
    [InlineData(ParsingListResponseStatus.Failed)]
    [InlineData(ParsingListResponseStatus.Pending)]
    [InlineData(ParsingListResponseStatus.Running)]
    public void Validation_Works(ParsingListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ParsingListResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ParsingListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ParsingListResponseStatus.Cancelled)]
    [InlineData(ParsingListResponseStatus.Completed)]
    [InlineData(ParsingListResponseStatus.Failed)]
    [InlineData(ParsingListResponseStatus.Pending)]
    [InlineData(ParsingListResponseStatus.Running)]
    public void SerializationRoundtrip_Works(ParsingListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ParsingListResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ParsingListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ParsingListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ParsingListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ParsingListResponseUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ParsingListResponseUsage { Credits = 30 };

        double expectedCredits = 30;

        Assert.Equal(expectedCredits, model.Credits);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ParsingListResponseUsage { Credits = 30 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsingListResponseUsage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ParsingListResponseUsage { Credits = 30 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsingListResponseUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedCredits = 30;

        Assert.Equal(expectedCredits, deserialized.Credits);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ParsingListResponseUsage { Credits = 30 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ParsingListResponseUsage { };

        Assert.Null(model.Credits);
        Assert.False(model.RawData.ContainsKey("credits"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ParsingListResponseUsage { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ParsingListResponseUsage { Credits = null };

        Assert.Null(model.Credits);
        Assert.True(model.RawData.ContainsKey("credits"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ParsingListResponseUsage { Credits = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ParsingListResponseUsage { Credits = 30 };

        ParsingListResponseUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}
