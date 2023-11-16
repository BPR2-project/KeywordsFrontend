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

    public async Task<Keyword> GetKeywordAsync(Guid keywordId)
    {
        return await _keywordClient.GetKeywordAsync(keywordId);
    }

    public async Task<PaginatedKeywordsResponse> GetAllKeywordsByVideoIdAsync(PaginatedKeywordsRequest keywordsRequest)
    {
        return await _keywordClient.GetAllKeywordsByVideoIdAsync(keywordsRequest);
    }
   
}