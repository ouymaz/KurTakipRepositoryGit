using DataAccessLayer.Repositories;
using DataApi;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiLayer3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult DovizDataSave()
        {
            try
            {
                ICurrencyService service;

                List<DovizKuru> model = new List<DovizKuru>();


                //today için ayrıca gettoday fonksiyonunu çalıştırıyoruz. GetbyDate şeklinde bugünün datası için hatalı dönüş yapıyor xml servisi.
                try
                {
                    service = new CurrencyserviceClass();
                    var sonuc = service.GetToday();

                    foreach (var item in sonuc.Result)
                    {
                        DovizKuru m = new DovizKuru();

                        m.BanknoteBuying = item.BanknoteBuying;
                        m.BanknoteSelling = item.BanknoteSelling;
                        m.CrossRateOther = item.CrossRateOther;
                        m.CrossRateUSD = item.CrossRateUSD;
                        m.CurrencyCode = item.CurrencyCode;
                        m.ForexBuying = item.ForexBuying;
                        m.ForexSelling = item.ForexSelling;
                        m.Name = item.Name;
                        m.Unit = item.Unit;
                        m.Year = DateTime.Now.Year;
                        m.Month = DateTime.Now.Month;
                        m.Day = DateTime.Now.Day;

                        model.Add(m);
                    }

                }
                catch (Exception) { }

                //Geçmiş iki aylık data
                var today = DateTime.Now.AddDays(-1);//while dünden başlayacak.
                while (today > DateTime.Now.AddMonths(-2))
                {
                    try
                    {
                        var _year = today.Year;
                        var _month = today.Month;
                        var _day = today.Day;

                        today = today.AddDays(-1);

                        service = new CurrencyserviceClass();
                        var sonuc = service.GetByDate(new DateTime(year: _year, month: _month, day: _day));

                        foreach (var item in sonuc.Result)
                        {
                            DovizKuru m = new DovizKuru();

                            m.BanknoteBuying = item.BanknoteBuying;
                            m.BanknoteSelling = item.BanknoteSelling;
                            m.CrossRateOther = item.CrossRateOther;
                            m.CrossRateUSD = item.CrossRateUSD;
                            m.CurrencyCode = item.CurrencyCode;
                            m.ForexBuying = item.ForexBuying;
                            m.ForexSelling = item.ForexSelling;
                            m.Name = item.Name;
                            m.Unit = item.Unit;
                            m.Year = _year;
                            m.Month = _month;
                            m.Day = _day;

                            model.Add(m);
                        }

                    }
                    catch (Exception ex) { }
                }

                GenericRepository<DovizKuru> dvd = new GenericRepository<DovizKuru>();

                dvd.RangeInsert(model);

                return Ok("1");//işlem başarılı olduğunda 200
            }
            catch (Exception)
            {
                return Ok("0");//işlem başarısız
            }
        }

    }
}
