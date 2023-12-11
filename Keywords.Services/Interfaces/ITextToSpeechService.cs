namespace Keywords.Services.Interfaces;

public interface ITextToSpeechService
{
    /// <summary>
    /// Creates an audio file for the keyword and attaches its url to the keyword object
    /// </summary>
    /// <param name="id">Id of the keyword</param>
    Task CreateAudioForKeyword(Guid id);
}