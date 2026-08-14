using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Services;

namespace LlamaIndex.LlamaCloud;

/// <summary>
/// A client for interacting with the Llama Cloud REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ILlamaCloudClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ILlamaCloudClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILlamaCloudClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IFileService Files { get; }

    ISheetService Sheets { get; }

    ISplitService Split { get; }

    IParsingService Parsing { get; }

    IExtractService Extract { get; }

    IClassifierService Classifier { get; }

    IBatchService Batches { get; }

    IClassifyService Classify { get; }

    IConfigurationService Configurations { get; }

    IWebhookConfigService WebhookConfigs { get; }

    IProjectService Projects { get; }

    IV2ProjectService V2Projects { get; }

    IJobDataPointService JobDataPoints { get; }

    IDataSinkService DataSinks { get; }

    IDataSourceService DataSources { get; }

    IPipelineService Pipelines { get; }

    IRetrieverService Retrievers { get; }

    IBetaService Beta { get; }
}

/// <summary>
/// A view of <see cref="ILlamaCloudClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface ILlamaCloudClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ILlamaCloudClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IFileServiceWithRawResponse Files { get; }

    ISheetServiceWithRawResponse Sheets { get; }

    ISplitServiceWithRawResponse Split { get; }

    IParsingServiceWithRawResponse Parsing { get; }

    IExtractServiceWithRawResponse Extract { get; }

    IClassifierServiceWithRawResponse Classifier { get; }

    IBatchServiceWithRawResponse Batches { get; }

    IClassifyServiceWithRawResponse Classify { get; }

    IConfigurationServiceWithRawResponse Configurations { get; }

    IWebhookConfigServiceWithRawResponse WebhookConfigs { get; }

    IProjectServiceWithRawResponse Projects { get; }

    IV2ProjectServiceWithRawResponse V2Projects { get; }

    IJobDataPointServiceWithRawResponse JobDataPoints { get; }

    IDataSinkServiceWithRawResponse DataSinks { get; }

    IDataSourceServiceWithRawResponse DataSources { get; }

    IPipelineServiceWithRawResponse Pipelines { get; }

    IRetrieverServiceWithRawResponse Retrievers { get; }

    IBetaServiceWithRawResponse Beta { get; }

    /// <summary>
    /// Sends a request to the Llama Cloud REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
