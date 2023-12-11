using SwapVideos.API.Client.Generated;

namespace Keywords.Services.Interfaces;

public interface ISwapVideoService
{
    /// <summary>
    /// Retrieve a video by its id 
    /// </summary>
    /// <param name="videoId">Id of the video</param>
    /// <returns>Returns the video object</returns>
    Task<Video> GetVideoAsync(Guid videoId);
    /// <summary>
    /// Get a paginated list of videos
    /// </summary>
    /// <param name="page">Page number to retrieve</param>
    /// <param name="size">Size of the page</param>
    /// <returns>Returns a paginated list of videos</returns>
    Task<PaginatedVideosResponse> GetAllVideosAsync(int? page, int size);
}