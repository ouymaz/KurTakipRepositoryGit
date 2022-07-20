using DataAccessLayer.Concrete;
using DataApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILayer2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult DovizList()
        {
            ICurrencyService service;

            service = new CurrencyserviceClass();

            var sonuc = service.GetToday();

            return Ok(sonuc);//işlem başarılı olduğunda 200
        }
    }
}
