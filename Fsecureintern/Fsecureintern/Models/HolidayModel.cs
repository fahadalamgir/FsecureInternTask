using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fsecureintern.Models
{
    public class HolidayModel                 // Definition of Holidaymodel class and properties for response mapping from the  Nager.Date API
    {
       
        public DateTime? Date { get; set; }
        public string LocalName { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public bool Global { get; set; }
        public string Type { get; set; }


    }
}
