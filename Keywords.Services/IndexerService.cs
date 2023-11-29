using Keywords.API.Client.Generated;
using Keywords.Services.Interfaces;

namespace Keywords.Services;

public class IndexerService : IIndexerService
{
    private readonly IIndexerClient _indexerClient;

    public IndexerService(IIndexerClient indexerClient)
    {
        _indexerClient = indexerClient;
    }

    public async Task<RequestVideoIndexResponse> IndexVideoAsync(string url, string name, string description)
    {
        return await _indexerClient.IndexVideoAsync(url, name, description);
    }

    public async Task<ICollection<Video>> GetOcrListAsync(string videoId)
    {
        return await _indexerClient.GetOcrListAsync(videoId);
    }
    
    
}