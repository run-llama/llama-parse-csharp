using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Parsing;
using Pipelines = LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class PipelineCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Pipelines::PipelineCreateParams
        {
            Name = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSink = new()
            {
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                SinkType = Pipelines::SinkType.AstraDB,
            },
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EmbeddingConfig = new Pipelines::AzureOpenAIEmbeddingConfig()
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
                Type = Pipelines::Type.AzureEmbedding,
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
                ImagesToSave = [Pipelines::ImagesToSave.Embedded],
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
                Languages = [ParsingLanguages.Abq],
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
                ParseMode = ParsingMode.ParseDocumentWithAgent,
                ParsingInstruction = "parsing_instruction",
                PreciseBoundingBox = true,
                PremiumMode = true,
                PresentationOutOfBoundsContent = true,
                PresentationSkipEmbeddedData = true,
                PreserveLayoutAlignmentAcrossPages = true,
                PreserveVerySmallText = true,
                Preset = "preset",
                Priority = Pipelines::Priority.Critical,
                ProjectID = "project_id",
                RemoveHiddenText = true,
                ReplaceFailedPageMode = FailPageMode.BlankPage,
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
                        WebhookEvents =
                        [
                            Pipelines::WebhookEvent.ParseSuccess,
                            Pipelines::WebhookEvent.ParseError,
                        ],
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
            PipelineType = Pipelines::PipelineType.Managed,
            PresetRetrievalParameters = new()
            {
                Alpha = 0,
                ClassName = "class_name",
                DenseSimilarityCutoff = 0,
                DenseSimilarityTopK = 1,
                EnableReranking = true,
                FilesTopK = 1,
                RerankTopN = 1,
                RetrievalMode = Pipelines::RetrievalMode.AutoRouted,
                RetrieveImageNodes = true,
                RetrievePageFigureNodes = true,
                RetrievePageScreenshotNodes = true,
                SearchFilters = new()
                {
                    Filters =
                    [
                        new Pipelines::MetadataFilter()
                        {
                            Key = "key",
                            Value = 0,
                            Operator = Pipelines::Operator.Undefined,
                        },
                    ],
                    Condition = Pipelines::Condition.And,
                },
                SearchFiltersInferenceSchema = new Dictionary<
                    string,
                    Pipelines::PresetRetrievalParamsSearchFiltersInferenceSchema?
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
            SparseModelConfig = new()
            {
                ClassName = "class_name",
                ModelType = Pipelines::ModelType.Auto,
            },
            Status = "status",
            TransformConfig = new Pipelines::AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = Pipelines::AutoTransformConfigMode.Auto,
            },
        };

        string expectedName = "x";
        string expectedOrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Pipelines::DataSinkCreate expectedDataSink = new()
        {
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            SinkType = Pipelines::SinkType.AstraDB,
        };
        string expectedDataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Pipelines::EmbeddingConfig expectedEmbeddingConfig =
            new Pipelines::AzureOpenAIEmbeddingConfig()
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
                Type = Pipelines::Type.AzureEmbedding,
            };
        string expectedEmbeddingModelConfigID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Pipelines::LlamaParseParameters expectedLlamaParseParameters = new()
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
            ImagesToSave = [Pipelines::ImagesToSave.Embedded],
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
            Languages = [ParsingLanguages.Abq],
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
            ParseMode = ParsingMode.ParseDocumentWithAgent,
            ParsingInstruction = "parsing_instruction",
            PreciseBoundingBox = true,
            PremiumMode = true,
            PresentationOutOfBoundsContent = true,
            PresentationSkipEmbeddedData = true,
            PreserveLayoutAlignmentAcrossPages = true,
            PreserveVerySmallText = true,
            Preset = "preset",
            Priority = Pipelines::Priority.Critical,
            ProjectID = "project_id",
            RemoveHiddenText = true,
            ReplaceFailedPageMode = FailPageMode.BlankPage,
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
                    WebhookEvents =
                    [
                        Pipelines::WebhookEvent.ParseSuccess,
                        Pipelines::WebhookEvent.ParseError,
                    ],
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
        Pipelines::PipelineMetadataConfig expectedMetadataConfig = new()
        {
            ExcludedEmbedMetadataKeys = ["string"],
            ExcludedLlmMetadataKeys = ["string"],
        };
        ApiEnum<string, Pipelines::PipelineType> expectedPipelineType =
            Pipelines::PipelineType.Managed;
        Pipelines::PresetRetrievalParams expectedPresetRetrievalParameters = new()
        {
            Alpha = 0,
            ClassName = "class_name",
            DenseSimilarityCutoff = 0,
            DenseSimilarityTopK = 1,
            EnableReranking = true,
            FilesTopK = 1,
            RerankTopN = 1,
            RetrievalMode = Pipelines::RetrievalMode.AutoRouted,
            RetrieveImageNodes = true,
            RetrievePageFigureNodes = true,
            RetrievePageScreenshotNodes = true,
            SearchFilters = new()
            {
                Filters =
                [
                    new Pipelines::MetadataFilter()
                    {
                        Key = "key",
                        Value = 0,
                        Operator = Pipelines::Operator.Undefined,
                    },
                ],
                Condition = Pipelines::Condition.And,
            },
            SearchFiltersInferenceSchema = new Dictionary<
                string,
                Pipelines::PresetRetrievalParamsSearchFiltersInferenceSchema?
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
        Pipelines::SparseModelConfig expectedSparseModelConfig = new()
        {
            ClassName = "class_name",
            ModelType = Pipelines::ModelType.Auto,
        };
        string expectedStatus = "status";
        Pipelines::TransformConfig expectedTransformConfig = new Pipelines::AutoTransformConfig()
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = Pipelines::AutoTransformConfigMode.Auto,
        };

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedOrganizationID, parameters.OrganizationID);
        Assert.Equal(expectedProjectID, parameters.ProjectID);
        Assert.Equal(expectedDataSink, parameters.DataSink);
        Assert.Equal(expectedDataSinkID, parameters.DataSinkID);
        Assert.Equal(expectedEmbeddingConfig, parameters.EmbeddingConfig);
        Assert.Equal(expectedEmbeddingModelConfigID, parameters.EmbeddingModelConfigID);
        Assert.Equal(expectedLlamaParseParameters, parameters.LlamaParseParameters);
        Assert.Equal(expectedManagedPipelineID, parameters.ManagedPipelineID);
        Assert.Equal(expectedMetadataConfig, parameters.MetadataConfig);
        Assert.Equal(expectedPipelineType, parameters.PipelineType);
        Assert.Equal(expectedPresetRetrievalParameters, parameters.PresetRetrievalParameters);
        Assert.Equal(expectedSparseModelConfig, parameters.SparseModelConfig);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedTransformConfig, parameters.TransformConfig);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Pipelines::PipelineCreateParams
        {
            Name = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSink = new()
            {
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                SinkType = Pipelines::SinkType.AstraDB,
            },
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EmbeddingConfig = new Pipelines::AzureOpenAIEmbeddingConfig()
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
                Type = Pipelines::Type.AzureEmbedding,
            },
            EmbeddingModelConfigID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ManagedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MetadataConfig = new()
            {
                ExcludedEmbedMetadataKeys = ["string"],
                ExcludedLlmMetadataKeys = ["string"],
            },
            SparseModelConfig = new()
            {
                ClassName = "class_name",
                ModelType = Pipelines::ModelType.Auto,
            },
            Status = "status",
            TransformConfig = new Pipelines::AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = Pipelines::AutoTransformConfigMode.Auto,
            },
        };

        Assert.Null(parameters.LlamaParseParameters);
        Assert.False(parameters.RawBodyData.ContainsKey("llama_parse_parameters"));
        Assert.Null(parameters.PipelineType);
        Assert.False(parameters.RawBodyData.ContainsKey("pipeline_type"));
        Assert.Null(parameters.PresetRetrievalParameters);
        Assert.False(parameters.RawBodyData.ContainsKey("preset_retrieval_parameters"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Pipelines::PipelineCreateParams
        {
            Name = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSink = new()
            {
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                SinkType = Pipelines::SinkType.AstraDB,
            },
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EmbeddingConfig = new Pipelines::AzureOpenAIEmbeddingConfig()
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
                Type = Pipelines::Type.AzureEmbedding,
            },
            EmbeddingModelConfigID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ManagedPipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            MetadataConfig = new()
            {
                ExcludedEmbedMetadataKeys = ["string"],
                ExcludedLlmMetadataKeys = ["string"],
            },
            SparseModelConfig = new()
            {
                ClassName = "class_name",
                ModelType = Pipelines::ModelType.Auto,
            },
            Status = "status",
            TransformConfig = new Pipelines::AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = Pipelines::AutoTransformConfigMode.Auto,
            },

            // Null should be interpreted as omitted for these properties
            LlamaParseParameters = null,
            PipelineType = null,
            PresetRetrievalParameters = null,
        };

        Assert.Null(parameters.LlamaParseParameters);
        Assert.False(parameters.RawBodyData.ContainsKey("llama_parse_parameters"));
        Assert.Null(parameters.PipelineType);
        Assert.False(parameters.RawBodyData.ContainsKey("pipeline_type"));
        Assert.Null(parameters.PresetRetrievalParameters);
        Assert.False(parameters.RawBodyData.ContainsKey("preset_retrieval_parameters"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Pipelines::PipelineCreateParams
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
                ImagesToSave = [Pipelines::ImagesToSave.Embedded],
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
                Languages = [ParsingLanguages.Abq],
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
                ParseMode = ParsingMode.ParseDocumentWithAgent,
                ParsingInstruction = "parsing_instruction",
                PreciseBoundingBox = true,
                PremiumMode = true,
                PresentationOutOfBoundsContent = true,
                PresentationSkipEmbeddedData = true,
                PreserveLayoutAlignmentAcrossPages = true,
                PreserveVerySmallText = true,
                Preset = "preset",
                Priority = Pipelines::Priority.Critical,
                ProjectID = "project_id",
                RemoveHiddenText = true,
                ReplaceFailedPageMode = FailPageMode.BlankPage,
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
                        WebhookEvents =
                        [
                            Pipelines::WebhookEvent.ParseSuccess,
                            Pipelines::WebhookEvent.ParseError,
                        ],
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
            PipelineType = Pipelines::PipelineType.Managed,
            PresetRetrievalParameters = new()
            {
                Alpha = 0,
                ClassName = "class_name",
                DenseSimilarityCutoff = 0,
                DenseSimilarityTopK = 1,
                EnableReranking = true,
                FilesTopK = 1,
                RerankTopN = 1,
                RetrievalMode = Pipelines::RetrievalMode.AutoRouted,
                RetrieveImageNodes = true,
                RetrievePageFigureNodes = true,
                RetrievePageScreenshotNodes = true,
                SearchFilters = new()
                {
                    Filters =
                    [
                        new Pipelines::MetadataFilter()
                        {
                            Key = "key",
                            Value = 0,
                            Operator = Pipelines::Operator.Undefined,
                        },
                    ],
                    Condition = Pipelines::Condition.And,
                },
                SearchFiltersInferenceSchema = new Dictionary<
                    string,
                    Pipelines::PresetRetrievalParamsSearchFiltersInferenceSchema?
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

        Assert.Null(parameters.OrganizationID);
        Assert.False(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.False(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.DataSink);
        Assert.False(parameters.RawBodyData.ContainsKey("data_sink"));
        Assert.Null(parameters.DataSinkID);
        Assert.False(parameters.RawBodyData.ContainsKey("data_sink_id"));
        Assert.Null(parameters.EmbeddingConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("embedding_config"));
        Assert.Null(parameters.EmbeddingModelConfigID);
        Assert.False(parameters.RawBodyData.ContainsKey("embedding_model_config_id"));
        Assert.Null(parameters.ManagedPipelineID);
        Assert.False(parameters.RawBodyData.ContainsKey("managed_pipeline_id"));
        Assert.Null(parameters.MetadataConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata_config"));
        Assert.Null(parameters.SparseModelConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("sparse_model_config"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.TransformConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("transform_config"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Pipelines::PipelineCreateParams
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
                ImagesToSave = [Pipelines::ImagesToSave.Embedded],
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
                Languages = [ParsingLanguages.Abq],
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
                ParseMode = ParsingMode.ParseDocumentWithAgent,
                ParsingInstruction = "parsing_instruction",
                PreciseBoundingBox = true,
                PremiumMode = true,
                PresentationOutOfBoundsContent = true,
                PresentationSkipEmbeddedData = true,
                PreserveLayoutAlignmentAcrossPages = true,
                PreserveVerySmallText = true,
                Preset = "preset",
                Priority = Pipelines::Priority.Critical,
                ProjectID = "project_id",
                RemoveHiddenText = true,
                ReplaceFailedPageMode = FailPageMode.BlankPage,
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
                        WebhookEvents =
                        [
                            Pipelines::WebhookEvent.ParseSuccess,
                            Pipelines::WebhookEvent.ParseError,
                        ],
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
            PipelineType = Pipelines::PipelineType.Managed,
            PresetRetrievalParameters = new()
            {
                Alpha = 0,
                ClassName = "class_name",
                DenseSimilarityCutoff = 0,
                DenseSimilarityTopK = 1,
                EnableReranking = true,
                FilesTopK = 1,
                RerankTopN = 1,
                RetrievalMode = Pipelines::RetrievalMode.AutoRouted,
                RetrieveImageNodes = true,
                RetrievePageFigureNodes = true,
                RetrievePageScreenshotNodes = true,
                SearchFilters = new()
                {
                    Filters =
                    [
                        new Pipelines::MetadataFilter()
                        {
                            Key = "key",
                            Value = 0,
                            Operator = Pipelines::Operator.Undefined,
                        },
                    ],
                    Condition = Pipelines::Condition.And,
                },
                SearchFiltersInferenceSchema = new Dictionary<
                    string,
                    Pipelines::PresetRetrievalParamsSearchFiltersInferenceSchema?
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

            OrganizationID = null,
            ProjectID = null,
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

        Assert.Null(parameters.OrganizationID);
        Assert.True(parameters.RawQueryData.ContainsKey("organization_id"));
        Assert.Null(parameters.ProjectID);
        Assert.True(parameters.RawQueryData.ContainsKey("project_id"));
        Assert.Null(parameters.DataSink);
        Assert.True(parameters.RawBodyData.ContainsKey("data_sink"));
        Assert.Null(parameters.DataSinkID);
        Assert.True(parameters.RawBodyData.ContainsKey("data_sink_id"));
        Assert.Null(parameters.EmbeddingConfig);
        Assert.True(parameters.RawBodyData.ContainsKey("embedding_config"));
        Assert.Null(parameters.EmbeddingModelConfigID);
        Assert.True(parameters.RawBodyData.ContainsKey("embedding_model_config_id"));
        Assert.Null(parameters.ManagedPipelineID);
        Assert.True(parameters.RawBodyData.ContainsKey("managed_pipeline_id"));
        Assert.Null(parameters.MetadataConfig);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata_config"));
        Assert.Null(parameters.SparseModelConfig);
        Assert.True(parameters.RawBodyData.ContainsKey("sparse_model_config"));
        Assert.Null(parameters.Status);
        Assert.True(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.TransformConfig);
        Assert.True(parameters.RawBodyData.ContainsKey("transform_config"));
    }

    [Fact]
    public void Url_Works()
    {
        Pipelines::PipelineCreateParams parameters = new()
        {
            Name = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.cloud.llamaindex.ai/api/v1/pipelines?organization_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&project_id=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Pipelines::PipelineCreateParams
        {
            Name = "x",
            OrganizationID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            DataSink = new()
            {
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                SinkType = Pipelines::SinkType.AstraDB,
            },
            DataSinkID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EmbeddingConfig = new Pipelines::AzureOpenAIEmbeddingConfig()
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
                Type = Pipelines::Type.AzureEmbedding,
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
                ImagesToSave = [Pipelines::ImagesToSave.Embedded],
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
                Languages = [ParsingLanguages.Abq],
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
                ParseMode = ParsingMode.ParseDocumentWithAgent,
                ParsingInstruction = "parsing_instruction",
                PreciseBoundingBox = true,
                PremiumMode = true,
                PresentationOutOfBoundsContent = true,
                PresentationSkipEmbeddedData = true,
                PreserveLayoutAlignmentAcrossPages = true,
                PreserveVerySmallText = true,
                Preset = "preset",
                Priority = Pipelines::Priority.Critical,
                ProjectID = "project_id",
                RemoveHiddenText = true,
                ReplaceFailedPageMode = FailPageMode.BlankPage,
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
                        WebhookEvents =
                        [
                            Pipelines::WebhookEvent.ParseSuccess,
                            Pipelines::WebhookEvent.ParseError,
                        ],
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
            PipelineType = Pipelines::PipelineType.Managed,
            PresetRetrievalParameters = new()
            {
                Alpha = 0,
                ClassName = "class_name",
                DenseSimilarityCutoff = 0,
                DenseSimilarityTopK = 1,
                EnableReranking = true,
                FilesTopK = 1,
                RerankTopN = 1,
                RetrievalMode = Pipelines::RetrievalMode.AutoRouted,
                RetrieveImageNodes = true,
                RetrievePageFigureNodes = true,
                RetrievePageScreenshotNodes = true,
                SearchFilters = new()
                {
                    Filters =
                    [
                        new Pipelines::MetadataFilter()
                        {
                            Key = "key",
                            Value = 0,
                            Operator = Pipelines::Operator.Undefined,
                        },
                    ],
                    Condition = Pipelines::Condition.And,
                },
                SearchFiltersInferenceSchema = new Dictionary<
                    string,
                    Pipelines::PresetRetrievalParamsSearchFiltersInferenceSchema?
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
            SparseModelConfig = new()
            {
                ClassName = "class_name",
                ModelType = Pipelines::ModelType.Auto,
            },
            Status = "status",
            TransformConfig = new Pipelines::AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = Pipelines::AutoTransformConfigMode.Auto,
            },
        };

        Pipelines::PipelineCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EmbeddingConfigTest : TestBase
{
    [Fact]
    public void AzureOpenAIValidationWorks()
    {
        Pipelines::EmbeddingConfig value = new Pipelines::AzureOpenAIEmbeddingConfig()
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
            Type = Pipelines::Type.AzureEmbedding,
        };
        value.Validate();
    }

    [Fact]
    public void BedrockValidationWorks()
    {
        Pipelines::EmbeddingConfig value = new Pipelines::BedrockEmbeddingConfig()
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
            Type = Pipelines::BedrockEmbeddingConfigType.BedrockEmbedding,
        };
        value.Validate();
    }

    [Fact]
    public void CohereValidationWorks()
    {
        Pipelines::EmbeddingConfig value = new Pipelines::CohereEmbeddingConfig()
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
            Type = Pipelines::CohereEmbeddingConfigType.CohereEmbedding,
        };
        value.Validate();
    }

    [Fact]
    public void GeminiValidationWorks()
    {
        Pipelines::EmbeddingConfig value = new Pipelines::GeminiEmbeddingConfig()
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
            Type = Pipelines::GeminiEmbeddingConfigType.GeminiEmbedding,
        };
        value.Validate();
    }

    [Fact]
    public void HuggingFaceInferenceApiValidationWorks()
    {
        Pipelines::EmbeddingConfig value = new Pipelines::HuggingFaceInferenceApiEmbeddingConfig()
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
                Pooling = Pipelines::Pooling.Cls,
                QueryInstruction = "query_instruction",
                Task = "task",
                TextInstruction = "text_instruction",
                Timeout = 0,
            },
            Type = Pipelines::HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding,
        };
        value.Validate();
    }

    [Fact]
    public void OpenAIValidationWorks()
    {
        Pipelines::EmbeddingConfig value = new Pipelines::OpenAIEmbeddingConfig()
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
            Type = Pipelines::OpenAIEmbeddingConfigType.OpenAIEmbedding,
        };
        value.Validate();
    }

    [Fact]
    public void VertexAIValidationWorks()
    {
        Pipelines::EmbeddingConfig value = new Pipelines::VertexAIEmbeddingConfig()
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
                EmbedMode = Pipelines::EmbedMode.Classification,
                ModelName = "model_name",
                NumWorkers = 0,
            },
            Type = Pipelines::VertexAIEmbeddingConfigType.VertexaiEmbedding,
        };
        value.Validate();
    }

    [Fact]
    public void AzureOpenAISerializationRoundtripWorks()
    {
        Pipelines::EmbeddingConfig value = new Pipelines::AzureOpenAIEmbeddingConfig()
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
            Type = Pipelines::Type.AzureEmbedding,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::EmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BedrockSerializationRoundtripWorks()
    {
        Pipelines::EmbeddingConfig value = new Pipelines::BedrockEmbeddingConfig()
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
            Type = Pipelines::BedrockEmbeddingConfigType.BedrockEmbedding,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::EmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CohereSerializationRoundtripWorks()
    {
        Pipelines::EmbeddingConfig value = new Pipelines::CohereEmbeddingConfig()
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
            Type = Pipelines::CohereEmbeddingConfigType.CohereEmbedding,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::EmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GeminiSerializationRoundtripWorks()
    {
        Pipelines::EmbeddingConfig value = new Pipelines::GeminiEmbeddingConfig()
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
            Type = Pipelines::GeminiEmbeddingConfigType.GeminiEmbedding,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::EmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void HuggingFaceInferenceApiSerializationRoundtripWorks()
    {
        Pipelines::EmbeddingConfig value = new Pipelines::HuggingFaceInferenceApiEmbeddingConfig()
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
                Pooling = Pipelines::Pooling.Cls,
                QueryInstruction = "query_instruction",
                Task = "task",
                TextInstruction = "text_instruction",
                Timeout = 0,
            },
            Type = Pipelines::HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::EmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OpenAISerializationRoundtripWorks()
    {
        Pipelines::EmbeddingConfig value = new Pipelines::OpenAIEmbeddingConfig()
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
            Type = Pipelines::OpenAIEmbeddingConfigType.OpenAIEmbedding,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::EmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VertexAISerializationRoundtripWorks()
    {
        Pipelines::EmbeddingConfig value = new Pipelines::VertexAIEmbeddingConfig()
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
                EmbedMode = Pipelines::EmbedMode.Classification,
                ModelName = "model_name",
                NumWorkers = 0,
            },
            Type = Pipelines::VertexAIEmbeddingConfigType.VertexaiEmbedding,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::EmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TransformConfigTest : TestBase
{
    [Fact]
    public void AutoValidationWorks()
    {
        Pipelines::TransformConfig value = new Pipelines::AutoTransformConfig()
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = Pipelines::AutoTransformConfigMode.Auto,
        };
        value.Validate();
    }

    [Fact]
    public void AdvancedModeValidationWorks()
    {
        Pipelines::TransformConfig value = new Pipelines::AdvancedModeTransformConfig()
        {
            ChunkingConfig = new Pipelines::NoneChunkingConfig() { Mode = Pipelines::Mode.None },
            Mode = Pipelines::AdvancedModeTransformConfigMode.Advanced,
            SegmentationConfig = new Pipelines::NoneSegmentationConfig()
            {
                Mode = Pipelines::NoneSegmentationConfigMode.None,
            },
        };
        value.Validate();
    }

    [Fact]
    public void AutoSerializationRoundtripWorks()
    {
        Pipelines::TransformConfig value = new Pipelines::AutoTransformConfig()
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = Pipelines::AutoTransformConfigMode.Auto,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::TransformConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AdvancedModeSerializationRoundtripWorks()
    {
        Pipelines::TransformConfig value = new Pipelines::AdvancedModeTransformConfig()
        {
            ChunkingConfig = new Pipelines::NoneChunkingConfig() { Mode = Pipelines::Mode.None },
            Mode = Pipelines::AdvancedModeTransformConfigMode.Advanced,
            SegmentationConfig = new Pipelines::NoneSegmentationConfig()
            {
                Mode = Pipelines::NoneSegmentationConfigMode.None,
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::TransformConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
