using SwapVideos.API.Client.Generated;

namespace Keywords.Services.Interfaces;

public interface ISwapVideoService
{
    Task<Video> GetVideoAsync(Guid videoId);
    Task<IList<Video>> GetAllVideosAsync(int? page, int size);
    Task<Video> TagVideoAsIndexedAsync(Guid videoId, bool isIndexed);
}