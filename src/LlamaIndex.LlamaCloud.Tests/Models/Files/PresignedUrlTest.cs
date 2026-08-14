using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Files;

namespace LlamaIndex.LlamaCloud.Tests.Models.Files;

public class PresignedUrlTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PresignedUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            FormFields = new Dictionary<string, string>() { { "foo", "string" } },
        };

        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUrl = "https://example.com";
        Dictionary<string, string> expectedFormFields = new() { { "foo", "string" } };

        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedUrl, model.Url);
        Assert.NotNull(model.FormFields);
        Assert.Equal(expectedFormFields.Count, model.FormFields.Count);
        foreach (var item in expectedFormFields)
        {
            Assert.True(model.FormFields.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.FormFields[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PresignedUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            FormFields = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PresignedUrl>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PresignedUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            FormFields = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PresignedUrl>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUrl = "https://example.com";
        Dictionary<string, string> expectedFormFields = new() { { "foo", "string" } };

        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.NotNull(deserialized.FormFields);
        Assert.Equal(expectedFormFields.Count, deserialized.FormFields.Count);
        foreach (var item in expectedFormFields)
        {
            Assert.True(deserialized.FormFields.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.FormFields[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PresignedUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            FormFields = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PresignedUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
        };

        Assert.Null(model.FormFields);
        Assert.False(model.RawData.ContainsKey("form_fields"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PresignedUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PresignedUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",

            FormFields = null,
        };

        Assert.Null(model.FormFields);
        Assert.True(model.RawData.ContainsKey("form_fields"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PresignedUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",

            FormFields = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PresignedUrl
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            FormFields = new Dictionary<string, string>() { { "foo", "string" } },
        };

        PresignedUrl copied = new(model);

        Assert.Equal(model, copied);
    }
}
