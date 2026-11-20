using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models.Extract.Review;

/// <summary>
/// Beta: answers 403 until extract review is enabled for the caller and their organization.
///
/// <para>Confirm, correct, clear, restore or undo fields of a completed job.</para>
///
/// <para>The changes apply in order, in one write. A job without a review gets one
/// with the default settings, at revision 0. A path that is not a field of the job,
/// or a value the field's schema refuses, answers 400 and changes nothing. A job
/// that has not completed answers 409 with `code: job_not_reviewable`. A `revision`
/// other than the review's latest answers 409 with `code: stale_revision` and the
/// latest `revision`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ReviewChangeFieldsParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? JobID { get; init; }

    /// <summary>
    /// Changes to apply, in order.
    /// </summary>
    public required IReadOnlyList<Change> Changes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Change>>("changes");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Change>>(
                "changes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The review's revision as the caller last read it.
    /// </summary>
    public required long Revision
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<long>("revision");
        }
        init { this._rawBodyData.Set("revision", value); }
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

    public ReviewChangeFieldsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReviewChangeFieldsParams(ReviewChangeFieldsParams reviewChangeFieldsParams)
        : base(reviewChangeFieldsParams)
    {
        this.JobID = reviewChangeFieldsParams.JobID;

        this._rawBodyData = new(reviewChangeFieldsParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ReviewChangeFieldsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReviewChangeFieldsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string jobID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.JobID = jobID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ReviewChangeFieldsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string jobID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ReviewChangeFieldsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.JobID?.Equals(other.JobID) ?? other.JobID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/api/v2/extract/{0}/review/fields", this.JobID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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

/// <summary>
/// One change to one field.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Change, ChangeFromRaw>))]
public sealed record class Change : JsonModel
{
    /// <summary>
    /// confirm, correct to `value`, clear, restore the model's value, or undo.
    /// </summary>
    public required ApiEnum<string, ChangeChange> ChangeValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ChangeChange>>("change");
        }
        init { this._rawData.Set("change", value); }
    }

    /// <summary>
    /// JSON Pointer of the field.
    /// </summary>
    public required string Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    /// <summary>
    /// The corrected value, for `correct`.
    /// </summary>
    public JsonElement? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ChangeValue.Validate();
        _ = this.Path;
        _ = this.Value;
    }

    public Change() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Change(Change change)
        : base(change) { }
#pragma warning restore CS8618

    public Change(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Change(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChangeFromRaw.FromRawUnchecked"/>
    public static Change FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChangeFromRaw : IFromRawJson<Change>
{
    /// <inheritdoc/>
    public Change FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Change.FromRawUnchecked(rawData);
}

/// <summary>
/// confirm, correct to `value`, clear, restore the model's value, or undo.
/// </summary>
[JsonConverter(typeof(ChangeChangeConverter))]
public enum ChangeChange
{
    Clear,
    Confirm,
    Correct,
    Restore,
    Undo,
}

sealed class ChangeChangeConverter : JsonConverter<ChangeChange>
{
    public override ChangeChange Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "clear" => ChangeChange.Clear,
            "confirm" => ChangeChange.Confirm,
            "correct" => ChangeChange.Correct,
            "restore" => ChangeChange.Restore,
            "undo" => ChangeChange.Undo,
            _ => (ChangeChange)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChangeChange value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChangeChange.Clear => "clear",
                ChangeChange.Confirm => "confirm",
                ChangeChange.Correct => "correct",
                ChangeChange.Restore => "restore",
                ChangeChange.Undo => "undo",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
