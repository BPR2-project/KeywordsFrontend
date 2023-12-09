namespace Keywords.Services.Interfaces;

public interface ITextToSpeechService
{
    Task CreateAudioForKeyword(Guid id);
}