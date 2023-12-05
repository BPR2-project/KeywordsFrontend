using Keywords.API.Client.Generated;

namespace Keywords.Services.Interfaces;

public interface ISpeechService
{
    Task<PronunciationAssessmentResponseDTO> CreatePronunciationAssessmentAsync(FileParameter audioFile, string language,
        string referenceText);
}