using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines;

namespace LlamaCloud.Tests.Models.Pipelines;

public class MetadataFiltersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MetadataFilters
        {
            Filters =
            [
                new MetadataFilter()
                {
                    Key = "key",
                    Value = 0,
                    Operator = Operator.Undefined,
                },
            ],
            Condition = Condition.And,
        };

        List<Filter> expectedFilters =
        [
            new MetadataFilter()
            {
                Key = "key",
                Value = 0,
                Operator = Operator.Undefined,
            },
        ];
        ApiEnum<string, Condition> expectedCondition = Condition.And;

        Assert.Equal(expectedFilters.Count, model.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], model.Filters[i]);
        }
        Assert.Equal(expectedCondition, model.Condition);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MetadataFilters
        {
            Filters =
            [
                new MetadataFilter()
                {
                    Key = "key",
                    Value = 0,
                    Operator = Operator.Undefined,
                },
            ],
            Condition = Condition.And,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataFilters>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MetadataFilters
        {
            Filters =
            [
                new MetadataFilter()
                {
                    Key = "key",
                    Value = 0,
                    Operator = Operator.Undefined,
                },
            ],
            Condition = Condition.And,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataFilters>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Filter> expectedFilters =
        [
            new MetadataFilter()
            {
                Key = "key",
                Value = 0,
                Operator = Operator.Undefined,
            },
        ];
        ApiEnum<string, Condition> expectedCondition = Condition.And;

        Assert.Equal(expectedFilters.Count, deserialized.Filters.Count);
        for (int i = 0; i < expectedFilters.Count; i++)
        {
            Assert.Equal(expectedFilters[i], deserialized.Filters[i]);
        }
        Assert.Equal(expectedCondition, deserialized.Condition);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MetadataFilters
        {
            Filters =
            [
                new MetadataFilter()
                {
                    Key = "key",
                    Value = 0,
                    Operator = Operator.Undefined,
                },
            ],
            Condition = Condition.And,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MetadataFilters
        {
            Filters =
            [
                new MetadataFilter()
                {
                    Key = "key",
                    Value = 0,
                    Operator = Operator.Undefined,
                },
            ],
        };

        Assert.Null(model.Condition);
        Assert.False(model.RawData.ContainsKey("condition"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MetadataFilters
        {
            Filters =
            [
                new MetadataFilter()
                {
                    Key = "key",
                    Value = 0,
                    Operator = Operator.Undefined,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MetadataFilters
        {
            Filters =
            [
                new MetadataFilter()
                {
                    Key = "key",
                    Value = 0,
                    Operator = Operator.Undefined,
                },
            ],

            Condition = null,
        };

        Assert.Null(model.Condition);
        Assert.True(model.RawData.ContainsKey("condition"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MetadataFilters
        {
            Filters =
            [
                new MetadataFilter()
                {
                    Key = "key",
                    Value = 0,
                    Operator = Operator.Undefined,
                },
            ],

            Condition = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MetadataFilters
        {
            Filters =
            [
                new MetadataFilter()
                {
                    Key = "key",
                    Value = 0,
                    Operator = Operator.Undefined,
                },
            ],
            Condition = Condition.And,
        };

        MetadataFilters copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FilterTest : TestBase
{
    [Fact]
    public void MetadataValidationWorks()
    {
        Filter value = new MetadataFilter()
        {
            Key = "key",
            Value = 0,
            Operator = Operator.Undefined,
        };
        value.Validate();
    }

    [Fact]
    public void MetadataFiltersValidationWorks()
    {
        Filter value = new MetadataFilters()
        {
            Filters =
            [
                new MetadataFilter()
                {
                    Key = "key",
                    Value = 0,
                    Operator = Operator.Undefined,
                },
            ],
            Condition = Condition.And,
        };
        value.Validate();
    }

    [Fact]
    public void MetadataSerializationRoundtripWorks()
    {
        Filter value = new MetadataFilter()
        {
            Key = "key",
            Value = 0,
            Operator = Operator.Undefined,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Filter>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MetadataFiltersSerializationRoundtripWorks()
    {
        Filter value = new MetadataFilters()
        {
            Filters =
            [
                new MetadataFilter()
                {
                    Key = "key",
                    Value = 0,
                    Operator = Operator.Undefined,
                },
            ],
            Condition = Condition.And,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Filter>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MetadataFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MetadataFilter
        {
            Key = "key",
            Value = 0,
            Operator = Operator.Undefined,
        };

        string expectedKey = "key";
        MetadataFilterValue expectedValue = 0;
        ApiEnum<string, Operator> expectedOperator = Operator.Undefined;

        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedOperator, model.Operator);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MetadataFilter
        {
            Key = "key",
            Value = 0,
            Operator = Operator.Undefined,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MetadataFilter
        {
            Key = "key",
            Value = 0,
            Operator = Operator.Undefined,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedKey = "key";
        MetadataFilterValue expectedValue = 0;
        ApiEnum<string, Operator> expectedOperator = Operator.Undefined;

        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedOperator, deserialized.Operator);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MetadataFilter
        {
            Key = "key",
            Value = 0,
            Operator = Operator.Undefined,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MetadataFilter { Key = "key", Value = 0 };

        Assert.Null(model.Operator);
        Assert.False(model.RawData.ContainsKey("operator"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MetadataFilter { Key = "key", Value = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MetadataFilter
        {
            Key = "key",
            Value = 0,

            // Null should be interpreted as omitted for these properties
            Operator = null,
        };

        Assert.Null(model.Operator);
        Assert.False(model.RawData.ContainsKey("operator"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MetadataFilter
        {
            Key = "key",
            Value = 0,

            // Null should be interpreted as omitted for these properties
            Operator = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MetadataFilter
        {
            Key = "key",
            Value = 0,
            Operator = Operator.Undefined,
        };

        MetadataFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MetadataFilterValueTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        MetadataFilterValue value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        MetadataFilterValue value = "string";
        value.Validate();
    }

    [Fact]
    public void StringArrayValidationWorks()
    {
        MetadataFilterValue value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void NumberArrayValidationWorks()
    {
        MetadataFilterValue value = new List<double>() { 0 };
        value.Validate();
    }

    [Fact]
    public void IntegerArrayValidationWorks()
    {
        MetadataFilterValue value = new List<long>() { 0 };
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        MetadataFilterValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataFilterValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MetadataFilterValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataFilterValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringArraySerializationRoundtripWorks()
    {
        MetadataFilterValue value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataFilterValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NumberArraySerializationRoundtripWorks()
    {
        MetadataFilterValue value = new List<double>() { 0 };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataFilterValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void IntegerArraySerializationRoundtripWorks()
    {
        MetadataFilterValue value = new List<long>() { 0 };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MetadataFilterValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class OperatorTest : TestBase
{
    [Theory]
    [InlineData(Operator.Undefined)]
    [InlineData(Operator.V1)]
    [InlineData(Operator.V2)]
    [InlineData(Operator.V3)]
    [InlineData(Operator.V4)]
    [InlineData(Operator.V5)]
    [InlineData(Operator.All)]
    [InlineData(Operator.Any)]
    [InlineData(Operator.Contains)]
    [InlineData(Operator.In)]
    [InlineData(Operator.IsEmpty)]
    [InlineData(Operator.Nin)]
    [InlineData(Operator.TextMatch)]
    [InlineData(Operator.TextMatchInsensitive)]
    public void Validation_Works(Operator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Operator.Undefined)]
    [InlineData(Operator.V1)]
    [InlineData(Operator.V2)]
    [InlineData(Operator.V3)]
    [InlineData(Operator.V4)]
    [InlineData(Operator.V5)]
    [InlineData(Operator.All)]
    [InlineData(Operator.Any)]
    [InlineData(Operator.Contains)]
    [InlineData(Operator.In)]
    [InlineData(Operator.IsEmpty)]
    [InlineData(Operator.Nin)]
    [InlineData(Operator.TextMatch)]
    [InlineData(Operator.TextMatchInsensitive)]
    public void SerializationRoundtrip_Works(Operator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Operator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Operator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ConditionTest : TestBase
{
    [Theory]
    [InlineData(Condition.And)]
    [InlineData(Condition.Not)]
    [InlineData(Condition.Or)]
    public void Validation_Works(Condition rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Condition> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Condition>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Condition.And)]
    [InlineData(Condition.Not)]
    [InlineData(Condition.Or)]
    public void SerializationRoundtrip_Works(Condition rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Condition> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Condition>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Condition>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Condition>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
