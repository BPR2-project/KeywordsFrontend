using Keywords.API.Client.Generated;
using Keywords.Services.Interfaces;

namespace Keywords.Services;

public class TextToSpeechService : ITextToSpeechService
{
    private ITextToSpeechClient _textToSpeechClient;

    public TextToSpeechService(ITextToSpeechClient textToSpeechClient)
    {
        _textToSpeechClient = textToSpeechClient;
    }

    public async Task CreateAudioForKeyword(Guid id)
    {
        await _textToSpeechClient.CreateAudioAsync(id);
    }
}