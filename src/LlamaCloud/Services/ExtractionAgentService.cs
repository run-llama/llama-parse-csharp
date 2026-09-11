using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Models.ExtractionAgents;

namespace LlamaCloud.Services;

/// <inheritdoc/>
public sealed class ExtractionAgentService : IExtractionAgentService
{
    readonly Lazy<IExtractionAgentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExtractionAgentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IExtractionAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExtractionAgentService(this._client.WithOptions(modifier));
    }

    public ExtractionAgentService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ExtractionAgentServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<ExtractionAgentListPage> List(
        ExtractionAgentListParams? parameters = null,
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
public sealed class ExtractionAgentServiceWithRawResponse : IExtractionAgentServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExtractionAgentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ExtractionAgentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExtractionAgentServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExtractionAgentListPage>> List(
        ExtractionAgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ExtractionAgentListParams> request = new()
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
                    .Deserialize<ExtractionAgentListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ExtractionAgentListPage(this, parameters, page);
            }
        );
    }
}
