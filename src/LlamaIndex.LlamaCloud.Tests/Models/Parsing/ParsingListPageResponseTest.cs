using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Parsing;

namespace LlamaIndex.LlamaCloud.Tests.Models.Parsing;

public class ParsingListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ParsingListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = ParsingListResponseStatus.Cancelled,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Name = "Q4 Financial Report",
                    Tier = "fast",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Usage = new() { Credits = 30 },
                    UserMetadata = new Dictionary<string, string>()
                    {
                        { "owner", "jerry" },
                        { "team", "research" },
                    },
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        List<ParsingListResponse> expectedItems =
        [
            new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Status = ParsingListResponseStatus.Cancelled,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "error_message",
                Name = "Q4 Financial Report",
                Tier = "fast",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Usage = new() { Credits = 30 },
                UserMetadata = new Dictionary<string, string>()
                {
                    { "owner", "jerry" },
                    { "team", "research" },
                },
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
        var model = new ParsingListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = ParsingListResponseStatus.Cancelled,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Name = "Q4 Financial Report",
                    Tier = "fast",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Usage = new() { Credits = 30 },
                    UserMetadata = new Dictionary<string, string>()
                    {
                        { "owner", "jerry" },
                        { "team", "research" },
                    },
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsingListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ParsingListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = ParsingListResponseStatus.Cancelled,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Name = "Q4 Financial Report",
                    Tier = "fast",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Usage = new() { Credits = 30 },
                    UserMetadata = new Dictionary<string, string>()
                    {
                        { "owner", "jerry" },
                        { "team", "research" },
                    },
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParsingListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ParsingListResponse> expectedItems =
        [
            new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Status = ParsingListResponseStatus.Cancelled,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "error_message",
                Name = "Q4 Financial Report",
                Tier = "fast",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Usage = new() { Credits = 30 },
                UserMetadata = new Dictionary<string, string>()
                {
                    { "owner", "jerry" },
                    { "team", "research" },
                },
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
        var model = new ParsingListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = ParsingListResponseStatus.Cancelled,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Name = "Q4 Financial Report",
                    Tier = "fast",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Usage = new() { Credits = 30 },
                    UserMetadata = new Dictionary<string, string>()
                    {
                        { "owner", "jerry" },
                        { "team", "research" },
                    },
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
        var model = new ParsingListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = ParsingListResponseStatus.Cancelled,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Name = "Q4 Financial Report",
                    Tier = "fast",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Usage = new() { Credits = 30 },
                    UserMetadata = new Dictionary<string, string>()
                    {
                        { "owner", "jerry" },
                        { "team", "research" },
                    },
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
        var model = new ParsingListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = ParsingListResponseStatus.Cancelled,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Name = "Q4 Financial Report",
                    Tier = "fast",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Usage = new() { Credits = 30 },
                    UserMetadata = new Dictionary<string, string>()
                    {
                        { "owner", "jerry" },
                        { "team", "research" },
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ParsingListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = ParsingListResponseStatus.Cancelled,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Name = "Q4 Financial Report",
                    Tier = "fast",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Usage = new() { Credits = 30 },
                    UserMetadata = new Dictionary<string, string>()
                    {
                        { "owner", "jerry" },
                        { "team", "research" },
                    },
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
        var model = new ParsingListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = ParsingListResponseStatus.Cancelled,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Name = "Q4 Financial Report",
                    Tier = "fast",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Usage = new() { Credits = 30 },
                    UserMetadata = new Dictionary<string, string>()
                    {
                        { "owner", "jerry" },
                        { "team", "research" },
                    },
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
        var model = new ParsingListPageResponse
        {
            Items =
            [
                new()
                {
                    ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                    Status = ParsingListResponseStatus.Cancelled,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "error_message",
                    Name = "Q4 Financial Report",
                    Tier = "fast",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Usage = new() { Credits = 30 },
                    UserMetadata = new Dictionary<string, string>()
                    {
                        { "owner", "jerry" },
                        { "team", "research" },
                    },
                },
            ],
            NextPageToken = "next_page_token",
            TotalSize = 0,
        };

        ParsingListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
