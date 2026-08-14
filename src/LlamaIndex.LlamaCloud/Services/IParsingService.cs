using System;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.Parsing;

namespace LlamaIndex.LlamaCloud.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IParsingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IParsingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IParsingService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Parse a file by file ID or URL.
    ///
    /// <para>Provide either `file_id` (a previously uploaded file) or `source_url` (a
    /// publicly accessible URL). Configure parsing with options like `tier`,
    /// `target_pages`, and `lang`.</para>
    ///
    /// <para>## Tiers</para>
    ///
    /// <para>- `fast` — rule-based, cheapest, no AI - `cost_effective` — balanced speed
    /// and quality - `agentic` — full AI-powered parsing - `agentic_plus` — premium AI
    /// with specialized features</para>
    ///
    /// <para>The job runs asynchronously. Poll `GET /parse/{job_id}` with `expand=text`
    /// or `expand=markdown` to retrieve results.</para>
    /// </summary>
    Task<ParsingCreateResponse> Create(
        ParsingCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List parse jobs for the current project.
    ///
    /// <para>Filter by `status` or creation date range. Results are paginated — use
    /// `page_token` from the response to fetch subsequent pages.</para>
    /// </summary>
    Task<ParsingListPage> List(
        ParsingListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a running parse job.
    ///
    /// <para>Stops processing and marks the job as CANCELLED. Returns the updated job.
    /// Jobs already in a terminal state (COMPLETED, FAILED, CANCELLED) cannot be
    /// cancelled.</para>
    /// </summary>
    Task<ParsingCancelResponse> Cancel(
        ParsingCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(ParsingCancelParams, CancellationToken)"/>
    Task<ParsingCancelResponse> Cancel(
        string jobID,
        ParsingCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a parse job with optional expanded content.
    ///
    /// <para>By default returns job metadata only. Use `expand` to include parsed
    /// content:</para>
    ///
    /// <para>- `text` — plain text output - `markdown` — markdown output - `items` —
    /// structured page-by-page output - `job_metadata` — processing details - `usage` —
    /// credits billed against the job</para>
    ///
    /// <para>Content metadata fields (e.g. `text_content_metadata`) return presigned
    /// URLs for downloading large results.</para>
    /// </summary>
    Task<ParsingGetResponse> Get(
        ParsingGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(ParsingGetParams, CancellationToken)"/>
    Task<ParsingGetResponse> Get(
        string jobID,
        ParsingGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the parse versions accepted by each tier.
    /// </summary>
    Task<ParsingListVersionsResponse> ListVersions(
        ParsingListVersionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IParsingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IParsingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IParsingServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v2/parse</c>, but is otherwise the
    /// same as <see cref="IParsingService.Create(ParsingCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ParsingCreateResponse>> Create(
        ParsingCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v2/parse</c>, but is otherwise the
    /// same as <see cref="IParsingService.List(ParsingListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ParsingListPage>> List(
        ParsingListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v2/parse/{job_id}/cancel</c>, but is otherwise the
    /// same as <see cref="IParsingService.Cancel(ParsingCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ParsingCancelResponse>> Cancel(
        ParsingCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(ParsingCancelParams, CancellationToken)"/>
    Task<HttpResponse<ParsingCancelResponse>> Cancel(
        string jobID,
        ParsingCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v2/parse/{job_id}</c>, but is otherwise the
    /// same as <see cref="IParsingService.Get(ParsingGetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ParsingGetResponse>> Get(
        ParsingGetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Get(ParsingGetParams, CancellationToken)"/>
    Task<HttpResponse<ParsingGetResponse>> Get(
        string jobID,
        ParsingGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v2/parse/versions</c>, but is otherwise the
    /// same as <see cref="IParsingService.ListVersions(ParsingListVersionsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ParsingListVersionsResponse>> ListVersions(
        ParsingListVersionsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
