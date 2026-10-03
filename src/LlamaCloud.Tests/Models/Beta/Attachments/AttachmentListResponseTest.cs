using System;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Beta.Attachments;

namespace LlamaCloud.Tests.Models.Beta.Attachments;

public class AttachmentListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AttachmentListResponse
        {
            Name = "name",
            Size = 0,
            LastModified = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedName = "name";
        long expectedSize = 0;
        DateTimeOffset expectedLastModified = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSize, model.Size);
        Assert.Equal(expectedLastModified, model.LastModified);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AttachmentListResponse
        {
            Name = "name",
            Size = 0,
            LastModified = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttachmentListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AttachmentListResponse
        {
            Name = "name",
            Size = 0,
            LastModified = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AttachmentListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        long expectedSize = 0;
        DateTimeOffset expectedLastModified = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSize, deserialized.Size);
        Assert.Equal(expectedLastModified, deserialized.LastModified);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AttachmentListResponse
        {
            Name = "name",
            Size = 0,
            LastModified = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AttachmentListResponse { Name = "name", Size = 0 };

        Assert.Null(model.LastModified);
        Assert.False(model.RawData.ContainsKey("last_modified"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new AttachmentListResponse { Name = "name", Size = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AttachmentListResponse
        {
            Name = "name",
            Size = 0,

            LastModified = null,
        };

        Assert.Null(model.LastModified);
        Assert.True(model.RawData.ContainsKey("last_modified"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AttachmentListResponse
        {
            Name = "name",
            Size = 0,

            LastModified = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AttachmentListResponse
        {
            Name = "name",
            Size = 0,
            LastModified = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        AttachmentListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
