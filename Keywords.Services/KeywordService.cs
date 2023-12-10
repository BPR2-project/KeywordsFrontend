using Keywords.API.Client.Generated;
using Keywords.Services.Interfaces;

namespace Keywords.Services;

public class KeywordService : IKeywordService
{
    private readonly IKeywordClient _keywordClient;

    public KeywordService(IKeywordClient keywordClient)
    {
        _keywordClient = keywordClient;
    }

    public async Task<PaginatedKeywordsResponse> GetAllKeywordsByVideoIdAsync(PaginatedKeywordsRequest keywordsRequest)
    {
        return await _keywordClient.GetAllKeywordsByVideoIdAsync(keywordsRequest);
    }

    public async Task<Keyword> PublishKeywordAsync(Guid keywordId, bool? toBePublished)
    {
        return await _keywordClient.PublishKeywordAsync(keywordId, toBePublished);
    }
   
}