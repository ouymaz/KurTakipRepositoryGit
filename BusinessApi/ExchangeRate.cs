using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessApi
{
    public class ExchangeRate
    {
        public string CurrencyCode { get; set; }
        public string value { get; set; }
        public string date { get; set; } // Day+Month+Year birleştirilmiş halde
    }
}
