using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LD.Utilities.xml
{
    public static class XMLUtilities
    {
        /// <summary>
        /// Convierte un xml string en el objeto indicado
        /// </summary>
        /// <typeparam name="T">Clase a mapear</typeparam>
        /// <param name="xml">string del xml</param>
        /// <returns>xml mapeado a la clase</returns>
        public static T convertXMLtoObject<T>(string xml)
        {
            var myObject = default(T);
            try
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(T));
                using (TextReader reader = new StringReader(xml))
                {
                    myObject = (T)mySerializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            { }
            return myObject;
        }
    }
}
