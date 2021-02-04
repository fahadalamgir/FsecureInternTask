using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fsecureintern.Services;
using Fsecureintern.Models;
using Microsoft.Extensions.Logging;

namespace Fsecureintern.Controllers
{
    public class HomeController : Controller
    {
        //Injecting HolidayService in Home Controller

        private readonly IHolidayService _holidayservice; 

        public HomeController (IHolidayService holidayService)
        {
            _holidayservice = holidayService;
        }
        public async Task <IActionResult> Index (string CountryCode, int Year) //Controller Action method for creating Holidaymodel list
        {
            List<HolidayModel> holidays = new List<HolidayModel>();

                if (!string.IsNullOrEmpty(CountryCode) && Year > 0)
                {
                    holidays = await _holidayservice.GetPublicHolidays(CountryCode, Year); //storing result from GetPublicHolidays to list variable
                }
           
            return View(holidays); //returning list to Index Razor view
        }
    }
}