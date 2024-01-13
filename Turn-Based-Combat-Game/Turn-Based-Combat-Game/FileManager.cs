using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Turn_Based_Combat_Game
{
    public static class FileManager
    {
        public static StreamWriter Save<T>(T data, string filePath)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));
            StreamWriter write = new StreamWriter($"{filePath}.xml");
            xml.Serialize(write, data);
            write.Close();
            return write;
        }

        public static T Load<T>(string filePath)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                var myFileStream = new FileStream($"{filePath}.xml", FileMode.Open);
                return (T)xml.Deserialize(myFileStream);
            }
            catch (Exception e)
            {
                throw new Exception("File Manager caught an Exception: ", e);
            }
        }
    }
}
