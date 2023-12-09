using Keywords.API.Client.Generated;
using SwapVideos.API.Client.Generated;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Keywords.Services;
using Keywords.Services.Interfaces;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IKeywordClient>(_ => new KeywordClient
    { BaseUrl = builder.Configuration.GetConnectionString("keywordsbackend") });
builder.Services.AddScoped<IIndexerClient>(_ => new IndexerClient
    { BaseUrl = builder.Configuration.GetConnectionString("keywordsbackend") });
builder.Services.AddScoped<ISpeechClient>(_ => new SpeechClient()
    { BaseUrl = builder.Configuration.GetConnectionString("keywordsbackend") });
builder.Services.AddScoped<IVideoClient>(_ => new VideoClient
    { BaseUrl = builder.Configuration.GetConnectionString("videosbackend") });
builder.Services.AddScoped<ITextToSpeechClient>(_ => new TextToSpeechClient()
    { BaseUrl = builder.Configuration.GetConnectionString("keywordsbackend") });

// Add services to the container.
builder.Services.AddScoped<IKeywordService, KeywordService>();
builder.Services.AddScoped<IIndexerService, IndexerService>();
builder.Services.AddScoped<ISwapVideoService, SwapVideoService>();
builder.Services.AddScoped<ISpeechService, SpeechService>();
builder.Services.AddScoped<ITextToSpeechService, TextToSpeechService>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<DialogService>();

builder.Services.AddSignalR(options => { options.MaximumReceiveMessageSize = Int64.MaxValue; });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/Users/Shared/_Host");
app.MapFallbackToPage("/admin/{**slug}","/Admin/Shared/_Host");



app.Run();