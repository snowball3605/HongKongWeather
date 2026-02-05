using System.Text.Json.Serialization;

namespace Weather;

public class Response
{
    public List<WeatherForecast> weatherForecast { get; set; } = new();

}

public class WeatherForecast
{
    public string forecastDate {get; set;}
    public string PSR {get; set;}
    
    public ForecastTemp forecastMaxtemp {get; set;}
    public ForecastTemp forecastMintemp {get; set;}
    
}

public class ForecastTemp
{
    public int value {get; set;}
    public string unit {get; set;}
}