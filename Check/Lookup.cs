using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace personalDev.MotHistory.Lookup
{
    public class MotChecker
    {
        static HttpClient client = new HttpClient();
        public async Task<string> GetMotHistory(string input)
        {
            //Uri
            var uri = "https://driver-vehicle-licensing.api.gov.uk/vehicle-enquiry/v1/vehicles";
            //Api Key
            client.DefaultRequestHeaders.Add("x-api-key", Environment.GetEnvironmentVariable("Dvla_Api_Key"));
            //Json
            var data = new RegistrationNumber { registrationNumber = input };
            //POST
            var response = await client.PostAsJsonAsync(uri, data);
            //Return response
            return await response.Content.ReadAsStringAsync();
        }
    }

    
}