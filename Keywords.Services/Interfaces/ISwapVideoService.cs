using SwapVideos.API.Client.Generated;

namespace Keywords.Services.Interfaces;

public interface ISwapVideoService
{
    Task<Video> GetVideoAsync(Guid videoId);
    Task<PaginatedVideosResponse> GetVideoAsync(int? page, int size);
}