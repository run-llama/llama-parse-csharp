using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models;

namespace LlamaCloud.Tests.Models;

public class CloudPostgresVectorStoreTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CloudPostgresVectorStore
        {
            Database = "database",
            EmbedDim = 0,
            Host = "host",
            Password = "password",
            Port = 0,
            SchemaName = "schema_name",
            TableName = "table_name",
            User = "user",
            ClassName = "class_name",
            HnswSettings = new()
            {
                DistanceMethod = DistanceMethod.Cosine,
                EfConstruction = 1,
                EfSearch = 1,
                M = 1,
                VectorType = VectorType.Bit,
            },
            HybridSearch = true,
            PerformSetup = true,
            SupportsNestedMetadataFilters = true,
        };

        string expectedDatabase = "database";
        long expectedEmbedDim = 0;
        string expectedHost = "host";
        string expectedPassword = "password";
        long expectedPort = 0;
        string expectedSchemaName = "schema_name";
        string expectedTableName = "table_name";
        string expectedUser = "user";
        string expectedClassName = "class_name";
        PgVectorHnswSettings expectedHnswSettings = new()
        {
            DistanceMethod = DistanceMethod.Cosine,
            EfConstruction = 1,
            EfSearch = 1,
            M = 1,
            VectorType = VectorType.Bit,
        };
        bool expectedHybridSearch = true;
        bool expectedPerformSetup = true;
        bool expectedSupportsNestedMetadataFilters = true;

        Assert.Equal(expectedDatabase, model.Database);
        Assert.Equal(expectedEmbedDim, model.EmbedDim);
        Assert.Equal(expectedHost, model.Host);
        Assert.Equal(expectedPassword, model.Password);
        Assert.Equal(expectedPort, model.Port);
        Assert.Equal(expectedSchemaName, model.SchemaName);
        Assert.Equal(expectedTableName, model.TableName);
        Assert.Equal(expectedUser, model.User);
        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedHnswSettings, model.HnswSettings);
        Assert.Equal(expectedHybridSearch, model.HybridSearch);
        Assert.Equal(expectedPerformSetup, model.PerformSetup);
        Assert.Equal(expectedSupportsNestedMetadataFilters, model.SupportsNestedMetadataFilters);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CloudPostgresVectorStore
        {
            Database = "database",
            EmbedDim = 0,
            Host = "host",
            Password = "password",
            Port = 0,
            SchemaName = "schema_name",
            TableName = "table_name",
            User = "user",
            ClassName = "class_name",
            HnswSettings = new()
            {
                DistanceMethod = DistanceMethod.Cosine,
                EfConstruction = 1,
                EfSearch = 1,
                M = 1,
                VectorType = VectorType.Bit,
            },
            HybridSearch = true,
            PerformSetup = true,
            SupportsNestedMetadataFilters = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudPostgresVectorStore>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CloudPostgresVectorStore
        {
            Database = "database",
            EmbedDim = 0,
            Host = "host",
            Password = "password",
            Port = 0,
            SchemaName = "schema_name",
            TableName = "table_name",
            User = "user",
            ClassName = "class_name",
            HnswSettings = new()
            {
                DistanceMethod = DistanceMethod.Cosine,
                EfConstruction = 1,
                EfSearch = 1,
                M = 1,
                VectorType = VectorType.Bit,
            },
            HybridSearch = true,
            PerformSetup = true,
            SupportsNestedMetadataFilters = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CloudPostgresVectorStore>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDatabase = "database";
        long expectedEmbedDim = 0;
        string expectedHost = "host";
        string expectedPassword = "password";
        long expectedPort = 0;
        string expectedSchemaName = "schema_name";
        string expectedTableName = "table_name";
        string expectedUser = "user";
        string expectedClassName = "class_name";
        PgVectorHnswSettings expectedHnswSettings = new()
        {
            DistanceMethod = DistanceMethod.Cosine,
            EfConstruction = 1,
            EfSearch = 1,
            M = 1,
            VectorType = VectorType.Bit,
        };
        bool expectedHybridSearch = true;
        bool expectedPerformSetup = true;
        bool expectedSupportsNestedMetadataFilters = true;

        Assert.Equal(expectedDatabase, deserialized.Database);
        Assert.Equal(expectedEmbedDim, deserialized.EmbedDim);
        Assert.Equal(expectedHost, deserialized.Host);
        Assert.Equal(expectedPassword, deserialized.Password);
        Assert.Equal(expectedPort, deserialized.Port);
        Assert.Equal(expectedSchemaName, deserialized.SchemaName);
        Assert.Equal(expectedTableName, deserialized.TableName);
        Assert.Equal(expectedUser, deserialized.User);
        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedHnswSettings, deserialized.HnswSettings);
        Assert.Equal(expectedHybridSearch, deserialized.HybridSearch);
        Assert.Equal(expectedPerformSetup, deserialized.PerformSetup);
        Assert.Equal(
            expectedSupportsNestedMetadataFilters,
            deserialized.SupportsNestedMetadataFilters
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CloudPostgresVectorStore
        {
            Database = "database",
            EmbedDim = 0,
            Host = "host",
            Password = "password",
            Port = 0,
            SchemaName = "schema_name",
            TableName = "table_name",
            User = "user",
            ClassName = "class_name",
            HnswSettings = new()
            {
                DistanceMethod = DistanceMethod.Cosine,
                EfConstruction = 1,
                EfSearch = 1,
                M = 1,
                VectorType = VectorType.Bit,
            },
            HybridSearch = true,
            PerformSetup = true,
            SupportsNestedMetadataFilters = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudPostgresVectorStore
        {
            Database = "database",
            EmbedDim = 0,
            Host = "host",
            Password = "password",
            Port = 0,
            SchemaName = "schema_name",
            TableName = "table_name",
            User = "user",
            HnswSettings = new()
            {
                DistanceMethod = DistanceMethod.Cosine,
                EfConstruction = 1,
                EfSearch = 1,
                M = 1,
                VectorType = VectorType.Bit,
            },
            HybridSearch = true,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.PerformSetup);
        Assert.False(model.RawData.ContainsKey("perform_setup"));
        Assert.Null(model.SupportsNestedMetadataFilters);
        Assert.False(model.RawData.ContainsKey("supports_nested_metadata_filters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudPostgresVectorStore
        {
            Database = "database",
            EmbedDim = 0,
            Host = "host",
            Password = "password",
            Port = 0,
            SchemaName = "schema_name",
            TableName = "table_name",
            User = "user",
            HnswSettings = new()
            {
                DistanceMethod = DistanceMethod.Cosine,
                EfConstruction = 1,
                EfSearch = 1,
                M = 1,
                VectorType = VectorType.Bit,
            },
            HybridSearch = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CloudPostgresVectorStore
        {
            Database = "database",
            EmbedDim = 0,
            Host = "host",
            Password = "password",
            Port = 0,
            SchemaName = "schema_name",
            TableName = "table_name",
            User = "user",
            HnswSettings = new()
            {
                DistanceMethod = DistanceMethod.Cosine,
                EfConstruction = 1,
                EfSearch = 1,
                M = 1,
                VectorType = VectorType.Bit,
            },
            HybridSearch = true,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            PerformSetup = null,
            SupportsNestedMetadataFilters = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.PerformSetup);
        Assert.False(model.RawData.ContainsKey("perform_setup"));
        Assert.Null(model.SupportsNestedMetadataFilters);
        Assert.False(model.RawData.ContainsKey("supports_nested_metadata_filters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudPostgresVectorStore
        {
            Database = "database",
            EmbedDim = 0,
            Host = "host",
            Password = "password",
            Port = 0,
            SchemaName = "schema_name",
            TableName = "table_name",
            User = "user",
            HnswSettings = new()
            {
                DistanceMethod = DistanceMethod.Cosine,
                EfConstruction = 1,
                EfSearch = 1,
                M = 1,
                VectorType = VectorType.Bit,
            },
            HybridSearch = true,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            PerformSetup = null,
            SupportsNestedMetadataFilters = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CloudPostgresVectorStore
        {
            Database = "database",
            EmbedDim = 0,
            Host = "host",
            Password = "password",
            Port = 0,
            SchemaName = "schema_name",
            TableName = "table_name",
            User = "user",
            ClassName = "class_name",
            PerformSetup = true,
            SupportsNestedMetadataFilters = true,
        };

        Assert.Null(model.HnswSettings);
        Assert.False(model.RawData.ContainsKey("hnsw_settings"));
        Assert.Null(model.HybridSearch);
        Assert.False(model.RawData.ContainsKey("hybrid_search"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CloudPostgresVectorStore
        {
            Database = "database",
            EmbedDim = 0,
            Host = "host",
            Password = "password",
            Port = 0,
            SchemaName = "schema_name",
            TableName = "table_name",
            User = "user",
            ClassName = "class_name",
            PerformSetup = true,
            SupportsNestedMetadataFilters = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CloudPostgresVectorStore
        {
            Database = "database",
            EmbedDim = 0,
            Host = "host",
            Password = "password",
            Port = 0,
            SchemaName = "schema_name",
            TableName = "table_name",
            User = "user",
            ClassName = "class_name",
            PerformSetup = true,
            SupportsNestedMetadataFilters = true,

            HnswSettings = null,
            HybridSearch = null,
        };

        Assert.Null(model.HnswSettings);
        Assert.True(model.RawData.ContainsKey("hnsw_settings"));
        Assert.Null(model.HybridSearch);
        Assert.True(model.RawData.ContainsKey("hybrid_search"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CloudPostgresVectorStore
        {
            Database = "database",
            EmbedDim = 0,
            Host = "host",
            Password = "password",
            Port = 0,
            SchemaName = "schema_name",
            TableName = "table_name",
            User = "user",
            ClassName = "class_name",
            PerformSetup = true,
            SupportsNestedMetadataFilters = true,

            HnswSettings = null,
            HybridSearch = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CloudPostgresVectorStore
        {
            Database = "database",
            EmbedDim = 0,
            Host = "host",
            Password = "password",
            Port = 0,
            SchemaName = "schema_name",
            TableName = "table_name",
            User = "user",
            ClassName = "class_name",
            HnswSettings = new()
            {
                DistanceMethod = DistanceMethod.Cosine,
                EfConstruction = 1,
                EfSearch = 1,
                M = 1,
                VectorType = VectorType.Bit,
            },
            HybridSearch = true,
            PerformSetup = true,
            SupportsNestedMetadataFilters = true,
        };

        CloudPostgresVectorStore copied = new(model);

        Assert.Equal(model, copied);
    }
}
