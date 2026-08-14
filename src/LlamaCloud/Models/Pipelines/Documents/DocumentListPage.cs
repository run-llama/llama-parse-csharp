using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Services.Pipelines;

namespace LlamaCloud.Models.Pipelines.Documents;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IDocumentService.List(DocumentListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class DocumentListPage(
    IDocumentServiceWithRawResponse service,
    DocumentListParams parameters,
    DocumentListPageResponse response
) : IPage<CloudDocument>
{
    /// <inheritdoc/>
    public IReadOnlyList<CloudDocument> Items
    {
        get { return response.Documents; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            if (this.Items.Count == 0)
            {
                return false;
            }
            var totalCount = response.TotalCount;

            return this.Items.Count < totalCount;
        }
        catch (LlamaCloudInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<CloudDocument>> IPage<CloudDocument>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<DocumentListPage> Next(CancellationToken cancellationToken = default)
    {
        var currentOffset = parameters.Skip ?? 0;
        using var nextResponse = await service
            .List(parameters with { Skip = currentOffset + this.Items.Count }, cancellationToken)
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
        if (obj is not DocumentListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
