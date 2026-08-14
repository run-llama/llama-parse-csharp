using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.DataSinks;
using LlamaIndex.LlamaCloud.Models.Parsing;
using Pipelines = LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Models.Pipelines;

public class PipelineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pipelines::Pipeline
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConfigHash = new()
            {
                EmbeddingConfigHash = "embedding_config_hash",
                ParsingConfigHash = "parsing_config_hash",
                TransformConfigHash = "transform_config_hash",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DataSink = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SinkType = DataSinkSinkType.AstraDB,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            EmbeddingModelConfig = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Status = Pipelines::PipelineStatus.Created,
            TransformConfig = new Pipelines::AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = Pipelines::AutoTransformConfigMode.Auto,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Pipelines::PipelineEmbeddingConfig expectedEmbeddingConfig =
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
        string expectedName = "name";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Pipelines::ConfigHash expectedConfigHash = new()
        {
            EmbeddingConfigHash = "embedding_config_hash",
            ParsingConfigHash = "parsing_config_hash",
            TransformConfigHash = "transform_config_hash",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DataSink expectedDataSink = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SinkType = DataSinkSinkType.AstraDB,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Pipelines::EmbeddingModelConfig expectedEmbeddingModelConfig = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        ApiEnum<string, Pipelines::PipelineStatus> expectedStatus =
            Pipelines::PipelineStatus.Created;
        Pipelines::PipelineTransformConfig expectedTransformConfig =
            new Pipelines::AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = Pipelines::AutoTransformConfigMode.Auto,
            };
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEmbeddingConfig, model.EmbeddingConfig);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedConfigHash, model.ConfigHash);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDataSink, model.DataSink);
        Assert.Equal(expectedEmbeddingModelConfig, model.EmbeddingModelConfig);
        Assert.Equal(expectedEmbeddingModelConfigID, model.EmbeddingModelConfigID);
        Assert.Equal(expectedLlamaParseParameters, model.LlamaParseParameters);
        Assert.Equal(expectedManagedPipelineID, model.ManagedPipelineID);
        Assert.Equal(expectedMetadataConfig, model.MetadataConfig);
        Assert.Equal(expectedPipelineType, model.PipelineType);
        Assert.Equal(expectedPresetRetrievalParameters, model.PresetRetrievalParameters);
        Assert.Equal(expectedSparseModelConfig, model.SparseModelConfig);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTransformConfig, model.TransformConfig);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pipelines::Pipeline
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConfigHash = new()
            {
                EmbeddingConfigHash = "embedding_config_hash",
                ParsingConfigHash = "parsing_config_hash",
                TransformConfigHash = "transform_config_hash",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DataSink = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SinkType = DataSinkSinkType.AstraDB,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            EmbeddingModelConfig = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Status = Pipelines::PipelineStatus.Created,
            TransformConfig = new Pipelines::AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = Pipelines::AutoTransformConfigMode.Auto,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::Pipeline>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pipelines::Pipeline
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConfigHash = new()
            {
                EmbeddingConfigHash = "embedding_config_hash",
                ParsingConfigHash = "parsing_config_hash",
                TransformConfigHash = "transform_config_hash",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DataSink = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SinkType = DataSinkSinkType.AstraDB,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            EmbeddingModelConfig = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Status = Pipelines::PipelineStatus.Created,
            TransformConfig = new Pipelines::AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = Pipelines::AutoTransformConfigMode.Auto,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::Pipeline>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Pipelines::PipelineEmbeddingConfig expectedEmbeddingConfig =
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
        string expectedName = "name";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Pipelines::ConfigHash expectedConfigHash = new()
        {
            EmbeddingConfigHash = "embedding_config_hash",
            ParsingConfigHash = "parsing_config_hash",
            TransformConfigHash = "transform_config_hash",
        };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DataSink expectedDataSink = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Component = new(
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            ),
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            SinkType = DataSinkSinkType.AstraDB,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Pipelines::EmbeddingModelConfig expectedEmbeddingModelConfig = new()
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        ApiEnum<string, Pipelines::PipelineStatus> expectedStatus =
            Pipelines::PipelineStatus.Created;
        Pipelines::PipelineTransformConfig expectedTransformConfig =
            new Pipelines::AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = Pipelines::AutoTransformConfigMode.Auto,
            };
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEmbeddingConfig, deserialized.EmbeddingConfig);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedConfigHash, deserialized.ConfigHash);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDataSink, deserialized.DataSink);
        Assert.Equal(expectedEmbeddingModelConfig, deserialized.EmbeddingModelConfig);
        Assert.Equal(expectedEmbeddingModelConfigID, deserialized.EmbeddingModelConfigID);
        Assert.Equal(expectedLlamaParseParameters, deserialized.LlamaParseParameters);
        Assert.Equal(expectedManagedPipelineID, deserialized.ManagedPipelineID);
        Assert.Equal(expectedMetadataConfig, deserialized.MetadataConfig);
        Assert.Equal(expectedPipelineType, deserialized.PipelineType);
        Assert.Equal(expectedPresetRetrievalParameters, deserialized.PresetRetrievalParameters);
        Assert.Equal(expectedSparseModelConfig, deserialized.SparseModelConfig);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTransformConfig, deserialized.TransformConfig);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pipelines::Pipeline
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConfigHash = new()
            {
                EmbeddingConfigHash = "embedding_config_hash",
                ParsingConfigHash = "parsing_config_hash",
                TransformConfigHash = "transform_config_hash",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DataSink = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SinkType = DataSinkSinkType.AstraDB,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            EmbeddingModelConfig = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Status = Pipelines::PipelineStatus.Created,
            TransformConfig = new Pipelines::AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = Pipelines::AutoTransformConfigMode.Auto,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Pipelines::Pipeline
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConfigHash = new()
            {
                EmbeddingConfigHash = "embedding_config_hash",
                ParsingConfigHash = "parsing_config_hash",
                TransformConfigHash = "transform_config_hash",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DataSink = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SinkType = DataSinkSinkType.AstraDB,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            EmbeddingModelConfig = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            SparseModelConfig = new()
            {
                ClassName = "class_name",
                ModelType = Pipelines::ModelType.Auto,
            },
            Status = Pipelines::PipelineStatus.Created,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.PipelineType);
        Assert.False(model.RawData.ContainsKey("pipeline_type"));
        Assert.Null(model.PresetRetrievalParameters);
        Assert.False(model.RawData.ContainsKey("preset_retrieval_parameters"));
        Assert.Null(model.TransformConfig);
        Assert.False(model.RawData.ContainsKey("transform_config"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Pipelines::Pipeline
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConfigHash = new()
            {
                EmbeddingConfigHash = "embedding_config_hash",
                ParsingConfigHash = "parsing_config_hash",
                TransformConfigHash = "transform_config_hash",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DataSink = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SinkType = DataSinkSinkType.AstraDB,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            EmbeddingModelConfig = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            SparseModelConfig = new()
            {
                ClassName = "class_name",
                ModelType = Pipelines::ModelType.Auto,
            },
            Status = Pipelines::PipelineStatus.Created,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Pipelines::Pipeline
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConfigHash = new()
            {
                EmbeddingConfigHash = "embedding_config_hash",
                ParsingConfigHash = "parsing_config_hash",
                TransformConfigHash = "transform_config_hash",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DataSink = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SinkType = DataSinkSinkType.AstraDB,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            EmbeddingModelConfig = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            SparseModelConfig = new()
            {
                ClassName = "class_name",
                ModelType = Pipelines::ModelType.Auto,
            },
            Status = Pipelines::PipelineStatus.Created,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            PipelineType = null,
            PresetRetrievalParameters = null,
            TransformConfig = null,
        };

        Assert.Null(model.PipelineType);
        Assert.False(model.RawData.ContainsKey("pipeline_type"));
        Assert.Null(model.PresetRetrievalParameters);
        Assert.False(model.RawData.ContainsKey("preset_retrieval_parameters"));
        Assert.Null(model.TransformConfig);
        Assert.False(model.RawData.ContainsKey("transform_config"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Pipelines::Pipeline
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConfigHash = new()
            {
                EmbeddingConfigHash = "embedding_config_hash",
                ParsingConfigHash = "parsing_config_hash",
                TransformConfigHash = "transform_config_hash",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DataSink = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SinkType = DataSinkSinkType.AstraDB,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            EmbeddingModelConfig = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            SparseModelConfig = new()
            {
                ClassName = "class_name",
                ModelType = Pipelines::ModelType.Auto,
            },
            Status = Pipelines::PipelineStatus.Created,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            PipelineType = null,
            PresetRetrievalParameters = null,
            TransformConfig = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Pipelines::Pipeline
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            TransformConfig = new Pipelines::AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = Pipelines::AutoTransformConfigMode.Auto,
            },
        };

        Assert.Null(model.ConfigHash);
        Assert.False(model.RawData.ContainsKey("config_hash"));
        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DataSink);
        Assert.False(model.RawData.ContainsKey("data_sink"));
        Assert.Null(model.EmbeddingModelConfig);
        Assert.False(model.RawData.ContainsKey("embedding_model_config"));
        Assert.Null(model.EmbeddingModelConfigID);
        Assert.False(model.RawData.ContainsKey("embedding_model_config_id"));
        Assert.Null(model.LlamaParseParameters);
        Assert.False(model.RawData.ContainsKey("llama_parse_parameters"));
        Assert.Null(model.ManagedPipelineID);
        Assert.False(model.RawData.ContainsKey("managed_pipeline_id"));
        Assert.Null(model.MetadataConfig);
        Assert.False(model.RawData.ContainsKey("metadata_config"));
        Assert.Null(model.SparseModelConfig);
        Assert.False(model.RawData.ContainsKey("sparse_model_config"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Pipelines::Pipeline
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            TransformConfig = new Pipelines::AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = Pipelines::AutoTransformConfigMode.Auto,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Pipelines::Pipeline
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            TransformConfig = new Pipelines::AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = Pipelines::AutoTransformConfigMode.Auto,
            },

            ConfigHash = null,
            CreatedAt = null,
            DataSink = null,
            EmbeddingModelConfig = null,
            EmbeddingModelConfigID = null,
            LlamaParseParameters = null,
            ManagedPipelineID = null,
            MetadataConfig = null,
            SparseModelConfig = null,
            Status = null,
            UpdatedAt = null,
        };

        Assert.Null(model.ConfigHash);
        Assert.True(model.RawData.ContainsKey("config_hash"));
        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.DataSink);
        Assert.True(model.RawData.ContainsKey("data_sink"));
        Assert.Null(model.EmbeddingModelConfig);
        Assert.True(model.RawData.ContainsKey("embedding_model_config"));
        Assert.Null(model.EmbeddingModelConfigID);
        Assert.True(model.RawData.ContainsKey("embedding_model_config_id"));
        Assert.Null(model.LlamaParseParameters);
        Assert.True(model.RawData.ContainsKey("llama_parse_parameters"));
        Assert.Null(model.ManagedPipelineID);
        Assert.True(model.RawData.ContainsKey("managed_pipeline_id"));
        Assert.Null(model.MetadataConfig);
        Assert.True(model.RawData.ContainsKey("metadata_config"));
        Assert.Null(model.SparseModelConfig);
        Assert.True(model.RawData.ContainsKey("sparse_model_config"));
        Assert.Null(model.Status);
        Assert.True(model.RawData.ContainsKey("status"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Pipelines::Pipeline
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            TransformConfig = new Pipelines::AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = Pipelines::AutoTransformConfigMode.Auto,
            },

            ConfigHash = null,
            CreatedAt = null,
            DataSink = null,
            EmbeddingModelConfig = null,
            EmbeddingModelConfigID = null,
            LlamaParseParameters = null,
            ManagedPipelineID = null,
            MetadataConfig = null,
            SparseModelConfig = null,
            Status = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pipelines::Pipeline
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            ConfigHash = new()
            {
                EmbeddingConfigHash = "embedding_config_hash",
                ParsingConfigHash = "parsing_config_hash",
                TransformConfigHash = "transform_config_hash",
            },
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DataSink = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Component = new(
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                ),
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                SinkType = DataSinkSinkType.AstraDB,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            EmbeddingModelConfig = new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
                Name = "name",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Status = Pipelines::PipelineStatus.Created,
            TransformConfig = new Pipelines::AutoTransformConfig()
            {
                ChunkOverlap = 0,
                ChunkSize = 1,
                Mode = Pipelines::AutoTransformConfigMode.Auto,
            },
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Pipelines::Pipeline copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PipelineEmbeddingConfigTest : TestBase
{
    [Fact]
    public void AzureOpenAIValidationWorks()
    {
        Pipelines::PipelineEmbeddingConfig value = new Pipelines::AzureOpenAIEmbeddingConfig()
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
        Pipelines::PipelineEmbeddingConfig value = new Pipelines::BedrockEmbeddingConfig()
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
        Pipelines::PipelineEmbeddingConfig value = new Pipelines::CohereEmbeddingConfig()
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
        Pipelines::PipelineEmbeddingConfig value = new Pipelines::GeminiEmbeddingConfig()
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
        Pipelines::PipelineEmbeddingConfig value =
            new Pipelines::HuggingFaceInferenceApiEmbeddingConfig()
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
                Type =
                    Pipelines::HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding,
            };
        value.Validate();
    }

    [Fact]
    public void ManagedOpenAIEmbeddingValidationWorks()
    {
        Pipelines::PipelineEmbeddingConfig value = new Pipelines::ManagedOpenAIEmbedding()
        {
            Component = new()
            {
                ClassName = "class_name",
                EmbedBatchSize = 1,
                ModelName =
                    Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
                NumWorkers = 0,
            },
            Type = Pipelines::ManagedOpenAIEmbeddingType.ManagedOpenAIEmbedding,
        };
        value.Validate();
    }

    [Fact]
    public void OpenAIValidationWorks()
    {
        Pipelines::PipelineEmbeddingConfig value = new Pipelines::OpenAIEmbeddingConfig()
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
        Pipelines::PipelineEmbeddingConfig value = new Pipelines::VertexAIEmbeddingConfig()
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
        Pipelines::PipelineEmbeddingConfig value = new Pipelines::AzureOpenAIEmbeddingConfig()
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
        var deserialized = JsonSerializer.Deserialize<Pipelines::PipelineEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BedrockSerializationRoundtripWorks()
    {
        Pipelines::PipelineEmbeddingConfig value = new Pipelines::BedrockEmbeddingConfig()
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
        var deserialized = JsonSerializer.Deserialize<Pipelines::PipelineEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CohereSerializationRoundtripWorks()
    {
        Pipelines::PipelineEmbeddingConfig value = new Pipelines::CohereEmbeddingConfig()
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
        var deserialized = JsonSerializer.Deserialize<Pipelines::PipelineEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GeminiSerializationRoundtripWorks()
    {
        Pipelines::PipelineEmbeddingConfig value = new Pipelines::GeminiEmbeddingConfig()
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
        var deserialized = JsonSerializer.Deserialize<Pipelines::PipelineEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void HuggingFaceInferenceApiSerializationRoundtripWorks()
    {
        Pipelines::PipelineEmbeddingConfig value =
            new Pipelines::HuggingFaceInferenceApiEmbeddingConfig()
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
                Type =
                    Pipelines::HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::PipelineEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ManagedOpenAIEmbeddingSerializationRoundtripWorks()
    {
        Pipelines::PipelineEmbeddingConfig value = new Pipelines::ManagedOpenAIEmbedding()
        {
            Component = new()
            {
                ClassName = "class_name",
                EmbedBatchSize = 1,
                ModelName =
                    Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
                NumWorkers = 0,
            },
            Type = Pipelines::ManagedOpenAIEmbeddingType.ManagedOpenAIEmbedding,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::PipelineEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OpenAISerializationRoundtripWorks()
    {
        Pipelines::PipelineEmbeddingConfig value = new Pipelines::OpenAIEmbeddingConfig()
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
        var deserialized = JsonSerializer.Deserialize<Pipelines::PipelineEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VertexAISerializationRoundtripWorks()
    {
        Pipelines::PipelineEmbeddingConfig value = new Pipelines::VertexAIEmbeddingConfig()
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
        var deserialized = JsonSerializer.Deserialize<Pipelines::PipelineEmbeddingConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ManagedOpenAIEmbeddingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbedding
        {
            Component = new()
            {
                ClassName = "class_name",
                EmbedBatchSize = 1,
                ModelName =
                    Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
                NumWorkers = 0,
            },
            Type = Pipelines::ManagedOpenAIEmbeddingType.ManagedOpenAIEmbedding,
        };

        Pipelines::ManagedOpenAIEmbeddingComponent expectedComponent = new()
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,
            ModelName =
                Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
            NumWorkers = 0,
        };
        ApiEnum<string, Pipelines::ManagedOpenAIEmbeddingType> expectedType =
            Pipelines::ManagedOpenAIEmbeddingType.ManagedOpenAIEmbedding;

        Assert.Equal(expectedComponent, model.Component);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbedding
        {
            Component = new()
            {
                ClassName = "class_name",
                EmbedBatchSize = 1,
                ModelName =
                    Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
                NumWorkers = 0,
            },
            Type = Pipelines::ManagedOpenAIEmbeddingType.ManagedOpenAIEmbedding,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::ManagedOpenAIEmbedding>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbedding
        {
            Component = new()
            {
                ClassName = "class_name",
                EmbedBatchSize = 1,
                ModelName =
                    Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
                NumWorkers = 0,
            },
            Type = Pipelines::ManagedOpenAIEmbeddingType.ManagedOpenAIEmbedding,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::ManagedOpenAIEmbedding>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Pipelines::ManagedOpenAIEmbeddingComponent expectedComponent = new()
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,
            ModelName =
                Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
            NumWorkers = 0,
        };
        ApiEnum<string, Pipelines::ManagedOpenAIEmbeddingType> expectedType =
            Pipelines::ManagedOpenAIEmbeddingType.ManagedOpenAIEmbedding;

        Assert.Equal(expectedComponent, deserialized.Component);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbedding
        {
            Component = new()
            {
                ClassName = "class_name",
                EmbedBatchSize = 1,
                ModelName =
                    Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
                NumWorkers = 0,
            },
            Type = Pipelines::ManagedOpenAIEmbeddingType.ManagedOpenAIEmbedding,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbedding { };

        Assert.Null(model.Component);
        Assert.False(model.RawData.ContainsKey("component"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbedding { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbedding
        {
            // Null should be interpreted as omitted for these properties
            Component = null,
            Type = null,
        };

        Assert.Null(model.Component);
        Assert.False(model.RawData.ContainsKey("component"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbedding
        {
            // Null should be interpreted as omitted for these properties
            Component = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbedding
        {
            Component = new()
            {
                ClassName = "class_name",
                EmbedBatchSize = 1,
                ModelName =
                    Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
                NumWorkers = 0,
            },
            Type = Pipelines::ManagedOpenAIEmbeddingType.ManagedOpenAIEmbedding,
        };

        Pipelines::ManagedOpenAIEmbedding copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ManagedOpenAIEmbeddingComponentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbeddingComponent
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,
            ModelName =
                Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
            NumWorkers = 0,
        };

        string expectedClassName = "class_name";
        long expectedEmbedBatchSize = 1;
        ApiEnum<string, Pipelines::ManagedOpenAIEmbeddingComponentModelName> expectedModelName =
            Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small;
        long expectedNumWorkers = 0;

        Assert.Equal(expectedClassName, model.ClassName);
        Assert.Equal(expectedEmbedBatchSize, model.EmbedBatchSize);
        Assert.Equal(expectedModelName, model.ModelName);
        Assert.Equal(expectedNumWorkers, model.NumWorkers);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbeddingComponent
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,
            ModelName =
                Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
            NumWorkers = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::ManagedOpenAIEmbeddingComponent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbeddingComponent
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,
            ModelName =
                Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
            NumWorkers = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::ManagedOpenAIEmbeddingComponent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClassName = "class_name";
        long expectedEmbedBatchSize = 1;
        ApiEnum<string, Pipelines::ManagedOpenAIEmbeddingComponentModelName> expectedModelName =
            Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small;
        long expectedNumWorkers = 0;

        Assert.Equal(expectedClassName, deserialized.ClassName);
        Assert.Equal(expectedEmbedBatchSize, deserialized.EmbedBatchSize);
        Assert.Equal(expectedModelName, deserialized.ModelName);
        Assert.Equal(expectedNumWorkers, deserialized.NumWorkers);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbeddingComponent
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,
            ModelName =
                Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
            NumWorkers = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbeddingComponent { NumWorkers = 0 };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.EmbedBatchSize);
        Assert.False(model.RawData.ContainsKey("embed_batch_size"));
        Assert.Null(model.ModelName);
        Assert.False(model.RawData.ContainsKey("model_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbeddingComponent { NumWorkers = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbeddingComponent
        {
            NumWorkers = 0,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            EmbedBatchSize = null,
            ModelName = null,
        };

        Assert.Null(model.ClassName);
        Assert.False(model.RawData.ContainsKey("class_name"));
        Assert.Null(model.EmbedBatchSize);
        Assert.False(model.RawData.ContainsKey("embed_batch_size"));
        Assert.Null(model.ModelName);
        Assert.False(model.RawData.ContainsKey("model_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbeddingComponent
        {
            NumWorkers = 0,

            // Null should be interpreted as omitted for these properties
            ClassName = null,
            EmbedBatchSize = null,
            ModelName = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbeddingComponent
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,
            ModelName =
                Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
        };

        Assert.Null(model.NumWorkers);
        Assert.False(model.RawData.ContainsKey("num_workers"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbeddingComponent
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,
            ModelName =
                Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbeddingComponent
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,
            ModelName =
                Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,

            NumWorkers = null,
        };

        Assert.Null(model.NumWorkers);
        Assert.True(model.RawData.ContainsKey("num_workers"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbeddingComponent
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,
            ModelName =
                Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,

            NumWorkers = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pipelines::ManagedOpenAIEmbeddingComponent
        {
            ClassName = "class_name",
            EmbedBatchSize = 1,
            ModelName =
                Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small,
            NumWorkers = 0,
        };

        Pipelines::ManagedOpenAIEmbeddingComponent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ManagedOpenAIEmbeddingComponentModelNameTest : TestBase
{
    [Theory]
    [InlineData(Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small)]
    public void Validation_Works(Pipelines::ManagedOpenAIEmbeddingComponentModelName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Pipelines::ManagedOpenAIEmbeddingComponentModelName> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Pipelines::ManagedOpenAIEmbeddingComponentModelName>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Pipelines::ManagedOpenAIEmbeddingComponentModelName.OpenAITextEmbedding3Small)]
    public void SerializationRoundtrip_Works(
        Pipelines::ManagedOpenAIEmbeddingComponentModelName rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Pipelines::ManagedOpenAIEmbeddingComponentModelName> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Pipelines::ManagedOpenAIEmbeddingComponentModelName>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Pipelines::ManagedOpenAIEmbeddingComponentModelName>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Pipelines::ManagedOpenAIEmbeddingComponentModelName>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ManagedOpenAIEmbeddingTypeTest : TestBase
{
    [Theory]
    [InlineData(Pipelines::ManagedOpenAIEmbeddingType.ManagedOpenAIEmbedding)]
    public void Validation_Works(Pipelines::ManagedOpenAIEmbeddingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Pipelines::ManagedOpenAIEmbeddingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Pipelines::ManagedOpenAIEmbeddingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Pipelines::ManagedOpenAIEmbeddingType.ManagedOpenAIEmbedding)]
    public void SerializationRoundtrip_Works(Pipelines::ManagedOpenAIEmbeddingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Pipelines::ManagedOpenAIEmbeddingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Pipelines::ManagedOpenAIEmbeddingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Pipelines::ManagedOpenAIEmbeddingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Pipelines::ManagedOpenAIEmbeddingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConfigHashTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pipelines::ConfigHash
        {
            EmbeddingConfigHash = "embedding_config_hash",
            ParsingConfigHash = "parsing_config_hash",
            TransformConfigHash = "transform_config_hash",
        };

        string expectedEmbeddingConfigHash = "embedding_config_hash";
        string expectedParsingConfigHash = "parsing_config_hash";
        string expectedTransformConfigHash = "transform_config_hash";

        Assert.Equal(expectedEmbeddingConfigHash, model.EmbeddingConfigHash);
        Assert.Equal(expectedParsingConfigHash, model.ParsingConfigHash);
        Assert.Equal(expectedTransformConfigHash, model.TransformConfigHash);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pipelines::ConfigHash
        {
            EmbeddingConfigHash = "embedding_config_hash",
            ParsingConfigHash = "parsing_config_hash",
            TransformConfigHash = "transform_config_hash",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::ConfigHash>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pipelines::ConfigHash
        {
            EmbeddingConfigHash = "embedding_config_hash",
            ParsingConfigHash = "parsing_config_hash",
            TransformConfigHash = "transform_config_hash",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::ConfigHash>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmbeddingConfigHash = "embedding_config_hash";
        string expectedParsingConfigHash = "parsing_config_hash";
        string expectedTransformConfigHash = "transform_config_hash";

        Assert.Equal(expectedEmbeddingConfigHash, deserialized.EmbeddingConfigHash);
        Assert.Equal(expectedParsingConfigHash, deserialized.ParsingConfigHash);
        Assert.Equal(expectedTransformConfigHash, deserialized.TransformConfigHash);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pipelines::ConfigHash
        {
            EmbeddingConfigHash = "embedding_config_hash",
            ParsingConfigHash = "parsing_config_hash",
            TransformConfigHash = "transform_config_hash",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Pipelines::ConfigHash { };

        Assert.Null(model.EmbeddingConfigHash);
        Assert.False(model.RawData.ContainsKey("embedding_config_hash"));
        Assert.Null(model.ParsingConfigHash);
        Assert.False(model.RawData.ContainsKey("parsing_config_hash"));
        Assert.Null(model.TransformConfigHash);
        Assert.False(model.RawData.ContainsKey("transform_config_hash"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Pipelines::ConfigHash { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Pipelines::ConfigHash
        {
            EmbeddingConfigHash = null,
            ParsingConfigHash = null,
            TransformConfigHash = null,
        };

        Assert.Null(model.EmbeddingConfigHash);
        Assert.True(model.RawData.ContainsKey("embedding_config_hash"));
        Assert.Null(model.ParsingConfigHash);
        Assert.True(model.RawData.ContainsKey("parsing_config_hash"));
        Assert.Null(model.TransformConfigHash);
        Assert.True(model.RawData.ContainsKey("transform_config_hash"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Pipelines::ConfigHash
        {
            EmbeddingConfigHash = null,
            ParsingConfigHash = null,
            TransformConfigHash = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pipelines::ConfigHash
        {
            EmbeddingConfigHash = "embedding_config_hash",
            ParsingConfigHash = "parsing_config_hash",
            TransformConfigHash = "transform_config_hash",
        };

        Pipelines::ConfigHash copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EmbeddingModelConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pipelines::EmbeddingModelConfig
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Pipelines::EmbeddingModelConfigEmbeddingConfig expectedEmbeddingConfig =
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
        string expectedName = "name";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEmbeddingConfig, model.EmbeddingConfig);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pipelines::EmbeddingModelConfig
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::EmbeddingModelConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pipelines::EmbeddingModelConfig
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::EmbeddingModelConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        Pipelines::EmbeddingModelConfigEmbeddingConfig expectedEmbeddingConfig =
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
        string expectedName = "name";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEmbeddingConfig, deserialized.EmbeddingConfig);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pipelines::EmbeddingModelConfig
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Pipelines::EmbeddingModelConfig
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Pipelines::EmbeddingModelConfig
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Pipelines::EmbeddingModelConfig
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            CreatedAt = null,
            UpdatedAt = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Pipelines::EmbeddingModelConfig
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",

            CreatedAt = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pipelines::EmbeddingModelConfig
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
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
            Name = "name",
            ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Pipelines::EmbeddingModelConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EmbeddingModelConfigEmbeddingConfigTest : TestBase
{
    [Fact]
    public void AzureOpenAIValidationWorks()
    {
        Pipelines::EmbeddingModelConfigEmbeddingConfig value =
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
        value.Validate();
    }

    [Fact]
    public void BedrockValidationWorks()
    {
        Pipelines::EmbeddingModelConfigEmbeddingConfig value =
            new Pipelines::BedrockEmbeddingConfig()
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
        Pipelines::EmbeddingModelConfigEmbeddingConfig value =
            new Pipelines::CohereEmbeddingConfig()
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
        Pipelines::EmbeddingModelConfigEmbeddingConfig value =
            new Pipelines::GeminiEmbeddingConfig()
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
        Pipelines::EmbeddingModelConfigEmbeddingConfig value =
            new Pipelines::HuggingFaceInferenceApiEmbeddingConfig()
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
                Type =
                    Pipelines::HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding,
            };
        value.Validate();
    }

    [Fact]
    public void OpenAIValidationWorks()
    {
        Pipelines::EmbeddingModelConfigEmbeddingConfig value =
            new Pipelines::OpenAIEmbeddingConfig()
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
        Pipelines::EmbeddingModelConfigEmbeddingConfig value =
            new Pipelines::VertexAIEmbeddingConfig()
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
        Pipelines::EmbeddingModelConfigEmbeddingConfig value =
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Pipelines::EmbeddingModelConfigEmbeddingConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BedrockSerializationRoundtripWorks()
    {
        Pipelines::EmbeddingModelConfigEmbeddingConfig value =
            new Pipelines::BedrockEmbeddingConfig()
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
        var deserialized =
            JsonSerializer.Deserialize<Pipelines::EmbeddingModelConfigEmbeddingConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CohereSerializationRoundtripWorks()
    {
        Pipelines::EmbeddingModelConfigEmbeddingConfig value =
            new Pipelines::CohereEmbeddingConfig()
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
        var deserialized =
            JsonSerializer.Deserialize<Pipelines::EmbeddingModelConfigEmbeddingConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GeminiSerializationRoundtripWorks()
    {
        Pipelines::EmbeddingModelConfigEmbeddingConfig value =
            new Pipelines::GeminiEmbeddingConfig()
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
        var deserialized =
            JsonSerializer.Deserialize<Pipelines::EmbeddingModelConfigEmbeddingConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void HuggingFaceInferenceApiSerializationRoundtripWorks()
    {
        Pipelines::EmbeddingModelConfigEmbeddingConfig value =
            new Pipelines::HuggingFaceInferenceApiEmbeddingConfig()
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
                Type =
                    Pipelines::HuggingFaceInferenceApiEmbeddingConfigType.HuggingfaceApiEmbedding,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Pipelines::EmbeddingModelConfigEmbeddingConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OpenAISerializationRoundtripWorks()
    {
        Pipelines::EmbeddingModelConfigEmbeddingConfig value =
            new Pipelines::OpenAIEmbeddingConfig()
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
        var deserialized =
            JsonSerializer.Deserialize<Pipelines::EmbeddingModelConfigEmbeddingConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void VertexAISerializationRoundtripWorks()
    {
        Pipelines::EmbeddingModelConfigEmbeddingConfig value =
            new Pipelines::VertexAIEmbeddingConfig()
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
        var deserialized =
            JsonSerializer.Deserialize<Pipelines::EmbeddingModelConfigEmbeddingConfig>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class PipelineStatusTest : TestBase
{
    [Theory]
    [InlineData(Pipelines::PipelineStatus.Created)]
    [InlineData(Pipelines::PipelineStatus.Deleting)]
    public void Validation_Works(Pipelines::PipelineStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Pipelines::PipelineStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Pipelines::PipelineStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Pipelines::PipelineStatus.Created)]
    [InlineData(Pipelines::PipelineStatus.Deleting)]
    public void SerializationRoundtrip_Works(Pipelines::PipelineStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Pipelines::PipelineStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Pipelines::PipelineStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Pipelines::PipelineStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Pipelines::PipelineStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PipelineTransformConfigTest : TestBase
{
    [Fact]
    public void AutoValidationWorks()
    {
        Pipelines::PipelineTransformConfig value = new Pipelines::AutoTransformConfig()
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
        Pipelines::PipelineTransformConfig value = new Pipelines::AdvancedModeTransformConfig()
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
        Pipelines::PipelineTransformConfig value = new Pipelines::AutoTransformConfig()
        {
            ChunkOverlap = 0,
            ChunkSize = 1,
            Mode = Pipelines::AutoTransformConfigMode.Auto,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::PipelineTransformConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AdvancedModeSerializationRoundtripWorks()
    {
        Pipelines::PipelineTransformConfig value = new Pipelines::AdvancedModeTransformConfig()
        {
            ChunkingConfig = new Pipelines::NoneChunkingConfig() { Mode = Pipelines::Mode.None },
            Mode = Pipelines::AdvancedModeTransformConfigMode.Advanced,
            SegmentationConfig = new Pipelines::NoneSegmentationConfig()
            {
                Mode = Pipelines::NoneSegmentationConfigMode.None,
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pipelines::PipelineTransformConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
