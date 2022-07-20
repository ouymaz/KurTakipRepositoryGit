using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class DovizKuru
    {
        [Key]
        public int ID { get; set; }
        public string CurrencyCode { get; set; }
        public int Unit { get; set; }
        public string Name { get; set; }
        public decimal ForexBuying { get; set; }
        public string ForexSelling { get; set; }
        public string BanknoteBuying { get; set; }
        public string BanknoteSelling { get; set; }
        public string CrossRateUSD { get; set; }
        public string CrossRateOther { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }
}
