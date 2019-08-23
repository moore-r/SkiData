using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

using SkiDataAPI.Utilities;
using SkiDataAPI.models;

namespace SkiDataAPI.Controllers
{
    /// <summary>
    /// Controller for all ski data related APIs
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SkiDataController : Controller
    {
        IConfiguration _iconfiguration;

        // Need to pass configuration into SkiData service
        public SkiDataController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        /// <summary>
        /// receive registration data from front end and pass it onto ski data service
        /// </summary>
        /// <param name="data">The registration data entered by user on the angular site</param>
        /// <returns></returns>
        [HttpPost("CreateAccount")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateAccount([FromBody] RegisterModel data)
        {
            try
            {
                SkiDataPortalService SkiDataRegister = new SkiDataPortalService(_iconfiguration);
                string SkiDataResponseContent = await SkiDataRegister.Register(data);

                return Ok(SkiDataResponseContent);
            }
            catch(Exception e)
            {
                // Return a failure message that includes the exception.
                string message = $"Registration failed with error: {e}";
                return StatusCode(500, message);
            }
        }

    }
}
