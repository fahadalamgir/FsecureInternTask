using Fsecureintern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsecureintern.Services
{
  public  interface IHolidayService  //defining Interface for the user to provide CountryCode and Year via function declared below
    {
        Task<List<HolidayModel>> GetPublicHolidays(String CountryCode, int Year); //method for returning a list of HolidayModel

    }
}
