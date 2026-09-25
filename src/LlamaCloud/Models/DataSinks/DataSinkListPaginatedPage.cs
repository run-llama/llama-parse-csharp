using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Services;

namespace LlamaCloud.Models.DataSinks;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IDataSinkService.ListPaginated(DataSinkListPaginatedParams, CancellationToken)"/> queries.
/// </summary>
public sealed class DataSinkListPaginatedPage(
    IDataSinkServiceWithRawResponse service,
    DataSinkListPaginatedParams parameters,
    DataSinkListPaginatedPageResponse response
) : IPage<DataSink>
{
    /// <inheritdoc/>
    public IReadOnlyList<DataSink> Items
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
    async Task<IPage<DataSink>> IPage<DataSink>.Next(CancellationToken cancellationToken) =>
        await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<DataSinkListPaginatedPage> Next(CancellationToken cancellationToken = default)
    {
        var nextCursor =
            response.NextPageToken
            ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service
            .ListPaginated(parameters with { PageToken = nextCursor }, cancellationToken)
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
        if (obj is not DataSinkListPaginatedPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
