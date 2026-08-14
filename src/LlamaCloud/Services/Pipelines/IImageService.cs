using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Models.Pipelines.Images;

namespace LlamaCloud.Services.Pipelines;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IImageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IImageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IImageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a specific figure from a page of a file.
    /// </summary>
    Task<JsonElement> GetPageFigure(
        ImageGetPageFigureParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetPageFigure(ImageGetPageFigureParams, CancellationToken)"/>
    Task<JsonElement> GetPageFigure(
        string figureName,
        ImageGetPageFigureParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get screenshot of a page from a file.
    /// </summary>
    Task<JsonElement> GetPageScreenshot(
        ImageGetPageScreenshotParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetPageScreenshot(ImageGetPageScreenshotParams, CancellationToken)"/>
    Task<JsonElement> GetPageScreenshot(
        long pageIndex,
        ImageGetPageScreenshotParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List metadata for all figures from all pages of a file.
    /// </summary>
    Task<List<ImageListPageFiguresResponse>> ListPageFigures(
        ImageListPageFiguresParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPageFigures(ImageListPageFiguresParams, CancellationToken)"/>
    Task<List<ImageListPageFiguresResponse>> ListPageFigures(
        string id,
        ImageListPageFiguresParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List metadata for all screenshots of pages from a file.
    /// </summary>
    Task<List<ImageListPageScreenshotsResponse>> ListPageScreenshots(
        ImageListPageScreenshotsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPageScreenshots(ImageListPageScreenshotsParams, CancellationToken)"/>
    Task<List<ImageListPageScreenshotsResponse>> ListPageScreenshots(
        string id,
        ImageListPageScreenshotsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IImageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IImageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IImageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/files/{id}/page-figures/{page_index}/{figure_name}</c>, but is otherwise the
    /// same as <see cref="IImageService.GetPageFigure(ImageGetPageFigureParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JsonElement>> GetPageFigure(
        ImageGetPageFigureParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetPageFigure(ImageGetPageFigureParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> GetPageFigure(
        string figureName,
        ImageGetPageFigureParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/files/{id}/page_screenshots/{page_index}</c>, but is otherwise the
    /// same as <see cref="IImageService.GetPageScreenshot(ImageGetPageScreenshotParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JsonElement>> GetPageScreenshot(
        ImageGetPageScreenshotParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetPageScreenshot(ImageGetPageScreenshotParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> GetPageScreenshot(
        long pageIndex,
        ImageGetPageScreenshotParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/files/{id}/page-figures</c>, but is otherwise the
    /// same as <see cref="IImageService.ListPageFigures(ImageListPageFiguresParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<ImageListPageFiguresResponse>>> ListPageFigures(
        ImageListPageFiguresParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPageFigures(ImageListPageFiguresParams, CancellationToken)"/>
    Task<HttpResponse<List<ImageListPageFiguresResponse>>> ListPageFigures(
        string id,
        ImageListPageFiguresParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/files/{id}/page_screenshots</c>, but is otherwise the
    /// same as <see cref="IImageService.ListPageScreenshots(ImageListPageScreenshotsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<ImageListPageScreenshotsResponse>>> ListPageScreenshots(
        ImageListPageScreenshotsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListPageScreenshots(ImageListPageScreenshotsParams, CancellationToken)"/>
    Task<HttpResponse<List<ImageListPageScreenshotsResponse>>> ListPageScreenshots(
        string id,
        ImageListPageScreenshotsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
