using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Beta.Sheets;
using LlamaCloud.Models.Files;

namespace LlamaCloud.Tests.Models.Beta.Sheets;

public class SheetsJobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SheetsJob
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
        };

        string expectedID = "id";
        SheetsParsingConfig expectedConfiguration = new()
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
        };
        string expectedCreatedAt = "created_at";
        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, SheetsJobStatus> expectedStatus = SheetsJobStatus.Cancelled;
        string expectedUpdatedAt = "updated_at";
        string expectedUserID = "user_id";
        SheetsParsingConfig expectedConfig = new()
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
        };
        string expectedConfigurationID = "configuration_id";
        List<string> expectedErrors = ["string"];
        File expectedFile = new()
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
        };
        Dictionary<string, JsonElement> expectedMetadataStateTransitions = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Parameters expectedParameters = new()
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
        };
        List<Region> expectedRegions =
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
        ];
        bool expectedSuccess = true;
        List<WorksheetMetadata> expectedWorksheetMetadata =
        [
            new()
            {
                SheetName = "sheet_name",
                Description = "description",
                Title = "title",
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConfiguration, model.Configuration);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedConfig, model.Config);
        Assert.Equal(expectedConfigurationID, model.ConfigurationID);
        Assert.NotNull(model.Errors);
        Assert.Equal(expectedErrors.Count, model.Errors.Count);
        for (int i = 0; i < expectedErrors.Count; i++)
        {
            Assert.Equal(expectedErrors[i], model.Errors[i]);
        }
        Assert.Equal(expectedFile, model.File);
        Assert.NotNull(model.MetadataStateTransitions);
        Assert.Equal(expectedMetadataStateTransitions.Count, model.MetadataStateTransitions.Count);
        foreach (var item in expectedMetadataStateTransitions)
        {
            Assert.True(model.MetadataStateTransitions.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.MetadataStateTransitions[item.Key]));
        }
        Assert.Equal(expectedParameters, model.Parameters);
        Assert.NotNull(model.Regions);
        Assert.Equal(expectedRegions.Count, model.Regions.Count);
        for (int i = 0; i < expectedRegions.Count; i++)
        {
            Assert.Equal(expectedRegions[i], model.Regions[i]);
        }
        Assert.Equal(expectedSuccess, model.Success);
        Assert.NotNull(model.WorksheetMetadata);
        Assert.Equal(expectedWorksheetMetadata.Count, model.WorksheetMetadata.Count);
        for (int i = 0; i < expectedWorksheetMetadata.Count; i++)
        {
            Assert.Equal(expectedWorksheetMetadata[i], model.WorksheetMetadata[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SheetsJob
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SheetsJob>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SheetsJob
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SheetsJob>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        SheetsParsingConfig expectedConfiguration = new()
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
        };
        string expectedCreatedAt = "created_at";
        string expectedFileID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedProjectID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, SheetsJobStatus> expectedStatus = SheetsJobStatus.Cancelled;
        string expectedUpdatedAt = "updated_at";
        string expectedUserID = "user_id";
        SheetsParsingConfig expectedConfig = new()
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
        };
        string expectedConfigurationID = "configuration_id";
        List<string> expectedErrors = ["string"];
        File expectedFile = new()
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
        };
        Dictionary<string, JsonElement> expectedMetadataStateTransitions = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Parameters expectedParameters = new()
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
        };
        List<Region> expectedRegions =
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
        ];
        bool expectedSuccess = true;
        List<WorksheetMetadata> expectedWorksheetMetadata =
        [
            new()
            {
                SheetName = "sheet_name",
                Description = "description",
                Title = "title",
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConfiguration, deserialized.Configuration);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedConfig, deserialized.Config);
        Assert.Equal(expectedConfigurationID, deserialized.ConfigurationID);
        Assert.NotNull(deserialized.Errors);
        Assert.Equal(expectedErrors.Count, deserialized.Errors.Count);
        for (int i = 0; i < expectedErrors.Count; i++)
        {
            Assert.Equal(expectedErrors[i], deserialized.Errors[i]);
        }
        Assert.Equal(expectedFile, deserialized.File);
        Assert.NotNull(deserialized.MetadataStateTransitions);
        Assert.Equal(
            expectedMetadataStateTransitions.Count,
            deserialized.MetadataStateTransitions.Count
        );
        foreach (var item in expectedMetadataStateTransitions)
        {
            Assert.True(deserialized.MetadataStateTransitions.TryGetValue(item.Key, out var value));

            Assert.True(
                JsonElement.DeepEquals(value, deserialized.MetadataStateTransitions[item.Key])
            );
        }
        Assert.Equal(expectedParameters, deserialized.Parameters);
        Assert.NotNull(deserialized.Regions);
        Assert.Equal(expectedRegions.Count, deserialized.Regions.Count);
        for (int i = 0; i < expectedRegions.Count; i++)
        {
            Assert.Equal(expectedRegions[i], deserialized.Regions[i]);
        }
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.NotNull(deserialized.WorksheetMetadata);
        Assert.Equal(expectedWorksheetMetadata.Count, deserialized.WorksheetMetadata.Count);
        for (int i = 0; i < expectedWorksheetMetadata.Count; i++)
        {
            Assert.Equal(expectedWorksheetMetadata[i], deserialized.WorksheetMetadata[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SheetsJob
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SheetsJob
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
            Success = true,
        };

        Assert.Null(model.Errors);
        Assert.False(model.RawData.ContainsKey("errors"));
        Assert.Null(model.Parameters);
        Assert.False(model.RawData.ContainsKey("parameters"));
        Assert.Null(model.Regions);
        Assert.False(model.RawData.ContainsKey("regions"));
        Assert.Null(model.WorksheetMetadata);
        Assert.False(model.RawData.ContainsKey("worksheet_metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SheetsJob
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
            Success = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SheetsJob
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
            Success = true,

            // Null should be interpreted as omitted for these properties
            Errors = null,
            Parameters = null,
            Regions = null,
            WorksheetMetadata = null,
        };

        Assert.Null(model.Errors);
        Assert.False(model.RawData.ContainsKey("errors"));
        Assert.Null(model.Parameters);
        Assert.False(model.RawData.ContainsKey("parameters"));
        Assert.Null(model.Regions);
        Assert.False(model.RawData.ContainsKey("regions"));
        Assert.Null(model.WorksheetMetadata);
        Assert.False(model.RawData.ContainsKey("worksheet_metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SheetsJob
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
            Success = true,

            // Null should be interpreted as omitted for these properties
            Errors = null,
            Parameters = null,
            Regions = null,
            WorksheetMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SheetsJob
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
            Errors = ["string"],
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
            WorksheetMetadata =
            [
                new()
                {
                    SheetName = "sheet_name",
                    Description = "description",
                    Title = "title",
                },
            ],
        };

        Assert.Null(model.Config);
        Assert.False(model.RawData.ContainsKey("config"));
        Assert.Null(model.ConfigurationID);
        Assert.False(model.RawData.ContainsKey("configuration_id"));
        Assert.Null(model.File);
        Assert.False(model.RawData.ContainsKey("file"));
        Assert.Null(model.MetadataStateTransitions);
        Assert.False(model.RawData.ContainsKey("metadata_state_transitions"));
        Assert.Null(model.Success);
        Assert.False(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SheetsJob
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
            Errors = ["string"],
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
            WorksheetMetadata =
            [
                new()
                {
                    SheetName = "sheet_name",
                    Description = "description",
                    Title = "title",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SheetsJob
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
            Errors = ["string"],
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
            WorksheetMetadata =
            [
                new()
                {
                    SheetName = "sheet_name",
                    Description = "description",
                    Title = "title",
                },
            ],

            Config = null,
            ConfigurationID = null,
            File = null,
            MetadataStateTransitions = null,
            Success = null,
        };

        Assert.Null(model.Config);
        Assert.True(model.RawData.ContainsKey("config"));
        Assert.Null(model.ConfigurationID);
        Assert.True(model.RawData.ContainsKey("configuration_id"));
        Assert.Null(model.File);
        Assert.True(model.RawData.ContainsKey("file"));
        Assert.Null(model.MetadataStateTransitions);
        Assert.True(model.RawData.ContainsKey("metadata_state_transitions"));
        Assert.Null(model.Success);
        Assert.True(model.RawData.ContainsKey("success"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SheetsJob
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
            Errors = ["string"],
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
            WorksheetMetadata =
            [
                new()
                {
                    SheetName = "sheet_name",
                    Description = "description",
                    Title = "title",
                },
            ],

            Config = null,
            ConfigurationID = null,
            File = null,
            MetadataStateTransitions = null,
            Success = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SheetsJob
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
        };

        SheetsJob copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SheetsJobStatusTest : TestBase
{
    [Theory]
    [InlineData(SheetsJobStatus.Cancelled)]
    [InlineData(SheetsJobStatus.Error)]
    [InlineData(SheetsJobStatus.PartialSuccess)]
    [InlineData(SheetsJobStatus.Pending)]
    [InlineData(SheetsJobStatus.Success)]
    public void Validation_Works(SheetsJobStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SheetsJobStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SheetsJobStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SheetsJobStatus.Cancelled)]
    [InlineData(SheetsJobStatus.Error)]
    [InlineData(SheetsJobStatus.PartialSuccess)]
    [InlineData(SheetsJobStatus.Pending)]
    [InlineData(SheetsJobStatus.Success)]
    public void SerializationRoundtrip_Works(SheetsJobStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SheetsJobStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SheetsJobStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SheetsJobStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SheetsJobStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ParametersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parameters
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
        };

        List<ParametersWebhookConfiguration> expectedWebhookConfigurations =
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
        ];

        Assert.NotNull(model.WebhookConfigurations);
        Assert.Equal(expectedWebhookConfigurations.Count, model.WebhookConfigurations.Count);
        for (int i = 0; i < expectedWebhookConfigurations.Count; i++)
        {
            Assert.Equal(expectedWebhookConfigurations[i], model.WebhookConfigurations[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parameters
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parameters>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parameters
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parameters>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ParametersWebhookConfiguration> expectedWebhookConfigurations =
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
        ];

        Assert.NotNull(deserialized.WebhookConfigurations);
        Assert.Equal(expectedWebhookConfigurations.Count, deserialized.WebhookConfigurations.Count);
        for (int i = 0; i < expectedWebhookConfigurations.Count; i++)
        {
            Assert.Equal(expectedWebhookConfigurations[i], deserialized.WebhookConfigurations[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parameters
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parameters { };

        Assert.Null(model.WebhookConfigurations);
        Assert.False(model.RawData.ContainsKey("webhook_configurations"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parameters { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parameters { WebhookConfigurations = null };

        Assert.Null(model.WebhookConfigurations);
        Assert.True(model.RawData.ContainsKey("webhook_configurations"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parameters { WebhookConfigurations = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parameters
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
        };

        Parameters copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ParametersWebhookConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ParametersWebhookConfiguration
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
        };

        List<ApiEnum<string, ParametersWebhookConfigurationWebhookEvent>> expectedWebhookEvents =
        [
            ParametersWebhookConfigurationWebhookEvent.ParseSuccess,
            ParametersWebhookConfigurationWebhookEvent.ParseError,
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
        var model = new ParametersWebhookConfiguration
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParametersWebhookConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ParametersWebhookConfiguration
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParametersWebhookConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ApiEnum<string, ParametersWebhookConfigurationWebhookEvent>> expectedWebhookEvents =
        [
            ParametersWebhookConfigurationWebhookEvent.ParseSuccess,
            ParametersWebhookConfigurationWebhookEvent.ParseError,
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
        var model = new ParametersWebhookConfiguration
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ParametersWebhookConfiguration { };

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
        var model = new ParametersWebhookConfiguration { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ParametersWebhookConfiguration
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
        var model = new ParametersWebhookConfiguration
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
        var model = new ParametersWebhookConfiguration
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
        };

        ParametersWebhookConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ParametersWebhookConfigurationWebhookEventTest : TestBase
{
    [Theory]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.BatchCancelled)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.BatchError)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.BatchPending)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.BatchRunning)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.BatchSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ClassifyCancelled)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ClassifyError)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ClassifyPartialSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ClassifyPending)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ClassifyRunning)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ClassifySuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ExtractCancelled)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ExtractError)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ExtractPartialSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ExtractPending)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ExtractSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ParseCancelled)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ParseError)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ParsePartialSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ParsePending)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ParseRunning)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ParseSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SheetsCancelled)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SheetsError)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SheetsPartialSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SheetsPending)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SheetsSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SplitCancelled)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SplitError)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SplitPending)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SplitProcessing)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SplitSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.UnmappedEvent)]
    public void Validation_Works(ParametersWebhookConfigurationWebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ParametersWebhookConfigurationWebhookEvent> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ParametersWebhookConfigurationWebhookEvent>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.BatchCancelled)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.BatchError)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.BatchPending)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.BatchRunning)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.BatchSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ClassifyCancelled)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ClassifyError)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ClassifyPartialSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ClassifyPending)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ClassifyRunning)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ClassifySuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ExtractCancelled)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ExtractError)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ExtractPartialSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ExtractPending)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ExtractSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ParseCancelled)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ParseError)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ParsePartialSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ParsePending)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ParseRunning)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.ParseSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SheetsCancelled)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SheetsError)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SheetsPartialSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SheetsPending)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SheetsSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SplitCancelled)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SplitError)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SplitPending)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SplitProcessing)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.SplitSuccess)]
    [InlineData(ParametersWebhookConfigurationWebhookEvent.UnmappedEvent)]
    public void SerializationRoundtrip_Works(ParametersWebhookConfigurationWebhookEvent rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ParametersWebhookConfigurationWebhookEvent> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ParametersWebhookConfigurationWebhookEvent>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ParametersWebhookConfigurationWebhookEvent>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ParametersWebhookConfigurationWebhookEvent>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RegionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Region
        {
            Location = "location",
            RegionType = "region_type",
            SheetName = "sheet_name",
            Description = "description",
            RegionID = "region_id",
            Title = "title",
        };

        string expectedLocation = "location";
        string expectedRegionType = "region_type";
        string expectedSheetName = "sheet_name";
        string expectedDescription = "description";
        string expectedRegionID = "region_id";
        string expectedTitle = "title";

        Assert.Equal(expectedLocation, model.Location);
        Assert.Equal(expectedRegionType, model.RegionType);
        Assert.Equal(expectedSheetName, model.SheetName);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedRegionID, model.RegionID);
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Region
        {
            Location = "location",
            RegionType = "region_type",
            SheetName = "sheet_name",
            Description = "description",
            RegionID = "region_id",
            Title = "title",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Region>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Region
        {
            Location = "location",
            RegionType = "region_type",
            SheetName = "sheet_name",
            Description = "description",
            RegionID = "region_id",
            Title = "title",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Region>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedLocation = "location";
        string expectedRegionType = "region_type";
        string expectedSheetName = "sheet_name";
        string expectedDescription = "description";
        string expectedRegionID = "region_id";
        string expectedTitle = "title";

        Assert.Equal(expectedLocation, deserialized.Location);
        Assert.Equal(expectedRegionType, deserialized.RegionType);
        Assert.Equal(expectedSheetName, deserialized.SheetName);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedRegionID, deserialized.RegionID);
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Region
        {
            Location = "location",
            RegionType = "region_type",
            SheetName = "sheet_name",
            Description = "description",
            RegionID = "region_id",
            Title = "title",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Region
        {
            Location = "location",
            RegionType = "region_type",
            SheetName = "sheet_name",
            Description = "description",
            Title = "title",
        };

        Assert.Null(model.RegionID);
        Assert.False(model.RawData.ContainsKey("region_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Region
        {
            Location = "location",
            RegionType = "region_type",
            SheetName = "sheet_name",
            Description = "description",
            Title = "title",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Region
        {
            Location = "location",
            RegionType = "region_type",
            SheetName = "sheet_name",
            Description = "description",
            Title = "title",

            // Null should be interpreted as omitted for these properties
            RegionID = null,
        };

        Assert.Null(model.RegionID);
        Assert.False(model.RawData.ContainsKey("region_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Region
        {
            Location = "location",
            RegionType = "region_type",
            SheetName = "sheet_name",
            Description = "description",
            Title = "title",

            // Null should be interpreted as omitted for these properties
            RegionID = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Region
        {
            Location = "location",
            RegionType = "region_type",
            SheetName = "sheet_name",
            RegionID = "region_id",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Region
        {
            Location = "location",
            RegionType = "region_type",
            SheetName = "sheet_name",
            RegionID = "region_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Region
        {
            Location = "location",
            RegionType = "region_type",
            SheetName = "sheet_name",
            RegionID = "region_id",

            Description = null,
            Title = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Title);
        Assert.True(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Region
        {
            Location = "location",
            RegionType = "region_type",
            SheetName = "sheet_name",
            RegionID = "region_id",

            Description = null,
            Title = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Region
        {
            Location = "location",
            RegionType = "region_type",
            SheetName = "sheet_name",
            Description = "description",
            RegionID = "region_id",
            Title = "title",
        };

        Region copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WorksheetMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorksheetMetadata
        {
            SheetName = "sheet_name",
            Description = "description",
            Title = "title",
        };

        string expectedSheetName = "sheet_name";
        string expectedDescription = "description";
        string expectedTitle = "title";

        Assert.Equal(expectedSheetName, model.SheetName);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorksheetMetadata
        {
            SheetName = "sheet_name",
            Description = "description",
            Title = "title",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorksheetMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorksheetMetadata
        {
            SheetName = "sheet_name",
            Description = "description",
            Title = "title",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorksheetMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSheetName = "sheet_name";
        string expectedDescription = "description";
        string expectedTitle = "title";

        Assert.Equal(expectedSheetName, deserialized.SheetName);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorksheetMetadata
        {
            SheetName = "sheet_name",
            Description = "description",
            Title = "title",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WorksheetMetadata { SheetName = "sheet_name" };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WorksheetMetadata { SheetName = "sheet_name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WorksheetMetadata
        {
            SheetName = "sheet_name",

            Description = null,
            Title = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Title);
        Assert.True(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WorksheetMetadata
        {
            SheetName = "sheet_name",

            Description = null,
            Title = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorksheetMetadata
        {
            SheetName = "sheet_name",
            Description = "description",
            Title = "title",
        };

        WorksheetMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
