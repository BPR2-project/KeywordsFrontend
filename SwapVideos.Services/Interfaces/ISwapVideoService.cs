using SwapVideos.API.Client.Generated;

namespace SwapVideos.Services.Interfaces;

public interface ISwapVideoService
{
    Task<Video> GetVideoAsync(Guid videoId);
    Task<IList<Video>> GetVideoAsync(int? page, int size);
    Task<Video> TagVideoAsIndexedAsync(Guid videoId, bool isIndexed);
}