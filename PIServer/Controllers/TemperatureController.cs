using Microsoft.AspNetCore.Mvc;
using PIServer.Service;

namespace PIServer.Controllers
{

    [Route("api/temperature")]
    public class TemperatureController : Controller
    {
        private readonly IDHT11Service _dht11;

        public TemperatureController(IDHT11Service dht11)
        {
            _dht11 = dht11;
        }

        [HttpGet("current")]
        public JsonResult CurrentTemperature()
        {
            var res = _dht11.CurrentStatus();
            return Json(res);
        }
    }
}
