using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Files;
using LlamaIndex.LlamaCloud.Models.Sheets;
using Sheets = LlamaIndex.LlamaCloud.Models.Beta.Sheets;

namespace LlamaIndex.LlamaCloud.Services;

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
    Task<Sheets::SheetsJob> Create(
        SheetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List spreadsheet parsing jobs.
    /// </summary>
    Task<SheetListPage> List(
        SheetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a spreadsheet parsing job and its associated data.
    /// </summary>
    Task<JsonElement> DeleteJob(
        SheetDeleteJobParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteJob(SheetDeleteJobParams, CancellationToken)"/>
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
    Task<Sheets::SheetsJob> Get(
        SheetGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(SheetGetParams, CancellationToken)"/>
    Task<Sheets::SheetsJob> Get(
        string spreadsheetJobID,
        SheetGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generate a presigned URL to download a specific extracted region.
    /// </summary>
    Task<PresignedUrl> GetResultTable(
        SheetGetResultTableParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetResultTable(SheetGetResultTableParams, CancellationToken)"/>
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
    /// Returns a raw HTTP response for <c>post /api/v1/sheets/jobs</c>, but is otherwise the
    /// same as <see cref="ISheetService.Create(SheetCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Sheets::SheetsJob>> Create(
        SheetCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/sheets/jobs</c>, but is otherwise the
    /// same as <see cref="ISheetService.List(SheetListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SheetListPage>> List(
        SheetListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v1/sheets/jobs/{spreadsheet_job_id}</c>, but is otherwise the
    /// same as <see cref="ISheetService.DeleteJob(SheetDeleteJobParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JsonElement>> DeleteJob(
        SheetDeleteJobParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="DeleteJob(SheetDeleteJobParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> DeleteJob(
        string spreadsheetJobID,
        SheetDeleteJobParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/sheets/jobs/{spreadsheet_job_id}</c>, but is otherwise the
    /// same as <see cref="ISheetService.Get(SheetGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Sheets::SheetsJob>> Get(
        SheetGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(SheetGetParams, CancellationToken)"/>
    Task<HttpResponse<Sheets::SheetsJob>> Get(
        string spreadsheetJobID,
        SheetGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/sheets/jobs/{spreadsheet_job_id}/regions/{region_id}/result/{region_type}</c>, but is otherwise the
    /// same as <see cref="ISheetService.GetResultTable(SheetGetResultTableParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PresignedUrl>> GetResultTable(
        SheetGetResultTableParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetResultTable(SheetGetResultTableParams, CancellationToken)"/>
    Task<HttpResponse<PresignedUrl>> GetResultTable(
        ApiEnum<string, RegionType> regionType,
        SheetGetResultTableParams parameters,
        CancellationToken cancellationToken = default
    );
}
