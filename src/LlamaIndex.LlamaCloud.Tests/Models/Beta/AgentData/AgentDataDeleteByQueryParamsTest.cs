using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.AgentData;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.AgentData;

public class AgentDataDeleteByQueryParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentDataDeleteByQueryParams
        {
            DeploymentName = "deployment_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Collection = "collection",
            Filter = new Dictionary<string, AgentDataDeleteByQueryParamsFilterItem>()
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
        };

        string expectedDeploymentName = "deployment_name";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCollection = "collection";
        Dictionary<string, AgentDataDeleteByQueryParamsFilterItem> expectedFilter = new()
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

        Assert.Equal(expectedDeploymentName, parameters.DeploymentName);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedCollection, parameters.Collection);
        Assert.NotNull(parameters.Filter);
        Assert.Equal(expectedFilter.Count, parameters.Filter.Count);
        foreach (var item in expectedFilter)
        {
            Assert.True(parameters.Filter.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Filter[item.Key]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AgentDataDeleteByQueryParams
        {
            DeploymentName = "deployment_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Filter = new Dictionary<string, AgentDataDeleteByQueryParamsFilterItem>()
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
        };

        Assert.Null(parameters.Collection);
        Assert.False(parameters.RawBodyData.ContainsKey("collection"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AgentDataDeleteByQueryParams
        {
            DeploymentName = "deployment_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Filter = new Dictionary<string, AgentDataDeleteByQueryParamsFilterItem>()
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

            // Null should be interpreted as omitted for these properties
            Collection = null,
        };

        Assert.Null(parameters.Collection);
        Assert.False(parameters.RawBodyData.ContainsKey("collection"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AgentDataDeleteByQueryParams
        {
            DeploymentName = "deployment_name",
            Collection = "collection",
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawBodyData.ContainsKey("filter"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AgentDataDeleteByQueryParams
        {
            DeploymentName = "deployment_name",
            Collection = "collection",

            OrganizationID = null,
            ProjectID = null,
            Filter = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Filter);
        Assert.True(parameters.RawBodyData.ContainsKey("filter"));
    }

    [Fact]
    public void Url_Works()
    {
        AgentDataDeleteByQueryParams parameters = new()
        {
            DeploymentName = "deployment_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/agent-data/:delete?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AgentDataDeleteByQueryParams
        {
            DeploymentName = "deployment_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Collection = "collection",
            Filter = new Dictionary<string, AgentDataDeleteByQueryParamsFilterItem>()
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
        };

        AgentDataDeleteByQueryParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AgentDataDeleteByQueryParamsFilterItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentDataDeleteByQueryParamsFilterItem
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

        AgentDataDeleteByQueryParamsFilterItemEq expectedEq = 0;
        List<AgentDataDeleteByQueryParamsFilterItemExclude?> expectedExcludes = [0];
        AgentDataDeleteByQueryParamsFilterItemGt expectedGt = 0;
        AgentDataDeleteByQueryParamsFilterItemGte expectedGte = 0;
        List<AgentDataDeleteByQueryParamsFilterItemInclude?> expectedIncludes = [0];
        AgentDataDeleteByQueryParamsFilterItemLt expectedLt = 0;
        AgentDataDeleteByQueryParamsFilterItemLte expectedLte = 0;
        AgentDataDeleteByQueryParamsFilterItemNe expectedNe = 0;

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
        var model = new AgentDataDeleteByQueryParamsFilterItem
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
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentDataDeleteByQueryParamsFilterItem
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
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AgentDataDeleteByQueryParamsFilterItemEq expectedEq = 0;
        List<AgentDataDeleteByQueryParamsFilterItemExclude?> expectedExcludes = [0];
        AgentDataDeleteByQueryParamsFilterItemGt expectedGt = 0;
        AgentDataDeleteByQueryParamsFilterItemGte expectedGte = 0;
        List<AgentDataDeleteByQueryParamsFilterItemInclude?> expectedIncludes = [0];
        AgentDataDeleteByQueryParamsFilterItemLt expectedLt = 0;
        AgentDataDeleteByQueryParamsFilterItemLte expectedLte = 0;
        AgentDataDeleteByQueryParamsFilterItemNe expectedNe = 0;

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
        var model = new AgentDataDeleteByQueryParamsFilterItem
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
        var model = new AgentDataDeleteByQueryParamsFilterItem
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
        var model = new AgentDataDeleteByQueryParamsFilterItem
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
        var model = new AgentDataDeleteByQueryParamsFilterItem
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
        var model = new AgentDataDeleteByQueryParamsFilterItem
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
        var model = new AgentDataDeleteByQueryParamsFilterItem { Excludes = [0], Includes = [0] };

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
        var model = new AgentDataDeleteByQueryParamsFilterItem { Excludes = [0], Includes = [0] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AgentDataDeleteByQueryParamsFilterItem
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
        var model = new AgentDataDeleteByQueryParamsFilterItem
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
        var model = new AgentDataDeleteByQueryParamsFilterItem
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

        AgentDataDeleteByQueryParamsFilterItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentDataDeleteByQueryParamsFilterItemEqTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemEq value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemEq value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemEq value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemEq value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemEq>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemEq value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemEq>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemEq value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemEq>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AgentDataDeleteByQueryParamsFilterItemExcludeTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemExclude value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemExclude value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemExclude value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemExclude value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemExclude>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemExclude value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemExclude>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemExclude value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemExclude>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class AgentDataDeleteByQueryParamsFilterItemGtTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemGt value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemGt value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemGt value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemGt value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemGt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemGt value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemGt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemGt value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemGt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AgentDataDeleteByQueryParamsFilterItemGteTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemGte value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemGte value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemGte value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemGte value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemGte>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemGte value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemGte>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemGte value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemGte>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AgentDataDeleteByQueryParamsFilterItemIncludeTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemInclude value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemInclude value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemInclude value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemInclude value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemInclude>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemInclude value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemInclude>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemInclude value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemInclude>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class AgentDataDeleteByQueryParamsFilterItemLtTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemLt value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemLt value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemLt value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemLt value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemLt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemLt value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemLt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemLt value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemLt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AgentDataDeleteByQueryParamsFilterItemLteTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemLte value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemLte value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemLte value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemLte value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemLte>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemLte value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemLte>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemLte value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemLte>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AgentDataDeleteByQueryParamsFilterItemNeTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemNe value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemNe value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemNe value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemNe value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemNe>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemNe value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemNe>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        AgentDataDeleteByQueryParamsFilterItemNe value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataDeleteByQueryParamsFilterItemNe>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
