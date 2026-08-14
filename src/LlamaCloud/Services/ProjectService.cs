using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Models.Projects;

namespace LlamaCloud.Services;

/// <inheritdoc/>
public sealed class ProjectService : IProjectService
{
    readonly Lazy<IProjectServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProjectServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IProjectService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProjectService(this._client.WithOptions(modifier));
    }

    public ProjectService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ProjectServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<Project>> List(
        ProjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Project> Get(
        ProjectGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Project> Get(
        string projectID,
        ProjectGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ProjectID = projectID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ProjectServiceWithRawResponse : IProjectServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProjectServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ProjectServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProjectServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<Project>>> List(
        ProjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ProjectListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var projects = await response
                    .Deserialize<List<Project>>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    foreach (var item in projects)
                    {
                        item.Validate();
                    }
                }
                return projects;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Project>> Get(
        ProjectGetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProjectID == null)
        {
            throw new LlamaCloudInvalidDataException("'parameters.ProjectID' cannot be null");
        }

        HttpRequest<ProjectGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var project = await response.Deserialize<Project>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    project.Validate();
                }
                return project;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Project>> Get(
        string projectID,
        ProjectGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Get(parameters with { ProjectID = projectID }, cancellationToken);
    }
}
