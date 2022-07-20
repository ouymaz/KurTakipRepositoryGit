using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLayer1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult DovizList()
        {
            using var c = new Context();
            var values = c.DovizKurus.ToList();
            return Ok(values);//işlem başarılı olduğunda 200
        }
    }
}
