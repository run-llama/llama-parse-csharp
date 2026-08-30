using System.Text.Json;
using LlamaCloud.Exceptions;
using LlamaCloud.Models;
using LlamaCloud.Models.Beta.Indexes;
using LlamaCloud.Models.Beta.Retrieval;
using LlamaCloud.Models.Classifier.Jobs;
using LlamaCloud.Models.DataSinks;
using LlamaCloud.Models.DataSources;
using LlamaCloud.Models.JobDataPoints;
using LlamaCloud.Models.Pipelines.Documents;
using LlamaCloud.Models.Retrievers;
using LlamaCloud.Models.Split;
using Batches = LlamaCloud.Models.Batches;
using Chat = LlamaCloud.Models.Beta.Chat;
using Classify = LlamaCloud.Models.Classify;
using Configurations = LlamaCloud.Models.Configurations;
using DataSources = LlamaCloud.Models.Pipelines.DataSources;
using Directories = LlamaCloud.Models.Beta.Directories;
using Extract = LlamaCloud.Models.Extract;
using Files = LlamaCloud.Models.Pipelines.Files;
using Parsing = LlamaCloud.Models.Parsing;
using Pipelines = LlamaCloud.Models.Pipelines;
using Split = LlamaCloud.Models.Beta.Split;
using WebhookConfigs = LlamaCloud.Models.WebhookConfigs;

namespace LlamaCloud.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<bool, SupportsNestedMetadataFilters>(),
            new ApiEnumConverter<
                bool,
                CloudAzureAISearchVectorStoreSupportsNestedMetadataFilters
            >(),
            new ApiEnumConverter<string, AuthenticationMechanism>(),
            new ApiEnumConverter<string, ApiVersion>(),
            new ApiEnumConverter<bool, SupportsAccessControl>(),
            new ApiEnumConverter<bool, CloudPineconeVectorStoreSupportsNestedMetadataFilters>(),
            new ApiEnumConverter<bool, CloudQdrantVectorStoreSupportsNestedMetadataFilters>(),
            new ApiEnumConverter<bool, CloudSharepointDataSourceSupportsAccessControl>(),
            new ApiEnumConverter<string, DistanceMethod>(),
            new ApiEnumConverter<string, VectorType>(),
            new ApiEnumConverter<string, DocumentInputType>(),
            new ApiEnumConverter<string, SplitCreateResponseSplittingStrategyAllowUncategorized>(),
            new ApiEnumConverter<string, SplitListResponseDocumentInputType>(),
            new ApiEnumConverter<string, SplitListResponseSplittingStrategyAllowUncategorized>(),
            new ApiEnumConverter<string, SplitCancelResponseDocumentInputType>(),
            new ApiEnumConverter<string, SplitCancelResponseSplittingStrategyAllowUncategorized>(),
            new ApiEnumConverter<string, SplitGetResponseDocumentInputType>(),
            new ApiEnumConverter<string, SplitGetResponseSplittingStrategyAllowUncategorized>(),
            new ApiEnumConverter<string, AllowUncategorized>(),
            new ApiEnumConverter<string, WebhookEvent>(),
            new ApiEnumConverter<string, Status>(),
            new ApiEnumConverter<string, Parsing::Type>(),
            new ApiEnumConverter<string, Parsing::FailPageMode>(),
            new ApiEnumConverter<string, Parsing::FooterItemType>(),
            new ApiEnumConverter<string, Parsing::Field>(),
            new ApiEnumConverter<string, Parsing::FormFieldType>(),
            new ApiEnumConverter<string, Parsing::FormListItemType>(),
            new ApiEnumConverter<string, Parsing::FormListTextItemType>(),
            new ApiEnumConverter<string, Parsing::FormSectionType>(),
            new ApiEnumConverter<string, Parsing::FormTableType>(),
            new ApiEnumConverter<string, Parsing::HeaderItemType>(),
            new ApiEnumConverter<string, Parsing::HeadingItemType>(),
            new ApiEnumConverter<string, Parsing::ImageItemType>(),
            new ApiEnumConverter<string, Parsing::LinkItemType>(),
            new ApiEnumConverter<string, Parsing::ListItemType>(),
            new ApiEnumConverter<string, Parsing::LlamaParseSupportedFileExtensions>(),
            new ApiEnumConverter<string, Parsing::ParsingLanguages>(),
            new ApiEnumConverter<string, Parsing::ParsingMode>(),
            new ApiEnumConverter<string, Parsing::StatusEnum>(),
            new ApiEnumConverter<string, Parsing::TableItemType>(),
            new ApiEnumConverter<string, Parsing::TextItemType>(),
            new ApiEnumConverter<string, Parsing::ParsingCreateResponseStatus>(),
            new ApiEnumConverter<string, Parsing::ParsingListResponseStatus>(),
            new ApiEnumConverter<string, Parsing::ParsingCancelResponseStatus>(),
            new ApiEnumConverter<string, Parsing::JobStatus>(),
            new ApiEnumConverter<string, Parsing::Category>(),
            new ApiEnumConverter<string, Parsing::RevisionType>(),
            new ApiEnumConverter<string, Parsing::Agentic>(),
            new ApiEnumConverter<string, Parsing::AgenticPlus>(),
            new ApiEnumConverter<string, Parsing::CostEffective>(),
            new ApiEnumConverter<string, Parsing::Fast>(),
            new ApiEnumConverter<string, Parsing::Tier>(),
            new ApiEnumConverter<string, Parsing::Version>(),
            new ApiEnumConverter<string, Parsing::GranularBbox>(),
            new ApiEnumConverter<string, Parsing::ImagesToSave>(),
            new ApiEnumConverter<string, Parsing::SpecializedChartParsing>(),
            new ApiEnumConverter<string, Parsing::ParsingConfTier>(),
            new ApiEnumConverter<string, Parsing::ParsingConfVersion>(),
            new ApiEnumConverter<string, Parsing::ConfidenceScoreEffort>(),
            new ApiEnumConverter<string, Parsing::Forms>(),
            new ApiEnumConverter<string, Parsing::ProcessingOptionsSpecializedChartParsing>(),
            new ApiEnumConverter<string, Parsing::WebhookOutputFormat>(),
            new ApiEnumConverter<string, Parsing::Status>(),
            new ApiEnumConverter<string, Extract::ExtractionTarget>(),
            new ApiEnumConverter<string, Extract::ParseTier>(),
            new ApiEnumConverter<string, Extract::Tier>(),
            new ApiEnumConverter<
                string,
                Extract::ExtractV2JobCreateWebhookConfigurationWebhookEvent
            >(),
            new ApiEnumConverter<string, Extract::WebhookEvent>(),
            new ApiEnumConverter<string, Extract::Status>(),
            new ApiEnumConverter<string, ClassifyJobMode>(),
            new ApiEnumConverter<string, Mode>(),
            new ApiEnumConverter<string, WebhookOutputFormat>(),
            new ApiEnumConverter<string, Batches::BatchCreateResponseConfigJobType>(),
            new ApiEnumConverter<string, Batches::BatchCreateResponseStatus>(),
            new ApiEnumConverter<string, Batches::JobReferenceType>(),
            new ApiEnumConverter<string, Batches::BatchListResponseConfigJobType>(),
            new ApiEnumConverter<string, Batches::BatchListResponseStatus>(),
            new ApiEnumConverter<string, Batches::BatchListResponseResultJobReferenceType>(),
            new ApiEnumConverter<string, Batches::BatchCancelResponseConfigJobType>(),
            new ApiEnumConverter<string, Batches::BatchCancelResponseStatus>(),
            new ApiEnumConverter<string, Batches::BatchCancelResponseResultJobReferenceType>(),
            new ApiEnumConverter<string, Batches::BatchGetResponseConfigJobType>(),
            new ApiEnumConverter<string, Batches::BatchGetResponseStatus>(),
            new ApiEnumConverter<string, Batches::BatchGetResponseResultJobReferenceType>(),
            new ApiEnumConverter<string, Batches::Type>(),
            new ApiEnumConverter<string, Batches::WebhookEvent>(),
            new ApiEnumConverter<string, Batches::Status>(),
            new ApiEnumConverter<string, Classify::Mode>(),
            new ApiEnumConverter<
                string,
                Classify::ClassifyCreateRequestWebhookConfigurationWebhookEvent
            >(),
            new ApiEnumConverter<string, Classify::DocumentInputType>(),
            new ApiEnumConverter<string, Classify::ClassifyCreateResponseStatus>(),
            new ApiEnumConverter<string, Classify::ClassifyListResponseDocumentInputType>(),
            new ApiEnumConverter<string, Classify::ClassifyListResponseStatus>(),
            new ApiEnumConverter<string, Classify::ClassifyCancelResponseDocumentInputType>(),
            new ApiEnumConverter<string, Classify::ClassifyCancelResponseStatus>(),
            new ApiEnumConverter<string, Classify::ClassifyGetResponseDocumentInputType>(),
            new ApiEnumConverter<string, Classify::ClassifyGetResponseStatus>(),
            new ApiEnumConverter<string, Classify::WebhookEvent>(),
            new ApiEnumConverter<string, Classify::Status>(),
            new ApiEnumConverter<string, Configurations::Mode>(),
            new ApiEnumConverter<
                string,
                Configurations::ConfigurationCreateParametersSpreadsheetV1TableMergeSensitivity
            >(),
            new ApiEnumConverter<
                string,
                Configurations::ConfigurationCreateParametersSpreadsheetV1Tier
            >(),
            new ApiEnumConverter<
                string,
                Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity
            >(),
            new ApiEnumConverter<
                string,
                Configurations::ConfigurationResponseParametersSpreadsheetV1Tier
            >(),
            new ApiEnumConverter<string, Configurations::ConfigurationResponseProductType>(),
            new ApiEnumConverter<string, Configurations::ExtractionTarget>(),
            new ApiEnumConverter<string, Configurations::ParseTier>(),
            new ApiEnumConverter<string, Configurations::ExtractV2ParametersTier>(),
            new ApiEnumConverter<string, Configurations::ParseV2ParametersTier>(),
            new ApiEnumConverter<string, Configurations::Version>(),
            new ApiEnumConverter<string, Configurations::GranularBbox>(),
            new ApiEnumConverter<string, Configurations::ImagesToSave>(),
            new ApiEnumConverter<string, Configurations::SpecializedChartParsing>(),
            new ApiEnumConverter<string, Configurations::ParsingConfTier>(),
            new ApiEnumConverter<string, Configurations::ParsingConfVersion>(),
            new ApiEnumConverter<string, Configurations::ConfidenceScoreEffort>(),
            new ApiEnumConverter<string, Configurations::Forms>(),
            new ApiEnumConverter<
                string,
                Configurations::ProcessingOptionsSpecializedChartParsing
            >(),
            new ApiEnumConverter<string, Configurations::WebhookOutputFormat>(),
            new ApiEnumConverter<string, Configurations::AllowUncategorized>(),
            new ApiEnumConverter<string, Configurations::TableMergeSensitivity>(),
            new ApiEnumConverter<string, Configurations::Tier>(),
            new ApiEnumConverter<
                string,
                Configurations::ConfigurationUpdateParamsParametersSpreadsheetV1TableMergeSensitivity
            >(),
            new ApiEnumConverter<
                string,
                Configurations::ConfigurationUpdateParamsParametersSpreadsheetV1Tier
            >(),
            new ApiEnumConverter<string, Configurations::ProductType>(),
            new ApiEnumConverter<string, WebhookConfigs::WebhookConfigCreateWebhookEvent>(),
            new ApiEnumConverter<string, WebhookConfigs::WebhookConfigCreateWebhookOutputFormat>(),
            new ApiEnumConverter<string, WebhookConfigs::WebhookConfigResponseWebhookEvent>(),
            new ApiEnumConverter<
                string,
                WebhookConfigs::WebhookConfigResponseWebhookOutputFormat
            >(),
            new ApiEnumConverter<string, WebhookConfigs::WebhookEvent>(),
            new ApiEnumConverter<string, WebhookConfigs::WebhookOutputFormat>(),
            new ApiEnumConverter<string, WebhookConfigs::WebhookConfigUpdateParamsWebhookEvent>(),
            new ApiEnumConverter<
                string,
                WebhookConfigs::WebhookConfigUpdateParamsWebhookOutputFormat
            >(),
            new ApiEnumConverter<string, JobType>(),
            new ApiEnumConverter<string, DataSinkSinkType>(),
            new ApiEnumConverter<string, SinkType>(),
            new ApiEnumConverter<string, DataSinkUpdateParamsSinkType>(),
            new ApiEnumConverter<string, DataSourceSourceType>(),
            new ApiEnumConverter<string, ReaderVersion>(),
            new ApiEnumConverter<string, SourceType>(),
            new ApiEnumConverter<string, DataSourceUpdateParamsSourceType>(),
            new ApiEnumConverter<string, Pipelines::Mode>(),
            new ApiEnumConverter<string, Pipelines::CharacterChunkingConfigMode>(),
            new ApiEnumConverter<string, Pipelines::TokenChunkingConfigMode>(),
            new ApiEnumConverter<string, Pipelines::SentenceChunkingConfigMode>(),
            new ApiEnumConverter<string, Pipelines::SemanticChunkingConfigMode>(),
            new ApiEnumConverter<string, Pipelines::AdvancedModeTransformConfigMode>(),
            new ApiEnumConverter<string, Pipelines::NoneSegmentationConfigMode>(),
            new ApiEnumConverter<string, Pipelines::PageSegmentationConfigMode>(),
            new ApiEnumConverter<string, Pipelines::ElementSegmentationConfigMode>(),
            new ApiEnumConverter<string, Pipelines::AutoTransformConfigMode>(),
            new ApiEnumConverter<string, Pipelines::Type>(),
            new ApiEnumConverter<string, Pipelines::BedrockEmbeddingConfigType>(),
            new ApiEnumConverter<string, Pipelines::CohereEmbeddingConfigType>(),
            new ApiEnumConverter<string, Pipelines::SinkType>(),
            new ApiEnumConverter<string, Pipelines::GeminiEmbeddingConfigType>(),
            new ApiEnumConverter<string, Pipelines::Pooling>(),
            new ApiEnumConverter<string, Pipelines::HuggingFaceInferenceApiEmbeddingConfigType>(),
            new ApiEnumConverter<string, Pipelines::ImagesToSave>(),
            new ApiEnumConverter<string, Pipelines::Priority>(),
            new ApiEnumConverter<string, Pipelines::WebhookEvent>(),
            new ApiEnumConverter<string, Pipelines::ModelName>(),
            new ApiEnumConverter<string, Pipelines::Status>(),
            new ApiEnumConverter<string, Pipelines::Step>(),
            new ApiEnumConverter<string, Pipelines::MessageRole>(),
            new ApiEnumConverter<string, Pipelines::Operator>(),
            new ApiEnumConverter<string, Pipelines::Condition>(),
            new ApiEnumConverter<string, Pipelines::OpenAIEmbeddingConfigType>(),
            new ApiEnumConverter<string, Pipelines::ManagedOpenAIEmbeddingComponentModelName>(),
            new ApiEnumConverter<string, Pipelines::ManagedOpenAIEmbeddingType>(),
            new ApiEnumConverter<string, Pipelines::PipelineStatus>(),
            new ApiEnumConverter<string, Pipelines::PipelineType>(),
            new ApiEnumConverter<string, Pipelines::RetrievalMode>(),
            new ApiEnumConverter<string, Pipelines::ModelType>(),
            new ApiEnumConverter<string, Pipelines::VertexAIEmbeddingConfigType>(),
            new ApiEnumConverter<string, Pipelines::EmbedMode>(),
            new ApiEnumConverter<string, DataSources::SourceType>(),
            new ApiEnumConverter<string, DataSources::Status>(),
            new ApiEnumConverter<string, Files::PipelineFileStatus>(),
            new ApiEnumConverter<string, Files::Status>(),
            new ApiEnumConverter<string, NodeType>(),
            new ApiEnumConverter<string, RelationshipRelatedNodeInfoNodeType>(),
            new ApiEnumConverter<string, StatusRefreshPolicy>(),
            new ApiEnumConverter<string, CompositeRetrievalMode>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, VectorTarget>(),
            new ApiEnumConverter<string, Operator>(),
            new ApiEnumConverter<string, NumericRangeFilterOperator>(),
            new ApiEnumConverter<string, ParsedDirectoryFileIDOperator>(),
            new ApiEnumConverter<string, Chat::Type>(),
            new ApiEnumConverter<string, Chat::TextDeltaType>(),
            new ApiEnumConverter<string, Chat::TextType>(),
            new ApiEnumConverter<string, Chat::ThinkingDeltaType>(),
            new ApiEnumConverter<string, Chat::ThinkingType>(),
            new ApiEnumConverter<string, Chat::ToolCallType>(),
            new ApiEnumConverter<string, Chat::ToolResultType>(),
            new ApiEnumConverter<string, Chat::UserInputType>(),
            new ApiEnumConverter<string, Directories::DirectoryCreateResponseType>(),
            new ApiEnumConverter<string, Directories::DirectoryUpdateResponseType>(),
            new ApiEnumConverter<string, Directories::DirectoryListResponseType>(),
            new ApiEnumConverter<string, Directories::DirectoryGetResponseType>(),
            new ApiEnumConverter<string, Directories::Type>(),
            new ApiEnumConverter<string, Directories::DirectoryListParamsType>(),
            new ApiEnumConverter<string, Directories::TypeModel>(),
            new ApiEnumConverter<string, Split::AllowUncategorized>(),
            new ApiEnumConverter<string, Split::Status>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
