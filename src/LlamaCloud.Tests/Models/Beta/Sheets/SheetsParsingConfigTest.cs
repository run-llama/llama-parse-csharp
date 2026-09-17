using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Beta.Sheets;

namespace LlamaCloud.Tests.Models.Beta.Sheets;

public class SheetsParsingConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SheetsParsingConfig
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity = TableMergeSensitivity.Strong,
            Tier = Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        string expectedExtractionRange = "extraction_range";
        bool expectedFlattenHierarchicalTables = true;
        bool expectedGenerateAdditionalMetadata = true;
        bool expectedIncludeHiddenCells = true;
        List<string> expectedSheetNames = ["string"];
        string expectedSpecialization = "specialization";
        ApiEnum<string, TableMergeSensitivity> expectedTableMergeSensitivity =
            TableMergeSensitivity.Strong;
        ApiEnum<string, Tier> expectedTier = Tier.Agentic;
        bool expectedUseExperimentalProcessing = true;

        Assert.Equal(expectedExtractionRange, model.ExtractionRange);
        Assert.Equal(expectedFlattenHierarchicalTables, model.FlattenHierarchicalTables);
        Assert.Equal(expectedGenerateAdditionalMetadata, model.GenerateAdditionalMetadata);
        Assert.Equal(expectedIncludeHiddenCells, model.IncludeHiddenCells);
        Assert.NotNull(model.SheetNames);
        Assert.Equal(expectedSheetNames.Count, model.SheetNames.Count);
        for (int i = 0; i < expectedSheetNames.Count; i++)
        {
            Assert.Equal(expectedSheetNames[i], model.SheetNames[i]);
        }
        Assert.Equal(expectedSpecialization, model.Specialization);
        Assert.Equal(expectedTableMergeSensitivity, model.TableMergeSensitivity);
        Assert.Equal(expectedTier, model.Tier);
        Assert.Equal(expectedUseExperimentalProcessing, model.UseExperimentalProcessing);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SheetsParsingConfig
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity = TableMergeSensitivity.Strong,
            Tier = Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SheetsParsingConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SheetsParsingConfig
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity = TableMergeSensitivity.Strong,
            Tier = Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SheetsParsingConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExtractionRange = "extraction_range";
        bool expectedFlattenHierarchicalTables = true;
        bool expectedGenerateAdditionalMetadata = true;
        bool expectedIncludeHiddenCells = true;
        List<string> expectedSheetNames = ["string"];
        string expectedSpecialization = "specialization";
        ApiEnum<string, TableMergeSensitivity> expectedTableMergeSensitivity =
            TableMergeSensitivity.Strong;
        ApiEnum<string, Tier> expectedTier = Tier.Agentic;
        bool expectedUseExperimentalProcessing = true;

        Assert.Equal(expectedExtractionRange, deserialized.ExtractionRange);
        Assert.Equal(expectedFlattenHierarchicalTables, deserialized.FlattenHierarchicalTables);
        Assert.Equal(expectedGenerateAdditionalMetadata, deserialized.GenerateAdditionalMetadata);
        Assert.Equal(expectedIncludeHiddenCells, deserialized.IncludeHiddenCells);
        Assert.NotNull(deserialized.SheetNames);
        Assert.Equal(expectedSheetNames.Count, deserialized.SheetNames.Count);
        for (int i = 0; i < expectedSheetNames.Count; i++)
        {
            Assert.Equal(expectedSheetNames[i], deserialized.SheetNames[i]);
        }
        Assert.Equal(expectedSpecialization, deserialized.Specialization);
        Assert.Equal(expectedTableMergeSensitivity, deserialized.TableMergeSensitivity);
        Assert.Equal(expectedTier, deserialized.Tier);
        Assert.Equal(expectedUseExperimentalProcessing, deserialized.UseExperimentalProcessing);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SheetsParsingConfig
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity = TableMergeSensitivity.Strong,
            Tier = Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SheetsParsingConfig
        {
            ExtractionRange = "extraction_range",
            SheetNames = ["string"],
            Specialization = "specialization",
        };

        Assert.Null(model.FlattenHierarchicalTables);
        Assert.False(model.RawData.ContainsKey("flatten_hierarchical_tables"));
        Assert.Null(model.GenerateAdditionalMetadata);
        Assert.False(model.RawData.ContainsKey("generate_additional_metadata"));
        Assert.Null(model.IncludeHiddenCells);
        Assert.False(model.RawData.ContainsKey("include_hidden_cells"));
        Assert.Null(model.TableMergeSensitivity);
        Assert.False(model.RawData.ContainsKey("table_merge_sensitivity"));
        Assert.Null(model.Tier);
        Assert.False(model.RawData.ContainsKey("tier"));
        Assert.Null(model.UseExperimentalProcessing);
        Assert.False(model.RawData.ContainsKey("use_experimental_processing"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SheetsParsingConfig
        {
            ExtractionRange = "extraction_range",
            SheetNames = ["string"],
            Specialization = "specialization",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SheetsParsingConfig
        {
            ExtractionRange = "extraction_range",
            SheetNames = ["string"],
            Specialization = "specialization",

            // Null should be interpreted as omitted for these properties
            FlattenHierarchicalTables = null,
            GenerateAdditionalMetadata = null,
            IncludeHiddenCells = null,
            TableMergeSensitivity = null,
            Tier = null,
            UseExperimentalProcessing = null,
        };

        Assert.Null(model.FlattenHierarchicalTables);
        Assert.False(model.RawData.ContainsKey("flatten_hierarchical_tables"));
        Assert.Null(model.GenerateAdditionalMetadata);
        Assert.False(model.RawData.ContainsKey("generate_additional_metadata"));
        Assert.Null(model.IncludeHiddenCells);
        Assert.False(model.RawData.ContainsKey("include_hidden_cells"));
        Assert.Null(model.TableMergeSensitivity);
        Assert.False(model.RawData.ContainsKey("table_merge_sensitivity"));
        Assert.Null(model.Tier);
        Assert.False(model.RawData.ContainsKey("tier"));
        Assert.Null(model.UseExperimentalProcessing);
        Assert.False(model.RawData.ContainsKey("use_experimental_processing"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SheetsParsingConfig
        {
            ExtractionRange = "extraction_range",
            SheetNames = ["string"],
            Specialization = "specialization",

            // Null should be interpreted as omitted for these properties
            FlattenHierarchicalTables = null,
            GenerateAdditionalMetadata = null,
            IncludeHiddenCells = null,
            TableMergeSensitivity = null,
            Tier = null,
            UseExperimentalProcessing = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SheetsParsingConfig
        {
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            TableMergeSensitivity = TableMergeSensitivity.Strong,
            Tier = Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        Assert.Null(model.ExtractionRange);
        Assert.False(model.RawData.ContainsKey("extraction_range"));
        Assert.Null(model.SheetNames);
        Assert.False(model.RawData.ContainsKey("sheet_names"));
        Assert.Null(model.Specialization);
        Assert.False(model.RawData.ContainsKey("specialization"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SheetsParsingConfig
        {
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            TableMergeSensitivity = TableMergeSensitivity.Strong,
            Tier = Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SheetsParsingConfig
        {
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            TableMergeSensitivity = TableMergeSensitivity.Strong,
            Tier = Tier.Agentic,
            UseExperimentalProcessing = true,

            ExtractionRange = null,
            SheetNames = null,
            Specialization = null,
        };

        Assert.Null(model.ExtractionRange);
        Assert.True(model.RawData.ContainsKey("extraction_range"));
        Assert.Null(model.SheetNames);
        Assert.True(model.RawData.ContainsKey("sheet_names"));
        Assert.Null(model.Specialization);
        Assert.True(model.RawData.ContainsKey("specialization"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SheetsParsingConfig
        {
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            TableMergeSensitivity = TableMergeSensitivity.Strong,
            Tier = Tier.Agentic,
            UseExperimentalProcessing = true,

            ExtractionRange = null,
            SheetNames = null,
            Specialization = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SheetsParsingConfig
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity = TableMergeSensitivity.Strong,
            Tier = Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        SheetsParsingConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TableMergeSensitivityTest : TestBase
{
    [Theory]
    [InlineData(TableMergeSensitivity.Strong)]
    [InlineData(TableMergeSensitivity.Weak)]
    public void Validation_Works(TableMergeSensitivity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TableMergeSensitivity> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TableMergeSensitivity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TableMergeSensitivity.Strong)]
    [InlineData(TableMergeSensitivity.Weak)]
    public void SerializationRoundtrip_Works(TableMergeSensitivity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TableMergeSensitivity> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TableMergeSensitivity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TableMergeSensitivity>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TableMergeSensitivity>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TierTest : TestBase
{
    [Theory]
    [InlineData(Tier.Agentic)]
    [InlineData(Tier.CostEffective)]
    public void Validation_Works(Tier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Tier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Tier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Tier.Agentic)]
    [InlineData(Tier.CostEffective)]
    public void SerializationRoundtrip_Works(Tier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Tier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Tier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Tier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Tier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
