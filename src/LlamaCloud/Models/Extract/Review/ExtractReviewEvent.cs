using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using System = System;

namespace LlamaCloud.Models.Extract.Review;

/// <summary>
/// One entry in a review's history.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExtractReviewEvent, ExtractReviewEventFromRaw>))]
public sealed record class ExtractReviewEvent : JsonModel
{
    /// <summary>
    /// Unique identifier of the entry.
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
    /// ID of the user who acted.
    /// </summary>
    public required string ActorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("actor_id");
        }
        init { this._rawData.Set("actor_id", value); }
    }

    /// <summary>
    /// When it happened.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// What happened.
    /// </summary>
    public required ApiEnum<string, Kind> Kind
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Kind>>("kind");
        }
        init { this._rawData.Set("kind", value); }
    }

    /// <summary>
    /// The settings for `created`, the reason for `rejected`, and the fields for
    /// `flags_signed_off`; null for the rest.
    /// </summary>
    public Detail? Detail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Detail>("detail");
        }
        init { this._rawData.Set("detail", value); }
    }

    /// <summary>
    /// JSON Pointer of the field it changed.
    /// </summary>
    public string? Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    /// <summary>
    /// The field's value after the change.
    /// </summary>
    public JsonElement? ValueAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("value_after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value_after", value);
        }
    }

    /// <summary>
    /// The field's value before the change.
    /// </summary>
    public JsonElement? ValueBefore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<JsonElement>("value_before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value_before", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ActorID;
        _ = this.CreatedAt;
        this.Kind.Validate();
        this.Detail?.Validate();
        _ = this.Path;
        _ = this.ValueAfter;
        _ = this.ValueBefore;
    }

    public ExtractReviewEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractReviewEvent(ExtractReviewEvent extractReviewEvent)
        : base(extractReviewEvent) { }
#pragma warning restore CS8618

    public ExtractReviewEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractReviewEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractReviewEventFromRaw.FromRawUnchecked"/>
    public static ExtractReviewEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractReviewEventFromRaw : IFromRawJson<ExtractReviewEvent>
{
    /// <inheritdoc/>
    public ExtractReviewEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExtractReviewEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// What happened.
/// </summary>
[JsonConverter(typeof(KindConverter))]
public enum Kind
{
    Approved,
    Created,
    FieldCleared,
    FieldConfirmed,
    FieldCorrected,
    FieldRestored,
    FieldUndone,
    FlagsSignedOff,
    Rejected,
    Reopened,
}

sealed class KindConverter : JsonConverter<Kind>
{
    public override Kind Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approved" => Kind.Approved,
            "created" => Kind.Created,
            "field_cleared" => Kind.FieldCleared,
            "field_confirmed" => Kind.FieldConfirmed,
            "field_corrected" => Kind.FieldCorrected,
            "field_restored" => Kind.FieldRestored,
            "field_undone" => Kind.FieldUndone,
            "flags_signed_off" => Kind.FlagsSignedOff,
            "rejected" => Kind.Rejected,
            "reopened" => Kind.Reopened,
            _ => (Kind)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Kind value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Kind.Approved => "approved",
                Kind.Created => "created",
                Kind.FieldCleared => "field_cleared",
                Kind.FieldConfirmed => "field_confirmed",
                Kind.FieldCorrected => "field_corrected",
                Kind.FieldRestored => "field_restored",
                Kind.FieldUndone => "field_undone",
                Kind.FlagsSignedOff => "flags_signed_off",
                Kind.Rejected => "rejected",
                Kind.Reopened => "reopened",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The settings for `created`, the reason for `rejected`, and the fields for `flags_signed_off`;
/// null for the rest.
/// </summary>
[JsonConverter(typeof(DetailConverter))]
public record class Detail : ModelBase
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

    public Detail(ExtractReviewCreatedDetail value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Detail(ExtractReviewRejectedDetail value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Detail(ExtractReviewSignedOffDetail value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Detail(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExtractReviewCreatedDetail"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExtractReviewCreated(out var value)) {
    ///     // `value` is of type `ExtractReviewCreatedDetail`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExtractReviewCreated(
        [NotNullWhen(true)] out ExtractReviewCreatedDetail? value
    )
    {
        value = this.Value as ExtractReviewCreatedDetail;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExtractReviewRejectedDetail"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExtractReviewRejected(out var value)) {
    ///     // `value` is of type `ExtractReviewRejectedDetail`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExtractReviewRejected(
        [NotNullWhen(true)] out ExtractReviewRejectedDetail? value
    )
    {
        value = this.Value as ExtractReviewRejectedDetail;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ExtractReviewSignedOffDetail"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickExtractReviewSignedOff(out var value)) {
    ///     // `value` is of type `ExtractReviewSignedOffDetail`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickExtractReviewSignedOff(
        [NotNullWhen(true)] out ExtractReviewSignedOffDetail? value
    )
    {
        value = this.Value as ExtractReviewSignedOffDetail;
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
    ///     (ExtractReviewCreatedDetail value) =&gt; {...},
    ///     (ExtractReviewRejectedDetail value) =&gt; {...},
    ///     (ExtractReviewSignedOffDetail value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ExtractReviewCreatedDetail> extractReviewCreated,
        System::Action<ExtractReviewRejectedDetail> extractReviewRejected,
        System::Action<ExtractReviewSignedOffDetail> extractReviewSignedOff
    )
    {
        switch (this.Value)
        {
            case ExtractReviewCreatedDetail value:
                extractReviewCreated(value);
                break;
            case ExtractReviewRejectedDetail value:
                extractReviewRejected(value);
                break;
            case ExtractReviewSignedOffDetail value:
                extractReviewSignedOff(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of Detail"
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
    ///     (ExtractReviewCreatedDetail value) =&gt; {...},
    ///     (ExtractReviewRejectedDetail value) =&gt; {...},
    ///     (ExtractReviewSignedOffDetail value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ExtractReviewCreatedDetail, T> extractReviewCreated,
        System::Func<ExtractReviewRejectedDetail, T> extractReviewRejected,
        System::Func<ExtractReviewSignedOffDetail, T> extractReviewSignedOff
    )
    {
        return this.Value switch
        {
            ExtractReviewCreatedDetail value => extractReviewCreated(value),
            ExtractReviewRejectedDetail value => extractReviewRejected(value),
            ExtractReviewSignedOffDetail value => extractReviewSignedOff(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of Detail"
            ),
        };
    }

    public static implicit operator Detail(ExtractReviewCreatedDetail value) => new(value);

    public static implicit operator Detail(ExtractReviewRejectedDetail value) => new(value);

    public static implicit operator Detail(ExtractReviewSignedOffDetail value) => new(value);

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
            throw new LlamaCloudInvalidDataException("Data did not match any variant of Detail");
        }
        this.Switch(
            (extractReviewCreated) => extractReviewCreated.Validate(),
            (extractReviewRejected) => extractReviewRejected.Validate(),
            (extractReviewSignedOff) => extractReviewSignedOff.Validate()
        );
    }

    public virtual bool Equals(Detail? other) =>
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
            ExtractReviewCreatedDetail _ => 0,
            ExtractReviewRejectedDetail _ => 1,
            ExtractReviewSignedOffDetail _ => 2,
            _ => -1,
        };
    }
}

sealed class DetailConverter : JsonConverter<Detail?>
{
    public override Detail? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ExtractReviewCreatedDetail>(
                element,
                options
            );
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
            var deserialized = JsonSerializer.Deserialize<ExtractReviewRejectedDetail>(
                element,
                options
            );
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
            var deserialized = JsonSerializer.Deserialize<ExtractReviewSignedOffDetail>(
                element,
                options
            );
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

    public override void Write(Utf8JsonWriter writer, Detail? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// What a `created` entry records: where review was turned on, and its settings.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ExtractReviewCreatedDetail, ExtractReviewCreatedDetailFromRaw>)
)]
public sealed record class ExtractReviewCreatedDetail : JsonModel
{
    /// <summary>
    /// Fields read below this confidence are flagged.
    /// </summary>
    public required double ConfidenceThreshold
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("confidence_threshold");
        }
        init { this._rawData.Set("confidence_threshold", value); }
    }

    /// <summary>
    /// JSON Pointers of the fields the threshold applies to; empty means all.
    /// </summary>
    public required IReadOnlyList<string> FieldsInScope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("fields_in_scope");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "fields_in_scope",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Turned on as the job ran, from History, by a first edit, or by the API.
    /// </summary>
    public required ApiEnum<string, Origin> Origin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Origin>>("origin");
        }
        init { this._rawData.Set("origin", value); }
    }

    /// <summary>
    /// JSON Pointers of fields flagged when empty.
    /// </summary>
    public required IReadOnlyList<string> RequiredFields
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("required_fields");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "required_fields",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConfidenceThreshold;
        _ = this.FieldsInScope;
        this.Origin.Validate();
        _ = this.RequiredFields;
    }

    public ExtractReviewCreatedDetail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractReviewCreatedDetail(ExtractReviewCreatedDetail extractReviewCreatedDetail)
        : base(extractReviewCreatedDetail) { }
#pragma warning restore CS8618

    public ExtractReviewCreatedDetail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractReviewCreatedDetail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractReviewCreatedDetailFromRaw.FromRawUnchecked"/>
    public static ExtractReviewCreatedDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractReviewCreatedDetailFromRaw : IFromRawJson<ExtractReviewCreatedDetail>
{
    /// <inheritdoc/>
    public ExtractReviewCreatedDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtractReviewCreatedDetail.FromRawUnchecked(rawData);
}

/// <summary>
/// Turned on as the job ran, from History, by a first edit, or by the API.
/// </summary>
[JsonConverter(typeof(OriginConverter))]
public enum Origin
{
    Api,
    Edit,
    History,
    Run,
}

sealed class OriginConverter : JsonConverter<Origin>
{
    public override Origin Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "api" => Origin.Api,
            "edit" => Origin.Edit,
            "history" => Origin.History,
            "run" => Origin.Run,
            _ => (Origin)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Origin value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Origin.Api => "api",
                Origin.Edit => "edit",
                Origin.History => "history",
                Origin.Run => "run",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// What a `rejected` entry records.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ExtractReviewRejectedDetail, ExtractReviewRejectedDetailFromRaw>)
)]
public sealed record class ExtractReviewRejectedDetail : JsonModel
{
    /// <summary>
    /// Why the result was rejected.
    /// </summary>
    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Reason;
    }

    public ExtractReviewRejectedDetail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractReviewRejectedDetail(ExtractReviewRejectedDetail extractReviewRejectedDetail)
        : base(extractReviewRejectedDetail) { }
#pragma warning restore CS8618

    public ExtractReviewRejectedDetail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractReviewRejectedDetail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractReviewRejectedDetailFromRaw.FromRawUnchecked"/>
    public static ExtractReviewRejectedDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExtractReviewRejectedDetail(string reason)
        : this()
    {
        this.Reason = reason;
    }
}

class ExtractReviewRejectedDetailFromRaw : IFromRawJson<ExtractReviewRejectedDetail>
{
    /// <inheritdoc/>
    public ExtractReviewRejectedDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtractReviewRejectedDetail.FromRawUnchecked(rawData);
}

/// <summary>
/// What a `flags_signed_off` entry records.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ExtractReviewSignedOffDetail, ExtractReviewSignedOffDetailFromRaw>)
)]
public sealed record class ExtractReviewSignedOffDetail : JsonModel
{
    /// <summary>
    /// JSON Pointers of the flagged fields confirmed as part of approving.
    /// </summary>
    public required IReadOnlyList<string> Paths
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("paths");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "paths",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Paths;
    }

    public ExtractReviewSignedOffDetail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractReviewSignedOffDetail(ExtractReviewSignedOffDetail extractReviewSignedOffDetail)
        : base(extractReviewSignedOffDetail) { }
#pragma warning restore CS8618

    public ExtractReviewSignedOffDetail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractReviewSignedOffDetail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractReviewSignedOffDetailFromRaw.FromRawUnchecked"/>
    public static ExtractReviewSignedOffDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExtractReviewSignedOffDetail(IReadOnlyList<string> paths)
        : this()
    {
        this.Paths = paths;
    }
}

class ExtractReviewSignedOffDetailFromRaw : IFromRawJson<ExtractReviewSignedOffDetail>
{
    /// <inheritdoc/>
    public ExtractReviewSignedOffDetail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExtractReviewSignedOffDetail.FromRawUnchecked(rawData);
}
