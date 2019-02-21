using SharpAutotests.Utils;
using System;
using System.IO;

namespace SharpAutotests.Config
{
    class ConfigReader
    {
        public static Settings GetFrameworkSettings()
        {
            var configFile = Environment.GetEnvironmentVariable("CONFIGTOUSE", EnvironmentVariableTarget.User);
            if(string.IsNullOrEmpty(configFile))
            {
                configFile = "GlobalConfig.xml";
            }
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\" + $"\\Config\\{configFile}";
            string xmlInputData = File.ReadAllText(path);
            return SerializerXML.Deserialize<Settings>(xmlInputData);
        }

    }
}
