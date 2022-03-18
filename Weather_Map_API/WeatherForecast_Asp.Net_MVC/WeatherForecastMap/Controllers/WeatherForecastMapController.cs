using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecastMap.Models;

namespace WeatherForecastMap.Controllers
{
    public class WeatherForecastMapController : Controller
    {
        WeatherDBAccessLayer weadb = new WeatherDBAccessLayer();

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind] ResultViewModel WeatherEntities)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = weadb.AddWeatherRecord(WeatherEntities);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
    }
}