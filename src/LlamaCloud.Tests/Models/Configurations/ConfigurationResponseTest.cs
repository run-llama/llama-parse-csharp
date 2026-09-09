using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Parsing;
using Configurations = LlamaCloud.Models.Configurations;

namespace LlamaCloud.Tests.Models.Configurations;

public class ConfigurationResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Configurations::ConfigurationResponse
        {
            ID = "id",
            Name = "name",
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
            ProductType = Configurations::ConfigurationResponseProductType.ClassifyV2,
            Version = "version",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedName = "name";
        Configurations::ConfigurationResponseParameters expectedParameters =
            new Configurations::ClassifyV2Parameters()
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
        ApiEnum<string, Configurations::ConfigurationResponseProductType> expectedProductType =
            Configurations::ConfigurationResponseProductType.ClassifyV2;
        string expectedVersion = "version";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedParameters, model.Parameters);
        Assert.Equal(expectedProductType, model.ProductType);
        Assert.Equal(expectedVersion, model.Version);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Configurations::ConfigurationResponse
        {
            ID = "id",
            Name = "name",
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
            ProductType = Configurations::ConfigurationResponseProductType.ClassifyV2,
            Version = "version",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Configurations::ConfigurationResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Configurations::ConfigurationResponse
        {
            ID = "id",
            Name = "name",
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
            ProductType = Configurations::ConfigurationResponseProductType.ClassifyV2,
            Version = "version",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Configurations::ConfigurationResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";
        Configurations::ConfigurationResponseParameters expectedParameters =
            new Configurations::ClassifyV2Parameters()
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
        ApiEnum<string, Configurations::ConfigurationResponseProductType> expectedProductType =
            Configurations::ConfigurationResponseProductType.ClassifyV2;
        string expectedVersion = "version";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedParameters, deserialized.Parameters);
        Assert.Equal(expectedProductType, deserialized.ProductType);
        Assert.Equal(expectedVersion, deserialized.Version);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Configurations::ConfigurationResponse
        {
            ID = "id",
            Name = "name",
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
            ProductType = Configurations::ConfigurationResponseProductType.ClassifyV2,
            Version = "version",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Configurations::ConfigurationResponse
        {
            ID = "id",
            Name = "name",
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
            ProductType = Configurations::ConfigurationResponseProductType.ClassifyV2,
            Version = "version",
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Configurations::ConfigurationResponse
        {
            ID = "id",
            Name = "name",
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
            ProductType = Configurations::ConfigurationResponseProductType.ClassifyV2,
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Configurations::ConfigurationResponse
        {
            ID = "id",
            Name = "name",
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
            ProductType = Configurations::ConfigurationResponseProductType.ClassifyV2,
            Version = "version",

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
        var model = new Configurations::ConfigurationResponse
        {
            ID = "id",
            Name = "name",
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
            ProductType = Configurations::ConfigurationResponseProductType.ClassifyV2,
            Version = "version",

            CreatedAt = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Configurations::ConfigurationResponse
        {
            ID = "id",
            Name = "name",
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
            ProductType = Configurations::ConfigurationResponseProductType.ClassifyV2,
            Version = "version",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Configurations::ConfigurationResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConfigurationResponseParametersTest : TestBase
{
    [Fact]
    public void ClassifyV2ValidationWorks()
    {
        Configurations::ConfigurationResponseParameters value =
            new Configurations::ClassifyV2Parameters()
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
        Configurations::ConfigurationResponseParameters value =
            new Configurations::ExtractV2Parameters()
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
                ParseTier = "fast",
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
        Configurations::ConfigurationResponseParameters value =
            new Configurations::ParseV2Parameters()
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
                                Ignore = new()
                                {
                                    IgnoreDiagonalText = true,
                                    IgnoreHiddenText = true,
                                },
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
        Configurations::ConfigurationResponseParameters value =
            new Configurations::SplitV1Parameters()
            {
                Categories = [new() { Name = "x", Description = "x" }],
                SplittingStrategy = new()
                {
                    AllowUncategorized = Configurations::AllowUncategorized.Forbid,
                },
            };
        value.Validate();
    }

    [Fact]
    public void SpreadsheetV1ValidationWorks()
    {
        Configurations::ConfigurationResponseParameters value =
            new Configurations::ConfigurationResponseParametersSpreadsheetV1()
            {
                ExtractionRange = "extraction_range",
                FlattenHierarchicalTables = true,
                GenerateAdditionalMetadata = true,
                IncludeHiddenCells = true,
                SheetNames = ["string"],
                Specialization = "specialization",
                TableMergeSensitivity =
                    Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity.Strong,
                Tier = Configurations::ConfigurationResponseParametersSpreadsheetV1Tier.Agentic,
                UseExperimentalProcessing = true,
            };
        value.Validate();
    }

    [Fact]
    public void UntypedValidationWorks()
    {
        Configurations::ConfigurationResponseParameters value =
            new Configurations::UntypedParameters();
        value.Validate();
    }

    [Fact]
    public void ClassifyV2SerializationRoundtripWorks()
    {
        Configurations::ConfigurationResponseParameters value =
            new Configurations::ClassifyV2Parameters()
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
        var deserialized =
            JsonSerializer.Deserialize<Configurations::ConfigurationResponseParameters>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExtractV2SerializationRoundtripWorks()
    {
        Configurations::ConfigurationResponseParameters value =
            new Configurations::ExtractV2Parameters()
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
                ParseTier = "fast",
                SheetNames = ["Sheet 1", "Q4 Summary"],
                SpreadsheetMode = true,
                SystemPrompt =
                    "Extract all monetary values in USD. If a currency is not specified, assume USD.",
                TargetPages = "1,3,5-7",
                Tier = Configurations::ExtractV2ParametersTier.CostEffective,
                Version = "latest",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Configurations::ConfigurationResponseParameters>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ParseV2SerializationRoundtripWorks()
    {
        Configurations::ConfigurationResponseParameters value =
            new Configurations::ParseV2Parameters()
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
                                Ignore = new()
                                {
                                    IgnoreDiagonalText = true,
                                    IgnoreHiddenText = true,
                                },
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
        var deserialized =
            JsonSerializer.Deserialize<Configurations::ConfigurationResponseParameters>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SplitV1SerializationRoundtripWorks()
    {
        Configurations::ConfigurationResponseParameters value =
            new Configurations::SplitV1Parameters()
            {
                Categories = [new() { Name = "x", Description = "x" }],
                SplittingStrategy = new()
                {
                    AllowUncategorized = Configurations::AllowUncategorized.Forbid,
                },
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Configurations::ConfigurationResponseParameters>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SpreadsheetV1SerializationRoundtripWorks()
    {
        Configurations::ConfigurationResponseParameters value =
            new Configurations::ConfigurationResponseParametersSpreadsheetV1()
            {
                ExtractionRange = "extraction_range",
                FlattenHierarchicalTables = true,
                GenerateAdditionalMetadata = true,
                IncludeHiddenCells = true,
                SheetNames = ["string"],
                Specialization = "specialization",
                TableMergeSensitivity =
                    Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity.Strong,
                Tier = Configurations::ConfigurationResponseParametersSpreadsheetV1Tier.Agentic,
                UseExperimentalProcessing = true,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Configurations::ConfigurationResponseParameters>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UntypedSerializationRoundtripWorks()
    {
        Configurations::ConfigurationResponseParameters value =
            new Configurations::UntypedParameters();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Configurations::ConfigurationResponseParameters>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class ConfigurationResponseParametersSpreadsheetV1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Configurations::ConfigurationResponseParametersSpreadsheetV1
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity =
                Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = Configurations::ConfigurationResponseParametersSpreadsheetV1Tier.Agentic,
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
            Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity
        > expectedTableMergeSensitivity =
            Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity.Strong;
        ApiEnum<
            string,
            Configurations::ConfigurationResponseParametersSpreadsheetV1Tier
        > expectedTier = Configurations::ConfigurationResponseParametersSpreadsheetV1Tier.Agentic;
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
        var model = new Configurations::ConfigurationResponseParametersSpreadsheetV1
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity =
                Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = Configurations::ConfigurationResponseParametersSpreadsheetV1Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Configurations::ConfigurationResponseParametersSpreadsheetV1>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Configurations::ConfigurationResponseParametersSpreadsheetV1
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity =
                Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = Configurations::ConfigurationResponseParametersSpreadsheetV1Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Configurations::ConfigurationResponseParametersSpreadsheetV1>(
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
            Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity
        > expectedTableMergeSensitivity =
            Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity.Strong;
        ApiEnum<
            string,
            Configurations::ConfigurationResponseParametersSpreadsheetV1Tier
        > expectedTier = Configurations::ConfigurationResponseParametersSpreadsheetV1Tier.Agentic;
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
        var model = new Configurations::ConfigurationResponseParametersSpreadsheetV1
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity =
                Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = Configurations::ConfigurationResponseParametersSpreadsheetV1Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Configurations::ConfigurationResponseParametersSpreadsheetV1
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
        var model = new Configurations::ConfigurationResponseParametersSpreadsheetV1
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
        var model = new Configurations::ConfigurationResponseParametersSpreadsheetV1
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
        var model = new Configurations::ConfigurationResponseParametersSpreadsheetV1
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
        var model = new Configurations::ConfigurationResponseParametersSpreadsheetV1
        {
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            TableMergeSensitivity =
                Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = Configurations::ConfigurationResponseParametersSpreadsheetV1Tier.Agentic,
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
        var model = new Configurations::ConfigurationResponseParametersSpreadsheetV1
        {
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            TableMergeSensitivity =
                Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = Configurations::ConfigurationResponseParametersSpreadsheetV1Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Configurations::ConfigurationResponseParametersSpreadsheetV1
        {
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            TableMergeSensitivity =
                Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = Configurations::ConfigurationResponseParametersSpreadsheetV1Tier.Agentic,
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
        var model = new Configurations::ConfigurationResponseParametersSpreadsheetV1
        {
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            TableMergeSensitivity =
                Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = Configurations::ConfigurationResponseParametersSpreadsheetV1Tier.Agentic,
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
        var model = new Configurations::ConfigurationResponseParametersSpreadsheetV1
        {
            ExtractionRange = "extraction_range",
            FlattenHierarchicalTables = true,
            GenerateAdditionalMetadata = true,
            IncludeHiddenCells = true,
            SheetNames = ["string"],
            Specialization = "specialization",
            TableMergeSensitivity =
                Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity.Strong,
            Tier = Configurations::ConfigurationResponseParametersSpreadsheetV1Tier.Agentic,
            UseExperimentalProcessing = true,
        };

        Configurations::ConfigurationResponseParametersSpreadsheetV1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivityTest : TestBase
{
    [Theory]
    [InlineData(
        Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity.Strong
    )]
    [InlineData(
        Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity.Weak
    )]
    public void Validation_Works(
        Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity.Strong
    )]
    [InlineData(
        Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity.Weak
    )]
    public void SerializationRoundtrip_Works(
        Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Configurations::ConfigurationResponseParametersSpreadsheetV1TableMergeSensitivity
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConfigurationResponseParametersSpreadsheetV1TierTest : TestBase
{
    [Theory]
    [InlineData(Configurations::ConfigurationResponseParametersSpreadsheetV1Tier.Agentic)]
    [InlineData(Configurations::ConfigurationResponseParametersSpreadsheetV1Tier.CostEffective)]
    public void Validation_Works(
        Configurations::ConfigurationResponseParametersSpreadsheetV1Tier rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Configurations::ConfigurationResponseParametersSpreadsheetV1Tier> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Configurations::ConfigurationResponseParametersSpreadsheetV1Tier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Configurations::ConfigurationResponseParametersSpreadsheetV1Tier.Agentic)]
    [InlineData(Configurations::ConfigurationResponseParametersSpreadsheetV1Tier.CostEffective)]
    public void SerializationRoundtrip_Works(
        Configurations::ConfigurationResponseParametersSpreadsheetV1Tier rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Configurations::ConfigurationResponseParametersSpreadsheetV1Tier> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Configurations::ConfigurationResponseParametersSpreadsheetV1Tier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Configurations::ConfigurationResponseParametersSpreadsheetV1Tier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Configurations::ConfigurationResponseParametersSpreadsheetV1Tier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ConfigurationResponseProductTypeTest : TestBase
{
    [Theory]
    [InlineData(Configurations::ConfigurationResponseProductType.ClassifyV2)]
    [InlineData(Configurations::ConfigurationResponseProductType.ExtractV2)]
    [InlineData(Configurations::ConfigurationResponseProductType.ParseV2)]
    [InlineData(Configurations::ConfigurationResponseProductType.SplitV1)]
    [InlineData(Configurations::ConfigurationResponseProductType.SpreadsheetV1)]
    [InlineData(Configurations::ConfigurationResponseProductType.Unknown)]
    public void Validation_Works(Configurations::ConfigurationResponseProductType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Configurations::ConfigurationResponseProductType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Configurations::ConfigurationResponseProductType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Configurations::ConfigurationResponseProductType.ClassifyV2)]
    [InlineData(Configurations::ConfigurationResponseProductType.ExtractV2)]
    [InlineData(Configurations::ConfigurationResponseProductType.ParseV2)]
    [InlineData(Configurations::ConfigurationResponseProductType.SplitV1)]
    [InlineData(Configurations::ConfigurationResponseProductType.SpreadsheetV1)]
    [InlineData(Configurations::ConfigurationResponseProductType.Unknown)]
    public void SerializationRoundtrip_Works(
        Configurations::ConfigurationResponseProductType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Configurations::ConfigurationResponseProductType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Configurations::ConfigurationResponseProductType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Configurations::ConfigurationResponseProductType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Configurations::ConfigurationResponseProductType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
