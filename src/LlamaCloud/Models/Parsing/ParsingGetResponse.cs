using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Parsing;

/// <summary>
/// Parse result response with job status and optional content or metadata.
///
/// <para>The job field is always included. Other fields are included based on expand parameters.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ParsingGetResponse, ParsingGetResponseFromRaw>))]
public sealed record class ParsingGetResponse : JsonModel
{
    /// <summary>
    /// Parse job status and metadata
    /// </summary>
    public required Job Job
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Job>("job");
        }
        init { this._rawData.Set("job", value); }
    }

    /// <summary>
    /// Per-page form analysis results (one entry per page).
    /// </summary>
    public ParsingGetResponseForms? Forms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ParsingGetResponseForms>("forms");
        }
        init { this._rawData.Set("forms", value); }
    }

    /// <summary>
    /// Metadata for all extracted images.
    /// </summary>
    public ImagesContentMetadata? ImagesContentMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ImagesContentMetadata>("images_content_metadata");
        }
        init { this._rawData.Set("images_content_metadata", value); }
    }

    /// <summary>
    /// Structured JSON result (if requested)
    /// </summary>
    public Items? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Items>("items");
        }
        init { this._rawData.Set("items", value); }
    }

    /// <summary>
    /// Job execution metadata (if requested)
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? JobMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "job_metadata"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "job_metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Markdown result (if requested)
    /// </summary>
    public ParsingGetResponseMarkdown? Markdown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ParsingGetResponseMarkdown>("markdown");
        }
        init { this._rawData.Set("markdown", value); }
    }

    /// <summary>
    /// Full raw markdown content (if requested)
    /// </summary>
    public string? MarkdownFull
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("markdown_full");
        }
        init { this._rawData.Set("markdown_full", value); }
    }

    /// <summary>
    /// Result containing metadata (page level and general) for the parsed document.
    /// </summary>
    public Metadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Metadata>("metadata");
        }
        init { this._rawData.Set("metadata", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? RawParameters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "raw_parameters"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "raw_parameters",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Metadata including size, existence, and presigned URLs for result files
    /// </summary>
    public IReadOnlyDictionary<string, ResultContentMetadataItem>? ResultContentMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                FrozenDictionary<string, ResultContentMetadataItem>
            >("result_content_metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, ResultContentMetadataItem>?>(
                "result_content_metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Plain text result (if requested)
    /// </summary>
    public Text? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Text>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// Full raw text content (if requested)
    /// </summary>
    public string? TextFull
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text_full");
        }
        init { this._rawData.Set("text_full", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Job.Validate();
        this.Forms?.Validate();
        this.ImagesContentMetadata?.Validate();
        this.Items?.Validate();
        _ = this.JobMetadata;
        this.Markdown?.Validate();
        _ = this.MarkdownFull;
        this.Metadata?.Validate();
        _ = this.RawParameters;
        if (this.ResultContentMetadata != null)
        {
            foreach (var item in this.ResultContentMetadata.Values)
            {
                item.Validate();
            }
        }
        this.Text?.Validate();
        _ = this.TextFull;
    }

    public ParsingGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingGetResponse(ParsingGetResponse parsingGetResponse)
        : base(parsingGetResponse) { }
#pragma warning restore CS8618

    public ParsingGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsingGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParsingGetResponseFromRaw.FromRawUnchecked"/>
    public static ParsingGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ParsingGetResponse(Job job)
        : this()
    {
        this.Job = job;
    }
}

class ParsingGetResponseFromRaw : IFromRawJson<ParsingGetResponse>
{
    /// <inheritdoc/>
    public ParsingGetResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ParsingGetResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Parse job status and metadata
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Job, JobFromRaw>))]
public sealed record class Job : JsonModel
{
    /// <summary>
    /// Unique parse job identifier
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Project this job belongs to
    /// </summary>
    public required string ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("project_id");
        }
        init { this._rawData.Set("project_id", value); }
    }

    /// <summary>
    /// Current job status: PENDING, RUNNING, COMPLETED, FAILED, or CANCELLED
    /// </summary>
    public required ApiEnum<string, JobStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, JobStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Creation datetime
    /// </summary>
    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Error details when status is FAILED
    /// </summary>
    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_message");
        }
        init { this._rawData.Set("error_message", value); }
    }

    /// <summary>
    /// Optional display name for this parse job
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Parsing tier used for this job
    /// </summary>
    public string? Tier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tier");
        }
        init { this._rawData.Set("tier", value); }
    }

    /// <summary>
    /// Update datetime
    /// </summary>
    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Usage recorded against a job.
    /// </summary>
    public JobUsage? Usage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<JobUsage>("usage");
        }
        init { this._rawData.Set("usage", value); }
    }

    /// <summary>
    /// Key/value tags associated with this job.
    /// </summary>
    public IReadOnlyDictionary<string, string>? UserMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "user_metadata"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>?>(
                "user_metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ProjectID;
        this.Status.Validate();
        _ = this.CreatedAt;
        _ = this.ErrorMessage;
        _ = this.Name;
        _ = this.Tier;
        _ = this.UpdatedAt;
        this.Usage?.Validate();
        _ = this.UserMetadata;
    }

    public Job() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Job(Job job)
        : base(job) { }
#pragma warning restore CS8618

    public Job(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Job(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JobFromRaw.FromRawUnchecked"/>
    public static Job FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JobFromRaw : IFromRawJson<Job>
{
    /// <inheritdoc/>
    public Job FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Job.FromRawUnchecked(rawData);
}

/// <summary>
/// Current job status: PENDING, RUNNING, COMPLETED, FAILED, or CANCELLED
/// </summary>
[JsonConverter(typeof(JobStatusConverter))]
public enum JobStatus
{
    Cancelled,
    Completed,
    Failed,
    Pending,
    Running,
}

sealed class JobStatusConverter : JsonConverter<JobStatus>
{
    public override JobStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CANCELLED" => JobStatus.Cancelled,
            "COMPLETED" => JobStatus.Completed,
            "FAILED" => JobStatus.Failed,
            "PENDING" => JobStatus.Pending,
            "RUNNING" => JobStatus.Running,
            _ => (JobStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JobStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JobStatus.Cancelled => "CANCELLED",
                JobStatus.Completed => "COMPLETED",
                JobStatus.Failed => "FAILED",
                JobStatus.Pending => "PENDING",
                JobStatus.Running => "RUNNING",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Usage recorded against a job.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JobUsage, JobUsageFromRaw>))]
public sealed record class JobUsage : JsonModel
{
    /// <summary>
    /// Total credits billed against this job. Null until billing has recorded it.
    /// </summary>
    public double? Credits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("credits");
        }
        init { this._rawData.Set("credits", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Credits;
    }

    public JobUsage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobUsage(JobUsage jobUsage)
        : base(jobUsage) { }
#pragma warning restore CS8618

    public JobUsage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JobUsage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JobUsageFromRaw.FromRawUnchecked"/>
    public static JobUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JobUsageFromRaw : IFromRawJson<JobUsage>
{
    /// <inheritdoc/>
    public JobUsage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JobUsage.FromRawUnchecked(rawData);
}

/// <summary>
/// Per-page form analysis results (one entry per page).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ParsingGetResponseForms, ParsingGetResponseFormsFromRaw>))]
public sealed record class ParsingGetResponseForms : JsonModel
{
    /// <summary>
    /// List of form pages or failed page entries
    /// </summary>
    public required IReadOnlyList<Page> Pages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Page>>("pages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Page>>(
                "pages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Pages)
        {
            item.Validate();
        }
    }

    public ParsingGetResponseForms() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingGetResponseForms(ParsingGetResponseForms parsingGetResponseForms)
        : base(parsingGetResponseForms) { }
#pragma warning restore CS8618

    public ParsingGetResponseForms(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsingGetResponseForms(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParsingGetResponseFormsFromRaw.FromRawUnchecked"/>
    public static ParsingGetResponseForms FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ParsingGetResponseForms(IReadOnlyList<Page> pages)
        : this()
    {
        this.Pages = pages;
    }
}

class ParsingGetResponseFormsFromRaw : IFromRawJson<ParsingGetResponseForms>
{
    /// <inheritdoc/>
    public ParsingGetResponseForms FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ParsingGetResponseForms.FromRawUnchecked(rawData);
}

/// <summary>
/// Forms found on one page. Pages without form content have an empty forms list.
/// </summary>
[JsonConverter(typeof(PageConverter))]
public record class Page : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long PageNumber
    {
        get { return Match(formsResult: (x) => x.PageNumber, failedForms: (x) => x.PageNumber); }
    }

    public JsonElement Success
    {
        get { return Match(formsResult: (x) => x.Success, failedForms: (x) => x.Success); }
    }

    public Page(FormsResultPage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Page(FailedFormsPage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Page(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FormsResultPage"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFormsResult(out var value)) {
    ///     // `value` is of type `FormsResultPage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFormsResult([NotNullWhen(true)] out FormsResultPage? value)
    {
        value = this.Value as FormsResultPage;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FailedFormsPage"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFailedForms(out var value)) {
    ///     // `value` is of type `FailedFormsPage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFailedForms([NotNullWhen(true)] out FailedFormsPage? value)
    {
        value = this.Value as FailedFormsPage;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (FormsResultPage value) =&gt; {...},
    ///     (FailedFormsPage value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<FormsResultPage> formsResult,
        System::Action<FailedFormsPage> failedForms
    )
    {
        switch (this.Value)
        {
            case FormsResultPage value:
                formsResult(value);
                break;
            case FailedFormsPage value:
                failedForms(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException("Data did not match any variant of Page");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (FormsResultPage value) =&gt; {...},
    ///     (FailedFormsPage value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<FormsResultPage, T> formsResult,
        System::Func<FailedFormsPage, T> failedForms
    )
    {
        return this.Value switch
        {
            FormsResultPage value => formsResult(value),
            FailedFormsPage value => failedForms(value),
            _ => throw new LlamaCloudInvalidDataException("Data did not match any variant of Page"),
        };
    }

    public static implicit operator Page(FormsResultPage value) => new(value);

    public static implicit operator Page(FailedFormsPage value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new LlamaCloudInvalidDataException("Data did not match any variant of Page");
        }
        this.Switch(
            (formsResult) => formsResult.Validate(),
            (failedForms) => failedForms.Validate()
        );
    }

    public virtual bool Equals(Page? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            FormsResultPage _ => 0,
            FailedFormsPage _ => 1,
            _ => -1,
        };
    }
}

sealed class PageConverter : JsonConverter<Page>
{
    public override Page? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<FormsResultPage>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<FailedFormsPage>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Page value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Forms found on one page. Pages without form content have an empty forms list.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FormsResultPage, FormsResultPageFromRaw>))]
public sealed record class FormsResultPage : JsonModel
{
    /// <summary>
    /// Forms detected on the page
    /// </summary>
    public required IReadOnlyList<Form> Forms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Form>>("forms");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Form>>(
                "forms",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Page number of the document
    /// </summary>
    public required long PageNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page_number");
        }
        init { this._rawData.Set("page_number", value); }
    }

    /// <summary>
    /// Success indicator
    /// </summary>
    public JsonElement Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <summary>
    /// Height of the page in points
    /// </summary>
    public double? PageHeight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("page_height");
        }
        init { this._rawData.Set("page_height", value); }
    }

    /// <summary>
    /// Width of the page in points
    /// </summary>
    public double? PageWidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("page_width");
        }
        init { this._rawData.Set("page_width", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Forms)
        {
            item.Validate();
        }
        _ = this.PageNumber;
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new LlamaCloudInvalidDataException("Invalid value given for constant");
        }
        _ = this.PageHeight;
        _ = this.PageWidth;
    }

    public FormsResultPage()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormsResultPage(FormsResultPage formsResultPage)
        : base(formsResultPage) { }
#pragma warning restore CS8618

    public FormsResultPage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormsResultPage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormsResultPageFromRaw.FromRawUnchecked"/>
    public static FormsResultPage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormsResultPageFromRaw : IFromRawJson<FormsResultPage>
{
    /// <inheritdoc/>
    public FormsResultPage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FormsResultPage.FromRawUnchecked(rawData);
}

/// <summary>
/// A page whose processing failed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FailedFormsPage, FailedFormsPageFromRaw>))]
public sealed record class FailedFormsPage : JsonModel
{
    /// <summary>
    /// Error message describing the failure
    /// </summary>
    public required string Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Page number of the document
    /// </summary>
    public required long PageNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page_number");
        }
        init { this._rawData.Set("page_number", value); }
    }

    /// <summary>
    /// Failure indicator
    /// </summary>
    public JsonElement Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Error;
        _ = this.PageNumber;
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(false)))
        {
            throw new LlamaCloudInvalidDataException("Invalid value given for constant");
        }
    }

    public FailedFormsPage()
    {
        this.Success = JsonSerializer.SerializeToElement(false);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FailedFormsPage(FailedFormsPage failedFormsPage)
        : base(failedFormsPage) { }
#pragma warning restore CS8618

    public FailedFormsPage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(false);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FailedFormsPage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FailedFormsPageFromRaw.FromRawUnchecked"/>
    public static FailedFormsPage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FailedFormsPageFromRaw : IFromRawJson<FailedFormsPage>
{
    /// <inheritdoc/>
    public FailedFormsPage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FailedFormsPage.FromRawUnchecked(rawData);
}

/// <summary>
/// Metadata for all extracted images.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ImagesContentMetadata, ImagesContentMetadataFromRaw>))]
public sealed record class ImagesContentMetadata : JsonModel
{
    /// <summary>
    /// List of image metadata with presigned URLs
    /// </summary>
    public required IReadOnlyList<ImagesContentMetadataImage> Images
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ImagesContentMetadataImage>>(
                "images"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ImagesContentMetadataImage>>(
                "images",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Total number of extracted images
    /// </summary>
    public required long TotalCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_count");
        }
        init { this._rawData.Set("total_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Images)
        {
            item.Validate();
        }
        _ = this.TotalCount;
    }

    public ImagesContentMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImagesContentMetadata(ImagesContentMetadata imagesContentMetadata)
        : base(imagesContentMetadata) { }
#pragma warning restore CS8618

    public ImagesContentMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImagesContentMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImagesContentMetadataFromRaw.FromRawUnchecked"/>
    public static ImagesContentMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImagesContentMetadataFromRaw : IFromRawJson<ImagesContentMetadata>
{
    /// <inheritdoc/>
    public ImagesContentMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ImagesContentMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Metadata for a single extracted image.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ImagesContentMetadataImage, ImagesContentMetadataImageFromRaw>)
)]
public sealed record class ImagesContentMetadataImage : JsonModel
{
    /// <summary>
    /// Image filename (e.g., 'image_0.png')
    /// </summary>
    public required string Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("filename");
        }
        init { this._rawData.Set("filename", value); }
    }

    /// <summary>
    /// Index of the image in the extraction order
    /// </summary>
    public required long Index
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("index");
        }
        init { this._rawData.Set("index", value); }
    }

    /// <summary>
    /// Bounding box for an image on its page.
    /// </summary>
    public Bbox? Bbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Bbox>("bbox");
        }
        init { this._rawData.Set("bbox", value); }
    }

    /// <summary>
    /// Image category: 'screenshot' (full page), 'embedded' (images in document),
    /// or 'layout' (cropped from layout detection)
    /// </summary>
    public ApiEnum<string, Category>? Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Category>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    /// <summary>
    /// MIME type of the image
    /// </summary>
    public string? ContentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content_type");
        }
        init { this._rawData.Set("content_type", value); }
    }

    /// <summary>
    /// Presigned URL to download the image
    /// </summary>
    public string? PresignedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("presigned_url");
        }
        init { this._rawData.Set("presigned_url", value); }
    }

    /// <summary>
    /// Deprecated: always returns None. Will be removed in a future release.
    /// </summary>
    [System::Obsolete("deprecated")]
    public long? SizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("size_bytes");
        }
        init { this._rawData.Set("size_bytes", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Filename;
        _ = this.Index;
        this.Bbox?.Validate();
        this.Category?.Validate();
        _ = this.ContentType;
        _ = this.PresignedUrl;
        _ = this.SizeBytes;
    }

    public ImagesContentMetadataImage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImagesContentMetadataImage(ImagesContentMetadataImage imagesContentMetadataImage)
        : base(imagesContentMetadataImage) { }
#pragma warning restore CS8618

    public ImagesContentMetadataImage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImagesContentMetadataImage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImagesContentMetadataImageFromRaw.FromRawUnchecked"/>
    public static ImagesContentMetadataImage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImagesContentMetadataImageFromRaw : IFromRawJson<ImagesContentMetadataImage>
{
    /// <inheritdoc/>
    public ImagesContentMetadataImage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ImagesContentMetadataImage.FromRawUnchecked(rawData);
}

/// <summary>
/// Bounding box for an image on its page.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Bbox, BboxFromRaw>))]
public sealed record class Bbox : JsonModel
{
    /// <summary>
    /// Height of the bounding box
    /// </summary>
    public required long H
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("h");
        }
        init { this._rawData.Set("h", value); }
    }

    /// <summary>
    /// Width of the bounding box
    /// </summary>
    public required long W
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("w");
        }
        init { this._rawData.Set("w", value); }
    }

    /// <summary>
    /// X coordinate of the bounding box
    /// </summary>
    public required long X
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("x");
        }
        init { this._rawData.Set("x", value); }
    }

    /// <summary>
    /// Y coordinate of the bounding box
    /// </summary>
    public required long Y
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("y");
        }
        init { this._rawData.Set("y", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.H;
        _ = this.W;
        _ = this.X;
        _ = this.Y;
    }

    public Bbox() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Bbox(Bbox bbox)
        : base(bbox) { }
#pragma warning restore CS8618

    public Bbox(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Bbox(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BboxFromRaw.FromRawUnchecked"/>
    public static Bbox FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BboxFromRaw : IFromRawJson<Bbox>
{
    /// <inheritdoc/>
    public Bbox FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Bbox.FromRawUnchecked(rawData);
}

/// <summary>
/// Image category: 'screenshot' (full page), 'embedded' (images in document), or
/// 'layout' (cropped from layout detection)
/// </summary>
[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    Embedded,
    Layout,
    Screenshot,
}

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "embedded" => Category.Embedded,
            "layout" => Category.Layout,
            "screenshot" => Category.Screenshot,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.Embedded => "embedded",
                Category.Layout => "layout",
                Category.Screenshot => "screenshot",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Structured JSON result (if requested)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Items, ItemsFromRaw>))]
public sealed record class Items : JsonModel
{
    /// <summary>
    /// List of structured pages or failed page entries
    /// </summary>
    public required IReadOnlyList<ItemsPage> Pages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ItemsPage>>("pages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ItemsPage>>(
                "pages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Pages)
        {
            item.Validate();
        }
    }

    public Items() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Items(Items items)
        : base(items) { }
#pragma warning restore CS8618

    public Items(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Items(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemsFromRaw.FromRawUnchecked"/>
    public static Items FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Items(IReadOnlyList<ItemsPage> pages)
        : this()
    {
        this.Pages = pages;
    }
}

class ItemsFromRaw : IFromRawJson<Items>
{
    /// <inheritdoc/>
    public Items FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Items.FromRawUnchecked(rawData);
}

/// <summary>
/// Successfully parsed page in structured items output.
/// </summary>
[JsonConverter(typeof(ItemsPageConverter))]
public record class ItemsPage : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long PageNumber
    {
        get
        {
            return Match(
                structuredResult: (x) => x.PageNumber,
                failedStructured: (x) => x.PageNumber
            );
        }
    }

    public JsonElement Success
    {
        get
        {
            return Match(structuredResult: (x) => x.Success, failedStructured: (x) => x.Success);
        }
    }

    public ItemsPage(StructuredResultPage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ItemsPage(FailedStructuredPage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ItemsPage(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="StructuredResultPage"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStructuredResult(out var value)) {
    ///     // `value` is of type `StructuredResultPage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStructuredResult([NotNullWhen(true)] out StructuredResultPage? value)
    {
        value = this.Value as StructuredResultPage;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FailedStructuredPage"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFailedStructured(out var value)) {
    ///     // `value` is of type `FailedStructuredPage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFailedStructured([NotNullWhen(true)] out FailedStructuredPage? value)
    {
        value = this.Value as FailedStructuredPage;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (StructuredResultPage value) =&gt; {...},
    ///     (FailedStructuredPage value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<StructuredResultPage> structuredResult,
        System::Action<FailedStructuredPage> failedStructured
    )
    {
        switch (this.Value)
        {
            case StructuredResultPage value:
                structuredResult(value);
                break;
            case FailedStructuredPage value:
                failedStructured(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of ItemsPage"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (StructuredResultPage value) =&gt; {...},
    ///     (FailedStructuredPage value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<StructuredResultPage, T> structuredResult,
        System::Func<FailedStructuredPage, T> failedStructured
    )
    {
        return this.Value switch
        {
            StructuredResultPage value => structuredResult(value),
            FailedStructuredPage value => failedStructured(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of ItemsPage"
            ),
        };
    }

    public static implicit operator ItemsPage(StructuredResultPage value) => new(value);

    public static implicit operator ItemsPage(FailedStructuredPage value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new LlamaCloudInvalidDataException("Data did not match any variant of ItemsPage");
        }
        this.Switch(
            (structuredResult) => structuredResult.Validate(),
            (failedStructured) => failedStructured.Validate()
        );
    }

    public virtual bool Equals(ItemsPage? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            StructuredResultPage _ => 0,
            FailedStructuredPage _ => 1,
            _ => -1,
        };
    }
}

sealed class ItemsPageConverter : JsonConverter<ItemsPage>
{
    public override ItemsPage? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<StructuredResultPage>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<FailedStructuredPage>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ItemsPage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Successfully parsed page in structured items output.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<StructuredResultPage, StructuredResultPageFromRaw>))]
public sealed record class StructuredResultPage : JsonModel
{
    /// <summary>
    /// List of structured items on the page
    /// </summary>
    public required IReadOnlyList<StructuredResultPageItem> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<StructuredResultPageItem>>(
                "items"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<StructuredResultPageItem>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Height of the page in points
    /// </summary>
    public required double PageHeight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("page_height");
        }
        init { this._rawData.Set("page_height", value); }
    }

    /// <summary>
    /// Page number of the document
    /// </summary>
    public required long PageNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page_number");
        }
        init { this._rawData.Set("page_number", value); }
    }

    /// <summary>
    /// Width of the page in points
    /// </summary>
    public required double PageWidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("page_width");
        }
        init { this._rawData.Set("page_width", value); }
    }

    /// <summary>
    /// Success indicator
    /// </summary>
    public JsonElement Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <summary>
    /// Extracted revisions and comments on the page
    /// </summary>
    public IReadOnlyList<Revision>? Revisions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Revision>>("revisions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Revision>?>(
                "revisions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.PageHeight;
        _ = this.PageNumber;
        _ = this.PageWidth;
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new LlamaCloudInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.Revisions ?? [])
        {
            item.Validate();
        }
    }

    public StructuredResultPage()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StructuredResultPage(StructuredResultPage structuredResultPage)
        : base(structuredResultPage) { }
#pragma warning restore CS8618

    public StructuredResultPage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StructuredResultPage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StructuredResultPageFromRaw.FromRawUnchecked"/>
    public static StructuredResultPage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StructuredResultPageFromRaw : IFromRawJson<StructuredResultPage>
{
    /// <inheritdoc/>
    public StructuredResultPage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => StructuredResultPage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StructuredResultPageItemConverter))]
public record class StructuredResultPageItem : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string Md
    {
        get
        {
            return Match(
                code: (x) => x.Md,
                footer: (x) => x.Md,
                header: (x) => x.Md,
                heading: (x) => x.Md,
                image: (x) => x.Md,
                link: (x) => x.Md,
                list: (x) => x.Md,
                table: (x) => x.Md,
                text: (x) => x.Md
            );
        }
    }

    public string? ValueValue
    {
        get
        {
            return Match<string?>(
                code: (x) => x.ValueValue,
                footer: (_) => null,
                header: (_) => null,
                heading: (x) => x.Value,
                image: (_) => null,
                link: (_) => null,
                list: (_) => null,
                table: (_) => null,
                text: (x) => x.Value
            );
        }
    }

    public string? Url
    {
        get
        {
            return Match<string?>(
                code: (_) => null,
                footer: (_) => null,
                header: (_) => null,
                heading: (_) => null,
                image: (x) => x.Url,
                link: (x) => x.Url,
                list: (_) => null,
                table: (_) => null,
                text: (_) => null
            );
        }
    }

    public StructuredResultPageItem(CodeItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public StructuredResultPageItem(FooterItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public StructuredResultPageItem(HeaderItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public StructuredResultPageItem(HeadingItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public StructuredResultPageItem(ImageItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public StructuredResultPageItem(LinkItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public StructuredResultPageItem(ListItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public StructuredResultPageItem(TableItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public StructuredResultPageItem(TextItem value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public StructuredResultPageItem(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CodeItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCode(out var value)) {
    ///     // `value` is of type `CodeItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCode([NotNullWhen(true)] out CodeItem? value)
    {
        value = this.Value as CodeItem;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FooterItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFooter(out var value)) {
    ///     // `value` is of type `FooterItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFooter([NotNullWhen(true)] out FooterItem? value)
    {
        value = this.Value as FooterItem;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="HeaderItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickHeader(out var value)) {
    ///     // `value` is of type `HeaderItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickHeader([NotNullWhen(true)] out HeaderItem? value)
    {
        value = this.Value as HeaderItem;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="HeadingItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickHeading(out var value)) {
    ///     // `value` is of type `HeadingItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickHeading([NotNullWhen(true)] out HeadingItem? value)
    {
        value = this.Value as HeadingItem;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ImageItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickImage(out var value)) {
    ///     // `value` is of type `ImageItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickImage([NotNullWhen(true)] out ImageItem? value)
    {
        value = this.Value as ImageItem;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="LinkItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLink(out var value)) {
    ///     // `value` is of type `LinkItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLink([NotNullWhen(true)] out LinkItem? value)
    {
        value = this.Value as LinkItem;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ListItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickList(out var value)) {
    ///     // `value` is of type `ListItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickList([NotNullWhen(true)] out ListItem? value)
    {
        value = this.Value as ListItem;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TableItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTable(out var value)) {
    ///     // `value` is of type `TableItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTable([NotNullWhen(true)] out TableItem? value)
    {
        value = this.Value as TableItem;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextItem"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickText(out var value)) {
    ///     // `value` is of type `TextItem`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickText([NotNullWhen(true)] out TextItem? value)
    {
        value = this.Value as TextItem;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (CodeItem value) =&gt; {...},
    ///     (FooterItem value) =&gt; {...},
    ///     (HeaderItem value) =&gt; {...},
    ///     (HeadingItem value) =&gt; {...},
    ///     (ImageItem value) =&gt; {...},
    ///     (LinkItem value) =&gt; {...},
    ///     (ListItem value) =&gt; {...},
    ///     (TableItem value) =&gt; {...},
    ///     (TextItem value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<CodeItem> code,
        System::Action<FooterItem> footer,
        System::Action<HeaderItem> header,
        System::Action<HeadingItem> heading,
        System::Action<ImageItem> image,
        System::Action<LinkItem> link,
        System::Action<ListItem> list,
        System::Action<TableItem> table,
        System::Action<TextItem> text
    )
    {
        switch (this.Value)
        {
            case CodeItem value:
                code(value);
                break;
            case FooterItem value:
                footer(value);
                break;
            case HeaderItem value:
                header(value);
                break;
            case HeadingItem value:
                heading(value);
                break;
            case ImageItem value:
                image(value);
                break;
            case LinkItem value:
                link(value);
                break;
            case ListItem value:
                list(value);
                break;
            case TableItem value:
                table(value);
                break;
            case TextItem value:
                text(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of StructuredResultPageItem"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (CodeItem value) =&gt; {...},
    ///     (FooterItem value) =&gt; {...},
    ///     (HeaderItem value) =&gt; {...},
    ///     (HeadingItem value) =&gt; {...},
    ///     (ImageItem value) =&gt; {...},
    ///     (LinkItem value) =&gt; {...},
    ///     (ListItem value) =&gt; {...},
    ///     (TableItem value) =&gt; {...},
    ///     (TextItem value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<CodeItem, T> code,
        System::Func<FooterItem, T> footer,
        System::Func<HeaderItem, T> header,
        System::Func<HeadingItem, T> heading,
        System::Func<ImageItem, T> image,
        System::Func<LinkItem, T> link,
        System::Func<ListItem, T> list,
        System::Func<TableItem, T> table,
        System::Func<TextItem, T> text
    )
    {
        return this.Value switch
        {
            CodeItem value => code(value),
            FooterItem value => footer(value),
            HeaderItem value => header(value),
            HeadingItem value => heading(value),
            ImageItem value => image(value),
            LinkItem value => link(value),
            ListItem value => list(value),
            TableItem value => table(value),
            TextItem value => text(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of StructuredResultPageItem"
            ),
        };
    }

    public static implicit operator StructuredResultPageItem(CodeItem value) => new(value);

    public static implicit operator StructuredResultPageItem(FooterItem value) => new(value);

    public static implicit operator StructuredResultPageItem(HeaderItem value) => new(value);

    public static implicit operator StructuredResultPageItem(HeadingItem value) => new(value);

    public static implicit operator StructuredResultPageItem(ImageItem value) => new(value);

    public static implicit operator StructuredResultPageItem(LinkItem value) => new(value);

    public static implicit operator StructuredResultPageItem(ListItem value) => new(value);

    public static implicit operator StructuredResultPageItem(TableItem value) => new(value);

    public static implicit operator StructuredResultPageItem(TextItem value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of StructuredResultPageItem"
            );
        }
        this.Switch(
            (code) => code.Validate(),
            (footer) => footer.Validate(),
            (header) => header.Validate(),
            (heading) => heading.Validate(),
            (image) => image.Validate(),
            (link) => link.Validate(),
            (list) => list.Validate(),
            (table) => table.Validate(),
            (text) => text.Validate()
        );
    }

    public virtual bool Equals(StructuredResultPageItem? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            CodeItem _ => 0,
            FooterItem _ => 1,
            HeaderItem _ => 2,
            HeadingItem _ => 3,
            ImageItem _ => 4,
            LinkItem _ => 5,
            ListItem _ => 6,
            TableItem _ => 7,
            TextItem _ => 8,
            _ => -1,
        };
    }
}

sealed class StructuredResultPageItemConverter : JsonConverter<StructuredResultPageItem>
{
    public override StructuredResultPageItem? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "code":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CodeItem>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "footer":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<FooterItem>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "header":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<HeaderItem>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "heading":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<HeadingItem>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "image":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ImageItem>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "link":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<LinkItem>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "list":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ListItem>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "table":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TableItem>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "text":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TextItem>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new StructuredResultPageItem(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        StructuredResultPageItem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// One extracted document revision linked to page content.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Revision, RevisionFromRaw>))]
public sealed record class Revision : JsonModel
{
    /// <summary>
    /// Revision or comment content
    /// </summary>
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// Bounding box of the printed revision balloon
    /// </summary>
    public required RevisionBbox RevisionBbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RevisionBbox>("revision_bbox");
        }
        init { this._rawData.Set("revision_bbox", value); }
    }

    /// <summary>
    /// Best available target text in the page content
    /// </summary>
    public required string Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    /// <summary>
    /// Union bounding box of the target spans
    /// </summary>
    public required TargetBbox TargetBbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TargetBbox>("target_bbox");
        }
        init { this._rawData.Set("target_bbox", value); }
    }

    /// <summary>
    /// Type of revision
    /// </summary>
    public required ApiEnum<string, RevisionType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RevisionType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Revision author, when available
    /// </summary>
    public string? Author
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("author");
        }
        init { this._rawData.Set("author", value); }
    }

    /// <summary>
    /// Exclusive end offset in final page markdown
    /// </summary>
    public long? EndIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("end_index");
        }
        init { this._rawData.Set("end_index", value); }
    }

    /// <summary>
    /// Inclusive start offset in final page markdown
    /// </summary>
    public long? StartIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("start_index");
        }
        init { this._rawData.Set("start_index", value); }
    }

    /// <summary>
    /// Disconnected target spans, when present
    /// </summary>
    public IReadOnlyList<TargetSpan>? TargetSpans
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TargetSpan>>("target_spans");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TargetSpan>?>(
                "target_spans",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        this.RevisionBbox.Validate();
        _ = this.Target;
        this.TargetBbox.Validate();
        this.Type.Validate();
        _ = this.Author;
        _ = this.EndIndex;
        _ = this.StartIndex;
        foreach (var item in this.TargetSpans ?? [])
        {
            item.Validate();
        }
    }

    public Revision() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Revision(Revision revision)
        : base(revision) { }
#pragma warning restore CS8618

    public Revision(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Revision(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RevisionFromRaw.FromRawUnchecked"/>
    public static Revision FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RevisionFromRaw : IFromRawJson<Revision>
{
    /// <inheritdoc/>
    public Revision FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Revision.FromRawUnchecked(rawData);
}

/// <summary>
/// Bounding box of the printed revision balloon
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RevisionBbox, RevisionBboxFromRaw>))]
public sealed record class RevisionBbox : JsonModel
{
    /// <summary>
    /// Height of the bounding box
    /// </summary>
    public required double H
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("h");
        }
        init { this._rawData.Set("h", value); }
    }

    /// <summary>
    /// Width of the bounding box
    /// </summary>
    public required double W
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("w");
        }
        init { this._rawData.Set("w", value); }
    }

    /// <summary>
    /// X coordinate of the bounding box
    /// </summary>
    public required double X
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("x");
        }
        init { this._rawData.Set("x", value); }
    }

    /// <summary>
    /// Y coordinate of the bounding box
    /// </summary>
    public required double Y
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("y");
        }
        init { this._rawData.Set("y", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.H;
        _ = this.W;
        _ = this.X;
        _ = this.Y;
    }

    public RevisionBbox() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RevisionBbox(RevisionBbox revisionBbox)
        : base(revisionBbox) { }
#pragma warning restore CS8618

    public RevisionBbox(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RevisionBbox(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RevisionBboxFromRaw.FromRawUnchecked"/>
    public static RevisionBbox FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RevisionBboxFromRaw : IFromRawJson<RevisionBbox>
{
    /// <inheritdoc/>
    public RevisionBbox FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RevisionBbox.FromRawUnchecked(rawData);
}

/// <summary>
/// Union bounding box of the target spans
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TargetBbox, TargetBboxFromRaw>))]
public sealed record class TargetBbox : JsonModel
{
    /// <summary>
    /// Height of the bounding box
    /// </summary>
    public required double H
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("h");
        }
        init { this._rawData.Set("h", value); }
    }

    /// <summary>
    /// Width of the bounding box
    /// </summary>
    public required double W
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("w");
        }
        init { this._rawData.Set("w", value); }
    }

    /// <summary>
    /// X coordinate of the bounding box
    /// </summary>
    public required double X
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("x");
        }
        init { this._rawData.Set("x", value); }
    }

    /// <summary>
    /// Y coordinate of the bounding box
    /// </summary>
    public required double Y
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("y");
        }
        init { this._rawData.Set("y", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.H;
        _ = this.W;
        _ = this.X;
        _ = this.Y;
    }

    public TargetBbox() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TargetBbox(TargetBbox targetBbox)
        : base(targetBbox) { }
#pragma warning restore CS8618

    public TargetBbox(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TargetBbox(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TargetBboxFromRaw.FromRawUnchecked"/>
    public static TargetBbox FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TargetBboxFromRaw : IFromRawJson<TargetBbox>
{
    /// <inheritdoc/>
    public TargetBbox FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TargetBbox.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of revision
/// </summary>
[JsonConverter(typeof(RevisionTypeConverter))]
public enum RevisionType
{
    Comment,
    Deleted,
    Formatted,
    Inserted,
    MovedFrom,
    MovedTo,
}

sealed class RevisionTypeConverter : JsonConverter<RevisionType>
{
    public override RevisionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "comment" => RevisionType.Comment,
            "deleted" => RevisionType.Deleted,
            "formatted" => RevisionType.Formatted,
            "inserted" => RevisionType.Inserted,
            "moved_from" => RevisionType.MovedFrom,
            "moved_to" => RevisionType.MovedTo,
            _ => (RevisionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RevisionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RevisionType.Comment => "comment",
                RevisionType.Deleted => "deleted",
                RevisionType.Formatted => "formatted",
                RevisionType.Inserted => "inserted",
                RevisionType.MovedFrom => "moved_from",
                RevisionType.MovedTo => "moved_to",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// One contiguous target span linked to a document revision.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TargetSpan, TargetSpanFromRaw>))]
public sealed record class TargetSpan : JsonModel
{
    /// <summary>
    /// Text covered by this target span
    /// </summary>
    public required string Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    /// <summary>
    /// Bounding box of this target span
    /// </summary>
    public required TargetSpanTargetBbox TargetBbox
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TargetSpanTargetBbox>("target_bbox");
        }
        init { this._rawData.Set("target_bbox", value); }
    }

    /// <summary>
    /// Exclusive end offset in final page markdown
    /// </summary>
    public long? EndIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("end_index");
        }
        init { this._rawData.Set("end_index", value); }
    }

    /// <summary>
    /// Inclusive start offset in final page markdown
    /// </summary>
    public long? StartIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("start_index");
        }
        init { this._rawData.Set("start_index", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Target;
        this.TargetBbox.Validate();
        _ = this.EndIndex;
        _ = this.StartIndex;
    }

    public TargetSpan() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TargetSpan(TargetSpan targetSpan)
        : base(targetSpan) { }
#pragma warning restore CS8618

    public TargetSpan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TargetSpan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TargetSpanFromRaw.FromRawUnchecked"/>
    public static TargetSpan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TargetSpanFromRaw : IFromRawJson<TargetSpan>
{
    /// <inheritdoc/>
    public TargetSpan FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TargetSpan.FromRawUnchecked(rawData);
}

/// <summary>
/// Bounding box of this target span
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TargetSpanTargetBbox, TargetSpanTargetBboxFromRaw>))]
public sealed record class TargetSpanTargetBbox : JsonModel
{
    /// <summary>
    /// Height of the bounding box
    /// </summary>
    public required double H
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("h");
        }
        init { this._rawData.Set("h", value); }
    }

    /// <summary>
    /// Width of the bounding box
    /// </summary>
    public required double W
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("w");
        }
        init { this._rawData.Set("w", value); }
    }

    /// <summary>
    /// X coordinate of the bounding box
    /// </summary>
    public required double X
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("x");
        }
        init { this._rawData.Set("x", value); }
    }

    /// <summary>
    /// Y coordinate of the bounding box
    /// </summary>
    public required double Y
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("y");
        }
        init { this._rawData.Set("y", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.H;
        _ = this.W;
        _ = this.X;
        _ = this.Y;
    }

    public TargetSpanTargetBbox() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TargetSpanTargetBbox(TargetSpanTargetBbox targetSpanTargetBbox)
        : base(targetSpanTargetBbox) { }
#pragma warning restore CS8618

    public TargetSpanTargetBbox(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TargetSpanTargetBbox(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TargetSpanTargetBboxFromRaw.FromRawUnchecked"/>
    public static TargetSpanTargetBbox FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TargetSpanTargetBboxFromRaw : IFromRawJson<TargetSpanTargetBbox>
{
    /// <inheritdoc/>
    public TargetSpanTargetBbox FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TargetSpanTargetBbox.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FailedStructuredPage, FailedStructuredPageFromRaw>))]
public sealed record class FailedStructuredPage : JsonModel
{
    /// <summary>
    /// Error message describing the failure
    /// </summary>
    public required string Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Page number of the document
    /// </summary>
    public required long PageNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page_number");
        }
        init { this._rawData.Set("page_number", value); }
    }

    /// <summary>
    /// Failure indicator
    /// </summary>
    public JsonElement Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Error;
        _ = this.PageNumber;
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(false)))
        {
            throw new LlamaCloudInvalidDataException("Invalid value given for constant");
        }
    }

    public FailedStructuredPage()
    {
        this.Success = JsonSerializer.SerializeToElement(false);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FailedStructuredPage(FailedStructuredPage failedStructuredPage)
        : base(failedStructuredPage) { }
#pragma warning restore CS8618

    public FailedStructuredPage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(false);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FailedStructuredPage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FailedStructuredPageFromRaw.FromRawUnchecked"/>
    public static FailedStructuredPage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FailedStructuredPageFromRaw : IFromRawJson<FailedStructuredPage>
{
    /// <inheritdoc/>
    public FailedStructuredPage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FailedStructuredPage.FromRawUnchecked(rawData);
}

/// <summary>
/// Markdown result (if requested)
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ParsingGetResponseMarkdown, ParsingGetResponseMarkdownFromRaw>)
)]
public sealed record class ParsingGetResponseMarkdown : JsonModel
{
    /// <summary>
    /// List of markdown pages or failed page entries
    /// </summary>
    public required IReadOnlyList<ParsingGetResponseMarkdownPage> Pages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ParsingGetResponseMarkdownPage>>(
                "pages"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ParsingGetResponseMarkdownPage>>(
                "pages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Pages)
        {
            item.Validate();
        }
    }

    public ParsingGetResponseMarkdown() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingGetResponseMarkdown(ParsingGetResponseMarkdown parsingGetResponseMarkdown)
        : base(parsingGetResponseMarkdown) { }
#pragma warning restore CS8618

    public ParsingGetResponseMarkdown(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsingGetResponseMarkdown(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ParsingGetResponseMarkdownFromRaw.FromRawUnchecked"/>
    public static ParsingGetResponseMarkdown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ParsingGetResponseMarkdown(IReadOnlyList<ParsingGetResponseMarkdownPage> pages)
        : this()
    {
        this.Pages = pages;
    }
}

class ParsingGetResponseMarkdownFromRaw : IFromRawJson<ParsingGetResponseMarkdown>
{
    /// <inheritdoc/>
    public ParsingGetResponseMarkdown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ParsingGetResponseMarkdown.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ParsingGetResponseMarkdownPageConverter))]
public record class ParsingGetResponseMarkdownPage : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long PageNumber
    {
        get
        {
            return Match(markdownResult: (x) => x.PageNumber, failedMarkdown: (x) => x.PageNumber);
        }
    }

    public JsonElement Success
    {
        get { return Match(markdownResult: (x) => x.Success, failedMarkdown: (x) => x.Success); }
    }

    public ParsingGetResponseMarkdownPage(MarkdownResultPage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ParsingGetResponseMarkdownPage(FailedMarkdownPage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ParsingGetResponseMarkdownPage(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="MarkdownResultPage"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMarkdownResult(out var value)) {
    ///     // `value` is of type `MarkdownResultPage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMarkdownResult([NotNullWhen(true)] out MarkdownResultPage? value)
    {
        value = this.Value as MarkdownResultPage;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FailedMarkdownPage"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFailedMarkdown(out var value)) {
    ///     // `value` is of type `FailedMarkdownPage`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFailedMarkdown([NotNullWhen(true)] out FailedMarkdownPage? value)
    {
        value = this.Value as FailedMarkdownPage;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (MarkdownResultPage value) =&gt; {...},
    ///     (FailedMarkdownPage value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<MarkdownResultPage> markdownResult,
        System::Action<FailedMarkdownPage> failedMarkdown
    )
    {
        switch (this.Value)
        {
            case MarkdownResultPage value:
                markdownResult(value);
                break;
            case FailedMarkdownPage value:
                failedMarkdown(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of ParsingGetResponseMarkdownPage"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (MarkdownResultPage value) =&gt; {...},
    ///     (FailedMarkdownPage value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<MarkdownResultPage, T> markdownResult,
        System::Func<FailedMarkdownPage, T> failedMarkdown
    )
    {
        return this.Value switch
        {
            MarkdownResultPage value => markdownResult(value),
            FailedMarkdownPage value => failedMarkdown(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of ParsingGetResponseMarkdownPage"
            ),
        };
    }

    public static implicit operator ParsingGetResponseMarkdownPage(MarkdownResultPage value) =>
        new(value);

    public static implicit operator ParsingGetResponseMarkdownPage(FailedMarkdownPage value) =>
        new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="LlamaCloudInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of ParsingGetResponseMarkdownPage"
            );
        }
        this.Switch(
            (markdownResult) => markdownResult.Validate(),
            (failedMarkdown) => failedMarkdown.Validate()
        );
    }

    public virtual bool Equals(ParsingGetResponseMarkdownPage? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            MarkdownResultPage _ => 0,
            FailedMarkdownPage _ => 1,
            _ => -1,
        };
    }
}

sealed class ParsingGetResponseMarkdownPageConverter : JsonConverter<ParsingGetResponseMarkdownPage>
{
    public override ParsingGetResponseMarkdownPage? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<MarkdownResultPage>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<FailedMarkdownPage>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ParsingGetResponseMarkdownPage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<MarkdownResultPage, MarkdownResultPageFromRaw>))]
public sealed record class MarkdownResultPage : JsonModel
{
    /// <summary>
    /// Markdown content of the page
    /// </summary>
    public required string Markdown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("markdown");
        }
        init { this._rawData.Set("markdown", value); }
    }

    /// <summary>
    /// Page number of the document
    /// </summary>
    public required long PageNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page_number");
        }
        init { this._rawData.Set("page_number", value); }
    }

    /// <summary>
    /// Success indicator
    /// </summary>
    public JsonElement Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <summary>
    /// Footer of the page in markdown
    /// </summary>
    public string? Footer
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("footer");
        }
        init { this._rawData.Set("footer", value); }
    }

    /// <summary>
    /// Header of the page in markdown
    /// </summary>
    public string? Header
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("header");
        }
        init { this._rawData.Set("header", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Markdown;
        _ = this.PageNumber;
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(true)))
        {
            throw new LlamaCloudInvalidDataException("Invalid value given for constant");
        }
        _ = this.Footer;
        _ = this.Header;
    }

    public MarkdownResultPage()
    {
        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MarkdownResultPage(MarkdownResultPage markdownResultPage)
        : base(markdownResultPage) { }
#pragma warning restore CS8618

    public MarkdownResultPage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(true);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MarkdownResultPage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MarkdownResultPageFromRaw.FromRawUnchecked"/>
    public static MarkdownResultPage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MarkdownResultPageFromRaw : IFromRawJson<MarkdownResultPage>
{
    /// <inheritdoc/>
    public MarkdownResultPage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MarkdownResultPage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FailedMarkdownPage, FailedMarkdownPageFromRaw>))]
public sealed record class FailedMarkdownPage : JsonModel
{
    /// <summary>
    /// Error message describing the failure
    /// </summary>
    public required string Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// Page number of the document
    /// </summary>
    public required long PageNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page_number");
        }
        init { this._rawData.Set("page_number", value); }
    }

    /// <summary>
    /// Failure indicator
    /// </summary>
    public JsonElement Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Error;
        _ = this.PageNumber;
        if (!JsonElement.DeepEquals(this.Success, JsonSerializer.SerializeToElement(false)))
        {
            throw new LlamaCloudInvalidDataException("Invalid value given for constant");
        }
    }

    public FailedMarkdownPage()
    {
        this.Success = JsonSerializer.SerializeToElement(false);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FailedMarkdownPage(FailedMarkdownPage failedMarkdownPage)
        : base(failedMarkdownPage) { }
#pragma warning restore CS8618

    public FailedMarkdownPage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Success = JsonSerializer.SerializeToElement(false);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FailedMarkdownPage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FailedMarkdownPageFromRaw.FromRawUnchecked"/>
    public static FailedMarkdownPage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FailedMarkdownPageFromRaw : IFromRawJson<FailedMarkdownPage>
{
    /// <inheritdoc/>
    public FailedMarkdownPage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FailedMarkdownPage.FromRawUnchecked(rawData);
}

/// <summary>
/// Result containing metadata (page level and general) for the parsed document.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Metadata, MetadataFromRaw>))]
public sealed record class Metadata : JsonModel
{
    /// <summary>
    /// List of page metadata entries
    /// </summary>
    public required IReadOnlyList<MetadataPage> Pages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MetadataPage>>("pages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<MetadataPage>>(
                "pages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Pages)
        {
            item.Validate();
        }
    }

    public Metadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Metadata(Metadata metadata)
        : base(metadata) { }
#pragma warning restore CS8618

    public Metadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetadataFromRaw.FromRawUnchecked"/>
    public static Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Metadata(IReadOnlyList<MetadataPage> pages)
        : this()
    {
        this.Pages = pages;
    }
}

class MetadataFromRaw : IFromRawJson<Metadata>
{
    /// <inheritdoc/>
    public Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Metadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Page-level metadata including confidence scores and presentation-specific data.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MetadataPage, MetadataPageFromRaw>))]
public sealed record class MetadataPage : JsonModel
{
    /// <summary>
    /// Page number of the document
    /// </summary>
    public required long PageNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page_number");
        }
        init { this._rawData.Set("page_number", value); }
    }

    /// <summary>
    /// Confidence score for the page parsing (0-1)
    /// </summary>
    public double? Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("confidence");
        }
        init { this._rawData.Set("confidence", value); }
    }

    /// <summary>
    /// Whether cost-optimized parsing was used for the page
    /// </summary>
    public bool? CostOptimized
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("cost_optimized");
        }
        init { this._rawData.Set("cost_optimized", value); }
    }

    /// <summary>
    /// Original orientation angle of the page in degrees
    /// </summary>
    public long? OriginalOrientationAngle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("original_orientation_angle");
        }
        init { this._rawData.Set("original_orientation_angle", value); }
    }

    /// <summary>
    /// Printed page number as it appears in the document
    /// </summary>
    public string? PrintedPageNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("printed_page_number");
        }
        init { this._rawData.Set("printed_page_number", value); }
    }

    /// <summary>
    /// Section name from presentation slides
    /// </summary>
    public string? SlideSectionName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("slide_section_name");
        }
        init { this._rawData.Set("slide_section_name", value); }
    }

    /// <summary>
    /// Speaker notes from presentation slides
    /// </summary>
    public string? SpeakerNotes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("speaker_notes");
        }
        init { this._rawData.Set("speaker_notes", value); }
    }

    /// <summary>
    /// Whether auto mode was triggered for the page
    /// </summary>
    public bool? TriggeredAutoMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("triggered_auto_mode");
        }
        init { this._rawData.Set("triggered_auto_mode", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PageNumber;
        _ = this.Confidence;
        _ = this.CostOptimized;
        _ = this.OriginalOrientationAngle;
        _ = this.PrintedPageNumber;
        _ = this.SlideSectionName;
        _ = this.SpeakerNotes;
        _ = this.TriggeredAutoMode;
    }

    public MetadataPage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MetadataPage(MetadataPage metadataPage)
        : base(metadataPage) { }
#pragma warning restore CS8618

    public MetadataPage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MetadataPage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetadataPageFromRaw.FromRawUnchecked"/>
    public static MetadataPage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public MetadataPage(long pageNumber)
        : this()
    {
        this.PageNumber = pageNumber;
    }
}

class MetadataPageFromRaw : IFromRawJson<MetadataPage>
{
    /// <inheritdoc/>
    public MetadataPage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MetadataPage.FromRawUnchecked(rawData);
}

/// <summary>
/// Metadata about a specific result type stored in S3.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ResultContentMetadataItem, ResultContentMetadataItemFromRaw>)
)]
public sealed record class ResultContentMetadataItem : JsonModel
{
    /// <summary>
    /// Size of the result file in bytes
    /// </summary>
    public required long SizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("size_bytes");
        }
        init { this._rawData.Set("size_bytes", value); }
    }

    /// <summary>
    /// Whether the result file exists in S3
    /// </summary>
    public bool? Exists
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("exists");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("exists", value);
        }
    }

    /// <summary>
    /// Presigned URL to download the result file
    /// </summary>
    public string? PresignedUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("presigned_url");
        }
        init { this._rawData.Set("presigned_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SizeBytes;
        _ = this.Exists;
        _ = this.PresignedUrl;
    }

    public ResultContentMetadataItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResultContentMetadataItem(ResultContentMetadataItem resultContentMetadataItem)
        : base(resultContentMetadataItem) { }
#pragma warning restore CS8618

    public ResultContentMetadataItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResultContentMetadataItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResultContentMetadataItemFromRaw.FromRawUnchecked"/>
    public static ResultContentMetadataItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ResultContentMetadataItem(long sizeBytes)
        : this()
    {
        this.SizeBytes = sizeBytes;
    }
}

class ResultContentMetadataItemFromRaw : IFromRawJson<ResultContentMetadataItem>
{
    /// <inheritdoc/>
    public ResultContentMetadataItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ResultContentMetadataItem.FromRawUnchecked(rawData);
}

/// <summary>
/// Plain text result (if requested)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Text, TextFromRaw>))]
public sealed record class Text : JsonModel
{
    /// <summary>
    /// List of text pages
    /// </summary>
    public required IReadOnlyList<TextPage> Pages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TextPage>>("pages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TextPage>>(
                "pages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Pages)
        {
            item.Validate();
        }
    }

    public Text() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Text(Text text)
        : base(text) { }
#pragma warning restore CS8618

    public Text(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Text(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextFromRaw.FromRawUnchecked"/>
    public static Text FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Text(IReadOnlyList<TextPage> pages)
        : this()
    {
        this.Pages = pages;
    }
}

class TextFromRaw : IFromRawJson<Text>
{
    /// <inheritdoc/>
    public Text FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Text.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TextPage, TextPageFromRaw>))]
public sealed record class TextPage : JsonModel
{
    /// <summary>
    /// Page number of the document
    /// </summary>
    public required long PageNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("page_number");
        }
        init { this._rawData.Set("page_number", value); }
    }

    /// <summary>
    /// Plain text content of the page
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PageNumber;
        _ = this.Text;
    }

    public TextPage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextPage(TextPage textPage)
        : base(textPage) { }
#pragma warning restore CS8618

    public TextPage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextPage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextPageFromRaw.FromRawUnchecked"/>
    public static TextPage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TextPageFromRaw : IFromRawJson<TextPage>
{
    /// <inheritdoc/>
    public TextPage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TextPage.FromRawUnchecked(rawData);
}
