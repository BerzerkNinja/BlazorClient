using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Logic
{
    public class WeatherGetter
    {
        private readonly string _city;
        private readonly Func<string, Task<WeatherResponse>> _getWeatherData;

        public WeatherGetter(string city, Func<string, Task<WeatherResponse>> getWeatherData)
        {
            _city = city;
            _getWeatherData = getWeatherData;
        }

        public async Task<List<WeatherModel>> GetAsync()
        {
            var weatherResponse = await _getWeatherData(_city);

            if (weatherResponse == null)
                return null;

            return weatherResponse.list.Select(x => new WeatherModel
            {
                Date = Convert.ToDateTime(x.dt_txt),
                Description = x.weather.FirstOrDefault().main,
                Temparature = x.main.temp
            }).ToList();
        }
    }
}

namespace Data
{
    public class WeatherGetterData
    {
        public static async Task<WeatherResponse> GetWeatherData(string city)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/forecast?q={city}&APPID=e03a1e9cfdc9a5a8be39ea7d34990511");

                if (!response.IsSuccessStatusCode)
                    return null;

                var json = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<WeatherResponse>(json, new JsonSerializerOptions
                {
                    AllowTrailingCommas = true
                });
            }
        }
    }
}