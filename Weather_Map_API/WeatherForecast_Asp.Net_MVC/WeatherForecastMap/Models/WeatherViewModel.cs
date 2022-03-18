﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WeatherForecastMap.Models
{
    public class ResultViewModel
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string CloudCoverConditions { get; set; }
        [Required]
        public string Humidity { get; set; }
        [Required]
        public string TemperatureFeelsLike { get; set; }
        [Required]
        public string Temperature { get; set; }
        [Required]
        public string TemperatureMax { get; set; }
        [Required]
        public string TemperatureMin { get; set; }
        public string WeatherIcon { get; set; }
        [Required]
        public string AirPressure { get; set; }
        [Required]
        public string WindSpeed { get; set; }
        [Required]
        public string WindDirection { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Weather
    {
        public double id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class Clouds
    {
        public double all { get; set; }
    }

    public class Sys
    {
        public double type { get; set; }
        public double id { get; set; }
        public string country { get; set; }
        public double sunrise { get; set; }
        public double sunset { get; set; }
    }

    public class RootObject
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}