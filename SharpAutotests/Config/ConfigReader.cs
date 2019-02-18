using SharpAutotests.Utils;
using System;
using System.IO;

namespace SharpAutotests.Config
{
    class ConfigReader
    {
        public static Settings GetFrameworkSettings()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\" + "\\Config\\FirefoxRemoteConfig.xml";
            string xmlInputData = File.ReadAllText(path);
            return SerializerXML.Deserialize<Settings>(xmlInputData);
        }

    }
}
