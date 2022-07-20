using DataApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataApi
{
    public interface ICurrencyService
    {
        Task<CurrencyClass[]> GetToday();
        Task<CurrencyClass[]> GetByDate(DateTime date);
    }
}
