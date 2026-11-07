using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Extract.Review;

namespace LlamaCloud.Services.Extract;

/// <inheritdoc/>
public sealed class ReviewService : IReviewService
{
    readonly Lazy<IReviewServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IReviewServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IReviewService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ReviewService(this._client.WithOptions(modifier));
    }

    public ReviewService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ReviewServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ExtractReview> Create(
        ReviewCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExtractReview> Create(
        string jobID,
        ReviewCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExtractReview> Approve(
        ReviewApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Approve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExtractReview> Approve(
        string jobID,
        ReviewApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Approve(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExtractReview> ChangeFields(
        ReviewChangeFieldsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ChangeFields(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExtractReview> ChangeFields(
        string jobID,
        ReviewChangeFieldsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ChangeFields(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExtractReview> Get(
        ReviewGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExtractReview> Get(
        string jobID,
        ReviewGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ReviewListEventsPage> ListEvents(
        ReviewListEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListEvents(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ReviewListEventsPage> ListEvents(
        string jobID,
        ReviewListEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListEvents(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExtractReview> Reject(
        ReviewRejectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Reject(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExtractReview> Reject(
        string jobID,
        ReviewRejectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Reject(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExtractReview> Reopen(
        ReviewReopenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Reopen(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExtractReview> Reopen(
        string jobID,
        ReviewReopenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Reopen(parameters with { JobID = jobID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ReviewServiceWithRawResponse : IReviewServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IReviewServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ReviewServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ReviewServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExtractReview>> Create(
        ReviewCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<ReviewCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var extractReview = await response
                    .Deserialize<ExtractReview>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    extractReview.Validate();
                }
                return extractReview;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ExtractReview>> Create(
        string jobID,
        ReviewCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Create(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExtractReview>> Approve(
        ReviewApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<ReviewApproveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var extractReview = await response
                    .Deserialize<ExtractReview>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    extractReview.Validate();
                }
                return extractReview;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ExtractReview>> Approve(
        string jobID,
        ReviewApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Approve(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExtractReview>> ChangeFields(
        ReviewChangeFieldsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<ReviewChangeFieldsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var extractReview = await response
                    .Deserialize<ExtractReview>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    extractReview.Validate();
                }
                return extractReview;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ExtractReview>> ChangeFields(
        string jobID,
        ReviewChangeFieldsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.ChangeFields(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExtractReview>> Get(
        ReviewGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<ReviewGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var extractReview = await response
                    .Deserialize<ExtractReview>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    extractReview.Validate();
                }
                return extractReview;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ExtractReview>> Get(
        string jobID,
        ReviewGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReviewListEventsPage>> ListEvents(
        ReviewListEventsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<ReviewListEventsParams> request = new()
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
                    .Deserialize<ReviewListEventsPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ReviewListEventsPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ReviewListEventsPage>> ListEvents(
        string jobID,
        ReviewListEventsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListEvents(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExtractReview>> Reject(
        ReviewRejectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<ReviewRejectParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var extractReview = await response
                    .Deserialize<ExtractReview>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    extractReview.Validate();
                }
                return extractReview;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ExtractReview>> Reject(
        string jobID,
        ReviewRejectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Reject(parameters with { JobID = jobID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExtractReview>> Reopen(
        ReviewReopenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.JobID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.JobID' cannot be null");
        }

        HttpRequest<ReviewReopenParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var extractReview = await response
                    .Deserialize<ExtractReview>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    extractReview.Validate();
                }
                return extractReview;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ExtractReview>> Reopen(
        string jobID,
        ReviewReopenParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Reopen(parameters with { JobID = jobID }, cancellationToken);
    }
}
