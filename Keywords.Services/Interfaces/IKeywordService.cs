using Keywords.API.Client.Generated;

namespace Keywords.Services.Interfaces;

public interface IKeywordService
{
    Task<PaginatedKeywordsResponse> GetAllKeywordsByVideoIdAsync(PaginatedKeywordsRequest keywordsRequest);
    Task<Keyword> PublishKeywordAsync(Guid keywordId, bool? toBePublished);
}