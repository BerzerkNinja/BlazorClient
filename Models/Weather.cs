using System;
using System.Collections.Generic;

namespace Models
{
    public class WeatherModel
    {
        public string DisplayDate => Date.ToString("dd-MMM-yyyy hh:mm tt");
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string DisplayTemparature => $"{Temparature - 273.15m}°C";
        public decimal Temparature { get; set; }
    }

    public class WeatherResponse
    {
        public string cod { get; set; }
        public decimal message { get; set; }
        public int cnt { get; set; }
        public List<WeatherRecord> list { get; set; }
        public City city { get; set; }
    }

    public class WeatherRecord
    {
        public long dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Sys sys { get; set; }
        public string dt_txt { get; set; }
    }

    public class Main
    {
        public decimal temp { get; set; }
        public decimal temp_min { get; set; }
        public decimal temp_max { get; set; }
        public decimal pressure { get; set; }
        public decimal sea_level { get; set; }
        public decimal grnd_Level { get; set; }
        public int humidity { get; set; }
        public decimal temp_kf { get; set; }
    }

    public class Weather
    {
        public long id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Wind
    {
        public decimal speed { get; set; }
        public decimal deg { get; set; }
    }

    public class Sys
    {
        public string pod { get; set; }
    }

    public class City
    {
        public long id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public long timezone { get; set; }
        public long sunrise { get; set; }
        public long sunset { get; set; }
    }

    public class Coord
    {
        public decimal lat { get; set; }
        public decimal lon { get; set; }
    }
}
