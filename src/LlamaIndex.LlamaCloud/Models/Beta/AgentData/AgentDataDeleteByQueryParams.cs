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
/// Bulk delete agent data by query (deployment_name, collection, optional filters).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AgentDataDeleteByQueryParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The agent deployment's name to delete data for
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
    /// The logical agent data collection to delete from
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
    /// Optional filters to select which items to delete
    /// </summary>
    public IReadOnlyDictionary<string, AgentDataDeleteByQueryParamsFilterItem>? Filter
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                FrozenDictionary<string, AgentDataDeleteByQueryParamsFilterItem>
            >("filter");
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<
                string,
                AgentDataDeleteByQueryParamsFilterItem
            >?>("filter", value == null ? null : FrozenDictionary.ToFrozenDictionary(value));
        }
    }

    public AgentDataDeleteByQueryParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentDataDeleteByQueryParams(AgentDataDeleteByQueryParams agentDataDeleteByQueryParams)
        : base(agentDataDeleteByQueryParams)
    {
        this._rawBodyData = new(agentDataDeleteByQueryParams._rawBodyData);
    }
#pragma warning restore CS8618

    public AgentDataDeleteByQueryParams(
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
    AgentDataDeleteByQueryParams(
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
    public static AgentDataDeleteByQueryParams FromRawUnchecked(
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

    public virtual bool Equals(AgentDataDeleteByQueryParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/beta/agent-data/:delete"
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
        AgentDataDeleteByQueryParamsFilterItem,
        AgentDataDeleteByQueryParamsFilterItemFromRaw
    >)
)]
public sealed record class AgentDataDeleteByQueryParamsFilterItem : JsonModel
{
    public AgentDataDeleteByQueryParamsFilterItemEq? Eq
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentDataDeleteByQueryParamsFilterItemEq>("eq");
        }
        init { this._rawData.Set("eq", value); }
    }

    public IReadOnlyList<AgentDataDeleteByQueryParamsFilterItemExclude?>? Excludes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<AgentDataDeleteByQueryParamsFilterItemExclude?>
            >("excludes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AgentDataDeleteByQueryParamsFilterItemExclude?>?>(
                "excludes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public AgentDataDeleteByQueryParamsFilterItemGt? Gt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentDataDeleteByQueryParamsFilterItemGt>("gt");
        }
        init { this._rawData.Set("gt", value); }
    }

    public AgentDataDeleteByQueryParamsFilterItemGte? Gte
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentDataDeleteByQueryParamsFilterItemGte>("gte");
        }
        init { this._rawData.Set("gte", value); }
    }

    public IReadOnlyList<AgentDataDeleteByQueryParamsFilterItemInclude?>? Includes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<AgentDataDeleteByQueryParamsFilterItemInclude?>
            >("includes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AgentDataDeleteByQueryParamsFilterItemInclude?>?>(
                "includes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public AgentDataDeleteByQueryParamsFilterItemLt? Lt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentDataDeleteByQueryParamsFilterItemLt>("lt");
        }
        init { this._rawData.Set("lt", value); }
    }

    public AgentDataDeleteByQueryParamsFilterItemLte? Lte
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentDataDeleteByQueryParamsFilterItemLte>("lte");
        }
        init { this._rawData.Set("lte", value); }
    }

    public AgentDataDeleteByQueryParamsFilterItemNe? Ne
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AgentDataDeleteByQueryParamsFilterItemNe>("ne");
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

    public AgentDataDeleteByQueryParamsFilterItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentDataDeleteByQueryParamsFilterItem(
        AgentDataDeleteByQueryParamsFilterItem agentDataDeleteByQueryParamsFilterItem
    )
        : base(agentDataDeleteByQueryParamsFilterItem) { }
#pragma warning restore CS8618

    public AgentDataDeleteByQueryParamsFilterItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentDataDeleteByQueryParamsFilterItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentDataDeleteByQueryParamsFilterItemFromRaw.FromRawUnchecked"/>
    public static AgentDataDeleteByQueryParamsFilterItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentDataDeleteByQueryParamsFilterItemFromRaw
    : IFromRawJson<AgentDataDeleteByQueryParamsFilterItem>
{
    /// <inheritdoc/>
    public AgentDataDeleteByQueryParamsFilterItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentDataDeleteByQueryParamsFilterItem.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AgentDataDeleteByQueryParamsFilterItemEqConverter))]
public record class AgentDataDeleteByQueryParamsFilterItemEq : ModelBase
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

    public AgentDataDeleteByQueryParamsFilterItemEq(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemEq(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemEq(
        DateTimeOffset value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemEq(JsonElement element)
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
                    "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemEq"
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
                "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemEq"
            ),
        };
    }

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemEq(double value) =>
        new(value);

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemEq(string value) =>
        new(value);

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemEq(
        DateTimeOffset value
    ) => new(value);

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
                "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemEq"
            );
        }
    }

    public virtual bool Equals(AgentDataDeleteByQueryParamsFilterItemEq? other) =>
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

sealed class AgentDataDeleteByQueryParamsFilterItemEqConverter
    : JsonConverter<AgentDataDeleteByQueryParamsFilterItemEq?>
{
    public override AgentDataDeleteByQueryParamsFilterItemEq? Read(
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
        AgentDataDeleteByQueryParamsFilterItemEq? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(AgentDataDeleteByQueryParamsFilterItemExcludeConverter))]
public record class AgentDataDeleteByQueryParamsFilterItemExclude : ModelBase
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

    public AgentDataDeleteByQueryParamsFilterItemExclude(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemExclude(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemExclude(
        DateTimeOffset value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemExclude(JsonElement element)
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
                    "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemExclude"
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
                "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemExclude"
            ),
        };
    }

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemExclude(double value) =>
        new(value);

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemExclude(string value) =>
        new(value);

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemExclude(
        DateTimeOffset value
    ) => new(value);

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
                "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemExclude"
            );
        }
    }

    public virtual bool Equals(AgentDataDeleteByQueryParamsFilterItemExclude? other) =>
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

sealed class AgentDataDeleteByQueryParamsFilterItemExcludeConverter
    : JsonConverter<AgentDataDeleteByQueryParamsFilterItemExclude?>
{
    public override AgentDataDeleteByQueryParamsFilterItemExclude? Read(
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
        AgentDataDeleteByQueryParamsFilterItemExclude? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(AgentDataDeleteByQueryParamsFilterItemGtConverter))]
public record class AgentDataDeleteByQueryParamsFilterItemGt : ModelBase
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

    public AgentDataDeleteByQueryParamsFilterItemGt(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemGt(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemGt(
        DateTimeOffset value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemGt(JsonElement element)
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
                    "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemGt"
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
                "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemGt"
            ),
        };
    }

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemGt(double value) =>
        new(value);

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemGt(string value) =>
        new(value);

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemGt(
        DateTimeOffset value
    ) => new(value);

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
                "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemGt"
            );
        }
    }

    public virtual bool Equals(AgentDataDeleteByQueryParamsFilterItemGt? other) =>
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

sealed class AgentDataDeleteByQueryParamsFilterItemGtConverter
    : JsonConverter<AgentDataDeleteByQueryParamsFilterItemGt?>
{
    public override AgentDataDeleteByQueryParamsFilterItemGt? Read(
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
        AgentDataDeleteByQueryParamsFilterItemGt? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(AgentDataDeleteByQueryParamsFilterItemGteConverter))]
public record class AgentDataDeleteByQueryParamsFilterItemGte : ModelBase
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

    public AgentDataDeleteByQueryParamsFilterItemGte(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemGte(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemGte(
        DateTimeOffset value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemGte(JsonElement element)
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
                    "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemGte"
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
                "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemGte"
            ),
        };
    }

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemGte(double value) =>
        new(value);

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemGte(string value) =>
        new(value);

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemGte(
        DateTimeOffset value
    ) => new(value);

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
                "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemGte"
            );
        }
    }

    public virtual bool Equals(AgentDataDeleteByQueryParamsFilterItemGte? other) =>
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

sealed class AgentDataDeleteByQueryParamsFilterItemGteConverter
    : JsonConverter<AgentDataDeleteByQueryParamsFilterItemGte?>
{
    public override AgentDataDeleteByQueryParamsFilterItemGte? Read(
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
        AgentDataDeleteByQueryParamsFilterItemGte? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(AgentDataDeleteByQueryParamsFilterItemIncludeConverter))]
public record class AgentDataDeleteByQueryParamsFilterItemInclude : ModelBase
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

    public AgentDataDeleteByQueryParamsFilterItemInclude(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemInclude(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemInclude(
        DateTimeOffset value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemInclude(JsonElement element)
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
                    "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemInclude"
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
                "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemInclude"
            ),
        };
    }

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemInclude(double value) =>
        new(value);

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemInclude(string value) =>
        new(value);

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemInclude(
        DateTimeOffset value
    ) => new(value);

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
                "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemInclude"
            );
        }
    }

    public virtual bool Equals(AgentDataDeleteByQueryParamsFilterItemInclude? other) =>
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

sealed class AgentDataDeleteByQueryParamsFilterItemIncludeConverter
    : JsonConverter<AgentDataDeleteByQueryParamsFilterItemInclude?>
{
    public override AgentDataDeleteByQueryParamsFilterItemInclude? Read(
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
        AgentDataDeleteByQueryParamsFilterItemInclude? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(AgentDataDeleteByQueryParamsFilterItemLtConverter))]
public record class AgentDataDeleteByQueryParamsFilterItemLt : ModelBase
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

    public AgentDataDeleteByQueryParamsFilterItemLt(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemLt(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemLt(
        DateTimeOffset value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemLt(JsonElement element)
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
                    "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemLt"
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
                "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemLt"
            ),
        };
    }

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemLt(double value) =>
        new(value);

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemLt(string value) =>
        new(value);

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemLt(
        DateTimeOffset value
    ) => new(value);

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
                "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemLt"
            );
        }
    }

    public virtual bool Equals(AgentDataDeleteByQueryParamsFilterItemLt? other) =>
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

sealed class AgentDataDeleteByQueryParamsFilterItemLtConverter
    : JsonConverter<AgentDataDeleteByQueryParamsFilterItemLt?>
{
    public override AgentDataDeleteByQueryParamsFilterItemLt? Read(
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
        AgentDataDeleteByQueryParamsFilterItemLt? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(AgentDataDeleteByQueryParamsFilterItemLteConverter))]
public record class AgentDataDeleteByQueryParamsFilterItemLte : ModelBase
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

    public AgentDataDeleteByQueryParamsFilterItemLte(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemLte(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemLte(
        DateTimeOffset value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemLte(JsonElement element)
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
                    "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemLte"
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
                "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemLte"
            ),
        };
    }

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemLte(double value) =>
        new(value);

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemLte(string value) =>
        new(value);

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemLte(
        DateTimeOffset value
    ) => new(value);

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
                "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemLte"
            );
        }
    }

    public virtual bool Equals(AgentDataDeleteByQueryParamsFilterItemLte? other) =>
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

sealed class AgentDataDeleteByQueryParamsFilterItemLteConverter
    : JsonConverter<AgentDataDeleteByQueryParamsFilterItemLte?>
{
    public override AgentDataDeleteByQueryParamsFilterItemLte? Read(
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
        AgentDataDeleteByQueryParamsFilterItemLte? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

[JsonConverter(typeof(AgentDataDeleteByQueryParamsFilterItemNeConverter))]
public record class AgentDataDeleteByQueryParamsFilterItemNe : ModelBase
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

    public AgentDataDeleteByQueryParamsFilterItemNe(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemNe(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemNe(
        DateTimeOffset value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AgentDataDeleteByQueryParamsFilterItemNe(JsonElement element)
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
                    "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemNe"
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
                "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemNe"
            ),
        };
    }

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemNe(double value) =>
        new(value);

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemNe(string value) =>
        new(value);

    public static implicit operator AgentDataDeleteByQueryParamsFilterItemNe(
        DateTimeOffset value
    ) => new(value);

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
                "Data did not match any variant of AgentDataDeleteByQueryParamsFilterItemNe"
            );
        }
    }

    public virtual bool Equals(AgentDataDeleteByQueryParamsFilterItemNe? other) =>
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

sealed class AgentDataDeleteByQueryParamsFilterItemNeConverter
    : JsonConverter<AgentDataDeleteByQueryParamsFilterItemNe?>
{
    public override AgentDataDeleteByQueryParamsFilterItemNe? Read(
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
        AgentDataDeleteByQueryParamsFilterItemNe? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}
