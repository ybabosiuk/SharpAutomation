using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;

namespace SharpAutotests.Utils
{
    class SerializerXML
    {
        public static T Deserialize<T>(string input) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StringReader stringReader = new StringReader(input))
            {
                return (T)ser.Deserialize(stringReader);
            }
        }

        public static string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                return textWriter.ToString();
            }
        }
    }
}
