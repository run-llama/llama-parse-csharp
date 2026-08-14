using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.Split;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Split;

public class SplitGetResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInput = new() { Type = "type", Value = "value" },
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            Result = new(
                [
                    new()
                    {
                        Category = "category",
                        ConfidenceCategory = "confidence_category",
                        Pages = [0],
                    },
                ]
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        List<SplitCategory> expectedCategories = [new() { Name = "x", Description = "x" }];
        SplitDocumentInput expectedDocumentInput = new() { Type = "type", Value = "value" };
        string expectedProjectID = "project_id";
        string expectedStatus = "status";
        string expectedUserID = "user_id";
        string expectedConfigurationID = "configuration_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        SplitResultResponse expectedResult = new(
            [
                new()
                {
                    Category = "category",
                    ConfidenceCategory = "confidence_category",
                    Pages = [0],
                },
            ]
        );
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCategories.Count, model.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], model.Categories[i]);
        }
        Assert.Equal(expectedDocumentInput, model.DocumentInput);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedConfigurationID, model.ConfigurationID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInput = new() { Type = "type", Value = "value" },
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            Result = new(
                [
                    new()
                    {
                        Category = "category",
                        ConfidenceCategory = "confidence_category",
                        Pages = [0],
                    },
                ]
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitGetResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInput = new() { Type = "type", Value = "value" },
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            Result = new(
                [
                    new()
                    {
                        Category = "category",
                        ConfidenceCategory = "confidence_category",
                        Pages = [0],
                    },
                ]
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SplitGetResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<SplitCategory> expectedCategories = [new() { Name = "x", Description = "x" }];
        SplitDocumentInput expectedDocumentInput = new() { Type = "type", Value = "value" };
        string expectedProjectID = "project_id";
        string expectedStatus = "status";
        string expectedUserID = "user_id";
        string expectedConfigurationID = "configuration_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        SplitResultResponse expectedResult = new(
            [
                new()
                {
                    Category = "category",
                    ConfidenceCategory = "confidence_category",
                    Pages = [0],
                },
            ]
        );
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCategories.Count, deserialized.Categories.Count);
        for (int i = 0; i < expectedCategories.Count; i++)
        {
            Assert.Equal(expectedCategories[i], deserialized.Categories[i]);
        }
        Assert.Equal(expectedDocumentInput, deserialized.DocumentInput);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedConfigurationID, deserialized.ConfigurationID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInput = new() { Type = "type", Value = "value" },
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            Result = new(
                [
                    new()
                    {
                        Category = "category",
                        ConfidenceCategory = "confidence_category",
                        Pages = [0],
                    },
                ]
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInput = new() { Type = "type", Value = "value" },
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
        };

        Assert.Null(model.ConfigurationID);
        Assert.False(model.RawData.ContainsKey("configuration_id"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInput = new() { Type = "type", Value = "value" },
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInput = new() { Type = "type", Value = "value" },
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",

            ConfigurationID = null,
            CreatedAt = null,
            ErrorMessage = null,
            Result = null,
            UpdatedAt = null,
        };

        Assert.Null(model.ConfigurationID);
        Assert.True(model.RawData.ContainsKey("configuration_id"));
        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.Result);
        Assert.True(model.RawData.ContainsKey("result"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInput = new() { Type = "type", Value = "value" },
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",

            ConfigurationID = null,
            CreatedAt = null,
            ErrorMessage = null,
            Result = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SplitGetResponse
        {
            ID = "id",
            Categories = [new() { Name = "x", Description = "x" }],
            DocumentInput = new() { Type = "type", Value = "value" },
            ProjectID = "project_id",
            Status = "status",
            UserID = "user_id",
            ConfigurationID = "configuration_id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "error_message",
            Result = new(
                [
                    new()
                    {
                        Category = "category",
                        ConfidenceCategory = "confidence_category",
                        Pages = [0],
                    },
                ]
            ),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        SplitGetResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
