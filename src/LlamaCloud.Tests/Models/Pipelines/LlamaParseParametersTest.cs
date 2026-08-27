using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Pipelines;
using Parsing = LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Pipelines;

public class LlamaParseParametersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LlamaParseParameters
        {
            AdaptiveLongTable = true,
            AggressiveTableExtraction = true,
            AnnotateLineNumbers = true,
            AnnotateLinks = true,
            AnnotateRevisions = true,
            AutoMode = true,
            AutoModeConfigurationJson = "auto_mode_configuration_json",
            AutoModeTriggerOnImageInPage = true,
            AutoModeTriggerOnRegexpInPage = "auto_mode_trigger_on_regexp_in_page",
            AutoModeTriggerOnTableInPage = true,
            AutoModeTriggerOnTextInPage = "auto_mode_trigger_on_text_in_page",
            AzureOpenAIApiVersion = "azure_openai_api_version",
            AzureOpenAIDeploymentName = "azure_openai_deployment_name",
            AzureOpenAIEndpoint = "azure_openai_endpoint",
            AzureOpenAIKey = "azure_openai_key",
            BboxBottom = 0,
            BboxLeft = 0,
            BboxRight = 0,
            BboxTop = 0,
            BoundingBox = "bounding_box",
            CompactMarkdownTable = true,
            ComplementalFormattingInstruction = "complemental_formatting_instruction",
            ConfidenceScoreEffort = "confidence_score_effort",
            ContentGuidelineInstruction = "content_guideline_instruction",
            ContinuousMode = true,
            DisableImageExtraction = true,
            DisableOcr = true,
            DisableReconstruction = true,
            DoNotCache = true,
            DoNotUnrollColumns = true,
            EnableCostOptimizer = true,
            ExtractCharts = true,
            ExtractLayout = true,
            ExtractPrintedPageNumber = true,
            FastMode = true,
            FormattingInstruction = "formatting_instruction",
            Gpt4oApiKey = "gpt4o_api_key",
            Gpt4oMode = true,
            GuessXlsxSheetName = true,
            HideFooters = true,
            HideHeaders = true,
            HighResOcr = true,
            HtmlMakeAllElementsVisible = true,
            HtmlRemoveFixedElements = true,
            HtmlRemoveNavigationElements = true,
            HttpProxy = "http_proxy",
            IgnoreDocumentElementsForLayoutDetection = true,
            ImagesToSave = [ImagesToSave.Embedded],
            InlineImagesInMarkdown = true,
            InputS3Path = "input_s3_path",
            InputS3Region = "input_s3_region",
            InputUrl = "input_url",
            InternalIsScreenshotJob = true,
            InvalidateCache = true,
            IsFormattingInstruction = true,
            JobTimeoutExtraTimePerPageInSeconds = 0,
            JobTimeoutInSeconds = 0,
            KeepPageSeparatorWhenMergingTables = true,
            Languages = [Parsing::ParsingLanguages.Abq],
            LayoutAware = true,
            LineLevelBoundingBox = true,
            MarkdownTableMultilineHeaderSeparator = "markdown_table_multiline_header_separator",
            MaxPages = 0,
            MaxPagesEnforced = 0,
            MergeTablesAcrossPagesInMarkdown = true,
            Model = "model",
            OutlinedTableExtraction = true,
            OutputPdfOfDocument = true,
            OutputS3PathPrefix = "output_s3_path_prefix",
            OutputS3Region = "output_s3_region",
            OutputTablesAsHtml = true,
            PageErrorTolerance = 0,
            PageFooterPrefix = "page_footer_prefix",
            PageFooterSuffix = "page_footer_suffix",
            PageHeaderPrefix = "page_header_prefix",
            PageHeaderSuffix = "page_header_suffix",
            PagePrefix = "page_prefix",
            PageSeparator = "page_separator",
            PageSuffix = "page_suffix",
            ParseMode = Parsing::ParsingMode.ParseDocumentWithAgent,
            ParsingInstruction = "parsing_instruction",
            PreciseBoundingBox = true,
            PremiumMode = true,
            PresentationOutOfBoundsContent = true,
            PresentationSkipEmbeddedData = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
            Preset = "preset",
            Priority = Priority.Critical,
            ProjectID = "project_id",
            RemoveHiddenText = true,
            ReplaceFailedPageMode = Parsing::FailPageMode.BlankPage,
            ReplaceFailedPageWithErrorMessagePrefix =
                "replace_failed_page_with_error_message_prefix",
            ReplaceFailedPageWithErrorMessageSuffix =
                "replace_failed_page_with_error_message_suffix",
            SaveImages = true,
            SkipDiagonalText = true,
            SpecializedChartParsingAgentic = true,
            SpecializedChartParsingEfficient = true,
            SpecializedChartParsingPlus = true,
            SpecializedImageParsing = true,
            SpreadsheetExtractSubTables = true,
            SpreadsheetForceFormulaComputation = true,
            SpreadsheetIncludeHiddenSheets = true,
            StrictModeBuggyFont = true,
            StrictModeImageExtraction = true,
            StrictModeImageOcr = true,
            StrictModeReconstruction = true,
            StructuredOutput = true,
            StructuredOutputJsonSchema = "structured_output_json_schema",
            StructuredOutputJsonSchemaName = "structured_output_json_schema_name",
            SystemPrompt = "system_prompt",
            SystemPromptAppend = "system_prompt_append",
            TakeScreenshot = true,
            TargetPages = "target_pages",
            Tier = "tier",
            UseVendorMultimodalModel = true,
            UserPrompt = "user_prompt",
            VendorMultimodalApiKey = "vendor_multimodal_api_key",
            VendorMultimodalModelName = "vendor_multimodal_model_name",
            Version = "version",
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
                    WebhookHeaders = new Dictionary<string, string>()
                    {
                        { "Authorization", "Bearer sk-..." },
                    },
                    WebhookOutputFormat = "json",
                    WebhookSigningSecret = "whsec_...",
                    WebhookUrl = "https://example.com/webhooks/llamacloud",
                },
            ],
            WebhookUrl = "webhook_url",
        };

        bool expectedAdaptiveLongTable = true;
        bool expectedAggressiveTableExtraction = true;
        bool expectedAnnotateLineNumbers = true;
        bool expectedAnnotateLinks = true;
        bool expectedAnnotateRevisions = true;
        bool expectedAutoMode = true;
        string expectedAutoModeConfigurationJson = "auto_mode_configuration_json";
        bool expectedAutoModeTriggerOnImageInPage = true;
        string expectedAutoModeTriggerOnRegexpInPage = "auto_mode_trigger_on_regexp_in_page";
        bool expectedAutoModeTriggerOnTableInPage = true;
        string expectedAutoModeTriggerOnTextInPage = "auto_mode_trigger_on_text_in_page";
        string expectedAzureOpenAIApiVersion = "azure_openai_api_version";
        string expectedAzureOpenAIDeploymentName = "azure_openai_deployment_name";
        string expectedAzureOpenAIEndpoint = "azure_openai_endpoint";
        string expectedAzureOpenAIKey = "azure_openai_key";
        double expectedBboxBottom = 0;
        double expectedBboxLeft = 0;
        double expectedBboxRight = 0;
        double expectedBboxTop = 0;
        string expectedBoundingBox = "bounding_box";
        bool expectedCompactMarkdownTable = true;
        string expectedComplementalFormattingInstruction = "complemental_formatting_instruction";
        string expectedConfidenceScoreEffort = "confidence_score_effort";
        string expectedContentGuidelineInstruction = "content_guideline_instruction";
        bool expectedContinuousMode = true;
        bool expectedDisableImageExtraction = true;
        bool expectedDisableOcr = true;
        bool expectedDisableReconstruction = true;
        bool expectedDoNotCache = true;
        bool expectedDoNotUnrollColumns = true;
        bool expectedEnableCostOptimizer = true;
        bool expectedExtractCharts = true;
        bool expectedExtractLayout = true;
        bool expectedExtractPrintedPageNumber = true;
        bool expectedFastMode = true;
        string expectedFormattingInstruction = "formatting_instruction";
        string expectedGpt4oApiKey = "gpt4o_api_key";
        bool expectedGpt4oMode = true;
        bool expectedGuessXlsxSheetName = true;
        bool expectedHideFooters = true;
        bool expectedHideHeaders = true;
        bool expectedHighResOcr = true;
        bool expectedHtmlMakeAllElementsVisible = true;
        bool expectedHtmlRemoveFixedElements = true;
        bool expectedHtmlRemoveNavigationElements = true;
        string expectedHttpProxy = "http_proxy";
        bool expectedIgnoreDocumentElementsForLayoutDetection = true;
        List<ApiEnum<string, ImagesToSave>> expectedImagesToSave = [ImagesToSave.Embedded];
        bool expectedInlineImagesInMarkdown = true;
        string expectedInputS3Path = "input_s3_path";
        string expectedInputS3Region = "input_s3_region";
        string expectedInputUrl = "input_url";
        bool expectedInternalIsScreenshotJob = true;
        bool expectedInvalidateCache = true;
        bool expectedIsFormattingInstruction = true;
        double expectedJobTimeoutExtraTimePerPageInSeconds = 0;
        double expectedJobTimeoutInSeconds = 0;
        bool expectedKeepPageSeparatorWhenMergingTables = true;
        List<ApiEnum<string, Parsing::ParsingLanguages>> expectedLanguages =
        [
            Parsing::ParsingLanguages.Abq,
        ];
        bool expectedLayoutAware = true;
        bool expectedLineLevelBoundingBox = true;
        string expectedMarkdownTableMultilineHeaderSeparator =
            "markdown_table_multiline_header_separator";
        long expectedMaxPages = 0;
        long expectedMaxPagesEnforced = 0;
        bool expectedMergeTablesAcrossPagesInMarkdown = true;
        string expectedModel = "model";
        bool expectedOutlinedTableExtraction = true;
        bool expectedOutputPdfOfDocument = true;
        string expectedOutputS3PathPrefix = "output_s3_path_prefix";
        string expectedOutputS3Region = "output_s3_region";
        bool expectedOutputTablesAsHtml = true;
        double expectedPageErrorTolerance = 0;
        string expectedPageFooterPrefix = "page_footer_prefix";
        string expectedPageFooterSuffix = "page_footer_suffix";
        string expectedPageHeaderPrefix = "page_header_prefix";
        string expectedPageHeaderSuffix = "page_header_suffix";
        string expectedPagePrefix = "page_prefix";
        string expectedPageSeparator = "page_separator";
        string expectedPageSuffix = "page_suffix";
        ApiEnum<string, Parsing::ParsingMode> expectedParseMode =
            Parsing::ParsingMode.ParseDocumentWithAgent;
        string expectedParsingInstruction = "parsing_instruction";
        bool expectedPreciseBoundingBox = true;
        bool expectedPremiumMode = true;
        bool expectedPresentationOutOfBoundsContent = true;
        bool expectedPresentationSkipEmbeddedData = true;
        bool expectedPreserveLayoutAlignmentAcrossPages = true;
        bool expectedPreserveVerySmallText = true;
        string expectedPreset = "preset";
        ApiEnum<string, Priority> expectedPriority = Priority.Critical;
        string expectedProjectID = "project_id";
        bool expectedRemoveHiddenText = true;
        ApiEnum<string, Parsing::FailPageMode> expectedReplaceFailedPageMode =
            Parsing::FailPageMode.BlankPage;
        string expectedReplaceFailedPageWithErrorMessagePrefix =
            "replace_failed_page_with_error_message_prefix";
        string expectedReplaceFailedPageWithErrorMessageSuffix =
            "replace_failed_page_with_error_message_suffix";
        bool expectedSaveImages = true;
        bool expectedSkipDiagonalText = true;
        bool expectedSpecializedChartParsingAgentic = true;
        bool expectedSpecializedChartParsingEfficient = true;
        bool expectedSpecializedChartParsingPlus = true;
        bool expectedSpecializedImageParsing = true;
        bool expectedSpreadsheetExtractSubTables = true;
        bool expectedSpreadsheetForceFormulaComputation = true;
        bool expectedSpreadsheetIncludeHiddenSheets = true;
        bool expectedStrictModeBuggyFont = true;
        bool expectedStrictModeImageExtraction = true;
        bool expectedStrictModeImageOcr = true;
        bool expectedStrictModeReconstruction = true;
        bool expectedStructuredOutput = true;
        string expectedStructuredOutputJsonSchema = "structured_output_json_schema";
        string expectedStructuredOutputJsonSchemaName = "structured_output_json_schema_name";
        string expectedSystemPrompt = "system_prompt";
        string expectedSystemPromptAppend = "system_prompt_append";
        bool expectedTakeScreenshot = true;
        string expectedTargetPages = "target_pages";
        string expectedTier = "tier";
        bool expectedUseVendorMultimodalModel = true;
        string expectedUserPrompt = "user_prompt";
        string expectedVendorMultimodalApiKey = "vendor_multimodal_api_key";
        string expectedVendorMultimodalModelName = "vendor_multimodal_model_name";
        string expectedVersion = "version";
        List<WebhookConfiguration> expectedWebhookConfigurations =
        [
            new()
            {
                WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
                WebhookHeaders = new Dictionary<string, string>()
                {
                    { "Authorization", "Bearer sk-..." },
                },
                WebhookOutputFormat = "json",
                WebhookSigningSecret = "whsec_...",
                WebhookUrl = "https://example.com/webhooks/llamacloud",
            },
        ];
        string expectedWebhookUrl = "webhook_url";

        Assert.Equal(expectedAdaptiveLongTable, model.AdaptiveLongTable);
        Assert.Equal(expectedAggressiveTableExtraction, model.AggressiveTableExtraction);
        Assert.Equal(expectedAnnotateLineNumbers, model.AnnotateLineNumbers);
        Assert.Equal(expectedAnnotateLinks, model.AnnotateLinks);
        Assert.Equal(expectedAnnotateRevisions, model.AnnotateRevisions);
        Assert.Equal(expectedAutoMode, model.AutoMode);
        Assert.Equal(expectedAutoModeConfigurationJson, model.AutoModeConfigurationJson);
        Assert.Equal(expectedAutoModeTriggerOnImageInPage, model.AutoModeTriggerOnImageInPage);
        Assert.Equal(expectedAutoModeTriggerOnRegexpInPage, model.AutoModeTriggerOnRegexpInPage);
        Assert.Equal(expectedAutoModeTriggerOnTableInPage, model.AutoModeTriggerOnTableInPage);
        Assert.Equal(expectedAutoModeTriggerOnTextInPage, model.AutoModeTriggerOnTextInPage);
        Assert.Equal(expectedAzureOpenAIApiVersion, model.AzureOpenAIApiVersion);
        Assert.Equal(expectedAzureOpenAIDeploymentName, model.AzureOpenAIDeploymentName);
        Assert.Equal(expectedAzureOpenAIEndpoint, model.AzureOpenAIEndpoint);
        Assert.Equal(expectedAzureOpenAIKey, model.AzureOpenAIKey);
        Assert.Equal(expectedBboxBottom, model.BboxBottom);
        Assert.Equal(expectedBboxLeft, model.BboxLeft);
        Assert.Equal(expectedBboxRight, model.BboxRight);
        Assert.Equal(expectedBboxTop, model.BboxTop);
        Assert.Equal(expectedBoundingBox, model.BoundingBox);
        Assert.Equal(expectedCompactMarkdownTable, model.CompactMarkdownTable);
        Assert.Equal(
            expectedComplementalFormattingInstruction,
            model.ComplementalFormattingInstruction
        );
        Assert.Equal(expectedConfidenceScoreEffort, model.ConfidenceScoreEffort);
        Assert.Equal(expectedContentGuidelineInstruction, model.ContentGuidelineInstruction);
        Assert.Equal(expectedContinuousMode, model.ContinuousMode);
        Assert.Equal(expectedDisableImageExtraction, model.DisableImageExtraction);
        Assert.Equal(expectedDisableOcr, model.DisableOcr);
        Assert.Equal(expectedDisableReconstruction, model.DisableReconstruction);
        Assert.Equal(expectedDoNotCache, model.DoNotCache);
        Assert.Equal(expectedDoNotUnrollColumns, model.DoNotUnrollColumns);
        Assert.Equal(expectedEnableCostOptimizer, model.EnableCostOptimizer);
        Assert.Equal(expectedExtractCharts, model.ExtractCharts);
        Assert.Equal(expectedExtractLayout, model.ExtractLayout);
        Assert.Equal(expectedExtractPrintedPageNumber, model.ExtractPrintedPageNumber);
        Assert.Equal(expectedFastMode, model.FastMode);
        Assert.Equal(expectedFormattingInstruction, model.FormattingInstruction);
        Assert.Equal(expectedGpt4oApiKey, model.Gpt4oApiKey);
        Assert.Equal(expectedGpt4oMode, model.Gpt4oMode);
        Assert.Equal(expectedGuessXlsxSheetName, model.GuessXlsxSheetName);
        Assert.Equal(expectedHideFooters, model.HideFooters);
        Assert.Equal(expectedHideHeaders, model.HideHeaders);
        Assert.Equal(expectedHighResOcr, model.HighResOcr);
        Assert.Equal(expectedHtmlMakeAllElementsVisible, model.HtmlMakeAllElementsVisible);
        Assert.Equal(expectedHtmlRemoveFixedElements, model.HtmlRemoveFixedElements);
        Assert.Equal(expectedHtmlRemoveNavigationElements, model.HtmlRemoveNavigationElements);
        Assert.Equal(expectedHttpProxy, model.HttpProxy);
        Assert.Equal(
            expectedIgnoreDocumentElementsForLayoutDetection,
            model.IgnoreDocumentElementsForLayoutDetection
        );
        Assert.NotNull(model.ImagesToSave);
        Assert.Equal(expectedImagesToSave.Count, model.ImagesToSave.Count);
        for (int i = 0; i < expectedImagesToSave.Count; i++)
        {
            Assert.Equal(expectedImagesToSave[i], model.ImagesToSave[i]);
        }
        Assert.Equal(expectedInlineImagesInMarkdown, model.InlineImagesInMarkdown);
        Assert.Equal(expectedInputS3Path, model.InputS3Path);
        Assert.Equal(expectedInputS3Region, model.InputS3Region);
        Assert.Equal(expectedInputUrl, model.InputUrl);
        Assert.Equal(expectedInternalIsScreenshotJob, model.InternalIsScreenshotJob);
        Assert.Equal(expectedInvalidateCache, model.InvalidateCache);
        Assert.Equal(expectedIsFormattingInstruction, model.IsFormattingInstruction);
        Assert.Equal(
            expectedJobTimeoutExtraTimePerPageInSeconds,
            model.JobTimeoutExtraTimePerPageInSeconds
        );
        Assert.Equal(expectedJobTimeoutInSeconds, model.JobTimeoutInSeconds);
        Assert.Equal(
            expectedKeepPageSeparatorWhenMergingTables,
            model.KeepPageSeparatorWhenMergingTables
        );
        Assert.NotNull(model.Languages);
        Assert.Equal(expectedLanguages.Count, model.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], model.Languages[i]);
        }
        Assert.Equal(expectedLayoutAware, model.LayoutAware);
        Assert.Equal(expectedLineLevelBoundingBox, model.LineLevelBoundingBox);
        Assert.Equal(
            expectedMarkdownTableMultilineHeaderSeparator,
            model.MarkdownTableMultilineHeaderSeparator
        );
        Assert.Equal(expectedMaxPages, model.MaxPages);
        Assert.Equal(expectedMaxPagesEnforced, model.MaxPagesEnforced);
        Assert.Equal(
            expectedMergeTablesAcrossPagesInMarkdown,
            model.MergeTablesAcrossPagesInMarkdown
        );
        Assert.Equal(expectedModel, model.Model);
        Assert.Equal(expectedOutlinedTableExtraction, model.OutlinedTableExtraction);
        Assert.Equal(expectedOutputPdfOfDocument, model.OutputPdfOfDocument);
        Assert.Equal(expectedOutputS3PathPrefix, model.OutputS3PathPrefix);
        Assert.Equal(expectedOutputS3Region, model.OutputS3Region);
        Assert.Equal(expectedOutputTablesAsHtml, model.OutputTablesAsHtml);
        Assert.Equal(expectedPageErrorTolerance, model.PageErrorTolerance);
        Assert.Equal(expectedPageFooterPrefix, model.PageFooterPrefix);
        Assert.Equal(expectedPageFooterSuffix, model.PageFooterSuffix);
        Assert.Equal(expectedPageHeaderPrefix, model.PageHeaderPrefix);
        Assert.Equal(expectedPageHeaderSuffix, model.PageHeaderSuffix);
        Assert.Equal(expectedPagePrefix, model.PagePrefix);
        Assert.Equal(expectedPageSeparator, model.PageSeparator);
        Assert.Equal(expectedPageSuffix, model.PageSuffix);
        Assert.Equal(expectedParseMode, model.ParseMode);
        Assert.Equal(expectedParsingInstruction, model.ParsingInstruction);
        Assert.Equal(expectedPreciseBoundingBox, model.PreciseBoundingBox);
        Assert.Equal(expectedPremiumMode, model.PremiumMode);
        Assert.Equal(expectedPresentationOutOfBoundsContent, model.PresentationOutOfBoundsContent);
        Assert.Equal(expectedPresentationSkipEmbeddedData, model.PresentationSkipEmbeddedData);
        Assert.Equal(
            expectedPreserveLayoutAlignmentAcrossPages,
            model.PreserveLayoutAlignmentAcrossPages
        );
        Assert.Equal(expectedPreserveVerySmallText, model.PreserveVerySmallText);
        Assert.Equal(expectedPreset, model.Preset);
        Assert.Equal(expectedPriority, model.Priority);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedRemoveHiddenText, model.RemoveHiddenText);
        Assert.Equal(expectedReplaceFailedPageMode, model.ReplaceFailedPageMode);
        Assert.Equal(
            expectedReplaceFailedPageWithErrorMessagePrefix,
            model.ReplaceFailedPageWithErrorMessagePrefix
        );
        Assert.Equal(
            expectedReplaceFailedPageWithErrorMessageSuffix,
            model.ReplaceFailedPageWithErrorMessageSuffix
        );
        Assert.Equal(expectedSaveImages, model.SaveImages);
        Assert.Equal(expectedSkipDiagonalText, model.SkipDiagonalText);
        Assert.Equal(expectedSpecializedChartParsingAgentic, model.SpecializedChartParsingAgentic);
        Assert.Equal(
            expectedSpecializedChartParsingEfficient,
            model.SpecializedChartParsingEfficient
        );
        Assert.Equal(expectedSpecializedChartParsingPlus, model.SpecializedChartParsingPlus);
        Assert.Equal(expectedSpecializedImageParsing, model.SpecializedImageParsing);
        Assert.Equal(expectedSpreadsheetExtractSubTables, model.SpreadsheetExtractSubTables);
        Assert.Equal(
            expectedSpreadsheetForceFormulaComputation,
            model.SpreadsheetForceFormulaComputation
        );
        Assert.Equal(expectedSpreadsheetIncludeHiddenSheets, model.SpreadsheetIncludeHiddenSheets);
        Assert.Equal(expectedStrictModeBuggyFont, model.StrictModeBuggyFont);
        Assert.Equal(expectedStrictModeImageExtraction, model.StrictModeImageExtraction);
        Assert.Equal(expectedStrictModeImageOcr, model.StrictModeImageOcr);
        Assert.Equal(expectedStrictModeReconstruction, model.StrictModeReconstruction);
        Assert.Equal(expectedStructuredOutput, model.StructuredOutput);
        Assert.Equal(expectedStructuredOutputJsonSchema, model.StructuredOutputJsonSchema);
        Assert.Equal(expectedStructuredOutputJsonSchemaName, model.StructuredOutputJsonSchemaName);
        Assert.Equal(expectedSystemPrompt, model.SystemPrompt);
        Assert.Equal(expectedSystemPromptAppend, model.SystemPromptAppend);
        Assert.Equal(expectedTakeScreenshot, model.TakeScreenshot);
        Assert.Equal(expectedTargetPages, model.TargetPages);
        Assert.Equal(expectedTier, model.Tier);
        Assert.Equal(expectedUseVendorMultimodalModel, model.UseVendorMultimodalModel);
        Assert.Equal(expectedUserPrompt, model.UserPrompt);
        Assert.Equal(expectedVendorMultimodalApiKey, model.VendorMultimodalApiKey);
        Assert.Equal(expectedVendorMultimodalModelName, model.VendorMultimodalModelName);
        Assert.Equal(expectedVersion, model.Version);
        Assert.NotNull(model.WebhookConfigurations);
        Assert.Equal(expectedWebhookConfigurations.Count, model.WebhookConfigurations.Count);
        for (int i = 0; i < expectedWebhookConfigurations.Count; i++)
        {
            Assert.Equal(expectedWebhookConfigurations[i], model.WebhookConfigurations[i]);
        }
        Assert.Equal(expectedWebhookUrl, model.WebhookUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LlamaParseParameters
        {
            AdaptiveLongTable = true,
            AggressiveTableExtraction = true,
            AnnotateLineNumbers = true,
            AnnotateLinks = true,
            AnnotateRevisions = true,
            AutoMode = true,
            AutoModeConfigurationJson = "auto_mode_configuration_json",
            AutoModeTriggerOnImageInPage = true,
            AutoModeTriggerOnRegexpInPage = "auto_mode_trigger_on_regexp_in_page",
            AutoModeTriggerOnTableInPage = true,
            AutoModeTriggerOnTextInPage = "auto_mode_trigger_on_text_in_page",
            AzureOpenAIApiVersion = "azure_openai_api_version",
            AzureOpenAIDeploymentName = "azure_openai_deployment_name",
            AzureOpenAIEndpoint = "azure_openai_endpoint",
            AzureOpenAIKey = "azure_openai_key",
            BboxBottom = 0,
            BboxLeft = 0,
            BboxRight = 0,
            BboxTop = 0,
            BoundingBox = "bounding_box",
            CompactMarkdownTable = true,
            ComplementalFormattingInstruction = "complemental_formatting_instruction",
            ConfidenceScoreEffort = "confidence_score_effort",
            ContentGuidelineInstruction = "content_guideline_instruction",
            ContinuousMode = true,
            DisableImageExtraction = true,
            DisableOcr = true,
            DisableReconstruction = true,
            DoNotCache = true,
            DoNotUnrollColumns = true,
            EnableCostOptimizer = true,
            ExtractCharts = true,
            ExtractLayout = true,
            ExtractPrintedPageNumber = true,
            FastMode = true,
            FormattingInstruction = "formatting_instruction",
            Gpt4oApiKey = "gpt4o_api_key",
            Gpt4oMode = true,
            GuessXlsxSheetName = true,
            HideFooters = true,
            HideHeaders = true,
            HighResOcr = true,
            HtmlMakeAllElementsVisible = true,
            HtmlRemoveFixedElements = true,
            HtmlRemoveNavigationElements = true,
            HttpProxy = "http_proxy",
            IgnoreDocumentElementsForLayoutDetection = true,
            ImagesToSave = [ImagesToSave.Embedded],
            InlineImagesInMarkdown = true,
            InputS3Path = "input_s3_path",
            InputS3Region = "input_s3_region",
            InputUrl = "input_url",
            InternalIsScreenshotJob = true,
            InvalidateCache = true,
            IsFormattingInstruction = true,
            JobTimeoutExtraTimePerPageInSeconds = 0,
            JobTimeoutInSeconds = 0,
            KeepPageSeparatorWhenMergingTables = true,
            Languages = [Parsing::ParsingLanguages.Abq],
            LayoutAware = true,
            LineLevelBoundingBox = true,
            MarkdownTableMultilineHeaderSeparator = "markdown_table_multiline_header_separator",
            MaxPages = 0,
            MaxPagesEnforced = 0,
            MergeTablesAcrossPagesInMarkdown = true,
            Model = "model",
            OutlinedTableExtraction = true,
            OutputPdfOfDocument = true,
            OutputS3PathPrefix = "output_s3_path_prefix",
            OutputS3Region = "output_s3_region",
            OutputTablesAsHtml = true,
            PageErrorTolerance = 0,
            PageFooterPrefix = "page_footer_prefix",
            PageFooterSuffix = "page_footer_suffix",
            PageHeaderPrefix = "page_header_prefix",
            PageHeaderSuffix = "page_header_suffix",
            PagePrefix = "page_prefix",
            PageSeparator = "page_separator",
            PageSuffix = "page_suffix",
            ParseMode = Parsing::ParsingMode.ParseDocumentWithAgent,
            ParsingInstruction = "parsing_instruction",
            PreciseBoundingBox = true,
            PremiumMode = true,
            PresentationOutOfBoundsContent = true,
            PresentationSkipEmbeddedData = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
            Preset = "preset",
            Priority = Priority.Critical,
            ProjectID = "project_id",
            RemoveHiddenText = true,
            ReplaceFailedPageMode = Parsing::FailPageMode.BlankPage,
            ReplaceFailedPageWithErrorMessagePrefix =
                "replace_failed_page_with_error_message_prefix",
            ReplaceFailedPageWithErrorMessageSuffix =
                "replace_failed_page_with_error_message_suffix",
            SaveImages = true,
            SkipDiagonalText = true,
            SpecializedChartParsingAgentic = true,
            SpecializedChartParsingEfficient = true,
            SpecializedChartParsingPlus = true,
            SpecializedImageParsing = true,
            SpreadsheetExtractSubTables = true,
            SpreadsheetForceFormulaComputation = true,
            SpreadsheetIncludeHiddenSheets = true,
            StrictModeBuggyFont = true,
            StrictModeImageExtraction = true,
            StrictModeImageOcr = true,
            StrictModeReconstruction = true,
            StructuredOutput = true,
            StructuredOutputJsonSchema = "structured_output_json_schema",
            StructuredOutputJsonSchemaName = "structured_output_json_schema_name",
            SystemPrompt = "system_prompt",
            SystemPromptAppend = "system_prompt_append",
            TakeScreenshot = true,
            TargetPages = "target_pages",
            Tier = "tier",
            UseVendorMultimodalModel = true,
            UserPrompt = "user_prompt",
            VendorMultimodalApiKey = "vendor_multimodal_api_key",
            VendorMultimodalModelName = "vendor_multimodal_model_name",
            Version = "version",
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
                    WebhookHeaders = new Dictionary<string, string>()
                    {
                        { "Authorization", "Bearer sk-..." },
                    },
                    WebhookOutputFormat = "json",
                    WebhookSigningSecret = "whsec_...",
                    WebhookUrl = "https://example.com/webhooks/llamacloud",
                },
            ],
            WebhookUrl = "webhook_url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LlamaParseParameters>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LlamaParseParameters
        {
            AdaptiveLongTable = true,
            AggressiveTableExtraction = true,
            AnnotateLineNumbers = true,
            AnnotateLinks = true,
            AnnotateRevisions = true,
            AutoMode = true,
            AutoModeConfigurationJson = "auto_mode_configuration_json",
            AutoModeTriggerOnImageInPage = true,
            AutoModeTriggerOnRegexpInPage = "auto_mode_trigger_on_regexp_in_page",
            AutoModeTriggerOnTableInPage = true,
            AutoModeTriggerOnTextInPage = "auto_mode_trigger_on_text_in_page",
            AzureOpenAIApiVersion = "azure_openai_api_version",
            AzureOpenAIDeploymentName = "azure_openai_deployment_name",
            AzureOpenAIEndpoint = "azure_openai_endpoint",
            AzureOpenAIKey = "azure_openai_key",
            BboxBottom = 0,
            BboxLeft = 0,
            BboxRight = 0,
            BboxTop = 0,
            BoundingBox = "bounding_box",
            CompactMarkdownTable = true,
            ComplementalFormattingInstruction = "complemental_formatting_instruction",
            ConfidenceScoreEffort = "confidence_score_effort",
            ContentGuidelineInstruction = "content_guideline_instruction",
            ContinuousMode = true,
            DisableImageExtraction = true,
            DisableOcr = true,
            DisableReconstruction = true,
            DoNotCache = true,
            DoNotUnrollColumns = true,
            EnableCostOptimizer = true,
            ExtractCharts = true,
            ExtractLayout = true,
            ExtractPrintedPageNumber = true,
            FastMode = true,
            FormattingInstruction = "formatting_instruction",
            Gpt4oApiKey = "gpt4o_api_key",
            Gpt4oMode = true,
            GuessXlsxSheetName = true,
            HideFooters = true,
            HideHeaders = true,
            HighResOcr = true,
            HtmlMakeAllElementsVisible = true,
            HtmlRemoveFixedElements = true,
            HtmlRemoveNavigationElements = true,
            HttpProxy = "http_proxy",
            IgnoreDocumentElementsForLayoutDetection = true,
            ImagesToSave = [ImagesToSave.Embedded],
            InlineImagesInMarkdown = true,
            InputS3Path = "input_s3_path",
            InputS3Region = "input_s3_region",
            InputUrl = "input_url",
            InternalIsScreenshotJob = true,
            InvalidateCache = true,
            IsFormattingInstruction = true,
            JobTimeoutExtraTimePerPageInSeconds = 0,
            JobTimeoutInSeconds = 0,
            KeepPageSeparatorWhenMergingTables = true,
            Languages = [Parsing::ParsingLanguages.Abq],
            LayoutAware = true,
            LineLevelBoundingBox = true,
            MarkdownTableMultilineHeaderSeparator = "markdown_table_multiline_header_separator",
            MaxPages = 0,
            MaxPagesEnforced = 0,
            MergeTablesAcrossPagesInMarkdown = true,
            Model = "model",
            OutlinedTableExtraction = true,
            OutputPdfOfDocument = true,
            OutputS3PathPrefix = "output_s3_path_prefix",
            OutputS3Region = "output_s3_region",
            OutputTablesAsHtml = true,
            PageErrorTolerance = 0,
            PageFooterPrefix = "page_footer_prefix",
            PageFooterSuffix = "page_footer_suffix",
            PageHeaderPrefix = "page_header_prefix",
            PageHeaderSuffix = "page_header_suffix",
            PagePrefix = "page_prefix",
            PageSeparator = "page_separator",
            PageSuffix = "page_suffix",
            ParseMode = Parsing::ParsingMode.ParseDocumentWithAgent,
            ParsingInstruction = "parsing_instruction",
            PreciseBoundingBox = true,
            PremiumMode = true,
            PresentationOutOfBoundsContent = true,
            PresentationSkipEmbeddedData = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
            Preset = "preset",
            Priority = Priority.Critical,
            ProjectID = "project_id",
            RemoveHiddenText = true,
            ReplaceFailedPageMode = Parsing::FailPageMode.BlankPage,
            ReplaceFailedPageWithErrorMessagePrefix =
                "replace_failed_page_with_error_message_prefix",
            ReplaceFailedPageWithErrorMessageSuffix =
                "replace_failed_page_with_error_message_suffix",
            SaveImages = true,
            SkipDiagonalText = true,
            SpecializedChartParsingAgentic = true,
            SpecializedChartParsingEfficient = true,
            SpecializedChartParsingPlus = true,
            SpecializedImageParsing = true,
            SpreadsheetExtractSubTables = true,
            SpreadsheetForceFormulaComputation = true,
            SpreadsheetIncludeHiddenSheets = true,
            StrictModeBuggyFont = true,
            StrictModeImageExtraction = true,
            StrictModeImageOcr = true,
            StrictModeReconstruction = true,
            StructuredOutput = true,
            StructuredOutputJsonSchema = "structured_output_json_schema",
            StructuredOutputJsonSchemaName = "structured_output_json_schema_name",
            SystemPrompt = "system_prompt",
            SystemPromptAppend = "system_prompt_append",
            TakeScreenshot = true,
            TargetPages = "target_pages",
            Tier = "tier",
            UseVendorMultimodalModel = true,
            UserPrompt = "user_prompt",
            VendorMultimodalApiKey = "vendor_multimodal_api_key",
            VendorMultimodalModelName = "vendor_multimodal_model_name",
            Version = "version",
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
                    WebhookHeaders = new Dictionary<string, string>()
                    {
                        { "Authorization", "Bearer sk-..." },
                    },
                    WebhookOutputFormat = "json",
                    WebhookSigningSecret = "whsec_...",
                    WebhookUrl = "https://example.com/webhooks/llamacloud",
                },
            ],
            WebhookUrl = "webhook_url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LlamaParseParameters>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedAdaptiveLongTable = true;
        bool expectedAggressiveTableExtraction = true;
        bool expectedAnnotateLineNumbers = true;
        bool expectedAnnotateLinks = true;
        bool expectedAnnotateRevisions = true;
        bool expectedAutoMode = true;
        string expectedAutoModeConfigurationJson = "auto_mode_configuration_json";
        bool expectedAutoModeTriggerOnImageInPage = true;
        string expectedAutoModeTriggerOnRegexpInPage = "auto_mode_trigger_on_regexp_in_page";
        bool expectedAutoModeTriggerOnTableInPage = true;
        string expectedAutoModeTriggerOnTextInPage = "auto_mode_trigger_on_text_in_page";
        string expectedAzureOpenAIApiVersion = "azure_openai_api_version";
        string expectedAzureOpenAIDeploymentName = "azure_openai_deployment_name";
        string expectedAzureOpenAIEndpoint = "azure_openai_endpoint";
        string expectedAzureOpenAIKey = "azure_openai_key";
        double expectedBboxBottom = 0;
        double expectedBboxLeft = 0;
        double expectedBboxRight = 0;
        double expectedBboxTop = 0;
        string expectedBoundingBox = "bounding_box";
        bool expectedCompactMarkdownTable = true;
        string expectedComplementalFormattingInstruction = "complemental_formatting_instruction";
        string expectedConfidenceScoreEffort = "confidence_score_effort";
        string expectedContentGuidelineInstruction = "content_guideline_instruction";
        bool expectedContinuousMode = true;
        bool expectedDisableImageExtraction = true;
        bool expectedDisableOcr = true;
        bool expectedDisableReconstruction = true;
        bool expectedDoNotCache = true;
        bool expectedDoNotUnrollColumns = true;
        bool expectedEnableCostOptimizer = true;
        bool expectedExtractCharts = true;
        bool expectedExtractLayout = true;
        bool expectedExtractPrintedPageNumber = true;
        bool expectedFastMode = true;
        string expectedFormattingInstruction = "formatting_instruction";
        string expectedGpt4oApiKey = "gpt4o_api_key";
        bool expectedGpt4oMode = true;
        bool expectedGuessXlsxSheetName = true;
        bool expectedHideFooters = true;
        bool expectedHideHeaders = true;
        bool expectedHighResOcr = true;
        bool expectedHtmlMakeAllElementsVisible = true;
        bool expectedHtmlRemoveFixedElements = true;
        bool expectedHtmlRemoveNavigationElements = true;
        string expectedHttpProxy = "http_proxy";
        bool expectedIgnoreDocumentElementsForLayoutDetection = true;
        List<ApiEnum<string, ImagesToSave>> expectedImagesToSave = [ImagesToSave.Embedded];
        bool expectedInlineImagesInMarkdown = true;
        string expectedInputS3Path = "input_s3_path";
        string expectedInputS3Region = "input_s3_region";
        string expectedInputUrl = "input_url";
        bool expectedInternalIsScreenshotJob = true;
        bool expectedInvalidateCache = true;
        bool expectedIsFormattingInstruction = true;
        double expectedJobTimeoutExtraTimePerPageInSeconds = 0;
        double expectedJobTimeoutInSeconds = 0;
        bool expectedKeepPageSeparatorWhenMergingTables = true;
        List<ApiEnum<string, Parsing::ParsingLanguages>> expectedLanguages =
        [
            Parsing::ParsingLanguages.Abq,
        ];
        bool expectedLayoutAware = true;
        bool expectedLineLevelBoundingBox = true;
        string expectedMarkdownTableMultilineHeaderSeparator =
            "markdown_table_multiline_header_separator";
        long expectedMaxPages = 0;
        long expectedMaxPagesEnforced = 0;
        bool expectedMergeTablesAcrossPagesInMarkdown = true;
        string expectedModel = "model";
        bool expectedOutlinedTableExtraction = true;
        bool expectedOutputPdfOfDocument = true;
        string expectedOutputS3PathPrefix = "output_s3_path_prefix";
        string expectedOutputS3Region = "output_s3_region";
        bool expectedOutputTablesAsHtml = true;
        double expectedPageErrorTolerance = 0;
        string expectedPageFooterPrefix = "page_footer_prefix";
        string expectedPageFooterSuffix = "page_footer_suffix";
        string expectedPageHeaderPrefix = "page_header_prefix";
        string expectedPageHeaderSuffix = "page_header_suffix";
        string expectedPagePrefix = "page_prefix";
        string expectedPageSeparator = "page_separator";
        string expectedPageSuffix = "page_suffix";
        ApiEnum<string, Parsing::ParsingMode> expectedParseMode =
            Parsing::ParsingMode.ParseDocumentWithAgent;
        string expectedParsingInstruction = "parsing_instruction";
        bool expectedPreciseBoundingBox = true;
        bool expectedPremiumMode = true;
        bool expectedPresentationOutOfBoundsContent = true;
        bool expectedPresentationSkipEmbeddedData = true;
        bool expectedPreserveLayoutAlignmentAcrossPages = true;
        bool expectedPreserveVerySmallText = true;
        string expectedPreset = "preset";
        ApiEnum<string, Priority> expectedPriority = Priority.Critical;
        string expectedProjectID = "project_id";
        bool expectedRemoveHiddenText = true;
        ApiEnum<string, Parsing::FailPageMode> expectedReplaceFailedPageMode =
            Parsing::FailPageMode.BlankPage;
        string expectedReplaceFailedPageWithErrorMessagePrefix =
            "replace_failed_page_with_error_message_prefix";
        string expectedReplaceFailedPageWithErrorMessageSuffix =
            "replace_failed_page_with_error_message_suffix";
        bool expectedSaveImages = true;
        bool expectedSkipDiagonalText = true;
        bool expectedSpecializedChartParsingAgentic = true;
        bool expectedSpecializedChartParsingEfficient = true;
        bool expectedSpecializedChartParsingPlus = true;
        bool expectedSpecializedImageParsing = true;
        bool expectedSpreadsheetExtractSubTables = true;
        bool expectedSpreadsheetForceFormulaComputation = true;
        bool expectedSpreadsheetIncludeHiddenSheets = true;
        bool expectedStrictModeBuggyFont = true;
        bool expectedStrictModeImageExtraction = true;
        bool expectedStrictModeImageOcr = true;
        bool expectedStrictModeReconstruction = true;
        bool expectedStructuredOutput = true;
        string expectedStructuredOutputJsonSchema = "structured_output_json_schema";
        string expectedStructuredOutputJsonSchemaName = "structured_output_json_schema_name";
        string expectedSystemPrompt = "system_prompt";
        string expectedSystemPromptAppend = "system_prompt_append";
        bool expectedTakeScreenshot = true;
        string expectedTargetPages = "target_pages";
        string expectedTier = "tier";
        bool expectedUseVendorMultimodalModel = true;
        string expectedUserPrompt = "user_prompt";
        string expectedVendorMultimodalApiKey = "vendor_multimodal_api_key";
        string expectedVendorMultimodalModelName = "vendor_multimodal_model_name";
        string expectedVersion = "version";
        List<WebhookConfiguration> expectedWebhookConfigurations =
        [
            new()
            {
                WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
                WebhookHeaders = new Dictionary<string, string>()
                {
                    { "Authorization", "Bearer sk-..." },
                },
                WebhookOutputFormat = "json",
                WebhookSigningSecret = "whsec_...",
                WebhookUrl = "https://example.com/webhooks/llamacloud",
            },
        ];
        string expectedWebhookUrl = "webhook_url";

        Assert.Equal(expectedAdaptiveLongTable, deserialized.AdaptiveLongTable);
        Assert.Equal(expectedAggressiveTableExtraction, deserialized.AggressiveTableExtraction);
        Assert.Equal(expectedAnnotateLineNumbers, deserialized.AnnotateLineNumbers);
        Assert.Equal(expectedAnnotateLinks, deserialized.AnnotateLinks);
        Assert.Equal(expectedAnnotateRevisions, deserialized.AnnotateRevisions);
        Assert.Equal(expectedAutoMode, deserialized.AutoMode);
        Assert.Equal(expectedAutoModeConfigurationJson, deserialized.AutoModeConfigurationJson);
        Assert.Equal(
            expectedAutoModeTriggerOnImageInPage,
            deserialized.AutoModeTriggerOnImageInPage
        );
        Assert.Equal(
            expectedAutoModeTriggerOnRegexpInPage,
            deserialized.AutoModeTriggerOnRegexpInPage
        );
        Assert.Equal(
            expectedAutoModeTriggerOnTableInPage,
            deserialized.AutoModeTriggerOnTableInPage
        );
        Assert.Equal(expectedAutoModeTriggerOnTextInPage, deserialized.AutoModeTriggerOnTextInPage);
        Assert.Equal(expectedAzureOpenAIApiVersion, deserialized.AzureOpenAIApiVersion);
        Assert.Equal(expectedAzureOpenAIDeploymentName, deserialized.AzureOpenAIDeploymentName);
        Assert.Equal(expectedAzureOpenAIEndpoint, deserialized.AzureOpenAIEndpoint);
        Assert.Equal(expectedAzureOpenAIKey, deserialized.AzureOpenAIKey);
        Assert.Equal(expectedBboxBottom, deserialized.BboxBottom);
        Assert.Equal(expectedBboxLeft, deserialized.BboxLeft);
        Assert.Equal(expectedBboxRight, deserialized.BboxRight);
        Assert.Equal(expectedBboxTop, deserialized.BboxTop);
        Assert.Equal(expectedBoundingBox, deserialized.BoundingBox);
        Assert.Equal(expectedCompactMarkdownTable, deserialized.CompactMarkdownTable);
        Assert.Equal(
            expectedComplementalFormattingInstruction,
            deserialized.ComplementalFormattingInstruction
        );
        Assert.Equal(expectedConfidenceScoreEffort, deserialized.ConfidenceScoreEffort);
        Assert.Equal(expectedContentGuidelineInstruction, deserialized.ContentGuidelineInstruction);
        Assert.Equal(expectedContinuousMode, deserialized.ContinuousMode);
        Assert.Equal(expectedDisableImageExtraction, deserialized.DisableImageExtraction);
        Assert.Equal(expectedDisableOcr, deserialized.DisableOcr);
        Assert.Equal(expectedDisableReconstruction, deserialized.DisableReconstruction);
        Assert.Equal(expectedDoNotCache, deserialized.DoNotCache);
        Assert.Equal(expectedDoNotUnrollColumns, deserialized.DoNotUnrollColumns);
        Assert.Equal(expectedEnableCostOptimizer, deserialized.EnableCostOptimizer);
        Assert.Equal(expectedExtractCharts, deserialized.ExtractCharts);
        Assert.Equal(expectedExtractLayout, deserialized.ExtractLayout);
        Assert.Equal(expectedExtractPrintedPageNumber, deserialized.ExtractPrintedPageNumber);
        Assert.Equal(expectedFastMode, deserialized.FastMode);
        Assert.Equal(expectedFormattingInstruction, deserialized.FormattingInstruction);
        Assert.Equal(expectedGpt4oApiKey, deserialized.Gpt4oApiKey);
        Assert.Equal(expectedGpt4oMode, deserialized.Gpt4oMode);
        Assert.Equal(expectedGuessXlsxSheetName, deserialized.GuessXlsxSheetName);
        Assert.Equal(expectedHideFooters, deserialized.HideFooters);
        Assert.Equal(expectedHideHeaders, deserialized.HideHeaders);
        Assert.Equal(expectedHighResOcr, deserialized.HighResOcr);
        Assert.Equal(expectedHtmlMakeAllElementsVisible, deserialized.HtmlMakeAllElementsVisible);
        Assert.Equal(expectedHtmlRemoveFixedElements, deserialized.HtmlRemoveFixedElements);
        Assert.Equal(
            expectedHtmlRemoveNavigationElements,
            deserialized.HtmlRemoveNavigationElements
        );
        Assert.Equal(expectedHttpProxy, deserialized.HttpProxy);
        Assert.Equal(
            expectedIgnoreDocumentElementsForLayoutDetection,
            deserialized.IgnoreDocumentElementsForLayoutDetection
        );
        Assert.NotNull(deserialized.ImagesToSave);
        Assert.Equal(expectedImagesToSave.Count, deserialized.ImagesToSave.Count);
        for (int i = 0; i < expectedImagesToSave.Count; i++)
        {
            Assert.Equal(expectedImagesToSave[i], deserialized.ImagesToSave[i]);
        }
        Assert.Equal(expectedInlineImagesInMarkdown, deserialized.InlineImagesInMarkdown);
        Assert.Equal(expectedInputS3Path, deserialized.InputS3Path);
        Assert.Equal(expectedInputS3Region, deserialized.InputS3Region);
        Assert.Equal(expectedInputUrl, deserialized.InputUrl);
        Assert.Equal(expectedInternalIsScreenshotJob, deserialized.InternalIsScreenshotJob);
        Assert.Equal(expectedInvalidateCache, deserialized.InvalidateCache);
        Assert.Equal(expectedIsFormattingInstruction, deserialized.IsFormattingInstruction);
        Assert.Equal(
            expectedJobTimeoutExtraTimePerPageInSeconds,
            deserialized.JobTimeoutExtraTimePerPageInSeconds
        );
        Assert.Equal(expectedJobTimeoutInSeconds, deserialized.JobTimeoutInSeconds);
        Assert.Equal(
            expectedKeepPageSeparatorWhenMergingTables,
            deserialized.KeepPageSeparatorWhenMergingTables
        );
        Assert.NotNull(deserialized.Languages);
        Assert.Equal(expectedLanguages.Count, deserialized.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], deserialized.Languages[i]);
        }
        Assert.Equal(expectedLayoutAware, deserialized.LayoutAware);
        Assert.Equal(expectedLineLevelBoundingBox, deserialized.LineLevelBoundingBox);
        Assert.Equal(
            expectedMarkdownTableMultilineHeaderSeparator,
            deserialized.MarkdownTableMultilineHeaderSeparator
        );
        Assert.Equal(expectedMaxPages, deserialized.MaxPages);
        Assert.Equal(expectedMaxPagesEnforced, deserialized.MaxPagesEnforced);
        Assert.Equal(
            expectedMergeTablesAcrossPagesInMarkdown,
            deserialized.MergeTablesAcrossPagesInMarkdown
        );
        Assert.Equal(expectedModel, deserialized.Model);
        Assert.Equal(expectedOutlinedTableExtraction, deserialized.OutlinedTableExtraction);
        Assert.Equal(expectedOutputPdfOfDocument, deserialized.OutputPdfOfDocument);
        Assert.Equal(expectedOutputS3PathPrefix, deserialized.OutputS3PathPrefix);
        Assert.Equal(expectedOutputS3Region, deserialized.OutputS3Region);
        Assert.Equal(expectedOutputTablesAsHtml, deserialized.OutputTablesAsHtml);
        Assert.Equal(expectedPageErrorTolerance, deserialized.PageErrorTolerance);
        Assert.Equal(expectedPageFooterPrefix, deserialized.PageFooterPrefix);
        Assert.Equal(expectedPageFooterSuffix, deserialized.PageFooterSuffix);
        Assert.Equal(expectedPageHeaderPrefix, deserialized.PageHeaderPrefix);
        Assert.Equal(expectedPageHeaderSuffix, deserialized.PageHeaderSuffix);
        Assert.Equal(expectedPagePrefix, deserialized.PagePrefix);
        Assert.Equal(expectedPageSeparator, deserialized.PageSeparator);
        Assert.Equal(expectedPageSuffix, deserialized.PageSuffix);
        Assert.Equal(expectedParseMode, deserialized.ParseMode);
        Assert.Equal(expectedParsingInstruction, deserialized.ParsingInstruction);
        Assert.Equal(expectedPreciseBoundingBox, deserialized.PreciseBoundingBox);
        Assert.Equal(expectedPremiumMode, deserialized.PremiumMode);
        Assert.Equal(
            expectedPresentationOutOfBoundsContent,
            deserialized.PresentationOutOfBoundsContent
        );
        Assert.Equal(
            expectedPresentationSkipEmbeddedData,
            deserialized.PresentationSkipEmbeddedData
        );
        Assert.Equal(
            expectedPreserveLayoutAlignmentAcrossPages,
            deserialized.PreserveLayoutAlignmentAcrossPages
        );
        Assert.Equal(expectedPreserveVerySmallText, deserialized.PreserveVerySmallText);
        Assert.Equal(expectedPreset, deserialized.Preset);
        Assert.Equal(expectedPriority, deserialized.Priority);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedRemoveHiddenText, deserialized.RemoveHiddenText);
        Assert.Equal(expectedReplaceFailedPageMode, deserialized.ReplaceFailedPageMode);
        Assert.Equal(
            expectedReplaceFailedPageWithErrorMessagePrefix,
            deserialized.ReplaceFailedPageWithErrorMessagePrefix
        );
        Assert.Equal(
            expectedReplaceFailedPageWithErrorMessageSuffix,
            deserialized.ReplaceFailedPageWithErrorMessageSuffix
        );
        Assert.Equal(expectedSaveImages, deserialized.SaveImages);
        Assert.Equal(expectedSkipDiagonalText, deserialized.SkipDiagonalText);
        Assert.Equal(
            expectedSpecializedChartParsingAgentic,
            deserialized.SpecializedChartParsingAgentic
        );
        Assert.Equal(
            expectedSpecializedChartParsingEfficient,
            deserialized.SpecializedChartParsingEfficient
        );
        Assert.Equal(expectedSpecializedChartParsingPlus, deserialized.SpecializedChartParsingPlus);
        Assert.Equal(expectedSpecializedImageParsing, deserialized.SpecializedImageParsing);
        Assert.Equal(expectedSpreadsheetExtractSubTables, deserialized.SpreadsheetExtractSubTables);
        Assert.Equal(
            expectedSpreadsheetForceFormulaComputation,
            deserialized.SpreadsheetForceFormulaComputation
        );
        Assert.Equal(
            expectedSpreadsheetIncludeHiddenSheets,
            deserialized.SpreadsheetIncludeHiddenSheets
        );
        Assert.Equal(expectedStrictModeBuggyFont, deserialized.StrictModeBuggyFont);
        Assert.Equal(expectedStrictModeImageExtraction, deserialized.StrictModeImageExtraction);
        Assert.Equal(expectedStrictModeImageOcr, deserialized.StrictModeImageOcr);
        Assert.Equal(expectedStrictModeReconstruction, deserialized.StrictModeReconstruction);
        Assert.Equal(expectedStructuredOutput, deserialized.StructuredOutput);
        Assert.Equal(expectedStructuredOutputJsonSchema, deserialized.StructuredOutputJsonSchema);
        Assert.Equal(
            expectedStructuredOutputJsonSchemaName,
            deserialized.StructuredOutputJsonSchemaName
        );
        Assert.Equal(expectedSystemPrompt, deserialized.SystemPrompt);
        Assert.Equal(expectedSystemPromptAppend, deserialized.SystemPromptAppend);
        Assert.Equal(expectedTakeScreenshot, deserialized.TakeScreenshot);
        Assert.Equal(expectedTargetPages, deserialized.TargetPages);
        Assert.Equal(expectedTier, deserialized.Tier);
        Assert.Equal(expectedUseVendorMultimodalModel, deserialized.UseVendorMultimodalModel);
        Assert.Equal(expectedUserPrompt, deserialized.UserPrompt);
        Assert.Equal(expectedVendorMultimodalApiKey, deserialized.VendorMultimodalApiKey);
        Assert.Equal(expectedVendorMultimodalModelName, deserialized.VendorMultimodalModelName);
        Assert.Equal(expectedVersion, deserialized.Version);
        Assert.NotNull(deserialized.WebhookConfigurations);
        Assert.Equal(expectedWebhookConfigurations.Count, deserialized.WebhookConfigurations.Count);
        for (int i = 0; i < expectedWebhookConfigurations.Count; i++)
        {
            Assert.Equal(expectedWebhookConfigurations[i], deserialized.WebhookConfigurations[i]);
        }
        Assert.Equal(expectedWebhookUrl, deserialized.WebhookUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LlamaParseParameters
        {
            AdaptiveLongTable = true,
            AggressiveTableExtraction = true,
            AnnotateLineNumbers = true,
            AnnotateLinks = true,
            AnnotateRevisions = true,
            AutoMode = true,
            AutoModeConfigurationJson = "auto_mode_configuration_json",
            AutoModeTriggerOnImageInPage = true,
            AutoModeTriggerOnRegexpInPage = "auto_mode_trigger_on_regexp_in_page",
            AutoModeTriggerOnTableInPage = true,
            AutoModeTriggerOnTextInPage = "auto_mode_trigger_on_text_in_page",
            AzureOpenAIApiVersion = "azure_openai_api_version",
            AzureOpenAIDeploymentName = "azure_openai_deployment_name",
            AzureOpenAIEndpoint = "azure_openai_endpoint",
            AzureOpenAIKey = "azure_openai_key",
            BboxBottom = 0,
            BboxLeft = 0,
            BboxRight = 0,
            BboxTop = 0,
            BoundingBox = "bounding_box",
            CompactMarkdownTable = true,
            ComplementalFormattingInstruction = "complemental_formatting_instruction",
            ConfidenceScoreEffort = "confidence_score_effort",
            ContentGuidelineInstruction = "content_guideline_instruction",
            ContinuousMode = true,
            DisableImageExtraction = true,
            DisableOcr = true,
            DisableReconstruction = true,
            DoNotCache = true,
            DoNotUnrollColumns = true,
            EnableCostOptimizer = true,
            ExtractCharts = true,
            ExtractLayout = true,
            ExtractPrintedPageNumber = true,
            FastMode = true,
            FormattingInstruction = "formatting_instruction",
            Gpt4oApiKey = "gpt4o_api_key",
            Gpt4oMode = true,
            GuessXlsxSheetName = true,
            HideFooters = true,
            HideHeaders = true,
            HighResOcr = true,
            HtmlMakeAllElementsVisible = true,
            HtmlRemoveFixedElements = true,
            HtmlRemoveNavigationElements = true,
            HttpProxy = "http_proxy",
            IgnoreDocumentElementsForLayoutDetection = true,
            ImagesToSave = [ImagesToSave.Embedded],
            InlineImagesInMarkdown = true,
            InputS3Path = "input_s3_path",
            InputS3Region = "input_s3_region",
            InputUrl = "input_url",
            InternalIsScreenshotJob = true,
            InvalidateCache = true,
            IsFormattingInstruction = true,
            JobTimeoutExtraTimePerPageInSeconds = 0,
            JobTimeoutInSeconds = 0,
            KeepPageSeparatorWhenMergingTables = true,
            Languages = [Parsing::ParsingLanguages.Abq],
            LayoutAware = true,
            LineLevelBoundingBox = true,
            MarkdownTableMultilineHeaderSeparator = "markdown_table_multiline_header_separator",
            MaxPages = 0,
            MaxPagesEnforced = 0,
            MergeTablesAcrossPagesInMarkdown = true,
            Model = "model",
            OutlinedTableExtraction = true,
            OutputPdfOfDocument = true,
            OutputS3PathPrefix = "output_s3_path_prefix",
            OutputS3Region = "output_s3_region",
            OutputTablesAsHtml = true,
            PageErrorTolerance = 0,
            PageFooterPrefix = "page_footer_prefix",
            PageFooterSuffix = "page_footer_suffix",
            PageHeaderPrefix = "page_header_prefix",
            PageHeaderSuffix = "page_header_suffix",
            PagePrefix = "page_prefix",
            PageSeparator = "page_separator",
            PageSuffix = "page_suffix",
            ParseMode = Parsing::ParsingMode.ParseDocumentWithAgent,
            ParsingInstruction = "parsing_instruction",
            PreciseBoundingBox = true,
            PremiumMode = true,
            PresentationOutOfBoundsContent = true,
            PresentationSkipEmbeddedData = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
            Preset = "preset",
            Priority = Priority.Critical,
            ProjectID = "project_id",
            RemoveHiddenText = true,
            ReplaceFailedPageMode = Parsing::FailPageMode.BlankPage,
            ReplaceFailedPageWithErrorMessagePrefix =
                "replace_failed_page_with_error_message_prefix",
            ReplaceFailedPageWithErrorMessageSuffix =
                "replace_failed_page_with_error_message_suffix",
            SaveImages = true,
            SkipDiagonalText = true,
            SpecializedChartParsingAgentic = true,
            SpecializedChartParsingEfficient = true,
            SpecializedChartParsingPlus = true,
            SpecializedImageParsing = true,
            SpreadsheetExtractSubTables = true,
            SpreadsheetForceFormulaComputation = true,
            SpreadsheetIncludeHiddenSheets = true,
            StrictModeBuggyFont = true,
            StrictModeImageExtraction = true,
            StrictModeImageOcr = true,
            StrictModeReconstruction = true,
            StructuredOutput = true,
            StructuredOutputJsonSchema = "structured_output_json_schema",
            StructuredOutputJsonSchemaName = "structured_output_json_schema_name",
            SystemPrompt = "system_prompt",
            SystemPromptAppend = "system_prompt_append",
            TakeScreenshot = true,
            TargetPages = "target_pages",
            Tier = "tier",
            UseVendorMultimodalModel = true,
            UserPrompt = "user_prompt",
            VendorMultimodalApiKey = "vendor_multimodal_api_key",
            VendorMultimodalModelName = "vendor_multimodal_model_name",
            Version = "version",
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
                    WebhookHeaders = new Dictionary<string, string>()
                    {
                        { "Authorization", "Bearer sk-..." },
                    },
                    WebhookOutputFormat = "json",
                    WebhookSigningSecret = "whsec_...",
                    WebhookUrl = "https://example.com/webhooks/llamacloud",
                },
            ],
            WebhookUrl = "webhook_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LlamaParseParameters
        {
            AdaptiveLongTable = true,
            AggressiveTableExtraction = true,
            AnnotateLineNumbers = true,
            AnnotateLinks = true,
            AnnotateRevisions = true,
            AutoMode = true,
            AutoModeConfigurationJson = "auto_mode_configuration_json",
            AutoModeTriggerOnImageInPage = true,
            AutoModeTriggerOnRegexpInPage = "auto_mode_trigger_on_regexp_in_page",
            AutoModeTriggerOnTableInPage = true,
            AutoModeTriggerOnTextInPage = "auto_mode_trigger_on_text_in_page",
            AzureOpenAIApiVersion = "azure_openai_api_version",
            AzureOpenAIDeploymentName = "azure_openai_deployment_name",
            AzureOpenAIEndpoint = "azure_openai_endpoint",
            AzureOpenAIKey = "azure_openai_key",
            BboxBottom = 0,
            BboxLeft = 0,
            BboxRight = 0,
            BboxTop = 0,
            BoundingBox = "bounding_box",
            CompactMarkdownTable = true,
            ComplementalFormattingInstruction = "complemental_formatting_instruction",
            ConfidenceScoreEffort = "confidence_score_effort",
            ContentGuidelineInstruction = "content_guideline_instruction",
            ContinuousMode = true,
            DisableImageExtraction = true,
            DisableOcr = true,
            DisableReconstruction = true,
            DoNotCache = true,
            DoNotUnrollColumns = true,
            EnableCostOptimizer = true,
            ExtractCharts = true,
            ExtractLayout = true,
            ExtractPrintedPageNumber = true,
            FastMode = true,
            FormattingInstruction = "formatting_instruction",
            Gpt4oApiKey = "gpt4o_api_key",
            Gpt4oMode = true,
            GuessXlsxSheetName = true,
            HideFooters = true,
            HideHeaders = true,
            HighResOcr = true,
            HtmlMakeAllElementsVisible = true,
            HtmlRemoveFixedElements = true,
            HtmlRemoveNavigationElements = true,
            HttpProxy = "http_proxy",
            IgnoreDocumentElementsForLayoutDetection = true,
            ImagesToSave = [ImagesToSave.Embedded],
            InlineImagesInMarkdown = true,
            InputS3Path = "input_s3_path",
            InputS3Region = "input_s3_region",
            InputUrl = "input_url",
            InternalIsScreenshotJob = true,
            InvalidateCache = true,
            IsFormattingInstruction = true,
            JobTimeoutExtraTimePerPageInSeconds = 0,
            JobTimeoutInSeconds = 0,
            KeepPageSeparatorWhenMergingTables = true,
            LayoutAware = true,
            LineLevelBoundingBox = true,
            MarkdownTableMultilineHeaderSeparator = "markdown_table_multiline_header_separator",
            MaxPages = 0,
            MaxPagesEnforced = 0,
            MergeTablesAcrossPagesInMarkdown = true,
            Model = "model",
            OutlinedTableExtraction = true,
            OutputPdfOfDocument = true,
            OutputS3PathPrefix = "output_s3_path_prefix",
            OutputS3Region = "output_s3_region",
            OutputTablesAsHtml = true,
            PageErrorTolerance = 0,
            PageFooterPrefix = "page_footer_prefix",
            PageFooterSuffix = "page_footer_suffix",
            PageHeaderPrefix = "page_header_prefix",
            PageHeaderSuffix = "page_header_suffix",
            PagePrefix = "page_prefix",
            PageSeparator = "page_separator",
            PageSuffix = "page_suffix",
            ParseMode = Parsing::ParsingMode.ParseDocumentWithAgent,
            ParsingInstruction = "parsing_instruction",
            PreciseBoundingBox = true,
            PremiumMode = true,
            PresentationOutOfBoundsContent = true,
            PresentationSkipEmbeddedData = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
            Preset = "preset",
            Priority = Priority.Critical,
            ProjectID = "project_id",
            RemoveHiddenText = true,
            ReplaceFailedPageMode = Parsing::FailPageMode.BlankPage,
            ReplaceFailedPageWithErrorMessagePrefix =
                "replace_failed_page_with_error_message_prefix",
            ReplaceFailedPageWithErrorMessageSuffix =
                "replace_failed_page_with_error_message_suffix",
            SaveImages = true,
            SkipDiagonalText = true,
            SpecializedChartParsingAgentic = true,
            SpecializedChartParsingEfficient = true,
            SpecializedChartParsingPlus = true,
            SpecializedImageParsing = true,
            SpreadsheetExtractSubTables = true,
            SpreadsheetForceFormulaComputation = true,
            SpreadsheetIncludeHiddenSheets = true,
            StrictModeBuggyFont = true,
            StrictModeImageExtraction = true,
            StrictModeImageOcr = true,
            StrictModeReconstruction = true,
            StructuredOutput = true,
            StructuredOutputJsonSchema = "structured_output_json_schema",
            StructuredOutputJsonSchemaName = "structured_output_json_schema_name",
            SystemPrompt = "system_prompt",
            SystemPromptAppend = "system_prompt_append",
            TakeScreenshot = true,
            TargetPages = "target_pages",
            Tier = "tier",
            UseVendorMultimodalModel = true,
            UserPrompt = "user_prompt",
            VendorMultimodalApiKey = "vendor_multimodal_api_key",
            VendorMultimodalModelName = "vendor_multimodal_model_name",
            Version = "version",
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
                    WebhookHeaders = new Dictionary<string, string>()
                    {
                        { "Authorization", "Bearer sk-..." },
                    },
                    WebhookOutputFormat = "json",
                    WebhookSigningSecret = "whsec_...",
                    WebhookUrl = "https://example.com/webhooks/llamacloud",
                },
            ],
            WebhookUrl = "webhook_url",
        };

        Assert.Null(model.Languages);
        Assert.False(model.RawData.ContainsKey("languages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new LlamaParseParameters
        {
            AdaptiveLongTable = true,
            AggressiveTableExtraction = true,
            AnnotateLineNumbers = true,
            AnnotateLinks = true,
            AnnotateRevisions = true,
            AutoMode = true,
            AutoModeConfigurationJson = "auto_mode_configuration_json",
            AutoModeTriggerOnImageInPage = true,
            AutoModeTriggerOnRegexpInPage = "auto_mode_trigger_on_regexp_in_page",
            AutoModeTriggerOnTableInPage = true,
            AutoModeTriggerOnTextInPage = "auto_mode_trigger_on_text_in_page",
            AzureOpenAIApiVersion = "azure_openai_api_version",
            AzureOpenAIDeploymentName = "azure_openai_deployment_name",
            AzureOpenAIEndpoint = "azure_openai_endpoint",
            AzureOpenAIKey = "azure_openai_key",
            BboxBottom = 0,
            BboxLeft = 0,
            BboxRight = 0,
            BboxTop = 0,
            BoundingBox = "bounding_box",
            CompactMarkdownTable = true,
            ComplementalFormattingInstruction = "complemental_formatting_instruction",
            ConfidenceScoreEffort = "confidence_score_effort",
            ContentGuidelineInstruction = "content_guideline_instruction",
            ContinuousMode = true,
            DisableImageExtraction = true,
            DisableOcr = true,
            DisableReconstruction = true,
            DoNotCache = true,
            DoNotUnrollColumns = true,
            EnableCostOptimizer = true,
            ExtractCharts = true,
            ExtractLayout = true,
            ExtractPrintedPageNumber = true,
            FastMode = true,
            FormattingInstruction = "formatting_instruction",
            Gpt4oApiKey = "gpt4o_api_key",
            Gpt4oMode = true,
            GuessXlsxSheetName = true,
            HideFooters = true,
            HideHeaders = true,
            HighResOcr = true,
            HtmlMakeAllElementsVisible = true,
            HtmlRemoveFixedElements = true,
            HtmlRemoveNavigationElements = true,
            HttpProxy = "http_proxy",
            IgnoreDocumentElementsForLayoutDetection = true,
            ImagesToSave = [ImagesToSave.Embedded],
            InlineImagesInMarkdown = true,
            InputS3Path = "input_s3_path",
            InputS3Region = "input_s3_region",
            InputUrl = "input_url",
            InternalIsScreenshotJob = true,
            InvalidateCache = true,
            IsFormattingInstruction = true,
            JobTimeoutExtraTimePerPageInSeconds = 0,
            JobTimeoutInSeconds = 0,
            KeepPageSeparatorWhenMergingTables = true,
            LayoutAware = true,
            LineLevelBoundingBox = true,
            MarkdownTableMultilineHeaderSeparator = "markdown_table_multiline_header_separator",
            MaxPages = 0,
            MaxPagesEnforced = 0,
            MergeTablesAcrossPagesInMarkdown = true,
            Model = "model",
            OutlinedTableExtraction = true,
            OutputPdfOfDocument = true,
            OutputS3PathPrefix = "output_s3_path_prefix",
            OutputS3Region = "output_s3_region",
            OutputTablesAsHtml = true,
            PageErrorTolerance = 0,
            PageFooterPrefix = "page_footer_prefix",
            PageFooterSuffix = "page_footer_suffix",
            PageHeaderPrefix = "page_header_prefix",
            PageHeaderSuffix = "page_header_suffix",
            PagePrefix = "page_prefix",
            PageSeparator = "page_separator",
            PageSuffix = "page_suffix",
            ParseMode = Parsing::ParsingMode.ParseDocumentWithAgent,
            ParsingInstruction = "parsing_instruction",
            PreciseBoundingBox = true,
            PremiumMode = true,
            PresentationOutOfBoundsContent = true,
            PresentationSkipEmbeddedData = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
            Preset = "preset",
            Priority = Priority.Critical,
            ProjectID = "project_id",
            RemoveHiddenText = true,
            ReplaceFailedPageMode = Parsing::FailPageMode.BlankPage,
            ReplaceFailedPageWithErrorMessagePrefix =
                "replace_failed_page_with_error_message_prefix",
            ReplaceFailedPageWithErrorMessageSuffix =
                "replace_failed_page_with_error_message_suffix",
            SaveImages = true,
            SkipDiagonalText = true,
            SpecializedChartParsingAgentic = true,
            SpecializedChartParsingEfficient = true,
            SpecializedChartParsingPlus = true,
            SpecializedImageParsing = true,
            SpreadsheetExtractSubTables = true,
            SpreadsheetForceFormulaComputation = true,
            SpreadsheetIncludeHiddenSheets = true,
            StrictModeBuggyFont = true,
            StrictModeImageExtraction = true,
            StrictModeImageOcr = true,
            StrictModeReconstruction = true,
            StructuredOutput = true,
            StructuredOutputJsonSchema = "structured_output_json_schema",
            StructuredOutputJsonSchemaName = "structured_output_json_schema_name",
            SystemPrompt = "system_prompt",
            SystemPromptAppend = "system_prompt_append",
            TakeScreenshot = true,
            TargetPages = "target_pages",
            Tier = "tier",
            UseVendorMultimodalModel = true,
            UserPrompt = "user_prompt",
            VendorMultimodalApiKey = "vendor_multimodal_api_key",
            VendorMultimodalModelName = "vendor_multimodal_model_name",
            Version = "version",
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
                    WebhookHeaders = new Dictionary<string, string>()
                    {
                        { "Authorization", "Bearer sk-..." },
                    },
                    WebhookOutputFormat = "json",
                    WebhookSigningSecret = "whsec_...",
                    WebhookUrl = "https://example.com/webhooks/llamacloud",
                },
            ],
            WebhookUrl = "webhook_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new LlamaParseParameters
        {
            AdaptiveLongTable = true,
            AggressiveTableExtraction = true,
            AnnotateLineNumbers = true,
            AnnotateLinks = true,
            AnnotateRevisions = true,
            AutoMode = true,
            AutoModeConfigurationJson = "auto_mode_configuration_json",
            AutoModeTriggerOnImageInPage = true,
            AutoModeTriggerOnRegexpInPage = "auto_mode_trigger_on_regexp_in_page",
            AutoModeTriggerOnTableInPage = true,
            AutoModeTriggerOnTextInPage = "auto_mode_trigger_on_text_in_page",
            AzureOpenAIApiVersion = "azure_openai_api_version",
            AzureOpenAIDeploymentName = "azure_openai_deployment_name",
            AzureOpenAIEndpoint = "azure_openai_endpoint",
            AzureOpenAIKey = "azure_openai_key",
            BboxBottom = 0,
            BboxLeft = 0,
            BboxRight = 0,
            BboxTop = 0,
            BoundingBox = "bounding_box",
            CompactMarkdownTable = true,
            ComplementalFormattingInstruction = "complemental_formatting_instruction",
            ConfidenceScoreEffort = "confidence_score_effort",
            ContentGuidelineInstruction = "content_guideline_instruction",
            ContinuousMode = true,
            DisableImageExtraction = true,
            DisableOcr = true,
            DisableReconstruction = true,
            DoNotCache = true,
            DoNotUnrollColumns = true,
            EnableCostOptimizer = true,
            ExtractCharts = true,
            ExtractLayout = true,
            ExtractPrintedPageNumber = true,
            FastMode = true,
            FormattingInstruction = "formatting_instruction",
            Gpt4oApiKey = "gpt4o_api_key",
            Gpt4oMode = true,
            GuessXlsxSheetName = true,
            HideFooters = true,
            HideHeaders = true,
            HighResOcr = true,
            HtmlMakeAllElementsVisible = true,
            HtmlRemoveFixedElements = true,
            HtmlRemoveNavigationElements = true,
            HttpProxy = "http_proxy",
            IgnoreDocumentElementsForLayoutDetection = true,
            ImagesToSave = [ImagesToSave.Embedded],
            InlineImagesInMarkdown = true,
            InputS3Path = "input_s3_path",
            InputS3Region = "input_s3_region",
            InputUrl = "input_url",
            InternalIsScreenshotJob = true,
            InvalidateCache = true,
            IsFormattingInstruction = true,
            JobTimeoutExtraTimePerPageInSeconds = 0,
            JobTimeoutInSeconds = 0,
            KeepPageSeparatorWhenMergingTables = true,
            LayoutAware = true,
            LineLevelBoundingBox = true,
            MarkdownTableMultilineHeaderSeparator = "markdown_table_multiline_header_separator",
            MaxPages = 0,
            MaxPagesEnforced = 0,
            MergeTablesAcrossPagesInMarkdown = true,
            Model = "model",
            OutlinedTableExtraction = true,
            OutputPdfOfDocument = true,
            OutputS3PathPrefix = "output_s3_path_prefix",
            OutputS3Region = "output_s3_region",
            OutputTablesAsHtml = true,
            PageErrorTolerance = 0,
            PageFooterPrefix = "page_footer_prefix",
            PageFooterSuffix = "page_footer_suffix",
            PageHeaderPrefix = "page_header_prefix",
            PageHeaderSuffix = "page_header_suffix",
            PagePrefix = "page_prefix",
            PageSeparator = "page_separator",
            PageSuffix = "page_suffix",
            ParseMode = Parsing::ParsingMode.ParseDocumentWithAgent,
            ParsingInstruction = "parsing_instruction",
            PreciseBoundingBox = true,
            PremiumMode = true,
            PresentationOutOfBoundsContent = true,
            PresentationSkipEmbeddedData = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
            Preset = "preset",
            Priority = Priority.Critical,
            ProjectID = "project_id",
            RemoveHiddenText = true,
            ReplaceFailedPageMode = Parsing::FailPageMode.BlankPage,
            ReplaceFailedPageWithErrorMessagePrefix =
                "replace_failed_page_with_error_message_prefix",
            ReplaceFailedPageWithErrorMessageSuffix =
                "replace_failed_page_with_error_message_suffix",
            SaveImages = true,
            SkipDiagonalText = true,
            SpecializedChartParsingAgentic = true,
            SpecializedChartParsingEfficient = true,
            SpecializedChartParsingPlus = true,
            SpecializedImageParsing = true,
            SpreadsheetExtractSubTables = true,
            SpreadsheetForceFormulaComputation = true,
            SpreadsheetIncludeHiddenSheets = true,
            StrictModeBuggyFont = true,
            StrictModeImageExtraction = true,
            StrictModeImageOcr = true,
            StrictModeReconstruction = true,
            StructuredOutput = true,
            StructuredOutputJsonSchema = "structured_output_json_schema",
            StructuredOutputJsonSchemaName = "structured_output_json_schema_name",
            SystemPrompt = "system_prompt",
            SystemPromptAppend = "system_prompt_append",
            TakeScreenshot = true,
            TargetPages = "target_pages",
            Tier = "tier",
            UseVendorMultimodalModel = true,
            UserPrompt = "user_prompt",
            VendorMultimodalApiKey = "vendor_multimodal_api_key",
            VendorMultimodalModelName = "vendor_multimodal_model_name",
            Version = "version",
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
                    WebhookHeaders = new Dictionary<string, string>()
                    {
                        { "Authorization", "Bearer sk-..." },
                    },
                    WebhookOutputFormat = "json",
                    WebhookSigningSecret = "whsec_...",
                    WebhookUrl = "https://example.com/webhooks/llamacloud",
                },
            ],
            WebhookUrl = "webhook_url",

            // Null should be interpreted as omitted for these properties
            Languages = null,
        };

        Assert.Null(model.Languages);
        Assert.False(model.RawData.ContainsKey("languages"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LlamaParseParameters
        {
            AdaptiveLongTable = true,
            AggressiveTableExtraction = true,
            AnnotateLineNumbers = true,
            AnnotateLinks = true,
            AnnotateRevisions = true,
            AutoMode = true,
            AutoModeConfigurationJson = "auto_mode_configuration_json",
            AutoModeTriggerOnImageInPage = true,
            AutoModeTriggerOnRegexpInPage = "auto_mode_trigger_on_regexp_in_page",
            AutoModeTriggerOnTableInPage = true,
            AutoModeTriggerOnTextInPage = "auto_mode_trigger_on_text_in_page",
            AzureOpenAIApiVersion = "azure_openai_api_version",
            AzureOpenAIDeploymentName = "azure_openai_deployment_name",
            AzureOpenAIEndpoint = "azure_openai_endpoint",
            AzureOpenAIKey = "azure_openai_key",
            BboxBottom = 0,
            BboxLeft = 0,
            BboxRight = 0,
            BboxTop = 0,
            BoundingBox = "bounding_box",
            CompactMarkdownTable = true,
            ComplementalFormattingInstruction = "complemental_formatting_instruction",
            ConfidenceScoreEffort = "confidence_score_effort",
            ContentGuidelineInstruction = "content_guideline_instruction",
            ContinuousMode = true,
            DisableImageExtraction = true,
            DisableOcr = true,
            DisableReconstruction = true,
            DoNotCache = true,
            DoNotUnrollColumns = true,
            EnableCostOptimizer = true,
            ExtractCharts = true,
            ExtractLayout = true,
            ExtractPrintedPageNumber = true,
            FastMode = true,
            FormattingInstruction = "formatting_instruction",
            Gpt4oApiKey = "gpt4o_api_key",
            Gpt4oMode = true,
            GuessXlsxSheetName = true,
            HideFooters = true,
            HideHeaders = true,
            HighResOcr = true,
            HtmlMakeAllElementsVisible = true,
            HtmlRemoveFixedElements = true,
            HtmlRemoveNavigationElements = true,
            HttpProxy = "http_proxy",
            IgnoreDocumentElementsForLayoutDetection = true,
            ImagesToSave = [ImagesToSave.Embedded],
            InlineImagesInMarkdown = true,
            InputS3Path = "input_s3_path",
            InputS3Region = "input_s3_region",
            InputUrl = "input_url",
            InternalIsScreenshotJob = true,
            InvalidateCache = true,
            IsFormattingInstruction = true,
            JobTimeoutExtraTimePerPageInSeconds = 0,
            JobTimeoutInSeconds = 0,
            KeepPageSeparatorWhenMergingTables = true,
            LayoutAware = true,
            LineLevelBoundingBox = true,
            MarkdownTableMultilineHeaderSeparator = "markdown_table_multiline_header_separator",
            MaxPages = 0,
            MaxPagesEnforced = 0,
            MergeTablesAcrossPagesInMarkdown = true,
            Model = "model",
            OutlinedTableExtraction = true,
            OutputPdfOfDocument = true,
            OutputS3PathPrefix = "output_s3_path_prefix",
            OutputS3Region = "output_s3_region",
            OutputTablesAsHtml = true,
            PageErrorTolerance = 0,
            PageFooterPrefix = "page_footer_prefix",
            PageFooterSuffix = "page_footer_suffix",
            PageHeaderPrefix = "page_header_prefix",
            PageHeaderSuffix = "page_header_suffix",
            PagePrefix = "page_prefix",
            PageSeparator = "page_separator",
            PageSuffix = "page_suffix",
            ParseMode = Parsing::ParsingMode.ParseDocumentWithAgent,
            ParsingInstruction = "parsing_instruction",
            PreciseBoundingBox = true,
            PremiumMode = true,
            PresentationOutOfBoundsContent = true,
            PresentationSkipEmbeddedData = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
            Preset = "preset",
            Priority = Priority.Critical,
            ProjectID = "project_id",
            RemoveHiddenText = true,
            ReplaceFailedPageMode = Parsing::FailPageMode.BlankPage,
            ReplaceFailedPageWithErrorMessagePrefix =
                "replace_failed_page_with_error_message_prefix",
            ReplaceFailedPageWithErrorMessageSuffix =
                "replace_failed_page_with_error_message_suffix",
            SaveImages = true,
            SkipDiagonalText = true,
            SpecializedChartParsingAgentic = true,
            SpecializedChartParsingEfficient = true,
            SpecializedChartParsingPlus = true,
            SpecializedImageParsing = true,
            SpreadsheetExtractSubTables = true,
            SpreadsheetForceFormulaComputation = true,
            SpreadsheetIncludeHiddenSheets = true,
            StrictModeBuggyFont = true,
            StrictModeImageExtraction = true,
            StrictModeImageOcr = true,
            StrictModeReconstruction = true,
            StructuredOutput = true,
            StructuredOutputJsonSchema = "structured_output_json_schema",
            StructuredOutputJsonSchemaName = "structured_output_json_schema_name",
            SystemPrompt = "system_prompt",
            SystemPromptAppend = "system_prompt_append",
            TakeScreenshot = true,
            TargetPages = "target_pages",
            Tier = "tier",
            UseVendorMultimodalModel = true,
            UserPrompt = "user_prompt",
            VendorMultimodalApiKey = "vendor_multimodal_api_key",
            VendorMultimodalModelName = "vendor_multimodal_model_name",
            Version = "version",
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
                    WebhookHeaders = new Dictionary<string, string>()
                    {
                        { "Authorization", "Bearer sk-..." },
                    },
                    WebhookOutputFormat = "json",
                    WebhookSigningSecret = "whsec_...",
                    WebhookUrl = "https://example.com/webhooks/llamacloud",
                },
            ],
            WebhookUrl = "webhook_url",

            // Null should be interpreted as omitted for these properties
            Languages = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LlamaParseParameters { Languages = [Parsing::ParsingLanguages.Abq] };

        Assert.Null(model.AdaptiveLongTable);
        Assert.False(model.RawData.ContainsKey("adaptive_long_table"));
        Assert.Null(model.AggressiveTableExtraction);
        Assert.False(model.RawData.ContainsKey("aggressive_table_extraction"));
        Assert.Null(model.AnnotateLineNumbers);
        Assert.False(model.RawData.ContainsKey("annotate_line_numbers"));
        Assert.Null(model.AnnotateLinks);
        Assert.False(model.RawData.ContainsKey("annotate_links"));
        Assert.Null(model.AnnotateRevisions);
        Assert.False(model.RawData.ContainsKey("annotate_revisions"));
        Assert.Null(model.AutoMode);
        Assert.False(model.RawData.ContainsKey("auto_mode"));
        Assert.Null(model.AutoModeConfigurationJson);
        Assert.False(model.RawData.ContainsKey("auto_mode_configuration_json"));
        Assert.Null(model.AutoModeTriggerOnImageInPage);
        Assert.False(model.RawData.ContainsKey("auto_mode_trigger_on_image_in_page"));
        Assert.Null(model.AutoModeTriggerOnRegexpInPage);
        Assert.False(model.RawData.ContainsKey("auto_mode_trigger_on_regexp_in_page"));
        Assert.Null(model.AutoModeTriggerOnTableInPage);
        Assert.False(model.RawData.ContainsKey("auto_mode_trigger_on_table_in_page"));
        Assert.Null(model.AutoModeTriggerOnTextInPage);
        Assert.False(model.RawData.ContainsKey("auto_mode_trigger_on_text_in_page"));
        Assert.Null(model.AzureOpenAIApiVersion);
        Assert.False(model.RawData.ContainsKey("azure_openai_api_version"));
        Assert.Null(model.AzureOpenAIDeploymentName);
        Assert.False(model.RawData.ContainsKey("azure_openai_deployment_name"));
        Assert.Null(model.AzureOpenAIEndpoint);
        Assert.False(model.RawData.ContainsKey("azure_openai_endpoint"));
        Assert.Null(model.AzureOpenAIKey);
        Assert.False(model.RawData.ContainsKey("azure_openai_key"));
        Assert.Null(model.BboxBottom);
        Assert.False(model.RawData.ContainsKey("bbox_bottom"));
        Assert.Null(model.BboxLeft);
        Assert.False(model.RawData.ContainsKey("bbox_left"));
        Assert.Null(model.BboxRight);
        Assert.False(model.RawData.ContainsKey("bbox_right"));
        Assert.Null(model.BboxTop);
        Assert.False(model.RawData.ContainsKey("bbox_top"));
        Assert.Null(model.BoundingBox);
        Assert.False(model.RawData.ContainsKey("bounding_box"));
        Assert.Null(model.CompactMarkdownTable);
        Assert.False(model.RawData.ContainsKey("compact_markdown_table"));
        Assert.Null(model.ComplementalFormattingInstruction);
        Assert.False(model.RawData.ContainsKey("complemental_formatting_instruction"));
        Assert.Null(model.ConfidenceScoreEffort);
        Assert.False(model.RawData.ContainsKey("confidence_score_effort"));
        Assert.Null(model.ContentGuidelineInstruction);
        Assert.False(model.RawData.ContainsKey("content_guideline_instruction"));
        Assert.Null(model.ContinuousMode);
        Assert.False(model.RawData.ContainsKey("continuous_mode"));
        Assert.Null(model.DisableImageExtraction);
        Assert.False(model.RawData.ContainsKey("disable_image_extraction"));
        Assert.Null(model.DisableOcr);
        Assert.False(model.RawData.ContainsKey("disable_ocr"));
        Assert.Null(model.DisableReconstruction);
        Assert.False(model.RawData.ContainsKey("disable_reconstruction"));
        Assert.Null(model.DoNotCache);
        Assert.False(model.RawData.ContainsKey("do_not_cache"));
        Assert.Null(model.DoNotUnrollColumns);
        Assert.False(model.RawData.ContainsKey("do_not_unroll_columns"));
        Assert.Null(model.EnableCostOptimizer);
        Assert.False(model.RawData.ContainsKey("enable_cost_optimizer"));
        Assert.Null(model.ExtractCharts);
        Assert.False(model.RawData.ContainsKey("extract_charts"));
        Assert.Null(model.ExtractLayout);
        Assert.False(model.RawData.ContainsKey("extract_layout"));
        Assert.Null(model.ExtractPrintedPageNumber);
        Assert.False(model.RawData.ContainsKey("extract_printed_page_number"));
        Assert.Null(model.FastMode);
        Assert.False(model.RawData.ContainsKey("fast_mode"));
        Assert.Null(model.FormattingInstruction);
        Assert.False(model.RawData.ContainsKey("formatting_instruction"));
        Assert.Null(model.Gpt4oApiKey);
        Assert.False(model.RawData.ContainsKey("gpt4o_api_key"));
        Assert.Null(model.Gpt4oMode);
        Assert.False(model.RawData.ContainsKey("gpt4o_mode"));
        Assert.Null(model.GuessXlsxSheetName);
        Assert.False(model.RawData.ContainsKey("guess_xlsx_sheet_name"));
        Assert.Null(model.HideFooters);
        Assert.False(model.RawData.ContainsKey("hide_footers"));
        Assert.Null(model.HideHeaders);
        Assert.False(model.RawData.ContainsKey("hide_headers"));
        Assert.Null(model.HighResOcr);
        Assert.False(model.RawData.ContainsKey("high_res_ocr"));
        Assert.Null(model.HtmlMakeAllElementsVisible);
        Assert.False(model.RawData.ContainsKey("html_make_all_elements_visible"));
        Assert.Null(model.HtmlRemoveFixedElements);
        Assert.False(model.RawData.ContainsKey("html_remove_fixed_elements"));
        Assert.Null(model.HtmlRemoveNavigationElements);
        Assert.False(model.RawData.ContainsKey("html_remove_navigation_elements"));
        Assert.Null(model.HttpProxy);
        Assert.False(model.RawData.ContainsKey("http_proxy"));
        Assert.Null(model.IgnoreDocumentElementsForLayoutDetection);
        Assert.False(model.RawData.ContainsKey("ignore_document_elements_for_layout_detection"));
        Assert.Null(model.ImagesToSave);
        Assert.False(model.RawData.ContainsKey("images_to_save"));
        Assert.Null(model.InlineImagesInMarkdown);
        Assert.False(model.RawData.ContainsKey("inline_images_in_markdown"));
        Assert.Null(model.InputS3Path);
        Assert.False(model.RawData.ContainsKey("input_s3_path"));
        Assert.Null(model.InputS3Region);
        Assert.False(model.RawData.ContainsKey("input_s3_region"));
        Assert.Null(model.InputUrl);
        Assert.False(model.RawData.ContainsKey("input_url"));
        Assert.Null(model.InternalIsScreenshotJob);
        Assert.False(model.RawData.ContainsKey("internal_is_screenshot_job"));
        Assert.Null(model.InvalidateCache);
        Assert.False(model.RawData.ContainsKey("invalidate_cache"));
        Assert.Null(model.IsFormattingInstruction);
        Assert.False(model.RawData.ContainsKey("is_formatting_instruction"));
        Assert.Null(model.JobTimeoutExtraTimePerPageInSeconds);
        Assert.False(model.RawData.ContainsKey("job_timeout_extra_time_per_page_in_seconds"));
        Assert.Null(model.JobTimeoutInSeconds);
        Assert.False(model.RawData.ContainsKey("job_timeout_in_seconds"));
        Assert.Null(model.KeepPageSeparatorWhenMergingTables);
        Assert.False(model.RawData.ContainsKey("keep_page_separator_when_merging_tables"));
        Assert.Null(model.LayoutAware);
        Assert.False(model.RawData.ContainsKey("layout_aware"));
        Assert.Null(model.LineLevelBoundingBox);
        Assert.False(model.RawData.ContainsKey("line_level_bounding_box"));
        Assert.Null(model.MarkdownTableMultilineHeaderSeparator);
        Assert.False(model.RawData.ContainsKey("markdown_table_multiline_header_separator"));
        Assert.Null(model.MaxPages);
        Assert.False(model.RawData.ContainsKey("max_pages"));
        Assert.Null(model.MaxPagesEnforced);
        Assert.False(model.RawData.ContainsKey("max_pages_enforced"));
        Assert.Null(model.MergeTablesAcrossPagesInMarkdown);
        Assert.False(model.RawData.ContainsKey("merge_tables_across_pages_in_markdown"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
        Assert.Null(model.OutlinedTableExtraction);
        Assert.False(model.RawData.ContainsKey("outlined_table_extraction"));
        Assert.Null(model.OutputPdfOfDocument);
        Assert.False(model.RawData.ContainsKey("output_pdf_of_document"));
        Assert.Null(model.OutputS3PathPrefix);
        Assert.False(model.RawData.ContainsKey("output_s3_path_prefix"));
        Assert.Null(model.OutputS3Region);
        Assert.False(model.RawData.ContainsKey("output_s3_region"));
        Assert.Null(model.OutputTablesAsHtml);
        Assert.False(model.RawData.ContainsKey("output_tables_as_HTML"));
        Assert.Null(model.PageErrorTolerance);
        Assert.False(model.RawData.ContainsKey("page_error_tolerance"));
        Assert.Null(model.PageFooterPrefix);
        Assert.False(model.RawData.ContainsKey("page_footer_prefix"));
        Assert.Null(model.PageFooterSuffix);
        Assert.False(model.RawData.ContainsKey("page_footer_suffix"));
        Assert.Null(model.PageHeaderPrefix);
        Assert.False(model.RawData.ContainsKey("page_header_prefix"));
        Assert.Null(model.PageHeaderSuffix);
        Assert.False(model.RawData.ContainsKey("page_header_suffix"));
        Assert.Null(model.PagePrefix);
        Assert.False(model.RawData.ContainsKey("page_prefix"));
        Assert.Null(model.PageSeparator);
        Assert.False(model.RawData.ContainsKey("page_separator"));
        Assert.Null(model.PageSuffix);
        Assert.False(model.RawData.ContainsKey("page_suffix"));
        Assert.Null(model.ParseMode);
        Assert.False(model.RawData.ContainsKey("parse_mode"));
        Assert.Null(model.ParsingInstruction);
        Assert.False(model.RawData.ContainsKey("parsing_instruction"));
        Assert.Null(model.PreciseBoundingBox);
        Assert.False(model.RawData.ContainsKey("precise_bounding_box"));
        Assert.Null(model.PremiumMode);
        Assert.False(model.RawData.ContainsKey("premium_mode"));
        Assert.Null(model.PresentationOutOfBoundsContent);
        Assert.False(model.RawData.ContainsKey("presentation_out_of_bounds_content"));
        Assert.Null(model.PresentationSkipEmbeddedData);
        Assert.False(model.RawData.ContainsKey("presentation_skip_embedded_data"));
        Assert.Null(model.PreserveLayoutAlignmentAcrossPages);
        Assert.False(model.RawData.ContainsKey("preserve_layout_alignment_across_pages"));
        Assert.Null(model.PreserveVerySmallText);
        Assert.False(model.RawData.ContainsKey("preserve_very_small_text"));
        Assert.Null(model.Preset);
        Assert.False(model.RawData.ContainsKey("preset"));
        Assert.Null(model.Priority);
        Assert.False(model.RawData.ContainsKey("priority"));
        Assert.Null(model.ProjectID);
        Assert.False(model.RawData.ContainsKey("project_id"));
        Assert.Null(model.RemoveHiddenText);
        Assert.False(model.RawData.ContainsKey("remove_hidden_text"));
        Assert.Null(model.ReplaceFailedPageMode);
        Assert.False(model.RawData.ContainsKey("replace_failed_page_mode"));
        Assert.Null(model.ReplaceFailedPageWithErrorMessagePrefix);
        Assert.False(model.RawData.ContainsKey("replace_failed_page_with_error_message_prefix"));
        Assert.Null(model.ReplaceFailedPageWithErrorMessageSuffix);
        Assert.False(model.RawData.ContainsKey("replace_failed_page_with_error_message_suffix"));
        Assert.Null(model.SaveImages);
        Assert.False(model.RawData.ContainsKey("save_images"));
        Assert.Null(model.SkipDiagonalText);
        Assert.False(model.RawData.ContainsKey("skip_diagonal_text"));
        Assert.Null(model.SpecializedChartParsingAgentic);
        Assert.False(model.RawData.ContainsKey("specialized_chart_parsing_agentic"));
        Assert.Null(model.SpecializedChartParsingEfficient);
        Assert.False(model.RawData.ContainsKey("specialized_chart_parsing_efficient"));
        Assert.Null(model.SpecializedChartParsingPlus);
        Assert.False(model.RawData.ContainsKey("specialized_chart_parsing_plus"));
        Assert.Null(model.SpecializedImageParsing);
        Assert.False(model.RawData.ContainsKey("specialized_image_parsing"));
        Assert.Null(model.SpreadsheetExtractSubTables);
        Assert.False(model.RawData.ContainsKey("spreadsheet_extract_sub_tables"));
        Assert.Null(model.SpreadsheetForceFormulaComputation);
        Assert.False(model.RawData.ContainsKey("spreadsheet_force_formula_computation"));
        Assert.Null(model.SpreadsheetIncludeHiddenSheets);
        Assert.False(model.RawData.ContainsKey("spreadsheet_include_hidden_sheets"));
        Assert.Null(model.StrictModeBuggyFont);
        Assert.False(model.RawData.ContainsKey("strict_mode_buggy_font"));
        Assert.Null(model.StrictModeImageExtraction);
        Assert.False(model.RawData.ContainsKey("strict_mode_image_extraction"));
        Assert.Null(model.StrictModeImageOcr);
        Assert.False(model.RawData.ContainsKey("strict_mode_image_ocr"));
        Assert.Null(model.StrictModeReconstruction);
        Assert.False(model.RawData.ContainsKey("strict_mode_reconstruction"));
        Assert.Null(model.StructuredOutput);
        Assert.False(model.RawData.ContainsKey("structured_output"));
        Assert.Null(model.StructuredOutputJsonSchema);
        Assert.False(model.RawData.ContainsKey("structured_output_json_schema"));
        Assert.Null(model.StructuredOutputJsonSchemaName);
        Assert.False(model.RawData.ContainsKey("structured_output_json_schema_name"));
        Assert.Null(model.SystemPrompt);
        Assert.False(model.RawData.ContainsKey("system_prompt"));
        Assert.Null(model.SystemPromptAppend);
        Assert.False(model.RawData.ContainsKey("system_prompt_append"));
        Assert.Null(model.TakeScreenshot);
        Assert.False(model.RawData.ContainsKey("take_screenshot"));
        Assert.Null(model.TargetPages);
        Assert.False(model.RawData.ContainsKey("target_pages"));
        Assert.Null(model.Tier);
        Assert.False(model.RawData.ContainsKey("tier"));
        Assert.Null(model.UseVendorMultimodalModel);
        Assert.False(model.RawData.ContainsKey("use_vendor_multimodal_model"));
        Assert.Null(model.UserPrompt);
        Assert.False(model.RawData.ContainsKey("user_prompt"));
        Assert.Null(model.VendorMultimodalApiKey);
        Assert.False(model.RawData.ContainsKey("vendor_multimodal_api_key"));
        Assert.Null(model.VendorMultimodalModelName);
        Assert.False(model.RawData.ContainsKey("vendor_multimodal_model_name"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
        Assert.Null(model.WebhookConfigurations);
        Assert.False(model.RawData.ContainsKey("webhook_configurations"));
        Assert.Null(model.WebhookUrl);
        Assert.False(model.RawData.ContainsKey("webhook_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new LlamaParseParameters { Languages = [Parsing::ParsingLanguages.Abq] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LlamaParseParameters
        {
            Languages = [Parsing::ParsingLanguages.Abq],

            AdaptiveLongTable = null,
            AggressiveTableExtraction = null,
            AnnotateLineNumbers = null,
            AnnotateLinks = null,
            AnnotateRevisions = null,
            AutoMode = null,
            AutoModeConfigurationJson = null,
            AutoModeTriggerOnImageInPage = null,
            AutoModeTriggerOnRegexpInPage = null,
            AutoModeTriggerOnTableInPage = null,
            AutoModeTriggerOnTextInPage = null,
            AzureOpenAIApiVersion = null,
            AzureOpenAIDeploymentName = null,
            AzureOpenAIEndpoint = null,
            AzureOpenAIKey = null,
            BboxBottom = null,
            BboxLeft = null,
            BboxRight = null,
            BboxTop = null,
            BoundingBox = null,
            CompactMarkdownTable = null,
            ComplementalFormattingInstruction = null,
            ConfidenceScoreEffort = null,
            ContentGuidelineInstruction = null,
            ContinuousMode = null,
            DisableImageExtraction = null,
            DisableOcr = null,
            DisableReconstruction = null,
            DoNotCache = null,
            DoNotUnrollColumns = null,
            EnableCostOptimizer = null,
            ExtractCharts = null,
            ExtractLayout = null,
            ExtractPrintedPageNumber = null,
            FastMode = null,
            FormattingInstruction = null,
            Gpt4oApiKey = null,
            Gpt4oMode = null,
            GuessXlsxSheetName = null,
            HideFooters = null,
            HideHeaders = null,
            HighResOcr = null,
            HtmlMakeAllElementsVisible = null,
            HtmlRemoveFixedElements = null,
            HtmlRemoveNavigationElements = null,
            HttpProxy = null,
            IgnoreDocumentElementsForLayoutDetection = null,
            ImagesToSave = null,
            InlineImagesInMarkdown = null,
            InputS3Path = null,
            InputS3Region = null,
            InputUrl = null,
            InternalIsScreenshotJob = null,
            InvalidateCache = null,
            IsFormattingInstruction = null,
            JobTimeoutExtraTimePerPageInSeconds = null,
            JobTimeoutInSeconds = null,
            KeepPageSeparatorWhenMergingTables = null,
            LayoutAware = null,
            LineLevelBoundingBox = null,
            MarkdownTableMultilineHeaderSeparator = null,
            MaxPages = null,
            MaxPagesEnforced = null,
            MergeTablesAcrossPagesInMarkdown = null,
            Model = null,
            OutlinedTableExtraction = null,
            OutputPdfOfDocument = null,
            OutputS3PathPrefix = null,
            OutputS3Region = null,
            OutputTablesAsHtml = null,
            PageErrorTolerance = null,
            PageFooterPrefix = null,
            PageFooterSuffix = null,
            PageHeaderPrefix = null,
            PageHeaderSuffix = null,
            PagePrefix = null,
            PageSeparator = null,
            PageSuffix = null,
            ParseMode = null,
            ParsingInstruction = null,
            PreciseBoundingBox = null,
            PremiumMode = null,
            PresentationOutOfBoundsContent = null,
            PresentationSkipEmbeddedData = null,
            PreserveLayoutAlignmentAcrossPages = null,
            PreserveVerySmallText = null,
            Preset = null,
            Priority = null,
            ProjectID = null,
            RemoveHiddenText = null,
            ReplaceFailedPageMode = null,
            ReplaceFailedPageWithErrorMessagePrefix = null,
            ReplaceFailedPageWithErrorMessageSuffix = null,
            SaveImages = null,
            SkipDiagonalText = null,
            SpecializedChartParsingAgentic = null,
            SpecializedChartParsingEfficient = null,
            SpecializedChartParsingPlus = null,
            SpecializedImageParsing = null,
            SpreadsheetExtractSubTables = null,
            SpreadsheetForceFormulaComputation = null,
            SpreadsheetIncludeHiddenSheets = null,
            StrictModeBuggyFont = null,
            StrictModeImageExtraction = null,
            StrictModeImageOcr = null,
            StrictModeReconstruction = null,
            StructuredOutput = null,
            StructuredOutputJsonSchema = null,
            StructuredOutputJsonSchemaName = null,
            SystemPrompt = null,
            SystemPromptAppend = null,
            TakeScreenshot = null,
            TargetPages = null,
            Tier = null,
            UseVendorMultimodalModel = null,
            UserPrompt = null,
            VendorMultimodalApiKey = null,
            VendorMultimodalModelName = null,
            Version = null,
            WebhookConfigurations = null,
            WebhookUrl = null,
        };

        Assert.Null(model.AdaptiveLongTable);
        Assert.True(model.RawData.ContainsKey("adaptive_long_table"));
        Assert.Null(model.AggressiveTableExtraction);
        Assert.True(model.RawData.ContainsKey("aggressive_table_extraction"));
        Assert.Null(model.AnnotateLineNumbers);
        Assert.True(model.RawData.ContainsKey("annotate_line_numbers"));
        Assert.Null(model.AnnotateLinks);
        Assert.True(model.RawData.ContainsKey("annotate_links"));
        Assert.Null(model.AnnotateRevisions);
        Assert.True(model.RawData.ContainsKey("annotate_revisions"));
        Assert.Null(model.AutoMode);
        Assert.True(model.RawData.ContainsKey("auto_mode"));
        Assert.Null(model.AutoModeConfigurationJson);
        Assert.True(model.RawData.ContainsKey("auto_mode_configuration_json"));
        Assert.Null(model.AutoModeTriggerOnImageInPage);
        Assert.True(model.RawData.ContainsKey("auto_mode_trigger_on_image_in_page"));
        Assert.Null(model.AutoModeTriggerOnRegexpInPage);
        Assert.True(model.RawData.ContainsKey("auto_mode_trigger_on_regexp_in_page"));
        Assert.Null(model.AutoModeTriggerOnTableInPage);
        Assert.True(model.RawData.ContainsKey("auto_mode_trigger_on_table_in_page"));
        Assert.Null(model.AutoModeTriggerOnTextInPage);
        Assert.True(model.RawData.ContainsKey("auto_mode_trigger_on_text_in_page"));
        Assert.Null(model.AzureOpenAIApiVersion);
        Assert.True(model.RawData.ContainsKey("azure_openai_api_version"));
        Assert.Null(model.AzureOpenAIDeploymentName);
        Assert.True(model.RawData.ContainsKey("azure_openai_deployment_name"));
        Assert.Null(model.AzureOpenAIEndpoint);
        Assert.True(model.RawData.ContainsKey("azure_openai_endpoint"));
        Assert.Null(model.AzureOpenAIKey);
        Assert.True(model.RawData.ContainsKey("azure_openai_key"));
        Assert.Null(model.BboxBottom);
        Assert.True(model.RawData.ContainsKey("bbox_bottom"));
        Assert.Null(model.BboxLeft);
        Assert.True(model.RawData.ContainsKey("bbox_left"));
        Assert.Null(model.BboxRight);
        Assert.True(model.RawData.ContainsKey("bbox_right"));
        Assert.Null(model.BboxTop);
        Assert.True(model.RawData.ContainsKey("bbox_top"));
        Assert.Null(model.BoundingBox);
        Assert.True(model.RawData.ContainsKey("bounding_box"));
        Assert.Null(model.CompactMarkdownTable);
        Assert.True(model.RawData.ContainsKey("compact_markdown_table"));
        Assert.Null(model.ComplementalFormattingInstruction);
        Assert.True(model.RawData.ContainsKey("complemental_formatting_instruction"));
        Assert.Null(model.ConfidenceScoreEffort);
        Assert.True(model.RawData.ContainsKey("confidence_score_effort"));
        Assert.Null(model.ContentGuidelineInstruction);
        Assert.True(model.RawData.ContainsKey("content_guideline_instruction"));
        Assert.Null(model.ContinuousMode);
        Assert.True(model.RawData.ContainsKey("continuous_mode"));
        Assert.Null(model.DisableImageExtraction);
        Assert.True(model.RawData.ContainsKey("disable_image_extraction"));
        Assert.Null(model.DisableOcr);
        Assert.True(model.RawData.ContainsKey("disable_ocr"));
        Assert.Null(model.DisableReconstruction);
        Assert.True(model.RawData.ContainsKey("disable_reconstruction"));
        Assert.Null(model.DoNotCache);
        Assert.True(model.RawData.ContainsKey("do_not_cache"));
        Assert.Null(model.DoNotUnrollColumns);
        Assert.True(model.RawData.ContainsKey("do_not_unroll_columns"));
        Assert.Null(model.EnableCostOptimizer);
        Assert.True(model.RawData.ContainsKey("enable_cost_optimizer"));
        Assert.Null(model.ExtractCharts);
        Assert.True(model.RawData.ContainsKey("extract_charts"));
        Assert.Null(model.ExtractLayout);
        Assert.True(model.RawData.ContainsKey("extract_layout"));
        Assert.Null(model.ExtractPrintedPageNumber);
        Assert.True(model.RawData.ContainsKey("extract_printed_page_number"));
        Assert.Null(model.FastMode);
        Assert.True(model.RawData.ContainsKey("fast_mode"));
        Assert.Null(model.FormattingInstruction);
        Assert.True(model.RawData.ContainsKey("formatting_instruction"));
        Assert.Null(model.Gpt4oApiKey);
        Assert.True(model.RawData.ContainsKey("gpt4o_api_key"));
        Assert.Null(model.Gpt4oMode);
        Assert.True(model.RawData.ContainsKey("gpt4o_mode"));
        Assert.Null(model.GuessXlsxSheetName);
        Assert.True(model.RawData.ContainsKey("guess_xlsx_sheet_name"));
        Assert.Null(model.HideFooters);
        Assert.True(model.RawData.ContainsKey("hide_footers"));
        Assert.Null(model.HideHeaders);
        Assert.True(model.RawData.ContainsKey("hide_headers"));
        Assert.Null(model.HighResOcr);
        Assert.True(model.RawData.ContainsKey("high_res_ocr"));
        Assert.Null(model.HtmlMakeAllElementsVisible);
        Assert.True(model.RawData.ContainsKey("html_make_all_elements_visible"));
        Assert.Null(model.HtmlRemoveFixedElements);
        Assert.True(model.RawData.ContainsKey("html_remove_fixed_elements"));
        Assert.Null(model.HtmlRemoveNavigationElements);
        Assert.True(model.RawData.ContainsKey("html_remove_navigation_elements"));
        Assert.Null(model.HttpProxy);
        Assert.True(model.RawData.ContainsKey("http_proxy"));
        Assert.Null(model.IgnoreDocumentElementsForLayoutDetection);
        Assert.True(model.RawData.ContainsKey("ignore_document_elements_for_layout_detection"));
        Assert.Null(model.ImagesToSave);
        Assert.True(model.RawData.ContainsKey("images_to_save"));
        Assert.Null(model.InlineImagesInMarkdown);
        Assert.True(model.RawData.ContainsKey("inline_images_in_markdown"));
        Assert.Null(model.InputS3Path);
        Assert.True(model.RawData.ContainsKey("input_s3_path"));
        Assert.Null(model.InputS3Region);
        Assert.True(model.RawData.ContainsKey("input_s3_region"));
        Assert.Null(model.InputUrl);
        Assert.True(model.RawData.ContainsKey("input_url"));
        Assert.Null(model.InternalIsScreenshotJob);
        Assert.True(model.RawData.ContainsKey("internal_is_screenshot_job"));
        Assert.Null(model.InvalidateCache);
        Assert.True(model.RawData.ContainsKey("invalidate_cache"));
        Assert.Null(model.IsFormattingInstruction);
        Assert.True(model.RawData.ContainsKey("is_formatting_instruction"));
        Assert.Null(model.JobTimeoutExtraTimePerPageInSeconds);
        Assert.True(model.RawData.ContainsKey("job_timeout_extra_time_per_page_in_seconds"));
        Assert.Null(model.JobTimeoutInSeconds);
        Assert.True(model.RawData.ContainsKey("job_timeout_in_seconds"));
        Assert.Null(model.KeepPageSeparatorWhenMergingTables);
        Assert.True(model.RawData.ContainsKey("keep_page_separator_when_merging_tables"));
        Assert.Null(model.LayoutAware);
        Assert.True(model.RawData.ContainsKey("layout_aware"));
        Assert.Null(model.LineLevelBoundingBox);
        Assert.True(model.RawData.ContainsKey("line_level_bounding_box"));
        Assert.Null(model.MarkdownTableMultilineHeaderSeparator);
        Assert.True(model.RawData.ContainsKey("markdown_table_multiline_header_separator"));
        Assert.Null(model.MaxPages);
        Assert.True(model.RawData.ContainsKey("max_pages"));
        Assert.Null(model.MaxPagesEnforced);
        Assert.True(model.RawData.ContainsKey("max_pages_enforced"));
        Assert.Null(model.MergeTablesAcrossPagesInMarkdown);
        Assert.True(model.RawData.ContainsKey("merge_tables_across_pages_in_markdown"));
        Assert.Null(model.Model);
        Assert.True(model.RawData.ContainsKey("model"));
        Assert.Null(model.OutlinedTableExtraction);
        Assert.True(model.RawData.ContainsKey("outlined_table_extraction"));
        Assert.Null(model.OutputPdfOfDocument);
        Assert.True(model.RawData.ContainsKey("output_pdf_of_document"));
        Assert.Null(model.OutputS3PathPrefix);
        Assert.True(model.RawData.ContainsKey("output_s3_path_prefix"));
        Assert.Null(model.OutputS3Region);
        Assert.True(model.RawData.ContainsKey("output_s3_region"));
        Assert.Null(model.OutputTablesAsHtml);
        Assert.True(model.RawData.ContainsKey("output_tables_as_HTML"));
        Assert.Null(model.PageErrorTolerance);
        Assert.True(model.RawData.ContainsKey("page_error_tolerance"));
        Assert.Null(model.PageFooterPrefix);
        Assert.True(model.RawData.ContainsKey("page_footer_prefix"));
        Assert.Null(model.PageFooterSuffix);
        Assert.True(model.RawData.ContainsKey("page_footer_suffix"));
        Assert.Null(model.PageHeaderPrefix);
        Assert.True(model.RawData.ContainsKey("page_header_prefix"));
        Assert.Null(model.PageHeaderSuffix);
        Assert.True(model.RawData.ContainsKey("page_header_suffix"));
        Assert.Null(model.PagePrefix);
        Assert.True(model.RawData.ContainsKey("page_prefix"));
        Assert.Null(model.PageSeparator);
        Assert.True(model.RawData.ContainsKey("page_separator"));
        Assert.Null(model.PageSuffix);
        Assert.True(model.RawData.ContainsKey("page_suffix"));
        Assert.Null(model.ParseMode);
        Assert.True(model.RawData.ContainsKey("parse_mode"));
        Assert.Null(model.ParsingInstruction);
        Assert.True(model.RawData.ContainsKey("parsing_instruction"));
        Assert.Null(model.PreciseBoundingBox);
        Assert.True(model.RawData.ContainsKey("precise_bounding_box"));
        Assert.Null(model.PremiumMode);
        Assert.True(model.RawData.ContainsKey("premium_mode"));
        Assert.Null(model.PresentationOutOfBoundsContent);
        Assert.True(model.RawData.ContainsKey("presentation_out_of_bounds_content"));
        Assert.Null(model.PresentationSkipEmbeddedData);
        Assert.True(model.RawData.ContainsKey("presentation_skip_embedded_data"));
        Assert.Null(model.PreserveLayoutAlignmentAcrossPages);
        Assert.True(model.RawData.ContainsKey("preserve_layout_alignment_across_pages"));
        Assert.Null(model.PreserveVerySmallText);
        Assert.True(model.RawData.ContainsKey("preserve_very_small_text"));
        Assert.Null(model.Preset);
        Assert.True(model.RawData.ContainsKey("preset"));
        Assert.Null(model.Priority);
        Assert.True(model.RawData.ContainsKey("priority"));
        Assert.Null(model.ProjectID);
        Assert.True(model.RawData.ContainsKey("project_id"));
        Assert.Null(model.RemoveHiddenText);
        Assert.True(model.RawData.ContainsKey("remove_hidden_text"));
        Assert.Null(model.ReplaceFailedPageMode);
        Assert.True(model.RawData.ContainsKey("replace_failed_page_mode"));
        Assert.Null(model.ReplaceFailedPageWithErrorMessagePrefix);
        Assert.True(model.RawData.ContainsKey("replace_failed_page_with_error_message_prefix"));
        Assert.Null(model.ReplaceFailedPageWithErrorMessageSuffix);
        Assert.True(model.RawData.ContainsKey("replace_failed_page_with_error_message_suffix"));
        Assert.Null(model.SaveImages);
        Assert.True(model.RawData.ContainsKey("save_images"));
        Assert.Null(model.SkipDiagonalText);
        Assert.True(model.RawData.ContainsKey("skip_diagonal_text"));
        Assert.Null(model.SpecializedChartParsingAgentic);
        Assert.True(model.RawData.ContainsKey("specialized_chart_parsing_agentic"));
        Assert.Null(model.SpecializedChartParsingEfficient);
        Assert.True(model.RawData.ContainsKey("specialized_chart_parsing_efficient"));
        Assert.Null(model.SpecializedChartParsingPlus);
        Assert.True(model.RawData.ContainsKey("specialized_chart_parsing_plus"));
        Assert.Null(model.SpecializedImageParsing);
        Assert.True(model.RawData.ContainsKey("specialized_image_parsing"));
        Assert.Null(model.SpreadsheetExtractSubTables);
        Assert.True(model.RawData.ContainsKey("spreadsheet_extract_sub_tables"));
        Assert.Null(model.SpreadsheetForceFormulaComputation);
        Assert.True(model.RawData.ContainsKey("spreadsheet_force_formula_computation"));
        Assert.Null(model.SpreadsheetIncludeHiddenSheets);
        Assert.True(model.RawData.ContainsKey("spreadsheet_include_hidden_sheets"));
        Assert.Null(model.StrictModeBuggyFont);
        Assert.True(model.RawData.ContainsKey("strict_mode_buggy_font"));
        Assert.Null(model.StrictModeImageExtraction);
        Assert.True(model.RawData.ContainsKey("strict_mode_image_extraction"));
        Assert.Null(model.StrictModeImageOcr);
        Assert.True(model.RawData.ContainsKey("strict_mode_image_ocr"));
        Assert.Null(model.StrictModeReconstruction);
        Assert.True(model.RawData.ContainsKey("strict_mode_reconstruction"));
        Assert.Null(model.StructuredOutput);
        Assert.True(model.RawData.ContainsKey("structured_output"));
        Assert.Null(model.StructuredOutputJsonSchema);
        Assert.True(model.RawData.ContainsKey("structured_output_json_schema"));
        Assert.Null(model.StructuredOutputJsonSchemaName);
        Assert.True(model.RawData.ContainsKey("structured_output_json_schema_name"));
        Assert.Null(model.SystemPrompt);
        Assert.True(model.RawData.ContainsKey("system_prompt"));
        Assert.Null(model.SystemPromptAppend);
        Assert.True(model.RawData.ContainsKey("system_prompt_append"));
        Assert.Null(model.TakeScreenshot);
        Assert.True(model.RawData.ContainsKey("take_screenshot"));
        Assert.Null(model.TargetPages);
        Assert.True(model.RawData.ContainsKey("target_pages"));
        Assert.Null(model.Tier);
        Assert.True(model.RawData.ContainsKey("tier"));
        Assert.Null(model.UseVendorMultimodalModel);
        Assert.True(model.RawData.ContainsKey("use_vendor_multimodal_model"));
        Assert.Null(model.UserPrompt);
        Assert.True(model.RawData.ContainsKey("user_prompt"));
        Assert.Null(model.VendorMultimodalApiKey);
        Assert.True(model.RawData.ContainsKey("vendor_multimodal_api_key"));
        Assert.Null(model.VendorMultimodalModelName);
        Assert.True(model.RawData.ContainsKey("vendor_multimodal_model_name"));
        Assert.Null(model.Version);
        Assert.True(model.RawData.ContainsKey("version"));
        Assert.Null(model.WebhookConfigurations);
        Assert.True(model.RawData.ContainsKey("webhook_configurations"));
        Assert.Null(model.WebhookUrl);
        Assert.True(model.RawData.ContainsKey("webhook_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LlamaParseParameters
        {
            Languages = [Parsing::ParsingLanguages.Abq],

            AdaptiveLongTable = null,
            AggressiveTableExtraction = null,
            AnnotateLineNumbers = null,
            AnnotateLinks = null,
            AnnotateRevisions = null,
            AutoMode = null,
            AutoModeConfigurationJson = null,
            AutoModeTriggerOnImageInPage = null,
            AutoModeTriggerOnRegexpInPage = null,
            AutoModeTriggerOnTableInPage = null,
            AutoModeTriggerOnTextInPage = null,
            AzureOpenAIApiVersion = null,
            AzureOpenAIDeploymentName = null,
            AzureOpenAIEndpoint = null,
            AzureOpenAIKey = null,
            BboxBottom = null,
            BboxLeft = null,
            BboxRight = null,
            BboxTop = null,
            BoundingBox = null,
            CompactMarkdownTable = null,
            ComplementalFormattingInstruction = null,
            ConfidenceScoreEffort = null,
            ContentGuidelineInstruction = null,
            ContinuousMode = null,
            DisableImageExtraction = null,
            DisableOcr = null,
            DisableReconstruction = null,
            DoNotCache = null,
            DoNotUnrollColumns = null,
            EnableCostOptimizer = null,
            ExtractCharts = null,
            ExtractLayout = null,
            ExtractPrintedPageNumber = null,
            FastMode = null,
            FormattingInstruction = null,
            Gpt4oApiKey = null,
            Gpt4oMode = null,
            GuessXlsxSheetName = null,
            HideFooters = null,
            HideHeaders = null,
            HighResOcr = null,
            HtmlMakeAllElementsVisible = null,
            HtmlRemoveFixedElements = null,
            HtmlRemoveNavigationElements = null,
            HttpProxy = null,
            IgnoreDocumentElementsForLayoutDetection = null,
            ImagesToSave = null,
            InlineImagesInMarkdown = null,
            InputS3Path = null,
            InputS3Region = null,
            InputUrl = null,
            InternalIsScreenshotJob = null,
            InvalidateCache = null,
            IsFormattingInstruction = null,
            JobTimeoutExtraTimePerPageInSeconds = null,
            JobTimeoutInSeconds = null,
            KeepPageSeparatorWhenMergingTables = null,
            LayoutAware = null,
            LineLevelBoundingBox = null,
            MarkdownTableMultilineHeaderSeparator = null,
            MaxPages = null,
            MaxPagesEnforced = null,
            MergeTablesAcrossPagesInMarkdown = null,
            Model = null,
            OutlinedTableExtraction = null,
            OutputPdfOfDocument = null,
            OutputS3PathPrefix = null,
            OutputS3Region = null,
            OutputTablesAsHtml = null,
            PageErrorTolerance = null,
            PageFooterPrefix = null,
            PageFooterSuffix = null,
            PageHeaderPrefix = null,
            PageHeaderSuffix = null,
            PagePrefix = null,
            PageSeparator = null,
            PageSuffix = null,
            ParseMode = null,
            ParsingInstruction = null,
            PreciseBoundingBox = null,
            PremiumMode = null,
            PresentationOutOfBoundsContent = null,
            PresentationSkipEmbeddedData = null,
            PreserveLayoutAlignmentAcrossPages = null,
            PreserveVerySmallText = null,
            Preset = null,
            Priority = null,
            ProjectID = null,
            RemoveHiddenText = null,
            ReplaceFailedPageMode = null,
            ReplaceFailedPageWithErrorMessagePrefix = null,
            ReplaceFailedPageWithErrorMessageSuffix = null,
            SaveImages = null,
            SkipDiagonalText = null,
            SpecializedChartParsingAgentic = null,
            SpecializedChartParsingEfficient = null,
            SpecializedChartParsingPlus = null,
            SpecializedImageParsing = null,
            SpreadsheetExtractSubTables = null,
            SpreadsheetForceFormulaComputation = null,
            SpreadsheetIncludeHiddenSheets = null,
            StrictModeBuggyFont = null,
            StrictModeImageExtraction = null,
            StrictModeImageOcr = null,
            StrictModeReconstruction = null,
            StructuredOutput = null,
            StructuredOutputJsonSchema = null,
            StructuredOutputJsonSchemaName = null,
            SystemPrompt = null,
            SystemPromptAppend = null,
            TakeScreenshot = null,
            TargetPages = null,
            Tier = null,
            UseVendorMultimodalModel = null,
            UserPrompt = null,
            VendorMultimodalApiKey = null,
            VendorMultimodalModelName = null,
            Version = null,
            WebhookConfigurations = null,
            WebhookUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LlamaParseParameters
        {
            AdaptiveLongTable = true,
            AggressiveTableExtraction = true,
            AnnotateLineNumbers = true,
            AnnotateLinks = true,
            AnnotateRevisions = true,
            AutoMode = true,
            AutoModeConfigurationJson = "auto_mode_configuration_json",
            AutoModeTriggerOnImageInPage = true,
            AutoModeTriggerOnRegexpInPage = "auto_mode_trigger_on_regexp_in_page",
            AutoModeTriggerOnTableInPage = true,
            AutoModeTriggerOnTextInPage = "auto_mode_trigger_on_text_in_page",
            AzureOpenAIApiVersion = "azure_openai_api_version",
            AzureOpenAIDeploymentName = "azure_openai_deployment_name",
            AzureOpenAIEndpoint = "azure_openai_endpoint",
            AzureOpenAIKey = "azure_openai_key",
            BboxBottom = 0,
            BboxLeft = 0,
            BboxRight = 0,
            BboxTop = 0,
            BoundingBox = "bounding_box",
            CompactMarkdownTable = true,
            ComplementalFormattingInstruction = "complemental_formatting_instruction",
            ConfidenceScoreEffort = "confidence_score_effort",
            ContentGuidelineInstruction = "content_guideline_instruction",
            ContinuousMode = true,
            DisableImageExtraction = true,
            DisableOcr = true,
            DisableReconstruction = true,
            DoNotCache = true,
            DoNotUnrollColumns = true,
            EnableCostOptimizer = true,
            ExtractCharts = true,
            ExtractLayout = true,
            ExtractPrintedPageNumber = true,
            FastMode = true,
            FormattingInstruction = "formatting_instruction",
            Gpt4oApiKey = "gpt4o_api_key",
            Gpt4oMode = true,
            GuessXlsxSheetName = true,
            HideFooters = true,
            HideHeaders = true,
            HighResOcr = true,
            HtmlMakeAllElementsVisible = true,
            HtmlRemoveFixedElements = true,
            HtmlRemoveNavigationElements = true,
            HttpProxy = "http_proxy",
            IgnoreDocumentElementsForLayoutDetection = true,
            ImagesToSave = [ImagesToSave.Embedded],
            InlineImagesInMarkdown = true,
            InputS3Path = "input_s3_path",
            InputS3Region = "input_s3_region",
            InputUrl = "input_url",
            InternalIsScreenshotJob = true,
            InvalidateCache = true,
            IsFormattingInstruction = true,
            JobTimeoutExtraTimePerPageInSeconds = 0,
            JobTimeoutInSeconds = 0,
            KeepPageSeparatorWhenMergingTables = true,
            Languages = [Parsing::ParsingLanguages.Abq],
            LayoutAware = true,
            LineLevelBoundingBox = true,
            MarkdownTableMultilineHeaderSeparator = "markdown_table_multiline_header_separator",
            MaxPages = 0,
            MaxPagesEnforced = 0,
            MergeTablesAcrossPagesInMarkdown = true,
            Model = "model",
            OutlinedTableExtraction = true,
            OutputPdfOfDocument = true,
            OutputS3PathPrefix = "output_s3_path_prefix",
            OutputS3Region = "output_s3_region",
            OutputTablesAsHtml = true,
            PageErrorTolerance = 0,
            PageFooterPrefix = "page_footer_prefix",
            PageFooterSuffix = "page_footer_suffix",
            PageHeaderPrefix = "page_header_prefix",
            PageHeaderSuffix = "page_header_suffix",
            PagePrefix = "page_prefix",
            PageSeparator = "page_separator",
            PageSuffix = "page_suffix",
            ParseMode = Parsing::ParsingMode.ParseDocumentWithAgent,
            ParsingInstruction = "parsing_instruction",
            PreciseBoundingBox = true,
            PremiumMode = true,
            PresentationOutOfBoundsContent = true,
            PresentationSkipEmbeddedData = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
            Preset = "preset",
            Priority = Priority.Critical,
            ProjectID = "project_id",
            RemoveHiddenText = true,
            ReplaceFailedPageMode = Parsing::FailPageMode.BlankPage,
            ReplaceFailedPageWithErrorMessagePrefix =
                "replace_failed_page_with_error_message_prefix",
            ReplaceFailedPageWithErrorMessageSuffix =
                "replace_failed_page_with_error_message_suffix",
            SaveImages = true,
            SkipDiagonalText = true,
            SpecializedChartParsingAgentic = true,
            SpecializedChartParsingEfficient = true,
            SpecializedChartParsingPlus = true,
            SpecializedImageParsing = true,
            SpreadsheetExtractSubTables = true,
            SpreadsheetForceFormulaComputation = true,
            SpreadsheetIncludeHiddenSheets = true,
            StrictModeBuggyFont = true,
            StrictModeImageExtraction = true,
            StrictModeImageOcr = true,
            StrictModeReconstruction = true,
            StructuredOutput = true,
            StructuredOutputJsonSchema = "structured_output_json_schema",
            StructuredOutputJsonSchemaName = "structured_output_json_schema_name",
            SystemPrompt = "system_prompt",
            SystemPromptAppend = "system_prompt_append",
            TakeScreenshot = true,
            TargetPages = "target_pages",
            Tier = "tier",
            UseVendorMultimodalModel = true,
            UserPrompt = "user_prompt",
            VendorMultimodalApiKey = "vendor_multimodal_api_key",
            VendorMultimodalModelName = "vendor_multimodal_model_name",
            Version = "version",
            WebhookConfigurations =
            [
                new()
                {
                    WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
                    WebhookHeaders = new Dictionary<string, string>()
                    {
                        { "Authorization", "Bearer sk-..." },
                    },
                    WebhookOutputFormat = "json",
                    WebhookSigningSecret = "whsec_...",
                    WebhookUrl = "https://example.com/webhooks/llamacloud",
                },
            ],
            WebhookUrl = "webhook_url",
        };

        LlamaParseParameters copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImagesToSaveTest : TestBase
{
    [Theory]
    [InlineData(ImagesToSave.Embedded)]
    [InlineData(ImagesToSave.Layout)]
    [InlineData(ImagesToSave.Screenshot)]
    public void Validation_Works(ImagesToSave rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ImagesToSave> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ImagesToSave>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ImagesToSave.Embedded)]
    [InlineData(ImagesToSave.Layout)]
    [InlineData(ImagesToSave.Screenshot)]
    public void SerializationRoundtrip_Works(ImagesToSave rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ImagesToSave> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ImagesToSave>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ImagesToSave>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ImagesToSave>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PriorityTest : TestBase
{
    [Theory]
    [InlineData(Priority.Critical)]
    [InlineData(Priority.High)]
    [InlineData(Priority.Low)]
    [InlineData(Priority.Medium)]
    public void Validation_Works(Priority rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Priority> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Priority>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Priority.Critical)]
    [InlineData(Priority.High)]
    [InlineData(Priority.Low)]
    [InlineData(Priority.Medium)]
    public void SerializationRoundtrip_Works(Priority rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Priority> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Priority>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Priority>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Priority>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class WebhookConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookConfiguration
        {
            WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        List<ApiEnum<string, WebhookEvent>> expectedWebhookEvents =
        [
            WebhookEvent.ParseSuccess,
            WebhookEvent.ParseError,
        ];
        Dictionary<string, string> expectedWebhookHeaders = new()
        {
            { "Authorization", "Bearer sk-..." },
        };
        string expectedWebhookOutputFormat = "json";
        string expectedWebhookSigningSecret = "whsec_...";
        string expectedWebhookUrl = "https://example.com/webhooks/llamacloud";

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

            Assert.Equal(value, model.WebhookHeaders[item.Key]);
        }
        Assert.Equal(expectedWebhookOutputFormat, model.WebhookOutputFormat);
        Assert.Equal(expectedWebhookSigningSecret, model.WebhookSigningSecret);
        Assert.Equal(expectedWebhookUrl, model.WebhookUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookConfiguration
        {
            WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookConfiguration
        {
            WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ApiEnum<string, WebhookEvent>> expectedWebhookEvents =
        [
            WebhookEvent.ParseSuccess,
            WebhookEvent.ParseError,
        ];
        Dictionary<string, string> expectedWebhookHeaders = new()
        {
            { "Authorization", "Bearer sk-..." },
        };
        string expectedWebhookOutputFormat = "json";
        string expectedWebhookSigningSecret = "whsec_...";
        string expectedWebhookUrl = "https://example.com/webhooks/llamacloud";

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

            Assert.Equal(value, deserialized.WebhookHeaders[item.Key]);
        }
        Assert.Equal(expectedWebhookOutputFormat, deserialized.WebhookOutputFormat);
        Assert.Equal(expectedWebhookSigningSecret, deserialized.WebhookSigningSecret);
        Assert.Equal(expectedWebhookUrl, deserialized.WebhookUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookConfiguration
        {
            WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebhookConfiguration { };

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
        var model = new WebhookConfiguration { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebhookConfiguration
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
        var model = new WebhookConfiguration
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
        var model = new WebhookConfiguration
        {
            WebhookEvents = [WebhookEvent.ParseSuccess, WebhookEvent.ParseError],
            WebhookHeaders = new Dictionary<string, string>()
            {
                { "Authorization", "Bearer sk-..." },
            },
            WebhookOutputFormat = "json",
            WebhookSigningSecret = "whsec_...",
            WebhookUrl = "https://example.com/webhooks/llamacloud",
        };

        WebhookConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebhookEventTest : TestBase
{
    [Theory]
    [InlineData(WebhookEvent.BatchCancelled)]
    [InlineData(WebhookEvent.BatchError)]
    [InlineData(WebhookEvent.BatchPending)]
    [InlineData(WebhookEvent.BatchRunning)]
    [InlineData(WebhookEvent.BatchSuccess)]
    [InlineData(WebhookEvent.ClassifyCancelled)]
    [InlineData(WebhookEvent.ClassifyError)]
    [InlineData(WebhookEvent.ClassifyPartialSuccess)]
    [InlineData(WebhookEvent.ClassifyPending)]
    [InlineData(WebhookEvent.ClassifyRunning)]
    [InlineData(WebhookEvent.ClassifySuccess)]
    [InlineData(WebhookEvent.ExtractCancelled)]
    [InlineData(WebhookEvent.ExtractError)]
    [InlineData(WebhookEvent.ExtractPartialSuccess)]
    [InlineData(WebhookEvent.ExtractPending)]
    [InlineData(WebhookEvent.ExtractSuccess)]
    [InlineData(WebhookEvent.ParseCancelled)]
    [InlineData(WebhookEvent.ParseError)]
    [InlineData(WebhookEvent.ParsePartialSuccess)]
    [InlineData(WebhookEvent.ParsePending)]
    [InlineData(WebhookEvent.ParseRunning)]
    [InlineData(WebhookEvent.ParseSuccess)]
    [InlineData(WebhookEvent.SheetsCancelled)]
    [InlineData(WebhookEvent.SheetsError)]
    [InlineData(WebhookEvent.SheetsPartialSuccess)]
    [InlineData(WebhookEvent.SheetsPending)]
    [InlineData(WebhookEvent.SheetsSuccess)]
    [InlineData(WebhookEvent.SplitCancelled)]
    [InlineData(WebhookEvent.SplitError)]
    [InlineData(WebhookEvent.SplitPending)]
    [InlineData(WebhookEvent.SplitProcessing)]
    [InlineData(WebhookEvent.SplitSuccess)]
    [InlineData(WebhookEvent.UnmappedEvent)]
    public void Validation_Works(WebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookEvent> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookEvent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookEvent.BatchCancelled)]
    [InlineData(WebhookEvent.BatchError)]
    [InlineData(WebhookEvent.BatchPending)]
    [InlineData(WebhookEvent.BatchRunning)]
    [InlineData(WebhookEvent.BatchSuccess)]
    [InlineData(WebhookEvent.ClassifyCancelled)]
    [InlineData(WebhookEvent.ClassifyError)]
    [InlineData(WebhookEvent.ClassifyPartialSuccess)]
    [InlineData(WebhookEvent.ClassifyPending)]
    [InlineData(WebhookEvent.ClassifyRunning)]
    [InlineData(WebhookEvent.ClassifySuccess)]
    [InlineData(WebhookEvent.ExtractCancelled)]
    [InlineData(WebhookEvent.ExtractError)]
    [InlineData(WebhookEvent.ExtractPartialSuccess)]
    [InlineData(WebhookEvent.ExtractPending)]
    [InlineData(WebhookEvent.ExtractSuccess)]
    [InlineData(WebhookEvent.ParseCancelled)]
    [InlineData(WebhookEvent.ParseError)]
    [InlineData(WebhookEvent.ParsePartialSuccess)]
    [InlineData(WebhookEvent.ParsePending)]
    [InlineData(WebhookEvent.ParseRunning)]
    [InlineData(WebhookEvent.ParseSuccess)]
    [InlineData(WebhookEvent.SheetsCancelled)]
    [InlineData(WebhookEvent.SheetsError)]
    [InlineData(WebhookEvent.SheetsPartialSuccess)]
    [InlineData(WebhookEvent.SheetsPending)]
    [InlineData(WebhookEvent.SheetsSuccess)]
    [InlineData(WebhookEvent.SplitCancelled)]
    [InlineData(WebhookEvent.SplitError)]
    [InlineData(WebhookEvent.SplitPending)]
    [InlineData(WebhookEvent.SplitProcessing)]
    [InlineData(WebhookEvent.SplitSuccess)]
    [InlineData(WebhookEvent.UnmappedEvent)]
    public void SerializationRoundtrip_Works(WebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookEvent> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookEvent>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookEvent>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookEvent>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
