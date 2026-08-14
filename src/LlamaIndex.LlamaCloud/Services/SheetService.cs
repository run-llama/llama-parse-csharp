using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Models.Files;
using LlamaIndex.LlamaCloud.Models.Sheets;
using Sheets = LlamaIndex.LlamaCloud.Models.Beta.Sheets;

namespace LlamaIndex.LlamaCloud.Services;

/// <inheritdoc/>
public sealed class SheetService : ISheetService
{
    readonly Lazy<ISheetServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISheetServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public ISheetService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SheetService(this._client.WithOptions(modifier));
    }

    public SheetService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SheetServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Sheets::SheetsJob> Create(
        SheetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SheetListPage> List(
        SheetListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> DeleteJob(
        SheetDeleteJobParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.DeleteJob(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JsonElement> DeleteJob(
        string spreadsheetJobID,
        SheetDeleteJobParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DeleteJob(
            parameters with
            {
                SpreadsheetJobID = spreadsheetJobID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<Sheets::SheetsJob> Get(
        SheetGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Sheets::SheetsJob> Get(
        string spreadsheetJobID,
        SheetGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { SpreadsheetJobID = spreadsheetJobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PresignedUrl> GetResultTable(
        SheetGetResultTableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetResultTable(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PresignedUrl> GetResultTable(
        ApiEnum<string, RegionType> regionType,
        SheetGetResultTableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetResultTable(parameters with { RegionType = regionType }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SheetServiceWithRawResponse : ISheetServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISheetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SheetServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SheetServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Sheets::SheetsJob>> Create(
        SheetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SheetCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var sheetsJob = await response
                    .Deserialize<Sheets::SheetsJob>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    sheetsJob.Validate();
                }
                return sheetsJob;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SheetListPage>> List(
        SheetListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SheetListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<SheetListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SheetListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> DeleteJob(
        SheetDeleteJobParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SpreadsheetJobID == null)
        {
            throw new LlamaCloudInvalidDataException(
                "'parameters.SpreadsheetJobID' cannot be null"
            );
        }

        HttpRequest<SheetDeleteJobParams> request = new()
        {
            Method = HttpMethod.Delete,
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
    public Task<HttpResponse<JsonElement>> DeleteJob(
        string spreadsheetJobID,
        SheetDeleteJobParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DeleteJob(
            parameters with
            {
                SpreadsheetJobID = spreadsheetJobID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Sheets::SheetsJob>> Get(
        SheetGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SpreadsheetJobID == null)
        {
            throw new LlamaCloudInvalidDataException(
                "'parameters.SpreadsheetJobID' cannot be null"
            );
        }

        HttpRequest<SheetGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var sheetsJob = await response
                    .Deserialize<Sheets::SheetsJob>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    sheetsJob.Validate();
                }
                return sheetsJob;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Sheets::SheetsJob>> Get(
        string spreadsheetJobID,
        SheetGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { SpreadsheetJobID = spreadsheetJobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PresignedUrl>> GetResultTable(
        SheetGetResultTableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RegionType == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.RegionType' cannot be null");
        }

        HttpRequest<SheetGetResultTableParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var presignedUrl = await response
                    .Deserialize<PresignedUrl>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    presignedUrl.Validate();
                }
                return presignedUrl;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PresignedUrl>> GetResultTable(
        ApiEnum<string, RegionType> regionType,
        SheetGetResultTableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.GetResultTable(parameters with { RegionType = regionType }, cancellationToken);
    }
}
