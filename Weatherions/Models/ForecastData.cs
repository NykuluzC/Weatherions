using System.Text.Json.Serialization;

namespace Weatherions.Models;

public class ForecastData
{
    [JsonPropertyName("forecast")]
    public ForecastDaysData? ForecastDays { get; set; }
}

public class ForecastDaysData
{
    [JsonPropertyName("forecastday")]
    public List<ForecastDay>? ForecastDays { get; set; }
}

public class ForecastDay
{
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("day")]
    public DayData? Day { get; set; }
}

public class DayData
{
    [JsonPropertyName("avgtemp_c")]
    public double? AvgTempC { get; set; }

    [JsonPropertyName("avghumidity")]
    public int? AvgHumidity { get; set; }

    [JsonPropertyName("condition")]
    public WeatherCondition? Condition { get; set; }
}