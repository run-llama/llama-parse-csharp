using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class ParsingDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ParsingDeleteResponse
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        string expectedID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedProjectID = "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedProjectID, model.ProjectID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ParsingDeleteResponse
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsingDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ParsingDeleteResponse
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsingDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedProjectID = "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ParsingDeleteResponse
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ParsingDeleteResponse
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
        };

        ParsingDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
