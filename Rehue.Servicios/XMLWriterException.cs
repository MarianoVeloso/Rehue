using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.Json;

namespace Rehue.Servicios.Helpers
{
    public static class XMLWriterException
    {
        public static void Escribir(Exception ex)
        {
            string path = @"C:\Rehue\Logs";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            XmlDocument document = new XmlDocument();

            if (!File.Exists(path + @"\\Errors.xml"))
            {
                var xmlData = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                              <errors>
                              </errors>
                              ";

                document.LoadXml(xmlData);
                document.Save(path + @"\\Errors.xml");
            }
            else
            {
                document.Load(path + @"\\Errors.xml");
            }

            XmlElement root = document.DocumentElement;

            XmlError error = new XmlError
            {
                Error = $"{ ex.Message }",
                FechaError = DateTime.Now.ToString(CultureInfo.CurrentCulture),
                TipoError = ex.GetType().Name.ToString()
            };

            XmlElement e1 = document.CreateElement("RehueException");
            e1.InnerText = JsonSerializer.Serialize(error);
            root?.InsertAfter(e1, root.LastChild);

            document.Save(path + @"\\Errors.xml");
        }
        public static List<XmlError> ObtenerErrores()
        {
            string path = @"C:\Rehue\Logs";
            XmlDocument document = new XmlDocument();
            document.Load(path + @"\\Errors.xml");

            List<XmlError> errores = new List<XmlError>();

            foreach (XmlNode item in document.DocumentElement.ChildNodes)
            {
                errores.Add(JsonSerializer.Deserialize<XmlError>(item.InnerText));
            }

            return errores;
        }
    }
}
