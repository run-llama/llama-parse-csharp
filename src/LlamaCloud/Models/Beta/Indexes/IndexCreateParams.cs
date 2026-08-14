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

namespace LlamaCloud.Models.Beta.Indexes;

/// <summary>
/// Create a searchable index over a source directory.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class IndexCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// ID of the source directory containing your documents.
    /// </summary>
    public required string SourceDirectoryID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("source_directory_id");
        }
        init { this._rawBodyData.Set("source_directory_id", value); }
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
    /// Optional description of the index.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// Optional display name for the index. If omitted, the index is named after
    /// the source directory.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Product configurations for syncing. Omit to use a default parse configuration.
    /// Include an explicit entry per product type (e.g. parse, extract) to override
    /// the default.
    /// </summary>
    public IReadOnlyList<Product>? Products
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Product>>("products");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Product>?>(
                "products",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Attachment kinds to store alongside parsed output. Each entry must be one
    /// of: screenshots, items. For example, ['screenshots'] renders and stores per-page
    /// screenshots; ['items'] stores structured items with bounding boxes. Omit or
    /// pass an empty list to skip attachments.
    /// </summary>
    public IReadOnlyList<string>? StoreAttachments
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("store_attachments");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "store_attachments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// How often to re-run the sync. One of: manual, daily, on_source_change. Defaults
    /// to manual.
    /// </summary>
    public string? SyncFrequency
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("sync_frequency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("sync_frequency", value);
        }
    }

    /// <summary>
    /// Vector export destination for the index. 'DEFAULT' exports to the managed
    /// vector DB destination resolved from configuration. 'DISABLED' skips vector
    /// export — the export destination falls back to 'Download'.
    /// </summary>
    public ApiEnum<string, VectorTarget>? VectorTarget
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, VectorTarget>>(
                "vector_target"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("vector_target", value);
        }
    }

    public IndexCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IndexCreateParams(IndexCreateParams indexCreateParams)
        : base(indexCreateParams)
    {
        this._rawBodyData = new(indexCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public IndexCreateParams(
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
    IndexCreateParams(
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
    public static IndexCreateParams FromRawUnchecked(
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

    public virtual bool Equals(IndexCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/api/v1/indexes")
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
/// A product configuration to include in an index's sync.
///
/// <para>Structurally mirrors ``directory_sync.SyncProductEntryRequest`` but is a
/// distinct class so the Index API surface stays SDK-gen-isolated from directory-sync
/// internals. Translation between the two happens in ``index/api_utils.py``.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Product, ProductFromRaw>))]
public sealed record class Product : JsonModel
{
    /// <summary>
    /// ID of the product configuration.
    /// </summary>
    public required string ProductConfigID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_config_id");
        }
        init { this._rawData.Set("product_config_id", value); }
    }

    /// <summary>
    /// Product type. One of: parse, extract.
    /// </summary>
    public required string ProductType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("product_type");
        }
        init { this._rawData.Set("product_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ProductConfigID;
        _ = this.ProductType;
    }

    public Product() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Product(Product product)
        : base(product) { }
#pragma warning restore CS8618

    public Product(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Product(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProductFromRaw.FromRawUnchecked"/>
    public static Product FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProductFromRaw : IFromRawJson<Product>
{
    /// <inheritdoc/>
    public Product FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Product.FromRawUnchecked(rawData);
}

/// <summary>
/// Vector export destination for the index. 'DEFAULT' exports to the managed vector
/// DB destination resolved from configuration. 'DISABLED' skips vector export —
/// the export destination falls back to 'Download'.
/// </summary>
[JsonConverter(typeof(VectorTargetConverter))]
public enum VectorTarget
{
    Default,
    Disabled,
}

sealed class VectorTargetConverter : JsonConverter<VectorTarget>
{
    public override VectorTarget Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DEFAULT" => VectorTarget.Default,
            "DISABLED" => VectorTarget.Disabled,
            _ => (VectorTarget)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VectorTarget value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VectorTarget.Default => "DEFAULT",
                VectorTarget.Disabled => "DISABLED",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
