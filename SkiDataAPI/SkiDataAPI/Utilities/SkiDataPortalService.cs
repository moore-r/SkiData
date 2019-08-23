using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

using SkiDataAPI.models;

namespace SkiDataAPI.Utilities
{
    /// <summary>
    /// Ski data service class, handles connections to the Ski Data portal
    /// as well as properly formatting the data received from the angular site.
    /// </summary>
    public class SkiDataPortalService
    {
        private readonly IConfiguration _config;

        // Load in the ski data config section from the appsettings - portal id and key.
        public SkiDataPortalService(IConfiguration configuration)
        {
            _config = configuration.GetSection("SkiDataConfig");
        }

        /// <summary>
        /// Asynchronous task uses a restsharp client to connect to the skidata api and
        /// await fro the calll results. 
        /// </summary>
        /// <param name="RegistrationData"> the data from the angular site</param>
        /// <returns> result contents as a string</returns>
        public async Task<string> Register(RegisterModel RegistrationData)
        {
            // Creating Restsharp client with method type and URI
            RestClient client = new RestClient("https://api.skidataus.com/");
            RestRequest request = new RestRequest($"user/{_config["PortalID"]}/v1/user", Method.POST);

            // Set headers
            request.AddHeader("x-api-key", _config["key"]);
            request.AddHeader("Content-Type", "application/json");

            // Serialize the data in a Ski daa portal excepted format.
            string json = Serialize(RegistrationData);

            request.AddJsonBody(json);

            // asynchronously execute the call 
            IRestResponse result = await client.ExecuteTaskAsync(request);

            return result.Content;
        }

        /// <summary>
        /// Serialize the Angular site date with netonsoft.json
        /// </summary>
        /// <param name="dataToSerialize">the data from the angular site</param>
        /// <returns>Jsonified data to be added to the request body.</returns>
        public string Serialize(RegisterModel dataToSerialize)
        {
            RegistrationRequestModel data = new RegistrationRequestModel();
            data.RegistrationChannel = " User reg tech challenge question";
            data.Username = dataToSerialize.name;
            data.Password = dataToSerialize.password;

            // Made the user profile properties a list in case I need to add more properties
            data.UserProfileProperties = new List<UserProfileModel>();
            data.UserProfileProperties.Add(new UserProfileModel(dataToSerialize.email, "email"));

            return JsonConvert.SerializeObject(data);
        }
    }
}
