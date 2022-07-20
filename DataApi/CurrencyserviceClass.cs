using DataApi.Model;
using DataApi.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataApi
{
    public class CurrencyserviceClass : ICurrencyService
    {
        private string url = "https://www.tcmb.gov.tr/kurlar/{0}.xml";
        private WebClient client;
        private IXmlDonusum serializer;

        public CurrencyserviceClass()
        {
            client = new WebClient {
                Encoding = Encoding.UTF8
            };

            serializer = new XmlDonusumClass();
        }

        public Task<CurrencyClass[]> GetToday()
        {
            var _url = new Uri(string.Format(url, "today"));
            var data = client.DownloadString(_url);
            var deserialize = serializer.Deserializer<Tarih_Date>(data);
            var sonuc = deserialize.Currency.Select(CurrencyClass.Map);

            return Task.FromResult(sonuc.ToArray());
        }

        public Task<CurrencyClass[]> GetByDate(DateTime date)
        {
            var day =  date.Day > 0 && date.Day<10 ? $"0{date.Day}" : date.Day.ToString();
            var mounth = date.Month>0 && date.Month<10 ? $"0{date.Month}" : date.Month.ToString();
            var year = date.Year.ToString();

            var _url = new Uri(string.Format(url, $"{year}{mounth}/{day}{mounth}{year}"));
            var data = client.DownloadString(_url);
            var deserialize = serializer.Deserializer<Tarih_Date>(data);
            var sonuc = deserialize.Currency.Select(CurrencyClass.Map);

            return Task.FromResult(sonuc.ToArray());
        }

    }
}
