using Keywords.API.Client.Generated;
using Keywords.Services.Interfaces;

namespace Keywords.Services;

public class SpeechService : ISpeechService
{
    private readonly ISpeechClient _speechClient;
    
    public SpeechService(ISpeechClient speechClient)
    {
        _speechClient = speechClient;
    }

    public async Task<PronunciationAssessmentResponseDTO> CreatePronunciationAssessmentAsync(FileParameter audioFile, string language, string referenceText)
    {
        return await _speechClient.CreatePronunciationAssessmentAsync(language, referenceText, audioFile);
    }
}