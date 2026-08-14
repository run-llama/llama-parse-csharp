using System;
using LlamaIndex.LlamaCloud.Core;
using Beta = LlamaIndex.LlamaCloud.Services.Beta;

namespace LlamaIndex.LlamaCloud.Services;

/// <inheritdoc/>
public sealed class BetaService : IBetaService
{
    readonly Lazy<IBetaServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBetaServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ILlamaCloudClient _client;

    /// <inheritdoc/>
    public IBetaService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BetaService(this._client.WithOptions(modifier));
    }

    public BetaService(ILlamaCloudClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BetaServiceWithRawResponse(client.WithRawResponse));
        _indexes = new(() => new Beta::IndexService(client));
        _retrieval = new(() => new Beta::RetrievalService(client));
        _chat = new(() => new Beta::ChatService(client));
        _agentData = new(() => new Beta::AgentDataService(client));
        _sheets = new(() => new Beta::SheetService(client));
        _directories = new(() => new Beta::DirectoryService(client));
        _split = new(() => new Beta::SplitService(client));
    }

    readonly Lazy<Beta::IIndexService> _indexes;
    public Beta::IIndexService Indexes
    {
        get { return _indexes.Value; }
    }

    readonly Lazy<Beta::IRetrievalService> _retrieval;
    public Beta::IRetrievalService Retrieval
    {
        get { return _retrieval.Value; }
    }

    readonly Lazy<Beta::IChatService> _chat;
    public Beta::IChatService Chat
    {
        get { return _chat.Value; }
    }

    readonly Lazy<Beta::IAgentDataService> _agentData;
    public Beta::IAgentDataService AgentData
    {
        get { return _agentData.Value; }
    }

    readonly Lazy<Beta::ISheetService> _sheets;
    public Beta::ISheetService Sheets
    {
        get { return _sheets.Value; }
    }

    readonly Lazy<Beta::IDirectoryService> _directories;
    public Beta::IDirectoryService Directories
    {
        get { return _directories.Value; }
    }

    readonly Lazy<Beta::ISplitService> _split;
    public Beta::ISplitService Split
    {
        get { return _split.Value; }
    }
}

/// <inheritdoc/>
public sealed class BetaServiceWithRawResponse : IBetaServiceWithRawResponse
{
    readonly ILlamaCloudClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBetaServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BetaServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BetaServiceWithRawResponse(ILlamaCloudClientWithRawResponse client)
    {
        _client = client;

        _indexes = new(() => new Beta::IndexServiceWithRawResponse(client));
        _retrieval = new(() => new Beta::RetrievalServiceWithRawResponse(client));
        _chat = new(() => new Beta::ChatServiceWithRawResponse(client));
        _agentData = new(() => new Beta::AgentDataServiceWithRawResponse(client));
        _sheets = new(() => new Beta::SheetServiceWithRawResponse(client));
        _directories = new(() => new Beta::DirectoryServiceWithRawResponse(client));
        _split = new(() => new Beta::SplitServiceWithRawResponse(client));
    }

    readonly Lazy<Beta::IIndexServiceWithRawResponse> _indexes;
    public Beta::IIndexServiceWithRawResponse Indexes
    {
        get { return _indexes.Value; }
    }

    readonly Lazy<Beta::IRetrievalServiceWithRawResponse> _retrieval;
    public Beta::IRetrievalServiceWithRawResponse Retrieval
    {
        get { return _retrieval.Value; }
    }

    readonly Lazy<Beta::IChatServiceWithRawResponse> _chat;
    public Beta::IChatServiceWithRawResponse Chat
    {
        get { return _chat.Value; }
    }

    readonly Lazy<Beta::IAgentDataServiceWithRawResponse> _agentData;
    public Beta::IAgentDataServiceWithRawResponse AgentData
    {
        get { return _agentData.Value; }
    }

    readonly Lazy<Beta::ISheetServiceWithRawResponse> _sheets;
    public Beta::ISheetServiceWithRawResponse Sheets
    {
        get { return _sheets.Value; }
    }

    readonly Lazy<Beta::IDirectoryServiceWithRawResponse> _directories;
    public Beta::IDirectoryServiceWithRawResponse Directories
    {
        get { return _directories.Value; }
    }

    readonly Lazy<Beta::ISplitServiceWithRawResponse> _split;
    public Beta::ISplitServiceWithRawResponse Split
    {
        get { return _split.Value; }
    }
}
