using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using LlamaCloud.Core;

namespace LlamaCloud.Models.Parsing;

/// <summary>
/// Retrieve a parse job with optional expanded content.
///
/// <para>By default returns job metadata only. Use `expand` to include parsed content:</para>
///
/// <para>- `text` — plain text output - `markdown` — markdown output - `items` —
/// structured page-by-page output - `job_metadata` — processing details - `usage`
/// — credits billed against the job</para>
///
/// <para>Content metadata fields (e.g. `text_content_metadata`) return presigned
/// URLs for downloading large results.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ParsingGetParams : ParamsBase
{
    public string? JobID { get; init; }

    /// <summary>
    /// Fields to include: text, markdown, items, metadata, forms, job_metadata, usage,
    /// text_content_metadata, markdown_content_metadata, items_content_metadata,
    /// metadata_content_metadata, forms_content_metadata, raw_words_content_metadata,
    /// xlsx_content_metadata, output_pdf_content_metadata, images_content_metadata.
    /// Metadata fields include presigned URLs.
    /// </summary>
    public IReadOnlyList<string>? Expand
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("expand");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "expand",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Filter to specific image filenames (optional). Example: image_0.png,image_1.jpg
    /// </summary>
    public string? ImageFilenames
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("image_filenames");
        }
        init { this._rawQueryData.Set("image_filenames", value); }
    }

    public string? OrganizationID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("organization_id");
        }
        init { this._rawQueryData.Set("organization_id", value); }
    }

    public string? ProjectID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("project_id");
        }
        init { this._rawQueryData.Set("project_id", value); }
    }

    public ParsingGetParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingGetParams(ParsingGetParams parsingGetParams)
        : base(parsingGetParams)
    {
        this.JobID = parsingGetParams.JobID;
    }
#pragma warning restore CS8618

    public ParsingGetParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsingGetParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string jobID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.JobID = jobID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ParsingGetParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string jobID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            jobID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["JobID"] = JsonSerializer.SerializeToElement(this.JobID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ParsingGetParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.JobID?.Equals(other.JobID) ?? other.JobID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/api/v2/parse/{0}", this.JobID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
