using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Parsing;

/// <summary>
/// List parse jobs for the current project.
///
/// <para>Filter by `status` or creation date range. Results are paginated — use
/// `page_token` from the response to fetch subsequent pages.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ParsingListParams : ParamsBase
{
    /// <summary>
    /// Include items created at or after this timestamp (inclusive)
    /// </summary>
    public System::DateTimeOffset? CreatedAtOnOrAfter
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "created_at_on_or_after"
            );
        }
        init { this._rawQueryData.Set("created_at_on_or_after", value); }
    }

    /// <summary>
    /// Include items created at or before this timestamp (inclusive)
    /// </summary>
    public System::DateTimeOffset? CreatedAtOnOrBefore
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "created_at_on_or_before"
            );
        }
        init { this._rawQueryData.Set("created_at_on_or_before", value); }
    }

    /// <summary>
    /// Filter by specific job IDs
    /// </summary>
    public IReadOnlyList<string>? JobIds
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("job_ids");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "job_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
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

    /// <summary>
    /// Number of items per page
    /// </summary>
    public long? PageSize
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("page_size");
        }
        init { this._rawQueryData.Set("page_size", value); }
    }

    /// <summary>
    /// Token for pagination
    /// </summary>
    public string? PageToken
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("page_token");
        }
        init { this._rawQueryData.Set("page_token", value); }
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

    /// <summary>
    /// Filter by job status (PENDING, RUNNING, COMPLETED, FAILED, CANCELLED)
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawQueryData.Set("status", value); }
    }

    public ParsingListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParsingListParams(ParsingListParams parsingListParams)
        : base(parsingListParams) { }
#pragma warning restore CS8618

    public ParsingListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ParsingListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ParsingListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
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

    public virtual bool Equals(ParsingListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v2/parse")
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

/// <summary>
/// Filter by job status (PENDING, RUNNING, COMPLETED, FAILED, CANCELLED)
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Cancelled,
    Completed,
    Failed,
    Pending,
    Running,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CANCELLED" => Status.Cancelled,
            "COMPLETED" => Status.Completed,
            "FAILED" => Status.Failed,
            "PENDING" => Status.Pending,
            "RUNNING" => Status.Running,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Cancelled => "CANCELLED",
                Status.Completed => "COMPLETED",
                Status.Failed => "FAILED",
                Status.Pending => "PENDING",
                Status.Running => "RUNNING",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
