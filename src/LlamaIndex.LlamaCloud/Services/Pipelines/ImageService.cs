using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Pipelines.Images;

namespace LlamaIndex.LlamaCloud.Services.Pipelines;

/// <inheritdoc/>
public sealed class ImageService : IImageService
{
    readonly Lazy<IImageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IImageServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IImageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ImageService(this._client.WithOptions(modifier));
    }

    public ImageService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ImageServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<JsonElement> GetPageFigure(
        ImageGetPageFigureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetPageFigure(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JsonElement> GetPageFigure(
        string figureName,
        ImageGetPageFigureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetPageFigure(parameters with { FigureName = figureName }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> GetPageScreenshot(
        ImageGetPageScreenshotParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetPageScreenshot(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JsonElement> GetPageScreenshot(
        long pageIndex,
        ImageGetPageScreenshotParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetPageScreenshot(parameters with { PageIndex = pageIndex }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<ImageListPageFiguresResponse>> ListPageFigures(
        ImageListPageFiguresParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListPageFigures(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<ImageListPageFiguresResponse>> ListPageFigures(
        string id,
        ImageListPageFiguresParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListPageFigures(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<ImageListPageScreenshotsResponse>> ListPageScreenshots(
        ImageListPageScreenshotsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListPageScreenshots(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<ImageListPageScreenshotsResponse>> ListPageScreenshots(
        string id,
        ImageListPageScreenshotsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListPageScreenshots(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ImageServiceWithRawResponse : IImageServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IImageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ImageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ImageServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> GetPageFigure(
        ImageGetPageFigureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FigureName == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.FigureName' cannot be null");
        }

        HttpRequest<ImageGetPageFigureParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> GetPageFigure(
        string figureName,
        ImageGetPageFigureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetPageFigure(parameters with { FigureName = figureName }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> GetPageScreenshot(
        ImageGetPageScreenshotParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PageIndex == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.PageIndex' cannot be null");
        }

        HttpRequest<ImageGetPageScreenshotParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> GetPageScreenshot(
        long pageIndex,
        ImageGetPageScreenshotParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetPageScreenshot(parameters with { PageIndex = pageIndex }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<ImageListPageFiguresResponse>>> ListPageFigures(
        ImageListPageFiguresParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ImageListPageFiguresParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<ImageListPageFiguresResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<ImageListPageFiguresResponse>>> ListPageFigures(
        string id,
        ImageListPageFiguresParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListPageFigures(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<ImageListPageScreenshotsResponse>>> ListPageScreenshots(
        ImageListPageScreenshotsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ImageListPageScreenshotsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<List<ImageListPageScreenshotsResponse>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in deserializedResponse)
                    {
                        item.Validate();
                    }
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<ImageListPageScreenshotsResponse>>> ListPageScreenshots(
        string id,
        ImageListPageScreenshotsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListPageScreenshots(parameters with { ID = id }, cancellationToken);
    }
}
