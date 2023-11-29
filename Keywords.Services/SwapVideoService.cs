using Keywords.Services.Interfaces;
using SwapVideos.API.Client.Generated;

namespace Keywords.Services;

public class SwapVideoService: ISwapVideoService
{
    private readonly IVideoClient _videoClient;

    public SwapVideoService(IVideoClient videoClient)
    {
        _videoClient = videoClient;
    }

    public async Task<Video> GetVideoAsync(Guid videoId)
    {
        return await _videoClient.GetVideoAsync(videoId);
    }
    
    public async Task<PaginatedVideosResponse> GetVideoAsync(int? page, int size)
    {
        var paginatedVideosRequest = new PaginatedVideosRequest()
        {
            Page = page,
            Size = size
        };
        return await _videoClient.GetAllVideosAsync(paginatedVideosRequest);
    }

    public async Task<Video> TagVideoAsIndexedAsync(Guid videoId, bool isIndexed)
    {
        return await _videoClient.TagVideoAsIndexedAsync(videoId, isIndexed);
    }
}