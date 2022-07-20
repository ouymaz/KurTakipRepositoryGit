using System;
using System.Collections.Generic;
using System.Text;

namespace DataApi.Model
{
    public class CurrencyClass
    {
        public int Unit { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ForexBuying { get; set; }
        public string ForexSelling { get; set; }
        public string BanknoteBuying { get; set; }
        public string BanknoteSelling { get; set; }
        public string CrossRateUSD { get; set; }
        public string CrossRateOther { get; set; }

        public static CurrencyClass Map(Tarih_DateCurrency model)
        {
            return new CurrencyClass
            {
                Unit = model.Unit,
                Name = model.CurrencyName,
                CurrencyCode = model.CurrencyCode,
                BanknoteSelling = model.BanknoteSelling,
                BanknoteBuying = model.BanknoteBuying,
                ForexBuying = model.ForexBuying,
                ForexSelling = model.ForexSelling,
                CrossRateUSD = model.CrossRateUSD,
                CrossRateOther = model.CrossRateOther
            };
        }
    }
}
