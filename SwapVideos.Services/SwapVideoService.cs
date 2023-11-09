using SwapVideos.API.Client.Generated;
using SwapVideos.Services.Interfaces;

namespace SwapVideos.Services;

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
    
    public async Task<IList<Video>> GetVideoAsync(int? page, int size)
    {
        var paginatedVideosRequest = new PaginatedVideosRequest()
        {
            Page = page,
            Size = size
        };
        var response = await _videoClient.GetAllVideosAsync(paginatedVideosRequest);
        return response.Videos.ToList();
    }

    public async Task<Video> TagVideoAsIndexedAsync(Guid videoId, bool isIndexed)
    {
        return await _videoClient.TagVideoAsIndexedAsync(videoId, isIndexed);
    }
}