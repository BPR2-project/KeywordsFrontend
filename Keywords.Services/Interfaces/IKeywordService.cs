using Keywords.API.Client.Generated;

namespace Keywords.Services.Interfaces;

public interface IKeywordService
{
    Task<Keyword> GetKeywordAsync(System.Guid keywordId);
}