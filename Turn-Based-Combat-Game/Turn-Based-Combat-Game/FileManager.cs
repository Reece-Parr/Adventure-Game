using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Turn_Based_Combat_Game
{
    public static class FileManager
    {
        public static string Save<T>(T data)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));
            StringWriter write = new StringWriter();
            xml.Serialize(write, data);
            return write.ToString();
        }

        public static T Load<T>(string xmlString) 
        {
            try
            {
                StringReader outStream = new StringReader(xmlString);
                XmlSerializer xml = new XmlSerializer(typeof(T));
                return (T)xml.Deserialize(outStream);
            }
            catch (Exception e)
            {
                throw new Exception("File Manager caught an Exception: ", e);
            }
        }
    }
}
