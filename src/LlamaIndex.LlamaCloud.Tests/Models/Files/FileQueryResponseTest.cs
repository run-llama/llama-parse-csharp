using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Files;

namespace LlamaIndex.LlamaCloud.Tests.Models.Files;

public class FileQueryResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Name = "invoice.pdf",
                    ProjectID = "123e4567-e89b-12d3-a456-426614174000",
                    DownloadUrl = new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Url = "https://example.com",
                        FormFields = new Dictionary<string, string>() { { "foo", "string" } },
                    },
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalFileID = "ext-12345",
                    FileType = "pdf",
                    LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Purpose = "parse",
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        List<Item> expectedItems =
        [
            new()
            {
                ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Name = "invoice.pdf",
                ProjectID = "123e4567-e89b-12d3-a456-426614174000",
                DownloadUrl = new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "https://example.com",
                    FormFields = new Dictionary<string, string>() { { "foo", "string" } },
                },
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalFileID = "ext-12345",
                FileType = "pdf",
                LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Purpose = "parse",
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
        var model = new FileQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Name = "invoice.pdf",
                    ProjectID = "123e4567-e89b-12d3-a456-426614174000",
                    DownloadUrl = new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Url = "https://example.com",
                        FormFields = new Dictionary<string, string>() { { "foo", "string" } },
                    },
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalFileID = "ext-12345",
                    FileType = "pdf",
                    LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Purpose = "parse",
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileQueryResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Name = "invoice.pdf",
                    ProjectID = "123e4567-e89b-12d3-a456-426614174000",
                    DownloadUrl = new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Url = "https://example.com",
                        FormFields = new Dictionary<string, string>() { { "foo", "string" } },
                    },
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalFileID = "ext-12345",
                    FileType = "pdf",
                    LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Purpose = "parse",
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FileQueryResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Item> expectedItems =
        [
            new()
            {
                ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Name = "invoice.pdf",
                ProjectID = "123e4567-e89b-12d3-a456-426614174000",
                DownloadUrl = new()
                {
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Url = "https://example.com",
                    FormFields = new Dictionary<string, string>() { { "foo", "string" } },
                },
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExternalFileID = "ext-12345",
                FileType = "pdf",
                LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Purpose = "parse",
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
        var model = new FileQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Name = "invoice.pdf",
                    ProjectID = "123e4567-e89b-12d3-a456-426614174000",
                    DownloadUrl = new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Url = "https://example.com",
                        FormFields = new Dictionary<string, string>() { { "foo", "string" } },
                    },
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalFileID = "ext-12345",
                    FileType = "pdf",
                    LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Purpose = "parse",
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
        var model = new FileQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Name = "invoice.pdf",
                    ProjectID = "123e4567-e89b-12d3-a456-426614174000",
                    DownloadUrl = new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Url = "https://example.com",
                        FormFields = new Dictionary<string, string>() { { "foo", "string" } },
                    },
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalFileID = "ext-12345",
                    FileType = "pdf",
                    LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Purpose = "parse",
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
        var model = new FileQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Name = "invoice.pdf",
                    ProjectID = "123e4567-e89b-12d3-a456-426614174000",
                    DownloadUrl = new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Url = "https://example.com",
                        FormFields = new Dictionary<string, string>() { { "foo", "string" } },
                    },
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalFileID = "ext-12345",
                    FileType = "pdf",
                    LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Purpose = "parse",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FileQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Name = "invoice.pdf",
                    ProjectID = "123e4567-e89b-12d3-a456-426614174000",
                    DownloadUrl = new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Url = "https://example.com",
                        FormFields = new Dictionary<string, string>() { { "foo", "string" } },
                    },
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalFileID = "ext-12345",
                    FileType = "pdf",
                    LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Purpose = "parse",
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
        var model = new FileQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Name = "invoice.pdf",
                    ProjectID = "123e4567-e89b-12d3-a456-426614174000",
                    DownloadUrl = new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Url = "https://example.com",
                        FormFields = new Dictionary<string, string>() { { "foo", "string" } },
                    },
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalFileID = "ext-12345",
                    FileType = "pdf",
                    LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Purpose = "parse",
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
        var model = new FileQueryResponse
        {
            Items =
            [
                new()
                {
                    ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Name = "invoice.pdf",
                    ProjectID = "123e4567-e89b-12d3-a456-426614174000",
                    DownloadUrl = new()
                    {
                        ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Url = "https://example.com",
                        FormFields = new Dictionary<string, string>() { { "foo", "string" } },
                    },
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExternalFileID = "ext-12345",
                    FileType = "pdf",
                    LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Purpose = "parse",
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        FileQueryResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Name = "invoice.pdf",
            ProjectID = "123e4567-e89b-12d3-a456-426614174000",
            DownloadUrl = new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "https://example.com",
                FormFields = new Dictionary<string, string>() { { "foo", "string" } },
            },
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalFileID = "ext-12345",
            FileType = "pdf",
            LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Purpose = "parse",
        };

        string expectedID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedName = "invoice.pdf";
        string expectedProjectID = "123e4567-e89b-12d3-a456-426614174000";
        PresignedUrl expectedDownloadUrl = new()
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            FormFields = new Dictionary<string, string>() { { "foo", "string" } },
        };
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalFileID = "ext-12345";
        string expectedFileType = "pdf";
        DateTimeOffset expectedLastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPurpose = "parse";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedDownloadUrl, model.DownloadUrl);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedExternalFileID, model.ExternalFileID);
        Assert.Equal(expectedFileType, model.FileType);
        Assert.Equal(expectedLastModifiedAt, model.LastModifiedAt);
        Assert.Equal(expectedPurpose, model.Purpose);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Name = "invoice.pdf",
            ProjectID = "123e4567-e89b-12d3-a456-426614174000",
            DownloadUrl = new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "https://example.com",
                FormFields = new Dictionary<string, string>() { { "foo", "string" } },
            },
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalFileID = "ext-12345",
            FileType = "pdf",
            LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Purpose = "parse",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
        {
            ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Name = "invoice.pdf",
            ProjectID = "123e4567-e89b-12d3-a456-426614174000",
            DownloadUrl = new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "https://example.com",
                FormFields = new Dictionary<string, string>() { { "foo", "string" } },
            },
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalFileID = "ext-12345",
            FileType = "pdf",
            LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Purpose = "parse",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedName = "invoice.pdf";
        string expectedProjectID = "123e4567-e89b-12d3-a456-426614174000";
        PresignedUrl expectedDownloadUrl = new()
        {
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Url = "https://example.com",
            FormFields = new Dictionary<string, string>() { { "foo", "string" } },
        };
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedExternalFileID = "ext-12345";
        string expectedFileType = "pdf";
        DateTimeOffset expectedLastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPurpose = "parse";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedDownloadUrl, deserialized.DownloadUrl);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedExternalFileID, deserialized.ExternalFileID);
        Assert.Equal(expectedFileType, deserialized.FileType);
        Assert.Equal(expectedLastModifiedAt, deserialized.LastModifiedAt);
        Assert.Equal(expectedPurpose, deserialized.Purpose);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Name = "invoice.pdf",
            ProjectID = "123e4567-e89b-12d3-a456-426614174000",
            DownloadUrl = new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "https://example.com",
                FormFields = new Dictionary<string, string>() { { "foo", "string" } },
            },
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalFileID = "ext-12345",
            FileType = "pdf",
            LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Purpose = "parse",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item
        {
            ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Name = "invoice.pdf",
            ProjectID = "123e4567-e89b-12d3-a456-426614174000",
        };

        Assert.Null(model.DownloadUrl);
        Assert.False(model.RawData.ContainsKey("download_url"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.ExternalFileID);
        Assert.False(model.RawData.ContainsKey("external_file_id"));
        Assert.Null(model.FileType);
        Assert.False(model.RawData.ContainsKey("file_type"));
        Assert.Null(model.LastModifiedAt);
        Assert.False(model.RawData.ContainsKey("last_modified_at"));
        Assert.Null(model.Purpose);
        Assert.False(model.RawData.ContainsKey("purpose"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item
        {
            ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Name = "invoice.pdf",
            ProjectID = "123e4567-e89b-12d3-a456-426614174000",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Item
        {
            ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Name = "invoice.pdf",
            ProjectID = "123e4567-e89b-12d3-a456-426614174000",

            DownloadUrl = null,
            ExpiresAt = null,
            ExternalFileID = null,
            FileType = null,
            LastModifiedAt = null,
            Purpose = null,
        };

        Assert.Null(model.DownloadUrl);
        Assert.True(model.RawData.ContainsKey("download_url"));
        Assert.Null(model.ExpiresAt);
        Assert.True(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.ExternalFileID);
        Assert.True(model.RawData.ContainsKey("external_file_id"));
        Assert.Null(model.FileType);
        Assert.True(model.RawData.ContainsKey("file_type"));
        Assert.Null(model.LastModifiedAt);
        Assert.True(model.RawData.ContainsKey("last_modified_at"));
        Assert.Null(model.Purpose);
        Assert.True(model.RawData.ContainsKey("purpose"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
        {
            ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Name = "invoice.pdf",
            ProjectID = "123e4567-e89b-12d3-a456-426614174000",

            DownloadUrl = null,
            ExpiresAt = null,
            ExternalFileID = null,
            FileType = null,
            LastModifiedAt = null,
            Purpose = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Item
        {
            ID = "dfl-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Name = "invoice.pdf",
            ProjectID = "123e4567-e89b-12d3-a456-426614174000",
            DownloadUrl = new()
            {
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Url = "https://example.com",
                FormFields = new Dictionary<string, string>() { { "foo", "string" } },
            },
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExternalFileID = "ext-12345",
            FileType = "pdf",
            LastModifiedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Purpose = "parse",
        };

        Item copied = new(model);

        Assert.Equal(model, copied);
    }
}
