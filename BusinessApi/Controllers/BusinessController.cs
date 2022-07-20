using DataAccessLayer.Repositories;
using DataApi;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessApi.Controllers
{
    [Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BusinessController : ControllerBase 
    {
        private readonly ILogger<BusinessController> _logger;
        //private readonly IDistributedCache _distributedCache;
        public BusinessController(ILogger<BusinessController> logger/*, IDistributedCache distributedCache*/)
        {
            _logger = logger;
            //_distributedCache = distributedCache;
        }
        //[HttpGet(Name = "GetExchangeRate")]
        [HttpGet("{id}")]
        public async Task<IEnumerable<ExchangeRate>> GetAsync(string id)
        {
            string[] months = { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sept", "Oct", "Now", "Dec" };

            GenericRepository<DovizKuru> dk = new GenericRepository<DovizKuru>();
            var result = dk.GetListAll().Where(a => a.CurrencyCode == id.ToUpper()).OrderBy(q => q.Year).ThenBy(w => w.Month).ThenBy(t => t.Day).Select(index => new ExchangeRate
            {
                CurrencyCode = index.CurrencyCode,
                value = index.ForexSelling,
                date = index.Day.ToString() + "-" + months[index.Month] + "-" + index.Year.ToString().Substring(2, 2)// new DateTime(day:index.Day,month:index.Month,year:index.Year).ToString("d-MMM-yy")

            }).ToArray();

            return result;


            //var cached = await _distributedCache.GetStringAsync("currency");

            //if (cached == null || cached == "")
            //{
            //    GenericRepository<DovizKuru> dk = new GenericRepository<DovizKuru>();
            //    var result = dk.GetListAll().Where(a => a.CurrencyCode == id.ToUpper()).OrderBy(q => q.Year).ThenBy(w => w.Month).ThenBy(t => t.Day).Select(index => new ExchangeRate
            //    {
            //        CurrencyCode = index.CurrencyCode,
            //        value = index.ForexSelling,
            //        date = index.Day.ToString() + "-" + months[index.Month] + "-" + index.Year.ToString().Substring(2, 2)// new DateTime(day:index.Day,month:index.Month,year:index.Year).ToString("d-MMM-yy")

            //    }).ToArray();

            //    await _distributedCache.SetStringAsync(
            //                                    "currency",
            //                                    System.Text.Json.JsonSerializer.Serialize(result),
            //                                    new DistributedCacheEntryOptions
            //                                    {
            //                                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
            //                                        SlidingExpiration = TimeSpan.FromSeconds(60)
            //                                    });

            //    return result;
            //}
            //else
            //{
            //    var data2 = JsonSerializer.Deserialize<IEnumerable<ExchangeRate>>(cached).ToList();
            //    var data = JsonSerializer.Deserialize<IEnumerable<ExchangeRate>>(cached).Where(a => a.CurrencyCode == id.ToUpper()).ToList();

            //    if (data.Count > 0)
            //    {
            //        return data;
            //    }
            //    else
            //    {
            //        GenericRepository<DovizKuru> dk = new GenericRepository<DovizKuru>();
            //        var result = dk.GetListAll().Where(a => a.CurrencyCode == id.ToUpper()).OrderBy(q => q.Year).ThenBy(w => w.Month).ThenBy(t => t.Day).Select(index => new ExchangeRate
            //        {
            //            CurrencyCode = index.CurrencyCode,
            //            value = index.ForexSelling,
            //            date = index.Day.ToString() + "-" + months[index.Month] + "-" + index.Year.ToString().Substring(2, 2)// new DateTime(day:index.Day,month:index.Month,year:index.Year).ToString("d-MMM-yy")

            //        }).ToList();

            //        var graphResult = result.ToList();//grafikte görünecek sonuçlar

            //        result.AddRange(data2);//önceki cache datalarının üzerine yeni arama ekleniyor.

            //        await _distributedCache.SetStringAsync(
            //                                        "currency",
            //                                        System.Text.Json.JsonSerializer.Serialize(result.ToArray()),
            //                                        new DistributedCacheEntryOptions
            //                                        {
            //                                            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
            //                                            SlidingExpiration = TimeSpan.FromSeconds(60)
            //                                        });

            //        return graphResult.ToArray();
            //    }

            //}
        }

    }
}
