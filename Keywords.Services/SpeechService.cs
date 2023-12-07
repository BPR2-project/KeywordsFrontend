using System.Net.Http.Headers;
using Keywords.API.Client.Generated;
using Keywords.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace Keywords.Services;

public class SpeechService : ISpeechService
{
    private readonly ISpeechClient _speechClient;
    private readonly IConfiguration _configuration;
    public SpeechService(ISpeechClient speechClient, IConfiguration configuration)
    {
        _speechClient = speechClient;
        _configuration = configuration;
    }

    public async Task<PronunciationAssessmentResponseDTO> CreatePronunciationAssessmentAsync(Stream audioFile, string language, string referenceText)
    {
        byte[] bytes;
        var binaryReader = new BinaryReader(audioFile);
        
        bytes = binaryReader.ReadBytes((int)audioFile.Length);
        var audioContent = new ByteArrayContent(bytes);

        var form = new MultipartFormDataContent();
        form.Headers.ContentType.MediaType = "multipart/form-data";
        audioContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/wav");
        
        form.Add(audioContent, "body", "body.wav");
        
        var httpClient = new HttpClient();

        var urlBuilder= new System.Text.StringBuilder();
        var url = _configuration.GetConnectionString("keywordsbackend");
        var url2 = urlBuilder.Append(url).Append("/speech").Append($"?language={language}")
            .Append($"&referenceText={referenceText}").ToString();

        var response = await httpClient.PostAsync(url2, form);

        var body = await response.Content.ReadAsStringAsync();
        var assessment = JsonConvert.DeserializeObject<PronunciationAssessmentResponseDTO>(body);
        
        // return await _speechClient.CreatePronunciationAssessmentAsync(audioFile, language, referenceText);
        return assessment ?? new PronunciationAssessmentResponseDTO();
    }
}