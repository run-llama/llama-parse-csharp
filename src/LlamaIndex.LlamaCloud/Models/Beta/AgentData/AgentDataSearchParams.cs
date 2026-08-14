using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;

namespace LlamaIndex.LlamaCloud.Models.Beta.AgentData;

/// <summary>
/// Search agent data with filtering, sorting, and pagination.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AgentDataSearchParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The agent deployment's name to search within
    /// </summary>
    public required string DeploymentName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("deployment_name");
        }
        init { this._rawBodyData.Set("deployment_name", value); }
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

    /// <summary>
    /// The logical agent data collection to search within
    /// </summary>
    public string? Collection
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("collection");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("collection", value);
        }
    }

    /// <summary>
    /// A filter object or expression that filters resources listed in the response.
    /// </summary>
    public IReadOnlyDictionary<string, AgentDataSearchParamsFilterItem>? Filter
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                FrozenDictionary<string, AgentDataSearchParamsFilterItem>
            >("filter");
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, AgentDataSearchParamsFilterItem>?>(
                "filter",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Whether to include the total number of items in the response
    /// </summary>
    public bool? IncludeTotal
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("include_total");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("include_total", value);
        }
    }

    /// <summary>
    /// The offset to start from. If not provided, the first page is returned
    /// </summary>
    public long? Offset
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("offset");
        }
        init { this._rawBodyData.Set("offset", value); }
    }

    /// <summary>
    /// A comma-separated list of fields to order by, sorted in ascending order.
    /// Use 'field_name desc' to specify descending order.
    /// </summary>
    public string? OrderBy
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("order_by");
        }
        init { this._rawBodyData.Set("order_by", value); }
    }

    /// <summary>
    /// The maximum number of items to return. The service may return fewer than this
    /// value. If unspecified, a default page size will be used. The maximum value
    /// is typically 1000; values above this will be coerced to the maximum.
    /// </summary>
    public long? PageSize
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("page_size");
        }
        init { this._rawBodyData.Set("page_size", value); }
    }

    /// <summary>
    /// A page token, received from a previous list call. Provide this to retrieve
    /// the subsequent page.
    /// </summary>
    public string? PageToken
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("page_token");
        }
        init { this._rawBodyData.Set("page_token", value); }
    }

    public AgentDataSearchParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentDataSearchParams(AgentDataSearchParams agentDataSearchParams)
        : base(agentDataSearchParams)
    {
        this._rawBodyData = new(agentDataSearchParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AgentDataSearchParams(
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
    AgentDataSearchParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AgentDataSearchParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
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
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(AgentDataSearchParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/beta/agent-data/:search"
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
/// API request model for a filter comparison operation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        AgentDataSearchParamsFilterItem,
        AgentDataSearchParamsFilterItemFromRaw
    >)
)]
public sealed record class AgentDataSearchParamsFilterItem : JsonModel
{
    public AgentDataSearchParamsFilterItemEq? Eq
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentDataSearchParamsFilterItemEq>("eq");
        }
        init { this._rawData.Set("eq", value); }
    }

    public IReadOnlyList<AgentDataSearchParamsFilterItemExclude?>? Excludes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<AgentDataSearchParamsFilterItemExclude?>
            >("excludes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AgentDataSearchParamsFilterItemExclude?>?>(
                "excludes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public AgentDataSearchParamsFilterItemGt? Gt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentDataSearchParamsFilterItemGt>("gt");
        }
        init { this._rawData.Set("gt", value); }
    }

    public AgentDataSearchParamsFilterItemGte? Gte
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentDataSearchParamsFilterItemGte>("gte");
        }
        init { this._rawData.Set("gte", value); }
    }

    public IReadOnlyList<AgentDataSearchParamsFilterItemInclude?>? Includes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<AgentDataSearchParamsFilterItemInclude?>
            >("includes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AgentDataSearchParamsFilterItemInclude?>?>(
                "includes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public AgentDataSearchParamsFilterItemLt? Lt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentDataSearchParamsFilterItemLt>("lt");
        }
        init { this._rawData.Set("lt", value); }
    }

    public AgentDataSearchParamsFilterItemLte? Lte
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentDataSearchParamsFilterItemLte>("lte");
        }
        init { this._rawData.Set("lte", value); }
    }

    public AgentDataSearchParamsFilterItemNe? Ne
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentDataSearchParamsFilterItemNe>("ne");
        }
        init { this._rawData.Set("ne", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Eq?.Validate();
        foreach (var item in this.Excludes ?? [])
        {
            item?.Validate();
        }
        this.Gt?.Validate();
        this.Gte?.Validate();
        foreach (var item in this.Includes ?? [])
        {
            item?.Validate();
        }
        this.Lt?.Validate();
        this.Lte?.Validate();
        this.Ne?.Validate();
    }

    public AgentDataSearchParamsFilterItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentDataSearchParamsFilterItem(
        AgentDataSearchParamsFilterItem agentDataSearchParamsFilterItem
    )
        : base(agentDataSearchParamsFilterItem) { }
#pragma warning restore CS8618

    public AgentDataSearchParamsFilterItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentDataSearchParamsFilterItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentDataSearchParamsFilterItemFromRaw.FromRawUnchecked"/>
    public static AgentDataSearchParamsFilterItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentDataSearchParamsFilterItemFromRaw : IFromRawJson<AgentDataSearchParamsFilterItem>
{
    /// <inheritdoc/>
    public AgentDataSearchParamsFilterItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentDataSearchParamsFilterItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AgentDataSearchParamsFilterItemEqConverter))]
public record class AgentDataSearchParamsFilterItemEq : ModelBase
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

    public AgentDataSearchParamsFilterItemEq(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemEq(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemEq(DateTimeOffset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemEq(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTimeOffset(out var value)) {
    ///     // `value` is of type `DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTimeOffset([NotNullWhen(true)] out DateTimeOffset? value)
    {
        value = this.Value as DateTimeOffset?;
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (DateTimeOffset value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<double> @double,
        Action<string> @string,
        Action<DateTimeOffset> @dateTimeOffset
    )
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            case DateTimeOffset value:
                @dateTimeOffset(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of AgentDataSearchParamsFilterItemEq"
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (DateTimeOffset value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<double, T> @double,
        Func<string, T> @string,
        Func<DateTimeOffset, T> @dateTimeOffset
    )
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            DateTimeOffset value => @dateTimeOffset(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of AgentDataSearchParamsFilterItemEq"
            ),
        };
    }

    public static implicit operator AgentDataSearchParamsFilterItemEq(double value) => new(value);

    public static implicit operator AgentDataSearchParamsFilterItemEq(string value) => new(value);

    public static implicit operator AgentDataSearchParamsFilterItemEq(DateTimeOffset value) =>
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
                "Data did not match any variant of AgentDataSearchParamsFilterItemEq"
            );
        }
    }

    public virtual bool Equals(AgentDataSearchParamsFilterItemEq? other) =>
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
            double _ => 0,
            string _ => 1,
            DateTimeOffset _ => 2,
            _ => -1,
        };
    }
}

sealed class AgentDataSearchParamsFilterItemEqConverter
    : JsonConverter<AgentDataSearchParamsFilterItemEq?>
{
    public override AgentDataSearchParamsFilterItemEq? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<DateTimeOffset>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentDataSearchParamsFilterItemEq? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(AgentDataSearchParamsFilterItemExcludeConverter))]
public record class AgentDataSearchParamsFilterItemExclude : ModelBase
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

    public AgentDataSearchParamsFilterItemExclude(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemExclude(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemExclude(DateTimeOffset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemExclude(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTimeOffset(out var value)) {
    ///     // `value` is of type `DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTimeOffset([NotNullWhen(true)] out DateTimeOffset? value)
    {
        value = this.Value as DateTimeOffset?;
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (DateTimeOffset value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<double> @double,
        Action<string> @string,
        Action<DateTimeOffset> @dateTimeOffset
    )
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            case DateTimeOffset value:
                @dateTimeOffset(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of AgentDataSearchParamsFilterItemExclude"
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (DateTimeOffset value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<double, T> @double,
        Func<string, T> @string,
        Func<DateTimeOffset, T> @dateTimeOffset
    )
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            DateTimeOffset value => @dateTimeOffset(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of AgentDataSearchParamsFilterItemExclude"
            ),
        };
    }

    public static implicit operator AgentDataSearchParamsFilterItemExclude(double value) =>
        new(value);

    public static implicit operator AgentDataSearchParamsFilterItemExclude(string value) =>
        new(value);

    public static implicit operator AgentDataSearchParamsFilterItemExclude(DateTimeOffset value) =>
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
                "Data did not match any variant of AgentDataSearchParamsFilterItemExclude"
            );
        }
    }

    public virtual bool Equals(AgentDataSearchParamsFilterItemExclude? other) =>
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
            double _ => 0,
            string _ => 1,
            DateTimeOffset _ => 2,
            _ => -1,
        };
    }
}

sealed class AgentDataSearchParamsFilterItemExcludeConverter
    : JsonConverter<AgentDataSearchParamsFilterItemExclude?>
{
    public override AgentDataSearchParamsFilterItemExclude? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<DateTimeOffset>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentDataSearchParamsFilterItemExclude? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(AgentDataSearchParamsFilterItemGtConverter))]
public record class AgentDataSearchParamsFilterItemGt : ModelBase
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

    public AgentDataSearchParamsFilterItemGt(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemGt(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemGt(DateTimeOffset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemGt(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTimeOffset(out var value)) {
    ///     // `value` is of type `DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTimeOffset([NotNullWhen(true)] out DateTimeOffset? value)
    {
        value = this.Value as DateTimeOffset?;
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (DateTimeOffset value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<double> @double,
        Action<string> @string,
        Action<DateTimeOffset> @dateTimeOffset
    )
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            case DateTimeOffset value:
                @dateTimeOffset(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of AgentDataSearchParamsFilterItemGt"
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (DateTimeOffset value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<double, T> @double,
        Func<string, T> @string,
        Func<DateTimeOffset, T> @dateTimeOffset
    )
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            DateTimeOffset value => @dateTimeOffset(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of AgentDataSearchParamsFilterItemGt"
            ),
        };
    }

    public static implicit operator AgentDataSearchParamsFilterItemGt(double value) => new(value);

    public static implicit operator AgentDataSearchParamsFilterItemGt(string value) => new(value);

    public static implicit operator AgentDataSearchParamsFilterItemGt(DateTimeOffset value) =>
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
                "Data did not match any variant of AgentDataSearchParamsFilterItemGt"
            );
        }
    }

    public virtual bool Equals(AgentDataSearchParamsFilterItemGt? other) =>
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
            double _ => 0,
            string _ => 1,
            DateTimeOffset _ => 2,
            _ => -1,
        };
    }
}

sealed class AgentDataSearchParamsFilterItemGtConverter
    : JsonConverter<AgentDataSearchParamsFilterItemGt?>
{
    public override AgentDataSearchParamsFilterItemGt? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<DateTimeOffset>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentDataSearchParamsFilterItemGt? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(AgentDataSearchParamsFilterItemGteConverter))]
public record class AgentDataSearchParamsFilterItemGte : ModelBase
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

    public AgentDataSearchParamsFilterItemGte(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemGte(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemGte(DateTimeOffset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemGte(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTimeOffset(out var value)) {
    ///     // `value` is of type `DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTimeOffset([NotNullWhen(true)] out DateTimeOffset? value)
    {
        value = this.Value as DateTimeOffset?;
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (DateTimeOffset value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<double> @double,
        Action<string> @string,
        Action<DateTimeOffset> @dateTimeOffset
    )
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            case DateTimeOffset value:
                @dateTimeOffset(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of AgentDataSearchParamsFilterItemGte"
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (DateTimeOffset value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<double, T> @double,
        Func<string, T> @string,
        Func<DateTimeOffset, T> @dateTimeOffset
    )
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            DateTimeOffset value => @dateTimeOffset(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of AgentDataSearchParamsFilterItemGte"
            ),
        };
    }

    public static implicit operator AgentDataSearchParamsFilterItemGte(double value) => new(value);

    public static implicit operator AgentDataSearchParamsFilterItemGte(string value) => new(value);

    public static implicit operator AgentDataSearchParamsFilterItemGte(DateTimeOffset value) =>
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
                "Data did not match any variant of AgentDataSearchParamsFilterItemGte"
            );
        }
    }

    public virtual bool Equals(AgentDataSearchParamsFilterItemGte? other) =>
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
            double _ => 0,
            string _ => 1,
            DateTimeOffset _ => 2,
            _ => -1,
        };
    }
}

sealed class AgentDataSearchParamsFilterItemGteConverter
    : JsonConverter<AgentDataSearchParamsFilterItemGte?>
{
    public override AgentDataSearchParamsFilterItemGte? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<DateTimeOffset>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentDataSearchParamsFilterItemGte? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(AgentDataSearchParamsFilterItemIncludeConverter))]
public record class AgentDataSearchParamsFilterItemInclude : ModelBase
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

    public AgentDataSearchParamsFilterItemInclude(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemInclude(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemInclude(DateTimeOffset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemInclude(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTimeOffset(out var value)) {
    ///     // `value` is of type `DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTimeOffset([NotNullWhen(true)] out DateTimeOffset? value)
    {
        value = this.Value as DateTimeOffset?;
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (DateTimeOffset value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<double> @double,
        Action<string> @string,
        Action<DateTimeOffset> @dateTimeOffset
    )
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            case DateTimeOffset value:
                @dateTimeOffset(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of AgentDataSearchParamsFilterItemInclude"
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (DateTimeOffset value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<double, T> @double,
        Func<string, T> @string,
        Func<DateTimeOffset, T> @dateTimeOffset
    )
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            DateTimeOffset value => @dateTimeOffset(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of AgentDataSearchParamsFilterItemInclude"
            ),
        };
    }

    public static implicit operator AgentDataSearchParamsFilterItemInclude(double value) =>
        new(value);

    public static implicit operator AgentDataSearchParamsFilterItemInclude(string value) =>
        new(value);

    public static implicit operator AgentDataSearchParamsFilterItemInclude(DateTimeOffset value) =>
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
                "Data did not match any variant of AgentDataSearchParamsFilterItemInclude"
            );
        }
    }

    public virtual bool Equals(AgentDataSearchParamsFilterItemInclude? other) =>
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
            double _ => 0,
            string _ => 1,
            DateTimeOffset _ => 2,
            _ => -1,
        };
    }
}

sealed class AgentDataSearchParamsFilterItemIncludeConverter
    : JsonConverter<AgentDataSearchParamsFilterItemInclude?>
{
    public override AgentDataSearchParamsFilterItemInclude? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<DateTimeOffset>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentDataSearchParamsFilterItemInclude? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(AgentDataSearchParamsFilterItemLtConverter))]
public record class AgentDataSearchParamsFilterItemLt : ModelBase
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

    public AgentDataSearchParamsFilterItemLt(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemLt(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemLt(DateTimeOffset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemLt(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTimeOffset(out var value)) {
    ///     // `value` is of type `DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTimeOffset([NotNullWhen(true)] out DateTimeOffset? value)
    {
        value = this.Value as DateTimeOffset?;
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (DateTimeOffset value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<double> @double,
        Action<string> @string,
        Action<DateTimeOffset> @dateTimeOffset
    )
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            case DateTimeOffset value:
                @dateTimeOffset(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of AgentDataSearchParamsFilterItemLt"
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (DateTimeOffset value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<double, T> @double,
        Func<string, T> @string,
        Func<DateTimeOffset, T> @dateTimeOffset
    )
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            DateTimeOffset value => @dateTimeOffset(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of AgentDataSearchParamsFilterItemLt"
            ),
        };
    }

    public static implicit operator AgentDataSearchParamsFilterItemLt(double value) => new(value);

    public static implicit operator AgentDataSearchParamsFilterItemLt(string value) => new(value);

    public static implicit operator AgentDataSearchParamsFilterItemLt(DateTimeOffset value) =>
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
                "Data did not match any variant of AgentDataSearchParamsFilterItemLt"
            );
        }
    }

    public virtual bool Equals(AgentDataSearchParamsFilterItemLt? other) =>
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
            double _ => 0,
            string _ => 1,
            DateTimeOffset _ => 2,
            _ => -1,
        };
    }
}

sealed class AgentDataSearchParamsFilterItemLtConverter
    : JsonConverter<AgentDataSearchParamsFilterItemLt?>
{
    public override AgentDataSearchParamsFilterItemLt? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<DateTimeOffset>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentDataSearchParamsFilterItemLt? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(AgentDataSearchParamsFilterItemLteConverter))]
public record class AgentDataSearchParamsFilterItemLte : ModelBase
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

    public AgentDataSearchParamsFilterItemLte(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemLte(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemLte(DateTimeOffset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemLte(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTimeOffset(out var value)) {
    ///     // `value` is of type `DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTimeOffset([NotNullWhen(true)] out DateTimeOffset? value)
    {
        value = this.Value as DateTimeOffset?;
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (DateTimeOffset value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<double> @double,
        Action<string> @string,
        Action<DateTimeOffset> @dateTimeOffset
    )
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            case DateTimeOffset value:
                @dateTimeOffset(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of AgentDataSearchParamsFilterItemLte"
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (DateTimeOffset value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<double, T> @double,
        Func<string, T> @string,
        Func<DateTimeOffset, T> @dateTimeOffset
    )
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            DateTimeOffset value => @dateTimeOffset(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of AgentDataSearchParamsFilterItemLte"
            ),
        };
    }

    public static implicit operator AgentDataSearchParamsFilterItemLte(double value) => new(value);

    public static implicit operator AgentDataSearchParamsFilterItemLte(string value) => new(value);

    public static implicit operator AgentDataSearchParamsFilterItemLte(DateTimeOffset value) =>
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
                "Data did not match any variant of AgentDataSearchParamsFilterItemLte"
            );
        }
    }

    public virtual bool Equals(AgentDataSearchParamsFilterItemLte? other) =>
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
            double _ => 0,
            string _ => 1,
            DateTimeOffset _ => 2,
            _ => -1,
        };
    }
}

sealed class AgentDataSearchParamsFilterItemLteConverter
    : JsonConverter<AgentDataSearchParamsFilterItemLte?>
{
    public override AgentDataSearchParamsFilterItemLte? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<DateTimeOffset>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentDataSearchParamsFilterItemLte? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(AgentDataSearchParamsFilterItemNeConverter))]
public record class AgentDataSearchParamsFilterItemNe : ModelBase
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

    public AgentDataSearchParamsFilterItemNe(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemNe(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemNe(DateTimeOffset value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataSearchParamsFilterItemNe(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DateTimeOffset"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDateTimeOffset(out var value)) {
    ///     // `value` is of type `DateTimeOffset`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDateTimeOffset([NotNullWhen(true)] out DateTimeOffset? value)
    {
        value = this.Value as DateTimeOffset?;
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (DateTimeOffset value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<double> @double,
        Action<string> @string,
        Action<DateTimeOffset> @dateTimeOffset
    )
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            case DateTimeOffset value:
                @dateTimeOffset(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of AgentDataSearchParamsFilterItemNe"
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
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (DateTimeOffset value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<double, T> @double,
        Func<string, T> @string,
        Func<DateTimeOffset, T> @dateTimeOffset
    )
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            DateTimeOffset value => @dateTimeOffset(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of AgentDataSearchParamsFilterItemNe"
            ),
        };
    }

    public static implicit operator AgentDataSearchParamsFilterItemNe(double value) => new(value);

    public static implicit operator AgentDataSearchParamsFilterItemNe(string value) => new(value);

    public static implicit operator AgentDataSearchParamsFilterItemNe(DateTimeOffset value) =>
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
                "Data did not match any variant of AgentDataSearchParamsFilterItemNe"
            );
        }
    }

    public virtual bool Equals(AgentDataSearchParamsFilterItemNe? other) =>
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
            double _ => 0,
            string _ => 1,
            DateTimeOffset _ => 2,
            _ => -1,
        };
    }
}

sealed class AgentDataSearchParamsFilterItemNeConverter
    : JsonConverter<AgentDataSearchParamsFilterItemNe?>
{
    public override AgentDataSearchParamsFilterItemNe? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<DateTimeOffset>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        AgentDataSearchParamsFilterItemNe? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
