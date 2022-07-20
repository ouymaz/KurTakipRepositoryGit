using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DataApi.Serialize
{
    public class XmlDonusumClass : IXmlDonusum
    {
        public T Deserializer<T>(string deger)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            var datareader = new StringReader(deger);

            return (T)serializer.Deserialize(datareader);
        }

        public string Donustur(object deger)
        {
            var xmlNameSpace = new XmlSerializerNamespaces();
            xmlNameSpace.Add(prefix:"",ns:"");

            var writer = new StringWriter();

            var xmlSettings = new XmlWriterSettings
            { 
                OmitXmlDeclaration = true
            };

            using var xmlWriter = XmlWriter.Create(writer,xmlSettings);

            var serializer = new System.Xml.Serialization.XmlSerializer(deger.GetType());
            serializer.Serialize(xmlWriter, deger, xmlNameSpace);

            return writer.ToString();
        }
    }
}
