using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaIndex.LlamaCloud.Core;

namespace LlamaIndex.LlamaCloud.Models.Beta.Indexes;

/// <summary>
/// A searchable index over a directory of documents.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<IndexGetResponse, IndexGetResponseFromRaw>))]
public sealed record class IndexGetResponse : JsonModel
{
    /// <summary>
    /// Unique identifier
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
    /// ID of the export configuration.
    /// </summary>
    public required string ExportConfigID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("export_config_id");
        }
        init { this._rawData.Set("export_config_id", value); }
    }

    /// <summary>
    /// Index name.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// ID of the output directory holding the indexed files.
    /// </summary>
    public required string OutputDirectoryID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("output_directory_id");
        }
        init { this._rawData.Set("output_directory_id", value); }
    }

    /// <summary>
    /// Project this index belongs to.
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
    /// ID of the source directory.
    /// </summary>
    public required string SourceDirectoryID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("source_directory_id");
        }
        init { this._rawData.Set("source_directory_id", value); }
    }

    /// <summary>
    /// ID of the sync configuration.
    /// </summary>
    public required string SyncConfigID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sync_config_id");
        }
        init { this._rawData.Set("sync_config_id", value); }
    }

    /// <summary>
    /// Creation datetime
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Index description.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Last export time.
    /// </summary>
    public DateTimeOffset? LastExportedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_exported_at");
        }
        init { this._rawData.Set("last_exported_at", value); }
    }

    /// <summary>
    /// Last sync time.
    /// </summary>
    public DateTimeOffset? LastSyncedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_synced_at");
        }
        init { this._rawData.Set("last_synced_at", value); }
    }

    /// <summary>
    /// Build state and diagnostic info.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Update datetime
    /// </summary>
    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExportConfigID;
        _ = this.Name;
        _ = this.OutputDirectoryID;
        _ = this.ProjectID;
        _ = this.SourceDirectoryID;
        _ = this.SyncConfigID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.LastExportedAt;
        _ = this.LastSyncedAt;
        _ = this.Metadata;
        _ = this.UpdatedAt;
    }

    public IndexGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IndexGetResponse(IndexGetResponse indexGetResponse)
        : base(indexGetResponse) { }
#pragma warning restore CS8618

    public IndexGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IndexGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IndexGetResponseFromRaw.FromRawUnchecked"/>
    public static IndexGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IndexGetResponseFromRaw : IFromRawJson<IndexGetResponse>
{
    /// <inheritdoc/>
    public IndexGetResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IndexGetResponse.FromRawUnchecked(rawData);
}
