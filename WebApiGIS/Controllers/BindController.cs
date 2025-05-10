using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiGIS.Models;

namespace WebApiGIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BindController : ControllerBase
    {
        [HttpGet("{age:int}/{name}")]//route sagment api/bind/11/ahmed
                 //querystring   api/bind?name=ahmed&age=11
        public IActionResult testPrimitive(int age ,string name)
        {
            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Edit(int id,Department dept)
        {
            return Ok();
        }

        //customize Bind
        [HttpGet]//api/bind?lan=10&&lat=20 without req body
                 //api/bind/10/20
        public IActionResult GetLocation([FromQuery]Location loc)//int lang ,int lat)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult post(int id,[FromBody]string name)//,Department dept)
        {
            return Ok();
        }
    }
}
