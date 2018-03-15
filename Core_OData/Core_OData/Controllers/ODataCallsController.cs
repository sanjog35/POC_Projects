using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_OData.Controllers
{
    [Produces("application/json")]
    [Route("api/ODataCalls")]
    public class ODataCallsController : Controller
    {
        [HttpGet]
        [Route("OData")]
        public async Task<IActionResult> GetOData()
        {
            string data = null;
            try
            {
                using (var _client = new HttpClient())
                {
                    string uri = "http://services.odata.org/V4/TripPinServiceRW";

                    using (HttpResponseMessage _response = await _client.GetAsync(uri))
                    using (HttpContent _context = _response.Content)
                    {
                        data = await _context.ReadAsStringAsync();
                    }                    
                }

            }
            catch (Exception)
            {

                throw;
            }
            return new JsonResult(data);
        }
    }
}