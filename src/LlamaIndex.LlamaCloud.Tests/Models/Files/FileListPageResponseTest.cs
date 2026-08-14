using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Files;

namespace LlamaIndex.LlamaCloud.Tests.Models.Files;

public class FileListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FileListPageResponse
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

        List<FileListResponse> expectedItems =
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
        var model = new FileListPageResponse
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
        var deserialized = JsonSerializer.Deserialize<FileListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FileListPageResponse
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
        var deserialized = JsonSerializer.Deserialize<FileListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FileListResponse> expectedItems =
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
        var model = new FileListPageResponse
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
        var model = new FileListPageResponse
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
        var model = new FileListPageResponse
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
        var model = new FileListPageResponse
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
        var model = new FileListPageResponse
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
        var model = new FileListPageResponse
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

        FileListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
