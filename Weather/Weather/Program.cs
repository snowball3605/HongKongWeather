using System.Text.Json;

namespace Weather
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            string json =
                await client.GetStringAsync(
                    "https://data.weather.gov.hk/weatherAPI/opendata/weather.php?dataType=fnd&lang=tc");
            
            Response date = JsonSerializer.Deserialize<Response>(json);

            Console.WriteLine("Hong Kong Weather Data");
            for (int i = 0; i < date.weatherForecast.Count; i++)
            {
                Console.Write($"Date: {date.weatherForecast[i].forecastDate}");
                Console.Write($" Temp: {date.weatherForecast[i].forecastMintemp.value}C-{date.weatherForecast[i].forecastMaxtemp.value}C");
                Console.WriteLine($" Chance of rain: {date.weatherForecast[i].PSR}");
            }
        }
    }
}