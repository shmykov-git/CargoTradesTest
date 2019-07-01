using Microsoft.AspNetCore.Mvc;
using Shared;
using WebServer.Tools;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private DbProvider dataProvider = new DbProvider();

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Ready";
        }

        [HttpGet("GetData")]
        public ActionResult<string> GetData()
        {
            return dataProvider.GetData();
        }


        // POST api/values
        [HttpPost("SendData")]
        public void SendData([FromBody] MyData data)
        {
            dataProvider.SaveData(data.Data);
        }

    }
}
