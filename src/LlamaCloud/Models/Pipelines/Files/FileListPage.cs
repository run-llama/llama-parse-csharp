using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LlamaCloud.Core;
using LlamaCloud.Exceptions;
using LlamaCloud.Services.Pipelines;

namespace LlamaCloud.Models.Pipelines.Files;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IFileService.List(FileListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class FileListPage(
    IFileServiceWithRawResponse service,
    FileListParams parameters,
    FileListPageResponse response
) : IPage<PipelineFile>
{
    /// <inheritdoc/>
    public IReadOnlyList<PipelineFile> Items
    {
        get { return response.Files; }
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
    async Task<IPage<PipelineFile>> IPage<PipelineFile>.Next(CancellationToken cancellationToken) =>
        await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<FileListPage> Next(CancellationToken cancellationToken = default)
    {
        var currentOffset = parameters.Offset ?? 0;
        using var nextResponse = await service
            .List(parameters with { Offset = currentOffset + this.Items.Count }, cancellationToken)
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
        if (obj is not FileListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
