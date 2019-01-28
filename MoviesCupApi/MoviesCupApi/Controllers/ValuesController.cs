using Microsoft.AspNetCore.Mvc;

namespace MoviesCupApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/Values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Api v1 is working";
        }
    }
}
