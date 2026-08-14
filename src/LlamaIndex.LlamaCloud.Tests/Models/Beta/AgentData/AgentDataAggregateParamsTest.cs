using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.AgentData;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.AgentData;

public class AgentDataAggregateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentDataAggregateParams
        {
            DeploymentName = "deployment_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Collection = "collection",
            Count = true,
            Filter = new Dictionary<string, FilterItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Eq = 0,
                        Excludes = [0],
                        Gt = 0,
                        Gte = 0,
                        Includes = [0],
                        Lt = 0,
                        Lte = 0,
                        Ne = 0,
                    }
                },
            },
            First = true,
            GroupBy = ["string"],
            Offset = 0,
            OrderBy = "order_by",
            PageSize = 0,
            PageToken = "page_token",
        };

        string expectedDeploymentName = "deployment_name";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCollection = "collection";
        bool expectedCount = true;
        Dictionary<string, FilterItem> expectedFilter = new()
        {
            {
                "foo",
                new()
                {
                    Eq = 0,
                    Excludes = [0],
                    Gt = 0,
                    Gte = 0,
                    Includes = [0],
                    Lt = 0,
                    Lte = 0,
                    Ne = 0,
                }
            },
        };
        bool expectedFirst = true;
        List<string> expectedGroupBy = ["string"];
        long expectedOffset = 0;
        string expectedOrderBy = "order_by";
        long expectedPageSize = 0;
        string expectedPageToken = "page_token";

        Assert.Equal(expectedDeploymentName, parameters.DeploymentName);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedCollection, parameters.Collection);
        Assert.Equal(expectedCount, parameters.Count);
        Assert.NotNull(parameters.Filter);
        Assert.Equal(expectedFilter.Count, parameters.Filter.Count);
        foreach (var item in expectedFilter)
        {
            Assert.True(parameters.Filter.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Filter[item.Key]);
        }
        Assert.Equal(expectedFirst, parameters.First);
        Assert.NotNull(parameters.GroupBy);
        Assert.Equal(expectedGroupBy.Count, parameters.GroupBy.Count);
        for (int i = 0; i < expectedGroupBy.Count; i++)
        {
            Assert.Equal(expectedGroupBy[i], parameters.GroupBy[i]);
        }
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedOrderBy, parameters.OrderBy);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedPageToken, parameters.PageToken);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AgentDataAggregateParams
        {
            DeploymentName = "deployment_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Count = true,
            Filter = new Dictionary<string, FilterItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Eq = 0,
                        Excludes = [0],
                        Gt = 0,
                        Gte = 0,
                        Includes = [0],
                        Lt = 0,
                        Lte = 0,
                        Ne = 0,
                    }
                },
            },
            First = true,
            GroupBy = ["string"],
            Offset = 0,
            OrderBy = "order_by",
            PageSize = 0,
            PageToken = "page_token",
        };

        Assert.Null(parameters.Collection);
        Assert.False(parameters.RawBodyData.ContainsKey("collection"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AgentDataAggregateParams
        {
            DeploymentName = "deployment_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Count = true,
            Filter = new Dictionary<string, FilterItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Eq = 0,
                        Excludes = [0],
                        Gt = 0,
                        Gte = 0,
                        Includes = [0],
                        Lt = 0,
                        Lte = 0,
                        Ne = 0,
                    }
                },
            },
            First = true,
            GroupBy = ["string"],
            Offset = 0,
            OrderBy = "order_by",
            PageSize = 0,
            PageToken = "page_token",

            // Null should be interpreted as omitted for these properties
            Collection = null,
        };

        Assert.Null(parameters.Collection);
        Assert.False(parameters.RawBodyData.ContainsKey("collection"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AgentDataAggregateParams
        {
            DeploymentName = "deployment_name",
            Collection = "collection",
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Count);
        Assert.False(parameters.RawBodyData.ContainsKey("count"));
        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawBodyData.ContainsKey("filter"));
        Assert.Null(parameters.First);
        Assert.False(parameters.RawBodyData.ContainsKey("first"));
        Assert.Null(parameters.GroupBy);
        Assert.False(parameters.RawBodyData.ContainsKey("group_by"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawBodyData.ContainsKey("offset"));
        Assert.Null(parameters.OrderBy);
        Assert.False(parameters.RawBodyData.ContainsKey("order_by"));
        Assert.Null(parameters.PageSize);
        Assert.False(parameters.RawBodyData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.False(parameters.RawBodyData.ContainsKey("page_token"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AgentDataAggregateParams
        {
            DeploymentName = "deployment_name",
            Collection = "collection",

            OrganizationID = null,
            ProjectID = null,
            Count = null,
            Filter = null,
            First = null,
            GroupBy = null,
            Offset = null,
            OrderBy = null,
            PageSize = null,
            PageToken = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Count);
        Assert.True(parameters.RawBodyData.ContainsKey("count"));
        Assert.Null(parameters.Filter);
        Assert.True(parameters.RawBodyData.ContainsKey("filter"));
        Assert.Null(parameters.First);
        Assert.True(parameters.RawBodyData.ContainsKey("first"));
        Assert.Null(parameters.GroupBy);
        Assert.True(parameters.RawBodyData.ContainsKey("group_by"));
        Assert.Null(parameters.Offset);
        Assert.True(parameters.RawBodyData.ContainsKey("offset"));
        Assert.Null(parameters.OrderBy);
        Assert.True(parameters.RawBodyData.ContainsKey("order_by"));
        Assert.Null(parameters.PageSize);
        Assert.True(parameters.RawBodyData.ContainsKey("page_size"));
        Assert.Null(parameters.PageToken);
        Assert.True(parameters.RawBodyData.ContainsKey("page_token"));
    }

    [Fact]
    public void Url_Works()
    {
        AgentDataAggregateParams parameters = new()
        {
            DeploymentName = "deployment_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/agent-data/:aggregate?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AgentDataAggregateParams
        {
            DeploymentName = "deployment_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Collection = "collection",
            Count = true,
            Filter = new Dictionary<string, FilterItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Eq = 0,
                        Excludes = [0],
                        Gt = 0,
                        Gte = 0,
                        Includes = [0],
                        Lt = 0,
                        Lte = 0,
                        Ne = 0,
                    }
                },
            },
            First = true,
            GroupBy = ["string"],
            Offset = 0,
            OrderBy = "order_by",
            PageSize = 0,
            PageToken = "page_token",
        };

        AgentDataAggregateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FilterItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FilterItem
        {
            Eq = 0,
            Excludes = [0],
            Gt = 0,
            Gte = 0,
            Includes = [0],
            Lt = 0,
            Lte = 0,
            Ne = 0,
        };

        Eq expectedEq = 0;
        List<Exclude?> expectedExcludes = [0];
        Gt expectedGt = 0;
        Gte expectedGte = 0;
        List<Include?> expectedIncludes = [0];
        Lt expectedLt = 0;
        Lte expectedLte = 0;
        Ne expectedNe = 0;

        Assert.Equal(expectedEq, model.Eq);
        Assert.NotNull(model.Excludes);
        Assert.Equal(expectedExcludes.Count, model.Excludes.Count);
        for (int i = 0; i < expectedExcludes.Count; i++)
        {
            Assert.Equal(expectedExcludes[i], model.Excludes[i]);
        }
        Assert.Equal(expectedGt, model.Gt);
        Assert.Equal(expectedGte, model.Gte);
        Assert.NotNull(model.Includes);
        Assert.Equal(expectedIncludes.Count, model.Includes.Count);
        for (int i = 0; i < expectedIncludes.Count; i++)
        {
            Assert.Equal(expectedIncludes[i], model.Includes[i]);
        }
        Assert.Equal(expectedLt, model.Lt);
        Assert.Equal(expectedLte, model.Lte);
        Assert.Equal(expectedNe, model.Ne);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FilterItem
        {
            Eq = 0,
            Excludes = [0],
            Gt = 0,
            Gte = 0,
            Includes = [0],
            Lt = 0,
            Lte = 0,
            Ne = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FilterItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FilterItem
        {
            Eq = 0,
            Excludes = [0],
            Gt = 0,
            Gte = 0,
            Includes = [0],
            Lt = 0,
            Lte = 0,
            Ne = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FilterItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Eq expectedEq = 0;
        List<Exclude?> expectedExcludes = [0];
        Gt expectedGt = 0;
        Gte expectedGte = 0;
        List<Include?> expectedIncludes = [0];
        Lt expectedLt = 0;
        Lte expectedLte = 0;
        Ne expectedNe = 0;

        Assert.Equal(expectedEq, deserialized.Eq);
        Assert.NotNull(deserialized.Excludes);
        Assert.Equal(expectedExcludes.Count, deserialized.Excludes.Count);
        for (int i = 0; i < expectedExcludes.Count; i++)
        {
            Assert.Equal(expectedExcludes[i], deserialized.Excludes[i]);
        }
        Assert.Equal(expectedGt, deserialized.Gt);
        Assert.Equal(expectedGte, deserialized.Gte);
        Assert.NotNull(deserialized.Includes);
        Assert.Equal(expectedIncludes.Count, deserialized.Includes.Count);
        for (int i = 0; i < expectedIncludes.Count; i++)
        {
            Assert.Equal(expectedIncludes[i], deserialized.Includes[i]);
        }
        Assert.Equal(expectedLt, deserialized.Lt);
        Assert.Equal(expectedLte, deserialized.Lte);
        Assert.Equal(expectedNe, deserialized.Ne);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FilterItem
        {
            Eq = 0,
            Excludes = [0],
            Gt = 0,
            Gte = 0,
            Includes = [0],
            Lt = 0,
            Lte = 0,
            Ne = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FilterItem
        {
            Eq = 0,
            Gt = 0,
            Gte = 0,
            Lt = 0,
            Lte = 0,
            Ne = 0,
        };

        Assert.Null(model.Excludes);
        Assert.False(model.RawData.ContainsKey("excludes"));
        Assert.Null(model.Includes);
        Assert.False(model.RawData.ContainsKey("includes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FilterItem
        {
            Eq = 0,
            Gt = 0,
            Gte = 0,
            Lt = 0,
            Lte = 0,
            Ne = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FilterItem
        {
            Eq = 0,
            Gt = 0,
            Gte = 0,
            Lt = 0,
            Lte = 0,
            Ne = 0,

            // Null should be interpreted as omitted for these properties
            Excludes = null,
            Includes = null,
        };

        Assert.Null(model.Excludes);
        Assert.False(model.RawData.ContainsKey("excludes"));
        Assert.Null(model.Includes);
        Assert.False(model.RawData.ContainsKey("includes"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FilterItem
        {
            Eq = 0,
            Gt = 0,
            Gte = 0,
            Lt = 0,
            Lte = 0,
            Ne = 0,

            // Null should be interpreted as omitted for these properties
            Excludes = null,
            Includes = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FilterItem { Excludes = [0], Includes = [0] };

        Assert.Null(model.Eq);
        Assert.False(model.RawData.ContainsKey("eq"));
        Assert.Null(model.Gt);
        Assert.False(model.RawData.ContainsKey("gt"));
        Assert.Null(model.Gte);
        Assert.False(model.RawData.ContainsKey("gte"));
        Assert.Null(model.Lt);
        Assert.False(model.RawData.ContainsKey("lt"));
        Assert.Null(model.Lte);
        Assert.False(model.RawData.ContainsKey("lte"));
        Assert.Null(model.Ne);
        Assert.False(model.RawData.ContainsKey("ne"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FilterItem { Excludes = [0], Includes = [0] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FilterItem
        {
            Excludes = [0],
            Includes = [0],

            Eq = null,
            Gt = null,
            Gte = null,
            Lt = null,
            Lte = null,
            Ne = null,
        };

        Assert.Null(model.Eq);
        Assert.True(model.RawData.ContainsKey("eq"));
        Assert.Null(model.Gt);
        Assert.True(model.RawData.ContainsKey("gt"));
        Assert.Null(model.Gte);
        Assert.True(model.RawData.ContainsKey("gte"));
        Assert.Null(model.Lt);
        Assert.True(model.RawData.ContainsKey("lt"));
        Assert.Null(model.Lte);
        Assert.True(model.RawData.ContainsKey("lte"));
        Assert.Null(model.Ne);
        Assert.True(model.RawData.ContainsKey("ne"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FilterItem
        {
            Excludes = [0],
            Includes = [0],

            Eq = null,
            Gt = null,
            Gte = null,
            Lt = null,
            Lte = null,
            Ne = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FilterItem
        {
            Eq = 0,
            Excludes = [0],
            Gt = 0,
            Gte = 0,
            Includes = [0],
            Lt = 0,
            Lte = 0,
            Ne = 0,
        };

        FilterItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EqTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Eq value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Eq value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        Eq value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Eq value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Eq>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Eq value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Eq>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        Eq value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Eq>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ExcludeTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Exclude value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Exclude value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        Exclude value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Exclude value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exclude>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Exclude value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exclude>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        Exclude value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Exclude>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GtTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Gt value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Gt value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        Gt value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Gt value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Gt>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Gt value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Gt>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        Gt value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Gt>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class GteTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Gte value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Gte value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        Gte value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Gte value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Gte>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Gte value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Gte>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        Gte value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Gte>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class IncludeTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Include value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Include value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        Include value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Include value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Include>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Include value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Include>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        Include value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Include>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class LtTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Lt value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Lt value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        Lt value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Lt value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Lt>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Lt value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Lt>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        Lt value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Lt>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class LteTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Lte value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Lte value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        Lte value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Lte value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Lte>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Lte value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Lte>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        Lte value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Lte>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NeTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Ne value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Ne value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        Ne value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Ne value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Ne>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Ne value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Ne>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        Ne value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Ne>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
