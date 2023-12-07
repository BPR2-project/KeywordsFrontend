using Keywords.API.Client.Generated;

namespace Keywords.Services.Interfaces;

public interface ISpeechService
{
    Task<PronunciationAssessmentResponseDTO> CreatePronunciationAssessmentAsync(Stream audioFile, string language,
        string referenceText);
}