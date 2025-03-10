using System.Text.Json.Serialization;

namespace Weatherions.Models
{
    public class WeatherData
    {
        [JsonPropertyName("location")]
        public LocationData? Location { get; set; }

        [JsonPropertyName("current")]
        public CurrentWeather? Current { get; set; }
        
        [JsonPropertyName("forecast")]
        public ForecastData? Forecast { get; set; }  
        // Latitude and Longitude should be doubles, not ForecastData
    }

    public class LocationData
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("region")]
        public string? Region { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }
        [JsonPropertyName("lat")]
        public double? Latitude { get; set; }
        [JsonPropertyName("lon")]
        public double? Longitude { get; set; }
    }

    public class CurrentWeather
    {
        [JsonPropertyName("temp_c")]
        public double? TempC { get; set; }

        [JsonPropertyName("condition")]
        public WeatherCondition? Condition { get; set; }

        [JsonPropertyName("feelslike_c")]
        public double? FeelsLikeC { get; set; }

        [JsonPropertyName("humidity")]
        public int? Humidity { get; set; }

        [JsonPropertyName("wind_kph")]
        public double? WindKph { get; set; }

        [JsonPropertyName("last_updated")]
        public string? LastUpdated { get; set; }
    }

    public class WeatherCondition
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }
    }
    
    public class GeolocationResult
    {
        public bool Success { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Message { get; set; }
    }
}