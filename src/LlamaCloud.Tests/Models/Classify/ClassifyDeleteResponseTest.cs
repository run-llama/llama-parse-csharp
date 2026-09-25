using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Classify;

namespace LlamaCloud.Tests.Models.Classify;

public class ClassifyDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClassifyDeleteResponse
        {
            ID = "clj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        string expectedID = "clj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedProjectID = "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedProjectID, model.ProjectID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClassifyDeleteResponse
        {
            ID = "clj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClassifyDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClassifyDeleteResponse
        {
            ID = "clj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClassifyDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "clj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedProjectID = "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClassifyDeleteResponse
        {
            ID = "clj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ClassifyDeleteResponse { ID = "clj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee" };

        Assert.Null(model.ProjectID);
        Assert.False(model.RawData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ClassifyDeleteResponse { ID = "clj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ClassifyDeleteResponse
        {
            ID = "clj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",

            ProjectID = null,
        };

        Assert.Null(model.ProjectID);
        Assert.True(model.RawData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ClassifyDeleteResponse
        {
            ID = "clj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",

            ProjectID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClassifyDeleteResponse
        {
            ID = "clj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        ClassifyDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
