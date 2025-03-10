namespace Weatherions.Services;

using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;

public class NewsService
{
    private readonly HttpClient _httpClient;
    private const string apiKey = "670c9e31d3b1457183c1160d965d708b";  // Your API key
    private const string baseUrl = "https://newsapi.org/v2/everything";  // The NewsAPI base URL

    public NewsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetWeatherNews(string query)
    {
        var url = $"{baseUrl}?q={query}&apiKey={apiKey}&pageSize=5";       
        try
        {
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching news: {ex.Message}");
            return null;
        }
    }
}