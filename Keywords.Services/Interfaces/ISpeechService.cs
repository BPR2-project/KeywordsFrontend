using Keywords.API.Client.Generated;

namespace Keywords.Services.Interfaces;

public interface ISpeechService
{
    /// <summary>
    /// Creates a request to send for pronunciation assessment
    /// </summary>
    /// <param name="audioFile">Voice recording</param>
    /// <param name="language">Language of the keyword</param>
    /// <param name="referenceText">Keyword to be used for assessment</param>
    /// <returns>Returns the assessment for the pronunciation</returns>
    Task<PronunciationAssessmentResponseDTO> CreatePronunciationAssessmentAsync(Stream audioFile, string language,
        string referenceText);
}