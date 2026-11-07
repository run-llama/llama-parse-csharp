using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;

namespace LlamaCloud.Models.Extract.Review;

/// <summary>
/// An extract job's review: its settings, flags, field actions and decision, with
/// the result as read and as reviewed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExtractReview, ExtractReviewFromRaw>))]
public sealed record class ExtractReview : JsonModel
{
    /// <summary>
    /// Unique identifier of the review.
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
    /// When review was turned on.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// When it was approved or rejected.
    /// </summary>
    public required DateTimeOffset? DecidedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("decided_at");
        }
        init { this._rawData.Set("decided_at", value); }
    }

    /// <summary>
    /// ID of the user who approved or rejected it.
    /// </summary>
    public required string? DecidedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("decided_by");
        }
        init { this._rawData.Set("decided_by", value); }
    }

    /// <summary>
    /// Why it was rejected.
    /// </summary>
    public required string? DecidedReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("decided_reason");
        }
        init { this._rawData.Set("decided_reason", value); }
    }

    /// <summary>
    /// The latest action per field, keyed by JSON Pointer.
    /// </summary>
    public required IReadOnlyDictionary<string, FieldActionsItem> FieldActions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, FieldActionsItem>>(
                "field_actions"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, FieldActionsItem>>(
                "field_actions",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
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
    /// Fields the review asks a person to check.
    /// </summary>
    public required IReadOnlyList<Flag> Flags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Flag>>("flags");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Flag>>(
                "flags",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The extract job reviewed.
    /// </summary>
    public required string JobID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("job_id");
        }
        init { this._rawData.Set("job_id", value); }
    }

    /// <summary>
    /// JSON Pointers of flagged fields nobody checked.
    /// </summary>
    public required IReadOnlyList<string> OpenFlags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("open_flags");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "open_flags",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The result as the model read it.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement>? OriginalResult
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "original_result"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "original_result",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
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

    /// <summary>
    /// When the job and its document may be deleted.
    /// </summary>
    public required DateTimeOffset RetainUntil
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("retain_until");
        }
        init { this._rawData.Set("retain_until", value); }
    }

    /// <summary>
    /// The result with the field actions.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> ReviewedResult
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "reviewed_result"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "reviewed_result",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Bumped by every change; actions name the one they saw.
    /// </summary>
    public required long Revision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("revision");
        }
        init { this._rawData.Set("revision", value); }
    }

    /// <summary>
    /// The file the job read, or the file behind the parse job it read; null for
    /// a URL.
    /// </summary>
    public required string? SourceFileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source_file_id");
        }
        init { this._rawData.Set("source_file_id", value); }
    }

    /// <summary>
    /// pending until approved or rejected.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// When the review last changed.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ConfidenceThreshold;
        _ = this.CreatedAt;
        _ = this.DecidedAt;
        _ = this.DecidedBy;
        _ = this.DecidedReason;
        foreach (var item in this.FieldActions.Values)
        {
            item.Validate();
        }
        _ = this.FieldsInScope;
        foreach (var item in this.Flags)
        {
            item.Validate();
        }
        _ = this.JobID;
        _ = this.OpenFlags;
        _ = this.OriginalResult;
        _ = this.RequiredFields;
        _ = this.RetainUntil;
        _ = this.ReviewedResult;
        _ = this.Revision;
        _ = this.SourceFileID;
        this.Status.Validate();
        _ = this.UpdatedAt;
    }

    public ExtractReview() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtractReview(ExtractReview extractReview)
        : base(extractReview) { }
#pragma warning restore CS8618

    public ExtractReview(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtractReview(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtractReviewFromRaw.FromRawUnchecked"/>
    public static ExtractReview FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtractReviewFromRaw : IFromRawJson<ExtractReview>
{
    /// <inheritdoc/>
    public ExtractReview FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExtractReview.FromRawUnchecked(rawData);
}

/// <summary>
/// The latest thing a person did to one field.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FieldActionsItem, FieldActionsItemFromRaw>))]
public sealed record class FieldActionsItem : JsonModel
{
    /// <summary>
    /// confirm, correct or clear.
    /// </summary>
    public required ApiEnum<string, global::LlamaCloud.Models.Extract.Review.Action> Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::LlamaCloud.Models.Extract.Review.Action>
            >("action");
        }
        init { this._rawData.Set("action", value); }
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
    /// When they acted.
    /// </summary>
    public required DateTimeOffset At
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("at");
        }
        init { this._rawData.Set("at", value); }
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
        this.Action.Validate();
        _ = this.ActorID;
        _ = this.At;
        _ = this.Value;
    }

    public FieldActionsItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FieldActionsItem(FieldActionsItem fieldActionsItem)
        : base(fieldActionsItem) { }
#pragma warning restore CS8618

    public FieldActionsItem(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FieldActionsItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FieldActionsItemFromRaw.FromRawUnchecked"/>
    public static FieldActionsItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FieldActionsItemFromRaw : IFromRawJson<FieldActionsItem>
{
    /// <inheritdoc/>
    public FieldActionsItem FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FieldActionsItem.FromRawUnchecked(rawData);
}

/// <summary>
/// confirm, correct or clear.
/// </summary>
[JsonConverter(typeof(ActionConverter))]
public enum Action
{
    Clear,
    Confirm,
    Correct,
}

sealed class ActionConverter : JsonConverter<global::LlamaCloud.Models.Extract.Review.Action>
{
    public override global::LlamaCloud.Models.Extract.Review.Action Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "clear" => global::LlamaCloud.Models.Extract.Review.Action.Clear,
            "confirm" => global::LlamaCloud.Models.Extract.Review.Action.Confirm,
            "correct" => global::LlamaCloud.Models.Extract.Review.Action.Correct,
            _ => (global::LlamaCloud.Models.Extract.Review.Action)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::LlamaCloud.Models.Extract.Review.Action value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::LlamaCloud.Models.Extract.Review.Action.Clear => "clear",
                global::LlamaCloud.Models.Extract.Review.Action.Confirm => "confirm",
                global::LlamaCloud.Models.Extract.Review.Action.Correct => "correct",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// A field the review asks a person to check.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Flag, FlagFromRaw>))]
public sealed record class Flag : JsonModel
{
    /// <summary>
    /// Whether someone confirmed, corrected or cleared it.
    /// </summary>
    public required bool Handled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("handled");
        }
        init { this._rawData.Set("handled", value); }
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
    /// below_threshold, or required_empty for a required field left empty.
    /// </summary>
    public required ApiEnum<string, Reason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Reason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Where in a list the least confident value is.
    /// </summary>
    public Cell? Cell
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Cell>("cell");
        }
        init { this._rawData.Set("cell", value); }
    }

    /// <summary>
    /// The field's confidence; for a list, its least confident value.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Handled;
        _ = this.Path;
        this.Reason.Validate();
        this.Cell?.Validate();
        _ = this.Confidence;
    }

    public Flag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Flag(Flag flag)
        : base(flag) { }
#pragma warning restore CS8618

    public Flag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Flag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FlagFromRaw.FromRawUnchecked"/>
    public static Flag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FlagFromRaw : IFromRawJson<Flag>
{
    /// <inheritdoc/>
    public Flag FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Flag.FromRawUnchecked(rawData);
}

/// <summary>
/// below_threshold, or required_empty for a required field left empty.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    BelowThreshold,
    RequiredEmpty,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "below_threshold" => Reason.BelowThreshold,
            "required_empty" => Reason.RequiredEmpty,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.BelowThreshold => "below_threshold",
                Reason.RequiredEmpty => "required_empty",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Where in a list the least confident value is.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Cell, CellFromRaw>))]
public sealed record class Cell : JsonModel
{
    /// <summary>
    /// Index of the row, from 0.
    /// </summary>
    public required long Row
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("row");
        }
        init { this._rawData.Set("row", value); }
    }

    /// <summary>
    /// Property of the row, when rows are objects.
    /// </summary>
    public string? Column
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("column");
        }
        init { this._rawData.Set("column", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Row;
        _ = this.Column;
    }

    public Cell() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cell(Cell cell)
        : base(cell) { }
#pragma warning restore CS8618

    public Cell(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Cell(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CellFromRaw.FromRawUnchecked"/>
    public static Cell FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Cell(long row)
        : this()
    {
        this.Row = row;
    }
}

class CellFromRaw : IFromRawJson<Cell>
{
    /// <inheritdoc/>
    public Cell FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Cell.FromRawUnchecked(rawData);
}

/// <summary>
/// pending until approved or rejected.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Approved,
    Pending,
    Rejected,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "approved" => Status.Approved,
            "pending" => Status.Pending,
            "rejected" => Status.Rejected,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Approved => "approved",
                Status.Pending => "pending",
                Status.Rejected => "rejected",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
