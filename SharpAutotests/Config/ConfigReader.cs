using NUnit.Framework;
using SharpAutotests.Utils;
using System;
using System.IO;

namespace SharpAutotests.Config
{
    class ConfigReader
    {
        public static Settings GetFrameworkSettings()
        {
            var configFile = TestContext.Parameters["configFileName"];
            if (string.IsNullOrEmpty(configFile))
            {
                configFile = "ChromeConfig.xml";
            }
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\" + $"\\Config\\{configFile}";

            string xmlInputData = File.ReadAllText(path);
            return SerializerXML.Deserialize<Settings>(xmlInputData);
        }

    }
}
