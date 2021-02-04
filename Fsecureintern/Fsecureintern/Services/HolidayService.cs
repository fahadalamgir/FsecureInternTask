using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Fsecureintern.Models;
using System.Net;

namespace Fsecureintern.Services
{
    public class HolidayService:IHolidayService     // Inheriting HolidayService class from Interface IHolidayService  
    {
        private readonly HttpClient client;  //creation of HttClient instance 

        public HolidayService(IHttpClientFactory clientFactory)
        {
            client = clientFactory.CreateClient("PublicHolidaysApi"); //initializing client instance for avoiding socket exhaustion 
        }

        public async Task<List<HolidayModel>> GetPublicHolidays(String CountryCode, int Year) //method GetPublicHolidays implementation
        {

            var URL = string.Format("/api/v2/PublicHolidays/{0}/{1}", Year, CountryCode); // building a URL for Nager.Date API and using year and countrycode
            var result = new List<HolidayModel>();          //variable for holding the returned HolidayModel list
            var response = await client.GetAsync(URL); // sending get request to specified URL asynchronously

            if(response.IsSuccessStatusCode)
            {
                var stringresponse = await response.Content.ReadAsStringAsync();  //serializing http content to a string

                result = JsonSerializer.Deserialize<List<HolidayModel>>(stringresponse, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }); //JSON serializer for deserializing  JSON response string into a list of HolidayModel objects
            }

            else 
            {

               throw new HttpRequestException(response.ReasonPhrase); //if resource not found explain the reason
                   
                 
            }

            return result;
        }
    }
}
