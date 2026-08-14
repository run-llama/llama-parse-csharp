using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Models.Pipelines;
using Parsing = LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Pipelines;

public class PipelineCreateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PipelineCreate
        {
            Name = "x",
            DataSink = new()
            {
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                SinkType = SinkType.AstraDB,
            },
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EmbeddingConfig = new AzureOpenAIEmbeddingConfig()
            {
                Component = new()
                {
                    AdditionalKwargs = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    ApiBase = "api_base",
                    ApiKey = "api_key",
                    ApiVersion = "api_version",
                    AzureDeployment = "azure_deployment",
                    AzureEndpoint = "azure_endpoint",
                    ClassName = "class_name",
                    DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
                    Dimensions = 0,
                    EmbedBatchSize = 1,
                    MaxRetries = 0,
                    ModelName = "model_name",
                    NumWorkers = 0,
                    ReuseClient = true,
                    Timeout = 0,
                },
                Type = Type.AzureEmbedding,
            },
            EmbeddingModelConfigID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LlamaParseParameters = new()
            {
                AdaptiveLongTable = true,
                AggressiveTableExtraction = true,
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
            },
            ManagedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MetadataConfig = new()
            {
                ExcludedEmbedMetadataKeys = ["string"],
                ExcludedLlmMetadataKeys = ["string"],
            },
            PipelineType = PipelineType.Managed,
            PresetRetrievalParameters = new()
            {
                Alpha = 0,
                ClassName = "class_name",
                DenseSimilarityCutoff = 0,
                DenseSimilarityTopK = 1,
                EnableReranking = true,
                FilesTopK = 1,
                RerankTopN = 1,
                RetrievalMode = RetrievalMode.AutoRouted,
                RetrieveImageNodes = true,
                RetrievePageFigureNodes = true,
                RetrievePageScreenshotNodes = true,
                SearchFilters = new()
                {
                    Filters =
                    [
                        new MetadataFilter()
                        {
                            Key = "key",
                            Value = 0,
                            Operator = Operator.Undefined,
                        },
                    ],
                    Condition = Condition.And,
                },
                SearchFiltersInferenceSchema = new Dictionary<
                    string,
                    PresetRetrievalParamsSearchFiltersInferenceSchema?
                >()
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
                SparseSimilarityTopK = 1,
            },
            SparseModelConfig = new() { ClassName = "class_name", ModelType = ModelType.Auto },
            Status = "status",
            TransformConfig = new AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = AutoTransformConfigMode.Auto,
            },
        };

        string expectedName = "x";
        DataSinkCreate expectedDataSink = new()
        {
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            SinkType = SinkType.AstraDB,
        };
        string expectedDataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        PipelineCreateEmbeddingConfig expectedEmbeddingConfig = new AzureOpenAIEmbeddingConfig()
        {
            Component = new()
            {
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ApiBase = "api_base",
                ApiKey = "api_key",
                ApiVersion = "api_version",
                AzureDeployment = "azure_deployment",
                AzureEndpoint = "azure_endpoint",
                ClassName = "class_name",
                DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
                Dimensions = 0,
                EmbedBatchSize = 1,
                MaxRetries = 0,
                ModelName = "model_name",
                NumWorkers = 0,
                ReuseClient = true,
                Timeout = 0,
            },
            Type = Type.AzureEmbedding,
        };
        string expectedEmbeddingModelConfigID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        LlamaParseParameters expectedLlamaParseParameters = new()
        {
            AdaptiveLongTable = true,
            AggressiveTableExtraction = true,
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
        string expectedManagedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        PipelineMetadataConfig expectedMetadataConfig = new()
        {
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
        };
        ApiEnum<string, PipelineType> expectedPipelineType = PipelineType.Managed;
        PresetRetrievalParams expectedPresetRetrievalParameters = new()
        {
            Alpha = 0,
            ClassName = "class_name",
            DenseSimilarityCutoff = 0,
            DenseSimilarityTopK = 1,
            EnableReranking = true,
            FilesTopK = 1,
            RerankTopN = 1,
            RetrievalMode = RetrievalMode.AutoRouted,
            RetrieveImageNodes = true,
            RetrievePageFigureNodes = true,
            RetrievePageScreenshotNodes = true,
            SearchFilters = new()
            {
                Filters =
                [
                    new MetadataFilter()
                    {
                        Key = "key",
                        Value = 0,
                        Operator = Operator.Undefined,
                    },
                ],
                Condition = Condition.And,
            },
            SearchFiltersInferenceSchema = new Dictionary<
                string,
                PresetRetrievalParamsSearchFiltersInferenceSchema?
            >()
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
            SparseSimilarityTopK = 1,
        };
        SparseModelConfig expectedSparseModelConfig = new()
        {
            ClassName = "class_name",
            ModelType = ModelType.Auto,
        };
        string expectedStatus = "status";
        PipelineCreateTransformConfig expectedTransformConfig = new AutoTransformConfig()
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = AutoTransformConfigMode.Auto,
        };

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedDataSink, model.DataSink);
        Assert.Equal(expectedDataSinkID, model.DataSinkID);
        Assert.Equal(expectedEmbeddingConfig, model.EmbeddingConfig);
        Assert.Equal(expectedEmbeddingModelConfigID, model.EmbeddingModelConfigID);
        Assert.Equal(expectedLlamaParseParameters, model.LlamaParseParameters);
        Assert.Equal(expectedManagedPipelineID, model.ManagedPipelineID);
        Assert.Equal(expectedMetadataConfig, model.MetadataConfig);
        Assert.Equal(expectedPipelineType, model.PipelineType);
        Assert.Equal(expectedPresetRetrievalParameters, model.PresetRetrievalParameters);
        Assert.Equal(expectedSparseModelConfig, model.SparseModelConfig);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTransformConfig, model.TransformConfig);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PipelineCreate
        {
            Name = "x",
            DataSink = new()
            {
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                SinkType = SinkType.AstraDB,
            },
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EmbeddingConfig = new AzureOpenAIEmbeddingConfig()
            {
                Component = new()
                {
                    AdditionalKwargs = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    ApiBase = "api_base",
                    ApiKey = "api_key",
                    ApiVersion = "api_version",
                    AzureDeployment = "azure_deployment",
                    AzureEndpoint = "azure_endpoint",
                    ClassName = "class_name",
                    DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
                    Dimensions = 0,
                    EmbedBatchSize = 1,
                    MaxRetries = 0,
                    ModelName = "model_name",
                    NumWorkers = 0,
                    ReuseClient = true,
                    Timeout = 0,
                },
                Type = Type.AzureEmbedding,
            },
            EmbeddingModelConfigID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LlamaParseParameters = new()
            {
                AdaptiveLongTable = true,
                AggressiveTableExtraction = true,
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
            },
            ManagedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MetadataConfig = new()
            {
                ExcludedEmbedMetadataKeys = ["string"],
                ExcludedLlmMetadataKeys = ["string"],
            },
            PipelineType = PipelineType.Managed,
            PresetRetrievalParameters = new()
            {
                Alpha = 0,
                ClassName = "class_name",
                DenseSimilarityCutoff = 0,
                DenseSimilarityTopK = 1,
                EnableReranking = true,
                FilesTopK = 1,
                RerankTopN = 1,
                RetrievalMode = RetrievalMode.AutoRouted,
                RetrieveImageNodes = true,
                RetrievePageFigureNodes = true,
                RetrievePageScreenshotNodes = true,
                SearchFilters = new()
                {
                    Filters =
                    [
                        new MetadataFilter()
                        {
                            Key = "key",
                            Value = 0,
                            Operator = Operator.Undefined,
                        },
                    ],
                    Condition = Condition.And,
                },
                SearchFiltersInferenceSchema = new Dictionary<
                    string,
                    PresetRetrievalParamsSearchFiltersInferenceSchema?
                >()
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
                SparseSimilarityTopK = 1,
            },
            SparseModelConfig = new() { ClassName = "class_name", ModelType = ModelType.Auto },
            Status = "status",
            TransformConfig = new AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = AutoTransformConfigMode.Auto,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineCreate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PipelineCreate
        {
            Name = "x",
            DataSink = new()
            {
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                SinkType = SinkType.AstraDB,
            },
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EmbeddingConfig = new AzureOpenAIEmbeddingConfig()
            {
                Component = new()
                {
                    AdditionalKwargs = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    ApiBase = "api_base",
                    ApiKey = "api_key",
                    ApiVersion = "api_version",
                    AzureDeployment = "azure_deployment",
                    AzureEndpoint = "azure_endpoint",
                    ClassName = "class_name",
                    DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
                    Dimensions = 0,
                    EmbedBatchSize = 1,
                    MaxRetries = 0,
                    ModelName = "model_name",
                    NumWorkers = 0,
                    ReuseClient = true,
                    Timeout = 0,
                },
                Type = Type.AzureEmbedding,
            },
            EmbeddingModelConfigID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LlamaParseParameters = new()
            {
                AdaptiveLongTable = true,
                AggressiveTableExtraction = true,
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
            },
            ManagedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MetadataConfig = new()
            {
                ExcludedEmbedMetadataKeys = ["string"],
                ExcludedLlmMetadataKeys = ["string"],
            },
            PipelineType = PipelineType.Managed,
            PresetRetrievalParameters = new()
            {
                Alpha = 0,
                ClassName = "class_name",
                DenseSimilarityCutoff = 0,
                DenseSimilarityTopK = 1,
                EnableReranking = true,
                FilesTopK = 1,
                RerankTopN = 1,
                RetrievalMode = RetrievalMode.AutoRouted,
                RetrieveImageNodes = true,
                RetrievePageFigureNodes = true,
                RetrievePageScreenshotNodes = true,
                SearchFilters = new()
                {
                    Filters =
                    [
                        new MetadataFilter()
                        {
                            Key = "key",
                            Value = 0,
                            Operator = Operator.Undefined,
                        },
                    ],
                    Condition = Condition.And,
                },
                SearchFiltersInferenceSchema = new Dictionary<
                    string,
                    PresetRetrievalParamsSearchFiltersInferenceSchema?
                >()
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
                SparseSimilarityTopK = 1,
            },
            SparseModelConfig = new() { ClassName = "class_name", ModelType = ModelType.Auto },
            Status = "status",
            TransformConfig = new AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = AutoTransformConfigMode.Auto,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineCreate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "x";
        DataSinkCreate expectedDataSink = new()
        {
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            SinkType = SinkType.AstraDB,
        };
        string expectedDataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        PipelineCreateEmbeddingConfig expectedEmbeddingConfig = new AzureOpenAIEmbeddingConfig()
        {
            Component = new()
            {
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ApiBase = "api_base",
                ApiKey = "api_key",
                ApiVersion = "api_version",
                AzureDeployment = "azure_deployment",
                AzureEndpoint = "azure_endpoint",
                ClassName = "class_name",
                DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
                Dimensions = 0,
                EmbedBatchSize = 1,
                MaxRetries = 0,
                ModelName = "model_name",
                NumWorkers = 0,
                ReuseClient = true,
                Timeout = 0,
            },
            Type = Type.AzureEmbedding,
        };
        string expectedEmbeddingModelConfigID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        LlamaParseParameters expectedLlamaParseParameters = new()
        {
            AdaptiveLongTable = true,
            AggressiveTableExtraction = true,
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
        string expectedManagedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        PipelineMetadataConfig expectedMetadataConfig = new()
        {
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
        };
        ApiEnum<string, PipelineType> expectedPipelineType = PipelineType.Managed;
        PresetRetrievalParams expectedPresetRetrievalParameters = new()
        {
            Alpha = 0,
            ClassName = "class_name",
            DenseSimilarityCutoff = 0,
            DenseSimilarityTopK = 1,
            EnableReranking = true,
            FilesTopK = 1,
            RerankTopN = 1,
            RetrievalMode = RetrievalMode.AutoRouted,
            RetrieveImageNodes = true,
            RetrievePageFigureNodes = true,
            RetrievePageScreenshotNodes = true,
            SearchFilters = new()
            {
                Filters =
                [
                    new MetadataFilter()
                    {
                        Key = "key",
                        Value = 0,
                        Operator = Operator.Undefined,
                    },
                ],
                Condition = Condition.And,
            },
            SearchFiltersInferenceSchema = new Dictionary<
                string,
                PresetRetrievalParamsSearchFiltersInferenceSchema?
            >()
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
            SparseSimilarityTopK = 1,
        };
        SparseModelConfig expectedSparseModelConfig = new()
        {
            ClassName = "class_name",
            ModelType = ModelType.Auto,
        };
        string expectedStatus = "status";
        PipelineCreateTransformConfig expectedTransformConfig = new AutoTransformConfig()
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = AutoTransformConfigMode.Auto,
        };

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedDataSink, deserialized.DataSink);
        Assert.Equal(expectedDataSinkID, deserialized.DataSinkID);
        Assert.Equal(expectedEmbeddingConfig, deserialized.EmbeddingConfig);
        Assert.Equal(expectedEmbeddingModelConfigID, deserialized.EmbeddingModelConfigID);
        Assert.Equal(expectedLlamaParseParameters, deserialized.LlamaParseParameters);
        Assert.Equal(expectedManagedPipelineID, deserialized.ManagedPipelineID);
        Assert.Equal(expectedMetadataConfig, deserialized.MetadataConfig);
        Assert.Equal(expectedPipelineType, deserialized.PipelineType);
        Assert.Equal(expectedPresetRetrievalParameters, deserialized.PresetRetrievalParameters);
        Assert.Equal(expectedSparseModelConfig, deserialized.SparseModelConfig);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTransformConfig, deserialized.TransformConfig);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PipelineCreate
        {
            Name = "x",
            DataSink = new()
            {
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                SinkType = SinkType.AstraDB,
            },
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EmbeddingConfig = new AzureOpenAIEmbeddingConfig()
            {
                Component = new()
                {
                    AdditionalKwargs = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    ApiBase = "api_base",
                    ApiKey = "api_key",
                    ApiVersion = "api_version",
                    AzureDeployment = "azure_deployment",
                    AzureEndpoint = "azure_endpoint",
                    ClassName = "class_name",
                    DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
                    Dimensions = 0,
                    EmbedBatchSize = 1,
                    MaxRetries = 0,
                    ModelName = "model_name",
                    NumWorkers = 0,
                    ReuseClient = true,
                    Timeout = 0,
                },
                Type = Type.AzureEmbedding,
            },
            EmbeddingModelConfigID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LlamaParseParameters = new()
            {
                AdaptiveLongTable = true,
                AggressiveTableExtraction = true,
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
            },
            ManagedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MetadataConfig = new()
            {
                ExcludedEmbedMetadataKeys = ["string"],
                ExcludedLlmMetadataKeys = ["string"],
            },
            PipelineType = PipelineType.Managed,
            PresetRetrievalParameters = new()
            {
                Alpha = 0,
                ClassName = "class_name",
                DenseSimilarityCutoff = 0,
                DenseSimilarityTopK = 1,
                EnableReranking = true,
                FilesTopK = 1,
                RerankTopN = 1,
                RetrievalMode = RetrievalMode.AutoRouted,
                RetrieveImageNodes = true,
                RetrievePageFigureNodes = true,
                RetrievePageScreenshotNodes = true,
                SearchFilters = new()
                {
                    Filters =
                    [
                        new MetadataFilter()
                        {
                            Key = "key",
                            Value = 0,
                            Operator = Operator.Undefined,
                        },
                    ],
                    Condition = Condition.And,
                },
                SearchFiltersInferenceSchema = new Dictionary<
                    string,
                    PresetRetrievalParamsSearchFiltersInferenceSchema?
                >()
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
                SparseSimilarityTopK = 1,
            },
            SparseModelConfig = new() { ClassName = "class_name", ModelType = ModelType.Auto },
            Status = "status",
            TransformConfig = new AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = AutoTransformConfigMode.Auto,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PipelineCreate
        {
            Name = "x",
            DataSink = new()
            {
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                SinkType = SinkType.AstraDB,
            },
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EmbeddingConfig = new AzureOpenAIEmbeddingConfig()
            {
                Component = new()
                {
                    AdditionalKwargs = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    ApiBase = "api_base",
                    ApiKey = "api_key",
                    ApiVersion = "api_version",
                    AzureDeployment = "azure_deployment",
                    AzureEndpoint = "azure_endpoint",
                    ClassName = "class_name",
                    DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
                    Dimensions = 0,
                    EmbedBatchSize = 1,
                    MaxRetries = 0,
                    ModelName = "model_name",
                    NumWorkers = 0,
                    ReuseClient = true,
                    Timeout = 0,
                },
                Type = Type.AzureEmbedding,
            },
            EmbeddingModelConfigID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ManagedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MetadataConfig = new()
            {
                ExcludedEmbedMetadataKeys = ["string"],
                ExcludedLlmMetadataKeys = ["string"],
            },
            SparseModelConfig = new() { ClassName = "class_name", ModelType = ModelType.Auto },
            Status = "status",
            TransformConfig = new AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = AutoTransformConfigMode.Auto,
            },
        };

        Assert.Null(model.LlamaParseParameters);
        Assert.False(model.RawData.ContainsKey("llama_parse_parameters"));
        Assert.Null(model.PipelineType);
        Assert.False(model.RawData.ContainsKey("pipeline_type"));
        Assert.Null(model.PresetRetrievalParameters);
        Assert.False(model.RawData.ContainsKey("preset_retrieval_parameters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PipelineCreate
        {
            Name = "x",
            DataSink = new()
            {
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                SinkType = SinkType.AstraDB,
            },
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EmbeddingConfig = new AzureOpenAIEmbeddingConfig()
            {
                Component = new()
                {
                    AdditionalKwargs = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    ApiBase = "api_base",
                    ApiKey = "api_key",
                    ApiVersion = "api_version",
                    AzureDeployment = "azure_deployment",
                    AzureEndpoint = "azure_endpoint",
                    ClassName = "class_name",
                    DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
                    Dimensions = 0,
                    EmbedBatchSize = 1,
                    MaxRetries = 0,
                    ModelName = "model_name",
                    NumWorkers = 0,
                    ReuseClient = true,
                    Timeout = 0,
                },
                Type = Type.AzureEmbedding,
            },
            EmbeddingModelConfigID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ManagedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MetadataConfig = new()
            {
                ExcludedEmbedMetadataKeys = ["string"],
                ExcludedLlmMetadataKeys = ["string"],
            },
            SparseModelConfig = new() { ClassName = "class_name", ModelType = ModelType.Auto },
            Status = "status",
            TransformConfig = new AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = AutoTransformConfigMode.Auto,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PipelineCreate
        {
            Name = "x",
            DataSink = new()
            {
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                SinkType = SinkType.AstraDB,
            },
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EmbeddingConfig = new AzureOpenAIEmbeddingConfig()
            {
                Component = new()
                {
                    AdditionalKwargs = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    ApiBase = "api_base",
                    ApiKey = "api_key",
                    ApiVersion = "api_version",
                    AzureDeployment = "azure_deployment",
                    AzureEndpoint = "azure_endpoint",
                    ClassName = "class_name",
                    DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
                    Dimensions = 0,
                    EmbedBatchSize = 1,
                    MaxRetries = 0,
                    ModelName = "model_name",
                    NumWorkers = 0,
                    ReuseClient = true,
                    Timeout = 0,
                },
                Type = Type.AzureEmbedding,
            },
            EmbeddingModelConfigID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ManagedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MetadataConfig = new()
            {
                ExcludedEmbedMetadataKeys = ["string"],
                ExcludedLlmMetadataKeys = ["string"],
            },
            SparseModelConfig = new() { ClassName = "class_name", ModelType = ModelType.Auto },
            Status = "status",
            TransformConfig = new AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = AutoTransformConfigMode.Auto,
            },

            // Null should be interpreted as omitted for these properties
            LlamaParseParameters = null,
            PipelineType = null,
            PresetRetrievalParameters = null,
        };

        Assert.Null(model.LlamaParseParameters);
        Assert.False(model.RawData.ContainsKey("llama_parse_parameters"));
        Assert.Null(model.PipelineType);
        Assert.False(model.RawData.ContainsKey("pipeline_type"));
        Assert.Null(model.PresetRetrievalParameters);
        Assert.False(model.RawData.ContainsKey("preset_retrieval_parameters"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PipelineCreate
        {
            Name = "x",
            DataSink = new()
            {
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                SinkType = SinkType.AstraDB,
            },
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EmbeddingConfig = new AzureOpenAIEmbeddingConfig()
            {
                Component = new()
                {
                    AdditionalKwargs = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    ApiBase = "api_base",
                    ApiKey = "api_key",
                    ApiVersion = "api_version",
                    AzureDeployment = "azure_deployment",
                    AzureEndpoint = "azure_endpoint",
                    ClassName = "class_name",
                    DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
                    Dimensions = 0,
                    EmbedBatchSize = 1,
                    MaxRetries = 0,
                    ModelName = "model_name",
                    NumWorkers = 0,
                    ReuseClient = true,
                    Timeout = 0,
                },
                Type = Type.AzureEmbedding,
            },
            EmbeddingModelConfigID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ManagedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MetadataConfig = new()
            {
                ExcludedEmbedMetadataKeys = ["string"],
                ExcludedLlmMetadataKeys = ["string"],
            },
            SparseModelConfig = new() { ClassName = "class_name", ModelType = ModelType.Auto },
            Status = "status",
            TransformConfig = new AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = AutoTransformConfigMode.Auto,
            },

            // Null should be interpreted as omitted for these properties
            LlamaParseParameters = null,
            PipelineType = null,
            PresetRetrievalParameters = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PipelineCreate
        {
            Name = "x",
            LlamaParseParameters = new()
            {
                AdaptiveLongTable = true,
                AggressiveTableExtraction = true,
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
            },
            PipelineType = PipelineType.Managed,
            PresetRetrievalParameters = new()
            {
                Alpha = 0,
                ClassName = "class_name",
                DenseSimilarityCutoff = 0,
                DenseSimilarityTopK = 1,
                EnableReranking = true,
                FilesTopK = 1,
                RerankTopN = 1,
                RetrievalMode = RetrievalMode.AutoRouted,
                RetrieveImageNodes = true,
                RetrievePageFigureNodes = true,
                RetrievePageScreenshotNodes = true,
                SearchFilters = new()
                {
                    Filters =
                    [
                        new MetadataFilter()
                        {
                            Key = "key",
                            Value = 0,
                            Operator = Operator.Undefined,
                        },
                    ],
                    Condition = Condition.And,
                },
                SearchFiltersInferenceSchema = new Dictionary<
                    string,
                    PresetRetrievalParamsSearchFiltersInferenceSchema?
                >()
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
                SparseSimilarityTopK = 1,
            },
        };

        Assert.Null(model.DataSink);
        Assert.False(model.RawData.ContainsKey("data_sink"));
        Assert.Null(model.DataSinkID);
        Assert.False(model.RawData.ContainsKey("data_sink_id"));
        Assert.Null(model.EmbeddingConfig);
        Assert.False(model.RawData.ContainsKey("embedding_config"));
        Assert.Null(model.EmbeddingModelConfigID);
        Assert.False(model.RawData.ContainsKey("embedding_model_config_id"));
        Assert.Null(model.ManagedPipelineID);
        Assert.False(model.RawData.ContainsKey("managed_pipeline_id"));
        Assert.Null(model.MetadataConfig);
        Assert.False(model.RawData.ContainsKey("metadata_config"));
        Assert.Null(model.SparseModelConfig);
        Assert.False(model.RawData.ContainsKey("sparse_model_config"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.TransformConfig);
        Assert.False(model.RawData.ContainsKey("transform_config"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PipelineCreate
        {
            Name = "x",
            LlamaParseParameters = new()
            {
                AdaptiveLongTable = true,
                AggressiveTableExtraction = true,
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
            },
            PipelineType = PipelineType.Managed,
            PresetRetrievalParameters = new()
            {
                Alpha = 0,
                ClassName = "class_name",
                DenseSimilarityCutoff = 0,
                DenseSimilarityTopK = 1,
                EnableReranking = true,
                FilesTopK = 1,
                RerankTopN = 1,
                RetrievalMode = RetrievalMode.AutoRouted,
                RetrieveImageNodes = true,
                RetrievePageFigureNodes = true,
                RetrievePageScreenshotNodes = true,
                SearchFilters = new()
                {
                    Filters =
                    [
                        new MetadataFilter()
                        {
                            Key = "key",
                            Value = 0,
                            Operator = Operator.Undefined,
                        },
                    ],
                    Condition = Condition.And,
                },
                SearchFiltersInferenceSchema = new Dictionary<
                    string,
                    PresetRetrievalParamsSearchFiltersInferenceSchema?
                >()
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
                SparseSimilarityTopK = 1,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PipelineCreate
        {
            Name = "x",
            LlamaParseParameters = new()
            {
                AdaptiveLongTable = true,
                AggressiveTableExtraction = true,
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
            },
            PipelineType = PipelineType.Managed,
            PresetRetrievalParameters = new()
            {
                Alpha = 0,
                ClassName = "class_name",
                DenseSimilarityCutoff = 0,
                DenseSimilarityTopK = 1,
                EnableReranking = true,
                FilesTopK = 1,
                RerankTopN = 1,
                RetrievalMode = RetrievalMode.AutoRouted,
                RetrieveImageNodes = true,
                RetrievePageFigureNodes = true,
                RetrievePageScreenshotNodes = true,
                SearchFilters = new()
                {
                    Filters =
                    [
                        new MetadataFilter()
                        {
                            Key = "key",
                            Value = 0,
                            Operator = Operator.Undefined,
                        },
                    ],
                    Condition = Condition.And,
                },
                SearchFiltersInferenceSchema = new Dictionary<
                    string,
                    PresetRetrievalParamsSearchFiltersInferenceSchema?
                >()
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
                SparseSimilarityTopK = 1,
            },

            DataSink = null,
            DataSinkID = null,
            EmbeddingConfig = null,
            EmbeddingModelConfigID = null,
            ManagedPipelineID = null,
            MetadataConfig = null,
            SparseModelConfig = null,
            Status = null,
            TransformConfig = null,
        };

        Assert.Null(model.DataSink);
        Assert.True(model.RawData.ContainsKey("data_sink"));
        Assert.Null(model.DataSinkID);
        Assert.True(model.RawData.ContainsKey("data_sink_id"));
        Assert.Null(model.EmbeddingConfig);
        Assert.True(model.RawData.ContainsKey("embedding_config"));
        Assert.Null(model.EmbeddingModelConfigID);
        Assert.True(model.RawData.ContainsKey("embedding_model_config_id"));
        Assert.Null(model.ManagedPipelineID);
        Assert.True(model.RawData.ContainsKey("managed_pipeline_id"));
        Assert.Null(model.MetadataConfig);
        Assert.True(model.RawData.ContainsKey("metadata_config"));
        Assert.Null(model.SparseModelConfig);
        Assert.True(model.RawData.ContainsKey("sparse_model_config"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.TransformConfig);
        Assert.True(model.RawData.ContainsKey("transform_config"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PipelineCreate
        {
            Name = "x",
            LlamaParseParameters = new()
            {
                AdaptiveLongTable = true,
                AggressiveTableExtraction = true,
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
            },
            PipelineType = PipelineType.Managed,
            PresetRetrievalParameters = new()
            {
                Alpha = 0,
                ClassName = "class_name",
                DenseSimilarityCutoff = 0,
                DenseSimilarityTopK = 1,
                EnableReranking = true,
                FilesTopK = 1,
                RerankTopN = 1,
                RetrievalMode = RetrievalMode.AutoRouted,
                RetrieveImageNodes = true,
                RetrievePageFigureNodes = true,
                RetrievePageScreenshotNodes = true,
                SearchFilters = new()
                {
                    Filters =
                    [
                        new MetadataFilter()
                        {
                            Key = "key",
                            Value = 0,
                            Operator = Operator.Undefined,
                        },
                    ],
                    Condition = Condition.And,
                },
                SearchFiltersInferenceSchema = new Dictionary<
                    string,
                    PresetRetrievalParamsSearchFiltersInferenceSchema?
                >()
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
                SparseSimilarityTopK = 1,
            },

            DataSink = null,
            DataSinkID = null,
            EmbeddingConfig = null,
            EmbeddingModelConfigID = null,
            ManagedPipelineID = null,
            MetadataConfig = null,
            SparseModelConfig = null,
            Status = null,
            TransformConfig = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PipelineCreate
        {
            Name = "x",
            DataSink = new()
            {
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                SinkType = SinkType.AstraDB,
            },
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EmbeddingConfig = new AzureOpenAIEmbeddingConfig()
            {
                Component = new()
                {
                    AdditionalKwargs = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    ApiBase = "api_base",
                    ApiKey = "api_key",
                    ApiVersion = "api_version",
                    AzureDeployment = "azure_deployment",
                    AzureEndpoint = "azure_endpoint",
                    ClassName = "class_name",
                    DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
                    Dimensions = 0,
                    EmbedBatchSize = 1,
                    MaxRetries = 0,
                    ModelName = "model_name",
                    NumWorkers = 0,
                    ReuseClient = true,
                    Timeout = 0,
                },
                Type = Type.AzureEmbedding,
            },
            EmbeddingModelConfigID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            LlamaParseParameters = new()
            {
                AdaptiveLongTable = true,
                AggressiveTableExtraction = true,
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
            },
            ManagedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MetadataConfig = new()
            {
                ExcludedEmbedMetadataKeys = ["string"],
                ExcludedLlmMetadataKeys = ["string"],
            },
            PipelineType = PipelineType.Managed,
            PresetRetrievalParameters = new()
            {
                Alpha = 0,
                ClassName = "class_name",
                DenseSimilarityCutoff = 0,
                DenseSimilarityTopK = 1,
                EnableReranking = true,
                FilesTopK = 1,
                RerankTopN = 1,
                RetrievalMode = RetrievalMode.AutoRouted,
                RetrieveImageNodes = true,
                RetrievePageFigureNodes = true,
                RetrievePageScreenshotNodes = true,
                SearchFilters = new()
                {
                    Filters =
                    [
                        new MetadataFilter()
                        {
                            Key = "key",
                            Value = 0,
                            Operator = Operator.Undefined,
                        },
                    ],
                    Condition = Condition.And,
                },
                SearchFiltersInferenceSchema = new Dictionary<
                    string,
                    PresetRetrievalParamsSearchFiltersInferenceSchema?
                >()
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
                SparseSimilarityTopK = 1,
            },
            SparseModelConfig = new() { ClassName = "class_name", ModelType = ModelType.Auto },
            Status = "status",
            TransformConfig = new AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = AutoTransformConfigMode.Auto,
            },
        };

        PipelineCreate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PipelineCreateEmbeddingConfigTest : TestBase
{
    [Fact]
    public void AzureOpenAIValidationWorks()
    {
        PipelineCreateEmbeddingConfig value = new AzureOpenAIEmbeddingConfig()
        {
            Component = new()
            {
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ApiBase = "api_base",
                ApiKey = "api_key",
                ApiVersion = "api_version",
                AzureDeployment = "azure_deployment",
                AzureEndpoint = "azure_endpoint",
                ClassName = "class_name",
                DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
                Dimensions = 0,
                EmbedBatchSize = 1,
                MaxRetries = 0,
                ModelName = "model_name",
                NumWorkers = 0,
                ReuseClient = true,
                Timeout = 0,
            },
            Type = Type.AzureEmbedding,
        };
        value.Validate();
    }

    [Fact]
    public void BedrockValidationWorks()
    {
        PipelineCreateEmbeddingConfig value = new BedrockEmbeddingConfig()
        {
            Component = new()
            {
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                AwsAccessKeyID = "aws_access_key_id",
                AwsSecretAccessKey = "aws_secret_access_key",
                AwsSessionToken = "aws_session_token",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                MaxRetries = 1,
                ModelName = "model_name",
                NumWorkers = 0,
                ProfileName = "profile_name",
                RegionName = "region_name",
                Timeout = 0,
            },
            Type = BedrockEmbeddingConfigType.BedrockEmbedding,
        };
        value.Validate();
    }

    [Fact]
    public void CohereValidationWorks()
    {
        PipelineCreateEmbeddingConfig value = new CohereEmbeddingConfig()
        {
            Component = new()
            {
                ApiKey = "api_key",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                EmbeddingType = "embedding_type",
                InputType = "input_type",
                ModelName = "model_name",
                NumWorkers = 0,
                Truncate = "truncate",
            },
            Type = CohereEmbeddingConfigType.CohereEmbedding,
        };
        value.Validate();
    }

    [Fact]
    public void GeminiValidationWorks()
    {
        PipelineCreateEmbeddingConfig value = new GeminiEmbeddingConfig()
        {
            Component = new()
            {
                ApiBase = "api_base",
                ApiKey = "api_key",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                ModelName = "model_name",
                NumWorkers = 0,
                OutputDimensionality = 0,
                TaskType = "task_type",
                Title = "title",
                Transport = "transport",
            },
            Type = GeminiEmbeddingConfigType.GeminiEmbedding,
        };
        value.Validate();
    }

    [Fact]
    public void HuggingFaceInferenceApiValidationWorks()
    {
        PipelineCreateEmbeddingConfig value = new HuggingFaceInferenceApiEmbeddingConfig()
        {
            Component = new()
            {
                Token = "string",
                ClassName = "class_name",
                Cookies = new Dictionary<string, string>() { { "foo", "string" } },
                EmbedBatchSize = 1,
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ModelName = "model_name",
                NumWorkers = 0,
                Pooling = Pooling.Cls,
                QueryInstruction = "query_instruction",
                Task = "task",
                TextInstruction = "text_instruction",
                Timeout = 0,
            },
            Type = HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding,
        };
        value.Validate();
    }

    [Fact]
    public void OpenAIValidationWorks()
    {
        PipelineCreateEmbeddingConfig value = new OpenAIEmbeddingConfig()
        {
            Component = new()
            {
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ApiBase = "api_base",
                ApiKey = "api_key",
                ApiVersion = "api_version",
                ClassName = "class_name",
                DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
                Dimensions = 0,
                EmbedBatchSize = 1,
                MaxRetries = 0,
                ModelName = "model_name",
                NumWorkers = 0,
                ReuseClient = true,
                Timeout = 0,
            },
            Type = OpenAIEmbeddingConfigType.OpenAIEmbedding,
        };
        value.Validate();
    }

    [Fact]
    public void VertexAIValidationWorks()
    {
        PipelineCreateEmbeddingConfig value = new VertexAIEmbeddingConfig()
        {
            Component = new()
            {
                ClientEmail = "client_email",
                Location = "location",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                Project = "project",
                TokenUri = "token_uri",
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ClassName = "class_name",
                EmbedBatchSize = 1,
                EmbedMode = EmbedMode.Classification,
                ModelName = "model_name",
                NumWorkers = 0,
            },
            Type = VertexAIEmbeddingConfigType.VertexaiEmbedding,
        };
        value.Validate();
    }

    [Fact]
    public void AzureOpenAISerializationRoundtripWorks()
    {
        PipelineCreateEmbeddingConfig value = new AzureOpenAIEmbeddingConfig()
        {
            Component = new()
            {
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ApiBase = "api_base",
                ApiKey = "api_key",
                ApiVersion = "api_version",
                AzureDeployment = "azure_deployment",
                AzureEndpoint = "azure_endpoint",
                ClassName = "class_name",
                DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
                Dimensions = 0,
                EmbedBatchSize = 1,
                MaxRetries = 0,
                ModelName = "model_name",
                NumWorkers = 0,
                ReuseClient = true,
                Timeout = 0,
            },
            Type = Type.AzureEmbedding,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineCreateEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BedrockSerializationRoundtripWorks()
    {
        PipelineCreateEmbeddingConfig value = new BedrockEmbeddingConfig()
        {
            Component = new()
            {
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                AwsAccessKeyID = "aws_access_key_id",
                AwsSecretAccessKey = "aws_secret_access_key",
                AwsSessionToken = "aws_session_token",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                MaxRetries = 1,
                ModelName = "model_name",
                NumWorkers = 0,
                ProfileName = "profile_name",
                RegionName = "region_name",
                Timeout = 0,
            },
            Type = BedrockEmbeddingConfigType.BedrockEmbedding,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineCreateEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CohereSerializationRoundtripWorks()
    {
        PipelineCreateEmbeddingConfig value = new CohereEmbeddingConfig()
        {
            Component = new()
            {
                ApiKey = "api_key",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                EmbeddingType = "embedding_type",
                InputType = "input_type",
                ModelName = "model_name",
                NumWorkers = 0,
                Truncate = "truncate",
            },
            Type = CohereEmbeddingConfigType.CohereEmbedding,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineCreateEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GeminiSerializationRoundtripWorks()
    {
        PipelineCreateEmbeddingConfig value = new GeminiEmbeddingConfig()
        {
            Component = new()
            {
                ApiBase = "api_base",
                ApiKey = "api_key",
                ClassName = "class_name",
                EmbedBatchSize = 1,
                ModelName = "model_name",
                NumWorkers = 0,
                OutputDimensionality = 0,
                TaskType = "task_type",
                Title = "title",
                Transport = "transport",
            },
            Type = GeminiEmbeddingConfigType.GeminiEmbedding,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineCreateEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void HuggingFaceInferenceApiSerializationRoundtripWorks()
    {
        PipelineCreateEmbeddingConfig value = new HuggingFaceInferenceApiEmbeddingConfig()
        {
            Component = new()
            {
                Token = "string",
                ClassName = "class_name",
                Cookies = new Dictionary<string, string>() { { "foo", "string" } },
                EmbedBatchSize = 1,
                Headers = new Dictionary<string, string>() { { "foo", "string" } },
                ModelName = "model_name",
                NumWorkers = 0,
                Pooling = Pooling.Cls,
                QueryInstruction = "query_instruction",
                Task = "task",
                TextInstruction = "text_instruction",
                Timeout = 0,
            },
            Type = HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineCreateEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OpenAISerializationRoundtripWorks()
    {
        PipelineCreateEmbeddingConfig value = new OpenAIEmbeddingConfig()
        {
            Component = new()
            {
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ApiBase = "api_base",
                ApiKey = "api_key",
                ApiVersion = "api_version",
                ClassName = "class_name",
                DefaultHeaders = new Dictionary<string, string>() { { "foo", "string" } },
                Dimensions = 0,
                EmbedBatchSize = 1,
                MaxRetries = 0,
                ModelName = "model_name",
                NumWorkers = 0,
                ReuseClient = true,
                Timeout = 0,
            },
            Type = OpenAIEmbeddingConfigType.OpenAIEmbedding,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineCreateEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VertexAISerializationRoundtripWorks()
    {
        PipelineCreateEmbeddingConfig value = new VertexAIEmbeddingConfig()
        {
            Component = new()
            {
                ClientEmail = "client_email",
                Location = "location",
                PrivateKey = "private_key",
                PrivateKeyID = "private_key_id",
                Project = "project",
                TokenUri = "token_uri",
                AdditionalKwargs = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                ClassName = "class_name",
                EmbedBatchSize = 1,
                EmbedMode = EmbedMode.Classification,
                ModelName = "model_name",
                NumWorkers = 0,
            },
            Type = VertexAIEmbeddingConfigType.VertexaiEmbedding,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineCreateEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PipelineCreateTransformConfigTest : TestBase
{
    [Fact]
    public void AutoValidationWorks()
    {
        PipelineCreateTransformConfig value = new AutoTransformConfig()
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = AutoTransformConfigMode.Auto,
        };
        value.Validate();
    }

    [Fact]
    public void AdvancedModeValidationWorks()
    {
        PipelineCreateTransformConfig value = new AdvancedModeTransformConfig()
        {
            ChunkingConfig = new NoneChunkingConfig() { Mode = Mode.None },
            Mode = AdvancedModeTransformConfigMode.Advanced,
            SegmentationConfig = new NoneSegmentationConfig()
            {
                Mode = NoneSegmentationConfigMode.None,
            },
        };
        value.Validate();
    }

    [Fact]
    public void AutoSerializationRoundtripWorks()
    {
        PipelineCreateTransformConfig value = new AutoTransformConfig()
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = AutoTransformConfigMode.Auto,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineCreateTransformConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AdvancedModeSerializationRoundtripWorks()
    {
        PipelineCreateTransformConfig value = new AdvancedModeTransformConfig()
        {
            ChunkingConfig = new NoneChunkingConfig() { Mode = Mode.None },
            Mode = AdvancedModeTransformConfigMode.Advanced,
            SegmentationConfig = new NoneSegmentationConfig()
            {
                Mode = NoneSegmentationConfigMode.None,
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PipelineCreateTransformConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
