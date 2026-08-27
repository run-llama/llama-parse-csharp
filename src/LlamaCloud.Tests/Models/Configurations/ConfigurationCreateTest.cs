using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Configurations;
using Parsing = LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Configurations;

public class ConfigurationCreateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConfigurationCreate
        {
            Name = "x",
            Parameters = new ClassifyV2Parameters()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
        };

        string expectedName = "x";
        ConfigurationCreateParameters expectedParameters = new ClassifyV2Parameters()
        {
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Mode = Mode.Fast,
            ParsingConfiguration = new()
            {
                Lang = "en",
                MaxPages = 10,
                TargetPages = "1,3,5-7",
            },
        };

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedParameters, model.Parameters);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConfigurationCreate
        {
            Name = "x",
            Parameters = new ClassifyV2Parameters()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigurationCreate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConfigurationCreate
        {
            Name = "x",
            Parameters = new ClassifyV2Parameters()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigurationCreate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        ConfigurationCreateParameters expectedParameters = new ClassifyV2Parameters()
        {
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Mode = Mode.Fast,
            ParsingConfiguration = new()
            {
                Lang = "en",
                MaxPages = 10,
                TargetPages = "1,3,5-7",
            },
        };

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedParameters, deserialized.Parameters);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConfigurationCreate
        {
            Name = "x",
            Parameters = new ClassifyV2Parameters()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConfigurationCreate
        {
            Name = "x",
            Parameters = new ClassifyV2Parameters()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
        };

        ConfigurationCreate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConfigurationCreateParametersTest : TestBase
{
    [Fact]
    public void ClassifyV2ValidationWorks()
    {
        ConfigurationCreateParameters value = new ClassifyV2Parameters()
        {
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Mode = Mode.Fast,
            ParsingConfiguration = new()
            {
                Lang = "en",
                MaxPages = 10,
                TargetPages = "1,3,5-7",
            },
        };
        value.Validate();
    }

    [Fact]
    public void ExtractV2ValidationWorks()
    {
        ConfigurationCreateParameters value = new ExtractV2Parameters()
        {
            DataSchema = new Dictionary<string, DataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            CiteSources = true,
            ConfidenceScores = true,
            DisableCache = true,
            ExtractionTarget = ExtractionTarget.PerDoc,
            MaxPages = 10,
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = "fast",
            SheetNames = ["Sheet 1", "Q4 Summary"],
            SpreadsheetMode = true,
            SystemPrompt =
                "Extract all monetary values in USD. If a currency is not specified, assume USD.",
            TargetPages = "1,3,5-7",
            Tier = ExtractV2ParametersTier.CostEffective,
            Version = "latest",
        };
        value.Validate();
    }

    [Fact]
    public void ParseV2ValidationWorks()
    {
        ConfigurationCreateParameters value = new ParseV2Parameters()
        {
            Tier = ParseV2ParametersTier.Agentic,
            Version = Version.Latest,
            AgenticOptions = new() { CustomPrompt = "custom_prompt" },
            ClientName = "client_name",
            CropBox = new()
            {
                Bottom = 0,
                Left = 0,
                Right = 0,
                Top = 0,
            },
            DisableCache = true,
            FastOptions = JsonSerializer.Deserialize<JsonElement>("{}"),
            InputOptions = new()
            {
                Html = new()
                {
                    MakeAllElementsVisible = true,
                    RemoveFixedElements = true,
                    RemoveNavigationElements = true,
                },
                Image = new() { CameraPhotoCorrection = true },
                Pdf = JsonSerializer.Deserialize<JsonElement>("{}"),
                Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                Spreadsheet = new()
                {
                    DetectSubTablesInSheets = true,
                    ForceFormulaComputationInSheets = true,
                    IncludeHiddenSheets = true,
                },
            },
            OutputOptions = new()
            {
                AdditionalOutputs = ["stripped_md", "concatenated_stripped_txt", "word_bbox"],
                ExtractPrintedPageNumber = true,
                GranularBboxes = [GranularBbox.Word, GranularBbox.Line, GranularBbox.Cell],
                ImagesToSave = [ImagesToSave.Embedded],
                Markdown = new()
                {
                    AnnotateLineNumbers = true,
                    AnnotateLinks = true,
                    AnnotateRevisions = true,
                    InlineImages = true,
                    Tables = new()
                    {
                        CompactMarkdownTables = true,
                        MarkdownTableMultilineSeparator = "markdown_table_multiline_separator",
                        MergeContinuedTables = true,
                        OutputTablesAsMarkdown = true,
                    },
                },
                SaveOutputPdf = true,
                SpatialText = new()
                {
                    DoNotUnrollColumns = true,
                    PreserveLayoutAlignmentAcrossPages = true,
                    PreserveVerySmallText = true,
                },
                TablesAsSpreadsheet = new() { Enable = true, GuessSheetName = true },
            },
            PageRanges = new() { MaxPages = 1, TargetPages = "target_pages" },
            ProcessingControl = new()
            {
                JobFailureConditions = new()
                {
                    AllowedPageFailureRatio = 1,
                    FailOnBuggyFont = true,
                    FailOnImageExtractionError = true,
                    FailOnImageOcrError = true,
                    FailOnMarkdownReconstructionError = true,
                },
                Timeouts = new() { BaseInSeconds = 1, ExtraTimePerPageInSeconds = 1 },
            },
            ProcessingOptions = new()
            {
                AggressiveTableExtraction = true,
                AutoModeConfiguration =
                [
                    new()
                    {
                        ParsingConf = new()
                        {
                            AdaptiveLongTable = true,
                            AggressiveTableExtraction = true,
                            CropBox = new()
                            {
                                Bottom = 0,
                                Left = 0,
                                Right = 0,
                                Top = 0,
                            },
                            CustomPrompt = "custom_prompt",
                            ExtractLayout = true,
                            HighResOcr = true,
                            Ignore = new() { IgnoreDiagonalText = true, IgnoreHiddenText = true },
                            Language = "language",
                            OutlinedTableExtraction = true,
                            Presentation = new()
                            {
                                OutOfBoundsContent = true,
                                SkipEmbeddedData = true,
                            },
                            SpatialText = new()
                            {
                                DoNotUnrollColumns = true,
                                PreserveLayoutAlignmentAcrossPages = true,
                                PreserveVerySmallText = true,
                            },
                            SpecializedChartParsing = SpecializedChartParsing.Agentic,
                            Tier = ParsingConfTier.Agentic,
                            Version = ParsingConfVersion.Latest,
                        },
                        FilenameMatchGlob = "*.txt",
                        FilenameMatchGlobList = ["string"],
                        FilenameRegexp = "filename_regexp",
                        FilenameRegexpMode = "filename_regexp_mode",
                        FullPageImageInPage = true,
                        FullPageImageInPageThreshold = 0,
                        ImageInPage = true,
                        LayoutElementInPage = "layout_element_in_page",
                        LayoutElementInPageConfidenceThreshold = 0,
                        PageContainsAtLeastNCharts = 0,
                        PageContainsAtLeastNImages = 0,
                        PageContainsAtLeastNLayoutElements = 0,
                        PageContainsAtLeastNLines = 0,
                        PageContainsAtLeastNLinks = 0,
                        PageContainsAtLeastNNumbers = 0,
                        PageContainsAtLeastNPercentNumbers = 0,
                        PageContainsAtLeastNTables = 0,
                        PageContainsAtLeastNWords = 0,
                        PageContainsAtMostNCharts = 0,
                        PageContainsAtMostNImages = 0,
                        PageContainsAtMostNLayoutElements = 0,
                        PageContainsAtMostNLines = 0,
                        PageContainsAtMostNLinks = 0,
                        PageContainsAtMostNNumbers = 0,
                        PageContainsAtMostNPercentNumbers = 0,
                        PageContainsAtMostNTables = 0,
                        PageContainsAtMostNWords = 0,
                        PageLongerThanNChars = 0,
                        PageMdError = true,
                        PageShorterThanNChars = 0,
                        RegexpInPage = "regexp_in_page",
                        RegexpInPageMode = "regexp_in_page_mode",
                        TableInPage = true,
                        TextInPage = "text_in_page",
                        TriggerMode = "trigger_mode",
                    },
                ],
                ConfidenceScoreEffort = ConfidenceScoreEffort.High,
                CostOptimizer = new() { Enable = true },
                DisableHeuristics = true,
                Forms = Forms.Enrich,
                Ignore = new()
                {
                    IgnoreDiagonalText = true,
                    IgnoreHiddenText = true,
                    IgnoreTextInImage = true,
                },
                OcrParameters = new() { Languages = [Parsing::ParsingLanguages.Abq] },
                SpecializedChartParsing = ProcessingOptionsSpecializedChartParsing.Agentic,
            },
            WebhookConfigurationIds = ["whc-...", "whc-..."],
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = ["parse.success", "parse.error"],
                    WebhookHeaders = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    WebhookOutputFormat = WebhookOutputFormat.Json,
                    WebhookSigningSecret = "webhook_signing_secret",
                    WebhookUrl = "https:",
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void SplitV1ValidationWorks()
    {
        ConfigurationCreateParameters value = new SplitV1Parameters()
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new() { AllowUncategorized = AllowUncategorized.Forbid },
        };
        value.Validate();
    }

    [Fact]
    public void SpreadsheetV1ValidationWorks()
    {
        ConfigurationCreateParameters value = new ConfigurationCreateParametersSpreadsheetV1()
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity =
                ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = ConfigurationCreateParametersSpreadsheetV1Tier.Agentic,
            UseExperimentalProcessing = true,
        };
        value.Validate();
    }

    [Fact]
    public void UntypedValidationWorks()
    {
        ConfigurationCreateParameters value = new UntypedParameters();
        value.Validate();
    }

    [Fact]
    public void ClassifyV2SerializationRoundtripWorks()
    {
        ConfigurationCreateParameters value = new ClassifyV2Parameters()
        {
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Mode = Mode.Fast,
            ParsingConfiguration = new()
            {
                Lang = "en",
                MaxPages = 10,
                TargetPages = "1,3,5-7",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigurationCreateParameters>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExtractV2SerializationRoundtripWorks()
    {
        ConfigurationCreateParameters value = new ExtractV2Parameters()
        {
            DataSchema = new Dictionary<string, DataSchema?>()
            {
                {
                    "foo",
                    new(
                        new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        }
                    )
                },
            },
            CiteSources = true,
            ConfidenceScores = true,
            DisableCache = true,
            ExtractionTarget = ExtractionTarget.PerDoc,
            MaxPages = 10,
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = "fast",
            SheetNames = ["Sheet 1", "Q4 Summary"],
            SpreadsheetMode = true,
            SystemPrompt =
                "Extract all monetary values in USD. If a currency is not specified, assume USD.",
            TargetPages = "1,3,5-7",
            Tier = ExtractV2ParametersTier.CostEffective,
            Version = "latest",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigurationCreateParameters>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ParseV2SerializationRoundtripWorks()
    {
        ConfigurationCreateParameters value = new ParseV2Parameters()
        {
            Tier = ParseV2ParametersTier.Agentic,
            Version = Version.Latest,
            AgenticOptions = new() { CustomPrompt = "custom_prompt" },
            ClientName = "client_name",
            CropBox = new()
            {
                Bottom = 0,
                Left = 0,
                Right = 0,
                Top = 0,
            },
            DisableCache = true,
            FastOptions = JsonSerializer.Deserialize<JsonElement>("{}"),
            InputOptions = new()
            {
                Html = new()
                {
                    MakeAllElementsVisible = true,
                    RemoveFixedElements = true,
                    RemoveNavigationElements = true,
                },
                Image = new() { CameraPhotoCorrection = true },
                Pdf = JsonSerializer.Deserialize<JsonElement>("{}"),
                Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                Spreadsheet = new()
                {
                    DetectSubTablesInSheets = true,
                    ForceFormulaComputationInSheets = true,
                    IncludeHiddenSheets = true,
                },
            },
            OutputOptions = new()
            {
                AdditionalOutputs = ["stripped_md", "concatenated_stripped_txt", "word_bbox"],
                ExtractPrintedPageNumber = true,
                GranularBboxes = [GranularBbox.Word, GranularBbox.Line, GranularBbox.Cell],
                ImagesToSave = [ImagesToSave.Embedded],
                Markdown = new()
                {
                    AnnotateLineNumbers = true,
                    AnnotateLinks = true,
                    AnnotateRevisions = true,
                    InlineImages = true,
                    Tables = new()
                    {
                        CompactMarkdownTables = true,
                        MarkdownTableMultilineSeparator = "markdown_table_multiline_separator",
                        MergeContinuedTables = true,
                        OutputTablesAsMarkdown = true,
                    },
                },
                SaveOutputPdf = true,
                SpatialText = new()
                {
                    DoNotUnrollColumns = true,
                    PreserveLayoutAlignmentAcrossPages = true,
                    PreserveVerySmallText = true,
                },
                TablesAsSpreadsheet = new() { Enable = true, GuessSheetName = true },
            },
            PageRanges = new() { MaxPages = 1, TargetPages = "target_pages" },
            ProcessingControl = new()
            {
                JobFailureConditions = new()
                {
                    AllowedPageFailureRatio = 1,
                    FailOnBuggyFont = true,
                    FailOnImageExtractionError = true,
                    FailOnImageOcrError = true,
                    FailOnMarkdownReconstructionError = true,
                },
                Timeouts = new() { BaseInSeconds = 1, ExtraTimePerPageInSeconds = 1 },
            },
            ProcessingOptions = new()
            {
                AggressiveTableExtraction = true,
                AutoModeConfiguration =
                [
                    new()
                    {
                        ParsingConf = new()
                        {
                            AdaptiveLongTable = true,
                            AggressiveTableExtraction = true,
                            CropBox = new()
                            {
                                Bottom = 0,
                                Left = 0,
                                Right = 0,
                                Top = 0,
                            },
                            CustomPrompt = "custom_prompt",
                            ExtractLayout = true,
                            HighResOcr = true,
                            Ignore = new() { IgnoreDiagonalText = true, IgnoreHiddenText = true },
                            Language = "language",
                            OutlinedTableExtraction = true,
                            Presentation = new()
                            {
                                OutOfBoundsContent = true,
                                SkipEmbeddedData = true,
                            },
                            SpatialText = new()
                            {
                                DoNotUnrollColumns = true,
                                PreserveLayoutAlignmentAcrossPages = true,
                                PreserveVerySmallText = true,
                            },
                            SpecializedChartParsing = SpecializedChartParsing.Agentic,
                            Tier = ParsingConfTier.Agentic,
                            Version = ParsingConfVersion.Latest,
                        },
                        FilenameMatchGlob = "*.txt",
                        FilenameMatchGlobList = ["string"],
                        FilenameRegexp = "filename_regexp",
                        FilenameRegexpMode = "filename_regexp_mode",
                        FullPageImageInPage = true,
                        FullPageImageInPageThreshold = 0,
                        ImageInPage = true,
                        LayoutElementInPage = "layout_element_in_page",
                        LayoutElementInPageConfidenceThreshold = 0,
                        PageContainsAtLeastNCharts = 0,
                        PageContainsAtLeastNImages = 0,
                        PageContainsAtLeastNLayoutElements = 0,
                        PageContainsAtLeastNLines = 0,
                        PageContainsAtLeastNLinks = 0,
                        PageContainsAtLeastNNumbers = 0,
                        PageContainsAtLeastNPercentNumbers = 0,
                        PageContainsAtLeastNTables = 0,
                        PageContainsAtLeastNWords = 0,
                        PageContainsAtMostNCharts = 0,
                        PageContainsAtMostNImages = 0,
                        PageContainsAtMostNLayoutElements = 0,
                        PageContainsAtMostNLines = 0,
                        PageContainsAtMostNLinks = 0,
                        PageContainsAtMostNNumbers = 0,
                        PageContainsAtMostNPercentNumbers = 0,
                        PageContainsAtMostNTables = 0,
                        PageContainsAtMostNWords = 0,
                        PageLongerThanNChars = 0,
                        PageMdError = true,
                        PageShorterThanNChars = 0,
                        RegexpInPage = "regexp_in_page",
                        RegexpInPageMode = "regexp_in_page_mode",
                        TableInPage = true,
                        TextInPage = "text_in_page",
                        TriggerMode = "trigger_mode",
                    },
                ],
                ConfidenceScoreEffort = ConfidenceScoreEffort.High,
                CostOptimizer = new() { Enable = true },
                DisableHeuristics = true,
                Forms = Forms.Enrich,
                Ignore = new()
                {
                    IgnoreDiagonalText = true,
                    IgnoreHiddenText = true,
                    IgnoreTextInImage = true,
                },
                OcrParameters = new() { Languages = [Parsing::ParsingLanguages.Abq] },
                SpecializedChartParsing = ProcessingOptionsSpecializedChartParsing.Agentic,
            },
            WebhookConfigurationIds = ["whc-...", "whc-..."],
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = ["parse.success", "parse.error"],
                    WebhookHeaders = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    WebhookOutputFormat = WebhookOutputFormat.Json,
                    WebhookSigningSecret = "webhook_signing_secret",
                    WebhookUrl = "https:",
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigurationCreateParameters>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SplitV1SerializationRoundtripWorks()
    {
        ConfigurationCreateParameters value = new SplitV1Parameters()
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new() { AllowUncategorized = AllowUncategorized.Forbid },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigurationCreateParameters>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpreadsheetV1SerializationRoundtripWorks()
    {
        ConfigurationCreateParameters value = new ConfigurationCreateParametersSpreadsheetV1()
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity =
                ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = ConfigurationCreateParametersSpreadsheetV1Tier.Agentic,
            UseExperimentalProcessing = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigurationCreateParameters>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UntypedSerializationRoundtripWorks()
    {
        ConfigurationCreateParameters value = new UntypedParameters();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigurationCreateParameters>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ConfigurationCreateParametersSpreadsheetV1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConfigurationCreateParametersSpreadsheetV1
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity =
                ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = ConfigurationCreateParametersSpreadsheetV1Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        JsonElement expectedProductType = JsonSerializer.SerializeToElement("spreadsheet_v1");
        string expectedExtractionRange = "extraction_range";
        bool expectedFlattenHierarchicalTables = true;
        bool expectedGenerateAdditionalMetadata = true;
        bool expectedIncludeHiddenCells = true;
        List<string> expectedSheetNames = ["string"];
        string expectedSpecialization = "specialization";
        ApiEnum<
            string,
            ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity
        > expectedTableMergeSensitivity =
            ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity.Strong;
        ApiEnum<string, ConfigurationCreateParametersSpreadsheetV1Tier> expectedTier =
            ConfigurationCreateParametersSpreadsheetV1Tier.Agentic;
        bool expectedUseExperimentalProcessing = true;

        Assert.True(JsonElement.DeepEquals(expectedProductType, model.ProductType));
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
        var model = new ConfigurationCreateParametersSpreadsheetV1
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity =
                ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = ConfigurationCreateParametersSpreadsheetV1Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigurationCreateParametersSpreadsheetV1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConfigurationCreateParametersSpreadsheetV1
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity =
                ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = ConfigurationCreateParametersSpreadsheetV1Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConfigurationCreateParametersSpreadsheetV1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedProductType = JsonSerializer.SerializeToElement("spreadsheet_v1");
        string expectedExtractionRange = "extraction_range";
        bool expectedFlattenHierarchicalTables = true;
        bool expectedGenerateAdditionalMetadata = true;
        bool expectedIncludeHiddenCells = true;
        List<string> expectedSheetNames = ["string"];
        string expectedSpecialization = "specialization";
        ApiEnum<
            string,
            ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity
        > expectedTableMergeSensitivity =
            ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity.Strong;
        ApiEnum<string, ConfigurationCreateParametersSpreadsheetV1Tier> expectedTier =
            ConfigurationCreateParametersSpreadsheetV1Tier.Agentic;
        bool expectedUseExperimentalProcessing = true;

        Assert.True(JsonElement.DeepEquals(expectedProductType, deserialized.ProductType));
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
        var model = new ConfigurationCreateParametersSpreadsheetV1
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity =
                ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = ConfigurationCreateParametersSpreadsheetV1Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConfigurationCreateParametersSpreadsheetV1
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
        var model = new ConfigurationCreateParametersSpreadsheetV1
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
        var model = new ConfigurationCreateParametersSpreadsheetV1
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
        var model = new ConfigurationCreateParametersSpreadsheetV1
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
        var model = new ConfigurationCreateParametersSpreadsheetV1
        {
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            TableMergeSensitivity =
                ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = ConfigurationCreateParametersSpreadsheetV1Tier.Agentic,
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
        var model = new ConfigurationCreateParametersSpreadsheetV1
        {
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            TableMergeSensitivity =
                ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = ConfigurationCreateParametersSpreadsheetV1Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ConfigurationCreateParametersSpreadsheetV1
        {
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            TableMergeSensitivity =
                ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = ConfigurationCreateParametersSpreadsheetV1Tier.Agentic,
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
        var model = new ConfigurationCreateParametersSpreadsheetV1
        {
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            TableMergeSensitivity =
                ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = ConfigurationCreateParametersSpreadsheetV1Tier.Agentic,
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
        var model = new ConfigurationCreateParametersSpreadsheetV1
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity =
                ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = ConfigurationCreateParametersSpreadsheetV1Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        ConfigurationCreateParametersSpreadsheetV1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivityTest : TestBase
{
    [Theory]
    [InlineData(ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity.Strong)]
    [InlineData(ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity.Weak)]
    public void Validation_Works(
        ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity.Strong)]
    [InlineData(ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity.Weak)]
    public void SerializationRoundtrip_Works(
        ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConfigurationCreateParametersSpreadsheetV1TierTest : TestBase
{
    [Theory]
    [InlineData(ConfigurationCreateParametersSpreadsheetV1Tier.Agentic)]
    [InlineData(ConfigurationCreateParametersSpreadsheetV1Tier.CostEffective)]
    public void Validation_Works(ConfigurationCreateParametersSpreadsheetV1Tier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConfigurationCreateParametersSpreadsheetV1Tier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConfigurationCreateParametersSpreadsheetV1Tier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConfigurationCreateParametersSpreadsheetV1Tier.Agentic)]
    [InlineData(ConfigurationCreateParametersSpreadsheetV1Tier.CostEffective)]
    public void SerializationRoundtrip_Works(
        ConfigurationCreateParametersSpreadsheetV1Tier rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConfigurationCreateParametersSpreadsheetV1Tier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConfigurationCreateParametersSpreadsheetV1Tier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ConfigurationCreateParametersSpreadsheetV1Tier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ConfigurationCreateParametersSpreadsheetV1Tier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
