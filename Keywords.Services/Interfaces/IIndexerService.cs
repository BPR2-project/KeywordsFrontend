using Keywords.API.Client.Generated;

namespace Keywords.Services.Interfaces;

public interface IIndexerService
{
    Task<RequestVideoIndexResponse> IndexVideoAsync(string url, string name, string description);
    Task<ICollection<Video>> GetOcrListAsync(string videoId);
}