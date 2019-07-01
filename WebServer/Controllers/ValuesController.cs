using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private string LastData { get; set; }

        // GET api/values
        [HttpGet("GetData")]
        public ActionResult<string> GetData()
        {
            return LastData??"Данные еще не приходили";
        }


        // POST api/values
        [HttpPost("SendData")]
        public void SendData([FromBody] string value)
        {
            LastData = value;
        }

    }
}
