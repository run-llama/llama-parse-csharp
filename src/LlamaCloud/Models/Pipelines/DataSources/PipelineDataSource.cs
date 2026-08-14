using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using DataSources = LlamaCloud.Models.DataSources;
using System = System;

namespace LlamaCloud.Models.Pipelines.DataSources;

/// <summary>
/// Schema for a data source in a pipeline.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PipelineDataSource, PipelineDataSourceFromRaw>))]
public sealed record class PipelineDataSource : JsonModel
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
    /// Component that implements the data source
    /// </summary>
    public required Component Component
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Component>("component");
        }
        init { this._rawData.Set("component", value); }
    }

    /// <summary>
    /// The ID of the data source.
    /// </summary>
    public required string DataSourceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("data_source_id");
        }
        init { this._rawData.Set("data_source_id", value); }
    }

    /// <summary>
    /// The last time the data source was automatically synced.
    /// </summary>
    public required System::DateTimeOffset LastSyncedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("last_synced_at");
        }
        init { this._rawData.Set("last_synced_at", value); }
    }

    /// <summary>
    /// The name of the data source.
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
    /// The ID of the pipeline.
    /// </summary>
    public required string PipelineID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("pipeline_id");
        }
        init { this._rawData.Set("pipeline_id", value); }
    }

    public required string ProjectID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("project_id");
        }
        init { this._rawData.Set("project_id", value); }
    }

    public required ApiEnum<string, SourceType> SourceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SourceType>>("source_type");
        }
        init { this._rawData.Set("source_type", value); }
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
    /// Custom metadata that will be present on all data loaded from the data source
    /// </summary>
    public IReadOnlyDictionary<string, CustomMetadata?>? CustomMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, CustomMetadata?>>(
                "custom_metadata"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, CustomMetadata?>?>(
                "custom_metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The status of the data source in the pipeline.
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The last time the status was updated.
    /// </summary>
    public System::DateTimeOffset? StatusUpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("status_updated_at");
        }
        init { this._rawData.Set("status_updated_at", value); }
    }

    /// <summary>
    /// The interval at which the data source should be synced.
    /// </summary>
    public double? SyncInterval
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("sync_interval");
        }
        init { this._rawData.Set("sync_interval", value); }
    }

    /// <summary>
    /// The id of the user who set the sync schedule.
    /// </summary>
    public string? SyncScheduleSetBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sync_schedule_set_by");
        }
        init { this._rawData.Set("sync_schedule_set_by", value); }
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

    /// <summary>
    /// Version metadata for the data source
    /// </summary>
    public DataSources::DataSourceReaderVersionMetadata? VersionMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataSources::DataSourceReaderVersionMetadata>(
                "version_metadata"
            );
        }
        init { this._rawData.Set("version_metadata", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Component.Validate();
        _ = this.DataSourceID;
        _ = this.LastSyncedAt;
        _ = this.Name;
        _ = this.PipelineID;
        _ = this.ProjectID;
        this.SourceType.Validate();
        _ = this.CreatedAt;
        if (this.CustomMetadata != null)
        {
            foreach (var item in this.CustomMetadata.Values)
            {
                item?.Validate();
            }
        }
        this.Status?.Validate();
        _ = this.StatusUpdatedAt;
        _ = this.SyncInterval;
        _ = this.SyncScheduleSetBy;
        _ = this.UpdatedAt;
        this.VersionMetadata?.Validate();
    }

    public PipelineDataSource() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PipelineDataSource(PipelineDataSource pipelineDataSource)
        : base(pipelineDataSource) { }
#pragma warning restore CS8618

    public PipelineDataSource(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PipelineDataSource(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PipelineDataSourceFromRaw.FromRawUnchecked"/>
    public static PipelineDataSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PipelineDataSourceFromRaw : IFromRawJson<PipelineDataSource>
{
    /// <inheritdoc/>
    public PipelineDataSource FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PipelineDataSource.FromRawUnchecked(rawData);
}

/// <summary>
/// Component that implements the data source
/// </summary>
[JsonConverter(typeof(ComponentConverter))]
public record class Component : ModelBase
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

    public string? ClassName
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudS3DataSource: (x) => x.ClassName,
                cloudAzStorageBlobDataSource: (x) => x.ClassName,
                cloudGoogleDriveDataSource: (x) => x.ClassName,
                cloudOneDriveDataSource: (x) => x.ClassName,
                cloudSharepointDataSource: (x) => x.ClassName,
                cloudSlackDataSource: (x) => x.ClassName,
                cloudNotionPageDataSource: (x) => x.ClassName,
                cloudConfluenceDataSource: (x) => x.ClassName,
                cloudJiraDataSource: (x) => x.ClassName,
                cloudJiraDataSourceV2: (x) => x.ClassName,
                cloudBoxDataSource: (x) => x.ClassName
            );
        }
    }

    public string? Prefix
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudS3DataSource: (x) => x.Prefix,
                cloudAzStorageBlobDataSource: (x) => x.Prefix,
                cloudGoogleDriveDataSource: (_) => null,
                cloudOneDriveDataSource: (_) => null,
                cloudSharepointDataSource: (_) => null,
                cloudSlackDataSource: (_) => null,
                cloudNotionPageDataSource: (_) => null,
                cloudConfluenceDataSource: (_) => null,
                cloudJiraDataSource: (_) => null,
                cloudJiraDataSourceV2: (_) => null,
                cloudBoxDataSource: (_) => null
            );
        }
    }

    public string? ClientID
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudS3DataSource: (_) => null,
                cloudAzStorageBlobDataSource: (x) => x.ClientID,
                cloudGoogleDriveDataSource: (_) => null,
                cloudOneDriveDataSource: (x) => x.ClientID,
                cloudSharepointDataSource: (x) => x.ClientID,
                cloudSlackDataSource: (_) => null,
                cloudNotionPageDataSource: (_) => null,
                cloudConfluenceDataSource: (_) => null,
                cloudJiraDataSource: (_) => null,
                cloudJiraDataSourceV2: (_) => null,
                cloudBoxDataSource: (x) => x.ClientID
            );
        }
    }

    public string? ClientSecret
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudS3DataSource: (_) => null,
                cloudAzStorageBlobDataSource: (x) => x.ClientSecret,
                cloudGoogleDriveDataSource: (_) => null,
                cloudOneDriveDataSource: (x) => x.ClientSecret,
                cloudSharepointDataSource: (x) => x.ClientSecret,
                cloudSlackDataSource: (_) => null,
                cloudNotionPageDataSource: (_) => null,
                cloudConfluenceDataSource: (_) => null,
                cloudJiraDataSource: (_) => null,
                cloudJiraDataSourceV2: (_) => null,
                cloudBoxDataSource: (x) => x.ClientSecret
            );
        }
    }

    public string? TenantID
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudS3DataSource: (_) => null,
                cloudAzStorageBlobDataSource: (x) => x.TenantID,
                cloudGoogleDriveDataSource: (_) => null,
                cloudOneDriveDataSource: (x) => x.TenantID,
                cloudSharepointDataSource: (x) => x.TenantID,
                cloudSlackDataSource: (_) => null,
                cloudNotionPageDataSource: (_) => null,
                cloudConfluenceDataSource: (_) => null,
                cloudJiraDataSource: (_) => null,
                cloudJiraDataSourceV2: (_) => null,
                cloudBoxDataSource: (_) => null
            );
        }
    }

    public string? FolderID
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudS3DataSource: (_) => null,
                cloudAzStorageBlobDataSource: (_) => null,
                cloudGoogleDriveDataSource: (x) => x.FolderID,
                cloudOneDriveDataSource: (x) => x.FolderID,
                cloudSharepointDataSource: (x) => x.FolderID,
                cloudSlackDataSource: (_) => null,
                cloudNotionPageDataSource: (_) => null,
                cloudConfluenceDataSource: (_) => null,
                cloudJiraDataSource: (_) => null,
                cloudJiraDataSourceV2: (_) => null,
                cloudBoxDataSource: (x) => x.FolderID
            );
        }
    }

    public string? FolderPath
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudS3DataSource: (_) => null,
                cloudAzStorageBlobDataSource: (_) => null,
                cloudGoogleDriveDataSource: (_) => null,
                cloudOneDriveDataSource: (x) => x.FolderPath,
                cloudSharepointDataSource: (x) => x.FolderPath,
                cloudSlackDataSource: (_) => null,
                cloudNotionPageDataSource: (_) => null,
                cloudConfluenceDataSource: (_) => null,
                cloudJiraDataSource: (_) => null,
                cloudJiraDataSourceV2: (_) => null,
                cloudBoxDataSource: (_) => null
            );
        }
    }

    public bool? GetPermissions
    {
        get
        {
            return Match<bool?>(
                jsonElements: (_) => null,
                cloudS3DataSource: (_) => null,
                cloudAzStorageBlobDataSource: (_) => null,
                cloudGoogleDriveDataSource: (_) => null,
                cloudOneDriveDataSource: (_) => null,
                cloudSharepointDataSource: (x) => x.GetPermissions,
                cloudSlackDataSource: (_) => null,
                cloudNotionPageDataSource: (_) => null,
                cloudConfluenceDataSource: (_) => null,
                cloudJiraDataSource: (_) => null,
                cloudJiraDataSourceV2: (x) => x.GetPermissions,
                cloudBoxDataSource: (_) => null
            );
        }
    }

    public string? PageIds
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudS3DataSource: (_) => null,
                cloudAzStorageBlobDataSource: (_) => null,
                cloudGoogleDriveDataSource: (_) => null,
                cloudOneDriveDataSource: (_) => null,
                cloudSharepointDataSource: (_) => null,
                cloudSlackDataSource: (_) => null,
                cloudNotionPageDataSource: (x) => x.PageIds,
                cloudConfluenceDataSource: (x) => x.PageIds,
                cloudJiraDataSource: (_) => null,
                cloudJiraDataSourceV2: (_) => null,
                cloudBoxDataSource: (_) => null
            );
        }
    }

    public string? ServerUrl
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudS3DataSource: (_) => null,
                cloudAzStorageBlobDataSource: (_) => null,
                cloudGoogleDriveDataSource: (_) => null,
                cloudOneDriveDataSource: (_) => null,
                cloudSharepointDataSource: (_) => null,
                cloudSlackDataSource: (_) => null,
                cloudNotionPageDataSource: (_) => null,
                cloudConfluenceDataSource: (x) => x.ServerUrl,
                cloudJiraDataSource: (x) => x.ServerUrl,
                cloudJiraDataSourceV2: (x) => x.ServerUrl,
                cloudBoxDataSource: (_) => null
            );
        }
    }

    public string? ApiToken
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudS3DataSource: (_) => null,
                cloudAzStorageBlobDataSource: (_) => null,
                cloudGoogleDriveDataSource: (_) => null,
                cloudOneDriveDataSource: (_) => null,
                cloudSharepointDataSource: (_) => null,
                cloudSlackDataSource: (_) => null,
                cloudNotionPageDataSource: (_) => null,
                cloudConfluenceDataSource: (x) => x.ApiToken,
                cloudJiraDataSource: (x) => x.ApiToken,
                cloudJiraDataSourceV2: (x) => x.ApiToken,
                cloudBoxDataSource: (_) => null
            );
        }
    }

    public string? Query
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudS3DataSource: (_) => null,
                cloudAzStorageBlobDataSource: (_) => null,
                cloudGoogleDriveDataSource: (_) => null,
                cloudOneDriveDataSource: (_) => null,
                cloudSharepointDataSource: (_) => null,
                cloudSlackDataSource: (_) => null,
                cloudNotionPageDataSource: (_) => null,
                cloudConfluenceDataSource: (_) => null,
                cloudJiraDataSource: (x) => x.Query,
                cloudJiraDataSourceV2: (x) => x.Query,
                cloudBoxDataSource: (_) => null
            );
        }
    }

    public string? CloudID
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudS3DataSource: (_) => null,
                cloudAzStorageBlobDataSource: (_) => null,
                cloudGoogleDriveDataSource: (_) => null,
                cloudOneDriveDataSource: (_) => null,
                cloudSharepointDataSource: (_) => null,
                cloudSlackDataSource: (_) => null,
                cloudNotionPageDataSource: (_) => null,
                cloudConfluenceDataSource: (_) => null,
                cloudJiraDataSource: (x) => x.CloudID,
                cloudJiraDataSourceV2: (x) => x.CloudID,
                cloudBoxDataSource: (_) => null
            );
        }
    }

    public string? Email
    {
        get
        {
            return Match<string?>(
                jsonElements: (_) => null,
                cloudS3DataSource: (_) => null,
                cloudAzStorageBlobDataSource: (_) => null,
                cloudGoogleDriveDataSource: (_) => null,
                cloudOneDriveDataSource: (_) => null,
                cloudSharepointDataSource: (_) => null,
                cloudSlackDataSource: (_) => null,
                cloudNotionPageDataSource: (_) => null,
                cloudConfluenceDataSource: (_) => null,
                cloudJiraDataSource: (x) => x.Email,
                cloudJiraDataSourceV2: (x) => x.Email,
                cloudBoxDataSource: (_) => null
            );
        }
    }

    public Component(IReadOnlyDictionary<string, JsonElement> value, JsonElement? element = null)
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public Component(CloudS3DataSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Component(CloudAzStorageBlobDataSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Component(CloudGoogleDriveDataSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Component(CloudOneDriveDataSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Component(CloudSharepointDataSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Component(CloudSlackDataSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Component(CloudNotionPageDataSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Component(CloudConfluenceDataSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Component(CloudJiraDataSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Component(CloudJiraDataSourceV2 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Component(CloudBoxDataSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Component(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>JsonElement</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements(out var value)) {
    ///     // `value` is of type `IReadOnlyDictionary&lt;string, JsonElement&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value = this.Value as IReadOnlyDictionary<string, JsonElement>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudS3DataSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudS3DataSource(out var value)) {
    ///     // `value` is of type `CloudS3DataSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudS3DataSource([NotNullWhen(true)] out CloudS3DataSource? value)
    {
        value = this.Value as CloudS3DataSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudAzStorageBlobDataSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudAzStorageBlobDataSource(out var value)) {
    ///     // `value` is of type `CloudAzStorageBlobDataSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudAzStorageBlobDataSource(
        [NotNullWhen(true)] out CloudAzStorageBlobDataSource? value
    )
    {
        value = this.Value as CloudAzStorageBlobDataSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudGoogleDriveDataSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudGoogleDriveDataSource(out var value)) {
    ///     // `value` is of type `CloudGoogleDriveDataSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudGoogleDriveDataSource(
        [NotNullWhen(true)] out CloudGoogleDriveDataSource? value
    )
    {
        value = this.Value as CloudGoogleDriveDataSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudOneDriveDataSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudOneDriveDataSource(out var value)) {
    ///     // `value` is of type `CloudOneDriveDataSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudOneDriveDataSource(
        [NotNullWhen(true)] out CloudOneDriveDataSource? value
    )
    {
        value = this.Value as CloudOneDriveDataSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudSharepointDataSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudSharepointDataSource(out var value)) {
    ///     // `value` is of type `CloudSharepointDataSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudSharepointDataSource(
        [NotNullWhen(true)] out CloudSharepointDataSource? value
    )
    {
        value = this.Value as CloudSharepointDataSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudSlackDataSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudSlackDataSource(out var value)) {
    ///     // `value` is of type `CloudSlackDataSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudSlackDataSource([NotNullWhen(true)] out CloudSlackDataSource? value)
    {
        value = this.Value as CloudSlackDataSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudNotionPageDataSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudNotionPageDataSource(out var value)) {
    ///     // `value` is of type `CloudNotionPageDataSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudNotionPageDataSource(
        [NotNullWhen(true)] out CloudNotionPageDataSource? value
    )
    {
        value = this.Value as CloudNotionPageDataSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudConfluenceDataSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudConfluenceDataSource(out var value)) {
    ///     // `value` is of type `CloudConfluenceDataSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudConfluenceDataSource(
        [NotNullWhen(true)] out CloudConfluenceDataSource? value
    )
    {
        value = this.Value as CloudConfluenceDataSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudJiraDataSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudJiraDataSource(out var value)) {
    ///     // `value` is of type `CloudJiraDataSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudJiraDataSource([NotNullWhen(true)] out CloudJiraDataSource? value)
    {
        value = this.Value as CloudJiraDataSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudJiraDataSourceV2"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudJiraDataSourceV2(out var value)) {
    ///     // `value` is of type `CloudJiraDataSourceV2`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudJiraDataSourceV2([NotNullWhen(true)] out CloudJiraDataSourceV2? value)
    {
        value = this.Value as CloudJiraDataSourceV2;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudBoxDataSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudBoxDataSource(out var value)) {
    ///     // `value` is of type `CloudBoxDataSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudBoxDataSource([NotNullWhen(true)] out CloudBoxDataSource? value)
    {
        value = this.Value as CloudBoxDataSource;
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
    ///     (IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
    ///     (CloudS3DataSource value) =&gt; {...},
    ///     (CloudAzStorageBlobDataSource value) =&gt; {...},
    ///     (CloudGoogleDriveDataSource value) =&gt; {...},
    ///     (CloudOneDriveDataSource value) =&gt; {...},
    ///     (CloudSharepointDataSource value) =&gt; {...},
    ///     (CloudSlackDataSource value) =&gt; {...},
    ///     (CloudNotionPageDataSource value) =&gt; {...},
    ///     (CloudConfluenceDataSource value) =&gt; {...},
    ///     (CloudJiraDataSource value) =&gt; {...},
    ///     (CloudJiraDataSourceV2 value) =&gt; {...},
    ///     (CloudBoxDataSource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<IReadOnlyDictionary<string, JsonElement>> jsonElements,
        System::Action<CloudS3DataSource> cloudS3DataSource,
        System::Action<CloudAzStorageBlobDataSource> cloudAzStorageBlobDataSource,
        System::Action<CloudGoogleDriveDataSource> cloudGoogleDriveDataSource,
        System::Action<CloudOneDriveDataSource> cloudOneDriveDataSource,
        System::Action<CloudSharepointDataSource> cloudSharepointDataSource,
        System::Action<CloudSlackDataSource> cloudSlackDataSource,
        System::Action<CloudNotionPageDataSource> cloudNotionPageDataSource,
        System::Action<CloudConfluenceDataSource> cloudConfluenceDataSource,
        System::Action<CloudJiraDataSource> cloudJiraDataSource,
        System::Action<CloudJiraDataSourceV2> cloudJiraDataSourceV2,
        System::Action<CloudBoxDataSource> cloudBoxDataSource
    )
    {
        switch (this.Value)
        {
            case IReadOnlyDictionary<string, JsonElement> value:
                jsonElements(value);
                break;
            case CloudS3DataSource value:
                cloudS3DataSource(value);
                break;
            case CloudAzStorageBlobDataSource value:
                cloudAzStorageBlobDataSource(value);
                break;
            case CloudGoogleDriveDataSource value:
                cloudGoogleDriveDataSource(value);
                break;
            case CloudOneDriveDataSource value:
                cloudOneDriveDataSource(value);
                break;
            case CloudSharepointDataSource value:
                cloudSharepointDataSource(value);
                break;
            case CloudSlackDataSource value:
                cloudSlackDataSource(value);
                break;
            case CloudNotionPageDataSource value:
                cloudNotionPageDataSource(value);
                break;
            case CloudConfluenceDataSource value:
                cloudConfluenceDataSource(value);
                break;
            case CloudJiraDataSource value:
                cloudJiraDataSource(value);
                break;
            case CloudJiraDataSourceV2 value:
                cloudJiraDataSourceV2(value);
                break;
            case CloudBoxDataSource value:
                cloudBoxDataSource(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of Component"
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
    ///     (IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
    ///     (CloudS3DataSource value) =&gt; {...},
    ///     (CloudAzStorageBlobDataSource value) =&gt; {...},
    ///     (CloudGoogleDriveDataSource value) =&gt; {...},
    ///     (CloudOneDriveDataSource value) =&gt; {...},
    ///     (CloudSharepointDataSource value) =&gt; {...},
    ///     (CloudSlackDataSource value) =&gt; {...},
    ///     (CloudNotionPageDataSource value) =&gt; {...},
    ///     (CloudConfluenceDataSource value) =&gt; {...},
    ///     (CloudJiraDataSource value) =&gt; {...},
    ///     (CloudJiraDataSourceV2 value) =&gt; {...},
    ///     (CloudBoxDataSource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<IReadOnlyDictionary<string, JsonElement>, T> jsonElements,
        System::Func<CloudS3DataSource, T> cloudS3DataSource,
        System::Func<CloudAzStorageBlobDataSource, T> cloudAzStorageBlobDataSource,
        System::Func<CloudGoogleDriveDataSource, T> cloudGoogleDriveDataSource,
        System::Func<CloudOneDriveDataSource, T> cloudOneDriveDataSource,
        System::Func<CloudSharepointDataSource, T> cloudSharepointDataSource,
        System::Func<CloudSlackDataSource, T> cloudSlackDataSource,
        System::Func<CloudNotionPageDataSource, T> cloudNotionPageDataSource,
        System::Func<CloudConfluenceDataSource, T> cloudConfluenceDataSource,
        System::Func<CloudJiraDataSource, T> cloudJiraDataSource,
        System::Func<CloudJiraDataSourceV2, T> cloudJiraDataSourceV2,
        System::Func<CloudBoxDataSource, T> cloudBoxDataSource
    )
    {
        return this.Value switch
        {
            IReadOnlyDictionary<string, JsonElement> value => jsonElements(value),
            CloudS3DataSource value => cloudS3DataSource(value),
            CloudAzStorageBlobDataSource value => cloudAzStorageBlobDataSource(value),
            CloudGoogleDriveDataSource value => cloudGoogleDriveDataSource(value),
            CloudOneDriveDataSource value => cloudOneDriveDataSource(value),
            CloudSharepointDataSource value => cloudSharepointDataSource(value),
            CloudSlackDataSource value => cloudSlackDataSource(value),
            CloudNotionPageDataSource value => cloudNotionPageDataSource(value),
            CloudConfluenceDataSource value => cloudConfluenceDataSource(value),
            CloudJiraDataSource value => cloudJiraDataSource(value),
            CloudJiraDataSourceV2 value => cloudJiraDataSourceV2(value),
            CloudBoxDataSource value => cloudBoxDataSource(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of Component"
            ),
        };
    }

    public static implicit operator Component(Dictionary<string, JsonElement> value) =>
        new((IReadOnlyDictionary<string, JsonElement>)value);

    public static implicit operator Component(CloudS3DataSource value) => new(value);

    public static implicit operator Component(CloudAzStorageBlobDataSource value) => new(value);

    public static implicit operator Component(CloudGoogleDriveDataSource value) => new(value);

    public static implicit operator Component(CloudOneDriveDataSource value) => new(value);

    public static implicit operator Component(CloudSharepointDataSource value) => new(value);

    public static implicit operator Component(CloudSlackDataSource value) => new(value);

    public static implicit operator Component(CloudNotionPageDataSource value) => new(value);

    public static implicit operator Component(CloudConfluenceDataSource value) => new(value);

    public static implicit operator Component(CloudJiraDataSource value) => new(value);

    public static implicit operator Component(CloudJiraDataSourceV2 value) => new(value);

    public static implicit operator Component(CloudBoxDataSource value) => new(value);

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
            throw new LlamaCloudInvalidDataException("Data did not match any variant of Component");
        }
        this.Switch(
            (_) => { },
            (cloudS3DataSource) => cloudS3DataSource.Validate(),
            (cloudAzStorageBlobDataSource) => cloudAzStorageBlobDataSource.Validate(),
            (cloudGoogleDriveDataSource) => cloudGoogleDriveDataSource.Validate(),
            (cloudOneDriveDataSource) => cloudOneDriveDataSource.Validate(),
            (cloudSharepointDataSource) => cloudSharepointDataSource.Validate(),
            (cloudSlackDataSource) => cloudSlackDataSource.Validate(),
            (cloudNotionPageDataSource) => cloudNotionPageDataSource.Validate(),
            (cloudConfluenceDataSource) => cloudConfluenceDataSource.Validate(),
            (cloudJiraDataSource) => cloudJiraDataSource.Validate(),
            (cloudJiraDataSourceV2) => cloudJiraDataSourceV2.Validate(),
            (cloudBoxDataSource) => cloudBoxDataSource.Validate()
        );
    }

    public virtual bool Equals(Component? other) =>
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
            IReadOnlyDictionary<string, JsonElement> _ => 0,
            CloudS3DataSource _ => 1,
            CloudAzStorageBlobDataSource _ => 2,
            CloudGoogleDriveDataSource _ => 3,
            CloudOneDriveDataSource _ => 4,
            CloudSharepointDataSource _ => 5,
            CloudSlackDataSource _ => 6,
            CloudNotionPageDataSource _ => 7,
            CloudConfluenceDataSource _ => 8,
            CloudJiraDataSource _ => 9,
            CloudJiraDataSourceV2 _ => 10,
            CloudBoxDataSource _ => 11,
            _ => -1,
        };
    }
}

sealed class ComponentConverter : JsonConverter<Component>
{
    public override Component? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<CloudS3DataSource>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<CloudAzStorageBlobDataSource>(
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
            var deserialized = JsonSerializer.Deserialize<CloudGoogleDriveDataSource>(
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
            var deserialized = JsonSerializer.Deserialize<CloudOneDriveDataSource>(
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
            var deserialized = JsonSerializer.Deserialize<CloudSharepointDataSource>(
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
            var deserialized = JsonSerializer.Deserialize<CloudSlackDataSource>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<CloudNotionPageDataSource>(
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
            var deserialized = JsonSerializer.Deserialize<CloudConfluenceDataSource>(
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
            var deserialized = JsonSerializer.Deserialize<CloudJiraDataSource>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<CloudJiraDataSourceV2>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<CloudBoxDataSource>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                element,
                options
            );
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
        Component value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(SourceTypeConverter))]
public enum SourceType
{
    AzureStorageBlob,
    Box,
    Confluence,
    GoogleDrive,
    Jira,
    JiraV2,
    MicrosoftOnedrive,
    MicrosoftSharepoint,
    NotionPage,
    S3,
    Slack,
}

sealed class SourceTypeConverter : JsonConverter<SourceType>
{
    public override SourceType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "AZURE_STORAGE_BLOB" => SourceType.AzureStorageBlob,
            "BOX" => SourceType.Box,
            "CONFLUENCE" => SourceType.Confluence,
            "GOOGLE_DRIVE" => SourceType.GoogleDrive,
            "JIRA" => SourceType.Jira,
            "JIRA_V2" => SourceType.JiraV2,
            "MICROSOFT_ONEDRIVE" => SourceType.MicrosoftOnedrive,
            "MICROSOFT_SHAREPOINT" => SourceType.MicrosoftSharepoint,
            "NOTION_PAGE" => SourceType.NotionPage,
            "S3" => SourceType.S3,
            "SLACK" => SourceType.Slack,
            _ => (SourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SourceType.AzureStorageBlob => "AZURE_STORAGE_BLOB",
                SourceType.Box => "BOX",
                SourceType.Confluence => "CONFLUENCE",
                SourceType.GoogleDrive => "GOOGLE_DRIVE",
                SourceType.Jira => "JIRA",
                SourceType.JiraV2 => "JIRA_V2",
                SourceType.MicrosoftOnedrive => "MICROSOFT_ONEDRIVE",
                SourceType.MicrosoftSharepoint => "MICROSOFT_SHAREPOINT",
                SourceType.NotionPage => "NOTION_PAGE",
                SourceType.S3 => "S3",
                SourceType.Slack => "SLACK",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(CustomMetadataConverter))]
public record class CustomMetadata : ModelBase
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

    public CustomMetadata(
        IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public CustomMetadata(IReadOnlyList<JsonElement> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public CustomMetadata(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CustomMetadata(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CustomMetadata(bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public CustomMetadata(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>JsonElement</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements(out var value)) {
    ///     // `value` is of type `IReadOnlyDictionary&lt;string, JsonElement&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value = this.Value as IReadOnlyDictionary<string, JsonElement>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>JsonElement</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJsonElements1(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;JsonElement&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJsonElements1([NotNullWhen(true)] out IReadOnlyList<JsonElement>? value)
    {
        value = this.Value as IReadOnlyList<JsonElement>;
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
    ///     (IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
    ///     (IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<IReadOnlyDictionary<string, JsonElement>> jsonElements,
        System::Action<IReadOnlyList<JsonElement>> jsonElements1,
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case IReadOnlyDictionary<string, JsonElement> value:
                jsonElements(value);
                break;
            case IReadOnlyList<JsonElement> value:
                jsonElements1(value);
                break;
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new LlamaCloudInvalidDataException(
                    "Data did not match any variant of CustomMetadata"
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
    ///     (IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
    ///     (IReadOnlyList&lt;JsonElement&gt; value) =&gt; {...},
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<IReadOnlyDictionary<string, JsonElement>, T> jsonElements,
        System::Func<IReadOnlyList<JsonElement>, T> jsonElements1,
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            IReadOnlyDictionary<string, JsonElement> value => jsonElements(value),
            IReadOnlyList<JsonElement> value => jsonElements1(value),
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new LlamaCloudInvalidDataException(
                "Data did not match any variant of CustomMetadata"
            ),
        };
    }

    public static implicit operator CustomMetadata(Dictionary<string, JsonElement> value) =>
        new((IReadOnlyDictionary<string, JsonElement>)value);

    public static implicit operator CustomMetadata(List<JsonElement> value) =>
        new((IReadOnlyList<JsonElement>)value);

    public static implicit operator CustomMetadata(string value) => new(value);

    public static implicit operator CustomMetadata(double value) => new(value);

    public static implicit operator CustomMetadata(bool value) => new(value);

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
                "Data did not match any variant of CustomMetadata"
            );
        }
    }

    public virtual bool Equals(CustomMetadata? other) =>
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
            IReadOnlyDictionary<string, JsonElement> _ => 0,
            IReadOnlyList<JsonElement> _ => 1,
            string _ => 2,
            double _ => 3,
            bool _ => 4,
            _ => -1,
        };
    }
}

sealed class CustomMetadataConverter : JsonConverter<CustomMetadata?>
{
    public override CustomMetadata? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                element,
                options
            );
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
            var deserialized = JsonSerializer.Deserialize<List<JsonElement>>(element, options);
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

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        CustomMetadata? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// The status of the data source in the pipeline.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Cancelled,
    Error,
    InProgress,
    NotStarted,
    Success,
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
            "ERROR" => Status.Error,
            "IN_PROGRESS" => Status.InProgress,
            "NOT_STARTED" => Status.NotStarted,
            "SUCCESS" => Status.Success,
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
                Status.Error => "ERROR",
                Status.InProgress => "IN_PROGRESS",
                Status.NotStarted => "NOT_STARTED",
                Status.Success => "SUCCESS",
                _ => throw new LlamaCloudInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
