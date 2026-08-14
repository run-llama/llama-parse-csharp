using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Models.JobDataPoints;

namespace LlamaIndex.LlamaCloud.Services;

/// <inheritdoc/>
public sealed class JobDataPointService : IJobDataPointService
{
    readonly Lazy<IJobDataPointServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IJobDataPointServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IJobDataPointService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new JobDataPointService(this._client.WithOptions(modifier));
    }

    public JobDataPointService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new JobDataPointServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<JobDataPointListPage> List(
        JobDataPointListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class JobDataPointServiceWithRawResponse : IJobDataPointServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IJobDataPointServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new JobDataPointServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public JobDataPointServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JobDataPointListPage>> List(
        JobDataPointListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<JobDataPointListParams> request = new()
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
                    .Deserialize<JobDataPointListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new JobDataPointListPage(this, parameters, page);
            }
        );
    }
}
