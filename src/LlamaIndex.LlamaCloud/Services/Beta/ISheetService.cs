using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Beta.Sheets;
using LlamaIndex.LlamaCloud.Models.Files;

namespace LlamaIndex.LlamaCloud.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISheetService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISheetServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISheetService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a spreadsheet parsing job.
    ///
    /// <para>Provide at most one of `configuration` (an inline parsing configuration)
    /// or `configuration_id` (a saved configuration preset). If neither is provided, a
    /// default configuration is used. Optionally include `webhook_configurations` to
    /// receive `sheets.*` status notifications.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<SheetsJob> Create(
        SheetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List spreadsheet parsing jobs.
    /// </summary>
    [Obsolete("deprecated")]
    Task<SheetListPage> List(
        SheetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a spreadsheet parsing job and its associated data.
    /// </summary>
    [Obsolete("deprecated")]
    Task<JsonElement> DeleteJob(
        SheetDeleteJobParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteJob(SheetDeleteJobParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<JsonElement> DeleteJob(
        string spreadsheetJobID,
        SheetDeleteJobParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a spreadsheet parsing job. When `include_results=True` (default), embeds
    /// extracted regions and results if complete, skipping the separate `/results`
    /// call.
    /// </summary>
    [Obsolete("deprecated")]
    Task<SheetsJob> Get(SheetGetParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Get(SheetGetParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<SheetsJob> Get(
        string spreadsheetJobID,
        SheetGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generate a presigned URL to download a specific extracted region.
    /// </summary>
    [Obsolete("deprecated")]
    Task<PresignedUrl> GetResultTable(
        SheetGetResultTableParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetResultTable(SheetGetResultTableParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<PresignedUrl> GetResultTable(
        ApiEnum<string, RegionType> regionType,
        SheetGetResultTableParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISheetService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISheetServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISheetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/beta/sheets/jobs</c>, but is otherwise the
    /// same as <see cref="ISheetService.Create(SheetCreateParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<SheetsJob>> Create(
        SheetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/sheets/jobs</c>, but is otherwise the
    /// same as <see cref="ISheetService.List(SheetListParams?, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<SheetListPage>> List(
        SheetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/beta/sheets/jobs/{spreadsheet_job_id}</c>, but is otherwise the
    /// same as <see cref="ISheetService.DeleteJob(SheetDeleteJobParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<JsonElement>> DeleteJob(
        SheetDeleteJobParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteJob(SheetDeleteJobParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<JsonElement>> DeleteJob(
        string spreadsheetJobID,
        SheetDeleteJobParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/sheets/jobs/{spreadsheet_job_id}</c>, but is otherwise the
    /// same as <see cref="ISheetService.Get(SheetGetParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<SheetsJob>> Get(
        SheetGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(SheetGetParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<SheetsJob>> Get(
        string spreadsheetJobID,
        SheetGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/beta/sheets/jobs/{spreadsheet_job_id}/regions/{region_id}/result/{region_type}</c>, but is otherwise the
    /// same as <see cref="ISheetService.GetResultTable(SheetGetResultTableParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<PresignedUrl>> GetResultTable(
        SheetGetResultTableParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetResultTable(SheetGetResultTableParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<PresignedUrl>> GetResultTable(
        ApiEnum<string, RegionType> regionType,
        SheetGetResultTableParams parameters,
        CancellationToken cancellationToken = default
    );
}
