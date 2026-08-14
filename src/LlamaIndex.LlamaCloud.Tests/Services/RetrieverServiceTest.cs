using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using LlamaIndex.LlamaCloud.Models.Pipelines;

namespace LlamaIndex.LlamaCloud.Tests.Services;

public class RetrieverServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var retriever = await this.client.Retrievers.Create(
            new() { Name = "x" },
            TestContext.Current.CancellationToken
        );
        retriever.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var retriever = await this.client.Retrievers.Update(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new()
            {
                Pipelines =
                [
                    new()
                    {
                        Description = "description",
                        Name = "x",
                        PipelineID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                        PresetRetrievalParameters = new()
                        {
                            Alpha = 0,
                            ClassName = "class_name",
                            DenseSimilarityCutoff = 0,
                            DenseSimilarityTopK = 1,
                            EnableReranking = true,
                            FilesTopK = 1,
                            RerankTopN = 1,
                            RetrievalMode = RetrievalMode.AutoRouted,
                            RetrieveImageNodes = true,
                            RetrievePageFigureNodes = true,
                            RetrievePageScreenshotNodes = true,
                            SearchFilters = new()
                            {
                                Filters =
                                [
                                    new MetadataFilter()
                                    {
                                        Key = "key",
                                        Value = 0,
                                        Operator = Operator.Undefined,
                                    },
                                ],
                                Condition = Condition.And,
                            },
                            SearchFiltersInferenceSchema = new Dictionary<
                                string,
                                PresetRetrievalParamsSearchFiltersInferenceSchema?
                            >()
                            {
                                {
                                    "foo",
                                    new(
                                        new Dictionary<string, JsonElement>()
                                        {
                                            { "foo", JsonSerializer.SerializeToElement("bar") },
                                        }
                                    )
                                },
                            },
                            SparseSimilarityTopK = 1,
                        },
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        retriever.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var retrievers = await this.client.Retrievers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in retrievers)
        {
            item.Validate();
        }
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Retrievers.Delete(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Get_Works()
    {
        var retriever = await this.client.Retrievers.Get(
            "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            new(),
            TestContext.Current.CancellationToken
        );
        retriever.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Search_Works()
    {
        var compositeRetrievalResult = await this.client.Retrievers.Search(
            new() { Query = "x" },
            TestContext.Current.CancellationToken
        );
        compositeRetrievalResult.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Upsert_Works()
    {
        var retriever = await this.client.Retrievers.Upsert(
            new() { Name = "x" },
            TestContext.Current.CancellationToken
        );
        retriever.Validate();
    }
}
