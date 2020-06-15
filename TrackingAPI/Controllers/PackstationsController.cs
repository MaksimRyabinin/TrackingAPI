using Microsoft.AspNetCore.Mvc;
using TrackingAPI.Storages;

namespace TrackingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class PackstationsController : ControllerBase
    {
        private readonly PackstationsStorage packstationsStorageInst = null;

        public PackstationsController()
        {
            packstationsStorageInst = PackstationsStorage.GetInstance();
        }

        [HttpGet]
        public IActionResult Get([FromQuery]string number)
        {
            var result = packstationsStorageInst.GetPackstation(number);

            if (result == null)
                return BadRequest("Постамат не найден");

            return Ok(result);
        }
    }
}
