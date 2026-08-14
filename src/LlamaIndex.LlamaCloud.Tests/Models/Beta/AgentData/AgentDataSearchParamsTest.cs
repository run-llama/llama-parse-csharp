using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.AgentData;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.AgentData;

public class AgentDataSearchParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentDataSearchParams
        {
            DeploymentName = "deployment_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Collection = "collection",
            Filter = new Dictionary<string, AgentDataSearchParamsFilterItem>()
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
            IncludeTotal = true,
            Offset = 0,
            OrderBy = "order_by",
            PageSize = 0,
            PageToken = "page_token",
        };

        string expectedDeploymentName = "deployment_name";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCollection = "collection";
        Dictionary<string, AgentDataSearchParamsFilterItem> expectedFilter = new()
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
        bool expectedIncludeTotal = true;
        long expectedOffset = 0;
        string expectedOrderBy = "order_by";
        long expectedPageSize = 0;
        string expectedPageToken = "page_token";

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
        Assert.Equal(expectedIncludeTotal, parameters.IncludeTotal);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedOrderBy, parameters.OrderBy);
        Assert.Equal(expectedPageSize, parameters.PageSize);
        Assert.Equal(expectedPageToken, parameters.PageToken);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AgentDataSearchParams
        {
            DeploymentName = "deployment_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Filter = new Dictionary<string, AgentDataSearchParamsFilterItem>()
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
            Offset = 0,
            OrderBy = "order_by",
            PageSize = 0,
            PageToken = "page_token",
        };

        Assert.Null(parameters.Collection);
        Assert.False(parameters.RawBodyData.ContainsKey("collection"));
        Assert.Null(parameters.IncludeTotal);
        Assert.False(parameters.RawBodyData.ContainsKey("include_total"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AgentDataSearchParams
        {
            DeploymentName = "deployment_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Filter = new Dictionary<string, AgentDataSearchParamsFilterItem>()
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
            Offset = 0,
            OrderBy = "order_by",
            PageSize = 0,
            PageToken = "page_token",

            // Null should be interpreted as omitted for these properties
            Collection = null,
            IncludeTotal = null,
        };

        Assert.Null(parameters.Collection);
        Assert.False(parameters.RawBodyData.ContainsKey("collection"));
        Assert.Null(parameters.IncludeTotal);
        Assert.False(parameters.RawBodyData.ContainsKey("include_total"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AgentDataSearchParams
        {
            DeploymentName = "deployment_name",
            Collection = "collection",
            IncludeTotal = true,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Filter);
        Assert.False(parameters.RawBodyData.ContainsKey("filter"));
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
        var parameters = new AgentDataSearchParams
        {
            DeploymentName = "deployment_name",
            Collection = "collection",
            IncludeTotal = true,

            OrganizationID = null,
            ProjectID = null,
            Filter = null,
            Offset = null,
            OrderBy = null,
            PageSize = null,
            PageToken = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.Filter);
        Assert.True(parameters.RawBodyData.ContainsKey("filter"));
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
        AgentDataSearchParams parameters = new()
        {
            DeploymentName = "deployment_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/agent-data/:search?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AgentDataSearchParams
        {
            DeploymentName = "deployment_name",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Collection = "collection",
            Filter = new Dictionary<string, AgentDataSearchParamsFilterItem>()
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
            IncludeTotal = true,
            Offset = 0,
            OrderBy = "order_by",
            PageSize = 0,
            PageToken = "page_token",
        };

        AgentDataSearchParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AgentDataSearchParamsFilterItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AgentDataSearchParamsFilterItem
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

        AgentDataSearchParamsFilterItemEq expectedEq = 0;
        List<AgentDataSearchParamsFilterItemExclude?> expectedExcludes = [0];
        AgentDataSearchParamsFilterItemGt expectedGt = 0;
        AgentDataSearchParamsFilterItemGte expectedGte = 0;
        List<AgentDataSearchParamsFilterItemInclude?> expectedIncludes = [0];
        AgentDataSearchParamsFilterItemLt expectedLt = 0;
        AgentDataSearchParamsFilterItemLte expectedLte = 0;
        AgentDataSearchParamsFilterItemNe expectedNe = 0;

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
        var model = new AgentDataSearchParamsFilterItem
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
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AgentDataSearchParamsFilterItem
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
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AgentDataSearchParamsFilterItemEq expectedEq = 0;
        List<AgentDataSearchParamsFilterItemExclude?> expectedExcludes = [0];
        AgentDataSearchParamsFilterItemGt expectedGt = 0;
        AgentDataSearchParamsFilterItemGte expectedGte = 0;
        List<AgentDataSearchParamsFilterItemInclude?> expectedIncludes = [0];
        AgentDataSearchParamsFilterItemLt expectedLt = 0;
        AgentDataSearchParamsFilterItemLte expectedLte = 0;
        AgentDataSearchParamsFilterItemNe expectedNe = 0;

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
        var model = new AgentDataSearchParamsFilterItem
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
        var model = new AgentDataSearchParamsFilterItem
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
        var model = new AgentDataSearchParamsFilterItem
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
        var model = new AgentDataSearchParamsFilterItem
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
        var model = new AgentDataSearchParamsFilterItem
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
        var model = new AgentDataSearchParamsFilterItem { Excludes = [0], Includes = [0] };

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
        var model = new AgentDataSearchParamsFilterItem { Excludes = [0], Includes = [0] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AgentDataSearchParamsFilterItem
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
        var model = new AgentDataSearchParamsFilterItem
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
        var model = new AgentDataSearchParamsFilterItem
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

        AgentDataSearchParamsFilterItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentDataSearchParamsFilterItemEqTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AgentDataSearchParamsFilterItemEq value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AgentDataSearchParamsFilterItemEq value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        AgentDataSearchParamsFilterItemEq value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemEq value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemEq>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemEq value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemEq>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemEq value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemEq>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AgentDataSearchParamsFilterItemExcludeTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AgentDataSearchParamsFilterItemExclude value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AgentDataSearchParamsFilterItemExclude value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        AgentDataSearchParamsFilterItemExclude value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemExclude value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemExclude>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemExclude value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemExclude>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemExclude value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemExclude>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AgentDataSearchParamsFilterItemGtTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AgentDataSearchParamsFilterItemGt value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AgentDataSearchParamsFilterItemGt value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        AgentDataSearchParamsFilterItemGt value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemGt value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemGt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemGt value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemGt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemGt value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemGt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AgentDataSearchParamsFilterItemGteTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AgentDataSearchParamsFilterItemGte value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AgentDataSearchParamsFilterItemGte value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        AgentDataSearchParamsFilterItemGte value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemGte value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemGte>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemGte value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemGte>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemGte value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemGte>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AgentDataSearchParamsFilterItemIncludeTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AgentDataSearchParamsFilterItemInclude value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AgentDataSearchParamsFilterItemInclude value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        AgentDataSearchParamsFilterItemInclude value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemInclude value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemInclude>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemInclude value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemInclude>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemInclude value = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemInclude>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AgentDataSearchParamsFilterItemLtTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AgentDataSearchParamsFilterItemLt value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AgentDataSearchParamsFilterItemLt value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        AgentDataSearchParamsFilterItemLt value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemLt value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemLt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemLt value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemLt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemLt value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemLt>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AgentDataSearchParamsFilterItemLteTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AgentDataSearchParamsFilterItemLte value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AgentDataSearchParamsFilterItemLte value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        AgentDataSearchParamsFilterItemLte value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemLte value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemLte>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemLte value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemLte>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemLte value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemLte>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AgentDataSearchParamsFilterItemNeTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AgentDataSearchParamsFilterItemNe value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AgentDataSearchParamsFilterItemNe value = "string";
        value.Validate();
    }

    [Fact]
    public void DateTimeOffsetValidationWorks()
    {
        AgentDataSearchParamsFilterItemNe value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemNe value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemNe>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemNe value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemNe>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DateTimeOffsetSerializationRoundtripWorks()
    {
        AgentDataSearchParamsFilterItemNe value = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AgentDataSearchParamsFilterItemNe>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
