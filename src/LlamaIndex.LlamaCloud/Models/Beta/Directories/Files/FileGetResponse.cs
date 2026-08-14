using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Files;
using System = System;

namespace LlamaIndex.LlamaCloud.Models.Beta.Directories.Files;

/// <summary>
/// API response schema for a directory file.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileGetResponse, FileGetResponseFromRaw>))]
public sealed record class FileGetResponse : JsonModel
{
    /// <summary>
    /// Unique identifier for the directory file.
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
    /// Directory the file belongs to.
    /// </summary>
    public required string DirectoryID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("directory_id");
        }
        init { this._rawData.Set("directory_id", value); }
    }

    /// <summary>
    /// Display name for the file.
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
    }

    /// <summary>
    /// Project the directory file belongs to.
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
    /// Unique identifier for the file in the directory
    /// </summary>
    public required string UniqueID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("unique_id");
        }
        init { this._rawData.Set("unique_id", value); }
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
    /// Soft delete marker when the file is removed upstream or by user action.
    /// </summary>
    public System::DateTimeOffset? DeletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("deleted_at");
        }
        init { this._rawData.Set("deleted_at", value); }
    }

    /// <summary>
    /// Schema for a presigned URL.
    /// </summary>
    public PresignedUrl? DownloadUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PresignedUrl>("download_url");
        }
        init { this._rawData.Set("download_url", value); }
    }

    /// <summary>
    /// File ID for the storage location.
    /// </summary>
    public string? FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    /// <summary>
    /// Merged metadata from all sources. Higher-priority sources override lower.
    /// </summary>
    public IReadOnlyDictionary<string, FileGetResponseMetadata?>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                FrozenDictionary<string, FileGetResponseMetadata?>
            >("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, FileGetResponseMetadata?>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.DirectoryID;
        _ = this.DisplayName;
        _ = this.ProjectID;
        _ = this.UniqueID;
        _ = this.CreatedAt;
        _ = this.DeletedAt;
        this.DownloadUrl?.Validate();
        _ = this.FileID;
        if (this.Metadata != null)
        {
            foreach (var item in this.Metadata.Values)
            {
                item?.Validate();
            }
        }
        _ = this.UpdatedAt;
    }

    public FileGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileGetResponse(FileGetResponse fileGetResponse)
        : base(fileGetResponse) { }
#pragma warning restore CS8618

    public FileGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileGetResponseFromRaw.FromRawUnchecked"/>
    public static FileGetResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileGetResponseFromRaw : IFromRawJson<FileGetResponse>
{
    /// <inheritdoc/>
    public FileGetResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileGetResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FileGetResponseMetadataConverter))]
public record class FileGetResponseMetadata : ModelBase
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

    public FileGetResponseMetadata(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FileGetResponseMetadata(long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FileGetResponseMetadata(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FileGetResponseMetadata(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public FileGetResponseMetadata(IReadOnlyList<string> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public FileGetResponseMetadata(JsonElement element)
    {
        this._element = element;
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
    /// type <see cref="long"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLong(out var value)) {
    ///     // `value` is of type `long`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value = this.Value as long?;
        return value != null;
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
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>string</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickListValue(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;string&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickListValue([NotNullWhen(true)] out IReadOnlyList<string>? value)
    {
        value = this.Value as IReadOnlyList<string>;
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
    ///     (string value) =&gt; {...},
    ///     (long value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<long> @long,
        System::Action<double> @double,
        System::Action<bool> @bool,
        System::Action<IReadOnlyList<string>> metadataListValue
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case long value:
                @long(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            case IReadOnlyList<string> value:
                metadataListValue(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of FileGetResponseMetadata"
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
    ///     (string value) =&gt; {...},
    ///     (long value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<long, T> @long,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool,
        System::Func<IReadOnlyList<string>, T> metadataListValue
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            long value => @long(value),
            double value => @double(value),
            bool value => @bool(value),
            IReadOnlyList<string> value => metadataListValue(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of FileGetResponseMetadata"
            ),
        };
    }

    public static implicit operator FileGetResponseMetadata(string value) => new(value);

    public static implicit operator FileGetResponseMetadata(long value) => new(value);

    public static implicit operator FileGetResponseMetadata(double value) => new(value);

    public static implicit operator FileGetResponseMetadata(bool value) => new(value);

    public static implicit operator FileGetResponseMetadata(List<string> value) =>
        new((IReadOnlyList<string>)value);

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
                "Data did not match any variant of FileGetResponseMetadata"
            );
        }
    }

    public virtual bool Equals(FileGetResponseMetadata? other) =>
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
            string _ => 0,
            long _ => 1,
            double _ => 2,
            bool _ => 3,
            IReadOnlyList<string> _ => 4,
            _ => -1,
        };
    }
}

sealed class FileGetResponseMetadataConverter : JsonConverter<FileGetResponseMetadata>
{
    public override FileGetResponseMetadata? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is LlamaCloudInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(element, options);
            if (deserialized != null)
            {
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
        FileGetResponseMetadata value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
