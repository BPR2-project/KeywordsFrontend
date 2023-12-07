using Keywords.API.Client.Generated;
using Keywords.Services.Interfaces;
using SwapVideos.API.Client.Generated;

namespace Keywords.Services;

public class IndexerService : IIndexerService
{
    private readonly IIndexerClient _indexerClient;

    public IndexerService(IIndexerClient indexerClient)
    {
        _indexerClient = indexerClient;
    }

    public async Task IndexVideoAsync(Guid videoId, string url)
    {
        await _indexerClient.IndexVideoAsync(videoId, url);
    }

    public async Task<IndexerProgress> GetIndexerProgressAsync(Guid videoId)
    {
        return await _indexerClient.GetIndexerProgressAsync(videoId);
    }
}