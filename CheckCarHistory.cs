using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using personalDev.MotHistory.Validation;
using personalDev.MotHistory.Lookup;


namespace personalDev.MotHistory
{
    public static class MotHistoryFunction
    {
        [FunctionName("MotHistoryFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // Initialise
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            string registration = req.Query["registrationNumber"];
            registration = registration ?? data?.registration;

            //Validate
            var validation = new RegistrationValidation();
            bool verified = validation.ValidateRegistration(registration);

            //Process request
            if (verified)
            {
                var lookup = new MotChecker();
                var motApi = await lookup.GetMotHistory(registration);
                return new OkObjectResult(motApi.ToString());
            }

            //Request is not valid
            return new BadRequestObjectResult("Something went wrong. Make sure to include 'registrationNumber' in your request.");



        }
    }
}
