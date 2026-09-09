using System;
using System.Collections.Generic;
using System.Text.Json;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using Parsing = LlamaCloud.Models.Parsing;

namespace LlamaCloud.Tests.Models.Parsing;

public class ParsingGetResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::ParsingGetResponse
        {
            Job = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Status = Parsing::JobStatus.Cancelled,
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
            Forms = new(
                [
                    new Parsing::FormsResultPage()
                    {
                        Forms =
                        [
                            new()
                            {
                                Json =
                                [
                                    new Parsing::FormField()
                                    {
                                        Field = Parsing::Field.Checkbox,
                                        ID = "id",
                                        Bbox =
                                        [
                                            new()
                                            {
                                                H = 0,
                                                W = 0,
                                                X = 0,
                                                Y = 0,
                                                Confidence = 0,
                                                EndIndex = 0,
                                                Label = "label",
                                                R = 0,
                                                StartIndex = 0,
                                            },
                                        ],
                                        IsEmpty = true,
                                        Label = "label",
                                        Type = Parsing::FormFieldType.Field,
                                        Value = "string",
                                        ValueItems =
                                        [
                                            new Parsing::FormSection()
                                            {
                                                Items =
                                                [
                                                    new Parsing::FormTable()
                                                    {
                                                        Rows =
                                                        [
                                                            ["string"],
                                                        ],
                                                        ID = "id",
                                                        Bbox =
                                                        [
                                                            new()
                                                            {
                                                                H = 0,
                                                                W = 0,
                                                                X = 0,
                                                                Y = 0,
                                                                Confidence = 0,
                                                                EndIndex = 0,
                                                                Label = "label",
                                                                R = 0,
                                                                StartIndex = 0,
                                                            },
                                                        ],
                                                        Columns = ["string"],
                                                        Label = "label",
                                                        Type = Parsing::FormTableType.Table,
                                                    },
                                                ],
                                                ID = "id",
                                                Label = "label",
                                                Type = Parsing::FormSectionType.Section,
                                            },
                                        ],
                                    },
                                ],
                                List = new()
                                {
                                    Items =
                                    [
                                        new Parsing::FormListTextItem()
                                        {
                                            Md = "md",
                                            Value = "value",
                                            Type = Parsing::FormListTextItemType.Text,
                                        },
                                    ],
                                    Md = "md",
                                    Ordered = true,
                                    Type = Parsing::FormListItemType.List,
                                },
                            },
                        ],
                        PageNumber = 0,
                        PageHeight = 0,
                        PageWidth = 0,
                    },
                ]
            ),
            ImagesContentMetadata = new()
            {
                Images =
                [
                    new()
                    {
                        Filename = "filename",
                        Index = 0,
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                        Category = Parsing::Category.Embedded,
                        ContentType = "content_type",
                        PresignedUrl = "presigned_url",
                        SizeBytes = 0,
                    },
                ],
                TotalCount = 0,
            },
            Items = new(
                [
                    new Parsing::StructuredResultPage()
                    {
                        Items =
                        [
                            new Parsing::CodeItem()
                            {
                                Md = "md",
                                ValueValue = "value",
                                Bbox =
                                [
                                    new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                ],
                                Language = "language",
                                Type = Parsing::Type.Code,
                            },
                        ],
                        PageHeight = 0,
                        PageNumber = 0,
                        PageWidth = 0,
                        Revisions =
                        [
                            new()
                            {
                                Content = "content",
                                RevisionBbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                                Target = "target",
                                TargetBbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                                Type = Parsing::RevisionType.Comment,
                                Author = "author",
                                EndIndex = 0,
                                StartIndex = 0,
                                TargetSpans =
                                [
                                    new()
                                    {
                                        Target = "target",
                                        TargetBbox = new()
                                        {
                                            H = 0,
                                            W = 0,
                                            X = 0,
                                            Y = 0,
                                        },
                                        EndIndex = 0,
                                        StartIndex = 0,
                                    },
                                ],
                            },
                        ],
                    },
                ]
            ),
            JobMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Markdown = new(
                [
                    new Parsing::MarkdownResultPage()
                    {
                        Markdown = "markdown",
                        PageNumber = 0,
                        Footer = "footer",
                        Header = "header",
                    },
                ]
            ),
            MarkdownFull = "markdown_full",
            Metadata = new(
                [
                    new()
                    {
                        PageNumber = 0,
                        Confidence = 0,
                        CostOptimized = true,
                        OriginalOrientationAngle = 0,
                        PrintedPageNumber = "printed_page_number",
                        SlideSectionName = "slide_section_name",
                        SpeakerNotes = "speaker_notes",
                        TriggeredAutoMode = true,
                    },
                ]
            ),
            RawParameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ResultContentMetadata = new Dictionary<string, Parsing::ResultContentMetadataItem>()
            {
                {
                    "foo",
                    new()
                    {
                        SizeBytes = 0,
                        Exists = true,
                        PresignedUrl = "presigned_url",
                    }
                },
            },
            Text = new([new() { PageNumber = 0, Text = "text" }]),
            TextFull = "text_full",
        };

        Parsing::Job expectedJob = new()
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = Parsing::JobStatus.Cancelled,
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
        };
        Parsing::ParsingGetResponseForms expectedForms = new(
            [
                new Parsing::FormsResultPage()
                {
                    Forms =
                    [
                        new()
                        {
                            Json =
                            [
                                new Parsing::FormField()
                                {
                                    Field = Parsing::Field.Checkbox,
                                    ID = "id",
                                    Bbox =
                                    [
                                        new()
                                        {
                                            H = 0,
                                            W = 0,
                                            X = 0,
                                            Y = 0,
                                            Confidence = 0,
                                            EndIndex = 0,
                                            Label = "label",
                                            R = 0,
                                            StartIndex = 0,
                                        },
                                    ],
                                    IsEmpty = true,
                                    Label = "label",
                                    Type = Parsing::FormFieldType.Field,
                                    Value = "string",
                                    ValueItems =
                                    [
                                        new Parsing::FormSection()
                                        {
                                            Items =
                                            [
                                                new Parsing::FormTable()
                                                {
                                                    Rows =
                                                    [
                                                        ["string"],
                                                    ],
                                                    ID = "id",
                                                    Bbox =
                                                    [
                                                        new()
                                                        {
                                                            H = 0,
                                                            W = 0,
                                                            X = 0,
                                                            Y = 0,
                                                            Confidence = 0,
                                                            EndIndex = 0,
                                                            Label = "label",
                                                            R = 0,
                                                            StartIndex = 0,
                                                        },
                                                    ],
                                                    Columns = ["string"],
                                                    Label = "label",
                                                    Type = Parsing::FormTableType.Table,
                                                },
                                            ],
                                            ID = "id",
                                            Label = "label",
                                            Type = Parsing::FormSectionType.Section,
                                        },
                                    ],
                                },
                            ],
                            List = new()
                            {
                                Items =
                                [
                                    new Parsing::FormListTextItem()
                                    {
                                        Md = "md",
                                        Value = "value",
                                        Type = Parsing::FormListTextItemType.Text,
                                    },
                                ],
                                Md = "md",
                                Ordered = true,
                                Type = Parsing::FormListItemType.List,
                            },
                        },
                    ],
                    PageNumber = 0,
                    PageHeight = 0,
                    PageWidth = 0,
                },
            ]
        );
        Parsing::ImagesContentMetadata expectedImagesContentMetadata = new()
        {
            Images =
            [
                new()
                {
                    Filename = "filename",
                    Index = 0,
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Category = Parsing::Category.Embedded,
                    ContentType = "content_type",
                    PresignedUrl = "presigned_url",
                    SizeBytes = 0,
                },
            ],
            TotalCount = 0,
        };
        Parsing::Items expectedItems = new(
            [
                new Parsing::StructuredResultPage()
                {
                    Items =
                    [
                        new Parsing::CodeItem()
                        {
                            Md = "md",
                            ValueValue = "value",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            Language = "language",
                            Type = Parsing::Type.Code,
                        },
                    ],
                    PageHeight = 0,
                    PageNumber = 0,
                    PageWidth = 0,
                    Revisions =
                    [
                        new()
                        {
                            Content = "content",
                            RevisionBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            Target = "target",
                            TargetBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            Type = Parsing::RevisionType.Comment,
                            Author = "author",
                            EndIndex = 0,
                            StartIndex = 0,
                            TargetSpans =
                            [
                                new()
                                {
                                    Target = "target",
                                    TargetBbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                    },
                                    EndIndex = 0,
                                    StartIndex = 0,
                                },
                            ],
                        },
                    ],
                },
            ]
        );
        Dictionary<string, JsonElement> expectedJobMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Parsing::ParsingGetResponseMarkdown expectedMarkdown = new(
            [
                new Parsing::MarkdownResultPage()
                {
                    Markdown = "markdown",
                    PageNumber = 0,
                    Footer = "footer",
                    Header = "header",
                },
            ]
        );
        string expectedMarkdownFull = "markdown_full";
        Parsing::Metadata expectedMetadata = new(
            [
                new()
                {
                    PageNumber = 0,
                    Confidence = 0,
                    CostOptimized = true,
                    OriginalOrientationAngle = 0,
                    PrintedPageNumber = "printed_page_number",
                    SlideSectionName = "slide_section_name",
                    SpeakerNotes = "speaker_notes",
                    TriggeredAutoMode = true,
                },
            ]
        );
        Dictionary<string, JsonElement> expectedRawParameters = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, Parsing::ResultContentMetadataItem> expectedResultContentMetadata = new()
        {
            {
                "foo",
                new()
                {
                    SizeBytes = 0,
                    Exists = true,
                    PresignedUrl = "presigned_url",
                }
            },
        };
        Parsing::Text expectedText = new([new() { PageNumber = 0, Text = "text" }]);
        string expectedTextFull = "text_full";

        Assert.Equal(expectedJob, model.Job);
        Assert.Equal(expectedForms, model.Forms);
        Assert.Equal(expectedImagesContentMetadata, model.ImagesContentMetadata);
        Assert.Equal(expectedItems, model.Items);
        Assert.NotNull(model.JobMetadata);
        Assert.Equal(expectedJobMetadata.Count, model.JobMetadata.Count);
        foreach (var item in expectedJobMetadata)
        {
            Assert.True(model.JobMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.JobMetadata[item.Key]));
        }
        Assert.Equal(expectedMarkdown, model.Markdown);
        Assert.Equal(expectedMarkdownFull, model.MarkdownFull);
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.NotNull(model.RawParameters);
        Assert.Equal(expectedRawParameters.Count, model.RawParameters.Count);
        foreach (var item in expectedRawParameters)
        {
            Assert.True(model.RawParameters.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.RawParameters[item.Key]));
        }
        Assert.NotNull(model.ResultContentMetadata);
        Assert.Equal(expectedResultContentMetadata.Count, model.ResultContentMetadata.Count);
        foreach (var item in expectedResultContentMetadata)
        {
            Assert.True(model.ResultContentMetadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.ResultContentMetadata[item.Key]);
        }
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedTextFull, model.TextFull);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::ParsingGetResponse
        {
            Job = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Status = Parsing::JobStatus.Cancelled,
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
            Forms = new(
                [
                    new Parsing::FormsResultPage()
                    {
                        Forms =
                        [
                            new()
                            {
                                Json =
                                [
                                    new Parsing::FormField()
                                    {
                                        Field = Parsing::Field.Checkbox,
                                        ID = "id",
                                        Bbox =
                                        [
                                            new()
                                            {
                                                H = 0,
                                                W = 0,
                                                X = 0,
                                                Y = 0,
                                                Confidence = 0,
                                                EndIndex = 0,
                                                Label = "label",
                                                R = 0,
                                                StartIndex = 0,
                                            },
                                        ],
                                        IsEmpty = true,
                                        Label = "label",
                                        Type = Parsing::FormFieldType.Field,
                                        Value = "string",
                                        ValueItems =
                                        [
                                            new Parsing::FormSection()
                                            {
                                                Items =
                                                [
                                                    new Parsing::FormTable()
                                                    {
                                                        Rows =
                                                        [
                                                            ["string"],
                                                        ],
                                                        ID = "id",
                                                        Bbox =
                                                        [
                                                            new()
                                                            {
                                                                H = 0,
                                                                W = 0,
                                                                X = 0,
                                                                Y = 0,
                                                                Confidence = 0,
                                                                EndIndex = 0,
                                                                Label = "label",
                                                                R = 0,
                                                                StartIndex = 0,
                                                            },
                                                        ],
                                                        Columns = ["string"],
                                                        Label = "label",
                                                        Type = Parsing::FormTableType.Table,
                                                    },
                                                ],
                                                ID = "id",
                                                Label = "label",
                                                Type = Parsing::FormSectionType.Section,
                                            },
                                        ],
                                    },
                                ],
                                List = new()
                                {
                                    Items =
                                    [
                                        new Parsing::FormListTextItem()
                                        {
                                            Md = "md",
                                            Value = "value",
                                            Type = Parsing::FormListTextItemType.Text,
                                        },
                                    ],
                                    Md = "md",
                                    Ordered = true,
                                    Type = Parsing::FormListItemType.List,
                                },
                            },
                        ],
                        PageNumber = 0,
                        PageHeight = 0,
                        PageWidth = 0,
                    },
                ]
            ),
            ImagesContentMetadata = new()
            {
                Images =
                [
                    new()
                    {
                        Filename = "filename",
                        Index = 0,
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                        Category = Parsing::Category.Embedded,
                        ContentType = "content_type",
                        PresignedUrl = "presigned_url",
                        SizeBytes = 0,
                    },
                ],
                TotalCount = 0,
            },
            Items = new(
                [
                    new Parsing::StructuredResultPage()
                    {
                        Items =
                        [
                            new Parsing::CodeItem()
                            {
                                Md = "md",
                                ValueValue = "value",
                                Bbox =
                                [
                                    new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                ],
                                Language = "language",
                                Type = Parsing::Type.Code,
                            },
                        ],
                        PageHeight = 0,
                        PageNumber = 0,
                        PageWidth = 0,
                        Revisions =
                        [
                            new()
                            {
                                Content = "content",
                                RevisionBbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                                Target = "target",
                                TargetBbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                                Type = Parsing::RevisionType.Comment,
                                Author = "author",
                                EndIndex = 0,
                                StartIndex = 0,
                                TargetSpans =
                                [
                                    new()
                                    {
                                        Target = "target",
                                        TargetBbox = new()
                                        {
                                            H = 0,
                                            W = 0,
                                            X = 0,
                                            Y = 0,
                                        },
                                        EndIndex = 0,
                                        StartIndex = 0,
                                    },
                                ],
                            },
                        ],
                    },
                ]
            ),
            JobMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Markdown = new(
                [
                    new Parsing::MarkdownResultPage()
                    {
                        Markdown = "markdown",
                        PageNumber = 0,
                        Footer = "footer",
                        Header = "header",
                    },
                ]
            ),
            MarkdownFull = "markdown_full",
            Metadata = new(
                [
                    new()
                    {
                        PageNumber = 0,
                        Confidence = 0,
                        CostOptimized = true,
                        OriginalOrientationAngle = 0,
                        PrintedPageNumber = "printed_page_number",
                        SlideSectionName = "slide_section_name",
                        SpeakerNotes = "speaker_notes",
                        TriggeredAutoMode = true,
                    },
                ]
            ),
            RawParameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ResultContentMetadata = new Dictionary<string, Parsing::ResultContentMetadataItem>()
            {
                {
                    "foo",
                    new()
                    {
                        SizeBytes = 0,
                        Exists = true,
                        PresignedUrl = "presigned_url",
                    }
                },
            },
            Text = new([new() { PageNumber = 0, Text = "text" }]),
            TextFull = "text_full",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ParsingGetResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::ParsingGetResponse
        {
            Job = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Status = Parsing::JobStatus.Cancelled,
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
            Forms = new(
                [
                    new Parsing::FormsResultPage()
                    {
                        Forms =
                        [
                            new()
                            {
                                Json =
                                [
                                    new Parsing::FormField()
                                    {
                                        Field = Parsing::Field.Checkbox,
                                        ID = "id",
                                        Bbox =
                                        [
                                            new()
                                            {
                                                H = 0,
                                                W = 0,
                                                X = 0,
                                                Y = 0,
                                                Confidence = 0,
                                                EndIndex = 0,
                                                Label = "label",
                                                R = 0,
                                                StartIndex = 0,
                                            },
                                        ],
                                        IsEmpty = true,
                                        Label = "label",
                                        Type = Parsing::FormFieldType.Field,
                                        Value = "string",
                                        ValueItems =
                                        [
                                            new Parsing::FormSection()
                                            {
                                                Items =
                                                [
                                                    new Parsing::FormTable()
                                                    {
                                                        Rows =
                                                        [
                                                            ["string"],
                                                        ],
                                                        ID = "id",
                                                        Bbox =
                                                        [
                                                            new()
                                                            {
                                                                H = 0,
                                                                W = 0,
                                                                X = 0,
                                                                Y = 0,
                                                                Confidence = 0,
                                                                EndIndex = 0,
                                                                Label = "label",
                                                                R = 0,
                                                                StartIndex = 0,
                                                            },
                                                        ],
                                                        Columns = ["string"],
                                                        Label = "label",
                                                        Type = Parsing::FormTableType.Table,
                                                    },
                                                ],
                                                ID = "id",
                                                Label = "label",
                                                Type = Parsing::FormSectionType.Section,
                                            },
                                        ],
                                    },
                                ],
                                List = new()
                                {
                                    Items =
                                    [
                                        new Parsing::FormListTextItem()
                                        {
                                            Md = "md",
                                            Value = "value",
                                            Type = Parsing::FormListTextItemType.Text,
                                        },
                                    ],
                                    Md = "md",
                                    Ordered = true,
                                    Type = Parsing::FormListItemType.List,
                                },
                            },
                        ],
                        PageNumber = 0,
                        PageHeight = 0,
                        PageWidth = 0,
                    },
                ]
            ),
            ImagesContentMetadata = new()
            {
                Images =
                [
                    new()
                    {
                        Filename = "filename",
                        Index = 0,
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                        Category = Parsing::Category.Embedded,
                        ContentType = "content_type",
                        PresignedUrl = "presigned_url",
                        SizeBytes = 0,
                    },
                ],
                TotalCount = 0,
            },
            Items = new(
                [
                    new Parsing::StructuredResultPage()
                    {
                        Items =
                        [
                            new Parsing::CodeItem()
                            {
                                Md = "md",
                                ValueValue = "value",
                                Bbox =
                                [
                                    new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                ],
                                Language = "language",
                                Type = Parsing::Type.Code,
                            },
                        ],
                        PageHeight = 0,
                        PageNumber = 0,
                        PageWidth = 0,
                        Revisions =
                        [
                            new()
                            {
                                Content = "content",
                                RevisionBbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                                Target = "target",
                                TargetBbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                                Type = Parsing::RevisionType.Comment,
                                Author = "author",
                                EndIndex = 0,
                                StartIndex = 0,
                                TargetSpans =
                                [
                                    new()
                                    {
                                        Target = "target",
                                        TargetBbox = new()
                                        {
                                            H = 0,
                                            W = 0,
                                            X = 0,
                                            Y = 0,
                                        },
                                        EndIndex = 0,
                                        StartIndex = 0,
                                    },
                                ],
                            },
                        ],
                    },
                ]
            ),
            JobMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Markdown = new(
                [
                    new Parsing::MarkdownResultPage()
                    {
                        Markdown = "markdown",
                        PageNumber = 0,
                        Footer = "footer",
                        Header = "header",
                    },
                ]
            ),
            MarkdownFull = "markdown_full",
            Metadata = new(
                [
                    new()
                    {
                        PageNumber = 0,
                        Confidence = 0,
                        CostOptimized = true,
                        OriginalOrientationAngle = 0,
                        PrintedPageNumber = "printed_page_number",
                        SlideSectionName = "slide_section_name",
                        SpeakerNotes = "speaker_notes",
                        TriggeredAutoMode = true,
                    },
                ]
            ),
            RawParameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ResultContentMetadata = new Dictionary<string, Parsing::ResultContentMetadataItem>()
            {
                {
                    "foo",
                    new()
                    {
                        SizeBytes = 0,
                        Exists = true,
                        PresignedUrl = "presigned_url",
                    }
                },
            },
            Text = new([new() { PageNumber = 0, Text = "text" }]),
            TextFull = "text_full",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ParsingGetResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Parsing::Job expectedJob = new()
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = Parsing::JobStatus.Cancelled,
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
        };
        Parsing::ParsingGetResponseForms expectedForms = new(
            [
                new Parsing::FormsResultPage()
                {
                    Forms =
                    [
                        new()
                        {
                            Json =
                            [
                                new Parsing::FormField()
                                {
                                    Field = Parsing::Field.Checkbox,
                                    ID = "id",
                                    Bbox =
                                    [
                                        new()
                                        {
                                            H = 0,
                                            W = 0,
                                            X = 0,
                                            Y = 0,
                                            Confidence = 0,
                                            EndIndex = 0,
                                            Label = "label",
                                            R = 0,
                                            StartIndex = 0,
                                        },
                                    ],
                                    IsEmpty = true,
                                    Label = "label",
                                    Type = Parsing::FormFieldType.Field,
                                    Value = "string",
                                    ValueItems =
                                    [
                                        new Parsing::FormSection()
                                        {
                                            Items =
                                            [
                                                new Parsing::FormTable()
                                                {
                                                    Rows =
                                                    [
                                                        ["string"],
                                                    ],
                                                    ID = "id",
                                                    Bbox =
                                                    [
                                                        new()
                                                        {
                                                            H = 0,
                                                            W = 0,
                                                            X = 0,
                                                            Y = 0,
                                                            Confidence = 0,
                                                            EndIndex = 0,
                                                            Label = "label",
                                                            R = 0,
                                                            StartIndex = 0,
                                                        },
                                                    ],
                                                    Columns = ["string"],
                                                    Label = "label",
                                                    Type = Parsing::FormTableType.Table,
                                                },
                                            ],
                                            ID = "id",
                                            Label = "label",
                                            Type = Parsing::FormSectionType.Section,
                                        },
                                    ],
                                },
                            ],
                            List = new()
                            {
                                Items =
                                [
                                    new Parsing::FormListTextItem()
                                    {
                                        Md = "md",
                                        Value = "value",
                                        Type = Parsing::FormListTextItemType.Text,
                                    },
                                ],
                                Md = "md",
                                Ordered = true,
                                Type = Parsing::FormListItemType.List,
                            },
                        },
                    ],
                    PageNumber = 0,
                    PageHeight = 0,
                    PageWidth = 0,
                },
            ]
        );
        Parsing::ImagesContentMetadata expectedImagesContentMetadata = new()
        {
            Images =
            [
                new()
                {
                    Filename = "filename",
                    Index = 0,
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Category = Parsing::Category.Embedded,
                    ContentType = "content_type",
                    PresignedUrl = "presigned_url",
                    SizeBytes = 0,
                },
            ],
            TotalCount = 0,
        };
        Parsing::Items expectedItems = new(
            [
                new Parsing::StructuredResultPage()
                {
                    Items =
                    [
                        new Parsing::CodeItem()
                        {
                            Md = "md",
                            ValueValue = "value",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            Language = "language",
                            Type = Parsing::Type.Code,
                        },
                    ],
                    PageHeight = 0,
                    PageNumber = 0,
                    PageWidth = 0,
                    Revisions =
                    [
                        new()
                        {
                            Content = "content",
                            RevisionBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            Target = "target",
                            TargetBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            Type = Parsing::RevisionType.Comment,
                            Author = "author",
                            EndIndex = 0,
                            StartIndex = 0,
                            TargetSpans =
                            [
                                new()
                                {
                                    Target = "target",
                                    TargetBbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                    },
                                    EndIndex = 0,
                                    StartIndex = 0,
                                },
                            ],
                        },
                    ],
                },
            ]
        );
        Dictionary<string, JsonElement> expectedJobMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Parsing::ParsingGetResponseMarkdown expectedMarkdown = new(
            [
                new Parsing::MarkdownResultPage()
                {
                    Markdown = "markdown",
                    PageNumber = 0,
                    Footer = "footer",
                    Header = "header",
                },
            ]
        );
        string expectedMarkdownFull = "markdown_full";
        Parsing::Metadata expectedMetadata = new(
            [
                new()
                {
                    PageNumber = 0,
                    Confidence = 0,
                    CostOptimized = true,
                    OriginalOrientationAngle = 0,
                    PrintedPageNumber = "printed_page_number",
                    SlideSectionName = "slide_section_name",
                    SpeakerNotes = "speaker_notes",
                    TriggeredAutoMode = true,
                },
            ]
        );
        Dictionary<string, JsonElement> expectedRawParameters = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, Parsing::ResultContentMetadataItem> expectedResultContentMetadata = new()
        {
            {
                "foo",
                new()
                {
                    SizeBytes = 0,
                    Exists = true,
                    PresignedUrl = "presigned_url",
                }
            },
        };
        Parsing::Text expectedText = new([new() { PageNumber = 0, Text = "text" }]);
        string expectedTextFull = "text_full";

        Assert.Equal(expectedJob, deserialized.Job);
        Assert.Equal(expectedForms, deserialized.Forms);
        Assert.Equal(expectedImagesContentMetadata, deserialized.ImagesContentMetadata);
        Assert.Equal(expectedItems, deserialized.Items);
        Assert.NotNull(deserialized.JobMetadata);
        Assert.Equal(expectedJobMetadata.Count, deserialized.JobMetadata.Count);
        foreach (var item in expectedJobMetadata)
        {
            Assert.True(deserialized.JobMetadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.JobMetadata[item.Key]));
        }
        Assert.Equal(expectedMarkdown, deserialized.Markdown);
        Assert.Equal(expectedMarkdownFull, deserialized.MarkdownFull);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.NotNull(deserialized.RawParameters);
        Assert.Equal(expectedRawParameters.Count, deserialized.RawParameters.Count);
        foreach (var item in expectedRawParameters)
        {
            Assert.True(deserialized.RawParameters.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.RawParameters[item.Key]));
        }
        Assert.NotNull(deserialized.ResultContentMetadata);
        Assert.Equal(expectedResultContentMetadata.Count, deserialized.ResultContentMetadata.Count);
        foreach (var item in expectedResultContentMetadata)
        {
            Assert.True(deserialized.ResultContentMetadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.ResultContentMetadata[item.Key]);
        }
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedTextFull, deserialized.TextFull);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::ParsingGetResponse
        {
            Job = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Status = Parsing::JobStatus.Cancelled,
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
            Forms = new(
                [
                    new Parsing::FormsResultPage()
                    {
                        Forms =
                        [
                            new()
                            {
                                Json =
                                [
                                    new Parsing::FormField()
                                    {
                                        Field = Parsing::Field.Checkbox,
                                        ID = "id",
                                        Bbox =
                                        [
                                            new()
                                            {
                                                H = 0,
                                                W = 0,
                                                X = 0,
                                                Y = 0,
                                                Confidence = 0,
                                                EndIndex = 0,
                                                Label = "label",
                                                R = 0,
                                                StartIndex = 0,
                                            },
                                        ],
                                        IsEmpty = true,
                                        Label = "label",
                                        Type = Parsing::FormFieldType.Field,
                                        Value = "string",
                                        ValueItems =
                                        [
                                            new Parsing::FormSection()
                                            {
                                                Items =
                                                [
                                                    new Parsing::FormTable()
                                                    {
                                                        Rows =
                                                        [
                                                            ["string"],
                                                        ],
                                                        ID = "id",
                                                        Bbox =
                                                        [
                                                            new()
                                                            {
                                                                H = 0,
                                                                W = 0,
                                                                X = 0,
                                                                Y = 0,
                                                                Confidence = 0,
                                                                EndIndex = 0,
                                                                Label = "label",
                                                                R = 0,
                                                                StartIndex = 0,
                                                            },
                                                        ],
                                                        Columns = ["string"],
                                                        Label = "label",
                                                        Type = Parsing::FormTableType.Table,
                                                    },
                                                ],
                                                ID = "id",
                                                Label = "label",
                                                Type = Parsing::FormSectionType.Section,
                                            },
                                        ],
                                    },
                                ],
                                List = new()
                                {
                                    Items =
                                    [
                                        new Parsing::FormListTextItem()
                                        {
                                            Md = "md",
                                            Value = "value",
                                            Type = Parsing::FormListTextItemType.Text,
                                        },
                                    ],
                                    Md = "md",
                                    Ordered = true,
                                    Type = Parsing::FormListItemType.List,
                                },
                            },
                        ],
                        PageNumber = 0,
                        PageHeight = 0,
                        PageWidth = 0,
                    },
                ]
            ),
            ImagesContentMetadata = new()
            {
                Images =
                [
                    new()
                    {
                        Filename = "filename",
                        Index = 0,
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                        Category = Parsing::Category.Embedded,
                        ContentType = "content_type",
                        PresignedUrl = "presigned_url",
                        SizeBytes = 0,
                    },
                ],
                TotalCount = 0,
            },
            Items = new(
                [
                    new Parsing::StructuredResultPage()
                    {
                        Items =
                        [
                            new Parsing::CodeItem()
                            {
                                Md = "md",
                                ValueValue = "value",
                                Bbox =
                                [
                                    new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                ],
                                Language = "language",
                                Type = Parsing::Type.Code,
                            },
                        ],
                        PageHeight = 0,
                        PageNumber = 0,
                        PageWidth = 0,
                        Revisions =
                        [
                            new()
                            {
                                Content = "content",
                                RevisionBbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                                Target = "target",
                                TargetBbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                                Type = Parsing::RevisionType.Comment,
                                Author = "author",
                                EndIndex = 0,
                                StartIndex = 0,
                                TargetSpans =
                                [
                                    new()
                                    {
                                        Target = "target",
                                        TargetBbox = new()
                                        {
                                            H = 0,
                                            W = 0,
                                            X = 0,
                                            Y = 0,
                                        },
                                        EndIndex = 0,
                                        StartIndex = 0,
                                    },
                                ],
                            },
                        ],
                    },
                ]
            ),
            JobMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Markdown = new(
                [
                    new Parsing::MarkdownResultPage()
                    {
                        Markdown = "markdown",
                        PageNumber = 0,
                        Footer = "footer",
                        Header = "header",
                    },
                ]
            ),
            MarkdownFull = "markdown_full",
            Metadata = new(
                [
                    new()
                    {
                        PageNumber = 0,
                        Confidence = 0,
                        CostOptimized = true,
                        OriginalOrientationAngle = 0,
                        PrintedPageNumber = "printed_page_number",
                        SlideSectionName = "slide_section_name",
                        SpeakerNotes = "speaker_notes",
                        TriggeredAutoMode = true,
                    },
                ]
            ),
            RawParameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ResultContentMetadata = new Dictionary<string, Parsing::ResultContentMetadataItem>()
            {
                {
                    "foo",
                    new()
                    {
                        SizeBytes = 0,
                        Exists = true,
                        PresignedUrl = "presigned_url",
                    }
                },
            },
            Text = new([new() { PageNumber = 0, Text = "text" }]),
            TextFull = "text_full",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::ParsingGetResponse
        {
            Job = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Status = Parsing::JobStatus.Cancelled,
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
        };

        Assert.Null(model.Forms);
        Assert.False(model.RawData.ContainsKey("forms"));
        Assert.Null(model.ImagesContentMetadata);
        Assert.False(model.RawData.ContainsKey("images_content_metadata"));
        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.JobMetadata);
        Assert.False(model.RawData.ContainsKey("job_metadata"));
        Assert.Null(model.Markdown);
        Assert.False(model.RawData.ContainsKey("markdown"));
        Assert.Null(model.MarkdownFull);
        Assert.False(model.RawData.ContainsKey("markdown_full"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.RawParameters);
        Assert.False(model.RawData.ContainsKey("raw_parameters"));
        Assert.Null(model.ResultContentMetadata);
        Assert.False(model.RawData.ContainsKey("result_content_metadata"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.TextFull);
        Assert.False(model.RawData.ContainsKey("text_full"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::ParsingGetResponse
        {
            Job = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Status = Parsing::JobStatus.Cancelled,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::ParsingGetResponse
        {
            Job = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Status = Parsing::JobStatus.Cancelled,
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

            Forms = null,
            ImagesContentMetadata = null,
            Items = null,
            JobMetadata = null,
            Markdown = null,
            MarkdownFull = null,
            Metadata = null,
            RawParameters = null,
            ResultContentMetadata = null,
            Text = null,
            TextFull = null,
        };

        Assert.Null(model.Forms);
        Assert.True(model.RawData.ContainsKey("forms"));
        Assert.Null(model.ImagesContentMetadata);
        Assert.True(model.RawData.ContainsKey("images_content_metadata"));
        Assert.Null(model.Items);
        Assert.True(model.RawData.ContainsKey("items"));
        Assert.Null(model.JobMetadata);
        Assert.True(model.RawData.ContainsKey("job_metadata"));
        Assert.Null(model.Markdown);
        Assert.True(model.RawData.ContainsKey("markdown"));
        Assert.Null(model.MarkdownFull);
        Assert.True(model.RawData.ContainsKey("markdown_full"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.RawParameters);
        Assert.True(model.RawData.ContainsKey("raw_parameters"));
        Assert.Null(model.ResultContentMetadata);
        Assert.True(model.RawData.ContainsKey("result_content_metadata"));
        Assert.Null(model.Text);
        Assert.True(model.RawData.ContainsKey("text"));
        Assert.Null(model.TextFull);
        Assert.True(model.RawData.ContainsKey("text_full"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::ParsingGetResponse
        {
            Job = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Status = Parsing::JobStatus.Cancelled,
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

            Forms = null,
            ImagesContentMetadata = null,
            Items = null,
            JobMetadata = null,
            Markdown = null,
            MarkdownFull = null,
            Metadata = null,
            RawParameters = null,
            ResultContentMetadata = null,
            Text = null,
            TextFull = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::ParsingGetResponse
        {
            Job = new()
            {
                ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
                Status = Parsing::JobStatus.Cancelled,
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
            Forms = new(
                [
                    new Parsing::FormsResultPage()
                    {
                        Forms =
                        [
                            new()
                            {
                                Json =
                                [
                                    new Parsing::FormField()
                                    {
                                        Field = Parsing::Field.Checkbox,
                                        ID = "id",
                                        Bbox =
                                        [
                                            new()
                                            {
                                                H = 0,
                                                W = 0,
                                                X = 0,
                                                Y = 0,
                                                Confidence = 0,
                                                EndIndex = 0,
                                                Label = "label",
                                                R = 0,
                                                StartIndex = 0,
                                            },
                                        ],
                                        IsEmpty = true,
                                        Label = "label",
                                        Type = Parsing::FormFieldType.Field,
                                        Value = "string",
                                        ValueItems =
                                        [
                                            new Parsing::FormSection()
                                            {
                                                Items =
                                                [
                                                    new Parsing::FormTable()
                                                    {
                                                        Rows =
                                                        [
                                                            ["string"],
                                                        ],
                                                        ID = "id",
                                                        Bbox =
                                                        [
                                                            new()
                                                            {
                                                                H = 0,
                                                                W = 0,
                                                                X = 0,
                                                                Y = 0,
                                                                Confidence = 0,
                                                                EndIndex = 0,
                                                                Label = "label",
                                                                R = 0,
                                                                StartIndex = 0,
                                                            },
                                                        ],
                                                        Columns = ["string"],
                                                        Label = "label",
                                                        Type = Parsing::FormTableType.Table,
                                                    },
                                                ],
                                                ID = "id",
                                                Label = "label",
                                                Type = Parsing::FormSectionType.Section,
                                            },
                                        ],
                                    },
                                ],
                                List = new()
                                {
                                    Items =
                                    [
                                        new Parsing::FormListTextItem()
                                        {
                                            Md = "md",
                                            Value = "value",
                                            Type = Parsing::FormListTextItemType.Text,
                                        },
                                    ],
                                    Md = "md",
                                    Ordered = true,
                                    Type = Parsing::FormListItemType.List,
                                },
                            },
                        ],
                        PageNumber = 0,
                        PageHeight = 0,
                        PageWidth = 0,
                    },
                ]
            ),
            ImagesContentMetadata = new()
            {
                Images =
                [
                    new()
                    {
                        Filename = "filename",
                        Index = 0,
                        Bbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                        Category = Parsing::Category.Embedded,
                        ContentType = "content_type",
                        PresignedUrl = "presigned_url",
                        SizeBytes = 0,
                    },
                ],
                TotalCount = 0,
            },
            Items = new(
                [
                    new Parsing::StructuredResultPage()
                    {
                        Items =
                        [
                            new Parsing::CodeItem()
                            {
                                Md = "md",
                                ValueValue = "value",
                                Bbox =
                                [
                                    new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                ],
                                Language = "language",
                                Type = Parsing::Type.Code,
                            },
                        ],
                        PageHeight = 0,
                        PageNumber = 0,
                        PageWidth = 0,
                        Revisions =
                        [
                            new()
                            {
                                Content = "content",
                                RevisionBbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                                Target = "target",
                                TargetBbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                                Type = Parsing::RevisionType.Comment,
                                Author = "author",
                                EndIndex = 0,
                                StartIndex = 0,
                                TargetSpans =
                                [
                                    new()
                                    {
                                        Target = "target",
                                        TargetBbox = new()
                                        {
                                            H = 0,
                                            W = 0,
                                            X = 0,
                                            Y = 0,
                                        },
                                        EndIndex = 0,
                                        StartIndex = 0,
                                    },
                                ],
                            },
                        ],
                    },
                ]
            ),
            JobMetadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Markdown = new(
                [
                    new Parsing::MarkdownResultPage()
                    {
                        Markdown = "markdown",
                        PageNumber = 0,
                        Footer = "footer",
                        Header = "header",
                    },
                ]
            ),
            MarkdownFull = "markdown_full",
            Metadata = new(
                [
                    new()
                    {
                        PageNumber = 0,
                        Confidence = 0,
                        CostOptimized = true,
                        OriginalOrientationAngle = 0,
                        PrintedPageNumber = "printed_page_number",
                        SlideSectionName = "slide_section_name",
                        SpeakerNotes = "speaker_notes",
                        TriggeredAutoMode = true,
                    },
                ]
            ),
            RawParameters = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            ResultContentMetadata = new Dictionary<string, Parsing::ResultContentMetadataItem>()
            {
                {
                    "foo",
                    new()
                    {
                        SizeBytes = 0,
                        Exists = true,
                        PresignedUrl = "presigned_url",
                    }
                },
            },
            Text = new([new() { PageNumber = 0, Text = "text" }]),
            TextFull = "text_full",
        };

        Parsing::ParsingGetResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JobTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::Job
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = Parsing::JobStatus.Cancelled,
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
        };

        string expectedID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        ApiEnum<string, Parsing::JobStatus> expectedStatus = Parsing::JobStatus.Cancelled;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        string expectedName = "Q4 Financial Report";
        string expectedTier = "fast";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Parsing::JobUsage expectedUsage = new() { Credits = 30 };
        Dictionary<string, string> expectedUserMetadata = new()
        {
            { "owner", "jerry" },
            { "team", "research" },
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedProjectID, model.ProjectID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedTier, model.Tier);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUsage, model.Usage);
        Assert.NotNull(model.UserMetadata);
        Assert.Equal(expectedUserMetadata.Count, model.UserMetadata.Count);
        foreach (var item in expectedUserMetadata)
        {
            Assert.True(model.UserMetadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.UserMetadata[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::Job
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = Parsing::JobStatus.Cancelled,
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Job>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::Job
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = Parsing::JobStatus.Cancelled,
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Job>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        string expectedProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee";
        ApiEnum<string, Parsing::JobStatus> expectedStatus = Parsing::JobStatus.Cancelled;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "error_message";
        string expectedName = "Q4 Financial Report";
        string expectedTier = "fast";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Parsing::JobUsage expectedUsage = new() { Credits = 30 };
        Dictionary<string, string> expectedUserMetadata = new()
        {
            { "owner", "jerry" },
            { "team", "research" },
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedProjectID, deserialized.ProjectID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedTier, deserialized.Tier);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUsage, deserialized.Usage);
        Assert.NotNull(deserialized.UserMetadata);
        Assert.Equal(expectedUserMetadata.Count, deserialized.UserMetadata.Count);
        foreach (var item in expectedUserMetadata)
        {
            Assert.True(deserialized.UserMetadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.UserMetadata[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::Job
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = Parsing::JobStatus.Cancelled,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::Job
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = Parsing::JobStatus.Cancelled,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Tier);
        Assert.False(model.RawData.ContainsKey("tier"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Usage);
        Assert.False(model.RawData.ContainsKey("usage"));
        Assert.Null(model.UserMetadata);
        Assert.False(model.RawData.ContainsKey("user_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::Job
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = Parsing::JobStatus.Cancelled,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::Job
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = Parsing::JobStatus.Cancelled,

            CreatedAt = null,
            ErrorMessage = null,
            Name = null,
            Tier = null,
            UpdatedAt = null,
            Usage = null,
            UserMetadata = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.True(model.RawData.ContainsKey("created_at"));
        Assert.Null(model.ErrorMessage);
        Assert.True(model.RawData.ContainsKey("error_message"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.Tier);
        Assert.True(model.RawData.ContainsKey("tier"));
        Assert.Null(model.UpdatedAt);
        Assert.True(model.RawData.ContainsKey("updated_at"));
        Assert.Null(model.Usage);
        Assert.True(model.RawData.ContainsKey("usage"));
        Assert.Null(model.UserMetadata);
        Assert.True(model.RawData.ContainsKey("user_metadata"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::Job
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = Parsing::JobStatus.Cancelled,

            CreatedAt = null,
            ErrorMessage = null,
            Name = null,
            Tier = null,
            UpdatedAt = null,
            Usage = null,
            UserMetadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::Job
        {
            ID = "pjb-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ProjectID = "prj-aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            Status = Parsing::JobStatus.Cancelled,
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
        };

        Parsing::Job copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JobStatusTest : TestBase
{
    [Theory]
    [InlineData(Parsing::JobStatus.Cancelled)]
    [InlineData(Parsing::JobStatus.Completed)]
    [InlineData(Parsing::JobStatus.Failed)]
    [InlineData(Parsing::JobStatus.Pending)]
    [InlineData(Parsing::JobStatus.Running)]
    public void Validation_Works(Parsing::JobStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::JobStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::JobStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Parsing::JobStatus.Cancelled)]
    [InlineData(Parsing::JobStatus.Completed)]
    [InlineData(Parsing::JobStatus.Failed)]
    [InlineData(Parsing::JobStatus.Pending)]
    [InlineData(Parsing::JobStatus.Running)]
    public void SerializationRoundtrip_Works(Parsing::JobStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::JobStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::JobStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::JobStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::JobStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class JobUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::JobUsage { Credits = 30 };

        double expectedCredits = 30;

        Assert.Equal(expectedCredits, model.Credits);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::JobUsage { Credits = 30 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::JobUsage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::JobUsage { Credits = 30 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::JobUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedCredits = 30;

        Assert.Equal(expectedCredits, deserialized.Credits);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::JobUsage { Credits = 30 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::JobUsage { };

        Assert.Null(model.Credits);
        Assert.False(model.RawData.ContainsKey("credits"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::JobUsage { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::JobUsage { Credits = null };

        Assert.Null(model.Credits);
        Assert.True(model.RawData.ContainsKey("credits"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::JobUsage { Credits = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::JobUsage { Credits = 30 };

        Parsing::JobUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ParsingGetResponseFormsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::ParsingGetResponseForms
        {
            Pages =
            [
                new Parsing::FormsResultPage()
                {
                    Forms =
                    [
                        new()
                        {
                            Json =
                            [
                                new Parsing::FormField()
                                {
                                    Field = Parsing::Field.Checkbox,
                                    ID = "id",
                                    Bbox =
                                    [
                                        new()
                                        {
                                            H = 0,
                                            W = 0,
                                            X = 0,
                                            Y = 0,
                                            Confidence = 0,
                                            EndIndex = 0,
                                            Label = "label",
                                            R = 0,
                                            StartIndex = 0,
                                        },
                                    ],
                                    IsEmpty = true,
                                    Label = "label",
                                    Type = Parsing::FormFieldType.Field,
                                    Value = "string",
                                    ValueItems =
                                    [
                                        new Parsing::FormSection()
                                        {
                                            Items =
                                            [
                                                new Parsing::FormTable()
                                                {
                                                    Rows =
                                                    [
                                                        ["string"],
                                                    ],
                                                    ID = "id",
                                                    Bbox =
                                                    [
                                                        new()
                                                        {
                                                            H = 0,
                                                            W = 0,
                                                            X = 0,
                                                            Y = 0,
                                                            Confidence = 0,
                                                            EndIndex = 0,
                                                            Label = "label",
                                                            R = 0,
                                                            StartIndex = 0,
                                                        },
                                                    ],
                                                    Columns = ["string"],
                                                    Label = "label",
                                                    Type = Parsing::FormTableType.Table,
                                                },
                                            ],
                                            ID = "id",
                                            Label = "label",
                                            Type = Parsing::FormSectionType.Section,
                                        },
                                    ],
                                },
                            ],
                            List = new()
                            {
                                Items =
                                [
                                    new Parsing::FormListTextItem()
                                    {
                                        Md = "md",
                                        Value = "value",
                                        Type = Parsing::FormListTextItemType.Text,
                                    },
                                ],
                                Md = "md",
                                Ordered = true,
                                Type = Parsing::FormListItemType.List,
                            },
                        },
                    ],
                    PageNumber = 0,
                    PageHeight = 0,
                    PageWidth = 0,
                },
            ],
        };

        List<Parsing::Page> expectedPages =
        [
            new Parsing::FormsResultPage()
            {
                Forms =
                [
                    new()
                    {
                        Json =
                        [
                            new Parsing::FormField()
                            {
                                Field = Parsing::Field.Checkbox,
                                ID = "id",
                                Bbox =
                                [
                                    new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                ],
                                IsEmpty = true,
                                Label = "label",
                                Type = Parsing::FormFieldType.Field,
                                Value = "string",
                                ValueItems =
                                [
                                    new Parsing::FormSection()
                                    {
                                        Items =
                                        [
                                            new Parsing::FormTable()
                                            {
                                                Rows =
                                                [
                                                    ["string"],
                                                ],
                                                ID = "id",
                                                Bbox =
                                                [
                                                    new()
                                                    {
                                                        H = 0,
                                                        W = 0,
                                                        X = 0,
                                                        Y = 0,
                                                        Confidence = 0,
                                                        EndIndex = 0,
                                                        Label = "label",
                                                        R = 0,
                                                        StartIndex = 0,
                                                    },
                                                ],
                                                Columns = ["string"],
                                                Label = "label",
                                                Type = Parsing::FormTableType.Table,
                                            },
                                        ],
                                        ID = "id",
                                        Label = "label",
                                        Type = Parsing::FormSectionType.Section,
                                    },
                                ],
                            },
                        ],
                        List = new()
                        {
                            Items =
                            [
                                new Parsing::FormListTextItem()
                                {
                                    Md = "md",
                                    Value = "value",
                                    Type = Parsing::FormListTextItemType.Text,
                                },
                            ],
                            Md = "md",
                            Ordered = true,
                            Type = Parsing::FormListItemType.List,
                        },
                    },
                ],
                PageNumber = 0,
                PageHeight = 0,
                PageWidth = 0,
            },
        ];

        Assert.Equal(expectedPages.Count, model.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], model.Pages[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::ParsingGetResponseForms
        {
            Pages =
            [
                new Parsing::FormsResultPage()
                {
                    Forms =
                    [
                        new()
                        {
                            Json =
                            [
                                new Parsing::FormField()
                                {
                                    Field = Parsing::Field.Checkbox,
                                    ID = "id",
                                    Bbox =
                                    [
                                        new()
                                        {
                                            H = 0,
                                            W = 0,
                                            X = 0,
                                            Y = 0,
                                            Confidence = 0,
                                            EndIndex = 0,
                                            Label = "label",
                                            R = 0,
                                            StartIndex = 0,
                                        },
                                    ],
                                    IsEmpty = true,
                                    Label = "label",
                                    Type = Parsing::FormFieldType.Field,
                                    Value = "string",
                                    ValueItems =
                                    [
                                        new Parsing::FormSection()
                                        {
                                            Items =
                                            [
                                                new Parsing::FormTable()
                                                {
                                                    Rows =
                                                    [
                                                        ["string"],
                                                    ],
                                                    ID = "id",
                                                    Bbox =
                                                    [
                                                        new()
                                                        {
                                                            H = 0,
                                                            W = 0,
                                                            X = 0,
                                                            Y = 0,
                                                            Confidence = 0,
                                                            EndIndex = 0,
                                                            Label = "label",
                                                            R = 0,
                                                            StartIndex = 0,
                                                        },
                                                    ],
                                                    Columns = ["string"],
                                                    Label = "label",
                                                    Type = Parsing::FormTableType.Table,
                                                },
                                            ],
                                            ID = "id",
                                            Label = "label",
                                            Type = Parsing::FormSectionType.Section,
                                        },
                                    ],
                                },
                            ],
                            List = new()
                            {
                                Items =
                                [
                                    new Parsing::FormListTextItem()
                                    {
                                        Md = "md",
                                        Value = "value",
                                        Type = Parsing::FormListTextItemType.Text,
                                    },
                                ],
                                Md = "md",
                                Ordered = true,
                                Type = Parsing::FormListItemType.List,
                            },
                        },
                    ],
                    PageNumber = 0,
                    PageHeight = 0,
                    PageWidth = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ParsingGetResponseForms>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::ParsingGetResponseForms
        {
            Pages =
            [
                new Parsing::FormsResultPage()
                {
                    Forms =
                    [
                        new()
                        {
                            Json =
                            [
                                new Parsing::FormField()
                                {
                                    Field = Parsing::Field.Checkbox,
                                    ID = "id",
                                    Bbox =
                                    [
                                        new()
                                        {
                                            H = 0,
                                            W = 0,
                                            X = 0,
                                            Y = 0,
                                            Confidence = 0,
                                            EndIndex = 0,
                                            Label = "label",
                                            R = 0,
                                            StartIndex = 0,
                                        },
                                    ],
                                    IsEmpty = true,
                                    Label = "label",
                                    Type = Parsing::FormFieldType.Field,
                                    Value = "string",
                                    ValueItems =
                                    [
                                        new Parsing::FormSection()
                                        {
                                            Items =
                                            [
                                                new Parsing::FormTable()
                                                {
                                                    Rows =
                                                    [
                                                        ["string"],
                                                    ],
                                                    ID = "id",
                                                    Bbox =
                                                    [
                                                        new()
                                                        {
                                                            H = 0,
                                                            W = 0,
                                                            X = 0,
                                                            Y = 0,
                                                            Confidence = 0,
                                                            EndIndex = 0,
                                                            Label = "label",
                                                            R = 0,
                                                            StartIndex = 0,
                                                        },
                                                    ],
                                                    Columns = ["string"],
                                                    Label = "label",
                                                    Type = Parsing::FormTableType.Table,
                                                },
                                            ],
                                            ID = "id",
                                            Label = "label",
                                            Type = Parsing::FormSectionType.Section,
                                        },
                                    ],
                                },
                            ],
                            List = new()
                            {
                                Items =
                                [
                                    new Parsing::FormListTextItem()
                                    {
                                        Md = "md",
                                        Value = "value",
                                        Type = Parsing::FormListTextItemType.Text,
                                    },
                                ],
                                Md = "md",
                                Ordered = true,
                                Type = Parsing::FormListItemType.List,
                            },
                        },
                    ],
                    PageNumber = 0,
                    PageHeight = 0,
                    PageWidth = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ParsingGetResponseForms>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Parsing::Page> expectedPages =
        [
            new Parsing::FormsResultPage()
            {
                Forms =
                [
                    new()
                    {
                        Json =
                        [
                            new Parsing::FormField()
                            {
                                Field = Parsing::Field.Checkbox,
                                ID = "id",
                                Bbox =
                                [
                                    new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                        Confidence = 0,
                                        EndIndex = 0,
                                        Label = "label",
                                        R = 0,
                                        StartIndex = 0,
                                    },
                                ],
                                IsEmpty = true,
                                Label = "label",
                                Type = Parsing::FormFieldType.Field,
                                Value = "string",
                                ValueItems =
                                [
                                    new Parsing::FormSection()
                                    {
                                        Items =
                                        [
                                            new Parsing::FormTable()
                                            {
                                                Rows =
                                                [
                                                    ["string"],
                                                ],
                                                ID = "id",
                                                Bbox =
                                                [
                                                    new()
                                                    {
                                                        H = 0,
                                                        W = 0,
                                                        X = 0,
                                                        Y = 0,
                                                        Confidence = 0,
                                                        EndIndex = 0,
                                                        Label = "label",
                                                        R = 0,
                                                        StartIndex = 0,
                                                    },
                                                ],
                                                Columns = ["string"],
                                                Label = "label",
                                                Type = Parsing::FormTableType.Table,
                                            },
                                        ],
                                        ID = "id",
                                        Label = "label",
                                        Type = Parsing::FormSectionType.Section,
                                    },
                                ],
                            },
                        ],
                        List = new()
                        {
                            Items =
                            [
                                new Parsing::FormListTextItem()
                                {
                                    Md = "md",
                                    Value = "value",
                                    Type = Parsing::FormListTextItemType.Text,
                                },
                            ],
                            Md = "md",
                            Ordered = true,
                            Type = Parsing::FormListItemType.List,
                        },
                    },
                ],
                PageNumber = 0,
                PageHeight = 0,
                PageWidth = 0,
            },
        ];

        Assert.Equal(expectedPages.Count, deserialized.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], deserialized.Pages[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::ParsingGetResponseForms
        {
            Pages =
            [
                new Parsing::FormsResultPage()
                {
                    Forms =
                    [
                        new()
                        {
                            Json =
                            [
                                new Parsing::FormField()
                                {
                                    Field = Parsing::Field.Checkbox,
                                    ID = "id",
                                    Bbox =
                                    [
                                        new()
                                        {
                                            H = 0,
                                            W = 0,
                                            X = 0,
                                            Y = 0,
                                            Confidence = 0,
                                            EndIndex = 0,
                                            Label = "label",
                                            R = 0,
                                            StartIndex = 0,
                                        },
                                    ],
                                    IsEmpty = true,
                                    Label = "label",
                                    Type = Parsing::FormFieldType.Field,
                                    Value = "string",
                                    ValueItems =
                                    [
                                        new Parsing::FormSection()
                                        {
                                            Items =
                                            [
                                                new Parsing::FormTable()
                                                {
                                                    Rows =
                                                    [
                                                        ["string"],
                                                    ],
                                                    ID = "id",
                                                    Bbox =
                                                    [
                                                        new()
                                                        {
                                                            H = 0,
                                                            W = 0,
                                                            X = 0,
                                                            Y = 0,
                                                            Confidence = 0,
                                                            EndIndex = 0,
                                                            Label = "label",
                                                            R = 0,
                                                            StartIndex = 0,
                                                        },
                                                    ],
                                                    Columns = ["string"],
                                                    Label = "label",
                                                    Type = Parsing::FormTableType.Table,
                                                },
                                            ],
                                            ID = "id",
                                            Label = "label",
                                            Type = Parsing::FormSectionType.Section,
                                        },
                                    ],
                                },
                            ],
                            List = new()
                            {
                                Items =
                                [
                                    new Parsing::FormListTextItem()
                                    {
                                        Md = "md",
                                        Value = "value",
                                        Type = Parsing::FormListTextItemType.Text,
                                    },
                                ],
                                Md = "md",
                                Ordered = true,
                                Type = Parsing::FormListItemType.List,
                            },
                        },
                    ],
                    PageNumber = 0,
                    PageHeight = 0,
                    PageWidth = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::ParsingGetResponseForms
        {
            Pages =
            [
                new Parsing::FormsResultPage()
                {
                    Forms =
                    [
                        new()
                        {
                            Json =
                            [
                                new Parsing::FormField()
                                {
                                    Field = Parsing::Field.Checkbox,
                                    ID = "id",
                                    Bbox =
                                    [
                                        new()
                                        {
                                            H = 0,
                                            W = 0,
                                            X = 0,
                                            Y = 0,
                                            Confidence = 0,
                                            EndIndex = 0,
                                            Label = "label",
                                            R = 0,
                                            StartIndex = 0,
                                        },
                                    ],
                                    IsEmpty = true,
                                    Label = "label",
                                    Type = Parsing::FormFieldType.Field,
                                    Value = "string",
                                    ValueItems =
                                    [
                                        new Parsing::FormSection()
                                        {
                                            Items =
                                            [
                                                new Parsing::FormTable()
                                                {
                                                    Rows =
                                                    [
                                                        ["string"],
                                                    ],
                                                    ID = "id",
                                                    Bbox =
                                                    [
                                                        new()
                                                        {
                                                            H = 0,
                                                            W = 0,
                                                            X = 0,
                                                            Y = 0,
                                                            Confidence = 0,
                                                            EndIndex = 0,
                                                            Label = "label",
                                                            R = 0,
                                                            StartIndex = 0,
                                                        },
                                                    ],
                                                    Columns = ["string"],
                                                    Label = "label",
                                                    Type = Parsing::FormTableType.Table,
                                                },
                                            ],
                                            ID = "id",
                                            Label = "label",
                                            Type = Parsing::FormSectionType.Section,
                                        },
                                    ],
                                },
                            ],
                            List = new()
                            {
                                Items =
                                [
                                    new Parsing::FormListTextItem()
                                    {
                                        Md = "md",
                                        Value = "value",
                                        Type = Parsing::FormListTextItemType.Text,
                                    },
                                ],
                                Md = "md",
                                Ordered = true,
                                Type = Parsing::FormListItemType.List,
                            },
                        },
                    ],
                    PageNumber = 0,
                    PageHeight = 0,
                    PageWidth = 0,
                },
            ],
        };

        Parsing::ParsingGetResponseForms copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PageTest : TestBase
{
    [Fact]
    public void FormsResultValidationWorks()
    {
        Parsing::Page value = new Parsing::FormsResultPage()
        {
            Forms =
            [
                new()
                {
                    Json =
                    [
                        new Parsing::FormField()
                        {
                            Field = Parsing::Field.Checkbox,
                            ID = "id",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            IsEmpty = true,
                            Label = "label",
                            Type = Parsing::FormFieldType.Field,
                            Value = "string",
                            ValueItems =
                            [
                                new Parsing::FormSection()
                                {
                                    Items =
                                    [
                                        new Parsing::FormTable()
                                        {
                                            Rows =
                                            [
                                                ["string"],
                                            ],
                                            ID = "id",
                                            Bbox =
                                            [
                                                new()
                                                {
                                                    H = 0,
                                                    W = 0,
                                                    X = 0,
                                                    Y = 0,
                                                    Confidence = 0,
                                                    EndIndex = 0,
                                                    Label = "label",
                                                    R = 0,
                                                    StartIndex = 0,
                                                },
                                            ],
                                            Columns = ["string"],
                                            Label = "label",
                                            Type = Parsing::FormTableType.Table,
                                        },
                                    ],
                                    ID = "id",
                                    Label = "label",
                                    Type = Parsing::FormSectionType.Section,
                                },
                            ],
                        },
                    ],
                    List = new()
                    {
                        Items =
                        [
                            new Parsing::FormListTextItem()
                            {
                                Md = "md",
                                Value = "value",
                                Type = Parsing::FormListTextItemType.Text,
                            },
                        ],
                        Md = "md",
                        Ordered = true,
                        Type = Parsing::FormListItemType.List,
                    },
                },
            ],
            PageNumber = 0,
            PageHeight = 0,
            PageWidth = 0,
        };
        value.Validate();
    }

    [Fact]
    public void FailedFormsValidationWorks()
    {
        Parsing::Page value = new Parsing::FailedFormsPage() { Error = "error", PageNumber = 0 };
        value.Validate();
    }

    [Fact]
    public void FormsResultSerializationRoundtripWorks()
    {
        Parsing::Page value = new Parsing::FormsResultPage()
        {
            Forms =
            [
                new()
                {
                    Json =
                    [
                        new Parsing::FormField()
                        {
                            Field = Parsing::Field.Checkbox,
                            ID = "id",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            IsEmpty = true,
                            Label = "label",
                            Type = Parsing::FormFieldType.Field,
                            Value = "string",
                            ValueItems =
                            [
                                new Parsing::FormSection()
                                {
                                    Items =
                                    [
                                        new Parsing::FormTable()
                                        {
                                            Rows =
                                            [
                                                ["string"],
                                            ],
                                            ID = "id",
                                            Bbox =
                                            [
                                                new()
                                                {
                                                    H = 0,
                                                    W = 0,
                                                    X = 0,
                                                    Y = 0,
                                                    Confidence = 0,
                                                    EndIndex = 0,
                                                    Label = "label",
                                                    R = 0,
                                                    StartIndex = 0,
                                                },
                                            ],
                                            Columns = ["string"],
                                            Label = "label",
                                            Type = Parsing::FormTableType.Table,
                                        },
                                    ],
                                    ID = "id",
                                    Label = "label",
                                    Type = Parsing::FormSectionType.Section,
                                },
                            ],
                        },
                    ],
                    List = new()
                    {
                        Items =
                        [
                            new Parsing::FormListTextItem()
                            {
                                Md = "md",
                                Value = "value",
                                Type = Parsing::FormListTextItemType.Text,
                            },
                        ],
                        Md = "md",
                        Ordered = true,
                        Type = Parsing::FormListItemType.List,
                    },
                },
            ],
            PageNumber = 0,
            PageHeight = 0,
            PageWidth = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Page>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FailedFormsSerializationRoundtripWorks()
    {
        Parsing::Page value = new Parsing::FailedFormsPage() { Error = "error", PageNumber = 0 };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Page>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FormsResultPageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::FormsResultPage
        {
            Forms =
            [
                new()
                {
                    Json =
                    [
                        new Parsing::FormField()
                        {
                            Field = Parsing::Field.Checkbox,
                            ID = "id",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            IsEmpty = true,
                            Label = "label",
                            Type = Parsing::FormFieldType.Field,
                            Value = "string",
                            ValueItems =
                            [
                                new Parsing::FormSection()
                                {
                                    Items =
                                    [
                                        new Parsing::FormTable()
                                        {
                                            Rows =
                                            [
                                                ["string"],
                                            ],
                                            ID = "id",
                                            Bbox =
                                            [
                                                new()
                                                {
                                                    H = 0,
                                                    W = 0,
                                                    X = 0,
                                                    Y = 0,
                                                    Confidence = 0,
                                                    EndIndex = 0,
                                                    Label = "label",
                                                    R = 0,
                                                    StartIndex = 0,
                                                },
                                            ],
                                            Columns = ["string"],
                                            Label = "label",
                                            Type = Parsing::FormTableType.Table,
                                        },
                                    ],
                                    ID = "id",
                                    Label = "label",
                                    Type = Parsing::FormSectionType.Section,
                                },
                            ],
                        },
                    ],
                    List = new()
                    {
                        Items =
                        [
                            new Parsing::FormListTextItem()
                            {
                                Md = "md",
                                Value = "value",
                                Type = Parsing::FormListTextItemType.Text,
                            },
                        ],
                        Md = "md",
                        Ordered = true,
                        Type = Parsing::FormListItemType.List,
                    },
                },
            ],
            PageNumber = 0,
            PageHeight = 0,
            PageWidth = 0,
        };

        List<Parsing::Form> expectedForms =
        [
            new()
            {
                Json =
                [
                    new Parsing::FormField()
                    {
                        Field = Parsing::Field.Checkbox,
                        ID = "id",
                        Bbox =
                        [
                            new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                        ],
                        IsEmpty = true,
                        Label = "label",
                        Type = Parsing::FormFieldType.Field,
                        Value = "string",
                        ValueItems =
                        [
                            new Parsing::FormSection()
                            {
                                Items =
                                [
                                    new Parsing::FormTable()
                                    {
                                        Rows =
                                        [
                                            ["string"],
                                        ],
                                        ID = "id",
                                        Bbox =
                                        [
                                            new()
                                            {
                                                H = 0,
                                                W = 0,
                                                X = 0,
                                                Y = 0,
                                                Confidence = 0,
                                                EndIndex = 0,
                                                Label = "label",
                                                R = 0,
                                                StartIndex = 0,
                                            },
                                        ],
                                        Columns = ["string"],
                                        Label = "label",
                                        Type = Parsing::FormTableType.Table,
                                    },
                                ],
                                ID = "id",
                                Label = "label",
                                Type = Parsing::FormSectionType.Section,
                            },
                        ],
                    },
                ],
                List = new()
                {
                    Items =
                    [
                        new Parsing::FormListTextItem()
                        {
                            Md = "md",
                            Value = "value",
                            Type = Parsing::FormListTextItemType.Text,
                        },
                    ],
                    Md = "md",
                    Ordered = true,
                    Type = Parsing::FormListItemType.List,
                },
            },
        ];
        long expectedPageNumber = 0;
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);
        double expectedPageHeight = 0;
        double expectedPageWidth = 0;

        Assert.Equal(expectedForms.Count, model.Forms.Count);
        for (int i = 0; i < expectedForms.Count; i++)
        {
            Assert.Equal(expectedForms[i], model.Forms[i]);
        }
        Assert.Equal(expectedPageNumber, model.PageNumber);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
        Assert.Equal(expectedPageHeight, model.PageHeight);
        Assert.Equal(expectedPageWidth, model.PageWidth);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::FormsResultPage
        {
            Forms =
            [
                new()
                {
                    Json =
                    [
                        new Parsing::FormField()
                        {
                            Field = Parsing::Field.Checkbox,
                            ID = "id",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            IsEmpty = true,
                            Label = "label",
                            Type = Parsing::FormFieldType.Field,
                            Value = "string",
                            ValueItems =
                            [
                                new Parsing::FormSection()
                                {
                                    Items =
                                    [
                                        new Parsing::FormTable()
                                        {
                                            Rows =
                                            [
                                                ["string"],
                                            ],
                                            ID = "id",
                                            Bbox =
                                            [
                                                new()
                                                {
                                                    H = 0,
                                                    W = 0,
                                                    X = 0,
                                                    Y = 0,
                                                    Confidence = 0,
                                                    EndIndex = 0,
                                                    Label = "label",
                                                    R = 0,
                                                    StartIndex = 0,
                                                },
                                            ],
                                            Columns = ["string"],
                                            Label = "label",
                                            Type = Parsing::FormTableType.Table,
                                        },
                                    ],
                                    ID = "id",
                                    Label = "label",
                                    Type = Parsing::FormSectionType.Section,
                                },
                            ],
                        },
                    ],
                    List = new()
                    {
                        Items =
                        [
                            new Parsing::FormListTextItem()
                            {
                                Md = "md",
                                Value = "value",
                                Type = Parsing::FormListTextItemType.Text,
                            },
                        ],
                        Md = "md",
                        Ordered = true,
                        Type = Parsing::FormListItemType.List,
                    },
                },
            ],
            PageNumber = 0,
            PageHeight = 0,
            PageWidth = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::FormsResultPage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::FormsResultPage
        {
            Forms =
            [
                new()
                {
                    Json =
                    [
                        new Parsing::FormField()
                        {
                            Field = Parsing::Field.Checkbox,
                            ID = "id",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            IsEmpty = true,
                            Label = "label",
                            Type = Parsing::FormFieldType.Field,
                            Value = "string",
                            ValueItems =
                            [
                                new Parsing::FormSection()
                                {
                                    Items =
                                    [
                                        new Parsing::FormTable()
                                        {
                                            Rows =
                                            [
                                                ["string"],
                                            ],
                                            ID = "id",
                                            Bbox =
                                            [
                                                new()
                                                {
                                                    H = 0,
                                                    W = 0,
                                                    X = 0,
                                                    Y = 0,
                                                    Confidence = 0,
                                                    EndIndex = 0,
                                                    Label = "label",
                                                    R = 0,
                                                    StartIndex = 0,
                                                },
                                            ],
                                            Columns = ["string"],
                                            Label = "label",
                                            Type = Parsing::FormTableType.Table,
                                        },
                                    ],
                                    ID = "id",
                                    Label = "label",
                                    Type = Parsing::FormSectionType.Section,
                                },
                            ],
                        },
                    ],
                    List = new()
                    {
                        Items =
                        [
                            new Parsing::FormListTextItem()
                            {
                                Md = "md",
                                Value = "value",
                                Type = Parsing::FormListTextItemType.Text,
                            },
                        ],
                        Md = "md",
                        Ordered = true,
                        Type = Parsing::FormListItemType.List,
                    },
                },
            ],
            PageNumber = 0,
            PageHeight = 0,
            PageWidth = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::FormsResultPage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Parsing::Form> expectedForms =
        [
            new()
            {
                Json =
                [
                    new Parsing::FormField()
                    {
                        Field = Parsing::Field.Checkbox,
                        ID = "id",
                        Bbox =
                        [
                            new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                        ],
                        IsEmpty = true,
                        Label = "label",
                        Type = Parsing::FormFieldType.Field,
                        Value = "string",
                        ValueItems =
                        [
                            new Parsing::FormSection()
                            {
                                Items =
                                [
                                    new Parsing::FormTable()
                                    {
                                        Rows =
                                        [
                                            ["string"],
                                        ],
                                        ID = "id",
                                        Bbox =
                                        [
                                            new()
                                            {
                                                H = 0,
                                                W = 0,
                                                X = 0,
                                                Y = 0,
                                                Confidence = 0,
                                                EndIndex = 0,
                                                Label = "label",
                                                R = 0,
                                                StartIndex = 0,
                                            },
                                        ],
                                        Columns = ["string"],
                                        Label = "label",
                                        Type = Parsing::FormTableType.Table,
                                    },
                                ],
                                ID = "id",
                                Label = "label",
                                Type = Parsing::FormSectionType.Section,
                            },
                        ],
                    },
                ],
                List = new()
                {
                    Items =
                    [
                        new Parsing::FormListTextItem()
                        {
                            Md = "md",
                            Value = "value",
                            Type = Parsing::FormListTextItemType.Text,
                        },
                    ],
                    Md = "md",
                    Ordered = true,
                    Type = Parsing::FormListItemType.List,
                },
            },
        ];
        long expectedPageNumber = 0;
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);
        double expectedPageHeight = 0;
        double expectedPageWidth = 0;

        Assert.Equal(expectedForms.Count, deserialized.Forms.Count);
        for (int i = 0; i < expectedForms.Count; i++)
        {
            Assert.Equal(expectedForms[i], deserialized.Forms[i]);
        }
        Assert.Equal(expectedPageNumber, deserialized.PageNumber);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
        Assert.Equal(expectedPageHeight, deserialized.PageHeight);
        Assert.Equal(expectedPageWidth, deserialized.PageWidth);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::FormsResultPage
        {
            Forms =
            [
                new()
                {
                    Json =
                    [
                        new Parsing::FormField()
                        {
                            Field = Parsing::Field.Checkbox,
                            ID = "id",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            IsEmpty = true,
                            Label = "label",
                            Type = Parsing::FormFieldType.Field,
                            Value = "string",
                            ValueItems =
                            [
                                new Parsing::FormSection()
                                {
                                    Items =
                                    [
                                        new Parsing::FormTable()
                                        {
                                            Rows =
                                            [
                                                ["string"],
                                            ],
                                            ID = "id",
                                            Bbox =
                                            [
                                                new()
                                                {
                                                    H = 0,
                                                    W = 0,
                                                    X = 0,
                                                    Y = 0,
                                                    Confidence = 0,
                                                    EndIndex = 0,
                                                    Label = "label",
                                                    R = 0,
                                                    StartIndex = 0,
                                                },
                                            ],
                                            Columns = ["string"],
                                            Label = "label",
                                            Type = Parsing::FormTableType.Table,
                                        },
                                    ],
                                    ID = "id",
                                    Label = "label",
                                    Type = Parsing::FormSectionType.Section,
                                },
                            ],
                        },
                    ],
                    List = new()
                    {
                        Items =
                        [
                            new Parsing::FormListTextItem()
                            {
                                Md = "md",
                                Value = "value",
                                Type = Parsing::FormListTextItemType.Text,
                            },
                        ],
                        Md = "md",
                        Ordered = true,
                        Type = Parsing::FormListItemType.List,
                    },
                },
            ],
            PageNumber = 0,
            PageHeight = 0,
            PageWidth = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::FormsResultPage
        {
            Forms =
            [
                new()
                {
                    Json =
                    [
                        new Parsing::FormField()
                        {
                            Field = Parsing::Field.Checkbox,
                            ID = "id",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            IsEmpty = true,
                            Label = "label",
                            Type = Parsing::FormFieldType.Field,
                            Value = "string",
                            ValueItems =
                            [
                                new Parsing::FormSection()
                                {
                                    Items =
                                    [
                                        new Parsing::FormTable()
                                        {
                                            Rows =
                                            [
                                                ["string"],
                                            ],
                                            ID = "id",
                                            Bbox =
                                            [
                                                new()
                                                {
                                                    H = 0,
                                                    W = 0,
                                                    X = 0,
                                                    Y = 0,
                                                    Confidence = 0,
                                                    EndIndex = 0,
                                                    Label = "label",
                                                    R = 0,
                                                    StartIndex = 0,
                                                },
                                            ],
                                            Columns = ["string"],
                                            Label = "label",
                                            Type = Parsing::FormTableType.Table,
                                        },
                                    ],
                                    ID = "id",
                                    Label = "label",
                                    Type = Parsing::FormSectionType.Section,
                                },
                            ],
                        },
                    ],
                    List = new()
                    {
                        Items =
                        [
                            new Parsing::FormListTextItem()
                            {
                                Md = "md",
                                Value = "value",
                                Type = Parsing::FormListTextItemType.Text,
                            },
                        ],
                        Md = "md",
                        Ordered = true,
                        Type = Parsing::FormListItemType.List,
                    },
                },
            ],
            PageNumber = 0,
        };

        Assert.Null(model.PageHeight);
        Assert.False(model.RawData.ContainsKey("page_height"));
        Assert.Null(model.PageWidth);
        Assert.False(model.RawData.ContainsKey("page_width"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::FormsResultPage
        {
            Forms =
            [
                new()
                {
                    Json =
                    [
                        new Parsing::FormField()
                        {
                            Field = Parsing::Field.Checkbox,
                            ID = "id",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            IsEmpty = true,
                            Label = "label",
                            Type = Parsing::FormFieldType.Field,
                            Value = "string",
                            ValueItems =
                            [
                                new Parsing::FormSection()
                                {
                                    Items =
                                    [
                                        new Parsing::FormTable()
                                        {
                                            Rows =
                                            [
                                                ["string"],
                                            ],
                                            ID = "id",
                                            Bbox =
                                            [
                                                new()
                                                {
                                                    H = 0,
                                                    W = 0,
                                                    X = 0,
                                                    Y = 0,
                                                    Confidence = 0,
                                                    EndIndex = 0,
                                                    Label = "label",
                                                    R = 0,
                                                    StartIndex = 0,
                                                },
                                            ],
                                            Columns = ["string"],
                                            Label = "label",
                                            Type = Parsing::FormTableType.Table,
                                        },
                                    ],
                                    ID = "id",
                                    Label = "label",
                                    Type = Parsing::FormSectionType.Section,
                                },
                            ],
                        },
                    ],
                    List = new()
                    {
                        Items =
                        [
                            new Parsing::FormListTextItem()
                            {
                                Md = "md",
                                Value = "value",
                                Type = Parsing::FormListTextItemType.Text,
                            },
                        ],
                        Md = "md",
                        Ordered = true,
                        Type = Parsing::FormListItemType.List,
                    },
                },
            ],
            PageNumber = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::FormsResultPage
        {
            Forms =
            [
                new()
                {
                    Json =
                    [
                        new Parsing::FormField()
                        {
                            Field = Parsing::Field.Checkbox,
                            ID = "id",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            IsEmpty = true,
                            Label = "label",
                            Type = Parsing::FormFieldType.Field,
                            Value = "string",
                            ValueItems =
                            [
                                new Parsing::FormSection()
                                {
                                    Items =
                                    [
                                        new Parsing::FormTable()
                                        {
                                            Rows =
                                            [
                                                ["string"],
                                            ],
                                            ID = "id",
                                            Bbox =
                                            [
                                                new()
                                                {
                                                    H = 0,
                                                    W = 0,
                                                    X = 0,
                                                    Y = 0,
                                                    Confidence = 0,
                                                    EndIndex = 0,
                                                    Label = "label",
                                                    R = 0,
                                                    StartIndex = 0,
                                                },
                                            ],
                                            Columns = ["string"],
                                            Label = "label",
                                            Type = Parsing::FormTableType.Table,
                                        },
                                    ],
                                    ID = "id",
                                    Label = "label",
                                    Type = Parsing::FormSectionType.Section,
                                },
                            ],
                        },
                    ],
                    List = new()
                    {
                        Items =
                        [
                            new Parsing::FormListTextItem()
                            {
                                Md = "md",
                                Value = "value",
                                Type = Parsing::FormListTextItemType.Text,
                            },
                        ],
                        Md = "md",
                        Ordered = true,
                        Type = Parsing::FormListItemType.List,
                    },
                },
            ],
            PageNumber = 0,

            PageHeight = null,
            PageWidth = null,
        };

        Assert.Null(model.PageHeight);
        Assert.True(model.RawData.ContainsKey("page_height"));
        Assert.Null(model.PageWidth);
        Assert.True(model.RawData.ContainsKey("page_width"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::FormsResultPage
        {
            Forms =
            [
                new()
                {
                    Json =
                    [
                        new Parsing::FormField()
                        {
                            Field = Parsing::Field.Checkbox,
                            ID = "id",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            IsEmpty = true,
                            Label = "label",
                            Type = Parsing::FormFieldType.Field,
                            Value = "string",
                            ValueItems =
                            [
                                new Parsing::FormSection()
                                {
                                    Items =
                                    [
                                        new Parsing::FormTable()
                                        {
                                            Rows =
                                            [
                                                ["string"],
                                            ],
                                            ID = "id",
                                            Bbox =
                                            [
                                                new()
                                                {
                                                    H = 0,
                                                    W = 0,
                                                    X = 0,
                                                    Y = 0,
                                                    Confidence = 0,
                                                    EndIndex = 0,
                                                    Label = "label",
                                                    R = 0,
                                                    StartIndex = 0,
                                                },
                                            ],
                                            Columns = ["string"],
                                            Label = "label",
                                            Type = Parsing::FormTableType.Table,
                                        },
                                    ],
                                    ID = "id",
                                    Label = "label",
                                    Type = Parsing::FormSectionType.Section,
                                },
                            ],
                        },
                    ],
                    List = new()
                    {
                        Items =
                        [
                            new Parsing::FormListTextItem()
                            {
                                Md = "md",
                                Value = "value",
                                Type = Parsing::FormListTextItemType.Text,
                            },
                        ],
                        Md = "md",
                        Ordered = true,
                        Type = Parsing::FormListItemType.List,
                    },
                },
            ],
            PageNumber = 0,

            PageHeight = null,
            PageWidth = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::FormsResultPage
        {
            Forms =
            [
                new()
                {
                    Json =
                    [
                        new Parsing::FormField()
                        {
                            Field = Parsing::Field.Checkbox,
                            ID = "id",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            IsEmpty = true,
                            Label = "label",
                            Type = Parsing::FormFieldType.Field,
                            Value = "string",
                            ValueItems =
                            [
                                new Parsing::FormSection()
                                {
                                    Items =
                                    [
                                        new Parsing::FormTable()
                                        {
                                            Rows =
                                            [
                                                ["string"],
                                            ],
                                            ID = "id",
                                            Bbox =
                                            [
                                                new()
                                                {
                                                    H = 0,
                                                    W = 0,
                                                    X = 0,
                                                    Y = 0,
                                                    Confidence = 0,
                                                    EndIndex = 0,
                                                    Label = "label",
                                                    R = 0,
                                                    StartIndex = 0,
                                                },
                                            ],
                                            Columns = ["string"],
                                            Label = "label",
                                            Type = Parsing::FormTableType.Table,
                                        },
                                    ],
                                    ID = "id",
                                    Label = "label",
                                    Type = Parsing::FormSectionType.Section,
                                },
                            ],
                        },
                    ],
                    List = new()
                    {
                        Items =
                        [
                            new Parsing::FormListTextItem()
                            {
                                Md = "md",
                                Value = "value",
                                Type = Parsing::FormListTextItemType.Text,
                            },
                        ],
                        Md = "md",
                        Ordered = true,
                        Type = Parsing::FormListItemType.List,
                    },
                },
            ],
            PageNumber = 0,
            PageHeight = 0,
            PageWidth = 0,
        };

        Parsing::FormsResultPage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FailedFormsPageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::FailedFormsPage { Error = "error", PageNumber = 0 };

        string expectedError = "error";
        long expectedPageNumber = 0;
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(false);

        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedPageNumber, model.PageNumber);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::FailedFormsPage { Error = "error", PageNumber = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::FailedFormsPage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::FailedFormsPage { Error = "error", PageNumber = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::FailedFormsPage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedError = "error";
        long expectedPageNumber = 0;
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(false);

        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedPageNumber, deserialized.PageNumber);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::FailedFormsPage { Error = "error", PageNumber = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::FailedFormsPage { Error = "error", PageNumber = 0 };

        Parsing::FailedFormsPage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImagesContentMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::ImagesContentMetadata
        {
            Images =
            [
                new()
                {
                    Filename = "filename",
                    Index = 0,
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Category = Parsing::Category.Embedded,
                    ContentType = "content_type",
                    PresignedUrl = "presigned_url",
                    SizeBytes = 0,
                },
            ],
            TotalCount = 0,
        };

        List<Parsing::ImagesContentMetadataImage> expectedImages =
        [
            new()
            {
                Filename = "filename",
                Index = 0,
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                },
                Category = Parsing::Category.Embedded,
                ContentType = "content_type",
                PresignedUrl = "presigned_url",
                SizeBytes = 0,
            },
        ];
        long expectedTotalCount = 0;

        Assert.Equal(expectedImages.Count, model.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], model.Images[i]);
        }
        Assert.Equal(expectedTotalCount, model.TotalCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::ImagesContentMetadata
        {
            Images =
            [
                new()
                {
                    Filename = "filename",
                    Index = 0,
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Category = Parsing::Category.Embedded,
                    ContentType = "content_type",
                    PresignedUrl = "presigned_url",
                    SizeBytes = 0,
                },
            ],
            TotalCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ImagesContentMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::ImagesContentMetadata
        {
            Images =
            [
                new()
                {
                    Filename = "filename",
                    Index = 0,
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Category = Parsing::Category.Embedded,
                    ContentType = "content_type",
                    PresignedUrl = "presigned_url",
                    SizeBytes = 0,
                },
            ],
            TotalCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ImagesContentMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Parsing::ImagesContentMetadataImage> expectedImages =
        [
            new()
            {
                Filename = "filename",
                Index = 0,
                Bbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                },
                Category = Parsing::Category.Embedded,
                ContentType = "content_type",
                PresignedUrl = "presigned_url",
                SizeBytes = 0,
            },
        ];
        long expectedTotalCount = 0;

        Assert.Equal(expectedImages.Count, deserialized.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], deserialized.Images[i]);
        }
        Assert.Equal(expectedTotalCount, deserialized.TotalCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::ImagesContentMetadata
        {
            Images =
            [
                new()
                {
                    Filename = "filename",
                    Index = 0,
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Category = Parsing::Category.Embedded,
                    ContentType = "content_type",
                    PresignedUrl = "presigned_url",
                    SizeBytes = 0,
                },
            ],
            TotalCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::ImagesContentMetadata
        {
            Images =
            [
                new()
                {
                    Filename = "filename",
                    Index = 0,
                    Bbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Category = Parsing::Category.Embedded,
                    ContentType = "content_type",
                    PresignedUrl = "presigned_url",
                    SizeBytes = 0,
                },
            ],
            TotalCount = 0,
        };

        Parsing::ImagesContentMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImagesContentMetadataImageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::ImagesContentMetadataImage
        {
            Filename = "filename",
            Index = 0,
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Category = Parsing::Category.Embedded,
            ContentType = "content_type",
            PresignedUrl = "presigned_url",
            SizeBytes = 0,
        };

        string expectedFilename = "filename";
        long expectedIndex = 0;
        Parsing::Bbox expectedBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };
        ApiEnum<string, Parsing::Category> expectedCategory = Parsing::Category.Embedded;
        string expectedContentType = "content_type";
        string expectedPresignedUrl = "presigned_url";
        long expectedSizeBytes = 0;

        Assert.Equal(expectedFilename, model.Filename);
        Assert.Equal(expectedIndex, model.Index);
        Assert.Equal(expectedBbox, model.Bbox);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedContentType, model.ContentType);
        Assert.Equal(expectedPresignedUrl, model.PresignedUrl);
        Assert.Equal(expectedSizeBytes, model.SizeBytes);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::ImagesContentMetadataImage
        {
            Filename = "filename",
            Index = 0,
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Category = Parsing::Category.Embedded,
            ContentType = "content_type",
            PresignedUrl = "presigned_url",
            SizeBytes = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ImagesContentMetadataImage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::ImagesContentMetadataImage
        {
            Filename = "filename",
            Index = 0,
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Category = Parsing::Category.Embedded,
            ContentType = "content_type",
            PresignedUrl = "presigned_url",
            SizeBytes = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ImagesContentMetadataImage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFilename = "filename";
        long expectedIndex = 0;
        Parsing::Bbox expectedBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };
        ApiEnum<string, Parsing::Category> expectedCategory = Parsing::Category.Embedded;
        string expectedContentType = "content_type";
        string expectedPresignedUrl = "presigned_url";
        long expectedSizeBytes = 0;

        Assert.Equal(expectedFilename, deserialized.Filename);
        Assert.Equal(expectedIndex, deserialized.Index);
        Assert.Equal(expectedBbox, deserialized.Bbox);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedContentType, deserialized.ContentType);
        Assert.Equal(expectedPresignedUrl, deserialized.PresignedUrl);
        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::ImagesContentMetadataImage
        {
            Filename = "filename",
            Index = 0,
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Category = Parsing::Category.Embedded,
            ContentType = "content_type",
            PresignedUrl = "presigned_url",
            SizeBytes = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::ImagesContentMetadataImage { Filename = "filename", Index = 0 };

        Assert.Null(model.Bbox);
        Assert.False(model.RawData.ContainsKey("bbox"));
        Assert.Null(model.Category);
        Assert.False(model.RawData.ContainsKey("category"));
        Assert.Null(model.ContentType);
        Assert.False(model.RawData.ContainsKey("content_type"));
        Assert.Null(model.PresignedUrl);
        Assert.False(model.RawData.ContainsKey("presigned_url"));
        Assert.Null(model.SizeBytes);
        Assert.False(model.RawData.ContainsKey("size_bytes"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::ImagesContentMetadataImage { Filename = "filename", Index = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::ImagesContentMetadataImage
        {
            Filename = "filename",
            Index = 0,

            Bbox = null,
            Category = null,
            ContentType = null,
            PresignedUrl = null,
            SizeBytes = null,
        };

        Assert.Null(model.Bbox);
        Assert.True(model.RawData.ContainsKey("bbox"));
        Assert.Null(model.Category);
        Assert.True(model.RawData.ContainsKey("category"));
        Assert.Null(model.ContentType);
        Assert.True(model.RawData.ContainsKey("content_type"));
        Assert.Null(model.PresignedUrl);
        Assert.True(model.RawData.ContainsKey("presigned_url"));
        Assert.Null(model.SizeBytes);
        Assert.True(model.RawData.ContainsKey("size_bytes"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::ImagesContentMetadataImage
        {
            Filename = "filename",
            Index = 0,

            Bbox = null,
            Category = null,
            ContentType = null,
            PresignedUrl = null,
            SizeBytes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::ImagesContentMetadataImage
        {
            Filename = "filename",
            Index = 0,
            Bbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Category = Parsing::Category.Embedded,
            ContentType = "content_type",
            PresignedUrl = "presigned_url",
            SizeBytes = 0,
        };

        Parsing::ImagesContentMetadataImage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BboxTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::Bbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        long expectedH = 0;
        long expectedW = 0;
        long expectedX = 0;
        long expectedY = 0;

        Assert.Equal(expectedH, model.H);
        Assert.Equal(expectedW, model.W);
        Assert.Equal(expectedX, model.X);
        Assert.Equal(expectedY, model.Y);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::Bbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Bbox>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::Bbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Bbox>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedH = 0;
        long expectedW = 0;
        long expectedX = 0;
        long expectedY = 0;

        Assert.Equal(expectedH, deserialized.H);
        Assert.Equal(expectedW, deserialized.W);
        Assert.Equal(expectedX, deserialized.X);
        Assert.Equal(expectedY, deserialized.Y);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::Bbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::Bbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        Parsing::Bbox copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Parsing::Category.Embedded)]
    [InlineData(Parsing::Category.Layout)]
    [InlineData(Parsing::Category.Screenshot)]
    public void Validation_Works(Parsing::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Parsing::Category.Embedded)]
    [InlineData(Parsing::Category.Layout)]
    [InlineData(Parsing::Category.Screenshot)]
    public void SerializationRoundtrip_Works(Parsing::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ItemsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::Items
        {
            Pages =
            [
                new Parsing::StructuredResultPage()
                {
                    Items =
                    [
                        new Parsing::CodeItem()
                        {
                            Md = "md",
                            ValueValue = "value",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            Language = "language",
                            Type = Parsing::Type.Code,
                        },
                    ],
                    PageHeight = 0,
                    PageNumber = 0,
                    PageWidth = 0,
                    Revisions =
                    [
                        new()
                        {
                            Content = "content",
                            RevisionBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            Target = "target",
                            TargetBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            Type = Parsing::RevisionType.Comment,
                            Author = "author",
                            EndIndex = 0,
                            StartIndex = 0,
                            TargetSpans =
                            [
                                new()
                                {
                                    Target = "target",
                                    TargetBbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                    },
                                    EndIndex = 0,
                                    StartIndex = 0,
                                },
                            ],
                        },
                    ],
                },
            ],
        };

        List<Parsing::ItemsPage> expectedPages =
        [
            new Parsing::StructuredResultPage()
            {
                Items =
                [
                    new Parsing::CodeItem()
                    {
                        Md = "md",
                        ValueValue = "value",
                        Bbox =
                        [
                            new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                        ],
                        Language = "language",
                        Type = Parsing::Type.Code,
                    },
                ],
                PageHeight = 0,
                PageNumber = 0,
                PageWidth = 0,
                Revisions =
                [
                    new()
                    {
                        Content = "content",
                        RevisionBbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                        Target = "target",
                        TargetBbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                        Type = Parsing::RevisionType.Comment,
                        Author = "author",
                        EndIndex = 0,
                        StartIndex = 0,
                        TargetSpans =
                        [
                            new()
                            {
                                Target = "target",
                                TargetBbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                                EndIndex = 0,
                                StartIndex = 0,
                            },
                        ],
                    },
                ],
            },
        ];

        Assert.Equal(expectedPages.Count, model.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], model.Pages[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::Items
        {
            Pages =
            [
                new Parsing::StructuredResultPage()
                {
                    Items =
                    [
                        new Parsing::CodeItem()
                        {
                            Md = "md",
                            ValueValue = "value",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            Language = "language",
                            Type = Parsing::Type.Code,
                        },
                    ],
                    PageHeight = 0,
                    PageNumber = 0,
                    PageWidth = 0,
                    Revisions =
                    [
                        new()
                        {
                            Content = "content",
                            RevisionBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            Target = "target",
                            TargetBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            Type = Parsing::RevisionType.Comment,
                            Author = "author",
                            EndIndex = 0,
                            StartIndex = 0,
                            TargetSpans =
                            [
                                new()
                                {
                                    Target = "target",
                                    TargetBbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                    },
                                    EndIndex = 0,
                                    StartIndex = 0,
                                },
                            ],
                        },
                    ],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Items>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::Items
        {
            Pages =
            [
                new Parsing::StructuredResultPage()
                {
                    Items =
                    [
                        new Parsing::CodeItem()
                        {
                            Md = "md",
                            ValueValue = "value",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            Language = "language",
                            Type = Parsing::Type.Code,
                        },
                    ],
                    PageHeight = 0,
                    PageNumber = 0,
                    PageWidth = 0,
                    Revisions =
                    [
                        new()
                        {
                            Content = "content",
                            RevisionBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            Target = "target",
                            TargetBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            Type = Parsing::RevisionType.Comment,
                            Author = "author",
                            EndIndex = 0,
                            StartIndex = 0,
                            TargetSpans =
                            [
                                new()
                                {
                                    Target = "target",
                                    TargetBbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                    },
                                    EndIndex = 0,
                                    StartIndex = 0,
                                },
                            ],
                        },
                    ],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Items>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Parsing::ItemsPage> expectedPages =
        [
            new Parsing::StructuredResultPage()
            {
                Items =
                [
                    new Parsing::CodeItem()
                    {
                        Md = "md",
                        ValueValue = "value",
                        Bbox =
                        [
                            new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                                Confidence = 0,
                                EndIndex = 0,
                                Label = "label",
                                R = 0,
                                StartIndex = 0,
                            },
                        ],
                        Language = "language",
                        Type = Parsing::Type.Code,
                    },
                ],
                PageHeight = 0,
                PageNumber = 0,
                PageWidth = 0,
                Revisions =
                [
                    new()
                    {
                        Content = "content",
                        RevisionBbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                        Target = "target",
                        TargetBbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                        Type = Parsing::RevisionType.Comment,
                        Author = "author",
                        EndIndex = 0,
                        StartIndex = 0,
                        TargetSpans =
                        [
                            new()
                            {
                                Target = "target",
                                TargetBbox = new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                },
                                EndIndex = 0,
                                StartIndex = 0,
                            },
                        ],
                    },
                ],
            },
        ];

        Assert.Equal(expectedPages.Count, deserialized.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], deserialized.Pages[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::Items
        {
            Pages =
            [
                new Parsing::StructuredResultPage()
                {
                    Items =
                    [
                        new Parsing::CodeItem()
                        {
                            Md = "md",
                            ValueValue = "value",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            Language = "language",
                            Type = Parsing::Type.Code,
                        },
                    ],
                    PageHeight = 0,
                    PageNumber = 0,
                    PageWidth = 0,
                    Revisions =
                    [
                        new()
                        {
                            Content = "content",
                            RevisionBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            Target = "target",
                            TargetBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            Type = Parsing::RevisionType.Comment,
                            Author = "author",
                            EndIndex = 0,
                            StartIndex = 0,
                            TargetSpans =
                            [
                                new()
                                {
                                    Target = "target",
                                    TargetBbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                    },
                                    EndIndex = 0,
                                    StartIndex = 0,
                                },
                            ],
                        },
                    ],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::Items
        {
            Pages =
            [
                new Parsing::StructuredResultPage()
                {
                    Items =
                    [
                        new Parsing::CodeItem()
                        {
                            Md = "md",
                            ValueValue = "value",
                            Bbox =
                            [
                                new()
                                {
                                    H = 0,
                                    W = 0,
                                    X = 0,
                                    Y = 0,
                                    Confidence = 0,
                                    EndIndex = 0,
                                    Label = "label",
                                    R = 0,
                                    StartIndex = 0,
                                },
                            ],
                            Language = "language",
                            Type = Parsing::Type.Code,
                        },
                    ],
                    PageHeight = 0,
                    PageNumber = 0,
                    PageWidth = 0,
                    Revisions =
                    [
                        new()
                        {
                            Content = "content",
                            RevisionBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            Target = "target",
                            TargetBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            Type = Parsing::RevisionType.Comment,
                            Author = "author",
                            EndIndex = 0,
                            StartIndex = 0,
                            TargetSpans =
                            [
                                new()
                                {
                                    Target = "target",
                                    TargetBbox = new()
                                    {
                                        H = 0,
                                        W = 0,
                                        X = 0,
                                        Y = 0,
                                    },
                                    EndIndex = 0,
                                    StartIndex = 0,
                                },
                            ],
                        },
                    ],
                },
            ],
        };

        Parsing::Items copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemsPageTest : TestBase
{
    [Fact]
    public void StructuredResultValidationWorks()
    {
        Parsing::ItemsPage value = new Parsing::StructuredResultPage()
        {
            Items =
            [
                new Parsing::CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
                    Bbox =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                    ],
                    Language = "language",
                    Type = Parsing::Type.Code,
                },
            ],
            PageHeight = 0,
            PageNumber = 0,
            PageWidth = 0,
            Revisions =
            [
                new()
                {
                    Content = "content",
                    RevisionBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Target = "target",
                    TargetBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Type = Parsing::RevisionType.Comment,
                    Author = "author",
                    EndIndex = 0,
                    StartIndex = 0,
                    TargetSpans =
                    [
                        new()
                        {
                            Target = "target",
                            TargetBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            EndIndex = 0,
                            StartIndex = 0,
                        },
                    ],
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void FailedStructuredValidationWorks()
    {
        Parsing::ItemsPage value = new Parsing::FailedStructuredPage()
        {
            Error = "error",
            PageNumber = 0,
        };
        value.Validate();
    }

    [Fact]
    public void StructuredResultSerializationRoundtripWorks()
    {
        Parsing::ItemsPage value = new Parsing::StructuredResultPage()
        {
            Items =
            [
                new Parsing::CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
                    Bbox =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                    ],
                    Language = "language",
                    Type = Parsing::Type.Code,
                },
            ],
            PageHeight = 0,
            PageNumber = 0,
            PageWidth = 0,
            Revisions =
            [
                new()
                {
                    Content = "content",
                    RevisionBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Target = "target",
                    TargetBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Type = Parsing::RevisionType.Comment,
                    Author = "author",
                    EndIndex = 0,
                    StartIndex = 0,
                    TargetSpans =
                    [
                        new()
                        {
                            Target = "target",
                            TargetBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            EndIndex = 0,
                            StartIndex = 0,
                        },
                    ],
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ItemsPage>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FailedStructuredSerializationRoundtripWorks()
    {
        Parsing::ItemsPage value = new Parsing::FailedStructuredPage()
        {
            Error = "error",
            PageNumber = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ItemsPage>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StructuredResultPageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::StructuredResultPage
        {
            Items =
            [
                new Parsing::CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
                    Bbox =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                    ],
                    Language = "language",
                    Type = Parsing::Type.Code,
                },
            ],
            PageHeight = 0,
            PageNumber = 0,
            PageWidth = 0,
            Revisions =
            [
                new()
                {
                    Content = "content",
                    RevisionBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Target = "target",
                    TargetBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Type = Parsing::RevisionType.Comment,
                    Author = "author",
                    EndIndex = 0,
                    StartIndex = 0,
                    TargetSpans =
                    [
                        new()
                        {
                            Target = "target",
                            TargetBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            EndIndex = 0,
                            StartIndex = 0,
                        },
                    ],
                },
            ],
        };

        List<Parsing::StructuredResultPageItem> expectedItems =
        [
            new Parsing::CodeItem()
            {
                Md = "md",
                ValueValue = "value",
                Bbox =
                [
                    new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                ],
                Language = "language",
                Type = Parsing::Type.Code,
            },
        ];
        double expectedPageHeight = 0;
        long expectedPageNumber = 0;
        double expectedPageWidth = 0;
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);
        List<Parsing::Revision> expectedRevisions =
        [
            new()
            {
                Content = "content",
                RevisionBbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                },
                Target = "target",
                TargetBbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                },
                Type = Parsing::RevisionType.Comment,
                Author = "author",
                EndIndex = 0,
                StartIndex = 0,
                TargetSpans =
                [
                    new()
                    {
                        Target = "target",
                        TargetBbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                        EndIndex = 0,
                        StartIndex = 0,
                    },
                ],
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedPageHeight, model.PageHeight);
        Assert.Equal(expectedPageNumber, model.PageNumber);
        Assert.Equal(expectedPageWidth, model.PageWidth);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
        Assert.NotNull(model.Revisions);
        Assert.Equal(expectedRevisions.Count, model.Revisions.Count);
        for (int i = 0; i < expectedRevisions.Count; i++)
        {
            Assert.Equal(expectedRevisions[i], model.Revisions[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::StructuredResultPage
        {
            Items =
            [
                new Parsing::CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
                    Bbox =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                    ],
                    Language = "language",
                    Type = Parsing::Type.Code,
                },
            ],
            PageHeight = 0,
            PageNumber = 0,
            PageWidth = 0,
            Revisions =
            [
                new()
                {
                    Content = "content",
                    RevisionBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Target = "target",
                    TargetBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Type = Parsing::RevisionType.Comment,
                    Author = "author",
                    EndIndex = 0,
                    StartIndex = 0,
                    TargetSpans =
                    [
                        new()
                        {
                            Target = "target",
                            TargetBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            EndIndex = 0,
                            StartIndex = 0,
                        },
                    ],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::StructuredResultPage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::StructuredResultPage
        {
            Items =
            [
                new Parsing::CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
                    Bbox =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                    ],
                    Language = "language",
                    Type = Parsing::Type.Code,
                },
            ],
            PageHeight = 0,
            PageNumber = 0,
            PageWidth = 0,
            Revisions =
            [
                new()
                {
                    Content = "content",
                    RevisionBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Target = "target",
                    TargetBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Type = Parsing::RevisionType.Comment,
                    Author = "author",
                    EndIndex = 0,
                    StartIndex = 0,
                    TargetSpans =
                    [
                        new()
                        {
                            Target = "target",
                            TargetBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            EndIndex = 0,
                            StartIndex = 0,
                        },
                    ],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::StructuredResultPage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Parsing::StructuredResultPageItem> expectedItems =
        [
            new Parsing::CodeItem()
            {
                Md = "md",
                ValueValue = "value",
                Bbox =
                [
                    new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                        Confidence = 0,
                        EndIndex = 0,
                        Label = "label",
                        R = 0,
                        StartIndex = 0,
                    },
                ],
                Language = "language",
                Type = Parsing::Type.Code,
            },
        ];
        double expectedPageHeight = 0;
        long expectedPageNumber = 0;
        double expectedPageWidth = 0;
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);
        List<Parsing::Revision> expectedRevisions =
        [
            new()
            {
                Content = "content",
                RevisionBbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                },
                Target = "target",
                TargetBbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                },
                Type = Parsing::RevisionType.Comment,
                Author = "author",
                EndIndex = 0,
                StartIndex = 0,
                TargetSpans =
                [
                    new()
                    {
                        Target = "target",
                        TargetBbox = new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                        },
                        EndIndex = 0,
                        StartIndex = 0,
                    },
                ],
            },
        ];

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedPageHeight, deserialized.PageHeight);
        Assert.Equal(expectedPageNumber, deserialized.PageNumber);
        Assert.Equal(expectedPageWidth, deserialized.PageWidth);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
        Assert.NotNull(deserialized.Revisions);
        Assert.Equal(expectedRevisions.Count, deserialized.Revisions.Count);
        for (int i = 0; i < expectedRevisions.Count; i++)
        {
            Assert.Equal(expectedRevisions[i], deserialized.Revisions[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::StructuredResultPage
        {
            Items =
            [
                new Parsing::CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
                    Bbox =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                    ],
                    Language = "language",
                    Type = Parsing::Type.Code,
                },
            ],
            PageHeight = 0,
            PageNumber = 0,
            PageWidth = 0,
            Revisions =
            [
                new()
                {
                    Content = "content",
                    RevisionBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Target = "target",
                    TargetBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Type = Parsing::RevisionType.Comment,
                    Author = "author",
                    EndIndex = 0,
                    StartIndex = 0,
                    TargetSpans =
                    [
                        new()
                        {
                            Target = "target",
                            TargetBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            EndIndex = 0,
                            StartIndex = 0,
                        },
                    ],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::StructuredResultPage
        {
            Items =
            [
                new Parsing::CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
                    Bbox =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                    ],
                    Language = "language",
                    Type = Parsing::Type.Code,
                },
            ],
            PageHeight = 0,
            PageNumber = 0,
            PageWidth = 0,
        };

        Assert.Null(model.Revisions);
        Assert.False(model.RawData.ContainsKey("revisions"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::StructuredResultPage
        {
            Items =
            [
                new Parsing::CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
                    Bbox =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                    ],
                    Language = "language",
                    Type = Parsing::Type.Code,
                },
            ],
            PageHeight = 0,
            PageNumber = 0,
            PageWidth = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::StructuredResultPage
        {
            Items =
            [
                new Parsing::CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
                    Bbox =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                    ],
                    Language = "language",
                    Type = Parsing::Type.Code,
                },
            ],
            PageHeight = 0,
            PageNumber = 0,
            PageWidth = 0,

            Revisions = null,
        };

        Assert.Null(model.Revisions);
        Assert.True(model.RawData.ContainsKey("revisions"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::StructuredResultPage
        {
            Items =
            [
                new Parsing::CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
                    Bbox =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                    ],
                    Language = "language",
                    Type = Parsing::Type.Code,
                },
            ],
            PageHeight = 0,
            PageNumber = 0,
            PageWidth = 0,

            Revisions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::StructuredResultPage
        {
            Items =
            [
                new Parsing::CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
                    Bbox =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                    ],
                    Language = "language",
                    Type = Parsing::Type.Code,
                },
            ],
            PageHeight = 0,
            PageNumber = 0,
            PageWidth = 0,
            Revisions =
            [
                new()
                {
                    Content = "content",
                    RevisionBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Target = "target",
                    TargetBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    Type = Parsing::RevisionType.Comment,
                    Author = "author",
                    EndIndex = 0,
                    StartIndex = 0,
                    TargetSpans =
                    [
                        new()
                        {
                            Target = "target",
                            TargetBbox = new()
                            {
                                H = 0,
                                W = 0,
                                X = 0,
                                Y = 0,
                            },
                            EndIndex = 0,
                            StartIndex = 0,
                        },
                    ],
                },
            ],
        };

        Parsing::StructuredResultPage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StructuredResultPageItemTest : TestBase
{
    [Fact]
    public void CodeValidationWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::CodeItem()
        {
            Md = "md",
            ValueValue = "value",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Language = "language",
            Type = Parsing::Type.Code,
        };
        value.Validate();
    }

    [Fact]
    public void FooterValidationWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::FooterItem()
        {
            Items =
            [
                new Parsing::CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
                    Bbox =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                    ],
                    Language = "language",
                    Type = Parsing::Type.Code,
                },
            ],
            Md = "md",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = Parsing::FooterItemType.Footer,
        };
        value.Validate();
    }

    [Fact]
    public void HeaderValidationWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::HeaderItem()
        {
            Items =
            [
                new Parsing::CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
                    Bbox =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                    ],
                    Language = "language",
                    Type = Parsing::Type.Code,
                },
            ],
            Md = "md",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = Parsing::HeaderItemType.Header,
        };
        value.Validate();
    }

    [Fact]
    public void HeadingValidationWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::HeadingItem()
        {
            Level = 0,
            Md = "md",
            Value = "value",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = Parsing::HeadingItemType.Heading,
        };
        value.Validate();
    }

    [Fact]
    public void ImageValidationWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::ImageItem()
        {
            Caption = "caption",
            Md = "md",
            Url = "url",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = Parsing::ImageItemType.Image,
        };
        value.Validate();
    }

    [Fact]
    public void LinkValidationWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::LinkItem()
        {
            Md = "md",
            Text = "text",
            Url = "url",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = Parsing::LinkItemType.Link,
        };
        value.Validate();
    }

    [Fact]
    public void ListValidationWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::ListItem()
        {
            Items =
            [
                new Parsing::TextItem()
                {
                    Md = "md",
                    Value = "value",
                    Bbox =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                    ],
                    Type = Parsing::TextItemType.Text,
                },
            ],
            Md = "md",
            Ordered = true,
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = Parsing::ListItemType.List,
        };
        value.Validate();
    }

    [Fact]
    public void TableValidationWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::TableItem()
        {
            Csv = "csv",
            Html = "html",
            Md = "md",
            Rows =
            [
                ["string"],
            ],
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            MergedFromPages = [0],
            MergedIntoPage = 0,
            ParseConcerns = [new() { Details = "details", Type = "type" }],
            Type = Parsing::TableItemType.Table,
        };
        value.Validate();
    }

    [Fact]
    public void TextValidationWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::TextItem()
        {
            Md = "md",
            Value = "value",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = Parsing::TextItemType.Text,
        };
        value.Validate();
    }

    [Fact]
    public void CodeSerializationRoundtripWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::CodeItem()
        {
            Md = "md",
            ValueValue = "value",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Language = "language",
            Type = Parsing::Type.Code,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::StructuredResultPageItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FooterSerializationRoundtripWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::FooterItem()
        {
            Items =
            [
                new Parsing::CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
                    Bbox =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                    ],
                    Language = "language",
                    Type = Parsing::Type.Code,
                },
            ],
            Md = "md",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = Parsing::FooterItemType.Footer,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::StructuredResultPageItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void HeaderSerializationRoundtripWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::HeaderItem()
        {
            Items =
            [
                new Parsing::CodeItem()
                {
                    Md = "md",
                    ValueValue = "value",
                    Bbox =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                    ],
                    Language = "language",
                    Type = Parsing::Type.Code,
                },
            ],
            Md = "md",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = Parsing::HeaderItemType.Header,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::StructuredResultPageItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void HeadingSerializationRoundtripWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::HeadingItem()
        {
            Level = 0,
            Md = "md",
            Value = "value",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = Parsing::HeadingItemType.Heading,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::StructuredResultPageItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageSerializationRoundtripWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::ImageItem()
        {
            Caption = "caption",
            Md = "md",
            Url = "url",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = Parsing::ImageItemType.Image,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::StructuredResultPageItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LinkSerializationRoundtripWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::LinkItem()
        {
            Md = "md",
            Text = "text",
            Url = "url",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = Parsing::LinkItemType.Link,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::StructuredResultPageItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ListSerializationRoundtripWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::ListItem()
        {
            Items =
            [
                new Parsing::TextItem()
                {
                    Md = "md",
                    Value = "value",
                    Bbox =
                    [
                        new()
                        {
                            H = 0,
                            W = 0,
                            X = 0,
                            Y = 0,
                            Confidence = 0,
                            EndIndex = 0,
                            Label = "label",
                            R = 0,
                            StartIndex = 0,
                        },
                    ],
                    Type = Parsing::TextItemType.Text,
                },
            ],
            Md = "md",
            Ordered = true,
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = Parsing::ListItemType.List,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::StructuredResultPageItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TableSerializationRoundtripWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::TableItem()
        {
            Csv = "csv",
            Html = "html",
            Md = "md",
            Rows =
            [
                ["string"],
            ],
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            MergedFromPages = [0],
            MergedIntoPage = 0,
            ParseConcerns = [new() { Details = "details", Type = "type" }],
            Type = Parsing::TableItemType.Table,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::StructuredResultPageItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TextSerializationRoundtripWorks()
    {
        Parsing::StructuredResultPageItem value = new Parsing::TextItem()
        {
            Md = "md",
            Value = "value",
            Bbox =
            [
                new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                    Confidence = 0,
                    EndIndex = 0,
                    Label = "label",
                    R = 0,
                    StartIndex = 0,
                },
            ],
            Type = Parsing::TextItemType.Text,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::StructuredResultPageItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RevisionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::Revision
        {
            Content = "content",
            RevisionBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Type = Parsing::RevisionType.Comment,
            Author = "author",
            EndIndex = 0,
            StartIndex = 0,
            TargetSpans =
            [
                new()
                {
                    Target = "target",
                    TargetBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    EndIndex = 0,
                    StartIndex = 0,
                },
            ],
        };

        string expectedContent = "content";
        Parsing::RevisionBbox expectedRevisionBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };
        string expectedTarget = "target";
        Parsing::TargetBbox expectedTargetBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };
        ApiEnum<string, Parsing::RevisionType> expectedType = Parsing::RevisionType.Comment;
        string expectedAuthor = "author";
        long expectedEndIndex = 0;
        long expectedStartIndex = 0;
        List<Parsing::TargetSpan> expectedTargetSpans =
        [
            new()
            {
                Target = "target",
                TargetBbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                },
                EndIndex = 0,
                StartIndex = 0,
            },
        ];

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedRevisionBbox, model.RevisionBbox);
        Assert.Equal(expectedTarget, model.Target);
        Assert.Equal(expectedTargetBbox, model.TargetBbox);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedAuthor, model.Author);
        Assert.Equal(expectedEndIndex, model.EndIndex);
        Assert.Equal(expectedStartIndex, model.StartIndex);
        Assert.NotNull(model.TargetSpans);
        Assert.Equal(expectedTargetSpans.Count, model.TargetSpans.Count);
        for (int i = 0; i < expectedTargetSpans.Count; i++)
        {
            Assert.Equal(expectedTargetSpans[i], model.TargetSpans[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::Revision
        {
            Content = "content",
            RevisionBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Type = Parsing::RevisionType.Comment,
            Author = "author",
            EndIndex = 0,
            StartIndex = 0,
            TargetSpans =
            [
                new()
                {
                    Target = "target",
                    TargetBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    EndIndex = 0,
                    StartIndex = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Revision>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::Revision
        {
            Content = "content",
            RevisionBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Type = Parsing::RevisionType.Comment,
            Author = "author",
            EndIndex = 0,
            StartIndex = 0,
            TargetSpans =
            [
                new()
                {
                    Target = "target",
                    TargetBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    EndIndex = 0,
                    StartIndex = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Revision>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        Parsing::RevisionBbox expectedRevisionBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };
        string expectedTarget = "target";
        Parsing::TargetBbox expectedTargetBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };
        ApiEnum<string, Parsing::RevisionType> expectedType = Parsing::RevisionType.Comment;
        string expectedAuthor = "author";
        long expectedEndIndex = 0;
        long expectedStartIndex = 0;
        List<Parsing::TargetSpan> expectedTargetSpans =
        [
            new()
            {
                Target = "target",
                TargetBbox = new()
                {
                    H = 0,
                    W = 0,
                    X = 0,
                    Y = 0,
                },
                EndIndex = 0,
                StartIndex = 0,
            },
        ];

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedRevisionBbox, deserialized.RevisionBbox);
        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.Equal(expectedTargetBbox, deserialized.TargetBbox);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedAuthor, deserialized.Author);
        Assert.Equal(expectedEndIndex, deserialized.EndIndex);
        Assert.Equal(expectedStartIndex, deserialized.StartIndex);
        Assert.NotNull(deserialized.TargetSpans);
        Assert.Equal(expectedTargetSpans.Count, deserialized.TargetSpans.Count);
        for (int i = 0; i < expectedTargetSpans.Count; i++)
        {
            Assert.Equal(expectedTargetSpans[i], deserialized.TargetSpans[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::Revision
        {
            Content = "content",
            RevisionBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Type = Parsing::RevisionType.Comment,
            Author = "author",
            EndIndex = 0,
            StartIndex = 0,
            TargetSpans =
            [
                new()
                {
                    Target = "target",
                    TargetBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    EndIndex = 0,
                    StartIndex = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::Revision
        {
            Content = "content",
            RevisionBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Type = Parsing::RevisionType.Comment,
        };

        Assert.Null(model.Author);
        Assert.False(model.RawData.ContainsKey("author"));
        Assert.Null(model.EndIndex);
        Assert.False(model.RawData.ContainsKey("end_index"));
        Assert.Null(model.StartIndex);
        Assert.False(model.RawData.ContainsKey("start_index"));
        Assert.Null(model.TargetSpans);
        Assert.False(model.RawData.ContainsKey("target_spans"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::Revision
        {
            Content = "content",
            RevisionBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Type = Parsing::RevisionType.Comment,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::Revision
        {
            Content = "content",
            RevisionBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Type = Parsing::RevisionType.Comment,

            Author = null,
            EndIndex = null,
            StartIndex = null,
            TargetSpans = null,
        };

        Assert.Null(model.Author);
        Assert.True(model.RawData.ContainsKey("author"));
        Assert.Null(model.EndIndex);
        Assert.True(model.RawData.ContainsKey("end_index"));
        Assert.Null(model.StartIndex);
        Assert.True(model.RawData.ContainsKey("start_index"));
        Assert.Null(model.TargetSpans);
        Assert.True(model.RawData.ContainsKey("target_spans"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::Revision
        {
            Content = "content",
            RevisionBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Type = Parsing::RevisionType.Comment,

            Author = null,
            EndIndex = null,
            StartIndex = null,
            TargetSpans = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::Revision
        {
            Content = "content",
            RevisionBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            Type = Parsing::RevisionType.Comment,
            Author = "author",
            EndIndex = 0,
            StartIndex = 0,
            TargetSpans =
            [
                new()
                {
                    Target = "target",
                    TargetBbox = new()
                    {
                        H = 0,
                        W = 0,
                        X = 0,
                        Y = 0,
                    },
                    EndIndex = 0,
                    StartIndex = 0,
                },
            ],
        };

        Parsing::Revision copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RevisionBboxTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::RevisionBbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        double expectedH = 0;
        double expectedW = 0;
        double expectedX = 0;
        double expectedY = 0;

        Assert.Equal(expectedH, model.H);
        Assert.Equal(expectedW, model.W);
        Assert.Equal(expectedX, model.X);
        Assert.Equal(expectedY, model.Y);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::RevisionBbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::RevisionBbox>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::RevisionBbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::RevisionBbox>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedH = 0;
        double expectedW = 0;
        double expectedX = 0;
        double expectedY = 0;

        Assert.Equal(expectedH, deserialized.H);
        Assert.Equal(expectedW, deserialized.W);
        Assert.Equal(expectedX, deserialized.X);
        Assert.Equal(expectedY, deserialized.Y);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::RevisionBbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::RevisionBbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        Parsing::RevisionBbox copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TargetBboxTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::TargetBbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        double expectedH = 0;
        double expectedW = 0;
        double expectedX = 0;
        double expectedY = 0;

        Assert.Equal(expectedH, model.H);
        Assert.Equal(expectedW, model.W);
        Assert.Equal(expectedX, model.X);
        Assert.Equal(expectedY, model.Y);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::TargetBbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::TargetBbox>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::TargetBbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::TargetBbox>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedH = 0;
        double expectedW = 0;
        double expectedX = 0;
        double expectedY = 0;

        Assert.Equal(expectedH, deserialized.H);
        Assert.Equal(expectedW, deserialized.W);
        Assert.Equal(expectedX, deserialized.X);
        Assert.Equal(expectedY, deserialized.Y);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::TargetBbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::TargetBbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        Parsing::TargetBbox copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RevisionTypeTest : TestBase
{
    [Theory]
    [InlineData(Parsing::RevisionType.Comment)]
    [InlineData(Parsing::RevisionType.Deleted)]
    [InlineData(Parsing::RevisionType.Formatted)]
    [InlineData(Parsing::RevisionType.Inserted)]
    [InlineData(Parsing::RevisionType.MovedFrom)]
    [InlineData(Parsing::RevisionType.MovedTo)]
    public void Validation_Works(Parsing::RevisionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::RevisionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::RevisionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<LlamaCloudInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Parsing::RevisionType.Comment)]
    [InlineData(Parsing::RevisionType.Deleted)]
    [InlineData(Parsing::RevisionType.Formatted)]
    [InlineData(Parsing::RevisionType.Inserted)]
    [InlineData(Parsing::RevisionType.MovedFrom)]
    [InlineData(Parsing::RevisionType.MovedTo)]
    public void SerializationRoundtrip_Works(Parsing::RevisionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Parsing::RevisionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::RevisionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Parsing::RevisionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Parsing::RevisionType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TargetSpanTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::TargetSpan
        {
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            EndIndex = 0,
            StartIndex = 0,
        };

        string expectedTarget = "target";
        Parsing::TargetSpanTargetBbox expectedTargetBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };
        long expectedEndIndex = 0;
        long expectedStartIndex = 0;

        Assert.Equal(expectedTarget, model.Target);
        Assert.Equal(expectedTargetBbox, model.TargetBbox);
        Assert.Equal(expectedEndIndex, model.EndIndex);
        Assert.Equal(expectedStartIndex, model.StartIndex);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::TargetSpan
        {
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            EndIndex = 0,
            StartIndex = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::TargetSpan>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::TargetSpan
        {
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            EndIndex = 0,
            StartIndex = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::TargetSpan>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTarget = "target";
        Parsing::TargetSpanTargetBbox expectedTargetBbox = new()
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };
        long expectedEndIndex = 0;
        long expectedStartIndex = 0;

        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.Equal(expectedTargetBbox, deserialized.TargetBbox);
        Assert.Equal(expectedEndIndex, deserialized.EndIndex);
        Assert.Equal(expectedStartIndex, deserialized.StartIndex);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::TargetSpan
        {
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            EndIndex = 0,
            StartIndex = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::TargetSpan
        {
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
        };

        Assert.Null(model.EndIndex);
        Assert.False(model.RawData.ContainsKey("end_index"));
        Assert.Null(model.StartIndex);
        Assert.False(model.RawData.ContainsKey("start_index"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::TargetSpan
        {
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::TargetSpan
        {
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },

            EndIndex = null,
            StartIndex = null,
        };

        Assert.Null(model.EndIndex);
        Assert.True(model.RawData.ContainsKey("end_index"));
        Assert.Null(model.StartIndex);
        Assert.True(model.RawData.ContainsKey("start_index"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::TargetSpan
        {
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },

            EndIndex = null,
            StartIndex = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::TargetSpan
        {
            Target = "target",
            TargetBbox = new()
            {
                H = 0,
                W = 0,
                X = 0,
                Y = 0,
            },
            EndIndex = 0,
            StartIndex = 0,
        };

        Parsing::TargetSpan copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TargetSpanTargetBboxTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::TargetSpanTargetBbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        double expectedH = 0;
        double expectedW = 0;
        double expectedX = 0;
        double expectedY = 0;

        Assert.Equal(expectedH, model.H);
        Assert.Equal(expectedW, model.W);
        Assert.Equal(expectedX, model.X);
        Assert.Equal(expectedY, model.Y);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::TargetSpanTargetBbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::TargetSpanTargetBbox>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::TargetSpanTargetBbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::TargetSpanTargetBbox>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedH = 0;
        double expectedW = 0;
        double expectedX = 0;
        double expectedY = 0;

        Assert.Equal(expectedH, deserialized.H);
        Assert.Equal(expectedW, deserialized.W);
        Assert.Equal(expectedX, deserialized.X);
        Assert.Equal(expectedY, deserialized.Y);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::TargetSpanTargetBbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::TargetSpanTargetBbox
        {
            H = 0,
            W = 0,
            X = 0,
            Y = 0,
        };

        Parsing::TargetSpanTargetBbox copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FailedStructuredPageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::FailedStructuredPage { Error = "error", PageNumber = 0 };

        string expectedError = "error";
        long expectedPageNumber = 0;
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(false);

        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedPageNumber, model.PageNumber);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::FailedStructuredPage { Error = "error", PageNumber = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::FailedStructuredPage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::FailedStructuredPage { Error = "error", PageNumber = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::FailedStructuredPage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedError = "error";
        long expectedPageNumber = 0;
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(false);

        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedPageNumber, deserialized.PageNumber);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::FailedStructuredPage { Error = "error", PageNumber = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::FailedStructuredPage { Error = "error", PageNumber = 0 };

        Parsing::FailedStructuredPage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ParsingGetResponseMarkdownTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::ParsingGetResponseMarkdown
        {
            Pages =
            [
                new Parsing::MarkdownResultPage()
                {
                    Markdown = "markdown",
                    PageNumber = 0,
                    Footer = "footer",
                    Header = "header",
                },
            ],
        };

        List<Parsing::ParsingGetResponseMarkdownPage> expectedPages =
        [
            new Parsing::MarkdownResultPage()
            {
                Markdown = "markdown",
                PageNumber = 0,
                Footer = "footer",
                Header = "header",
            },
        ];

        Assert.Equal(expectedPages.Count, model.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], model.Pages[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::ParsingGetResponseMarkdown
        {
            Pages =
            [
                new Parsing::MarkdownResultPage()
                {
                    Markdown = "markdown",
                    PageNumber = 0,
                    Footer = "footer",
                    Header = "header",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ParsingGetResponseMarkdown>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::ParsingGetResponseMarkdown
        {
            Pages =
            [
                new Parsing::MarkdownResultPage()
                {
                    Markdown = "markdown",
                    PageNumber = 0,
                    Footer = "footer",
                    Header = "header",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ParsingGetResponseMarkdown>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Parsing::ParsingGetResponseMarkdownPage> expectedPages =
        [
            new Parsing::MarkdownResultPage()
            {
                Markdown = "markdown",
                PageNumber = 0,
                Footer = "footer",
                Header = "header",
            },
        ];

        Assert.Equal(expectedPages.Count, deserialized.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], deserialized.Pages[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::ParsingGetResponseMarkdown
        {
            Pages =
            [
                new Parsing::MarkdownResultPage()
                {
                    Markdown = "markdown",
                    PageNumber = 0,
                    Footer = "footer",
                    Header = "header",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::ParsingGetResponseMarkdown
        {
            Pages =
            [
                new Parsing::MarkdownResultPage()
                {
                    Markdown = "markdown",
                    PageNumber = 0,
                    Footer = "footer",
                    Header = "header",
                },
            ],
        };

        Parsing::ParsingGetResponseMarkdown copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ParsingGetResponseMarkdownPageTest : TestBase
{
    [Fact]
    public void MarkdownResultValidationWorks()
    {
        Parsing::ParsingGetResponseMarkdownPage value = new Parsing::MarkdownResultPage()
        {
            Markdown = "markdown",
            PageNumber = 0,
            Footer = "footer",
            Header = "header",
        };
        value.Validate();
    }

    [Fact]
    public void FailedMarkdownValidationWorks()
    {
        Parsing::ParsingGetResponseMarkdownPage value = new Parsing::FailedMarkdownPage()
        {
            Error = "error",
            PageNumber = 0,
        };
        value.Validate();
    }

    [Fact]
    public void MarkdownResultSerializationRoundtripWorks()
    {
        Parsing::ParsingGetResponseMarkdownPage value = new Parsing::MarkdownResultPage()
        {
            Markdown = "markdown",
            PageNumber = 0,
            Footer = "footer",
            Header = "header",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ParsingGetResponseMarkdownPage>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FailedMarkdownSerializationRoundtripWorks()
    {
        Parsing::ParsingGetResponseMarkdownPage value = new Parsing::FailedMarkdownPage()
        {
            Error = "error",
            PageNumber = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ParsingGetResponseMarkdownPage>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MarkdownResultPageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::MarkdownResultPage
        {
            Markdown = "markdown",
            PageNumber = 0,
            Footer = "footer",
            Header = "header",
        };

        string expectedMarkdown = "markdown";
        long expectedPageNumber = 0;
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);
        string expectedFooter = "footer";
        string expectedHeader = "header";

        Assert.Equal(expectedMarkdown, model.Markdown);
        Assert.Equal(expectedPageNumber, model.PageNumber);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
        Assert.Equal(expectedFooter, model.Footer);
        Assert.Equal(expectedHeader, model.Header);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::MarkdownResultPage
        {
            Markdown = "markdown",
            PageNumber = 0,
            Footer = "footer",
            Header = "header",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::MarkdownResultPage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::MarkdownResultPage
        {
            Markdown = "markdown",
            PageNumber = 0,
            Footer = "footer",
            Header = "header",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::MarkdownResultPage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMarkdown = "markdown";
        long expectedPageNumber = 0;
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(true);
        string expectedFooter = "footer";
        string expectedHeader = "header";

        Assert.Equal(expectedMarkdown, deserialized.Markdown);
        Assert.Equal(expectedPageNumber, deserialized.PageNumber);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
        Assert.Equal(expectedFooter, deserialized.Footer);
        Assert.Equal(expectedHeader, deserialized.Header);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::MarkdownResultPage
        {
            Markdown = "markdown",
            PageNumber = 0,
            Footer = "footer",
            Header = "header",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::MarkdownResultPage { Markdown = "markdown", PageNumber = 0 };

        Assert.Null(model.Footer);
        Assert.False(model.RawData.ContainsKey("footer"));
        Assert.Null(model.Header);
        Assert.False(model.RawData.ContainsKey("header"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::MarkdownResultPage { Markdown = "markdown", PageNumber = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::MarkdownResultPage
        {
            Markdown = "markdown",
            PageNumber = 0,

            Footer = null,
            Header = null,
        };

        Assert.Null(model.Footer);
        Assert.True(model.RawData.ContainsKey("footer"));
        Assert.Null(model.Header);
        Assert.True(model.RawData.ContainsKey("header"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::MarkdownResultPage
        {
            Markdown = "markdown",
            PageNumber = 0,

            Footer = null,
            Header = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::MarkdownResultPage
        {
            Markdown = "markdown",
            PageNumber = 0,
            Footer = "footer",
            Header = "header",
        };

        Parsing::MarkdownResultPage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FailedMarkdownPageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::FailedMarkdownPage { Error = "error", PageNumber = 0 };

        string expectedError = "error";
        long expectedPageNumber = 0;
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(false);

        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedPageNumber, model.PageNumber);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, model.Success));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::FailedMarkdownPage { Error = "error", PageNumber = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::FailedMarkdownPage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::FailedMarkdownPage { Error = "error", PageNumber = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::FailedMarkdownPage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedError = "error";
        long expectedPageNumber = 0;
        JsonElement expectedSuccess = JsonSerializer.SerializeToElement(false);

        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedPageNumber, deserialized.PageNumber);
        Assert.True(JsonElement.DeepEquals(expectedSuccess, deserialized.Success));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::FailedMarkdownPage { Error = "error", PageNumber = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::FailedMarkdownPage { Error = "error", PageNumber = 0 };

        Parsing::FailedMarkdownPage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::Metadata
        {
            Pages =
            [
                new()
                {
                    PageNumber = 0,
                    Confidence = 0,
                    CostOptimized = true,
                    OriginalOrientationAngle = 0,
                    PrintedPageNumber = "printed_page_number",
                    SlideSectionName = "slide_section_name",
                    SpeakerNotes = "speaker_notes",
                    TriggeredAutoMode = true,
                },
            ],
        };

        List<Parsing::MetadataPage> expectedPages =
        [
            new()
            {
                PageNumber = 0,
                Confidence = 0,
                CostOptimized = true,
                OriginalOrientationAngle = 0,
                PrintedPageNumber = "printed_page_number",
                SlideSectionName = "slide_section_name",
                SpeakerNotes = "speaker_notes",
                TriggeredAutoMode = true,
            },
        ];

        Assert.Equal(expectedPages.Count, model.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], model.Pages[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::Metadata
        {
            Pages =
            [
                new()
                {
                    PageNumber = 0,
                    Confidence = 0,
                    CostOptimized = true,
                    OriginalOrientationAngle = 0,
                    PrintedPageNumber = "printed_page_number",
                    SlideSectionName = "slide_section_name",
                    SpeakerNotes = "speaker_notes",
                    TriggeredAutoMode = true,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Metadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::Metadata
        {
            Pages =
            [
                new()
                {
                    PageNumber = 0,
                    Confidence = 0,
                    CostOptimized = true,
                    OriginalOrientationAngle = 0,
                    PrintedPageNumber = "printed_page_number",
                    SlideSectionName = "slide_section_name",
                    SpeakerNotes = "speaker_notes",
                    TriggeredAutoMode = true,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Metadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Parsing::MetadataPage> expectedPages =
        [
            new()
            {
                PageNumber = 0,
                Confidence = 0,
                CostOptimized = true,
                OriginalOrientationAngle = 0,
                PrintedPageNumber = "printed_page_number",
                SlideSectionName = "slide_section_name",
                SpeakerNotes = "speaker_notes",
                TriggeredAutoMode = true,
            },
        ];

        Assert.Equal(expectedPages.Count, deserialized.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], deserialized.Pages[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::Metadata
        {
            Pages =
            [
                new()
                {
                    PageNumber = 0,
                    Confidence = 0,
                    CostOptimized = true,
                    OriginalOrientationAngle = 0,
                    PrintedPageNumber = "printed_page_number",
                    SlideSectionName = "slide_section_name",
                    SpeakerNotes = "speaker_notes",
                    TriggeredAutoMode = true,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::Metadata
        {
            Pages =
            [
                new()
                {
                    PageNumber = 0,
                    Confidence = 0,
                    CostOptimized = true,
                    OriginalOrientationAngle = 0,
                    PrintedPageNumber = "printed_page_number",
                    SlideSectionName = "slide_section_name",
                    SpeakerNotes = "speaker_notes",
                    TriggeredAutoMode = true,
                },
            ],
        };

        Parsing::Metadata copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MetadataPageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::MetadataPage
        {
            PageNumber = 0,
            Confidence = 0,
            CostOptimized = true,
            OriginalOrientationAngle = 0,
            PrintedPageNumber = "printed_page_number",
            SlideSectionName = "slide_section_name",
            SpeakerNotes = "speaker_notes",
            TriggeredAutoMode = true,
        };

        long expectedPageNumber = 0;
        double expectedConfidence = 0;
        bool expectedCostOptimized = true;
        long expectedOriginalOrientationAngle = 0;
        string expectedPrintedPageNumber = "printed_page_number";
        string expectedSlideSectionName = "slide_section_name";
        string expectedSpeakerNotes = "speaker_notes";
        bool expectedTriggeredAutoMode = true;

        Assert.Equal(expectedPageNumber, model.PageNumber);
        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedCostOptimized, model.CostOptimized);
        Assert.Equal(expectedOriginalOrientationAngle, model.OriginalOrientationAngle);
        Assert.Equal(expectedPrintedPageNumber, model.PrintedPageNumber);
        Assert.Equal(expectedSlideSectionName, model.SlideSectionName);
        Assert.Equal(expectedSpeakerNotes, model.SpeakerNotes);
        Assert.Equal(expectedTriggeredAutoMode, model.TriggeredAutoMode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::MetadataPage
        {
            PageNumber = 0,
            Confidence = 0,
            CostOptimized = true,
            OriginalOrientationAngle = 0,
            PrintedPageNumber = "printed_page_number",
            SlideSectionName = "slide_section_name",
            SpeakerNotes = "speaker_notes",
            TriggeredAutoMode = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::MetadataPage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::MetadataPage
        {
            PageNumber = 0,
            Confidence = 0,
            CostOptimized = true,
            OriginalOrientationAngle = 0,
            PrintedPageNumber = "printed_page_number",
            SlideSectionName = "slide_section_name",
            SpeakerNotes = "speaker_notes",
            TriggeredAutoMode = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::MetadataPage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedPageNumber = 0;
        double expectedConfidence = 0;
        bool expectedCostOptimized = true;
        long expectedOriginalOrientationAngle = 0;
        string expectedPrintedPageNumber = "printed_page_number";
        string expectedSlideSectionName = "slide_section_name";
        string expectedSpeakerNotes = "speaker_notes";
        bool expectedTriggeredAutoMode = true;

        Assert.Equal(expectedPageNumber, deserialized.PageNumber);
        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedCostOptimized, deserialized.CostOptimized);
        Assert.Equal(expectedOriginalOrientationAngle, deserialized.OriginalOrientationAngle);
        Assert.Equal(expectedPrintedPageNumber, deserialized.PrintedPageNumber);
        Assert.Equal(expectedSlideSectionName, deserialized.SlideSectionName);
        Assert.Equal(expectedSpeakerNotes, deserialized.SpeakerNotes);
        Assert.Equal(expectedTriggeredAutoMode, deserialized.TriggeredAutoMode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::MetadataPage
        {
            PageNumber = 0,
            Confidence = 0,
            CostOptimized = true,
            OriginalOrientationAngle = 0,
            PrintedPageNumber = "printed_page_number",
            SlideSectionName = "slide_section_name",
            SpeakerNotes = "speaker_notes",
            TriggeredAutoMode = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::MetadataPage { PageNumber = 0 };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.CostOptimized);
        Assert.False(model.RawData.ContainsKey("cost_optimized"));
        Assert.Null(model.OriginalOrientationAngle);
        Assert.False(model.RawData.ContainsKey("original_orientation_angle"));
        Assert.Null(model.PrintedPageNumber);
        Assert.False(model.RawData.ContainsKey("printed_page_number"));
        Assert.Null(model.SlideSectionName);
        Assert.False(model.RawData.ContainsKey("slide_section_name"));
        Assert.Null(model.SpeakerNotes);
        Assert.False(model.RawData.ContainsKey("speaker_notes"));
        Assert.Null(model.TriggeredAutoMode);
        Assert.False(model.RawData.ContainsKey("triggered_auto_mode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::MetadataPage { PageNumber = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::MetadataPage
        {
            PageNumber = 0,

            Confidence = null,
            CostOptimized = null,
            OriginalOrientationAngle = null,
            PrintedPageNumber = null,
            SlideSectionName = null,
            SpeakerNotes = null,
            TriggeredAutoMode = null,
        };

        Assert.Null(model.Confidence);
        Assert.True(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.CostOptimized);
        Assert.True(model.RawData.ContainsKey("cost_optimized"));
        Assert.Null(model.OriginalOrientationAngle);
        Assert.True(model.RawData.ContainsKey("original_orientation_angle"));
        Assert.Null(model.PrintedPageNumber);
        Assert.True(model.RawData.ContainsKey("printed_page_number"));
        Assert.Null(model.SlideSectionName);
        Assert.True(model.RawData.ContainsKey("slide_section_name"));
        Assert.Null(model.SpeakerNotes);
        Assert.True(model.RawData.ContainsKey("speaker_notes"));
        Assert.Null(model.TriggeredAutoMode);
        Assert.True(model.RawData.ContainsKey("triggered_auto_mode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::MetadataPage
        {
            PageNumber = 0,

            Confidence = null,
            CostOptimized = null,
            OriginalOrientationAngle = null,
            PrintedPageNumber = null,
            SlideSectionName = null,
            SpeakerNotes = null,
            TriggeredAutoMode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::MetadataPage
        {
            PageNumber = 0,
            Confidence = 0,
            CostOptimized = true,
            OriginalOrientationAngle = 0,
            PrintedPageNumber = "printed_page_number",
            SlideSectionName = "slide_section_name",
            SpeakerNotes = "speaker_notes",
            TriggeredAutoMode = true,
        };

        Parsing::MetadataPage copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultContentMetadataItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::ResultContentMetadataItem
        {
            SizeBytes = 0,
            Exists = true,
            PresignedUrl = "presigned_url",
        };

        long expectedSizeBytes = 0;
        bool expectedExists = true;
        string expectedPresignedUrl = "presigned_url";

        Assert.Equal(expectedSizeBytes, model.SizeBytes);
        Assert.Equal(expectedExists, model.Exists);
        Assert.Equal(expectedPresignedUrl, model.PresignedUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::ResultContentMetadataItem
        {
            SizeBytes = 0,
            Exists = true,
            PresignedUrl = "presigned_url",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ResultContentMetadataItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::ResultContentMetadataItem
        {
            SizeBytes = 0,
            Exists = true,
            PresignedUrl = "presigned_url",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::ResultContentMetadataItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedSizeBytes = 0;
        bool expectedExists = true;
        string expectedPresignedUrl = "presigned_url";

        Assert.Equal(expectedSizeBytes, deserialized.SizeBytes);
        Assert.Equal(expectedExists, deserialized.Exists);
        Assert.Equal(expectedPresignedUrl, deserialized.PresignedUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::ResultContentMetadataItem
        {
            SizeBytes = 0,
            Exists = true,
            PresignedUrl = "presigned_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::ResultContentMetadataItem
        {
            SizeBytes = 0,
            PresignedUrl = "presigned_url",
        };

        Assert.Null(model.Exists);
        Assert.False(model.RawData.ContainsKey("exists"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::ResultContentMetadataItem
        {
            SizeBytes = 0,
            PresignedUrl = "presigned_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Parsing::ResultContentMetadataItem
        {
            SizeBytes = 0,
            PresignedUrl = "presigned_url",

            // Null should be interpreted as omitted for these properties
            Exists = null,
        };

        Assert.Null(model.Exists);
        Assert.False(model.RawData.ContainsKey("exists"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::ResultContentMetadataItem
        {
            SizeBytes = 0,
            PresignedUrl = "presigned_url",

            // Null should be interpreted as omitted for these properties
            Exists = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Parsing::ResultContentMetadataItem { SizeBytes = 0, Exists = true };

        Assert.Null(model.PresignedUrl);
        Assert.False(model.RawData.ContainsKey("presigned_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Parsing::ResultContentMetadataItem { SizeBytes = 0, Exists = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Parsing::ResultContentMetadataItem
        {
            SizeBytes = 0,
            Exists = true,

            PresignedUrl = null,
        };

        Assert.Null(model.PresignedUrl);
        Assert.True(model.RawData.ContainsKey("presigned_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Parsing::ResultContentMetadataItem
        {
            SizeBytes = 0,
            Exists = true,

            PresignedUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::ResultContentMetadataItem
        {
            SizeBytes = 0,
            Exists = true,
            PresignedUrl = "presigned_url",
        };

        Parsing::ResultContentMetadataItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TextTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::Text { Pages = [new() { PageNumber = 0, Text = "text" }] };

        List<Parsing::TextPage> expectedPages = [new() { PageNumber = 0, Text = "text" }];

        Assert.Equal(expectedPages.Count, model.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], model.Pages[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::Text { Pages = [new() { PageNumber = 0, Text = "text" }] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Text>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::Text { Pages = [new() { PageNumber = 0, Text = "text" }] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::Text>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Parsing::TextPage> expectedPages = [new() { PageNumber = 0, Text = "text" }];

        Assert.Equal(expectedPages.Count, deserialized.Pages.Count);
        for (int i = 0; i < expectedPages.Count; i++)
        {
            Assert.Equal(expectedPages[i], deserialized.Pages[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::Text { Pages = [new() { PageNumber = 0, Text = "text" }] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::Text { Pages = [new() { PageNumber = 0, Text = "text" }] };

        Parsing::Text copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TextPageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Parsing::TextPage { PageNumber = 0, Text = "text" };

        long expectedPageNumber = 0;
        string expectedText = "text";

        Assert.Equal(expectedPageNumber, model.PageNumber);
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Parsing::TextPage { PageNumber = 0, Text = "text" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::TextPage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Parsing::TextPage { PageNumber = 0, Text = "text" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Parsing::TextPage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedPageNumber = 0;
        string expectedText = "text";

        Assert.Equal(expectedPageNumber, deserialized.PageNumber);
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Parsing::TextPage { PageNumber = 0, Text = "text" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Parsing::TextPage { PageNumber = 0, Text = "text" };

        Parsing::TextPage copied = new(model);

        Assert.Equal(model, copied);
    }
}
