using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Beta.Retrieval;

namespace LlamaCloud.Tests.Models.Beta.Retrieval;

public class RetrievalRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RetrievalRetrieveParams
        {
            IndexID = "idx-abc123",
            Query = "What are the key findings?",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomFilters = new Dictionary<string, CustomFilter?>()
            {
                {
                    "foo",
                    new ValueFilter() { Operator = Operator.Eq, Value = "string" }
                },
            },
            FullTextPipelineWeight = 0,
            NumCandidates = 0,
            Rerank = new() { Enabled = true, TopN = 5 },
            ScoreThreshold = 0,
            StaticFilters = new()
            {
                ParsedDirectoryFileID = new()
                {
                    Operator = ParsedDirectoryFileIDOperator.Eq,
                    Value = "string",
                },
            },
            TopK = 10,
            VectorPipelineWeight = 0,
        };

        string expectedIndexID = "idx-abc123";
        string expectedQuery = "What are the key findings?";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Dictionary<string, CustomFilter?> expectedCustomFilters = new()
        {
            {
                "foo",
                new ValueFilter() { Operator = Operator.Eq, Value = "string" }
            },
        };
        double expectedFullTextPipelineWeight = 0;
        long expectedNumCandidates = 0;
        Rerank expectedRerank = new() { Enabled = true, TopN = 5 };
        double expectedScoreThreshold = 0;
        StaticFilters expectedStaticFilters = new()
        {
            ParsedDirectoryFileID = new()
            {
                Operator = ParsedDirectoryFileIDOperator.Eq,
                Value = "string",
            },
        };
        long expectedTopK = 10;
        double expectedVectorPipelineWeight = 0;

        Assert.Equal(expectedIndexID, parameters.IndexID);
        Assert.Equal(expectedQuery, parameters.Query);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.NotNull(parameters.CustomFilters);
        Assert.Equal(expectedCustomFilters.Count, parameters.CustomFilters.Count);
        foreach (var item in expectedCustomFilters)
        {
            Assert.True(parameters.CustomFilters.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.CustomFilters[item.Key]);
        }
        Assert.Equal(expectedFullTextPipelineWeight, parameters.FullTextPipelineWeight);
        Assert.Equal(expectedNumCandidates, parameters.NumCandidates);
        Assert.Equal(expectedRerank, parameters.Rerank);
        Assert.Equal(expectedScoreThreshold, parameters.ScoreThreshold);
        Assert.Equal(expectedStaticFilters, parameters.StaticFilters);
        Assert.Equal(expectedTopK, parameters.TopK);
        Assert.Equal(expectedVectorPipelineWeight, parameters.VectorPipelineWeight);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RetrievalRetrieveParams
        {
            IndexID = "idx-abc123",
            Query = "What are the key findings?",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomFilters = new Dictionary<string, CustomFilter?>()
            {
                {
                    "foo",
                    new ValueFilter() { Operator = Operator.Eq, Value = "string" }
                },
            },
            FullTextPipelineWeight = 0,
            NumCandidates = 0,
            ScoreThreshold = 0,
            StaticFilters = new()
            {
                ParsedDirectoryFileID = new()
                {
                    Operator = ParsedDirectoryFileIDOperator.Eq,
                    Value = "string",
                },
            },
            TopK = 10,
            VectorPipelineWeight = 0,
        };

        Assert.Null(parameters.Rerank);
        Assert.False(parameters.RawBodyData.ContainsKey("rerank"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RetrievalRetrieveParams
        {
            IndexID = "idx-abc123",
            Query = "What are the key findings?",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomFilters = new Dictionary<string, CustomFilter?>()
            {
                {
                    "foo",
                    new ValueFilter() { Operator = Operator.Eq, Value = "string" }
                },
            },
            FullTextPipelineWeight = 0,
            NumCandidates = 0,
            ScoreThreshold = 0,
            StaticFilters = new()
            {
                ParsedDirectoryFileID = new()
                {
                    Operator = ParsedDirectoryFileIDOperator.Eq,
                    Value = "string",
                },
            },
            TopK = 10,
            VectorPipelineWeight = 0,

            // Null should be interpreted as omitted for these properties
            Rerank = null,
        };

        Assert.Null(parameters.Rerank);
        Assert.False(parameters.RawBodyData.ContainsKey("rerank"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RetrievalRetrieveParams
        {
            IndexID = "idx-abc123",
            Query = "What are the key findings?",
            Rerank = new() { Enabled = true, TopN = 5 },
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.CustomFilters);
        Assert.False(parameters.RawBodyData.ContainsKey("custom_filters"));
        Assert.Null(parameters.FullTextPipelineWeight);
        Assert.False(parameters.RawBodyData.ContainsKey("full_text_pipeline_weight"));
        Assert.Null(parameters.NumCandidates);
        Assert.False(parameters.RawBodyData.ContainsKey("num_candidates"));
        Assert.Null(parameters.ScoreThreshold);
        Assert.False(parameters.RawBodyData.ContainsKey("score_threshold"));
        Assert.Null(parameters.StaticFilters);
        Assert.False(parameters.RawBodyData.ContainsKey("static_filters"));
        Assert.Null(parameters.TopK);
        Assert.False(parameters.RawBodyData.ContainsKey("top_k"));
        Assert.Null(parameters.VectorPipelineWeight);
        Assert.False(parameters.RawBodyData.ContainsKey("vector_pipeline_weight"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RetrievalRetrieveParams
        {
            IndexID = "idx-abc123",
            Query = "What are the key findings?",
            Rerank = new() { Enabled = true, TopN = 5 },

            OrganizationID = null,
            ProjectID = null,
            CustomFilters = null,
            FullTextPipelineWeight = null,
            NumCandidates = null,
            ScoreThreshold = null,
            StaticFilters = null,
            TopK = null,
            VectorPipelineWeight = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.CustomFilters);
        Assert.True(parameters.RawBodyData.ContainsKey("custom_filters"));
        Assert.Null(parameters.FullTextPipelineWeight);
        Assert.True(parameters.RawBodyData.ContainsKey("full_text_pipeline_weight"));
        Assert.Null(parameters.NumCandidates);
        Assert.True(parameters.RawBodyData.ContainsKey("num_candidates"));
        Assert.Null(parameters.ScoreThreshold);
        Assert.True(parameters.RawBodyData.ContainsKey("score_threshold"));
        Assert.Null(parameters.StaticFilters);
        Assert.True(parameters.RawBodyData.ContainsKey("static_filters"));
        Assert.Null(parameters.TopK);
        Assert.True(parameters.RawBodyData.ContainsKey("top_k"));
        Assert.Null(parameters.VectorPipelineWeight);
        Assert.True(parameters.RawBodyData.ContainsKey("vector_pipeline_weight"));
    }

    [Fact]
    public void Url_Works()
    {
        RetrievalRetrieveParams parameters = new()
        {
            IndexID = "idx-abc123",
            Query = "What are the key findings?",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/retrieval/retrieve?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RetrievalRetrieveParams
        {
            IndexID = "idx-abc123",
            Query = "What are the key findings?",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CustomFilters = new Dictionary<string, CustomFilter?>()
            {
                {
                    "foo",
                    new ValueFilter() { Operator = Operator.Eq, Value = "string" }
                },
            },
            FullTextPipelineWeight = 0,
            NumCandidates = 0,
            Rerank = new() { Enabled = true, TopN = 5 },
            ScoreThreshold = 0,
            StaticFilters = new()
            {
                ParsedDirectoryFileID = new()
                {
                    Operator = ParsedDirectoryFileIDOperator.Eq,
                    Value = "string",
                },
            },
            TopK = 10,
            VectorPipelineWeight = 0,
        };

        RetrievalRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CustomFilterTest : TestBase
{
    [Fact]
    public void ValueValidationWorks()
    {
        CustomFilter value = new ValueFilter() { Operator = Operator.Eq, Value = "string" };
        value.Validate();
    }

    [Fact]
    public void NumericRangeFiltersValidationWorks()
    {
        CustomFilter value = new(
            [new NumericRangeFilter() { Operator = NumericRangeFilterOperator.Eq, Value = 0 }]
        );
        value.Validate();
    }

    [Fact]
    public void ValueSerializationRoundtripWorks()
    {
        CustomFilter value = new ValueFilter() { Operator = Operator.Eq, Value = "string" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomFilter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NumericRangeFiltersSerializationRoundtripWorks()
    {
        CustomFilter value = new(
            [new NumericRangeFilter() { Operator = NumericRangeFilterOperator.Eq, Value = 0 }]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomFilter>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ValueFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ValueFilter { Operator = Operator.Eq, Value = "string" };

        ApiEnum<string, Operator> expectedOperator = Operator.Eq;
        ValueFilterValue expectedValue = "string";

        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ValueFilter { Operator = Operator.Eq, Value = "string" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ValueFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ValueFilter { Operator = Operator.Eq, Value = "string" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ValueFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Operator> expectedOperator = Operator.Eq;
        ValueFilterValue expectedValue = "string";

        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ValueFilter { Operator = Operator.Eq, Value = "string" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ValueFilter { Operator = Operator.Eq, Value = "string" };

        ValueFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OperatorTest : TestBase
{
    [Theory]
    [InlineData(Operator.Eq)]
    [InlineData(Operator.Gt)]
    [InlineData(Operator.Gte)]
    [InlineData(Operator.In)]
    [InlineData(Operator.Lt)]
    [InlineData(Operator.Lte)]
    [InlineData(Operator.Ne)]
    [InlineData(Operator.Nin)]
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
    [InlineData(Operator.Eq)]
    [InlineData(Operator.Gt)]
    [InlineData(Operator.Gte)]
    [InlineData(Operator.In)]
    [InlineData(Operator.Lt)]
    [InlineData(Operator.Lte)]
    [InlineData(Operator.Ne)]
    [InlineData(Operator.Nin)]
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

public class ValueFilterValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ValueFilterValue value = "string";
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ValueFilterValue value = true;
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ValueFilterValue value = 0;
        value.Validate();
    }

    [Fact]
    public void UnnamedSchemaWithArrayParent0sValidationWorks()
    {
        ValueFilterValue value = new([new UnnamedSchemaWithArrayParent0("string")]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ValueFilterValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ValueFilterValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ValueFilterValue value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ValueFilterValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ValueFilterValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ValueFilterValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnnamedSchemaWithArrayParent0sSerializationRoundtripWorks()
    {
        ValueFilterValue value = new([new UnnamedSchemaWithArrayParent0("string")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ValueFilterValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnnamedSchemaWithArrayParent0Test : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        UnnamedSchemaWithArrayParent0 value = "string";
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        UnnamedSchemaWithArrayParent0 value = true;
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        UnnamedSchemaWithArrayParent0 value = 0;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0 value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0 value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        UnnamedSchemaWithArrayParent0 value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnnamedSchemaWithArrayParent0>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NumericRangeFilterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NumericRangeFilter { Operator = NumericRangeFilterOperator.Eq, Value = 0 };

        ApiEnum<string, NumericRangeFilterOperator> expectedOperator =
            NumericRangeFilterOperator.Eq;
        NumericRangeFilterValue expectedValue = 0;

        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NumericRangeFilter { Operator = NumericRangeFilterOperator.Eq, Value = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NumericRangeFilter>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NumericRangeFilter { Operator = NumericRangeFilterOperator.Eq, Value = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NumericRangeFilter>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, NumericRangeFilterOperator> expectedOperator =
            NumericRangeFilterOperator.Eq;
        NumericRangeFilterValue expectedValue = 0;

        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NumericRangeFilter { Operator = NumericRangeFilterOperator.Eq, Value = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NumericRangeFilter { Operator = NumericRangeFilterOperator.Eq, Value = 0 };

        NumericRangeFilter copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NumericRangeFilterOperatorTest : TestBase
{
    [Theory]
    [InlineData(NumericRangeFilterOperator.Eq)]
    [InlineData(NumericRangeFilterOperator.Gt)]
    [InlineData(NumericRangeFilterOperator.Gte)]
    [InlineData(NumericRangeFilterOperator.In)]
    [InlineData(NumericRangeFilterOperator.Lt)]
    [InlineData(NumericRangeFilterOperator.Lte)]
    [InlineData(NumericRangeFilterOperator.Ne)]
    [InlineData(NumericRangeFilterOperator.Nin)]
    public void Validation_Works(NumericRangeFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NumericRangeFilterOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NumericRangeFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NumericRangeFilterOperator.Eq)]
    [InlineData(NumericRangeFilterOperator.Gt)]
    [InlineData(NumericRangeFilterOperator.Gte)]
    [InlineData(NumericRangeFilterOperator.In)]
    [InlineData(NumericRangeFilterOperator.Lt)]
    [InlineData(NumericRangeFilterOperator.Lte)]
    [InlineData(NumericRangeFilterOperator.Ne)]
    [InlineData(NumericRangeFilterOperator.Nin)]
    public void SerializationRoundtrip_Works(NumericRangeFilterOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NumericRangeFilterOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NumericRangeFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NumericRangeFilterOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, NumericRangeFilterOperator>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class NumericRangeFilterValueTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        NumericRangeFilterValue value = 0;
        value.Validate();
    }

    [Fact]
    public void DoublesValidationWorks()
    {
        NumericRangeFilterValue value = new([0]);
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        NumericRangeFilterValue value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NumericRangeFilterValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoublesSerializationRoundtripWorks()
    {
        NumericRangeFilterValue value = new([0]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NumericRangeFilterValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RerankTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Rerank { Enabled = true, TopN = 5 };

        bool expectedEnabled = true;
        long expectedTopN = 5;

        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedTopN, model.TopN);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Rerank { Enabled = true, TopN = 5 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rerank>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Rerank { Enabled = true, TopN = 5 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Rerank>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        bool expectedEnabled = true;
        long expectedTopN = 5;

        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedTopN, deserialized.TopN);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Rerank { Enabled = true, TopN = 5 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Rerank { TopN = 5 };

        Assert.Null(model.Enabled);
        Assert.False(model.RawData.ContainsKey("enabled"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Rerank { TopN = 5 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Rerank
        {
            TopN = 5,

            // Null should be interpreted as omitted for these properties
            Enabled = null,
        };

        Assert.Null(model.Enabled);
        Assert.False(model.RawData.ContainsKey("enabled"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Rerank
        {
            TopN = 5,

            // Null should be interpreted as omitted for these properties
            Enabled = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Rerank { Enabled = true };

        Assert.Null(model.TopN);
        Assert.False(model.RawData.ContainsKey("top_n"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Rerank { Enabled = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Rerank
        {
            Enabled = true,

            TopN = null,
        };

        Assert.Null(model.TopN);
        Assert.True(model.RawData.ContainsKey("top_n"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Rerank
        {
            Enabled = true,

            TopN = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Rerank { Enabled = true, TopN = 5 };

        Rerank copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StaticFiltersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new StaticFilters
        {
            ParsedDirectoryFileID = new()
            {
                Operator = ParsedDirectoryFileIDOperator.Eq,
                Value = "string",
            },
        };

        ParsedDirectoryFileID expectedParsedDirectoryFileID = new()
        {
            Operator = ParsedDirectoryFileIDOperator.Eq,
            Value = "string",
        };

        Assert.Equal(expectedParsedDirectoryFileID, model.ParsedDirectoryFileID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new StaticFilters
        {
            ParsedDirectoryFileID = new()
            {
                Operator = ParsedDirectoryFileIDOperator.Eq,
                Value = "string",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StaticFilters>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new StaticFilters
        {
            ParsedDirectoryFileID = new()
            {
                Operator = ParsedDirectoryFileIDOperator.Eq,
                Value = "string",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<StaticFilters>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ParsedDirectoryFileID expectedParsedDirectoryFileID = new()
        {
            Operator = ParsedDirectoryFileIDOperator.Eq,
            Value = "string",
        };

        Assert.Equal(expectedParsedDirectoryFileID, deserialized.ParsedDirectoryFileID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new StaticFilters
        {
            ParsedDirectoryFileID = new()
            {
                Operator = ParsedDirectoryFileIDOperator.Eq,
                Value = "string",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new StaticFilters { };

        Assert.Null(model.ParsedDirectoryFileID);
        Assert.False(model.RawData.ContainsKey("parsed_directory_file_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new StaticFilters { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new StaticFilters { ParsedDirectoryFileID = null };

        Assert.Null(model.ParsedDirectoryFileID);
        Assert.True(model.RawData.ContainsKey("parsed_directory_file_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new StaticFilters { ParsedDirectoryFileID = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new StaticFilters
        {
            ParsedDirectoryFileID = new()
            {
                Operator = ParsedDirectoryFileIDOperator.Eq,
                Value = "string",
            },
        };

        StaticFilters copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ParsedDirectoryFileIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ParsedDirectoryFileID
        {
            Operator = ParsedDirectoryFileIDOperator.Eq,
            Value = "string",
        };

        ApiEnum<string, ParsedDirectoryFileIDOperator> expectedOperator =
            ParsedDirectoryFileIDOperator.Eq;
        ParsedDirectoryFileIDValue expectedValue = "string";

        Assert.Equal(expectedOperator, model.Operator);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ParsedDirectoryFileID
        {
            Operator = ParsedDirectoryFileIDOperator.Eq,
            Value = "string",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsedDirectoryFileID>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ParsedDirectoryFileID
        {
            Operator = ParsedDirectoryFileIDOperator.Eq,
            Value = "string",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsedDirectoryFileID>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ParsedDirectoryFileIDOperator> expectedOperator =
            ParsedDirectoryFileIDOperator.Eq;
        ParsedDirectoryFileIDValue expectedValue = "string";

        Assert.Equal(expectedOperator, deserialized.Operator);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ParsedDirectoryFileID
        {
            Operator = ParsedDirectoryFileIDOperator.Eq,
            Value = "string",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ParsedDirectoryFileID
        {
            Operator = ParsedDirectoryFileIDOperator.Eq,
            Value = "string",
        };

        ParsedDirectoryFileID copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ParsedDirectoryFileIDOperatorTest : TestBase
{
    [Theory]
    [InlineData(ParsedDirectoryFileIDOperator.Eq)]
    [InlineData(ParsedDirectoryFileIDOperator.Gt)]
    [InlineData(ParsedDirectoryFileIDOperator.Gte)]
    [InlineData(ParsedDirectoryFileIDOperator.In)]
    [InlineData(ParsedDirectoryFileIDOperator.Lt)]
    [InlineData(ParsedDirectoryFileIDOperator.Lte)]
    [InlineData(ParsedDirectoryFileIDOperator.Ne)]
    [InlineData(ParsedDirectoryFileIDOperator.Nin)]
    public void Validation_Works(ParsedDirectoryFileIDOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ParsedDirectoryFileIDOperator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ParsedDirectoryFileIDOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ParsedDirectoryFileIDOperator.Eq)]
    [InlineData(ParsedDirectoryFileIDOperator.Gt)]
    [InlineData(ParsedDirectoryFileIDOperator.Gte)]
    [InlineData(ParsedDirectoryFileIDOperator.In)]
    [InlineData(ParsedDirectoryFileIDOperator.Lt)]
    [InlineData(ParsedDirectoryFileIDOperator.Lte)]
    [InlineData(ParsedDirectoryFileIDOperator.Ne)]
    [InlineData(ParsedDirectoryFileIDOperator.Nin)]
    public void SerializationRoundtrip_Works(ParsedDirectoryFileIDOperator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ParsedDirectoryFileIDOperator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ParsedDirectoryFileIDOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ParsedDirectoryFileIDOperator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ParsedDirectoryFileIDOperator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ParsedDirectoryFileIDValueTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ParsedDirectoryFileIDValue value = "string";
        value.Validate();
    }

    [Fact]
    public void StringsValidationWorks()
    {
        ParsedDirectoryFileIDValue value = new(["string"]);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ParsedDirectoryFileIDValue value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsedDirectoryFileIDValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringsSerializationRoundtripWorks()
    {
        ParsedDirectoryFileIDValue value = new(["string"]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsedDirectoryFileIDValue>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
