using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using Parsing = LlamaIndex.LlamaCloud.Models.Parsing;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Pipelines;

[JsonConverter(typeof(JsonModelConverter<LlamaParseParameters, LlamaParseParametersFromRaw>))]
public sealed record class LlamaParseParameters : JsonModel
{
    public bool? AdaptiveLongTable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("adaptive_long_table");
        }
        init { this._rawData.Set("adaptive_long_table", value); }
    }

    public bool? AggressiveTableExtraction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("aggressive_table_extraction");
        }
        init { this._rawData.Set("aggressive_table_extraction", value); }
    }

    public bool? AnnotateLinks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("annotate_links");
        }
        init { this._rawData.Set("annotate_links", value); }
    }

    public bool? AnnotateRevisions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("annotate_revisions");
        }
        init { this._rawData.Set("annotate_revisions", value); }
    }

    public bool? AutoMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("auto_mode");
        }
        init { this._rawData.Set("auto_mode", value); }
    }

    public string? AutoModeConfigurationJson
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("auto_mode_configuration_json");
        }
        init { this._rawData.Set("auto_mode_configuration_json", value); }
    }

    public bool? AutoModeTriggerOnImageInPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("auto_mode_trigger_on_image_in_page");
        }
        init { this._rawData.Set("auto_mode_trigger_on_image_in_page", value); }
    }

    public string? AutoModeTriggerOnRegexpInPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("auto_mode_trigger_on_regexp_in_page");
        }
        init { this._rawData.Set("auto_mode_trigger_on_regexp_in_page", value); }
    }

    public bool? AutoModeTriggerOnTableInPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("auto_mode_trigger_on_table_in_page");
        }
        init { this._rawData.Set("auto_mode_trigger_on_table_in_page", value); }
    }

    public string? AutoModeTriggerOnTextInPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("auto_mode_trigger_on_text_in_page");
        }
        init { this._rawData.Set("auto_mode_trigger_on_text_in_page", value); }
    }

    public string? AzureOpenAIApiVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("azure_openai_api_version");
        }
        init { this._rawData.Set("azure_openai_api_version", value); }
    }

    public string? AzureOpenAIDeploymentName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("azure_openai_deployment_name");
        }
        init { this._rawData.Set("azure_openai_deployment_name", value); }
    }

    public string? AzureOpenAIEndpoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("azure_openai_endpoint");
        }
        init { this._rawData.Set("azure_openai_endpoint", value); }
    }

    public string? AzureOpenAIKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("azure_openai_key");
        }
        init { this._rawData.Set("azure_openai_key", value); }
    }

    public double? BboxBottom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("bbox_bottom");
        }
        init { this._rawData.Set("bbox_bottom", value); }
    }

    public double? BboxLeft
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("bbox_left");
        }
        init { this._rawData.Set("bbox_left", value); }
    }

    public double? BboxRight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("bbox_right");
        }
        init { this._rawData.Set("bbox_right", value); }
    }

    public double? BboxTop
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("bbox_top");
        }
        init { this._rawData.Set("bbox_top", value); }
    }

    public string? BoundingBox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bounding_box");
        }
        init { this._rawData.Set("bounding_box", value); }
    }

    public bool? CompactMarkdownTable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("compact_markdown_table");
        }
        init { this._rawData.Set("compact_markdown_table", value); }
    }

    public string? ComplementalFormattingInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("complemental_formatting_instruction");
        }
        init { this._rawData.Set("complemental_formatting_instruction", value); }
    }

    public string? ConfidenceScoreEffort
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("confidence_score_effort");
        }
        init { this._rawData.Set("confidence_score_effort", value); }
    }

    public string? ContentGuidelineInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content_guideline_instruction");
        }
        init { this._rawData.Set("content_guideline_instruction", value); }
    }

    public bool? ContinuousMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("continuous_mode");
        }
        init { this._rawData.Set("continuous_mode", value); }
    }

    public bool? DisableImageExtraction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("disable_image_extraction");
        }
        init { this._rawData.Set("disable_image_extraction", value); }
    }

    public bool? DisableOcr
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("disable_ocr");
        }
        init { this._rawData.Set("disable_ocr", value); }
    }

    public bool? DisableReconstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("disable_reconstruction");
        }
        init { this._rawData.Set("disable_reconstruction", value); }
    }

    public bool? DoNotCache
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("do_not_cache");
        }
        init { this._rawData.Set("do_not_cache", value); }
    }

    public bool? DoNotUnrollColumns
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("do_not_unroll_columns");
        }
        init { this._rawData.Set("do_not_unroll_columns", value); }
    }

    public bool? EnableCostOptimizer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enable_cost_optimizer");
        }
        init { this._rawData.Set("enable_cost_optimizer", value); }
    }

    public bool? ExtractCharts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("extract_charts");
        }
        init { this._rawData.Set("extract_charts", value); }
    }

    public bool? ExtractLayout
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("extract_layout");
        }
        init { this._rawData.Set("extract_layout", value); }
    }

    public bool? ExtractPrintedPageNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("extract_printed_page_number");
        }
        init { this._rawData.Set("extract_printed_page_number", value); }
    }

    public bool? FastMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("fast_mode");
        }
        init { this._rawData.Set("fast_mode", value); }
    }

    public string? FormattingInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("formatting_instruction");
        }
        init { this._rawData.Set("formatting_instruction", value); }
    }

    public string? Gpt4oApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("gpt4o_api_key");
        }
        init { this._rawData.Set("gpt4o_api_key", value); }
    }

    public bool? Gpt4oMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("gpt4o_mode");
        }
        init { this._rawData.Set("gpt4o_mode", value); }
    }

    public bool? GuessXlsxSheetName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("guess_xlsx_sheet_name");
        }
        init { this._rawData.Set("guess_xlsx_sheet_name", value); }
    }

    public bool? HideFooters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hide_footers");
        }
        init { this._rawData.Set("hide_footers", value); }
    }

    public bool? HideHeaders
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hide_headers");
        }
        init { this._rawData.Set("hide_headers", value); }
    }

    public bool? HighResOcr
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("high_res_ocr");
        }
        init { this._rawData.Set("high_res_ocr", value); }
    }

    public bool? HtmlMakeAllElementsVisible
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("html_make_all_elements_visible");
        }
        init { this._rawData.Set("html_make_all_elements_visible", value); }
    }

    public bool? HtmlRemoveFixedElements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("html_remove_fixed_elements");
        }
        init { this._rawData.Set("html_remove_fixed_elements", value); }
    }

    public bool? HtmlRemoveNavigationElements
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("html_remove_navigation_elements");
        }
        init { this._rawData.Set("html_remove_navigation_elements", value); }
    }

    public string? HttpProxy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("http_proxy");
        }
        init { this._rawData.Set("http_proxy", value); }
    }

    public bool? IgnoreDocumentElementsForLayoutDetection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "ignore_document_elements_for_layout_detection"
            );
        }
        init { this._rawData.Set("ignore_document_elements_for_layout_detection", value); }
    }

    public IReadOnlyList<ApiEnum<string, ImagesToSave>>? ImagesToSave
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, ImagesToSave>>>(
                "images_to_save"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, ImagesToSave>>?>(
                "images_to_save",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? InlineImagesInMarkdown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("inline_images_in_markdown");
        }
        init { this._rawData.Set("inline_images_in_markdown", value); }
    }

    public string? InputS3Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("input_s3_path");
        }
        init { this._rawData.Set("input_s3_path", value); }
    }

    public string? InputS3Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("input_s3_region");
        }
        init { this._rawData.Set("input_s3_region", value); }
    }

    public string? InputUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("input_url");
        }
        init { this._rawData.Set("input_url", value); }
    }

    public bool? InternalIsScreenshotJob
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("internal_is_screenshot_job");
        }
        init { this._rawData.Set("internal_is_screenshot_job", value); }
    }

    public bool? InvalidateCache
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("invalidate_cache");
        }
        init { this._rawData.Set("invalidate_cache", value); }
    }

    public bool? IsFormattingInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_formatting_instruction");
        }
        init { this._rawData.Set("is_formatting_instruction", value); }
    }

    public double? JobTimeoutExtraTimePerPageInSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "job_timeout_extra_time_per_page_in_seconds"
            );
        }
        init { this._rawData.Set("job_timeout_extra_time_per_page_in_seconds", value); }
    }

    public double? JobTimeoutInSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("job_timeout_in_seconds");
        }
        init { this._rawData.Set("job_timeout_in_seconds", value); }
    }

    public bool? KeepPageSeparatorWhenMergingTables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("keep_page_separator_when_merging_tables");
        }
        init { this._rawData.Set("keep_page_separator_when_merging_tables", value); }
    }

    public IReadOnlyList<ApiEnum<string, Parsing::ParsingLanguages>>? Languages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, Parsing::ParsingLanguages>>
            >("languages");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, Parsing::ParsingLanguages>>?>(
                "languages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? LayoutAware
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("layout_aware");
        }
        init { this._rawData.Set("layout_aware", value); }
    }

    public bool? LineLevelBoundingBox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("line_level_bounding_box");
        }
        init { this._rawData.Set("line_level_bounding_box", value); }
    }

    public string? MarkdownTableMultilineHeaderSeparator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "markdown_table_multiline_header_separator"
            );
        }
        init { this._rawData.Set("markdown_table_multiline_header_separator", value); }
    }

    public long? MaxPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_pages");
        }
        init { this._rawData.Set("max_pages", value); }
    }

    public long? MaxPagesEnforced
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("max_pages_enforced");
        }
        init { this._rawData.Set("max_pages_enforced", value); }
    }

    public bool? MergeTablesAcrossPagesInMarkdown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("merge_tables_across_pages_in_markdown");
        }
        init { this._rawData.Set("merge_tables_across_pages_in_markdown", value); }
    }

    public string? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    public bool? OutlinedTableExtraction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("outlined_table_extraction");
        }
        init { this._rawData.Set("outlined_table_extraction", value); }
    }

    public bool? OutputPdfOfDocument
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("output_pdf_of_document");
        }
        init { this._rawData.Set("output_pdf_of_document", value); }
    }

    public string? OutputS3PathPrefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("output_s3_path_prefix");
        }
        init { this._rawData.Set("output_s3_path_prefix", value); }
    }

    public string? OutputS3Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("output_s3_region");
        }
        init { this._rawData.Set("output_s3_region", value); }
    }

    public bool? OutputTablesAsHtml
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("output_tables_as_HTML");
        }
        init { this._rawData.Set("output_tables_as_HTML", value); }
    }

    public double? PageErrorTolerance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("page_error_tolerance");
        }
        init { this._rawData.Set("page_error_tolerance", value); }
    }

    public string? PageFooterPrefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("page_footer_prefix");
        }
        init { this._rawData.Set("page_footer_prefix", value); }
    }

    public string? PageFooterSuffix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("page_footer_suffix");
        }
        init { this._rawData.Set("page_footer_suffix", value); }
    }

    public string? PageHeaderPrefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("page_header_prefix");
        }
        init { this._rawData.Set("page_header_prefix", value); }
    }

    public string? PageHeaderSuffix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("page_header_suffix");
        }
        init { this._rawData.Set("page_header_suffix", value); }
    }

    public string? PagePrefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("page_prefix");
        }
        init { this._rawData.Set("page_prefix", value); }
    }

    public string? PageSeparator
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("page_separator");
        }
        init { this._rawData.Set("page_separator", value); }
    }

    public string? PageSuffix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("page_suffix");
        }
        init { this._rawData.Set("page_suffix", value); }
    }

    /// <summary>
    /// Enum for representing the mode of parsing to be used.
    /// </summary>
    public ApiEnum<string, Parsing::ParsingMode>? ParseMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Parsing::ParsingMode>>(
                "parse_mode"
            );
        }
        init { this._rawData.Set("parse_mode", value); }
    }

    public string? ParsingInstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("parsing_instruction");
        }
        init { this._rawData.Set("parsing_instruction", value); }
    }

    public bool? PreciseBoundingBox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("precise_bounding_box");
        }
        init { this._rawData.Set("precise_bounding_box", value); }
    }

    public bool? PremiumMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("premium_mode");
        }
        init { this._rawData.Set("premium_mode", value); }
    }

    public bool? PresentationOutOfBoundsContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("presentation_out_of_bounds_content");
        }
        init { this._rawData.Set("presentation_out_of_bounds_content", value); }
    }

    public bool? PresentationSkipEmbeddedData
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("presentation_skip_embedded_data");
        }
        init { this._rawData.Set("presentation_skip_embedded_data", value); }
    }

    public bool? PreserveLayoutAlignmentAcrossPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("preserve_layout_alignment_across_pages");
        }
        init { this._rawData.Set("preserve_layout_alignment_across_pages", value); }
    }

    public bool? PreserveVerySmallText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("preserve_very_small_text");
        }
        init { this._rawData.Set("preserve_very_small_text", value); }
    }

    public string? Preset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("preset");
        }
        init { this._rawData.Set("preset", value); }
    }

    /// <summary>
    /// The priority for the request. This field may be ignored or overwritten depending
    /// on the organization tier.
    /// </summary>
    public ApiEnum<string, Priority>? Priority
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Priority>>("priority");
        }
        init { this._rawData.Set("priority", value); }
    }

    public string? ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("project_id");
        }
        init { this._rawData.Set("project_id", value); }
    }

    public bool? RemoveHiddenText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("remove_hidden_text");
        }
        init { this._rawData.Set("remove_hidden_text", value); }
    }

    /// <summary>
    /// Enum for representing the different available page error handling modes.
    /// </summary>
    public ApiEnum<string, Parsing::FailPageMode>? ReplaceFailedPageMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Parsing::FailPageMode>>(
                "replace_failed_page_mode"
            );
        }
        init { this._rawData.Set("replace_failed_page_mode", value); }
    }

    public string? ReplaceFailedPageWithErrorMessagePrefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "replace_failed_page_with_error_message_prefix"
            );
        }
        init { this._rawData.Set("replace_failed_page_with_error_message_prefix", value); }
    }

    public string? ReplaceFailedPageWithErrorMessageSuffix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "replace_failed_page_with_error_message_suffix"
            );
        }
        init { this._rawData.Set("replace_failed_page_with_error_message_suffix", value); }
    }

    public bool? SaveImages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("save_images");
        }
        init { this._rawData.Set("save_images", value); }
    }

    public bool? SkipDiagonalText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("skip_diagonal_text");
        }
        init { this._rawData.Set("skip_diagonal_text", value); }
    }

    public bool? SpecializedChartParsingAgentic
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("specialized_chart_parsing_agentic");
        }
        init { this._rawData.Set("specialized_chart_parsing_agentic", value); }
    }

    public bool? SpecializedChartParsingEfficient
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("specialized_chart_parsing_efficient");
        }
        init { this._rawData.Set("specialized_chart_parsing_efficient", value); }
    }

    public bool? SpecializedChartParsingPlus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("specialized_chart_parsing_plus");
        }
        init { this._rawData.Set("specialized_chart_parsing_plus", value); }
    }

    public bool? SpecializedImageParsing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("specialized_image_parsing");
        }
        init { this._rawData.Set("specialized_image_parsing", value); }
    }

    public bool? SpreadsheetExtractSubTables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("spreadsheet_extract_sub_tables");
        }
        init { this._rawData.Set("spreadsheet_extract_sub_tables", value); }
    }

    public bool? SpreadsheetForceFormulaComputation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("spreadsheet_force_formula_computation");
        }
        init { this._rawData.Set("spreadsheet_force_formula_computation", value); }
    }

    public bool? SpreadsheetIncludeHiddenSheets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("spreadsheet_include_hidden_sheets");
        }
        init { this._rawData.Set("spreadsheet_include_hidden_sheets", value); }
    }

    public bool? StrictModeBuggyFont
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("strict_mode_buggy_font");
        }
        init { this._rawData.Set("strict_mode_buggy_font", value); }
    }

    public bool? StrictModeImageExtraction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("strict_mode_image_extraction");
        }
        init { this._rawData.Set("strict_mode_image_extraction", value); }
    }

    public bool? StrictModeImageOcr
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("strict_mode_image_ocr");
        }
        init { this._rawData.Set("strict_mode_image_ocr", value); }
    }

    public bool? StrictModeReconstruction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("strict_mode_reconstruction");
        }
        init { this._rawData.Set("strict_mode_reconstruction", value); }
    }

    public bool? StructuredOutput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("structured_output");
        }
        init { this._rawData.Set("structured_output", value); }
    }

    public string? StructuredOutputJsonSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("structured_output_json_schema");
        }
        init { this._rawData.Set("structured_output_json_schema", value); }
    }

    public string? StructuredOutputJsonSchemaName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("structured_output_json_schema_name");
        }
        init { this._rawData.Set("structured_output_json_schema_name", value); }
    }

    public string? SystemPrompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("system_prompt");
        }
        init { this._rawData.Set("system_prompt", value); }
    }

    public string? SystemPromptAppend
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("system_prompt_append");
        }
        init { this._rawData.Set("system_prompt_append", value); }
    }

    public bool? TakeScreenshot
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("take_screenshot");
        }
        init { this._rawData.Set("take_screenshot", value); }
    }

    public string? TargetPages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("target_pages");
        }
        init { this._rawData.Set("target_pages", value); }
    }

    public string? Tier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tier");
        }
        init { this._rawData.Set("tier", value); }
    }

    public bool? UseVendorMultimodalModel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("use_vendor_multimodal_model");
        }
        init { this._rawData.Set("use_vendor_multimodal_model", value); }
    }

    public string? UserPrompt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_prompt");
        }
        init { this._rawData.Set("user_prompt", value); }
    }

    public string? VendorMultimodalApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("vendor_multimodal_api_key");
        }
        init { this._rawData.Set("vendor_multimodal_api_key", value); }
    }

    public string? VendorMultimodalModelName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("vendor_multimodal_model_name");
        }
        init { this._rawData.Set("vendor_multimodal_model_name", value); }
    }

    public string? Version
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("version");
        }
        init { this._rawData.Set("version", value); }
    }

    /// <summary>
    /// Outbound webhook endpoints to notify on job status changes
    /// </summary>
    public IReadOnlyList<WebhookConfiguration>? WebhookConfigurations
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WebhookConfiguration>>(
                "webhook_configurations"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<WebhookConfiguration>?>(
                "webhook_configurations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? WebhookUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("webhook_url");
        }
        init { this._rawData.Set("webhook_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AdaptiveLongTable;
        _ = this.AggressiveTableExtraction;
        _ = this.AnnotateLinks;
        _ = this.AnnotateRevisions;
        _ = this.AutoMode;
        _ = this.AutoModeConfigurationJson;
        _ = this.AutoModeTriggerOnImageInPage;
        _ = this.AutoModeTriggerOnRegexpInPage;
        _ = this.AutoModeTriggerOnTableInPage;
        _ = this.AutoModeTriggerOnTextInPage;
        _ = this.AzureOpenAIApiVersion;
        _ = this.AzureOpenAIDeploymentName;
        _ = this.AzureOpenAIEndpoint;
        _ = this.AzureOpenAIKey;
        _ = this.BboxBottom;
        _ = this.BboxLeft;
        _ = this.BboxRight;
        _ = this.BboxTop;
        _ = this.BoundingBox;
        _ = this.CompactMarkdownTable;
        _ = this.ComplementalFormattingInstruction;
        _ = this.ConfidenceScoreEffort;
        _ = this.ContentGuidelineInstruction;
        _ = this.ContinuousMode;
        _ = this.DisableImageExtraction;
        _ = this.DisableOcr;
        _ = this.DisableReconstruction;
        _ = this.DoNotCache;
        _ = this.DoNotUnrollColumns;
        _ = this.EnableCostOptimizer;
        _ = this.ExtractCharts;
        _ = this.ExtractLayout;
        _ = this.ExtractPrintedPageNumber;
        _ = this.FastMode;
        _ = this.FormattingInstruction;
        _ = this.Gpt4oApiKey;
        _ = this.Gpt4oMode;
        _ = this.GuessXlsxSheetName;
        _ = this.HideFooters;
        _ = this.HideHeaders;
        _ = this.HighResOcr;
        _ = this.HtmlMakeAllElementsVisible;
        _ = this.HtmlRemoveFixedElements;
        _ = this.HtmlRemoveNavigationElements;
        _ = this.HttpProxy;
        _ = this.IgnoreDocumentElementsForLayoutDetection;
        foreach (var item in this.ImagesToSave ?? [])
        {
            item.Validate();
        }
        _ = this.InlineImagesInMarkdown;
        _ = this.InputS3Path;
        _ = this.InputS3Region;
        _ = this.InputUrl;
        _ = this.InternalIsScreenshotJob;
        _ = this.InvalidateCache;
        _ = this.IsFormattingInstruction;
        _ = this.JobTimeoutExtraTimePerPageInSeconds;
        _ = this.JobTimeoutInSeconds;
        _ = this.KeepPageSeparatorWhenMergingTables;
        foreach (var item in this.Languages ?? [])
        {
            item.Validate();
        }
        _ = this.LayoutAware;
        _ = this.LineLevelBoundingBox;
        _ = this.MarkdownTableMultilineHeaderSeparator;
        _ = this.MaxPages;
        _ = this.MaxPagesEnforced;
        _ = this.MergeTablesAcrossPagesInMarkdown;
        _ = this.Model;
        _ = this.OutlinedTableExtraction;
        _ = this.OutputPdfOfDocument;
        _ = this.OutputS3PathPrefix;
        _ = this.OutputS3Region;
        _ = this.OutputTablesAsHtml;
        _ = this.PageErrorTolerance;
        _ = this.PageFooterPrefix;
        _ = this.PageFooterSuffix;
        _ = this.PageHeaderPrefix;
        _ = this.PageHeaderSuffix;
        _ = this.PagePrefix;
        _ = this.PageSeparator;
        _ = this.PageSuffix;
        this.ParseMode?.Validate();
        _ = this.ParsingInstruction;
        _ = this.PreciseBoundingBox;
        _ = this.PremiumMode;
        _ = this.PresentationOutOfBoundsContent;
        _ = this.PresentationSkipEmbeddedData;
        _ = this.PreserveLayoutAlignmentAcrossPages;
        _ = this.PreserveVerySmallText;
        _ = this.Preset;
        this.Priority?.Validate();
        _ = this.ProjectID;
        _ = this.RemoveHiddenText;
        this.ReplaceFailedPageMode?.Validate();
        _ = this.ReplaceFailedPageWithErrorMessagePrefix;
        _ = this.ReplaceFailedPageWithErrorMessageSuffix;
        _ = this.SaveImages;
        _ = this.SkipDiagonalText;
        _ = this.SpecializedChartParsingAgentic;
        _ = this.SpecializedChartParsingEfficient;
        _ = this.SpecializedChartParsingPlus;
        _ = this.SpecializedImageParsing;
        _ = this.SpreadsheetExtractSubTables;
        _ = this.SpreadsheetForceFormulaComputation;
        _ = this.SpreadsheetIncludeHiddenSheets;
        _ = this.StrictModeBuggyFont;
        _ = this.StrictModeImageExtraction;
        _ = this.StrictModeImageOcr;
        _ = this.StrictModeReconstruction;
        _ = this.StructuredOutput;
        _ = this.StructuredOutputJsonSchema;
        _ = this.StructuredOutputJsonSchemaName;
        _ = this.SystemPrompt;
        _ = this.SystemPromptAppend;
        _ = this.TakeScreenshot;
        _ = this.TargetPages;
        _ = this.Tier;
        _ = this.UseVendorMultimodalModel;
        _ = this.UserPrompt;
        _ = this.VendorMultimodalApiKey;
        _ = this.VendorMultimodalModelName;
        _ = this.Version;
        foreach (var item in this.WebhookConfigurations ?? [])
        {
            item.Validate();
        }
        _ = this.WebhookUrl;
    }

    public LlamaParseParameters() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LlamaParseParameters(LlamaParseParameters llamaParseParameters)
        : base(llamaParseParameters) { }
#pragma warning restore CS8618

    public LlamaParseParameters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LlamaParseParameters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LlamaParseParametersFromRaw.FromRawUnchecked"/>
    public static LlamaParseParameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LlamaParseParametersFromRaw : IFromRawJson<LlamaParseParameters>
{
    /// <inheritdoc/>
    public LlamaParseParameters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => LlamaParseParameters.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ImagesToSaveConverter))]
public enum ImagesToSave
{
    Embedded,
    Layout,
    Screenshot,
}

sealed class ImagesToSaveConverter : JsonConverter<ImagesToSave>
{
    public override ImagesToSave Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "embedded" => ImagesToSave.Embedded,
            "layout" => ImagesToSave.Layout,
            "screenshot" => ImagesToSave.Screenshot,
            _ => (ImagesToSave)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ImagesToSave value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ImagesToSave.Embedded => "embedded",
                ImagesToSave.Layout => "layout",
                ImagesToSave.Screenshot => "screenshot",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The priority for the request. This field may be ignored or overwritten depending
/// on the organization tier.
/// </summary>
[JsonConverter(typeof(PriorityConverter))]
public enum Priority
{
    Critical,
    High,
    Low,
    Medium,
}

sealed class PriorityConverter : JsonConverter<Priority>
{
    public override Priority Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "critical" => Priority.Critical,
            "high" => Priority.High,
            "low" => Priority.Low,
            "medium" => Priority.Medium,
            _ => (Priority)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Priority value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Priority.Critical => "critical",
                Priority.High => "high",
                Priority.Low => "low",
                Priority.Medium => "medium",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration for a single outbound webhook endpoint.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebhookConfiguration, WebhookConfigurationFromRaw>))]
public sealed record class WebhookConfiguration : JsonModel
{
    /// <summary>
    /// Events to subscribe to (e.g. 'parse.success', 'extract.error'). If null, all
    /// events are delivered.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, WebhookEvent>>? WebhookEvents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, WebhookEvent>>>(
                "webhook_events"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, WebhookEvent>>?>(
                "webhook_events",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Custom HTTP headers sent with each webhook request (e.g. auth tokens)
    /// </summary>
    public IReadOnlyDictionary<string, string>? WebhookHeaders
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "webhook_headers"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "webhook_headers",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Response format sent to the webhook: 'string' (default) or 'json'
    /// </summary>
    public string? WebhookOutputFormat
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("webhook_output_format");
        }
        init { this._rawData.Set("webhook_output_format", value); }
    }

    /// <summary>
    /// Shared signing secret used to sign webhook deliveries. When set, each request
    /// includes an HMAC-SHA256 signature of the request body in the 'LC-Signature'
    /// header (value 'sha256=&lt;hex&gt;'). Recompute the HMAC over the raw request
    /// body with this secret to verify the delivery is authentic.
    /// </summary>
    public string? WebhookSigningSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("webhook_signing_secret");
        }
        init { this._rawData.Set("webhook_signing_secret", value); }
    }

    /// <summary>
    /// URL to receive webhook POST notifications
    /// </summary>
    public string? WebhookUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("webhook_url");
        }
        init { this._rawData.Set("webhook_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.WebhookEvents ?? [])
        {
            item.Validate();
        }
        _ = this.WebhookHeaders;
        _ = this.WebhookOutputFormat;
        _ = this.WebhookSigningSecret;
        _ = this.WebhookUrl;
    }

    public WebhookConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebhookConfiguration(WebhookConfiguration webhookConfiguration)
        : base(webhookConfiguration) { }
#pragma warning restore CS8618

    public WebhookConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebhookConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebhookConfigurationFromRaw.FromRawUnchecked"/>
    public static WebhookConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebhookConfigurationFromRaw : IFromRawJson<WebhookConfiguration>
{
    /// <inheritdoc/>
    public WebhookConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebhookConfiguration.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(WebhookEventConverter))]
public enum WebhookEvent
{
    BatchCancelled,
    BatchError,
    BatchPending,
    BatchRunning,
    BatchSuccess,
    ClassifyCancelled,
    ClassifyError,
    ClassifyPartialSuccess,
    ClassifyPending,
    ClassifyRunning,
    ClassifySuccess,
    ExtractCancelled,
    ExtractError,
    ExtractPartialSuccess,
    ExtractPending,
    ExtractSuccess,
    ParseCancelled,
    ParseError,
    ParsePartialSuccess,
    ParsePending,
    ParseRunning,
    ParseSuccess,
    SheetsCancelled,
    SheetsError,
    SheetsPartialSuccess,
    SheetsPending,
    SheetsSuccess,
    SplitCancelled,
    SplitError,
    SplitPending,
    SplitProcessing,
    SplitSuccess,
    UnmappedEvent,
}

sealed class WebhookEventConverter : JsonConverter<WebhookEvent>
{
    public override WebhookEvent Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "batch.cancelled" => WebhookEvent.BatchCancelled,
            "batch.error" => WebhookEvent.BatchError,
            "batch.pending" => WebhookEvent.BatchPending,
            "batch.running" => WebhookEvent.BatchRunning,
            "batch.success" => WebhookEvent.BatchSuccess,
            "classify.cancelled" => WebhookEvent.ClassifyCancelled,
            "classify.error" => WebhookEvent.ClassifyError,
            "classify.partial_success" => WebhookEvent.ClassifyPartialSuccess,
            "classify.pending" => WebhookEvent.ClassifyPending,
            "classify.running" => WebhookEvent.ClassifyRunning,
            "classify.success" => WebhookEvent.ClassifySuccess,
            "extract.cancelled" => WebhookEvent.ExtractCancelled,
            "extract.error" => WebhookEvent.ExtractError,
            "extract.partial_success" => WebhookEvent.ExtractPartialSuccess,
            "extract.pending" => WebhookEvent.ExtractPending,
            "extract.success" => WebhookEvent.ExtractSuccess,
            "parse.cancelled" => WebhookEvent.ParseCancelled,
            "parse.error" => WebhookEvent.ParseError,
            "parse.partial_success" => WebhookEvent.ParsePartialSuccess,
            "parse.pending" => WebhookEvent.ParsePending,
            "parse.running" => WebhookEvent.ParseRunning,
            "parse.success" => WebhookEvent.ParseSuccess,
            "sheets.cancelled" => WebhookEvent.SheetsCancelled,
            "sheets.error" => WebhookEvent.SheetsError,
            "sheets.partial_success" => WebhookEvent.SheetsPartialSuccess,
            "sheets.pending" => WebhookEvent.SheetsPending,
            "sheets.success" => WebhookEvent.SheetsSuccess,
            "split.cancelled" => WebhookEvent.SplitCancelled,
            "split.error" => WebhookEvent.SplitError,
            "split.pending" => WebhookEvent.SplitPending,
            "split.processing" => WebhookEvent.SplitProcessing,
            "split.success" => WebhookEvent.SplitSuccess,
            "unmapped_event" => WebhookEvent.UnmappedEvent,
            _ => (WebhookEvent)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookEvent.BatchCancelled => "batch.cancelled",
                WebhookEvent.BatchError => "batch.error",
                WebhookEvent.BatchPending => "batch.pending",
                WebhookEvent.BatchRunning => "batch.running",
                WebhookEvent.BatchSuccess => "batch.success",
                WebhookEvent.ClassifyCancelled => "classify.cancelled",
                WebhookEvent.ClassifyError => "classify.error",
                WebhookEvent.ClassifyPartialSuccess => "classify.partial_success",
                WebhookEvent.ClassifyPending => "classify.pending",
                WebhookEvent.ClassifyRunning => "classify.running",
                WebhookEvent.ClassifySuccess => "classify.success",
                WebhookEvent.ExtractCancelled => "extract.cancelled",
                WebhookEvent.ExtractError => "extract.error",
                WebhookEvent.ExtractPartialSuccess => "extract.partial_success",
                WebhookEvent.ExtractPending => "extract.pending",
                WebhookEvent.ExtractSuccess => "extract.success",
                WebhookEvent.ParseCancelled => "parse.cancelled",
                WebhookEvent.ParseError => "parse.error",
                WebhookEvent.ParsePartialSuccess => "parse.partial_success",
                WebhookEvent.ParsePending => "parse.pending",
                WebhookEvent.ParseRunning => "parse.running",
                WebhookEvent.ParseSuccess => "parse.success",
                WebhookEvent.SheetsCancelled => "sheets.cancelled",
                WebhookEvent.SheetsError => "sheets.error",
                WebhookEvent.SheetsPartialSuccess => "sheets.partial_success",
                WebhookEvent.SheetsPending => "sheets.pending",
                WebhookEvent.SheetsSuccess => "sheets.success",
                WebhookEvent.SplitCancelled => "split.cancelled",
                WebhookEvent.SplitError => "split.error",
                WebhookEvent.SplitPending => "split.pending",
                WebhookEvent.SplitProcessing => "split.processing",
                WebhookEvent.SplitSuccess => "split.success",
                WebhookEvent.UnmappedEvent => "unmapped_event",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
