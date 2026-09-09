using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Services;

namespace LlamaCloud;

/// <inheritdoc/>
public sealed class LlamaCloudClient : ILlamaCloudClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    readonly Lazy<ILlamaCloudClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ILlamaCloudClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public ILlamaCloudClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LlamaCloudClient(modifier(this._options));
    }

    readonly Lazy<IFileService> _files;
    public IFileService Files
    {
        get { return _files.Value; }
    }

    readonly Lazy<ISheetService> _sheets;
    public ISheetService Sheets
    {
        get { return _sheets.Value; }
    }

    readonly Lazy<ISplitService> _split;
    public ISplitService Split
    {
        get { return _split.Value; }
    }

    readonly Lazy<IParsingService> _parsing;
    public IParsingService Parsing
    {
        get { return _parsing.Value; }
    }

    readonly Lazy<IExtractService> _extract;
    public IExtractService Extract
    {
        get { return _extract.Value; }
    }

    readonly Lazy<IClassifierService> _classifier;
    public IClassifierService Classifier
    {
        get { return _classifier.Value; }
    }

    readonly Lazy<IBatchService> _batches;
    public IBatchService Batches
    {
        get { return _batches.Value; }
    }

    readonly Lazy<IClassifyService> _classify;
    public IClassifyService Classify
    {
        get { return _classify.Value; }
    }

    readonly Lazy<IConfigurationService> _configurations;
    public IConfigurationService Configurations
    {
        get { return _configurations.Value; }
    }

    readonly Lazy<IWebhookConfigService> _webhookConfigs;
    public IWebhookConfigService WebhookConfigs
    {
        get { return _webhookConfigs.Value; }
    }

    readonly Lazy<IProjectService> _projects;
    public IProjectService Projects
    {
        get { return _projects.Value; }
    }

    readonly Lazy<IV2ProjectService> _v2Projects;
    public IV2ProjectService V2Projects
    {
        get { return _v2Projects.Value; }
    }

    readonly Lazy<IJobDataPointService> _jobDataPoints;
    public IJobDataPointService JobDataPoints
    {
        get { return _jobDataPoints.Value; }
    }

    readonly Lazy<IDataSinkService> _dataSinks;
    public IDataSinkService DataSinks
    {
        get { return _dataSinks.Value; }
    }

    readonly Lazy<IDataSourceService> _dataSources;
    public IDataSourceService DataSources
    {
        get { return _dataSources.Value; }
    }

    readonly Lazy<IPipelineService> _pipelines;
    public IPipelineService Pipelines
    {
        get { return _pipelines.Value; }
    }

    readonly Lazy<IRetrieverService> _retrievers;
    public IRetrieverService Retrievers
    {
        get { return _retrievers.Value; }
    }

    readonly Lazy<IBetaService> _beta;
    public IBetaService Beta
    {
        get { return _beta.Value; }
    }

    public void Dispose() => this.HttpClient.Dispose();

    public LlamaCloudClient()
    {
        _options = new();

        _withRawResponse = new(() => new LlamaCloudClientWithRawResponse(this._options));
        _files = new(() => new FileService(this));
        _sheets = new(() => new SheetService(this));
        _split = new(() => new SplitService(this));
        _parsing = new(() => new ParsingService(this));
        _extract = new(() => new ExtractService(this));
        _classifier = new(() => new ClassifierService(this));
        _batches = new(() => new BatchService(this));
        _classify = new(() => new ClassifyService(this));
        _configurations = new(() => new ConfigurationService(this));
        _webhookConfigs = new(() => new WebhookConfigService(this));
        _projects = new(() => new ProjectService(this));
        _v2Projects = new(() => new V2ProjectService(this));
        _jobDataPoints = new(() => new JobDataPointService(this));
        _dataSinks = new(() => new DataSinkService(this));
        _dataSources = new(() => new DataSourceService(this));
        _pipelines = new(() => new PipelineService(this));
        _retrievers = new(() => new RetrieverService(this));
        _beta = new(() => new BetaService(this));
    }

    public LlamaCloudClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class LlamaCloudClientWithRawResponse : ILlamaCloudClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    internal static HttpMethod PatchMethod = new("PATCH");

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public ILlamaCloudClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new LlamaCloudClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<IFileServiceWithRawResponse> _files;
    public IFileServiceWithRawResponse Files
    {
        get { return _files.Value; }
    }

    readonly Lazy<ISheetServiceWithRawResponse> _sheets;
    public ISheetServiceWithRawResponse Sheets
    {
        get { return _sheets.Value; }
    }

    readonly Lazy<ISplitServiceWithRawResponse> _split;
    public ISplitServiceWithRawResponse Split
    {
        get { return _split.Value; }
    }

    readonly Lazy<IParsingServiceWithRawResponse> _parsing;
    public IParsingServiceWithRawResponse Parsing
    {
        get { return _parsing.Value; }
    }

    readonly Lazy<IExtractServiceWithRawResponse> _extract;
    public IExtractServiceWithRawResponse Extract
    {
        get { return _extract.Value; }
    }

    readonly Lazy<IClassifierServiceWithRawResponse> _classifier;
    public IClassifierServiceWithRawResponse Classifier
    {
        get { return _classifier.Value; }
    }

    readonly Lazy<IBatchServiceWithRawResponse> _batches;
    public IBatchServiceWithRawResponse Batches
    {
        get { return _batches.Value; }
    }

    readonly Lazy<IClassifyServiceWithRawResponse> _classify;
    public IClassifyServiceWithRawResponse Classify
    {
        get { return _classify.Value; }
    }

    readonly Lazy<IConfigurationServiceWithRawResponse> _configurations;
    public IConfigurationServiceWithRawResponse Configurations
    {
        get { return _configurations.Value; }
    }

    readonly Lazy<IWebhookConfigServiceWithRawResponse> _webhookConfigs;
    public IWebhookConfigServiceWithRawResponse WebhookConfigs
    {
        get { return _webhookConfigs.Value; }
    }

    readonly Lazy<IProjectServiceWithRawResponse> _projects;
    public IProjectServiceWithRawResponse Projects
    {
        get { return _projects.Value; }
    }

    readonly Lazy<IV2ProjectServiceWithRawResponse> _v2Projects;
    public IV2ProjectServiceWithRawResponse V2Projects
    {
        get { return _v2Projects.Value; }
    }

    readonly Lazy<IJobDataPointServiceWithRawResponse> _jobDataPoints;
    public IJobDataPointServiceWithRawResponse JobDataPoints
    {
        get { return _jobDataPoints.Value; }
    }

    readonly Lazy<IDataSinkServiceWithRawResponse> _dataSinks;
    public IDataSinkServiceWithRawResponse DataSinks
    {
        get { return _dataSinks.Value; }
    }

    readonly Lazy<IDataSourceServiceWithRawResponse> _dataSources;
    public IDataSourceServiceWithRawResponse DataSources
    {
        get { return _dataSources.Value; }
    }

    readonly Lazy<IPipelineServiceWithRawResponse> _pipelines;
    public IPipelineServiceWithRawResponse Pipelines
    {
        get { return _pipelines.Value; }
    }

    readonly Lazy<IRetrieverServiceWithRawResponse> _retrievers;
    public IRetrieverServiceWithRawResponse Retrievers
    {
        get { return _retrievers.Value; }
    }

    readonly Lazy<IBetaServiceWithRawResponse> _beta;
    public IBetaServiceWithRawResponse Beta
    {
        get { return _beta.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, retries, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw LlamaCloudExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new LlamaCloudIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new LlamaCloudIOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (
            apiBackoff != null
            && apiBackoff > TimeSpan.Zero
            && apiBackoff < TimeSpan.FromMinutes(1)
        )
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is LlamaCloudIOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public LlamaCloudClientWithRawResponse()
    {
        _options = new();

        _files = new(() => new FileServiceWithRawResponse(this));
        _sheets = new(() => new SheetServiceWithRawResponse(this));
        _split = new(() => new SplitServiceWithRawResponse(this));
        _parsing = new(() => new ParsingServiceWithRawResponse(this));
        _extract = new(() => new ExtractServiceWithRawResponse(this));
        _classifier = new(() => new ClassifierServiceWithRawResponse(this));
        _batches = new(() => new BatchServiceWithRawResponse(this));
        _classify = new(() => new ClassifyServiceWithRawResponse(this));
        _configurations = new(() => new ConfigurationServiceWithRawResponse(this));
        _webhookConfigs = new(() => new WebhookConfigServiceWithRawResponse(this));
        _projects = new(() => new ProjectServiceWithRawResponse(this));
        _v2Projects = new(() => new V2ProjectServiceWithRawResponse(this));
        _jobDataPoints = new(() => new JobDataPointServiceWithRawResponse(this));
        _dataSinks = new(() => new DataSinkServiceWithRawResponse(this));
        _dataSources = new(() => new DataSourceServiceWithRawResponse(this));
        _pipelines = new(() => new PipelineServiceWithRawResponse(this));
        _retrievers = new(() => new RetrieverServiceWithRawResponse(this));
        _beta = new(() => new BetaServiceWithRawResponse(this));
    }

    public LlamaCloudClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
