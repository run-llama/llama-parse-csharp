using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;

namespace LlamaIndex.LlamaCloud.Models.JobDataPoints;

/// <summary>
/// Returns paginated job data points for the current project.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class JobDataPointListParams : ParamsBase
{
    /// <summary>
    /// Job type to query.
    /// </summary>
    public required ApiEnum<string, JobType> JobType
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<ApiEnum<string, JobType>>("job_type");
        }
        init { this._rawQueryData.Set("job_type", value); }
    }

    /// <summary>
    /// Include items created at or after this timestamp (inclusive)
    /// </summary>
    public DateTimeOffset? CreatedAtOnOrAfter
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at_on_or_after");
        }
        init { this._rawQueryData.Set("created_at_on_or_after", value); }
    }

    /// <summary>
    /// Include items created at or before this timestamp (inclusive)
    /// </summary>
    public DateTimeOffset? CreatedAtOnOrBefore
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>("created_at_on_or_before");
        }
        init { this._rawQueryData.Set("created_at_on_or_before", value); }
    }

    /// <summary>
    /// Hours of history to include.
    /// </summary>
    public long? Hours
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("hours");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("hours", value);
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
    /// Number of items per page.
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
    /// Cursor token for the next page.
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
    /// Filter by status.
    /// </summary>
    public IReadOnlyList<string>? Status
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>("status");
        }
        init
        {
            this._rawQueryData.Set<ImmutableArray<string>?>(
                "status",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public JobDataPointListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobDataPointListParams(JobDataPointListParams jobDataPointListParams)
        : base(jobDataPointListParams) { }
#pragma warning restore CS8618

    public JobDataPointListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JobDataPointListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static JobDataPointListParams FromRawUnchecked(
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

    public virtual bool Equals(JobDataPointListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/job-data-points")
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
/// Job type to query.
/// </summary>
[JsonConverter(typeof(JobTypeConverter))]
public enum JobType
{
    Classify,
    Extract,
    Parse,
}

sealed class JobTypeConverter : JsonConverter<JobType>
{
    public override JobType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "classify" => JobType.Classify,
            "extract" => JobType.Extract,
            "parse" => JobType.Parse,
            _ => (JobType)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, JobType value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JobType.Classify => "classify",
                JobType.Extract => "extract",
                JobType.Parse => "parse",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
