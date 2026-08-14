using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Configurations;
using LlamaIndex.LlamaCloud.Models.Extract;

namespace LlamaIndex.LlamaCloud.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IExtractService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExtractServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExtractService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create an extraction job.
    ///
    /// <para>Extracts structured data from a document using either a saved
    /// configuration or an inline JSON Schema.</para>
    ///
    /// <para>## Input</para>
    ///
    /// <para>Provide exactly one of: - `configuration_id` — reference a saved
    /// extraction config - `configuration` — inline configuration with a `data_schema`</para>
    ///
    /// <para>## Document input</para>
    ///
    /// <para>Set `file_input` to a file ID (`dfl-...`) or a completed parse job ID
    /// (`pjb-...`).</para>
    ///
    /// <para>The job runs asynchronously. Poll `GET /extract/{job_id}` or register a
    /// webhook to monitor completion.</para>
    /// </summary>
    Task<ExtractV2Job> Create(
        ExtractCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List extraction jobs with optional filtering and pagination.
    ///
    /// <para>Filter by `configuration_id`, `status`, `file_input`, or creation date
    /// range. Results are returned newest-first. Use `expand=configuration` to include
    /// the full configuration used, and `expand=extract_metadata` for per-field
    /// metadata.</para>
    /// </summary>
    Task<ExtractListPage> List(
        ExtractListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an extraction job and its results.
    /// </summary>
    Task<JsonElement> Delete(
        ExtractDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ExtractDeleteParams, CancellationToken)"/>
    Task<JsonElement> Delete(
        string jobID,
        ExtractDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a running extraction job.
    ///
    /// <para>Stops processing and marks the job as CANCELLED. Returns the updated job.
    /// Jobs already in a terminal state (COMPLETED, FAILED, CANCELLED) cannot be
    /// cancelled.</para>
    /// </summary>
    Task<ExtractV2Job> Cancel(
        ExtractCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(ExtractCancelParams, CancellationToken)"/>
    Task<ExtractV2Job> Cancel(
        string jobID,
        ExtractCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Generate a JSON schema and return a product configuration request.
    /// </summary>
    Task<ConfigurationCreate> GenerateSchema(
        ExtractGenerateSchemaParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a single extraction job by ID.
    ///
    /// <para>Returns the job status and results when complete. Use
    /// `expand=configuration` to include the full configuration used,
    /// `expand=extract_metadata` for per-field metadata, and `expand=usage` for credits
    /// billed against the job.</para>
    /// </summary>
    Task<ExtractV2Job> Get(
        ExtractGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(ExtractGetParams, CancellationToken)"/>
    Task<ExtractV2Job> Get(
        string jobID,
        ExtractGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Validate a JSON schema for extraction.
    /// </summary>
    Task<ExtractV2SchemaValidateResponse> ValidateSchema(
        ExtractValidateSchemaParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExtractService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExtractServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExtractServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v2/extract</c>, but is otherwise the
    /// same as <see cref="IExtractService.Create(ExtractCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExtractV2Job>> Create(
        ExtractCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v2/extract</c>, but is otherwise the
    /// same as <see cref="IExtractService.List(ExtractListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExtractListPage>> List(
        ExtractListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /api/v2/extract/{job_id}</c>, but is otherwise the
    /// same as <see cref="IExtractService.Delete(ExtractDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JsonElement>> Delete(
        ExtractDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ExtractDeleteParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> Delete(
        string jobID,
        ExtractDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v2/extract/{job_id}/cancel</c>, but is otherwise the
    /// same as <see cref="IExtractService.Cancel(ExtractCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExtractV2Job>> Cancel(
        ExtractCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(ExtractCancelParams, CancellationToken)"/>
    Task<HttpResponse<ExtractV2Job>> Cancel(
        string jobID,
        ExtractCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v2/extract/schema/generate</c>, but is otherwise the
    /// same as <see cref="IExtractService.GenerateSchema(ExtractGenerateSchemaParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ConfigurationCreate>> GenerateSchema(
        ExtractGenerateSchemaParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v2/extract/{job_id}</c>, but is otherwise the
    /// same as <see cref="IExtractService.Get(ExtractGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExtractV2Job>> Get(
        ExtractGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(ExtractGetParams, CancellationToken)"/>
    Task<HttpResponse<ExtractV2Job>> Get(
        string jobID,
        ExtractGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v2/extract/schema/validation</c>, but is otherwise the
    /// same as <see cref="IExtractService.ValidateSchema(ExtractValidateSchemaParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExtractV2SchemaValidateResponse>> ValidateSchema(
        ExtractValidateSchemaParams parameters,
        CancellationToken cancellationToken = default
    );
}
