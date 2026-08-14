using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Classifier.Jobs;

namespace LlamaIndex.LlamaCloud.Tests.Models.Classifier.Jobs;

public class ClassifierRuleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClassifierRule
        {
            Description = "contains invoice number, line items, and total amount",
            Type = "invoice",
        };

        string expectedDescription = "contains invoice number, line items, and total amount";
        string expectedType = "invoice";

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClassifierRule
        {
            Description = "contains invoice number, line items, and total amount",
            Type = "invoice",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClassifierRule>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClassifierRule
        {
            Description = "contains invoice number, line items, and total amount",
            Type = "invoice",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClassifierRule>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "contains invoice number, line items, and total amount";
        string expectedType = "invoice";

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClassifierRule
        {
            Description = "contains invoice number, line items, and total amount",
            Type = "invoice",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClassifierRule
        {
            Description = "contains invoice number, line items, and total amount",
            Type = "invoice",
        };

        ClassifierRule copied = new(model);

        Assert.Equal(model, copied);
    }
}
