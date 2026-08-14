using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Core;
using LlamaIndex.LlamaCloud.Exceptions;
using LlamaIndex.LlamaCloud.Services.Beta;

namespace LlamaIndex.LlamaCloud.Models.Beta.Retrieval;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IRetrievalService.Find(RetrievalFindParams, CancellationToken)"/> queries.
/// </summary>
public sealed class RetrievalFindPage(
    IRetrievalServiceWithRawResponse service,
    RetrievalFindParams parameters,
    RetrievalFindPageResponse response
) : IPage<RetrievalFindResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<RetrievalFindResponse> Items
    {
        get { return response.Items; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            return this.Items.Count > 0 && response.NextPageToken != null;
        }
        catch (LlamaCloudInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<RetrievalFindResponse>> IPage<RetrievalFindResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<RetrievalFindPage> Next(CancellationToken cancellationToken = default)
    {
        var nextCursor =
            response.NextPageToken
            ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service
            .Find(parameters with { PageToken = nextCursor }, cancellationToken)
            .ConfigureAwait(false);
        return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this.Items)),
            ModelBase.ToStringSerializerOptions
        );

    public override bool Equals(object? obj)
    {
        if (obj is not RetrievalFindPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
