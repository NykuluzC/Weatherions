namespace Weatherions.Services; // Add this at the top

using System.Net.Http.Json;
using System.Text.Json;
using Weatherions.Models; // Make sure to reference the correct namespace

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "5a48c4d966164738bde75819250903";
    private const string BaseUrl = "http://api.weatherapi.com/v1/current.json";

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Location>> GetCitySuggestionsAsync(string query)
    {
        try
        {
            string url = $"https://api.weatherapi.com/v1/search.json?key={ApiKey}&q={query}&limit=20";
            var response = await _httpClient.GetFromJsonAsync<List<Location>>(url);
            return response ?? new List<Location>();
        }
        catch
        {
            return new List<Location>();
        }
    }
    public async Task<WeatherData?> GetWeatherByCoordinatesAsync(double lat, double lon)
    {
        try
        {
            string url = $"http://api.weatherapi.com/v1/current.json?key={ApiKey}&q={lat},{lon}&aqi=no";
            Console.WriteLine($"Fetching: {url}");

            var response = await _httpClient.GetStringAsync(url);
            var weatherData = JsonSerializer.Deserialize<WeatherData>(response);
            return weatherData;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching weather by coordinates: {ex.Message}");
            return null;
        }
    }
    public async Task<ForecastData?> GetForecastByCoordinatesAsync(double lat, double lon)
    {
        try
        {
            string url = $"http://api.weatherapi.com/v1/forecast.json?key={ApiKey}&q={lat},{lon}&days=7&aqi=no";
            Console.WriteLine($"Fetching Forecast: {url}");

            var response = await _httpClient.GetStringAsync(url);
            var forecastData = JsonSerializer.Deserialize<ForecastData>(response);
            return forecastData;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching weather forecast: {ex.Message}");
            return null;
        }
    }
    public async Task<WeatherData?> GetWeatherAsync(string city)
    {
        try
        {
            string url = $"{BaseUrl}?key={ApiKey}&q={city}&aqi=no";
            Console.WriteLine($"Fetching: {url}");

            var response = await _httpClient.GetStringAsync(url);
            Console.WriteLine($"API Response: {response}");

            var weatherData = JsonSerializer.Deserialize<WeatherData>(response);
            return weatherData;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching weather: {ex.Message}");
            return null;
        }
    }
}