using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using Parsing = LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class ParsingCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Parsing::ParsingCreateParams
        {
            Tier = Parsing::Tier.Fast,
            Version = Parsing::Version.Latest,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AgenticOptions = new() { CustomPrompt = "custom_prompt" },
            ClientName = "client_name",
            ConfigurationID = "configuration_id",
            CropBox = new()
            {
                Bottom = 0,
                Left = 0,
                Right = 0,
                Top = 0,
            },
            DisableCache = true,
            FastOptions = JsonSerializer.Deserialize<JsonElement>("{}"),
            FileID = "file_id",
            HttpProxy = "https:",
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
                    Parsing::GranularBbox.Word,
                    Parsing::GranularBbox.Line,
                    Parsing::GranularBbox.Cell,
                ],
                ImagesToSave = [Parsing::ImagesToSave.Embedded],
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
                            SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                            Tier = Parsing::ParsingConfTier.Agentic,
                            Version = Parsing::ParsingConfVersion.Latest,
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
                ConfidenceScoreEffort = Parsing::ConfidenceScoreEffort.High,
                CostOptimizer = new() { Enable = true },
                DisableHeuristics = true,
                Forms = Parsing::Forms.Enrich,
                Ignore = new()
                {
                    IgnoreDiagonalText = true,
                    IgnoreHiddenText = true,
                    IgnoreTextInImage = true,
                },
                OcrParameters = new() { Languages = [Parsing::ParsingLanguages.Abq] },
                SpecializedChartParsing = Parsing::ProcessingOptionsSpecializedChartParsing.Agentic,
            },
            SourceUrl = "https:",
            UserMetadata = new Dictionary<string, string>()
            {
                { "owner", "jerry" },
                { "team", "research" },
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
                    WebhookOutputFormat = Parsing::WebhookOutputFormat.Json,
                    WebhookSigningSecret = "webhook_signing_secret",
                    WebhookUrl = "https:",
                },
            ],
        };

        ApiEnum<string, Parsing::Tier> expectedTier = Parsing::Tier.Fast;
        ApiEnum<string, Parsing::Version> expectedVersion = Parsing::Version.Latest;
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Parsing::AgenticOptions expectedAgenticOptions = new() { CustomPrompt = "custom_prompt" };
        string expectedClientName = "client_name";
        string expectedConfigurationID = "configuration_id";
        Parsing::CropBox expectedCropBox = new()
        {
            Bottom = 0,
            Left = 0,
            Right = 0,
            Top = 0,
        };
        bool expectedDisableCache = true;
        JsonElement expectedFastOptions = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedFileID = "file_id";
        string expectedHttpProxy = "https:";
        Parsing::InputOptions expectedInputOptions = new()
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
        };
        Parsing::OutputOptions expectedOutputOptions = new()
        {
            AdditionalOutputs = ["stripped_md", "concatenated_stripped_txt", "word_bbox"],
            ExtractPrintedPageNumber = true,
            GranularBboxes =
            [
                Parsing::GranularBbox.Word,
                Parsing::GranularBbox.Line,
                Parsing::GranularBbox.Cell,
            ],
            ImagesToSave = [Parsing::ImagesToSave.Embedded],
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
        };
        Parsing::PageRanges expectedPageRanges = new()
        {
            MaxPages = 1,
            TargetPages = "target_pages",
        };
        Parsing::ProcessingControl expectedProcessingControl = new()
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
        };
        Parsing::ProcessingOptions expectedProcessingOptions = new()
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
                        Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                        SpatialText = new()
                        {
                            DoNotUnrollColumns = true,
                            PreserveLayoutAlignmentAcrossPages = true,
                            PreserveVerySmallText = true,
                        },
                        SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                        Tier = Parsing::ParsingConfTier.Agentic,
                        Version = Parsing::ParsingConfVersion.Latest,
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
            ConfidenceScoreEffort = Parsing::ConfidenceScoreEffort.High,
            CostOptimizer = new() { Enable = true },
            DisableHeuristics = true,
            Forms = Parsing::Forms.Enrich,
            Ignore = new()
            {
                IgnoreDiagonalText = true,
                IgnoreHiddenText = true,
                IgnoreTextInImage = true,
            },
            OcrParameters = new() { Languages = [Parsing::ParsingLanguages.Abq] },
            SpecializedChartParsing = Parsing::ProcessingOptionsSpecializedChartParsing.Agentic,
        };
        string expectedSourceUrl = "https:";
        Dictionary<string, string> expectedUserMetadata = new()
        {
            { "owner", "jerry" },
            { "team", "research" },
        };
        List<string> expectedWebhookConfigurationIds = ["whc-...", "whc-..."];
        List<Parsing::WebhookConfiguration> expectedWebhookConfigurations =
        [
            new()
            {
                WebhookEvents = ["parse.success", "parse.error"],
                WebhookHeaders = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                WebhookOutputFormat = Parsing::WebhookOutputFormat.Json,
                WebhookSigningSecret = "webhook_signing_secret",
                WebhookUrl = "https:",
            },
        ];

        Assert.Equal(expectedTier, parameters.Tier);
        Assert.Equal(expectedVersion, parameters.Version);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedAgenticOptions, parameters.AgenticOptions);
        Assert.Equal(expectedClientName, parameters.ClientName);
        Assert.Equal(expectedConfigurationID, parameters.ConfigurationID);
        Assert.Equal(expectedCropBox, parameters.CropBox);
        Assert.Equal(expectedDisableCache, parameters.DisableCache);
        Assert.NotNull(parameters.FastOptions);
        Assert.True(JsonElement.DeepEquals(expectedFastOptions, parameters.FastOptions.Value));
        Assert.Equal(expectedFileID, parameters.FileID);
        Assert.Equal(expectedHttpProxy, parameters.HttpProxy);
        Assert.Equal(expectedInputOptions, parameters.InputOptions);
        Assert.Equal(expectedOutputOptions, parameters.OutputOptions);
        Assert.Equal(expectedPageRanges, parameters.PageRanges);
        Assert.Equal(expectedProcessingControl, parameters.ProcessingControl);
        Assert.Equal(expectedProcessingOptions, parameters.ProcessingOptions);
        Assert.Equal(expectedSourceUrl, parameters.SourceUrl);
        Assert.NotNull(parameters.UserMetadata);
        Assert.Equal(expectedUserMetadata.Count, parameters.UserMetadata.Count);
        foreach (var item in expectedUserMetadata)
        {
            Assert.True(parameters.UserMetadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.UserMetadata[item.Key]);
        }
        Assert.NotNull(parameters.WebhookConfigurationIds);
        Assert.Equal(
            expectedWebhookConfigurationIds.Count,
            parameters.WebhookConfigurationIds.Count
        );
        for (int i = 0; i < expectedWebhookConfigurationIds.Count; i++)
        {
            Assert.Equal(expectedWebhookConfigurationIds[i], parameters.WebhookConfigurationIds[i]);
        }
        Assert.NotNull(parameters.WebhookConfigurations);
        Assert.Equal(expectedWebhookConfigurations.Count, parameters.WebhookConfigurations.Count);
        for (int i = 0; i < expectedWebhookConfigurations.Count; i++)
        {
            Assert.Equal(expectedWebhookConfigurations[i], parameters.WebhookConfigurations[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Parsing::ParsingCreateParams
        {
            Tier = Parsing::Tier.Fast,
            Version = Parsing::Version.Latest,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AgenticOptions = new() { CustomPrompt = "custom_prompt" },
            ClientName = "client_name",
            ConfigurationID = "configuration_id",
            DisableCache = true,
            FastOptions = JsonSerializer.Deserialize<JsonElement>("{}"),
            FileID = "file_id",
            HttpProxy = "https:",
            SourceUrl = "https:",
            UserMetadata = new Dictionary<string, string>()
            {
                { "owner", "jerry" },
                { "team", "research" },
            },
            WebhookConfigurationIds = ["whc-...", "whc-..."],
        };

        Assert.Null(parameters.CropBox);
        Assert.False(parameters.RawBodyData.ContainsKey("crop_box"));
        Assert.Null(parameters.InputOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("input_options"));
        Assert.Null(parameters.OutputOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("output_options"));
        Assert.Null(parameters.PageRanges);
        Assert.False(parameters.RawBodyData.ContainsKey("page_ranges"));
        Assert.Null(parameters.ProcessingControl);
        Assert.False(parameters.RawBodyData.ContainsKey("processing_control"));
        Assert.Null(parameters.ProcessingOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("processing_options"));
        Assert.Null(parameters.WebhookConfigurations);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_configurations"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Parsing::ParsingCreateParams
        {
            Tier = Parsing::Tier.Fast,
            Version = Parsing::Version.Latest,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AgenticOptions = new() { CustomPrompt = "custom_prompt" },
            ClientName = "client_name",
            ConfigurationID = "configuration_id",
            DisableCache = true,
            FastOptions = JsonSerializer.Deserialize<JsonElement>("{}"),
            FileID = "file_id",
            HttpProxy = "https:",
            SourceUrl = "https:",
            UserMetadata = new Dictionary<string, string>()
            {
                { "owner", "jerry" },
                { "team", "research" },
            },
            WebhookConfigurationIds = ["whc-...", "whc-..."],

            // Null should be interpreted as omitted for these properties
            CropBox = null,
            InputOptions = null,
            OutputOptions = null,
            PageRanges = null,
            ProcessingControl = null,
            ProcessingOptions = null,
            WebhookConfigurations = null,
        };

        Assert.Null(parameters.CropBox);
        Assert.False(parameters.RawBodyData.ContainsKey("crop_box"));
        Assert.Null(parameters.InputOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("input_options"));
        Assert.Null(parameters.OutputOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("output_options"));
        Assert.Null(parameters.PageRanges);
        Assert.False(parameters.RawBodyData.ContainsKey("page_ranges"));
        Assert.Null(parameters.ProcessingControl);
        Assert.False(parameters.RawBodyData.ContainsKey("processing_control"));
        Assert.Null(parameters.ProcessingOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("processing_options"));
        Assert.Null(parameters.WebhookConfigurations);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_configurations"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Parsing::ParsingCreateParams
        {
            Tier = Parsing::Tier.Fast,
            Version = Parsing::Version.Latest,
            CropBox = new()
            {
                Bottom = 0,
                Left = 0,
                Right = 0,
                Top = 0,
            },
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
                    Parsing::GranularBbox.Word,
                    Parsing::GranularBbox.Line,
                    Parsing::GranularBbox.Cell,
                ],
                ImagesToSave = [Parsing::ImagesToSave.Embedded],
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
                            SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                            Tier = Parsing::ParsingConfTier.Agentic,
                            Version = Parsing::ParsingConfVersion.Latest,
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
                ConfidenceScoreEffort = Parsing::ConfidenceScoreEffort.High,
                CostOptimizer = new() { Enable = true },
                DisableHeuristics = true,
                Forms = Parsing::Forms.Enrich,
                Ignore = new()
                {
                    IgnoreDiagonalText = true,
                    IgnoreHiddenText = true,
                    IgnoreTextInImage = true,
                },
                OcrParameters = new() { Languages = [Parsing::ParsingLanguages.Abq] },
                SpecializedChartParsing = Parsing::ProcessingOptionsSpecializedChartParsing.Agentic,
            },
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = ["parse.success", "parse.error"],
                    WebhookHeaders = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    WebhookOutputFormat = Parsing::WebhookOutputFormat.Json,
                    WebhookSigningSecret = "webhook_signing_secret",
                    WebhookUrl = "https:",
                },
            ],
        };

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.AgenticOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("agentic_options"));
        Assert.Null(parameters.ClientName);
        Assert.False(parameters.RawBodyData.ContainsKey("client_name"));
        Assert.Null(parameters.ConfigurationID);
        Assert.False(parameters.RawBodyData.ContainsKey("configuration_id"));
        Assert.Null(parameters.DisableCache);
        Assert.False(parameters.RawBodyData.ContainsKey("disable_cache"));
        Assert.Null(parameters.FastOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("fast_options"));
        Assert.Null(parameters.FileID);
        Assert.False(parameters.RawBodyData.ContainsKey("file_id"));
        Assert.Null(parameters.HttpProxy);
        Assert.False(parameters.RawBodyData.ContainsKey("http_proxy"));
        Assert.Null(parameters.SourceUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("source_url"));
        Assert.Null(parameters.UserMetadata);
        Assert.False(parameters.RawBodyData.ContainsKey("user_metadata"));
        Assert.Null(parameters.WebhookConfigurationIds);
        Assert.False(parameters.RawBodyData.ContainsKey("webhook_configuration_ids"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Parsing::ParsingCreateParams
        {
            Tier = Parsing::Tier.Fast,
            Version = Parsing::Version.Latest,
            CropBox = new()
            {
                Bottom = 0,
                Left = 0,
                Right = 0,
                Top = 0,
            },
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
                    Parsing::GranularBbox.Word,
                    Parsing::GranularBbox.Line,
                    Parsing::GranularBbox.Cell,
                ],
                ImagesToSave = [Parsing::ImagesToSave.Embedded],
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
                            SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                            Tier = Parsing::ParsingConfTier.Agentic,
                            Version = Parsing::ParsingConfVersion.Latest,
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
                ConfidenceScoreEffort = Parsing::ConfidenceScoreEffort.High,
                CostOptimizer = new() { Enable = true },
                DisableHeuristics = true,
                Forms = Parsing::Forms.Enrich,
                Ignore = new()
                {
                    IgnoreDiagonalText = true,
                    IgnoreHiddenText = true,
                    IgnoreTextInImage = true,
                },
                OcrParameters = new() { Languages = [Parsing::ParsingLanguages.Abq] },
                SpecializedChartParsing = Parsing::ProcessingOptionsSpecializedChartParsing.Agentic,
            },
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = ["parse.success", "parse.error"],
                    WebhookHeaders = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    WebhookOutputFormat = Parsing::WebhookOutputFormat.Json,
                    WebhookSigningSecret = "webhook_signing_secret",
                    WebhookUrl = "https:",
                },
            ],

            OrganizationID = null,
            ProjectID = null,
            AgenticOptions = null,
            ClientName = null,
            ConfigurationID = null,
            DisableCache = null,
            FastOptions = null,
            FileID = null,
            HttpProxy = null,
            SourceUrl = null,
            UserMetadata = null,
            WebhookConfigurationIds = null,
        };

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.AgenticOptions);
        Assert.True(parameters.RawBodyData.ContainsKey("agentic_options"));
        Assert.Null(parameters.ClientName);
        Assert.True(parameters.RawBodyData.ContainsKey("client_name"));
        Assert.Null(parameters.ConfigurationID);
        Assert.True(parameters.RawBodyData.ContainsKey("configuration_id"));
        Assert.Null(parameters.DisableCache);
        Assert.True(parameters.RawBodyData.ContainsKey("disable_cache"));
        Assert.Null(parameters.FastOptions);
        Assert.True(parameters.RawBodyData.ContainsKey("fast_options"));
        Assert.Null(parameters.FileID);
        Assert.True(parameters.RawBodyData.ContainsKey("file_id"));
        Assert.Null(parameters.HttpProxy);
        Assert.True(parameters.RawBodyData.ContainsKey("http_proxy"));
        Assert.Null(parameters.SourceUrl);
        Assert.True(parameters.RawBodyData.ContainsKey("source_url"));
        Assert.Null(parameters.UserMetadata);
        Assert.True(parameters.RawBodyData.ContainsKey("user_metadata"));
        Assert.Null(parameters.WebhookConfigurationIds);
        Assert.True(parameters.RawBodyData.ContainsKey("webhook_configuration_ids"));
    }

    [Fact]
    public void Url_Works()
    {
        Parsing::ParsingCreateParams parameters = new()
        {
            Tier = Parsing::Tier.Fast,
            Version = Parsing::Version.Latest,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v2/parse?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Parsing::ParsingCreateParams
        {
            Tier = Parsing::Tier.Fast,
            Version = Parsing::Version.Latest,
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            AgenticOptions = new() { CustomPrompt = "custom_prompt" },
            ClientName = "client_name",
            ConfigurationID = "configuration_id",
            CropBox = new()
            {
                Bottom = 0,
                Left = 0,
                Right = 0,
                Top = 0,
            },
            DisableCache = true,
            FastOptions = JsonSerializer.Deserialize<JsonElement>("{}"),
            FileID = "file_id",
            HttpProxy = "https:",
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
                    Parsing::GranularBbox.Word,
                    Parsing::GranularBbox.Line,
                    Parsing::GranularBbox.Cell,
                ],
                ImagesToSave = [Parsing::ImagesToSave.Embedded],
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
                            SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                            Tier = Parsing::ParsingConfTier.Agentic,
                            Version = Parsing::ParsingConfVersion.Latest,
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
                ConfidenceScoreEffort = Parsing::ConfidenceScoreEffort.High,
                CostOptimizer = new() { Enable = true },
                DisableHeuristics = true,
                Forms = Parsing::Forms.Enrich,
                Ignore = new()
                {
                    IgnoreDiagonalText = true,
                    IgnoreHiddenText = true,
                    IgnoreTextInImage = true,
                },
                OcrParameters = new() { Languages = [Parsing::ParsingLanguages.Abq] },
                SpecializedChartParsing = Parsing::ProcessingOptionsSpecializedChartParsing.Agentic,
            },
            SourceUrl = "https:",
            UserMetadata = new Dictionary<string, string>()
            {
                { "owner", "jerry" },
                { "team", "research" },
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
                    WebhookOutputFormat = Parsing::WebhookOutputFormat.Json,
                    WebhookSigningSecret = "webhook_signing_secret",
                    WebhookUrl = "https:",
                },
            ],
        };

        Parsing::ParsingCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TierTest : TestBase
{
    [Theory]
    [InlineData(Parsing::Tier.Fast)]
    [InlineData(Parsing::Tier.CostEffective)]
    [InlineData(Parsing::Tier.Agentic)]
    [InlineData(Parsing::Tier.AgenticPlus)]
    public void Validation_Works(Parsing::Tier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::Tier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::Tier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Parsing::Tier.Fast)]
    [InlineData(Parsing::Tier.CostEffective)]
    [InlineData(Parsing::Tier.Agentic)]
    [InlineData(Parsing::Tier.AgenticPlus)]
    public void SerializationRoundtrip_Works(Parsing::Tier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::Tier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::Tier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::Tier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::Tier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VersionTest : TestBase
{
    [Theory]
    [InlineData(Parsing::Version.Latest)]
    [InlineData(Parsing::Version.V2026_08_19)]
    [InlineData(Parsing::Version.V2026_06_15)]
    public void Validation_Works(Parsing::Version rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::Version> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::Version>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Parsing::Version.Latest)]
    [InlineData(Parsing::Version.V2026_08_19)]
    [InlineData(Parsing::Version.V2026_06_15)]
    public void SerializationRoundtrip_Works(Parsing::Version rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::Version> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::Version>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::Version>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::Version>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AgenticOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::AgenticOptions { CustomPrompt = "custom_prompt" };

        string expectedCustomPrompt = "custom_prompt";

        Assert.Equal(expectedCustomPrompt, model.CustomPrompt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::AgenticOptions { CustomPrompt = "custom_prompt" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::AgenticOptions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::AgenticOptions { CustomPrompt = "custom_prompt" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::AgenticOptions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCustomPrompt = "custom_prompt";

        Assert.Equal(expectedCustomPrompt, deserialized.CustomPrompt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::AgenticOptions { CustomPrompt = "custom_prompt" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::AgenticOptions { };

        Assert.Null(model.CustomPrompt);
        Assert.False(model.RawData.ContainsKey("custom_prompt"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::AgenticOptions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::AgenticOptions { CustomPrompt = null };

        Assert.Null(model.CustomPrompt);
        Assert.True(model.RawData.ContainsKey("custom_prompt"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::AgenticOptions { CustomPrompt = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::AgenticOptions { CustomPrompt = "custom_prompt" };

        Parsing::AgenticOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CropBoxTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::CropBox
        {
            Bottom = 0,
            Left = 0,
            Right = 0,
            Top = 0,
        };

        double expectedBottom = 0;
        double expectedLeft = 0;
        double expectedRight = 0;
        double expectedTop = 0;

        Assert.Equal(expectedBottom, model.Bottom);
        Assert.Equal(expectedLeft, model.Left);
        Assert.Equal(expectedRight, model.Right);
        Assert.Equal(expectedTop, model.Top);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::CropBox
        {
            Bottom = 0,
            Left = 0,
            Right = 0,
            Top = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::CropBox>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::CropBox
        {
            Bottom = 0,
            Left = 0,
            Right = 0,
            Top = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::CropBox>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBottom = 0;
        double expectedLeft = 0;
        double expectedRight = 0;
        double expectedTop = 0;

        Assert.Equal(expectedBottom, deserialized.Bottom);
        Assert.Equal(expectedLeft, deserialized.Left);
        Assert.Equal(expectedRight, deserialized.Right);
        Assert.Equal(expectedTop, deserialized.Top);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::CropBox
        {
            Bottom = 0,
            Left = 0,
            Right = 0,
            Top = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::CropBox { };

        Assert.Null(model.Bottom);
        Assert.False(model.RawData.ContainsKey("bottom"));
        Assert.Null(model.Left);
        Assert.False(model.RawData.ContainsKey("left"));
        Assert.Null(model.Right);
        Assert.False(model.RawData.ContainsKey("right"));
        Assert.Null(model.Top);
        Assert.False(model.RawData.ContainsKey("top"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::CropBox { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::CropBox
        {
            Bottom = null,
            Left = null,
            Right = null,
            Top = null,
        };

        Assert.Null(model.Bottom);
        Assert.True(model.RawData.ContainsKey("bottom"));
        Assert.Null(model.Left);
        Assert.True(model.RawData.ContainsKey("left"));
        Assert.Null(model.Right);
        Assert.True(model.RawData.ContainsKey("right"));
        Assert.Null(model.Top);
        Assert.True(model.RawData.ContainsKey("top"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::CropBox
        {
            Bottom = null,
            Left = null,
            Right = null,
            Top = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::CropBox
        {
            Bottom = 0,
            Left = 0,
            Right = 0,
            Top = 0,
        };

        Parsing::CropBox copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InputOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::InputOptions
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
        };

        Parsing::Html expectedHtml = new()
        {
            MakeAllElementsVisible = true,
            RemoveFixedElements = true,
            RemoveNavigationElements = true,
        };
        Parsing::Image expectedImage = new() { CameraPhotoCorrection = true };
        JsonElement expectedPdf = JsonSerializer.Deserialize<JsonElement>("{}");
        Parsing::Presentation expectedPresentation = new()
        {
            OutOfBoundsContent = true,
            SkipEmbeddedData = true,
        };
        Parsing::Spreadsheet expectedSpreadsheet = new()
        {
            DetectSubTablesInSheets = true,
            ForceFormulaComputationInSheets = true,
            IncludeHiddenSheets = true,
        };

        Assert.Equal(expectedHtml, model.Html);
        Assert.Equal(expectedImage, model.Image);
        Assert.NotNull(model.Pdf);
        Assert.True(JsonElement.DeepEquals(expectedPdf, model.Pdf.Value));
        Assert.Equal(expectedPresentation, model.Presentation);
        Assert.Equal(expectedSpreadsheet, model.Spreadsheet);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::InputOptions
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::InputOptions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::InputOptions
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::InputOptions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Parsing::Html expectedHtml = new()
        {
            MakeAllElementsVisible = true,
            RemoveFixedElements = true,
            RemoveNavigationElements = true,
        };
        Parsing::Image expectedImage = new() { CameraPhotoCorrection = true };
        JsonElement expectedPdf = JsonSerializer.Deserialize<JsonElement>("{}");
        Parsing::Presentation expectedPresentation = new()
        {
            OutOfBoundsContent = true,
            SkipEmbeddedData = true,
        };
        Parsing::Spreadsheet expectedSpreadsheet = new()
        {
            DetectSubTablesInSheets = true,
            ForceFormulaComputationInSheets = true,
            IncludeHiddenSheets = true,
        };

        Assert.Equal(expectedHtml, deserialized.Html);
        Assert.Equal(expectedImage, deserialized.Image);
        Assert.NotNull(deserialized.Pdf);
        Assert.True(JsonElement.DeepEquals(expectedPdf, deserialized.Pdf.Value));
        Assert.Equal(expectedPresentation, deserialized.Presentation);
        Assert.Equal(expectedSpreadsheet, deserialized.Spreadsheet);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::InputOptions
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::InputOptions { };

        Assert.Null(model.Html);
        Assert.False(model.RawData.ContainsKey("html"));
        Assert.Null(model.Image);
        Assert.False(model.RawData.ContainsKey("image"));
        Assert.Null(model.Pdf);
        Assert.False(model.RawData.ContainsKey("pdf"));
        Assert.Null(model.Presentation);
        Assert.False(model.RawData.ContainsKey("presentation"));
        Assert.Null(model.Spreadsheet);
        Assert.False(model.RawData.ContainsKey("spreadsheet"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::InputOptions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Parsing::InputOptions
        {
            // Null should be interpreted as omitted for these properties
            Html = null,
            Image = null,
            Pdf = null,
            Presentation = null,
            Spreadsheet = null,
        };

        Assert.Null(model.Html);
        Assert.False(model.RawData.ContainsKey("html"));
        Assert.Null(model.Image);
        Assert.False(model.RawData.ContainsKey("image"));
        Assert.Null(model.Pdf);
        Assert.False(model.RawData.ContainsKey("pdf"));
        Assert.Null(model.Presentation);
        Assert.False(model.RawData.ContainsKey("presentation"));
        Assert.Null(model.Spreadsheet);
        Assert.False(model.RawData.ContainsKey("spreadsheet"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::InputOptions
        {
            // Null should be interpreted as omitted for these properties
            Html = null,
            Image = null,
            Pdf = null,
            Presentation = null,
            Spreadsheet = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::InputOptions
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
        };

        Parsing::InputOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class HtmlTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::Html
        {
            MakeAllElementsVisible = true,
            RemoveFixedElements = true,
            RemoveNavigationElements = true,
        };

        bool expectedMakeAllElementsVisible = true;
        bool expectedRemoveFixedElements = true;
        bool expectedRemoveNavigationElements = true;

        Assert.Equal(expectedMakeAllElementsVisible, model.MakeAllElementsVisible);
        Assert.Equal(expectedRemoveFixedElements, model.RemoveFixedElements);
        Assert.Equal(expectedRemoveNavigationElements, model.RemoveNavigationElements);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::Html
        {
            MakeAllElementsVisible = true,
            RemoveFixedElements = true,
            RemoveNavigationElements = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Html>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::Html
        {
            MakeAllElementsVisible = true,
            RemoveFixedElements = true,
            RemoveNavigationElements = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Html>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedMakeAllElementsVisible = true;
        bool expectedRemoveFixedElements = true;
        bool expectedRemoveNavigationElements = true;

        Assert.Equal(expectedMakeAllElementsVisible, deserialized.MakeAllElementsVisible);
        Assert.Equal(expectedRemoveFixedElements, deserialized.RemoveFixedElements);
        Assert.Equal(expectedRemoveNavigationElements, deserialized.RemoveNavigationElements);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::Html
        {
            MakeAllElementsVisible = true,
            RemoveFixedElements = true,
            RemoveNavigationElements = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::Html { };

        Assert.Null(model.MakeAllElementsVisible);
        Assert.False(model.RawData.ContainsKey("make_all_elements_visible"));
        Assert.Null(model.RemoveFixedElements);
        Assert.False(model.RawData.ContainsKey("remove_fixed_elements"));
        Assert.Null(model.RemoveNavigationElements);
        Assert.False(model.RawData.ContainsKey("remove_navigation_elements"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::Html { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::Html
        {
            MakeAllElementsVisible = null,
            RemoveFixedElements = null,
            RemoveNavigationElements = null,
        };

        Assert.Null(model.MakeAllElementsVisible);
        Assert.True(model.RawData.ContainsKey("make_all_elements_visible"));
        Assert.Null(model.RemoveFixedElements);
        Assert.True(model.RawData.ContainsKey("remove_fixed_elements"));
        Assert.Null(model.RemoveNavigationElements);
        Assert.True(model.RawData.ContainsKey("remove_navigation_elements"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::Html
        {
            MakeAllElementsVisible = null,
            RemoveFixedElements = null,
            RemoveNavigationElements = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::Html
        {
            MakeAllElementsVisible = true,
            RemoveFixedElements = true,
            RemoveNavigationElements = true,
        };

        Parsing::Html copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::Image { CameraPhotoCorrection = true };

        bool expectedCameraPhotoCorrection = true;

        Assert.Equal(expectedCameraPhotoCorrection, model.CameraPhotoCorrection);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::Image { CameraPhotoCorrection = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Image>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::Image { CameraPhotoCorrection = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Image>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCameraPhotoCorrection = true;

        Assert.Equal(expectedCameraPhotoCorrection, deserialized.CameraPhotoCorrection);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::Image { CameraPhotoCorrection = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::Image { };

        Assert.Null(model.CameraPhotoCorrection);
        Assert.False(model.RawData.ContainsKey("camera_photo_correction"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::Image { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::Image { CameraPhotoCorrection = null };

        Assert.Null(model.CameraPhotoCorrection);
        Assert.True(model.RawData.ContainsKey("camera_photo_correction"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::Image { CameraPhotoCorrection = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::Image { CameraPhotoCorrection = true };

        Parsing::Image copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PresentationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::Presentation
        {
            OutOfBoundsContent = true,
            SkipEmbeddedData = true,
        };

        bool expectedOutOfBoundsContent = true;
        bool expectedSkipEmbeddedData = true;

        Assert.Equal(expectedOutOfBoundsContent, model.OutOfBoundsContent);
        Assert.Equal(expectedSkipEmbeddedData, model.SkipEmbeddedData);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::Presentation
        {
            OutOfBoundsContent = true,
            SkipEmbeddedData = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Presentation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::Presentation
        {
            OutOfBoundsContent = true,
            SkipEmbeddedData = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Presentation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedOutOfBoundsContent = true;
        bool expectedSkipEmbeddedData = true;

        Assert.Equal(expectedOutOfBoundsContent, deserialized.OutOfBoundsContent);
        Assert.Equal(expectedSkipEmbeddedData, deserialized.SkipEmbeddedData);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::Presentation
        {
            OutOfBoundsContent = true,
            SkipEmbeddedData = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::Presentation { };

        Assert.Null(model.OutOfBoundsContent);
        Assert.False(model.RawData.ContainsKey("out_of_bounds_content"));
        Assert.Null(model.SkipEmbeddedData);
        Assert.False(model.RawData.ContainsKey("skip_embedded_data"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::Presentation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::Presentation
        {
            OutOfBoundsContent = null,
            SkipEmbeddedData = null,
        };

        Assert.Null(model.OutOfBoundsContent);
        Assert.True(model.RawData.ContainsKey("out_of_bounds_content"));
        Assert.Null(model.SkipEmbeddedData);
        Assert.True(model.RawData.ContainsKey("skip_embedded_data"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::Presentation
        {
            OutOfBoundsContent = null,
            SkipEmbeddedData = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::Presentation
        {
            OutOfBoundsContent = true,
            SkipEmbeddedData = true,
        };

        Parsing::Presentation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SpreadsheetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::Spreadsheet
        {
            DetectSubTablesInSheets = true,
            ForceFormulaComputationInSheets = true,
            IncludeHiddenSheets = true,
        };

        bool expectedDetectSubTablesInSheets = true;
        bool expectedForceFormulaComputationInSheets = true;
        bool expectedIncludeHiddenSheets = true;

        Assert.Equal(expectedDetectSubTablesInSheets, model.DetectSubTablesInSheets);
        Assert.Equal(
            expectedForceFormulaComputationInSheets,
            model.ForceFormulaComputationInSheets
        );
        Assert.Equal(expectedIncludeHiddenSheets, model.IncludeHiddenSheets);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::Spreadsheet
        {
            DetectSubTablesInSheets = true,
            ForceFormulaComputationInSheets = true,
            IncludeHiddenSheets = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Spreadsheet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::Spreadsheet
        {
            DetectSubTablesInSheets = true,
            ForceFormulaComputationInSheets = true,
            IncludeHiddenSheets = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Spreadsheet>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedDetectSubTablesInSheets = true;
        bool expectedForceFormulaComputationInSheets = true;
        bool expectedIncludeHiddenSheets = true;

        Assert.Equal(expectedDetectSubTablesInSheets, deserialized.DetectSubTablesInSheets);
        Assert.Equal(
            expectedForceFormulaComputationInSheets,
            deserialized.ForceFormulaComputationInSheets
        );
        Assert.Equal(expectedIncludeHiddenSheets, deserialized.IncludeHiddenSheets);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::Spreadsheet
        {
            DetectSubTablesInSheets = true,
            ForceFormulaComputationInSheets = true,
            IncludeHiddenSheets = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::Spreadsheet { };

        Assert.Null(model.DetectSubTablesInSheets);
        Assert.False(model.RawData.ContainsKey("detect_sub_tables_in_sheets"));
        Assert.Null(model.ForceFormulaComputationInSheets);
        Assert.False(model.RawData.ContainsKey("force_formula_computation_in_sheets"));
        Assert.Null(model.IncludeHiddenSheets);
        Assert.False(model.RawData.ContainsKey("include_hidden_sheets"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::Spreadsheet { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::Spreadsheet
        {
            DetectSubTablesInSheets = null,
            ForceFormulaComputationInSheets = null,
            IncludeHiddenSheets = null,
        };

        Assert.Null(model.DetectSubTablesInSheets);
        Assert.True(model.RawData.ContainsKey("detect_sub_tables_in_sheets"));
        Assert.Null(model.ForceFormulaComputationInSheets);
        Assert.True(model.RawData.ContainsKey("force_formula_computation_in_sheets"));
        Assert.Null(model.IncludeHiddenSheets);
        Assert.True(model.RawData.ContainsKey("include_hidden_sheets"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::Spreadsheet
        {
            DetectSubTablesInSheets = null,
            ForceFormulaComputationInSheets = null,
            IncludeHiddenSheets = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::Spreadsheet
        {
            DetectSubTablesInSheets = true,
            ForceFormulaComputationInSheets = true,
            IncludeHiddenSheets = true,
        };

        Parsing::Spreadsheet copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OutputOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::OutputOptions
        {
            AdditionalOutputs = ["stripped_md", "concatenated_stripped_txt", "word_bbox"],
            ExtractPrintedPageNumber = true,
            GranularBboxes =
            [
                Parsing::GranularBbox.Word,
                Parsing::GranularBbox.Line,
                Parsing::GranularBbox.Cell,
            ],
            ImagesToSave = [Parsing::ImagesToSave.Embedded],
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
        };

        List<string> expectedAdditionalOutputs =
        [
            "stripped_md",
            "concatenated_stripped_txt",
            "word_bbox",
        ];
        bool expectedExtractPrintedPageNumber = true;
        List<ApiEnum<string, Parsing::GranularBbox>> expectedGranularBboxes =
        [
            Parsing::GranularBbox.Word,
            Parsing::GranularBbox.Line,
            Parsing::GranularBbox.Cell,
        ];
        List<ApiEnum<string, Parsing::ImagesToSave>> expectedImagesToSave =
        [
            Parsing::ImagesToSave.Embedded,
        ];
        Parsing::Markdown expectedMarkdown = new()
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
        };
        bool expectedSaveOutputPdf = true;
        Parsing::SpatialText expectedSpatialText = new()
        {
            DoNotUnrollColumns = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
        };
        Parsing::TablesAsSpreadsheet expectedTablesAsSpreadsheet = new()
        {
            Enable = true,
            GuessSheetName = true,
        };

        Assert.NotNull(model.AdditionalOutputs);
        Assert.Equal(expectedAdditionalOutputs.Count, model.AdditionalOutputs.Count);
        for (int i = 0; i < expectedAdditionalOutputs.Count; i++)
        {
            Assert.Equal(expectedAdditionalOutputs[i], model.AdditionalOutputs[i]);
        }
        Assert.Equal(expectedExtractPrintedPageNumber, model.ExtractPrintedPageNumber);
        Assert.NotNull(model.GranularBboxes);
        Assert.Equal(expectedGranularBboxes.Count, model.GranularBboxes.Count);
        for (int i = 0; i < expectedGranularBboxes.Count; i++)
        {
            Assert.Equal(expectedGranularBboxes[i], model.GranularBboxes[i]);
        }
        Assert.NotNull(model.ImagesToSave);
        Assert.Equal(expectedImagesToSave.Count, model.ImagesToSave.Count);
        for (int i = 0; i < expectedImagesToSave.Count; i++)
        {
            Assert.Equal(expectedImagesToSave[i], model.ImagesToSave[i]);
        }
        Assert.Equal(expectedMarkdown, model.Markdown);
        Assert.Equal(expectedSaveOutputPdf, model.SaveOutputPdf);
        Assert.Equal(expectedSpatialText, model.SpatialText);
        Assert.Equal(expectedTablesAsSpreadsheet, model.TablesAsSpreadsheet);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::OutputOptions
        {
            AdditionalOutputs = ["stripped_md", "concatenated_stripped_txt", "word_bbox"],
            ExtractPrintedPageNumber = true,
            GranularBboxes =
            [
                Parsing::GranularBbox.Word,
                Parsing::GranularBbox.Line,
                Parsing::GranularBbox.Cell,
            ],
            ImagesToSave = [Parsing::ImagesToSave.Embedded],
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::OutputOptions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::OutputOptions
        {
            AdditionalOutputs = ["stripped_md", "concatenated_stripped_txt", "word_bbox"],
            ExtractPrintedPageNumber = true,
            GranularBboxes =
            [
                Parsing::GranularBbox.Word,
                Parsing::GranularBbox.Line,
                Parsing::GranularBbox.Cell,
            ],
            ImagesToSave = [Parsing::ImagesToSave.Embedded],
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::OutputOptions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedAdditionalOutputs =
        [
            "stripped_md",
            "concatenated_stripped_txt",
            "word_bbox",
        ];
        bool expectedExtractPrintedPageNumber = true;
        List<ApiEnum<string, Parsing::GranularBbox>> expectedGranularBboxes =
        [
            Parsing::GranularBbox.Word,
            Parsing::GranularBbox.Line,
            Parsing::GranularBbox.Cell,
        ];
        List<ApiEnum<string, Parsing::ImagesToSave>> expectedImagesToSave =
        [
            Parsing::ImagesToSave.Embedded,
        ];
        Parsing::Markdown expectedMarkdown = new()
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
        };
        bool expectedSaveOutputPdf = true;
        Parsing::SpatialText expectedSpatialText = new()
        {
            DoNotUnrollColumns = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
        };
        Parsing::TablesAsSpreadsheet expectedTablesAsSpreadsheet = new()
        {
            Enable = true,
            GuessSheetName = true,
        };

        Assert.NotNull(deserialized.AdditionalOutputs);
        Assert.Equal(expectedAdditionalOutputs.Count, deserialized.AdditionalOutputs.Count);
        for (int i = 0; i < expectedAdditionalOutputs.Count; i++)
        {
            Assert.Equal(expectedAdditionalOutputs[i], deserialized.AdditionalOutputs[i]);
        }
        Assert.Equal(expectedExtractPrintedPageNumber, deserialized.ExtractPrintedPageNumber);
        Assert.NotNull(deserialized.GranularBboxes);
        Assert.Equal(expectedGranularBboxes.Count, deserialized.GranularBboxes.Count);
        for (int i = 0; i < expectedGranularBboxes.Count; i++)
        {
            Assert.Equal(expectedGranularBboxes[i], deserialized.GranularBboxes[i]);
        }
        Assert.NotNull(deserialized.ImagesToSave);
        Assert.Equal(expectedImagesToSave.Count, deserialized.ImagesToSave.Count);
        for (int i = 0; i < expectedImagesToSave.Count; i++)
        {
            Assert.Equal(expectedImagesToSave[i], deserialized.ImagesToSave[i]);
        }
        Assert.Equal(expectedMarkdown, deserialized.Markdown);
        Assert.Equal(expectedSaveOutputPdf, deserialized.SaveOutputPdf);
        Assert.Equal(expectedSpatialText, deserialized.SpatialText);
        Assert.Equal(expectedTablesAsSpreadsheet, deserialized.TablesAsSpreadsheet);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::OutputOptions
        {
            AdditionalOutputs = ["stripped_md", "concatenated_stripped_txt", "word_bbox"],
            ExtractPrintedPageNumber = true,
            GranularBboxes =
            [
                Parsing::GranularBbox.Word,
                Parsing::GranularBbox.Line,
                Parsing::GranularBbox.Cell,
            ],
            ImagesToSave = [Parsing::ImagesToSave.Embedded],
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::OutputOptions
        {
            ExtractPrintedPageNumber = true,
            ImagesToSave = [Parsing::ImagesToSave.Embedded],
            SaveOutputPdf = true,
        };

        Assert.Null(model.AdditionalOutputs);
        Assert.False(model.RawData.ContainsKey("additional_outputs"));
        Assert.Null(model.GranularBboxes);
        Assert.False(model.RawData.ContainsKey("granular_bboxes"));
        Assert.Null(model.Markdown);
        Assert.False(model.RawData.ContainsKey("markdown"));
        Assert.Null(model.SpatialText);
        Assert.False(model.RawData.ContainsKey("spatial_text"));
        Assert.Null(model.TablesAsSpreadsheet);
        Assert.False(model.RawData.ContainsKey("tables_as_spreadsheet"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::OutputOptions
        {
            ExtractPrintedPageNumber = true,
            ImagesToSave = [Parsing::ImagesToSave.Embedded],
            SaveOutputPdf = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Parsing::OutputOptions
        {
            ExtractPrintedPageNumber = true,
            ImagesToSave = [Parsing::ImagesToSave.Embedded],
            SaveOutputPdf = true,

            // Null should be interpreted as omitted for these properties
            AdditionalOutputs = null,
            GranularBboxes = null,
            Markdown = null,
            SpatialText = null,
            TablesAsSpreadsheet = null,
        };

        Assert.Null(model.AdditionalOutputs);
        Assert.False(model.RawData.ContainsKey("additional_outputs"));
        Assert.Null(model.GranularBboxes);
        Assert.False(model.RawData.ContainsKey("granular_bboxes"));
        Assert.Null(model.Markdown);
        Assert.False(model.RawData.ContainsKey("markdown"));
        Assert.Null(model.SpatialText);
        Assert.False(model.RawData.ContainsKey("spatial_text"));
        Assert.Null(model.TablesAsSpreadsheet);
        Assert.False(model.RawData.ContainsKey("tables_as_spreadsheet"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::OutputOptions
        {
            ExtractPrintedPageNumber = true,
            ImagesToSave = [Parsing::ImagesToSave.Embedded],
            SaveOutputPdf = true,

            // Null should be interpreted as omitted for these properties
            AdditionalOutputs = null,
            GranularBboxes = null,
            Markdown = null,
            SpatialText = null,
            TablesAsSpreadsheet = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::OutputOptions
        {
            AdditionalOutputs = ["stripped_md", "concatenated_stripped_txt", "word_bbox"],
            GranularBboxes =
            [
                Parsing::GranularBbox.Word,
                Parsing::GranularBbox.Line,
                Parsing::GranularBbox.Cell,
            ],
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
            SpatialText = new()
            {
                DoNotUnrollColumns = true,
                PreserveLayoutAlignmentAcrossPages = true,
                PreserveVerySmallText = true,
            },
            TablesAsSpreadsheet = new() { Enable = true, GuessSheetName = true },
        };

        Assert.Null(model.ExtractPrintedPageNumber);
        Assert.False(model.RawData.ContainsKey("extract_printed_page_number"));
        Assert.Null(model.ImagesToSave);
        Assert.False(model.RawData.ContainsKey("images_to_save"));
        Assert.Null(model.SaveOutputPdf);
        Assert.False(model.RawData.ContainsKey("save_output_pdf"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::OutputOptions
        {
            AdditionalOutputs = ["stripped_md", "concatenated_stripped_txt", "word_bbox"],
            GranularBboxes =
            [
                Parsing::GranularBbox.Word,
                Parsing::GranularBbox.Line,
                Parsing::GranularBbox.Cell,
            ],
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
            SpatialText = new()
            {
                DoNotUnrollColumns = true,
                PreserveLayoutAlignmentAcrossPages = true,
                PreserveVerySmallText = true,
            },
            TablesAsSpreadsheet = new() { Enable = true, GuessSheetName = true },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::OutputOptions
        {
            AdditionalOutputs = ["stripped_md", "concatenated_stripped_txt", "word_bbox"],
            GranularBboxes =
            [
                Parsing::GranularBbox.Word,
                Parsing::GranularBbox.Line,
                Parsing::GranularBbox.Cell,
            ],
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
            SpatialText = new()
            {
                DoNotUnrollColumns = true,
                PreserveLayoutAlignmentAcrossPages = true,
                PreserveVerySmallText = true,
            },
            TablesAsSpreadsheet = new() { Enable = true, GuessSheetName = true },

            ExtractPrintedPageNumber = null,
            ImagesToSave = null,
            SaveOutputPdf = null,
        };

        Assert.Null(model.ExtractPrintedPageNumber);
        Assert.True(model.RawData.ContainsKey("extract_printed_page_number"));
        Assert.Null(model.ImagesToSave);
        Assert.True(model.RawData.ContainsKey("images_to_save"));
        Assert.Null(model.SaveOutputPdf);
        Assert.True(model.RawData.ContainsKey("save_output_pdf"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::OutputOptions
        {
            AdditionalOutputs = ["stripped_md", "concatenated_stripped_txt", "word_bbox"],
            GranularBboxes =
            [
                Parsing::GranularBbox.Word,
                Parsing::GranularBbox.Line,
                Parsing::GranularBbox.Cell,
            ],
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
            SpatialText = new()
            {
                DoNotUnrollColumns = true,
                PreserveLayoutAlignmentAcrossPages = true,
                PreserveVerySmallText = true,
            },
            TablesAsSpreadsheet = new() { Enable = true, GuessSheetName = true },

            ExtractPrintedPageNumber = null,
            ImagesToSave = null,
            SaveOutputPdf = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::OutputOptions
        {
            AdditionalOutputs = ["stripped_md", "concatenated_stripped_txt", "word_bbox"],
            ExtractPrintedPageNumber = true,
            GranularBboxes =
            [
                Parsing::GranularBbox.Word,
                Parsing::GranularBbox.Line,
                Parsing::GranularBbox.Cell,
            ],
            ImagesToSave = [Parsing::ImagesToSave.Embedded],
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
        };

        Parsing::OutputOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GranularBboxTest : TestBase
{
    [Theory]
    [InlineData(Parsing::GranularBbox.Cell)]
    [InlineData(Parsing::GranularBbox.Line)]
    [InlineData(Parsing::GranularBbox.Word)]
    public void Validation_Works(Parsing::GranularBbox rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::GranularBbox> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::GranularBbox>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Parsing::GranularBbox.Cell)]
    [InlineData(Parsing::GranularBbox.Line)]
    [InlineData(Parsing::GranularBbox.Word)]
    public void SerializationRoundtrip_Works(Parsing::GranularBbox rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::GranularBbox> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::GranularBbox>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::GranularBbox>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::GranularBbox>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ImagesToSaveTest : TestBase
{
    [Theory]
    [InlineData(Parsing::ImagesToSave.Embedded)]
    [InlineData(Parsing::ImagesToSave.Layout)]
    [InlineData(Parsing::ImagesToSave.Screenshot)]
    public void Validation_Works(Parsing::ImagesToSave rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::ImagesToSave> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::ImagesToSave>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Parsing::ImagesToSave.Embedded)]
    [InlineData(Parsing::ImagesToSave.Layout)]
    [InlineData(Parsing::ImagesToSave.Screenshot)]
    public void SerializationRoundtrip_Works(Parsing::ImagesToSave rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::ImagesToSave> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::ImagesToSave>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::ImagesToSave>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::ImagesToSave>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MarkdownTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::Markdown
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
        };

        bool expectedAnnotateLineNumbers = true;
        bool expectedAnnotateLinks = true;
        bool expectedAnnotateRevisions = true;
        bool expectedInlineImages = true;
        Parsing::Tables expectedTables = new()
        {
            CompactMarkdownTables = true,
            MarkdownTableMultilineSeparator = "markdown_table_multiline_separator",
            MergeContinuedTables = true,
            OutputTablesAsMarkdown = true,
        };

        Assert.Equal(expectedAnnotateLineNumbers, model.AnnotateLineNumbers);
        Assert.Equal(expectedAnnotateLinks, model.AnnotateLinks);
        Assert.Equal(expectedAnnotateRevisions, model.AnnotateRevisions);
        Assert.Equal(expectedInlineImages, model.InlineImages);
        Assert.Equal(expectedTables, model.Tables);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::Markdown
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Markdown>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::Markdown
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Markdown>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAnnotateLineNumbers = true;
        bool expectedAnnotateLinks = true;
        bool expectedAnnotateRevisions = true;
        bool expectedInlineImages = true;
        Parsing::Tables expectedTables = new()
        {
            CompactMarkdownTables = true,
            MarkdownTableMultilineSeparator = "markdown_table_multiline_separator",
            MergeContinuedTables = true,
            OutputTablesAsMarkdown = true,
        };

        Assert.Equal(expectedAnnotateLineNumbers, deserialized.AnnotateLineNumbers);
        Assert.Equal(expectedAnnotateLinks, deserialized.AnnotateLinks);
        Assert.Equal(expectedAnnotateRevisions, deserialized.AnnotateRevisions);
        Assert.Equal(expectedInlineImages, deserialized.InlineImages);
        Assert.Equal(expectedTables, deserialized.Tables);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::Markdown
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::Markdown
        {
            AnnotateLineNumbers = true,
            AnnotateLinks = true,
            AnnotateRevisions = true,
            InlineImages = true,
        };

        Assert.Null(model.Tables);
        Assert.False(model.RawData.ContainsKey("tables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::Markdown
        {
            AnnotateLineNumbers = true,
            AnnotateLinks = true,
            AnnotateRevisions = true,
            InlineImages = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Parsing::Markdown
        {
            AnnotateLineNumbers = true,
            AnnotateLinks = true,
            AnnotateRevisions = true,
            InlineImages = true,

            // Null should be interpreted as omitted for these properties
            Tables = null,
        };

        Assert.Null(model.Tables);
        Assert.False(model.RawData.ContainsKey("tables"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::Markdown
        {
            AnnotateLineNumbers = true,
            AnnotateLinks = true,
            AnnotateRevisions = true,
            InlineImages = true,

            // Null should be interpreted as omitted for these properties
            Tables = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::Markdown
        {
            Tables = new()
            {
                CompactMarkdownTables = true,
                MarkdownTableMultilineSeparator = "markdown_table_multiline_separator",
                MergeContinuedTables = true,
                OutputTablesAsMarkdown = true,
            },
        };

        Assert.Null(model.AnnotateLineNumbers);
        Assert.False(model.RawData.ContainsKey("annotate_line_numbers"));
        Assert.Null(model.AnnotateLinks);
        Assert.False(model.RawData.ContainsKey("annotate_links"));
        Assert.Null(model.AnnotateRevisions);
        Assert.False(model.RawData.ContainsKey("annotate_revisions"));
        Assert.Null(model.InlineImages);
        Assert.False(model.RawData.ContainsKey("inline_images"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::Markdown
        {
            Tables = new()
            {
                CompactMarkdownTables = true,
                MarkdownTableMultilineSeparator = "markdown_table_multiline_separator",
                MergeContinuedTables = true,
                OutputTablesAsMarkdown = true,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::Markdown
        {
            Tables = new()
            {
                CompactMarkdownTables = true,
                MarkdownTableMultilineSeparator = "markdown_table_multiline_separator",
                MergeContinuedTables = true,
                OutputTablesAsMarkdown = true,
            },

            AnnotateLineNumbers = null,
            AnnotateLinks = null,
            AnnotateRevisions = null,
            InlineImages = null,
        };

        Assert.Null(model.AnnotateLineNumbers);
        Assert.True(model.RawData.ContainsKey("annotate_line_numbers"));
        Assert.Null(model.AnnotateLinks);
        Assert.True(model.RawData.ContainsKey("annotate_links"));
        Assert.Null(model.AnnotateRevisions);
        Assert.True(model.RawData.ContainsKey("annotate_revisions"));
        Assert.Null(model.InlineImages);
        Assert.True(model.RawData.ContainsKey("inline_images"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::Markdown
        {
            Tables = new()
            {
                CompactMarkdownTables = true,
                MarkdownTableMultilineSeparator = "markdown_table_multiline_separator",
                MergeContinuedTables = true,
                OutputTablesAsMarkdown = true,
            },

            AnnotateLineNumbers = null,
            AnnotateLinks = null,
            AnnotateRevisions = null,
            InlineImages = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::Markdown
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
        };

        Parsing::Markdown copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TablesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::Tables
        {
            CompactMarkdownTables = true,
            MarkdownTableMultilineSeparator = "markdown_table_multiline_separator",
            MergeContinuedTables = true,
            OutputTablesAsMarkdown = true,
        };

        bool expectedCompactMarkdownTables = true;
        string expectedMarkdownTableMultilineSeparator = "markdown_table_multiline_separator";
        bool expectedMergeContinuedTables = true;
        bool expectedOutputTablesAsMarkdown = true;

        Assert.Equal(expectedCompactMarkdownTables, model.CompactMarkdownTables);
        Assert.Equal(
            expectedMarkdownTableMultilineSeparator,
            model.MarkdownTableMultilineSeparator
        );
        Assert.Equal(expectedMergeContinuedTables, model.MergeContinuedTables);
        Assert.Equal(expectedOutputTablesAsMarkdown, model.OutputTablesAsMarkdown);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::Tables
        {
            CompactMarkdownTables = true,
            MarkdownTableMultilineSeparator = "markdown_table_multiline_separator",
            MergeContinuedTables = true,
            OutputTablesAsMarkdown = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Tables>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::Tables
        {
            CompactMarkdownTables = true,
            MarkdownTableMultilineSeparator = "markdown_table_multiline_separator",
            MergeContinuedTables = true,
            OutputTablesAsMarkdown = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Tables>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedCompactMarkdownTables = true;
        string expectedMarkdownTableMultilineSeparator = "markdown_table_multiline_separator";
        bool expectedMergeContinuedTables = true;
        bool expectedOutputTablesAsMarkdown = true;

        Assert.Equal(expectedCompactMarkdownTables, deserialized.CompactMarkdownTables);
        Assert.Equal(
            expectedMarkdownTableMultilineSeparator,
            deserialized.MarkdownTableMultilineSeparator
        );
        Assert.Equal(expectedMergeContinuedTables, deserialized.MergeContinuedTables);
        Assert.Equal(expectedOutputTablesAsMarkdown, deserialized.OutputTablesAsMarkdown);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::Tables
        {
            CompactMarkdownTables = true,
            MarkdownTableMultilineSeparator = "markdown_table_multiline_separator",
            MergeContinuedTables = true,
            OutputTablesAsMarkdown = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::Tables { };

        Assert.Null(model.CompactMarkdownTables);
        Assert.False(model.RawData.ContainsKey("compact_markdown_tables"));
        Assert.Null(model.MarkdownTableMultilineSeparator);
        Assert.False(model.RawData.ContainsKey("markdown_table_multiline_separator"));
        Assert.Null(model.MergeContinuedTables);
        Assert.False(model.RawData.ContainsKey("merge_continued_tables"));
        Assert.Null(model.OutputTablesAsMarkdown);
        Assert.False(model.RawData.ContainsKey("output_tables_as_markdown"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::Tables { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::Tables
        {
            CompactMarkdownTables = null,
            MarkdownTableMultilineSeparator = null,
            MergeContinuedTables = null,
            OutputTablesAsMarkdown = null,
        };

        Assert.Null(model.CompactMarkdownTables);
        Assert.True(model.RawData.ContainsKey("compact_markdown_tables"));
        Assert.Null(model.MarkdownTableMultilineSeparator);
        Assert.True(model.RawData.ContainsKey("markdown_table_multiline_separator"));
        Assert.Null(model.MergeContinuedTables);
        Assert.True(model.RawData.ContainsKey("merge_continued_tables"));
        Assert.Null(model.OutputTablesAsMarkdown);
        Assert.True(model.RawData.ContainsKey("output_tables_as_markdown"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::Tables
        {
            CompactMarkdownTables = null,
            MarkdownTableMultilineSeparator = null,
            MergeContinuedTables = null,
            OutputTablesAsMarkdown = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::Tables
        {
            CompactMarkdownTables = true,
            MarkdownTableMultilineSeparator = "markdown_table_multiline_separator",
            MergeContinuedTables = true,
            OutputTablesAsMarkdown = true,
        };

        Parsing::Tables copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SpatialTextTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::SpatialText
        {
            DoNotUnrollColumns = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
        };

        bool expectedDoNotUnrollColumns = true;
        bool expectedPreserveLayoutAlignmentAcrossPages = true;
        bool expectedPreserveVerySmallText = true;

        Assert.Equal(expectedDoNotUnrollColumns, model.DoNotUnrollColumns);
        Assert.Equal(
            expectedPreserveLayoutAlignmentAcrossPages,
            model.PreserveLayoutAlignmentAcrossPages
        );
        Assert.Equal(expectedPreserveVerySmallText, model.PreserveVerySmallText);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::SpatialText
        {
            DoNotUnrollColumns = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::SpatialText>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::SpatialText
        {
            DoNotUnrollColumns = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::SpatialText>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedDoNotUnrollColumns = true;
        bool expectedPreserveLayoutAlignmentAcrossPages = true;
        bool expectedPreserveVerySmallText = true;

        Assert.Equal(expectedDoNotUnrollColumns, deserialized.DoNotUnrollColumns);
        Assert.Equal(
            expectedPreserveLayoutAlignmentAcrossPages,
            deserialized.PreserveLayoutAlignmentAcrossPages
        );
        Assert.Equal(expectedPreserveVerySmallText, deserialized.PreserveVerySmallText);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::SpatialText
        {
            DoNotUnrollColumns = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::SpatialText { };

        Assert.Null(model.DoNotUnrollColumns);
        Assert.False(model.RawData.ContainsKey("do_not_unroll_columns"));
        Assert.Null(model.PreserveLayoutAlignmentAcrossPages);
        Assert.False(model.RawData.ContainsKey("preserve_layout_alignment_across_pages"));
        Assert.Null(model.PreserveVerySmallText);
        Assert.False(model.RawData.ContainsKey("preserve_very_small_text"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::SpatialText { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::SpatialText
        {
            DoNotUnrollColumns = null,
            PreserveLayoutAlignmentAcrossPages = null,
            PreserveVerySmallText = null,
        };

        Assert.Null(model.DoNotUnrollColumns);
        Assert.True(model.RawData.ContainsKey("do_not_unroll_columns"));
        Assert.Null(model.PreserveLayoutAlignmentAcrossPages);
        Assert.True(model.RawData.ContainsKey("preserve_layout_alignment_across_pages"));
        Assert.Null(model.PreserveVerySmallText);
        Assert.True(model.RawData.ContainsKey("preserve_very_small_text"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::SpatialText
        {
            DoNotUnrollColumns = null,
            PreserveLayoutAlignmentAcrossPages = null,
            PreserveVerySmallText = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::SpatialText
        {
            DoNotUnrollColumns = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
        };

        Parsing::SpatialText copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TablesAsSpreadsheetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::TablesAsSpreadsheet { Enable = true, GuessSheetName = true };

        bool expectedEnable = true;
        bool expectedGuessSheetName = true;

        Assert.Equal(expectedEnable, model.Enable);
        Assert.Equal(expectedGuessSheetName, model.GuessSheetName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::TablesAsSpreadsheet { Enable = true, GuessSheetName = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::TablesAsSpreadsheet>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::TablesAsSpreadsheet { Enable = true, GuessSheetName = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::TablesAsSpreadsheet>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedEnable = true;
        bool expectedGuessSheetName = true;

        Assert.Equal(expectedEnable, deserialized.Enable);
        Assert.Equal(expectedGuessSheetName, deserialized.GuessSheetName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::TablesAsSpreadsheet { Enable = true, GuessSheetName = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::TablesAsSpreadsheet { Enable = true };

        Assert.Null(model.GuessSheetName);
        Assert.False(model.RawData.ContainsKey("guess_sheet_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::TablesAsSpreadsheet { Enable = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Parsing::TablesAsSpreadsheet
        {
            Enable = true,

            // Null should be interpreted as omitted for these properties
            GuessSheetName = null,
        };

        Assert.Null(model.GuessSheetName);
        Assert.False(model.RawData.ContainsKey("guess_sheet_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::TablesAsSpreadsheet
        {
            Enable = true,

            // Null should be interpreted as omitted for these properties
            GuessSheetName = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::TablesAsSpreadsheet { GuessSheetName = true };

        Assert.Null(model.Enable);
        Assert.False(model.RawData.ContainsKey("enable"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::TablesAsSpreadsheet { GuessSheetName = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::TablesAsSpreadsheet
        {
            GuessSheetName = true,

            Enable = null,
        };

        Assert.Null(model.Enable);
        Assert.True(model.RawData.ContainsKey("enable"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::TablesAsSpreadsheet
        {
            GuessSheetName = true,

            Enable = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::TablesAsSpreadsheet { Enable = true, GuessSheetName = true };

        Parsing::TablesAsSpreadsheet copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PageRangesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::PageRanges { MaxPages = 1, TargetPages = "target_pages" };

        long expectedMaxPages = 1;
        string expectedTargetPages = "target_pages";

        Assert.Equal(expectedMaxPages, model.MaxPages);
        Assert.Equal(expectedTargetPages, model.TargetPages);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::PageRanges { MaxPages = 1, TargetPages = "target_pages" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageRanges>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::PageRanges { MaxPages = 1, TargetPages = "target_pages" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageRanges>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedMaxPages = 1;
        string expectedTargetPages = "target_pages";

        Assert.Equal(expectedMaxPages, deserialized.MaxPages);
        Assert.Equal(expectedTargetPages, deserialized.TargetPages);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::PageRanges { MaxPages = 1, TargetPages = "target_pages" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::PageRanges { };

        Assert.Null(model.MaxPages);
        Assert.False(model.RawData.ContainsKey("max_pages"));
        Assert.Null(model.TargetPages);
        Assert.False(model.RawData.ContainsKey("target_pages"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::PageRanges { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::PageRanges { MaxPages = null, TargetPages = null };

        Assert.Null(model.MaxPages);
        Assert.True(model.RawData.ContainsKey("max_pages"));
        Assert.Null(model.TargetPages);
        Assert.True(model.RawData.ContainsKey("target_pages"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::PageRanges { MaxPages = null, TargetPages = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::PageRanges { MaxPages = 1, TargetPages = "target_pages" };

        Parsing::PageRanges copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProcessingControlTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::ProcessingControl
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
        };

        Parsing::JobFailureConditions expectedJobFailureConditions = new()
        {
            AllowedPageFailureRatio = 1,
            FailOnBuggyFont = true,
            FailOnImageExtractionError = true,
            FailOnImageOcrError = true,
            FailOnMarkdownReconstructionError = true,
        };
        Parsing::Timeouts expectedTimeouts = new()
        {
            BaseInSeconds = 1,
            ExtraTimePerPageInSeconds = 1,
        };

        Assert.Equal(expectedJobFailureConditions, model.JobFailureConditions);
        Assert.Equal(expectedTimeouts, model.Timeouts);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::ProcessingControl
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ProcessingControl>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::ProcessingControl
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ProcessingControl>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Parsing::JobFailureConditions expectedJobFailureConditions = new()
        {
            AllowedPageFailureRatio = 1,
            FailOnBuggyFont = true,
            FailOnImageExtractionError = true,
            FailOnImageOcrError = true,
            FailOnMarkdownReconstructionError = true,
        };
        Parsing::Timeouts expectedTimeouts = new()
        {
            BaseInSeconds = 1,
            ExtraTimePerPageInSeconds = 1,
        };

        Assert.Equal(expectedJobFailureConditions, deserialized.JobFailureConditions);
        Assert.Equal(expectedTimeouts, deserialized.Timeouts);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::ProcessingControl
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::ProcessingControl { };

        Assert.Null(model.JobFailureConditions);
        Assert.False(model.RawData.ContainsKey("job_failure_conditions"));
        Assert.Null(model.Timeouts);
        Assert.False(model.RawData.ContainsKey("timeouts"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::ProcessingControl { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Parsing::ProcessingControl
        {
            // Null should be interpreted as omitted for these properties
            JobFailureConditions = null,
            Timeouts = null,
        };

        Assert.Null(model.JobFailureConditions);
        Assert.False(model.RawData.ContainsKey("job_failure_conditions"));
        Assert.Null(model.Timeouts);
        Assert.False(model.RawData.ContainsKey("timeouts"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::ProcessingControl
        {
            // Null should be interpreted as omitted for these properties
            JobFailureConditions = null,
            Timeouts = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::ProcessingControl
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
        };

        Parsing::ProcessingControl copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JobFailureConditionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::JobFailureConditions
        {
            AllowedPageFailureRatio = 1,
            FailOnBuggyFont = true,
            FailOnImageExtractionError = true,
            FailOnImageOcrError = true,
            FailOnMarkdownReconstructionError = true,
        };

        double expectedAllowedPageFailureRatio = 1;
        bool expectedFailOnBuggyFont = true;
        bool expectedFailOnImageExtractionError = true;
        bool expectedFailOnImageOcrError = true;
        bool expectedFailOnMarkdownReconstructionError = true;

        Assert.Equal(expectedAllowedPageFailureRatio, model.AllowedPageFailureRatio);
        Assert.Equal(expectedFailOnBuggyFont, model.FailOnBuggyFont);
        Assert.Equal(expectedFailOnImageExtractionError, model.FailOnImageExtractionError);
        Assert.Equal(expectedFailOnImageOcrError, model.FailOnImageOcrError);
        Assert.Equal(
            expectedFailOnMarkdownReconstructionError,
            model.FailOnMarkdownReconstructionError
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::JobFailureConditions
        {
            AllowedPageFailureRatio = 1,
            FailOnBuggyFont = true,
            FailOnImageExtractionError = true,
            FailOnImageOcrError = true,
            FailOnMarkdownReconstructionError = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::JobFailureConditions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::JobFailureConditions
        {
            AllowedPageFailureRatio = 1,
            FailOnBuggyFont = true,
            FailOnImageExtractionError = true,
            FailOnImageOcrError = true,
            FailOnMarkdownReconstructionError = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::JobFailureConditions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAllowedPageFailureRatio = 1;
        bool expectedFailOnBuggyFont = true;
        bool expectedFailOnImageExtractionError = true;
        bool expectedFailOnImageOcrError = true;
        bool expectedFailOnMarkdownReconstructionError = true;

        Assert.Equal(expectedAllowedPageFailureRatio, deserialized.AllowedPageFailureRatio);
        Assert.Equal(expectedFailOnBuggyFont, deserialized.FailOnBuggyFont);
        Assert.Equal(expectedFailOnImageExtractionError, deserialized.FailOnImageExtractionError);
        Assert.Equal(expectedFailOnImageOcrError, deserialized.FailOnImageOcrError);
        Assert.Equal(
            expectedFailOnMarkdownReconstructionError,
            deserialized.FailOnMarkdownReconstructionError
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::JobFailureConditions
        {
            AllowedPageFailureRatio = 1,
            FailOnBuggyFont = true,
            FailOnImageExtractionError = true,
            FailOnImageOcrError = true,
            FailOnMarkdownReconstructionError = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::JobFailureConditions { };

        Assert.Null(model.AllowedPageFailureRatio);
        Assert.False(model.RawData.ContainsKey("allowed_page_failure_ratio"));
        Assert.Null(model.FailOnBuggyFont);
        Assert.False(model.RawData.ContainsKey("fail_on_buggy_font"));
        Assert.Null(model.FailOnImageExtractionError);
        Assert.False(model.RawData.ContainsKey("fail_on_image_extraction_error"));
        Assert.Null(model.FailOnImageOcrError);
        Assert.False(model.RawData.ContainsKey("fail_on_image_ocr_error"));
        Assert.Null(model.FailOnMarkdownReconstructionError);
        Assert.False(model.RawData.ContainsKey("fail_on_markdown_reconstruction_error"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::JobFailureConditions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::JobFailureConditions
        {
            AllowedPageFailureRatio = null,
            FailOnBuggyFont = null,
            FailOnImageExtractionError = null,
            FailOnImageOcrError = null,
            FailOnMarkdownReconstructionError = null,
        };

        Assert.Null(model.AllowedPageFailureRatio);
        Assert.True(model.RawData.ContainsKey("allowed_page_failure_ratio"));
        Assert.Null(model.FailOnBuggyFont);
        Assert.True(model.RawData.ContainsKey("fail_on_buggy_font"));
        Assert.Null(model.FailOnImageExtractionError);
        Assert.True(model.RawData.ContainsKey("fail_on_image_extraction_error"));
        Assert.Null(model.FailOnImageOcrError);
        Assert.True(model.RawData.ContainsKey("fail_on_image_ocr_error"));
        Assert.Null(model.FailOnMarkdownReconstructionError);
        Assert.True(model.RawData.ContainsKey("fail_on_markdown_reconstruction_error"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::JobFailureConditions
        {
            AllowedPageFailureRatio = null,
            FailOnBuggyFont = null,
            FailOnImageExtractionError = null,
            FailOnImageOcrError = null,
            FailOnMarkdownReconstructionError = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::JobFailureConditions
        {
            AllowedPageFailureRatio = 1,
            FailOnBuggyFont = true,
            FailOnImageExtractionError = true,
            FailOnImageOcrError = true,
            FailOnMarkdownReconstructionError = true,
        };

        Parsing::JobFailureConditions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TimeoutsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::Timeouts { BaseInSeconds = 1, ExtraTimePerPageInSeconds = 1 };

        long expectedBaseInSeconds = 1;
        long expectedExtraTimePerPageInSeconds = 1;

        Assert.Equal(expectedBaseInSeconds, model.BaseInSeconds);
        Assert.Equal(expectedExtraTimePerPageInSeconds, model.ExtraTimePerPageInSeconds);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::Timeouts { BaseInSeconds = 1, ExtraTimePerPageInSeconds = 1 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Timeouts>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::Timeouts { BaseInSeconds = 1, ExtraTimePerPageInSeconds = 1 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Timeouts>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedBaseInSeconds = 1;
        long expectedExtraTimePerPageInSeconds = 1;

        Assert.Equal(expectedBaseInSeconds, deserialized.BaseInSeconds);
        Assert.Equal(expectedExtraTimePerPageInSeconds, deserialized.ExtraTimePerPageInSeconds);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::Timeouts { BaseInSeconds = 1, ExtraTimePerPageInSeconds = 1 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::Timeouts { };

        Assert.Null(model.BaseInSeconds);
        Assert.False(model.RawData.ContainsKey("base_in_seconds"));
        Assert.Null(model.ExtraTimePerPageInSeconds);
        Assert.False(model.RawData.ContainsKey("extra_time_per_page_in_seconds"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::Timeouts { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::Timeouts
        {
            BaseInSeconds = null,
            ExtraTimePerPageInSeconds = null,
        };

        Assert.Null(model.BaseInSeconds);
        Assert.True(model.RawData.ContainsKey("base_in_seconds"));
        Assert.Null(model.ExtraTimePerPageInSeconds);
        Assert.True(model.RawData.ContainsKey("extra_time_per_page_in_seconds"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::Timeouts
        {
            BaseInSeconds = null,
            ExtraTimePerPageInSeconds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::Timeouts { BaseInSeconds = 1, ExtraTimePerPageInSeconds = 1 };

        Parsing::Timeouts copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProcessingOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::ProcessingOptions
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
                        Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                        SpatialText = new()
                        {
                            DoNotUnrollColumns = true,
                            PreserveLayoutAlignmentAcrossPages = true,
                            PreserveVerySmallText = true,
                        },
                        SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                        Tier = Parsing::ParsingConfTier.Agentic,
                        Version = Parsing::ParsingConfVersion.Latest,
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
            ConfidenceScoreEffort = Parsing::ConfidenceScoreEffort.High,
            CostOptimizer = new() { Enable = true },
            DisableHeuristics = true,
            Forms = Parsing::Forms.Enrich,
            Ignore = new()
            {
                IgnoreDiagonalText = true,
                IgnoreHiddenText = true,
                IgnoreTextInImage = true,
            },
            OcrParameters = new() { Languages = [Parsing::ParsingLanguages.Abq] },
            SpecializedChartParsing = Parsing::ProcessingOptionsSpecializedChartParsing.Agentic,
        };

        bool expectedAggressiveTableExtraction = true;
        List<Parsing::AutoModeConfiguration> expectedAutoModeConfiguration =
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
                    Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                    SpatialText = new()
                    {
                        DoNotUnrollColumns = true,
                        PreserveLayoutAlignmentAcrossPages = true,
                        PreserveVerySmallText = true,
                    },
                    SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                    Tier = Parsing::ParsingConfTier.Agentic,
                    Version = Parsing::ParsingConfVersion.Latest,
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
        ];
        ApiEnum<string, Parsing::ConfidenceScoreEffort> expectedConfidenceScoreEffort =
            Parsing::ConfidenceScoreEffort.High;
        Parsing::CostOptimizer expectedCostOptimizer = new() { Enable = true };
        bool expectedDisableHeuristics = true;
        ApiEnum<string, Parsing::Forms> expectedForms = Parsing::Forms.Enrich;
        Parsing::ProcessingOptionsIgnore expectedIgnore = new()
        {
            IgnoreDiagonalText = true,
            IgnoreHiddenText = true,
            IgnoreTextInImage = true,
        };
        Parsing::OcrParameters expectedOcrParameters = new()
        {
            Languages = [Parsing::ParsingLanguages.Abq],
        };
        ApiEnum<
            string,
            Parsing::ProcessingOptionsSpecializedChartParsing
        > expectedSpecializedChartParsing =
            Parsing::ProcessingOptionsSpecializedChartParsing.Agentic;

        Assert.Equal(expectedAggressiveTableExtraction, model.AggressiveTableExtraction);
        Assert.NotNull(model.AutoModeConfiguration);
        Assert.Equal(expectedAutoModeConfiguration.Count, model.AutoModeConfiguration.Count);
        for (int i = 0; i < expectedAutoModeConfiguration.Count; i++)
        {
            Assert.Equal(expectedAutoModeConfiguration[i], model.AutoModeConfiguration[i]);
        }
        Assert.Equal(expectedConfidenceScoreEffort, model.ConfidenceScoreEffort);
        Assert.Equal(expectedCostOptimizer, model.CostOptimizer);
        Assert.Equal(expectedDisableHeuristics, model.DisableHeuristics);
        Assert.Equal(expectedForms, model.Forms);
        Assert.Equal(expectedIgnore, model.Ignore);
        Assert.Equal(expectedOcrParameters, model.OcrParameters);
        Assert.Equal(expectedSpecializedChartParsing, model.SpecializedChartParsing);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::ProcessingOptions
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
                        Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                        SpatialText = new()
                        {
                            DoNotUnrollColumns = true,
                            PreserveLayoutAlignmentAcrossPages = true,
                            PreserveVerySmallText = true,
                        },
                        SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                        Tier = Parsing::ParsingConfTier.Agentic,
                        Version = Parsing::ParsingConfVersion.Latest,
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
            ConfidenceScoreEffort = Parsing::ConfidenceScoreEffort.High,
            CostOptimizer = new() { Enable = true },
            DisableHeuristics = true,
            Forms = Parsing::Forms.Enrich,
            Ignore = new()
            {
                IgnoreDiagonalText = true,
                IgnoreHiddenText = true,
                IgnoreTextInImage = true,
            },
            OcrParameters = new() { Languages = [Parsing::ParsingLanguages.Abq] },
            SpecializedChartParsing = Parsing::ProcessingOptionsSpecializedChartParsing.Agentic,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ProcessingOptions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::ProcessingOptions
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
                        Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                        SpatialText = new()
                        {
                            DoNotUnrollColumns = true,
                            PreserveLayoutAlignmentAcrossPages = true,
                            PreserveVerySmallText = true,
                        },
                        SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                        Tier = Parsing::ParsingConfTier.Agentic,
                        Version = Parsing::ParsingConfVersion.Latest,
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
            ConfidenceScoreEffort = Parsing::ConfidenceScoreEffort.High,
            CostOptimizer = new() { Enable = true },
            DisableHeuristics = true,
            Forms = Parsing::Forms.Enrich,
            Ignore = new()
            {
                IgnoreDiagonalText = true,
                IgnoreHiddenText = true,
                IgnoreTextInImage = true,
            },
            OcrParameters = new() { Languages = [Parsing::ParsingLanguages.Abq] },
            SpecializedChartParsing = Parsing::ProcessingOptionsSpecializedChartParsing.Agentic,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ProcessingOptions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAggressiveTableExtraction = true;
        List<Parsing::AutoModeConfiguration> expectedAutoModeConfiguration =
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
                    Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                    SpatialText = new()
                    {
                        DoNotUnrollColumns = true,
                        PreserveLayoutAlignmentAcrossPages = true,
                        PreserveVerySmallText = true,
                    },
                    SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                    Tier = Parsing::ParsingConfTier.Agentic,
                    Version = Parsing::ParsingConfVersion.Latest,
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
        ];
        ApiEnum<string, Parsing::ConfidenceScoreEffort> expectedConfidenceScoreEffort =
            Parsing::ConfidenceScoreEffort.High;
        Parsing::CostOptimizer expectedCostOptimizer = new() { Enable = true };
        bool expectedDisableHeuristics = true;
        ApiEnum<string, Parsing::Forms> expectedForms = Parsing::Forms.Enrich;
        Parsing::ProcessingOptionsIgnore expectedIgnore = new()
        {
            IgnoreDiagonalText = true,
            IgnoreHiddenText = true,
            IgnoreTextInImage = true,
        };
        Parsing::OcrParameters expectedOcrParameters = new()
        {
            Languages = [Parsing::ParsingLanguages.Abq],
        };
        ApiEnum<
            string,
            Parsing::ProcessingOptionsSpecializedChartParsing
        > expectedSpecializedChartParsing =
            Parsing::ProcessingOptionsSpecializedChartParsing.Agentic;

        Assert.Equal(expectedAggressiveTableExtraction, deserialized.AggressiveTableExtraction);
        Assert.NotNull(deserialized.AutoModeConfiguration);
        Assert.Equal(expectedAutoModeConfiguration.Count, deserialized.AutoModeConfiguration.Count);
        for (int i = 0; i < expectedAutoModeConfiguration.Count; i++)
        {
            Assert.Equal(expectedAutoModeConfiguration[i], deserialized.AutoModeConfiguration[i]);
        }
        Assert.Equal(expectedConfidenceScoreEffort, deserialized.ConfidenceScoreEffort);
        Assert.Equal(expectedCostOptimizer, deserialized.CostOptimizer);
        Assert.Equal(expectedDisableHeuristics, deserialized.DisableHeuristics);
        Assert.Equal(expectedForms, deserialized.Forms);
        Assert.Equal(expectedIgnore, deserialized.Ignore);
        Assert.Equal(expectedOcrParameters, deserialized.OcrParameters);
        Assert.Equal(expectedSpecializedChartParsing, deserialized.SpecializedChartParsing);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::ProcessingOptions
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
                        Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                        SpatialText = new()
                        {
                            DoNotUnrollColumns = true,
                            PreserveLayoutAlignmentAcrossPages = true,
                            PreserveVerySmallText = true,
                        },
                        SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                        Tier = Parsing::ParsingConfTier.Agentic,
                        Version = Parsing::ParsingConfVersion.Latest,
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
            ConfidenceScoreEffort = Parsing::ConfidenceScoreEffort.High,
            CostOptimizer = new() { Enable = true },
            DisableHeuristics = true,
            Forms = Parsing::Forms.Enrich,
            Ignore = new()
            {
                IgnoreDiagonalText = true,
                IgnoreHiddenText = true,
                IgnoreTextInImage = true,
            },
            OcrParameters = new() { Languages = [Parsing::ParsingLanguages.Abq] },
            SpecializedChartParsing = Parsing::ProcessingOptionsSpecializedChartParsing.Agentic,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::ProcessingOptions
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
                        Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                        SpatialText = new()
                        {
                            DoNotUnrollColumns = true,
                            PreserveLayoutAlignmentAcrossPages = true,
                            PreserveVerySmallText = true,
                        },
                        SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                        Tier = Parsing::ParsingConfTier.Agentic,
                        Version = Parsing::ParsingConfVersion.Latest,
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
            ConfidenceScoreEffort = Parsing::ConfidenceScoreEffort.High,
            CostOptimizer = new() { Enable = true },
            DisableHeuristics = true,
            Forms = Parsing::Forms.Enrich,
            SpecializedChartParsing = Parsing::ProcessingOptionsSpecializedChartParsing.Agentic,
        };

        Assert.Null(model.Ignore);
        Assert.False(model.RawData.ContainsKey("ignore"));
        Assert.Null(model.OcrParameters);
        Assert.False(model.RawData.ContainsKey("ocr_parameters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::ProcessingOptions
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
                        Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                        SpatialText = new()
                        {
                            DoNotUnrollColumns = true,
                            PreserveLayoutAlignmentAcrossPages = true,
                            PreserveVerySmallText = true,
                        },
                        SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                        Tier = Parsing::ParsingConfTier.Agentic,
                        Version = Parsing::ParsingConfVersion.Latest,
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
            ConfidenceScoreEffort = Parsing::ConfidenceScoreEffort.High,
            CostOptimizer = new() { Enable = true },
            DisableHeuristics = true,
            Forms = Parsing::Forms.Enrich,
            SpecializedChartParsing = Parsing::ProcessingOptionsSpecializedChartParsing.Agentic,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Parsing::ProcessingOptions
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
                        Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                        SpatialText = new()
                        {
                            DoNotUnrollColumns = true,
                            PreserveLayoutAlignmentAcrossPages = true,
                            PreserveVerySmallText = true,
                        },
                        SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                        Tier = Parsing::ParsingConfTier.Agentic,
                        Version = Parsing::ParsingConfVersion.Latest,
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
            ConfidenceScoreEffort = Parsing::ConfidenceScoreEffort.High,
            CostOptimizer = new() { Enable = true },
            DisableHeuristics = true,
            Forms = Parsing::Forms.Enrich,
            SpecializedChartParsing = Parsing::ProcessingOptionsSpecializedChartParsing.Agentic,

            // Null should be interpreted as omitted for these properties
            Ignore = null,
            OcrParameters = null,
        };

        Assert.Null(model.Ignore);
        Assert.False(model.RawData.ContainsKey("ignore"));
        Assert.Null(model.OcrParameters);
        Assert.False(model.RawData.ContainsKey("ocr_parameters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::ProcessingOptions
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
                        Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                        SpatialText = new()
                        {
                            DoNotUnrollColumns = true,
                            PreserveLayoutAlignmentAcrossPages = true,
                            PreserveVerySmallText = true,
                        },
                        SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                        Tier = Parsing::ParsingConfTier.Agentic,
                        Version = Parsing::ParsingConfVersion.Latest,
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
            ConfidenceScoreEffort = Parsing::ConfidenceScoreEffort.High,
            CostOptimizer = new() { Enable = true },
            DisableHeuristics = true,
            Forms = Parsing::Forms.Enrich,
            SpecializedChartParsing = Parsing::ProcessingOptionsSpecializedChartParsing.Agentic,

            // Null should be interpreted as omitted for these properties
            Ignore = null,
            OcrParameters = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::ProcessingOptions
        {
            Ignore = new()
            {
                IgnoreDiagonalText = true,
                IgnoreHiddenText = true,
                IgnoreTextInImage = true,
            },
            OcrParameters = new() { Languages = [Parsing::ParsingLanguages.Abq] },
        };

        Assert.Null(model.AggressiveTableExtraction);
        Assert.False(model.RawData.ContainsKey("aggressive_table_extraction"));
        Assert.Null(model.AutoModeConfiguration);
        Assert.False(model.RawData.ContainsKey("auto_mode_configuration"));
        Assert.Null(model.ConfidenceScoreEffort);
        Assert.False(model.RawData.ContainsKey("confidence_score_effort"));
        Assert.Null(model.CostOptimizer);
        Assert.False(model.RawData.ContainsKey("cost_optimizer"));
        Assert.Null(model.DisableHeuristics);
        Assert.False(model.RawData.ContainsKey("disable_heuristics"));
        Assert.Null(model.Forms);
        Assert.False(model.RawData.ContainsKey("forms"));
        Assert.Null(model.SpecializedChartParsing);
        Assert.False(model.RawData.ContainsKey("specialized_chart_parsing"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::ProcessingOptions
        {
            Ignore = new()
            {
                IgnoreDiagonalText = true,
                IgnoreHiddenText = true,
                IgnoreTextInImage = true,
            },
            OcrParameters = new() { Languages = [Parsing::ParsingLanguages.Abq] },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::ProcessingOptions
        {
            Ignore = new()
            {
                IgnoreDiagonalText = true,
                IgnoreHiddenText = true,
                IgnoreTextInImage = true,
            },
            OcrParameters = new() { Languages = [Parsing::ParsingLanguages.Abq] },

            AggressiveTableExtraction = null,
            AutoModeConfiguration = null,
            ConfidenceScoreEffort = null,
            CostOptimizer = null,
            DisableHeuristics = null,
            Forms = null,
            SpecializedChartParsing = null,
        };

        Assert.Null(model.AggressiveTableExtraction);
        Assert.True(model.RawData.ContainsKey("aggressive_table_extraction"));
        Assert.Null(model.AutoModeConfiguration);
        Assert.True(model.RawData.ContainsKey("auto_mode_configuration"));
        Assert.Null(model.ConfidenceScoreEffort);
        Assert.True(model.RawData.ContainsKey("confidence_score_effort"));
        Assert.Null(model.CostOptimizer);
        Assert.True(model.RawData.ContainsKey("cost_optimizer"));
        Assert.Null(model.DisableHeuristics);
        Assert.True(model.RawData.ContainsKey("disable_heuristics"));
        Assert.Null(model.Forms);
        Assert.True(model.RawData.ContainsKey("forms"));
        Assert.Null(model.SpecializedChartParsing);
        Assert.True(model.RawData.ContainsKey("specialized_chart_parsing"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::ProcessingOptions
        {
            Ignore = new()
            {
                IgnoreDiagonalText = true,
                IgnoreHiddenText = true,
                IgnoreTextInImage = true,
            },
            OcrParameters = new() { Languages = [Parsing::ParsingLanguages.Abq] },

            AggressiveTableExtraction = null,
            AutoModeConfiguration = null,
            ConfidenceScoreEffort = null,
            CostOptimizer = null,
            DisableHeuristics = null,
            Forms = null,
            SpecializedChartParsing = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::ProcessingOptions
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
                        Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                        SpatialText = new()
                        {
                            DoNotUnrollColumns = true,
                            PreserveLayoutAlignmentAcrossPages = true,
                            PreserveVerySmallText = true,
                        },
                        SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                        Tier = Parsing::ParsingConfTier.Agentic,
                        Version = Parsing::ParsingConfVersion.Latest,
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
            ConfidenceScoreEffort = Parsing::ConfidenceScoreEffort.High,
            CostOptimizer = new() { Enable = true },
            DisableHeuristics = true,
            Forms = Parsing::Forms.Enrich,
            Ignore = new()
            {
                IgnoreDiagonalText = true,
                IgnoreHiddenText = true,
                IgnoreTextInImage = true,
            },
            OcrParameters = new() { Languages = [Parsing::ParsingLanguages.Abq] },
            SpecializedChartParsing = Parsing::ProcessingOptionsSpecializedChartParsing.Agentic,
        };

        Parsing::ProcessingOptions copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AutoModeConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::AutoModeConfiguration
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
                Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                SpatialText = new()
                {
                    DoNotUnrollColumns = true,
                    PreserveLayoutAlignmentAcrossPages = true,
                    PreserveVerySmallText = true,
                },
                SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                Tier = Parsing::ParsingConfTier.Agentic,
                Version = Parsing::ParsingConfVersion.Latest,
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
        };

        Parsing::ParsingConf expectedParsingConf = new()
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
            Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
            SpatialText = new()
            {
                DoNotUnrollColumns = true,
                PreserveLayoutAlignmentAcrossPages = true,
                PreserveVerySmallText = true,
            },
            SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
            Tier = Parsing::ParsingConfTier.Agentic,
            Version = Parsing::ParsingConfVersion.Latest,
        };
        string expectedFilenameMatchGlob = "*.txt";
        List<string> expectedFilenameMatchGlobList = ["string"];
        string expectedFilenameRegexp = "filename_regexp";
        string expectedFilenameRegexpMode = "filename_regexp_mode";
        bool expectedFullPageImageInPage = true;
        Parsing::FullPageImageInPageThreshold expectedFullPageImageInPageThreshold = 0;
        bool expectedImageInPage = true;
        string expectedLayoutElementInPage = "layout_element_in_page";
        Parsing::LayoutElementInPageConfidenceThreshold expectedLayoutElementInPageConfidenceThreshold =
            0;
        Parsing::PageContainsAtLeastNCharts expectedPageContainsAtLeastNCharts = 0;
        Parsing::PageContainsAtLeastNImages expectedPageContainsAtLeastNImages = 0;
        Parsing::PageContainsAtLeastNLayoutElements expectedPageContainsAtLeastNLayoutElements = 0;
        Parsing::PageContainsAtLeastNLines expectedPageContainsAtLeastNLines = 0;
        Parsing::PageContainsAtLeastNLinks expectedPageContainsAtLeastNLinks = 0;
        Parsing::PageContainsAtLeastNNumbers expectedPageContainsAtLeastNNumbers = 0;
        Parsing::PageContainsAtLeastNPercentNumbers expectedPageContainsAtLeastNPercentNumbers = 0;
        Parsing::PageContainsAtLeastNTables expectedPageContainsAtLeastNTables = 0;
        Parsing::PageContainsAtLeastNWords expectedPageContainsAtLeastNWords = 0;
        Parsing::PageContainsAtMostNCharts expectedPageContainsAtMostNCharts = 0;
        Parsing::PageContainsAtMostNImages expectedPageContainsAtMostNImages = 0;
        Parsing::PageContainsAtMostNLayoutElements expectedPageContainsAtMostNLayoutElements = 0;
        Parsing::PageContainsAtMostNLines expectedPageContainsAtMostNLines = 0;
        Parsing::PageContainsAtMostNLinks expectedPageContainsAtMostNLinks = 0;
        Parsing::PageContainsAtMostNNumbers expectedPageContainsAtMostNNumbers = 0;
        Parsing::PageContainsAtMostNPercentNumbers expectedPageContainsAtMostNPercentNumbers = 0;
        Parsing::PageContainsAtMostNTables expectedPageContainsAtMostNTables = 0;
        Parsing::PageContainsAtMostNWords expectedPageContainsAtMostNWords = 0;
        Parsing::PageLongerThanNChars expectedPageLongerThanNChars = 0;
        bool expectedPageMdError = true;
        Parsing::PageShorterThanNChars expectedPageShorterThanNChars = 0;
        string expectedRegexpInPage = "regexp_in_page";
        string expectedRegexpInPageMode = "regexp_in_page_mode";
        bool expectedTableInPage = true;
        string expectedTextInPage = "text_in_page";
        string expectedTriggerMode = "trigger_mode";

        Assert.Equal(expectedParsingConf, model.ParsingConf);
        Assert.Equal(expectedFilenameMatchGlob, model.FilenameMatchGlob);
        Assert.NotNull(model.FilenameMatchGlobList);
        Assert.Equal(expectedFilenameMatchGlobList.Count, model.FilenameMatchGlobList.Count);
        for (int i = 0; i < expectedFilenameMatchGlobList.Count; i++)
        {
            Assert.Equal(expectedFilenameMatchGlobList[i], model.FilenameMatchGlobList[i]);
        }
        Assert.Equal(expectedFilenameRegexp, model.FilenameRegexp);
        Assert.Equal(expectedFilenameRegexpMode, model.FilenameRegexpMode);
        Assert.Equal(expectedFullPageImageInPage, model.FullPageImageInPage);
        Assert.Equal(expectedFullPageImageInPageThreshold, model.FullPageImageInPageThreshold);
        Assert.Equal(expectedImageInPage, model.ImageInPage);
        Assert.Equal(expectedLayoutElementInPage, model.LayoutElementInPage);
        Assert.Equal(
            expectedLayoutElementInPageConfidenceThreshold,
            model.LayoutElementInPageConfidenceThreshold
        );
        Assert.Equal(expectedPageContainsAtLeastNCharts, model.PageContainsAtLeastNCharts);
        Assert.Equal(expectedPageContainsAtLeastNImages, model.PageContainsAtLeastNImages);
        Assert.Equal(
            expectedPageContainsAtLeastNLayoutElements,
            model.PageContainsAtLeastNLayoutElements
        );
        Assert.Equal(expectedPageContainsAtLeastNLines, model.PageContainsAtLeastNLines);
        Assert.Equal(expectedPageContainsAtLeastNLinks, model.PageContainsAtLeastNLinks);
        Assert.Equal(expectedPageContainsAtLeastNNumbers, model.PageContainsAtLeastNNumbers);
        Assert.Equal(
            expectedPageContainsAtLeastNPercentNumbers,
            model.PageContainsAtLeastNPercentNumbers
        );
        Assert.Equal(expectedPageContainsAtLeastNTables, model.PageContainsAtLeastNTables);
        Assert.Equal(expectedPageContainsAtLeastNWords, model.PageContainsAtLeastNWords);
        Assert.Equal(expectedPageContainsAtMostNCharts, model.PageContainsAtMostNCharts);
        Assert.Equal(expectedPageContainsAtMostNImages, model.PageContainsAtMostNImages);
        Assert.Equal(
            expectedPageContainsAtMostNLayoutElements,
            model.PageContainsAtMostNLayoutElements
        );
        Assert.Equal(expectedPageContainsAtMostNLines, model.PageContainsAtMostNLines);
        Assert.Equal(expectedPageContainsAtMostNLinks, model.PageContainsAtMostNLinks);
        Assert.Equal(expectedPageContainsAtMostNNumbers, model.PageContainsAtMostNNumbers);
        Assert.Equal(
            expectedPageContainsAtMostNPercentNumbers,
            model.PageContainsAtMostNPercentNumbers
        );
        Assert.Equal(expectedPageContainsAtMostNTables, model.PageContainsAtMostNTables);
        Assert.Equal(expectedPageContainsAtMostNWords, model.PageContainsAtMostNWords);
        Assert.Equal(expectedPageLongerThanNChars, model.PageLongerThanNChars);
        Assert.Equal(expectedPageMdError, model.PageMdError);
        Assert.Equal(expectedPageShorterThanNChars, model.PageShorterThanNChars);
        Assert.Equal(expectedRegexpInPage, model.RegexpInPage);
        Assert.Equal(expectedRegexpInPageMode, model.RegexpInPageMode);
        Assert.Equal(expectedTableInPage, model.TableInPage);
        Assert.Equal(expectedTextInPage, model.TextInPage);
        Assert.Equal(expectedTriggerMode, model.TriggerMode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::AutoModeConfiguration
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
                Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                SpatialText = new()
                {
                    DoNotUnrollColumns = true,
                    PreserveLayoutAlignmentAcrossPages = true,
                    PreserveVerySmallText = true,
                },
                SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                Tier = Parsing::ParsingConfTier.Agentic,
                Version = Parsing::ParsingConfVersion.Latest,
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::AutoModeConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::AutoModeConfiguration
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
                Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                SpatialText = new()
                {
                    DoNotUnrollColumns = true,
                    PreserveLayoutAlignmentAcrossPages = true,
                    PreserveVerySmallText = true,
                },
                SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                Tier = Parsing::ParsingConfTier.Agentic,
                Version = Parsing::ParsingConfVersion.Latest,
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::AutoModeConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Parsing::ParsingConf expectedParsingConf = new()
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
            Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
            SpatialText = new()
            {
                DoNotUnrollColumns = true,
                PreserveLayoutAlignmentAcrossPages = true,
                PreserveVerySmallText = true,
            },
            SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
            Tier = Parsing::ParsingConfTier.Agentic,
            Version = Parsing::ParsingConfVersion.Latest,
        };
        string expectedFilenameMatchGlob = "*.txt";
        List<string> expectedFilenameMatchGlobList = ["string"];
        string expectedFilenameRegexp = "filename_regexp";
        string expectedFilenameRegexpMode = "filename_regexp_mode";
        bool expectedFullPageImageInPage = true;
        Parsing::FullPageImageInPageThreshold expectedFullPageImageInPageThreshold = 0;
        bool expectedImageInPage = true;
        string expectedLayoutElementInPage = "layout_element_in_page";
        Parsing::LayoutElementInPageConfidenceThreshold expectedLayoutElementInPageConfidenceThreshold =
            0;
        Parsing::PageContainsAtLeastNCharts expectedPageContainsAtLeastNCharts = 0;
        Parsing::PageContainsAtLeastNImages expectedPageContainsAtLeastNImages = 0;
        Parsing::PageContainsAtLeastNLayoutElements expectedPageContainsAtLeastNLayoutElements = 0;
        Parsing::PageContainsAtLeastNLines expectedPageContainsAtLeastNLines = 0;
        Parsing::PageContainsAtLeastNLinks expectedPageContainsAtLeastNLinks = 0;
        Parsing::PageContainsAtLeastNNumbers expectedPageContainsAtLeastNNumbers = 0;
        Parsing::PageContainsAtLeastNPercentNumbers expectedPageContainsAtLeastNPercentNumbers = 0;
        Parsing::PageContainsAtLeastNTables expectedPageContainsAtLeastNTables = 0;
        Parsing::PageContainsAtLeastNWords expectedPageContainsAtLeastNWords = 0;
        Parsing::PageContainsAtMostNCharts expectedPageContainsAtMostNCharts = 0;
        Parsing::PageContainsAtMostNImages expectedPageContainsAtMostNImages = 0;
        Parsing::PageContainsAtMostNLayoutElements expectedPageContainsAtMostNLayoutElements = 0;
        Parsing::PageContainsAtMostNLines expectedPageContainsAtMostNLines = 0;
        Parsing::PageContainsAtMostNLinks expectedPageContainsAtMostNLinks = 0;
        Parsing::PageContainsAtMostNNumbers expectedPageContainsAtMostNNumbers = 0;
        Parsing::PageContainsAtMostNPercentNumbers expectedPageContainsAtMostNPercentNumbers = 0;
        Parsing::PageContainsAtMostNTables expectedPageContainsAtMostNTables = 0;
        Parsing::PageContainsAtMostNWords expectedPageContainsAtMostNWords = 0;
        Parsing::PageLongerThanNChars expectedPageLongerThanNChars = 0;
        bool expectedPageMdError = true;
        Parsing::PageShorterThanNChars expectedPageShorterThanNChars = 0;
        string expectedRegexpInPage = "regexp_in_page";
        string expectedRegexpInPageMode = "regexp_in_page_mode";
        bool expectedTableInPage = true;
        string expectedTextInPage = "text_in_page";
        string expectedTriggerMode = "trigger_mode";

        Assert.Equal(expectedParsingConf, deserialized.ParsingConf);
        Assert.Equal(expectedFilenameMatchGlob, deserialized.FilenameMatchGlob);
        Assert.NotNull(deserialized.FilenameMatchGlobList);
        Assert.Equal(expectedFilenameMatchGlobList.Count, deserialized.FilenameMatchGlobList.Count);
        for (int i = 0; i < expectedFilenameMatchGlobList.Count; i++)
        {
            Assert.Equal(expectedFilenameMatchGlobList[i], deserialized.FilenameMatchGlobList[i]);
        }
        Assert.Equal(expectedFilenameRegexp, deserialized.FilenameRegexp);
        Assert.Equal(expectedFilenameRegexpMode, deserialized.FilenameRegexpMode);
        Assert.Equal(expectedFullPageImageInPage, deserialized.FullPageImageInPage);
        Assert.Equal(
            expectedFullPageImageInPageThreshold,
            deserialized.FullPageImageInPageThreshold
        );
        Assert.Equal(expectedImageInPage, deserialized.ImageInPage);
        Assert.Equal(expectedLayoutElementInPage, deserialized.LayoutElementInPage);
        Assert.Equal(
            expectedLayoutElementInPageConfidenceThreshold,
            deserialized.LayoutElementInPageConfidenceThreshold
        );
        Assert.Equal(expectedPageContainsAtLeastNCharts, deserialized.PageContainsAtLeastNCharts);
        Assert.Equal(expectedPageContainsAtLeastNImages, deserialized.PageContainsAtLeastNImages);
        Assert.Equal(
            expectedPageContainsAtLeastNLayoutElements,
            deserialized.PageContainsAtLeastNLayoutElements
        );
        Assert.Equal(expectedPageContainsAtLeastNLines, deserialized.PageContainsAtLeastNLines);
        Assert.Equal(expectedPageContainsAtLeastNLinks, deserialized.PageContainsAtLeastNLinks);
        Assert.Equal(expectedPageContainsAtLeastNNumbers, deserialized.PageContainsAtLeastNNumbers);
        Assert.Equal(
            expectedPageContainsAtLeastNPercentNumbers,
            deserialized.PageContainsAtLeastNPercentNumbers
        );
        Assert.Equal(expectedPageContainsAtLeastNTables, deserialized.PageContainsAtLeastNTables);
        Assert.Equal(expectedPageContainsAtLeastNWords, deserialized.PageContainsAtLeastNWords);
        Assert.Equal(expectedPageContainsAtMostNCharts, deserialized.PageContainsAtMostNCharts);
        Assert.Equal(expectedPageContainsAtMostNImages, deserialized.PageContainsAtMostNImages);
        Assert.Equal(
            expectedPageContainsAtMostNLayoutElements,
            deserialized.PageContainsAtMostNLayoutElements
        );
        Assert.Equal(expectedPageContainsAtMostNLines, deserialized.PageContainsAtMostNLines);
        Assert.Equal(expectedPageContainsAtMostNLinks, deserialized.PageContainsAtMostNLinks);
        Assert.Equal(expectedPageContainsAtMostNNumbers, deserialized.PageContainsAtMostNNumbers);
        Assert.Equal(
            expectedPageContainsAtMostNPercentNumbers,
            deserialized.PageContainsAtMostNPercentNumbers
        );
        Assert.Equal(expectedPageContainsAtMostNTables, deserialized.PageContainsAtMostNTables);
        Assert.Equal(expectedPageContainsAtMostNWords, deserialized.PageContainsAtMostNWords);
        Assert.Equal(expectedPageLongerThanNChars, deserialized.PageLongerThanNChars);
        Assert.Equal(expectedPageMdError, deserialized.PageMdError);
        Assert.Equal(expectedPageShorterThanNChars, deserialized.PageShorterThanNChars);
        Assert.Equal(expectedRegexpInPage, deserialized.RegexpInPage);
        Assert.Equal(expectedRegexpInPageMode, deserialized.RegexpInPageMode);
        Assert.Equal(expectedTableInPage, deserialized.TableInPage);
        Assert.Equal(expectedTextInPage, deserialized.TextInPage);
        Assert.Equal(expectedTriggerMode, deserialized.TriggerMode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::AutoModeConfiguration
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
                Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                SpatialText = new()
                {
                    DoNotUnrollColumns = true,
                    PreserveLayoutAlignmentAcrossPages = true,
                    PreserveVerySmallText = true,
                },
                SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                Tier = Parsing::ParsingConfTier.Agentic,
                Version = Parsing::ParsingConfVersion.Latest,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::AutoModeConfiguration
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
                Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                SpatialText = new()
                {
                    DoNotUnrollColumns = true,
                    PreserveLayoutAlignmentAcrossPages = true,
                    PreserveVerySmallText = true,
                },
                SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                Tier = Parsing::ParsingConfTier.Agentic,
                Version = Parsing::ParsingConfVersion.Latest,
            },
        };

        Assert.Null(model.FilenameMatchGlob);
        Assert.False(model.RawData.ContainsKey("filename_match_glob"));
        Assert.Null(model.FilenameMatchGlobList);
        Assert.False(model.RawData.ContainsKey("filename_match_glob_list"));
        Assert.Null(model.FilenameRegexp);
        Assert.False(model.RawData.ContainsKey("filename_regexp"));
        Assert.Null(model.FilenameRegexpMode);
        Assert.False(model.RawData.ContainsKey("filename_regexp_mode"));
        Assert.Null(model.FullPageImageInPage);
        Assert.False(model.RawData.ContainsKey("full_page_image_in_page"));
        Assert.Null(model.FullPageImageInPageThreshold);
        Assert.False(model.RawData.ContainsKey("full_page_image_in_page_threshold"));
        Assert.Null(model.ImageInPage);
        Assert.False(model.RawData.ContainsKey("image_in_page"));
        Assert.Null(model.LayoutElementInPage);
        Assert.False(model.RawData.ContainsKey("layout_element_in_page"));
        Assert.Null(model.LayoutElementInPageConfidenceThreshold);
        Assert.False(model.RawData.ContainsKey("layout_element_in_page_confidence_threshold"));
        Assert.Null(model.PageContainsAtLeastNCharts);
        Assert.False(model.RawData.ContainsKey("page_contains_at_least_n_charts"));
        Assert.Null(model.PageContainsAtLeastNImages);
        Assert.False(model.RawData.ContainsKey("page_contains_at_least_n_images"));
        Assert.Null(model.PageContainsAtLeastNLayoutElements);
        Assert.False(model.RawData.ContainsKey("page_contains_at_least_n_layout_elements"));
        Assert.Null(model.PageContainsAtLeastNLines);
        Assert.False(model.RawData.ContainsKey("page_contains_at_least_n_lines"));
        Assert.Null(model.PageContainsAtLeastNLinks);
        Assert.False(model.RawData.ContainsKey("page_contains_at_least_n_links"));
        Assert.Null(model.PageContainsAtLeastNNumbers);
        Assert.False(model.RawData.ContainsKey("page_contains_at_least_n_numbers"));
        Assert.Null(model.PageContainsAtLeastNPercentNumbers);
        Assert.False(model.RawData.ContainsKey("page_contains_at_least_n_percent_numbers"));
        Assert.Null(model.PageContainsAtLeastNTables);
        Assert.False(model.RawData.ContainsKey("page_contains_at_least_n_tables"));
        Assert.Null(model.PageContainsAtLeastNWords);
        Assert.False(model.RawData.ContainsKey("page_contains_at_least_n_words"));
        Assert.Null(model.PageContainsAtMostNCharts);
        Assert.False(model.RawData.ContainsKey("page_contains_at_most_n_charts"));
        Assert.Null(model.PageContainsAtMostNImages);
        Assert.False(model.RawData.ContainsKey("page_contains_at_most_n_images"));
        Assert.Null(model.PageContainsAtMostNLayoutElements);
        Assert.False(model.RawData.ContainsKey("page_contains_at_most_n_layout_elements"));
        Assert.Null(model.PageContainsAtMostNLines);
        Assert.False(model.RawData.ContainsKey("page_contains_at_most_n_lines"));
        Assert.Null(model.PageContainsAtMostNLinks);
        Assert.False(model.RawData.ContainsKey("page_contains_at_most_n_links"));
        Assert.Null(model.PageContainsAtMostNNumbers);
        Assert.False(model.RawData.ContainsKey("page_contains_at_most_n_numbers"));
        Assert.Null(model.PageContainsAtMostNPercentNumbers);
        Assert.False(model.RawData.ContainsKey("page_contains_at_most_n_percent_numbers"));
        Assert.Null(model.PageContainsAtMostNTables);
        Assert.False(model.RawData.ContainsKey("page_contains_at_most_n_tables"));
        Assert.Null(model.PageContainsAtMostNWords);
        Assert.False(model.RawData.ContainsKey("page_contains_at_most_n_words"));
        Assert.Null(model.PageLongerThanNChars);
        Assert.False(model.RawData.ContainsKey("page_longer_than_n_chars"));
        Assert.Null(model.PageMdError);
        Assert.False(model.RawData.ContainsKey("page_md_error"));
        Assert.Null(model.PageShorterThanNChars);
        Assert.False(model.RawData.ContainsKey("page_shorter_than_n_chars"));
        Assert.Null(model.RegexpInPage);
        Assert.False(model.RawData.ContainsKey("regexp_in_page"));
        Assert.Null(model.RegexpInPageMode);
        Assert.False(model.RawData.ContainsKey("regexp_in_page_mode"));
        Assert.Null(model.TableInPage);
        Assert.False(model.RawData.ContainsKey("table_in_page"));
        Assert.Null(model.TextInPage);
        Assert.False(model.RawData.ContainsKey("text_in_page"));
        Assert.Null(model.TriggerMode);
        Assert.False(model.RawData.ContainsKey("trigger_mode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::AutoModeConfiguration
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
                Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                SpatialText = new()
                {
                    DoNotUnrollColumns = true,
                    PreserveLayoutAlignmentAcrossPages = true,
                    PreserveVerySmallText = true,
                },
                SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                Tier = Parsing::ParsingConfTier.Agentic,
                Version = Parsing::ParsingConfVersion.Latest,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::AutoModeConfiguration
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
                Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                SpatialText = new()
                {
                    DoNotUnrollColumns = true,
                    PreserveLayoutAlignmentAcrossPages = true,
                    PreserveVerySmallText = true,
                },
                SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                Tier = Parsing::ParsingConfTier.Agentic,
                Version = Parsing::ParsingConfVersion.Latest,
            },

            FilenameMatchGlob = null,
            FilenameMatchGlobList = null,
            FilenameRegexp = null,
            FilenameRegexpMode = null,
            FullPageImageInPage = null,
            FullPageImageInPageThreshold = null,
            ImageInPage = null,
            LayoutElementInPage = null,
            LayoutElementInPageConfidenceThreshold = null,
            PageContainsAtLeastNCharts = null,
            PageContainsAtLeastNImages = null,
            PageContainsAtLeastNLayoutElements = null,
            PageContainsAtLeastNLines = null,
            PageContainsAtLeastNLinks = null,
            PageContainsAtLeastNNumbers = null,
            PageContainsAtLeastNPercentNumbers = null,
            PageContainsAtLeastNTables = null,
            PageContainsAtLeastNWords = null,
            PageContainsAtMostNCharts = null,
            PageContainsAtMostNImages = null,
            PageContainsAtMostNLayoutElements = null,
            PageContainsAtMostNLines = null,
            PageContainsAtMostNLinks = null,
            PageContainsAtMostNNumbers = null,
            PageContainsAtMostNPercentNumbers = null,
            PageContainsAtMostNTables = null,
            PageContainsAtMostNWords = null,
            PageLongerThanNChars = null,
            PageMdError = null,
            PageShorterThanNChars = null,
            RegexpInPage = null,
            RegexpInPageMode = null,
            TableInPage = null,
            TextInPage = null,
            TriggerMode = null,
        };

        Assert.Null(model.FilenameMatchGlob);
        Assert.True(model.RawData.ContainsKey("filename_match_glob"));
        Assert.Null(model.FilenameMatchGlobList);
        Assert.True(model.RawData.ContainsKey("filename_match_glob_list"));
        Assert.Null(model.FilenameRegexp);
        Assert.True(model.RawData.ContainsKey("filename_regexp"));
        Assert.Null(model.FilenameRegexpMode);
        Assert.True(model.RawData.ContainsKey("filename_regexp_mode"));
        Assert.Null(model.FullPageImageInPage);
        Assert.True(model.RawData.ContainsKey("full_page_image_in_page"));
        Assert.Null(model.FullPageImageInPageThreshold);
        Assert.True(model.RawData.ContainsKey("full_page_image_in_page_threshold"));
        Assert.Null(model.ImageInPage);
        Assert.True(model.RawData.ContainsKey("image_in_page"));
        Assert.Null(model.LayoutElementInPage);
        Assert.True(model.RawData.ContainsKey("layout_element_in_page"));
        Assert.Null(model.LayoutElementInPageConfidenceThreshold);
        Assert.True(model.RawData.ContainsKey("layout_element_in_page_confidence_threshold"));
        Assert.Null(model.PageContainsAtLeastNCharts);
        Assert.True(model.RawData.ContainsKey("page_contains_at_least_n_charts"));
        Assert.Null(model.PageContainsAtLeastNImages);
        Assert.True(model.RawData.ContainsKey("page_contains_at_least_n_images"));
        Assert.Null(model.PageContainsAtLeastNLayoutElements);
        Assert.True(model.RawData.ContainsKey("page_contains_at_least_n_layout_elements"));
        Assert.Null(model.PageContainsAtLeastNLines);
        Assert.True(model.RawData.ContainsKey("page_contains_at_least_n_lines"));
        Assert.Null(model.PageContainsAtLeastNLinks);
        Assert.True(model.RawData.ContainsKey("page_contains_at_least_n_links"));
        Assert.Null(model.PageContainsAtLeastNNumbers);
        Assert.True(model.RawData.ContainsKey("page_contains_at_least_n_numbers"));
        Assert.Null(model.PageContainsAtLeastNPercentNumbers);
        Assert.True(model.RawData.ContainsKey("page_contains_at_least_n_percent_numbers"));
        Assert.Null(model.PageContainsAtLeastNTables);
        Assert.True(model.RawData.ContainsKey("page_contains_at_least_n_tables"));
        Assert.Null(model.PageContainsAtLeastNWords);
        Assert.True(model.RawData.ContainsKey("page_contains_at_least_n_words"));
        Assert.Null(model.PageContainsAtMostNCharts);
        Assert.True(model.RawData.ContainsKey("page_contains_at_most_n_charts"));
        Assert.Null(model.PageContainsAtMostNImages);
        Assert.True(model.RawData.ContainsKey("page_contains_at_most_n_images"));
        Assert.Null(model.PageContainsAtMostNLayoutElements);
        Assert.True(model.RawData.ContainsKey("page_contains_at_most_n_layout_elements"));
        Assert.Null(model.PageContainsAtMostNLines);
        Assert.True(model.RawData.ContainsKey("page_contains_at_most_n_lines"));
        Assert.Null(model.PageContainsAtMostNLinks);
        Assert.True(model.RawData.ContainsKey("page_contains_at_most_n_links"));
        Assert.Null(model.PageContainsAtMostNNumbers);
        Assert.True(model.RawData.ContainsKey("page_contains_at_most_n_numbers"));
        Assert.Null(model.PageContainsAtMostNPercentNumbers);
        Assert.True(model.RawData.ContainsKey("page_contains_at_most_n_percent_numbers"));
        Assert.Null(model.PageContainsAtMostNTables);
        Assert.True(model.RawData.ContainsKey("page_contains_at_most_n_tables"));
        Assert.Null(model.PageContainsAtMostNWords);
        Assert.True(model.RawData.ContainsKey("page_contains_at_most_n_words"));
        Assert.Null(model.PageLongerThanNChars);
        Assert.True(model.RawData.ContainsKey("page_longer_than_n_chars"));
        Assert.Null(model.PageMdError);
        Assert.True(model.RawData.ContainsKey("page_md_error"));
        Assert.Null(model.PageShorterThanNChars);
        Assert.True(model.RawData.ContainsKey("page_shorter_than_n_chars"));
        Assert.Null(model.RegexpInPage);
        Assert.True(model.RawData.ContainsKey("regexp_in_page"));
        Assert.Null(model.RegexpInPageMode);
        Assert.True(model.RawData.ContainsKey("regexp_in_page_mode"));
        Assert.Null(model.TableInPage);
        Assert.True(model.RawData.ContainsKey("table_in_page"));
        Assert.Null(model.TextInPage);
        Assert.True(model.RawData.ContainsKey("text_in_page"));
        Assert.Null(model.TriggerMode);
        Assert.True(model.RawData.ContainsKey("trigger_mode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::AutoModeConfiguration
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
                Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                SpatialText = new()
                {
                    DoNotUnrollColumns = true,
                    PreserveLayoutAlignmentAcrossPages = true,
                    PreserveVerySmallText = true,
                },
                SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                Tier = Parsing::ParsingConfTier.Agentic,
                Version = Parsing::ParsingConfVersion.Latest,
            },

            FilenameMatchGlob = null,
            FilenameMatchGlobList = null,
            FilenameRegexp = null,
            FilenameRegexpMode = null,
            FullPageImageInPage = null,
            FullPageImageInPageThreshold = null,
            ImageInPage = null,
            LayoutElementInPage = null,
            LayoutElementInPageConfidenceThreshold = null,
            PageContainsAtLeastNCharts = null,
            PageContainsAtLeastNImages = null,
            PageContainsAtLeastNLayoutElements = null,
            PageContainsAtLeastNLines = null,
            PageContainsAtLeastNLinks = null,
            PageContainsAtLeastNNumbers = null,
            PageContainsAtLeastNPercentNumbers = null,
            PageContainsAtLeastNTables = null,
            PageContainsAtLeastNWords = null,
            PageContainsAtMostNCharts = null,
            PageContainsAtMostNImages = null,
            PageContainsAtMostNLayoutElements = null,
            PageContainsAtMostNLines = null,
            PageContainsAtMostNLinks = null,
            PageContainsAtMostNNumbers = null,
            PageContainsAtMostNPercentNumbers = null,
            PageContainsAtMostNTables = null,
            PageContainsAtMostNWords = null,
            PageLongerThanNChars = null,
            PageMdError = null,
            PageShorterThanNChars = null,
            RegexpInPage = null,
            RegexpInPageMode = null,
            TableInPage = null,
            TextInPage = null,
            TriggerMode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::AutoModeConfiguration
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
                Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
                SpatialText = new()
                {
                    DoNotUnrollColumns = true,
                    PreserveLayoutAlignmentAcrossPages = true,
                    PreserveVerySmallText = true,
                },
                SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
                Tier = Parsing::ParsingConfTier.Agentic,
                Version = Parsing::ParsingConfVersion.Latest,
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
        };

        Parsing::AutoModeConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ParsingConfTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::ParsingConf
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
            Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
            SpatialText = new()
            {
                DoNotUnrollColumns = true,
                PreserveLayoutAlignmentAcrossPages = true,
                PreserveVerySmallText = true,
            },
            SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
            Tier = Parsing::ParsingConfTier.Agentic,
            Version = Parsing::ParsingConfVersion.Latest,
        };

        bool expectedAdaptiveLongTable = true;
        bool expectedAggressiveTableExtraction = true;
        Parsing::ParsingConfCropBox expectedCropBox = new()
        {
            Bottom = 0,
            Left = 0,
            Right = 0,
            Top = 0,
        };
        string expectedCustomPrompt = "custom_prompt";
        bool expectedExtractLayout = true;
        bool expectedHighResOcr = true;
        Parsing::Ignore expectedIgnore = new()
        {
            IgnoreDiagonalText = true,
            IgnoreHiddenText = true,
        };
        string expectedLanguage = "language";
        bool expectedOutlinedTableExtraction = true;
        Parsing::ParsingConfPresentation expectedPresentation = new()
        {
            OutOfBoundsContent = true,
            SkipEmbeddedData = true,
        };
        Parsing::ParsingConfSpatialText expectedSpatialText = new()
        {
            DoNotUnrollColumns = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
        };
        ApiEnum<string, Parsing::SpecializedChartParsing> expectedSpecializedChartParsing =
            Parsing::SpecializedChartParsing.Agentic;
        ApiEnum<string, Parsing::ParsingConfTier> expectedTier = Parsing::ParsingConfTier.Agentic;
        ApiEnum<string, Parsing::ParsingConfVersion> expectedVersion =
            Parsing::ParsingConfVersion.Latest;

        Assert.Equal(expectedAdaptiveLongTable, model.AdaptiveLongTable);
        Assert.Equal(expectedAggressiveTableExtraction, model.AggressiveTableExtraction);
        Assert.Equal(expectedCropBox, model.CropBox);
        Assert.Equal(expectedCustomPrompt, model.CustomPrompt);
        Assert.Equal(expectedExtractLayout, model.ExtractLayout);
        Assert.Equal(expectedHighResOcr, model.HighResOcr);
        Assert.Equal(expectedIgnore, model.Ignore);
        Assert.Equal(expectedLanguage, model.Language);
        Assert.Equal(expectedOutlinedTableExtraction, model.OutlinedTableExtraction);
        Assert.Equal(expectedPresentation, model.Presentation);
        Assert.Equal(expectedSpatialText, model.SpatialText);
        Assert.Equal(expectedSpecializedChartParsing, model.SpecializedChartParsing);
        Assert.Equal(expectedTier, model.Tier);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::ParsingConf
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
            Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
            SpatialText = new()
            {
                DoNotUnrollColumns = true,
                PreserveLayoutAlignmentAcrossPages = true,
                PreserveVerySmallText = true,
            },
            SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
            Tier = Parsing::ParsingConfTier.Agentic,
            Version = Parsing::ParsingConfVersion.Latest,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ParsingConf>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::ParsingConf
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
            Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
            SpatialText = new()
            {
                DoNotUnrollColumns = true,
                PreserveLayoutAlignmentAcrossPages = true,
                PreserveVerySmallText = true,
            },
            SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
            Tier = Parsing::ParsingConfTier.Agentic,
            Version = Parsing::ParsingConfVersion.Latest,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ParsingConf>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAdaptiveLongTable = true;
        bool expectedAggressiveTableExtraction = true;
        Parsing::ParsingConfCropBox expectedCropBox = new()
        {
            Bottom = 0,
            Left = 0,
            Right = 0,
            Top = 0,
        };
        string expectedCustomPrompt = "custom_prompt";
        bool expectedExtractLayout = true;
        bool expectedHighResOcr = true;
        Parsing::Ignore expectedIgnore = new()
        {
            IgnoreDiagonalText = true,
            IgnoreHiddenText = true,
        };
        string expectedLanguage = "language";
        bool expectedOutlinedTableExtraction = true;
        Parsing::ParsingConfPresentation expectedPresentation = new()
        {
            OutOfBoundsContent = true,
            SkipEmbeddedData = true,
        };
        Parsing::ParsingConfSpatialText expectedSpatialText = new()
        {
            DoNotUnrollColumns = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
        };
        ApiEnum<string, Parsing::SpecializedChartParsing> expectedSpecializedChartParsing =
            Parsing::SpecializedChartParsing.Agentic;
        ApiEnum<string, Parsing::ParsingConfTier> expectedTier = Parsing::ParsingConfTier.Agentic;
        ApiEnum<string, Parsing::ParsingConfVersion> expectedVersion =
            Parsing::ParsingConfVersion.Latest;

        Assert.Equal(expectedAdaptiveLongTable, deserialized.AdaptiveLongTable);
        Assert.Equal(expectedAggressiveTableExtraction, deserialized.AggressiveTableExtraction);
        Assert.Equal(expectedCropBox, deserialized.CropBox);
        Assert.Equal(expectedCustomPrompt, deserialized.CustomPrompt);
        Assert.Equal(expectedExtractLayout, deserialized.ExtractLayout);
        Assert.Equal(expectedHighResOcr, deserialized.HighResOcr);
        Assert.Equal(expectedIgnore, deserialized.Ignore);
        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.Equal(expectedOutlinedTableExtraction, deserialized.OutlinedTableExtraction);
        Assert.Equal(expectedPresentation, deserialized.Presentation);
        Assert.Equal(expectedSpatialText, deserialized.SpatialText);
        Assert.Equal(expectedSpecializedChartParsing, deserialized.SpecializedChartParsing);
        Assert.Equal(expectedTier, deserialized.Tier);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::ParsingConf
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
            Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
            SpatialText = new()
            {
                DoNotUnrollColumns = true,
                PreserveLayoutAlignmentAcrossPages = true,
                PreserveVerySmallText = true,
            },
            SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
            Tier = Parsing::ParsingConfTier.Agentic,
            Version = Parsing::ParsingConfVersion.Latest,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::ParsingConf { };

        Assert.Null(model.AdaptiveLongTable);
        Assert.False(model.RawData.ContainsKey("adaptive_long_table"));
        Assert.Null(model.AggressiveTableExtraction);
        Assert.False(model.RawData.ContainsKey("aggressive_table_extraction"));
        Assert.Null(model.CropBox);
        Assert.False(model.RawData.ContainsKey("crop_box"));
        Assert.Null(model.CustomPrompt);
        Assert.False(model.RawData.ContainsKey("custom_prompt"));
        Assert.Null(model.ExtractLayout);
        Assert.False(model.RawData.ContainsKey("extract_layout"));
        Assert.Null(model.HighResOcr);
        Assert.False(model.RawData.ContainsKey("high_res_ocr"));
        Assert.Null(model.Ignore);
        Assert.False(model.RawData.ContainsKey("ignore"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.OutlinedTableExtraction);
        Assert.False(model.RawData.ContainsKey("outlined_table_extraction"));
        Assert.Null(model.Presentation);
        Assert.False(model.RawData.ContainsKey("presentation"));
        Assert.Null(model.SpatialText);
        Assert.False(model.RawData.ContainsKey("spatial_text"));
        Assert.Null(model.SpecializedChartParsing);
        Assert.False(model.RawData.ContainsKey("specialized_chart_parsing"));
        Assert.Null(model.Tier);
        Assert.False(model.RawData.ContainsKey("tier"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::ParsingConf { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::ParsingConf
        {
            AdaptiveLongTable = null,
            AggressiveTableExtraction = null,
            CropBox = null,
            CustomPrompt = null,
            ExtractLayout = null,
            HighResOcr = null,
            Ignore = null,
            Language = null,
            OutlinedTableExtraction = null,
            Presentation = null,
            SpatialText = null,
            SpecializedChartParsing = null,
            Tier = null,
            Version = null,
        };

        Assert.Null(model.AdaptiveLongTable);
        Assert.True(model.RawData.ContainsKey("adaptive_long_table"));
        Assert.Null(model.AggressiveTableExtraction);
        Assert.True(model.RawData.ContainsKey("aggressive_table_extraction"));
        Assert.Null(model.CropBox);
        Assert.True(model.RawData.ContainsKey("crop_box"));
        Assert.Null(model.CustomPrompt);
        Assert.True(model.RawData.ContainsKey("custom_prompt"));
        Assert.Null(model.ExtractLayout);
        Assert.True(model.RawData.ContainsKey("extract_layout"));
        Assert.Null(model.HighResOcr);
        Assert.True(model.RawData.ContainsKey("high_res_ocr"));
        Assert.Null(model.Ignore);
        Assert.True(model.RawData.ContainsKey("ignore"));
        Assert.Null(model.Language);
        Assert.True(model.RawData.ContainsKey("language"));
        Assert.Null(model.OutlinedTableExtraction);
        Assert.True(model.RawData.ContainsKey("outlined_table_extraction"));
        Assert.Null(model.Presentation);
        Assert.True(model.RawData.ContainsKey("presentation"));
        Assert.Null(model.SpatialText);
        Assert.True(model.RawData.ContainsKey("spatial_text"));
        Assert.Null(model.SpecializedChartParsing);
        Assert.True(model.RawData.ContainsKey("specialized_chart_parsing"));
        Assert.Null(model.Tier);
        Assert.True(model.RawData.ContainsKey("tier"));
        Assert.Null(model.Version);
        Assert.True(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::ParsingConf
        {
            AdaptiveLongTable = null,
            AggressiveTableExtraction = null,
            CropBox = null,
            CustomPrompt = null,
            ExtractLayout = null,
            HighResOcr = null,
            Ignore = null,
            Language = null,
            OutlinedTableExtraction = null,
            Presentation = null,
            SpatialText = null,
            SpecializedChartParsing = null,
            Tier = null,
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::ParsingConf
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
            Presentation = new() { OutOfBoundsContent = true, SkipEmbeddedData = true },
            SpatialText = new()
            {
                DoNotUnrollColumns = true,
                PreserveLayoutAlignmentAcrossPages = true,
                PreserveVerySmallText = true,
            },
            SpecializedChartParsing = Parsing::SpecializedChartParsing.Agentic,
            Tier = Parsing::ParsingConfTier.Agentic,
            Version = Parsing::ParsingConfVersion.Latest,
        };

        Parsing::ParsingConf copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ParsingConfCropBoxTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::ParsingConfCropBox
        {
            Bottom = 0,
            Left = 0,
            Right = 0,
            Top = 0,
        };

        double expectedBottom = 0;
        double expectedLeft = 0;
        double expectedRight = 0;
        double expectedTop = 0;

        Assert.Equal(expectedBottom, model.Bottom);
        Assert.Equal(expectedLeft, model.Left);
        Assert.Equal(expectedRight, model.Right);
        Assert.Equal(expectedTop, model.Top);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::ParsingConfCropBox
        {
            Bottom = 0,
            Left = 0,
            Right = 0,
            Top = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ParsingConfCropBox>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::ParsingConfCropBox
        {
            Bottom = 0,
            Left = 0,
            Right = 0,
            Top = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ParsingConfCropBox>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedBottom = 0;
        double expectedLeft = 0;
        double expectedRight = 0;
        double expectedTop = 0;

        Assert.Equal(expectedBottom, deserialized.Bottom);
        Assert.Equal(expectedLeft, deserialized.Left);
        Assert.Equal(expectedRight, deserialized.Right);
        Assert.Equal(expectedTop, deserialized.Top);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::ParsingConfCropBox
        {
            Bottom = 0,
            Left = 0,
            Right = 0,
            Top = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::ParsingConfCropBox { };

        Assert.Null(model.Bottom);
        Assert.False(model.RawData.ContainsKey("bottom"));
        Assert.Null(model.Left);
        Assert.False(model.RawData.ContainsKey("left"));
        Assert.Null(model.Right);
        Assert.False(model.RawData.ContainsKey("right"));
        Assert.Null(model.Top);
        Assert.False(model.RawData.ContainsKey("top"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::ParsingConfCropBox { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::ParsingConfCropBox
        {
            Bottom = null,
            Left = null,
            Right = null,
            Top = null,
        };

        Assert.Null(model.Bottom);
        Assert.True(model.RawData.ContainsKey("bottom"));
        Assert.Null(model.Left);
        Assert.True(model.RawData.ContainsKey("left"));
        Assert.Null(model.Right);
        Assert.True(model.RawData.ContainsKey("right"));
        Assert.Null(model.Top);
        Assert.True(model.RawData.ContainsKey("top"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::ParsingConfCropBox
        {
            Bottom = null,
            Left = null,
            Right = null,
            Top = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::ParsingConfCropBox
        {
            Bottom = 0,
            Left = 0,
            Right = 0,
            Top = 0,
        };

        Parsing::ParsingConfCropBox copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IgnoreTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::Ignore { IgnoreDiagonalText = true, IgnoreHiddenText = true };

        bool expectedIgnoreDiagonalText = true;
        bool expectedIgnoreHiddenText = true;

        Assert.Equal(expectedIgnoreDiagonalText, model.IgnoreDiagonalText);
        Assert.Equal(expectedIgnoreHiddenText, model.IgnoreHiddenText);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::Ignore { IgnoreDiagonalText = true, IgnoreHiddenText = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Ignore>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::Ignore { IgnoreDiagonalText = true, IgnoreHiddenText = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Ignore>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedIgnoreDiagonalText = true;
        bool expectedIgnoreHiddenText = true;

        Assert.Equal(expectedIgnoreDiagonalText, deserialized.IgnoreDiagonalText);
        Assert.Equal(expectedIgnoreHiddenText, deserialized.IgnoreHiddenText);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::Ignore { IgnoreDiagonalText = true, IgnoreHiddenText = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::Ignore { };

        Assert.Null(model.IgnoreDiagonalText);
        Assert.False(model.RawData.ContainsKey("ignore_diagonal_text"));
        Assert.Null(model.IgnoreHiddenText);
        Assert.False(model.RawData.ContainsKey("ignore_hidden_text"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::Ignore { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::Ignore { IgnoreDiagonalText = null, IgnoreHiddenText = null };

        Assert.Null(model.IgnoreDiagonalText);
        Assert.True(model.RawData.ContainsKey("ignore_diagonal_text"));
        Assert.Null(model.IgnoreHiddenText);
        Assert.True(model.RawData.ContainsKey("ignore_hidden_text"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::Ignore { IgnoreDiagonalText = null, IgnoreHiddenText = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::Ignore { IgnoreDiagonalText = true, IgnoreHiddenText = true };

        Parsing::Ignore copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ParsingConfPresentationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::ParsingConfPresentation
        {
            OutOfBoundsContent = true,
            SkipEmbeddedData = true,
        };

        bool expectedOutOfBoundsContent = true;
        bool expectedSkipEmbeddedData = true;

        Assert.Equal(expectedOutOfBoundsContent, model.OutOfBoundsContent);
        Assert.Equal(expectedSkipEmbeddedData, model.SkipEmbeddedData);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::ParsingConfPresentation
        {
            OutOfBoundsContent = true,
            SkipEmbeddedData = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ParsingConfPresentation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::ParsingConfPresentation
        {
            OutOfBoundsContent = true,
            SkipEmbeddedData = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ParsingConfPresentation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedOutOfBoundsContent = true;
        bool expectedSkipEmbeddedData = true;

        Assert.Equal(expectedOutOfBoundsContent, deserialized.OutOfBoundsContent);
        Assert.Equal(expectedSkipEmbeddedData, deserialized.SkipEmbeddedData);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::ParsingConfPresentation
        {
            OutOfBoundsContent = true,
            SkipEmbeddedData = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::ParsingConfPresentation { };

        Assert.Null(model.OutOfBoundsContent);
        Assert.False(model.RawData.ContainsKey("out_of_bounds_content"));
        Assert.Null(model.SkipEmbeddedData);
        Assert.False(model.RawData.ContainsKey("skip_embedded_data"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::ParsingConfPresentation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::ParsingConfPresentation
        {
            OutOfBoundsContent = null,
            SkipEmbeddedData = null,
        };

        Assert.Null(model.OutOfBoundsContent);
        Assert.True(model.RawData.ContainsKey("out_of_bounds_content"));
        Assert.Null(model.SkipEmbeddedData);
        Assert.True(model.RawData.ContainsKey("skip_embedded_data"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::ParsingConfPresentation
        {
            OutOfBoundsContent = null,
            SkipEmbeddedData = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::ParsingConfPresentation
        {
            OutOfBoundsContent = true,
            SkipEmbeddedData = true,
        };

        Parsing::ParsingConfPresentation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ParsingConfSpatialTextTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::ParsingConfSpatialText
        {
            DoNotUnrollColumns = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
        };

        bool expectedDoNotUnrollColumns = true;
        bool expectedPreserveLayoutAlignmentAcrossPages = true;
        bool expectedPreserveVerySmallText = true;

        Assert.Equal(expectedDoNotUnrollColumns, model.DoNotUnrollColumns);
        Assert.Equal(
            expectedPreserveLayoutAlignmentAcrossPages,
            model.PreserveLayoutAlignmentAcrossPages
        );
        Assert.Equal(expectedPreserveVerySmallText, model.PreserveVerySmallText);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::ParsingConfSpatialText
        {
            DoNotUnrollColumns = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ParsingConfSpatialText>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::ParsingConfSpatialText
        {
            DoNotUnrollColumns = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ParsingConfSpatialText>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedDoNotUnrollColumns = true;
        bool expectedPreserveLayoutAlignmentAcrossPages = true;
        bool expectedPreserveVerySmallText = true;

        Assert.Equal(expectedDoNotUnrollColumns, deserialized.DoNotUnrollColumns);
        Assert.Equal(
            expectedPreserveLayoutAlignmentAcrossPages,
            deserialized.PreserveLayoutAlignmentAcrossPages
        );
        Assert.Equal(expectedPreserveVerySmallText, deserialized.PreserveVerySmallText);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::ParsingConfSpatialText
        {
            DoNotUnrollColumns = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::ParsingConfSpatialText { };

        Assert.Null(model.DoNotUnrollColumns);
        Assert.False(model.RawData.ContainsKey("do_not_unroll_columns"));
        Assert.Null(model.PreserveLayoutAlignmentAcrossPages);
        Assert.False(model.RawData.ContainsKey("preserve_layout_alignment_across_pages"));
        Assert.Null(model.PreserveVerySmallText);
        Assert.False(model.RawData.ContainsKey("preserve_very_small_text"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::ParsingConfSpatialText { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::ParsingConfSpatialText
        {
            DoNotUnrollColumns = null,
            PreserveLayoutAlignmentAcrossPages = null,
            PreserveVerySmallText = null,
        };

        Assert.Null(model.DoNotUnrollColumns);
        Assert.True(model.RawData.ContainsKey("do_not_unroll_columns"));
        Assert.Null(model.PreserveLayoutAlignmentAcrossPages);
        Assert.True(model.RawData.ContainsKey("preserve_layout_alignment_across_pages"));
        Assert.Null(model.PreserveVerySmallText);
        Assert.True(model.RawData.ContainsKey("preserve_very_small_text"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::ParsingConfSpatialText
        {
            DoNotUnrollColumns = null,
            PreserveLayoutAlignmentAcrossPages = null,
            PreserveVerySmallText = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::ParsingConfSpatialText
        {
            DoNotUnrollColumns = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
        };

        Parsing::ParsingConfSpatialText copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SpecializedChartParsingTest : TestBase
{
    [Theory]
    [InlineData(Parsing::SpecializedChartParsing.Agentic)]
    [InlineData(Parsing::SpecializedChartParsing.AgenticPlus)]
    [InlineData(Parsing::SpecializedChartParsing.Efficient)]
    public void Validation_Works(Parsing::SpecializedChartParsing rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::SpecializedChartParsing> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::SpecializedChartParsing>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Parsing::SpecializedChartParsing.Agentic)]
    [InlineData(Parsing::SpecializedChartParsing.AgenticPlus)]
    [InlineData(Parsing::SpecializedChartParsing.Efficient)]
    public void SerializationRoundtrip_Works(Parsing::SpecializedChartParsing rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::SpecializedChartParsing> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Parsing::SpecializedChartParsing>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::SpecializedChartParsing>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Parsing::SpecializedChartParsing>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ParsingConfTierTest : TestBase
{
    [Theory]
    [InlineData(Parsing::ParsingConfTier.Agentic)]
    [InlineData(Parsing::ParsingConfTier.AgenticPlus)]
    [InlineData(Parsing::ParsingConfTier.CostEffective)]
    [InlineData(Parsing::ParsingConfTier.Fast)]
    public void Validation_Works(Parsing::ParsingConfTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::ParsingConfTier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::ParsingConfTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Parsing::ParsingConfTier.Agentic)]
    [InlineData(Parsing::ParsingConfTier.AgenticPlus)]
    [InlineData(Parsing::ParsingConfTier.CostEffective)]
    [InlineData(Parsing::ParsingConfTier.Fast)]
    public void SerializationRoundtrip_Works(Parsing::ParsingConfTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::ParsingConfTier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::ParsingConfTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::ParsingConfTier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::ParsingConfTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ParsingConfVersionTest : TestBase
{
    [Theory]
    [InlineData(Parsing::ParsingConfVersion.Latest)]
    [InlineData(Parsing::ParsingConfVersion.V2026_08_19)]
    [InlineData(Parsing::ParsingConfVersion.V2026_06_15)]
    public void Validation_Works(Parsing::ParsingConfVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::ParsingConfVersion> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::ParsingConfVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Parsing::ParsingConfVersion.Latest)]
    [InlineData(Parsing::ParsingConfVersion.V2026_08_19)]
    [InlineData(Parsing::ParsingConfVersion.V2026_06_15)]
    public void SerializationRoundtrip_Works(Parsing::ParsingConfVersion rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::ParsingConfVersion> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::ParsingConfVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::ParsingConfVersion>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::ParsingConfVersion>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FullPageImageInPageThresholdTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Parsing::FullPageImageInPageThreshold value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::FullPageImageInPageThreshold value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Parsing::FullPageImageInPageThreshold value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::FullPageImageInPageThreshold>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::FullPageImageInPageThreshold value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::FullPageImageInPageThreshold>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class LayoutElementInPageConfidenceThresholdTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        Parsing::LayoutElementInPageConfidenceThreshold value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::LayoutElementInPageConfidenceThreshold value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Parsing::LayoutElementInPageConfidenceThreshold value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Parsing::LayoutElementInPageConfidenceThreshold>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::LayoutElementInPageConfidenceThreshold value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Parsing::LayoutElementInPageConfidenceThreshold>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtLeastNChartsTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtLeastNCharts value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtLeastNCharts value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNCharts value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNCharts>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNCharts value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNCharts>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtLeastNImagesTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtLeastNImages value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtLeastNImages value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNImages value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNImages>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNImages value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNImages>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtLeastNLayoutElementsTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtLeastNLayoutElements value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtLeastNLayoutElements value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNLayoutElements value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNLayoutElements>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNLayoutElements value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNLayoutElements>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtLeastNLinesTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtLeastNLines value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtLeastNLines value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNLines value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNLines>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNLines value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNLines>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtLeastNLinksTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtLeastNLinks value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtLeastNLinks value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNLinks value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNLinks>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNLinks value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNLinks>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtLeastNNumbersTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtLeastNNumbers value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtLeastNNumbers value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNNumbers value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNNumbers>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNNumbers value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNNumbers>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtLeastNPercentNumbersTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtLeastNPercentNumbers value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtLeastNPercentNumbers value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNPercentNumbers value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNPercentNumbers>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNPercentNumbers value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNPercentNumbers>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtLeastNTablesTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtLeastNTables value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtLeastNTables value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNTables value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNTables>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNTables value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNTables>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtLeastNWordsTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtLeastNWords value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtLeastNWords value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNWords value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNWords>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtLeastNWords value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtLeastNWords>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtMostNChartsTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtMostNCharts value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtMostNCharts value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNCharts value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNCharts>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNCharts value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNCharts>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtMostNImagesTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtMostNImages value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtMostNImages value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNImages value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNImages>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNImages value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNImages>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtMostNLayoutElementsTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtMostNLayoutElements value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtMostNLayoutElements value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNLayoutElements value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNLayoutElements>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNLayoutElements value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNLayoutElements>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtMostNLinesTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtMostNLines value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtMostNLines value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNLines value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNLines>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNLines value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNLines>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtMostNLinksTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtMostNLinks value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtMostNLinks value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNLinks value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNLinks>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNLinks value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNLinks>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtMostNNumbersTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtMostNNumbers value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtMostNNumbers value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNNumbers value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNNumbers>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNNumbers value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNNumbers>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtMostNPercentNumbersTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtMostNPercentNumbers value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtMostNPercentNumbers value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNPercentNumbers value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNPercentNumbers>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNPercentNumbers value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNPercentNumbers>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtMostNTablesTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtMostNTables value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtMostNTables value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNTables value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNTables>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNTables value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNTables>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageContainsAtMostNWordsTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageContainsAtMostNWords value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageContainsAtMostNWords value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNWords value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNWords>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageContainsAtMostNWords value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageContainsAtMostNWords>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageLongerThanNCharsTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageLongerThanNChars value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageLongerThanNChars value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageLongerThanNChars value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageLongerThanNChars>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageLongerThanNChars value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageLongerThanNChars>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PageShorterThanNCharsTest : TestBase
{
    [Fact]
    public void LongValidationWorks()
    {
        Parsing::PageShorterThanNChars value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Parsing::PageShorterThanNChars value = "string";
        value.Validate();
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        Parsing::PageShorterThanNChars value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageShorterThanNChars>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Parsing::PageShorterThanNChars value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::PageShorterThanNChars>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ConfidenceScoreEffortTest : TestBase
{
    [Theory]
    [InlineData(Parsing::ConfidenceScoreEffort.High)]
    public void Validation_Works(Parsing::ConfidenceScoreEffort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::ConfidenceScoreEffort> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::ConfidenceScoreEffort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Parsing::ConfidenceScoreEffort.High)]
    public void SerializationRoundtrip_Works(Parsing::ConfidenceScoreEffort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::ConfidenceScoreEffort> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Parsing::ConfidenceScoreEffort>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::ConfidenceScoreEffort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Parsing::ConfidenceScoreEffort>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CostOptimizerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::CostOptimizer { Enable = true };

        bool expectedEnable = true;

        Assert.Equal(expectedEnable, model.Enable);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::CostOptimizer { Enable = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::CostOptimizer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::CostOptimizer { Enable = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::CostOptimizer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedEnable = true;

        Assert.Equal(expectedEnable, deserialized.Enable);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::CostOptimizer { Enable = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::CostOptimizer { };

        Assert.Null(model.Enable);
        Assert.False(model.RawData.ContainsKey("enable"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::CostOptimizer { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::CostOptimizer { Enable = null };

        Assert.Null(model.Enable);
        Assert.True(model.RawData.ContainsKey("enable"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::CostOptimizer { Enable = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::CostOptimizer { Enable = true };

        Parsing::CostOptimizer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FormsTest : TestBase
{
    [Theory]
    [InlineData(Parsing::Forms.Default)]
    [InlineData(Parsing::Forms.Enrich)]
    public void Validation_Works(Parsing::Forms rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::Forms> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::Forms>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Parsing::Forms.Default)]
    [InlineData(Parsing::Forms.Enrich)]
    public void SerializationRoundtrip_Works(Parsing::Forms rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::Forms> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::Forms>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::Forms>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::Forms>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ProcessingOptionsIgnoreTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::ProcessingOptionsIgnore
        {
            IgnoreDiagonalText = true,
            IgnoreHiddenText = true,
            IgnoreTextInImage = true,
        };

        bool expectedIgnoreDiagonalText = true;
        bool expectedIgnoreHiddenText = true;
        bool expectedIgnoreTextInImage = true;

        Assert.Equal(expectedIgnoreDiagonalText, model.IgnoreDiagonalText);
        Assert.Equal(expectedIgnoreHiddenText, model.IgnoreHiddenText);
        Assert.Equal(expectedIgnoreTextInImage, model.IgnoreTextInImage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::ProcessingOptionsIgnore
        {
            IgnoreDiagonalText = true,
            IgnoreHiddenText = true,
            IgnoreTextInImage = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ProcessingOptionsIgnore>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::ProcessingOptionsIgnore
        {
            IgnoreDiagonalText = true,
            IgnoreHiddenText = true,
            IgnoreTextInImage = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ProcessingOptionsIgnore>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedIgnoreDiagonalText = true;
        bool expectedIgnoreHiddenText = true;
        bool expectedIgnoreTextInImage = true;

        Assert.Equal(expectedIgnoreDiagonalText, deserialized.IgnoreDiagonalText);
        Assert.Equal(expectedIgnoreHiddenText, deserialized.IgnoreHiddenText);
        Assert.Equal(expectedIgnoreTextInImage, deserialized.IgnoreTextInImage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::ProcessingOptionsIgnore
        {
            IgnoreDiagonalText = true,
            IgnoreHiddenText = true,
            IgnoreTextInImage = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::ProcessingOptionsIgnore { };

        Assert.Null(model.IgnoreDiagonalText);
        Assert.False(model.RawData.ContainsKey("ignore_diagonal_text"));
        Assert.Null(model.IgnoreHiddenText);
        Assert.False(model.RawData.ContainsKey("ignore_hidden_text"));
        Assert.Null(model.IgnoreTextInImage);
        Assert.False(model.RawData.ContainsKey("ignore_text_in_image"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::ProcessingOptionsIgnore { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::ProcessingOptionsIgnore
        {
            IgnoreDiagonalText = null,
            IgnoreHiddenText = null,
            IgnoreTextInImage = null,
        };

        Assert.Null(model.IgnoreDiagonalText);
        Assert.True(model.RawData.ContainsKey("ignore_diagonal_text"));
        Assert.Null(model.IgnoreHiddenText);
        Assert.True(model.RawData.ContainsKey("ignore_hidden_text"));
        Assert.Null(model.IgnoreTextInImage);
        Assert.True(model.RawData.ContainsKey("ignore_text_in_image"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::ProcessingOptionsIgnore
        {
            IgnoreDiagonalText = null,
            IgnoreHiddenText = null,
            IgnoreTextInImage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::ProcessingOptionsIgnore
        {
            IgnoreDiagonalText = true,
            IgnoreHiddenText = true,
            IgnoreTextInImage = true,
        };

        Parsing::ProcessingOptionsIgnore copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OcrParametersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::OcrParameters { Languages = [Parsing::ParsingLanguages.Abq] };

        List<ApiEnum<string, Parsing::ParsingLanguages>> expectedLanguages =
        [
            Parsing::ParsingLanguages.Abq,
        ];

        Assert.NotNull(model.Languages);
        Assert.Equal(expectedLanguages.Count, model.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], model.Languages[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::OcrParameters { Languages = [Parsing::ParsingLanguages.Abq] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::OcrParameters>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::OcrParameters { Languages = [Parsing::ParsingLanguages.Abq] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::OcrParameters>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ApiEnum<string, Parsing::ParsingLanguages>> expectedLanguages =
        [
            Parsing::ParsingLanguages.Abq,
        ];

        Assert.NotNull(deserialized.Languages);
        Assert.Equal(expectedLanguages.Count, deserialized.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], deserialized.Languages[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::OcrParameters { Languages = [Parsing::ParsingLanguages.Abq] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::OcrParameters { };

        Assert.Null(model.Languages);
        Assert.False(model.RawData.ContainsKey("languages"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::OcrParameters { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::OcrParameters { Languages = null };

        Assert.Null(model.Languages);
        Assert.True(model.RawData.ContainsKey("languages"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::OcrParameters { Languages = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::OcrParameters { Languages = [Parsing::ParsingLanguages.Abq] };

        Parsing::OcrParameters copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProcessingOptionsSpecializedChartParsingTest : TestBase
{
    [Theory]
    [InlineData(Parsing::ProcessingOptionsSpecializedChartParsing.Agentic)]
    [InlineData(Parsing::ProcessingOptionsSpecializedChartParsing.AgenticPlus)]
    [InlineData(Parsing::ProcessingOptionsSpecializedChartParsing.Efficient)]
    public void Validation_Works(Parsing::ProcessingOptionsSpecializedChartParsing rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::ProcessingOptionsSpecializedChartParsing> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Parsing::ProcessingOptionsSpecializedChartParsing>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Parsing::ProcessingOptionsSpecializedChartParsing.Agentic)]
    [InlineData(Parsing::ProcessingOptionsSpecializedChartParsing.AgenticPlus)]
    [InlineData(Parsing::ProcessingOptionsSpecializedChartParsing.Efficient)]
    public void SerializationRoundtrip_Works(
        Parsing::ProcessingOptionsSpecializedChartParsing rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::ProcessingOptionsSpecializedChartParsing> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Parsing::ProcessingOptionsSpecializedChartParsing>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Parsing::ProcessingOptionsSpecializedChartParsing>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Parsing::ProcessingOptionsSpecializedChartParsing>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class WebhookConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::WebhookConfiguration
        {
            WebhookEvents = ["parse.success", "parse.error"],
            WebhookHeaders = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            WebhookOutputFormat = Parsing::WebhookOutputFormat.Json,
            WebhookSigningSecret = "webhook_signing_secret",
            WebhookUrl = "https:",
        };

        List<string> expectedWebhookEvents = ["parse.success", "parse.error"];
        Dictionary<string, JsonElement> expectedWebhookHeaders = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, Parsing::WebhookOutputFormat> expectedWebhookOutputFormat =
            Parsing::WebhookOutputFormat.Json;
        string expectedWebhookSigningSecret = "webhook_signing_secret";
        string expectedWebhookUrl = "https:";

        Assert.NotNull(model.WebhookEvents);
        Assert.Equal(expectedWebhookEvents.Count, model.WebhookEvents.Count);
        for (int i = 0; i < expectedWebhookEvents.Count; i++)
        {
            Assert.Equal(expectedWebhookEvents[i], model.WebhookEvents[i]);
        }
        Assert.NotNull(model.WebhookHeaders);
        Assert.Equal(expectedWebhookHeaders.Count, model.WebhookHeaders.Count);
        foreach (var item in expectedWebhookHeaders)
        {
            Assert.True(model.WebhookHeaders.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.WebhookHeaders[item.Key]));
        }
        Assert.Equal(expectedWebhookOutputFormat, model.WebhookOutputFormat);
        Assert.Equal(expectedWebhookSigningSecret, model.WebhookSigningSecret);
        Assert.Equal(expectedWebhookUrl, model.WebhookUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::WebhookConfiguration
        {
            WebhookEvents = ["parse.success", "parse.error"],
            WebhookHeaders = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            WebhookOutputFormat = Parsing::WebhookOutputFormat.Json,
            WebhookSigningSecret = "webhook_signing_secret",
            WebhookUrl = "https:",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::WebhookConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::WebhookConfiguration
        {
            WebhookEvents = ["parse.success", "parse.error"],
            WebhookHeaders = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            WebhookOutputFormat = Parsing::WebhookOutputFormat.Json,
            WebhookSigningSecret = "webhook_signing_secret",
            WebhookUrl = "https:",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::WebhookConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedWebhookEvents = ["parse.success", "parse.error"];
        Dictionary<string, JsonElement> expectedWebhookHeaders = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, Parsing::WebhookOutputFormat> expectedWebhookOutputFormat =
            Parsing::WebhookOutputFormat.Json;
        string expectedWebhookSigningSecret = "webhook_signing_secret";
        string expectedWebhookUrl = "https:";

        Assert.NotNull(deserialized.WebhookEvents);
        Assert.Equal(expectedWebhookEvents.Count, deserialized.WebhookEvents.Count);
        for (int i = 0; i < expectedWebhookEvents.Count; i++)
        {
            Assert.Equal(expectedWebhookEvents[i], deserialized.WebhookEvents[i]);
        }
        Assert.NotNull(deserialized.WebhookHeaders);
        Assert.Equal(expectedWebhookHeaders.Count, deserialized.WebhookHeaders.Count);
        foreach (var item in expectedWebhookHeaders)
        {
            Assert.True(deserialized.WebhookHeaders.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.WebhookHeaders[item.Key]));
        }
        Assert.Equal(expectedWebhookOutputFormat, deserialized.WebhookOutputFormat);
        Assert.Equal(expectedWebhookSigningSecret, deserialized.WebhookSigningSecret);
        Assert.Equal(expectedWebhookUrl, deserialized.WebhookUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::WebhookConfiguration
        {
            WebhookEvents = ["parse.success", "parse.error"],
            WebhookHeaders = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            WebhookOutputFormat = Parsing::WebhookOutputFormat.Json,
            WebhookSigningSecret = "webhook_signing_secret",
            WebhookUrl = "https:",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::WebhookConfiguration { };

        Assert.Null(model.WebhookEvents);
        Assert.False(model.RawData.ContainsKey("webhook_events"));
        Assert.Null(model.WebhookHeaders);
        Assert.False(model.RawData.ContainsKey("webhook_headers"));
        Assert.Null(model.WebhookOutputFormat);
        Assert.False(model.RawData.ContainsKey("webhook_output_format"));
        Assert.Null(model.WebhookSigningSecret);
        Assert.False(model.RawData.ContainsKey("webhook_signing_secret"));
        Assert.Null(model.WebhookUrl);
        Assert.False(model.RawData.ContainsKey("webhook_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::WebhookConfiguration { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::WebhookConfiguration
        {
            WebhookEvents = null,
            WebhookHeaders = null,
            WebhookOutputFormat = null,
            WebhookSigningSecret = null,
            WebhookUrl = null,
        };

        Assert.Null(model.WebhookEvents);
        Assert.True(model.RawData.ContainsKey("webhook_events"));
        Assert.Null(model.WebhookHeaders);
        Assert.True(model.RawData.ContainsKey("webhook_headers"));
        Assert.Null(model.WebhookOutputFormat);
        Assert.True(model.RawData.ContainsKey("webhook_output_format"));
        Assert.Null(model.WebhookSigningSecret);
        Assert.True(model.RawData.ContainsKey("webhook_signing_secret"));
        Assert.Null(model.WebhookUrl);
        Assert.True(model.RawData.ContainsKey("webhook_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::WebhookConfiguration
        {
            WebhookEvents = null,
            WebhookHeaders = null,
            WebhookOutputFormat = null,
            WebhookSigningSecret = null,
            WebhookUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::WebhookConfiguration
        {
            WebhookEvents = ["parse.success", "parse.error"],
            WebhookHeaders = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            WebhookOutputFormat = Parsing::WebhookOutputFormat.Json,
            WebhookSigningSecret = "webhook_signing_secret",
            WebhookUrl = "https:",
        };

        Parsing::WebhookConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookOutputFormatTest : TestBase
{
    [Theory]
    [InlineData(Parsing::WebhookOutputFormat.Json)]
    [InlineData(Parsing::WebhookOutputFormat.String)]
    public void Validation_Works(Parsing::WebhookOutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::WebhookOutputFormat> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::WebhookOutputFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Parsing::WebhookOutputFormat.Json)]
    [InlineData(Parsing::WebhookOutputFormat.String)]
    public void SerializationRoundtrip_Works(Parsing::WebhookOutputFormat rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::WebhookOutputFormat> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Parsing::WebhookOutputFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::WebhookOutputFormat>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Parsing::WebhookOutputFormat>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
