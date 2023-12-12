using Keywords.API.Client.Generated;

namespace Keywords.Services.Interfaces;

public interface IKeywordService
{
    /// <summary>
    /// Gets a list of keywords paginated with the possibility to filter them
    /// </summary>
    /// <param name="keywordsRequest">Request that includes the filters to apply for pagination</param>
    /// <returns>Returns a filtered/paginated list of keywords</returns>
    Task<PaginatedKeywordsResponse> GetAllKeywordsByVideoIdAsync(PaginatedKeywordsRequest keywordsRequest);
    
    /// <summary>
    /// Action to publish or unpublish a keyword
    /// </summary>
    /// <param name="keywordId">Id of the keyword</param>
    /// <param name="toBePublished">Flag to be applied on the keyword</param>
    /// <returns>Returns the keyword with the updated flag</returns>
    Task<Keyword> PublishKeywordAsync(Guid keywordId, bool? toBePublished);
}