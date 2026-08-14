using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.Sheets;
using LlamaIndex.LlamaCloud.Models.Files;

namespace LlamaIndex.LlamaCloud.Tests.Models.Beta.Sheets;

public class SheetListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SheetListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    CreatedAt = "created_at",
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Status = SheetsJobStatus.Cancelled,
                    UpdatedAt = "updated_at",
                    UserID = "user_id",
                    Config = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    ConfigurationID = "configuration_id",
                    Errors = ["string"],
                    File = new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Name = "x",
                        ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalFileID = "external_file_id",
                        FileSize = 0,
                        FileType = "x",
                        LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PermissionInfo = new Dictionary<string, PermissionInfo?>()
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
                        Purpose = "purpose",
                        ResourceInfo = new Dictionary<string, ResourceInfo?>()
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
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    MetadataStateTransitions = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Parameters = new()
                    {
                        WebhookConfigurations =
                        [
                            new()
                            {
                                WebhookEvents =
                                [
                                    ParametersWebhookConfigurationWebhookEvent.ParseSuccess,
                                    ParametersWebhookConfigurationWebhookEvent.ParseError,
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
                    },
                    Regions =
                    [
                        new()
                        {
                            Location = "location",
                            RegionType = "region_type",
                            SheetName = "sheet_name",
                            Description = "description",
                            RegionID = "region_id",
                            Title = "title",
                        },
                    ],
                    Success = true,
                    WorksheetMetadata =
                    [
                        new()
                        {
                            SheetName = "sheet_name",
                            Description = "description",
                            Title = "title",
                        },
                    ],
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        List<SheetsJob> expectedItems =
        [
            new()
            {
                ID = "id",
                Configuration = new()
                {
                    ExtractionRange = "extraction_range",
                    FlattenHierarchicalTables = true,
                    GenerateAdditionalMetadata = true,
                    IncludeHiddenCells = true,
                    SheetNames = ["string"],
                    Specialization = "specialization",
                    TableMergeSensitivity = TableMergeSensitivity.Strong,
                    Tier = Tier.Agentic,
                    UseExperimentalProcessing = true,
                },
                CreatedAt = "created_at",
                FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Status = SheetsJobStatus.Cancelled,
                UpdatedAt = "updated_at",
                UserID = "user_id",
                Config = new()
                {
                    ExtractionRange = "extraction_range",
                    FlattenHierarchicalTables = true,
                    GenerateAdditionalMetadata = true,
                    IncludeHiddenCells = true,
                    SheetNames = ["string"],
                    Specialization = "specialization",
                    TableMergeSensitivity = TableMergeSensitivity.Strong,
                    Tier = Tier.Agentic,
                    UseExperimentalProcessing = true,
                },
                ConfigurationID = "configuration_id",
                Errors = ["string"],
                File = new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Name = "x",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalFileID = "external_file_id",
                    FileSize = 0,
                    FileType = "x",
                    LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PermissionInfo = new Dictionary<string, PermissionInfo?>()
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
                    Purpose = "purpose",
                    ResourceInfo = new Dictionary<string, ResourceInfo?>()
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
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                MetadataStateTransitions = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Parameters = new()
                {
                    WebhookConfigurations =
                    [
                        new()
                        {
                            WebhookEvents =
                            [
                                ParametersWebhookConfigurationWebhookEvent.ParseSuccess,
                                ParametersWebhookConfigurationWebhookEvent.ParseError,
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
                },
                Regions =
                [
                    new()
                    {
                        Location = "location",
                        RegionType = "region_type",
                        SheetName = "sheet_name",
                        Description = "description",
                        RegionID = "region_id",
                        Title = "title",
                    },
                ],
                Success = true,
                WorksheetMetadata =
                [
                    new()
                    {
                        SheetName = "sheet_name",
                        Description = "description",
                        Title = "title",
                    },
                ],
            },
        ];
        string expectedNextPageToken = "next_page_token";
        long expectedTotalSize = 0;

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextPageToken, model.NextPageToken);
        Assert.Equal(expectedTotalSize, model.TotalSize);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SheetListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    CreatedAt = "created_at",
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Status = SheetsJobStatus.Cancelled,
                    UpdatedAt = "updated_at",
                    UserID = "user_id",
                    Config = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    ConfigurationID = "configuration_id",
                    Errors = ["string"],
                    File = new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Name = "x",
                        ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalFileID = "external_file_id",
                        FileSize = 0,
                        FileType = "x",
                        LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PermissionInfo = new Dictionary<string, PermissionInfo?>()
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
                        Purpose = "purpose",
                        ResourceInfo = new Dictionary<string, ResourceInfo?>()
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
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    MetadataStateTransitions = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Parameters = new()
                    {
                        WebhookConfigurations =
                        [
                            new()
                            {
                                WebhookEvents =
                                [
                                    ParametersWebhookConfigurationWebhookEvent.ParseSuccess,
                                    ParametersWebhookConfigurationWebhookEvent.ParseError,
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
                    },
                    Regions =
                    [
                        new()
                        {
                            Location = "location",
                            RegionType = "region_type",
                            SheetName = "sheet_name",
                            Description = "description",
                            RegionID = "region_id",
                            Title = "title",
                        },
                    ],
                    Success = true,
                    WorksheetMetadata =
                    [
                        new()
                        {
                            SheetName = "sheet_name",
                            Description = "description",
                            Title = "title",
                        },
                    ],
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SheetListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SheetListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    CreatedAt = "created_at",
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Status = SheetsJobStatus.Cancelled,
                    UpdatedAt = "updated_at",
                    UserID = "user_id",
                    Config = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    ConfigurationID = "configuration_id",
                    Errors = ["string"],
                    File = new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Name = "x",
                        ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalFileID = "external_file_id",
                        FileSize = 0,
                        FileType = "x",
                        LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PermissionInfo = new Dictionary<string, PermissionInfo?>()
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
                        Purpose = "purpose",
                        ResourceInfo = new Dictionary<string, ResourceInfo?>()
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
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    MetadataStateTransitions = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Parameters = new()
                    {
                        WebhookConfigurations =
                        [
                            new()
                            {
                                WebhookEvents =
                                [
                                    ParametersWebhookConfigurationWebhookEvent.ParseSuccess,
                                    ParametersWebhookConfigurationWebhookEvent.ParseError,
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
                    },
                    Regions =
                    [
                        new()
                        {
                            Location = "location",
                            RegionType = "region_type",
                            SheetName = "sheet_name",
                            Description = "description",
                            RegionID = "region_id",
                            Title = "title",
                        },
                    ],
                    Success = true,
                    WorksheetMetadata =
                    [
                        new()
                        {
                            SheetName = "sheet_name",
                            Description = "description",
                            Title = "title",
                        },
                    ],
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SheetListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<SheetsJob> expectedItems =
        [
            new()
            {
                ID = "id",
                Configuration = new()
                {
                    ExtractionRange = "extraction_range",
                    FlattenHierarchicalTables = true,
                    GenerateAdditionalMetadata = true,
                    IncludeHiddenCells = true,
                    SheetNames = ["string"],
                    Specialization = "specialization",
                    TableMergeSensitivity = TableMergeSensitivity.Strong,
                    Tier = Tier.Agentic,
                    UseExperimentalProcessing = true,
                },
                CreatedAt = "created_at",
                FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Status = SheetsJobStatus.Cancelled,
                UpdatedAt = "updated_at",
                UserID = "user_id",
                Config = new()
                {
                    ExtractionRange = "extraction_range",
                    FlattenHierarchicalTables = true,
                    GenerateAdditionalMetadata = true,
                    IncludeHiddenCells = true,
                    SheetNames = ["string"],
                    Specialization = "specialization",
                    TableMergeSensitivity = TableMergeSensitivity.Strong,
                    Tier = Tier.Agentic,
                    UseExperimentalProcessing = true,
                },
                ConfigurationID = "configuration_id",
                Errors = ["string"],
                File = new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Name = "x",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalFileID = "external_file_id",
                    FileSize = 0,
                    FileType = "x",
                    LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PermissionInfo = new Dictionary<string, PermissionInfo?>()
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
                    Purpose = "purpose",
                    ResourceInfo = new Dictionary<string, ResourceInfo?>()
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
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                MetadataStateTransitions = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Parameters = new()
                {
                    WebhookConfigurations =
                    [
                        new()
                        {
                            WebhookEvents =
                            [
                                ParametersWebhookConfigurationWebhookEvent.ParseSuccess,
                                ParametersWebhookConfigurationWebhookEvent.ParseError,
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
                },
                Regions =
                [
                    new()
                    {
                        Location = "location",
                        RegionType = "region_type",
                        SheetName = "sheet_name",
                        Description = "description",
                        RegionID = "region_id",
                        Title = "title",
                    },
                ],
                Success = true,
                WorksheetMetadata =
                [
                    new()
                    {
                        SheetName = "sheet_name",
                        Description = "description",
                        Title = "title",
                    },
                ],
            },
        ];
        string expectedNextPageToken = "next_page_token";
        long expectedTotalSize = 0;

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextPageToken, deserialized.NextPageToken);
        Assert.Equal(expectedTotalSize, deserialized.TotalSize);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SheetListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    CreatedAt = "created_at",
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Status = SheetsJobStatus.Cancelled,
                    UpdatedAt = "updated_at",
                    UserID = "user_id",
                    Config = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    ConfigurationID = "configuration_id",
                    Errors = ["string"],
                    File = new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Name = "x",
                        ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalFileID = "external_file_id",
                        FileSize = 0,
                        FileType = "x",
                        LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PermissionInfo = new Dictionary<string, PermissionInfo?>()
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
                        Purpose = "purpose",
                        ResourceInfo = new Dictionary<string, ResourceInfo?>()
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
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    MetadataStateTransitions = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Parameters = new()
                    {
                        WebhookConfigurations =
                        [
                            new()
                            {
                                WebhookEvents =
                                [
                                    ParametersWebhookConfigurationWebhookEvent.ParseSuccess,
                                    ParametersWebhookConfigurationWebhookEvent.ParseError,
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
                    },
                    Regions =
                    [
                        new()
                        {
                            Location = "location",
                            RegionType = "region_type",
                            SheetName = "sheet_name",
                            Description = "description",
                            RegionID = "region_id",
                            Title = "title",
                        },
                    ],
                    Success = true,
                    WorksheetMetadata =
                    [
                        new()
                        {
                            SheetName = "sheet_name",
                            Description = "description",
                            Title = "title",
                        },
                    ],
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SheetListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    CreatedAt = "created_at",
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Status = SheetsJobStatus.Cancelled,
                    UpdatedAt = "updated_at",
                    UserID = "user_id",
                    Config = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    ConfigurationID = "configuration_id",
                    Errors = ["string"],
                    File = new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Name = "x",
                        ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalFileID = "external_file_id",
                        FileSize = 0,
                        FileType = "x",
                        LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PermissionInfo = new Dictionary<string, PermissionInfo?>()
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
                        Purpose = "purpose",
                        ResourceInfo = new Dictionary<string, ResourceInfo?>()
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
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    MetadataStateTransitions = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Parameters = new()
                    {
                        WebhookConfigurations =
                        [
                            new()
                            {
                                WebhookEvents =
                                [
                                    ParametersWebhookConfigurationWebhookEvent.ParseSuccess,
                                    ParametersWebhookConfigurationWebhookEvent.ParseError,
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
                    },
                    Regions =
                    [
                        new()
                        {
                            Location = "location",
                            RegionType = "region_type",
                            SheetName = "sheet_name",
                            Description = "description",
                            RegionID = "region_id",
                            Title = "title",
                        },
                    ],
                    Success = true,
                    WorksheetMetadata =
                    [
                        new()
                        {
                            SheetName = "sheet_name",
                            Description = "description",
                            Title = "title",
                        },
                    ],
                },
            ],
        };

        Assert.Null(model.NextPageToken);
        Assert.False(model.RawData.ContainsKey("next_page_token"));
        Assert.Null(model.TotalSize);
        Assert.False(model.RawData.ContainsKey("total_size"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SheetListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    CreatedAt = "created_at",
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Status = SheetsJobStatus.Cancelled,
                    UpdatedAt = "updated_at",
                    UserID = "user_id",
                    Config = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    ConfigurationID = "configuration_id",
                    Errors = ["string"],
                    File = new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Name = "x",
                        ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalFileID = "external_file_id",
                        FileSize = 0,
                        FileType = "x",
                        LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PermissionInfo = new Dictionary<string, PermissionInfo?>()
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
                        Purpose = "purpose",
                        ResourceInfo = new Dictionary<string, ResourceInfo?>()
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
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    MetadataStateTransitions = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Parameters = new()
                    {
                        WebhookConfigurations =
                        [
                            new()
                            {
                                WebhookEvents =
                                [
                                    ParametersWebhookConfigurationWebhookEvent.ParseSuccess,
                                    ParametersWebhookConfigurationWebhookEvent.ParseError,
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
                    },
                    Regions =
                    [
                        new()
                        {
                            Location = "location",
                            RegionType = "region_type",
                            SheetName = "sheet_name",
                            Description = "description",
                            RegionID = "region_id",
                            Title = "title",
                        },
                    ],
                    Success = true,
                    WorksheetMetadata =
                    [
                        new()
                        {
                            SheetName = "sheet_name",
                            Description = "description",
                            Title = "title",
                        },
                    ],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SheetListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    CreatedAt = "created_at",
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Status = SheetsJobStatus.Cancelled,
                    UpdatedAt = "updated_at",
                    UserID = "user_id",
                    Config = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    ConfigurationID = "configuration_id",
                    Errors = ["string"],
                    File = new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Name = "x",
                        ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalFileID = "external_file_id",
                        FileSize = 0,
                        FileType = "x",
                        LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PermissionInfo = new Dictionary<string, PermissionInfo?>()
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
                        Purpose = "purpose",
                        ResourceInfo = new Dictionary<string, ResourceInfo?>()
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
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    MetadataStateTransitions = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Parameters = new()
                    {
                        WebhookConfigurations =
                        [
                            new()
                            {
                                WebhookEvents =
                                [
                                    ParametersWebhookConfigurationWebhookEvent.ParseSuccess,
                                    ParametersWebhookConfigurationWebhookEvent.ParseError,
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
                    },
                    Regions =
                    [
                        new()
                        {
                            Location = "location",
                            RegionType = "region_type",
                            SheetName = "sheet_name",
                            Description = "description",
                            RegionID = "region_id",
                            Title = "title",
                        },
                    ],
                    Success = true,
                    WorksheetMetadata =
                    [
                        new()
                        {
                            SheetName = "sheet_name",
                            Description = "description",
                            Title = "title",
                        },
                    ],
                },
            ],

            NextPageToken = null,
            TotalSize = null,
        };

        Assert.Null(model.NextPageToken);
        Assert.True(model.RawData.ContainsKey("next_page_token"));
        Assert.Null(model.TotalSize);
        Assert.True(model.RawData.ContainsKey("total_size"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SheetListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    CreatedAt = "created_at",
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Status = SheetsJobStatus.Cancelled,
                    UpdatedAt = "updated_at",
                    UserID = "user_id",
                    Config = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    ConfigurationID = "configuration_id",
                    Errors = ["string"],
                    File = new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Name = "x",
                        ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalFileID = "external_file_id",
                        FileSize = 0,
                        FileType = "x",
                        LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PermissionInfo = new Dictionary<string, PermissionInfo?>()
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
                        Purpose = "purpose",
                        ResourceInfo = new Dictionary<string, ResourceInfo?>()
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
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    MetadataStateTransitions = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Parameters = new()
                    {
                        WebhookConfigurations =
                        [
                            new()
                            {
                                WebhookEvents =
                                [
                                    ParametersWebhookConfigurationWebhookEvent.ParseSuccess,
                                    ParametersWebhookConfigurationWebhookEvent.ParseError,
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
                    },
                    Regions =
                    [
                        new()
                        {
                            Location = "location",
                            RegionType = "region_type",
                            SheetName = "sheet_name",
                            Description = "description",
                            RegionID = "region_id",
                            Title = "title",
                        },
                    ],
                    Success = true,
                    WorksheetMetadata =
                    [
                        new()
                        {
                            SheetName = "sheet_name",
                            Description = "description",
                            Title = "title",
                        },
                    ],
                },
            ],

            NextPageToken = null,
            TotalSize = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SheetListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Configuration = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    CreatedAt = "created_at",
                    FileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Status = SheetsJobStatus.Cancelled,
                    UpdatedAt = "updated_at",
                    UserID = "user_id",
                    Config = new()
                    {
                        ExtractionRange = "extraction_range",
                        FlattenHierarchicalTables = true,
                        GenerateAdditionalMetadata = true,
                        IncludeHiddenCells = true,
                        SheetNames = ["string"],
                        Specialization = "specialization",
                        TableMergeSensitivity = TableMergeSensitivity.Strong,
                        Tier = Tier.Agentic,
                        UseExperimentalProcessing = true,
                    },
                    ConfigurationID = "configuration_id",
                    Errors = ["string"],
                    File = new()
                    {
                        ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        Name = "x",
                        ProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        DataSourceID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ExternalFileID = "external_file_id",
                        FileSize = 0,
                        FileType = "x",
                        LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PermissionInfo = new Dictionary<string, PermissionInfo?>()
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
                        Purpose = "purpose",
                        ResourceInfo = new Dictionary<string, ResourceInfo?>()
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
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    MetadataStateTransitions = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Parameters = new()
                    {
                        WebhookConfigurations =
                        [
                            new()
                            {
                                WebhookEvents =
                                [
                                    ParametersWebhookConfigurationWebhookEvent.ParseSuccess,
                                    ParametersWebhookConfigurationWebhookEvent.ParseError,
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
                    },
                    Regions =
                    [
                        new()
                        {
                            Location = "location",
                            RegionType = "region_type",
                            SheetName = "sheet_name",
                            Description = "description",
                            RegionID = "region_id",
                            Title = "title",
                        },
                    ],
                    Success = true,
                    WorksheetMetadata =
                    [
                        new()
                        {
                            SheetName = "sheet_name",
                            Description = "description",
                            Title = "title",
                        },
                    ],
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        SheetListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
