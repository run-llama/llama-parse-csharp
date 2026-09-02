using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Parsing;
using Configurations = LlamaCloud.Models.Configurations;

namespace LlamaCloud.Tests.Models.Configurations;

public class ConfigurationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Configurations::ConfigurationCreateParams
        {
            Name = "x",
            Parameters = new Configurations::ClassifyV2Parameters()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Configurations::Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedName = "x";
        Configurations::Parameters expectedParameters = new Configurations::ClassifyV2Parameters()
        {
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Mode = Configurations::Mode.Fast,
            ParsingConfiguration = new()
            {
                Lang = "en",
                MaxPages = 10,
                TargetPages = "1,3,5-7",
            },
        };
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedParameters, parameters.Parameters);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Configurations::ConfigurationCreateParams
        {
            Name = "x",
            Parameters = new Configurations::ClassifyV2Parameters()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Configurations::Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Configurations::ConfigurationCreateParams
        {
            Name = "x",
            Parameters = new Configurations::ClassifyV2Parameters()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Configurations::Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },

            OrganizationID = null,
            ProjectID = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
    }

    [Fact]
    public void Url_Works()
    {
        Configurations::ConfigurationCreateParams parameters = new()
        {
            Name = "x",
            Parameters = new Configurations::ClassifyV2Parameters()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Configurations::Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/beta/configurations?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Configurations::ConfigurationCreateParams
        {
            Name = "x",
            Parameters = new Configurations::ClassifyV2Parameters()
            {
                Rules =
                [
                    new()
                    {
                        Description = "contains invoice number, line items, and total amount",
                        Type = "invoice",
                    },
                ],
                Mode = Configurations::Mode.Fast,
                ParsingConfiguration = new()
                {
                    Lang = "en",
                    MaxPages = 10,
                    TargetPages = "1,3,5-7",
                },
            },
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Configurations::ConfigurationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ParametersTest : TestBase
{
    [Fact]
    public void ClassifyV2ValidationWorks()
    {
        Configurations::Parameters value = new Configurations::ClassifyV2Parameters()
        {
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Mode = Configurations::Mode.Fast,
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
        Configurations::Parameters value = new Configurations::ExtractV2Parameters()
        {
            DataSchema = new Dictionary<string, Configurations::DataSchema?>()
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
            ExtractionTarget = Configurations::ExtractionTarget.PerDoc,
            MaxPages = 10,
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = Configurations::ParseTier.Fast,
            SheetNames = ["Sheet 1", "Q4 Summary"],
            SpreadsheetMode = true,
            SystemPrompt =
                "Extract all monetary values in USD. If a currency is not specified, assume USD.",
            TargetPages = "1,3,5-7",
            Tier = Configurations::ExtractV2ParametersTier.CostEffective,
            Version = "latest",
        };
        value.Validate();
    }

    [Fact]
    public void ParseV2ValidationWorks()
    {
        Configurations::Parameters value = new Configurations::ParseV2Parameters()
        {
            Tier = Configurations::ParseV2ParametersTier.Agentic,
            Version = Configurations::Version.Latest,
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
                GranularBboxes =
                [
                    Configurations::GranularBbox.Word,
                    Configurations::GranularBbox.Line,
                    Configurations::GranularBbox.Cell,
                ],
                ImagesToSave = [Configurations::ImagesToSave.Embedded],
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
                            SpecializedChartParsing =
                                Configurations::SpecializedChartParsing.Agentic,
                            Tier = Configurations::ParsingConfTier.Agentic,
                            Version = Configurations::ParsingConfVersion.Latest,
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
                ConfidenceScoreEffort = Configurations::ConfidenceScoreEffort.High,
                CostOptimizer = new() { Enable = true },
                DisableHeuristics = true,
                Forms = Configurations::Forms.Enrich,
                Ignore = new()
                {
                    IgnoreDiagonalText = true,
                    IgnoreHiddenText = true,
                    IgnoreTextInImage = true,
                },
                OcrParameters = new() { Languages = [ParsingLanguages.Abq] },
                SpecializedChartParsing =
                    Configurations::ProcessingOptionsSpecializedChartParsing.Agentic,
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
                    WebhookOutputFormat = Configurations::WebhookOutputFormat.Json,
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
        Configurations::Parameters value = new Configurations::SplitV1Parameters()
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new()
            {
                AllowUncategorized = Configurations::AllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },
        };
        value.Validate();
    }

    [Fact]
    public void SpreadsheetV1ValidationWorks()
    {
        Configurations::Parameters value = new Configurations::SpreadsheetV1()
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity = Configurations::TableMergeSensitivity.Strong,
            Tier = Configurations::Tier.Agentic,
            UseExperimentalProcessing = true,
        };
        value.Validate();
    }

    [Fact]
    public void UntypedValidationWorks()
    {
        Configurations::Parameters value = new Configurations::UntypedParameters();
        value.Validate();
    }

    [Fact]
    public void ClassifyV2SerializationRoundtripWorks()
    {
        Configurations::Parameters value = new Configurations::ClassifyV2Parameters()
        {
            Rules =
            [
                new()
                {
                    Description = "contains invoice number, line items, and total amount",
                    Type = "invoice",
                },
            ],
            Mode = Configurations::Mode.Fast,
            ParsingConfiguration = new()
            {
                Lang = "en",
                MaxPages = 10,
                TargetPages = "1,3,5-7",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Configurations::Parameters>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExtractV2SerializationRoundtripWorks()
    {
        Configurations::Parameters value = new Configurations::ExtractV2Parameters()
        {
            DataSchema = new Dictionary<string, Configurations::DataSchema?>()
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
            ExtractionTarget = Configurations::ExtractionTarget.PerDoc,
            MaxPages = 10,
            ParseConfigID = "cfg-11111111-2222-3333-4444-555555555555",
            ParseTier = Configurations::ParseTier.Fast,
            SheetNames = ["Sheet 1", "Q4 Summary"],
            SpreadsheetMode = true,
            SystemPrompt =
                "Extract all monetary values in USD. If a currency is not specified, assume USD.",
            TargetPages = "1,3,5-7",
            Tier = Configurations::ExtractV2ParametersTier.CostEffective,
            Version = "latest",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Configurations::Parameters>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ParseV2SerializationRoundtripWorks()
    {
        Configurations::Parameters value = new Configurations::ParseV2Parameters()
        {
            Tier = Configurations::ParseV2ParametersTier.Agentic,
            Version = Configurations::Version.Latest,
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
                GranularBboxes =
                [
                    Configurations::GranularBbox.Word,
                    Configurations::GranularBbox.Line,
                    Configurations::GranularBbox.Cell,
                ],
                ImagesToSave = [Configurations::ImagesToSave.Embedded],
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
                            SpecializedChartParsing =
                                Configurations::SpecializedChartParsing.Agentic,
                            Tier = Configurations::ParsingConfTier.Agentic,
                            Version = Configurations::ParsingConfVersion.Latest,
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
                ConfidenceScoreEffort = Configurations::ConfidenceScoreEffort.High,
                CostOptimizer = new() { Enable = true },
                DisableHeuristics = true,
                Forms = Configurations::Forms.Enrich,
                Ignore = new()
                {
                    IgnoreDiagonalText = true,
                    IgnoreHiddenText = true,
                    IgnoreTextInImage = true,
                },
                OcrParameters = new() { Languages = [ParsingLanguages.Abq] },
                SpecializedChartParsing =
                    Configurations::ProcessingOptionsSpecializedChartParsing.Agentic,
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
                    WebhookOutputFormat = Configurations::WebhookOutputFormat.Json,
                    WebhookSigningSecret = "webhook_signing_secret",
                    WebhookUrl = "https:",
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Configurations::Parameters>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SplitV1SerializationRoundtripWorks()
    {
        Configurations::Parameters value = new Configurations::SplitV1Parameters()
        {
            Categories = [new() { Name = "x", Description = "x" }],
            SplittingStrategy = new()
            {
                AllowUncategorized = Configurations::AllowUncategorized.Forbid,
                CustomInstructions = "Start a new segment at every signature page.",
                MinPagesPerSplit = 1,
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Configurations::Parameters>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpreadsheetV1SerializationRoundtripWorks()
    {
        Configurations::Parameters value = new Configurations::SpreadsheetV1()
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity = Configurations::TableMergeSensitivity.Strong,
            Tier = Configurations::Tier.Agentic,
            UseExperimentalProcessing = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Configurations::Parameters>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UntypedSerializationRoundtripWorks()
    {
        Configurations::Parameters value = new Configurations::UntypedParameters();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Configurations::Parameters>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SpreadsheetV1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Configurations::SpreadsheetV1
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity = Configurations::TableMergeSensitivity.Strong,
            Tier = Configurations::Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        JsonElement expectedProductType = JsonSerializer.SerializeToElement("spreadsheet_v1");
        string expectedExtractionRange = "extraction_range";
        bool expectedFlattenHierarchicalTables = true;
        bool expectedGenerateAdditionalMetadata = true;
        bool expectedIncludeHiddenCells = true;
        List<string> expectedSheetNames = ["string"];
        string expectedSpecialization = "specialization";
        ApiEnum<string, Configurations::TableMergeSensitivity> expectedTableMergeSensitivity =
            Configurations::TableMergeSensitivity.Strong;
        ApiEnum<string, Configurations::Tier> expectedTier = Configurations::Tier.Agentic;
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
        var model = new Configurations::SpreadsheetV1
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity = Configurations::TableMergeSensitivity.Strong,
            Tier = Configurations::Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Configurations::SpreadsheetV1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Configurations::SpreadsheetV1
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity = Configurations::TableMergeSensitivity.Strong,
            Tier = Configurations::Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Configurations::SpreadsheetV1>(
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
        ApiEnum<string, Configurations::TableMergeSensitivity> expectedTableMergeSensitivity =
            Configurations::TableMergeSensitivity.Strong;
        ApiEnum<string, Configurations::Tier> expectedTier = Configurations::Tier.Agentic;
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
        var model = new Configurations::SpreadsheetV1
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity = Configurations::TableMergeSensitivity.Strong,
            Tier = Configurations::Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Configurations::SpreadsheetV1
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
        var model = new Configurations::SpreadsheetV1
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
        var model = new Configurations::SpreadsheetV1
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
        var model = new Configurations::SpreadsheetV1
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
        var model = new Configurations::SpreadsheetV1
        {
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            TableMergeSensitivity = Configurations::TableMergeSensitivity.Strong,
            Tier = Configurations::Tier.Agentic,
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
        var model = new Configurations::SpreadsheetV1
        {
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            TableMergeSensitivity = Configurations::TableMergeSensitivity.Strong,
            Tier = Configurations::Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Configurations::SpreadsheetV1
        {
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            TableMergeSensitivity = Configurations::TableMergeSensitivity.Strong,
            Tier = Configurations::Tier.Agentic,
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
        var model = new Configurations::SpreadsheetV1
        {
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            TableMergeSensitivity = Configurations::TableMergeSensitivity.Strong,
            Tier = Configurations::Tier.Agentic,
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
        var model = new Configurations::SpreadsheetV1
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity = Configurations::TableMergeSensitivity.Strong,
            Tier = Configurations::Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        Configurations::SpreadsheetV1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TableMergeSensitivityTest : TestBase
{
    [Theory]
    [InlineData(Configurations::TableMergeSensitivity.Strong)]
    [InlineData(Configurations::TableMergeSensitivity.Weak)]
    public void Validation_Works(Configurations::TableMergeSensitivity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Configurations::TableMergeSensitivity> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Configurations::TableMergeSensitivity>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Configurations::TableMergeSensitivity.Strong)]
    [InlineData(Configurations::TableMergeSensitivity.Weak)]
    public void SerializationRoundtrip_Works(Configurations::TableMergeSensitivity rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Configurations::TableMergeSensitivity> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Configurations::TableMergeSensitivity>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Configurations::TableMergeSensitivity>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Configurations::TableMergeSensitivity>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TierTest : TestBase
{
    [Theory]
    [InlineData(Configurations::Tier.Agentic)]
    [InlineData(Configurations::Tier.CostEffective)]
    public void Validation_Works(Configurations::Tier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Configurations::Tier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Configurations::Tier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Configurations::Tier.Agentic)]
    [InlineData(Configurations::Tier.CostEffective)]
    public void SerializationRoundtrip_Works(Configurations::Tier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Configurations::Tier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Configurations::Tier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Configurations::Tier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Configurations::Tier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
