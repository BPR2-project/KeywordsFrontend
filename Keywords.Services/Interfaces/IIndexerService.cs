using Keywords.API.Client.Generated;

namespace Keywords.Services.Interfaces;

public interface IIndexerService
{
    /// <summary>
    /// Start indexing a video
    /// </summary>
    /// <param name="videoId">Id of the video to be indexed</param>
    /// <param name="url">Url of the video to be indexed</param>
    Task IndexVideoAsync(Guid videoId, string url);
    
    /// <summary>
    /// Gets the indexing status of the video 
    /// </summary>
    /// <param name="videoId">Id of the video that is being indexed</param>
    /// <returns>Returns the indexing state of the video</returns>
    Task<IndexerProgress> GetIndexerProgressAsync(Guid videoId);
}