using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WeatherForecastMap.Models;

namespace WeatherForecastMap.Models
{
    public class WeatherDBAccessLayer
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-RMI9JAI;Database=WeatherDB;Trusted_Connection=True;");
        public string AddWeatherRecord(ResultViewModel weatherEntities)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Weather_Add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@City", weatherEntities.City);
                cmd.Parameters.AddWithValue("@CloudCoverConditions", weatherEntities.CloudCoverConditions);
                cmd.Parameters.AddWithValue("@Humidity", weatherEntities.Humidity);
                cmd.Parameters.AddWithValue("@Temperature", weatherEntities.Temperature);
                cmd.Parameters.AddWithValue("@TemperatureFeelsLike", weatherEntities.TemperatureFeelsLike);
                cmd.Parameters.AddWithValue("@TemperatureMax", weatherEntities.TemperatureMax);
                cmd.Parameters.AddWithValue("@TemperatureMin", weatherEntities.TemperatureMin);
                cmd.Parameters.AddWithValue("@WindSpeed", weatherEntities.WindSpeed);
                cmd.Parameters.AddWithValue("@WindDirection", weatherEntities.WindDirection);
                cmd.Parameters.AddWithValue("@AirPressure", weatherEntities.AirPressure);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}