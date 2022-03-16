using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WeatherForecastMap.Models;

namespace WeatherForecastMap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Weather()
        {
            return View();
        } 
  
        [HttpPost]
    public String WeatherDetail(string City)
    {

        //Assign API KEY which received from OPENWEATHERMAP.ORG  
        string appId = "d9663da104dbbce4e707c54f37bbd603";

        //API path with CITY parameter and other parameters.  
        string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", City, appId);

        using (WebClient client = new WebClient())
        {
            string json = client.DownloadString(url);

            //Converting to OBJECT from JSON string.  
            RootObject weatherInfo = (new JavaScriptSerializer()).Deserialize<RootObject>(json);

            //Special VIEWMODEL design to send only required fields not all fields which received from   
            //www.openweathermap.org api  
            ResultViewModel rslt = new ResultViewModel();

                rslt.Country = weatherInfo.sys.country;
                rslt.City = weatherInfo.name;
                rslt.CloudCoverCondition = weatherInfo.weather[0].description;
                rslt.Humidity = Convert.ToString(weatherInfo.main.humidity) +"%";
                rslt.Temp = Convert.ToString(weatherInfo.main.temp) +"°C";
                rslt.TempFeelsLike = Convert.ToString(weatherInfo.main.feels_like) +"°C";
                rslt.TempMax = Convert.ToString(weatherInfo.main.temp_max) +"°C";
                rslt.TempMin = Convert.ToString(weatherInfo.main.temp_min) +"°C";
                rslt.WeatherIcon = weatherInfo.weather[0].icon;
                rslt.AirPressure = Convert.ToString(weatherInfo.main.pressure) +"hPa";
                rslt.WindSpeed = Convert.ToString(weatherInfo.wind.speed) +"m/s";
                rslt.WindDirection = Convert.ToString(weatherInfo.wind.deg) +"°";

                //Converting OBJECT to JSON String   
                var jsonstring = new JavaScriptSerializer().Serialize(rslt);

            //Return JSON string.  
            return jsonstring;
        }
    }
}
}