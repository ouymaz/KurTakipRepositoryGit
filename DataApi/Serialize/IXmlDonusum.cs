using System;
using System.Collections.Generic;
using System.Text;

namespace DataApi.Serialize
{
    public interface IXmlDonusum
    {
        T Deserializer<T>(string deger);
        string Donustur(object deger);
    }
}
