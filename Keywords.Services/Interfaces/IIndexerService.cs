using Keywords.API.Client.Generated;

namespace Keywords.Services.Interfaces;

public interface IIndexerService
{
    Task IndexVideoAsync(Guid videoId, string url);
    Task<IndexerProgress> GetIndexerProgressAsync(Guid videoId);
}